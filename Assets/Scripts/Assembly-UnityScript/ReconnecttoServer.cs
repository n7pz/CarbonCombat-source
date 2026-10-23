using System;
using Photon;
using UnityEngine;

[Serializable]
public class ReconnecttoServer : Photon.MonoBehaviour
{
	public float counter;

	public string hname;

	public ReconnecttoServer()
	{
		counter = 2f;
		hname = string.Empty;
	}

	public virtual void starter(string t)
	{
		hname = t;
	}

	public virtual void Awake()
	{
		MasterServer.RequestHostList("CarbonCombat");
	}

	public virtual void Update()
	{
		if (!(hname != string.Empty))
		{
			return;
		}
		if (!(counter <= 0f))
		{
			counter -= Time.deltaTime;
		}
		else
		{
			MasterServer.ClearHostList();
			MasterServer.RequestHostList("CarbonCombat");
			counter = 2f;
		}
		HostData[] array = MasterServer.PollHostList();
		int i = 0;
		HostData[] array2 = array;
		for (int length = array2.Length; i < length; i++)
		{
			if (array2[i].comment == "Admin")
			{
				PhotonNetwork.JoinRoom(array2[i].guid);
			}
		}
	}
}
