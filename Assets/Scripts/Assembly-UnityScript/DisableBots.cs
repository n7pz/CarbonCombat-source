using System;
using Photon;
using UnityEngine;

[Serializable]
public class DisableBots : Photon.MonoBehaviour
{
	public GUIStyle buttonstyle;

	public GUIStyle boxstyle;

	private string buttonstatus;

	public GameObject chatobj;

	public RefreshMasterServer refreshsrc;

	public SpawningScript spwnsrc;

	public PlayerCar_Script playercar;

	public AudioController acon;

	public MasterServerScript mserver;

	public DisableBots()
	{
		buttonstatus = "Press [b]\nTo Turn Bots Off";
	}

	public virtual void OnGUI()
	{
		if (!AudioController.hideGUI)
		{
			if (!RefreshMasterServer.personjoined && (PhotonNetwork.isMasterClient || MasterServerScript.connectedToDed) && SpawningScript.team2 != string.Empty)
			{
				GUI.depth = -3;
				GUI.BeginGroup(new Rect(Screen.width / 2 - 108, -10f, 300f, 70f));
				GUI.Box(new Rect(0f, 0f, 216f, 88f), buttonstatus, boxstyle);
				GUI.EndGroup();
			}
			if (RefreshMasterServer.personjoined && (PhotonNetwork.isMasterClient || MasterServerScript.connectedToDed))
			{
				buttonstatus = "Press [b]\nTo Turn Bots On";
			}
		}
	}

	public virtual void Update()
	{
		if (Input.GetKeyDown("b") && !RefreshMasterServer.personjoined && (PhotonNetwork.isMasterClient || MasterServerScript.connectedToDed) && SpawningScript.team2 != string.Empty && PlayerCar_Script.controlenabled)
		{
			if (buttonstatus == "Press [b]\nTo Turn Bots Off")
			{
				buttonstatus = "Press [b]\nTo Turn Bots On";
				chatobj.SendMessage("botcon", "off");
			}
			else
			{
				buttonstatus = "Press [b]\nTo Turn Bots Off";
				chatobj.SendMessage("botcon", "on");
			}
		}
	}
}
