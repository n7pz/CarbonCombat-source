using System;
using Photon;
using UnityEngine;

[Serializable]
public class RainbowManager : Photon.MonoBehaviour
{
	public ParticleEmitter rainbowPart;

	public PlayerCar_Script pcar;

	public ChatScript cscript;

	public AIManager aimanager;

	public virtual void Start()
	{
		if (ChatScript.hasrainbow && photonView.isMine && !aimanager.isAI)
		{
			((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("enableRainbow", PhotonTargets.AllBuffered);
			enableRainbow();
		}
	}

	[RPC]
	public virtual void enableRainbow()
	{
		((TrailRenderer)gameObject.GetComponent(typeof(TrailRenderer))).enabled = true;
		rainbowPart.emit = true;
	}

	public virtual void Update()
	{
		if (rainbowPart.emit)
		{
			rainbowPart.minEmission = Mathf.Min(PlayerCar_Script.mph, 40f) / 40f * 20f;
			rainbowPart.maxEmission = Mathf.Min(PlayerCar_Script.mph, 40f) / 40f * 25f;
		}
	}
}
