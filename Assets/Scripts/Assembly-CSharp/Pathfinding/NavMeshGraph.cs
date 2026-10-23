using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Pathfinding
{
	[Serializable]
	public class NavMeshGraph : NavGraph, ISerializableObject, ISerializableGraph, IUpdatableGraph, INavmesh, IFunnelGraph
	{
		public Mesh sourceMesh;

		public Vector3 offset;

		public Vector3 rotation;

		public float scale = 1f;

		private BBTree _bbTree;

		[NonSerialized]
		private Int3[] _vertices;

		[NonSerialized]
		private Vector3[] originalVertices;

		private Matrix4x4 _originalMatrix;

		[NonSerialized]
		public int[] triangles;

		public BBTree bbTree
		{
			get
			{
				return _bbTree;
			}
			set
			{
				_bbTree = value;
			}
		}

		public Int3[] vertices
		{
			get
			{
				return _vertices;
			}
			set
			{
				_vertices = value;
			}
		}

		public override Node[] CreateNodes(int number)
		{
			MeshNode[] array = new MeshNode[number];
			for (int i = 0; i < number; i++)
			{
				array[i] = new MeshNode();
			}
			return array;
		}

		public void GenerateMatrix()
		{
			matrix = Matrix4x4.TRS(offset, Quaternion.Euler(rotation), new Vector3(scale, scale, scale));
		}

		public override void RelocateNodes(Matrix4x4 oldMatrix, Matrix4x4 newMatrix)
		{
			if (vertices == null || vertices.Length == 0 || originalVertices == null || originalVertices.Length != vertices.Length)
			{
				return;
			}
			for (int i = 0; i < vertices.Length; i++)
			{
				vertices[i] = newMatrix.MultiplyPoint3x4(originalVertices[i]);
			}
			for (int j = 0; j < nodes.Length; j++)
			{
				MeshNode meshNode = (MeshNode)nodes[j];
				meshNode.position = (vertices[meshNode.v1] + vertices[meshNode.v2] + vertices[meshNode.v3]) / 3f;
				if (meshNode.connections != null)
				{
					for (int k = 0; k < meshNode.connections.Length; k++)
					{
						meshNode.connectionCosts[k] = (meshNode.position - meshNode.connections[k].position).costMagnitude;
					}
				}
			}
		}

		public static NNInfo GetNearest(INavmesh graph, Node[] nodes, Vector3 position, NNConstraint constraint)
		{
			if (nodes == null || nodes.Length == 0)
			{
				Debug.LogError("NavGraph hasn't been generated yet or does not contain any nodes");
				return default(NNInfo);
			}
			return GetNearestForce(nodes, graph.vertices, position, constraint);
		}

		public override NNInfo GetNearest(Vector3 position, NNConstraint constraint, Node hint = null)
		{
			return GetNearest(this, nodes, position, constraint);
		}

		public override NNInfo GetNearestForce(Vector3 position, NNConstraint constraint)
		{
			return GetNearestForce(nodes, vertices, position, constraint);
		}

		public static NNInfo GetNearestForce(Node[] nodes, Int3[] vertices, Vector3 position, NNConstraint constraint)
		{
			Int3 @int = position;
			int num = -1;
			Node node = null;
			float num2 = -1f;
			Node node2 = null;
			int num3 = -1;
			Node node3 = null;
			float num4 = -1f;
			Node node4 = null;
			for (int i = 0; i < nodes.Length; i++)
			{
				MeshNode meshNode = nodes[i] as MeshNode;
				if (!Polygon.IsClockwise(vertices[meshNode.v1], vertices[meshNode.v2], @int) || !Polygon.IsClockwise(vertices[meshNode.v2], vertices[meshNode.v3], @int) || !Polygon.IsClockwise(vertices[meshNode.v3], vertices[meshNode.v1], @int))
				{
					float sqrMagnitude = (meshNode.position - @int).sqrMagnitude;
					if (num2 == -1f || sqrMagnitude < num2)
					{
						num2 = sqrMagnitude;
						node2 = meshNode;
					}
					if (constraint.Suitable(meshNode) && (num4 == -1f || sqrMagnitude < num4))
					{
						num4 = sqrMagnitude;
						node4 = meshNode;
					}
				}
				else
				{
					int num5 = Mathfx.Abs(meshNode.position.y - @int.y);
					if (num == -1 || num5 < num)
					{
						num = num5;
						node = meshNode;
					}
					if (constraint.Suitable(meshNode) && (num3 == -1 || num5 < num3))
					{
						num3 = num5;
						node3 = meshNode;
					}
				}
			}
			NNInfo result = new NNInfo((node != null) ? node : node2, (node != null) ? NearestNodePriority.High : NearestNodePriority.Low);
			if (result.node != null)
			{
				MeshNode meshNode2 = result.node as MeshNode;
				Vector3[] triangle = new Vector3[3]
				{
					vertices[meshNode2.v1],
					vertices[meshNode2.v2],
					vertices[meshNode2.v3]
				};
				Vector3 clampedPosition = Polygon.ClosesPointOnTriangle(triangle, position);
				result.clampedPosition = clampedPosition;
			}
			result.constrainedNode = ((node3 != null) ? node3 : node4);
			if (result.constrainedNode != null)
			{
				MeshNode meshNode3 = result.constrainedNode as MeshNode;
				Vector3[] triangle2 = new Vector3[3]
				{
					vertices[meshNode3.v1],
					vertices[meshNode3.v2],
					vertices[meshNode3.v3]
				};
				Vector3 constClampedPosition = Polygon.ClosesPointOnTriangle(triangle2, position);
				result.constClampedPosition = constClampedPosition;
			}
			return result;
		}

		public void BuildFunnelCorridor(Node[] path, int startIndex, int endIndex, List<Vector3> left, List<Vector3> right)
		{
			BuildFunnelCorridor(this, path, startIndex, endIndex, left, right);
		}

		public static void BuildFunnelCorridor(INavmesh graph, Node[] path, int startIndex, int endIndex, List<Vector3> left, List<Vector3> right)
		{
			if (graph == null)
			{
				Debug.LogError("Couldn't cast graph to the appropriate type (graph isn't a Navmesh type graph, it doesn't implement the INavmesh interface)");
				return;
			}
			Int3[] array = graph.vertices;
			int num = -1;
			int num2 = -1;
			for (int i = startIndex; i < endIndex; i++)
			{
				MeshNode meshNode = path[i] as MeshNode;
				MeshNode meshNode2 = path[i + 1] as MeshNode;
				bool flag = false;
				int num3 = -1;
				int num4 = -1;
				for (int j = 0; j < 3; j++)
				{
					int vertexIndex = meshNode.GetVertexIndex(j);
					for (int k = 0; k < 3; k++)
					{
						int vertexIndex2 = meshNode2.GetVertexIndex(k);
						if (vertexIndex == vertexIndex2)
						{
							if (flag)
							{
								num4 = vertexIndex2;
								break;
							}
							num3 = vertexIndex2;
							flag = true;
						}
					}
				}
				if (num3 == -1 || num4 == -1)
				{
					left.Add(meshNode.position);
					right.Add(meshNode.position);
					left.Add(meshNode2.position);
					right.Add(meshNode2.position);
					num = num3;
					num2 = num4;
				}
				else if (num3 == num)
				{
					left.Add(array[num3]);
					right.Add(array[num4]);
					num = num3;
					num2 = num4;
				}
				else if (num3 == num2)
				{
					left.Add(array[num4]);
					right.Add(array[num3]);
					num = num4;
					num2 = num3;
				}
				else if (num4 == num)
				{
					left.Add(array[num4]);
					right.Add(array[num3]);
					num = num4;
					num2 = num3;
				}
				else
				{
					left.Add(array[num3]);
					right.Add(array[num4]);
					num = num3;
					num2 = num4;
				}
			}
		}

		public void AddPortal(Node n1, Node n2, List<Vector3> left, List<Vector3> right)
		{
		}

		public void UpdateArea(GraphUpdateObject o)
		{
			if (nodes == null || nodes.Length == 0)
			{
				Debug.LogError("NavGraph hasn't been generated yet or does not contain any nodes");
				return;
			}
			Bounds bounds = o.bounds;
			Rect rect = Rect.MinMaxRect(bounds.min.x, bounds.min.z, bounds.max.x, bounds.max.z);
			Vector3 vector = new Vector3(rect.xMin, 0f, rect.yMin);
			Vector3 vector2 = new Vector3(rect.xMin, 0f, rect.yMax);
			Vector3 vector3 = new Vector3(rect.xMax, 0f, rect.yMin);
			Vector3 vector4 = new Vector3(rect.xMax, 0f, rect.yMax);
			for (int i = 0; i < nodes.Length; i++)
			{
				MeshNode meshNode = nodes[i] as MeshNode;
				bool flag = false;
				int num = 0;
				int num2 = 0;
				int num3 = 0;
				int num4 = 0;
				for (int j = 0; j < 3; j++)
				{
					Vector3 vector5 = vertices[meshNode[j]];
					Vector2 point = new Vector2(vector5.x, vector5.z);
					if (rect.Contains(point))
					{
						flag = true;
						break;
					}
					if (vector5.x < rect.xMin)
					{
						num++;
					}
					if (vector5.x > rect.xMax)
					{
						num2++;
					}
					if (vector5.z < rect.yMin)
					{
						num3++;
					}
					if (vector5.z > rect.yMax)
					{
						num4++;
					}
				}
				if (!flag && (num == 3 || num2 == 3 || num3 == 3 || num4 == 3))
				{
					continue;
				}
				for (int k = 0; k < 3; k++)
				{
					int i2 = ((k <= 1) ? (k + 1) : 0);
					Vector3 start = vertices[meshNode[k]];
					Vector3 end = vertices[meshNode[i2]];
					if (Polygon.Intersects(vector, vector2, start, end))
					{
						flag = true;
						break;
					}
					if (Polygon.Intersects(vector, vector3, start, end))
					{
						flag = true;
						break;
					}
					if (Polygon.Intersects(vector3, vector4, start, end))
					{
						flag = true;
						break;
					}
					if (Polygon.Intersects(vector4, vector2, start, end))
					{
						flag = true;
						break;
					}
				}
				if (!flag && ContainsPoint(meshNode, vector))
				{
					flag = true;
				}
				if (!flag && ContainsPoint(meshNode, vector2))
				{
					flag = true;
				}
				if (!flag && ContainsPoint(meshNode, vector3))
				{
					flag = true;
				}
				if (!flag && ContainsPoint(meshNode, vector4))
				{
					flag = true;
				}
				if (flag)
				{
					o.Apply(meshNode);
				}
			}
		}

		public static Vector3 ClosestPointOnNode(MeshNode node, Int3[] vertices, Vector3 pos)
		{
			return Polygon.ClosesPointOnTriangle(vertices[node[0]], vertices[node[1]], vertices[node[2]], pos);
		}

		public bool ContainsPoint(MeshNode node, Vector3 pos)
		{
			if (Polygon.IsClockwise((Vector3)vertices[node.v1], (Vector3)vertices[node.v2], pos) && Polygon.IsClockwise((Vector3)vertices[node.v2], (Vector3)vertices[node.v3], pos) && Polygon.IsClockwise((Vector3)vertices[node.v3], (Vector3)vertices[node.v1], pos))
			{
				return true;
			}
			return false;
		}

		public static bool ContainsPoint(MeshNode node, Vector3 pos, Int3[] vertices)
		{
			if (Polygon.IsClockwiseMargin(vertices[node.v1], vertices[node.v2], pos) && Polygon.IsClockwiseMargin(vertices[node.v2], vertices[node.v3], pos) && Polygon.IsClockwiseMargin(vertices[node.v3], vertices[node.v1], pos))
			{
				return true;
			}
			return false;
		}

		public void Scan(string objMeshPath)
		{
			Mesh mesh = ObjImporter.ImportFile(objMeshPath);
			if (mesh == null)
			{
				Debug.LogError("Couldn't read .obj file at '" + objMeshPath + "'");
				return;
			}
			sourceMesh = mesh;
			Scan();
		}

		public override void Scan()
		{
			if (!(sourceMesh == null))
			{
				GenerateMatrix();
				Vector3[] vectorVertices = sourceMesh.vertices;
				triangles = sourceMesh.triangles;
				GenerateNodes(this, vectorVertices, triangles, out originalVertices, out _vertices);
			}
		}

		public static void GenerateNodes(NavGraph graph, Vector3[] vectorVertices, int[] triangles, out Vector3[] originalVertices, out Int3[] vertices)
		{
			if (!(graph is INavmesh))
			{
				Debug.LogError("The specified graph does not implement interface 'INavmesh'");
				originalVertices = vectorVertices;
				vertices = new Int3[0];
				graph.nodes = graph.CreateNodes(0);
				return;
			}
			if (vectorVertices.Length == 0 || triangles.Length == 0)
			{
				originalVertices = vectorVertices;
				vertices = new Int3[0];
				graph.nodes = graph.CreateNodes(0);
				return;
			}
			vertices = new Int3[vectorVertices.Length];
			int num = 0;
			for (int i = 0; i < vertices.Length; i++)
			{
				vertices[i] = graph.matrix.MultiplyPoint(vectorVertices[i]);
			}
			Dictionary<Int3, int> dictionary = new Dictionary<Int3, int>();
			int[] array = new int[vertices.Length];
			for (int j = 0; j < vertices.Length - 1; j++)
			{
				if (!dictionary.ContainsKey(vertices[j]))
				{
					array[num] = j;
					dictionary.Add(vertices[j], num);
					num++;
				}
			}
			array[num] = vertices.Length - 1;
			if (!dictionary.ContainsKey(vertices[array[num]]))
			{
				dictionary.Add(vertices[array[num]], num);
				num++;
			}
			for (int k = 0; k < triangles.Length; k++)
			{
				Int3 key = vertices[triangles[k]];
				triangles[k] = dictionary[key];
			}
			Int3[] array2 = vertices;
			vertices = new Int3[num];
			originalVertices = new Vector3[num];
			for (int l = 0; l < num; l++)
			{
				originalVertices[l] = vectorVertices[array[l]];
				vertices[l] = array2[array[l]];
			}
			Node[] array3 = (graph.nodes = graph.CreateNodes(triangles.Length / 3));
			for (int m = 0; m < array3.Length; m++)
			{
				MeshNode meshNode = (MeshNode)array3[m];
				meshNode.walkable = true;
				meshNode.position = (vertices[triangles[m * 3]] + vertices[triangles[m * 3 + 1]] + vertices[triangles[m * 3 + 2]]) / 3f;
				meshNode.v1 = triangles[m * 3];
				meshNode.v2 = triangles[m * 3 + 1];
				meshNode.v3 = triangles[m * 3 + 2];
				if (!Polygon.IsClockwise(vertices[meshNode.v1], vertices[meshNode.v2], vertices[meshNode.v3]))
				{
					int v = meshNode.v1;
					meshNode.v1 = meshNode.v3;
					meshNode.v3 = v;
				}
				if (Polygon.IsColinear(vertices[meshNode.v1], vertices[meshNode.v2], vertices[meshNode.v3]))
				{
					Debug.DrawLine(vertices[meshNode.v1], vertices[meshNode.v2], Color.red);
					Debug.DrawLine(vertices[meshNode.v2], vertices[meshNode.v3], Color.red);
					Debug.DrawLine(vertices[meshNode.v3], vertices[meshNode.v1], Color.red);
				}
				array3[m] = meshNode;
			}
			List<Node> list = new List<Node>();
			List<int> list2 = new List<int>();
			int num2 = 0;
			for (int n = 0; n < triangles.Length; n += 3)
			{
				list.Clear();
				list2.Clear();
				Node node = array3[n / 3];
				for (int num3 = 0; num3 < triangles.Length; num3 += 3)
				{
					if (num3 != n)
					{
						int num4 = 0;
						if (triangles[num3] == triangles[n])
						{
							num4++;
						}
						if (triangles[num3 + 1] == triangles[n])
						{
							num4++;
						}
						if (triangles[num3 + 2] == triangles[n])
						{
							num4++;
						}
						if (triangles[num3] == triangles[n + 1])
						{
							num4++;
						}
						if (triangles[num3 + 1] == triangles[n + 1])
						{
							num4++;
						}
						if (triangles[num3 + 2] == triangles[n + 1])
						{
							num4++;
						}
						if (triangles[num3] == triangles[n + 2])
						{
							num4++;
						}
						if (triangles[num3 + 1] == triangles[n + 2])
						{
							num4++;
						}
						if (triangles[num3 + 2] == triangles[n + 2])
						{
							num4++;
						}
						if (num4 >= 3)
						{
							num2++;
							Debug.DrawLine(vertices[triangles[num3]], vertices[triangles[num3 + 1]], Color.red);
							Debug.DrawLine(vertices[triangles[num3]], vertices[triangles[num3 + 2]], Color.red);
							Debug.DrawLine(vertices[triangles[num3 + 2]], vertices[triangles[num3 + 1]], Color.red);
						}
						if (num4 == 2)
						{
							Node node2 = array3[num3 / 3];
							list.Add(node2);
							list2.Add(Mathf.RoundToInt((node.position - node2.position).magnitude));
						}
					}
				}
				node.connections = list.ToArray();
				node.connectionCosts = list2.ToArray();
			}
			if (num2 > 0)
			{
				Debug.LogError("One or more triangles are identical to other triangles, this is not a good thing to have in a navmesh\nIncreasing the scale of the mesh might help\nNumber of triangles with error: " + num2 + "\n");
			}
			RebuildBBTree(graph);
		}

		public static void RebuildBBTree(NavGraph graph)
		{
		}

		public void PostProcess()
		{
			int num = UnityEngine.Random.Range(0, nodes.Length);
			Node node = nodes[num];
			NavGraph navGraph = null;
			navGraph = ((AstarPath.active.astarData.GetGraphIndex(this) != 0) ? AstarPath.active.graphs[0] : AstarPath.active.graphs[1]);
			num = UnityEngine.Random.Range(0, navGraph.nodes.Length);
			List<Node> list = new List<Node>();
			List<int> list2 = new List<int>();
			list.AddRange(node.connections);
			list2.AddRange(node.connectionCosts);
			Node node2 = navGraph.nodes[num];
			list.Add(node2);
			list2.Add(Mathf.RoundToInt((node.position - node2.position).magnitude * 100f));
			node.connections = list.ToArray();
			node.connectionCosts = list2.ToArray();
		}

		public void Sort(Vector3[] a)
		{
			bool flag = true;
			while (flag)
			{
				flag = false;
				for (int i = 0; i < a.Length - 1; i++)
				{
					if (a[i].x > a[i + 1].x || (a[i].x == a[i + 1].x && (a[i].y > a[i + 1].y || (a[i].y == a[i + 1].y && a[i].z > a[i + 1].z))))
					{
						Vector3 vector = a[i];
						a[i] = a[i + 1];
						a[i + 1] = vector;
						flag = true;
					}
				}
			}
		}

		public override void OnDrawGizmos(bool drawNodes)
		{
			if (!drawNodes)
			{
				return;
			}
			Matrix4x4 matrix4x = matrix;
			GenerateMatrix();
			if (nodes == null)
			{
				Scan();
			}
			if (nodes == null)
			{
				return;
			}
			if (matrix4x != matrix)
			{
				RelocateNodes(matrix4x, matrix);
			}
			for (int i = 0; i < nodes.Length; i++)
			{
				MeshNode meshNode = (MeshNode)nodes[i];
				Gizmos.color = NodeColor(meshNode);
				if (meshNode.walkable)
				{
					if (meshNode.parent != null)
					{
						Gizmos.DrawLine(meshNode.position, meshNode.parent.position);
					}
					else
					{
						for (int j = 0; j < meshNode.connections.Length; j++)
						{
							Gizmos.DrawLine(meshNode.position, meshNode.connections[j].position);
						}
					}
					Gizmos.color = AstarColor.MeshEdgeColor;
				}
				else
				{
					Gizmos.color = Color.red;
				}
				Gizmos.DrawLine(vertices[meshNode.v1], vertices[meshNode.v2]);
				Gizmos.DrawLine(vertices[meshNode.v2], vertices[meshNode.v3]);
				Gizmos.DrawLine(vertices[meshNode.v3], vertices[meshNode.v1]);
			}
		}

		public static void SerializeMeshNodes(INavmesh graph, Node[] nodes, AstarSerializer serializer)
		{
			BinaryWriter writerStream = serializer.writerStream;
			for (int i = 0; i < nodes.Length; i++)
			{
				MeshNode meshNode = nodes[i] as MeshNode;
				if (meshNode == null)
				{
					Debug.LogError("Serialization Error : Couldn't cast the node to the appropriate type - NavMeshGenerator");
					return;
				}
				writerStream.Write(meshNode.v1);
				writerStream.Write(meshNode.v2);
				writerStream.Write(meshNode.v3);
			}
			Int3[] array = graph.vertices;
			if (array == null)
			{
				array = new Int3[0];
			}
			writerStream.Write(array.Length);
			for (int j = 0; j < array.Length; j++)
			{
				writerStream.Write(array[j].x);
				writerStream.Write(array[j].y);
				writerStream.Write(array[j].z);
			}
		}

		public static void DeSerializeMeshNodes(INavmesh graph, Node[] nodes, AstarSerializer serializer)
		{
			BinaryReader readerStream = serializer.readerStream;
			for (int i = 0; i < nodes.Length; i++)
			{
				MeshNode meshNode = nodes[i] as MeshNode;
				if (meshNode == null)
				{
					Debug.LogError("Serialization Error : Couldn't cast the node to the appropriate type - NavMeshGenerator");
					return;
				}
				meshNode.v1 = readerStream.ReadInt32();
				meshNode.v2 = readerStream.ReadInt32();
				meshNode.v3 = readerStream.ReadInt32();
			}
			int num = readerStream.ReadInt32();
			graph.vertices = new Int3[num];
			for (int j = 0; j < num; j++)
			{
				int x = readerStream.ReadInt32();
				int y = readerStream.ReadInt32();
				int z = readerStream.ReadInt32();
				graph.vertices[j] = new Int3(x, y, z);
			}
			RebuildBBTree(graph as NavGraph);
		}

		public void SerializeNodes(Node[] nodes, AstarSerializer serializer)
		{
			SerializeMeshNodes(this, nodes, serializer);
		}

		public void DeSerializeNodes(Node[] nodes, AstarSerializer serializer)
		{
			DeSerializeMeshNodes(this, nodes, serializer);
		}

		public void SerializeSettings(AstarSerializer serializer)
		{
			BinaryWriter writerStream = serializer.writerStream;
			serializer.AddValue("offset", offset);
			serializer.AddValue("rotation", rotation);
			serializer.AddValue("scale", scale);
			if (sourceMesh != null)
			{
				Vector3[] array = sourceMesh.vertices;
				int[] array2 = sourceMesh.triangles;
				writerStream.Write(array.Length);
				writerStream.Write(array2.Length);
				for (int i = 0; i < array.Length; i++)
				{
					writerStream.Write(array[i].x);
					writerStream.Write(array[i].y);
					writerStream.Write(array[i].z);
				}
				for (int j = 0; j < array2.Length; j++)
				{
					writerStream.Write(array2[j]);
				}
			}
			else
			{
				writerStream.Write(0);
				writerStream.Write(0);
			}
			serializer.AddUnityReferenceValue("sourceMesh", sourceMesh);
		}

		public void DeSerializeSettings(AstarSerializer serializer)
		{
			BinaryReader readerStream = serializer.readerStream;
			offset = (Vector3)serializer.GetValue("offset", typeof(Vector3));
			rotation = (Vector3)serializer.GetValue("rotation", typeof(Vector3));
			scale = (float)serializer.GetValue("scale", typeof(float));
			GenerateMatrix();
			Vector3[] array = new Vector3[readerStream.ReadInt32()];
			int[] array2 = new int[readerStream.ReadInt32()];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = new Vector3(readerStream.ReadSingle(), readerStream.ReadSingle(), readerStream.ReadSingle());
			}
			for (int j = 0; j < array2.Length; j++)
			{
				array2[j] = readerStream.ReadInt32();
			}
			sourceMesh = serializer.GetUnityReferenceValue("sourceMesh", typeof(Mesh)) as Mesh;
			if (Application.isPlaying)
			{
				sourceMesh = new Mesh();
				sourceMesh.name = "NavGraph Mesh";
				sourceMesh.vertices = array;
				sourceMesh.triangles = array2;
			}
		}
	}
}
