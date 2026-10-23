using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Photon;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class NetworkMode : Photon.MonoBehaviour
{
	[Serializable]
	internal sealed class _0024coRoutine_00245028 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal GameObject _0024go_00245029;

			internal int _0024_00241288_00245030;

			internal GameObject[] _0024_00241289_00245031;

			internal int _0024_00241290_00245032;

			internal NetworkMode _0024self__00245033;

			public _0024(NetworkMode self_)
			{
				_0024self__00245033 = self_;
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
					result = (YieldDefault(4) ? 1 : 0);
					break;
				case 4:
					result = (YieldDefault(5) ? 1 : 0);
					break;
				case 5:
					isenabled = true;
					if (PhotonNetwork.isMasterClient && !_0024self__00245033.photonView.isMine)
					{
						_0024_00241288_00245030 = 0;
						_0024_00241289_00245031 = (GameObject[])UnityEngine.Object.FindObjectsOfType(typeof(GameObject));
						for (_0024_00241290_00245032 = _0024_00241289_00245031.Length; _0024_00241288_00245030 < _0024_00241290_00245032; _0024_00241288_00245030++)
						{
							if (_0024_00241289_00245031[_0024_00241288_00245030].name == "CarPrefab(Clone)" && ((PhotonView)_0024_00241289_00245031[_0024_00241288_00245030].GetComponent(typeof(PhotonView))).isMine)
							{
								_0024_00241289_00245031[_0024_00241288_00245030].SendMessage("APersonJoined", SendMessageOptions.DontRequireReceiver);
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

		internal NetworkMode _0024self__00245034;

		public _0024coRoutine_00245028(NetworkMode self_)
		{
			_0024self__00245034 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00245034);
		}
	}

	[NonSerialized]
	public static bool isenabled = true;

	public SpawningScript spwnsrc;

	public virtual void Awake()
	{
		isenabled = true;
		StartCoroutine_Auto(coRoutine());
	}

	public virtual IEnumerator coRoutine()
	{
		return new _0024coRoutine_00245028(this).GetEnumerator();
	}

	public virtual void OnPhotonPlayerConnected()
	{
		if (PhotonNetwork.isMasterClient && UnityScript.Lang.Extensions.get_length((System.Array)PhotonNetwork.playerList) + 1 > 10 && photonView.isMine)
		{
			((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("updateCount", PhotonTargets.All, UnityScript.Lang.Extensions.get_length((System.Array)PhotonNetwork.playerList) + 1);
		}
	}

	public virtual void APersonJoined()
	{
		OnPhotonPlayerConnected();
	}

	public virtual void OnPhotonPlayerDisconnected()
	{
		if (PhotonNetwork.isMasterClient && UnityScript.Lang.Extensions.get_length((System.Array)PhotonNetwork.playerList) < 11 && photonView.isMine)
		{
			((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("updateCount", PhotonTargets.All, UnityScript.Lang.Extensions.get_length((System.Array)PhotonNetwork.playerList));
		}
	}

	[RPC]
	public virtual void updateCount(int i)
	{
		if (i > 10)
		{
			isenabled = false;
			photonView.observed = this.gameObject.rigidbody;
			if (SpawningScript.team2 == string.Empty)
			{
				UnityEngine.Object.Destroy(GameObject.Find("Spawn Point").GetComponent("PlayerLocal"));
				UnityEngine.Object.Destroy(GameObject.Find("Spawn Point").GetComponent("Rigidbody"));
			}
			else
			{
				UnityEngine.Object.Destroy(SpawningScript.playertrans.gameObject.GetComponent("PlayerLocal"));
				((PhotonView)SpawningScript.playertrans.GetComponent(typeof(PhotonView))).observed = SpawningScript.playertrans.gameObject.rigidbody;
				if (SpawningScript.playertrans.gameObject.GetComponent("NetworkRigidbody") == null)
				{
					SpawningScript.playertrans.gameObject.AddComponent("NetworkRigidbody");
				}
			}
			int j = 0;
			GameObject[] array = (GameObject[])UnityEngine.Object.FindObjectsOfType(typeof(GameObject));
			for (int length = array.Length; j < length; j++)
			{
				if (array[j].name == "CarPrefab(Clone)" && !((PhotonView)array[j].GetComponent(typeof(PhotonView))).isMine)
				{
					if (array[j].GetComponent("PlayerRemote") != null)
					{
						UnityEngine.Object.Destroy(array[j].GetComponent("PlayerRemote"));
					}
					if (array[j].GetComponent("NetworkRigidbody") == null)
					{
						array[j].AddComponent("NetworkRigidbody");
					}
					((PhotonView)array[j].GetComponent(typeof(PhotonView))).observed = array[j].gameObject.rigidbody;
				}
			}
			return;
		}
		isenabled = true;
		if (SpawningScript.team2 == string.Empty)
		{
			GameObject gameObject = GameObject.Find("Spawn Point");
			GameObject.Find("Spawn Point").AddComponent("PlayerLocal");
			GameObject.Find("Spawn Point").AddComponent("Rigidbody");
			GameObject.Find("Spawn Point").rigidbody.isKinematic = true;
		}
		else
		{
			if (SpawningScript.playertrans.gameObject.GetComponent("NetworkRigidbody") != null)
			{
				UnityEngine.Object.Destroy(SpawningScript.playertrans.gameObject.GetComponent("NetworkRigidbody"));
			}
			if (SpawningScript.playertrans.gameObject.GetComponent("PlayerLocal") == null)
			{
				SpawningScript.playertrans.gameObject.AddComponent("PlayerLocal");
			}
			((PhotonView)SpawningScript.playertrans.GetComponent(typeof(PhotonView))).observed = SpawningScript.playertrans.gameObject.GetComponent("PlayerLocal");
		}
		int k = 0;
		GameObject[] array2 = (GameObject[])UnityEngine.Object.FindObjectsOfType(typeof(GameObject));
		for (int length2 = array2.Length; k < length2; k++)
		{
			if (array2[k].name == "CarPrefab(Clone)" && !((PhotonView)array2[k].GetComponent(typeof(PhotonView))).isMine)
			{
				if (array2[k].GetComponent("PlayerRemote") == null)
				{
					array2[k].AddComponent("PlayerRemote");
				}
				if (array2[k].GetComponent("NetworkRigidbody") != null)
				{
					UnityEngine.Object.Destroy(array2[k].GetComponent("NetworkRigidbody"));
				}
				((PhotonView)array2[k].GetComponent(typeof(PhotonView))).observed = array2[k].GetComponent("PlayerRemote");
			}
		}
	}
}
