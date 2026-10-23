using System.Collections;
using UnityEngine;

public class Playtomic_GameVars : Playtomic_Responder
{
	private static string SECTION;

	private static string LOAD;

	internal static void Initialise(string apikey)
	{
		SECTION = Playtomic_Encode.MD5("gamevars-" + apikey);
		LOAD = Playtomic_Encode.MD5("gamevars-load-" + apikey);
	}

	public IEnumerator Load()
	{
		string url;
		WWWForm post;
		Playtomic_Request.Prepare(SECTION, LOAD, null, out url, out post);
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
		SetResponse(response, "Load");
	}
}
