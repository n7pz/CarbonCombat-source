using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using Photon;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class FPSCalculateHealth : Photon.MonoBehaviour
{
	[Serializable]
	internal sealed class _0024Start_00243817 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal FPSCalculateHealth _0024self__00243818;

			public _0024(FPSCalculateHealth self_)
			{
				_0024self__00243818 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__00243818.photonView.isMine)
					{
						isafking = false;
						_0024self__00243818.healthGUI = GameObject.Find("HealthDisplay");
						_0024self__00243818.chatGUI = GameObject.Find("GUI/Chat");
						_0024self__00243818.tchooseGUI = GameObject.Find("TeamChooseGUI");
						((PhotonView)_0024self__00243818.spawnedFromCar.transform.Find("Colliders/MainBoxCol").GetComponent(typeof(PhotonView))).RPC("uncloak", PhotonTargets.All);
						_0024self__00243818.healthGUI.SendMessage("updatehealthNoEx", _0024self__00243818.currenthealth);
						GameObject.Find("HealthEffect").SendMessage("FadeTo", (100f - _0024self__00243818.currenthealth) / 1.3f);
					}
					if (((GunAndCameraBob)_0024self__00243818.gameObject.GetComponent(typeof(GunAndCameraBob))).team == "red")
					{
						_0024self__00243818.redGlow.emit = true;
						UnityEngine.Object.Destroy(_0024self__00243818.blueGlow.gameObject);
					}
					else
					{
						_0024self__00243818.blueGlow.emit = true;
						UnityEngine.Object.Destroy(_0024self__00243818.redGlow.gameObject);
					}
					goto case 2;
				case 2:
					if (_0024self__00243818.initInvinc > 0f)
					{
						_0024self__00243818.initInvinc = Mathf.Max(0f, _0024self__00243818.initInvinc - Time.deltaTime);
						result = (YieldDefault(2) ? 1 : 0);
						break;
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

		internal FPSCalculateHealth _0024self__00243819;

		public _0024Start_00243817(FPSCalculateHealth self_)
		{
			_0024self__00243819 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00243819);
		}
	}

	[Serializable]
	internal sealed class _0024aiWin_00243820 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal string _0024aiteam_00243821;

			internal string _0024s_00243822;

			internal FPSCalculateHealth _0024self__00243823;

			public _0024(string s, FPSCalculateHealth self_)
			{
				_0024s_00243822 = s;
				_0024self__00243823 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					result = (Yield(2, new WaitForSeconds(UnityEngine.Random.Range(2, 5))) ? 1 : 0);
					break;
				case 2:
					_0024aiteam_00243821 = string.Empty;
					if (_0024s_00243822 == MasterServerScript.ainame)
					{
						if (SpawningScript.aiteamlist == "rbb")
						{
							_0024aiteam_00243821 = "red";
						}
						else
						{
							_0024aiteam_00243821 = "blue";
						}
					}
					if (_0024s_00243822 == MasterServerScript.ainame2)
					{
						if (SpawningScript.aiteamlist == "rbb")
						{
							_0024aiteam_00243821 = "blue";
						}
						else
						{
							_0024aiteam_00243821 = "red";
						}
					}
					if (_0024s_00243822 == MasterServerScript.ainame3)
					{
						if (SpawningScript.aiteamlist == "rbb")
						{
							_0024aiteam_00243821 = "blue";
						}
						else
						{
							_0024aiteam_00243821 = "red";
						}
					}
					GameObject.Find("/GUI/Chat").SendMessage("aiSpeaking" + _0024aiteam_00243821, RuntimeServices.InvokeBinaryOperator("op_Addition", _0024s_00243822 + ": ", _0024self__00243823.winMessage[UnityEngine.Random.Range(0, _0024self__00243823.winMessage.length)]));
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal string _0024s_00243824;

		internal FPSCalculateHealth _0024self__00243825;

		public _0024aiWin_00243820(string s, FPSCalculateHealth self_)
		{
			_0024s_00243824 = s;
			_0024self__00243825 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024s_00243824, _0024self__00243825);
		}
	}

	[Serializable]
	internal sealed class _0024findkiller_00243826 : GenericGenerator<WWW>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WWW>, IEnumerator
		{
			internal bool _0024isalias_00243827;

			internal string _0024uname_00243828;

			internal bool _0024isownteam_00243829;

			internal int _0024randomnumber_00243830;

			internal WWW _0024rankings_00243831;

			internal int _0024actualGoldEarned_00243832;

			internal int _0024killedscore_00243833;

			internal int _0024myscore_00243834;

			internal float _0024calcscore_00243835;

			internal GameObject _0024kongobj_00243836;

			internal int _0024_0024524_00243837;

			internal string[] _0024_0024525_00243838;

			internal int _0024_0024526_00243839;

			internal string _0024u_00243840;

			internal string _0024deaduser_00243841;

			internal bool _0024team_00243842;

			internal string _0024action_00243843;

			internal FPSCalculateHealth _0024self__00243844;

			public _0024(string u, string deaduser, bool team, string action, FPSCalculateHealth self_)
			{
				_0024u_00243840 = u;
				_0024deaduser_00243841 = deaduser;
				_0024team_00243842 = team;
				_0024action_00243843 = action;
				_0024self__00243844 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (UnityEngine.Random.Range(0, 4) == 0 && PhotonNetwork.isMasterClient)
					{
						if (_0024u_00243840 == MasterServerScript.ainame)
						{
							_0024self__00243844.StartCoroutine_Auto(_0024self__00243844.aiWin(MasterServerScript.ainame));
						}
						if (_0024u_00243840 == MasterServerScript.ainame2)
						{
							_0024self__00243844.StartCoroutine_Auto(_0024self__00243844.aiWin(MasterServerScript.ainame2));
						}
						if (_0024u_00243840 == MasterServerScript.ainame3)
						{
							_0024self__00243844.StartCoroutine_Auto(_0024self__00243844.aiWin(MasterServerScript.ainame3));
						}
					}
					_0024isalias_00243827 = false;
					_0024_0024524_00243837 = 0;
					_0024_0024525_00243838 = PlayerPrefs.GetString("alias", string.Empty).Split("|"[0]);
					for (_0024_0024526_00243839 = _0024_0024525_00243838.Length; _0024_0024524_00243837 < _0024_0024526_00243839; _0024_0024524_00243837++)
					{
						if (_0024_0024525_00243838[_0024_0024524_00243837] == _0024deaduser_00243841)
						{
							_0024isalias_00243827 = true;
						}
					}
					if (AuthGameObject.username == _0024u_00243840 && !_0024isalias_00243827)
					{
						CalculateHealth.killstreak++;
					}
					_0024isownteam_00243829 = false;
					if (AuthGameObject.gametype != "Deathmatch" && AuthGameObject.gametype != "Freeplay" && AuthGameObject.gametype != "Survival")
					{
						if (SpawningScript.team2 == "red" && !_0024team_00243842)
						{
							_0024isownteam_00243829 = true;
						}
						if (SpawningScript.team2 == "blue" && _0024team_00243842)
						{
							_0024isownteam_00243829 = true;
						}
					}
					if (AuthGameObject.username == _0024u_00243840 && _0024isownteam_00243829)
					{
						GameObject.Find("/AuthGameObject").SendMessage("gotAch", "Accidents Happen");
					}
					if ((_0024u_00243840 == MasterServerScript.ainame || _0024u_00243840 == MasterServerScript.ainame2 || _0024u_00243840 == MasterServerScript.ainame3) && PhotonNetwork.isMasterClient && !_0024deaduser_00243841.Contains("guest_"))
					{
						_0024randomnumber_00243830 = UnityEngine.Random.Range(0, 99999);
						_0024rankings_00243831 = new WWW("http://72.14.184.180/rankingsManager.php?request=submit&key=" + Md5Sum.ComputeMd5(global::DontDestroyOnLoad.hitcollider + _0024randomnumber_00243830.ToString()) + "&user=" + _0024deaduser_00243841 + "&score=" + (-3).ToString() + "&random=" + _0024randomnumber_00243830.ToString());
						result = (Yield(2, _0024rankings_00243831) ? 1 : 0);
						break;
					}
					goto case 2;
				case 2:
					if (AuthGameObject.username == _0024u_00243840 && !AuthGameObject.username.Contains("guest_") && !_0024isalias_00243827)
					{
						((PhotonView)GameObject.Find("/GUI/Chat").GetComponent(typeof(PhotonView))).RPC("gotKill", PhotonTargets.All, true, AuthGameObject.username);
						if (AuthGameObject.shop)
						{
							_0024actualGoldEarned_00243832 = 0;
							if (!_0024isownteam_00243829)
							{
								CalculateHealth.goldearned = ((float)UnityBuiltins.parseInt(_0024self__00243844.returnGold()) + Mathf.Round(20f + 10f * CalculateHealth.bonus)).ToString();
								CalculateHealth.goldearned = _0024self__00243844.returnGoldEncrypted();
								_0024actualGoldEarned_00243832 = (int)((float)_0024actualGoldEarned_00243832 + Mathf.Round(20f + 10f * CalculateHealth.bonus * (float)((!RefreshMasterServer.isunderdog) ? 1 : 2)));
								CalculateHealth.bonus = Mathf.Clamp(CalculateHealth.bonus + 0.3f, 0.5f, 2f);
							}
							else
							{
								CalculateHealth.bonus = Mathf.Clamp(CalculateHealth.bonus - 0.2f, 0.5f, 2f);
							}
							_0024randomnumber_00243830 = UnityEngine.Random.Range(0, 99999);
							_0024rankings_00243831 = new WWW("http://72.14.184.180/rankingsManager.php?request=returnspecific&key=" + Md5Sum.ComputeMd5(global::DontDestroyOnLoad.hitcollider + _0024randomnumber_00243830.ToString()) + "&random=" + _0024randomnumber_00243830.ToString() + "&user=" + _0024deaduser_00243841);
							result = (Yield(3, _0024rankings_00243831) ? 1 : 0);
							break;
						}
						goto case 6;
					}
					goto IL_088a;
				case 3:
					_0024killedscore_00243833 = 500;
					_0024myscore_00243834 = 500;
					if (string.IsNullOrEmpty(_0024rankings_00243831.error))
					{
						_0024killedscore_00243833 = UnityBuiltins.parseInt(_0024rankings_00243831.text);
					}
					_0024rankings_00243831 = new WWW("http://72.14.184.180/rankingsManager.php?request=returnspecific&key=" + Md5Sum.ComputeMd5(global::DontDestroyOnLoad.hitcollider + _0024randomnumber_00243830.ToString()) + "&random=" + _0024randomnumber_00243830.ToString() + "&user=" + AuthGameObject.username);
					result = (Yield(4, _0024rankings_00243831) ? 1 : 0);
					break;
				case 4:
					if (string.IsNullOrEmpty(_0024rankings_00243831.error))
					{
						_0024myscore_00243834 = UnityBuiltins.parseInt(_0024rankings_00243831.text);
					}
					_0024randomnumber_00243830 = UnityEngine.Random.Range(0, 99999);
					_0024calcscore_00243835 = ((_0024killedscore_00243833 > _0024myscore_00243834) ? Mathf.Round(5f + (float)(_0024killedscore_00243833 - _0024myscore_00243834) / Mathf.Sqrt((float)(_0024killedscore_00243833 - _0024myscore_00243834) * 1f)) : 3f) * ((!_0024isownteam_00243829) ? 1f : (-1f));
					if (!_0024isownteam_00243829)
					{
						CalculateHealth.goldearned = ((float)UnityBuiltins.parseInt(_0024self__00243844.returnGold()) + Mathf.Round(_0024calcscore_00243835 - 2f)).ToString();
						_0024actualGoldEarned_00243832 = (int)((float)_0024actualGoldEarned_00243832 + Mathf.Round(_0024calcscore_00243835 - 2f));
						CalculateHealth.goldearned = _0024self__00243844.returnGoldEncrypted();
					}
					CalculateHealth.totalXPEarned = (int)((float)CalculateHealth.totalXPEarned + _0024calcscore_00243835);
					if (!_0024isownteam_00243829)
					{
						CalculateHealth.totalCKills++;
					}
					_0024rankings_00243831 = new WWW("http://72.14.184.180/rankingsManager.php?request=submit&key=" + Md5Sum.ComputeMd5(global::DontDestroyOnLoad.hitcollider + _0024randomnumber_00243830.ToString()) + "&user=" + AuthGameObject.username + "&score=" + _0024calcscore_00243835.ToString() + "&random=" + _0024randomnumber_00243830.ToString());
					result = (Yield(5, _0024rankings_00243831) ? 1 : 0);
					break;
				case 5:
					if (!_0024deaduser_00243841.Contains("guest_") && !_0024isownteam_00243829)
					{
						_0024randomnumber_00243830 = UnityEngine.Random.Range(0, 99999);
						_0024rankings_00243831 = new WWW("http://72.14.184.180/rankingsManager.php?request=submit&key=" + Md5Sum.ComputeMd5(global::DontDestroyOnLoad.hitcollider + _0024randomnumber_00243830.ToString()) + "&user=" + _0024deaduser_00243841 + "&score=" + (-0.5f * _0024calcscore_00243835).ToString() + "&random=" + _0024randomnumber_00243830.ToString());
						result = (Yield(6, _0024rankings_00243831) ? 1 : 0);
						break;
					}
					goto case 6;
				case 6:
					if (Application.isWebPlayer)
					{
						_0024kongobj_00243836 = GameObject.Find("KongregateAPI");
						((KongregateAPI)_0024kongobj_00243836.GetComponent(typeof(KongregateAPI))).SubmitStat("TotalKillsEver", 1);
					}
					goto IL_088a;
				case 1:
					{
						result = 0;
						break;
					}
					IL_088a:
					if (AuthGameObject.username == _0024u_00243840 && AuthGameObject.username != _0024deaduser_00243841)
					{
						GameObject.Find("/GUI/SubMessage").SendMessage("setMessage", "You " + _0024action_00243843 + " " + _0024deaduser_00243841 + ((!_0024isownteam_00243829) ? string.Empty : " (your own teammate)") + "!" + ((_0024calcscore_00243835 == 0f) ? string.Empty : ("\n+" + _0024actualGoldEarned_00243832.ToString() + " credits  " + ((_0024calcscore_00243835 <= 0f) ? string.Empty : "+") + _0024calcscore_00243835.ToString() + " XP")));
					}
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal string _0024u_00243845;

		internal string _0024deaduser_00243846;

		internal bool _0024team_00243847;

		internal string _0024action_00243848;

		internal FPSCalculateHealth _0024self__00243849;

		public _0024findkiller_00243826(string u, string deaduser, bool team, string action, FPSCalculateHealth self_)
		{
			_0024u_00243845 = u;
			_0024deaduser_00243846 = deaduser;
			_0024team_00243847 = team;
			_0024action_00243848 = action;
			_0024self__00243849 = self_;
		}

		public override IEnumerator<WWW> GetEnumerator()
		{
			return new _0024(_0024u_00243845, _0024deaduser_00243846, _0024team_00243847, _0024action_00243848, _0024self__00243849);
		}
	}

	private AuthGameObject authgameobject;

	private SpawningScript spwnsrc;

	private MasterServerScript mserver;

	private CalculateHealth chealth;

	private ChatScript cscript;

	private RefreshMasterServer refreshmserver;

	private DontDestroyOnLoad ddol;

	private GameObject tchooseGUI;

	private GameObject healthGUI;

	private GameObject chatGUI;

	private BotSpawner bspawn;

	public float currenthealth;

	[NonSerialized]
	public static bool isafking;

	private float isafkingtimer;

	public GameObject nameObj;

	private bool isburning;

	private float burntimeleft;

	public ParticleEmitter burnflames;

	private Hashtable killedby;

	private UnityScript.Lang.Array killerarr;

	private UnityScript.Lang.Array dead;

	private UnityScript.Lang.Array winMessage;

	private float lastHUpdate;

	public GameObject spawnedFromCar;

	private bool isEMPd;

	public ParticleEmitter blueGlow;

	public ParticleEmitter redGlow;

	public ParticleEmitter deadGlow;

	private InterpNetTrans pRemote;

	private float initInvinc;

	private DamageDisplay damageDisplay;

	public FPSCalculateHealth()
	{
		currenthealth = 100f;
		isafkingtimer = 60f;
		burntimeleft = 15f;
		killerarr = new UnityScript.Lang.Array();
		dead = new UnityScript.Lang.Array("ow", "grr", "darn", "argh!", "nice shot", "good shot", "nice hit", "good hit", "mmph", "oof", "I'll get you next time", ":(", "D:", ":O", ":[");
		winMessage = new UnityScript.Lang.Array("haha", "pwned", "hehe", "heh", "gotcha", "boom!", "boom", "kaboom", ">:)", "die", "DIE", "lol", "i win", "I win", ":D", ":)", ">:D", ":]");
		lastHUpdate = 100f;
		initInvinc = 5.5f;
	}

	public virtual void returnbadge(GameObject t)
	{
		if (SpawningScript.team2 == "red")
		{
			t.SendMessage("returnedbadge", ((!(nameObj.name == "CarbonTech") && !(nameObj.name == "nattyfrank") && !(nameObj.name == "techietotoro") && !(nameObj.name == "Apophis") && !(nameObj.name == "Nattyfrank") && !(nameObj.name == "TheGoodGuy")) ? string.Empty : "[mod] ") + nameObj.name + " - " + Mathf.Round(currenthealth).ToString() + "%" + ((!(pRemote.networkStatus != string.Empty)) ? string.Empty : ("\n" + pRemote.networkStatus)));
		}
		else if (SpawningScript.team2 == "blue")
		{
			t.SendMessage("returnedbadge", ((!(nameObj.name == "CarbonTech") && !(nameObj.name == "nattyfrank") && !(nameObj.name == "techietotoro") && !(nameObj.name == "Apophis") && !(nameObj.name == "Nattyfrank") && !(nameObj.name == "TheGoodGuy")) ? string.Empty : "[mod] ") + nameObj.name + " - " + Mathf.Round(currenthealth).ToString() + "%" + ((!(pRemote.networkStatus != string.Empty)) ? string.Empty : ("\n" + pRemote.networkStatus)));
		}
	}

	public virtual void Awake()
	{
		pRemote = (InterpNetTrans)gameObject.GetComponent(typeof(InterpNetTrans));
		damageDisplay = (DamageDisplay)GameObject.Find("/DamageDisplay").GetComponent(typeof(DamageDisplay));
	}

	public virtual IEnumerator Start()
	{
		return new _0024Start_00243817(this).GetEnumerator();
	}

	[RPC]
	public virtual void addIdle(int i)
	{
		if (i == 0)
		{
			nameObj.name += " (Idle)";
		}
		if (i == 1)
		{
			nameObj.name = nameObj.name.Replace(" (Idle)", string.Empty);
		}
	}

	[RPC]
	public virtual void updateHealth(int h)
	{
		currenthealth = (float)h * 1f;
	}

	public virtual void Update()
	{
		if (!(burntimeleft <= 0f) && isburning && !(transform.position.y <= 7.2f))
		{
			if (!burnflames.emit)
			{
				burnflames.emit = true;
			}
			burntimeleft -= Time.deltaTime;
			if (!photonView.isMine)
			{
			}
		}
		else
		{
			burntimeleft = 15f;
			isburning = false;
			if (burnflames.emit)
			{
				burnflames.emit = false;
			}
		}
		if (!photonView.isMine)
		{
			return;
		}
		if (lastHUpdate != currenthealth)
		{
			if (!(currenthealth <= 100f))
			{
				currenthealth = 100f;
			}
			if (!(currenthealth > 0f))
			{
				currenthealth = 0f;
				CalculateHealth.bonus = 1f;
				tchooseGUI.SendMessage("addvictim", AuthGameObject.username);
				spawnedFromCar.transform.Find("Colliders/MainBoxCol").SendMessage("delayregenFPS", transform.position);
				((PlayerCar_Script)spawnedFromCar.GetComponent(typeof(PlayerCar_Script))).inCar = true;
				ChatScript.isCar = true;
				Camera.main.transform.parent = null;
				SpawningScript.playertrans = spawnedFromCar.transform;
				GameObject gameObject = new GameObject("FPSCamObject");
				gameObject.transform.position = transform.position;
				gameObject.transform.rotation = transform.rotation;
				Camera.main.SendMessage("SetFPSTarget", gameObject.transform);
				GameObject.Find("/MinimapCam").SendMessage("SetTarget", SpawningScript.playertrans);
				BotSpawner.hiveMindTarget = spawnedFromCar.transform;
				((PhotonView)GameObject.Find("/Spawn Point").GetComponent(typeof(PhotonView))).RPC("customHumanDestroy", PhotonTargets.MasterClient);
				if ((bool)GameObject.Find("/BattlefieldBounds"))
				{
					GameObject.Find("/BattlefieldBounds").SendMessage("resetStates");
				}
				((PhotonView)this.gameObject.GetComponent(typeof(PhotonView))).RPC("customNetDestroy", PhotonTargets.All);
			}
			lastHUpdate = currenthealth;
			((PhotonView)this.gameObject.GetComponent(typeof(PhotonView))).RPC("updateHealth", PhotonTargets.Others, UnityBuiltins.parseInt(Mathf.Round(currenthealth)));
			healthGUI.SendMessage("updatehealthNoEx", currenthealth);
		}
		if (Input.GetAxis("Horizontal") != 0f || Input.GetAxis("Vertical") != 0f || Input.GetKeyDown("m") || Input.GetButtonDown("Fire1"))
		{
			if (isafking)
			{
				((PhotonView)this.gameObject.GetComponent(typeof(PhotonView))).RPC("addIdle", PhotonTargets.All, 1);
			}
			isafkingtimer = 60f;
			isafking = false;
		}
		else if (!(isafkingtimer <= 0f))
		{
			isafkingtimer -= Time.deltaTime;
		}
		else
		{
			isafkingtimer = 0f;
			if (!isafking)
			{
				((PhotonView)this.gameObject.GetComponent(typeof(PhotonView))).RPC("addIdle", PhotonTargets.All, 0);
			}
			isafking = true;
		}
	}

	public virtual void safeDestroy()
	{
		((PlayerCar_Script)spawnedFromCar.GetComponent(typeof(PlayerCar_Script))).inCar = true;
		ChatScript.isCar = true;
		Camera.main.transform.parent = null;
		SpawningScript.playertrans = spawnedFromCar.transform;
		spawnedFromCar.transform.Find("Colliders/MainBoxCol").SendMessage("delayregenFPS", transform.position);
		((PhotonView)spawnedFromCar.transform.Find("Colliders/MainBoxCol").GetComponent(typeof(PhotonView))).RPC("EnableAllFPS", PhotonTargets.All);
		GameObject gameObject = new GameObject("FPSCamObject");
		gameObject.transform.position = transform.position;
		gameObject.transform.rotation = transform.rotation;
		Camera.main.SendMessage("SetFPSTarget", gameObject.transform);
		GameObject.Find("/MinimapCam").SendMessage("SetTarget", SpawningScript.playertrans);
		BotSpawner.hiveMindTarget = spawnedFromCar.transform;
		((PhotonView)GameObject.Find("/Spawn Point").GetComponent(typeof(PhotonView))).RPC("customHumanDestroy", PhotonTargets.MasterClient);
		((PhotonView)this.gameObject.GetComponent(typeof(PhotonView))).RPC("customNetDestroy", PhotonTargets.All);
	}

	public virtual void safeDestroyRound()
	{
		((PlayerCar_Script)spawnedFromCar.GetComponent(typeof(PlayerCar_Script))).inCar = true;
		ChatScript.isCar = true;
		Camera.main.transform.parent = null;
		SpawningScript.playertrans = spawnedFromCar.transform;
		spawnedFromCar.transform.Find("Colliders/MainBoxCol").SendMessage("delayregenFPSQuick", transform.position);
		((PhotonView)spawnedFromCar.transform.Find("Colliders/MainBoxCol").GetComponent(typeof(PhotonView))).RPC("EnableAll", PhotonTargets.All);
		Camera.main.SendMessage("SetTarget", SpawningScript.playertrans);
		GameObject.Find("/MinimapCam").SendMessage("SetTarget", SpawningScript.playertrans);
		BotSpawner.hiveMindTarget = SpawningScript.playertrans;
		((PhotonView)GameObject.Find("/Spawn Point").GetComponent(typeof(PhotonView))).RPC("customHumanDestroy", PhotonTargets.MasterClient);
		((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("customNetDestroy", PhotonTargets.All);
	}

	[RPC]
	public virtual void customNetDestroy()
	{
		deadGlow.emit = true;
		deadGlow.transform.parent = null;
		if ((bool)spawnedFromCar)
		{
			PhotonNetwork.RemoveRPCs((PhotonView)spawnedFromCar.GetComponent(typeof(PhotonView)));
		}
		if (PhotonNetwork.isMasterClient)
		{
			int num = 0;
			IEnumerator enumerator = UnityRuntimeServices.GetEnumerator(SpawningScript.spawnedCars);
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				if (!(obj is GameObject))
				{
					obj = RuntimeServices.Coerce(obj, typeof(GameObject));
				}
				GameObject gameObject = (GameObject)obj;
				if (gameObject == this.gameObject)
				{
					SpawningScript.spawnedCars.RemoveAt(num);
					break;
				}
				num++;
			}
		}
		UnityEngine.Object.Destroy(this.gameObject);
	}

	public virtual void OnPhotonSerializeView(PhotonStream stream)
	{
		if (stream.isWriting)
		{
			stream.SendNext(currenthealth);
		}
		else
		{
			currenthealth = RuntimeServices.UnboxSingle(stream.ReceiveNext());
		}
	}

	[RPC]
	public virtual void networkedRam(string n)
	{
		if (!(currenthealth <= 0f) && photonView.isMine)
		{
			int level = 1;
			float damage = 150f;
			string action = "rammed";
			string weaponUsed = "vehicle";
			bool hasLevel = false;
			damageDelegate(n, level, damage, action, weaponUsed, hasLevel);
		}
	}

	public virtual void hardimpact(int i)
	{
	}

	public virtual void outofbounds()
	{
		currenthealth = 0f;
		GameObject.Find("/GUI/HealthDisplay").SendMessage("killerusername", "YOU");
	}

	public virtual void resethealth()
	{
		currenthealth = 100f;
		killerarr.Clear();
		killedby.Clear();
	}

	public virtual void bladeHitLarge(string u)
	{
		string user = u.Split("|"[0])[0];
		int num = UnityBuiltins.parseInt(u.Split("|"[0])[1]);
		float damage = UnityEngine.Random.Range(20f * Time.deltaTime + (float)(num / 2), 36f * Time.deltaTime + (float)(num / 2)) * 2f;
		string action = "sliced";
		string weaponUsed = "Melee Slicer Armor";
		bool hasLevel = true;
		damageDelegate(user, num, damage, action, weaponUsed, hasLevel);
	}

	public virtual void bladeHit(string u)
	{
		string user = u.Split("|"[0])[0];
		int num = UnityBuiltins.parseInt(u.Split("|"[0])[1]);
		float damage = UnityEngine.Random.Range(10f * Time.deltaTime + (float)(num / 2), 18f * Time.deltaTime + (float)(num / 2)) * 2f;
		string action = "sliced";
		string weaponUsed = "Melee Ramming Blade";
		bool hasLevel = true;
		damageDelegate(user, num, damage, action, weaponUsed, hasLevel);
	}

	public virtual void empgrenadeHit(string u)
	{
		isEMPd = true;
		string user = u.Split("|"[0])[0];
		int num = UnityBuiltins.parseInt(u.Split("|"[0])[1]);
		float damage = ((UnityScript.Lang.Extensions.get_length((System.Array)u.Split("|"[0])) <= 2) ? 1f : UnityBuiltins.parseFloat(u.Split("|"[0])[2])) * (float)UnityEngine.Random.Range(30 + num / 2, 45 + num / 2) * 2f;
		string action = "fragged";
		string weaponUsed = "EMP Grenade Launcher";
		bool hasLevel = true;
		damageDelegate(user, num, damage, action, weaponUsed, hasLevel);
	}

	public virtual void grenadeHit(string u)
	{
		string user = u.Split("|"[0])[0];
		int num = UnityBuiltins.parseInt(u.Split("|"[0])[1]);
		float damage = ((UnityScript.Lang.Extensions.get_length((System.Array)u.Split("|"[0])) <= 2) ? 1f : UnityBuiltins.parseFloat(u.Split("|"[0])[2])) * (float)UnityEngine.Random.Range(30 + num / 2, 45 + num / 2) * 2f;
		string action = "fragged";
		string weaponUsed = "Grenade Launcher";
		bool hasLevel = true;
		damageDelegate(user, num, damage, action, weaponUsed, hasLevel);
	}

	public virtual void shotgunBulletHit(string u)
	{
		string user = u.Split("|"[0])[0];
		int num = UnityBuiltins.parseInt(u.Split("|"[0])[1]);
		float damage = (5f + (float)num / 8f) * 2f;
		string action = "blasted";
		string weaponUsed = "Shotgun";
		bool hasLevel = true;
		damageDelegate(user, num, damage, action, weaponUsed, hasLevel);
	}

	public virtual void bulletHit(string u)
	{
		string user = u.Split("|"[0])[0];
		int num = UnityBuiltins.parseInt(u.Split("|"[0])[1]);
		float damage = (1.5f + (float)(num / 15)) * 2f;
		string action = "gunned down";
		string weaponUsed = "Minigun/Assault Rifle";
		bool hasLevel = true;
		damageDelegate(user, num, damage, action, weaponUsed, hasLevel);
	}

	public virtual void railBulletHit(string u)
	{
		string user = u.Split("|"[0])[0];
		int num = UnityBuiltins.parseInt(u.Split("|"[0])[1]);
		float damage = ((UnityScript.Lang.Extensions.get_length((System.Array)u.Split("|"[0])) <= 2) ? 1f : UnityBuiltins.parseFloat(u.Split("|"[0])[2])) * (float)(75 + num / 2) * 2f;
		string action = "sniped";
		string weaponUsed = "Railgun";
		bool hasLevel = true;
		damageDelegate(user, num, damage, action, weaponUsed, hasLevel);
	}

	public virtual void burnHit(string u)
	{
		int level = 1;
		float damage = Time.deltaTime * 2f;
		string action = "burned";
		string weaponUsed = "burn damage";
		bool hasLevel = false;
		damageDelegate(u, level, damage, action, weaponUsed, hasLevel);
	}

	public virtual void OnParticleCollision(GameObject theparticle)
	{
		if (!(theparticle.name == "flameprefab(Clone)"))
		{
			return;
		}
		object obj = UnityRuntimeServices.Invoke(theparticle.GetComponent("FlameScript"), "returnUser", new object[0], typeof(UnityEngine.MonoBehaviour));
		int num = RuntimeServices.UnboxInt32(UnityRuntimeServices.Invoke(theparticle.GetComponent("FlameScript"), "returnLevel", new object[0], typeof(UnityEngine.MonoBehaviour)));
		object obj2 = UnityRuntimeServices.Invoke(theparticle.GetComponent("FlameScript"), "returnTeam", new object[0], typeof(UnityEngine.MonoBehaviour));
		if (!(obj2 is string))
		{
			obj2 = RuntimeServices.Coerce(obj2, typeof(string));
		}
		string text = (string)obj2;
		float damage = Mathf.Round(0.35f + (float)(num / 160)) * 2f;
		string action = "burned";
		string weaponUsed = "Flamethrower";
		bool hasLevel = true;
		if (text != SpawningScript.team2)
		{
			object obj3 = obj;
			if (!(obj3 is string))
			{
				obj3 = RuntimeServices.Coerce(obj3, typeof(string));
			}
			damageDelegate((string)obj3, num, damage, action, weaponUsed, hasLevel);
		}
	}

	public virtual void missileHit(string u)
	{
		string user = u.Split("|"[0])[0];
		int num = UnityBuiltins.parseInt(u.Split("|"[0])[1]);
		float damage = ((UnityScript.Lang.Extensions.get_length((System.Array)u.Split("|"[0])) <= 2) ? 1f : UnityBuiltins.parseFloat(u.Split("|"[0])[2])) * (float)UnityEngine.Random.Range(10 + num / 8, 15 + num / 8) * 2f;
		string action = "blew up";
		string weaponUsed = "Missile Launcher";
		bool hasLevel = true;
		damageDelegate(user, num, damage, action, weaponUsed, hasLevel);
	}

	public virtual void laserCannonHit(string u)
	{
		string user = u.Split("|"[0])[0];
		int num = UnityBuiltins.parseInt(u.Split("|"[0])[1]);
		string text = u.Split("|"[0])[2];
		float damage = ((UnityScript.Lang.Extensions.get_length((System.Array)u.Split("|"[0])) <= 3) ? 1f : UnityBuiltins.parseFloat(u.Split("|"[0])[3])) * (float)UnityBuiltins.parseInt(100 + num / 2) * 2f;
		string action = "fried";
		string weaponUsed = "Laser Cannon";
		bool hasLevel = true;
		if (text != SpawningScript.team2)
		{
			damageDelegate(user, num, damage, action, weaponUsed, hasLevel);
		}
	}

	public virtual void laserhit(string u)
	{
		string user = u.Split("|"[0])[0];
		int num = UnityBuiltins.parseInt(u.Split("|"[0])[1]);
		float damage = ((UnityScript.Lang.Extensions.get_length((System.Array)u.Split("|"[0])) <= 2) ? 1f : UnityBuiltins.parseFloat(u.Split("|"[0])[2])) * (float)UnityEngine.Random.Range(3 + num / 5, 6 + num / 5) * 2f;
		string action = "zapped";
		string weaponUsed = "Plasma Blaster";
		bool hasLevel = true;
		damageDelegate(user, num, damage, action, weaponUsed, hasLevel);
	}

	public virtual void rockethit(string u)
	{
		string user = u.Split("|"[0])[0];
		int num = UnityBuiltins.parseInt(u.Split("|"[0])[1]);
		float damage = ((UnityScript.Lang.Extensions.get_length((System.Array)u.Split("|"[0])) <= 2) ? 1f : UnityBuiltins.parseFloat(u.Split("|"[0])[2])) * (float)UnityEngine.Random.Range(30 + num / 5, 40 + num / 5) * 2f;
		string action = "blew up";
		string weaponUsed = "Rocket Launcher";
		bool hasLevel = true;
		damageDelegate(user, num, damage, action, weaponUsed, hasLevel);
	}

	public virtual void explosionHit(string u)
	{
		string user = u.Split("|"[0])[0];
		int num = UnityBuiltins.parseInt(u.Split("|"[0])[1]);
		float damage = ((UnityScript.Lang.Extensions.get_length((System.Array)u.Split("|"[0])) <= 2) ? 1f : UnityBuiltins.parseFloat(u.Split("|"[0])[2])) * Mathf.Round(UnityBuiltins.parseFloat(num)) * 2f;
		string action = "fragged";
		string weaponUsed = "explosion damage";
		bool hasLevel = false;
		damageDelegate(user, num, damage, action, weaponUsed, hasLevel);
	}

	public virtual void damageDelegate(string user, int level, float damage, string action, string weaponUsed, bool hasLevel)
	{
		if (!photonView.isMine || currenthealth == 0f || isafking || initInvinc > 0f)
		{
			return;
		}
		PhotonPlayer photonPlayer = usernameToPlayer(user);
		if (photonPlayer != null)
		{
			((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("hD", photonPlayer, Mathf.RoundToInt(damage));
		}
		currenthealth -= damage;
		if (!(currenthealth > 0f))
		{
			if (!isafking)
			{
				((PhotonView)spawnedFromCar.transform.Find("Colliders/MainBoxCol").GetComponent(typeof(PhotonView))).RPC("findkiller", PhotonTargets.All, user, AuthGameObject.username, (!(SpawningScript.team2 == "red")) ? true : false, action);
			}
			GameObject.Find("HealthEffect").SendMessage("setnfo");
			GameObject.Find("HealthEffect").SendMessage("Fadeout");
			currenthealth = 0f;
			if (AuthGameObject.username == user)
			{
				chatGUI.SendMessage("OutsideSystem", AuthGameObject.username + " killed himself!");
				GameObject.Find("/GUI/HealthDisplay").SendMessage("killerusername", "YOU");
			}
			else
			{
				chatGUI.SendMessage("OutsideSystem", user + " " + action + " " + AuthGameObject.username + "!");
				GameObject.Find("/GUI/HealthDisplay").SendMessage("killerusername", user + " (" + ((!hasLevel) ? string.Empty : ("lvl " + level + " ")) + weaponUsed + ")");
			}
			if (!isafking)
			{
				tchooseGUI.SendMessage("addkiller", user);
			}
			IEnumerator enumerator = UnityRuntimeServices.GetEnumerator(killerarr);
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				if (!(obj is string))
				{
					obj = RuntimeServices.Coerce(obj, typeof(string));
				}
				string text = (string)obj;
				if (text != user && !isafking)
				{
					((PhotonView)spawnedFromCar.transform.Find("Colliders/MainBoxCol").GetComponent(typeof(PhotonView))).RPC("youHelpedToKill", PhotonTargets.All, text, UnityBuiltins.parseInt(Mathf.Round(RuntimeServices.UnboxSingle(RuntimeServices.InvokeBinaryOperator("op_Division", RuntimeServices.Invoke(typeof(UnityBuiltins), "parseInt", new object[1] { killedby[text] }), 10f)))), AuthGameObject.username, (!(SpawningScript.team2 == "red")) ? true : false);
					UnityRuntimeServices.Update(enumerator, text);
				}
			}
			killerarr.Clear();
			killedby.Clear();
		}
		else
		{
			if (!killedby.ContainsKey(user))
			{
				killedby.Add(user, damage);
				killerarr.Add(user);
			}
			else
			{
				killedby[user] = RuntimeServices.InvokeBinaryOperator("op_Addition", killedby[user], damage);
			}
			if (!(currenthealth > 15f))
			{
				GameObject.Find("HealthEffect").SendMessage("FadeAt", 65f);
				bool flag = true;
			}
			else
			{
				GameObject.Find("HealthEffect").SendMessage("FadeTo", (100f - currenthealth) / 1.3f);
			}
		}
	}

	public virtual void forceSetHealth(float h)
	{
		currenthealth = h;
	}

	public virtual IEnumerator aiWin(string s)
	{
		return new _0024aiWin_00243820(s, this).GetEnumerator();
	}

	[RPC]
	public virtual IEnumerator findkiller(string u, string deaduser, bool team, string action, PhotonMessageInfo info)
	{
		return new _0024findkiller_00243826(u, deaduser, team, action, this).GetEnumerator();
	}

	[RPC]
	public virtual void youHelpedToKill(string u, int i, string deaduser, bool team)
	{
	}

	public virtual string returnGold()
	{
		string goldearned = CalculateHealth.goldearned;
		string text = string.Empty;
		for (int i = 0; i < UnityScript.Lang.Extensions.get_length(goldearned); i++)
		{
			if (goldearned.Substring(i, 1) == "a")
			{
				text += "0";
			}
			if (goldearned.Substring(i, 1) == "b")
			{
				text += "1";
			}
			if (goldearned.Substring(i, 1) == "c")
			{
				text += "2";
			}
			if (goldearned.Substring(i, 1) == "d")
			{
				text += "3";
			}
			if (goldearned.Substring(i, 1) == "e")
			{
				text += "4";
			}
			if (goldearned.Substring(i, 1) == "f")
			{
				text += "5";
			}
			if (goldearned.Substring(i, 1) == "g")
			{
				text += "6";
			}
			if (goldearned.Substring(i, 1) == "h")
			{
				text += "7";
			}
			if (goldearned.Substring(i, 1) == "i")
			{
				text += "8";
			}
			if (goldearned.Substring(i, 1) == "j")
			{
				text += "9";
			}
		}
		return text;
	}

	public virtual string returnGoldEncrypted()
	{
		string goldearned = CalculateHealth.goldearned;
		string text = null;
		for (int i = 0; i < UnityScript.Lang.Extensions.get_length(goldearned); i++)
		{
			if (goldearned.Substring(i, 1) == "0")
			{
				text += "a";
			}
			if (goldearned.Substring(i, 1) == "1")
			{
				text += "b";
			}
			if (goldearned.Substring(i, 1) == "2")
			{
				text += "c";
			}
			if (goldearned.Substring(i, 1) == "3")
			{
				text += "d";
			}
			if (goldearned.Substring(i, 1) == "4")
			{
				text += "e";
			}
			if (goldearned.Substring(i, 1) == "5")
			{
				text += "f";
			}
			if (goldearned.Substring(i, 1) == "6")
			{
				text += "g";
			}
			if (goldearned.Substring(i, 1) == "7")
			{
				text += "h";
			}
			if (goldearned.Substring(i, 1) == "8")
			{
				text += "i";
			}
			if (goldearned.Substring(i, 1) == "9")
			{
				text += "j";
			}
		}
		return text;
	}

	[RPC]
	public virtual void hD(int amnt)
	{
		damageDisplay.addDamage(amnt, transform.position);
	}

	public virtual PhotonPlayer usernameToPlayer(string u)
	{
		IEnumerator enumerator = UnityRuntimeServices.GetEnumerator(SpawningScript.netPlayers);
		object result;
		while (true)
		{
			if (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				if (!(obj is NetPlayer))
				{
					obj = RuntimeServices.Coerce(obj, typeof(NetPlayer));
				}
				NetPlayer netPlayer = (NetPlayer)obj;
				if (netPlayer.username == u)
				{
					result = netPlayer.nplayer;
					break;
				}
				continue;
			}
			result = null;
			break;
		}
		return (PhotonPlayer)result;
	}

	public virtual void Main()
	{
		killedby = new Hashtable();
	}
}
