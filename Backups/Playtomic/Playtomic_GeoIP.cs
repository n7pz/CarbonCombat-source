using System.Collections;
using UnityEngine;

public class Playtomic_GeoIP : Playtomic_Responder
{
	private static string SECTION;

	private static string LOOKUP;

	internal static void Initialise(string apikey)
	{
		SECTION = Playtomic_Encode.MD5("geoip-" + apikey);
		LOOKUP = Playtomic_Encode.MD5("geoip-lookup-" + apikey);
	}

	public IEnumerator Lookup()
	{
		string url;
		WWWForm post;
		Playtomic_Request.Prepare(SECTION, LOOKUP, null, out url, out post);
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
		SetResponse(response, "Lookup");
	}
}
