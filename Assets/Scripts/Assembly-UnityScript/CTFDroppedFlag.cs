using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Photon;
using UnityEngine;

[Serializable]
public class CTFDroppedFlag : Photon.MonoBehaviour
{
	[Serializable]
	internal sealed class _0024yielddestroy_00243387 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal CTFDroppedFlag _0024self__00243388;

			public _0024(CTFDroppedFlag self_)
			{
				_0024self__00243388 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					result = (Yield(2, new WaitForSeconds(1.5f)) ? 1 : 0);
					break;
				case 2:
					if (_0024self__00243388.destroyobj)
					{
						UnityEngine.Object.Destroy(_0024self__00243388.gameObject);
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

		internal CTFDroppedFlag _0024self__00243389;

		public _0024yielddestroy_00243387(CTFDroppedFlag self_)
		{
			_0024self__00243389 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00243389);
		}
	}

	[Serializable]
	internal sealed class _0024FlagTake_00243390 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal GameObject _0024obj_00243391;

			internal CapsuleCollider[] _0024coll_00243392;

			internal int _0024_0024436_00243393;

			internal GameObject[] _0024_0024437_00243394;

			internal int _0024_0024438_00243395;

			internal CTFDroppedFlag _0024self__00243396;

			public _0024(CTFDroppedFlag self_)
			{
				_0024self__00243396 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00243396.renderer.enabled = false;
					_0024_0024436_00243393 = 0;
					_0024_0024437_00243394 = _0024self__00243396.objects2disable;
					for (_0024_0024438_00243395 = _0024_0024437_00243394.Length; _0024_0024436_00243393 < _0024_0024438_00243395; _0024_0024436_00243393++)
					{
						_0024_0024437_00243394[_0024_0024436_00243393].active = false;
					}
					_0024coll_00243392 = _0024self__00243396.GetComponents<CapsuleCollider>();
					UnityEngine.Object.Destroy(_0024coll_00243392[0]);
					_0024self__00243396.flagtake.emit = true;
					result = (YieldDefault(2) ? 1 : 0);
					break;
				case 2:
					result = (YieldDefault(3) ? 1 : 0);
					break;
				case 3:
					result = (YieldDefault(4) ? 1 : 0);
					break;
				case 4:
					reclaimflag = 5;
					result = (YieldDefault(5) ? 1 : 0);
					break;
				case 5:
					UnityEngine.Object.Destroy(_0024self__00243396.gameObject);
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal CTFDroppedFlag _0024self__00243397;

		public _0024FlagTake_00243390(CTFDroppedFlag self_)
		{
			_0024self__00243397 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00243397);
		}
	}

	public ParticleEmitter flagtake;

	public string team;

	public SpawningScript src;

	public AuthGameObject authobj;

	public CTFFlagSender ctfflagsender;

	private GameObject srcobj;

	private float counter;

	private bool startenter;

	public GameObject[] objects2disable;

	[NonSerialized]
	public static int reclaimflag;

	private bool destroyobj;

	public ChatScript cscript;

	public CTFDroppedFlag()
	{
		counter = 1.5f;
		destroyobj = true;
	}

	public virtual void Start()
	{
		reclaimflag = 0;
		srcobj = GameObject.Find("/GUI/Chat");
		if (!PhotonNetwork.isMasterClient)
		{
			((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("confirmflag", PhotonTargets.MasterClient);
			StartCoroutine_Auto(yielddestroy());
		}
	}

	public virtual IEnumerator yielddestroy()
	{
		return new _0024yielddestroy_00243387(this).GetEnumerator();
	}

	[RPC]
	public virtual void confirmflag(PhotonMessageInfo info)
	{
		((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("confirmed", info.sender);
	}

	[RPC]
	public virtual void confirmed()
	{
		destroyobj = false;
	}

	public virtual void Update()
	{
		if (!(counter <= 0f))
		{
			counter -= Time.deltaTime;
		}
		else
		{
			startenter = true;
		}
	}

	public virtual void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.name == "MainBoxCol" && ChatScript.isCar && ((PhotonView)col.gameObject.GetComponent(typeof(PhotonView))).isMine && startenter)
		{
			if (SpawningScript.team2 != team)
			{
				col.gameObject.SendMessage("setflagteam", team);
				col.gameObject.SendMessage("setctf", true);
				CTFFlagSender.gotflag = true;
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("FlagTake", PhotonTargets.All);
				reclaimflag = 1;
				srcobj.SendMessage("OutsideSystem", AuthGameObject.username + " recaptured the " + team + " flag!");
			}
			else
			{
				col.gameObject.SendMessage("setflagteam", team);
				CTFFlagSender.gotflag = true;
				col.gameObject.SendMessage("setctf", true);
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("FlagTake", PhotonTargets.All);
				reclaimflag = 2;
				srcobj.SendMessage("OutsideSystem", AuthGameObject.username + " reclaimed the " + team + " flag!");
			}
		}
		if (col.gameObject.name == "HumanPrefab(Clone)" && ((PhotonView)col.transform.gameObject.GetComponent(typeof(PhotonView))).isMine && !ChatScript.isCar)
		{
			GameObject.Find("/GUI/SubMessage").SendMessage("setMessage", "You cannot pick up items when outside the car!");
		}
	}

	[RPC]
	public virtual IEnumerator FlagTake(PhotonMessageInfo info)
	{
		return new _0024FlagTake_00243390(this).GetEnumerator();
	}
}
