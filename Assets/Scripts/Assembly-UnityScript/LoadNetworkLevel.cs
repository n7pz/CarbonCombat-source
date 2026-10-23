using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Photon;
using UnityEngine;

[Serializable]
[RequireComponent(typeof(PhotonView))]
public class LoadNetworkLevel : Photon.MonoBehaviour
{
	[Serializable]
	internal sealed class _0024LoadLevel_00244757 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal LoadNetworkLevel _0024self__00244758;

			public _0024(LoadNetworkLevel self_)
			{
				_0024self__00244758 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					PhotonNetwork.isMessageQueueRunning = false;
					UnityEngine.Object.DontDestroyOnLoad(_0024self__00244758);
					_0024self__00244758.photonView.group = 1;
					PhotonNetwork.isMessageQueueRunning = false;
					PhotonNetwork.SetSendingEnabled(0, true);
					PhotonNetwork.SetSendingEnabled(8, true);
					PhotonNetwork.SetSendingEnabled(9, true);
					PhotonNetwork.SetSendingEnabled(10, true);
					Debug.Log("Loading a level");
					if (CWFLoader.worldData == string.Empty)
					{
						if (MasterServerScript.curworld == 0)
						{
							PhotonNetwork.SetLevelPrefix(3);
							Application.LoadLevel("MainScene");
						}
						if (MasterServerScript.curworld == 1)
						{
							PhotonNetwork.SetLevelPrefix(4);
							Application.LoadLevel("NuclearSilo");
						}
						if (MasterServerScript.curworld == 2)
						{
							PhotonNetwork.SetLevelPrefix(5);
							Application.LoadLevel("NewIsland");
						}
						if (MasterServerScript.curworld == 3)
						{
							PhotonNetwork.SetLevelPrefix(6);
							Application.LoadLevel("ChokePoint");
						}
						if (MasterServerScript.curworld == 4)
						{
							PhotonNetwork.SetLevelPrefix(7);
							Application.LoadLevel("Sanctum");
						}
						if (MasterServerScript.curworld == 5)
						{
							InitWorld.finaldone = false;
							PhotonNetwork.SetLevelPrefix(8);
							Application.LoadLevel("CCWhirldScene");
						}
					}
					else
					{
						PhotonNetwork.SetLevelPrefix(9);
						Application.LoadLevel("Forge_Scene");
					}
					goto case 2;
				case 2:
					if (Application.isLoadingLevel)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					if (AuthGameObject.whirldurl != string.Empty)
					{
						goto case 3;
					}
					goto IL_0186;
				case 3:
					if (!InitWorld.finaldone)
					{
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					goto IL_0186;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0186:
					PhotonNetwork.isMessageQueueRunning = true;
					PhotonNetwork.SetSendingEnabled(0, true);
					PhotonNetwork.SetSendingEnabled(8, true);
					PhotonNetwork.SetSendingEnabled(9, true);
					PhotonNetwork.SetSendingEnabled(10, true);
					Debug.Log("Level Loaded!");
					if (!PhotonNetwork.isMasterClient)
					{
					}
					_0024self__00244758.destroyNextLoad = true;
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal LoadNetworkLevel _0024self__00244759;

		public _0024LoadLevel_00244757(LoadNetworkLevel self_)
		{
			_0024self__00244759 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00244759);
		}
	}

	public MasterServerScript mscript;

	public AuthGameObject authobj;

	public InitWorld iw;

	public CWFLoader cwf;

	private bool destroyNextLoad;

	public virtual IEnumerator LoadLevel()
	{
		return new _0024LoadLevel_00244757(this).GetEnumerator();
	}

	public virtual void Update()
	{
		if (Application.loadedLevelName == "Menu" && destroyNextLoad)
		{
			UnityEngine.Object.Destroy(gameObject);
		}
	}

	[RPC]
	public virtual void PlayerConnectedDel(PhotonMessageInfo info)
	{
		int i = 0;
		GameObject[] array = (GameObject[])UnityEngine.Object.FindObjectsOfType(typeof(GameObject));
		for (int length = array.Length; i < length; i++)
		{
			array[i].SendMessage("OnPhotonPlayerConnected", info.sender, SendMessageOptions.DontRequireReceiver);
		}
	}

	public virtual void Main()
	{
	}
}
