using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Pathfinding;
using UnityEngine;

[AddComponentMenu("Pathfinding/Pathfinder")]
public class AstarPath : MonoBehaviour
{
	public enum PathfindingStatus
	{
		None = 0,
		Searching = 1,
		Waiting = 2,
		Locking = 3,
		SearchLoop = 4
	}

	public static readonly bool HasPro = false;

	public AstarData astarData;

	public bool showGraphs;

	public bool showNavGraphs = true;

	public bool showUnwalkableNodes = true;

	public bool scanOnStartup = true;

	public bool prioritizeGraphs;

	public float prioritizeGraphsLimit = 1f;

	public AstarColor colorSettings;

	public static int PathsCompleted = 0;

	public static long TotalSearchedNodes = 0L;

	public static long TotalSearchTime = 0L;

	public float lastScanTime;

	public static OnVoidDelegate OnAwakeSettings;

	public static OnGraphDelegate OnGraphPreScan;

	public static OnGraphDelegate OnGraphPostScan;

	public static OnPathDelegate OnPathPreSearch;

	public static OnPathDelegate OnPathPostSearch;

	public static OnScanDelegate OnPreScan;

	public static OnScanDelegate OnPostScan;

	public static OnScanDelegate OnLatePostScan;

	public static OnScanDelegate OnGraphsUpdated;

	public static OnVoidDelegate OnSafeNodeUpdate;

	public float startUpdate;

	public static OnPathDelegate OnGraphUpdate;

	[NonSerialized]
	public Stack<GraphUpdateObject> graphUpdateStack;

	[NonSerialized]
	public Stack<Node> floodStack;

	public int lastUniqueAreaIndex;

	public Heuristic heuristic = Heuristic.Euclidean;

	public float heuristicScale = 1f;

	public Path debugPath;

	public string inGameDebugPath;

	public GraphDebugMode debugMode;

	public float debugFloor;

	public float debugRoof = 10000f;

	public bool showSearchTree;

	public bool stepByStep = true;

	private bool acceptNewPaths = true;

	public readonly bool useMultithreading;

	public static Path pathQueueEnd;

	public static Path pathQueueStart;

	public static Path pathReturnQueueStart;

	public static bool missedPathQueueIncrement = false;

	[NonSerialized]
	public static Thread activeThread;

	public float maxFrameTime = 1f;

	public static bool isCalculatingPaths = false;

	[NonSerialized]
	public BinaryHeap binaryHeap;

	public int binaryHeapSize = 5000;

	public bool recyclePaths;

	public int minAreaSize = 10;

	[NonSerialized]
	public static object lockObject = new object();

	public static AstarPath _active;

	public static bool _activeSet = false;

	public PathLog logPathResults = PathLog.Normal;

	public static Stack<Path> PathPool;

	private int nextFreePathID = 1;

	public static PathfindingStatus pathfindingStatus = PathfindingStatus.None;

	public OnVoidDelegate OnDrawGizmosCallback;

	public bool limitGraphUpdates = true;

	public float maxGraphUpdateFreq = 0.2f;

	private float lastGraphUpdate = -9999f;

	private bool graphUpdateRoutineRunning;

	public OnVoidDelegate OnGraphsWillBeUpdated;

	public OnVoidDelegate OnGraphsWillBeUpdated2;

	private bool isUpdatingGraphs;

	private bool isRegisteredForUpdate;

	public static Version Version
	{
		get
		{
			return new Version(3, 0, 6);
		}
	}

	public Type[] graphTypes
	{
		get
		{
			return astarData.graphTypes;
		}
	}

	public NavGraph[] graphs
	{
		get
		{
			if (astarData == null)
			{
				astarData = new AstarData();
			}
			return astarData.graphs;
		}
		set
		{
			if (astarData == null)
			{
				astarData = new AstarData();
			}
			astarData.graphs = value;
		}
	}

	public new static AstarPath active
	{
		get
		{
			if (_activeSet)
			{
				return _active;
			}
			return null;
		}
		set
		{
			_activeSet = value != null;
			_active = value;
		}
	}

	public static Path GetFromPathPool()
	{
		if (active == null)
		{
			throw new NullReferenceException("There is no active AstarPath object in the scene");
		}
		if (active.recyclePaths)
		{
			if (PathPool == null)
			{
				PathPool = new Stack<Path>(10);
				return new Path();
			}
			if (PathPool.Count > 0)
			{
				return PathPool.Pop();
			}
			return new Path();
		}
		return new Path();
	}

	public static void AddToPathPool(Path p)
	{
		if (active.recyclePaths)
		{
			if (PathPool == null)
			{
				PathPool = new Stack<Path>(16);
			}
			PathPool.Push(p);
		}
	}

	public int GetNextPathID()
	{
		if (nextFreePathID > 65535)
		{
			nextFreePathID = 1;
			StartPath(new CleanupPath65K());
		}
		return nextFreePathID++;
	}

	public static void SetPathfindingStatus(PathfindingStatus s)
	{
		pathfindingStatus = s;
	}

	public void OnDrawGizmos()
	{
		if (active == null)
		{
			active = this;
		}
		else if (active != this)
		{
			return;
		}
		if (graphs == null)
		{
			return;
		}
		for (int i = 0; i < graphs.Length; i++)
		{
			if (graphs[i] != null)
			{
				graphs[i].OnDrawGizmos(showNavGraphs);
			}
		}
		if (showUnwalkableNodes)
		{
			Gizmos.color = AstarColor.UnwalkableNode;
			for (int j = 0; j < graphs.Length; j++)
			{
				if (graphs[j] == null || graphs[j].nodes == null)
				{
					continue;
				}
				Node[] nodes = graphs[j].nodes;
				for (int k = 0; k < nodes.Length; k++)
				{
					if (!nodes[k].walkable)
					{
						Gizmos.DrawCube(nodes[k].position, Vector3.one * 0.3f);
					}
				}
			}
		}
		if (OnDrawGizmosCallback != null)
		{
			OnDrawGizmosCallback();
		}
	}

	public void OnGUI()
	{
		if (Input.GetKey("l"))
		{
			GUI.Label(new Rect(Screen.width - 100, 5f, 100f, 25f), (1f / Time.smoothDeltaTime).ToString("0") + " fps");
		}
		if (logPathResults == PathLog.InGame && inGameDebugPath != string.Empty)
		{
			GUI.Label(new Rect(5f, 5f, 400f, 600f), inGameDebugPath);
		}
	}

	public static void AstarLog(string s)
	{
		if (active == null)
		{
			Debug.Log("No AstarPath object was found : " + s);
		}
		else if (active.logPathResults != PathLog.None && active.logPathResults != PathLog.OnlyErrors)
		{
			Debug.Log(s);
		}
	}

	public static void AstarLogError(string s)
	{
		if (active == null)
		{
			Debug.Log("No AstarPath object was found : " + s);
		}
		else if (active.logPathResults != PathLog.None)
		{
			Debug.LogError(s);
		}
	}

	public void LogPathResults(Path p)
	{
		if (logPathResults != PathLog.None)
		{
			string message = p.DebugString(logPathResults);
			if (logPathResults == PathLog.InGame)
			{
				inGameDebugPath = message;
			}
			else
			{
				Debug.Log(message);
			}
		}
	}

	public void UpdateGraphs(Bounds bounds)
	{
		UpdateGraphs(new GraphUpdateObject(bounds));
	}

	public IEnumerator DelayedGraphUpdate()
	{
		graphUpdateRoutineRunning = true;
		yield return new WaitForSeconds(maxGraphUpdateFreq - (Time.realtimeSinceStartup - lastGraphUpdate));
		if (useMultithreading)
		{
			lock (lockObject)
			{
				DoUpdateGraphs();
			}
		}
		else if (!isRegisteredForUpdate)
		{
			isRegisteredForUpdate = true;
			OnGraphUpdate = (OnPathDelegate)Delegate.Combine(OnGraphUpdate, new OnPathDelegate(DoUpdateGraphs));
		}
		graphUpdateRoutineRunning = false;
	}

	public void UpdateGraphs(GraphUpdateObject ob)
	{
		if (graphUpdateStack == null)
		{
			graphUpdateStack = new Stack<GraphUpdateObject>();
		}
		graphUpdateStack.Push(ob);
		if (isUpdatingGraphs)
		{
			return;
		}
		if (limitGraphUpdates && Time.realtimeSinceStartup - lastGraphUpdate < maxGraphUpdateFreq)
		{
			if (!graphUpdateRoutineRunning)
			{
				StartCoroutine(DelayedGraphUpdate());
			}
			return;
		}
		if (useMultithreading)
		{
			lock (lockObject)
			{
				DoUpdateGraphs();
				return;
			}
		}
		if (!isRegisteredForUpdate)
		{
			isRegisteredForUpdate = true;
			OnGraphUpdate = (OnPathDelegate)Delegate.Combine(OnGraphUpdate, new OnPathDelegate(DoUpdateGraphs));
		}
	}

	private void DoUpdateGraphs(Path p)
	{
		OnGraphUpdate = (OnPathDelegate)Delegate.Remove(OnGraphUpdate, new OnPathDelegate(DoUpdateGraphs));
		isRegisteredForUpdate = false;
		DoUpdateGraphs();
	}

	private void DoUpdateGraphs()
	{
		isUpdatingGraphs = true;
		lastGraphUpdate = Time.realtimeSinceStartup;
		if (OnGraphsWillBeUpdated2 != null)
		{
			OnVoidDelegate onGraphsWillBeUpdated = OnGraphsWillBeUpdated2;
			OnGraphsWillBeUpdated2 = null;
			onGraphsWillBeUpdated();
		}
		if (OnGraphsWillBeUpdated != null)
		{
			OnVoidDelegate onGraphsWillBeUpdated2 = OnGraphsWillBeUpdated;
			OnGraphsWillBeUpdated = null;
			onGraphsWillBeUpdated2();
		}
		if (graphUpdateStack != null)
		{
			while (graphUpdateStack.Count > 0)
			{
				GraphUpdateObject o = graphUpdateStack.Pop();
				foreach (IUpdatableGraph updateableGraph in astarData.GetUpdateableGraphs())
				{
					updateableGraph.UpdateArea(o);
				}
			}
		}
		isUpdatingGraphs = false;
		FloodFill();
		if (OnGraphsUpdated != null)
		{
			OnGraphsUpdated(this);
		}
	}

	public void RegisterCanUpdateGraphs(OnVoidDelegate callback, OnVoidDelegate callback2 = null)
	{
		OnGraphsWillBeUpdated = (OnVoidDelegate)Delegate.Combine(OnGraphsWillBeUpdated, callback);
		if (callback2 != null)
		{
			OnGraphsWillBeUpdated2 = (OnVoidDelegate)Delegate.Combine(OnGraphsWillBeUpdated2, callback2);
		}
		if (limitGraphUpdates && Time.realtimeSinceStartup - lastGraphUpdate < maxGraphUpdateFreq)
		{
			if (!graphUpdateRoutineRunning)
			{
				StartCoroutine(DelayedGraphUpdate());
			}
			return;
		}
		if (useMultithreading)
		{
			lock (lockObject)
			{
				DoUpdateGraphs();
				return;
			}
		}
		if (!isRegisteredForUpdate)
		{
			isRegisteredForUpdate = true;
			OnGraphUpdate = (OnPathDelegate)Delegate.Combine(OnGraphUpdate, new OnPathDelegate(DoUpdateGraphs));
		}
	}

	public void LogProfiler()
	{
	}

	public void ResetProfiler()
	{
	}

	public void Awake()
	{
		active = this;
		if (OnAwakeSettings != null)
		{
			OnAwakeSettings();
		}
		Initialize();
		if (scanOnStartup && (!astarData.cacheStartup || astarData.data_cachedStartup == null))
		{
			Scan();
		}
	}

	public void SetUpReferences()
	{
		active = this;
		if (astarData == null)
		{
			astarData = new AstarData();
		}
		if (astarData.userConnections == null)
		{
			astarData.userConnections = new UserConnection[0];
		}
		if (colorSettings == null)
		{
			colorSettings = new AstarColor();
		}
		colorSettings.OnEnable();
	}

	public void Initialize()
	{
		SetUpReferences();
		astarData.FindGraphTypes();
		binaryHeap = new BinaryHeap(binaryHeapSize);
		astarData.Awake();
		for (int i = 0; i < astarData.graphs.Length; i++)
		{
			astarData.graphs[i].Awake();
		}
	}

	public void OnDestroy()
	{
		Debug.Log("+++ Destroyed - Cleaning Up Pathfinding Data +++");
		if (activeThread != null)
		{
			activeThread.Abort();
			activeThread = null;
		}
		isCalculatingPaths = false;
		Debug.Log("Destroying Graphs");
		if (astarData.graphs != null)
		{
			for (int i = 0; i < astarData.graphs.Length; i++)
			{
				astarData.graphs[i].OnDestroy();
			}
		}
		astarData.graphs = null;
		Debug.Log("Returning Paths");
		acceptNewPaths = false;
		if (useMultithreading)
		{
			while (pathReturnQueueStart != null)
			{
				Path path = pathReturnQueueStart;
				path.error = true;
				path.errorLog = "Canceled because AstarPath object was destroyed";
				path.ReturnPath();
				if (path.next != null)
				{
					pathReturnQueueStart = path.next;
					continue;
				}
				break;
			}
		}
		else
		{
			while (pathQueueStart != null)
			{
				Path path2 = pathQueueStart;
				path2.error = true;
				path2.errorLog = "Canceled because AstarPath object was destroyed";
				path2.ReturnPath();
				if (path2.next != null)
				{
					pathQueueStart = path2.next;
					continue;
				}
				break;
			}
		}
		if (pathQueueStart != null)
		{
			pathQueueStart.next = null;
			pathQueueStart.error = true;
			pathQueueStart.callback = null;
		}
		Debug.Log("Cleaning up variables");
		floodStack = null;
		graphUpdateStack = null;
		binaryHeap = null;
		pathQueueEnd = null;
		pathQueueStart = null;
		pathReturnQueueStart = null;
		missedPathQueueIncrement = false;
		OnGraphPreScan = null;
		OnGraphPostScan = null;
		OnPathPreSearch = null;
		OnPathPostSearch = null;
		OnPreScan = null;
		OnPostScan = null;
		OnGraphUpdate = null;
		OnGraphsUpdated = null;
		PathsCompleted = 0;
		active = null;
	}

	public void FloodFill(Node seed)
	{
		FloodFill(seed, lastUniqueAreaIndex + 1);
		lastUniqueAreaIndex++;
	}

	public void FloodFill(Node seed, int area)
	{
		if (area > 255)
		{
			Debug.LogError("Too high area index - The maximum area index is 255");
			return;
		}
		if (area < 0)
		{
			Debug.LogError("Too low area index - The minimum area index is 0");
			return;
		}
		if (floodStack == null)
		{
			floodStack = new Stack<Node>(1024);
		}
		Stack<Node> stack = floodStack;
		stack.Clear();
		stack.Push(seed);
		seed.area = area;
		while (stack.Count > 0)
		{
			stack.Pop().FloodFill(stack, area);
		}
	}

	public void FloodFill()
	{
		if (astarData.graphs == null)
		{
			return;
		}
		int num = 0;
		lastUniqueAreaIndex = 0;
		if (floodStack == null)
		{
			floodStack = new Stack<Node>(1024);
		}
		Stack<Node> stack = floodStack;
		for (int i = 0; i < graphs.Length; i++)
		{
			NavGraph navGraph = graphs[i];
			if (navGraph.nodes != null)
			{
				for (int j = 0; j < navGraph.nodes.Length; j++)
				{
					navGraph.nodes[j].area = 0;
				}
			}
		}
		int num2 = 0;
		for (int k = 0; k < graphs.Length; k++)
		{
			NavGraph navGraph2 = graphs[k];
			if (navGraph2.nodes == null)
			{
				Debug.LogWarning("Graph " + k + " has not defined any nodes");
				continue;
			}
			for (int l = 0; l < navGraph2.nodes.Length; l++)
			{
				if (!navGraph2.nodes[l].walkable || navGraph2.nodes[l].area != 0)
				{
					continue;
				}
				num++;
				if (num > 255)
				{
					Debug.LogError("Too many areas - The maximum number of areas is 256");
					num--;
					break;
				}
				stack.Clear();
				stack.Push(navGraph2.nodes[l]);
				int num3 = 1;
				navGraph2.nodes[l].area = num;
				while (stack.Count > 0)
				{
					num3++;
					stack.Pop().FloodFill(stack, num);
				}
				if (num3 < minAreaSize)
				{
					stack.Clear();
					stack.Push(navGraph2.nodes[l]);
					navGraph2.nodes[l].area = 254;
					while (stack.Count > 0)
					{
						stack.Pop().FloodFill(stack, 254);
					}
					num2++;
					num--;
				}
			}
		}
		lastUniqueAreaIndex = num;
		if (num2 > 0)
		{
			AstarLog(num2 + " small areas were detected (fewer than " + minAreaSize + " nodes),these might have the same IDs as other areas, but it shouldn't affect pathfinding in any significant way (you might get All Nodes Searched as a reason for path failure).\nWhich areas are defined as 'small' is controlled by the 'Min Area Size' variable, it can be changed in the A* inspector-->Settings-->Min Area Size\nThe small areas will use the area id 254");
		}
	}

	public void AutoScan()
	{
		if (!Application.isPlaying && lastScanTime < 0.11f)
		{
			Scan();
		}
	}

	public void Scan()
	{
		IEnumerator<Progress> enumerator = ScanLoop().GetEnumerator();
		while (enumerator.MoveNext())
		{
		}
	}

	public IEnumerable<Progress> ScanLoop()
	{
		if (graphs == null)
		{
			yield break;
		}
		yield return new Progress(0.05f, "Pre processing graphs");
		if (OnPreScan != null)
		{
			OnPreScan(this);
		}
		DateTime startTime = DateTime.UtcNow;
		for (int i = 0; i < graphs.Length; i++)
		{
			NavGraph graph = graphs[i];
			if (OnGraphPreScan != null)
			{
				yield return new Progress(Mathfx.MapTo(0.05f, 0.9f, ((float)i + 0.5f) / (float)(graphs.Length + 1)), "Scanning graph " + (i + 1) + " of " + graphs.Length + " - Pre processing");
				OnGraphPreScan(graph);
			}
			yield return new Progress(Mathfx.MapTo(0.05f, 0.9f, ((float)i + 1f) / (float)(graphs.Length + 1)), "Scanning graph " + (i + 1) + " of " + graphs.Length);
			graph.Scan();
			yield return new Progress(Mathfx.MapTo(0.05f, 0.9f, ((float)i + 1.1f) / (float)(graphs.Length + 1)), "Scanning graph " + (i + 1) + " of " + graphs.Length + " - Assigning graph indices");
			if (graph.nodes != null)
			{
				for (int j = 0; j < graph.nodes.Length; j++)
				{
					graph.nodes[j].graphIndex = i;
				}
			}
			if (OnGraphPostScan != null)
			{
				yield return new Progress(Mathfx.MapTo(0.05f, 0.9f, ((float)i + 1.5f) / (float)(graphs.Length + 1)), "Scanning graph " + (i + 1) + " of " + graphs.Length + " - Post processing");
				OnGraphPostScan(graph);
			}
		}
		yield return new Progress(0.9f, "Post processing graphs");
		if (OnPostScan != null)
		{
			OnPostScan(this);
		}
		yield return new Progress(0.9f, "Applying links");
		ApplyLinks();
		yield return new Progress(0.95f, "Computing areas");
		FloodFill();
		yield return new Progress(0.9f, "Late post processing");
		if (OnLatePostScan != null)
		{
			OnLatePostScan(this);
		}
		lastScanTime = (float)(DateTime.UtcNow - startTime).TotalSeconds;
		Debug.Log("Scanning - Process took " + (lastScanTime * 1000f).ToString("0") + " ms to complete ");
	}

	public void ApplyLinks()
	{
		for (int i = 0; i < astarData.userConnections.Length; i++)
		{
			UserConnection userConnection = astarData.userConnections[i];
			Node node = GetNearest(userConnection.p1);
			Node node2 = GetNearest(userConnection.p2);
			if (node != null && node2 != null)
			{
				int cost = ((!userConnection.doOverrideCost) ? (node.position - node2.position).costMagnitude : userConnection.overrideCost);
				node.AddConnection(node2, cost);
				if (!userConnection.oneWay)
				{
					node2.AddConnection(node, cost);
				}
			}
		}
	}

	public static void RegisterSafeNodeUpdate(OnVoidDelegate callback)
	{
		if (callback != null)
		{
			if (isCalculatingPaths)
			{
				OnSafeNodeUpdate = (OnVoidDelegate)Delegate.Combine(OnSafeNodeUpdate, callback);
			}
			else
			{
				callback();
			}
		}
	}

	public static void RegisterThreadSafeNodeUpdate(OnVoidDelegate callback)
	{
		if (callback == null)
		{
			return;
		}
		if (isCalculatingPaths)
		{
			if (active.useMultithreading)
			{
				lock (lockObject)
				{
					callback();
					return;
				}
			}
			OnSafeNodeUpdate = (OnVoidDelegate)Delegate.Combine(OnSafeNodeUpdate, callback);
		}
		else
		{
			callback();
		}
	}

	public static IEnumerator DelayedPathReturn(Path p)
	{
		yield return 0;
		p.ReturnPath();
	}

	public static void StartPath(Path p)
	{
		if (active == null)
		{
			Debug.LogError("There is no AstarPath object in the scene");
			return;
		}
		if (!active.acceptNewPaths)
		{
			p.error = true;
			p.errorLog += "No new paths are accepted";
			p.ReturnPath();
			return;
		}
		if (active.graphs == null || active.graphs.Length == 0)
		{
			Debug.LogError("There are no graphs in the scene");
			p.error = true;
			p.errorLog = "There are no graphs in the scene";
			p.ReturnPath();
			return;
		}
		if (pathQueueEnd == null)
		{
			Debug.Log("Initializing Path Queue...");
			pathQueueEnd = p;
			pathQueueStart = p;
			if (active.useMultithreading)
			{
				pathReturnQueueStart = p;
			}
		}
		else
		{
			pathQueueEnd.next = p;
			pathQueueEnd = p;
			if (pathQueueStart == null)
			{
				pathQueueStart = p;
			}
		}
		if (!isCalculatingPaths)
		{
			Debug.Log("Starting Pathfinder...");
			active.StartCoroutine(CalculatePaths());
		}
	}

	public static IEnumerator CalculatePaths()
	{
		isCalculatingPaths = true;
		float ptf = 0f;
		int framesWithNoPaths = 0;
		Path p = pathQueueStart;
		if (missedPathQueueIncrement)
		{
			missedPathQueueIncrement = false;
			if (pathQueueStart.next == null)
			{
				Debug.LogError("Error : No path was added to the queue, but the pathfinding was started");
				yield break;
			}
			pathQueueStart = pathQueueStart.next;
			p = pathQueueStart;
		}
		while (p != null)
		{
			framesWithNoPaths = 0;
			if (ptf >= active.maxFrameTime)
			{
				yield return 0;
				ptf = 0f;
			}
			bool skip = false;
			if (p.processed)
			{
				skip = true;
				p.error = true;
				p.errorLog += "Calling pathfinding with an already processed path";
				Debug.LogError(p.errorLog);
			}
			if (!skip)
			{
				if (OnPathPreSearch != null)
				{
					OnPathPreSearch(p);
				}
				if (OnGraphUpdate != null)
				{
					OnGraphUpdate(p);
				}
				if (OnSafeNodeUpdate != null)
				{
					OnSafeNodeUpdate();
					OnSafeNodeUpdate = null;
				}
				p.Prepare();
				if (!p.error)
				{
					if (OnPathPreSearch != null)
					{
						OnPathPreSearch(p);
					}
					active.debugPath = p;
					p.Initialize();
					ptf += p.duration + 0.1f;
					if (!p.error && !p.foundEnd)
					{
						ptf += p.CalculateStep(active.maxFrameTime - ptf);
						p.searchIterations++;
						while (!p.foundEnd && !p.error)
						{
							yield return 0;
							ptf = p.CalculateStep(active.maxFrameTime);
							p.searchIterations++;
						}
					}
					if (OnPathPostSearch != null)
					{
						OnPathPostSearch(p);
					}
				}
				else
				{
					ptf += p.duration + 0.05f;
				}
				PathsCompleted++;
				if (p.pathID > 2)
				{
					TotalSearchedNodes += p.searchedNodes;
					TotalSearchTime += (long)Math.Round(p.duration * 10000f);
				}
				if (OnPathPostSearch != null)
				{
					OnPathPostSearch(p);
				}
				p.processed = true;
				p.ReturnPath();
				active.LogPathResults(p);
			}
			while (pathQueueStart.next == null)
			{
				ptf = 0f;
				framesWithNoPaths++;
				if (OnSafeNodeUpdate != null)
				{
					OnSafeNodeUpdate();
					OnSafeNodeUpdate = null;
				}
				if (OnGraphUpdate != null)
				{
					OnGraphUpdate(p);
				}
				if (framesWithNoPaths > 5000)
				{
					missedPathQueueIncrement = true;
					isCalculatingPaths = false;
					yield break;
				}
				yield return 0;
			}
			Path tmp = pathQueueStart;
			pathQueueStart = pathQueueStart.next;
			p = pathQueueStart;
			tmp.next = null;
		}
		Debug.LogError("Error : This part should never be reached");
		isCalculatingPaths = false;
	}

	public NNInfo GetNearest(Vector3 position, NNConstraint constraint = null, Node hint = null)
	{
		if (graphs == null)
		{
			return null;
		}
		if (constraint == null)
		{
			constraint = NNConstraint.None;
		}
		float num = float.PositiveInfinity;
		NNInfo result = default(NNInfo);
		int num2 = 0;
		for (int i = 0; i < graphs.Length; i++)
		{
			NavGraph navGraph = graphs[i];
			NNInfo nearest = navGraph.GetNearest(position, constraint);
			Node node = nearest.node;
			if (node != null)
			{
				float magnitude = (nearest.clampedPosition - position).magnitude;
				if (prioritizeGraphs && magnitude < prioritizeGraphsLimit)
				{
					num = magnitude * (float)nearest.priority;
					result = nearest;
					num2 = i;
					break;
				}
				if (magnitude * (float)nearest.priority < num)
				{
					num = magnitude * (float)nearest.priority;
					result = nearest;
					num2 = i;
				}
			}
		}
		if (result.node != null && !constraint.Suitable(result.node))
		{
			if (result.constrainedNode != null)
			{
				result.node = result.constrainedNode;
				result.clampedPosition = result.constClampedPosition;
			}
			else
			{
				NNInfo nearestForce = graphs[num2].GetNearestForce(position, constraint);
				if (nearestForce.node != null)
				{
					result = nearestForce;
				}
			}
		}
		return result;
	}

	public Node GetNearest(Ray ray)
	{
		if (graphs == null)
		{
			return null;
		}
		float num = float.PositiveInfinity;
		Node result = null;
		Vector3 direction = ray.direction;
		Vector3 origin = ray.origin;
		for (int i = 0; i < graphs.Length; i++)
		{
			NavGraph navGraph = graphs[i];
			Node[] nodes = navGraph.nodes;
			if (nodes == null)
			{
				continue;
			}
			foreach (Node node in nodes)
			{
				Vector3 vector = node.position;
				Vector3 vector2 = origin + Vector3.Dot(vector - origin, direction) * direction;
				float num2 = Mathf.Abs(vector2.x - vector.x);
				num2 *= num2;
				if (num2 > num)
				{
					continue;
				}
				num2 = Mathf.Abs(vector2.z - vector.z);
				num2 *= num2;
				if (!(num2 > num))
				{
					float sqrMagnitude = (vector2 - vector).sqrMagnitude;
					if (sqrMagnitude < num)
					{
						num = sqrMagnitude;
						result = node;
					}
				}
			}
		}
		return result;
	}

	public AstarSerializer Savex(NavGraph graph, bool runtime)
	{
		float realtimeSinceStartup = Time.realtimeSinceStartup;
		if (isCalculatingPaths)
		{
			Debug.LogWarning("The script is currently calculating paths, the serialization can interfere with the pathfinding");
		}
		for (int i = 0; i < graphs.Length; i++)
		{
			NavGraph navGraph = graphs[i];
			if (navGraph.nodes != null)
			{
				for (int j = 0; j < navGraph.nodes.Length; j++)
				{
					navGraph.nodes[j].g = j;
					navGraph.nodes[j].h = i;
				}
			}
		}
		AstarSerializer astarSerializer = new AstarSerializer(this);
		astarSerializer.compress = astarData.compress;
		if (runtime)
		{
			astarSerializer.Close();
		}
		Debug.Log("Saving took " + (Time.realtimeSinceStartup - realtimeSinceStartup).ToString("0.00") + " s to complete");
		return astarSerializer;
	}

	public AstarSerializer Loadx(bool runtime, out NavGraph graph)
	{
		return Loadx(runtime, out graph, null);
	}

	public AstarSerializer Loadx(bool runtime, out NavGraph graph, AstarSerializer.DeSerializationInterrupt interrupt)
	{
		float realtimeSinceStartup = Time.realtimeSinceStartup;
		AstarSerializer astarSerializer = new AstarSerializer(this);
		if (runtime)
		{
			astarSerializer.Close();
		}
		graph = null;
		Debug.Log("Loading took " + (Time.realtimeSinceStartup - realtimeSinceStartup) + " s to complete");
		return astarSerializer;
	}
}
