using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Photon;
using UnityEngine;

[Serializable]
public class FlagCapture : Photon.MonoBehaviour
{
	[Serializable]
	internal sealed class _0024hideflag_00244603 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal FlagCapture _0024self__00244604;

			public _0024(FlagCapture self_)
			{
				_0024self__00244604 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00244604.flagobj.SetActiveRecursively(false);
					_0024self__00244604.emitterobj.emit = true;
					result = (Yield(2, new WaitForSeconds(2f)) ? 1 : 0);
					break;
				case 2:
					_0024self__00244604.emitterobj.emit = false;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal FlagCapture _0024self__00244605;

		public _0024hideflag_00244603(FlagCapture self_)
		{
			_0024self__00244605 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00244605);
		}
	}

	public GameObject flagobj;

	public ParticleEmitter emitterobj;

	public string team;

	public FlagCapture()
	{
		team = string.Empty;
	}

	public virtual void OnTriggerEnter(Collider objenter)
	{
		if (objenter.gameObject.name == "MainBoxCol")
		{
			objenter.gameObject.SendMessage("FlagEnabled", gameObject);
		}
	}

	public virtual void yeshide(string t)
	{
		if (t == team)
		{
			((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("hideflag", PhotonTargets.AllBuffered);
		}
	}

	[RPC]
	public virtual IEnumerator hideflag()
	{
		return new _0024hideflag_00244603(this).GetEnumerator();
	}
}
