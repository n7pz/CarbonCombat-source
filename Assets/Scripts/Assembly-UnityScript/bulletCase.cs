using System;
using UnityEngine;

[Serializable]
public class bulletCase : MonoBehaviour
{
	public float life;

	private float destroyTime;

	private Vector3 velocity;

	private float gravity;

	private float turnSpeed;

	private float turnAngle;

	public bulletCase()
	{
		life = 0.5f;
		gravity = 9.8f;
	}

	public virtual void Start()
	{
		destroyTime = Time.time + life;
		turnAngle = UnityEngine.Random.value * 360f;
		turnSpeed = UnityEngine.Random.Range(-360f, 360f);
	}

	public virtual void Update()
	{
		if (!(Time.time <= destroyTime))
		{
			UnityEngine.Object.Destroy(gameObject);
		}
		transform.LookAt(Camera.main.transform.position);
		turnAngle += turnSpeed * Time.deltaTime;
		float z = transform.localRotation.eulerAngles.z + turnAngle;
		Quaternion localRotation = transform.localRotation;
		Vector3 eulerAngles = localRotation.eulerAngles;
		float num = (eulerAngles.z = z);
		Vector3 vector = (localRotation.eulerAngles = eulerAngles);
		Quaternion quaternion = (transform.localRotation = localRotation);
		velocity.y -= gravity * Time.deltaTime;
		transform.position += velocity * Time.deltaTime;
		transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, Time.deltaTime * life * 2f);
	}

	public virtual void Main()
	{
	}
}
