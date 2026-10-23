using System;
using UnityEngine;

namespace Pathfinding
{
	[Serializable]
	public class GraphCollision : ISerializableObject
	{
		public ColliderType type = ColliderType.Capsule;

		public float diameter = 1f;

		public float height = 2f;

		public RayDirection rayDirection = RayDirection.Both;

		public LayerMask mask;

		public LayerMask heightMask = -1;

		public float fromHeight = 100f;

		public bool thickRaycast;

		public float thickRaycastDiameter = 1f;

		private Vector3 up;

		private Vector3 upheight;

		private float finalRadius;

		private float finalRaycastRadius;

		public bool collisionCheck = true;

		public bool heightCheck = true;

		public bool unwalkableWhenNoGround = true;

		public void Initialize(Matrix4x4 matrix, float scale)
		{
			up = matrix.MultiplyVector(Vector3.up);
			upheight = up * height;
			finalRadius = diameter * scale * 0.5f;
			finalRaycastRadius = thickRaycastDiameter * scale * 0.5f;
		}

		public bool Check(Vector3 position)
		{
			if (!collisionCheck)
			{
				return true;
			}
			switch (type)
			{
			case ColliderType.Capsule:
				return !Physics.CheckCapsule(position, position + upheight, finalRadius, mask);
			case ColliderType.Sphere:
				return !Physics.CheckSphere(position, finalRadius, mask);
			default:
				switch (rayDirection)
				{
				case RayDirection.Both:
					return !Physics.Raycast(position, up, height, mask) && !Physics.Raycast(position + upheight, -up, height, mask);
				case RayDirection.Up:
					return !Physics.Raycast(position, up, height, mask);
				default:
					return !Physics.Raycast(position + upheight, -up, height, mask);
				}
			}
		}

		public Vector3 CheckHeight(Vector3 position)
		{
			RaycastHit hit;
			bool walkable;
			return CheckHeight(position, out hit, out walkable);
		}

		public Vector3 CheckHeight(Vector3 position, out RaycastHit hit, out bool walkable)
		{
			walkable = true;
			if (!heightCheck)
			{
				hit = default(RaycastHit);
				return position;
			}
			if (thickRaycast)
			{
				Ray ray = new Ray(position + up * fromHeight, -up);
				if (Physics.SphereCast(ray, finalRaycastRadius, out hit, fromHeight + 0.005f, heightMask))
				{
					return Mathfx.NearestPoint(ray.origin, ray.origin + ray.direction, hit.point);
				}
				if (unwalkableWhenNoGround)
				{
					walkable = false;
				}
			}
			else
			{
				if (Physics.Raycast(position + up * fromHeight, -up, out hit, fromHeight + 0.005f, heightMask))
				{
					return hit.point;
				}
				if (unwalkableWhenNoGround)
				{
					walkable = false;
				}
			}
			return position;
		}

		public RaycastHit[] CheckHeightAll(Vector3 position)
		{
			if (!heightCheck)
			{
				RaycastHit raycastHit = new RaycastHit
				{
					point = position,
					distance = 0f
				};
				return new RaycastHit[1] { raycastHit };
			}
			RaycastHit[] array;
			if (thickRaycast)
			{
				Ray ray = new Ray(position + up * fromHeight, -up);
				array = Physics.SphereCastAll(ray, finalRaycastRadius, fromHeight, heightMask);
				for (int i = 0; i < array.Length; i++)
				{
					array[i].point = Mathfx.NearestPoint(ray.origin, ray.origin + ray.direction, array[i].point);
				}
			}
			else
			{
				array = Physics.RaycastAll(position + up * fromHeight, -up, fromHeight, heightMask);
			}
			return array;
		}

		public void SerializeSettings(AstarSerializer serializer)
		{
			serializer.AddValue("Mask", (int)mask);
			serializer.AddValue("Diameter", diameter);
			serializer.AddValue("Height", height);
			serializer.AddValue("Type", (int)type);
			serializer.AddValue("RayDirection", (int)rayDirection);
			serializer.AddValue("heightMask", (int)heightMask);
			serializer.AddValue("fromHeight", fromHeight);
			serializer.AddValue("thickRaycastDiameter", thickRaycastDiameter);
			serializer.AddValue("thickRaycast", thickRaycast);
			serializer.AddValue("collisionCheck", collisionCheck);
			serializer.AddValue("heightCheck", heightCheck);
			serializer.AddValue("unwalkableWhenNoGround", unwalkableWhenNoGround);
		}

		public void DeSerializeSettings(AstarSerializer serializer)
		{
			mask.value = (int)serializer.GetValue("Mask", typeof(int));
			diameter = (float)serializer.GetValue("Diameter", typeof(float));
			height = (float)serializer.GetValue("Height", typeof(float));
			type = (ColliderType)(int)serializer.GetValue("Type", typeof(int));
			rayDirection = (RayDirection)(int)serializer.GetValue("RayDirection", typeof(int));
			heightMask.value = (int)serializer.GetValue("heightMask", typeof(int), -1);
			fromHeight = (float)serializer.GetValue("fromHeight", typeof(float), 100f);
			thickRaycastDiameter = (float)serializer.GetValue("thickRaycastDiameter", typeof(float));
			thickRaycast = (bool)serializer.GetValue("thickRaycast", typeof(bool));
			collisionCheck = (bool)serializer.GetValue("collisionCheck", typeof(bool), true);
			heightCheck = (bool)serializer.GetValue("heightCheck", typeof(bool), true);
			unwalkableWhenNoGround = (bool)serializer.GetValue("unwalkableWhenNoGround", typeof(bool), true);
			if (fromHeight == 0f)
			{
				fromHeight = 100f;
			}
		}
	}
}
