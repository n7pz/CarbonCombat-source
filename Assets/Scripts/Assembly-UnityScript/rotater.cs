using System;
using UnityEngine;

[Serializable]
public class rotater : MonoBehaviour
{
	public float xSpeed;

	public float ySpeed;

	public float zSpeed;

	public bool manual;

	public Transform maincar;

	public rotater()
	{
		xSpeed = 1f;
		ySpeed = 1f;
		zSpeed = 1f;
	}

	public virtual void Update()
	{
		int num = 0;
		Quaternion rotation = transform.rotation;
		Vector3 eulerAngles = rotation.eulerAngles;
		float num2 = (eulerAngles.x = num);
		Vector3 vector = (rotation.eulerAngles = eulerAngles);
		Quaternion quaternion = (transform.rotation = rotation);
		int num3 = 0;
		Quaternion rotation2 = transform.rotation;
		Vector3 eulerAngles2 = rotation2.eulerAngles;
		float num4 = (eulerAngles2.z = num3);
		Vector3 vector3 = (rotation2.eulerAngles = eulerAngles2);
		Quaternion quaternion3 = (transform.rotation = rotation2);
		float x = maincar.position.x;
		Vector3 position = transform.position;
		float num5 = (position.x = x);
		Vector3 vector5 = (transform.position = position);
		float z = maincar.position.z;
		Vector3 position2 = transform.position;
		float num6 = (position2.z = z);
		Vector3 vector7 = (transform.position = position2);
		if (!manual)
		{
			transform.RotateAround(transform.position, Vector3.right, ySpeed * Time.deltaTime);
			transform.RotateAround(transform.position, Vector3.up, xSpeed * Time.deltaTime);
			transform.RotateAround(transform.position, Vector3.forward, zSpeed * Time.deltaTime);
			return;
		}
		if (Input.GetAxis("Horizontal") != 0f)
		{
			transform.RotateAround(transform.position, Vector3.up, Input.GetAxis("Horizontal") * xSpeed * Time.deltaTime);
		}
		if (Input.GetAxis("Vertical") != 0f)
		{
			transform.RotateAround(transform.position, Vector3.right, Input.GetAxis("Vertical") * ySpeed * Time.deltaTime);
		}
	}

	public virtual void Main()
	{
	}
}
