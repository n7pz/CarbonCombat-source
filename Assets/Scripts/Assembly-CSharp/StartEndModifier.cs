using System;
using Pathfinding;
using UnityEngine;

[Serializable]
public class StartEndModifier : Modifier
{
	public bool addPoints;

	public bool exactStartPoint = true;

	public bool exactEndPoint = true;

	public bool useRaycasting;

	public LayerMask mask = -1;

	public bool useGraphRaycasting;

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
			return (ModifierData)(((!addPoints) ? 4 : 0) | 8);
		}
	}

	public override void Apply(Path p, ModifierData source)
	{
		Vector3 zero = Vector3.zero;
		Vector3 zero2 = Vector3.zero;
		zero = ((!exactStartPoint) ? ((Vector3)p.path[0].position) : GetClampedPoint(p.path[0].position, p.originalStartPoint, p.path[0]));
		zero2 = ((!exactEndPoint) ? ((Vector3)p.path[p.path.Length - 1].position) : GetClampedPoint(p.path[p.path.Length - 1].position, p.originalEndPoint, p.path[p.path.Length - 1]));
		if (!addPoints)
		{
			p.vectorPath[0] = zero;
			p.vectorPath[p.vectorPath.Length - 1] = zero2;
			return;
		}
		Vector3[] array = new Vector3[p.vectorPath.Length + (exactStartPoint ? 1 : 0) + (exactEndPoint ? 1 : 0)];
		if (exactStartPoint)
		{
			array[0] = zero;
		}
		if (exactEndPoint)
		{
			array[array.Length - 1] = zero2;
		}
		int num = (exactStartPoint ? 1 : 0);
		for (int i = 0; i < p.vectorPath.Length; i++)
		{
			array[i + num] = p.vectorPath[i];
		}
		p.vectorPath = array;
	}

	public Vector3 GetClampedPoint(Vector3 from, Vector3 to, Node hint)
	{
		Vector3 vector = to;
		RaycastHit hitInfo;
		if (useRaycasting && Physics.Linecast(from, to, out hitInfo, mask))
		{
			vector = hitInfo.point;
		}
		if (useGraphRaycasting && hint != null)
		{
			NavGraph graph = AstarData.GetGraph(hint);
			if (graph != null)
			{
				IRaycastableGraph raycastableGraph = graph as IRaycastableGraph;
				GraphHitInfo hit;
				if (raycastableGraph != null && raycastableGraph.Linecast(from, vector, hint, out hit))
				{
					vector = hit.point;
				}
			}
		}
		return vector;
	}
}
