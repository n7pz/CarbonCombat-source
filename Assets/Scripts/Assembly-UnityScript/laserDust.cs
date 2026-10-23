using System;
using Boo.Lang.Runtime;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class laserDust : MonoBehaviour
{
	private float startTime;

	private float life;

	private float lifeVariation;

	private float endTime;

	private float length;

	private float scale;

	private float maxAlpha;

	public laserDust()
	{
		life = 0.5f;
		lifeVariation = 1f;
	}

	public virtual void Start()
	{
		startTime = Time.time;
		life += lifeVariation * UnityEngine.Random.value;
		endTime = Time.time + life;
		length = UnityEngine.Random.Range(6, 8);
		scale = UnityEngine.Random.Range(0.11f, 0.14f);
		Color color = new Color(0f, 0f, 0f);
		renderer.material.SetColor("_TintColor", color);
		maxAlpha = UnityEngine.Random.Range(0.1f, 0.3f);
	}

	public virtual void Update()
	{
		if (!(Time.time <= endTime))
		{
			UnityEngine.Object.Destroy(gameObject);
		}
		float num = Time.time - startTime;
		float num2 = num / life;
		float num3 = -4f * Mathf.Pow(num2, 2f) + num2 * 4f;
		float num4 = 1f;
		if (transform.parent != null)
		{
			num4 = RuntimeServices.UnboxSingle(UnityRuntimeServices.Invoke(transform.parent.GetComponent("laserLine"), "GetCurveProgress", new object[0], typeof(MonoBehaviour)));
		}
		Color color = new Color(num3 * maxAlpha * num4, 0f, 0f);
		renderer.material.SetColor("_TintColor", color);
		transform.LookAt(Camera.main.transform.position);
		transform.localScale = Vector3.one * (scale + num3 * scale * 0.2f);
	}

	public virtual void Main()
	{
	}
}
