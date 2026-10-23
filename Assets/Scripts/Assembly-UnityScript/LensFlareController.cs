using System;
using UnityEngine;

[Serializable]
public class LensFlareController : MonoBehaviour
{
	private LensFlare lF;

	private int hideLayer;

	private int showLayer;

	public LensFlareController()
	{
		hideLayer = 16;
		showLayer = 9;
	}

	public virtual void Awake()
	{
		lF = (LensFlare)gameObject.GetComponent(typeof(LensFlare));
	}

	public virtual void Update()
	{
		if (gameObject.layer == hideLayer && lF.enabled)
		{
			lF.enabled = false;
		}
		else if (gameObject.layer == showLayer && !lF.enabled)
		{
			lF.enabled = true;
		}
	}

	public virtual void Main()
	{
	}
}
