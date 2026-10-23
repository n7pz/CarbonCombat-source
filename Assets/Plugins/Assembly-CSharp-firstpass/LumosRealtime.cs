using System.Collections.Generic;
using UnityEngine;

public class LumosRealtime
{
	public static void Record(string[] messages)
	{
		if (messages.Length != 0)
		{
			List<string> list = new List<string>();
			foreach (string value in messages)
			{
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				dictionary.Add("level", Application.loadedLevelName);
				dictionary.Add("message", value);
				Dictionary<string, string> json = dictionary;
				string item = LumosUtil.Json.Serialize(json);
				list.Add(item);
			}
			Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
			dictionary2.Add("messages", list);
			Dictionary<string, object> parameters = dictionary2;
			LumosWWW.Send("realtime.message", parameters);
		}
	}
}
