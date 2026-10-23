using System;
using UnityEngine;

[Serializable]
public class dustCloud : MonoBehaviour
{
	public float life;

	private float startTime;

	private float destroyTime;

	private Vector3 velocity;

	private float gravity;

	private float angle;

	private float startSturnSpeed;

	private float turnSpeed;

	private float startScale;

	private float endScale;

	public dustCloud()
	{
		life = 2f;
		gravity = 9.8f;
	}

	public virtual void Start()
	{
		startTime = Time.time;
		destroyTime = Time.time + life;
		velocity += UnityEngine.Random.insideUnitSphere * 0.5f;
		velocity.y += UnityEngine.Random.value * 0.6f;
		turnSpeed = UnityEngine.Random.Range(-360, 360);
		startSturnSpeed = turnSpeed;
		angle = UnityEngine.Random.value * 360f;
		startScale = UnityEngine.Random.Range(0.05f, 0.01f);
		transform.localScale = Vector3.one * startScale;
		endScale = 1f + UnityEngine.Random.value * 2f;
	}

	public virtual void Update()
	{
		if (!(Time.time <= destroyTime))
		{
			UnityEngine.Object.Destroy(gameObject);
		}
		float num = Time.time - startTime;
		float t = Mathf.Pow(num / life, 0.2f);
		turnSpeed = Mathf.Lerp(startSturnSpeed, 0f, t);
		velocity.y -= gravity * Time.deltaTime;
		velocity = Vector3.Lerp(velocity, Vector3.zero, Time.deltaTime * 5f);
		transform.position += velocity * Time.deltaTime;
		transform.LookAt(Camera.main.transform.position);
		angle += turnSpeed * Time.deltaTime;
		float z = angle;
		Quaternion localRotation = transform.localRotation;
		Vector3 eulerAngles = localRotation.eulerAngles;
		float num2 = (eulerAngles.z = z);
		Vector3 vector = (localRotation.eulerAngles = eulerAngles);
		Quaternion quaternion = (transform.localRotation = localRotation);
		transform.localScale = Vector3.Lerp(Vector3.one * startScale, Vector3.one * endScale, t);
		Color color = renderer.material.GetColor("_Color");
		color.a = Mathf.Lerp(color.a, 0f, Time.deltaTime * life);
		renderer.material.SetColor("_Color", color);
	}

	public virtual void Main()
	{
	}
}
