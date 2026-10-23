using System.Collections.Generic;
using UnityEngine;

public class Playtomic_Link
{
	private List<string> Clicks = new List<string>();

	public bool Open(string url, string name, string group)
	{
		int unique = 0;
		int unique2 = 0;
		int num = 0;
		int num2 = 0;
		int fail = 0;
		int fail2 = 0;
		string item = url + "." + name;
		string text = url;
		text = text.Replace("http://", string.Empty);
		if (text.IndexOf("/") > -1)
		{
			text = text.Substring(0, text.IndexOf("/"));
		}
		if (text.IndexOf("?") > -1)
		{
			text = text.Substring(0, text.IndexOf("?"));
		}
		text = "http://" + text + "/";
		string text2 = text;
		if (text2.IndexOf("//") > -1)
		{
			text2 = text2.Substring(text2.IndexOf("//") + 2);
		}
		text2 = text2.Replace("www.", string.Empty);
		if (text2.IndexOf("/") > -1)
		{
			text2 = text2.Substring(0, text2.IndexOf("/"));
		}
		Application.OpenURL(url);
		if (Clicks.IndexOf(item) > -1)
		{
			num = 1;
		}
		else
		{
			num = 1;
			unique = 1;
			Clicks.Add(item);
		}
		if (Clicks.IndexOf(text2) > -1)
		{
			num2 = 1;
		}
		else
		{
			num2 = 1;
			unique2 = 1;
			Clicks.Add(text2);
		}
		bool result = true;
		Playtomic.Log.Link(text, text2.ToLower(), "DomainTotals", unique2, num2, fail2);
		Playtomic.Log.Link(url, name, group, unique, num, fail);
		Playtomic.Log.ForceSend();
		return result;
	}
}
