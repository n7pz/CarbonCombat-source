using System;
using UnityEngine;

namespace Pathfinding
{
	public class NavGraph
	{
		public Guid _guid = Guid.NewGuid();

		public byte[] _sguid;

		public AstarPath active;

		public bool open;

		public Node[] nodes;

		public Matrix4x4 matrix;

		public Guid guid
		{
			get
			{
				if (_sguid == null || _sguid.Length != 16)
				{
					_sguid = Guid.NewGuid().ToByteArray();
				}
				return new Guid(_sguid);
			}
			set
			{
				_sguid = value.ToByteArray();
			}
		}

		public virtual Node[] CreateNodes(int number)
		{
			Node[] array = new Node[number];
			for (int i = 0; i < number; i++)
			{
				array[i] = new Node();
			}
			return array;
		}

		public virtual void RelocateNodes(Matrix4x4 oldMatrix, Matrix4x4 newMatrix)
		{
			if (nodes != null && nodes.Length != 0)
			{
				Matrix4x4 inverse = oldMatrix.inverse;
				for (int i = 0; i < nodes.Length; i++)
				{
					Vector3 v = inverse.MultiplyPoint3x4(nodes[i].position);
					nodes[i].position = newMatrix.MultiplyPoint3x4(v);
				}
			}
		}

		public NNInfo GetNearest(Vector3 position)
		{
			return GetNearest(position, NNConstraint.Default);
		}

		public virtual NNInfo GetNearest(Vector3 position, NNConstraint constraint, Node hint = null)
		{
			if (nodes == null)
			{
				return default(NNInfo);
			}
			float num = float.PositiveInfinity;
			Node node = null;
			float num2 = float.PositiveInfinity;
			Node node2 = null;
			for (int i = 0; i < nodes.Length; i++)
			{
				Node node3 = nodes[i];
				float sqrMagnitude = (position - (Vector3)node3.position).sqrMagnitude;
				if (sqrMagnitude < num)
				{
					num = sqrMagnitude;
					node = node3;
				}
				if (constraint.Suitable(node3) && sqrMagnitude < num2)
				{
					num2 = sqrMagnitude;
					node2 = node3;
				}
			}
			NNInfo result = new NNInfo(node);
			result.constrainedNode = node2;
			if (node2 != null)
			{
				result.constClampedPosition = node2.position;
			}
			else if (node != null)
			{
				result.constrainedNode = node;
				result.constClampedPosition = node.position;
			}
			return result;
		}

		public virtual NNInfo GetNearestForce(Vector3 position, NNConstraint constraint)
		{
			Debug.LogError("This should not be called if not GetNearest has been overriden, and if GetNearest has been overriden, you should override this function too, always return a node which returns true when passed to constraint.Suitable (node)");
			return default(NNInfo);
		}

		public virtual void Awake()
		{
		}

		public void SafeOnDestroy()
		{
			AstarPath.RegisterSafeNodeUpdate(OnDestroy);
		}

		public virtual void OnDestroy()
		{
			Debug.Log("Destroying Graph");
			nodes = null;
		}

		public void ScanGraph()
		{
			if (AstarPath.OnPreScan != null)
			{
				AstarPath.OnPreScan(AstarPath.active);
			}
			if (AstarPath.OnGraphPreScan != null)
			{
				AstarPath.OnGraphPreScan(this);
			}
			Scan();
			if (AstarPath.OnGraphPostScan != null)
			{
				AstarPath.OnGraphPostScan(this);
			}
			if (AstarPath.OnPostScan != null)
			{
				AstarPath.OnPostScan(AstarPath.active);
			}
		}

		public virtual void Scan()
		{
			Debug.LogError("Scan is not implemented in this NavGraph");
		}

		public virtual Color NodeColor(Node node)
		{
			Color result = Color.white;
			switch (AstarPath.active.debugMode)
			{
			case GraphDebugMode.Areas:
				result = AstarColor.GetAreaColor(node.area);
				break;
			case GraphDebugMode.G:
				result = Color.Lerp(AstarColor.ConnectionLowLerp, AstarColor.ConnectionHighLerp, (float)node.g / AstarPath.active.debugRoof);
				break;
			case GraphDebugMode.H:
				result = Color.Lerp(AstarColor.ConnectionLowLerp, AstarColor.ConnectionHighLerp, (float)node.h / AstarPath.active.debugRoof);
				break;
			case GraphDebugMode.F:
				result = Color.Lerp(AstarColor.ConnectionLowLerp, AstarColor.ConnectionHighLerp, (float)node.f / AstarPath.active.debugRoof);
				break;
			case GraphDebugMode.Penalty:
				result = Color.Lerp(AstarColor.ConnectionLowLerp, AstarColor.ConnectionHighLerp, (float)node.penalty / AstarPath.active.debugRoof);
				break;
			}
			result.a *= 0.5f;
			return result;
		}

		public virtual void OnDrawGizmos(bool drawNodes)
		{
			if (nodes == null || !drawNodes)
			{
				if (Application.isPlaying)
				{
				}
				return;
			}
			for (int i = 0; i < nodes.Length; i++)
			{
				Node node = nodes[i];
				if (node.connections == null)
				{
					continue;
				}
				Gizmos.color = NodeColor(node);
				if (AstarPath.active.debugPath != null && AstarPath.active.showSearchTree && (node.pathID != AstarPath.active.debugPath.pathID || Node.activePath == null))
				{
					break;
				}
				if (node.parent != null && AstarPath.active.showSearchTree)
				{
					Gizmos.DrawLine(node.position, node.parent.position);
					continue;
				}
				for (int j = 0; j < node.connections.Length; j++)
				{
					Gizmos.DrawLine(node.position, node.connections[j].position);
				}
			}
		}
	}
}
