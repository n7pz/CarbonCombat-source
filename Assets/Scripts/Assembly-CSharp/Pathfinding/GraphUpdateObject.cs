using UnityEngine;

namespace Pathfinding
{
	public class GraphUpdateObject
	{
		public Bounds bounds;

		public bool updatePhysics = true;

		public NNConstraint nnConstraint = NNConstraint.None;

		public int addPenalty;

		public bool modifyWalkability;

		public bool setWalkability;

		public GraphUpdateObject()
		{
		}

		public GraphUpdateObject(Bounds b)
		{
			bounds = b;
		}

		public virtual void Apply(Node node)
		{
			node.penalty += addPenalty;
			if (modifyWalkability)
			{
				node.walkable = setWalkability;
			}
		}
	}
}
