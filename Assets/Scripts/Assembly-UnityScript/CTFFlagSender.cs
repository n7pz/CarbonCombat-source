using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Photon;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class CTFFlagSender : Photon.MonoBehaviour
{
	[Serializable]
	internal sealed class _0024OnCreatedRoom_00243398 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal CTFFlagSender _0024self__00243399;

			public _0024(CTFFlagSender self_)
			{
				_0024self__00243399 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					result = (Yield(2, new WaitForSeconds(0.4f)) ? 1 : 0);
					break;
				case 2:
					if (AuthGameObject.gametype != "Capture the Flag")
					{
						_0024self__00243399.gameObject.SetActiveRecursively(false);
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

		internal CTFFlagSender _0024self__00243400;

		public _0024OnCreatedRoom_00243398(CTFFlagSender self_)
		{
			_0024self__00243400 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00243400);
		}
	}

	[Serializable]
	internal sealed class _0024flashcolorsonly_00243401 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal CTFFlagSender _0024self__00243402;

			public _0024(CTFFlagSender self_)
			{
				_0024self__00243402 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00243402.flagtake.emit = true;
					result = (Yield(2, new WaitForSeconds(2f)) ? 1 : 0);
					break;
				case 2:
					_0024self__00243402.flagtake.emit = false;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal CTFFlagSender _0024self__00243403;

		public _0024flashcolorsonly_00243401(CTFFlagSender self_)
		{
			_0024self__00243403 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00243403);
		}
	}

	[Serializable]
	internal sealed class _0024flashcolors_00243404 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal bool _0024t_00243405;

			internal CTFFlagSender _0024self__00243406;

			public _0024(bool t, CTFFlagSender self_)
			{
				_0024t_00243405 = t;
				_0024self__00243406 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00243406.flagpole.SetActiveRecursively(_0024t_00243405);
					if (!_0024t_00243405)
					{
						_0024self__00243406.othergotflag = true;
					}
					else
					{
						_0024self__00243406.othergotflag = false;
					}
					_0024self__00243406.flagtake.emit = true;
					result = (Yield(2, new WaitForSeconds(2f)) ? 1 : 0);
					break;
				case 2:
					_0024self__00243406.flagtake.emit = false;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal bool _0024t_00243407;

		internal CTFFlagSender _0024self__00243408;

		public _0024flashcolors_00243404(bool t, CTFFlagSender self_)
		{
			_0024t_00243407 = t;
			_0024self__00243408 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024t_00243407, _0024self__00243408);
		}
	}

	public ParticleEmitter flagtake;

	public string team;

	public GameObject flagpole;

	public SpawningScript src;

	public CTFDelegate ctfdel;

	public CTFDroppedFlag ctfdrop;

	public AuthGameObject authobj;

	public EndofRound igssrc;

	public ChatScript cscript;

	public RefreshMasterServer refresh;

	public GameObject srcobj;

	[NonSerialized]
	public static bool gotflag;

	private bool othergotflag;

	public GameObject otherflagunit;

	public GameObject igs;

	private bool reclaim;

	[NonSerialized]
	public static bool reclaimstat;

	public CalculateHealth chealth;

	[RPC]
	public virtual void returnedstate(bool t)
	{
		flagpole.SetActiveRecursively(t);
	}

	[RPC]
	public virtual void returnctfmodeDel(PhotonMessageInfo info)
	{
		((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("returnedstate", info.sender, flagpole.active);
	}

	public virtual void Awake()
	{
		gotflag = false;
		reclaimstat = reclaim;
		othergotflag = false;
	}

	public virtual void Start()
	{
		if (!PhotonNetwork.isMasterClient && AuthGameObject.gametype == "Capture the Flag")
		{
			((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("returnctfmodeDel", PhotonTargets.MasterClient);
		}
		if (AuthGameObject.gametype != "Capture the Flag")
		{
			gameObject.SetActiveRecursively(false);
		}
	}

	public virtual IEnumerator OnCreatedRoom()
	{
		return new _0024OnCreatedRoom_00243398(this).GetEnumerator();
	}

	public virtual void resetrespawn()
	{
		CTFDelegate.maincol.gameObject.SendMessage("setctf", false);
		gotflag = false;
	}

	[RPC]
	public virtual void awardGold()
	{
		CalculateHealth.goldearned = ((float)UnityBuiltins.parseInt(returnGold(CalculateHealth.goldearned)) + Mathf.Round(25f + 10f * CalculateHealth.bonus * (float)((!RefreshMasterServer.isunderdog) ? 1 : 2))).ToString();
		CalculateHealth.goldearned = returnGoldEncrypted(CalculateHealth.goldearned);
	}

	public virtual string returnGold(string g)
	{
		string text = string.Empty;
		for (int i = 0; i < UnityScript.Lang.Extensions.get_length(g); i++)
		{
			if (g.Substring(i, 1) == "a")
			{
				text += "0";
			}
			if (g.Substring(i, 1) == "b")
			{
				text += "1";
			}
			if (g.Substring(i, 1) == "c")
			{
				text += "2";
			}
			if (g.Substring(i, 1) == "d")
			{
				text += "3";
			}
			if (g.Substring(i, 1) == "e")
			{
				text += "4";
			}
			if (g.Substring(i, 1) == "f")
			{
				text += "5";
			}
			if (g.Substring(i, 1) == "g")
			{
				text += "6";
			}
			if (g.Substring(i, 1) == "h")
			{
				text += "7";
			}
			if (g.Substring(i, 1) == "i")
			{
				text += "8";
			}
			if (g.Substring(i, 1) == "j")
			{
				text += "9";
			}
		}
		return text;
	}

	public virtual string returnGoldEncrypted(string g)
	{
		string text = null;
		for (int i = 0; i < UnityScript.Lang.Extensions.get_length(g); i++)
		{
			if (g.Substring(i, 1) == "0")
			{
				text += "a";
			}
			if (g.Substring(i, 1) == "1")
			{
				text += "b";
			}
			if (g.Substring(i, 1) == "2")
			{
				text += "c";
			}
			if (g.Substring(i, 1) == "3")
			{
				text += "d";
			}
			if (g.Substring(i, 1) == "4")
			{
				text += "e";
			}
			if (g.Substring(i, 1) == "5")
			{
				text += "f";
			}
			if (g.Substring(i, 1) == "6")
			{
				text += "g";
			}
			if (g.Substring(i, 1) == "7")
			{
				text += "h";
			}
			if (g.Substring(i, 1) == "8")
			{
				text += "i";
			}
			if (g.Substring(i, 1) == "9")
			{
				text += "j";
			}
		}
		return text;
	}

	[RPC]
	public virtual void checkForAFK(PhotonMessageInfo info)
	{
		if (PhotonNetwork.isMasterClient)
		{
			if (UnityScript.Lang.Extensions.get_length((System.Array)PhotonNetwork.playerList) == 1 && !CalculateHealth.isafking)
			{
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("awardGold", info.sender);
			}
			else if (UnityScript.Lang.Extensions.get_length((System.Array)PhotonNetwork.playerList) > 1)
			{
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("awardGold", info.sender);
			}
		}
		else if (!CalculateHealth.isafking)
		{
			((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("awardGold", info.sender);
		}
	}

	public virtual void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.name == "HumanPrefab(Clone)" && ((PhotonView)col.transform.gameObject.GetComponent(typeof(PhotonView))).isMine && !ChatScript.isCar)
		{
			GameObject.Find("/GUI/SubMessage").SendMessage("setMessage", "You cannot pick up items when outside the car!");
		}
		if (!(col.gameObject.name == "MainBoxCol") || !ChatScript.isCar || !((PhotonView)col.gameObject.GetComponent(typeof(PhotonView))).isMine || !(SpawningScript.team2 != string.Empty) || !RefreshMasterServer.personjoined || ((AIManager)col.transform.root.gameObject.GetComponent(typeof(AIManager))).isAI)
		{
			return;
		}
		if (SpawningScript.team2 != team)
		{
			if (!gotflag && !othergotflag)
			{
				col.gameObject.SendMessage("setflagteam", team);
				col.gameObject.SendMessage("setctf", true);
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("flashcolors", PhotonTargets.All, false);
				gotflag = true;
				srcobj.SendMessage("OutsideSystem", AuthGameObject.username + " stole the " + team + " flag!");
			}
		}
		else
		{
			if (!gotflag)
			{
				return;
			}
			if (PhotonNetwork.isMasterClient && RefreshMasterServer.personjoined)
			{
				if (UnityScript.Lang.Extensions.get_length((System.Array)PhotonNetwork.playerList) == 1)
				{
					((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("checkForAFK", PhotonTargets.Others);
				}
				else
				{
					awardGold();
				}
			}
			else
			{
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("checkForAFK", PhotonTargets.MasterClient);
			}
			gotflag = false;
			othergotflag = false;
			col.gameObject.SendMessage("setctf", false);
			((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("otherflashcolors", PhotonTargets.All);
			if (!reclaim)
			{
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("flashcolorsonly", PhotonTargets.All);
				if (team == "red")
				{
					srcobj.SendMessage("OutsideSystem", AuthGameObject.username + " scored a flag capture for the red team!");
					igs.SendMessage("bluedeath");
				}
				else
				{
					srcobj.SendMessage("OutsideSystem", AuthGameObject.username + " scored a flag capture for the blue team!");
					igs.SendMessage("reddeath");
				}
			}
			else
			{
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("flashcolors", PhotonTargets.All, true);
				reclaim = false;
				srcobj.SendMessage("OutsideSystem", AuthGameObject.username + " returned the stolen " + team + " flag!");
			}
		}
	}

	public virtual void Update()
	{
		if (CTFDelegate.dropflagvar)
		{
			gotflag = false;
			reclaim = false;
		}
		if (CTFDroppedFlag.reclaimflag == 1 || CTFDroppedFlag.reclaimflag == 2)
		{
			gotflag = true;
			if (CTFDroppedFlag.reclaimflag == 2)
			{
				reclaim = true;
			}
		}
		if (AuthGameObject.gametype != "Capture the Flag")
		{
			gameObject.SetActiveRecursively(false);
		}
		if (EndofRound.resetflags)
		{
			reclaim = false;
			((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("flashcolors", PhotonTargets.All, true);
		}
		reclaimstat = reclaim;
	}

	[RPC]
	public virtual void otherflashcolors()
	{
		otherflagunit.SendMessage("flashcolors", true);
	}

	[RPC]
	public virtual IEnumerator flashcolorsonly()
	{
		return new _0024flashcolorsonly_00243401(this).GetEnumerator();
	}

	[RPC]
	public virtual IEnumerator flashcolors(bool t)
	{
		return new _0024flashcolors_00243404(t, this).GetEnumerator();
	}
}
