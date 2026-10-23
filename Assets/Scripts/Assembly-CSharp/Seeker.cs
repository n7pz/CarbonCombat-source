using System;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

[AddComponentMenu("Pathfinding/Seeker")]
public class Seeker : MonoBehaviour
{
	public enum ModifierPass
	{
		PreProcess = 0,
		PostProcessOriginal = 1,
		PostProcess = 2
	}

	public bool drawGizmos = true;

	public bool detailedGizmos;

	public StartEndModifier startEndModifier = new StartEndModifier();

	public OnPathDelegate pathCallback;

	public OnPathDelegate preProcessPath;

	public OnPathDelegate postProcessOriginalPath;

	public OnPathDelegate postProcessPath;

	public GetNextTargetDelegate getNextTarget;

	[NonSerialized]
	public Vector3[] lastCompletedVectorPath;

	[NonSerialized]
	public Node[] lastCompletedNodePath;

	[NonSerialized]
	public Path path;

	public bool saveGetNearestHints = true;

	private Node startHint;

	private Node endHint;

	private OnPathDelegate tmpPathCallback;

	private List<IPathModifier> modifiers = new List<IPathModifier>();

	private int lastPathID;

	public void Awake()
	{
		startEndModifier.Awake(this);
	}

	public void OnDestroy()
	{
		startEndModifier.OnDestroy(this);
	}

	public void RegisterModifier(IPathModifier mod)
	{
		if (modifiers == null)
		{
			modifiers = new List<IPathModifier>(1);
		}
		modifiers.Add(mod);
	}

	public void DeregisterModifier(IPathModifier mod)
	{
		if (modifiers != null)
		{
			modifiers.Remove(mod);
		}
	}

	public void RunModifiers(ModifierPass pass, Path p)
	{
		bool flag = true;
		while (flag)
		{
			flag = false;
			for (int i = 0; i < modifiers.Count - 1; i++)
			{
				if (modifiers[i].Priority < modifiers[i + 1].Priority)
				{
					IPathModifier value = modifiers[i];
					modifiers[i] = modifiers[i + 1];
					modifiers[i + 1] = value;
					flag = true;
				}
			}
		}
		switch (pass)
		{
		case ModifierPass.PreProcess:
			if (preProcessPath != null)
			{
				preProcessPath(p);
			}
			break;
		case ModifierPass.PostProcessOriginal:
			if (postProcessOriginalPath != null)
			{
				postProcessOriginalPath(p);
			}
			break;
		case ModifierPass.PostProcess:
			if (postProcessPath != null)
			{
				postProcessPath(p);
			}
			break;
		}
		ModifierData modifierData = ModifierData.All;
		for (int j = 0; j < modifiers.Count; j++)
		{
			switch (pass)
			{
			case ModifierPass.PreProcess:
				modifiers[j].PreProcess(p);
				break;
			case ModifierPass.PostProcessOriginal:
				modifiers[j].ApplyOriginal(p);
				break;
			case ModifierPass.PostProcess:
			{
				ModifierData modifierData2 = ModifierConverter.Convert(p, modifierData, modifiers[j].input);
				if (modifierData2 != ModifierData.None)
				{
					modifiers[j].Apply(p, modifierData2);
					modifierData = modifiers[j].output;
					break;
				}
				Debug.Log("Error converting " + ((j <= 0) ? "original" : modifiers[j - 1].GetType().Name) + "'s output to " + modifiers[j].GetType().Name + "'s input");
				modifierData = ModifierData.None;
				break;
			}
			}
			if (modifierData == ModifierData.None)
			{
				break;
			}
		}
	}

	public void OnPathComplete(Path p)
	{
		OnPathComplete(p, true, true);
	}

	public void OnPathComplete(Path p, bool runModifiers, bool sendCallbacks)
	{
		if (this == null || p == null || p != path)
		{
			return;
		}
		startHint = p.startNode;
		endHint = p.endNode;
		if (!path.error && runModifiers)
		{
			RunModifiers(ModifierPass.PostProcessOriginal, path);
			RunModifiers(ModifierPass.PostProcess, path);
		}
		if (sendCallbacks)
		{
			if (tmpPathCallback != null)
			{
				tmpPathCallback(p);
			}
			if (pathCallback != null)
			{
				pathCallback(p);
			}
			lastCompletedNodePath = p.path;
			lastCompletedVectorPath = p.vectorPath;
		}
	}

	public void OnEnable()
	{
	}

	public void OnDisable()
	{
	}

	public void CheckPathValidity(AstarPath active)
	{
	}

	public Path GetNewPath(Vector3 start, Vector3 end)
	{
		Path fromPathPool = AstarPath.GetFromPathPool();
		fromPathPool.Reset(start, end, null);
		return fromPathPool;
	}

	public Path StartPath(Vector3 start, Vector3 end, OnPathDelegate callback = null, int graphMask = -1)
	{
		Path newPath = GetNewPath(start, end);
		return StartPath(newPath, callback, graphMask);
	}

	public Path StartPath(Path p, OnPathDelegate callback = null, int graphMask = -1)
	{
		if (path != null && !path.processed && lastPathID == path.pathID)
		{
			Path obj = path;
			obj.errorLog = obj.errorLog + "Canceled path because a new one was requested\nGameObject: " + base.gameObject.name;
			path.error = true;
		}
		path = p;
		Path obj2 = path;
		obj2.callback = (OnPathDelegate)Delegate.Combine(obj2.callback, new OnPathDelegate(OnPathComplete));
		tmpPathCallback = callback;
		if (path.startHint == null)
		{
			path.startHint = startHint;
		}
		if (path.endHint == null)
		{
			path.endHint = endHint;
		}
		lastPathID = path.pathID;
		RunModifiers(ModifierPass.PreProcess, path);
		AstarPath.StartPath(path);
		return path;
	}

	public IEnumerator DelayPathStart(Path p)
	{
		yield return 0;
		RunModifiers(ModifierPass.PreProcess, p);
		AstarPath.StartPath(p);
	}

	public void OnDrawGizmos()
	{
		if (lastCompletedNodePath == null || !drawGizmos)
		{
			return;
		}
		if (detailedGizmos)
		{
			Gizmos.color = new Color(0.7f, 0.5f, 0.1f, 0.5f);
			if (lastCompletedNodePath != null)
			{
				for (int i = 0; i < lastCompletedNodePath.Length - 1; i++)
				{
					Gizmos.DrawLine(lastCompletedNodePath[i].position, lastCompletedNodePath[i + 1].position);
				}
			}
		}
		Gizmos.color = new Color(0f, 1f, 0f, 1f);
		if (lastCompletedVectorPath != null)
		{
			for (int j = 0; j < lastCompletedVectorPath.Length - 1; j++)
			{
				Gizmos.DrawLine(lastCompletedVectorPath[j], lastCompletedVectorPath[j + 1]);
			}
		}
	}
}
