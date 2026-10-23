using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Photon;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class EnableDisableArmor08 : Photon.MonoBehaviour
{
	[Serializable]
	internal sealed class _0024setRenderer_00243701 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal int _0024i_00243702;

			internal bool _0024t_00243703;

			internal int _0024vt_00243704;

			internal EnableDisableArmor08 _0024self__00243705;

			public _0024(bool t, int vt, EnableDisableArmor08 self_)
			{
				_0024t_00243703 = t;
				_0024vt_00243704 = vt;
				_0024self__00243705 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00243705.armor = _0024t_00243703;
					if (_0024t_00243703)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					for (_0024i_00243702 = 0; _0024i_00243702 < UnityScript.Lang.Extensions.get_length((System.Array)_0024self__00243705.armorArr); _0024i_00243702++)
					{
						_0024self__00243705.armorArr[_0024i_00243702].enabled = false;
						_0024self__00243705.armorArr[_0024i_00243702].gameObject.layer = 16;
					}
					goto IL_0193;
				case 2:
					result = (YieldDefault(3) ? 1 : 0);
					break;
				case 3:
					for (_0024i_00243702 = 0; _0024i_00243702 < UnityScript.Lang.Extensions.get_length((System.Array)_0024self__00243705.armorArr); _0024i_00243702++)
					{
						if (_0024vt_00243704 == _0024i_00243702)
						{
							_0024self__00243705.armorArr[_0024i_00243702].enabled = true;
							_0024self__00243705.armorArr[_0024i_00243702].gameObject.active = true;
							_0024self__00243705.armorArr[_0024i_00243702].gameObject.layer = 10;
						}
						else
						{
							_0024self__00243705.armorArr[_0024i_00243702].enabled = false;
							_0024self__00243705.armorArr[_0024i_00243702].gameObject.layer = 16;
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

		internal bool _0024t_00243706;

		internal int _0024vt_00243707;

		internal EnableDisableArmor08 _0024self__00243708;

		public _0024setRenderer_00243701(bool t, int vt, EnableDisableArmor08 self_)
		{
			_0024t_00243706 = t;
			_0024vt_00243707 = vt;
			_0024self__00243708 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024t_00243706, _0024vt_00243707, _0024self__00243708);
		}
	}

	public ChatScript cscript;

	public AIManager aimanager;

	private bool armor;

	public Renderer[] armorArr;

	[RPC]
	public virtual IEnumerator setRenderer(bool t, int vt)
	{
		return new _0024setRenderer_00243701(t, vt, this).GetEnumerator();
	}

	public virtual void Start()
	{
		if (photonView.isMine && !aimanager.isAI)
		{
			PhotonNetwork.RemoveRPCs(photonView);
			if (!ChatScript.hasghost)
			{
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("setRenderer", PhotonTargets.AllBuffered, ChatScript.hasarmor8, ChatScript.vehicleType);
			}
		}
	}
}
