using System;
using UnityEngine;

[Serializable]
public class flyingSpark : MonoBehaviour
{
	public float life;

	public float lifeVariation;

	private float startTime;

	private float destroyTime;

	private Vector3 velocity;

	private float gravity;

	private float scale;

	public flyingSpark()
	{
		life = 1.5f;
		lifeVariation = 0.5f;
		gravity = 9.8f;
		scale = 1f;
	}

	public virtual void Start()
	{
		startTime = Time.time;
		life += UnityEngine.Random.Range((0f - lifeVariation) * 0.5f, lifeVariation * 0.5f);
		destroyTime = Time.time + life;
		velocity = UnityEngine.Random.insideUnitSphere * 4f;
		velocity.y += UnityEngine.Random.value * 3f;
	}

	public virtual void Update()
	{
		if (!(Time.time <= destroyTime))
		{
			UnityEngine.Object.Destroy(gameObject);
		}
		RaycastHit hitInfo = default(RaycastHit);
		if (Physics.Raycast(transform.position, velocity, out hitInfo, velocity.magnitude * Time.deltaTime))
		{
			velocity = Vector3.Reflect(velocity, hitInfo.normal);
		}
		velocity.y -= gravity * Time.deltaTime;
		velocity = Vector3.Lerp(velocity, Vector3.zero, Time.deltaTime);
		transform.position += velocity * Time.deltaTime;
		transform.LookAt(transform.position + velocity);
		scale = Mathf.Lerp(0.2f, 0.05f, (Time.time - startTime) / life);
		transform.localScale = Vector3.one * scale;
		float z = (0.2f + velocity.magnitude * 0.6f) * scale;
		Vector3 localScale = transform.localScale;
		float num = (localScale.z = z);
		Vector3 vector = (transform.localScale = localScale);
	}

	public virtual void Main()
	{
	}
}
