using System;
using Boo.Lang.Runtime;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class KongregateAPI : MonoBehaviour
{
	private bool debugmode;

	public bool isKongregate;

	[NonSerialized]
	public static int userId;

	[NonSerialized]
	public static string username = "Guest";

	[NonSerialized]
	public static string gameAuthToken = string.Empty;

	public bool primaryScript;

	public string stat;

	public int statValue;

	[NonSerialized]
	public static bool loggedin;

	[NonSerialized]
	public static bool alreadyreg;

	[NonSerialized]
	public static string regname = string.Empty;

	public KongregateAPI()
	{
		stat = "stat";
	}

	public virtual void OnKongregateAPILoaded(object userInfoString)
	{
		isKongregate = true;
		Debug.Log("ON KONG");
		object target = UnityRuntimeServices.Invoke(userInfoString, "Split", new object[1] { "|"[0] }, typeof(MonoBehaviour));
		userId = RuntimeServices.UnboxInt32(UnityRuntimeServices.Invoke(typeof(UnityBuiltins), "parseInt", new object[1] { RuntimeServices.GetSlice(target, string.Empty, new object[1] { 0 }) }, typeof(MonoBehaviour)));
		object obj = RuntimeServices.GetSlice(target, string.Empty, new object[1] { 1 });
		if (!(obj is string))
		{
			obj = RuntimeServices.Coerce(obj, typeof(string));
		}
		username = (string)obj;
		object obj2 = RuntimeServices.GetSlice(target, string.Empty, new object[1] { 2 });
		if (!(obj2 is string))
		{
			obj2 = RuntimeServices.Coerce(obj2, typeof(string));
		}
		gameAuthToken = (string)obj2;
		loggedin = true;
		Application.ExternalEval("kongregate.services.addEventListener('login', function(){" + "   var services = kongregate.services;" + "   var params=[services.getUserId(), services.getUsername(), services.getGameAuthToken()].join('|');" + "   kongregateUnitySupport.getUnityObject().SendMessage('KongregateAPI', 'OnKongregateUserSignedIn', params);" + "});");
	}

	public virtual void OnKongregateUserSignedIn(object userInfoString)
	{
		isKongregate = true;
		Debug.Log("ON KONG");
		object target = UnityRuntimeServices.Invoke(userInfoString, "Split", new object[1] { "|"[0] }, typeof(MonoBehaviour));
		userId = RuntimeServices.UnboxInt32(UnityRuntimeServices.Invoke(typeof(UnityBuiltins), "parseInt", new object[1] { RuntimeServices.GetSlice(target, string.Empty, new object[1] { 0 }) }, typeof(MonoBehaviour)));
		object obj = RuntimeServices.GetSlice(target, string.Empty, new object[1] { 1 });
		if (!(obj is string))
		{
			obj = RuntimeServices.Coerce(obj, typeof(string));
		}
		username = (string)obj;
		object obj2 = RuntimeServices.GetSlice(target, string.Empty, new object[1] { 2 });
		if (!(obj2 is string))
		{
			obj2 = RuntimeServices.Coerce(obj2, typeof(string));
		}
		gameAuthToken = (string)obj2;
		loggedin = true;
	}

	public virtual void OnGUI()
	{
		if (debugmode)
		{
			if (isKongregate)
			{
				GUILayout.Label("Connected!");
				GUILayout.Label("UserID: " + userId);
				GUILayout.Label("UserName: " + username);
				GUILayout.Label("gameAuthToken: " + gameAuthToken);
			}
			else
			{
				GUILayout.Label("Not Connected");
			}
			GUILayout.BeginHorizontal();
			stat = GUILayout.TextField(stat, GUILayout.Width(100f));
			if (GUILayout.Button("-"))
			{
				statValue = Mathf.Max(0, statValue - 1);
			}
			GUILayout.Label(statValue.ToString());
			if (GUILayout.Button("+"))
			{
				statValue++;
			}
			if (GUILayout.Button("sumbit stat!"))
			{
				Application.ExternalCall("kongregate.stats.submit", stat, statValue);
			}
			GUILayout.EndHorizontal();
		}
	}

	public virtual void SubmitStat(string stat, int val)
	{
		if (isKongregate)
		{
			Application.ExternalCall("kongregate.stats.submit", stat, val);
			Debug.Log("Stat Sumbitted!  " + stat + "   " + val);
		}
	}

	public virtual void Awake()
	{
		bool flag = false;
		KongregateAPI[] array = ((KongregateAPI[])UnityEngine.Object.FindObjectsOfType(typeof(KongregateAPI))) as KongregateAPI[];
		for (int i = 0; i < array.Length - 1; i++)
		{
			if (array[i].primaryScript)
			{
				flag = true;
			}
		}
		if (flag)
		{
			UnityEngine.Object.Destroy(gameObject);
		}
		else
		{
			primaryScript = true;
		}
		UnityEngine.Object.DontDestroyOnLoad(this);
	}

	public virtual void getReg(string s)
	{
		regname = s;
		alreadyreg = true;
		Debug.Log(s);
	}

	public virtual void Start()
	{
		Application.ExternalEval("if(typeof(kongregateUnitySupport) != 'undefined'){" + " kongregateUnitySupport.initAPI('KongregateAPI', 'OnKongregateAPILoaded');" + "}");
		Application.ExternalEval("var i,x,y,ARRcookies=document.cookie.split(';');" + "for (i=0;i<ARRcookies.length;i++) {" + "x=ARRcookies[i].substr(0,ARRcookies[i].indexOf('='));" + "y=ARRcookies[i].substr(ARRcookies[i].indexOf('=')+1);" + "x=x.replace(/^\\s+|\\s+$/g,'');" + "if (x=='sysLogin') {" + "unityObject.getObjectById('unityPlayer').SendMessage('KongregateAPI', 'getReg', unescape(y));" + "}" + "}");
	}

	public virtual void Main()
	{
	}
}
