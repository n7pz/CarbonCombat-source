using System;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

[Serializable]
[AddComponentMenu("Pathfinding/Modifiers/Funnel")]
public class FunnelModifier : MonoModifier
{
	private static List<Vector3> tmpList;

	private static Int3[] leftFunnel;

	private static Int3[] rightFunnel;

	public static Vector3[] lastLeftFunnel;

	public static Vector3[] lastRightFunnel;

	public override ModifierData input
	{
		get
		{
			return ModifierData.StrictVectorPath;
		}
	}

	public override ModifierData output
	{
		get
		{
			return ModifierData.VectorPath;
		}
	}

	[Obsolete("Don't use this, probably doesn't work")]
	public new static Vector3 GetNextTarget(Path path, Vector3 currPosition)
	{
		return GetNextTarget(path, currPosition, 0f, 0f);
	}

	[Obsolete("Don't use this, probably doesn't work")]
	public static Vector3 GetNextTarget(Path path, Vector3 currPosition, float offset, float pickNextWaypointMargin)
	{
		if (path.error)
		{
			return currPosition;
		}
		Int3 @int = currPosition;
		int num = 0;
		int num2 = path.path.Length;
		INavmesh navmesh = AstarData.GetGraph(path.path[0]) as INavmesh;
		if (navmesh == null)
		{
			Debug.LogError("Couldn't cast graph to the appropriate type (graph isn't a Navmesh type graph, it doesn't implement the INavmesh interface)");
			return currPosition;
		}
		Int3[] vertices = navmesh.vertices;
		MeshNode meshNode = path.path[num2 - 1] as MeshNode;
		if (meshNode == null)
		{
			Debug.LogWarning("Path could not be casted to Mesh Nodes");
			return @int;
		}
		PathNNConstraint pathNNConstraint = PathNNConstraint.Default;
		pathNNConstraint.SetStart(meshNode);
		@int = NavMeshGraph.GetNearestForce(path.path, vertices, currPosition, pathNNConstraint).clampedPosition;
		MeshNode[] array = new MeshNode[num2 - num];
		for (int i = num; i < num2; i++)
		{
			array[i - num] = path.path[i] as MeshNode;
		}
		if (leftFunnel == null || leftFunnel.Length < array.Length + 1)
		{
			leftFunnel = new Int3[array.Length + 1];
		}
		if (rightFunnel == null || rightFunnel.Length < array.Length + 1)
		{
			rightFunnel = new Int3[array.Length + 1];
		}
		int num3 = array.Length + 1;
		leftFunnel[0] = @int;
		rightFunnel[0] = @int;
		leftFunnel[array.Length] = path.endPoint;
		rightFunnel[array.Length] = path.endPoint;
		int num4 = -1;
		int num5 = -1;
		for (int j = 0; j < array.Length - 1; j++)
		{
			MeshNode meshNode2 = array[j];
			MeshNode meshNode3 = array[j + 1];
			bool flag = false;
			int num6 = -1;
			int num7 = -1;
			for (int k = 0; k < 3; k++)
			{
				int num8 = meshNode2[k];
				for (int l = 0; l < 3; l++)
				{
					int num9 = meshNode3[l];
					if (num8 == num9)
					{
						if (flag)
						{
							num7 = num9;
							break;
						}
						num6 = num9;
						flag = true;
					}
				}
			}
			if (num6 == num4)
			{
				leftFunnel[j + 1] = vertices[num6];
				rightFunnel[j + 1] = vertices[num7];
				num4 = num6;
				num5 = num7;
			}
			else if (num6 == num5)
			{
				leftFunnel[j + 1] = vertices[num7];
				rightFunnel[j + 1] = vertices[num6];
				num4 = num7;
				num5 = num6;
			}
			else if (num7 == num4)
			{
				leftFunnel[j + 1] = vertices[num7];
				rightFunnel[j + 1] = vertices[num6];
				num4 = num7;
				num5 = num6;
			}
			else
			{
				leftFunnel[j + 1] = vertices[num6];
				rightFunnel[j + 1] = vertices[num7];
				num4 = num6;
				num5 = num7;
			}
		}
		if (!Polygon.IsClockwise(@int, leftFunnel[1], rightFunnel[1]))
		{
			Int3[] array2 = leftFunnel;
			leftFunnel = rightFunnel;
			rightFunnel = array2;
		}
		for (int m = 1; m < num3 - 1; m++)
		{
			Int3 int2 = rightFunnel[m] - leftFunnel[m];
			float worldMagnitude = int2.worldMagnitude;
			int2 /= worldMagnitude;
			int2 *= Mathf.Clamp(offset, 0f, worldMagnitude / 2f);
			leftFunnel[m] += int2;
			rightFunnel[m] -= int2;
		}
		if (tmpList == null)
		{
			tmpList = new List<Vector3>(3);
		}
		List<Vector3> list = tmpList;
		list.Clear();
		list.Add(@int);
		Int3 int3 = @int;
		Int3 int4 = leftFunnel[0];
		Int3 int5 = rightFunnel[0];
		int num10 = 0;
		int num11 = 0;
		int num12 = 0;
		for (int n = 1; n < num3; n++)
		{
			Int3 int6 = leftFunnel[n];
			Int3 int7 = rightFunnel[n];
			if (Polygon.TriangleArea2(int3, int5, int7) >= 0)
			{
				if (!(int3 == int5) && Polygon.TriangleArea2(int3, int4, int7) > 0)
				{
					list.Add(int4);
					int3 = int4;
					num10 = num12;
					int4 = int3;
					int5 = int3;
					num12 = num10;
					num11 = num10;
					n = num10;
					continue;
				}
				int5 = int7;
				num11 = n;
			}
			if (Polygon.TriangleArea2(int3, int4, int6) <= 0)
			{
				if (int3 == int4 || Polygon.TriangleArea2(int3, int5, int6) >= 0)
				{
					int4 = int6;
					num12 = n;
					continue;
				}
				list.Add(int5);
				int3 = int5;
				num10 = num11;
				int4 = int3;
				int5 = int3;
				num12 = num10;
				num11 = num10;
				n = num10;
			}
		}
		list.Add(path.endPoint);
		Vector3[] array3 = list.ToArray();
		if (array3.Length <= 1)
		{
			return @int;
		}
		for (int num13 = 1; num13 < array3.Length - 1; num13++)
		{
			Vector3 vector = Mathfx.NearestPointStrict(array3[num13], array3[num13 + 1], @int);
			if (!((vector - (Vector3)@int).sqrMagnitude < pickNextWaypointMargin * pickNextWaypointMargin))
			{
				return array3[num13];
			}
		}
		return array3[array3.Length - 1];
	}

	public override void Apply(Path p, ModifierData source)
	{
		Node[] path = p.path;
		Vector3[] vectorPath = p.vectorPath;
		if (path == null || path.Length == 0 || vectorPath == null || vectorPath.Length != path.Length)
		{
			return;
		}
		int graphIndex = path[0].graphIndex;
		int num = 0;
		List<Vector3> list = new List<Vector3>();
		List<Vector3> left = new List<Vector3>();
		List<Vector3> right = new List<Vector3>();
		for (int i = 0; i < path.Length; i++)
		{
			if (path[i].graphIndex == graphIndex)
			{
				continue;
			}
			IFunnelGraph funnelGraph = AstarData.GetGraph(path[num]) as IFunnelGraph;
			if (funnelGraph == null)
			{
				Debug.Log("Funnel Graph is null");
				for (int j = num; j <= i; j++)
				{
					list.Add(path[j].position);
				}
			}
			else
			{
				ConstructFunnel(funnelGraph, vectorPath, path, num, i, list, left, right);
			}
			graphIndex = path[i].graphIndex;
			num = i;
		}
		IFunnelGraph funnelGraph2 = AstarData.GetGraph(path[num]) as IFunnelGraph;
		if (funnelGraph2 == null)
		{
			for (int k = num; k < path.Length - 1; k++)
			{
				list.Add(path[k].position);
			}
		}
		else
		{
			ConstructFunnel(funnelGraph2, vectorPath, path, num, path.Length - 1, list, left, right);
		}
		p.vectorPath = list.ToArray();
	}

	public void ConstructFunnel(IFunnelGraph funnelGraph, Vector3[] vectorPath, Node[] path, int sIndex, int eIndex, List<Vector3> funnelPath, List<Vector3> left, List<Vector3> right)
	{
		left.Clear();
		right.Clear();
		left.Add(vectorPath[sIndex]);
		right.Add(vectorPath[sIndex]);
		funnelGraph.BuildFunnelCorridor(path, sIndex, eIndex, left, right);
		left.Add(vectorPath[eIndex]);
		right.Add(vectorPath[eIndex]);
		if (!RunFunnel(left, right, funnelPath))
		{
			funnelPath.Add(vectorPath[sIndex]);
			funnelPath.Add(vectorPath[eIndex]);
		}
		lastLeftFunnel = left.ToArray();
		lastRightFunnel = right.ToArray();
	}

	public bool RunFunnel(List<Vector3> left, List<Vector3> right, List<Vector3> funnelPath)
	{
		if (left.Count <= 3)
		{
			return false;
		}
		Console.WriteLine("Start");
		while (left[1] == left[2] && right[1] == right[2])
		{
			Console.WriteLine("Removing identical left and right");
			left.RemoveAt(1);
			right.RemoveAt(1);
		}
		Vector3 vector = left[2];
		if (vector == left[1])
		{
			vector = right[2];
		}
		if (Polygon.IsColinear(left[0], left[1], right[1]) || Polygon.Left(left[1], right[1], vector) == Polygon.Left(left[1], right[1], left[0]))
		{
			Debug.DrawLine(left[1], right[1], new Color(0f, 0f, 0f, 0.5f));
			Debug.DrawLine(left[0], vector, new Color(0f, 0f, 0f, 0.5f));
			Console.WriteLine("Wrong Side");
			left[0] = Mathfx.NearestPointStrict(left[1], right[1], left[0]);
			List<Vector3> list2;
			List<Vector3> list = (list2 = left);
			int index2;
			int index = (index2 = 0);
			Vector3 vector2 = list2[index2];
			list[index] = vector2 + (left[0] - vector).normalized * 0.001f;
			right[0] = left[0];
		}
		if (!Polygon.IsClockwise(left[0], left[1], right[1]) && !Polygon.IsColinear(left[0], left[1], right[1]))
		{
			Console.WriteLine("Wrong Side 2");
			List<Vector3> list3 = left;
			left = right;
			right = list3;
		}
		funnelPath.Add(left[0]);
		Vector3 vector3 = left[0];
		Vector3 vector4 = left[1];
		Vector3 vector5 = right[1];
		int num = 0;
		int num2 = 1;
		int num3 = 1;
		for (int i = 2; i < left.Count; i++)
		{
			if (funnelPath.Count > 200)
			{
				Debug.LogWarning("Avoiding infinite loop");
				break;
			}
			Vector3 vector6 = left[i];
			Vector3 vector7 = right[i];
			if (Polygon.TriangleArea2(vector3, vector5, vector7) >= 0f)
			{
				if (!(vector3 == vector5) && !(Polygon.TriangleArea2(vector3, vector4, vector7) <= 0f))
				{
					funnelPath.Add(vector4);
					vector3 = vector4;
					num = num3;
					vector4 = vector3;
					vector5 = vector3;
					num3 = num;
					num2 = num;
					i = num;
					continue;
				}
				vector5 = vector7;
				num2 = i;
			}
			if (Polygon.TriangleArea2(vector3, vector4, vector6) <= 0f)
			{
				if (vector3 == vector4 || Polygon.TriangleArea2(vector3, vector5, vector6) >= 0f)
				{
					vector4 = vector6;
					num3 = i;
					continue;
				}
				funnelPath.Add(vector5);
				vector3 = vector5;
				num = num2;
				vector4 = vector3;
				vector5 = vector3;
				num3 = num;
				num2 = num;
				i = num;
			}
		}
		funnelPath.Add(left[left.Count - 1]);
		return true;
	}
}
