using System;
using UnityEngine;

[Serializable]
public class inverseKinematics : MonoBehaviour
{
	private Vector3 target;

	private Vector3 elbowTarget;

	public virtual void CalculateIK()
	{
		this.transform.LookAt(target, this.transform.position - elbowTarget);
		Transform transform = this.transform.Find("upperArm");
		Transform transform2 = this.transform.Find("upperArm/elbow");
		Transform transform3 = this.transform.Find("upperArm/elbow/hand");
		float num = Vector3.Distance(transform.position, transform2.position);
		float num2 = Vector3.Distance(transform2.position, transform3.position);
		float num3 = num + num2;
		float num4 = num;
		float a = Vector3.Distance(transform.position, target);
		a = Mathf.Min(a, num3 - 0.0001f);
		float num5 = a * (num / num3);
		float num6 = Mathf.Acos(num5 / num4) * 57.29578f;
		transform.LookAt(target, this.transform.root.up);
		float x = transform.localRotation.eulerAngles.x + num6;
		Quaternion localRotation = transform.localRotation;
		Vector3 eulerAngles = localRotation.eulerAngles;
		float num7 = (eulerAngles.x = x);
		Vector3 vector = (localRotation.eulerAngles = eulerAngles);
		Quaternion quaternion = (transform.localRotation = localRotation);
		transform2.LookAt(target, this.transform.root.up);
	}

	public virtual void Main()
	{
	}
}
