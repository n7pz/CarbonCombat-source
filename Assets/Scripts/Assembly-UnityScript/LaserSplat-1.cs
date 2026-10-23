using System;
using UnityEngine;

[Serializable]
public class LaserSplat_00201 : MonoBehaviour
{
	public Transform explosion;

	public bool explode;

	private bool disableray;

	public LayerMask layermask;

	public virtual void FixedUpdate()
	{
		if (!explode)
		{
			transform.Translate(new Vector3(-1000f * Time.deltaTime, 0f, 0f));
		}
		RaycastHit hitInfo = default(RaycastHit);
		if (!disableray && Physics.Raycast(transform.position, -transform.right, out hitInfo, 5000f, layermask) && hitInfo.transform.gameObject.tag != "WorldColliders")
		{
			float distance = hitInfo.distance;
			float num = distance / 1000f;
			if (!(num >= 0.015f))
			{
				Quaternion rotation = transform.rotation;
				Vector3 point = hitInfo.point;
				laserhit(point, rotation);
				disableray = true;
			}
		}
	}

	public virtual void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag != "WorldColliders")
		{
			ContactPoint contactPoint = collision.contacts[0];
			Quaternion rot = Quaternion.FromToRotation(Vector3.up, contactPoint.normal);
			Vector3 point = contactPoint.point;
			laserhit(point, rot);
			disableray = true;
		}
	}

	public virtual void laserhit(Vector3 pos, Quaternion rot)
	{
		Transform transform = null;
		explode = true;
		transform = (Transform)UnityEngine.Object.Instantiate(explosion, pos, rot);
		this.transform.DetachChildren();
		UnityEngine.Object.Destroy(gameObject);
	}

	public virtual void Main()
	{
	}
}
