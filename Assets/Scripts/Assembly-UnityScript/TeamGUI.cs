using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using Photon;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class TeamGUI : Photon.MonoBehaviour
{
	[Serializable]
	internal sealed class _0024Start_00244955 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string _0024descString_00244956;

			internal string _0024username_00244957;

			internal GameObject _0024go_00244958;

			internal GameObject _0024rain_00244959;

			internal int _0024ran_00244960;

			internal GameObject _0024go_00244961;

			internal int _0024_00241252_00244962;

			internal GameObject[] _0024_00241253_00244963;

			internal int _0024_00241254_00244964;

			internal int _0024_00241256_00244965;

			internal GameObject[] _0024_00241257_00244966;

			internal int _0024_00241258_00244967;

			internal TeamGUI _0024self__00244968;

			public _0024(TeamGUI self_)
			{
				_0024self__00244968 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (!AuthGameObject.showTutorial)
					{
						_0024descString_00244956 = string.Empty;
						if (AuthGameObject.gametype == "Freeplay")
						{
							_0024descString_00244956 = "Freeplay: Have fun with friends without worrying about rounds, XP or credits.";
						}
						if (AuthGameObject.gametype == "Deathmatch")
						{
							_0024descString_00244956 = "Deathmatch: Classic free-for-all; there are no teams and everyone is your enemy.";
						}
						if (AuthGameObject.gametype == "Survival")
						{
							_0024descString_00244956 = "Survival: Everyone starts off with basic weapons and no armor. Scavenge for gear in crates around the map.";
						}
						if (AuthGameObject.gametype == "Team Death-Match")
						{
							_0024descString_00244956 = "Team Death-Match: Work with your teammates and shoot anyone not on your team.";
						}
						if (AuthGameObject.gametype == "Capture the Flag")
						{
							_0024descString_00244956 = "Capture the Flag: Steal and capture the other team's flag while defending your own.";
						}
						GameObject.Find("/AuthGameObject").SendMessage("fadeInGameMode", _0024descString_00244956);
					}
					if (AuthGameObject.gametype == "Freeplay" || AuthGameObject.gametype == "Deathmatch" || AuthGameObject.gametype == "Survival")
					{
						_0024self__00244968.nogui = true;
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					if (AuthGameObject.isAIserver)
					{
						if (PhotonNetwork.isMasterClient)
						{
							_0024ran_00244960 = UnityEngine.Random.Range(1, 3);
							if (_0024ran_00244960 == 1 || AuthGameObject.showTutorial)
							{
								_0024self__00244968.redteam = MasterServerScript.ainame + "\n";
								_0024self__00244968.redcount = 1;
								_0024self__00244968.spawnpoint.SendMessage("spawnAI", 1);
								if (MasterServerScript.ainame2 != string.Empty)
								{
									_0024self__00244968.blueteam = MasterServerScript.ainame2 + "\n";
									_0024self__00244968.bluecount = 1;
									if (MasterServerScript.ainame3 != string.Empty)
									{
										_0024self__00244968.blueteam += MasterServerScript.ainame3 + "\n";
										_0024self__00244968.bluecount++;
									}
								}
							}
							else
							{
								_0024self__00244968.blueteam = MasterServerScript.ainame + "\n";
								_0024self__00244968.bluecount = 1;
								_0024self__00244968.spawnpoint.SendMessage("spawnAI", 2);
								if (MasterServerScript.ainame2 != string.Empty)
								{
									_0024self__00244968.redteam = MasterServerScript.ainame2 + "\n";
									_0024self__00244968.redcount = 1;
									if (MasterServerScript.ainame3 != string.Empty)
									{
										_0024self__00244968.redteam += MasterServerScript.ainame3 + "\n";
										_0024self__00244968.redcount++;
									}
								}
							}
							if (AuthGameObject.showTutorial)
							{
								_0024self__00244968.spawnpoint.SendMessage("setteam", (_0024self__00244968.redcount <= _0024self__00244968.bluecount) ? "red" : "blue");
								_0024username_00244957 = AuthGameObject.username;
								_0024self__00244968.refresh.SendMessage("teamset", (_0024self__00244968.redcount <= _0024self__00244968.bluecount) ? 1 : 0);
								_0024_00241256_00244965 = 0;
								_0024_00241257_00244966 = (GameObject[])UnityEngine.Object.FindObjectsOfType(typeof(GameObject));
								for (_0024_00241258_00244967 = _0024_00241257_00244966.Length; _0024_00241256_00244965 < _0024_00241258_00244967; _0024_00241256_00244965++)
								{
									_0024_00241257_00244966[_0024_00241256_00244965].SendMessage("OnNetworkLoadedLevel", SendMessageOptions.DontRequireReceiver);
								}
								_0024rain_00244959 = GameObject.Find("/Rain");
								UnityEngine.Object.Destroy(_0024rain_00244959);
								_0024self__00244968.enabled = false;
							}
						}
					}
					else if (PhotonNetwork.isMasterClient)
					{
						_0024self__00244968.choosemessage = "Choose a Team";
					}
					goto IL_05c3;
				case 2:
					result = (YieldDefault(3) ? 1 : 0);
					break;
				case 3:
					result = (YieldDefault(4) ? 1 : 0);
					break;
				case 4:
					result = (YieldDefault(5) ? 1 : 0);
					break;
				case 5:
					if (Application.loadedLevelName == "Forge_Scene")
					{
						goto case 6;
					}
					goto IL_0198;
				case 6:
					if (CWFLoader.isLoading)
					{
						result = (YieldDefault(6) ? 1 : 0);
						break;
					}
					goto IL_0198;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0198:
					_0024self__00244968.spawnpoint.SendMessage("setteam", "red");
					_0024username_00244957 = AuthGameObject.username;
					_0024self__00244968.refresh.SendMessage("teamset", 1);
					if (AuthGameObject.isAIserver && PhotonNetwork.isMasterClient)
					{
						_0024self__00244968.spawnpoint.SendMessage("spawnAI", (object)0);
					}
					_0024_00241252_00244962 = 0;
					_0024_00241253_00244963 = (GameObject[])UnityEngine.Object.FindObjectsOfType(typeof(GameObject));
					for (_0024_00241254_00244964 = _0024_00241253_00244963.Length; _0024_00241252_00244962 < _0024_00241254_00244964; _0024_00241252_00244962++)
					{
						_0024_00241253_00244963[_0024_00241252_00244962].SendMessage("OnNetworkLoadedLevel", SendMessageOptions.DontRequireReceiver);
					}
					_0024rain_00244959 = GameObject.Find("/Rain");
					UnityEngine.Object.Destroy(_0024rain_00244959);
					_0024self__00244968.enabled = false;
					goto IL_05c3;
					IL_05c3:
					if (!PhotonNetwork.isMasterClient)
					{
					}
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal TeamGUI _0024self__00244969;

		public _0024Start_00244955(TeamGUI self_)
		{
			_0024self__00244969 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00244969);
		}
	}

	public GUIStyle backgroundstyle;

	public GUIStyle redbutton;

	public GUIStyle bluebutton;

	public string redteam;

	public string blueteam;

	public int redcount;

	public int bluecount;

	public GameObject spawnpoint;

	public GUIStyle textstyle;

	public GameObject refresh;

	public SpectatorController speccon;

	public float timer;

	public string choosemessage;

	public AuthGameObject authgameobject;

	public InitWorld iw;

	public MasterServerScript mserver;

	public AudioController acon;

	public SpawningScript spawnsrc;

	public CWFLoader cwf;

	private bool connectionSetup;

	private bool nogui;

	public TeamGUI()
	{
		timer = 5f;
		choosemessage = "Loading Teamlists...";
	}

	public virtual void addkiller(string p)
	{
		spawnpoint.SendMessage("addkiller", p);
	}

	public virtual void addvictim(string p)
	{
		spawnpoint.SendMessage("addvictim", p);
	}

	public virtual void Update()
	{
		if (AuthGameObject.whirldurl == string.Empty || InitWorld.finaldone)
		{
			if (!(timer <= 0f))
			{
				timer -= Time.deltaTime;
			}
			else
			{
				timer = 5f;
			}
		}
		if (PhotonNetwork.isMasterClient)
		{
			return;
		}
		string text = string.Empty;
		string text2 = string.Empty;
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
				text += netPlayer.username + "\n";
				UnityRuntimeServices.Update(enumerator, netPlayer);
			}
			if (netPlayer.team == "blue")
			{
				text2 += netPlayer.username + "\n";
				UnityRuntimeServices.Update(enumerator, netPlayer);
			}
		}
		parseTeamsCallback(text, text2);
	}

	public virtual void refreshListAll()
	{
	}

	[RPC]
	public virtual void parseTeams(PhotonMessageInfo info)
	{
		string text = string.Empty;
		string text2 = string.Empty;
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
				text += netPlayer.username + "\n";
				UnityRuntimeServices.Update(enumerator, netPlayer);
			}
			if (netPlayer.team == "blue")
			{
				text2 += netPlayer.username + "\n";
				UnityRuntimeServices.Update(enumerator, netPlayer);
			}
		}
		((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("parseTeamsCallback", info.sender, text, text2);
	}

	[RPC]
	public virtual void parseTeamsCallback(string r, string b)
	{
		redteam = r;
		blueteam = b;
		redcount = UnityScript.Lang.Extensions.get_length((System.Array)r.Split("\n"[0])) - 1;
		bluecount = UnityScript.Lang.Extensions.get_length((System.Array)b.Split("\n"[0])) - 1;
		connectionSetup = true;
	}

	public virtual IEnumerator Start()
	{
		return new _0024Start_00244955(this).GetEnumerator();
	}

	public virtual void OnGUI()
	{
		if (AudioController.hideGUI || nogui || SpectatorController.iscont)
		{
			return;
		}
		GUI.depth = -4;
		int num = 0;
		if (bluecount > redcount)
		{
			num = 18 * bluecount + 105;
		}
		if (redcount > bluecount)
		{
			num = 18 * redcount + 105;
		}
		if (redcount == bluecount)
		{
			num = 18 * redcount + 105;
		}
		if (num == 0)
		{
			num = 110;
		}
		GUI.BeginGroup(new Rect(Screen.width / 2 - 175, Screen.height / 2 - num / 2, 350f, num));
		if (redteam != string.Empty || (blueteam != string.Empty && choosemessage == "Loading Teamlists..."))
		{
			choosemessage = "Choose a Team";
		}
		GUI.Box(new Rect(0f, 0f, 350f, num), choosemessage, backgroundstyle);
		GUI.Label(new Rect(20f, 90f, 152f, 80f), redteam, textstyle);
		GUI.Label(new Rect(180f, 90f, 152f, 80f), blueteam, textstyle);
		if (connectionSetup || PhotonNetwork.isMasterClient)
		{
			if (redcount < bluecount)
			{
				GUI.enabled = true;
			}
			else
			{
				if (redcount == bluecount)
				{
					GUI.enabled = true;
				}
				if (redcount > bluecount)
				{
					GUI.enabled = false;
				}
			}
		}
		else
		{
			GUI.enabled = false;
		}
		if (GUI.Button(new Rect(20f, 45f, 152f, 32f), "Red Team (" + redcount + ")", redbutton))
		{
			spawnpoint.SendMessage("setteam", "red");
			string username = AuthGameObject.username;
			refresh.SendMessage("teamset", 1);
			int i = 0;
			GameObject[] array = (GameObject[])UnityEngine.Object.FindObjectsOfType(typeof(GameObject));
			for (int length = array.Length; i < length; i++)
			{
				array[i].SendMessage("OnNetworkLoadedLevel", SendMessageOptions.DontRequireReceiver);
			}
			GameObject obj = GameObject.Find("/Rain");
			UnityEngine.Object.Destroy(obj);
			enabled = false;
		}
		if (connectionSetup || PhotonNetwork.isMasterClient)
		{
			if (bluecount < redcount)
			{
				GUI.enabled = true;
			}
			else
			{
				if (bluecount == redcount)
				{
					GUI.enabled = true;
				}
				if (bluecount > redcount)
				{
					GUI.enabled = false;
				}
			}
		}
		else
		{
			GUI.enabled = false;
		}
		if (GUI.Button(new Rect(180f, 45f, 152f, 32f), "Blue Team (" + bluecount + ")", bluebutton))
		{
			spawnpoint.SendMessage("setteam", "blue");
			string username = AuthGameObject.username;
			refresh.SendMessage("teamset", 2);
			int j = 0;
			GameObject[] array2 = (GameObject[])UnityEngine.Object.FindObjectsOfType(typeof(GameObject));
			for (int length2 = array2.Length; j < length2; j++)
			{
				array2[j].SendMessage("OnNetworkLoadedLevel", SendMessageOptions.DontRequireReceiver);
			}
			GameObject obj = GameObject.Find("/Rain");
			UnityEngine.Object.Destroy(obj);
			enabled = false;
		}
		GUI.EndGroup();
	}
}
