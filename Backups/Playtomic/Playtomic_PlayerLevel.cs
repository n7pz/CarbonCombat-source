using System;
using System.Collections.Generic;

public class Playtomic_PlayerLevel
{
	public string LevelId;

	public string PlayerSource = string.Empty;

	public string PlayerId = string.Empty;

	public string PlayerName = string.Empty;

	public string Name;

	public string Data;

	public int Votes;

	public int Plays;

	public double Rating;

	public int Score;

	public DateTime SDate;

	public string RDate;

	public Dictionary<string, string> CustomData = new Dictionary<string, string>();

	public string Thumbnail
	{
		get
		{
			return "http:/api.playtomic.com/playerlevels/thumb.aspx?swfid=" + Playtomic.GameId + "&guid=" + Playtomic.GameGuid + "&levelid=" + LevelId;
		}
	}

	public Playtomic_PlayerLevel()
	{
		SDate = default(DateTime);
		RDate = "Just now";
	}
}
