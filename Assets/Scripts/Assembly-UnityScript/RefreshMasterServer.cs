using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using Photon;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class RefreshMasterServer : Photon.MonoBehaviour
{
	[Serializable]
	internal sealed class _0024OnPhotonPlayerDisconnected_00244923 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal int _0024playerCount_00244924;

			internal NetPlayer _0024np_00244925;

			internal IEnumerator _0024_0024iterator_0024343_00244926;

			internal PhotonPlayer _0024player_00244927;

			internal RefreshMasterServer _0024self__00244928;

			public _0024(PhotonPlayer player, RefreshMasterServer self_)
			{
				_0024player_00244927 = player;
				_0024self__00244928 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					result = (YieldDefault(2) ? 1 : 0);
					break;
				case 2:
					_0024self__00244928.StartCoroutine_Auto(_0024self__00244928.removeplayer(_0024player_00244927));
					result = (YieldDefault(3) ? 1 : 0);
					break;
				case 3:
					result = (YieldDefault(4) ? 1 : 0);
					break;
				case 4:
					result = (YieldDefault(5) ? 1 : 0);
					break;
				case 5:
					result = (YieldDefault(6) ? 1 : 0);
					break;
				case 6:
					_0024playerCount_00244924 = default(int);
					_0024_0024iterator_0024343_00244926 = UnityRuntimeServices.GetEnumerator(SpawningScript.netPlayers);
					while (_0024_0024iterator_0024343_00244926.MoveNext())
					{
						object obj = _0024_0024iterator_0024343_00244926.Current;
						if (!(obj is NetPlayer))
						{
							obj = RuntimeServices.Coerce(obj, typeof(NetPlayer));
						}
						_0024np_00244925 = (NetPlayer)obj;
						if (_0024np_00244925.team != string.Empty)
						{
							_0024playerCount_00244924++;
						}
					}
					if (_0024playerCount_00244924 == 1 && AuthGameObject.gametype != "Freeplay" && personjoined)
					{
						personjoined = true;
						GameObject.Find("GUI/GameScores").SendMessage("showEndOfRound");
					}
					result = (YieldDefault(7) ? 1 : 0);
					break;
				case 7:
					result = (YieldDefault(8) ? 1 : 0);
					break;
				case 8:
					_0024self__00244928.ht.Remove(_0024player_00244927);
					_0024self__00244928.calcAvgXP();
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal PhotonPlayer _0024player_00244929;

		internal RefreshMasterServer _0024self__00244930;

		public _0024OnPhotonPlayerDisconnected_00244923(PhotonPlayer player, RefreshMasterServer self_)
		{
			_0024player_00244929 = player;
			_0024self__00244930 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024player_00244929, _0024self__00244930);
		}
	}

	[Serializable]
	internal sealed class _0024removeplayer_00244931 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal int _0024redTeam_00244932;

			internal int _0024blueTeam_00244933;

			internal NetPlayer _0024np_00244934;

			internal IEnumerator _0024_0024iterator_0024342_00244935;

			internal RefreshMasterServer _0024self__00244936;

			public _0024(RefreshMasterServer self_)
			{
				_0024self__00244936 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					result = (YieldDefault(2) ? 1 : 0);
					break;
				case 2:
					result = (YieldDefault(3) ? 1 : 0);
					break;
				case 3:
					result = (YieldDefault(4) ? 1 : 0);
					break;
				case 4:
					_0024self__00244936.teamGUI.SendMessage("refreshListAll");
					_0024redTeam_00244932 = 0;
					_0024blueTeam_00244933 = 0;
					_0024_0024iterator_0024342_00244935 = UnityRuntimeServices.GetEnumerator(SpawningScript.netPlayers);
					while (_0024_0024iterator_0024342_00244935.MoveNext())
					{
						object obj = _0024_0024iterator_0024342_00244935.Current;
						if (!(obj is NetPlayer))
						{
							obj = RuntimeServices.Coerce(obj, typeof(NetPlayer));
						}
						_0024np_00244934 = (NetPlayer)obj;
						if (_0024np_00244934.team == "red")
						{
							_0024redTeam_00244932++;
						}
						if (_0024np_00244934.team == "blue")
						{
							_0024blueTeam_00244933++;
						}
					}
					if (_0024redTeam_00244932 == _0024blueTeam_00244933)
					{
						((PhotonView)_0024self__00244936.gameObject.GetComponent(typeof(PhotonView))).RPC("noUnderdog", PhotonTargets.All);
					}
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal RefreshMasterServer _0024self__00244937;

		public _0024removeplayer_00244931(RefreshMasterServer self_)
		{
			_0024self__00244937 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00244937);
		}
	}

	public MasterServerScript gname;

	private float timer;

	public string playerlistred;

	public string playerlistblue;

	public int redcount;

	public int bluecount;

	public int myteam;

	public GameObject teamGUI;

	public AuthGameObject authgameobject;

	public CWFLoader cwf;

	public SpawningScript spwnsrc;

	public HeadlesssDedServer headless;

	public PreloaderExplosion pex;

	public DisplayTopPlayers dplayer;

	[NonSerialized]
	public static bool personjoined;

	[NonSerialized]
	public static bool isunderdog;

	[NonSerialized]
	public static bool forceAIrefresh;

	private bool dedPersonJoined;

	private bool sendOnce;

	private bool dedUpdate;

	private int calculatedXP;

	private Hashtable ht;

	[NonSerialized]
	public static string bannedList = string.Empty;

	public RefreshMasterServer()
	{
		timer = 2f;
		playerlistred = string.Empty;
		playerlistblue = string.Empty;
		calculatedXP = 500;
		ht = new Hashtable();
	}

	[RPC]
	public virtual void dedPersonJoinedFunc()
	{
		dedPersonJoined = true;
	}

	public virtual void calcAvgXP()
	{
		int num = default(int);
		int num2 = default(int);
		int i = 0;
		PhotonPlayer[] playerList = PhotonNetwork.playerList;
		for (int length = playerList.Length; i < length; i++)
		{
			if (ht.ContainsKey(playerList[i]))
			{
				num = RuntimeServices.UnboxInt32(RuntimeServices.InvokeBinaryOperator("op_Addition", num, ht[playerList[i]]));
				num2++;
			}
		}
		calculatedXP = (int)Mathf.Round(num / num2);
	}

	public virtual void Start()
	{
		bannedList = string.Empty;
		((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("myXP", PhotonTargets.AllBuffered, DisplayTopPlayers.mypointsStat);
	}

	[RPC]
	public virtual void myXP(int xp, PhotonMessageInfo info)
	{
		if (!ht.ContainsKey(info.sender))
		{
			ht.Add(info.sender, xp);
			calcAvgXP();
		}
	}

	public virtual void Update()
	{
		if (PhotonNetwork.isMasterClient)
		{
			if (forceAIrefresh)
			{
				forceAIrefresh = false;
				teamGUI.SendMessage("refreshListAll");
			}
			if (!(timer > 0f))
			{
				string username = AuthGameObject.username;
				if ((SpawningScript.team2 != string.Empty || HeadlesssDedServer.isServerHost) && PhotonNetwork.room != null)
				{
					Hashtable hashtable = new Hashtable();
					hashtable.Add("comment", username + ((!HeadlesssDedServer.isServerHost) ? string.Empty : " (D)") + "|" + AuthGameObject.gametype + "|" + SpawningScript.activeplayers + "|" + SpawningScript.spectators + "|" + AuthGameObject.whirldurl + ((!(CWFLoader.worldData != string.Empty)) ? string.Empty : "[CustomMap]") + "|" + ((!AuthGameObject.showTutorial) ? "THIS*SERVER*IS*JOINABLE" : "DO*NOT*JOIN*THIS") + "|" + ((!AuthGameObject.isAIserver) ? string.Empty : ("_AI" + ((!(MasterServerScript.ainame2 != string.Empty)) ? string.Empty : "2") + ((!(MasterServerScript.ainame3 != string.Empty)) ? string.Empty : "3"))) + "|" + calculatedXP + "|" + bannedList);
					PhotonNetwork.room.SetCustomProperties(hashtable);
				}
				timer = 2f;
			}
			else
			{
				timer -= Time.deltaTime;
			}
		}
		else
		{
			personjoined = true;
		}
		int num = default(int);
		IEnumerator enumerator = UnityRuntimeServices.GetEnumerator(SpawningScript.netPlayers);
		while (enumerator.MoveNext())
		{
			object obj = enumerator.Current;
			if (!(obj is NetPlayer))
			{
				obj = RuntimeServices.Coerce(obj, typeof(NetPlayer));
			}
			NetPlayer netPlayer = (NetPlayer)obj;
			if (netPlayer.team != string.Empty)
			{
				num++;
			}
		}
	}

	public virtual void Awake()
	{
		personjoined = false;
		isunderdog = false;
		forceAIrefresh = false;
		if (AuthGameObject.isAIserver)
		{
			personjoined = true;
		}
	}

	public virtual IEnumerator OnPhotonPlayerDisconnected(PhotonPlayer player)
	{
		return new _0024OnPhotonPlayerDisconnected_00244923(player, this).GetEnumerator();
	}

	public virtual void teamset(int t)
	{
		myteam = t;
	}

	[RPC]
	public virtual void updateclientsredandblue(string t, int count, string t1, int count1)
	{
		playerlistred = t;
		redcount = UnityScript.Lang.Extensions.get_length((System.Array)t.Split("\n"[0]));
		if (playerlistred == null)
		{
			playerlistred = string.Empty;
		}
		teamGUI.SendMessage("setredlist", playerlistred);
		teamGUI.SendMessage("setredcount", count);
		playerlistblue = t1;
		if (playerlistblue == null)
		{
			playerlistblue = string.Empty;
		}
		bluecount = UnityScript.Lang.Extensions.get_length((System.Array)t1.Split("\n"[0]));
		teamGUI.SendMessage("setbluelist", playerlistblue);
		teamGUI.SendMessage("setbluecount", count1);
	}

	public virtual IEnumerator removeplayer(PhotonPlayer t)
	{
		return new _0024removeplayer_00244931(this).GetEnumerator();
	}

	[RPC]
	public virtual void setUnderdog(string t)
	{
		if (t == SpawningScript.team2)
		{
			isunderdog = true;
		}
	}

	[RPC]
	public virtual void noUnderdog()
	{
		isunderdog = false;
	}

	public virtual void balanceTeams()
	{
		if (Mathf.Abs(redcount - bluecount) <= 1)
		{
			return;
		}
		int num = default(int);
		int num2 = default(int);
		UnityScript.Lang.Array array = new UnityScript.Lang.Array();
		UnityScript.Lang.Array array2 = new UnityScript.Lang.Array();
		IEnumerator enumerator = UnityRuntimeServices.GetEnumerator(SpawningScript.netPlayers);
		while (enumerator.MoveNext())
		{
			object obj = enumerator.Current;
			if (!(obj is NetPlayer))
			{
				obj = RuntimeServices.Coerce(obj, typeof(NetPlayer));
			}
			NetPlayer netPlayer = (NetPlayer)obj;
			if (netPlayer.team == "red")
			{
				num++;
				array.Add(netPlayer.username);
				UnityRuntimeServices.Update(enumerator, netPlayer);
			}
			if (netPlayer.team == "blue")
			{
				num2++;
				array2.Add(netPlayer.username);
				UnityRuntimeServices.Update(enumerator, netPlayer);
			}
		}
		if (num > num2)
		{
			for (int i = 0; (float)i < Mathf.Floor((num - num2) / 2); i++)
			{
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("changeTeams", PhotonTargets.All, array[i]);
				IEnumerator enumerator2 = UnityRuntimeServices.GetEnumerator(SpawningScript.netPlayers);
				while (enumerator2.MoveNext())
				{
					object current = enumerator2.Current;
					if (RuntimeServices.EqualityOperator(UnityRuntimeServices.GetProperty(current, "username"), array[i]))
					{
						RuntimeServices.SetProperty(current, "team", "blue");
						UnityRuntimeServices.Update(enumerator2, current);
					}
				}
				teamGUI.SendMessage("refreshListAll");
			}
		}
		else
		{
			if (num2 <= num)
			{
				return;
			}
			array = playerlistblue.Split("\n"[0]);
			for (int i = 0; (float)i < Mathf.Floor((num2 - num) / 2); i++)
			{
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("changeTeams", PhotonTargets.All, array[i]);
				IEnumerator enumerator3 = UnityRuntimeServices.GetEnumerator(SpawningScript.netPlayers);
				while (enumerator3.MoveNext())
				{
					object current2 = enumerator3.Current;
					if (RuntimeServices.EqualityOperator(UnityRuntimeServices.GetProperty(current2, "username"), array[i]))
					{
						RuntimeServices.SetProperty(current2, "team", "red");
						UnityRuntimeServices.Update(enumerator3, current2);
					}
				}
				teamGUI.SendMessage("refreshListAll");
			}
		}
	}

	[RPC]
	public virtual void changeTeams(string u)
	{
		if (AuthGameObject.username == u)
		{
			GameObject.Find("/Spawn Point").SendMessage("setteam", (!(SpawningScript.team2 == "red")) ? "red" : "blue");
			GameObject.Find("/Spawn Point").SendMessage("switchTeams");
			teamset((SpawningScript.team2 == "red") ? 1 : 2);
		}
	}
}
