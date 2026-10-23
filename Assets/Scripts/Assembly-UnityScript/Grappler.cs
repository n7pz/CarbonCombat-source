using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using Photon;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class Grappler : Photon.MonoBehaviour
{
	[Serializable]
	internal sealed class _0024startRetract_00243939 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal Grappler _0024self__00243940;

			public _0024(Grappler self_)
			{
				_0024self__00243940 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__00243940.spj.maxDistance > 10f)
					{
						_0024self__00243940.spj.maxDistance = _0024self__00243940.spj.maxDistance - 2.5f * Time.deltaTime;
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Grappler _0024self__00243941;

		public _0024startRetract_00243939(Grappler self_)
		{
			_0024self__00243941 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00243941);
		}
	}

	private string theowner;

	private bool gavedamage;

	private Rigidbody homeobject;

	private SpringJoint spj;

	private bool alreadyhit;

	private Vector3 lastpos;

	public LayerMask layermask;

	private Transform firepoint;

	public AuthGameObject authobj;

	public SpawningScript spwnsrc;

	public FireGun firegun;

	public HealthBar hbar;

	private GameObject kinobj;

	private bool wearegrappled;

	private string team;

	public Grappler()
	{
		team = string.Empty;
	}

	public virtual void Awake()
	{
		lastpos = transform.position;
	}

	public virtual void setowner(string u)
	{
		theowner = u;
		gavedamage = false;
	}

	public virtual void setteam(string t)
	{
		if (!AuthGameObject.ff && AuthGameObject.gametype != "Deathmatch" && AuthGameObject.gametype != "Freeplay" && AuthGameObject.gametype != "Survival")
		{
			team = t;
		}
	}

	public virtual void setfirepoint(Transform p)
	{
		firepoint = p;
	}

	[RPC]
	public virtual void hitCar(string user, Vector3 pos, string theuser)
	{
		GameObject gameObject = null;
		GameObject gameObject2 = null;
		int num = 0;
		IEnumerator enumerator = UnityRuntimeServices.GetEnumerator(SpawningScript.spawnedCars);
		while (enumerator.MoveNext())
		{
			object obj = enumerator.Current;
			if (!(obj is GameObject))
			{
				obj = RuntimeServices.Coerce(obj, typeof(GameObject));
			}
			GameObject gameObject3 = (GameObject)obj;
			if ((bool)gameObject3 && gameObject3.active)
			{
				if (gameObject3.name == "CarPrefab(Clone)")
				{
					ReturnName returnName = (ReturnName)gameObject3.GetComponent("ReturnName");
					UnityRuntimeServices.Update(enumerator, gameObject3);
					if (returnName.returnName() == user)
					{
						gameObject = gameObject3;
						UnityRuntimeServices.Update(enumerator, gameObject3);
					}
					if (returnName.returnName() == theuser)
					{
						gameObject2 = gameObject3;
						UnityRuntimeServices.Update(enumerator, gameObject3);
					}
					if (returnName.returnAI())
					{
						gameObject3.SendMessage("empDisable", 5f);
						UnityRuntimeServices.Update(enumerator, gameObject3);
					}
				}
				num++;
			}
			else
			{
				SpawningScript.spawnedCars.RemoveAt(num);
			}
		}
		UnityEngine.Object.Destroy((Rigidbody)this.gameObject.GetComponent(typeof(Rigidbody)));
		transform.parent = gameObject.transform;
		transform.localPosition = pos;
		if (((PhotonView)gameObject.GetComponent(typeof(PhotonView))).isMine)
		{
			Debug.Log("WE ARE GRAPPLED");
			wearegrappled = true;
			if (team != SpawningScript.team2)
			{
				gameObject.SendMessage("empDisable", 5f);
			}
			if ((bool)kinobj)
			{
				UnityEngine.Object.Destroy(kinobj);
			}
			kinobj = new GameObject("GrappleLoc");
			kinobj.transform.parent = firepoint.transform;
			kinobj.transform.localPosition = Vector3.zero;
			kinobj.AddComponent(typeof(Rigidbody));
			kinobj.rigidbody.isKinematic = true;
			kinobj.AddComponent(typeof(SpringJoint));
			spj = (SpringJoint)kinobj.GetComponent(typeof(SpringJoint));
			spj.connectedBody = gameObject.rigidbody;
			spj.spring = 100f;
			spj.damper = 0f;
			spj.minDistance = 0f;
			spj.maxDistance = 50f;
			StartCoroutine_Auto(startRetract());
		}
		else if (((PhotonView)gameObject2.GetComponent(typeof(PhotonView))).isMine)
		{
			Debug.Log("WE FIRED");
			if ((bool)kinobj)
			{
				UnityEngine.Object.Destroy(kinobj);
			}
			kinobj = new GameObject("GrappleLoc");
			kinobj.transform.parent = firepoint.transform;
			kinobj.transform.localPosition = Vector3.zero;
			kinobj.AddComponent(typeof(Rigidbody));
			kinobj.rigidbody.isKinematic = true;
			kinobj.AddComponent(typeof(SpringJoint));
			spj = (SpringJoint)kinobj.GetComponent(typeof(SpringJoint));
			spj.connectedBody = gameObject.rigidbody;
			spj.spring = 100f;
			spj.damper = 0.2f;
			spj.minDistance = 0f;
			spj.maxDistance = 50f;
			StartCoroutine_Auto(startRetract());
		}
	}

	public virtual void hitRigidbody(GameObject hitobj)
	{
		UnityEngine.Object.Destroy((Rigidbody)gameObject.GetComponent(typeof(Rigidbody)));
		transform.parent = hitobj.transform;
		if ((bool)kinobj)
		{
			UnityEngine.Object.Destroy(kinobj);
		}
		kinobj = new GameObject("GrappleLoc");
		kinobj.transform.parent = firepoint.transform;
		kinobj.transform.localPosition = Vector3.zero;
		kinobj.AddComponent(typeof(Rigidbody));
		kinobj.rigidbody.isKinematic = true;
		kinobj.AddComponent(typeof(SpringJoint));
		spj = (SpringJoint)kinobj.GetComponent(typeof(SpringJoint));
		spj.connectedBody = hitobj.rigidbody;
		spj.spring = 100f;
		spj.damper = 0.2f;
		spj.minDistance = 0f;
		spj.maxDistance = 50f;
		StartCoroutine_Auto(startRetract());
	}

	public virtual void LateUpdate()
	{
		if (photonView.isMine)
		{
			if (!alreadyhit)
			{
				RaycastHit hitInfo = default(RaycastHit);
				if (Physics.Linecast(lastpos, transform.position, out hitInfo, layermask))
				{
					transform.position = hitInfo.point;
					transform.rotation = Quaternion.FromToRotation(-Vector3.forward, hitInfo.normal);
					alreadyhit = true;
					transform.parent = hitInfo.transform;
					if (hitInfo.transform.gameObject.name == "MainBoxCol" || hitInfo.transform.gameObject.name == "CarPrefab(Clone)")
					{
						ReturnName returnName = (ReturnName)hitInfo.transform.gameObject.GetComponent("ReturnName");
						((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("hitCar", PhotonTargets.All, returnName.returnName(), hitInfo.transform.InverseTransformPoint(hitInfo.point), AuthGameObject.username);
					}
					else if ((bool)(Rigidbody)hitInfo.transform.gameObject.GetComponent(typeof(Rigidbody)))
					{
						hitRigidbody(hitInfo.transform.gameObject);
					}
					else
					{
						transform.parent = hitInfo.transform;
						gameObject.AddComponent(typeof(SpringJoint));
						spj = (SpringJoint)gameObject.GetComponent(typeof(SpringJoint));
						spj.connectedBody = homeobject;
						spj.spring = 100f;
						spj.damper = 0.2f;
						spj.minDistance = 0f;
						spj.maxDistance = 50f;
						StartCoroutine_Auto(startRetract());
						rigidbody.isKinematic = true;
					}
				}
			}
			if (FireGun.stopgrapple && photonView.isMine)
			{
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("everyoneDestroy", PhotonTargets.All);
			}
			lastpos = transform.position;
		}
		if (wearegrappled && HealthBar.isdead)
		{
			((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("everyoneDestroy", PhotonTargets.All);
		}
		if (wearegrappled && FireGun.respawngrapplestop)
		{
			((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("everyoneDestroy", PhotonTargets.All);
			bool flag = false;
		}
		LineRenderer lineRenderer = (LineRenderer)gameObject.GetComponent(typeof(LineRenderer));
		lineRenderer.SetPosition(0, firepoint.position);
		lineRenderer.SetPosition(1, transform.position);
	}

	[RPC]
	public virtual void everyoneDestroy()
	{
		if ((bool)kinobj)
		{
			UnityEngine.Object.Destroy(kinobj);
		}
		if ((bool)spj)
		{
			UnityEngine.Object.Destroy(spj);
		}
		if (photonView.isMine)
		{
			FireGun.stopgrappleyield = true;
		}
		UnityEngine.Object.Destroy(gameObject);
	}

	public virtual void sethome(Rigidbody o)
	{
		homeobject = o;
	}

	public virtual IEnumerator startRetract()
	{
		return new _0024startRetract_00243939(this).GetEnumerator();
	}
}
