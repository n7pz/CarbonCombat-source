using System;
using UnityEngine;

[Serializable]
public class bulletHole : MonoBehaviour
{
	public Material[] materials;

	public float life;

	public float size;

	private float destroyTime;

	private float startTime;

	public bulletHole()
	{
		life = 4f;
		size = 1f;
	}

	public virtual void Start()
	{
		startTime = Time.time;
		destroyTime = Time.time + life;
		int num = Mathf.RoundToInt(UnityEngine.Random.Range(0, materials.Length));
		renderer.material = materials[num];
		Transform parent = transform.parent;
		transform.parent = null;
		float z = UnityEngine.Random.value * 360f;
		Quaternion localRotation = transform.localRotation;
		Vector3 eulerAngles = localRotation.eulerAngles;
		float num2 = (eulerAngles.z = z);
		Vector3 vector = (localRotation.eulerAngles = eulerAngles);
		Quaternion quaternion = (transform.localRotation = localRotation);
		transform.localScale = Vector3.one * (0.5f + UnityEngine.Random.value * 0.5f) * size;
		transform.parent = parent;
	}

	public virtual void Update()
	{
		if (!(Time.time <= destroyTime))
		{
			UnityEngine.Object.Destroy(gameObject);
		}
		if (!(Time.time <= destroyTime - 1f))
		{
			float num = destroyTime - Time.time;
			float a = num;
			Color color = renderer.material.color;
			float num2 = (color.a = a);
			Color color2 = (renderer.material.color = color);
		}
	}

	public virtual void Main()
	{
	}
}
