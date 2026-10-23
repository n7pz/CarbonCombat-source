using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Photon;
using UnityEngine;

[Serializable]
public class CloakItem : Photon.MonoBehaviour
{
	[Serializable]
	internal sealed class _0024enabledelegate_00244177 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal float _0024t_00244178;

			internal CloakItem _0024self__00244179;

			public _0024(float t, CloakItem self_)
			{
				_0024t_00244178 = t;
				_0024self__00244179 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (!(PhotonNetwork.time >= (double)_0024t_00244178) && !HealthBar.showendofround)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024self__00244179.renderer.enabled = true;
					_0024self__00244179.disabled = false;
					_0024self__00244179.glow.emit = true;
					if (PhotonNetwork.isMasterClient)
					{
						PhotonNetwork.RemoveRPCs(_0024self__00244179.photonView);
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

		internal float _0024t_00244180;

		internal CloakItem _0024self__00244181;

		public _0024enabledelegate_00244177(float t, CloakItem self_)
		{
			_0024t_00244180 = t;
			_0024self__00244181 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024t_00244180, _0024self__00244181);
		}
	}

	public ParticleEmitter glow;

	private bool disabled;

	private ChatScript cscript;

	private HealthBar hbar;

	public virtual void OnTriggerEnter(Collider objenter)
	{
		if (!disabled)
		{
			if (objenter.gameObject.name == "MainBoxCol")
			{
				ReturnName returnName = (ReturnName)objenter.gameObject.GetComponent("ReturnName");
				if (((PhotonView)objenter.gameObject.GetComponent(typeof(PhotonView))).isMine && !returnName.returnAI() && ChatScript.isCar)
				{
					((PhotonView)objenter.gameObject.GetComponent(typeof(PhotonView))).RPC("Cloak", PhotonTargets.All, 1245);
					((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("destroy", PhotonTargets.AllBuffered);
				}
			}
			if (objenter.gameObject.name == "HumanPrefab(Clone)" && ((PhotonView)objenter.transform.gameObject.GetComponent(typeof(PhotonView))).isMine && !ChatScript.isCar)
			{
				GameObject.Find("/GUI/SubMessage").SendMessage("setMessage", "You cannot pick up items when outside the car!");
			}
		}
		else
		{
			if (renderer.enabled)
			{
				renderer.enabled = false;
			}
			if (glow.emit)
			{
				glow.emit = false;
			}
		}
	}

	public virtual IEnumerator enabledelegate(float t)
	{
		return new _0024enabledelegate_00244177(t, this).GetEnumerator();
	}

	[RPC]
	public virtual void destroy(PhotonMessageInfo info)
	{
		renderer.enabled = false;
		glow.emit = false;
		disabled = true;
		StartCoroutine_Auto(enabledelegate((float)(info.timestamp + 150.0)));
	}
}
