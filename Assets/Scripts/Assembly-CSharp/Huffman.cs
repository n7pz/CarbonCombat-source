using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public sealed class Huffman : IDisposable
{
	internal class Leaf
	{
		public Guid ID;

		public Guid ParentID;

		public bool IsNode;

		public bool Left;

		public bool Right;

		public byte ByteValue;

		public int BitValue;

		public int BitCount;

		public long FrequencyValue;

		public Leaf()
		{
			ID = Guid.NewGuid();
		}
	}

	private List<Leaf> HuffmanTree = new List<Leaf>();

	private MemoryStream msInputbytes = new MemoryStream();

	private StringBuilder Log = new StringBuilder();

	private bool LogEnabled;

	public Huffman()
	{
		Init();
	}

	public Huffman(byte[] bInput)
	{
		Init();
		foreach (byte b in bInput)
		{
			HuffmanTree[b].FrequencyValue++;
			msInputbytes.WriteByte(b);
		}
	}

	public Huffman(string sInput)
	{
		Init();
		foreach (char c in sInput)
		{
			HuffmanTree[c].FrequencyValue++;
			msInputbytes.WriteByte((byte)c);
		}
	}

	public void Dispose()
	{
		msInputbytes.Dispose();
		HuffmanTree = null;
		Log = null;
	}

	public void Add(byte b)
	{
		HuffmanTree[b].FrequencyValue++;
		BuildTree();
	}

	public void Add(string s)
	{
		foreach (char index in s)
		{
			HuffmanTree[index].FrequencyValue++;
		}
	}

	public void Clear()
	{
		msInputbytes.Dispose();
		msInputbytes = new MemoryStream();
	}

	public byte[] Encode(out string OutputLog)
	{
		LogEnabled = true;
		BuildTree();
		EncodeTree();
		byte[] result = Encode();
		OutputLog = Log.ToString();
		return result;
	}

	public byte[] Encode()
	{
		long num = 0L;
		int num2 = 0;
		int num3 = 0;
		MemoryStream memoryStream = new MemoryStream();
		BuildTree();
		EncodeTree();
		List<Leaf> list = new List<Leaf>(HuffmanTree);
		list.RemoveAll((Leaf leaf2) => leaf2.IsNode);
		MemoryStream memoryStream2 = new MemoryStream();
		foreach (Leaf item in list)
		{
			if (!item.IsNode & (item.FrequencyValue > 0))
			{
				num = (int)item.ByteValue;
				num <<= 8;
				num ^= item.BitCount;
				num <<= 48;
				num ^= item.BitValue;
				memoryStream2.Write(BitConverter.GetBytes(num), 0, 8);
				num3++;
				num = 0L;
			}
		}
		memoryStream.Write(BitConverter.GetBytes(msInputbytes.Length), 0, 8);
		memoryStream.WriteByte((byte)(num3 - 1));
		memoryStream.Write(memoryStream2.ToArray(), 0, Convert.ToInt16(memoryStream2.Length));
		memoryStream.Write(new byte[3] { 66, 67, 68 }, 0, 3);
		num = 0L;
		num2 = 0;
		byte[] array = msInputbytes.ToArray();
		foreach (byte index in array)
		{
			Leaf leaf = list[index];
			num2 += leaf.BitCount;
			if (num != 0L)
			{
				num <<= leaf.BitCount;
				num ^= leaf.BitValue;
			}
			else
			{
				num = leaf.BitValue;
			}
			while (num2 > 7)
			{
				int num5 = (int)(num >> num2 - 8);
				memoryStream.WriteByte((byte)num5);
				num2 -= 8;
				num5 <<= num2;
				num ^= num5;
			}
		}
		if (num2 > 0)
		{
			num <<= 8 - num2;
			memoryStream.WriteByte((byte)num);
		}
		return memoryStream.ToArray();
	}

	public byte[] Decode(byte[] bInput)
	{
		List<Leaf> list = new List<Leaf>(255);
		Leaf leaf = null;
		long num = 0L;
		long num2 = 0L;
		int num3 = 0;
		int num4 = 0;
		int num5 = 0;
		int num6 = 0;
		int num7 = 0;
		for (int i = 0; i < 256; i++)
		{
			list.Add(new Leaf());
		}
		num2 = BitConverter.ToInt64(bInput, 0);
		byte[] array = new byte[num2];
		num5 = bInput[8];
		num6 = (num5 + 1) * 8 + 8;
		for (int j = 9; j <= num6; j += 8)
		{
			num = BitConverter.ToInt64(bInput, j);
			leaf = new Leaf();
			leaf.ByteValue = (byte)(num >> 56);
			if (leaf.ByteValue != 0)
			{
				num ^= (long)(int)leaf.ByteValue << 56;
			}
			leaf.BitCount = (int)(num >> 48);
			num ^= (long)leaf.BitCount << 48;
			leaf.BitValue = (int)num;
			list[leaf.ByteValue] = leaf;
		}
		num = 0L;
		for (int k = num6 + 4; k < bInput.Length; k++)
		{
			num3 += 8;
			if (num != 0L)
			{
				num <<= 8;
				num ^= (int)bInput[k];
			}
			else
			{
				num = (int)bInput[k];
			}
			for (int num8 = num3 - 1; num8 >= 0; num8--)
			{
				num4 = (int)(num >> num8);
				if (num4 != 0)
				{
					int num9 = num3 - num8;
					for (int l = 0; l < 256; l++)
					{
						if (list[l].BitValue == num4 && list[l].BitCount == num9)
						{
							array[num7] = list[l].ByteValue;
							num4 <<= num8;
							num ^= num4;
							num3 = num8;
							num7++;
							break;
						}
					}
				}
			}
		}
		return array;
	}

	private void Init()
	{
		for (short num = 0; num <= 255; num++)
		{
			HuffmanTree.Add(new Leaf
			{
				ByteValue = (byte)num
			});
		}
	}

	private bool EncodeTree()
	{
		int num = 0;
		int num2 = 0;
		foreach (Leaf Node in HuffmanTree)
		{
			if (Node.IsNode || Node.FrequencyValue == 0L)
			{
				continue;
			}
			num = 0;
			num2 = 0;
			if (Node.Left || Node.Right)
			{
				if (Node.Left)
				{
					num2++;
				}
				else if (Node.Right)
				{
					num ^= 1 << (num2 & 0x1F);
					num2++;
				}
				Leaf ParentNode = HuffmanTree.Find((Leaf leaf) => leaf.ID == Node.ParentID);
				while (ParentNode.ParentID != default(Guid))
				{
					if (ParentNode.Left)
					{
						num2++;
					}
					else if (ParentNode.Right)
					{
						num ^= 1 << (num2 & 0x1F);
						num2++;
					}
					ParentNode = HuffmanTree.Find((Leaf leaf) => leaf.ID == ParentNode.ParentID);
				}
			}
			Node.BitValue = num;
			Node.BitCount = num2;
			if (Node.BitValue == 0)
			{
				Node.BitValue = 1;
				Node.BitCount++;
			}
			if (LogEnabled)
			{
				Log.AppendLine(string.Format("{0} = {1} (Bits: {2})", (int)Node.ByteValue, Convert.ToString(Node.BitValue, 2), Node.BitCount));
			}
		}
		return true;
	}

	private bool BuildTree()
	{
		Debug.Log("Calling Build Tree");
		int num = 0;
		List<Leaf> list = new List<Leaf>(HuffmanTree);
		list.RemoveAll((Leaf leaf3) => leaf3.FrequencyValue == 0);
		list.Sort((Leaf L1, Leaf L2) => L1.FrequencyValue.CompareTo(L2.FrequencyValue));
		List<Leaf> WorkingTree = new List<Leaf>(list);
		while (WorkingTree.Count > 1)
		{
			WorkingTree.Sort((Leaf L1, Leaf L2) => L1.FrequencyValue.CompareTo(L2.FrequencyValue));
			Leaf leaf = new Leaf();
			leaf.FrequencyValue = WorkingTree[0].FrequencyValue + WorkingTree[1].FrequencyValue;
			leaf.IsNode = true;
			Leaf leaf2 = leaf;
			HuffmanTree.Add(leaf2);
			num = HuffmanTree.FindIndex((Leaf L1) => L1.Equals(WorkingTree[0]));
			HuffmanTree[num].Left = true;
			HuffmanTree[num].ParentID = leaf2.ID;
			num = HuffmanTree.FindIndex((Leaf L1) => L1.Equals(WorkingTree[1]));
			HuffmanTree[num].Right = true;
			HuffmanTree[num].ParentID = leaf2.ID;
			list.Clear();
			list.AddRange(HuffmanTree.ToArray());
			list.RemoveAll((Leaf leaf3) => leaf3.FrequencyValue == 0);
			list.Sort((Leaf L1, Leaf L2) => L1.FrequencyValue.CompareTo(L2.FrequencyValue));
			WorkingTree.Clear();
			WorkingTree.AddRange(list.ToArray());
			WorkingTree.RemoveAll((Leaf leaf3) => leaf3.ParentID != default(Guid));
		}
		return true;
	}
}
