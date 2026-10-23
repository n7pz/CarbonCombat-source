using System;
using UnityEngine;

[Serializable]
public class laserPoint : MonoBehaviour
{
	public bool on;

	public laserPoint()
	{
		on = true;
	}

	public virtual void Update()
	{
		if (on)
		{
			transform.LookAt(Camera.main.transform.position);
			transform.localScale = Vector3.one * UnityEngine.Random.Range(0.3f, 0.5f);
			Color red = Color.red;
			red.a = UnityEngine.Random.Range(0.2f, 1f);
			renderer.material.SetColor("_TintColor", red);
			renderer.enabled = true;
		}
		else
		{
			renderer.enabled = false;
		}
	}

	public virtual void Main()
	{
	}
}
