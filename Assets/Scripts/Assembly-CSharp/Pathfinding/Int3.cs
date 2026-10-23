using System;
using UnityEngine;

namespace Pathfinding
{
	public struct Int3
	{
		public const int Precision = 100;

		public const float FloatPrecision = 100f;

		public const float PrecisionFactor = 0.01f;

		public int x;

		public int y;

		public int z;

		public int this[int i]
		{
			get
			{
				int result;
				switch (i)
				{
				case 0:
					result = x;
					break;
				case 1:
					result = y;
					break;
				default:
					result = z;
					break;
				}
				return result;
			}
		}

		public float magnitude
		{
			get
			{
				double num = x;
				double num2 = y;
				double num3 = z;
				return (float)Math.Sqrt(num * num + num2 * num2 + num3 * num3);
			}
		}

		public int costMagnitude
		{
			get
			{
				return (int)Math.Round(magnitude);
			}
		}

		public float worldMagnitude
		{
			get
			{
				double num = x;
				double num2 = y;
				double num3 = z;
				return (float)Math.Sqrt(num * num + num2 * num2 + num3 * num3) * 0.01f;
			}
		}

		public float sqrMagnitude
		{
			get
			{
				double num = x;
				double num2 = y;
				double num3 = z;
				return (float)(num * num + num2 * num2 + num3 * num3);
			}
		}

		public int unsafeSqrMagnitude
		{
			get
			{
				return x * x + y * y + z * z;
			}
		}

		[Obsolete("Same implementation as .magnitude")]
		public float safeMagnitude
		{
			get
			{
				double num = x;
				double num2 = y;
				double num3 = z;
				return (float)Math.Sqrt(num * num + num2 * num2 + num3 * num3);
			}
		}

		[Obsolete(".sqrMagnitude is now per default safe (.unsafeSqrMagnitude can be used for unsafe operations)")]
		public float safeSqrMagnitude
		{
			get
			{
				float num = (float)x * 0.01f;
				float num2 = (float)y * 0.01f;
				float num3 = (float)z * 0.01f;
				return num * num + num2 * num2 + num3 * num3;
			}
		}

		public Int3(Vector3 position)
		{
			x = (int)Math.Round(position.x * 100f);
			y = (int)Math.Round(position.y * 100f);
			z = (int)Math.Round(position.z * 100f);
		}

		public Int3(int _x, int _y, int _z)
		{
			x = _x;
			y = _y;
			z = _z;
		}

		public static int Dot(Int3 lhs, Int3 rhs)
		{
			return lhs.x * rhs.x + lhs.y * rhs.y + lhs.z * rhs.z;
		}

		public Int3 NormalizeTo(int newMagn)
		{
			float num = magnitude;
			if (num == 0f)
			{
				return this;
			}
			x *= newMagn;
			y *= newMagn;
			z *= newMagn;
			x = (int)Math.Round((float)x / num);
			y = (int)Math.Round((float)y / num);
			z = (int)Math.Round((float)z / num);
			return this;
		}

		public override string ToString()
		{
			return "( " + x + ", " + y + ", " + z + ")";
		}

		public override bool Equals(object o)
		{
			if (o == null)
			{
				return false;
			}
			Int3 @int = (Int3)o;
			return x == @int.x && y == @int.y && z == @int.z;
		}

		public override int GetHashCode()
		{
			return x * 9 + y * 10 + z * 11;
		}

		public static bool operator ==(Int3 lhs, Int3 rhs)
		{
			return lhs.x == rhs.x && lhs.y == rhs.y && lhs.z == rhs.z;
		}

		public static bool operator !=(Int3 lhs, Int3 rhs)
		{
			return lhs.x != rhs.x || lhs.y != rhs.y || lhs.z != rhs.z;
		}

		public static implicit operator Int3(Vector3 ob)
		{
			return new Int3((int)Math.Round(ob.x * 100f), (int)Math.Round(ob.y * 100f), (int)Math.Round(ob.z * 100f));
		}

		public static implicit operator Vector3(Int3 ob)
		{
			return new Vector3((float)ob.x * 0.01f, (float)ob.y * 0.01f, (float)ob.z * 0.01f);
		}

		public static Int3 operator -(Int3 lhs, Int3 rhs)
		{
			lhs.x -= rhs.x;
			lhs.y -= rhs.y;
			lhs.z -= rhs.z;
			return lhs;
		}

		public static Int3 operator +(Int3 lhs, Int3 rhs)
		{
			lhs.x += rhs.x;
			lhs.y += rhs.y;
			lhs.z += rhs.z;
			return lhs;
		}

		public static Int3 operator *(Int3 lhs, int rhs)
		{
			lhs.x *= rhs;
			lhs.y *= rhs;
			lhs.z *= rhs;
			return lhs;
		}

		public static Int3 operator *(Int3 lhs, float rhs)
		{
			lhs.x = (int)Math.Round((float)lhs.x * rhs);
			lhs.y = (int)Math.Round((float)lhs.y * rhs);
			lhs.z = (int)Math.Round((float)lhs.z * rhs);
			return lhs;
		}

		public static Int3 operator *(Int3 lhs, Vector3 rhs)
		{
			lhs.x = (int)Math.Round((float)lhs.x * rhs.x);
			lhs.y = (int)Math.Round((float)lhs.y * rhs.y);
			lhs.z = (int)Math.Round((float)lhs.z * rhs.z);
			return lhs;
		}

		public static Int3 operator /(Int3 lhs, float rhs)
		{
			lhs.x = (int)Math.Round((float)lhs.x / rhs);
			lhs.y = (int)Math.Round((float)lhs.y / rhs);
			lhs.z = (int)Math.Round((float)lhs.z / rhs);
			return lhs;
		}

		public static implicit operator string(Int3 ob)
		{
			return ob.ToString();
		}
	}
}
