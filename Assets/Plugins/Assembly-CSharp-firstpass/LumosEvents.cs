using System;
using System.Collections.Generic;
using UnityEngine;

public class LumosEvents : MonoBehaviour
{
	private static List<Dictionary<string, object>> events = new List<Dictionary<string, object>>();

	private static List<string> unsentUniqueEvents = new List<string>();

	private float levelStartTime;

	private LumosEvents()
	{
	}

	public static void Record(string name, float? value, bool repeatable)
	{
		if (name == null || name == string.Empty)
		{
			Lumos.LogWarning("Name must be sent. Event not recorded.");
			return;
		}
		if (!repeatable)
		{
			if (RecordedUnique(name))
			{
				return;
			}
			unsentUniqueEvents.Add(name);
		}
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		dictionary.Add("name", name);
		dictionary.Add("level", Application.loadedLevelName);
		Dictionary<string, object> dictionary2 = dictionary;
		if (value.HasValue)
		{
			dictionary2.Add("value_str", value.Value.ToString());
		}
		events.Add(dictionary2);
	}

	public static bool RecordedUnique(string name)
	{
		bool result = false;
		if (PlayerPrefs.HasKey(PlayerPrefsKey(name)) || unsentUniqueEvents.Contains(name))
		{
			result = true;
		}
		return result;
	}

	public static string PlayerPrefsKey(string eventName)
	{
		return "lumos_event_" + Application.loadedLevelName + "_" + eventName;
	}

	public static void Send()
	{
		if (events.Count == 0)
		{
			return;
		}
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		dictionary.Add("events", events);
		Dictionary<string, object> parameters = dictionary;
		LumosWWW.Send("events.record", parameters, delegate
		{
			foreach (string unsentUniqueEvent in unsentUniqueEvents)
			{
				PlayerPrefs.SetString(PlayerPrefsKey(unsentUniqueEvent), DateTime.Now.ToString());
			}
			unsentUniqueEvents.Clear();
			events.Clear();
		});
	}

	private void Awake()
	{
		levelStartTime = Time.time;
		Lumos.Event("Level Started", false);
	}

	private void OnLevelWasLoaded()
	{
		Lumos.Event("Level Completion Time", Time.time - levelStartTime);
		levelStartTime = Time.time;
		Lumos.Event("Level Started", false);
	}
}
