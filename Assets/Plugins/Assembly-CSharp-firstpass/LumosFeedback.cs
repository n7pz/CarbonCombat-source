using System.Collections.Generic;
using UnityEngine;

public class LumosFeedback
{
	public delegate void CloseHandler();

	private const int windowId = 345992;

	private const int margin = 10;

	private static Rect windowRect;

	private static bool visible;

	private static bool sentMessage;

	private static string email = string.Empty;

	private static string message = string.Empty;

	private static string type = "Feature Request";

	public static GUISkin skin { get; set; }

	public static event CloseHandler windowClosed;

	private LumosFeedback()
	{
	}

	public static void OnGUI()
	{
		if (visible)
		{
			if (skin != null)
			{
				GUI.skin = skin;
			}
			windowRect = new Rect(10f, 10f, Screen.width - 20, Screen.height - 20);
			GUILayout.Window(345992, windowRect, DisplayWindow, "Leave Feedback");
		}
	}

	private static void DisplayWindow(int windowId)
	{
		GUI.BringWindowToFront(windowId);
		GUILayout.BeginHorizontal();
		GUILayout.Label("Email (optional)", GUILayout.ExpandWidth(false));
		email = GUILayout.TextField(email, 320);
		GUILayout.EndHorizontal();
		GUILayout.BeginHorizontal();
		GUILayout.Label("Type", GUILayout.ExpandWidth(false));
		type = GUILayout.TextField(type);
		GUILayout.EndHorizontal();
		if (!sentMessage)
		{
			message = GUILayout.TextArea(message, GUILayout.MinHeight(200f));
		}
		else
		{
			GUILayout.BeginHorizontal();
			GUILayout.FlexibleSpace();
			GUILayout.Label("Your message has been sent.");
			GUILayout.FlexibleSpace();
			GUILayout.EndHorizontal();
		}
		GUILayout.BeginHorizontal();
		GUILayout.FlexibleSpace();
		if (!sentMessage)
		{
			if (GUILayout.Button("Cancel"))
			{
				HideDialog();
			}
			if (GUILayout.Button("Send"))
			{
				Record(message, email, type);
				message = string.Empty;
				sentMessage = true;
			}
		}
		else if (GUILayout.Button("OK"))
		{
			HideDialog();
			sentMessage = false;
		}
		GUILayout.EndHorizontal();
	}

	public static void ShowDialog()
	{
		visible = true;
	}

	public static void HideDialog()
	{
		if (LumosFeedback.windowClosed != null)
		{
			LumosFeedback.windowClosed();
		}
		visible = false;
	}

	public static void Record(string message, string email, string type)
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		dictionary.Add("player_id", Lumos.playerId);
		dictionary.Add("message", message);
		Dictionary<string, object> dictionary2 = dictionary;
		if (email != null)
		{
			dictionary2.Add("email", email);
		}
		if (type != null)
		{
			dictionary2.Add("type", type);
		}
		LumosWWW.Send("feedback.record", dictionary2);
	}
}
