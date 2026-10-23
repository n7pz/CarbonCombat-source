using System;
using UnityEngine;

[Serializable]
public class OtherDotController : MonoBehaviour
{
	public virtual void LateUpdate()
	{
		Vector3 zero = Vector3.zero;
		Quaternion rotation = transform.rotation;
		Vector3 vector = (rotation.eulerAngles = zero);
		Quaternion quaternion = (transform.rotation = rotation);
		float y = transform.parent.rotation.eulerAngles.y;
		Quaternion rotation2 = transform.rotation;
		Vector3 eulerAngles = rotation2.eulerAngles;
		float num = (eulerAngles.y = y);
		Vector3 vector3 = (rotation2.eulerAngles = eulerAngles);
		Quaternion quaternion3 = (transform.rotation = rotation2);
		transform.position = transform.parent.position;
	}

	public virtual void Main()
	{
	}
}
