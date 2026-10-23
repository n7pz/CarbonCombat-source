using System;
using Photon;
using UnityEngine;

[Serializable]
public class MineExploder : Photon.MonoBehaviour
{
	private string theowner;

	public GameObject explosion;

	public int damage;

	public int radius;

	public bool isemp;

	public float emptime;

	private bool wentboom;

	public AuthGameObject authobj;

	public virtual void OnCollisionEnter(Collision col)
	{
		if (!(col.gameObject != Terrain.activeTerrain.gameObject) || col.gameObject.isStatic || wentboom)
		{
			return;
		}
		wentboom = true;
		Collider[] array = Physics.OverlapSphere(transform.position, radius);
		int i = 0;
		Collider[] array2 = array;
		for (int length = array2.Length; i < length; i++)
		{
			array2[i].gameObject.SendMessage("explosionHit", theowner + "|" + Mathf.Round(damage).ToString(), SendMessageOptions.DontRequireReceiver);
			if (isemp)
			{
				array2[i].gameObject.SendMessage("empDisable", emptime, SendMessageOptions.DontRequireReceiver);
			}
		}
		UnityEngine.Object.Instantiate(explosion, transform.position, transform.rotation);
		((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("destroy", PhotonTargets.All);
	}

	public virtual void justGoBoom()
	{
		if (wentboom)
		{
			return;
		}
		wentboom = true;
		Collider[] array = Physics.OverlapSphere(transform.position, radius);
		int i = 0;
		Collider[] array2 = array;
		for (int length = array2.Length; i < length; i++)
		{
			array2[i].gameObject.SendMessage("explosionHit", theowner + "|" + Mathf.Round(damage).ToString(), SendMessageOptions.DontRequireReceiver);
			if (isemp)
			{
				array2[i].gameObject.SendMessage("empDisable", emptime, SendMessageOptions.DontRequireReceiver);
			}
		}
		UnityEngine.Object.Instantiate(explosion, transform.position, transform.rotation);
		((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("destroy", PhotonTargets.All);
	}

	public virtual void setteam(string t)
	{
		if (!AuthGameObject.ff && AuthGameObject.gametype != "Deathmatch" && AuthGameObject.gametype != "Freeplay" && AuthGameObject.gametype != "Survival")
		{
		}
	}

	public virtual void missileHit()
	{
		justGoBoom();
	}

	public virtual void OnParticleCollision(GameObject col)
	{
		justGoBoom();
	}

	public virtual void bulletHit()
	{
		justGoBoom();
	}

	public virtual void setlevel(int l)
	{
		damage += l / 2;
	}

	public virtual void setowner(string t)
	{
		((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("setownerRPC", PhotonTargets.All, t);
	}

	[RPC]
	public virtual void setownerRPC(string t)
	{
		theowner = t;
	}

	[RPC]
	public virtual void destroy()
	{
		UnityEngine.Object.Destroy(transform.parent.gameObject);
	}
}
