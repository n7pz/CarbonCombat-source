using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Photon;
using UnityEngine;

[Serializable]
public class InGameScores : Photon.MonoBehaviour
{
	[Serializable]
	internal sealed class _0024reseteverything_00244023 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal int _0024t_00244024;

			internal InGameScores _0024self__00244025;

			public _0024(int t, InGameScores self_)
			{
				_0024t_00244024 = t;
				_0024self__00244025 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00244025.timeleftmin = _0024t_00244024;
					_0024self__00244025.timeleftsec = 0;
					_0024self__00244025.rednumber = 0;
					_0024self__00244025.bluenumber = 0;
					_0024self__00244025.endtimer = false;
					_0024self__00244025.timercounter = 1f;
					if ((bool)SpawningScript.playertransCar)
					{
						SpawningScript.playertransCar.gameObject.SendMessage("roundsetter", true);
					}
					resethealthscript = true;
					result = (YieldDefault(2) ? 1 : 0);
					break;
				case 2:
					resethealthscript = false;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal int _0024t_00244026;

		internal InGameScores _0024self__00244027;

		public _0024reseteverything_00244023(int t, InGameScores self_)
		{
			_0024t_00244026 = t;
			_0024self__00244027 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024t_00244026, _0024self__00244027);
		}
	}

	public GUIStyle mainskin;

	public GUIStyle mainskin2;

	public GUIStyle counttxt;

	public GUIStyle teamtxt;

	public Color redcolor;

	public Color bluecolor;

	public Color timercolor;

	private int timeleftsec;

	private int timeleftmin;

	private bool endtimer;

	private int rednumber;

	private int bluenumber;

	[NonSerialized]
	public static int redpoints;

	[NonSerialized]
	public static int bluepoints;

	public AuthGameObject authobj;

	public RefreshMasterServer refresh;

	public InitWorld iw;

	public AudioController acon;

	public GameObject endofround;

	public SpawningScript src;

	public HeadlesssDedServer headless;

	public float timercounter;

	private float updatecounter;

	private bool sendonce;

	[NonSerialized]
	public static bool resethealthscript;

	public InGameScores()
	{
		timeleftsec = 99;
		timeleftmin = 99;
		timercounter = 1f;
		updatecounter = 3f;
	}

	public virtual void Awake()
	{
		if (AuthGameObject.gametype == "Freeplay")
		{
			enabled = false;
		}
	}

	public virtual void Start()
	{
		if (PhotonNetwork.isMasterClient)
		{
			timeleftmin = AuthGameObject.timelimit;
			timeleftsec = 0;
		}
		starttimer();
	}

	public virtual void resetdelegate()
	{
		if (PhotonNetwork.isMasterClient)
		{
			((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("reseteverything", PhotonTargets.All, AuthGameObject.timelimit);
		}
	}

	[RPC]
	public virtual IEnumerator reseteverything(int t)
	{
		return new _0024reseteverything_00244023(t, this).GetEnumerator();
	}

	public virtual void OnPhotonPlayerConnected(PhotonPlayer player)
	{
		((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("updateAll", player, rednumber, bluenumber, timeleftsec, timeleftmin);
	}

	public virtual void starttimer()
	{
		if (timeleftsec - 1 < 0)
		{
			if (timeleftmin != 0)
			{
				timeleftsec = 59;
				timeleftmin--;
			}
			else if (!sendonce)
			{
				sendonce = true;
				timeleftsec = 0;
				endtimer = true;
				endofround.SendMessage("setguiactive", true);
				endofround.SendMessage("formatplayers");
				endofround.SendMessage("fadein");
				if (SpawningScript.playertrans != null)
				{
					SpawningScript.playertransCar.gameObject.SendMessage("roundsetter", false);
				}
			}
		}
		else
		{
			timeleftsec--;
			sendonce = false;
		}
	}

	public virtual void Update()
	{
		if (PhotonNetwork.isMasterClient)
		{
			if (!(updatecounter <= 0f))
			{
				updatecounter -= Time.deltaTime;
			}
			else
			{
				updatecounter = 3f;
				if (AuthGameObject.whirldurl == string.Empty || InitWorld.finaldone)
				{
					((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("updateAll", PhotonTargets.All, rednumber, bluenumber, timeleftsec, timeleftmin);
				}
			}
		}
		if (RefreshMasterServer.personjoined || PhotonNetwork.isMasterClient)
		{
		}
		if (!(timercounter <= 0f))
		{
			timercounter -= Time.deltaTime;
		}
		else
		{
			timercounter = 1f;
			if (timeleftmin >= 0 && timeleftsec >= 0 && !endtimer && RefreshMasterServer.personjoined)
			{
				starttimer();
			}
		}
		redpoints = rednumber;
		bluepoints = bluenumber;
	}

	public virtual void reddeath()
	{
		((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("addblue", PhotonTargets.All);
	}

	public virtual void bluedeath()
	{
		((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("addred", PhotonTargets.All);
	}

	public virtual void OnGUI()
	{
		if (!AudioController.hideGUI)
		{
			GUI.depth = -1;
			GUI.BeginGroup(new Rect(Screen.width / 2 - 110, -5f, 220f, 60f));
			GUI.Box(new Rect(0f, 0f, 220f, 60f), string.Empty, (!(AuthGameObject.gametype == "Deathmatch") && !(AuthGameObject.gametype == "Survival")) ? mainskin : mainskin2);
			if (timeleftmin == 0)
			{
				GUI.color = timercolor;
			}
			string lhs = timeleftmin.ToString();
			string rhs = timeleftsec.ToString();
			if (timeleftmin < 10)
			{
				lhs = "0" + timeleftmin.ToString();
			}
			if (timeleftsec < 10)
			{
				rhs = "0" + timeleftsec.ToString();
			}
			GUI.Label(new Rect(55f, 13f, 110f, 20f), lhs + ":" + rhs, counttxt);
			if (AuthGameObject.gametype != "Deathmatch" && AuthGameObject.gametype != "Survival")
			{
				GUI.color = redcolor;
				GUI.Label(new Rect(32f, 9f, 30f, 20f), rednumber.ToString(), teamtxt);
				GUI.color = bluecolor;
				GUI.Label(new Rect(159f, 9f, 30f, 20f), bluenumber.ToString(), teamtxt);
			}
			GUI.EndGroup();
		}
	}

	[RPC]
	public virtual void addred()
	{
		rednumber++;
	}

	[RPC]
	public virtual void addblue()
	{
		bluenumber++;
	}

	public virtual void showEndOfRound()
	{
		endtimer = true;
		endofround.SendMessage("setguiactive", true);
		endofround.SendMessage("formatplayers");
		endofround.SendMessage("fadein");
		if (SpawningScript.playertransCar != null)
		{
			SpawningScript.playertransCar.gameObject.SendMessage("roundsetter", false);
		}
	}

	[RPC]
	public virtual void updateAll(int rednum, int bluenum, int sec, int minvar)
	{
		rednumber = rednum;
		bluenumber = bluenum;
		timeleftsec = sec;
		endtimer = false;
		timeleftmin = minvar;
	}
}
