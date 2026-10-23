using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playtomic_PlayerLevels : Playtomic_Responder
{
	private static string SECTION;

	private static string SAVE;

	private static string LIST;

	private static string LOAD;

	private static string RATE;

	internal static void Initialise(string apikey)
	{
		SECTION = Playtomic_Encode.MD5("playerlevels-" + apikey);
		RATE = Playtomic_Encode.MD5("playerlevels-rate-" + apikey);
		LIST = Playtomic_Encode.MD5("playerlevels-list-" + apikey);
		SAVE = Playtomic_Encode.MD5("playerlevels-save-" + apikey);
		LOAD = Playtomic_Encode.MD5("playerlevels-load-" + apikey);
	}

	public IEnumerator Save(Playtomic_PlayerLevel level)
	{
		Dictionary<string, string> postdata = new Dictionary<string, string>
		{
			{ "data", level.Data },
			{ "playerid", level.PlayerId },
			{ "playername", level.PlayerName },
			{
				"playersource",
				Playtomic.SourceUrl
			},
			{ "name", level.Name },
			{ "nothumb", "y" },
			{
				"customfields",
				level.CustomData.Count.ToString()
			}
		};
		int n = 0;
		foreach (string key in level.CustomData.Keys)
		{
			postdata.Add("ckey" + n, key);
			postdata.Add("cdata" + n, level.CustomData[key]);
			n++;
		}
		string url;
		WWWForm post;
		Playtomic_Request.Prepare(SECTION, SAVE, postdata, out url, out post);
		WWW www = new WWW(url, post);
		yield return www;
		Playtomic_Response response = Playtomic_Request.Process(www);
		if (response.Success)
		{
			Hashtable data = response.JSON;
			foreach (string key2 in data.Keys)
			{
				string name = WWW.UnEscapeURL(key2);
				string value = WWW.UnEscapeURL((string)data[key2]);
				response.Data.Add(name, value);
			}
		}
		SetResponse(response, "Save");
	}

	public IEnumerator Load(string levelid)
	{
		string url;
		WWWForm post;
		Playtomic_Request.Prepare(SECTION, LOAD, new Dictionary<string, string> { { "levelid", levelid } }, out url, out post);	
		WWW www = new WWW(url, post);
		yield return www;
		Playtomic_Response response = Playtomic_Request.Process(www);
		if (response.Success)
		{
			Hashtable item = response.JSON;
			Playtomic_PlayerLevel level = new Playtomic_PlayerLevel
			{
				LevelId = (string)item["LevelId"],
				PlayerSource = (string)item["PlayerSource"],
				PlayerName = WWW.UnEscapeURL((string)item["PlayerName"]),
				Name = WWW.UnEscapeURL((string)item["Name"]),
				Votes = (int)(double)item["Votes"],
				Plays = (int)(double)item["Plays"],
				Rating = (double)item["Rating"],
				Score = (int)(double)item["Score"],
				SDate = DateTime.Parse((string)item["SDate"]),
				RDate = WWW.UnEscapeURL((string)item["RDate"])
			};
			if (item.ContainsKey("Data"))
			{
				level.Data = (string)item["Data"];
			}
			if (item.ContainsKey("CustomData"))
			{
				Hashtable customdata = (Hashtable)item["CustomData"];
				foreach (object key in customdata.Keys)
				{
					level.CustomData.Add((string)key, WWW.UnEscapeURL((string)customdata[key]));
				}
			}
			response.Levels = new List<Playtomic_PlayerLevel>();
			response.Levels.Add(level);
		}
		SetResponse(response, "Load");
	}

	public IEnumerator List(string mode, int page, int perpage)
	{
		return List(mode, page, perpage, false, false, DateTime.MinValue, DateTime.MaxValue);
	}

	public IEnumerator List(string mode, int page, int perpage, bool includedata, bool includethumbs)
	{
		return List(mode, page, perpage, includedata, includethumbs, DateTime.MinValue, DateTime.MaxValue);
	}

	public IEnumerator List(string mode, int page, int perpage, bool includedata, bool includethumbs, DateTime datemin, DateTime datemax)
	{
		string url;
		WWWForm post;
		Playtomic_Request.Prepare(postdata: new Dictionary<string, string>
		{
			{ "mode", mode },
			{
				"page",
				page.ToString()
			},
			{
				"perpage",
				perpage.ToString()
			},
			{
				"thumbs",
				(!includethumbs) ? "n" : "y"
			},
			{
				"data",
				(!includedata) ? "n" : "y"
			},
			{
				"datemin",
				datemin.ToString("MM/dd/yyyy")
			},
			{
				"datemax",
				datemax.ToString("MM/dd/yyyy")
			},
			{ "filters", "0" }
		}, section: SECTION, action: LIST, url: out url, post: out post);
		WWW www = new WWW(url, post);
		yield return www;
		Playtomic_Response response = Playtomic_Request.Process(www);
		if (response.Success)
		{
			Hashtable data = response.JSON;
			ArrayList levels = (ArrayList)data["Levels"];
			int len = levels.Count;
			response.NumItems = (int)(double)data["NumLevels"];
			response.Levels = new List<Playtomic_PlayerLevel>();
			for (int i = 0; i < len; i++)
			{
				Hashtable item = (Hashtable)levels[i];
				Playtomic_PlayerLevel level = new Playtomic_PlayerLevel
				{
					LevelId = (string)item["LevelId"],
					PlayerSource = (string)item["PlayerSource"],
					PlayerName = WWW.UnEscapeURL((string)item["PlayerName"]),
					Name = WWW.UnEscapeURL((string)item["Name"]),
					Votes = (int)(double)item["Votes"],
					Plays = (int)(double)item["Plays"],
					Rating = (double)item["Rating"],
					Score = (int)(double)item["Score"],
					SDate = DateTime.Parse((string)item["SDate"]),
					RDate = WWW.UnEscapeURL((string)item["RDate"])
				};
				if (item.ContainsKey("Data"))
				{
					level.Data = (string)item["Data"];
				}
				if (item.ContainsKey("CustomData"))
				{
					Hashtable customdata = (Hashtable)item["CustomData"];
					foreach (object key in customdata.Keys)
					{
						level.CustomData.Add((string)key, WWW.UnEscapeURL((string)customdata[key]));
					}
				}
				response.Levels.Add(level);
			}
		}
		SetResponse(response, "List");
	}

	public IEnumerator Rate(string levelid, int rating)
	{
		if (rating < 1 || rating > 10)
		{
			SetResponse(Playtomic_Response.Error(401), "Rate");
			yield break;
		}
		string url;
		WWWForm post;
		Playtomic_Request.Prepare(postdata: new Dictionary<string, string>
		{
			{ "levelid", levelid },
			{
				"rating",
				rating.ToString()
			}
		}, section: SECTION, action: RATE, url: out url, post: out post);
		WWW www = new WWW(url, post);
		yield return www;
		Playtomic_Response response = Playtomic_Request.Process(www);
		SetResponse(response, "Rate");
	}

	public void LogStart(string levelid)
	{
		Playtomic.Log.PlayerLevelStart(levelid);
	}

	public void LogQuit(string levelid)
	{
		Playtomic.Log.PlayerLevelQuit(levelid);
	}

	public void LogWin(string levelid)
	{
		Playtomic.Log.PlayerLevelWin(levelid);
	}

	public void LogRetry(string levelid)
	{
		Playtomic.Log.PlayerLevelRetry(levelid);
	}

	public void Flag(string levelid)
	{
		Playtomic.Log.PlayerLevelFlag(levelid);
	}
}
