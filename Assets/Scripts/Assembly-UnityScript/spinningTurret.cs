using System;
using UnityEngine;

[Serializable]
public class spinningTurret : MonoBehaviour
{
	public bool on;

	public float maxSpeed;

	public float acceleration;

	public float speed;

	public spinningTurret()
	{
		on = true;
		maxSpeed = 1000f;
		acceleration = 0.8f;
	}

	public virtual void Update()
	{
		if (on)
		{
			speed = Mathf.Lerp(speed, maxSpeed, Time.deltaTime * acceleration);
		}
		else
		{
			speed = Mathf.Lerp(speed, 0f, Time.deltaTime * acceleration);
		}
		float y = transform.localRotation.eulerAngles.y + speed * Time.deltaTime;
		Quaternion localRotation = transform.localRotation;
		Vector3 eulerAngles = localRotation.eulerAngles;
		float num = (eulerAngles.y = y);
		Vector3 vector = (localRotation.eulerAngles = eulerAngles);
		Quaternion quaternion = (transform.localRotation = localRotation);
	}

	public virtual void Main()
	{
	}
}
