using System;
using System.Collections.Generic;

public class Playtomic_PlayerScore
{
	public string Name;

	public string FBUserId;

	public double Points;

	public string Website;

	public DateTime SDate;

	public string RDate;

	public long Rank;

	public Dictionary<string, string> CustomData = new Dictionary<string, string>();

	public bool SubmittedOrBest;

	public Playtomic_PlayerScore()
	{
		SDate = default(DateTime);
		RDate = "Just now";
	}
}
