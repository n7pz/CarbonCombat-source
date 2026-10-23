using System.Collections;
using UnityEngine;

public class Lumos : MonoBehaviour
{
	private delegate void MessageLogger(object message);

	public const string version = "0.8";

	private static string _playerId;

	private static uint _timerInterval = 30u;

	private static bool timerPaused;

	public string secretKey;

	public bool runInEditor;

	public bool recordPresetEvents;

	public bool recordErrors;

	public bool recordWarnings;

	public bool recordLogs;

	public static Lumos instance { get; private set; }

	public static bool debug { get; set; }

	public static string appId { get; private set; }

	public static string playerId
	{
		get
		{
			if (_playerId == null)
			{
				_playerId = PlayerPrefs.GetString(LumosUtil.playerIdPrefsKey);
			}
			return _playerId;
		}
		private set
		{
			_playerId = value;
			PlayerPrefs.SetString(LumosUtil.playerIdPrefsKey, value);
		}
	}

	public static bool hasPlayer
	{
		get
		{
			return PlayerPrefs.HasKey(LumosUtil.playerIdPrefsKey);
		}
	}

	public static uint timerInterval
	{
		get
		{
			return _timerInterval;
		}
		set
		{
			_timerInterval = value;
		}
	}

	private Lumos()
	{
	}

	private void Awake()
	{
		if (instance != null)
		{
			Log("Destroy");
			Object.Destroy(base.gameObject);
			return;
		}
		instance = this;
		Object.DontDestroyOnLoad(this);
		appId = secretKey.Split('-')[0];
		if (appId == null || appId == string.Empty)
		{
			Debug.LogWarning("Lumos secret key not set. No information will be sent.");
			Object.Destroy(base.gameObject);
			return;
		}
		if (recordPresetEvents)
		{
			base.gameObject.AddComponent<LumosEvents>();
		}
		Application.RegisterLogCallback(LumosLogs.Record);
	}

	private void Start()
	{
		if (hasPlayer)
		{
			Log("Using existing player " + playerId);
			LumosApp.Ping();
		}
		else
		{
			playerId = LumosUtil.GeneratePlayerId();
			Log("Using new player " + playerId);
			LumosApp.Ping(true);
			LumosSystemInfo.Record();
		}
		RunRoutine(SendQueuedRoutine());
	}

	private void OnGUI()
	{
		LumosFeedback.OnGUI();
	}

	private void OnLevelWasLoaded()
	{
		SendQueued();
	}

	public void SendQueued()
	{
		LumosLogs.Send();
		LumosEvents.Send();
	}

	private IEnumerator SendQueuedRoutine()
	{
		yield return new WaitForSeconds(timerInterval);
		if (!timerPaused)
		{
			SendQueued();
		}
		RunRoutine(SendQueuedRoutine());
	}

	public static void PauseTimer()
	{
		timerPaused = true;
	}

	public static void ResumeTimer()
	{
		timerPaused = false;
	}

	public static Coroutine RunRoutine(IEnumerator routine)
	{
		if (instance == null)
		{
			LogError("The Lumos game object must be instantiated before its methods can be used.");
			return null;
		}
		return instance.StartCoroutine(routine);
	}

	public static void Log(object message)
	{
		LogMessage(Debug.Log, message);
	}

	public static void LogWarning(object message)
	{
		LogMessage(Debug.LogWarning, message);
	}

	public static void LogError(object message)
	{
		LogMessage(Debug.LogError, message);
	}

	private static void LogMessage(MessageLogger logger, object message)
	{
		if (!(instance == null) && debug)
		{
			logger("[Lumos] " + message.ToString());
		}
	}

	public static void Event(string name)
	{
		LumosEvents.Record(name, null, true);
	}

	public static void Event(string name, int value)
	{
		LumosEvents.Record(name, value, true);
	}

	public static void Event(string name, float value)
	{
		LumosEvents.Record(name, value, true);
	}

	public static void Event(string name, bool repeatable)
	{
		LumosEvents.Record(name, null, repeatable);
	}

	public static void Event(string name, int value, bool repeatable)
	{
		LumosEvents.Record(name, value, repeatable);
	}

	public static void Event(string name, float value, bool repeatable)
	{
		LumosEvents.Record(name, value, repeatable);
	}

	public static void Feedback(string message)
	{
		LumosFeedback.Record(message, null, null);
	}

	public static void Feedback(string message, string email)
	{
		LumosFeedback.Record(message, email, null);
	}

	public static void Feedback(string message, string email, string type)
	{
		LumosFeedback.Record(message, email, type);
	}

	public static void Realtime(params string[] message)
	{
		LumosRealtime.Record(message);
	}
}
