using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Pathfinding
{
	public class Path
	{
		public OnPathDelegate callback;

		[Obsolete]
		public OnPathDelegate preCallback;

		public bool error;

		public string errorLog;

		public bool foundEnd;

		public Node[] path;

		public Vector3[] vectorPath;

		public bool forceStartSnap;

		public bool forceEndSnap;

		protected float maxFrameTime;

		public Node startNode;

		public Node endNode;

		protected Node current;

		public Node startHint;

		public Node endHint;

		public Vector3 originalStartPoint;

		public Vector3 originalEndPoint;

		public Vector3 startPoint;

		public Vector3 endPoint;

		public Int3 startIntPoint;

		public Int3 hTarget;

		public BinaryHeap open;

		public float duration;

		public int searchIterations;

		public int searchedNodes;

		public DateTime callTime;

		public bool processed;

		public bool multithreaded;

		public NNConstraint nnConstraint = PathNNConstraint.Default;

		public Path next;

		public int radius;

		public int walkabilityMask = -1;

		public int height;

		public int turnRadius;

		public int speed;

		public Dictionary<string, int> customData;

		public Heuristic heuristic;

		public float heuristicScale = 1f;

		public int pathID;

		private int[] endNodeCosts;

		public static StringBuilder debugStringBuilder = new StringBuilder();

		public Path()
		{
		}

		public Path(Vector3 start, Vector3 end, OnPathDelegate callbackDelegate)
		{
			Reset(start, end, callbackDelegate, false);
		}

		public void LogError(string msg)
		{
			error = true;
			errorLog += msg;
			if (AstarPath.active.logPathResults != PathLog.None && AstarPath.active.logPathResults != PathLog.InGame)
			{
				Debug.LogWarning(msg);
			}
		}

		public virtual void UpdateStartEnd(Vector3 start, Vector3 end)
		{
			originalStartPoint = start;
			originalEndPoint = end;
			startPoint = start;
			endPoint = end;
			startIntPoint = start;
			hTarget = end;
		}

		public virtual void Reset(Vector3 start, Vector3 end, OnPathDelegate callbackDelegate, bool reset = true)
		{
			if (reset)
			{
				customData = null;
				processed = false;
				vectorPath = null;
				path = null;
				next = null;
				foundEnd = false;
				error = false;
				errorLog = string.Empty;
				callback = null;
				current = null;
				duration = 0f;
				searchIterations = 0;
				searchedNodes = 0;
				startHint = null;
				endHint = null;
			}
			callTime = DateTime.Now;
			callback = callbackDelegate;
			if (AstarPath.active == null || AstarPath.active.graphs == null)
			{
				errorLog += "No NavGraphs have been calculated yet - Don't run any pathfinding calls in Awake";
				if (AstarPath.active.logPathResults != PathLog.None)
				{
					Debug.LogWarning(errorLog);
				}
				error = true;
			}
			else
			{
				pathID = AstarPath.active.GetNextPathID();
				UpdateStartEnd(start, end);
				heuristic = AstarPath.active.heuristic;
				heuristicScale = AstarPath.active.heuristicScale;
			}
		}

		public virtual void Prepare()
		{
			DateTime now = DateTime.Now;
			maxFrameTime = AstarPath.active.maxFrameTime;
			NNInfo nearest = AstarPath.active.GetNearest(startPoint, nnConstraint, startHint);
			PathNNConstraint pathNNConstraint = nnConstraint as PathNNConstraint;
			if (pathNNConstraint != null)
			{
				pathNNConstraint.SetStart(nearest.node);
			}
			NNInfo nearest2 = AstarPath.active.GetNearest(endPoint, nnConstraint, endHint);
			startPoint = nearest.clampedPosition;
			endPoint = nearest2.clampedPosition;
			startIntPoint = startPoint;
			hTarget = endPoint;
			startNode = nearest.node;
			endNode = nearest2.node;
			if (startNode == null || endNode == null)
			{
				LogError("Couldn't find close nodes to either the start or the end (start = " + (startNode != null) + " end = " + (endNode != null) + ")");
				duration += (float)(DateTime.Now.Ticks - now.Ticks) * 0.0001f;
			}
			else if (!startNode.walkable)
			{
				LogError("The node closest to the start point is not walkable");
				duration += (float)(DateTime.Now.Ticks - now.Ticks) * 0.0001f;
			}
			else if (!endNode.walkable)
			{
				LogError("The node closest to the start point is not walkable");
				duration += (float)(DateTime.Now.Ticks - now.Ticks) * 0.0001f;
			}
			else if (startNode.area != endNode.area)
			{
				LogError("There is no valid path to the target (start area: " + startNode.area + ", target area: " + endNode.area + ")");
				duration += (float)(DateTime.Now.Ticks - now.Ticks) * 0.0001f;
			}
			else
			{
				duration += (float)(DateTime.Now.Ticks - now.Ticks) * 0.0001f;
			}
		}

		public virtual void Initialize()
		{
			DateTime now = DateTime.Now;
			open = AstarPath.active.binaryHeap;
			open.numberOfItems = 1;
			if (startNode == endNode)
			{
				endNode.parent = null;
				endNode.h = 0;
				endNode.g = 0;
				Trace(endNode);
				foundEnd = true;
				return;
			}
			endNodeCosts = endNode.InitialOpen(open, hTarget, endPoint, this, false);
			callback = (OnPathDelegate)Delegate.Combine(callback, new OnPathDelegate(ResetCosts));
			Node.activePath = this;
			startNode.pathID = pathID;
			startNode.parent = null;
			startNode.cost = 0;
			startNode.g = startNode.penalty;
			startNode.UpdateH(hTarget, heuristic, heuristicScale);
			startNode.InitialOpen(open, hTarget, startIntPoint, this, true);
			searchedNodes++;
			if (open.numberOfItems <= 1)
			{
				LogError("No open points, the start node didn't open any nodes");
				duration += (float)(DateTime.Now.Ticks - now.Ticks) * 0.0001f;
			}
			else
			{
				current = open.Remove();
				duration += (float)(DateTime.Now.Ticks - now.Ticks) * 0.0001f;
			}
		}

		public virtual float CalculateStep(float remainingFrameTime)
		{
			DateTime now = DateTime.Now;
			long num = (long)(remainingFrameTime * 10000f);
			int num2 = 0;
			while (!foundEnd && !error)
			{
				searchedNodes++;
				if (current == endNode)
				{
					foundEnd = true;
					break;
				}
				current.Open(open, hTarget, this);
				if (open.numberOfItems <= 1)
				{
					LogError("No open points, whole area searched");
					float num3 = (float)(DateTime.Now.Ticks - now.Ticks) * 0.0001f;
					duration += num3;
					return num3;
				}
				current = open.Remove();
				if (num2 > 500)
				{
					if (DateTime.Now.Ticks - now.Ticks > num)
					{
						float num4 = (float)(DateTime.Now.Ticks - now.Ticks) * 0.0001f;
						duration += num4;
						return num4;
					}
					num2 = 0;
				}
				num2++;
			}
			if (foundEnd && !error)
			{
				Trace(endNode);
			}
			float num5 = (float)(DateTime.Now.Ticks - now.Ticks) * 0.0001f;
			duration += num5;
			return num5;
		}

		public void ResetCosts(Path p)
		{
			endNode.ResetCosts(endNodeCosts);
		}

		public virtual void Trace(Node from)
		{
			int num = 0;
			Node node = from;
			while (node != null)
			{
				node = node.parent;
				num++;
				if (num > 1024)
				{
					Debug.LogWarning("Inifinity loop? >1024 node path");
					break;
				}
			}
			path = new Node[num];
			node = from;
			for (int i = 0; i < num; i++)
			{
				if (node == null)
				{
					Debug.LogError("C == NULL");
				}
				path[num - 1 - i] = node;
				node = node.parent;
			}
			vectorPath = new Vector3[num];
			for (int j = 0; j < num; j++)
			{
				if (path[j] == null)
				{
					Debug.LogError("C == NULL " + j + " " + num);
				}
				vectorPath[j] = path[j].position;
			}
		}

		public virtual string DebugString(PathLog logMode)
		{
			if (logMode == PathLog.None || (!error && logMode == PathLog.OnlyErrors))
			{
				return string.Empty;
			}
			debugStringBuilder.Length = 0;
			StringBuilder stringBuilder = debugStringBuilder;
			stringBuilder.Append((!error) ? "Path Completed : " : "Path Failed : ");
			stringBuilder.Append("Computation Time ");
			stringBuilder.Append(duration.ToString((logMode != PathLog.Heavy) ? "0.00" : "0.000"));
			stringBuilder.Append(" ms Searched Nodes ");
			stringBuilder.Append(searchedNodes);
			if (!error)
			{
				stringBuilder.Append(" Path Length ");
				stringBuilder.Append((path != null) ? path.Length.ToString() : "Null");
				if (logMode == PathLog.Heavy)
				{
					stringBuilder.Append("\nSearch Iterations " + searchIterations);
					stringBuilder.Append("\nEnd Node\n\tG: ");
					stringBuilder.Append(endNode.g);
					stringBuilder.Append("\n\tH: ");
					stringBuilder.Append(endNode.h);
					stringBuilder.Append("\n\tF: ");
					stringBuilder.Append(endNode.f);
					stringBuilder.Append("\n\tPoint: ");
					stringBuilder.Append(endPoint.ToString());
					stringBuilder.Append("\n\tGraph: ");
					stringBuilder.Append(endNode.graphIndex);
					stringBuilder.Append("\nStart Node");
					stringBuilder.Append("\n\tPoint: ");
					stringBuilder.Append(endPoint.ToString());
					stringBuilder.Append("\n\tGraph: ");
					stringBuilder.Append(startNode.graphIndex);
					stringBuilder.Append("\nBinary Heap size at completion: ");
					stringBuilder.Append((open != null) ? (open.numberOfItems - 2).ToString() : "Null");
				}
			}
			if (error)
			{
				stringBuilder.Append("\nError: ");
				stringBuilder.Append(errorLog);
			}
			stringBuilder.Append("\nPath Number ");
			stringBuilder.Append(pathID);
			return stringBuilder.ToString();
		}

		public virtual void ReturnPath()
		{
			if (callback != null)
			{
				callback(this);
			}
		}

		public Vector3 GetMovementVector(Vector3 point)
		{
			if (vectorPath == null || vectorPath.Length < 2)
			{
				return Vector3.zero;
			}
			float num = float.PositiveInfinity;
			int num2 = 0;
			for (int i = 0; i < vectorPath.Length - 1; i++)
			{
				Vector3 vector = Mathfx.NearestPointStrict(vectorPath[i], vectorPath[i + 1], point);
				float sqrMagnitude = (vector - point).sqrMagnitude;
				if (sqrMagnitude < num)
				{
					num = sqrMagnitude;
					num2 = i;
				}
			}
			return vectorPath[num2 + 1] - point;
		}
	}
}
