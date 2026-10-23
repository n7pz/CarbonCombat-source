using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Photon;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class EnableDisableArmor02 : Photon.MonoBehaviour
{
	[Serializable]
	internal sealed class _0024setRenderer_00243641 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal int _0024i_00243642;

			internal bool _0024t_00243643;

			internal int _0024vt_00243644;

			internal EnableDisableArmor02 _0024self__00243645;

			public _0024(bool t, int vt, EnableDisableArmor02 self_)
			{
				_0024t_00243643 = t;
				_0024vt_00243644 = vt;
				_0024self__00243645 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00243645.armor = _0024t_00243643;
					if (_0024t_00243643)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					for (_0024i_00243642 = 0; _0024i_00243642 < UnityScript.Lang.Extensions.get_length((System.Array)_0024self__00243645.armorArr); _0024i_00243642++)
					{
						_0024self__00243645.armorArr[_0024i_00243642].enabled = false;
						_0024self__00243645.armorArr[_0024i_00243642].gameObject.layer = 16;
					}
					goto IL_0193;
				case 2:
					result = (YieldDefault(3) ? 1 : 0);
					break;
				case 3:
					for (_0024i_00243642 = 0; _0024i_00243642 < UnityScript.Lang.Extensions.get_length((System.Array)_0024self__00243645.armorArr); _0024i_00243642++)
					{
						if (_0024vt_00243644 == _0024i_00243642)
						{
							_0024self__00243645.armorArr[_0024i_00243642].enabled = true;
							_0024self__00243645.armorArr[_0024i_00243642].gameObject.active = true;
							_0024self__00243645.armorArr[_0024i_00243642].gameObject.layer = 10;
						}
						else
						{
							_0024self__00243645.armorArr[_0024i_00243642].enabled = false;
							_0024self__00243645.armorArr[_0024i_00243642].gameObject.layer = 16;
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

		internal bool _0024t_00243646;

		internal int _0024vt_00243647;

		internal EnableDisableArmor02 _0024self__00243648;

		public _0024setRenderer_00243641(bool t, int vt, EnableDisableArmor02 self_)
		{
			_0024t_00243646 = t;
			_0024vt_00243647 = vt;
			_0024self__00243648 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024t_00243646, _0024vt_00243647, _0024self__00243648);
		}
	}

	[Serializable]
	internal sealed class _0024Start_00243649 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal EnableDisableArmor02 _0024self__00243650;

			public _0024(EnableDisableArmor02 self_)
			{
				_0024self__00243650 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__00243650.photonView.isMine && !_0024self__00243650.aimanager.isAI)
					{
						PhotonNetwork.RemoveRPCs(_0024self__00243650.photonView);
						if (!ChatScript.hasghost)
						{
							((PhotonView)_0024self__00243650.gameObject.GetComponent(typeof(PhotonView))).RPC("setRenderer", PhotonTargets.AllBuffered, ChatScript.hasarmor2, ChatScript.vehicleType);
						}
					}
					result = (YieldDefault(2) ? 1 : 0);
					break;
				case 2:
					if (PhotonNetwork.isMasterClient && _0024self__00243650.aimanager.isAI && _0024self__00243650.aimanager.armorLevel == 1)
					{
						((PhotonView)_0024self__00243650.gameObject.GetComponent(typeof(PhotonView))).RPC("setRenderer", PhotonTargets.AllBuffered, true, 0);
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

		internal EnableDisableArmor02 _0024self__00243651;

		public _0024Start_00243649(EnableDisableArmor02 self_)
		{
			_0024self__00243651 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00243651);
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
		return new _0024setRenderer_00243641(t, vt, this).GetEnumerator();
	}

	public virtual IEnumerator Start()
	{
		return new _0024Start_00243649(this).GetEnumerator();
	}
}
