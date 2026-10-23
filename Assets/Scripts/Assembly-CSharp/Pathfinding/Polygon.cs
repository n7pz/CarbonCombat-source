using System;
using UnityEngine;

namespace Pathfinding
{
	public class Polygon
	{
		public static int TriangleArea2(Int3 a, Int3 b, Int3 c)
		{
			return (b.x - a.x) * (c.z - a.z) - (c.x - a.x) * (b.z - a.z);
		}

		public static float TriangleArea2(Vector3 a, Vector3 b, Vector3 c)
		{
			return (b.x - a.x) * (c.z - a.z) - (c.x - a.x) * (b.z - a.z);
		}

		public static int TriangleArea(Int3 a, Int3 b, Int3 c)
		{
			return (b.x - a.x) * (c.z - a.z) - (c.x - a.x) * (b.z - a.z);
		}

		public static float TriangleArea(Vector3 a, Vector3 b, Vector3 c)
		{
			return (b.x - a.x) * (c.z - a.z) - (c.x - a.x) * (b.z - a.z);
		}

		public static bool ContainsPoint(Vector2[] polyPoints, Vector2 p)
		{
			int num = polyPoints.Length - 1;
			bool flag = false;
			int num2 = 0;
			while (num2 < polyPoints.Length)
			{
				if (((polyPoints[num2].y <= p.y && p.y < polyPoints[num].y) || (polyPoints[num].y <= p.y && p.y < polyPoints[num2].y)) && p.x < (polyPoints[num].x - polyPoints[num2].x) * (p.y - polyPoints[num2].y) / (polyPoints[num].y - polyPoints[num2].y) + polyPoints[num2].x)
				{
					flag = !flag;
				}
				num = num2++;
			}
			return flag;
		}

		public static bool Left(Vector3 a, Vector3 b, Vector3 p)
		{
			return (b.x - a.x) * (p.z - a.z) - (p.x - a.x) * (b.z - a.z) <= 0f;
		}

		public static bool Left(Int3 a, Int3 b, Int3 p)
		{
			return (b.x - a.x) * (p.z - a.z) - (p.x - a.x) * (b.z - a.z) <= 0;
		}

		public static bool IsClockwiseMargin(Vector3 a, Vector3 b, Vector3 c)
		{
			return (b.x - a.x) * (c.z - a.z) - (c.x - a.x) * (b.z - a.z) <= float.Epsilon;
		}

		public static bool IsClockwise(Vector3 a, Vector3 b, Vector3 c)
		{
			return (b.x - a.x) * (c.z - a.z) - (c.x - a.x) * (b.z - a.z) < 0f;
		}

		public static bool IsClockwise(Int3 a, Int3 b, Int3 c)
		{
			return (b.x - a.x) * (c.z - a.z) - (c.x - a.x) * (b.z - a.z) < 0;
		}

		public static bool IsColinear(Int3 a, Int3 b, Int3 c)
		{
			return (b.x - a.x) * (c.z - a.z) - (c.x - a.x) * (b.z - a.z) == 0;
		}

		public static bool IsColinear(Vector3 a, Vector3 b, Vector3 c)
		{
			return Mathf.Approximately((b.x - a.x) * (c.z - a.z) - (c.x - a.x) * (b.z - a.z), 0f);
		}

		public static bool IntersectsUnclamped(Vector3 a, Vector3 b, Vector3 a2, Vector3 b2)
		{
			return Left(a, b, a2) != Left(a, b, b2);
		}

		public static bool Intersects(Vector3 start1, Vector3 end1, Vector3 start2, Vector3 end2)
		{
			Vector3 vector = end1 - start1;
			Vector3 vector2 = end2 - start2;
			float num = vector2.z * vector.x - vector2.x * vector.z;
			if (num == 0f)
			{
				return false;
			}
			float num2 = vector2.x * (start1.z - start2.z) - vector2.z * (start1.x - start2.x);
			float num3 = vector.x * (start1.z - start2.z) - vector.z * (start1.x - start2.x);
			float num4 = num2 / num;
			float num5 = num3 / num;
			if (num4 < 0f || num4 > 1f || num5 < 0f || num5 > 1f)
			{
				return false;
			}
			return true;
		}

		public static Vector3 IntersectionPointOptimized(Vector3 start1, Vector3 dir1, Vector3 start2, Vector3 dir2)
		{
			float num = dir2.z * dir1.x - dir2.x * dir1.z;
			if (num == 0f)
			{
				return start1;
			}
			float num2 = dir2.x * (start1.z - start2.z) - dir2.z * (start1.x - start2.x);
			float num3 = num2 / num;
			return start1 + dir1 * num3;
		}

		public static Vector3 IntersectionPointOptimized(Vector3 start1, Vector3 dir1, Vector3 start2, Vector3 dir2, out bool intersects)
		{
			float num = dir2.z * dir1.x - dir2.x * dir1.z;
			if (num == 0f)
			{
				intersects = false;
				return start1;
			}
			float num2 = dir2.x * (start1.z - start2.z) - dir2.z * (start1.x - start2.x);
			float num3 = num2 / num;
			intersects = true;
			return start1 + dir1 * num3;
		}

		public static float IntersectionFactor(Vector3 start1, Vector3 end1, Vector3 start2, Vector3 end2)
		{
			Vector3 vector = end1 - start1;
			Vector3 vector2 = end2 - start2;
			float num = vector2.z * vector.x - vector2.x * vector.z;
			if (num == 0f)
			{
				return -1f;
			}
			float num2 = vector2.x * (start1.z - start2.z) - vector2.z * (start1.x - start2.x);
			return num2 / num;
		}

		public static Vector3 IntersectionPoint(Vector3 start1, Vector3 end1, Vector3 start2, Vector3 end2)
		{
			bool intersects;
			return IntersectionPoint(start1, end1, start2, end2, out intersects);
		}

		public static Vector3 IntersectionPoint(Vector3 start1, Vector3 end1, Vector3 start2, Vector3 end2, out bool intersects)
		{
			Vector3 vector = end1 - start1;
			Vector3 vector2 = end2 - start2;
			float num = vector2.z * vector.x - vector2.x * vector.z;
			if (num == 0f)
			{
				intersects = false;
				return start1;
			}
			float num2 = vector2.x * (start1.z - start2.z) - vector2.z * (start1.x - start2.x);
			float num3 = num2 / num;
			intersects = true;
			return start1 + vector * num3;
		}

		public static Vector3 SegmentIntersectionPoint(Vector3 start1, Vector3 end1, Vector3 start2, Vector3 end2, out bool intersects)
		{
			Vector3 vector = end1 - start1;
			Vector3 vector2 = end2 - start2;
			float num = vector2.z * vector.x - vector2.x * vector.z;
			if (num == 0f)
			{
				intersects = false;
				return start1;
			}
			float num2 = vector2.x * (start1.z - start2.z) - vector2.z * (start1.x - start2.x);
			float num3 = vector.x * (start1.z - start2.z) - vector.z * (start1.x - start2.x);
			float num4 = num2 / num;
			float num5 = num3 / num;
			if (num4 < 0f || num4 > 1f || num5 < 0f || num5 > 1f)
			{
				intersects = false;
				return start1;
			}
			intersects = true;
			return start1 + vector * num4;
		}

		public static bool LineIntersectsBounds(Bounds bounds, Vector3 a, Vector3 b)
		{
			a -= bounds.center;
			b -= bounds.center;
			Vector3 vector = (a + b) * 0.5f;
			Vector3 vector2 = a - vector;
			Vector3 vector3 = new Vector3(Math.Abs(vector2.x), Math.Abs(vector2.y), Math.Abs(vector2.z));
			Vector3 extents = bounds.extents;
			if (Math.Abs(vector.x) > extents.x + vector3.x)
			{
				return false;
			}
			if (Math.Abs(vector.y) > extents.y + vector3.y)
			{
				return false;
			}
			if (Math.Abs(vector.z) > extents.z + vector3.z)
			{
				return false;
			}
			if (Math.Abs(vector.y * vector2.z - vector.z * vector2.y) > extents.y * vector3.z + extents.z * vector3.y)
			{
				return false;
			}
			if (Math.Abs(vector.x * vector2.z - vector.z * vector2.x) > extents.x * vector3.z + extents.z * vector3.x)
			{
				return false;
			}
			if (Math.Abs(vector.x * vector2.y - vector.y * vector2.x) > extents.x * vector3.y + extents.y * vector3.x)
			{
				return false;
			}
			return true;
		}

		public static float Dot(Vector3 lhs, Vector3 rhs)
		{
			return lhs.x * rhs.x + lhs.y * rhs.y + lhs.z * rhs.z;
		}

		public static Vector3[] Subdivide(Vector3[] path, int subdivisions)
		{
			subdivisions = ((subdivisions >= 0) ? subdivisions : 0);
			if (subdivisions == 0)
			{
				return path;
			}
			Vector3[] array = new Vector3[(path.Length - 1) * (int)Mathf.Pow(2f, subdivisions) + 1];
			int num = 0;
			for (int i = 0; i < path.Length - 1; i++)
			{
				float num2 = 1f / Mathf.Pow(2f, subdivisions);
				for (float num3 = 0f; num3 < 1f; num3 += num2)
				{
					array[num] = Vector3.Lerp(path[i], path[i + 1], Mathf.SmoothStep(0f, 1f, num3));
					num++;
				}
			}
			array[num] = path[path.Length - 1];
			return array;
		}

		public static Vector3 ClosesPointOnTriangle(Vector3[] triangle, Vector3 point)
		{
			return ClosesPointOnTriangle(triangle[0], triangle[1], triangle[2], point);
		}

		public static Vector3 ClosesPointOnTriangle(Vector3 tr0, Vector3 tr1, Vector3 tr2, Vector3 point)
		{
			Vector3 vector = tr1 - tr0;
			Vector3 vector2 = tr2 - tr0;
			Vector3 rhs = tr0 - point;
			float num = Vector3.Dot(vector, vector);
			float num2 = Vector3.Dot(vector, vector2);
			float num3 = Vector3.Dot(vector2, vector2);
			float num4 = Vector3.Dot(vector, rhs);
			float num5 = Vector3.Dot(vector2, rhs);
			float num6 = num * num3 - num2 * num2;
			float num7 = num2 * num5 - num3 * num4;
			float num8 = num2 * num4 - num * num5;
			if (num7 + num8 < num6)
			{
				if (num7 < 0f)
				{
					if (num8 < 0f)
					{
						if (num4 < 0f)
						{
							num7 = Mathfx.Clamp01((0f - num4) / num);
							num8 = 0f;
						}
						else
						{
							num7 = 0f;
							num8 = Mathfx.Clamp01((0f - num5) / num3);
						}
					}
					else
					{
						num7 = 0f;
						num8 = Mathfx.Clamp01((0f - num5) / num3);
					}
				}
				else if (num8 < 0f)
				{
					num7 = Mathfx.Clamp01((0f - num4) / num);
					num8 = 0f;
				}
				else
				{
					float num9 = 1f / num6;
					num7 *= num9;
					num8 *= num9;
				}
			}
			else if (num7 < 0f)
			{
				float num10 = num2 + num4;
				float num11 = num3 + num5;
				if (num11 > num10)
				{
					float num12 = num11 - num10;
					float num13 = num - 2f * num2 + num3;
					num7 = Mathfx.Clamp01(num12 / num13);
					num8 = 1f - num7;
				}
				else
				{
					num8 = Mathfx.Clamp01((0f - num5) / num3);
					num7 = 0f;
				}
			}
			else if (num8 < 0f)
			{
				if (num + num4 > num2 + num5)
				{
					float num14 = num3 + num5 - num2 - num4;
					float num15 = num - 2f * num2 + num3;
					num7 = Mathfx.Clamp01(num14 / num15);
					num8 = 1f - num7;
				}
				else
				{
					num7 = Mathfx.Clamp01((0f - num5) / num3);
					num8 = 0f;
				}
			}
			else
			{
				float num16 = num3 + num5 - num2 - num4;
				float num17 = num - 2f * num2 + num3;
				num7 = Mathfx.Clamp01(num16 / num17);
				num8 = 1f - num7;
			}
			return tr0 + num7 * vector + num8 * vector2;
		}
	}
}
