using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playtomic_Data : Playtomic_Responder
{
	private static string SECTION;

	private static string VIEWS;

	private static string PLAYS;

	private static string PLAYTIME;

	private static string CUSTOMMETRIC;

	private static string LEVELCOUNTERMETRIC;

	private static string LEVELAVERAGEMETRIC;

	private static string LEVELRANGEDMETRIC;

	internal static void Initialise(string apikey)
	{
		SECTION = Playtomic_Encode.MD5("data-" + apikey);
		VIEWS = Playtomic_Encode.MD5("data-views-" + apikey);
		PLAYS = Playtomic_Encode.MD5("data-plays-" + apikey);
		PLAYTIME = Playtomic_Encode.MD5("data-playtime-" + apikey);
		CUSTOMMETRIC = Playtomic_Encode.MD5("data-custommetric-" + apikey);
		LEVELCOUNTERMETRIC = Playtomic_Encode.MD5("data-levelcountermetric-" + apikey);
		LEVELAVERAGEMETRIC = Playtomic_Encode.MD5("data-levelaveragemetric-" + apikey);
		LEVELRANGEDMETRIC = Playtomic_Encode.MD5("data-levelrangedmetric-" + apikey);
	}

	public IEnumerator Views()
	{
		return Views(0, 0, 0);
	}

	public IEnumerator Views(int day, int month, int year)
	{
		return General(VIEWS, "Views", day, month, year);
	}

	public IEnumerator Plays()
	{
		return Plays(0, 0, 0);
	}

	public IEnumerator Plays(int day, int month, int year)
	{
		return General(PLAYS, "Plays", day, month, year);
	}

	public IEnumerator PlayTime()
	{
		return PlayTime(0, 0, 0);
	}

	public IEnumerator PlayTime(int day, int month, int year)
	{
		return General(PLAYTIME, "PlayTime", day, month, year);
	}

	private IEnumerator General(string action, string type, int day, int month, int year)
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		dictionary.Add("day", day.ToString());
		dictionary.Add("month", month.ToString());
		dictionary.Add("year", year.ToString());
		return GetData(type, action, dictionary);
	}

	public IEnumerator CustomMetric(string metric)
	{
		return CustomMetric(metric, 0, 0, 0);
	}

	public IEnumerator CustomMetric(string metric, int day, int month, int year)
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		dictionary.Add("day", day.ToString());
		dictionary.Add("month", month.ToString());
		dictionary.Add("year", year.ToString());
		dictionary.Add("metric", metric);
		return GetData("CustomMetric", CUSTOMMETRIC, dictionary);
	}

	public IEnumerator LevelCounter(string metric, string level)
	{
		return LevelCounter(metric, level, 0, 0, 0);
	}

	public IEnumerator LevelCounter(string metric, int level)
	{
		return LevelCounter(metric, level.ToString(), 0, 0, 0);
	}

	public IEnumerator LevelCounter(string metric, int level, int day, int month, int year)
	{
		return LevelCounter(metric, level.ToString(), day, month, year);
	}

	public IEnumerator LevelCounter(string metric, string level, int day, int month, int year)
	{
		return LevelMetric("Counter", LEVELCOUNTERMETRIC, metric, level, day, month, year);
	}

	public IEnumerator LevelAverage(string metric, string level)
	{
		return LevelAverage(metric, level, 0, 0, 0);
	}

	public IEnumerator LevelAverage(string metric, int level)
	{
		return LevelAverage(metric, level.ToString(), 0, 0, 0);
	}

	public IEnumerator LevelAverage(string metric, int level, int day, int month, int year)
	{
		return LevelAverage(metric, level.ToString(), day, month, year);
	}

	public IEnumerator LevelAverage(string metric, string level, int day, int month, int year)
	{
		return LevelMetric("Average", LEVELAVERAGEMETRIC, metric, level, day, month, year);
	}

	public IEnumerator LevelRanged(string metric, string level)
	{
		return LevelRanged(metric, level, 0, 0, 0);
	}

	public IEnumerator LevelRanged(string metric, int level)
	{
		return LevelRanged(metric, level.ToString(), 0, 0, 0);
	}

	public IEnumerator LevelRanged(string metric, int level, int day, int month, int year)
	{
		return LevelRanged(metric, level.ToString(), day, month, year);
	}

	public IEnumerator LevelRanged(string metric, string level, int day, int month, int year)
	{
		return LevelMetric("Ranged", LEVELRANGEDMETRIC, metric, level, day, month, year);
	}

	private IEnumerator LevelMetric(string type, string action, string metric, string level, int day, int month, int year)
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		dictionary.Add("day", day.ToString());
		dictionary.Add("month", month.ToString());
		dictionary.Add("year", year.ToString());
		dictionary.Add("metric", metric);
		dictionary.Add("level", level);
		return GetData(type, action, dictionary);
	}

	private IEnumerator GetData(string type, string action, Dictionary<string, string> postdata)
	{
		string url;
		WWWForm post;
		Playtomic_Request.Prepare(SECTION, action, postdata, out url, out post);
		WWW www = new WWW(url, post);
		yield return www;
		Debug.Log(www.text);
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
		SetResponse(response, type);
	}
}
