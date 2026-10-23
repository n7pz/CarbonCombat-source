using System;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class NavmeshController : MonoBehaviour
{
	public float forwardPlanning;

	protected Vector3 prevPos;

	protected Node prevNode;

	protected CharacterController controller;

	private Stack<Node> tmpStack = new Stack<Node>(16);

	private List<Node> tmpClosed = new List<Node>(32);

	public void Start()
	{
		AstarPath.OnAwakeSettings = (OnVoidDelegate)Delegate.Combine(AstarPath.OnAwakeSettings, new OnVoidDelegate(OnAstarAwake));
	}

	private void OnAstarAwake()
	{
		AstarPath.OnLatePostScan = (OnScanDelegate)Delegate.Combine(AstarPath.OnLatePostScan, new OnScanDelegate(OnRescan));
	}

	private void OnDisable()
	{
		AstarPath.OnAwakeSettings = (OnVoidDelegate)Delegate.Remove(AstarPath.OnAwakeSettings, new OnVoidDelegate(OnAstarAwake));
	}

	private void OnRescan(AstarPath active)
	{
		Teleport();
		Debug.LogWarning("On Rescan");
	}

	public void Teleport()
	{
		prevNode = null;
	}

	public Vector3 SimpleMove(Vector3 currentPosition, Vector3 direction)
	{
		forwardPlanning = ((!(forwardPlanning < 0.01f)) ? forwardPlanning : 0.01f);
		if (controller == null)
		{
			controller = GetComponent<CharacterController>();
		}
		if (controller == null)
		{
			Debug.LogError("No CharacterController is attached to the GameObject");
			return direction;
		}
		Vector3 target = currentPosition + direction * forwardPlanning;
		target = ClampToNavmesh(target);
		direction = (target - currentPosition) * (1f / forwardPlanning);
		controller.SimpleMove(direction);
		return direction;
	}

	public Vector3 ClampToNavmesh(Vector3 target)
	{
		if (prevNode == null)
		{
			prevNode = AstarPath.active.GetNearest(base.transform.position).node;
			prevPos = base.transform.position;
		}
		Vector3 clampedPos;
		prevNode = ClampAlongNavmesh(prevPos, prevNode, target, out clampedPos);
		prevPos = clampedPos;
		return clampedPos;
	}

	public Node ClampAlongNavmesh(Vector3 startPos, Node startNode, Vector3 endPos, out Vector3 clampedPos)
	{
		clampedPos = endPos;
		Stack<Node> stack = tmpStack;
		List<Node> list = tmpClosed;
		stack.Clear();
		list.Clear();
		float num = float.PositiveInfinity;
		Node result = null;
		Vector3 vector = (startPos + endPos) / 2f;
		float num2 = Mathfx.MagnitudeXZ(startPos, endPos) / 2f;
		Vector3 vector2 = startPos;
		stack.Push(startNode);
		list.Add(startNode);
		INavmesh navmesh = AstarData.GetGraph(startNode) as INavmesh;
		if (navmesh == null)
		{
			return startNode;
		}
		while (stack.Count > 0)
		{
			Node node = stack.Pop();
			MeshNode meshNode = node as MeshNode;
			if (NavMeshGraph.ContainsPoint(meshNode, endPos, navmesh.vertices))
			{
				result = node;
				vector2 = endPos;
				break;
			}
			int num3 = 0;
			int i = 2;
			while (num3 < 3)
			{
				int vertexIndex = meshNode.GetVertexIndex(i);
				int vertexIndex2 = meshNode.GetVertexIndex(num3);
				bool flag = true;
				MeshNode meshNode2 = null;
				for (int j = 0; j < node.connections.Length; j++)
				{
					meshNode2 = node.connections[j] as MeshNode;
					if (meshNode2 == null)
					{
						continue;
					}
					int num4 = 0;
					int i2 = 2;
					while (num4 < 3)
					{
						int vertexIndex3 = meshNode2.GetVertexIndex(i2);
						int vertexIndex4 = meshNode2.GetVertexIndex(num4);
						if ((vertexIndex3 == vertexIndex && vertexIndex4 == vertexIndex2) || (vertexIndex3 == vertexIndex2 && vertexIndex4 == vertexIndex))
						{
							flag = false;
							break;
						}
						i2 = num4++;
					}
					if (!flag)
					{
						break;
					}
				}
				if (flag)
				{
					Vector3 vector3 = Mathfx.NearestPointStrictXZ(navmesh.vertices[vertexIndex], navmesh.vertices[vertexIndex2], endPos);
					float num5 = Mathfx.MagnitudeXZ(vector3, endPos);
					if (num5 < num)
					{
						vector2 = vector3;
						num = num5;
						result = node;
					}
				}
				else if (!list.Contains(meshNode2))
				{
					list.Add(meshNode2);
					Vector3 vector3 = Mathfx.NearestPointStrictXZ(navmesh.vertices[vertexIndex], navmesh.vertices[vertexIndex2], vector);
					float num5 = Mathfx.MagnitudeXZ(vector3, vector);
					if (num5 <= num2)
					{
						stack.Push(meshNode2);
					}
				}
				i = num3++;
			}
		}
		clampedPos = vector2;
		return result;
	}
}
