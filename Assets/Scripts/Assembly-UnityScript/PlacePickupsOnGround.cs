using System;
using UnityEngine;

[Serializable]
public class PlacePickupsOnGround : MonoBehaviour
{
	private bool onlyonce;

	private Transform thePickup;

	public virtual void Awake()
	{
		thePickup = transform.Find((!gameObject.name.Contains("WeaponPickup")) ? "Pickup" : "DroppedWeaponPrefab");
	}

	public virtual void Start()
	{
		if (Application.loadedLevelName != "Forge_Scene")
		{
			RaycastHit hitInfo = default(RaycastHit);
			if (Physics.Raycast(transform.position, -Vector3.up, out hitInfo))
			{
				Quaternion rotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);
				Vector3 point = hitInfo.point;
				transform.position = point;
				transform.rotation = rotation;
			}
		}
	}

	public virtual void Main()
	{
	}
}
