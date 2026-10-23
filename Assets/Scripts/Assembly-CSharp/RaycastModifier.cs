using System;
using System.Collections.Generic;
using System.Diagnostics;
using Pathfinding;
using UnityEngine;

[Serializable]
[AddComponentMenu("Pathfinding/Modifiers/Raycast Simplifier")]
public class RaycastModifier : MonoModifier
{
	public bool useRaycasting = true;

	public LayerMask mask = -1;

	public bool thickRaycast;

	public float thickRaycastRadius;

	public Vector3 raycastOffset = Vector3.zero;

	public bool subdivideEveryIter;

	public int iterations = 2;

	public bool useGraphRaycasting;

	private static List<Vector3> nodes;

	public override ModifierData input
	{
		get
		{
			return ModifierData.Vector;
		}
	}

	public override ModifierData output
	{
		get
		{
			return ModifierData.VectorPath;
		}
	}

	public override void Apply(Path p, ModifierData source)
	{
		if (iterations <= 0)
		{
			return;
		}
		if (nodes == null)
		{
			nodes = new List<Vector3>(p.vectorPath.Length);
		}
		else
		{
			nodes.Clear();
		}
		nodes.AddRange(p.vectorPath);
		for (int i = 0; i < iterations; i++)
		{
			if (subdivideEveryIter && i != 0)
			{
				if (nodes.Capacity < nodes.Count * 3)
				{
					nodes.Capacity = nodes.Count * 3;
				}
				int count = nodes.Count;
				for (int j = 0; j < count - 1; j++)
				{
					nodes.Add(Vector3.zero);
					nodes.Add(Vector3.zero);
				}
				for (int num = count - 1; num > 0; num--)
				{
					Vector3 vector = nodes[num];
					Vector3 to = nodes[num + 1];
					nodes[num * 3] = nodes[num];
					if (num != count - 1)
					{
						nodes[num * 3 + 1] = Vector3.Lerp(vector, to, 0.33f);
						nodes[num * 3 + 2] = Vector3.Lerp(vector, to, 0.66f);
					}
				}
			}
			int num2 = 0;
			while (num2 < nodes.Count - 2)
			{
				Vector3 v = nodes[num2];
				Vector3 v2 = nodes[num2 + 2];
				Stopwatch stopwatch = new Stopwatch();
				stopwatch.Start();
				if (ValidateLine(null, null, v, v2))
				{
					nodes.RemoveAt(num2 + 1);
				}
				else
				{
					num2++;
				}
				stopwatch.Stop();
			}
		}
		p.vectorPath = nodes.ToArray();
	}

	public bool ValidateLine(Node n1, Node n2, Vector3 v1, Vector3 v2)
	{
		if (useRaycasting)
		{
			RaycastHit hitInfo2;
			if (thickRaycast && thickRaycastRadius > 0f)
			{
				RaycastHit hitInfo;
				if (Physics.SphereCast(v1 + raycastOffset, thickRaycastRadius, v2 - v1, out hitInfo, (v2 - v1).magnitude, mask))
				{
					return false;
				}
			}
			else if (Physics.Linecast(v1 + raycastOffset, v2 + raycastOffset, out hitInfo2, mask))
			{
				return false;
			}
		}
		if (useGraphRaycasting && n1 == null)
		{
			n1 = AstarPath.active.GetNearest(v1);
			n2 = AstarPath.active.GetNearest(v2);
		}
		if (useGraphRaycasting && n1 != null && n2 != null)
		{
			NavGraph graph = AstarData.GetGraph(n1);
			NavGraph graph2 = AstarData.GetGraph(n2);
			if (graph != graph2)
			{
				return false;
			}
			if (graph != null)
			{
				IRaycastableGraph raycastableGraph = graph as IRaycastableGraph;
				if (raycastableGraph != null && raycastableGraph.Linecast(v1, v2, n1))
				{
					return false;
				}
			}
		}
		return true;
	}
}
