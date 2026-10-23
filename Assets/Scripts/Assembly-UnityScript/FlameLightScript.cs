using System;
using UnityEngine;

[Serializable]
public class FlameLightScript : MonoBehaviour
{
	private bool lightenabled;

	public FlameLightScript()
	{
		lightenabled = true;
	}

	public virtual void setEnable(bool t)
	{
		lightenabled = t;
	}

	public virtual void Update()
	{
		if (lightenabled)
		{
			light.intensity = Mathf.Clamp01(light.intensity + 10f * Time.deltaTime);
			int num = (int)(Time.time * 4f);
			if (!(Time.time - (float)num / 4f >= 0.125f))
			{
				light.intensity += (Time.time - (float)num / 4f) * 1f;
			}
			else
			{
				light.intensity += (0.5f - (Time.time - (float)num / 4f)) * 1f;
			}
		}
		else
		{
			light.intensity = Mathf.Clamp01(light.intensity - 10f * Time.deltaTime);
		}
	}

	public virtual void Main()
	{
	}
}
