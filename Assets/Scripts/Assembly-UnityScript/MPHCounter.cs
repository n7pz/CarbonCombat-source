using System;
using UnityEngine;

[Serializable]
public class MPHCounter : MonoBehaviour
{
	public GUIStyle mphskin;

	public GUIStyle mphnodiv;

	public GUIStyle labelskin;

	public ChatScript cscript;

	public PlayerCar_Script carscript;

	public SpawningScript spwnscript;

	public SpectatorController specbot;

	public AudioController acon;

	public CTFFlagSender ctf;

	public AuthGameObject authobj;

	public float sealevel;

	public virtual void OnGUI()
	{
		if (AudioController.hideGUI)
		{
			return;
		}
		GUI.depth = -1;
		if (ChatScript.isCar && SpawningScript.team2 != string.Empty)
		{
			GUI.BeginGroup(new Rect(Screen.width / 2 - 105, Screen.height - 75, 210f, 36f));
			if (!CTFFlagSender.gotflag && !AuthGameObject.showTutorial)
			{
				GUI.Box(new Rect(0f, 0f, 210f, 36f), string.Empty, mphnodiv);
				if (!Application.absoluteURL.Contains("Conduit.unity3d"))
				{
					GUI.Label(new Rect(0f, 0f, 210f, 36f), (!AuthGameObject.fpsenabled) ? "Exiting disabled by host" : "Press [g] to Exit Vehicle", labelskin);
				}
			}
			GUI.EndGroup();
		}
		if (ChatScript.isCar)
		{
			GUI.BeginGroup(new Rect(Screen.width / 2 - 76, Screen.height - 39, 152f, 36f));
			if (SpawningScript.team2 != string.Empty)
			{
				GUI.Box(new Rect(0f, 0f, 152f, 36f), string.Empty, mphskin);
				GUI.Label(new Rect(4f, 0f, 72f, 36f), "MPH: " + PlayerCar_Script.mph.ToString(), labelskin);
				GUI.Label(new Rect(76f, 0f, 72f, 36f), "Alt: " + (((float)PlayerCar_Script.altvar - sealevel) / 2.5f).ToString(), labelskin);
			}
			else if (SpectatorController.iscont)
			{
				GUI.Box(new Rect(0f, 0f, 152f, 36f), string.Empty, mphskin);
				GUI.Label(new Rect(4f, 0f, 72f, 36f), "MPH: " + Mathf.Round(SpawningScript.playertrans.rigidbody.velocity.magnitude * 2.2369363f / 3.3f).ToString(), labelskin);
				GUI.Label(new Rect(76f, 0f, 72f, 36f), "Alt: " + ((Mathf.Round(SpawningScript.playertrans.position.y) - sealevel) / 2.5f).ToString(), labelskin);
			}
			GUI.EndGroup();
		}
	}

	public virtual void Main()
	{
	}
}
