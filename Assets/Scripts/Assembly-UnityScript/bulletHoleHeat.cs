using System;
using UnityEngine;

[Serializable]
public class bulletHoleHeat : MonoBehaviour
{
	public float life;

	public Color startColor;

	public Color endColor;

	private float startTime;

	private float destroyTime;

	public bulletHoleHeat()
	{
		life = 1f;
	}

	public virtual void Start()
	{
		life = UnityEngine.Random.value * life;
		startTime = Time.time;
		destroyTime = Time.time + life;
	}

	public virtual void Update()
	{
		if (!(Time.time <= destroyTime))
		{
			UnityEngine.Object.Destroy(gameObject);
		}
		float num = Time.time - startTime;
		float t = num / life;
		Color color = renderer.material.GetColor("_TintColor");
		color = Color.Lerp(startColor, endColor, t);
		color.a = Mathf.Lerp(1f, 0f, t);
		renderer.material.SetColor("_TintColor", color);
	}

	public virtual void Main()
	{
	}
}
