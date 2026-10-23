using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playtomic_Leaderboards : Playtomic_Responder
{
	private static string SECTION;

	private static string CREATEPRIVATELEADERBOARD;

	private static string LOADPRIVATELEADERBOARD;

	private static string SAVEANDLIST;

	private static string SAVE;

	private static string LIST;

	internal static void Initialise(string apikey)
	{
		SECTION = Playtomic_Encode.MD5("leaderboards-" + apikey);
		CREATEPRIVATELEADERBOARD = Playtomic_Encode.MD5("leaderboards-createprivateleaderboard-" + apikey);
		LOADPRIVATELEADERBOARD = Playtomic_Encode.MD5("leaderboards-loadprivateleaderboard-" + apikey);
		SAVEANDLIST = Playtomic_Encode.MD5("leaderboards-saveandlist-" + apikey);
		SAVE = Playtomic_Encode.MD5("leaderboards-save-" + apikey);
		LIST = Playtomic_Encode.MD5("leaderboards-list-" + apikey);
	}

	public IEnumerator CreatePrivateLeaderboard(string table, bool highest, string permalink)
	{
		string url;
		WWWForm post;
		Playtomic_Request.Prepare(postdata: new Dictionary<string, string>
		{
			{ "table", table },
			{
				"highest",
				(!highest) ? "n" : "y"
			},
			{ "permalink", permalink }
		}, section: SECTION, action: CREATEPRIVATELEADERBOARD, url: out url, post: out post);
		WWW www = new WWW(url, post);
		yield return www;
		Playtomic_Response response = Playtomic_Request.Process(www);
		if (response.Success)
		{
			Hashtable data = response.JSON;
			foreach (string key in data.Keys)
			{
				string name = WWW.UnEscapeURL(key);
				string value = WWW.UnEscapeURL((string)data[key]);
				response.Data.Add(name, value);
			}
		}
		SetResponse(response, "CreatePrivateLeaderboard");
	}

	public IEnumerator LoadPrivateLeaderboard(string tableid)
	{
		string url;
		WWWForm post;
		Playtomic_Request.Prepare(postdata: new Dictionary<string, string> { { "levelid", levelid } }, section: SECTION, action: LOAD, url: out url, post: out post);
		WWW www = new WWW(url, post);
		yield return www;
		Playtomic_Response response = Playtomic_Request.Process(www);
		if (response.Success)
		{
			Hashtable data = response.JSON;
			foreach (string key in data.Keys)
			{
				string name = WWW.UnEscapeURL(key);
				string value = WWW.UnEscapeURL((string)data[key]);
				response.Data.Add(name, value);
			}
		}
		SetResponse(response, "LoadPrivateLeaderboard");
	}

	public string GetLeaderboardFromUrl()
	{
		string sourceUrl = Playtomic.SourceUrl;
		if (!sourceUrl.Contains("?"))
		{
			return null;
		}
		if (!sourceUrl.Contains("leaderboard="))
		{
			return null;
		}
		string text = sourceUrl.Substring(sourceUrl.IndexOf("leaderboard=") + 12);
		if (text.IndexOf("&") > -1)
		{
			text = text.Substring(0, text.IndexOf("&"));
		}
		if (text.IndexOf("#") > -1)
		{
			text = text.Substring(0, text.IndexOf("#"));
		}
		if (text.Length == 24)
		{
			return text;
		}
		return null;
	}

	public IEnumerator Save(string table, Playtomic_PlayerScore score, bool highest)
	{
		return Save(table, score, highest, false, false);
	}

	public IEnumerator Save(string table, Playtomic_PlayerScore score, bool highest, bool allowduplicates)
	{
		return Save(table, score, highest, allowduplicates, false);
	}

	public IEnumerator Save(string table, Playtomic_PlayerScore score, bool highest, bool allowduplicates, bool facebook)
	{
		Dictionary<string, string> postdata = new Dictionary<string, string>
		{
			{ "table", table },
			{
				"highest",
				(!highest) ? "n" : "y"
			},
			{ "name", score.Name },
			{
				"points",
				score.Points.ToString()
			},
			{
				"allowduplicates",
				(!allowduplicates) ? "n" : "y"
			},
			{
				"auth",
				Playtomic_Encode.MD5(Playtomic.SourceUrl + score.Points)
			},
			{
				"customfields",
				score.CustomData.Count.ToString()
			},
			{
				"fbuserid",
				(!string.IsNullOrEmpty(score.FBUserId)) ? score.FBUserId : string.Empty
			},
			{
				"fb",
				(!facebook) ? "n" : "y"
			},
			{
				"url",
				Playtomic.SourceUrl
			}
		};
		int n = 0;
		foreach (string key in score.CustomData.Keys)
		{
			postdata.Add("ckey" + n, key);
			postdata.Add("cdata" + n, score.CustomData[key]);
			n++;
		}
		string url;
		WWWForm post;
		Playtomic_Request.Prepare(SECTION, SAVE, postdata, out url, out post);
		WWW www = new WWW(url, post);
		yield return www;
		Playtomic_Response response = Playtomic_Request.Process(www);
		SetResponse(response, "Save");
	}

	public IEnumerator SaveAndList(string table, Playtomic_PlayerScore score, bool highest, string mode, int perpage, bool isglobal)
	{
		return SaveAndList(table, score, highest, mode, perpage, isglobal, false, false, null);
	}

	public IEnumerator SaveAndList(string table, Playtomic_PlayerScore score, bool highest, string mode, int perpage, bool isglobal, bool allowduplicates)
	{
		return SaveAndList(table, score, highest, mode, perpage, isglobal, allowduplicates, false, null);
	}

	public IEnumerator SaveAndList(string table, Playtomic_PlayerScore score, bool highest, string mode, int perpage, bool isglobal, bool allowduplicates, bool facebook, Dictionary<string, string> customfilters)
	{
		Dictionary<string, string> postdata = new Dictionary<string, string>
		{
			{ "table", table },
			{
				"highest",
				(!highest) ? "n" : "y"
			},
			{
				"fb",
				(!facebook) ? "n" : "y"
			},
			{ "name", score.Name },
			{
				"points",
				score.Points.ToString()
			},
			{
				"allowduplicates",
				(!allowduplicates) ? "n" : "y"
			},
			{
				"auth",
				Playtomic_Encode.MD5(Playtomic.SourceUrl + score.Points)
			},
			{
				"numfields",
				score.CustomData.Count.ToString()
			},
			{
				"fbuserid",
				(!string.IsNullOrEmpty(score.FBUserId)) ? score.FBUserId : string.Empty
			},
			{
				"url",
				Playtomic.SourceUrl
			}
		};
		int n = 0;
		foreach (string key in score.CustomData.Keys)
		{
			postdata.Add("ckey" + n, key);
			postdata.Add("cdata" + n, score.CustomData[key]);
			n++;
		}
		int numfilters = ((customfilters != null) ? customfilters.Count : 0);
		postdata.Add("global", (!isglobal) ? "n" : "y");
		postdata.Add("perpage", perpage.ToString());
		postdata.Add("mode", mode);
		postdata.Add("numfilters", numfilters.ToString());
		int fieldnumber = 0;
		if (numfilters > 0)
		{
			foreach (string key2 in customfilters.Keys)
			{
				postdata.Add("lkey" + fieldnumber, key2);
				postdata.Add("ldata" + fieldnumber, customfilters[key2]);
				fieldnumber++;
			}
		}
		string url;
		WWWForm post;
		Playtomic_Request.Prepare(SECTION, SAVEANDLIST, postdata, out url, out post);
		WWW www = new WWW(url, post);
		yield return www;
		Playtomic_Response response = Playtomic_Request.Process(www);
		if (response.Success)
		{
			Hashtable data = response.JSON;
			ArrayList scores = (ArrayList)data["Scores"];
			int len = scores.Count;
			response.NumItems = (int)(double)data["NumScores"];
			response.Scores = new List<Playtomic_PlayerScore>();
			for (int i = 0; i < len; i++)
			{
				Hashtable item = (Hashtable)scores[i];
				Playtomic_PlayerScore sscore = new Playtomic_PlayerScore
				{
					Name = WWW.UnEscapeURL((string)item["Name"]),
					Points = (int)(double)item["Points"],
					SDate = DateTime.Parse((string)item["SDate"]),
					RDate = WWW.UnEscapeURL((string)item["RDate"]),
					Rank = (long)(double)item["Rank"]
				};
				if (item.ContainsKey("SubmittedOrBest"))
				{
					sscore.SubmittedOrBest = item["SubmittedOrBest"].ToString() == "true";
				}
				if (item.ContainsKey("CustomData"))
				{
					Hashtable customdata = (Hashtable)item["CustomData"];
					foreach (object key3 in customdata.Keys)
					{
						sscore.CustomData.Add((string)key3, WWW.UnEscapeURL((string)customdata[key3]));
					}
				}
				response.Scores.Add(sscore);
			}
		}
		SetResponse(response, "SaveAndList");
	}

	public IEnumerator List(string table, bool highest, string mode, int page, int perpage)
	{
		return List(table, highest, mode, page, perpage, false, null, null);
	}

	public IEnumerator List(string table, bool highest, string mode, int page, int perpage, bool facebook)
	{
		return List(table, highest, mode, page, perpage, facebook, null, null);
	}

	public IEnumerator List(string table, bool highest, string mode, int page, int perpage, bool facebook, Dictionary<string, string> customfilters)
	{
		return List(table, highest, mode, page, perpage, facebook, customfilters, null);
	}

	public IEnumerator List(string table, bool highest, string mode, int page, int perpage, bool facebook, Dictionary<string, string> customfilters, string[] friendslist)
	{
		int numfilters = ((customfilters != null) ? customfilters.Count : 0);
		Dictionary<string, string> postdata = new Dictionary<string, string>
		{
			{ "table", table },
			{
				"highest",
				(!highest) ? "n" : "y"
			},
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
				"filters",
				numfilters.ToString()
			},
			{ "url", "global" }
		};
		if (numfilters > 0)
		{
			int fieldnumber = 0;
			foreach (string key in customfilters.Keys)
			{
				postdata.Add("ckey" + fieldnumber, key);
				postdata.Add("cdata" + fieldnumber, customfilters[key]);
				fieldnumber++;
			}
		}
		if (facebook)
		{
			postdata.Add("fb", "y");
			if (friendslist != null && friendslist.Length > 0)
			{
				postdata.Add("friendslist", string.Join(",", friendslist));
			}
		}
		else
		{
			postdata.Add("fb", "n");
		}
		string url;
		WWWForm post;
		Playtomic_Request.Prepare(SECTION, LIST, postdata, out url, out post);
		WWW www = new WWW(url, post);
		yield return www;
		Playtomic_Response response = Playtomic_Request.Process(www);
		if (response.Success)
		{
			Hashtable data = response.JSON;
			ArrayList scores = (ArrayList)data["Scores"];
			int len = scores.Count;
			response.NumItems = (int)(double)data["NumScores"];
			response.Scores = new List<Playtomic_PlayerScore>();
			for (int i = 0; i < len; i++)
			{
				Hashtable item = (Hashtable)scores[i];
				Playtomic_PlayerScore sscore = new Playtomic_PlayerScore
				{
					Name = WWW.UnEscapeURL((string)item["Name"]),
					Points = (int)(double)item["Points"],
					SDate = DateTime.Parse((string)item["SDate"]),
					RDate = WWW.UnEscapeURL((string)item["RDate"]),
					Rank = (long)(double)item["Rank"]
				};
				if (item.ContainsKey("CustomData"))
				{
					Hashtable customdata = (Hashtable)item["CustomData"];
					foreach (object key2 in customdata.Keys)
					{
						sscore.CustomData.Add((string)key2, WWW.UnEscapeURL((string)customdata[key2]));
					}
				}
				response.Scores.Add(sscore);
			}
		}
		SetResponse(response, "List");
	}
}
