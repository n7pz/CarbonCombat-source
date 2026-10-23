using UnityEngine;

public class Playtomic : MonoBehaviour
{
	private long gameid;

	private string gameguid;

	private string sourceUrl;

	private Playtomic_Log log;

	private Playtomic_Data data;

	private Playtomic_Leaderboards leaderboards;

	private Playtomic_PlayerLevels playerlevels;

	private Playtomic_GeoIP geoip;

	private Playtomic_Link link;

	private Playtomic_GameVars gamevars;

	private Playtomic_Parse parse;

	private static Playtomic _instance;

	public static long GameId
	{
		get
		{
			return _instance.gameid;
		}
	}

	public static string GameGuid
	{
		get
		{
			return _instance.gameguid;
		}
	}

	public static string SourceUrl
	{
		get
		{
			return _instance.sourceUrl;
		}
	}

	public static Playtomic API
	{
		get
		{
			return _instance;
		}
	}

	public static Playtomic_Log Log
	{
		get
		{
			return _instance.log;
		}
	}

	public static Playtomic_Data Data
	{
		get
		{
			return _instance.data;
		}
	}

	public static Playtomic_Leaderboards Leaderboards
	{
		get
		{
			return _instance.leaderboards;
		}
	}

	public static Playtomic_PlayerLevels PlayerLevels
	{
		get
		{
			return _instance.playerlevels;
		}
	}

	public static Playtomic_GeoIP GeoIP
	{
		get
		{
			return _instance.geoip;
		}
	}

	public static Playtomic_Link Link
	{
		get
		{
			return _instance.link;
		}
	}

	public static Playtomic_GameVars GameVars
	{
		get
		{
			return _instance.gamevars;
		}
	}

	public static Playtomic_Parse Parse
	{
		get
		{
			return _instance.parse;
		}
	}

	public static void Initialize(long gameid, string gameguid, string apikey)
	{
		if (!(_instance != null))
		{
			GameObject gameObject = new GameObject("playtomic");
			Object.DontDestroyOnLoad(gameObject);
			_instance = gameObject.AddComponent("Playtomic") as Playtomic;
			_instance.gameid = gameid;
			_instance.gameguid = gameguid;
			_instance.sourceUrl = ((!string.IsNullOrEmpty(Application.absoluteURL)) ? Application.absoluteURL : "http://localhost/");
			_instance.log = new Playtomic_Log();
			_instance.data = new Playtomic_Data();
			_instance.leaderboards = new Playtomic_Leaderboards();
			_instance.playerlevels = new Playtomic_PlayerLevels();
			_instance.geoip = new Playtomic_GeoIP();
			_instance.link = new Playtomic_Link();
			_instance.gamevars = new Playtomic_GameVars();
			_instance.parse = new Playtomic_Parse();
			Playtomic_Request.Initialise();
			Playtomic_Data.Initialise(apikey);
			Playtomic_GameVars.Initialise(apikey);
			Playtomic_Leaderboards.Initialise(apikey);
			Playtomic_GeoIP.Initialise(apikey);
			Playtomic_PlayerLevels.Initialise(apikey);
			Playtomic_Parse.Initialise(apikey);
		}
	}
}
