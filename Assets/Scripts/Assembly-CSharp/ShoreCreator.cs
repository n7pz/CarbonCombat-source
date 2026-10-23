using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoreCreator : MonoBehaviour
{
	private class Triangle
	{
		public int idx;

		public bool shore;

		public Vector3 shoreVertex1;

		public Vector3 shoreVertex2;

		public int shoreVertexIdx1;

		public int shoreVertexIdx2;

		public List<int> neighbours = new List<int>();

		private int rightIdx = -1;

		private int leftIdx = -1;

		public int v1;

		public int v2;

		public int v3;

		public int upperTri;

		public int lowerTri;

		public Vector3 directionToSea;

		public Triangle(int idx, int i, int j, int resx, int resy, bool lower)
		{
			this.idx = idx;
			if (!lower || (lower && j > 0))
			{
				neighbours.Add(idx - 1);
			}
			if (lower || (!lower && j < resy - 2))
			{
				neighbours.Add(idx + 1);
			}
			if (lower && i > 0)
			{
				neighbours.Add(idx + 1 - 2 * (resy - 1));
			}
			else if (!lower && i < resx - 2)
			{
				neighbours.Add(idx - 1 + 2 * (resy - 1));
			}
		}

		public int GetNeighbourhoodShore(Triangle[] list)
		{
			int num = 0;
			foreach (int neighbour in neighbours)
			{
				if (list[neighbour].shore)
				{
					num++;
				}
			}
			return num;
		}

		public bool GetRightShoreNeighbour(Triangle[] list, out int idx)
		{
			if (rightIdx >= 0)
			{
				idx = rightIdx;
				return true;
			}
			idx = -1;
			Vector3 rhs = Vector3.Cross(directionToSea, Vector3.up);
			bool result = false;
			float num = 0f;
			foreach (int neighbour in neighbours)
			{
				if (list[neighbour].shore)
				{
					Vector3 normalized = (list[neighbour].shoreVertex1 - shoreVertex1).normalized;
					if (Vector3.Dot(normalized, rhs) > num)
					{
						result = true;
						idx = (rightIdx = neighbour);
						num = Vector3.Dot(normalized, rhs);
					}
				}
			}
			return result;
		}

		public bool GetLeftShoreNeighbour(Triangle[] list, out int idx)
		{
			if (leftIdx >= 0)
			{
				idx = leftIdx;
				return true;
			}
			idx = -1;
			Vector3 rhs = Vector3.Cross(directionToSea, Vector3.up);
			bool result = false;
			float num = 0f;
			foreach (int neighbour in neighbours)
			{
				if (list[neighbour].shore)
				{
					Vector3 normalized = (list[neighbour].shoreVertex1 - shoreVertex1).normalized;
					if (Vector3.Dot(normalized, rhs) < num)
					{
						result = true;
						idx = (leftIdx = neighbour);
						num = Vector3.Dot(normalized, rhs);
					}
				}
			}
			return result;
		}

		public int GetLeftNeighbour(Triangle[] list)
		{
			Vector3 rhs = Vector3.Cross(directionToSea, Vector3.up);
			int result = neighbours[0];
			float num = 1f;
			foreach (int neighbour in neighbours)
			{
				if (list[neighbour].shore)
				{
					Vector3 normalized = (list[neighbour].shoreVertex1 - shoreVertex1).normalized;
					if (Vector3.Dot(normalized, rhs) < num)
					{
						result = neighbour;
						num = Vector3.Dot(normalized, rhs);
					}
				}
			}
			return result;
		}

		public void SetVertices(int v1, int v2, int v3)
		{
			this.v1 = v1;
			this.v2 = v2;
			this.v3 = v3;
		}
	}

	public GameObject mainTerrain;

	public float threshold = 0.03f;

	public int neighbourhood = 2;

	public int meshResolution = 150;

	public int scaling = 1;

	private MeshFilter shoreLine;

	private float height;

	private Vector3[] vertices;

	private int[] triangles;

	private Triangle[] myTriangles;

	private IEnumerator Start()
	{
		yield return new WaitForEndOfFrame();
		shoreLine = (MeshFilter)GetComponent(typeof(MeshFilter));
		height = base.transform.position.y;
		if (shoreLine != null)
		{
			adaptPlaneToTerrain();
			extractShoreTriangles();
		}
	}

	private void adaptPlaneToTerrain()
	{
		Vector3 min = base.renderer.bounds.min;
		Vector3 size = base.renderer.bounds.size;
		int num = meshResolution;
		int num2 = meshResolution;
		float num3 = size.x / size.z;
		if (num3 < 1f)
		{
			num = Mathf.RoundToInt((float)num * num3);
		}
		else if (num3 > 1f)
		{
			num2 = Mathf.RoundToInt((float)num2 / num3);
		}
		size.Scale(new Vector3(1f / (float)(num - 1), 0f, 1f / (float)(num2 - 1)));
		vertices = new Vector3[num * num2];
		triangles = new int[6 * (num - 1) * (num2 - 1)];
		myTriangles = new Triangle[triangles.Length / 3];
		int layerMask = 1 << mainTerrain.layer;
		for (int i = 0; i < num; i++)
		{
			for (int j = 0; j < num2; j++)
			{
				RaycastHit hitInfo;
				if (Physics.Raycast(new Ray(new Vector3(min.x + (float)i * size.x, 10000f, min.z + (float)j * size.z), Vector3.down), out hitInfo, 10000f, layerMask))
				{
					vertices[i * num2 + j] = hitInfo.point;
				}
				else
				{
					vertices[i * num2 + j] = new Vector3(min.x + (float)i * size.x, 0f, min.z + (float)j * size.z);
				}
				if (i < num - 1 && j < num2 - 1)
				{
					int num4 = 6 * (i * (num2 - 1) + j);
					triangles[num4] = i * num2 + j + 1;
					triangles[num4 + 1] = (i + 1) * num2 + j;
					triangles[num4 + 2] = i * num2 + j;
					triangles[num4 + 3] = i * num2 + j + 1;
					triangles[num4 + 4] = (i + 1) * num2 + j + 1;
					triangles[num4 + 5] = (i + 1) * num2 + j;
					int num5 = 2 * (i * (num2 - 1) + j);
					myTriangles[num5] = new Triangle(num5, i, j, num, num2, true);
					myTriangles[num5].SetVertices(triangles[num4], triangles[num4 + 1], triangles[num4 + 2]);
					myTriangles[num5 + 1] = new Triangle(num5 + 1, i, j, num, num2, false);
					myTriangles[num5 + 1].SetVertices(triangles[num4 + 3], triangles[num4 + 4], triangles[num4 + 5]);
				}
			}
		}
		shoreLine.transform.position = Vector3.zero;
		shoreLine.transform.localScale = Vector3.one;
		shoreLine.transform.rotation = Quaternion.identity;
		shoreLine.mesh.Clear();
		shoreLine.mesh.vertices = vertices;
		shoreLine.mesh.triangles = triangles;
		shoreLine.mesh.RecalculateNormals();
	}

	private void extractShoreTriangles()
	{
		bool[] array = new bool[vertices.Length];
		for (int i = 0; i < vertices.Length; i++)
		{
			array[i] = vertices[i].y < height;
		}
		List<Triangle> shoreTriangles = new List<Triangle>();
		Triangle[] array2 = myTriangles;
		foreach (Triangle triangle in array2)
		{
			triangle.shore = (array[triangle.v1] ^ array[triangle.v2]) || (array[triangle.v1] ^ array[triangle.v3]);
			if (triangle.shore)
			{
				shoreTriangles.Add(triangle);
			}
		}
		foreach (Triangle item in shoreTriangles)
		{
			calculateShoreVertices(item);
		}
		foreach (Triangle item2 in shoreTriangles)
		{
			averageDirectionToSeaOverNeighbourhood(item2, neighbourhood);
		}
		List<Vector2> uv = new List<Vector2>(shoreTriangles.Count * 2);
		List<Vector3> vert = new List<Vector3>(shoreTriangles.Count * 2);
		List<int> tri = new List<int>();
		for (int k = 0; k < shoreTriangles.Count; k++)
		{
			Triangle triangle2 = shoreTriangles[k];
			vert.Add(triangle2.shoreVertex1);
			vert.Add(triangle2.shoreVertex2);
			uv.Add(new Vector2(0f, 0f));
			uv.Add(new Vector2(0f, 1f));
			triangle2.shoreVertexIdx1 = k * 2;
			triangle2.shoreVertexIdx2 = k * 2 + 1;
		}
		int num = 0;
		for (int l = 0; l < shoreTriangles.Count; l++)
		{
			Triangle triangle3 = shoreTriangles[l];
			int idx;
			if (!triangle3.GetLeftShoreNeighbour(myTriangles, out idx))
			{
				continue;
			}
			Triangle triangle4 = myTriangles[idx];
			float num2 = areaTriangle(triangle4.shoreVertex2, triangle3.shoreVertex1, triangle3.shoreVertex2);
			if (num2 > threshold)
			{
				tri.Add(triangle4.shoreVertexIdx2);
				tri.Add(triangle3.shoreVertexIdx1);
				tri.Add(triangle3.shoreVertexIdx2);
				triangle3.lowerTri = num;
				num += 3;
				num2 = areaTriangle(triangle4.shoreVertex2, triangle4.shoreVertex1, triangle3.shoreVertex1);
				if (num2 > threshold)
				{
					tri.Add(triangle4.shoreVertexIdx2);
					tri.Add(triangle4.shoreVertexIdx1);
					tri.Add(triangle3.shoreVertexIdx1);
					triangle3.upperTri = num;
					num += 3;
				}
				else
				{
					vert[triangle4.shoreVertexIdx1] = vert[triangle3.shoreVertexIdx1];
				}
			}
			else
			{
				vert[triangle4.shoreVertexIdx2] = vert[triangle3.shoreVertexIdx2];
				num2 = areaTriangle(triangle4.shoreVertex2, triangle4.shoreVertex1, triangle3.shoreVertex1);
				if (num2 > threshold)
				{
					tri.Add(triangle4.shoreVertexIdx2);
					tri.Add(triangle4.shoreVertexIdx1);
					tri.Add(triangle3.shoreVertexIdx1);
					triangle3.upperTri = num;
					num += 3;
				}
			}
		}
		produceUVMapping(ref uv, ref vert, ref tri, ref shoreTriangles);
		shoreLine.mesh.Clear();
		shoreLine.mesh.vertices = vert.ToArray();
		shoreLine.mesh.triangles = tri.ToArray();
		shoreLine.mesh.uv = uv.ToArray();
		shoreLine.mesh.RecalculateNormals();
	}

	private void produceUVMapping(ref List<Vector2> uv, ref List<Vector3> vert, ref List<int> tri, ref List<Triangle> shoreTriangles)
	{
		int num = 0;
		List<Triangle> list = new List<Triangle>();
		List<Triangle> list2 = new List<Triangle>();
		List<float> list3 = new List<float>();
		List<int> list4 = new List<int>();
		while (num < 100 && shoreTriangles.Count > 0)
		{
			num++;
			int i = 1;
			Triangle triangle = shoreTriangles[0];
			shoreTriangles.Remove(triangle);
			Triangle triangle2 = triangle;
			Triangle triangle3 = triangle;
			Vector3 zero = Vector3.zero;
			int idx;
			for (; i < 1000; i++)
			{
				if (!triangle.GetLeftShoreNeighbour(myTriangles, out idx))
				{
					break;
				}
				triangle3 = myTriangles[idx];
				shoreTriangles.Remove(triangle3);
				zero += triangle.shoreVertex2;
				if (triangle3 == triangle2)
				{
					break;
				}
				triangle = triangle3;
			}
			if (i == 1000)
			{
				Debug.LogError("Error in shore genereation 1");
				break;
			}
			if (triangle3 == triangle2 && triangle != triangle2)
			{
				vert[tri[triangle.lowerTri + 1]] = vert[tri[triangle.upperTri + 1]];
				vert[tri[triangle.lowerTri + 2]] = vert[tri[triangle.upperTri]];
				zero /= (float)i;
				list3.Add(Vector3.Dot((zero - triangle3.shoreVertex1).normalized, triangle3.directionToSea.normalized));
				list.Add(triangle2);
				list2.Add(triangle);
				list4.Add(-1);
				continue;
			}
			triangle2 = triangle;
			for (; i < 1000; i++)
			{
				if (!triangle.GetRightShoreNeighbour(myTriangles, out idx))
				{
					break;
				}
				triangle3 = myTriangles[idx];
				shoreTriangles.Remove(triangle3);
				triangle = triangle3;
			}
			if (i == 1000)
			{
				Debug.LogError("Error in shore genereation 2");
			}
			Debug.Log("LINE");
			list3.Add(0f);
			list.Add(triangle3);
			list2.Add(triangle2);
			list4.Add(i);
		}
		for (int j = 0; j < list.Count; j++)
		{
			if (list3[j] > 0f)
			{
				Triangle triangle4 = list[j];
				List<int> list5 = new List<int>();
				int idx2;
				while (triangle4 != list2[j] && triangle4.GetLeftShoreNeighbour(myTriangles, out idx2))
				{
					list5.Add(triangle4.upperTri);
					list5.Add(triangle4.upperTri + 1);
					list5.Add(triangle4.upperTri + 2);
					list5.Add(triangle4.lowerTri);
					list5.Add(triangle4.lowerTri + 1);
					list5.Add(triangle4.lowerTri + 2);
					triangle4 = myTriangles[idx2];
				}
				list5.Sort();
				list5.Reverse();
				foreach (int item in list5)
				{
					tri[item] = 0;
				}
				continue;
			}
			float num2 = list4[j];
			int num3 = 0;
			bool flag = num2 > 0f;
			uv[list[j].shoreVertexIdx1] = new Vector2(0f, 0f);
			uv[list[j].shoreVertexIdx2] = new Vector2(0f, 1f);
			float num4 = ((!flag) ? 0f : Mathf.Abs((float)num3 / num2 - 0.5f));
			List<Vector3> list7;
			List<Vector3> list6 = (list7 = vert);
			int shoreVertexIdx;
			int index = (shoreVertexIdx = list[j].shoreVertexIdx2);
			Vector3 vector = list7[shoreVertexIdx];
			list6[index] = vector - list[j].directionToSea * num4 * 2f * scaling;
			Triangle triangle5 = list[j];
			int idx3;
			while (num3 < 1000 && triangle5 != list2[j] && triangle5.GetLeftShoreNeighbour(myTriangles, out idx3))
			{
				num3++;
				Triangle triangle6 = myTriangles[idx3];
				float num5 = 0.5f * (Vector3.Distance(triangle5.shoreVertex1, triangle6.shoreVertex1) + Vector3.Distance(triangle5.shoreVertex2, triangle6.shoreVertex2));
				Vector2 vector2 = new Vector2(num5 / (4f * (float)scaling), 0f);
				uv[triangle6.shoreVertexIdx1] = uv[triangle5.shoreVertexIdx1] + vector2;
				uv[triangle6.shoreVertexIdx2] = uv[triangle5.shoreVertexIdx2] + vector2;
				num4 = ((!flag) ? 0f : Mathf.Abs((float)num3 / num2 - 0.5f));
				List<Vector3> list9;
				List<Vector3> list8 = (list9 = vert);
				int index2 = (shoreVertexIdx = triangle6.shoreVertexIdx2);
				vector = list9[shoreVertexIdx];
				list8[index2] = vector - triangle6.directionToSea * num4 * 2f * scaling;
				triangle5 = triangle6;
			}
			if (num3 == 1000)
			{
				Debug.LogError("Error in shore genereation");
			}
		}
	}

	private float areaTriangle(Vector3 A, Vector3 B, Vector3 C)
	{
		float num = Mathf.Pow(Vector3.Distance(A, B), 2f);
		float num2 = Mathf.Pow(Vector3.Distance(B, C), 2f);
		float num3 = Mathf.Pow(Vector3.Distance(C, A), 2f);
		return 0.25f * Mathf.Sqrt(2f * (num * num2 + num * num3 + num2 * num3) - (num * num + num2 * num2 + num3 * num3));
	}

	private void calculateShoreVertices(Triangle t)
	{
		Vector3 vector = vertices[t.v1];
		Vector3 vector2 = vertices[t.v2];
		Vector3 vector3 = vertices[t.v3];
		if ((vector.y < height) ^ (vector2.y < height))
		{
			if ((vector2.y < height) ^ (vector3.y < height))
			{
				Vector3 vector4 = vector;
				vector = vector2;
				vector2 = vector3;
				vector3 = vector4;
			}
		}
		else if (((vector.y < height) ^ (vector3.y < height)) && ((vector2.y < height) ^ (vector3.y < height)))
		{
			Vector3 vector5 = vector;
			vector = vector3;
			vector3 = vector2;
			vector2 = vector5;
		}
		float num = Mathf.Abs((vector.y - height) / (vector2.y - vector.y));
		Vector3 vector6 = num * (vector2 - vector);
		float num2 = Mathf.Abs((vector.y - height) / (vector3.y - vector.y));
		Vector3 vector7 = num2 * (vector3 - vector);
		Vector3 vector8 = vector + (vector6 + vector7) / 2f;
		Vector3 normalized = (vector7 - vector6).normalized;
		if (vector.y < height)
		{
			normalized = (vector6 - vector7).normalized;
			t.shoreVertex1 = (vector2 + vector3) / 2f;
		}
		else
		{
			t.shoreVertex1 = vector;
		}
		t.directionToSea = Vector3.Cross(normalized, Vector3.up).normalized;
		float num3 = Mathf.Clamp01(Mathf.Abs((vector2 - vector).normalized.y) + Mathf.Abs((vector3 - vector).normalized.y));
		t.shoreVertex1 = (1f - num3) * t.shoreVertex1 + num3 * vector8;
	}

	private void averageDirectionToSeaOverNeighbourhood(Triangle t, int degree)
	{
		Vector3 avgDir = t.directionToSea;
		int num = 1;
		List<int> used = new List<int>();
		if (degree > 0)
		{
			averageDirectionToSea(t, degree - 1, ref num, ref avgDir, ref used);
		}
		t.directionToSea = avgDir / num;
		t.shoreVertex2 = t.shoreVertex1 + t.directionToSea * scaling;
		t.shoreVertex2.y = height;
	}

	private void averageDirectionToSea(Triangle t, int degree, ref int num, ref Vector3 avgDir, ref List<int> used)
	{
		foreach (int neighbour in t.neighbours)
		{
			try
			{
				if (myTriangles[neighbour].shore && !used.Contains(neighbour))
				{
					used.Add(neighbour);
					avgDir += myTriangles[neighbour].directionToSea;
					num++;
					if (degree > 0)
					{
						averageDirectionToSea(myTriangles[neighbour], degree - 1, ref num, ref avgDir, ref used);
					}
				}
			}
			catch
			{
			}
		}
	}
}
