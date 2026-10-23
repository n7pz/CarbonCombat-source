using System;
using UnityEngine;

[Serializable]
public class LFlareQuality : MonoBehaviour
{
	private LensFlare lflare;

	public virtual void Awake()
	{
		lflare = (LensFlare)gameObject.GetComponent(typeof(LensFlare));
	}

	public virtual void Update()
	{
		if (QualitySettings.GetQualityLevel() == 4 || QualitySettings.GetQualityLevel() == 5)
		{
			if (!lflare.enabled)
			{
				lflare.enabled = true;
			}
		}
		else if (lflare.enabled)
		{
			lflare.enabled = false;
		}
	}

	public virtual void Main()
	{
	}
}
