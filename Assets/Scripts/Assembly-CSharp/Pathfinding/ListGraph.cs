using System.Collections.Generic;
using UnityEngine;

namespace Pathfinding
{
	public class ListGraph : NavGraph, ISerializableObject, ISerializableGraph
	{
		public Transform root;

		public string searchTag;

		public float maxDistance;

		public Vector3 limits;

		public bool raycast = true;

		public bool thickRaycast;

		public float thickRaycastRadius = 1f;

		public bool recursive = true;

		public LayerMask mask;

		public int CountChildren(Transform tr)
		{
			int num = 0;
			foreach (Transform item in tr)
			{
				num++;
				num += CountChildren(item);
			}
			return num;
		}

		public void AddChildren(int c, Transform tr)
		{
			foreach (Transform item in tr)
			{
				nodes[c].position = item.position;
				nodes[c].walkable = true;
				c++;
				AddChildren(c, item);
			}
		}

		public override void Scan()
		{
			if (root == null)
			{
				GameObject[] array = GameObject.FindGameObjectsWithTag(searchTag);
				if (array == null)
				{
					CreateNodes(0);
					return;
				}
				nodes = CreateNodes(array.Length);
				for (int i = 0; i < array.Length; i++)
				{
					nodes[i].position = array[i].transform.position;
					nodes[i].walkable = true;
				}
			}
			else if (!recursive)
			{
				nodes = CreateNodes(root.childCount);
				int num = 0;
				foreach (Transform item in root)
				{
					nodes[num].position = item.position;
					nodes[num].walkable = true;
					num++;
				}
			}
			else
			{
				nodes = CreateNodes(CountChildren(root));
				AddChildren(0, root);
			}
			List<Node> list = new List<Node>(3);
			List<int> list2 = new List<int>(3);
			for (int j = 0; j < nodes.Length; j++)
			{
				list.Clear();
				list2.Clear();
				Node node = nodes[j];
				for (int k = 0; k < nodes.Length; k++)
				{
					Node node2 = nodes[k];
					float dist = 0f;
					if (IsValidConnection(node, node2, out dist))
					{
						list.Add(node2);
						list2.Add(Mathf.RoundToInt(dist));
					}
				}
				node.connections = list.ToArray();
				node.connectionCosts = list2.ToArray();
			}
		}

		public bool IsValidConnection(Node a, Node b, out float dist)
		{
			dist = 0f;
			if (!a.walkable || !b.walkable)
			{
				return false;
			}
			Vector3 vector = a.position - b.position;
			if ((!Mathf.Approximately(limits.x, 0f) && Mathf.Abs(vector.x) > limits.x) || (!Mathf.Approximately(limits.y, 0f) && Mathf.Abs(vector.y) > limits.y) || (!Mathf.Approximately(limits.z, 0f) && Mathf.Abs(vector.z) > limits.z))
			{
				return false;
			}
			dist = vector.magnitude;
			if (maxDistance == 0f || dist < maxDistance)
			{
				if (!raycast)
				{
					return true;
				}
				Ray ray = new Ray(a.position, b.position - a.position);
				Ray ray2 = new Ray(b.position, a.position - b.position);
				if (thickRaycast)
				{
					if (!Physics.SphereCast(ray, thickRaycastRadius, dist, mask) && !Physics.SphereCast(ray2, thickRaycastRadius, dist, mask))
					{
						return true;
					}
				}
				else if (!Physics.Raycast(ray, dist, mask) && !Physics.Raycast(ray2, dist, mask))
				{
					return true;
				}
			}
			return false;
		}

		public void SerializeNodes(Node[] nodes, AstarSerializer serializer)
		{
		}

		public void DeSerializeNodes(Node[] nodes, AstarSerializer serializer)
		{
		}

		public void SerializeSettings(AstarSerializer serializer)
		{
			serializer.AddUnityReferenceValue("root", root);
			serializer.AddValue("maxDistance", maxDistance);
			serializer.AddValue("limits", limits);
			serializer.AddValue("mask", mask.value);
			serializer.AddValue("thickRaycast", thickRaycast);
			serializer.AddValue("thickRaycastRadius", thickRaycastRadius);
			serializer.AddValue("searchTag", searchTag);
			serializer.AddValue("recursive", recursive);
		}

		public void DeSerializeSettings(AstarSerializer serializer)
		{
			root = (Transform)serializer.GetUnityReferenceValue("root", typeof(Transform));
			maxDistance = (float)serializer.GetValue("maxDistance", typeof(float));
			limits = (Vector3)serializer.GetValue("limits", typeof(Vector3));
			mask.value = (int)serializer.GetValue("mask", typeof(int));
			thickRaycast = (bool)serializer.GetValue("thickRaycast", typeof(bool));
			thickRaycastRadius = (float)serializer.GetValue("thickRaycastRadius", typeof(float));
			searchTag = (string)serializer.GetValue("searchTag", typeof(string));
			recursive = (bool)serializer.GetValue("recursive", typeof(bool));
		}
	}
}
