using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using UnityEngine;

public class AstarProfiler
{
	public struct ProfilePoint
	{
		public DateTime lastRecorded;

		public TimeSpan totalTime;

		public int totalCalls;
	}

	private static Dictionary<string, ProfilePoint> profiles = new Dictionary<string, ProfilePoint>();

	private static DateTime startTime = DateTime.UtcNow;

	public static ProfilePoint[] fastProfiles;

	public static string[] fastProfileNames;

	private AstarProfiler()
	{
	}

	[Conditional("DEBUG")]
	public static void InitializeFastProfile(string[] profileNames)
	{
		fastProfileNames = profileNames;
		fastProfiles = new ProfilePoint[profileNames.Length];
	}

	[Conditional("DEBUG")]
	public static void StartFastProfile(int tag)
	{
		fastProfiles[tag].lastRecorded = DateTime.UtcNow;
	}

	[Conditional("DEBUG")]
	public static void EndFastProfile(int tag)
	{
		DateTime utcNow = DateTime.UtcNow;
		ProfilePoint profilePoint = fastProfiles[tag];
		profilePoint.totalTime += utcNow - profilePoint.lastRecorded;
		profilePoint.totalCalls++;
		fastProfiles[tag] = profilePoint;
	}

	[Conditional("DEBUG")]
	public static void StartProfile(string tag)
	{
		ProfilePoint value;
		profiles.TryGetValue(tag, out value);
		value.lastRecorded = DateTime.UtcNow;
		profiles[tag] = value;
	}

	[Conditional("DEBUG")]
	public static void EndProfile(string tag)
	{
		if (!profiles.ContainsKey(tag))
		{
			UnityEngine.Debug.LogError("Can only end profiling for a tag which has already been started (tag was " + tag + ")");
			return;
		}
		DateTime utcNow = DateTime.UtcNow;
		ProfilePoint value = profiles[tag];
		value.totalTime += utcNow - value.lastRecorded;
		value.totalCalls++;
		profiles[tag] = value;
	}

	[Conditional("DEBUG")]
	public static void Reset()
	{
		profiles.Clear();
		startTime = DateTime.UtcNow;
		if (fastProfiles != null)
		{
			for (int i = 0; i < fastProfiles.Length; i++)
			{
				fastProfiles[i] = default(ProfilePoint);
			}
		}
	}

	[Conditional("DEBUG")]
	public static void PrintFastResults()
	{
		TimeSpan timeSpan = DateTime.UtcNow - startTime;
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("============================\n\t\t\t\tProfile results:\n============================\n");
		for (int i = 0; i < fastProfiles.Length; i++)
		{
			string value = fastProfileNames[i];
			ProfilePoint profilePoint = fastProfiles[i];
			double totalMilliseconds = profilePoint.totalTime.TotalMilliseconds;
			int totalCalls = profilePoint.totalCalls;
			if (totalCalls >= 1)
			{
				stringBuilder.Append("\nProfile ");
				stringBuilder.Append(value);
				stringBuilder.Append(" took \t");
				stringBuilder.Append(totalMilliseconds.ToString("0.0"));
				stringBuilder.Append(" ms to complete over ");
				stringBuilder.Append(totalCalls);
				stringBuilder.Append(" iteration");
				if (totalCalls != 1)
				{
					stringBuilder.Append("s");
				}
				stringBuilder.Append(", averaging \t");
				stringBuilder.Append((totalMilliseconds / (double)totalCalls).ToString("0.000"));
				stringBuilder.Append(" ms per call");
			}
		}
		stringBuilder.Append("\n\n============================\n\t\tTotal runtime: ");
		stringBuilder.Append(timeSpan.TotalSeconds.ToString("F3"));
		stringBuilder.Append(" seconds\n============================");
		UnityEngine.Debug.Log(stringBuilder.ToString());
	}

	[Conditional("DEBUG")]
	public static void PrintResults()
	{
		TimeSpan timeSpan = DateTime.UtcNow - startTime;
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("============================\n\t\t\t\tProfile results:\n============================\n");
		foreach (KeyValuePair<string, ProfilePoint> profile in profiles)
		{
			double totalMilliseconds = profile.Value.totalTime.TotalMilliseconds;
			int totalCalls = profile.Value.totalCalls;
			if (totalCalls >= 1)
			{
				stringBuilder.Append("\nProfile ");
				stringBuilder.Append(profile.Key);
				stringBuilder.Append(" took ");
				stringBuilder.Append(totalMilliseconds.ToString("0"));
				stringBuilder.Append(" ms to complete over ");
				stringBuilder.Append(totalCalls);
				stringBuilder.Append(" iteration");
				if (totalCalls != 1)
				{
					stringBuilder.Append("s");
				}
				stringBuilder.Append(", averaging ");
				stringBuilder.Append((totalMilliseconds / (double)totalCalls).ToString("0.0"));
				stringBuilder.Append(" ms per call");
			}
		}
		stringBuilder.Append("\n\n============================\n\t\tTotal runtime: ");
		stringBuilder.Append(timeSpan.TotalSeconds.ToString("F3"));
		stringBuilder.Append(" seconds\n============================");
		UnityEngine.Debug.Log(stringBuilder.ToString());
	}
}
