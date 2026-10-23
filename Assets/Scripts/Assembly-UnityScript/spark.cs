using System;
using UnityEngine;

[Serializable]
public class spark : MonoBehaviour
{
	private float life;

	private float destroyTime;

	private float angle;

	public Material[] material;

	public GameObject flyingSparkPrefab;

	private int flyingSparkAmount;

	private int flyingSparkAmountVariation;

	public spark()
	{
		life = 0.06f;
		flyingSparkAmount = 3;
		flyingSparkAmountVariation = 2;
	}

	public virtual void Start()
	{
		int num = Mathf.FloorToInt(UnityEngine.Random.value * (float)material.Length);
		renderer.material = material[num];
		destroyTime = Time.time + life;
		angle = UnityEngine.Random.value * 360f;
		transform.LookAt(Camera.main.transform.position);
		float z = transform.localRotation.eulerAngles.z + angle;
		Quaternion localRotation = transform.localRotation;
		Vector3 eulerAngles = localRotation.eulerAngles;
		float num2 = (eulerAngles.z = z);
		Vector3 vector = (localRotation.eulerAngles = eulerAngles);
		Quaternion quaternion = (transform.localRotation = localRotation);
		transform.localScale *= 0.5f + UnityEngine.Random.value;
		int num3 = flyingSparkAmount + Mathf.RoundToInt(UnityEngine.Random.Range((float)(-flyingSparkAmountVariation) * 0.5f, (float)flyingSparkAmountVariation * 0.5f));
		for (int i = 0; i < num3; i++)
		{
			UnityEngine.Object.Instantiate(flyingSparkPrefab, transform.position, transform.rotation);
		}
	}

	public virtual void Update()
	{
		if (!(Time.time <= destroyTime))
		{
			UnityEngine.Object.Destroy(gameObject);
		}
		transform.LookAt(Camera.main.transform.position);
		float z = transform.localRotation.eulerAngles.z + angle;
		Quaternion localRotation = transform.localRotation;
		Vector3 eulerAngles = localRotation.eulerAngles;
		float num = (eulerAngles.z = z);
		Vector3 vector = (localRotation.eulerAngles = eulerAngles);
		Quaternion quaternion = (transform.localRotation = localRotation);
		transform.localScale *= 1f + 10f * Time.deltaTime;
	}

	public virtual void Main()
	{
	}
}
