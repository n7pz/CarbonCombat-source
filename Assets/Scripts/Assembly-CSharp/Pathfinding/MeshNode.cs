using System;
using UnityEngine;

namespace Pathfinding
{
	public class MeshNode : Node
	{
		public int v1;

		public int v2;

		public int v3;

		public int this[int i]
		{
			get
			{
				return GetVertexIndex(i);
			}
		}

		public int GetVertexIndex(int i)
		{
			switch (i)
			{
			case 0:
				return v1;
			case 1:
				return v2;
			case 2:
				return v3;
			default:
				throw new ArgumentOutOfRangeException("A MeshNode only contains 3 vertices");
			}
		}

		public Vector3 ClosestPoint(Vector3 p, Int3[] vertices)
		{
			return Polygon.ClosesPointOnTriangle(vertices[v1], vertices[v2], vertices[v3], p);
		}
	}
}
