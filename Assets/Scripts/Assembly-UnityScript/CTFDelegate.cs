using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using Photon;
using UnityEngine;

[Serializable]
public class CTFDelegate : Photon.MonoBehaviour
{
	[Serializable]
	internal sealed class _0024OnPhotonPlayerDisconnected_00243368 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal GameObject _0024spawnobj_00243369;

			internal Vector3 _0024pos_00243370;

			internal string _0024team_00243371;

			internal bool _0024boo_00243372;

			internal PhotonPlayer _0024player_00243373;

			internal CTFDelegate _0024self__00243374;

			public _0024(PhotonPlayer player, CTFDelegate self_)
			{
				_0024player_00243373 = player;
				_0024self__00243374 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (!RuntimeServices.EqualityOperator(_0024player_00243373, PhotonNetwork.player) && ptable.ContainsKey(_0024player_00243373) && etable.ContainsKey(_0024player_00243373) && RuntimeServices.ToBool(etable[_0024player_00243373]))
					{
						_0024spawnobj_00243369 = GameObject.Find("/Spawn Point");
						_0024spawnobj_00243369.SendMessage("droppedflag", _0024player_00243373);
						_0024pos_00243370 = (Vector3)ptable[_0024player_00243373];
						object obj = ttable[_0024player_00243373];
						if (!(obj is string))
						{
							obj = RuntimeServices.Coerce(obj, typeof(string));
						}
						_0024team_00243371 = (string)obj;
						_0024boo_00243372 = RuntimeServices.UnboxBoolean(etable[_0024player_00243373]);
						ptable.Remove(_0024player_00243373);
						ttable.Remove(_0024player_00243373);
						etable.Remove(_0024player_00243373);
						result = (Yield(2, new WaitForSeconds(1.5f)) ? 1 : 0);
						break;
					}
					goto IL_0185;
				case 2:
					if (PhotonNetwork.isMasterClient && _0024boo_00243372)
					{
						_0024self__00243374.StartCoroutine_Auto(_0024self__00243374.dropflag(_0024pos_00243370, _0024team_00243371));
					}
					goto IL_0185;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0185:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal PhotonPlayer _0024player_00243375;

		internal CTFDelegate _0024self__00243376;

		public _0024OnPhotonPlayerDisconnected_00243368(PhotonPlayer player, CTFDelegate self_)
		{
			_0024player_00243375 = player;
			_0024self__00243376 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024player_00243375, _0024self__00243376);
		}
	}

	[Serializable]
	internal sealed class _0024dropflag_00243377 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal RaycastHit _0024hit_00243378;

			internal Quaternion _0024rot_00243379;

			internal Vector3 _0024pos_00243380;

			internal Vector3 _0024t_00243381;

			internal string _0024f_00243382;

			internal CTFDelegate _0024self__00243383;

			public _0024(Vector3 t, string f, CTFDelegate self_)
			{
				_0024t_00243381 = t;
				_0024f_00243382 = f;
				_0024self__00243383 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024hit_00243378 = default(RaycastHit);
					if (Physics.Raycast(_0024t_00243381, -Vector3.up, out _0024hit_00243378, float.PositiveInfinity, _0024self__00243383.layermask))
					{
						_0024rot_00243379 = Quaternion.FromToRotation(Vector3.up, _0024hit_00243378.normal);
						_0024pos_00243380 = _0024hit_00243378.point;
						_0024pos_00243380.y += 3.3f;
						if (_0024f_00243382 != string.Empty)
						{
							_0024self__00243383.rpcdrop(_0024pos_00243380, _0024rot_00243379, _0024f_00243382);
						}
						else
						{
							_0024self__00243383.rpcdrop(_0024pos_00243380, _0024rot_00243379, _0024self__00243383.flagteam);
						}
					}
					dropflagvar = true;
					result = (YieldDefault(2) ? 1 : 0);
					break;
				case 2:
					result = (YieldDefault(3) ? 1 : 0);
					break;
				case 3:
					result = (YieldDefault(4) ? 1 : 0);
					break;
				case 4:
					dropflagvar = false;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Vector3 _0024t_00243384;

		internal string _0024f_00243385;

		internal CTFDelegate _0024self__00243386;

		public _0024dropflag_00243377(Vector3 t, string f, CTFDelegate self_)
		{
			_0024t_00243384 = t;
			_0024f_00243385 = f;
			_0024self__00243386 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024t_00243384, _0024f_00243385, _0024self__00243386);
		}
	}

	public Renderer rocketgun;

	public GameObject lasergun;

	public GameObject ctfgun;

	public GameObject ctfgunred;

	public GameObject toggleguns;

	public GameObject firepoint;

	public GameObject flagprefab;

	public GameObject flagprefabred;

	public SpawningScript src;

	public ToggleGuns toggun;

	public AuthGameObject authobj;

	public CTFFlagSender flagsender;

	public ChatScript cscript;

	public string flagteam;

	[NonSerialized]
	public static bool dropflagvar;

	[NonSerialized]
	public static Collider maincol;

	[NonSerialized]
	public static Hashtable ptable;

	[NonSerialized]
	public static Hashtable ttable;

	[NonSerialized]
	public static Hashtable etable;

	[NonSerialized]
	public static PhotonPlayer serverplayer;

	[NonSerialized]
	public static string servername;

	[NonSerialized]
	public static Vector3 serverloc;

	[NonSerialized]
	public static string serverteam;

	[NonSerialized]
	public static bool serverbol;

	[NonSerialized]
	public static bool sayonce;

	private bool wasserver;

	private bool ctfgotdisconnected;

	public LayerMask layermask;

	public GameObject flamethrower;

	public GameObject minigun;

	public GameObject launcher;

	public GameObject missile;

	public GameObject railgun;

	public GameObject lasercannon;

	public GameObject shotgun;

	public AIManager aimanager;

	public virtual void Start()
	{
		if (ptable != null)
		{
			ptable.Clear();
		}
		if (ttable != null)
		{
			ttable.Clear();
		}
		if (etable != null)
		{
			etable.Clear();
		}
		if (photonView.isMine && !aimanager.isAI)
		{
			((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("addme", PhotonTargets.All, transform.position);
			if (ctfgotdisconnected)
			{
				int i = 0;
				GameObject[] array = (GameObject[])UnityEngine.Object.FindObjectsOfType(typeof(GameObject));
				for (int length = array.Length; i < length; i++)
				{
					if (array[i].name == "FlagPrefabBlue(Clone)" || array[i].name == "FlagPrefabRed(Clone)")
					{
						UnityEngine.Object.Destroy(array[i]);
					}
				}
			}
		}
		if ((AuthGameObject.gametype == "Freeplay" || AuthGameObject.gametype == "Deathmatch" || AuthGameObject.gametype == "Survival") && photonView.isMine && !aimanager.isAI)
		{
			gameObject.tag = "Untagged";
		}
		ptable.Clear();
		ttable.Clear();
		etable.Clear();
		dropflagvar = false;
		if (photonView.isMine || aimanager.isAI)
		{
			maincol = collider;
			ctfgunred.SetActiveRecursively(false);
			ctfgun.SetActiveRecursively(false);
			setctf(false);
		}
		if (PhotonNetwork.isMasterClient)
		{
			wasserver = true;
		}
		sayonce = false;
		if (AuthGameObject.gametype == "Capture the Flag")
		{
			if (!photonView.isMine)
			{
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("setstate", photonView.owner);
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("addme", PhotonTargets.All, transform.position);
			}
			else
			{
				setctf(false);
			}
		}
		else if (photonView.isMine || aimanager.isAI)
		{
			setctf(false);
		}
		else
		{
			((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("setstate", photonView.owner);
		}
	}

	public virtual void OnCreatedRoom()
	{
		ctfgotdisconnected = false;
		if (PhotonNetwork.isMasterClient)
		{
			wasserver = true;
		}
		sayonce = false;
		if (!ctfgotdisconnected || !(AuthGameObject.gametype == "Capture the Flag"))
		{
			return;
		}
		int i = 0;
		GameObject[] array = (GameObject[])UnityEngine.Object.FindObjectsOfType(typeof(GameObject));
		for (int length = array.Length; i < length; i++)
		{
			if (array[i].name == "FlagPrefabBlue(Clone)")
			{
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("serverCreateFlag", PhotonTargets.AllBuffered, "blue", array[i].transform.position, array[i].transform.rotation);
			}
			if (array[i].name == "FlagPrefabRed(Clone)")
			{
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("serverCreateFlag", PhotonTargets.AllBuffered, "red", array[i].transform.position, array[i].transform.rotation);
			}
		}
	}

	[RPC]
	public virtual void serverCreateFlag(string t, Vector3 pos, Quaternion rot)
	{
		UnityEngine.Object.Instantiate((!(t == "blue")) ? flagprefabred : flagprefab, pos, rot);
	}

	[RPC]
	public virtual void addme(Vector3 t, PhotonMessageInfo info)
	{
		if (!ptable.ContainsKey(info.sender))
		{
			ptable.Add(info.sender, t);
		}
		((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("returnedserver", info.sender, AuthGameObject.username);
	}

	[RPC]
	public virtual void returnedserver(string s, PhotonMessageInfo info)
	{
		servername = s;
		serverplayer = info.sender;
	}

	public virtual void Update()
	{
		if (!(AuthGameObject.gametype == "Capture the Flag"))
		{
			return;
		}
		ptable[photonView.owner] = transform.position;
		if (!ttable.ContainsKey(photonView.owner))
		{
			ttable.Add(photonView.owner, flagteam);
		}
		else
		{
			ttable[photonView.owner] = flagteam;
		}
		if (!etable.ContainsKey(photonView.owner))
		{
			if (ctfgun.active || ctfgunred.active)
			{
				etable.Add(photonView.owner, true);
			}
			else
			{
				etable.Add(photonView.owner, false);
			}
		}
		else if (ctfgun.active || ctfgunred.active)
		{
			etable[photonView.owner] = true;
		}
		else
		{
			etable[photonView.owner] = false;
		}
	}

	public virtual IEnumerator OnPhotonPlayerDisconnected(PhotonPlayer player)
	{
		return new _0024OnPhotonPlayerDisconnected_00243368(player, this).GetEnumerator();
	}

	[RPC]
	public virtual void setstate(PhotonMessageInfo info)
	{
		if (ctfgun.active || ctfgunred.active)
		{
			if (ctfgun.active)
			{
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("setflagteamrpc", info.sender, "blue");
			}
			else
			{
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("setflagteamrpc", info.sender, "red");
			}
			((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("rpcsetctf", info.sender, true, "nothing");
			return;
		}
		string text = null;
		if (rocketgun.enabled)
		{
			text = "rocket";
		}
		if (lasergun.active)
		{
			text = "laser";
		}
		if (flamethrower.active)
		{
			text = "flamethrower";
		}
		if (minigun.active)
		{
			text = "minigun";
		}
		if (launcher.active)
		{
			text = "launcher";
		}
		if (missile.active)
		{
			text = "missile";
		}
		if (railgun.active)
		{
			text = "railgun";
		}
		if (lasercannon.active)
		{
			text = "lasercannon";
		}
		if (shotgun.active)
		{
			text = "shotgun";
		}
		((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("rpcsetctf", info.sender, false, text);
	}

	public virtual void setflagteam(string t)
	{
		((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("setflagteamrpc", PhotonTargets.All, t);
	}

	[RPC]
	public virtual void setflagteamrpc(string t)
	{
		flagteam = t;
	}

	public virtual void setctf(bool t)
	{
		if (!photonView.isMine && !aimanager.isAI)
		{
			return;
		}
		toggleguns.SendMessage("setctf", t);
		firepoint.SendMessage("setctf", t);
		if (t && AuthGameObject.gametype == "Capture the Flag")
		{
			rocketgun.enabled = false;
			lasergun.SetActiveRecursively(false);
			flamethrower.SetActiveRecursively(false);
			minigun.SetActiveRecursively(false);
			launcher.SetActiveRecursively(false);
			missile.SetActiveRecursively(false);
			railgun.SetActiveRecursively(false);
			lasercannon.SetActiveRecursively(false);
			shotgun.SetActiveRecursively(false);
			if (flagteam == "red")
			{
				ctfgunred.SetActiveRecursively(t);
				ctfgun.SetActiveRecursively(!t);
			}
			else
			{
				ctfgun.SetActiveRecursively(t);
				ctfgunred.SetActiveRecursively(!t);
			}
		}
		else
		{
			ctfgunred.SetActiveRecursively(false);
			ctfgun.SetActiveRecursively(false);
			if (ToggleGuns.curmode == 1)
			{
				if (ChatScript.primaryweapon == "rocket" || (aimanager.isAI && aimanager.firetype == 0))
				{
					rocketgun.enabled = true;
					lasergun.SetActiveRecursively(false);
					flamethrower.SetActiveRecursively(false);
					minigun.SetActiveRecursively(false);
					launcher.SetActiveRecursively(false);
					missile.SetActiveRecursively(false);
					railgun.SetActiveRecursively(false);
					lasercannon.SetActiveRecursively(false);
					shotgun.SetActiveRecursively(false);
				}
				if (ChatScript.primaryweapon == "laser" || (aimanager.isAI && aimanager.firetype == 1))
				{
					rocketgun.enabled = false;
					lasergun.SetActiveRecursively(true);
					flamethrower.SetActiveRecursively(false);
					minigun.SetActiveRecursively(false);
					launcher.SetActiveRecursively(false);
					missile.SetActiveRecursively(false);
					railgun.SetActiveRecursively(false);
					lasercannon.SetActiveRecursively(false);
					shotgun.SetActiveRecursively(false);
				}
				if (!aimanager.isAI)
				{
					if ((ChatScript.primaryweapon == "launcher" || ChatScript.primaryweapon == "emplauncher" || ChatScript.primaryweapon == "grappling") && !aimanager.isAI)
					{
						rocketgun.enabled = false;
						lasergun.SetActiveRecursively(false);
						flamethrower.SetActiveRecursively(false);
						minigun.SetActiveRecursively(false);
						launcher.SetActiveRecursively(true);
						missile.SetActiveRecursively(false);
						railgun.SetActiveRecursively(false);
						lasercannon.SetActiveRecursively(false);
						shotgun.SetActiveRecursively(false);
					}
					if (ChatScript.primaryweapon == "flamethrower" && !aimanager.isAI)
					{
						rocketgun.enabled = false;
						lasergun.SetActiveRecursively(false);
						flamethrower.SetActiveRecursively(true);
						minigun.SetActiveRecursively(false);
						launcher.SetActiveRecursively(false);
						missile.SetActiveRecursively(false);
						railgun.SetActiveRecursively(false);
						lasercannon.SetActiveRecursively(false);
						shotgun.SetActiveRecursively(false);
					}
					if (ChatScript.primaryweapon == "minigun" && !aimanager.isAI)
					{
						rocketgun.enabled = false;
						lasergun.SetActiveRecursively(false);
						flamethrower.SetActiveRecursively(false);
						minigun.SetActiveRecursively(true);
						launcher.SetActiveRecursively(false);
						missile.SetActiveRecursively(false);
						railgun.SetActiveRecursively(false);
						lasercannon.SetActiveRecursively(false);
						shotgun.SetActiveRecursively(false);
					}
					if (ChatScript.primaryweapon == "laser")
					{
						rocketgun.enabled = false;
						lasergun.SetActiveRecursively(true);
						flamethrower.SetActiveRecursively(false);
						minigun.SetActiveRecursively(false);
						launcher.SetActiveRecursively(false);
						missile.SetActiveRecursively(false);
						railgun.SetActiveRecursively(false);
						lasercannon.SetActiveRecursively(false);
						shotgun.SetActiveRecursively(false);
					}
					if (ChatScript.primaryweapon == "missile" && !aimanager.isAI)
					{
						rocketgun.enabled = false;
						lasergun.SetActiveRecursively(false);
						flamethrower.SetActiveRecursively(false);
						minigun.SetActiveRecursively(false);
						launcher.SetActiveRecursively(false);
						missile.SetActiveRecursively(true);
						railgun.SetActiveRecursively(false);
						lasercannon.SetActiveRecursively(false);
						shotgun.SetActiveRecursively(false);
					}
					if (ChatScript.primaryweapon == "railgun" && !aimanager.isAI)
					{
						rocketgun.enabled = false;
						lasergun.SetActiveRecursively(false);
						flamethrower.SetActiveRecursively(false);
						minigun.SetActiveRecursively(false);
						launcher.SetActiveRecursively(false);
						missile.SetActiveRecursively(false);
						railgun.SetActiveRecursively(true);
						lasercannon.SetActiveRecursively(false);
						shotgun.SetActiveRecursively(false);
					}
					if (ChatScript.primaryweapon == "lasercannon" && !aimanager.isAI)
					{
						rocketgun.enabled = false;
						lasergun.SetActiveRecursively(false);
						flamethrower.SetActiveRecursively(false);
						minigun.SetActiveRecursively(false);
						launcher.SetActiveRecursively(false);
						missile.SetActiveRecursively(false);
						railgun.SetActiveRecursively(false);
						lasercannon.SetActiveRecursively(true);
						shotgun.SetActiveRecursively(false);
					}
					if (ChatScript.primaryweapon == "shotgun" && !aimanager.isAI)
					{
						rocketgun.enabled = false;
						lasergun.SetActiveRecursively(false);
						flamethrower.SetActiveRecursively(false);
						minigun.SetActiveRecursively(false);
						launcher.SetActiveRecursively(false);
						missile.SetActiveRecursively(false);
						railgun.SetActiveRecursively(false);
						lasercannon.SetActiveRecursively(false);
						shotgun.SetActiveRecursively(true);
					}
				}
			}
			else if (!aimanager.isAI)
			{
				if (ChatScript.secondaryweapon == "rocket")
				{
					rocketgun.enabled = true;
					lasergun.SetActiveRecursively(false);
					flamethrower.SetActiveRecursively(false);
					minigun.SetActiveRecursively(false);
					launcher.SetActiveRecursively(false);
					missile.SetActiveRecursively(false);
					railgun.SetActiveRecursively(false);
					lasercannon.SetActiveRecursively(false);
					shotgun.SetActiveRecursively(false);
				}
				if (ChatScript.secondaryweapon == "launcher" || ChatScript.secondaryweapon == "emplauncher" || ChatScript.secondaryweapon == "grappling")
				{
					rocketgun.enabled = false;
					lasergun.SetActiveRecursively(false);
					flamethrower.SetActiveRecursively(false);
					minigun.SetActiveRecursively(false);
					launcher.SetActiveRecursively(true);
					missile.SetActiveRecursively(false);
					railgun.SetActiveRecursively(false);
					lasercannon.SetActiveRecursively(false);
					shotgun.SetActiveRecursively(false);
				}
				if (ChatScript.secondaryweapon == "flamethrower")
				{
					rocketgun.enabled = false;
					lasergun.SetActiveRecursively(false);
					flamethrower.SetActiveRecursively(true);
					minigun.SetActiveRecursively(false);
					launcher.SetActiveRecursively(false);
					missile.SetActiveRecursively(false);
					railgun.SetActiveRecursively(false);
					lasercannon.SetActiveRecursively(false);
					shotgun.SetActiveRecursively(false);
				}
				if (ChatScript.secondaryweapon == "minigun")
				{
					rocketgun.enabled = false;
					lasergun.SetActiveRecursively(false);
					flamethrower.SetActiveRecursively(false);
					minigun.SetActiveRecursively(true);
					launcher.SetActiveRecursively(false);
					missile.SetActiveRecursively(false);
					railgun.SetActiveRecursively(false);
					lasercannon.SetActiveRecursively(false);
					shotgun.SetActiveRecursively(false);
				}
				if (ChatScript.secondaryweapon == "laser")
				{
					rocketgun.enabled = false;
					lasergun.SetActiveRecursively(true);
					flamethrower.SetActiveRecursively(false);
					minigun.SetActiveRecursively(false);
					launcher.SetActiveRecursively(false);
					missile.SetActiveRecursively(false);
					railgun.SetActiveRecursively(false);
					lasercannon.SetActiveRecursively(false);
					shotgun.SetActiveRecursively(false);
				}
				if (ChatScript.secondaryweapon == "missile")
				{
					rocketgun.enabled = false;
					lasergun.SetActiveRecursively(false);
					flamethrower.SetActiveRecursively(false);
					minigun.SetActiveRecursively(false);
					launcher.SetActiveRecursively(false);
					missile.SetActiveRecursively(true);
					railgun.SetActiveRecursively(false);
					lasercannon.SetActiveRecursively(false);
					shotgun.SetActiveRecursively(false);
				}
				if (ChatScript.secondaryweapon == "railgun")
				{
					rocketgun.enabled = false;
					lasergun.SetActiveRecursively(false);
					flamethrower.SetActiveRecursively(false);
					minigun.SetActiveRecursively(false);
					launcher.SetActiveRecursively(false);
					missile.SetActiveRecursively(false);
					railgun.SetActiveRecursively(true);
					lasercannon.SetActiveRecursively(false);
					shotgun.SetActiveRecursively(false);
				}
				if (ChatScript.secondaryweapon == "lasercannon")
				{
					rocketgun.enabled = false;
					lasergun.SetActiveRecursively(false);
					flamethrower.SetActiveRecursively(false);
					minigun.SetActiveRecursively(false);
					launcher.SetActiveRecursively(false);
					missile.SetActiveRecursively(false);
					railgun.SetActiveRecursively(false);
					lasercannon.SetActiveRecursively(true);
					shotgun.SetActiveRecursively(false);
				}
				if (ChatScript.secondaryweapon == "shotgun")
				{
					rocketgun.enabled = false;
					lasergun.SetActiveRecursively(false);
					flamethrower.SetActiveRecursively(false);
					minigun.SetActiveRecursively(false);
					launcher.SetActiveRecursively(false);
					missile.SetActiveRecursively(false);
					railgun.SetActiveRecursively(false);
					lasercannon.SetActiveRecursively(false);
					shotgun.SetActiveRecursively(true);
				}
			}
		}
		if (!aimanager.isAI)
		{
			if (ToggleGuns.curmode == 1)
			{
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("rpcsetctf", PhotonTargets.Others, t, ChatScript.primaryweapon);
			}
			else
			{
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("rpcsetctf", PhotonTargets.Others, t, ChatScript.secondaryweapon);
			}
		}
		else
		{
			((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("rpcsetctf", PhotonTargets.Others, t, (aimanager.firetype != 0) ? "laser" : "rocket");
		}
	}

	public virtual void dropflagdel(Vector3 t)
	{
		StartCoroutine_Auto(dropflag(t, string.Empty));
	}

	public virtual IEnumerator dropflag(Vector3 t, string f)
	{
		return new _0024dropflag_00243377(t, f, this).GetEnumerator();
	}

	public virtual void rpcdrop(Vector3 t, Quaternion q, string s)
	{
		if (s == "red")
		{
			PhotonNetwork.Instantiate(flagprefabred.name, t, q, 0);
		}
		else
		{
			PhotonNetwork.Instantiate(flagprefab.name, t, q, 0);
		}
	}

	[RPC]
	public virtual void rpcsetctf(bool t, string i)
	{
		toggleguns.SendMessage("setctf", t);
		if (t && AuthGameObject.gametype == "Capture the Flag")
		{
			rocketgun.enabled = false;
			lasergun.SetActiveRecursively(false);
			flamethrower.SetActiveRecursively(false);
			minigun.SetActiveRecursively(false);
			launcher.SetActiveRecursively(false);
			missile.SetActiveRecursively(false);
			railgun.SetActiveRecursively(false);
			lasercannon.SetActiveRecursively(false);
			shotgun.SetActiveRecursively(false);
			if (flagteam == "red")
			{
				ctfgunred.SetActiveRecursively(t);
				ctfgun.SetActiveRecursively(!t);
			}
			else
			{
				ctfgun.SetActiveRecursively(t);
				ctfgunred.SetActiveRecursively(!t);
			}
			return;
		}
		ctfgunred.SetActiveRecursively(false);
		ctfgun.SetActiveRecursively(false);
		if (i == "rocket")
		{
			rocketgun.enabled = true;
			lasergun.SetActiveRecursively(false);
			flamethrower.SetActiveRecursively(false);
			minigun.SetActiveRecursively(false);
			launcher.SetActiveRecursively(false);
			missile.SetActiveRecursively(false);
			railgun.SetActiveRecursively(false);
			lasercannon.SetActiveRecursively(false);
			shotgun.SetActiveRecursively(false);
		}
		switch (i)
		{
		case "launcher":
		case "emplauncher":
		case "grappling":
			rocketgun.enabled = false;
			lasergun.SetActiveRecursively(false);
			flamethrower.SetActiveRecursively(false);
			minigun.SetActiveRecursively(false);
			launcher.SetActiveRecursively(true);
			missile.SetActiveRecursively(false);
			railgun.SetActiveRecursively(false);
			lasercannon.SetActiveRecursively(false);
			shotgun.SetActiveRecursively(false);
			break;
		}
		if (i == "flamethrower")
		{
			rocketgun.enabled = false;
			lasergun.SetActiveRecursively(false);
			flamethrower.SetActiveRecursively(true);
			minigun.SetActiveRecursively(false);
			launcher.SetActiveRecursively(false);
			missile.SetActiveRecursively(false);
			railgun.SetActiveRecursively(false);
			lasercannon.SetActiveRecursively(false);
			shotgun.SetActiveRecursively(false);
		}
		if (i == "laser")
		{
			rocketgun.enabled = false;
			lasergun.SetActiveRecursively(true);
			flamethrower.SetActiveRecursively(false);
			minigun.SetActiveRecursively(false);
			launcher.SetActiveRecursively(false);
			missile.SetActiveRecursively(false);
			railgun.SetActiveRecursively(false);
			lasercannon.SetActiveRecursively(false);
			shotgun.SetActiveRecursively(false);
		}
		if (i == "minigun")
		{
			rocketgun.enabled = false;
			lasergun.SetActiveRecursively(false);
			flamethrower.SetActiveRecursively(false);
			minigun.SetActiveRecursively(true);
			launcher.SetActiveRecursively(false);
			missile.SetActiveRecursively(false);
			railgun.SetActiveRecursively(false);
			lasercannon.SetActiveRecursively(false);
			shotgun.SetActiveRecursively(false);
		}
		if (i == "missile")
		{
			rocketgun.enabled = false;
			lasergun.SetActiveRecursively(false);
			flamethrower.SetActiveRecursively(false);
			minigun.SetActiveRecursively(false);
			launcher.SetActiveRecursively(false);
			missile.SetActiveRecursively(true);
			railgun.SetActiveRecursively(false);
			lasercannon.SetActiveRecursively(false);
			shotgun.SetActiveRecursively(false);
		}
		if (i == "railgun")
		{
			rocketgun.enabled = false;
			lasergun.SetActiveRecursively(false);
			flamethrower.SetActiveRecursively(false);
			minigun.SetActiveRecursively(false);
			launcher.SetActiveRecursively(false);
			missile.SetActiveRecursively(false);
			railgun.SetActiveRecursively(true);
			lasercannon.SetActiveRecursively(false);
			shotgun.SetActiveRecursively(false);
		}
		if (i == "lasercannon")
		{
			rocketgun.enabled = false;
			lasergun.SetActiveRecursively(false);
			flamethrower.SetActiveRecursively(false);
			minigun.SetActiveRecursively(false);
			launcher.SetActiveRecursively(false);
			missile.SetActiveRecursively(false);
			railgun.SetActiveRecursively(false);
			lasercannon.SetActiveRecursively(true);
			shotgun.SetActiveRecursively(false);
		}
		if (i == "shotgun")
		{
			rocketgun.enabled = false;
			lasergun.SetActiveRecursively(false);
			flamethrower.SetActiveRecursively(false);
			minigun.SetActiveRecursively(false);
			launcher.SetActiveRecursively(false);
			missile.SetActiveRecursively(false);
			railgun.SetActiveRecursively(false);
			lasercannon.SetActiveRecursively(false);
			shotgun.SetActiveRecursively(true);
		}
	}

	public virtual void Main()
	{
		ptable = new Hashtable();
		ttable = new Hashtable();
		etable = new Hashtable();
	}
}
