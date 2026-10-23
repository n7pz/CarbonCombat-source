using UnityEngine;

namespace Pathfinding
{
	public class GraphHitInfo
	{
		public Vector3 origin;

		public Vector3 point;

		public Node node;

		public Vector3 tangentOrigin;

		public Vector3 tangent;

		public bool success;

		public float distance
		{
			get
			{
				return (point - origin).magnitude;
			}
		}

		public GraphHitInfo()
		{
			success = false;
			tangentOrigin = Vector3.zero;
			origin = Vector3.zero;
			point = Vector3.zero;
			node = null;
			tangent = Vector3.zero;
		}

		public GraphHitInfo(Vector3 point)
		{
			success = false;
			tangentOrigin = Vector3.zero;
			origin = Vector3.zero;
			this.point = point;
			node = null;
			tangent = Vector3.zero;
		}
	}
}
