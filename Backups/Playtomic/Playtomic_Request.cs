using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class Playtomic_Request
{
	public static Dictionary<string, Playtomic_Response> Requests = new Dictionary<string, Playtomic_Response>();

	private static string URLStub;

	private static string URLTail;

	private static string URL;

	public static void Initialise()
	{
		URLStub = "http://g" + Playtomic.GameGuid + ".api.playtomic.com/";
		URLTail = "swfid=" + Playtomic.GameId + "&js=y";
		URL = URLStub + "v3/api.aspx?" + URLTail;
	}

	public static IEnumerator SendStatistics(string data)
	{
		WWWForm post = new WWWForm();
		post.AddField("x", "x");
		System.Random r = new System.Random();
		string turl = URLStub + "tracker/q.aspx?q=" + data + "&swfid=" + Playtomic.GameId + "&url=" + Escape(Playtomic.SourceUrl) + "&" + r.Next(1000000) + "Z";
		Debug.Log("Sending data to " + turl);
		WWW www = new WWW(turl, post);
		yield return www;
		Debug.Log(www.text);
	}

	public static void Prepare(string section, string action, Dictionary<string, string> postdata, out string url, out WWWForm post)
	{
		System.Random random = new System.Random();
		url = URL + "&r=" + random.Next(10000000) + "Z";
		string text = DateTime.Now.Subtract(new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds.ToString();
		string text2 = Playtomic_Encode.MD5(text + Playtomic.SourceUrl + Playtomic.GameGuid);
		ArrayList arr = new ArrayList();
		arr.Add("nonce=" + text2);
		arr.Add("timestamp=" + text);
		if (postdata != null)
		{
			foreach (string key in postdata.Keys)
			{
				arr.Add(key + "=" + Escape(postdata[key]));
			}
		}
		GenerateKey("section", section, ref arr);
		GenerateKey("action", action, ref arr);
		GenerateKey("signature", text2 + text + section + action + url + Playtomic.GameGuid, ref arr);
		string text3 = string.Empty;
		foreach (object item in arr)
		{
			text3 = text3 + ((!(text3 == string.Empty)) ? "&" : string.Empty) + item;
		}
		post = new WWWForm();
		post.AddField("data", Escape(Playtomic_Encode.Base64(text3)));
	}

	public static Playtomic_Response Process(WWW www)
	{
		if (www == null)
		{
			return Playtomic_Response.GeneralError(1);
		}
		if (www.error != null)
		{
			return Playtomic_Response.GeneralError(www.error);
		}
		if (string.IsNullOrEmpty(www.text))
		{
			return Playtomic_Response.Error(1);
		}
		Hashtable hashtable = (Hashtable)Playtomic_JSON.JsonDecode(www.text);
		if (!hashtable.ContainsKey("Status") || !hashtable.ContainsKey("ErrorCode"))
		{
			return Playtomic_Response.GeneralError(1);
		}
		Playtomic_Response playtomic_Response = new Playtomic_Response();
		playtomic_Response.Success = (int)(double)hashtable["Status"] == 1;
		playtomic_Response.ErrorCode = (int)(double)hashtable["ErrorCode"];
		if (playtomic_Response.Success && hashtable.ContainsKey("Data"))
		{
			if (hashtable["Data"] is Hashtable)
			{
				playtomic_Response.JSON = (Hashtable)hashtable["Data"];
			}
			if (hashtable["Data"] is ArrayList)
			{
				playtomic_Response.ARRAY = (ArrayList)hashtable["Data"];
			}
		}
		return playtomic_Response;
	}

	private static void GenerateKey(string name, string key, ref ArrayList arr)
	{
		string[] array = (string[])arr.ToArray(typeof(string));
		Array.Sort(array);
		string text = string.Empty;
		string[] array2 = array;
		foreach (string text2 in array2)
		{
			text = text + ((!(text == string.Empty)) ? "&" : string.Empty) + text2;
		}
		arr.Add(name + "=" + Playtomic_Encode.MD5(text + key));
	}

	private static string Escape(string str)
	{
		str = string.Join("%25", str.Split('%'));
		str = string.Join("%3B", str.Split(';'));
		str = string.Join("%3F", str.Split('?'));
		str = string.Join("%2F", str.Split('/'));
		str = string.Join("%3A", str.Split(':'));
		str = string.Join("%23", str.Split('#'));
		str = string.Join("%26", str.Split('&'));
		str = string.Join("%3D", str.Split('='));
		str = string.Join("%2B", str.Split('+'));
		str = string.Join("%24", str.Split('$'));
		str = string.Join("%2C", str.Split(','));
		str = string.Join("%20", str.Split(' '));
		str = string.Join("%3C", str.Split('<'));
		str = string.Join("%3E", str.Split('>'));
		str = string.Join("%7E", str.Split('~'));
		return str;
	}
}
