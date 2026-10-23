using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using Photon;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class HealthItem : Photon.MonoBehaviour
{
	[Serializable]
	internal sealed class _0024Start_00244741 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal HealthItem _0024self__00244742;

			public _0024(HealthItem self_)
			{
				_0024self__00244742 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					result = (Yield(2, new WaitForSeconds(3f)) ? 1 : 0);
					break;
				case 2:
					if (AuthGameObject.gametype == "Survival")
					{
						_0024self__00244742.renderer.enabled = false;
						_0024self__00244742.crate.enabled = true;
					}
					else
					{
						_0024self__00244742.crate.enabled = false;
						if (!_0024self__00244742.disabled)
						{
							_0024self__00244742.renderer.enabled = true;
						}
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

		internal HealthItem _0024self__00244743;

		public _0024Start_00244741(HealthItem self_)
		{
			_0024self__00244743 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00244743);
		}
	}

	[Serializable]
	internal sealed class _0024enabledelegate_00244744 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal float _0024t_00244745;

			internal HealthItem _0024self__00244746;

			public _0024(float t, HealthItem self_)
			{
				_0024t_00244745 = t;
				_0024self__00244746 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (!(PhotonNetwork.time >= (double)_0024t_00244745) && !HealthBar.showendofround)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					if (AuthGameObject.gametype != "Survival")
					{
						_0024self__00244746.renderer.enabled = true;
					}
					else
					{
						_0024self__00244746.crate.enabled = true;
					}
					_0024self__00244746.disabled = false;
					_0024self__00244746.glow.emit = true;
					if (PhotonNetwork.isMasterClient)
					{
						PhotonNetwork.RemoveRPCs(_0024self__00244746.photonView);
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

		internal float _0024t_00244747;

		internal HealthItem _0024self__00244748;

		public _0024enabledelegate_00244744(float t, HealthItem self_)
		{
			_0024t_00244747 = t;
			_0024self__00244748 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024t_00244747, _0024self__00244748);
		}
	}

	public ParticleEmitter glow;

	public Renderer crate;

	private bool disabled;

	private ChatScript cscript;

	private AuthGameObject authobj;

	private HealthBar hbar;

	private FireGun fgun;

	private UnityScript.Lang.Array weaponList;

	private UnityScript.Lang.Array armorList;

	public HealthItem()
	{
		weaponList = new UnityScript.Lang.Array("flamethrower|flamethrower", "grappling|grappling hook", "lasercannon|laser cannon", "laser|plasma blaster", "minigun|minigun", "missile|missile launcher", "railgun|railgun", "rocket|rocket launcher", "emplauncher|EMP grenade launcher", "launcher|grenade launcher", "shotgun|shotgun");
		armorList = new UnityScript.Lang.Array("basic armor", "light armor", "assault armor", "heavy armor", "invisibility armor");
	}

	public virtual IEnumerator Start()
	{
		return new _0024Start_00244741(this).GetEnumerator();
	}

	public virtual void OnTriggerEnter(Collider objenter)
	{
		if (!disabled)
		{
			if (objenter.gameObject.name == "MainBoxCol")
			{
				ReturnName returnName = (ReturnName)objenter.gameObject.GetComponent("ReturnName");
				if (((PhotonView)objenter.gameObject.GetComponent(typeof(PhotonView))).isMine && !returnName.returnAI())
				{
					if (AuthGameObject.gametype != "Survival")
					{
						objenter.gameObject.SendMessage("HealthUp", 1692);
					}
					else if (UnityEngine.Random.Range(0, 2) == 0)
					{
						int index = UnityEngine.Random.Range(0, weaponList.length);
						if (FireGun.guntype == "rocket")
						{
							GameObject.Find("/GUI/Chat").SendMessage("changeWeapons", RuntimeServices.InvokeBinaryOperator("op_Addition", RuntimeServices.GetSlice(RuntimeServices.Invoke(weaponList[index], "Split", new object[1] { "|"[0] }), string.Empty, new object[1] { 0 }), "|2"));
							GameObject.Find("/GUI/SubMessage").SendMessage("setMessage4", RuntimeServices.InvokeBinaryOperator("op_Addition", RuntimeServices.InvokeBinaryOperator("op_Addition", "Equipping ", RuntimeServices.GetSlice(RuntimeServices.Invoke(weaponList[index], "Split", new object[1] { "|"[0] }), string.Empty, new object[1] { 1 })), " as secondary weapon...\nPress [3] to cancel"));
						}
						else
						{
							GameObject.Find("/GUI/Chat").SendMessage("changeWeapons", RuntimeServices.InvokeBinaryOperator("op_Addition", RuntimeServices.GetSlice(RuntimeServices.Invoke(weaponList[index], "Split", new object[1] { "|"[0] }), string.Empty, new object[1] { 0 }), "|1"));
							GameObject.Find("/GUI/SubMessage").SendMessage("setMessage4", RuntimeServices.InvokeBinaryOperator("op_Addition", RuntimeServices.InvokeBinaryOperator("op_Addition", "Equipping ", RuntimeServices.GetSlice(RuntimeServices.Invoke(weaponList[index], "Split", new object[1] { "|"[0] }), string.Empty, new object[1] { 1 })), " as primary weapon...\nPress [3] to cancel"));
						}
					}
					else
					{
						int index = UnityEngine.Random.Range(0, 101);
						int num = -1;
						if (index > 0)
						{
							num++;
						}
						if (index > 30)
						{
							num++;
						}
						if (index > 60)
						{
							num++;
						}
						if (index > 80)
						{
							num++;
						}
						if (index > 90)
						{
							num++;
						}
						GameObject.Find("/GUI/Chat").SendMessage("changeArmor", num + 1);
						GameObject.Find("/GUI/SubMessage").SendMessage("setMessage4", RuntimeServices.InvokeBinaryOperator("op_Addition", RuntimeServices.InvokeBinaryOperator("op_Addition", "Equipping ", armorList[num]), "...\nPress [3] to cancel"));
					}
					if (AuthGameObject.gametype != "Survival")
					{
						renderer.enabled = false;
					}
					else
					{
						crate.enabled = false;
					}
					glow.emit = false;
					disabled = true;
					((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("destroy", PhotonTargets.AllBuffered);
				}
				else if (AuthGameObject.gametype != "Survival")
				{
					objenter.gameObject.SendMessage("HealthUp", 1692);
				}
			}
			if (objenter.gameObject.name == "HumanPrefab(Clone)" && ((PhotonView)objenter.transform.gameObject.GetComponent(typeof(PhotonView))).isMine && !ChatScript.isCar)
			{
				GameObject.Find("/GUI/SubMessage").SendMessage("setMessage", "You cannot pick up items when outside the car!");
			}
			return;
		}
		if (AuthGameObject.gametype != "Survival")
		{
			if (renderer.enabled)
			{
				renderer.enabled = false;
			}
		}
		else if (crate.enabled)
		{
			crate.enabled = false;
		}
		if (glow.emit)
		{
			glow.emit = false;
		}
	}

	public virtual IEnumerator enabledelegate(float t)
	{
		return new _0024enabledelegate_00244744(t, this).GetEnumerator();
	}

	[RPC]
	public virtual void destroy(PhotonMessageInfo info)
	{
		if (AuthGameObject.gametype != "Survival")
		{
			renderer.enabled = false;
		}
		else
		{
			crate.enabled = false;
		}
		glow.emit = false;
		disabled = true;
		Debug.Log("Sending enable delegate with time of " + (info.timestamp + 150.0));
		StartCoroutine_Auto(enabledelegate((float)(info.timestamp + 150.0)));
	}
}
