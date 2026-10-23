using System;
using UnityEngine;

[Serializable]
public class AdjustBlobShadowHeight : MonoBehaviour
{
	public LayerMask layermask;

	public virtual void LateUpdate()
	{
		RaycastHit hitInfo = default(RaycastHit);
		if (Physics.Raycast(transform.position, Vector3.up, out hitInfo, 1f))
		{
			float y = hitInfo.point.y - 1f;
			Vector3 position = transform.position;
			float num = (position.y = y);
			Vector3 vector = (transform.position = position);
			Debug.DrawLine(transform.position, hitInfo.point, Color.red);
			if (Physics.Raycast(transform.position, -Vector3.up, out hitInfo, float.PositiveInfinity, layermask))
			{
				((Projector)gameObject.GetComponent(typeof(Projector))).fieldOfView = 0.00126823f * hitInfo.distance;
			}
			else
			{
				((Projector)gameObject.GetComponent(typeof(Projector))).fieldOfView = 38f;
			}
		}
		else
		{
			((Projector)gameObject.GetComponent(typeof(Projector))).fieldOfView = 38f;
		}
	}

	public virtual void Main()
	{
	}
}
