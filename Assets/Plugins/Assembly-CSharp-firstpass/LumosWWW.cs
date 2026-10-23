using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class LumosWWW
{
	public delegate void SuccessHandler();

	public delegate void ErrorHandler();

	private static string _url = "http://www.uselumos.com/api/";

	private static readonly Hashtable headers = new Hashtable { { "Content-type", "application/json" } };

	public static string url
	{
		private get
		{
			return _url;
		}
		set
		{
			_url = value;
		}
	}

	public static Coroutine Send(string method, Dictionary<string, object> parameters)
	{
		return Lumos.RunRoutine(SendCoroutine(method, parameters, null, null));
	}

	public static Coroutine Send(string method, Dictionary<string, object> parameters, SuccessHandler successCallback)
	{
		return Lumos.RunRoutine(SendCoroutine(method, parameters, successCallback, null));
	}

	public static Coroutine Send(string method, Dictionary<string, object> parameters, SuccessHandler successCallback, ErrorHandler errorCallback)
	{
		return Lumos.RunRoutine(SendCoroutine(method, parameters, successCallback, errorCallback));
	}

	private static IEnumerator SendCoroutine(string method, Dictionary<string, object> parameters, SuccessHandler successCallback, ErrorHandler errorCallback)
	{
		if (Application.isEditor && !Lumos.instance.runInEditor)
		{
			yield break;
		}
		if (Application.internetReachability == NetworkReachability.NotReachable)
		{
			if (errorCallback != null)
			{
				errorCallback();
			}
			yield break;
		}
		parameters.Add("app_id", Lumos.appId);
		string json = LumosUtil.Json.Serialize(parameters);
		WWW www = new WWW(postData: Encoding.ASCII.GetBytes(json), url: url + method, headers: headers);
		yield return www;
		Lumos.Log("Request: " + json);
		Lumos.Log("Response: " + www.text);
		try
		{
			if (www.error != null)
			{
				throw new Exception(www.error);
			}
			IDictionary response = LumosUtil.Json.Deserialize(www.text) as IDictionary;
			if (response.Count != 0 && response.Contains("result"))
			{
				object result = response["result"];
				Lumos.Log("Success: " + result);
			}
			if (successCallback != null)
			{
				successCallback();
			}
		}
		catch (Exception ex)
		{
			Lumos.LogError("Failure: " + ex.Message);
			if (errorCallback != null)
			{
				errorCallback();
			}
		}
	}
}
