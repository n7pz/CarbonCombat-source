using System.Collections.Generic;

namespace Pathfinding
{
	public class GridNode : Node
	{
		protected int indices;

		public static GridGraph[] gridGraphs;

		public bool GetConnection(int i)
		{
			return ((flags >> i) & 1) == 1;
		}

		public void SetConnection(int i, int value)
		{
			flags = (flags & ~(1 << i)) | (value << i);
		}

		public void SetConnectionRaw(int i, int value)
		{
			flags |= value << i;
		}

		public int GetGridIndex()
		{
			return indices >> 24;
		}

		public int GetIndex()
		{
			return indices & 0xFFFFFF;
		}

		public void SetIndex(int i)
		{
			indices &= -16777216;
			indices |= i;
		}

		public void SetGridIndex(int gridIndex)
		{
			indices &= 16777215;
			indices |= gridIndex << 24;
		}

		public void UpdateGridConnections()
		{
			GridGraph gridGraph = gridGraphs[indices >> 24];
			int num = indices & 0xFFFFFF;
			int num2 = num % gridGraph.width;
			int num3 = num / gridGraph.width;
			gridGraph.CalculateConnections(gridGraph.graphNodes, num2, num3, this);
			int[] neighbourOffsets = gridGraph.neighbourOffsets;
			int[] neighbourXOffsets = gridGraph.neighbourXOffsets;
			int[] neighbourZOffsets = gridGraph.neighbourZOffsets;
			for (int i = 0; i < 8; i++)
			{
				int num4 = num2 + neighbourXOffsets[i];
				int num5 = num3 + neighbourZOffsets[i];
				if (num4 >= 0 && num5 >= 0 && num4 < gridGraph.width && num5 < gridGraph.depth)
				{
					GridNode node = (GridNode)gridGraph.nodes[num + neighbourOffsets[i]];
					gridGraph.CalculateConnections(gridGraph.graphNodes, num4, num5, node);
				}
			}
		}

		public override void UpdateAllG(BinaryHeap open)
		{
			base.UpdateAllG(open);
			int num = indices & 0xFFFFFF;
			int[] neighbourOffsets = gridGraphs[indices >> 24].neighbourOffsets;
			GridNode[] graphNodes = gridGraphs[indices >> 24].graphNodes;
			for (int i = 0; i < 8; i++)
			{
				if (((flags >> i) & 1) == 1)
				{
					Node node = graphNodes[num + neighbourOffsets[i]];
					if (node.parent == this && node.pathID == base.pathID)
					{
						node.UpdateAllG(open);
					}
				}
			}
		}

		public override void FloodFill(Stack<Node> stack, int area)
		{
			base.FloodFill(stack, area);
			GridGraph gridGraph = gridGraphs[indices >> 24];
			int num = indices & 0xFFFFFF;
			int[] neighbourOffsets = gridGraph.neighbourOffsets;
			GridNode[] graphNodes = gridGraph.graphNodes;
			for (int i = 0; i < 8; i++)
			{
				if (((flags >> i) & 1) == 1)
				{
					Node node = graphNodes[num + neighbourOffsets[i]];
					if (node.walkable && node.area != area)
					{
						stack.Push(node);
						node.area = area;
					}
				}
			}
		}

		public override int[] InitialOpen(BinaryHeap open, Int3 targetPosition, Int3 position, Path path, bool doOpen)
		{
			if (doOpen)
			{
				Open(open, targetPosition, path);
			}
			return base.InitialOpen(open, targetPosition, position, path, doOpen);
		}

		public override void Open(BinaryHeap open, Int3 targetPosition, Path path)
		{
			base.Open(open, targetPosition, path);
			GridGraph gridGraph = gridGraphs[indices >> 24];
			int[] neighbourOffsets = gridGraph.neighbourOffsets;
			int[] neighbourCosts = gridGraph.neighbourCosts;
			GridNode[] graphNodes = gridGraph.graphNodes;
			int num = indices & 0xFFFFFF;
			for (int i = 0; i < 8; i++)
			{
				if (((flags >> i) & 1) != 1)
				{
					continue;
				}
				Node node = graphNodes[num + neighbourOffsets[i]];
				if (node.pathID != base.pathID)
				{
					node.parent = this;
					node.pathID = base.pathID;
					node.cost = neighbourCosts[i];
					node.UpdateH(targetPosition, path.heuristic, path.heuristicScale);
					node.UpdateG();
					open.Add(node);
					continue;
				}
				int num2 = neighbourCosts[i];
				if (g + num2 + node.penalty < node.g)
				{
					node.cost = num2;
					node.parent = this;
					node.UpdateAllG(open);
				}
				else if (node.g + num2 + penalty < g)
				{
					parent = node;
					cost = num2;
					UpdateAllG(open);
				}
			}
		}

		public static void RemoveGridGraph(GridGraph graph)
		{
			if (gridGraphs == null)
			{
				return;
			}
			for (int i = 0; i < gridGraphs.Length; i++)
			{
				if (gridGraphs[i] != graph)
				{
					continue;
				}
				if (gridGraphs.Length == 1)
				{
					gridGraphs = null;
					break;
				}
				for (int j = i + 1; j < gridGraphs.Length; j++)
				{
					GridGraph gridGraph = gridGraphs[j];
					if (gridGraph.nodes != null)
					{
						for (int k = 0; k < gridGraph.nodes.Length; k++)
						{
							((GridNode)gridGraph.nodes[k]).SetGridIndex(j - 1);
						}
					}
				}
				GridGraph[] array = new GridGraph[gridGraphs.Length - 1];
				for (int l = 0; l < i; l++)
				{
					array[l] = gridGraphs[l];
				}
				for (int m = i + 1; m < gridGraphs.Length; m++)
				{
					array[m - 1] = gridGraphs[m];
				}
				break;
			}
		}

		public static int SetGridGraph(GridGraph graph)
		{
			if (gridGraphs == null)
			{
				gridGraphs = new GridGraph[1];
			}
			else
			{
				for (int i = 0; i < gridGraphs.Length; i++)
				{
					if (gridGraphs[i] == graph)
					{
						return i;
					}
				}
				GridGraph[] array = new GridGraph[gridGraphs.Length + 1];
				for (int j = 0; j < gridGraphs.Length; j++)
				{
					array[j] = gridGraphs[j];
				}
				gridGraphs = array;
			}
			gridGraphs[gridGraphs.Length - 1] = graph;
			return gridGraphs.Length - 1;
		}
	}
}
