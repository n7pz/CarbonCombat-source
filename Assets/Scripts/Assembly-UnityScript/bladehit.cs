using System;
using Photon;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class bladehit : Photon.MonoBehaviour
{
	public AuthGameObject authobj;

	public SpawningScript spwnsrc;

	public MasterServerScript mserver;

	public virtual void OnTriggerStay(Collider col)
	{
		if (!(col.gameObject.name == "MainBoxCol") && !(col.gameObject.name == "CarPrefab(Clone)"))
		{
			return;
		}
		ReturnName returnName = (ReturnName)col.gameObject.GetComponent("ReturnName");
		if (((PhotonView)col.transform.root.gameObject.GetComponent(typeof(PhotonView))).isMine)
		{
			if (!returnName.returnAI())
			{
				if (!((PhotonView)gameObject.GetComponent(typeof(PhotonView))).isMine)
				{
					col.gameObject.SendMessage("bladeHit", AuthGameObject.username + "|1");
				}
			}
			else if (((PhotonView)gameObject.GetComponent(typeof(PhotonView))).isMine)
			{
				col.gameObject.SendMessage("bladeHit", AuthGameObject.username + "|1");
			}
		}
		else if (((PhotonView)gameObject.GetComponent(typeof(PhotonView))).isMine)
		{
			Component component = col.gameObject.GetComponent("ReturnName");
			object obj = UnityRuntimeServices.Invoke(component, "returnName", new object[0], typeof(UnityEngine.MonoBehaviour));
			((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("bladeHit", PhotonTargets.Others, AuthGameObject.username, obj);
		}
	}

	[RPC]
	public virtual void bladeHit(string user, string ptokill)
	{
		if (user == MasterServerScript.ainame && PhotonNetwork.isMasterClient && MasterServerScript.ainame != string.Empty)
		{
			SpawningScript.aiplayerobjs[0].SendMessage("bladeHit", user + "|1");
		}
		if (user == MasterServerScript.ainame2 && PhotonNetwork.isMasterClient && MasterServerScript.ainame2 != string.Empty)
		{
			SpawningScript.aiplayerobjs[1].SendMessage("bladeHit", user + "|1");
		}
		if (user == MasterServerScript.ainame3 && PhotonNetwork.isMasterClient && MasterServerScript.ainame3 != string.Empty)
		{
			SpawningScript.aiplayerobjs[2].SendMessage("bladeHit", user + "|1");
		}
		if (AuthGameObject.username == ptokill)
		{
			SpawningScript.playertrans.SendMessage("bladeHit", user + "|1");
		}
	}
}
