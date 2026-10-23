using System.Collections.Generic;
using UnityEngine;

public class LumosLogs
{
	private static string[] lumosIgnore = new string[1] { "You are trying to load data from a www stream which had the following error when downloading. Failed downloading http://www.uselumos.com/" };

	private static List<Dictionary<string, object>> logs = new List<Dictionary<string, object>>();

	private static readonly Dictionary<LogType, string> typeLabels = new Dictionary<LogType, string>
	{
		{
			LogType.Assert,
			"assertion"
		},
		{
			LogType.Error,
			"error"
		},
		{
			LogType.Exception,
			"exception"
		},
		{
			LogType.Log,
			"info"
		},
		{
			LogType.Warning,
			"warning"
		}
	};

	public static string[] toIgnore { get; set; }

	private LumosLogs()
	{
	}

	public static void Record(string message, string stackTrace, LogType type)
	{
		if (message.StartsWith("[Lumos]") || (type == LogType.Log && !Lumos.instance.recordLogs) || (type == LogType.Warning && !Lumos.instance.recordWarnings) || (type == LogType.Error && !Lumos.instance.recordErrors) || (type == LogType.Exception && !Lumos.instance.recordErrors) || type == LogType.Assert)
		{
			return;
		}
		if (toIgnore != null)
		{
			string[] array = toIgnore;
			foreach (string value in array)
			{
				if (message.StartsWith(value))
				{
					return;
				}
			}
		}
		string[] array2 = lumosIgnore;
		foreach (string value2 in array2)
		{
			if (message.StartsWith(value2))
			{
				return;
			}
		}
		for (int k = 0; k < logs.Count; k++)
		{
			Dictionary<string, object> dictionary = logs[k];
			if ((string)dictionary["type"] == typeLabels[type] && (string)dictionary["message"] == message && (string)dictionary["stack_trace"] == stackTrace)
			{
				dictionary["total"] = (int)dictionary["total"] + 1;
				return;
			}
		}
		Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
		dictionary2.Add("type", typeLabels[type]);
		dictionary2.Add("message", message);
		dictionary2.Add("stack_trace", stackTrace);
		dictionary2.Add("level", Application.loadedLevelName);
		dictionary2.Add("total", 1);
		dictionary2.Add("hash", LumosUtil.MD5Hash(typeLabels[type], message, stackTrace));
		Dictionary<string, object> item = dictionary2;
		logs.Add(item);
	}

	public static void Send()
	{
		if (logs.Count != 0)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("logs", logs);
			Dictionary<string, object> parameters = dictionary;
			LumosWWW.Send("logs.record", parameters, delegate
			{
				logs.Clear();
			}, delegate
			{
				Lumos.LogWarning("Log messages not sent. Will try again at next timer interval.");
			});
		}
	}
}
