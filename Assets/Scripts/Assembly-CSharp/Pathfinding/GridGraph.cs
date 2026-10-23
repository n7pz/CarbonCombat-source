using System;
using System.Collections.Generic;
using UnityEngine;

namespace Pathfinding
{
	[Serializable]
	public class GridGraph : NavGraph, ISerializableObject, ISerializableGraph, IUpdatableGraph, IFunnelGraph
	{
		public int width;

		public int depth;

		public Vector3 rotation;

		public Bounds bounds;

		public Vector3 center;

		public Vector2 unclampedSize;

		public Vector2 size;

		public float nodeSize = 1f;

		public GraphCollision collision;

		public float maxClimb;

		public int maxClimbAxis = 1;

		public float maxSlope = 90f;

		public bool useRaycastNormal = true;

		public int erodeIterations;

		public bool autoLinkGrids;

		public float autoLinkDistLimit = 10f;

		[NonSerialized]
		public int[] neighbourOffsets;

		[NonSerialized]
		public int[] neighbourCosts;

		[NonSerialized]
		public int[] neighbourXOffsets;

		[NonSerialized]
		public int[] neighbourZOffsets;

		public GridNode[] graphNodes;

		public NumNeighbours neighbours = NumNeighbours.Eight;

		public bool cutCorners = true;

		public int getNearestForceLimit = 40;

		public bool penaltyPosition;

		public float penaltyPositionOffset;

		public float penaltyPositionFactor = 1f;

		public bool penaltyAngle;

		public float penaltyAngleFactor = 100f;

		public Matrix4x4 boundsMatrix;

		public Matrix4x4 boundsMatrix2;

		public Matrix4x4 inverseMatrix;

		public int scanns;

		[NonSerialized]
		private int[] corners;

		public virtual bool uniformWidhtDepthGrid
		{
			get
			{
				return true;
			}
		}

		public GridGraph()
		{
			unclampedSize = new Vector2(10f, 10f);
			nodeSize = 1f;
			collision = new GraphCollision();
		}

		public override Node[] CreateNodes(int number)
		{
			GridNode[] array = new GridNode[number];
			for (int i = 0; i < number; i++)
			{
				array[i] = new GridNode();
			}
			return array;
		}

		public override void OnDestroy()
		{
			base.OnDestroy();
			RemoveGridGraphFromStatic();
			graphNodes = null;
		}

		public void RemoveGridGraphFromStatic()
		{
			GridNode.RemoveGridGraph(this);
		}

		public void UpdateSizeFromWidthDepth()
		{
			unclampedSize = new Vector2(width, depth) * nodeSize;
			GenerateMatrix();
		}

		public void GenerateMatrix()
		{
			size = unclampedSize;
			size.x *= Mathf.Sign(size.x);
			size.y *= Mathf.Sign(size.y);
			nodeSize = Mathf.Clamp(nodeSize, size.x / 1024f, float.PositiveInfinity);
			nodeSize = Mathf.Clamp(nodeSize, size.y / 1024f, float.PositiveInfinity);
			size.x = ((!(size.x < nodeSize)) ? size.x : nodeSize);
			size.y = ((!(size.y < nodeSize)) ? size.y : nodeSize);
			boundsMatrix.SetTRS(center, Quaternion.Euler(rotation), Vector3.one);
			width = Mathf.FloorToInt(size.x / nodeSize);
			depth = Mathf.FloorToInt(size.y / nodeSize);
			if (Mathf.Approximately(size.x / nodeSize, Mathf.CeilToInt(size.x / nodeSize)))
			{
				width = Mathf.CeilToInt(size.x / nodeSize);
			}
			if (Mathf.Approximately(size.y / nodeSize, Mathf.CeilToInt(size.y / nodeSize)))
			{
				depth = Mathf.CeilToInt(size.y / nodeSize);
			}
			matrix.SetTRS(boundsMatrix.MultiplyPoint3x4(-new Vector3(size.x, 0f, size.y) * 0.5f), Quaternion.Euler(rotation), new Vector3(nodeSize, 1f, nodeSize));
			inverseMatrix = matrix.inverse;
		}

		public override NNInfo GetNearest(Vector3 position, NNConstraint constraint, Node hint = null)
		{
			if (graphNodes == null || depth * width != graphNodes.Length)
			{
				return default(NNInfo);
			}
			position = inverseMatrix.MultiplyPoint3x4(position);
			int num = Mathf.Clamp(Mathf.RoundToInt(position.x - 0.5f), 0, width - 1);
			int num2 = Mathf.Clamp(Mathf.RoundToInt(position.z - 0.5f), 0, depth - 1);
			return new NNInfo(nodes[num2 * width + num]);
		}

		public override NNInfo GetNearestForce(Vector3 position, NNConstraint constraint)
		{
			if (graphNodes == null || depth * width != graphNodes.Length)
			{
				return default(NNInfo);
			}
			Vector3 vector = position;
			position = inverseMatrix.MultiplyPoint3x4(position);
			int num = Mathf.Clamp(Mathf.RoundToInt(position.x - 0.5f), 0, width - 1);
			int num2 = Mathf.Clamp(Mathf.RoundToInt(position.z - 0.5f), 0, depth - 1);
			Node node = nodes[num + num2 * width];
			if (constraint.Suitable(node))
			{
				return node;
			}
			for (int i = 1; i < getNearestForceLimit; i++)
			{
				int num3 = num;
				int num4 = num2 + i;
				int num5 = num4 * width;
				float num6 = float.PositiveInfinity;
				Node node2 = null;
				for (num3 = num - i; num3 <= num + i; num3++)
				{
					if (num3 >= 0 && num4 >= 0 && num3 < width && num4 < depth && constraint.Suitable(nodes[num3 + num5]))
					{
						float sqrMagnitude = ((Vector3)nodes[num3 + num5].position - vector).sqrMagnitude;
						if (sqrMagnitude < num6)
						{
							num6 = sqrMagnitude;
							node2 = nodes[num3 + num5];
						}
					}
				}
				num4 = num2 - i;
				num5 = num4 * width;
				for (num3 = num - i; num3 <= num + i; num3++)
				{
					if (num3 >= 0 && num4 >= 0 && num3 < width && num4 < depth && constraint.Suitable(nodes[num3 + num5]))
					{
						float sqrMagnitude2 = ((Vector3)nodes[num3 + num5].position - vector).sqrMagnitude;
						if (sqrMagnitude2 < num6)
						{
							num6 = sqrMagnitude2;
							node2 = nodes[num3 + num5];
						}
					}
				}
				num3 = num - i;
				num4 = num2 - i + 1;
				for (num4 = num2 - i + 1; num4 <= num2 + i - 1; num4++)
				{
					if (num3 >= 0 && num4 >= 0 && num3 < width && num4 < depth && constraint.Suitable(nodes[num3 + num4 * width]))
					{
						float sqrMagnitude3 = ((Vector3)nodes[num3 + num4 * width].position - vector).sqrMagnitude;
						if (sqrMagnitude3 < num6)
						{
							num6 = sqrMagnitude3;
							node2 = nodes[num3 + num4 * width];
						}
					}
				}
				num3 = num + i;
				for (num4 = num2 - i + 1; num4 <= num2 + i - 1; num4++)
				{
					if (num3 >= 0 && num4 >= 0 && num3 < width && num4 < depth && constraint.Suitable(nodes[num3 + num4 * width]))
					{
						float sqrMagnitude4 = ((Vector3)nodes[num3 + num4 * width].position - vector).sqrMagnitude;
						if (sqrMagnitude4 < num6)
						{
							num6 = sqrMagnitude4;
							node2 = nodes[num3 + num4 * width];
						}
					}
				}
				if (node2 != null)
				{
					return node2;
				}
			}
			return null;
		}

		public virtual void SetUpOffsetsAndCosts()
		{
			neighbourOffsets = new int[8]
			{
				-width,
				1,
				width,
				-1,
				-width + 1,
				width + 1,
				width - 1,
				-width - 1
			};
			int num = Mathf.RoundToInt(nodeSize * 100f);
			int num2 = Mathf.RoundToInt(nodeSize * Mathf.Sqrt(2f) * 100f);
			neighbourCosts = new int[8] { num, num, num, num, num2, num2, num2, num2 };
			neighbourXOffsets = new int[8] { 0, 1, 0, -1, 1, 1, -1, -1 };
			neighbourZOffsets = new int[8] { -1, 0, 1, 0, -1, 1, 1, -1 };
		}

		public override void Scan()
		{
			AstarPath.OnPostScan = (OnScanDelegate)Delegate.Combine(AstarPath.OnPostScan, new OnScanDelegate(OnPostScan));
			scanns++;
			if (nodeSize <= 0f)
			{
				return;
			}
			GenerateMatrix();
			if (width > 1024 || depth > 1024)
			{
				Debug.LogError("One of the grid's sides is longer than 1024 nodes");
				return;
			}
			SetUpOffsetsAndCosts();
			int gridIndex = GridNode.SetGridGraph(this);
			nodes = CreateNodes(width * depth);
			graphNodes = nodes as GridNode[];
			if (collision == null)
			{
				collision = new GraphCollision();
			}
			collision.Initialize(matrix, nodeSize);
			for (int i = 0; i < depth; i++)
			{
				for (int j = 0; j < width; j++)
				{
					GridNode gridNode = graphNodes[i * width + j];
					gridNode.SetIndex(i * width + j);
					UpdateNodePositionCollision(gridNode, j, i);
					gridNode.SetGridIndex(gridIndex);
				}
			}
			for (int k = 0; k < depth; k++)
			{
				for (int l = 0; l < width; l++)
				{
					GridNode node = graphNodes[k * width + l];
					CalculateConnections(graphNodes, l, k, node);
				}
			}
			ErodeWalkableArea();
		}

		public void UpdateNodePositionCollision(Node node, int x, int z)
		{
			node.position = matrix.MultiplyPoint3x4(new Vector3((float)x + 0.5f, 0f, (float)z + 0.5f));
			bool walkable = true;
			RaycastHit hit;
			node.position = collision.CheckHeight(node.position, out hit, out walkable);
			node.penalty = 0;
			if (penaltyPosition)
			{
				node.penalty = Mathf.RoundToInt(((float)node.position.y - penaltyPositionOffset) * penaltyPositionFactor);
			}
			if (walkable && useRaycastNormal && collision.heightCheck && hit.normal != Vector3.zero)
			{
				float num = Vector3.Dot(hit.normal.normalized, Vector3.up);
				if (penaltyAngle)
				{
					node.penalty += Mathf.RoundToInt((1f - num) * penaltyAngleFactor);
				}
				float num2 = Mathf.Cos(maxSlope * ((float)Math.PI / 180f));
				if (num < num2)
				{
					walkable = false;
				}
			}
			if (walkable)
			{
				node.walkable = collision.Check(node.position);
			}
			else
			{
				node.walkable = walkable;
			}
		}

		public void ErodeWalkableArea()
		{
			for (int i = 0; i < erodeIterations; i++)
			{
				for (int j = 0; j < depth; j++)
				{
					for (int k = 0; k < width; k++)
					{
						GridNode gridNode = graphNodes[j * width + k];
						if (!gridNode.walkable)
						{
							int index = gridNode.GetIndex();
							for (int l = 0; l < 4; l++)
							{
								if (gridNode.GetConnection(l))
								{
									nodes[index + neighbourOffsets[l]].walkable = false;
								}
							}
							continue;
						}
						bool flag = false;
						for (int m = 0; m < 4; m++)
						{
							if (!gridNode.GetConnection(m))
							{
								flag = true;
								break;
							}
						}
						if (flag)
						{
							gridNode.walkable = false;
						}
					}
				}
				for (int n = 0; n < depth; n++)
				{
					for (int num = 0; num < width; num++)
					{
						GridNode node = graphNodes[n * width + num];
						CalculateConnections(graphNodes, num, n, node);
					}
				}
			}
		}

		public virtual bool IsValidConnection(GridNode n1, GridNode n2)
		{
			if (!n1.walkable || !n2.walkable)
			{
				return false;
			}
			if (maxClimb != 0f && (float)Mathf.Abs(n1.position[maxClimbAxis] - n2.position[maxClimbAxis]) > maxClimb * 100f)
			{
				return false;
			}
			return true;
		}

		public static void CalculateConnections(GridNode node)
		{
			GridGraph gridGraph = AstarData.GetGraph(node) as GridGraph;
			if (gridGraph != null)
			{
				int index = node.GetIndex();
				int x = index % gridGraph.width;
				int z = index / gridGraph.width;
				gridGraph.CalculateConnections(gridGraph.graphNodes, x, z, node);
			}
		}

		public void CalculateConnections(GridNode[] graphNodes, int x, int z, GridNode node)
		{
			node.flags &= -256;
			if (!node.walkable)
			{
				return;
			}
			int index = node.GetIndex();
			if (corners == null)
			{
				corners = new int[4];
			}
			else
			{
				for (int i = 0; i < 4; i++)
				{
					corners[i] = 0;
				}
			}
			int j = 0;
			int num = 3;
			for (; j < 4; j++)
			{
				int num2 = x + neighbourXOffsets[j];
				int num3 = z + neighbourZOffsets[j];
				if (num2 >= 0 && num3 >= 0 && num2 < width && num3 < depth)
				{
					GridNode n = graphNodes[index + neighbourOffsets[j]];
					if (IsValidConnection(node, n))
					{
						node.SetConnectionRaw(j, 1);
						corners[j]++;
						corners[num]++;
					}
				}
				num = j;
			}
			if (neighbours != NumNeighbours.Eight)
			{
				return;
			}
			if (cutCorners)
			{
				for (int k = 0; k < 4; k++)
				{
					if (corners[k] < 1)
					{
						continue;
					}
					int num4 = x + neighbourXOffsets[k + 4];
					int num5 = z + neighbourZOffsets[k + 4];
					if (num4 >= 0 && num5 >= 0 && num4 < width && num5 < depth)
					{
						GridNode n2 = graphNodes[index + neighbourOffsets[k + 4]];
						if (IsValidConnection(node, n2))
						{
							node.SetConnectionRaw(k + 4, 1);
						}
					}
				}
				return;
			}
			for (int l = 0; l < 4; l++)
			{
				if (corners[l] == 2)
				{
					GridNode n3 = graphNodes[index + neighbourOffsets[l + 4]];
					if (IsValidConnection(node, n3))
					{
						node.SetConnectionRaw(l + 4, 1);
					}
				}
			}
		}

		public void OnPostScan(AstarPath script)
		{
			AstarPath.OnPostScan = (OnScanDelegate)Delegate.Remove(AstarPath.OnPostScan, new OnScanDelegate(OnPostScan));
			if (!autoLinkGrids || autoLinkDistLimit <= 0f)
			{
				return;
			}
			int num = Mathf.RoundToInt(autoLinkDistLimit * 100f);
			foreach (GridGraph item in script.astarData.FindGraphsOfType(typeof(GridGraph)))
			{
				if (item == this || item.nodes == null || nodes == null)
				{
					continue;
				}
				for (int i = 0; i < width; i++)
				{
					Node node = nodes[i];
					Node node2 = item.GetNearest(node.position);
					if (!(inverseMatrix.MultiplyPoint3x4(node2.position).z > 0f))
					{
						int num2 = (int)(node.position - node2.position).magnitude;
						if (num2 <= num)
						{
							node.AddConnection(node2, num2);
							node2.AddConnection(node, num2);
						}
					}
				}
				for (int j = 0; j < depth; j++)
				{
					Node node3 = nodes[j * width];
					Node node4 = item.GetNearest(node3.position);
					if (!(inverseMatrix.MultiplyPoint3x4(node4.position).x > 0f))
					{
						int num3 = (int)(node3.position - node4.position).magnitude;
						if (num3 <= num)
						{
							node3.AddConnection(node4, num3);
							node4.AddConnection(node3, num3);
						}
					}
				}
				for (int k = 0; k < width; k++)
				{
					Node node5 = nodes[(depth - 1) * width + k];
					Node node6 = item.GetNearest(node5.position);
					if (!(inverseMatrix.MultiplyPoint3x4(node6.position).z < (float)(depth - 1)))
					{
						int num4 = (int)(node5.position - node6.position).magnitude;
						if (num4 <= num)
						{
							node5.AddConnection(node6, num4);
							node6.AddConnection(node5, num4);
						}
					}
				}
				for (int l = 0; l < depth; l++)
				{
					Node node7 = nodes[l * width + width - 1];
					Node node8 = item.GetNearest(node7.position);
					if (!(inverseMatrix.MultiplyPoint3x4(node8.position).x < (float)(width - 1)))
					{
						int num5 = (int)(node7.position - node8.position).magnitude;
						if (num5 <= num)
						{
							node7.AddConnection(node8, num5);
							node8.AddConnection(node7, num5);
						}
					}
				}
			}
		}

		public override void OnDrawGizmos(bool drawNodes)
		{
			Gizmos.matrix = boundsMatrix;
			Gizmos.color = Color.white;
			Gizmos.DrawWireCube(Vector3.zero, new Vector3(size.x, 0f, size.y));
			Gizmos.matrix = Matrix4x4.identity;
			if (!drawNodes || graphNodes == null || depth * width != graphNodes.Length)
			{
				return;
			}
			base.OnDrawGizmos(drawNodes);
			for (int i = 0; i < depth; i++)
			{
				for (int j = 0; j < width; j++)
				{
					GridNode gridNode = graphNodes[i * width + j];
					if (!gridNode.walkable)
					{
						continue;
					}
					Gizmos.color = NodeColor(gridNode);
					if (AstarPath.active.showSearchTree && Node.activePath != null && AstarPath.active.debugPath != null)
					{
						if (gridNode.pathID == AstarPath.active.debugPath.pathID && gridNode.parent != null)
						{
							Gizmos.DrawLine(gridNode.position, gridNode.parent.position);
						}
						continue;
					}
					for (int k = 0; k < 8; k++)
					{
						if (gridNode.GetConnection(k))
						{
							GridNode gridNode2 = graphNodes[gridNode.GetIndex() + neighbourOffsets[k]];
							Gizmos.DrawLine(gridNode.position, gridNode2.position);
						}
					}
				}
			}
		}

		public void UpdateArea(GraphUpdateObject o)
		{
			if (graphNodes == null || nodes == null)
			{
				Debug.LogWarning("The Grid Graph is not scanned, cannot update area ");
				return;
			}
			Bounds bounds = o.bounds;
			Vector3 v = inverseMatrix.MultiplyPoint3x4(bounds.min);
			Vector3 v2 = inverseMatrix.MultiplyPoint3x4(bounds.max);
			int num = Mathf.RoundToInt(v.x - 0.5f);
			int num2 = Mathf.RoundToInt(v2.x - 0.5f);
			int num3 = Mathf.RoundToInt(v.z - 0.5f);
			int num4 = Mathf.RoundToInt(v2.z - 0.5f);
			for (int i = num; i <= num2; i++)
			{
				for (int j = num3; j <= num4; j++)
				{
					if (i >= 0 && j >= 0)
					{
						if (j >= depth || i >= width)
						{
							break;
						}
						int num5 = j * width + i;
						GridNode node = graphNodes[num5];
						o.Apply(node);
					}
				}
			}
			if (!o.modifyWalkability && collision.collisionCheck)
			{
				Vector3 vector = new Vector3(collision.diameter, 0f, collision.diameter) * 0.5f;
				v -= vector * 1.02f;
				v2 += vector * 1.02f;
				Debug.DrawLine(matrix.MultiplyPoint3x4(v), matrix.MultiplyPoint3x4(v2), Color.cyan);
				num = Mathf.RoundToInt(v.x - 0.5f);
				num2 = Mathf.RoundToInt(v2.x - 0.5f);
				num3 = Mathf.RoundToInt(v.z - 0.5f);
				num4 = Mathf.RoundToInt(v2.z - 0.5f);
			}
			if (!o.modifyWalkability)
			{
				collision.Initialize(matrix, nodeSize);
				for (int k = num; k <= num2; k++)
				{
					for (int l = num3; l <= num4; l++)
					{
						if (k >= 0 && l >= 0)
						{
							if (l >= depth || k >= width)
							{
								break;
							}
							int num6 = l * width + k;
							GridNode node2 = graphNodes[num6];
							UpdateNodePositionCollision(node2, k, l);
						}
					}
				}
			}
			num--;
			num2++;
			num3--;
			num4++;
			for (int m = num; m <= num2; m++)
			{
				for (int n = num3; n <= num4; n++)
				{
					if (m >= 0 && n >= 0 && m < width && n < depth)
					{
						int num7 = n * width + m;
						GridNode node3 = graphNodes[num7];
						CalculateConnections(graphNodes, m, n, node3);
					}
				}
			}
		}

		public void SerializeNodes(Node[] nodes, AstarSerializer serializer)
		{
		}

		public void DeSerializeNodes(Node[] nodes, AstarSerializer serializer)
		{
		}

		public void BuildFunnelCorridor(Node[] path, int sIndex, int eIndex, List<Vector3> left, List<Vector3> right)
		{
			for (int i = sIndex; i < eIndex; i++)
			{
				GridNode n = path[i] as GridNode;
				GridNode n2 = path[i + 1] as GridNode;
				AddPortal(n, n2, left, right);
			}
		}

		public void AddPortal(Node n1, Node n2, List<Vector3> left, List<Vector3> right)
		{
		}

		public void AddPortal(GridNode n1, GridNode n2, List<Vector3> left, List<Vector3> right)
		{
			if (n1 == n2)
			{
				return;
			}
			int index = n1.GetIndex();
			int index2 = n2.GetIndex();
			int num = index % width;
			int num2 = index2 % width;
			int num3 = index / width;
			int num4 = index2 / width;
			Vector3 vector = n1.position;
			Vector3 vector2 = n2.position;
			int num5 = Mathf.Abs(num - num2);
			int num6 = Mathf.Abs(num3 - num4);
			if (num5 > 1 || num6 > 1)
			{
				left.Add(vector);
				right.Add(vector);
				left.Add(vector2);
				right.Add(vector2);
				return;
			}
			if (num5 + num6 <= 1)
			{
				Vector3 vector3 = (vector2 - vector).normalized * nodeSize * 0.5f;
				Vector3 vector4 = Vector3.Cross(vector3, Vector3.up).normalized * nodeSize * 0.5f;
				left.Add(vector + vector3 - vector4);
				right.Add(vector + vector3 + vector4);
				return;
			}
			Node node = nodes[num3 * width + num2];
			Node node2 = nodes[num4 * width + num];
			Node node3 = null;
			if (node.walkable)
			{
				node3 = node;
			}
			else if (node2.walkable)
			{
				node3 = node2;
			}
			if (node3 == null)
			{
				Vector3 item = (vector + vector2) * 0.5f;
				left.Add(item);
				right.Add(item);
			}
			else
			{
				AddPortal(n1, (GridNode)node3, left, right);
				AddPortal((GridNode)node3, n2, left, right);
			}
		}

		public bool CheckConnection(GridNode node, int dir)
		{
			if (neighbours == NumNeighbours.Eight)
			{
				return node.GetConnection(dir);
			}
			int num = (dir - 4 - 1) & 3;
			int num2 = (dir - 4 + 1) & 3;
			if (!node.GetConnection(num) || !node.GetConnection(num2))
			{
				return false;
			}
			GridNode gridNode = nodes[node.GetIndex() + neighbourOffsets[num]] as GridNode;
			GridNode gridNode2 = nodes[node.GetIndex() + neighbourOffsets[num2]] as GridNode;
			if (!gridNode.walkable || !gridNode2.walkable)
			{
				return false;
			}
			if (!gridNode2.GetConnection(num) || !gridNode.GetConnection(num2))
			{
				return false;
			}
			return true;
		}

		public void SerializeSettings(AstarSerializer serializer)
		{
			serializer.mask -= AstarSerializer.SMask.SaveNodePositions;
			serializer.AddValue("unclampedSize", unclampedSize);
			serializer.AddValue("cutCorners", cutCorners);
			serializer.AddValue("neighbours", (int)neighbours);
			serializer.AddValue("center", center);
			serializer.AddValue("rotation", rotation);
			serializer.AddValue("nodeSize", nodeSize);
			serializer.AddValue("collision", (collision != null) ? collision : new GraphCollision());
			serializer.AddValue("maxClimb", maxClimb);
			serializer.AddValue("maxClimbAxis", maxClimbAxis);
			serializer.AddValue("maxSlope", maxSlope);
			serializer.AddValue("erodeIterations", erodeIterations);
			serializer.AddValue("penaltyAngle", penaltyAngle);
			serializer.AddValue("penaltyAngleFactor", penaltyAngleFactor);
			serializer.AddValue("penaltyPosition", penaltyPosition);
			serializer.AddValue("penaltyPositionOffset", penaltyPositionOffset);
			serializer.AddValue("penaltyPositionFactor", penaltyPositionFactor);
		}

		public void DeSerializeSettings(AstarSerializer serializer)
		{
			unclampedSize = (Vector2)serializer.GetValue("unclampedSize", typeof(Vector2));
			cutCorners = (bool)serializer.GetValue("cutCorners", typeof(bool));
			neighbours = (NumNeighbours)(int)serializer.GetValue("neighbours", typeof(int));
			rotation = (Vector3)serializer.GetValue("rotation", typeof(Vector3));
			nodeSize = (float)serializer.GetValue("nodeSize", typeof(float));
			collision = (GraphCollision)serializer.GetValue("collision", typeof(GraphCollision));
			center = (Vector3)serializer.GetValue("center", typeof(Vector3));
			maxClimb = (float)serializer.GetValue("maxClimb", typeof(float));
			maxClimbAxis = (int)serializer.GetValue("maxClimbAxis", typeof(int), 1);
			maxSlope = (float)serializer.GetValue("maxSlope", typeof(float), 90f);
			erodeIterations = (int)serializer.GetValue("erodeIterations", typeof(int));
			penaltyAngle = (bool)serializer.GetValue("penaltyAngle", typeof(bool));
			penaltyAngleFactor = (float)serializer.GetValue("penaltyAngleFactor", typeof(float));
			penaltyPosition = (bool)serializer.GetValue("penaltyPosition", typeof(bool));
			penaltyPositionOffset = (float)serializer.GetValue("penaltyPositionOffset", typeof(float));
			penaltyPositionFactor = (float)serializer.GetValue("penaltyPositionFactor", typeof(float));
			Matrix4x4 matrix4x = matrix;
			GenerateMatrix();
			SetUpOffsetsAndCosts();
			if (serializer.onlySaveSettings && matrix4x != matrix && nodes != null)
			{
				AstarPath.active.AutoScan();
			}
		}
	}
}
