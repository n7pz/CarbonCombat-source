using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Photon;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class EnableDisableArmor03 : Photon.MonoBehaviour
{
	[Serializable]
	internal sealed class _0024setRenderer_00243652 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal int _0024i_00243653;

			internal bool _0024t_00243654;

			internal int _0024vt_00243655;

			internal EnableDisableArmor03 _0024self__00243656;

			public _0024(bool t, int vt, EnableDisableArmor03 self_)
			{
				_0024t_00243654 = t;
				_0024vt_00243655 = vt;
				_0024self__00243656 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00243656.armor = _0024t_00243654;
					if (_0024t_00243654)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					for (_0024i_00243653 = 0; _0024i_00243653 < UnityScript.Lang.Extensions.get_length((System.Array)_0024self__00243656.armorArr); _0024i_00243653++)
					{
						_0024self__00243656.armorArr[_0024i_00243653].enabled = false;
						_0024self__00243656.armorArr[_0024i_00243653].gameObject.layer = 16;
					}
					goto IL_0193;
				case 2:
					result = (YieldDefault(3) ? 1 : 0);
					break;
				case 3:
					for (_0024i_00243653 = 0; _0024i_00243653 < UnityScript.Lang.Extensions.get_length((System.Array)_0024self__00243656.armorArr); _0024i_00243653++)
					{
						if (_0024vt_00243655 == _0024i_00243653)
						{
							_0024self__00243656.armorArr[_0024i_00243653].enabled = true;
							_0024self__00243656.armorArr[_0024i_00243653].gameObject.active = true;
							_0024self__00243656.armorArr[_0024i_00243653].gameObject.layer = 10;
						}
						else
						{
							_0024self__00243656.armorArr[_0024i_00243653].enabled = false;
							_0024self__00243656.armorArr[_0024i_00243653].gameObject.layer = 16;
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

		internal bool _0024t_00243657;

		internal int _0024vt_00243658;

		internal EnableDisableArmor03 _0024self__00243659;

		public _0024setRenderer_00243652(bool t, int vt, EnableDisableArmor03 self_)
		{
			_0024t_00243657 = t;
			_0024vt_00243658 = vt;
			_0024self__00243659 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024t_00243657, _0024vt_00243658, _0024self__00243659);
		}
	}

	[Serializable]
	internal sealed class _0024Start_00243660 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal EnableDisableArmor03 _0024self__00243661;

			public _0024(EnableDisableArmor03 self_)
			{
				_0024self__00243661 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__00243661.photonView.isMine && !_0024self__00243661.aimanager.isAI)
					{
						PhotonNetwork.RemoveRPCs(_0024self__00243661.photonView);
						if (!ChatScript.hasghost)
						{
							((PhotonView)_0024self__00243661.gameObject.GetComponent(typeof(PhotonView))).RPC("setRenderer", PhotonTargets.AllBuffered, ChatScript.hasarmor3, ChatScript.vehicleType);
						}
					}
					result = (YieldDefault(2) ? 1 : 0);
					break;
				case 2:
					if (PhotonNetwork.isMasterClient && _0024self__00243661.aimanager.isAI && _0024self__00243661.aimanager.armorLevel == 2)
					{
						((PhotonView)_0024self__00243661.gameObject.GetComponent(typeof(PhotonView))).RPC("setRenderer", PhotonTargets.AllBuffered, true, 0);
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

		internal EnableDisableArmor03 _0024self__00243662;

		public _0024Start_00243660(EnableDisableArmor03 self_)
		{
			_0024self__00243662 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00243662);
		}
	}

	public ChatScript cscript;

	public Renderer gtrbasic;

	public AIManager aimanager;

	private bool armor;

	private bool gtrcar;

	public Renderer[] armorArr;

	[RPC]
	public virtual IEnumerator setRenderer(bool t, int vt)
	{
		return new _0024setRenderer_00243652(t, vt, this).GetEnumerator();
	}

	public virtual IEnumerator Start()
	{
		return new _0024Start_00243660(this).GetEnumerator();
	}
}
