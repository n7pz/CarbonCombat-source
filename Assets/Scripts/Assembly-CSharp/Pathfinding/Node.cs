using System.Collections.Generic;
using UnityEngine;

namespace Pathfinding
{
	public class Node
	{
		private const int WalkableBitNumber = 23;

		private const int WalkableBit = 8388608;

		private const int AreaBitNumber = 24;

		private const int AreaBitsSize = 255;

		private const int NotAreaBits = 16777215;

		private const int GraphIndexBitNumber = 18;

		private const int GraphIndexBitsSize = 31;

		private const int NotGraphIndexBits = -8126465;

		public Int3 position;

		public Node parent;

		public int pathIDx;

		public static Path activePath;

		public int g;

		public int h;

		public int cost;

		public int penalty;

		public Node[] connections;

		public int[] connectionCosts;

		public int flags;

		public int pathID
		{
			get
			{
				return pathIDx & 0xFFFF;
			}
			set
			{
				pathIDx = (pathIDx & -65536) | value;
			}
		}

		public bool Bit8
		{
			get
			{
				return (flags & 0x100) != 0;
			}
			set
			{
				flags = (flags & -257) | (value ? 256 : 0);
			}
		}

		public bool walkable
		{
			get
			{
				return (flags & 0x800000) == 8388608;
			}
			set
			{
				flags = (flags & -8388609) | (value ? 8388608 : 0);
			}
		}

		public int area
		{
			get
			{
				return (flags >> 24) & 0xFF;
			}
			set
			{
				flags = (flags & 0xFFFFFF) | (value << 24);
			}
		}

		public int graphIndex
		{
			get
			{
				return (flags >> 18) & 0x1F;
			}
			set
			{
				flags = (flags & -8126465) | ((value & 0x1F) << 18);
			}
		}

		public int f
		{
			get
			{
				return g + h;
			}
		}

		public virtual void UpdateH(Int3 targetPosition, Heuristic heuristic, float scale)
		{
			switch (heuristic)
			{
			case Heuristic.None:
				h = 0;
				break;
			case Heuristic.Manhattan:
				h = Mathfx.RoundToInt((float)(Abs(position.x - targetPosition.x) + Abs(position.y - targetPosition.y) + Abs(position.z - targetPosition.z)) * scale);
				break;
			case Heuristic.DiagonalManhattan:
			{
				int num = Abs(position.x - targetPosition.x);
				int num2 = Abs(position.z - targetPosition.z);
				if (num > num2)
				{
					h = (14 * num2 + 10 * (num - num2)) / 10;
				}
				else
				{
					h = (14 * num + 10 * (num2 - num)) / 10;
				}
				h = Mathfx.RoundToInt((float)h * scale);
				break;
			}
			default:
				h = Mathfx.RoundToInt((position - targetPosition).magnitude * scale);
				break;
			}
		}

		public static int Abs(int x)
		{
			return (x >= 0) ? x : (-x);
		}

		public virtual void UpdateG()
		{
			g = parent.g + cost + penalty;
		}

		public virtual void UpdateAllG(BinaryHeap open)
		{
			BaseUpdateAllG(open);
		}

		public void BaseUpdateAllG(BinaryHeap open)
		{
			g = parent.g + cost + penalty;
			open.Add(this);
			if (connections == null)
			{
				return;
			}
			for (int i = 0; i < connections.Length; i++)
			{
				if (connections[i].parent == this && connections[i].pathID == pathID)
				{
					connections[i].UpdateAllG(open);
				}
			}
		}

		public virtual int[] InitialOpen(BinaryHeap open, Int3 targetPosition, Int3 position, Path path, bool doOpen)
		{
			return BaseInitialOpen(open, targetPosition, position, path, doOpen);
		}

		public int[] BaseInitialOpen(BinaryHeap open, Int3 targetPosition, Int3 position, Path path, bool doOpen)
		{
			if (connectionCosts == null)
			{
				return null;
			}
			int[] result = connectionCosts;
			connectionCosts = new int[connectionCosts.Length];
			for (int i = 0; i < connectionCosts.Length; i++)
			{
				connectionCosts[i] = Mathf.RoundToInt((connections[i].position - position).magnitude);
			}
			if (!doOpen)
			{
				for (int j = 0; j < connectionCosts.Length; j++)
				{
					Node node = connections[j];
					for (int k = 0; k < node.connections.Length; k++)
					{
						if (node.connections[k] == this)
						{
							node.connectionCosts[k] = connectionCosts[j];
							break;
						}
					}
				}
			}
			if (doOpen)
			{
				Open(open, targetPosition, path);
				connectionCosts = result;
			}
			return result;
		}

		public virtual void ResetCosts(int[] costs)
		{
			BaseResetCosts(costs);
		}

		public void BaseResetCosts(int[] costs)
		{
			connectionCosts = costs;
			if (connectionCosts == null)
			{
				return;
			}
			for (int i = 0; i < connectionCosts.Length; i++)
			{
				Node node = connections[i];
				for (int j = 0; j < node.connections.Length; j++)
				{
					if (node.connections[j] == this)
					{
						node.connectionCosts[j] = connectionCosts[i];
						break;
					}
				}
			}
		}

		public virtual void Open(BinaryHeap open, Int3 targetPosition, Path path)
		{
			BaseOpen(open, targetPosition, path);
		}

		public void BaseOpen(BinaryHeap open, Int3 targetPosition, Path path)
		{
			if (connections == null)
			{
				return;
			}
			for (int i = 0; i < connections.Length; i++)
			{
				Node node = connections[i];
				if (!node.walkable)
				{
					continue;
				}
				if (node.pathID != pathID)
				{
					node.parent = this;
					node.pathID = pathID;
					node.cost = connectionCosts[i];
					node.UpdateH(targetPosition, path.heuristic, path.heuristicScale);
					node.UpdateG();
					open.Add(node);
					continue;
				}
				int num = connectionCosts[i];
				if (g + num + node.penalty < node.g)
				{
					node.cost = num;
					node.parent = this;
					node.UpdateAllG(open);
					open.Add(node);
				}
				else
				{
					if (node.g + num + penalty >= g)
					{
						continue;
					}
					bool flag = false;
					if (node.connections != null)
					{
						for (int j = 0; j < node.connections.Length; j++)
						{
							if (node.connections[j] == this)
							{
								flag = true;
								break;
							}
						}
					}
					if (flag)
					{
						parent = node;
						cost = num;
						UpdateAllG(open);
						open.Add(this);
					}
				}
			}
		}

		public virtual void FloodFill(Stack<Node> stack, int area)
		{
			BaseFloodFill(stack, area);
		}

		public void BaseFloodFill(Stack<Node> stack, int area)
		{
			if (connections == null)
			{
				return;
			}
			for (int i = 0; i < connections.Length; i++)
			{
				if (connections[i].walkable && connections[i].area != area)
				{
					stack.Push(connections[i]);
					connections[i].area = area;
				}
			}
		}

		public virtual void UpdateConnections()
		{
			if (connections == null)
			{
				return;
			}
			List<Node> list = null;
			List<int> list2 = null;
			for (int i = 0; i < connections.Length; i++)
			{
				if (!connections[i].walkable)
				{
					if (list == null)
					{
						list = new List<Node>(connections.Length - 1);
						list2 = new List<int>(connections.Length - 1);
						for (int j = 0; j < i; j++)
						{
							list.Add(connections[j]);
							list2.Add(connectionCosts[j]);
						}
					}
				}
				else if (list != null)
				{
					list.Add(connections[i]);
					list2.Add(connectionCosts[i]);
				}
			}
		}

		public virtual bool ContainsConnection(Node node)
		{
			if (connections != null)
			{
				for (int i = 0; i < connections.Length; i++)
				{
					if (connections[i] == node)
					{
						return true;
					}
				}
			}
			return false;
		}

		public void AddConnection(Node node, int cost)
		{
			if (connections == null)
			{
				connections = new Node[0];
				connectionCosts = new int[0];
			}
			else
			{
				for (int i = 0; i < connections.Length; i++)
				{
					if (connections[i] == node)
					{
						connectionCosts[i] = cost;
						return;
					}
				}
			}
			Node[] array = connections;
			int[] array2 = connectionCosts;
			connections = new Node[connections.Length + 1];
			connectionCosts = new int[connections.Length];
			for (int j = 0; j < array.Length; j++)
			{
				connections[j] = array[j];
				connectionCosts[j] = array2[j];
			}
			connections[array.Length] = node;
			connectionCosts[array.Length] = cost;
		}

		public bool RemoveConnection(Node node)
		{
			for (int i = 0; i < connections.Length; i++)
			{
				if (connections[i] == node)
				{
					connections[i] = connections[connections.Length - 1];
					connectionCosts[i] = connectionCosts[connectionCosts.Length - 1];
					Node[] array = new Node[connections.Length - 1];
					int[] array2 = new int[connections.Length - 1];
					int num = 0;
					while (num < connections.Length - 1)
					{
						array[num] = connections[num];
						array2[num] = connectionCosts[num];
						i++;
					}
					connections = array;
					connectionCosts = array2;
					return true;
				}
			}
			return false;
		}
	}
}
