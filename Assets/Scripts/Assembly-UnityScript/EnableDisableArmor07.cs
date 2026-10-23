using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Photon;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class EnableDisableArmor07 : Photon.MonoBehaviour
{
	[Serializable]
	internal sealed class _0024setRenderer_00243693 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal int _0024i_00243694;

			internal bool _0024t_00243695;

			internal int _0024vt_00243696;

			internal EnableDisableArmor07 _0024self__00243697;

			public _0024(bool t, int vt, EnableDisableArmor07 self_)
			{
				_0024t_00243695 = t;
				_0024vt_00243696 = vt;
				_0024self__00243697 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00243697.armor = _0024t_00243695;
					if (_0024t_00243695)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					for (_0024i_00243694 = 0; _0024i_00243694 < UnityScript.Lang.Extensions.get_length((System.Array)_0024self__00243697.armorArr); _0024i_00243694++)
					{
						_0024self__00243697.armorArr[_0024i_00243694].enabled = false;
						_0024self__00243697.armorArr[_0024i_00243694].gameObject.layer = 16;
					}
					goto IL_0193;
				case 2:
					result = (YieldDefault(3) ? 1 : 0);
					break;
				case 3:
					for (_0024i_00243694 = 0; _0024i_00243694 < UnityScript.Lang.Extensions.get_length((System.Array)_0024self__00243697.armorArr); _0024i_00243694++)
					{
						if (_0024vt_00243696 == _0024i_00243694)
						{
							_0024self__00243697.armorArr[_0024i_00243694].enabled = true;
							_0024self__00243697.armorArr[_0024i_00243694].gameObject.active = true;
							_0024self__00243697.armorArr[_0024i_00243694].gameObject.layer = 10;
						}
						else
						{
							_0024self__00243697.armorArr[_0024i_00243694].enabled = false;
							_0024self__00243697.armorArr[_0024i_00243694].gameObject.layer = 16;
						}
					}
					goto IL_0193;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0193:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal bool _0024t_00243698;

		internal int _0024vt_00243699;

		internal EnableDisableArmor07 _0024self__00243700;

		public _0024setRenderer_00243693(bool t, int vt, EnableDisableArmor07 self_)
		{
			_0024t_00243698 = t;
			_0024vt_00243699 = vt;
			_0024self__00243700 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024t_00243698, _0024vt_00243699, _0024self__00243700);
		}
	}

	public ChatScript cscript;

	public Renderer gtrbasic;

	public AIManager aimanager;

	public AuthGameObject authobj;

	public SpawningScript spwnsrc;

	private bool armor;

	private bool gtrcar;

	public Renderer[] armorArr;

	[RPC]
	public virtual IEnumerator setRenderer(bool t, int vt)
	{
		return new _0024setRenderer_00243693(t, vt, this).GetEnumerator();
	}

	public virtual void Start()
	{
		if (photonView.isMine && !aimanager.isAI)
		{
			PhotonNetwork.RemoveRPCs(photonView);
			if (!ChatScript.hasghost)
			{
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("setRenderer", PhotonTargets.All, ChatScript.hasarmor7, ChatScript.vehicleType);
			}
		}
	}

	public virtual void OnTriggerStay(Collider col)
	{
		if (!renderer.enabled || (!(col.gameObject.name == "MainBoxCol") && !(col.gameObject.name == "CarPrefab(Clone)")))
		{
			return;
		}
		if (((PhotonView)col.gameObject.GetComponent(typeof(PhotonView))).isMine)
		{
			if (!((PhotonView)gameObject.GetComponent(typeof(PhotonView))).isMine)
			{
				col.gameObject.SendMessage("bladeHitLarge", AuthGameObject.username + "|1");
				return;
			}
			ReturnName returnName = (ReturnName)col.gameObject.GetComponent("ReturnName");
			string text = returnName.returnName();
			if (returnName.returnAI())
			{
				col.gameObject.SendMessage("bladeHitLarge", AuthGameObject.username + "|1");
			}
		}
		else if (((PhotonView)gameObject.GetComponent(typeof(PhotonView))).isMine)
		{
			ReturnName returnName = (ReturnName)col.gameObject.GetComponent("ReturnName");
			string text = returnName.returnName();
			if (!returnName.returnAI())
			{
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("bladeHitLarge", PhotonTargets.Others, AuthGameObject.username, text);
			}
		}
	}

	[RPC]
	public virtual void bladeHitLarge(string user, string ptokill)
	{
		if (AuthGameObject.username == ptokill)
		{
			SpawningScript.playertrans.SendMessage("bladeHitLarge", user + "|1");
		}
	}
}
