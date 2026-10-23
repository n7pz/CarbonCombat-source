using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Photon;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class EnableDisableArmor05 : Photon.MonoBehaviour
{
	[Serializable]
	internal sealed class _0024setRenderer_00243674 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal int _0024i_00243675;

			internal bool _0024t_00243676;

			internal int _0024vt_00243677;

			internal EnableDisableArmor05 _0024self__00243678;

			public _0024(bool t, int vt, EnableDisableArmor05 self_)
			{
				_0024t_00243676 = t;
				_0024vt_00243677 = vt;
				_0024self__00243678 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00243678.armor = _0024t_00243676;
					if (_0024t_00243676)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					for (_0024i_00243675 = 0; _0024i_00243675 < UnityScript.Lang.Extensions.get_length((System.Array)_0024self__00243678.armorArr); _0024i_00243675++)
					{
						_0024self__00243678.armorArr[_0024i_00243675].enabled = false;
						_0024self__00243678.armorArr[_0024i_00243675].gameObject.layer = 16;
					}
					goto IL_0193;
				case 2:
					result = (YieldDefault(3) ? 1 : 0);
					break;
				case 3:
					for (_0024i_00243675 = 0; _0024i_00243675 < UnityScript.Lang.Extensions.get_length((System.Array)_0024self__00243678.armorArr); _0024i_00243675++)
					{
						if (_0024vt_00243677 == _0024i_00243675)
						{
							_0024self__00243678.armorArr[_0024i_00243675].enabled = true;
							_0024self__00243678.armorArr[_0024i_00243675].gameObject.active = true;
							_0024self__00243678.armorArr[_0024i_00243675].gameObject.layer = 10;
						}
						else
						{
							_0024self__00243678.armorArr[_0024i_00243675].enabled = false;
							_0024self__00243678.armorArr[_0024i_00243675].gameObject.layer = 16;
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

		internal bool _0024t_00243679;

		internal int _0024vt_00243680;

		internal EnableDisableArmor05 _0024self__00243681;

		public _0024setRenderer_00243674(bool t, int vt, EnableDisableArmor05 self_)
		{
			_0024t_00243679 = t;
			_0024vt_00243680 = vt;
			_0024self__00243681 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024t_00243679, _0024vt_00243680, _0024self__00243681);
		}
	}

	public ChatScript cscript;

	public PlayerCar_Script pcar;

	public CloakPickup cpickup;

	public EndofRound endofround;

	public HealthBar hbar;

	public GameObject mainboxcol;

	private float timer;

	private bool curcloakstate;

	public Renderer gtrbasic;

	private bool isgtrcarenabled;

	public AIManager aimanager;

	private bool armor;

	private bool gtrcar;

	public Renderer[] armorArr;

	public EnableDisableArmor05()
	{
		timer = 2.5f;
	}

	[RPC]
	public virtual IEnumerator setRenderer(bool t, int vt)
	{
		return new _0024setRenderer_00243674(t, vt, this).GetEnumerator();
	}

	public virtual void Start()
	{
		if (photonView.isMine && !aimanager.isAI)
		{
			PhotonNetwork.RemoveRPCs(photonView);
			if (!ChatScript.hasghost)
			{
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("setRenderer", PhotonTargets.AllBuffered, ChatScript.hasarmor5, ChatScript.vehicleType);
			}
		}
	}

	[RPC]
	public virtual void cloak(bool i)
	{
		curcloakstate = i;
		if (i)
		{
			mainboxcol.SendMessage("Cloak", 1246);
		}
		else
		{
			mainboxcol.SendMessage("cloakkill");
		}
	}

	public virtual void Update()
	{
		if (!photonView.isMine || !ChatScript.hasarmor5 || aimanager.isAI)
		{
			return;
		}
		if (!CloakPickup.iscloakedstat && curcloakstate)
		{
			curcloakstate = false;
		}
		if (!((float)PlayerCar_Script.mph >= 20f) && !CloakPickup.iscloakedstat && EndofRound.alphastat == 0f && !HealthBar.isdead)
		{
			if (!(timer <= 0f))
			{
				timer -= Time.deltaTime;
				return;
			}
			timer = 2.5f;
			if (!CloakPickup.iscloakedfrompickup && !curcloakstate)
			{
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("cloak", PhotonTargets.All, true);
			}
		}
		else
		{
			timer = 2.5f;
			if (((float)PlayerCar_Script.mph >= 20f || EndofRound.alphastat > 0f || HealthBar.isdead) && !CloakPickup.iscloakedfrompickup && curcloakstate)
			{
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("cloak", PhotonTargets.All, false);
			}
		}
	}
}
