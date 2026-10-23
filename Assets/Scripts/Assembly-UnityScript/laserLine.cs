using System;
using UnityEngine;

[Serializable]
public class laserLine : MonoBehaviour
{
	public GameObject laserDustPrefab;

	private float startTime;

	private float life;

	private float lifeVariation;

	private float endTime;

	private float length;

	private float laserDustRate;

	private float nextLaserDustTime;

	private Color laserColor;

	private float curveProgress;

	public laserLine()
	{
		life = 1f;
		lifeVariation = 1f;
		laserDustRate = 12f;
	}

	public virtual void Start()
	{
		startTime = Time.time;
		life += lifeVariation * UnityEngine.Random.value;
		endTime = Time.time + life;
		length = UnityEngine.Random.Range(1, 3);
		laserColor = new Color(0f, 0f, 0f);
		for (int i = 0; i < transform.childCount; i++)
		{
			Transform child = transform.GetChild(i);
			child.renderer.material.SetColor("_TintColor", laserColor);
		}
	}

	public virtual void Update()
	{
		if (!(Time.time <= endTime))
		{
			UnityEngine.Object.Destroy(this.gameObject);
		}
		float num = Time.time - startTime;
		float num2 = num / life;
		curveProgress = -4f * Mathf.Pow(num2, 2f) + num2 * 4f;
		laserColor = new Color(curveProgress * 0.1f, 0f, 0f);
		for (int i = 0; i < transform.childCount; i++)
		{
			Transform child = transform.GetChild(i);
			if (child.name == "visual")
			{
				child.renderer.material.SetColor("_TintColor", laserColor);
				child.localScale = Vector3.one * 0.1f;
				float y = length + 2f * curveProgress + UnityEngine.Random.value * 1f;
				Vector3 localScale = child.localScale;
				float num3 = (localScale.y = y);
				Vector3 vector = (child.localScale = localScale);
			}
		}
		transform.localScale = Vector3.one;
		if (!(Time.time <= nextLaserDustTime))
		{
			nextLaserDustTime = Time.time + 1f / laserDustRate;
			GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(laserDustPrefab, transform.position, Quaternion.identity);
			gameObject.transform.parent = transform;
			float num4 = transform.localScale.y * 0.5f / gameObject.transform.localScale.y;
			float y2 = UnityEngine.Random.Range((0f - num4) * 0.5f, num4 * 0.5f);
			Vector3 localPosition = gameObject.transform.localPosition;
			float num5 = (localPosition.y = y2);
			Vector3 vector3 = (gameObject.transform.localPosition = localPosition);
		}
	}

	public virtual float GetCurveProgress()
	{
		return curveProgress;
	}

	public virtual void Main()
	{
	}
}
