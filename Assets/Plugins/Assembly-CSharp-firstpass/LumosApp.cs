using System.Collections.Generic;
using UnityEngine;

public class LumosApp
{
	public static void Ping()
	{
		Ping(false);
	}

	public static void Ping(bool sendPlayerInfo)
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		dictionary.Add("player_id", Lumos.playerId);
		dictionary.Add("lumos_version", "0.8".ToString());
		Dictionary<string, object> dictionary2 = dictionary;
		if (sendPlayerInfo)
		{
			dictionary = new Dictionary<string, object>();
			dictionary.Add("language", Application.systemLanguage.ToString());
			Dictionary<string, object> dictionary3 = dictionary;
			if (Application.isWebPlayer)
			{
				dictionary3.Add("domain", Application.absoluteURL);
			}
			dictionary2.Add("player_info", dictionary3);
		}
		LumosWWW.Send("app.ping", dictionary2);
	}
}
