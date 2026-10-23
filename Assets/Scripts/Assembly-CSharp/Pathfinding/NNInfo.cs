using UnityEngine;

namespace Pathfinding
{
	public struct NNInfo
	{
		public Node node;

		public Node constrainedNode;

		public NearestNodePriority priority;

		public Vector3 clampedPosition;

		public Vector3 constClampedPosition;

		public NNInfo(Node node)
		{
			priority = NearestNodePriority.Normal;
			this.node = node;
			constrainedNode = null;
			constClampedPosition = Vector3.zero;
			if (node != null)
			{
				clampedPosition = node.position;
			}
			else
			{
				clampedPosition = Vector3.zero;
			}
		}

		public NNInfo(Node node, NearestNodePriority priority)
		{
			this.node = node;
			this.priority = priority;
			clampedPosition = node.position;
			constrainedNode = null;
			constClampedPosition = Vector3.zero;
		}

		public void SetConstrained(Node constrainedNode, Vector3 clampedPosition)
		{
			this.constrainedNode = constrainedNode;
			constClampedPosition = clampedPosition;
		}

		public void UpdateInfo()
		{
			if (node != null)
			{
				clampedPosition = node.position;
			}
			else
			{
				clampedPosition = Vector3.zero;
			}
			if (constrainedNode != null)
			{
				constClampedPosition = constrainedNode.position;
			}
			else
			{
				constClampedPosition = Vector3.zero;
			}
		}

		public static implicit operator Vector3(NNInfo ob)
		{
			return ob.clampedPosition;
		}

		public static implicit operator Node(NNInfo ob)
		{
			return ob.node;
		}

		public static implicit operator NNInfo(Node ob)
		{
			return new NNInfo(ob);
		}
	}
}
