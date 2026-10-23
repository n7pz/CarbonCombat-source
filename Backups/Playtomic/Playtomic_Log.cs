using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playtomic_Log
{
	public bool Enabled;

	public bool Queue = true;

	public Playtomic_LogRequest Request;

	private int Pings;

	private int Plays;

	private bool Frozen;

	private List<string> FrozenQueue = new List<string>();

	private List<string> Customs = new List<string>();

	private List<string> LevelCounters = new List<string>();

	private List<string> LevelAverages = new List<string>();

	private List<string> LevelRangeds = new List<string>();

	public void View()
	{
		if (Playtomic.GameId != 0L && !string.IsNullOrEmpty(Playtomic.GameGuid))
		{
			Enabled = true;
			Request = Playtomic_LogRequest.Create();
			int cookie = GetCookie("views");
			cookie++;
			SaveCookie("views", cookie);
			Send("v/" + cookie, true);
			Playtomic.API.StartCoroutine(TimerLoop());
		}
	}

	public void Play()
	{
		if (Enabled)
		{
			LevelCounters = new List<string>();
			LevelAverages = new List<string>();
			LevelRangeds = new List<string>();
			Plays++;
			Send("p/" + Plays);
		}
	}

	internal void PlayerLevelStart(string levelid)
	{
		if (Enabled)
		{
			Send("pls/" + levelid);
		}
	}

	internal void PlayerLevelWin(string levelid)
	{
		if (Enabled)
		{
			Send("plw/" + levelid);
		}
	}

	internal void PlayerLevelQuit(string levelid)
	{
		if (Enabled)
		{
			Send("plq/" + levelid);
		}
	}

	internal void PlayerLevelRetry(string levelid)
	{
		if (Enabled)
		{
			Send("plr/" + levelid);
		}
	}

	internal void PlayerLevelFlag(string levelid)
	{
		if (Enabled)
		{
			Send("plf/" + levelid);
		}
	}

	public void Heatmap(string name, string group, long x, long y)
	{
		if (Enabled)
		{
			Send("h/" + Clean(name) + "/" + Clean(group) + "/" + x + "/" + y);
		}
	}

	public void CustomMetric(string name)
	{
		CustomMetric(name, null, false);
	}

	public void CustomMetric(string name, string group)
	{
		CustomMetric(name, group, false);
	}

	public void CustomMetric(string name, string group, bool unique)
	{
		if (!Enabled)
		{
			return;
		}
		if (group == null)
		{
			group = string.Empty;
		}
		if (unique)
		{
			if (Customs.IndexOf(name) > -1)
			{
				return;
			}
			Customs.Add(name);
		}
		Send("c/" + Clean(name) + "/" + Clean(group));
	}

	public void LevelCounterMetric(string name, int level)
	{
		LevelCounterMetric(name, level.ToString(), false);
	}

	public void LevelCounterMetric(string name, int level, bool unique)
	{
		LevelCounterMetric(name, level.ToString(), unique);
	}

	public void LevelCounterMetric(string name, string level)
	{
		LevelCounterMetric(name, level, false);
	}

	public void LevelCounterMetric(string name, string level, bool unique)
	{
		if (!Enabled)
		{
			return;
		}
		if (unique)
		{
			string item = name + "." + level;
			if (LevelCounters.IndexOf(item) > -1)
			{
				return;
			}
			LevelCounters.Add(item);
		}
		Send("lc/" + Clean(name) + "/" + Clean(level));
	}

	public void LevelRangedMetric(string name, int level, int value)
	{
		LevelRangedMetric(name, level.ToString(), value, false);
	}

	public void LevelRangedMetric(string name, int level, int value, bool unique)
	{
		LevelRangedMetric(name, level.ToString(), value, unique);
	}

	public void LevelRangedMetric(string name, string level, int value)
	{
		LevelRangedMetric(name, level, value, false);
	}

	public void LevelRangedMetric(string name, string level, int value, bool unique)
	{
		if (!Enabled)
		{
			return;
		}
		if (unique)
		{
			string item = name + "." + level;
			if (LevelRangeds.IndexOf(item) > -1)
			{
				return;
			}
			LevelRangeds.Add(item);
		}
		Send("lr/" + Clean(name) + "/" + Clean(level) + "/" + value);
	}

	public void LevelAverageMetric(string name, int level, double value)
	{
		LevelAverageMetric(name, level.ToString(), value, false);
	}

	public void LevelAverageMetric(string name, int level, double value, bool unique)
	{
		LevelAverageMetric(name, level.ToString(), value, unique);
	}

	public void LevelAverageMetric(string name, string level, double value)
	{
		LevelAverageMetric(name, level, value, false);
	}

	public void LevelAverageMetric(string name, string level, double value, bool unique)
	{
		if (!Enabled)
		{
			return;
		}
		if (unique)
		{
			string item = name + "." + level;
			if (LevelAverages.IndexOf(item) > -1)
			{
				return;
			}
			LevelAverages.Add(item);
		}
		Send("la/" + Clean(name) + "/" + Clean(level) + "/" + value);
	}

	public void Link(string url, string name, string group, int unique, int total, int fail)
	{
		if (Enabled)
		{
			Send("l/" + Clean(name) + "/" + Clean(group) + "/" + Clean(url) + "/" + unique + "/" + total + "/" + fail);
		}
	}

	public void Freeze()
	{
		Frozen = true;
	}

	public void UnFreeze()
	{
		Frozen = false;
		Request.MassQueue(FrozenQueue);
	}

	public void ForceSend()
	{
		if (Enabled)
		{
			Request.Send();
			Request = Playtomic_LogRequest.Create();
			if (FrozenQueue.Count > 0)
			{
				Request.MassQueue(FrozenQueue);
			}
		}
	}

	private void Send(string s)
	{
		Send(s, false);
	}

	private void Send(string s, bool view)
	{
		if (Frozen)
		{
			FrozenQueue.Add(s);
			return;
		}
		Request.Queue(s);
		if (Request.Ready || view || !Queue)
		{
			Request.Send();
			Request = Playtomic_LogRequest.Create();
		}
	}

	private static string Clean(string s)
	{
		while (s.IndexOf("/") > -1)
		{
			s = s.Replace("/", "\\");
		}
		while (s.IndexOf("~") > -1)
		{
			s = s.Replace("~", "-");
		}
		return WWW.EscapeURL(s);
	}

	private static int GetCookie(string n)
	{
		if (PlayerPrefs.HasKey(n))
		{
			return PlayerPrefs.GetInt("playtomic-" + n);
		}
		return 0;
	}

	private static void SaveCookie(string n, int v)
	{
		PlayerPrefs.SetInt("playtomic-" + n, v);
	}

	private static string GetUrl(string defaulturl)
	{
		string s = ((Application.isWebPlayer && !Application.isEditor) ? defaulturl : "http://local-testing/");
		return WWW.EscapeURL(s);
	}

	private IEnumerator TimerLoop()
	{
		yield return new WaitForSeconds(60f);
		Pings++;
		Send("t/y/" + Pings, true);
		while (true)
		{
			yield return new WaitForSeconds(30f);
			Pings++;
			Send("t/n/" + Pings, true);
		}
	}
}
