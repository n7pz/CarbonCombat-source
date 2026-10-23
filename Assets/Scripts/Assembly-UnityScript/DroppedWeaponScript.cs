using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Photon;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class DroppedWeaponScript : Photon.MonoBehaviour
{
	[Serializable]
	internal sealed class _0024Start_00243620 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal DroppedWeaponScript _0024self__00243621;

			public _0024(DroppedWeaponScript self_)
			{
				_0024self__00243621 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (!_0024self__00243621.isPickup)
					{
						result = (Yield(2, new WaitForSeconds(120f)) ? 1 : 0);
						break;
					}
					goto IL_004b;
				case 2:
					UnityEngine.Object.Destroy(_0024self__00243621.gameObject);
					goto IL_004b;
				case 1:
					{
						result = 0;
						break;
					}
					IL_004b:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal DroppedWeaponScript _0024self__00243622;

		public _0024Start_00243620(DroppedWeaponScript self_)
		{
			_0024self__00243622 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00243622);
		}
	}

	[Serializable]
	internal sealed class _0024destroyPickup_00243623 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal GameObject _0024obj2_00243624;

			internal int _0024_0024504_00243625;

			internal GameObject[] _0024_0024505_00243626;

			internal int _0024_0024506_00243627;

			internal DroppedWeaponScript _0024self__00243628;

			public _0024(DroppedWeaponScript self_)
			{
				_0024self__00243628 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00243628.pickupEnabled = false;
					_0024_0024504_00243625 = 0;
					_0024_0024505_00243626 = _0024self__00243628.guns2;
					for (_0024_0024506_00243627 = _0024_0024505_00243626.Length; _0024_0024504_00243625 < _0024_0024506_00243627; _0024_0024504_00243625++)
					{
						_0024_0024505_00243626[_0024_0024504_00243625].SetActiveRecursively(false);
					}
					if (PhotonNetwork.isMasterClient)
					{
						result = (Yield(2, new WaitForSeconds(60f)) ? 1 : 0);
						break;
					}
					goto IL_00e7;
				case 2:
					((PhotonView)_0024self__00243628.gameObject.GetComponent(typeof(PhotonView))).RPC("setWeapon", PhotonTargets.All, _0024self__00243628.gunType, "blue");
					goto IL_00e7;
				case 1:
					{
						result = 0;
						break;
					}
					IL_00e7:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal DroppedWeaponScript _0024self__00243629;

		public _0024destroyPickup_00243623(DroppedWeaponScript self_)
		{
			_0024self__00243629 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00243629);
		}
	}

	public GameObject[] guns;

	public GameObject[] guns2;

	private string enabledwep;

	public ChatScript cscript;

	public FireGun fgun;

	public bool isPickup;

	public string gunType;

	private bool pickupEnabled;

	public DroppedWeaponScript()
	{
		gunType = string.Empty;
		pickupEnabled = true;
	}

	public virtual void Awake()
	{
		if (!isPickup)
		{
			int i = 0;
			GameObject[] array = guns;
			for (int length = array.Length; i < length; i++)
			{
				array[i].SetActiveRecursively(false);
			}
		}
		int j = 0;
		GameObject[] array2 = guns2;
		for (int length2 = array2.Length; j < length2; j++)
		{
			array2[j].SetActiveRecursively(false);
		}
		if (isPickup)
		{
			setWeapon(gunType, "blue");
		}
	}

	public virtual IEnumerator Start()
	{
		return new _0024Start_00243620(this).GetEnumerator();
	}

	[RPC]
	public virtual void setWeapon(string s, string t)
	{
		pickupEnabled = true;
		enabledwep = s;
		if (t == "red")
		{
			int i = 0;
			GameObject[] array = guns;
			for (int length = array.Length; i < length; i++)
			{
				if (array[i].name == s)
				{
					array[i].SetActiveRecursively(true);
					guns[UnityScript.Lang.Extensions.get_length((System.Array)guns) - 1].active = true;
					break;
				}
			}
			return;
		}
		int j = 0;
		GameObject[] array2 = guns2;
		for (int length2 = array2.Length; j < length2; j++)
		{
			if (array2[j].name == s)
			{
				array2[j].SetActiveRecursively(true);
				guns2[UnityScript.Lang.Extensions.get_length((System.Array)guns2) - 1].active = true;
				break;
			}
		}
	}

	public virtual void OnTriggerEnter(Collider col)
	{
		if (!pickupEnabled)
		{
			return;
		}
		if (col.gameObject.name == "CarPrefab(Clone)")
		{
			ReturnName returnName = (ReturnName)col.gameObject.GetComponent("ReturnName");
			if (((PhotonView)col.gameObject.GetComponent(typeof(PhotonView))).isMine && !returnName.returnAI() && ChatScript.isCar && !ChatScript.isPickingUpTemp)
			{
				string text = enabledwep;
				if (text == "grappling")
				{
					text = "grappling hook";
				}
				if (text == "lasercannon")
				{
					text = "laser cannon";
				}
				if (text == "laser")
				{
					text = "plasma blaster";
				}
				if (text == "missile")
				{
					text = "missile launcher";
				}
				if (text == "rocket")
				{
					text = "rocket launcher";
				}
				if (text == "emplauncher")
				{
					text = "EMP launcher";
				}
				if (text == "launcher")
				{
					text = "grenade launcher";
				}
				if (text == "shotgun")
				{
					text = "shotgun";
				}
				if (text == "railgun" && Application.loadedLevelName == "MainScene" && isPickup)
				{
					GameObject.Find("/AuthGameObject").SendMessage("gotAch", "Find the Railgun");
				}
				if (ChatScript.primaryweapon != enabledwep && ChatScript.secondaryweapon != enabledwep)
				{
					if (FireGun.guntype == "rocket")
					{
						GameObject.Find("/GUI/Chat").SendMessage("changeWeapons", enabledwep + "|2");
						GameObject.Find("/GUI/SubMessage").SendMessage("setMessage4", "Equipping " + text + " as secondary weapon...\nPress [3] to cancel");
					}
					else
					{
						GameObject.Find("/GUI/Chat").SendMessage("changeWeapons", enabledwep + "|1");
						GameObject.Find("/GUI/SubMessage").SendMessage("setMessage4", "Equipping " + text + " as primary weapon...\nPress [3] to cancel");
					}
				}
				if (!isPickup)
				{
					((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("destroyAll", PhotonTargets.AllBuffered);
				}
				else
				{
					((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("destroyPickup", PhotonTargets.AllBuffered);
				}
			}
		}
		if (col.gameObject.name == "HumanPrefab(Clone)" && ((PhotonView)col.transform.gameObject.GetComponent(typeof(PhotonView))).isMine && !ChatScript.isCar)
		{
			GameObject.Find("/GUI/SubMessage").SendMessage("setMessage", "You cannot pick up items when outside the car!");
		}
	}

	[RPC]
	public virtual IEnumerator destroyPickup()
	{
		return new _0024destroyPickup_00243623(this).GetEnumerator();
	}

	[RPC]
	public virtual void customNetDestroy()
	{
		UnityEngine.Object.Destroy(gameObject);
	}

	[RPC]
	public virtual void destroyAll()
	{
		if (PhotonNetwork.isMasterClient)
		{
			((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("customNetDestroy", PhotonTargets.All);
		}
	}
}
