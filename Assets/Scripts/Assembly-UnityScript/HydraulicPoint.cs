using System;
using UnityEngine;

[Serializable]
public class HydraulicPoint : MonoBehaviour
{
	public Transform target;

	public virtual void LateUpdate()
	{
		transform.LookAt(target);
		int num = 0;
		Quaternion localRotation = transform.localRotation;
		Vector3 eulerAngles = localRotation.eulerAngles;
		float num2 = (eulerAngles.z = num);
		Vector3 vector = (localRotation.eulerAngles = eulerAngles);
		Quaternion quaternion = (transform.localRotation = localRotation);
	}

	public virtual void Main()
	{
	}
}
