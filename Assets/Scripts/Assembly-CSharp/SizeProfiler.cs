using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using Pathfinding;
using UnityEngine;

public class SizeProfiler
{
	public struct ProfileSizePoint
	{
		public long lastBegin;

		public long totalSize;

		public bool open;
	}

	private static Dictionary<string, ProfileSizePoint> profiles = new Dictionary<string, ProfileSizePoint>();

	private static string lastOpen = string.Empty;

	private static bool hasClosed = false;

	public static void Initialize()
	{
		profiles.Clear();
	}

	[Conditional("SizeProfile")]
	public static void Begin(string s, BinaryWriter stream)
	{
	}

	[Conditional("SizeProfile")]
	public static void Begin(string s, BinaryWriter stream, bool autoClosing)
	{
	}

	[Conditional("SizeProfile")]
	public static void Begin(string s, Stream stream, bool autoClosing)
	{
		if (hasClosed || profiles.ContainsKey(lastOpen))
		{
		}
		ProfileSizePoint value = default(ProfileSizePoint);
		if (!profiles.ContainsKey(s))
		{
			profiles[s] = default(ProfileSizePoint);
		}
		else
		{
			value = profiles[s];
		}
		if (value.open)
		{
			UnityEngine.Debug.LogWarning("Opening an already open entry (" + s + ")");
		}
		value.lastBegin = stream.Position;
		value.open = true;
		if (autoClosing)
		{
			hasClosed = false;
			lastOpen = s;
		}
		profiles[s] = value;
	}

	[Conditional("SizeProfile")]
	public static void End(string s, BinaryWriter stream)
	{
	}

	[Conditional("SizeProfile")]
	public static void End(string s, Stream stream)
	{
		if (!profiles.ContainsKey(s))
		{
			UnityEngine.Debug.LogError("Can't end profile before one has started (" + s + ")");
			return;
		}
		ProfileSizePoint value = profiles[s];
		if (!value.open)
		{
			UnityEngine.Debug.LogWarning("Cannot close an already closed entry (" + s + ")");
			return;
		}
		hasClosed = true;
		value.totalSize += stream.Position - value.lastBegin;
		value.open = false;
		profiles[s] = value;
	}

	[Conditional("SizeProfile")]
	public static void Log()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("============================\n\t\t\t\tSize Profile results:\n============================\n");
		foreach (KeyValuePair<string, ProfileSizePoint> profile in profiles)
		{
			stringBuilder.Append(profile.Key);
			stringBuilder.Append("\tused\t");
			stringBuilder.Append(Mathfx.FormatBytes((int)profile.Value.totalSize));
			stringBuilder.Append("\n");
		}
		UnityEngine.Debug.Log(stringBuilder.ToString());
	}
}
