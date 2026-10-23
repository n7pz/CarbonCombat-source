using System;
using UnityEngine;

[Serializable]
public class muzzleFlash : MonoBehaviour
{
	public float minLife;

	public float maxLife;

	private float destroyTime;

	private float angle;

	public muzzleFlash()
	{
		minLife = 0.01f;
		maxLife = 0.02f;
	}

	public virtual void Start()
	{
		destroyTime = Time.time + UnityEngine.Random.Range(minLife, maxLife);
		angle = 90f * Mathf.Round(UnityEngine.Random.Range(0, 3));
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
	}

	public virtual void Main()
	{
	}
}
