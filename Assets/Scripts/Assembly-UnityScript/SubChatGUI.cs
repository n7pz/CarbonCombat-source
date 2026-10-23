using System;
using Photon;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class SubChatGUI : Photon.MonoBehaviour
{
	public GUIStyle backtexture;

	public GUIStyle rightbutton;

	public GUIStyle leftbutton;

	public float h1;

	private UnityScript.Lang.Array commandarray;

	private int counter;

	public ChatScript src;

	public AudioController acon;

	public MasterServerScript mserver;

	public SubChatGUI()
	{
		h1 = 29f;
		commandarray = new UnityScript.Lang.Array("Respawn car = /r or respawn", "Evict player = /e Usrname", "Private msg = /Usrname Msg", "Team chat = /t Msg", "Spawn bots = /bots Amt");
	}

	public virtual void OnGUI()
	{
		if (AudioController.hideGUI)
		{
			return;
		}
		GUI.depth = -1;
		float pubalpha = ChatScript.pubalpha;
		Color color = GUI.color;
		float num = (color.a = pubalpha);
		Color color2 = (GUI.color = color);
		if (ChatScript.pubalpha == 1f)
		{
			float alpha = ChatScript.alpha;
			Color color4 = GUI.color;
			float num2 = (color4.a = alpha);
			Color color5 = (GUI.color = color4);
		}
		GUI.BeginGroup(new Rect(21f, 431f - (345.9f - ChatScript.pubheight), 241f, h1));
		object obj = commandarray[counter];
		UnityRuntimeServices.Invoke(typeof(GUI), "Box", new object[3]
		{
			new Rect(0f, 0f, 241f, 29f),
			obj,
			backtexture
		}, typeof(UnityEngine.MonoBehaviour));
		if (GUI.Button(new Rect(214f, 3f, 15f, 15f), string.Empty, rightbutton))
		{
			counter++;
			if (!PhotonNetwork.isMasterClient && !MasterServerScript.connectedToDed && counter == 1)
			{
				counter++;
			}
			if (counter > 4)
			{
				counter = 0;
			}
		}
		if (GUI.Button(new Rect(195f, 3f, 15f, 15f), string.Empty, leftbutton))
		{
			counter--;
			if (!PhotonNetwork.isMasterClient && !MasterServerScript.connectedToDed && counter == 1)
			{
				counter--;
			}
			if (counter < 0)
			{
				counter = 4;
			}
		}
		GUI.EndGroup();
	}
}
