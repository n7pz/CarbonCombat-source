using System;
using Photon;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class HardImpactSend : Photon.MonoBehaviour
{
	public GameObject maincollider;

	public GameObject crashaudio;

	public AIManager aimanager;

	public virtual void externaldrop()
	{
		maincollider.SendMessage("externaldrop");
	}

	public virtual void bulletHit(string u)
	{
		if (photonView.isMine || aimanager.isAI)
		{
			maincollider.SendMessage("bulletHit", u);
		}
		else
		{
			maincollider.SendMessage("flash");
		}
	}

	public virtual void OnCollisionEnter(Collision collision)
	{
		if ((photonView.isMine || aimanager.isAI) && collision.gameObject.name != "RocketPrefab(Clone)" && collision.gameObject.name != "LaserPrefab(Clone)" && collision.gameObject.name != "LowPolyCasingPrefab(Clone)" && collision.gameObject.name != "GrenadePrefab(Clone)")
		{
			if (!(collision.relativeVelocity.magnitude < 60f))
			{
				maincollider.SendMessage("hardimpact", collision.relativeVelocity.magnitude);
			}
			bool flag = true;
		}
		if (!(collision.relativeVelocity.magnitude < 60f) && collision.gameObject.name != "LowPolyCasingPrefab(Clone)" && UnityScript.Lang.Extensions.get_length((System.Array)collision.contacts) > 0)
		{
			ContactPoint contactPoint = collision.contacts[0];
			Quaternion rotation = Quaternion.FromToRotation(Vector3.up, contactPoint.normal);
			Vector3 point = contactPoint.point;
			GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(crashaudio, point, rotation);
			gameObject.transform.audio.volume = collision.relativeVelocity.magnitude / 120f * 0.8f;
			float num = collision.relativeVelocity.magnitude / 250f;
			if (!(num <= 0.4f))
			{
				num = 0.4f;
			}
			gameObject.transform.audio.pitch = num;
		}
	}

	public virtual void outofbounds()
	{
		maincollider.SendMessage("hardimpact", 6025);
	}

	public virtual void resethealth()
	{
		maincollider.SendMessage("resethealth");
	}

	public virtual void missileHit(string u)
	{
		if (photonView.isMine || aimanager.isAI)
		{
			maincollider.SendMessage("missileHit", u);
		}
		else
		{
			maincollider.SendMessage("flash");
		}
	}

	public virtual void laserCannonHit(string u)
	{
		if (photonView.isMine || aimanager.isAI)
		{
			maincollider.SendMessage("laserCannonHit", u);
		}
		else
		{
			maincollider.SendMessage("flash");
		}
	}

	public virtual void grenadeHit(string u)
	{
		if (photonView.isMine || aimanager.isAI)
		{
			maincollider.SendMessage("grenadeHit", u);
		}
		else
		{
			maincollider.SendMessage("flash");
		}
	}

	public virtual void empgrenadeHit(string u)
	{
		if (photonView.isMine || aimanager.isAI)
		{
			maincollider.SendMessage("empgrenadeHit", u);
		}
		else
		{
			maincollider.SendMessage("flash");
		}
	}

	public virtual void bladeHitLarge(string u)
	{
		if (photonView.isMine || aimanager.isAI)
		{
			maincollider.SendMessage("bladeHitLarge", u);
		}
		else
		{
			maincollider.SendMessage("flash");
		}
	}

	public virtual void bladeHit(string u)
	{
		if (photonView.isMine || aimanager.isAI)
		{
			maincollider.SendMessage("bladeHit", u);
		}
		else
		{
			maincollider.SendMessage("flash");
		}
	}

	public virtual void shotgunBulletHit(string u)
	{
		if (photonView.isMine || aimanager.isAI)
		{
			maincollider.SendMessage("shotgunBulletHit", u);
		}
		else
		{
			maincollider.SendMessage("flash");
		}
	}

	public virtual void railBulletHit(string u)
	{
		if (photonView.isMine || aimanager.isAI)
		{
			maincollider.SendMessage("railBulletHit", u);
		}
		else
		{
			maincollider.SendMessage("flash");
		}
	}

	public virtual void rockethit(string u)
	{
		if (photonView.isMine || aimanager.isAI)
		{
			maincollider.SendMessage("rockethit", u);
		}
		else
		{
			maincollider.SendMessage("flash");
		}
	}

	public virtual void laserhit(string u)
	{
		if (photonView.isMine || aimanager.isAI)
		{
			maincollider.SendMessage("laserhit", u);
		}
		else
		{
			maincollider.SendMessage("flash");
		}
	}

	public virtual void forceSetHealth(float h)
	{
		maincollider.SendMessage("forcehealth", h);
	}

	public virtual void forceCloak(bool s)
	{
		if (s)
		{
			maincollider.SendMessage("Cloak");
		}
		else
		{
			maincollider.SendMessage("cloakkill");
		}
	}

	public virtual void Main()
	{
	}
}
