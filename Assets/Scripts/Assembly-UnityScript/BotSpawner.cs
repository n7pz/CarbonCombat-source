using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Photon;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class BotSpawner : Photon.MonoBehaviour
{
	[Serializable]
	internal sealed class _0024SpawnBots_00243355 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal GameObject _0024kongobj_00243356;

			internal GameObject _0024bot_00243357;

			internal int _0024i_00243358;

			internal GameObject[] _0024bots_00243359;

			internal GameObject _0024obj_00243360;

			internal int _0024_0024424_00243361;

			internal GameObject[] _0024_0024425_00243362;

			internal int _0024_0024426_00243363;

			internal int _0024level_00243364;

			internal BotSpawner _0024self__00243365;

			public _0024(int level, BotSpawner self_)
			{
				_0024level_00243364 = level;
				_0024self__00243365 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024level_00243364 == _0024self__00243365.curlvl && _0024level_00243364 > 1)
					{
						_0024self__00243365.hold = true;
						_0024self__00243365.chatobj.SendMessage("OutsideSystemNoRPC", "You have destroyed all killer drones in wave " + (_0024level_00243364 - 1) + "! Next wave starting in 20 seconds...");
						if (Application.isWebPlayer)
						{
							_0024kongobj_00243356 = GameObject.Find("KongregateAPI");
							((KongregateAPI)_0024kongobj_00243356.GetComponent(typeof(KongregateAPI))).SubmitStat("numbdronewaves", _0024self__00243365.curlvl);
						}
						result = (Yield(2, new WaitForSeconds(20f)) ? 1 : 0);
						break;
					}
					goto case 2;
				case 2:
					_0024bot_00243357 = null;
					hiveMindTarget = SpawningScript.playertrans;
					_0024i_00243358 = 0;
					goto IL_01a2;
				case 3:
					_0024i_00243358++;
					goto IL_01a2;
				case 1:
					{
						result = 0;
						break;
					}
					IL_01a2:
					if (_0024i_00243358 < _0024level_00243364)
					{
						if (SpawningScript.team2 == "red")
						{
							_0024bot_00243357 = (GameObject)UnityEngine.Object.Instantiate(_0024self__00243365.bluebot, _0024self__00243365.bluespawn.position, _0024self__00243365.bluespawn.rotation);
						}
						else
						{
							_0024bot_00243357 = (GameObject)UnityEngine.Object.Instantiate(_0024self__00243365.redbot, _0024self__00243365.redspawn.position, _0024self__00243365.redspawn.rotation);
						}
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					if (CloakPickup.iscloakedstat)
					{
						_0024bots_00243359 = GameObject.FindGameObjectsWithTag("Bot");
						_0024_0024424_00243361 = 0;
						_0024_0024425_00243362 = _0024bots_00243359;
						for (_0024_0024426_00243363 = _0024_0024425_00243362.Length; _0024_0024424_00243361 < _0024_0024426_00243363; _0024_0024424_00243361++)
						{
							_0024_0024425_00243362[_0024_0024424_00243361].SendMessage("PlayerCloak", true);
						}
					}
					if (QualitySettings.GetQualityLevel() == 0)
					{
						GameObject.Find("/GUI/QualitySettings").SendMessage("setAllObjectsSimp");
					}
					if (_0024level_00243364 == 1)
					{
						_0024self__00243365.chatobj.SendMessage("OutsideSystemNoRPC", "Wave 1 of the killer drones has been released (1 drone spawned).");
					}
					else
					{
						_0024self__00243365.chatobj.SendMessage("OutsideSystemNoRPC", "Wave " + _0024level_00243364 + " of the killer drones has been released (" + _0024level_00243364 + " drones spawned).");
					}
					_0024self__00243365.curlvl = _0024level_00243364;
					_0024self__00243365.curlvl++;
					_0024self__00243365.hold = false;
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal int _0024level_00243366;

		internal BotSpawner _0024self__00243367;

		public _0024SpawnBots_00243355(int level, BotSpawner self_)
		{
			_0024level_00243366 = level;
			_0024self__00243367 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024level_00243366, _0024self__00243367);
		}
	}

	public Transform redspawn;

	public Transform bluespawn;

	public GameObject chatobj;

	public GameObject bluebot;

	public GameObject redbot;

	public SpawningScript src;

	public RefreshMasterServer refreshsrc;

	public CloakPickup cpickup;

	public MasterServerScript mserver;

	private int curlvl;

	private bool hold;

	private bool person;

	[NonSerialized]
	public static Transform hiveMindTarget;

	public BotSpawner()
	{
		curlvl = 1;
	}

	public virtual void LateUpdate()
	{
		GameObject[] a;
		if ((PhotonNetwork.isMasterClient || MasterServerScript.connectedToDed) && !RefreshMasterServer.personjoined)
		{
			if (!(SpawningScript.team2 != string.Empty) || hold)
			{
				return;
			}
			a = GameObject.FindGameObjectsWithTag("Bot");
			if (UnityScript.Lang.Extensions.get_length((System.Array)a) != 0 || !(SpawningScript.playertrans != null))
			{
				return;
			}
			if (!person)
			{
				StartCoroutine_Auto(SpawnBots(curlvl));
				return;
			}
			person = false;
			if (curlvl == 1)
			{
				StartCoroutine_Auto(SpawnBots(curlvl));
			}
			else
			{
				StartCoroutine_Auto(SpawnBots(curlvl - 1));
			}
			return;
		}
		if (RefreshMasterServer.personjoined)
		{
			person = true;
		}
		a = GameObject.FindGameObjectsWithTag("Bot");
		if (UnityScript.Lang.Extensions.get_length((System.Array)a) > 0 && (PhotonNetwork.isMasterClient || MasterServerScript.connectedToDed))
		{
			int i = 0;
			GameObject[] array = a;
			for (int length = array.Length; i < length; i++)
			{
				UnityEngine.Object.Destroy(array[i]);
			}
			chatobj.SendMessage("OutsideSystemNoRPC", "Destroying single-player killer drones (a person has joined the game).");
		}
	}

	public virtual void chatSpawnBots(int i)
	{
		if (i == -1)
		{
			if (hold)
			{
				StartCoroutine_Auto(SpawnBots(curlvl));
			}
		}
		else
		{
			StartCoroutine_Auto(SpawnBots(i));
		}
	}

	public virtual IEnumerator SpawnBots(int level)
	{
		return new _0024SpawnBots_00243355(level, this).GetEnumerator();
	}
}
