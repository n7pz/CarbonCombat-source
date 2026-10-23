using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Photon;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class GetNetworkedName : Photon.MonoBehaviour
{
	[Serializable]
	internal sealed class _0024Start_00244606 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal GetNetworkedName _0024self__00244607;

			public _0024(GetNetworkedName self_)
			{
				_0024self__00244607 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__00244607.photonView.isMine)
					{
						_0024self__00244607.returnname(AuthGameObject.username);
						((PhotonView)_0024self__00244607.gameObject.GetComponent(typeof(PhotonView))).RPC("returnname", PhotonTargets.All, AuthGameObject.username);
						goto IL_0159;
					}
					result = (YieldDefault(2) ? 1 : 0);
					break;
				case 2:
					result = (YieldDefault(3) ? 1 : 0);
					break;
				case 3:
				case 4:
					if (_0024self__00244607.gameObject.name == "PlayerName" || _0024self__00244607.gameObject.name == "PlayerName (Idle)")
					{
						UnityRuntimeServices.Invoke((PhotonView)_0024self__00244607.gameObject.GetComponent(typeof(PhotonView)), "RPC", new object[2]
						{
							"secgetname",
							(!PhotonNetwork.isMasterClient) ? ((object)PhotonTargets.MasterClient) : _0024self__00244607.photonView.owner
						}, typeof(UnityEngine.MonoBehaviour));
						result = (Yield(4, new WaitForSeconds(3f)) ? 1 : 0);
						break;
					}
					goto IL_0159;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0159:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal GetNetworkedName _0024self__00244608;

		public _0024Start_00244606(GetNetworkedName self_)
		{
			_0024self__00244608 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00244608);
		}
	}

	public AuthGameObject authobj;

	public HeadlesssDedServer headless;

	public MasterServerScript mserver;

	public virtual IEnumerator Start()
	{
		return new _0024Start_00244606(this).GetEnumerator();
	}

	[RPC]
	public virtual void returnname(string u)
	{
		gameObject.name = u;
	}

	[RPC]
	public virtual void secgetname(PhotonMessageInfo info)
	{
		((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("returnname", info.sender, gameObject.name);
	}
}
