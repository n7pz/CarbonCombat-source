using System;
using System.Collections;
using Boo.Lang.Runtime;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class BattleFieldBorderDel : MonoBehaviour
{
	private UnityScript.Lang.Array colstates;

	public GameObject chatobj;

	private bool warning;

	private float timeleft;

	public GUIStyle txtstyle;

	public GUIStyle wbox;

	public GUIStyle wsym;

	public AuthGameObject authobj;

	public SpawningScript spawnobj;

	public AudioController acon;

	private int temptimeleft;

	private float GUIalpha;

	public BattleFieldBorderDel()
	{
		colstates = new UnityScript.Lang.Array(false, false, false, false, false, false);
		timeleft = 10f;
	}

	public virtual void Update()
	{
		bool flag = false;
		IEnumerator enumerator = UnityRuntimeServices.GetEnumerator(colstates);
		while (enumerator.MoveNext())
		{
			bool flag2 = RuntimeServices.UnboxBoolean(enumerator.Current);
			if (flag2)
			{
				flag = true;
			}
		}
		if (flag)
		{
			if (!warning)
			{
				warning = true;
			}
		}
		else
		{
			if (warning)
			{
				warning = false;
			}
			if (timeleft != 10f)
			{
				timeleft = 10f;
			}
		}
		if (!(timeleft > 0f))
		{
			timeleft = 10f;
			warning = false;
			chatobj.SendMessage("OutsideSystem", AuthGameObject.username + " was killed trying to leave the battlefield.");
			SpawningScript.playertrans.gameObject.SendMessage("outofbounds");
			GUIalpha = 0f;
		}
		if (warning)
		{
			timeleft -= Time.deltaTime;
			if (!(GUIalpha >= 1f))
			{
				GUIalpha = Mathf.Lerp(GUIalpha, 1f, Time.deltaTime * 3f);
			}
		}
		else if (!(GUIalpha <= 0f))
		{
			GUIalpha = Mathf.Lerp(GUIalpha, 0f, Time.deltaTime * 5f);
		}
	}

	public virtual void OnGUI()
	{
		if (!AudioController.hideGUI)
		{
			GUI.depth = -4;
			if (warning)
			{
				float gUIalpha = GUIalpha;
				Color color = GUI.color;
				float num = (color.a = gUIalpha);
				Color color2 = (GUI.color = color);
				GUI.BeginGroup(new Rect(Screen.width / 2 - 200, Screen.height / 2 - 50, 400f, 100f));
				GUI.Box(new Rect(0f, 0f, 400f, 100f), "Warning: Leaving the Battlefield", wbox);
				GUI.Label(new Rect(110f, 50f, 300f, 25f), "You have " + Mathf.Round(timeleft) + " seconds to return to the battle", txtstyle);
				GUI.Box(new Rect(25f, 20f, 60f, 60f), string.Empty, wsym);
				GUI.EndGroup();
				temptimeleft = (int)Mathf.Round(timeleft);
			}
			else if (!(GUIalpha <= 0f))
			{
				float gUIalpha2 = GUIalpha;
				Color color4 = GUI.color;
				float num2 = (color4.a = gUIalpha2);
				Color color5 = (GUI.color = color4);
				GUI.BeginGroup(new Rect(Screen.width / 2 - 200, Screen.height / 2 - 50, 400f, 100f));
				GUI.Box(new Rect(0f, 0f, 400f, 100f), "Warning: Leaving the Battlefield", wbox);
				GUI.Label(new Rect(105f, 50f, 300f, 25f), "You have " + temptimeleft + " seconds to return to the battle", txtstyle);
				GUI.Box(new Rect(25f, 20f, 60f, 60f), string.Empty, wsym);
				GUI.EndGroup();
			}
		}
	}

	public virtual void resetStates()
	{
		IEnumerator enumerator = UnityRuntimeServices.GetEnumerator(colstates);
		while (enumerator.MoveNext())
		{
			bool flag = RuntimeServices.UnboxBoolean(enumerator.Current);
			flag = false;
			UnityRuntimeServices.Update(enumerator, flag);
		}
	}

	public virtual void enter(int i)
	{
		colstates[i] = true;
	}

	public virtual void exit(int i)
	{
		colstates[i] = false;
	}

	public virtual void Main()
	{
	}
}
