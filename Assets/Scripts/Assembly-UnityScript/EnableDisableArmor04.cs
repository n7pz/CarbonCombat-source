using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Photon;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class EnableDisableArmor04 : Photon.MonoBehaviour
{
	[Serializable]
	internal sealed class _0024setRenderer_00243663 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal int _0024i_00243664;

			internal bool _0024t_00243665;

			internal int _0024vt_00243666;

			internal EnableDisableArmor04 _0024self__00243667;

			public _0024(bool t, int vt, EnableDisableArmor04 self_)
			{
				_0024t_00243665 = t;
				_0024vt_00243666 = vt;
				_0024self__00243667 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00243667.armor = _0024t_00243665;
					if (_0024t_00243665)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					for (_0024i_00243664 = 0; _0024i_00243664 < UnityScript.Lang.Extensions.get_length((System.Array)_0024self__00243667.armorArr); _0024i_00243664++)
					{
						_0024self__00243667.armorArr[_0024i_00243664].enabled = false;
						_0024self__00243667.armorArr[_0024i_00243664].gameObject.layer = 16;
					}
					goto IL_0193;
				case 2:
					result = (YieldDefault(3) ? 1 : 0);
					break;
				case 3:
					for (_0024i_00243664 = 0; _0024i_00243664 < UnityScript.Lang.Extensions.get_length((System.Array)_0024self__00243667.armorArr); _0024i_00243664++)
					{
						if (_0024vt_00243666 == _0024i_00243664)
						{
							_0024self__00243667.armorArr[_0024i_00243664].enabled = true;
							_0024self__00243667.armorArr[_0024i_00243664].gameObject.active = true;
							_0024self__00243667.armorArr[_0024i_00243664].gameObject.layer = 10;
						}
						else
						{
							_0024self__00243667.armorArr[_0024i_00243664].enabled = false;
							_0024self__00243667.armorArr[_0024i_00243664].gameObject.layer = 16;
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

		internal bool _0024t_00243668;

		internal int _0024vt_00243669;

		internal EnableDisableArmor04 _0024self__00243670;

		public _0024setRenderer_00243663(bool t, int vt, EnableDisableArmor04 self_)
		{
			_0024t_00243668 = t;
			_0024vt_00243669 = vt;
			_0024self__00243670 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024t_00243668, _0024vt_00243669, _0024self__00243670);
		}
	}

	[Serializable]
	internal sealed class _0024Start_00243671 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal EnableDisableArmor04 _0024self__00243672;

			public _0024(EnableDisableArmor04 self_)
			{
				_0024self__00243672 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__00243672.photonView.isMine && !_0024self__00243672.aimanager.isAI)
					{
						PhotonNetwork.RemoveRPCs(_0024self__00243672.photonView);
						if (!ChatScript.hasghost)
						{
							((PhotonView)_0024self__00243672.gameObject.GetComponent(typeof(PhotonView))).RPC("setRenderer", PhotonTargets.AllBuffered, ChatScript.hasarmor4, ChatScript.vehicleType);
						}
					}
					result = (YieldDefault(2) ? 1 : 0);
					break;
				case 2:
					if (PhotonNetwork.isMasterClient && _0024self__00243672.aimanager.isAI && _0024self__00243672.aimanager.armorLevel == 3)
					{
						((PhotonView)_0024self__00243672.gameObject.GetComponent(typeof(PhotonView))).RPC("setRenderer", PhotonTargets.AllBuffered, true, 0);
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

		internal EnableDisableArmor04 _0024self__00243673;

		public _0024Start_00243671(EnableDisableArmor04 self_)
		{
			_0024self__00243673 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00243673);
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
		return new _0024setRenderer_00243663(t, vt, this).GetEnumerator();
	}

	public virtual IEnumerator Start()
	{
		return new _0024Start_00243671(this).GetEnumerator();
	}
}
