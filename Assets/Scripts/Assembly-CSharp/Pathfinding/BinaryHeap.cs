using System.Text;
using UnityEngine;

namespace Pathfinding
{
	public class BinaryHeap
	{
		public Node[] binaryHeap;

		public int numberOfItems;

		public BinaryHeap(int numberOfElements)
		{
			binaryHeap = new Node[numberOfElements];
			numberOfItems = 2;
		}

		public void Add(Node node)
		{
			if (node == null)
			{
				Debug.Log("Sending null node to BinaryHeap");
				return;
			}
			if (numberOfItems == binaryHeap.Length)
			{
				Debug.Log("Forced to discard nodes because of binary heap size limit, please consider increasing the size (" + numberOfItems + " " + binaryHeap.Length + ")");
				numberOfItems--;
			}
			binaryHeap[numberOfItems] = node;
			int num = numberOfItems;
			int f = node.f;
			while (num != 1)
			{
				int num2 = num / 2;
				if (f <= binaryHeap[num2].f)
				{
					binaryHeap[num] = binaryHeap[num2];
					binaryHeap[num2] = node;
					num = num2;
					continue;
				}
				break;
			}
			numberOfItems++;
		}

		public Node Remove()
		{
			numberOfItems--;
			Node result = binaryHeap[1];
			binaryHeap[1] = binaryHeap[numberOfItems];
			int num = 1;
			int num2 = 1;
			do
			{
				num2 = num;
				int num3 = num2 * 2;
				if (num3 + 1 <= numberOfItems)
				{
					if (binaryHeap[num2].f >= binaryHeap[num3].f)
					{
						num = num3;
					}
					if (binaryHeap[num].f >= binaryHeap[num3 + 1].f)
					{
						num = num3 + 1;
					}
				}
				else if (num3 <= numberOfItems && binaryHeap[num2].f >= binaryHeap[num3].f)
				{
					num = num3;
				}
				if (num2 != num)
				{
					Node node = binaryHeap[num2];
					binaryHeap[num2] = binaryHeap[num];
					binaryHeap[num] = node;
				}
			}
			while (num2 != num);
			return result;
		}

		public void BubbleDown(Node node)
		{
			int num = 0;
			if (num < 1 || num > numberOfItems)
			{
				Debug.LogError("Node is not in the heap (index " + num + ")");
				Add(node);
				return;
			}
			while (num != 1)
			{
				int num2 = num / 2;
				if (binaryHeap[num].f <= binaryHeap[num2].f)
				{
					Node node2 = binaryHeap[num2];
					binaryHeap[num2] = binaryHeap[num];
					binaryHeap[num] = node2;
					num = num2;
					continue;
				}
				break;
			}
		}

		public void Rebuild()
		{
			for (int i = 2; i < numberOfItems; i++)
			{
				int num = i;
				Node node = binaryHeap[i];
				int f = node.f;
				while (num != 1)
				{
					int num2 = num / 2;
					if (f < binaryHeap[num2].f)
					{
						binaryHeap[num] = binaryHeap[num2];
						binaryHeap[num2] = node;
						num = num2;
						continue;
					}
					break;
				}
			}
		}

		public void Rearrange(Node node)
		{
			for (int i = 0; i < numberOfItems; i++)
			{
				if (binaryHeap[i] != node)
				{
					continue;
				}
				int num = i;
				while (num != 1)
				{
					int num2 = num / 2;
					if (binaryHeap[num].f <= binaryHeap[num2].f)
					{
						Node node2 = binaryHeap[num2];
						binaryHeap[num2] = binaryHeap[num];
						binaryHeap[num] = node2;
						num = num2;
						continue;
					}
					return;
				}
			}
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("\n=== Writing Binary Heap ===\n");
			stringBuilder.Append("Number of items: ").Append(numberOfItems - 2);
			stringBuilder.Append("Capacity: ").Append(binaryHeap.Length);
			stringBuilder.Append("\n");
			if (numberOfItems > 2)
			{
				WriteBranch(1, 1, stringBuilder);
			}
			stringBuilder.Append("\n\n");
			return stringBuilder.ToString();
		}

		private void WriteBranch(int index, int depth, StringBuilder text)
		{
			text.Append("\n");
			for (int i = 0; i < depth; i++)
			{
				text.Append("   ");
			}
			text.Append(binaryHeap[index].f);
			if (index > 1)
			{
				int num = index / 2;
				if (binaryHeap[index].f < binaryHeap[num].f)
				{
					text.Append("\t!!!");
				}
			}
			int num2 = index * 2;
			if (num2 + 1 <= numberOfItems)
			{
				WriteBranch(num2, depth + 1, text);
				WriteBranch(num2 + 1, depth + 1, text);
			}
			else if (num2 <= numberOfItems)
			{
				WriteBranch(num2, depth + 1, text);
			}
		}
	}
}
