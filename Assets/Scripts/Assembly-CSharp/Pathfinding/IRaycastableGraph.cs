using UnityEngine;

namespace Pathfinding
{
	public interface IRaycastableGraph
	{
		bool Linecast(Vector3 start, Vector3 end);

		bool Linecast(Vector3 start, Vector3 end, Node hint);

		bool Linecast(Vector3 start, Vector3 end, Node hint, out GraphHitInfo hit);
	}
}
