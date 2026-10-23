using System;
using Pathfinding;
using UnityEngine;

[Serializable]
[AddComponentMenu("Pathfinding/Modifiers/Simple Smooth")]
public class SimpleSmoothModifier : MonoModifier
{
	public enum SmoothType
	{
		Simple = 0,
		Bezier = 1,
		OffsetSimple = 2
	}

	public SmoothType smoothType;

	public int subdivisions = 2;

	public int iterations = 2;

	public float strength = 0.5f;

	public bool uniformLength = true;

	public float maxSegmentLength = 2f;

	public float bezierTangentLength = 0.4f;

	public float offset = 0.2f;

	public override ModifierData input
	{
		get
		{
			return ModifierData.All;
		}
	}

	public override ModifierData output
	{
		get
		{
			ModifierData modifierData = ModifierData.VectorPath;
			if (iterations == 0 && smoothType == SmoothType.Simple && !uniformLength)
			{
				modifierData |= ModifierData.StrictVectorPath;
			}
			return modifierData;
		}
	}

	public override void Apply(Path p, ModifierData source)
	{
		if (p.vectorPath != null)
		{
			Vector3[] vectorPath = p.vectorPath;
			switch (smoothType)
			{
			case SmoothType.Simple:
				p.vectorPath = SmoothSimple(vectorPath);
				break;
			case SmoothType.Bezier:
				p.vectorPath = SmoothBezier(vectorPath);
				break;
			case SmoothType.OffsetSimple:
				p.vectorPath = SmoothOffsetSimple(vectorPath);
				break;
			}
		}
	}

	public Vector3[] SmoothOffsetSimple(Vector3[] path)
	{
		if (path.Length <= 2 || iterations <= 0)
		{
			return path;
		}
		Vector3[] array = new Vector3[(path.Length - 2) * (int)Mathf.Pow(2f, iterations) + 2];
		Vector3[] array2 = new Vector3[(path.Length - 2) * (int)Mathf.Pow(2f, iterations) + 2];
		for (int i = 0; i < path.Length; i++)
		{
			array[i] = path[i];
		}
		for (int j = 0; j < iterations; j++)
		{
			int num = (path.Length - 2) * (int)Mathf.Pow(2f, j) + 2;
			Vector3[] array3 = array;
			array = array2;
			array2 = array3;
			float num2 = 1f;
			for (int k = 0; k < num - 1; k++)
			{
				Vector3 vector = array2[k];
				Vector3 vector2 = array2[k + 1];
				Vector3 normalized = Vector3.Cross(vector2 - vector, Vector3.up).normalized;
				bool flag = false;
				bool flag2 = false;
				bool flag3 = false;
				bool flag4 = false;
				if (k != 0 && !Polygon.IsColinear(vector, vector2, array2[k - 1]))
				{
					flag3 = true;
					flag = Polygon.Left(vector, vector2, array2[k - 1]);
				}
				if (k < num - 1 && !Polygon.IsColinear(vector, vector2, array2[k + 2]))
				{
					flag4 = true;
					flag2 = Polygon.Left(vector, vector2, array2[k + 2]);
				}
				if (flag3)
				{
					array[k * 2] = vector + ((!flag) ? (-normalized * offset * num2) : (normalized * offset * num2));
				}
				else
				{
					array[k * 2] = vector;
				}
				if (flag4)
				{
					array[k * 2 + 1] = vector2 + ((!flag2) ? (-normalized * offset * num2) : (normalized * offset * num2));
				}
				else
				{
					array[k * 2 + 1] = vector2;
				}
			}
			array[(path.Length - 2) * (int)Mathf.Pow(2f, j + 1) + 2 - 1] = array2[num - 1];
		}
		return array;
	}

	public Vector3[] SmoothSimple(Vector3[] path)
	{
		if (path.Length <= 2)
		{
			return path;
		}
		if (uniformLength)
		{
			int num = 0;
			maxSegmentLength = ((!(maxSegmentLength < 0.005f)) ? maxSegmentLength : 0.005f);
			for (int i = 0; i < path.Length - 1; i++)
			{
				float num2 = Vector3.Distance(path[i], path[i + 1]);
				num += Mathf.FloorToInt(num2 / maxSegmentLength);
			}
			Vector3[] array = new Vector3[num + 1];
			int num3 = 0;
			for (int j = 0; j < path.Length - 1; j++)
			{
				float num4 = Vector3.Distance(path[j], path[j + 1]);
				int num5 = Mathf.FloorToInt(num4 / maxSegmentLength);
				Vector3 vector = path[j + 1] - path[j];
				for (int k = 0; k < num5; k++)
				{
					array[num3] = vector * ((float)k / (float)num5) + path[j];
					num3++;
				}
			}
			array[num3] = path[path.Length - 1];
			for (int l = 0; l < iterations; l++)
			{
				Vector3 vector2 = array[0];
				for (int m = 1; m < array.Length - 1; m++)
				{
					Vector3 vector3 = array[m];
					array[m] = Vector3.Lerp(vector3, (vector2 + array[m + 1]) / 2f, strength);
					vector2 = vector3;
				}
			}
			return array;
		}
		Vector3[] array2 = Polygon.Subdivide(path, subdivisions);
		for (int n = 0; n < iterations; n++)
		{
			Vector3 vector4 = array2[0];
			for (int num6 = 1; num6 < array2.Length - 1; num6++)
			{
				Vector3 vector5 = array2[num6];
				array2[num6] = Vector3.Lerp(vector5, (vector4 + array2[num6 + 1]) / 2f, strength);
				vector4 = vector5;
			}
		}
		return array2;
	}

	public Vector3[] SmoothBezier(Vector3[] path)
	{
		float num = Mathf.Pow(2f, subdivisions);
		Vector3[] array = new Vector3[(path.Length - 1) * (int)num + 1];
		for (int i = 0; i < path.Length - 1; i++)
		{
			Vector3 zero = Vector3.zero;
			Vector3 zero2 = Vector3.zero;
			zero = ((i != 0) ? (path[i + 1] - path[i - 1]) : (path[i + 1] - path[i]));
			zero2 = ((i != path.Length - 2) ? (path[i] - path[i + 2]) : (path[i] - path[i + 1]));
			zero *= bezierTangentLength;
			zero2 *= bezierTangentLength;
			Vector3 vector = path[i];
			Vector3 vector2 = vector + zero;
			Vector3 vector3 = path[i + 1];
			Vector3 vector4 = vector3 + zero2;
			Debug.DrawLine(vector, vector3, Color.black);
			Debug.DrawLine(vector, vector2, Color.red);
			Debug.DrawLine(vector3, vector4, Color.red);
			for (int j = 0; j < (int)num; j++)
			{
				array[i * (int)num + j] = Mathfx.CubicBezier(vector, vector2, vector4, vector3, (float)j / num);
				Debug.DrawLine(Vector3.Lerp(vector, vector3, (float)j / num), array[i * (int)num + j], Color.blue);
			}
		}
		array[array.Length - 1] = path[path.Length - 1];
		return array;
	}
}
