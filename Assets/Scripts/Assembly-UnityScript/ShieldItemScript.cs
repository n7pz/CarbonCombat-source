using System;
using Photon;
using UnityEngine;

[Serializable]
public class ShieldItemScript : Photon.MonoBehaviour
{
	private int level;

	private float health;

	private float lastHealth;

	public Color deadcolor;

	private Color initcolor;

	public AIManager aimanager;

	public ShieldItemScript()
	{
		health = 100f;
		lastHealth = 100f;
	}

	[RPC]
	public virtual void s(float h)
	{
		health = h;
		setColor(health);
	}

	public virtual void Update()
	{
		if (lastHealth != health && photonView.isMine)
		{
			lastHealth = health;
			((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("s", PhotonTargets.Others, health);
		}
	}

	public virtual void Awake()
	{
		initcolor = renderer.material.GetColor("_Color");
		gameObject.active = false;
	}

	[RPC]
	public virtual void setLevel(int l)
	{
		level = l;
		health = 100f;
		renderer.material.SetColor("_Color", initcolor);
	}

	[RPC]
	public virtual void setColor(float h)
	{
		renderer.material.SetColor("_Color", Color.Lerp(initcolor, deadcolor, 1f - h / 100f));
	}

	public virtual void takeDamage(float i)
	{
		health -= i * (float)(1 - level / 50);
		if (photonView.isMine)
		{
			setColor(health);
		}
		if (!(health > 0f))
		{
			((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("dropShields", PhotonTargets.All);
		}
	}

	public virtual void dropShieldsRPC()
	{
		((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("dropShields", PhotonTargets.All);
	}

	[RPC]
	public virtual void dropShields()
	{
		gameObject.active = false;
	}
}
