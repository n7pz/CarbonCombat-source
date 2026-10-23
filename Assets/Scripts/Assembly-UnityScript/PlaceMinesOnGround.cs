using System;
using UnityEngine;

[Serializable]
public class PlaceMinesOnGround : MonoBehaviour
{
	private bool onlyonce;

	public LayerMask layermask;

	public virtual void Start()
	{
		RaycastHit hitInfo = default(RaycastHit);
		if (Physics.Raycast(transform.position, -Vector3.up, out hitInfo, float.PositiveInfinity, layermask))
		{
			Quaternion rotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);
			Vector3 point = hitInfo.point;
			transform.position = point;
			transform.rotation = rotation;
		}
	}

	public virtual void Main()
	{
	}
}
