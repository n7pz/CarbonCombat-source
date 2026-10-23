using System;
using UnityEngine;

[Serializable]
public class AdjustScaleBasedOnCamDist : MonoBehaviour
{
	public virtual void OnEnable()
	{
		transform.localScale = new Vector3(1f, 1f, 1f) * Mathf.Clamp(Vector3.Distance(transform.position, Camera.main.transform.position) / 65f, 1f, float.PositiveInfinity);
	}

	public virtual void Update()
	{
		transform.localScale = new Vector3(1f, 1f, 1f) * Mathf.Clamp(Vector3.Distance(transform.position, Camera.main.transform.position) / 65f, 1f, float.PositiveInfinity);
	}

	public virtual void Main()
	{
	}
}
