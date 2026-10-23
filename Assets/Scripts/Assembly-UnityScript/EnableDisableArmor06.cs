using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Photon;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class EnableDisableArmor06 : Photon.MonoBehaviour
{
	[Serializable]
	internal sealed class _0024setRenderer_00243682 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal int _0024i_00243683;

			internal bool _0024t_00243684;

			internal int _0024vt_00243685;

			internal EnableDisableArmor06 _0024self__00243686;

			public _0024(bool t, int vt, EnableDisableArmor06 self_)
			{
				_0024t_00243684 = t;
				_0024vt_00243685 = vt;
				_0024self__00243686 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00243686.armor = _0024t_00243684;
					if (_0024t_00243684)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					for (_0024i_00243683 = 0; _0024i_00243683 < UnityScript.Lang.Extensions.get_length((System.Array)_0024self__00243686.armorArr); _0024i_00243683++)
					{
						_0024self__00243686.armorArr[_0024i_00243683].enabled = false;
						_0024self__00243686.armorArr[_0024i_00243683].gameObject.layer = 16;
					}
					goto IL_0193;
				case 2:
					result = (YieldDefault(3) ? 1 : 0);
					break;
				case 3:
					for (_0024i_00243683 = 0; _0024i_00243683 < UnityScript.Lang.Extensions.get_length((System.Array)_0024self__00243686.armorArr); _0024i_00243683++)
					{
						if (_0024vt_00243685 == _0024i_00243683)
						{
							_0024self__00243686.armorArr[_0024i_00243683].enabled = true;
							_0024self__00243686.armorArr[_0024i_00243683].gameObject.active = true;
							_0024self__00243686.armorArr[_0024i_00243683].gameObject.layer = 10;
						}
						else
						{
							_0024self__00243686.armorArr[_0024i_00243683].enabled = false;
							_0024self__00243686.armorArr[_0024i_00243683].gameObject.layer = 16;
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

		internal bool _0024t_00243687;

		internal int _0024vt_00243688;

		internal EnableDisableArmor06 _0024self__00243689;

		public _0024setRenderer_00243682(bool t, int vt, EnableDisableArmor06 self_)
		{
			_0024t_00243687 = t;
			_0024vt_00243688 = vt;
			_0024self__00243689 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024t_00243687, _0024vt_00243688, _0024self__00243689);
		}
	}

	[Serializable]
	internal sealed class _0024Start_00243690 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal EnableDisableArmor06 _0024self__00243691;

			public _0024(EnableDisableArmor06 self_)
			{
				_0024self__00243691 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__00243691.photonView.isMine && !_0024self__00243691.aimanager.isAI)
					{
						PhotonNetwork.RemoveRPCs(_0024self__00243691.photonView);
						if (!ChatScript.hasghost)
						{
							((PhotonView)_0024self__00243691.gameObject.GetComponent(typeof(PhotonView))).RPC("setRenderer", PhotonTargets.AllBuffered, ChatScript.hasarmor6, ChatScript.vehicleType);
						}
					}
					result = (YieldDefault(2) ? 1 : 0);
					break;
				case 2:
					if (PhotonNetwork.isMasterClient && _0024self__00243691.aimanager.isAI && _0024self__00243691.aimanager.armorLevel == 4)
					{
						((PhotonView)_0024self__00243691.gameObject.GetComponent(typeof(PhotonView))).RPC("setRenderer", PhotonTargets.All, true, 0);
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

		internal EnableDisableArmor06 _0024self__00243692;

		public _0024Start_00243690(EnableDisableArmor06 self_)
		{
			_0024self__00243692 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00243692);
		}
	}

	public ChatScript cscript;

	public PlayerCar_Script pcar;

	public CloakPickup cpickup;

	public EndofRound endofround;

	public HealthBar hbar;

	public CalculateHealth chealth;

	public GameObject mainboxcol;

	private float timer;

	private float lasthealth;

	private float regentimer;

	public Renderer gtrbasic;

	private bool ishealth;

	public AIManager aimanager;

	private bool armor;

	private bool gtrcar;

	public Renderer[] armorArr;

	public EnableDisableArmor06()
	{
		timer = 5f;
		lasthealth = 100f;
		regentimer = 1f;
	}

	[RPC]
	public virtual IEnumerator setRenderer(bool t, int vt)
	{
		return new _0024setRenderer_00243682(t, vt, this).GetEnumerator();
	}

	public virtual IEnumerator Start()
	{
		return new _0024Start_00243690(this).GetEnumerator();
	}

	public virtual void Update()
	{
		if (photonView.isMine && ChatScript.hasarmor6 && !aimanager.isAI && ChatScript.isCar && EndofRound.alphastat == 0f && !HealthBar.isdead && !CalculateHealth.isafking)
		{
			if (!(timer <= 0f))
			{
				if (Mathf.Round(lasthealth) == Mathf.Round(CalculateHealth.healthstat))
				{
					timer -= Time.deltaTime;
				}
				else
				{
					lasthealth = CalculateHealth.healthstat;
					timer = 5f;
				}
			}
			else if (Mathf.Round(lasthealth) == Mathf.Round(CalculateHealth.healthstat))
			{
				if (!(regentimer <= 0f))
				{
					regentimer -= Time.deltaTime;
				}
				else
				{
					regentimer = 1f;
					lasthealth += 1f;
					mainboxcol.SendMessage("RegenHealth", 1);
				}
			}
			else
			{
				timer = 5f;
				lasthealth = CalculateHealth.healthstat;
			}
		}
		if (!PhotonNetwork.isMasterClient || !aimanager.isAI || aimanager.armorLevel != 4 || EndofRound.alphastat != 0f || aimanager.isDead)
		{
			return;
		}
		if (!(timer <= 0f))
		{
			if (Mathf.Round(lasthealth) == Mathf.Round(aimanager.aihealth))
			{
				timer -= Time.deltaTime;
				return;
			}
			lasthealth = aimanager.aihealth;
			timer = 5f;
		}
		else if (Mathf.Round(lasthealth) == Mathf.Round(aimanager.aihealth))
		{
			if (!(regentimer <= 0f))
			{
				regentimer -= Time.deltaTime;
				return;
			}
			regentimer = 1f;
			lasthealth += 1f;
			mainboxcol.SendMessage("RegenHealth", 1);
		}
		else
		{
			timer = 5f;
			lasthealth = aimanager.aihealth;
		}
	}
}
