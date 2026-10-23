using System;
using Boo.Lang.Runtime;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class BarrelExplode : MonoBehaviour
{
	public Transform mainbarrel;

	public Transform explosionpoint;

	public Transform deadbarrel;

	public Transform explosion;

	public AuthGameObject authobj;

	private bool isdead;

	public virtual void laserhit(string u)
	{
		blowup(u);
	}

	public virtual void rockethit(string u)
	{
		blowup(u);
	}

	public virtual void shotgunBulletHit(string u)
	{
		blowup(u);
	}

	public virtual void bulletHit(string u)
	{
		blowup(u);
	}

	public virtual void laserCannonHit(string u)
	{
		blowup(u);
	}

	public virtual void railBulletHit(string u)
	{
		blowup(u);
	}

	public virtual void missileHit(string u)
	{
		blowup(u);
	}

	public virtual void explosionHit(string u)
	{
		blowup(u);
	}

	public virtual void OnParticleCollision(GameObject theparticle)
	{
		object lhs = UnityRuntimeServices.Invoke(theparticle.GetComponent("FlameScript"), "returnUser", new object[0], typeof(MonoBehaviour));
		object obj = RuntimeServices.InvokeBinaryOperator("op_Addition", lhs, "|1");
		if (!(obj is string))
		{
			obj = RuntimeServices.Coerce(obj, typeof(string));
		}
		blowup((string)obj);
	}

	public virtual void blowup(string userhit)
	{
		userhit = userhit.Split("|"[0])[0];
		if (!isdead)
		{
			isdead = true;
			Collider[] array = Physics.OverlapSphere(this.transform.position, 30f);
			int i = 0;
			Collider[] array2 = array;
			for (int length = array2.Length; i < length; i++)
			{
				array2[i].gameObject.SendMessage("explosionHit", userhit + "|" + 65.ToString(), SendMessageOptions.DontRequireReceiver);
			}
			gameObject.name = "CanBoom";
			if (GameObject.Find("CanisterPrefab") == null && Application.loadedLevelName == "ChokePoint")
			{
				GameObject.Find("/AuthGameObject").SendMessage("gotAch", "Boom!");
			}
			Transform transform = null;
			Transform transform2 = null;
			if (deadbarrel != null)
			{
				transform = (Transform)UnityEngine.Object.Instantiate(deadbarrel, explosionpoint.position, explosionpoint.rotation);
			}
			transform2 = (Transform)UnityEngine.Object.Instantiate(explosion, explosionpoint.position, explosionpoint.rotation);
			UnityEngine.Object.Destroy(mainbarrel.gameObject);
		}
	}

	public virtual void Main()
	{
	}
}
