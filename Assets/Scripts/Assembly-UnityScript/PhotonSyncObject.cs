using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Photon;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class PhotonSyncObject : Photon.MonoBehaviour
{
	[Serializable]
	internal sealed class _0024returnName_00245051 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal GameObject _0024obj_00245052;

			internal ReturnName _0024returnname_00245053;

			internal string _0024user_00245054;

			internal int _0024_00241308_00245055;

			internal GameObject[] _0024_00241309_00245056;

			internal int _0024_00241310_00245057;

			internal string _0024u_00245058;

			internal PhotonSyncObject _0024self__00245059;

			public _0024(string u, PhotonSyncObject self_)
			{
				_0024u_00245058 = u;
				_0024self__00245059 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					result = (YieldDefault(2) ? 1 : 0);
					break;
				case 2:
					result = (YieldDefault(3) ? 1 : 0);
					break;
				case 3:
					_0024_00241308_00245055 = 0;
					_0024_00241309_00245056 = (GameObject[])UnityEngine.Object.FindObjectsOfType(typeof(GameObject));
					for (_0024_00241310_00245057 = _0024_00241309_00245056.Length; _0024_00241308_00245055 < _0024_00241310_00245057; _0024_00241308_00245055++)
					{
						if (_0024_00241309_00245056[_0024_00241308_00245055].name == "CarPrefab(Clone)")
						{
							_0024returnname_00245053 = (ReturnName)_0024_00241309_00245056[_0024_00241308_00245055].GetComponent("ReturnName");
							_0024user_00245054 = _0024returnname_00245053.returnName();
							if (_0024user_00245054 == _0024u_00245058)
							{
								_0024self__00245059.theObject = _0024_00241309_00245056[_0024_00241308_00245055];
							}
						}
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

		internal string _0024u_00245060;

		internal PhotonSyncObject _0024self__00245061;

		public _0024returnName_00245051(string u, PhotonSyncObject self_)
		{
			_0024u_00245060 = u;
			_0024self__00245061 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024u_00245060, _0024self__00245061);
		}
	}

	public AuthGameObject authobj;

	public GameObject theObject;

	public virtual void Start()
	{
		PhotonView photonView = (PhotonView)gameObject.GetComponent(typeof(PhotonView));
		if (!photonView.isMine)
		{
			((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("grabName", photonView.owner);
		}
	}

	[RPC]
	public virtual void grabName(PhotonMessageInfo info)
	{
		PhotonView photonView = (PhotonView)gameObject.GetComponent(typeof(PhotonView));
		((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("returnName", info.sender, AuthGameObject.username);
	}

	[RPC]
	public virtual IEnumerator returnName(string u)
	{
		return new _0024returnName_00245051(u, this).GetEnumerator();
	}

	[RPC]
	public virtual void updateStates(Vector3 pos, Quaternion rot, PhotonMessageInfo info)
	{
		UnityRuntimeServices.Invoke(theObject.GetComponent("PlayerRemote"), "updateStates", new object[3] { pos, rot, info.timestamp }, typeof(UnityEngine.MonoBehaviour));
	}

	public virtual void Main()
	{
	}
}
