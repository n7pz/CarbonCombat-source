using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using Photon;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class SpawningScript : Photon.MonoBehaviour
{
	[Serializable]
	internal sealed class _0024spawnAI_00245648 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal int _0024playerCounter_00245649;

			internal NetPlayer _0024np2_00245650;

			internal IEnumerator _0024_0024iterator_0024240_00245651;

			internal AIManager _0024p1_00245652;

			internal Transform _0024pl1_00245653;

			internal Transform _0024pl2_00245654;

			internal AIManager _0024aiman_00245655;

			internal int _0024i_00245656;

			internal SpawningScript _0024self__00245657;

			public _0024(int i, SpawningScript self_)
			{
				_0024i_00245656 = i;
				_0024self__00245657 = self_;
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
					_0024self__00245657.aiteam = _0024i_00245656;
					if (AuthGameObject.isAIserver && PhotonNetwork.isMasterClient)
					{
						((PhotonView)_0024self__00245657.gameObject.GetComponent(typeof(PhotonView))).RPC("thisIsMyName", PhotonTargets.AllBuffered, MasterServerScript.ainame, (AuthGameObject.gametype == "Deathmatch" || AuthGameObject.gametype == "Freeplay" || AuthGameObject.gametype == "Survival") ? "red" : ((_0024self__00245657.aiteam != 1) ? "blue" : "red"), true);
						if (MasterServerScript.ainame2 != string.Empty)
						{
							((PhotonView)_0024self__00245657.gameObject.GetComponent(typeof(PhotonView))).RPC("thisIsMyName", PhotonTargets.AllBuffered, MasterServerScript.ainame2, (AuthGameObject.gametype == "Deathmatch" || AuthGameObject.gametype == "Freeplay" || AuthGameObject.gametype == "Survival") ? "red" : ((_0024self__00245657.aiteam != 1) ? "red" : "blue"), true);
						}
						if (MasterServerScript.ainame3 != string.Empty)
						{
							((PhotonView)_0024self__00245657.gameObject.GetComponent(typeof(PhotonView))).RPC("thisIsMyName", PhotonTargets.AllBuffered, MasterServerScript.ainame3, (AuthGameObject.gametype == "Deathmatch" || AuthGameObject.gametype == "Freeplay" || AuthGameObject.gametype == "Survival") ? "red" : ((_0024self__00245657.aiteam != 1) ? "red" : "blue"), true);
						}
					}
					if (!HeadlesssDedServer.isServerHost)
					{
						goto IL_0371;
					}
					_0024playerCounter_00245649 = 0;
					goto case 4;
				case 4:
					if (_0024playerCounter_00245649 < 2)
					{
						_0024playerCounter_00245649 = 0;
						_0024_0024iterator_0024240_00245651 = UnityRuntimeServices.GetEnumerator(netPlayers);
						while (_0024_0024iterator_0024240_00245651.MoveNext())
						{
							object obj2 = _0024_0024iterator_0024240_00245651.Current;
							if (!(obj2 is NetPlayer))
							{
								obj2 = RuntimeServices.Coerce(obj2, typeof(NetPlayer));
							}
							_0024np2_00245650 = (NetPlayer)obj2;
							if (_0024np2_00245650.team != string.Empty)
							{
								_0024playerCounter_00245649++;
							}
						}
						result = (YieldDefault(4) ? 1 : 0);
						break;
					}
					goto IL_0371;
				case 5:
					result = (YieldDefault(6) ? 1 : 0);
					break;
				case 6:
					_0024p1_00245652 = null;
					_0024pl1_00245653 = null;
					_0024pl2_00245654 = null;
					if (!HeadlesssDedServer.isServerHost)
					{
						if (_0024i_00245656 == 0)
						{
							aiteamlist = "rrr";
							SpawningScript spawningScript8 = _0024self__00245657;
							object obj9 = _0024self__00245657.customNetInstantiateRed(_0024self__00245657.redplayerPrefab, _0024self__00245657.redspawn1.transform.position, _0024self__00245657.redspawn1.transform.rotation, 8);
							if (!(obj9 is Transform))
							{
								obj9 = RuntimeServices.Coerce(obj9, typeof(Transform));
							}
							spawningScript8.player1 = (Transform)obj9;
							_0024aiman_00245655 = (AIManager)_0024self__00245657.player1.gameObject.GetComponent("AIManager");
							_0024aiman_00245655.target = _0024self__00245657.player1;
							_0024aiman_00245655.isAI = true;
							_0024aiman_00245655.aiteam = "red";
							_0024aiman_00245655.ainame = MasterServerScript.ainame;
							_0024pl1_00245653 = _0024self__00245657.player1;
							aiplayerobjs[0] = _0024self__00245657.player1;
							if (_0024self__00245657.team == "red")
							{
								_0024p1_00245652 = _0024aiman_00245655;
							}
							result = (YieldDefault(7) ? 1 : 0);
							break;
						}
						goto IL_079d;
					}
					((PhotonView)_0024self__00245657.gameObject.GetComponent(typeof(PhotonView))).RPC("createAIPlayer", PhotonTargets.Others, _0024i_00245656);
					goto IL_0fd0;
				case 7:
					result = (YieldDefault(8) ? 1 : 0);
					break;
				case 8:
					if (MasterServerScript.ainame2 != string.Empty)
					{
						SpawningScript spawningScript5 = _0024self__00245657;
						object obj6 = _0024self__00245657.customNetInstantiateRed(_0024self__00245657.redplayerPrefab, _0024self__00245657.spawn1.transform.position, _0024self__00245657.spawn1.transform.rotation, 9);
						if (!(obj6 is Transform))
						{
							obj6 = RuntimeServices.Coerce(obj6, typeof(Transform));
						}
						spawningScript5.player1 = (Transform)obj6;
						_0024aiman_00245655 = (AIManager)_0024self__00245657.player1.gameObject.GetComponent("AIManager");
						_0024aiman_00245655.target = _0024self__00245657.player1;
						_0024aiman_00245655.isAI = true;
						_0024aiman_00245655.aiteam = "red";
						_0024aiman_00245655.ainame = MasterServerScript.ainame2;
						_0024pl2_00245654 = _0024self__00245657.player1;
						aiplayerobjs[1] = _0024self__00245657.player1;
						if (_0024self__00245657.team == "red")
						{
							_0024p1_00245652 = _0024aiman_00245655;
						}
					}
					result = (YieldDefault(9) ? 1 : 0);
					break;
				case 9:
					result = (YieldDefault(10) ? 1 : 0);
					break;
				case 10:
					if (MasterServerScript.ainame3 != string.Empty)
					{
						SpawningScript spawningScript6 = _0024self__00245657;
						object obj7 = _0024self__00245657.customNetInstantiateRed(_0024self__00245657.redplayerPrefab, _0024self__00245657.spawn2.transform.position, _0024self__00245657.spawn2.transform.rotation, 10);
						if (!(obj7 is Transform))
						{
							obj7 = RuntimeServices.Coerce(obj7, typeof(Transform));
						}
						spawningScript6.player1 = (Transform)obj7;
						aiplayerobjs[2] = _0024self__00245657.player1;
						_0024aiman_00245655 = (AIManager)_0024self__00245657.player1.gameObject.GetComponent("AIManager");
						_0024aiman_00245655.target = _0024self__00245657.player1;
						_0024aiman_00245655.isAI = true;
						_0024aiman_00245655.aiteam = "red";
						_0024aiman_00245655.ainame = MasterServerScript.ainame3;
					}
					if (MasterServerScript.ainame2 != string.Empty)
					{
						if (_0024self__00245657.team == "red")
						{
							_0024p1_00245652.target = _0024pl2_00245654;
						}
						if (_0024self__00245657.team == "blue")
						{
							_0024p1_00245652.target = _0024pl1_00245653;
						}
					}
					goto IL_079d;
				case 11:
					result = (YieldDefault(12) ? 1 : 0);
					break;
				case 12:
					if (MasterServerScript.ainame2 != string.Empty)
					{
						SpawningScript spawningScript2 = _0024self__00245657;
						object obj3 = _0024self__00245657.customNetInstantiateBlue(_0024self__00245657.playerPrefab, _0024self__00245657.spawn1.transform.position, _0024self__00245657.spawn1.transform.rotation, 9);
						if (!(obj3 is Transform))
						{
							obj3 = RuntimeServices.Coerce(obj3, typeof(Transform));
						}
						spawningScript2.player1 = (Transform)obj3;
						_0024aiman_00245655 = (AIManager)_0024self__00245657.player1.gameObject.GetComponent("AIManager");
						_0024aiman_00245655.target = _0024self__00245657.player1;
						_0024aiman_00245655.isAI = true;
						_0024aiman_00245655.aiteam = "blue";
						_0024aiman_00245655.ainame = MasterServerScript.ainame2;
						_0024pl2_00245654 = _0024self__00245657.player1;
						aiplayerobjs[1] = _0024self__00245657.player1;
						if (_0024self__00245657.team == "blue")
						{
							_0024p1_00245652 = _0024aiman_00245655;
						}
					}
					result = (YieldDefault(13) ? 1 : 0);
					break;
				case 13:
					result = (YieldDefault(14) ? 1 : 0);
					break;
				case 14:
					if (MasterServerScript.ainame3 != string.Empty)
					{
						SpawningScript spawningScript7 = _0024self__00245657;
						object obj8 = _0024self__00245657.customNetInstantiateBlue(_0024self__00245657.playerPrefab, _0024self__00245657.spawn2.transform.position, _0024self__00245657.spawn2.transform.rotation, 10);
						if (!(obj8 is Transform))
						{
							obj8 = RuntimeServices.Coerce(obj8, typeof(Transform));
						}
						spawningScript7.player1 = (Transform)obj8;
						aiplayerobjs[2] = _0024self__00245657.player1;
						_0024aiman_00245655 = (AIManager)_0024self__00245657.player1.gameObject.GetComponent("AIManager");
						_0024aiman_00245655.target = _0024self__00245657.player1;
						_0024aiman_00245655.isAI = true;
						_0024aiman_00245655.aiteam = "blue";
						_0024aiman_00245655.ainame = MasterServerScript.ainame3;
					}
					if (MasterServerScript.ainame2 != string.Empty)
					{
						if (_0024self__00245657.team == "red")
						{
							_0024p1_00245652.target = _0024pl2_00245654;
						}
						if (_0024self__00245657.team == "blue")
						{
							_0024p1_00245652.target = _0024pl1_00245653;
						}
					}
					goto IL_0b95;
				case 15:
					result = (YieldDefault(16) ? 1 : 0);
					break;
				case 16:
					if (MasterServerScript.ainame2 != string.Empty)
					{
						SpawningScript spawningScript4 = _0024self__00245657;
						object obj5 = _0024self__00245657.customNetInstantiateRed(_0024self__00245657.redplayerPrefab, _0024self__00245657.redspawn1.transform.position, _0024self__00245657.redspawn1.transform.rotation, 9);
						if (!(obj5 is Transform))
						{
							obj5 = RuntimeServices.Coerce(obj5, typeof(Transform));
						}
						spawningScript4.player1 = (Transform)obj5;
						_0024aiman_00245655 = (AIManager)_0024self__00245657.player1.gameObject.GetComponent("AIManager");
						_0024aiman_00245655.target = _0024self__00245657.player1;
						_0024aiman_00245655.isAI = true;
						_0024aiman_00245655.aiteam = "red";
						_0024aiman_00245655.ainame = MasterServerScript.ainame2;
						_0024pl2_00245654 = _0024self__00245657.player1;
						aiplayerobjs[1] = _0024self__00245657.player1;
						if (_0024self__00245657.team == "red")
						{
							_0024p1_00245652 = _0024aiman_00245655;
						}
					}
					result = (YieldDefault(17) ? 1 : 0);
					break;
				case 17:
					result = (YieldDefault(18) ? 1 : 0);
					break;
				case 18:
					if (MasterServerScript.ainame3 != string.Empty)
					{
						SpawningScript spawningScript = _0024self__00245657;
						object obj = _0024self__00245657.customNetInstantiateRed(_0024self__00245657.redplayerPrefab, _0024self__00245657.redspawn2.transform.position, _0024self__00245657.redspawn2.transform.rotation, 10);
						if (!(obj is Transform))
						{
							obj = RuntimeServices.Coerce(obj, typeof(Transform));
						}
						spawningScript.player1 = (Transform)obj;
						aiplayerobjs[2] = _0024self__00245657.player1;
						_0024aiman_00245655 = (AIManager)_0024self__00245657.player1.gameObject.GetComponent("AIManager");
						_0024aiman_00245655.target = _0024self__00245657.player1;
						_0024aiman_00245655.isAI = true;
						_0024aiman_00245655.aiteam = "red";
						_0024aiman_00245655.ainame = MasterServerScript.ainame3;
					}
					if (MasterServerScript.ainame2 != string.Empty)
					{
						if (_0024self__00245657.team == "blue")
						{
							_0024p1_00245652.target = _0024pl2_00245654;
						}
						if (_0024self__00245657.team == "red")
						{
							_0024p1_00245652.target = _0024pl1_00245653;
						}
					}
					goto IL_0fd0;
				case 1:
					{
						result = 0;
						break;
					}
					IL_079d:
					if (_0024i_00245656 == 1)
					{
						aiteamlist = "rbb";
						SpawningScript spawningScript3 = _0024self__00245657;
						object obj4 = _0024self__00245657.customNetInstantiateRed(_0024self__00245657.redplayerPrefab, _0024self__00245657.redspawn1.transform.position, _0024self__00245657.redspawn1.transform.rotation, 8);
						if (!(obj4 is Transform))
						{
							obj4 = RuntimeServices.Coerce(obj4, typeof(Transform));
						}
						spawningScript3.player1 = (Transform)obj4;
						_0024aiman_00245655 = (AIManager)_0024self__00245657.player1.gameObject.GetComponent("AIManager");
						_0024aiman_00245655.target = _0024self__00245657.player1;
						_0024aiman_00245655.isAI = true;
						_0024aiman_00245655.aiteam = "red";
						_0024aiman_00245655.ainame = MasterServerScript.ainame;
						_0024pl1_00245653 = _0024self__00245657.player1;
						aiplayerobjs[0] = _0024self__00245657.player1;
						if (_0024self__00245657.team == "red")
						{
							_0024p1_00245652 = _0024aiman_00245655;
						}
						result = (YieldDefault(11) ? 1 : 0);
						break;
					}
					goto IL_0b95;
					IL_0fd0:
					PhotonNetwork.SetSendingEnabled(8, true);
					PhotonNetwork.SetSendingEnabled(9, true);
					PhotonNetwork.SetSendingEnabled(10, true);
					if (AuthGameObject.showTutorial)
					{
						TutorialManager.bots[0] = aiplayerobjs[0].gameObject;
						TutorialManager.bots[1] = aiplayerobjs[1].gameObject;
						TutorialManager.bots[2] = aiplayerobjs[2].gameObject;
						TutorialManager.AIspawned = true;
					}
					YieldDefault(1);
					goto case 1;
					IL_0b95:
					if (_0024i_00245656 == 2)
					{
						aiteamlist = "brr";
						SpawningScript spawningScript9 = _0024self__00245657;
						object obj10 = _0024self__00245657.customNetInstantiateBlue(_0024self__00245657.playerPrefab, _0024self__00245657.spawn1.transform.position, _0024self__00245657.spawn1.transform.rotation, 8);
						if (!(obj10 is Transform))
						{
							obj10 = RuntimeServices.Coerce(obj10, typeof(Transform));
						}
						spawningScript9.player1 = (Transform)obj10;
						_0024aiman_00245655 = (AIManager)_0024self__00245657.player1.gameObject.GetComponent("AIManager");
						_0024aiman_00245655.target = _0024self__00245657.player1;
						_0024aiman_00245655.isAI = true;
						_0024aiman_00245655.aiteam = "blue";
						_0024aiman_00245655.ainame = MasterServerScript.ainame;
						_0024pl1_00245653 = _0024self__00245657.player1;
						aiplayerobjs[0] = _0024self__00245657.player1;
						if (_0024self__00245657.team == "blue")
						{
							_0024p1_00245652 = _0024aiman_00245655;
						}
						result = (YieldDefault(15) ? 1 : 0);
						break;
					}
					goto IL_0fd0;
					IL_0371:
					result = (YieldDefault(5) ? 1 : 0);
					break;
				}
				return (byte)result != 0;
			}
		}

		internal int _0024i_00245658;

		internal SpawningScript _0024self__00245659;

		public _0024spawnAI_00245648(int i, SpawningScript self_)
		{
			_0024i_00245658 = i;
			_0024self__00245659 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024i_00245658, _0024self__00245659);
		}
	}

	[Serializable]
	internal sealed class _0024SpawnNetworkedBots_00245660 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal UnityScript.Lang.Array _0024enemylist_00245661;

			internal GameObject _0024obj_00245662;

			internal IEnumerator _0024_0024iterator_0024241_00245663;

			internal int _0024rannum_00245664;

			internal GameObject _0024thetarget_00245665;

			internal GameObject _0024bot_00245666;

			internal int _0024s_00245667;

			internal PlayerCar_Script _0024carscript_00245668;

			internal int _0024i_00245669;

			internal SpawningScript _0024self__00245670;

			public _0024(int i, SpawningScript self_)
			{
				_0024i_00245669 = i;
				_0024self__00245670 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
				{
					_0024enemylist_00245661 = new UnityScript.Lang.Array();
					_0024_0024iterator_0024241_00245663 = UnityRuntimeServices.GetEnumerator(spawnedCars);
					while (_0024_0024iterator_0024241_00245663.MoveNext())
					{
						object obj = _0024_0024iterator_0024241_00245663.Current;
						if (!(obj is GameObject))
						{
							obj = RuntimeServices.Coerce(obj, typeof(GameObject));
						}
						_0024obj_00245662 = (GameObject)obj;
						if ((bool)(PlayerCar_Script)_0024obj_00245662.GetComponent(typeof(PlayerCar_Script)))
						{
							if (team2 == "red" && (((PlayerCar_Script)_0024obj_00245662.GetComponent(typeof(PlayerCar_Script))).returnTeam() == "blue" || AuthGameObject.gametype == "Deathmatch" || AuthGameObject.gametype == "Freeplay" || AuthGameObject.gametype == "Survival") && _0024obj_00245662.transform != playertrans && _0024obj_00245662.transform != playertransCar)
							{
								_0024enemylist_00245661.Add(_0024obj_00245662);
								UnityRuntimeServices.Update(_0024_0024iterator_0024241_00245663, _0024obj_00245662);
							}
							if (team2 == "blue" && ((PlayerCar_Script)_0024obj_00245662.GetComponent(typeof(PlayerCar_Script))).returnTeam() == "red")
							{
								_0024enemylist_00245661.Add(_0024obj_00245662);
								UnityRuntimeServices.Update(_0024_0024iterator_0024241_00245663, _0024obj_00245662);
							}
						}
					}
					_0024rannum_00245664 = UnityEngine.Random.Range(0, _0024enemylist_00245661.length);
					object obj2 = _0024enemylist_00245661[_0024rannum_00245664];
					if (!(obj2 is GameObject))
					{
						obj2 = RuntimeServices.Coerce(obj2, typeof(GameObject));
					}
					_0024thetarget_00245665 = (GameObject)obj2;
					_0024bot_00245666 = null;
					_0024s_00245667 = 0;
					goto IL_0326;
				}
				case 2:
					_0024s_00245667++;
					goto IL_0326;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0326:
					if (_0024s_00245667 < _0024i_00245669)
					{
						if (team2 == "red")
						{
							_0024carscript_00245668 = (PlayerCar_Script)playertransCar.GetComponent(typeof(PlayerCar_Script));
							_0024carscript_00245668.spawnRedBot(_0024self__00245670.redspawn1.transform.position, _0024self__00245670.redspawn1.transform.rotation, false, _0024thetarget_00245665.transform);
						}
						else
						{
							_0024carscript_00245668 = (PlayerCar_Script)playertransCar.GetComponent(typeof(PlayerCar_Script));
							_0024carscript_00245668.spawnBlueBot(_0024self__00245670.spawn1.transform.position, _0024self__00245670.spawn1.transform.rotation, false, _0024thetarget_00245665.transform);
						}
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal int _0024i_00245671;

		internal SpawningScript _0024self__00245672;

		public _0024SpawnNetworkedBots_00245660(int i, SpawningScript self_)
		{
			_0024i_00245671 = i;
			_0024self__00245672 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024i_00245671, _0024self__00245672);
		}
	}

	[Serializable]
	internal sealed class _0024Start_00245673 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal SpawningScript _0024self__00245674;

			public _0024(SpawningScript self_)
			{
				_0024self__00245674 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					netPlayers.Clear();
					goto case 2;
				case 2:
					if (!PhotonNetwork.isMessageQueueRunning)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					team2 = string.Empty;
					if (PhotonNetwork.isMasterClient)
					{
						_0024self__00245674.isOriginalHost = true;
						((PhotonView)_0024self__00245674.gameObject.GetComponent(typeof(PhotonView))).RPC("updateAuthValues", PhotonTargets.AllBuffered, AuthGameObject.weatherindex, AuthGameObject.whirldurl, AuthGameObject.whirldmmurl, AuthGameObject.whirldname, AuthGameObject.maxplayers, AuthGameObject.timelimit, AuthGameObject.gametype, AuthGameObject.isAIserver, AuthGameObject.ff, MasterServerScript.gamenamestring, MasterServerScript.curworld, MasterServerScript.ainame, MasterServerScript.ainame2, MasterServerScript.ainame3, AuthGameObject.fpsenabled, RefreshMasterServer.bannedList, AuthGameObject.cDam);
					}
					((PhotonView)_0024self__00245674.gameObject.GetComponent(typeof(PhotonView))).RPC("setUpNetPlayer", PhotonTargets.AllBuffered, AuthGameObject.username, false);
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal SpawningScript _0024self__00245675;

		public _0024Start_00245673(SpawningScript self_)
		{
			_0024self__00245675 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00245675);
		}
	}

	[Serializable]
	internal sealed class _0024setUpNetPlayer_00245676 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal bool _0024exists_00245677;

			internal NetPlayer _0024np_00245678;

			internal IEnumerator _0024_0024iterator_0024245_00245679;

			internal NetPlayer _0024myNetPlayer_00245680;

			internal string _0024u_00245681;

			internal bool _0024isAI_00245682;

			internal PhotonMessageInfo _0024info_00245683;

			public _0024(string u, bool isAI, PhotonMessageInfo info)
			{
				_0024u_00245681 = u;
				_0024isAI_00245682 = isAI;
				_0024info_00245683 = info;
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
					_0024exists_00245677 = false;
					_0024_0024iterator_0024245_00245679 = UnityRuntimeServices.GetEnumerator(netPlayers);
					while (_0024_0024iterator_0024245_00245679.MoveNext())
					{
						object obj = _0024_0024iterator_0024245_00245679.Current;
						if (!(obj is NetPlayer))
						{
							obj = RuntimeServices.Coerce(obj, typeof(NetPlayer));
						}
						_0024np_00245678 = (NetPlayer)obj;
						if (_0024np_00245678.username == _0024u_00245681)
						{
							_0024exists_00245677 = true;
						}
					}
					if (!_0024exists_00245677)
					{
						_0024myNetPlayer_00245680 = new NetPlayer(_0024info_00245683.sender, _0024u_00245681, 0, 0, string.Empty, _0024isAI_00245682);
						netPlayers.Add(_0024myNetPlayer_00245680);
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

		internal string _0024u_00245684;

		internal bool _0024isAI_00245685;

		internal PhotonMessageInfo _0024info_00245686;

		public _0024setUpNetPlayer_00245676(string u, bool isAI, PhotonMessageInfo info)
		{
			_0024u_00245684 = u;
			_0024isAI_00245685 = isAI;
			_0024info_00245686 = info;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024u_00245684, _0024isAI_00245685, _0024info_00245686);
		}
	}

	[Serializable]
	internal sealed class _0024Respawn_00245687 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal AuthGameObject _0024authObjScript_00245688;

			internal Behaviour[] _0024armorScriptsArr_00245689;

			internal int _0024ac_00245690;

			internal int _0024angleran_00245691;

			internal int _0024n_00245692;

			internal GameObject _0024minimapcam_00245693;

			internal string _0024message_00245694;

			internal float _0024t_00245695;

			internal SpawningScript _0024self__00245696;

			public _0024(float t, SpawningScript self_)
			{
				_0024t_00245695 = t;
				_0024self__00245696 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024authObjScript_00245688 = (AuthGameObject)GameObject.Find("/AuthGameObject").GetComponent(typeof(AuthGameObject));
					_0024authObjScript_00245688.StartCoroutine_Auto(_0024authObjScript_00245688.sendStat("mostconsecutivekills", CalculateHealth.totalCKills, 2));
					CalculateHealth.totalCKills = 0;
					if (AuthGameObject.gametype == "Survival")
					{
						ChatScript.primaryweapon = "rocket";
						ChatScript.secondaryweapon = "laser";
						FireGun.rocketammoleft = 6f;
						FireGun.laserammoleft = 20f;
						ToggleGuns.forceRefresh = true;
						ChatScript.hasarmor1 = false;
						ChatScript.hasarmor2 = false;
						ChatScript.hasarmor3 = false;
						ChatScript.hasarmor4 = false;
						ChatScript.hasarmor5 = false;
						ChatScript.hasarmor6 = false;
						ChatScript.hasarmor7 = false;
						ChatScript.hasarmor8 = false;
						_0024armorScriptsArr_00245689 = ((PlayerCar_Script)playertransCar.GetComponent(typeof(PlayerCar_Script))).armorScripts;
						for (_0024ac_00245690 = 0; _0024ac_00245690 < UnityScript.Lang.Extensions.get_length((System.Array)_0024armorScriptsArr_00245689); _0024ac_00245690++)
						{
							UnityRuntimeServices.Invoke(_0024armorScriptsArr_00245689[_0024ac_00245690], "Start", new object[0], typeof(UnityEngine.MonoBehaviour));
						}
						((PlayerCar_Script)playertransCar.GetComponent(typeof(PlayerCar_Script))).recalculateMass();
					}
					if (_0024t_00245695 == 5f)
					{
						((PhotonView)_0024self__00245696.gameObject.GetComponent(typeof(PhotonView))).RPC("addvictimRPC", PhotonTargets.MasterClient, AuthGameObject.username);
						if (_0024self__00245696.team == "red")
						{
							_0024self__00245696.igs.SendMessage("reddeath");
						}
						else
						{
							_0024self__00245696.igs.SendMessage("bluedeath");
						}
					}
					_0024angleran_00245691 = UnityEngine.Random.Range(1, 7);
					if (AuthGameObject.showTutorial)
					{
						_0024angleran_00245691 = 4;
					}
					Debug.Log("Respawning; random spawn point = " + _0024angleran_00245691);
					playertransCar.gameObject.SendMessage("SetKinematic", _0024t_00245695);
					playertransCar.SendMessage("sendAMessage", "everyoneKillSmoke|MainBoxCol");
					FireGun.respawnreload = true;
					FireGun.respawngrapplestop = true;
					FireGun.stopgrapple = true;
					FireGun.grappling = false;
					FireGun.oncePerRound = false;
					_0024self__00245696.killAllAttackBots();
					result = (Yield(2, new WaitForSeconds(_0024t_00245695)) ? 1 : 0);
					break;
				case 2:
					playertransCar.gameObject.SendMessage("resethealth");
					CalculateHealth.bonus = 1f;
					CalculateHealth.killstreak = 0;
					FireGun.respawngrapplestop = false;
					GameObject.Find("/GUI/AmmoDisplay").SendMessage("botalphafadeout");
					Camera.main.gameObject.SendMessage("respawndisable");
					if (_0024t_00245695 == 5f)
					{
						((PhotonView)_0024self__00245696.gameObject.GetComponent(typeof(PhotonView))).RPC("makeexplosion", PhotonTargets.All, playertransCar.position, playertransCar.rotation);
					}
					if (_0024t_00245695 == 0.101f && AuthGameObject.gametype == "Capture the Flag")
					{
						_0024self__00245696.flagbase.SendMessage("resetrespawn");
						if ((bool)_0024self__00245696.player1)
						{
							_0024self__00245696.player1.SendMessage("resethealth");
						}
					}
					else if (AuthGameObject.gametype == "Capture the Flag")
					{
						playertransCar.gameObject.SendMessage("externaldrop");
					}
					if (!_0024self__00245696.switchteams)
					{
						if (AuthGameObject.gametype != "Freeplay" && AuthGameObject.gametype != "Deathmatch" && AuthGameObject.gametype != "Survival")
						{
							if (_0024self__00245696.team == "blue")
							{
								if (_0024angleran_00245691 == 1)
								{
									playertransCar.position = _0024self__00245696.spawn1.transform.position;
									playertransCar.rotation = _0024self__00245696.spawn1.transform.rotation;
								}
								if (_0024angleran_00245691 == 2)
								{
									playertransCar.position = _0024self__00245696.spawn2.transform.position;
									playertransCar.rotation = _0024self__00245696.spawn2.transform.rotation;
								}
								if (_0024angleran_00245691 == 3)
								{
									playertransCar.position = _0024self__00245696.spawn3.transform.position;
									playertransCar.rotation = _0024self__00245696.spawn3.transform.rotation;
								}
								if (_0024angleran_00245691 == 4)
								{
									playertransCar.position = _0024self__00245696.spawn4.transform.position;
									playertransCar.rotation = _0024self__00245696.spawn4.transform.rotation;
								}
								if (_0024angleran_00245691 == 5)
								{
									playertransCar.position = _0024self__00245696.spawn5.transform.position;
									playertransCar.rotation = _0024self__00245696.spawn5.transform.rotation;
								}
								if (_0024angleran_00245691 == 6)
								{
									playertransCar.position = _0024self__00245696.spawn6.transform.position;
									playertransCar.rotation = _0024self__00245696.spawn6.transform.rotation;
								}
							}
							else
							{
								if (_0024angleran_00245691 == 1)
								{
									playertransCar.position = _0024self__00245696.redspawn1.transform.position;
									playertransCar.rotation = _0024self__00245696.redspawn1.transform.rotation;
								}
								if (_0024angleran_00245691 == 2)
								{
									playertransCar.position = _0024self__00245696.redspawn2.transform.position;
									playertransCar.rotation = _0024self__00245696.redspawn2.transform.rotation;
								}
								if (_0024angleran_00245691 == 3)
								{
									playertransCar.position = _0024self__00245696.redspawn3.transform.position;
									playertransCar.rotation = _0024self__00245696.redspawn3.transform.rotation;
								}
								if (_0024angleran_00245691 == 4)
								{
									playertransCar.position = _0024self__00245696.redspawn4.transform.position;
									playertransCar.rotation = _0024self__00245696.redspawn4.transform.rotation;
								}
								if (_0024angleran_00245691 == 5)
								{
									playertransCar.position = _0024self__00245696.redspawn5.transform.position;
									playertransCar.rotation = _0024self__00245696.redspawn5.transform.rotation;
								}
								if (_0024angleran_00245691 == 6)
								{
									playertransCar.position = _0024self__00245696.redspawn6.transform.position;
									playertransCar.rotation = _0024self__00245696.redspawn6.transform.rotation;
								}
							}
						}
						else
						{
							_0024angleran_00245691 = UnityEngine.Random.Range(1, 12);
							if (_0024angleran_00245691 == 1)
							{
								playertransCar.position = _0024self__00245696.spawn1.transform.position;
								playertransCar.rotation = _0024self__00245696.spawn1.transform.rotation;
							}
							if (_0024angleran_00245691 == 2)
							{
								playertransCar.position = _0024self__00245696.spawn2.transform.position;
								playertransCar.rotation = _0024self__00245696.spawn2.transform.rotation;
							}
							if (_0024angleran_00245691 == 3)
							{
								playertransCar.position = _0024self__00245696.spawn3.transform.position;
								playertransCar.rotation = _0024self__00245696.spawn3.transform.rotation;
							}
							if (_0024angleran_00245691 == 4)
							{
								playertransCar.position = _0024self__00245696.spawn4.transform.position;
								playertransCar.rotation = _0024self__00245696.spawn4.transform.rotation;
							}
							if (_0024angleran_00245691 == 5)
							{
								playertransCar.position = _0024self__00245696.spawn5.transform.position;
								playertransCar.rotation = _0024self__00245696.spawn5.transform.rotation;
							}
							if (_0024angleran_00245691 == 6)
							{
								playertransCar.position = _0024self__00245696.spawn6.transform.position;
								playertransCar.rotation = _0024self__00245696.spawn6.transform.rotation;
							}
							if (_0024angleran_00245691 == 7)
							{
								playertransCar.position = _0024self__00245696.redspawn1.transform.position;
								playertransCar.rotation = _0024self__00245696.redspawn1.transform.rotation;
							}
							if (_0024angleran_00245691 == 8)
							{
								playertransCar.position = _0024self__00245696.redspawn2.transform.position;
								playertransCar.rotation = _0024self__00245696.redspawn2.transform.rotation;
							}
							if (_0024angleran_00245691 == 9)
							{
								playertransCar.position = _0024self__00245696.redspawn3.transform.position;
								playertransCar.rotation = _0024self__00245696.redspawn3.transform.rotation;
							}
							if (_0024angleran_00245691 == 10)
							{
								playertransCar.position = _0024self__00245696.redspawn4.transform.position;
								playertransCar.rotation = _0024self__00245696.redspawn4.transform.rotation;
							}
							if (_0024angleran_00245691 == 11)
							{
								playertransCar.position = _0024self__00245696.redspawn5.transform.position;
								playertransCar.rotation = _0024self__00245696.redspawn5.transform.rotation;
							}
							if (_0024angleran_00245691 == 12)
							{
								playertransCar.position = _0024self__00245696.redspawn6.transform.position;
								playertransCar.rotation = _0024self__00245696.redspawn6.transform.rotation;
							}
						}
					}
					else
					{
						_0024self__00245696.switchteams = false;
						Camera.main.gameObject.SendMessage("waitForUp");
						Camera.main.gameObject.SendMessage("exitFPSmode");
						Camera.main.transform.parent = null;
						for (_0024n_00245692 = 0; _0024n_00245692 < netSpawnObjs.length; _0024n_00245692++)
						{
							if (RuntimeServices.EqualityOperator(UnityRuntimeServices.GetProperty(RuntimeServices.GetSlice(netSpawnObjs[_0024n_00245692], "arr", new object[1] { 0 }), "owner"), PhotonNetwork.player))
							{
								netSpawnObjs.RemoveAt(_0024n_00245692);
								break;
							}
						}
						((PhotonView)_0024self__00245696.gameObject.GetComponent(typeof(PhotonView))).RPC("customNetDestroy", PhotonTargets.All);
						if (_0024self__00245696.team == "blue")
						{
							if (_0024angleran_00245691 == 1)
							{
								object obj = _0024self__00245696.customNetInstantiateBlue(_0024self__00245696.playerPrefab, _0024self__00245696.spawn1.transform.position, _0024self__00245696.spawn1.transform.rotation, 0);
								if (!(obj is Transform))
								{
									obj = RuntimeServices.Coerce(obj, typeof(Transform));
								}
								playertransCar = (Transform)obj;
							}
							if (_0024angleran_00245691 == 2)
							{
								object obj2 = _0024self__00245696.customNetInstantiateBlue(_0024self__00245696.playerPrefab, _0024self__00245696.spawn2.transform.position, _0024self__00245696.spawn2.transform.rotation, 0);
								if (!(obj2 is Transform))
								{
									obj2 = RuntimeServices.Coerce(obj2, typeof(Transform));
								}
								playertransCar = (Transform)obj2;
							}
							if (_0024angleran_00245691 == 3)
							{
								object obj3 = _0024self__00245696.customNetInstantiateBlue(_0024self__00245696.playerPrefab, _0024self__00245696.spawn3.transform.position, _0024self__00245696.spawn3.transform.rotation, 0);
								if (!(obj3 is Transform))
								{
									obj3 = RuntimeServices.Coerce(obj3, typeof(Transform));
								}
								playertransCar = (Transform)obj3;
							}
							if (_0024angleran_00245691 == 4)
							{
								object obj4 = _0024self__00245696.customNetInstantiateBlue(_0024self__00245696.playerPrefab, _0024self__00245696.spawn4.transform.position, _0024self__00245696.spawn4.transform.rotation, 0);
								if (!(obj4 is Transform))
								{
									obj4 = RuntimeServices.Coerce(obj4, typeof(Transform));
								}
								playertransCar = (Transform)obj4;
							}
							if (_0024angleran_00245691 == 5)
							{
								object obj5 = _0024self__00245696.customNetInstantiateBlue(_0024self__00245696.playerPrefab, _0024self__00245696.spawn5.transform.position, _0024self__00245696.spawn5.transform.rotation, 0);
								if (!(obj5 is Transform))
								{
									obj5 = RuntimeServices.Coerce(obj5, typeof(Transform));
								}
								playertransCar = (Transform)obj5;
							}
							if (_0024angleran_00245691 == 6)
							{
								object obj6 = _0024self__00245696.customNetInstantiateBlue(_0024self__00245696.playerPrefab, _0024self__00245696.spawn6.transform.position, _0024self__00245696.spawn6.transform.rotation, 0);
								if (!(obj6 is Transform))
								{
									obj6 = RuntimeServices.Coerce(obj6, typeof(Transform));
								}
								playertransCar = (Transform)obj6;
							}
						}
						else
						{
							if (_0024angleran_00245691 == 1)
							{
								object obj7 = _0024self__00245696.customNetInstantiateRed(_0024self__00245696.redplayerPrefab, _0024self__00245696.redspawn1.transform.position, _0024self__00245696.redspawn1.transform.rotation, 0);
								if (!(obj7 is Transform))
								{
									obj7 = RuntimeServices.Coerce(obj7, typeof(Transform));
								}
								playertransCar = (Transform)obj7;
							}
							if (_0024angleran_00245691 == 2)
							{
								object obj8 = _0024self__00245696.customNetInstantiateRed(_0024self__00245696.redplayerPrefab, _0024self__00245696.redspawn2.transform.position, _0024self__00245696.redspawn2.transform.rotation, 0);
								if (!(obj8 is Transform))
								{
									obj8 = RuntimeServices.Coerce(obj8, typeof(Transform));
								}
								playertransCar = (Transform)obj8;
							}
							if (_0024angleran_00245691 == 3)
							{
								object obj9 = _0024self__00245696.customNetInstantiateRed(_0024self__00245696.redplayerPrefab, _0024self__00245696.redspawn3.transform.position, _0024self__00245696.redspawn3.transform.rotation, 0);
								if (!(obj9 is Transform))
								{
									obj9 = RuntimeServices.Coerce(obj9, typeof(Transform));
								}
								playertransCar = (Transform)obj9;
							}
							if (_0024angleran_00245691 == 4)
							{
								object obj10 = _0024self__00245696.customNetInstantiateRed(_0024self__00245696.redplayerPrefab, _0024self__00245696.redspawn4.transform.position, _0024self__00245696.redspawn4.transform.rotation, 0);
								if (!(obj10 is Transform))
								{
									obj10 = RuntimeServices.Coerce(obj10, typeof(Transform));
								}
								playertransCar = (Transform)obj10;
							}
							if (_0024angleran_00245691 == 5)
							{
								object obj11 = _0024self__00245696.customNetInstantiateRed(_0024self__00245696.redplayerPrefab, _0024self__00245696.redspawn5.transform.position, _0024self__00245696.redspawn5.transform.rotation, 0);
								if (!(obj11 is Transform))
								{
									obj11 = RuntimeServices.Coerce(obj11, typeof(Transform));
								}
								playertransCar = (Transform)obj11;
							}
							if (_0024angleran_00245691 == 6)
							{
								object obj12 = _0024self__00245696.customNetInstantiateRed(_0024self__00245696.redplayerPrefab, _0024self__00245696.redspawn6.transform.position, _0024self__00245696.redspawn6.transform.rotation, 0);
								if (!(obj12 is Transform))
								{
									obj12 = RuntimeServices.Coerce(obj12, typeof(Transform));
								}
								playertransCar = (Transform)obj12;
							}
						}
						Camera.main.SendMessage("SetTarget", playertransCar);
						_0024minimapcam_00245693 = GameObject.FindWithTag("minimap");
						_0024minimapcam_00245693.SendMessage("SetTarget", playertransCar);
						_0024self__00245696.chatscript.SendMessage("ownteam", _0024self__00245696.team);
						_0024message_00245694 = _0024self__00245696.username + " was moved to the " + _0024self__00245696.team + " team (auto team balancing)!";
						_0024self__00245696.chatscript.SendMessage("OutsideSystem", _0024message_00245694);
						_0024self__00245696.healthbar.SendMessage("setmaincar", playertransCar);
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

		internal float _0024t_00245697;

		internal SpawningScript _0024self__00245698;

		public _0024Respawn_00245687(float t, SpawningScript self_)
		{
			_0024t_00245697 = t;
			_0024self__00245698 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024t_00245697, _0024self__00245698);
		}
	}

	[Serializable]
	internal sealed class _0024disconnectAIs_00245699 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal string _0024message_00245700;

			internal int _0024c_00245701;

			internal NetPlayer _0024np_00245702;

			internal IEnumerator _0024_0024iterator_0024248_00245703;

			internal string _0024u_00245704;

			internal SpawningScript _0024self__00245705;

			public _0024(string u, SpawningScript self_)
			{
				_0024u_00245704 = u;
				_0024self__00245705 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					AuthGameObject.isAIserver = false;
					result = (Yield(2, new WaitForSeconds(UnityEngine.Random.Range(0f, 3f))) ? 1 : 0);
					break;
				case 2:
					_0024message_00245700 = _0024u_00245704 + " has disconnected from the server.";
					_0024self__00245705.chatscript.SendMessage("OutsideSystem", _0024message_00245700);
					_0024c_00245701 = 0;
					_0024_0024iterator_0024248_00245703 = UnityRuntimeServices.GetEnumerator(netPlayers);
					while (_0024_0024iterator_0024248_00245703.MoveNext())
					{
						object obj = _0024_0024iterator_0024248_00245703.Current;
						if (!(obj is NetPlayer))
						{
							obj = RuntimeServices.Coerce(obj, typeof(NetPlayer));
						}
						_0024np_00245702 = (NetPlayer)obj;
						if (_0024np_00245702.username == _0024u_00245704)
						{
							netPlayers.RemoveAt(_0024c_00245701);
							break;
						}
						_0024c_00245701++;
					}
					((PhotonView)_0024self__00245705.gameObject.GetComponent(typeof(PhotonView))).RPC("dB", PhotonTargets.All);
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal string _0024u_00245706;

		internal SpawningScript _0024self__00245707;

		public _0024disconnectAIs_00245699(string u, SpawningScript self_)
		{
			_0024u_00245706 = u;
			_0024self__00245707 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024u_00245706, _0024self__00245707);
		}
	}

	[Serializable]
	internal sealed class _0024OnPhotonPlayerDisconnected_00245708 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal int _0024n_00245709;

			internal string _0024message_00245710;

			internal int _0024obj_00245711;

			internal int _0024i_00245712;

			internal NetPlayer _0024np_00245713;

			internal IEnumerator _0024_0024iterator_0024251_00245714;

			internal PhotonPlayer _0024playerD_00245715;

			internal SpawningScript _0024self__00245716;

			public _0024(PhotonPlayer playerD, SpawningScript self_)
			{
				_0024playerD_00245715 = playerD;
				_0024self__00245716 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__00245716.sentPlayerList.ContainsKey(_0024playerD_00245715))
					{
						_0024self__00245716.sentPlayerList.Remove(_0024playerD_00245715);
					}
					for (_0024n_00245709 = 0; _0024n_00245709 < netSpawnObjs.length; _0024n_00245709++)
					{
						if (RuntimeServices.EqualityOperator(UnityRuntimeServices.GetProperty(RuntimeServices.GetSlice(netSpawnObjs[_0024n_00245709], "arr", new object[1] { 0 }), "owner"), _0024playerD_00245715))
						{
							netSpawnObjs.RemoveAt(_0024n_00245709);
							break;
						}
					}
					if (!RuntimeServices.EqualityOperator(UnityRuntimeServices.GetProperty(netPlayers[_0024self__00245716.networkPlayerToIndex(_0024playerD_00245715)], "team"), string.Empty) && PhotonNetwork.isMasterClient && !string.IsNullOrEmpty(_0024self__00245716.networkPlayerToUsername(_0024playerD_00245715)))
					{
						_0024message_00245710 = _0024self__00245716.networkPlayerToUsername(_0024playerD_00245715) + " has disconnected from the server.";
						_0024self__00245716.chatscript.SendMessage("OutsideSystem", _0024message_00245710);
					}
					result = (YieldDefault(2) ? 1 : 0);
					break;
				case 2:
					if (PhotonNetwork.isMasterClient)
					{
						PhotonNetwork.RemoveRPCs(_0024playerD_00245715);
						PhotonNetwork.DestroyPlayerObjects(_0024playerD_00245715);
					}
					result = (YieldDefault(3) ? 1 : 0);
					break;
				case 3:
					for (_0024obj_00245711 = 0; _0024obj_00245711 < spawnedCars.length; _0024obj_00245711++)
					{
						if (!RuntimeServices.ToBool(spawnedCars[_0024obj_00245711]))
						{
							spawnedCars.RemoveAt(_0024obj_00245711);
						}
					}
					_0024i_00245712 = 0;
					_0024_0024iterator_0024251_00245714 = UnityRuntimeServices.GetEnumerator(netPlayers);
					while (_0024_0024iterator_0024251_00245714.MoveNext())
					{
						object obj = _0024_0024iterator_0024251_00245714.Current;
						if (!(obj is NetPlayer))
						{
							obj = RuntimeServices.Coerce(obj, typeof(NetPlayer));
						}
						_0024np_00245713 = (NetPlayer)obj;
						if (RuntimeServices.EqualityOperator(_0024np_00245713.nplayer, _0024playerD_00245715))
						{
							netPlayers.RemoveAt(_0024i_00245712);
						}
						_0024i_00245712++;
					}
					result = (YieldDefault(4) ? 1 : 0);
					break;
				case 4:
					RefreshMasterServer.forceAIrefresh = true;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal PhotonPlayer _0024playerD_00245717;

		internal SpawningScript _0024self__00245718;

		public _0024OnPhotonPlayerDisconnected_00245708(PhotonPlayer playerD, SpawningScript self_)
		{
			_0024playerD_00245717 = playerD;
			_0024self__00245718 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024playerD_00245717, _0024self__00245718);
		}
	}

	[Serializable]
	internal sealed class _0024thisIsMyName_00245719 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal bool _0024exists_00245720;

			internal NetPlayer _0024np1_00245721;

			internal IEnumerator _0024_0024iterator_0024255_00245722;

			internal NetPlayer _0024myNetPlayer_00245723;

			internal int _0024playerCounter_00245724;

			internal NetPlayer _0024np2_00245725;

			internal IEnumerator _0024_0024iterator_0024256_00245726;

			internal string _0024n_00245727;

			internal string _0024team_00245728;

			internal bool _0024isAI_00245729;

			internal PhotonMessageInfo _0024s_00245730;

			internal SpawningScript _0024self__00245731;

			public _0024(string n, string team, bool isAI, PhotonMessageInfo s, SpawningScript self_)
			{
				_0024n_00245727 = n;
				_0024team_00245728 = team;
				_0024isAI_00245729 = isAI;
				_0024s_00245730 = s;
				_0024self__00245731 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					Debug.Log("Got instant call with vals: " + _0024n_00245727 + "    " + _0024isAI_00245729);
					result = (YieldDefault(2) ? 1 : 0);
					break;
				case 2:
					if (!RuntimeServices.EqualityOperator(_0024s_00245730.sender, PhotonNetwork.player))
					{
						RefreshMasterServer.personjoined = true;
					}
					_0024exists_00245720 = false;
					_0024_0024iterator_0024255_00245722 = UnityRuntimeServices.GetEnumerator(netPlayers);
					while (_0024_0024iterator_0024255_00245722.MoveNext())
					{
						object obj = _0024_0024iterator_0024255_00245722.Current;
						if (!(obj is NetPlayer))
						{
							obj = RuntimeServices.Coerce(obj, typeof(NetPlayer));
						}
						_0024np1_00245721 = (NetPlayer)obj;
						if (_0024np1_00245721.username == _0024n_00245727)
						{
							_0024exists_00245720 = true;
						}
					}
					if (!_0024exists_00245720)
					{
						_0024myNetPlayer_00245723 = new NetPlayer(_0024s_00245730.sender, _0024n_00245727, 0, 0, _0024team_00245728, _0024isAI_00245729);
						netPlayers.Add(_0024myNetPlayer_00245723);
					}
					else
					{
						RuntimeServices.SetProperty(netPlayers[_0024self__00245731.usernameToIndex(_0024n_00245727)], "team", _0024team_00245728);
					}
					_0024playerCounter_00245724 = 0;
					_0024_0024iterator_0024256_00245726 = UnityRuntimeServices.GetEnumerator(netPlayers);
					while (_0024_0024iterator_0024256_00245726.MoveNext())
					{
						object obj2 = _0024_0024iterator_0024256_00245726.Current;
						if (!(obj2 is NetPlayer))
						{
							obj2 = RuntimeServices.Coerce(obj2, typeof(NetPlayer));
						}
						_0024np2_00245725 = (NetPlayer)obj2;
						if (_0024np2_00245725.team != string.Empty)
						{
							_0024playerCounter_00245724++;
						}
					}
					if (_0024playerCounter_00245724 > 2 || !HeadlesssDedServer.isServerHost)
					{
					}
					result = (YieldDefault(3) ? 1 : 0);
					break;
				case 3:
					RefreshMasterServer.forceAIrefresh = true;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal string _0024n_00245732;

		internal string _0024team_00245733;

		internal bool _0024isAI_00245734;

		internal PhotonMessageInfo _0024s_00245735;

		internal SpawningScript _0024self__00245736;

		public _0024thisIsMyName_00245719(string n, string team, bool isAI, PhotonMessageInfo s, SpawningScript self_)
		{
			_0024n_00245732 = n;
			_0024team_00245733 = team;
			_0024isAI_00245734 = isAI;
			_0024s_00245735 = s;
			_0024self__00245736 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024n_00245732, _0024team_00245733, _0024isAI_00245734, _0024s_00245735, _0024self__00245736);
		}
	}

	[Serializable]
	internal sealed class _0024refreshRecursively_00245737 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal GameObject _0024obj_00245738;

			public _0024(GameObject obj)
			{
				_0024obj_00245738 = obj;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					((PhotonView)_0024obj_00245738.GetComponent(typeof(PhotonView))).enabled = false;
					result = (YieldDefault(2) ? 1 : 0);
					break;
				case 2:
					((PhotonView)_0024obj_00245738.GetComponent(typeof(PhotonView))).enabled = true;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal GameObject _0024obj_00245739;

		public _0024refreshRecursively_00245737(GameObject obj)
		{
			_0024obj_00245739 = obj;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024obj_00245739);
		}
	}

	[Serializable]
	internal sealed class _0024refreshobj_00245740 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal Vector3 _0024ppos_00245741;

			internal Quaternion _0024prot_00245742;

			internal GameObject _0024minimapcam_00245743;

			internal SpawningScript _0024self__00245744;

			public _0024(SpawningScript self_)
			{
				_0024self__00245744 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024ppos_00245741 = FakeDedicatedServer.spos;
					_0024prot_00245742 = FakeDedicatedServer.srot;
					FakeDedicatedServer.spos = Vector3.zero;
					result = (YieldDefault(2) ? 1 : 0);
					break;
				case 2:
					result = (YieldDefault(3) ? 1 : 0);
					break;
				case 3:
					if (_0024self__00245744.team == "red")
					{
						object obj = _0024self__00245744.customNetInstantiateRed(_0024self__00245744.redplayerPrefab, _0024ppos_00245741, _0024prot_00245742, 0);
						if (!(obj is Transform))
						{
							obj = RuntimeServices.Coerce(obj, typeof(Transform));
						}
						playertrans = (Transform)obj;
						_0024self__00245744.refresh.SendMessage("teamset", 1);
					}
					else if (_0024self__00245744.team == "blue")
					{
						object obj2 = _0024self__00245744.customNetInstantiateBlue(_0024self__00245744.playerPrefab, _0024ppos_00245741, _0024prot_00245742, 0);
						if (!(obj2 is Transform))
						{
							obj2 = RuntimeServices.Coerce(obj2, typeof(Transform));
						}
						playertrans = (Transform)obj2;
						_0024self__00245744.refresh.SendMessage("teamset", 2);
					}
					if (QualitySettings.GetQualityLevel() == 0)
					{
						GameObject.Find("/GUI/QualitySettings").SendMessage("setAllObjectsSimp");
					}
					if (_0024self__00245744.team != string.Empty)
					{
						_0024self__00245744.healthbar.SendMessage("sethealthdelegate", playertrans);
						Camera.main.SendMessage("SetTarget", playertrans);
						_0024minimapcam_00245743 = GameObject.FindWithTag("minimap");
						_0024minimapcam_00245743.SendMessage("SetTarget", playertrans);
						_0024self__00245744.healthbar.SendMessage("setmaincar", playertrans);
					}
					((PhotonView)GameObject.Find("/GUI/EndofRound").GetComponent(typeof(PhotonView))).RPC("fadeOutNetwork", PhotonTargets.MasterClient);
					if (PhotonNetwork.isMasterClient)
					{
						_0024self__00245744.addme();
					}
					else if (_0024self__00245744.team != string.Empty)
					{
						((PhotonView)_0024self__00245744.gameObject.GetComponent(typeof(PhotonView))).RPC("thisIsMyName", PhotonTargets.MasterClient, AuthGameObject.username, _0024self__00245744.team);
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

		internal SpawningScript _0024self__00245745;

		public _0024refreshobj_00245740(SpawningScript self_)
		{
			_0024self__00245745 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00245745);
		}
	}

	[NonSerialized]
	public static Transform playertrans;

	[NonSerialized]
	public static Transform playertransCar;

	public Transform playerPrefab;

	public Transform redplayerPrefab;

	public Transform chatscript;

	public GameObject healthbar;

	private bool spawnonce;

	public string username;

	public GameObject igs;

	private bool evictfalse;

	public GameObject spawn1;

	public GameObject spawn2;

	public GameObject spawn3;

	public GameObject spawn4;

	public GameObject spawn5;

	public GameObject spawn6;

	public GameObject redspawn1;

	public GameObject redspawn2;

	public GameObject redspawn3;

	public GameObject redspawn4;

	public GameObject redspawn5;

	public GameObject redspawn6;

	public GameObject refresh;

	private string team;

	[NonSerialized]
	public static string team2 = string.Empty;

	private bool messageonce;

	public AuthGameObject authgameobject;

	public LoadNetworkLevel loadnl;

	public CalculateHealth chealth;

	public FakeDedicatedServer fakeded;

	public MasterServerScript mserver;

	public FireGun fgun;

	public ToggleGuns toggun;

	public HeadlesssDedServer headless;

	public WhirldIn win;

	public TutorialManager tMan;

	public ChatScript cscript;

	public RefreshMasterServer refreshmserver;

	public GameObject flagbase;

	public GameObject expl;

	[NonSerialized]
	public static string activeplayers;

	[NonSerialized]
	public static string spectators;

	public Transform player1;

	public GameObject bluebot;

	public GameObject redbot;

	public GameObject explosionprefab;

	private bool switchteams;

	private Vector3 spos;

	private Quaternion srot;

	[NonSerialized]
	public static UnityScript.Lang.Array netPlayers = new UnityScript.Lang.Array();

	private int aiteam;

	[NonSerialized]
	public static UnityScript.Lang.Array spawnedCars = new UnityScript.Lang.Array();

	[NonSerialized]
	public static Transform[] aiplayerobjs = new Transform[3];

	[NonSerialized]
	public static string aiteamlist = string.Empty;

	[NonSerialized]
	public static UnityScript.Lang.Array netSpawnObjs = new UnityScript.Lang.Array();

	private Hashtable netCreatedObjects;

	private Hashtable sentPlayerList;

	public GameObject[] pPrefabsR;

	public GameObject[] pPrefabsB;

	public GameObject[] pickups;

	public GameObject ctfprefabblue;

	public GameObject ctfprefabred;

	private Hashtable cleanupNetPlayers;

	private Hashtable cleanupNetObjs;

	private bool isOriginalHost;

	public SpawningScript()
	{
		username = string.Empty;
		team = string.Empty;
		messageonce = true;
		cleanupNetPlayers = new Hashtable();
		cleanupNetObjs = new Hashtable();
	}

	[RPC]
	public virtual void vB(PhotonViewID id, int instId)
	{
		if (!netCreatedObjects.ContainsKey(instId))
		{
			NetArray netArray = new NetArray();
			netArray.isRed = false;
			netArray.arr.Add(id);
			netCreatedObjects.Add(instId, netArray);
		}
		else
		{
			UnityRuntimeServices.Invoke(UnityRuntimeServices.GetProperty(netCreatedObjects[instId], "arr"), "Add", new object[1] { id }, typeof(UnityEngine.MonoBehaviour));
		}
	}

	[RPC]
	public virtual void vR(PhotonViewID id, int instId)
	{
		if (!netCreatedObjects.ContainsKey(instId))
		{
			NetArray netArray = new NetArray();
			netArray.isRed = true;
			netArray.arr.Add(id);
			netCreatedObjects.Add(instId, netArray);
		}
		else
		{
			UnityRuntimeServices.Invoke(UnityRuntimeServices.GetProperty(netCreatedObjects[instId], "arr"), "Add", new object[1] { id }, typeof(UnityEngine.MonoBehaviour));
		}
	}

	[RPC]
	public virtual void remoteInstantiateRed(Vector3 pos, Quaternion rot, int id, int objType, Hashtable ht)
	{
		for (int i = 0; i < ht.Count; i++)
		{
			object obj = ht[i];
			if (!(obj is PhotonViewID))
			{
				obj = RuntimeServices.Coerce(obj, typeof(PhotonViewID));
			}
			vR((PhotonViewID)obj, id);
		}
		object obj2 = netCreatedObjects[id];
		if (!(obj2 is NetArray))
		{
			obj2 = RuntimeServices.Coerce(obj2, typeof(NetArray));
		}
		NetArray netArray = (NetArray)obj2;
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(pPrefabsR[objType], pos, rot);
		Component[] origRefs = ((ReturnOriginalReferences)gameObject.gameObject.GetComponent(typeof(ReturnOriginalReferences))).origRefs;
		for (int j = 0; j < UnityScript.Lang.Extensions.get_length((System.Array)origRefs); j++)
		{
			object obj3 = netArray.arr[j];
			if (!(obj3 is PhotonViewID))
			{
				obj3 = RuntimeServices.Coerce(obj3, typeof(PhotonViewID));
			}
			PhotonViewID value = (PhotonViewID)obj3;
			RuntimeServices.SetProperty(origRefs[j], "viewID", value);
		}
		if (objType == 1)
		{
			if (team2 == "red" && AuthGameObject.gametype != "Freeplay" && AuthGameObject.gametype != "Deathmatch" && AuthGameObject.gametype != "Survival")
			{
				gameObject.gameObject.tag = "RedTeam";
			}
			else
			{
				gameObject.gameObject.tag = "RedObjects";
			}
			((GunAndCameraBob)gameObject.GetComponent(typeof(GunAndCameraBob))).team = "red";
		}
		netArray.trans = gameObject.transform;
		netSpawnObjs.Add(netArray);
	}

	[RPC]
	public virtual void remoteInstantiateBlue(Vector3 pos, Quaternion rot, int id, int objType, Hashtable ht)
	{
		for (int i = 0; i < ht.Count; i++)
		{
			object obj = ht[i];
			if (!(obj is PhotonViewID))
			{
				obj = RuntimeServices.Coerce(obj, typeof(PhotonViewID));
			}
			vB((PhotonViewID)obj, id);
		}
		object obj2 = netCreatedObjects[id];
		if (!(obj2 is NetArray))
		{
			obj2 = RuntimeServices.Coerce(obj2, typeof(NetArray));
		}
		NetArray netArray = (NetArray)obj2;
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(pPrefabsB[objType], pos, rot);
		Component[] origRefs = ((ReturnOriginalReferences)gameObject.gameObject.GetComponent(typeof(ReturnOriginalReferences))).origRefs;
		for (int j = 0; j < UnityScript.Lang.Extensions.get_length((System.Array)origRefs); j++)
		{
			object obj3 = netArray.arr[j];
			if (!(obj3 is PhotonViewID))
			{
				obj3 = RuntimeServices.Coerce(obj3, typeof(PhotonViewID));
			}
			PhotonViewID value = (PhotonViewID)obj3;
			RuntimeServices.SetProperty(origRefs[j], "viewID", value);
		}
		if (objType == 1)
		{
			if (team2 == "blue")
			{
				gameObject.gameObject.tag = "BlueTeam";
			}
			else
			{
				gameObject.gameObject.tag = "BlueObjects";
			}
			((GunAndCameraBob)gameObject.GetComponent(typeof(GunAndCameraBob))).team = "blue";
		}
		if (objType == 2)
		{
		}
		if (objType == 3)
		{
		}
		netArray.trans = gameObject.transform;
		netSpawnObjs.Add(netArray);
	}

	[DuckTyped]
	public virtual object customNetInstantiateBlue(object prefab, Vector3 pos, Quaternion rot, int gr)
	{
		object obj = prefab;
		if (!(obj is UnityEngine.Object))
		{
			obj = RuntimeServices.Coerce(obj, typeof(UnityEngine.Object));
		}
		object obj2 = UnityEngine.Object.Instantiate((UnityEngine.Object)obj, pos, rot);
		object obj3 = UnityRuntimeServices.GetProperty(RuntimeServices.Invoke(UnityRuntimeServices.GetProperty(obj2, "gameObject"), "GetComponent", new object[1] { typeof(ReturnOriginalReferences) }), "origRefs");
		if (!(obj3 is Component[]))
		{
			obj3 = RuntimeServices.Coerce(obj3, typeof(Component[]));
		}
		Component[] array = (Component[])obj3;
		NetArray netArray = new NetArray();
		netArray.isRed = false;
		netArray.objectType = 0;
		object obj4 = UnityRuntimeServices.GetProperty(obj2, "transform");
		if (!(obj4 is Transform))
		{
			obj4 = RuntimeServices.Coerce(obj4, typeof(Transform));
		}
		netArray.trans = (Transform)obj4;
		for (int i = 0; i < UnityScript.Lang.Extensions.get_length((System.Array)array); i++)
		{
			PhotonViewID value = PhotonNetwork.AllocateViewID();
			netArray.arr.Add(value);
			RuntimeServices.SetProperty(array[i], "viewID", value);
		}
		netSpawnObjs.Add(netArray);
		int num = UnityEngine.Random.Range(-999999999, 999999999);
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < netArray.arr.length; i++)
		{
			hashtable.Add(i, netArray.arr[i]);
		}
		((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("remoteInstantiateBlue", PhotonTargets.OthersBuffered, netArray.trans.position, netArray.trans.rotation, num, 0, hashtable);
		return obj2;
	}

	[DuckTyped]
	public virtual object customNetInstantiateRed(object prefab, Vector3 pos, Quaternion rot, int gr)
	{
		object obj = prefab;
		if (!(obj is UnityEngine.Object))
		{
			obj = RuntimeServices.Coerce(obj, typeof(UnityEngine.Object));
		}
		object obj2 = UnityEngine.Object.Instantiate((UnityEngine.Object)obj, pos, rot);
		object obj3 = UnityRuntimeServices.GetProperty(RuntimeServices.Invoke(UnityRuntimeServices.GetProperty(obj2, "gameObject"), "GetComponent", new object[1] { typeof(ReturnOriginalReferences) }), "origRefs");
		if (!(obj3 is Component[]))
		{
			obj3 = RuntimeServices.Coerce(obj3, typeof(Component[]));
		}
		Component[] array = (Component[])obj3;
		NetArray netArray = new NetArray();
		netArray.isRed = true;
		netArray.objectType = 0;
		object obj4 = UnityRuntimeServices.GetProperty(obj2, "transform");
		if (!(obj4 is Transform))
		{
			obj4 = RuntimeServices.Coerce(obj4, typeof(Transform));
		}
		netArray.trans = (Transform)obj4;
		for (int i = 0; i < UnityScript.Lang.Extensions.get_length((System.Array)array); i++)
		{
			PhotonViewID value = PhotonNetwork.AllocateViewID();
			netArray.arr.Add(value);
			RuntimeServices.SetProperty(array[i], "viewID", value);
		}
		netSpawnObjs.Add(netArray);
		int num = UnityEngine.Random.Range(-999999999, 999999999);
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < netArray.arr.length; i++)
		{
			hashtable.Add(i, netArray.arr[i]);
		}
		((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("remoteInstantiateRed", PhotonTargets.OthersBuffered, netArray.trans.position, netArray.trans.rotation, num, 0, hashtable);
		return obj2;
	}

	public virtual GameObject customHumanInstantiate(Vector3 pos, Quaternion rot, string team)
	{
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate((!(team == "red")) ? pPrefabsB[1] : pPrefabsR[1], pos, rot);
		Component[] origRefs = ((ReturnOriginalReferences)gameObject.gameObject.GetComponent(typeof(ReturnOriginalReferences))).origRefs;
		NetArray netArray = new NetArray();
		netArray.isRed = true;
		netArray.objectType = 1;
		netArray.trans = gameObject.transform;
		for (int i = 0; i < UnityScript.Lang.Extensions.get_length((System.Array)origRefs); i++)
		{
			PhotonViewID value = PhotonNetwork.AllocateViewID();
			netArray.arr.Add(value);
			RuntimeServices.SetProperty(origRefs[i], "viewID", value);
		}
		netSpawnObjs.Add(netArray);
		int num = UnityEngine.Random.Range(-999999999, 999999999);
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < netArray.arr.length; i++)
		{
			hashtable.Add(i, netArray.arr[i]);
		}
		((PhotonView)playertransCar.GetComponent(typeof(PhotonView))).RPC("remoteInstantiateDel" + ((!(team == "red")) ? "Blue" : "Red"), PhotonTargets.OthersBuffered, netArray.trans.position, netArray.trans.rotation, num, 1, hashtable);
		return gameObject;
	}

	public virtual GameObject customPickupInstantiate(Vector3 pos, Quaternion rot, int t)
	{
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(pickups[t], pos, rot);
		Component[] origRefs = ((ReturnOriginalReferences)gameObject.gameObject.GetComponent(typeof(ReturnOriginalReferences))).origRefs;
		NetArray netArray = new NetArray();
		netArray.isRed = false;
		netArray.objectType = 2 + t;
		netArray.trans = gameObject.transform;
		for (int i = 0; i < UnityScript.Lang.Extensions.get_length((System.Array)origRefs); i++)
		{
			PhotonViewID value = PhotonNetwork.AllocateViewID();
			netArray.arr.Add(value);
			RuntimeServices.SetProperty(origRefs[i], "viewID", value);
		}
		netSpawnObjs.Add(netArray);
		int num = UnityEngine.Random.Range(-999999999, 999999999);
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < netArray.arr.length; i++)
		{
			hashtable.Add(i, netArray.arr[i]);
		}
		((PhotonView)this.gameObject.GetComponent(typeof(PhotonView))).RPC("remoteInstantiateBlue", PhotonTargets.OthersBuffered, netArray.trans.position, netArray.trans.rotation, num, 2 + t, hashtable);
		return gameObject;
	}

	[RPC]
	public virtual void customHumanDestroy(PhotonMessageInfo info)
	{
		for (int i = 0; i < netSpawnObjs.length; i++)
		{
			if (RuntimeServices.EqualityOperator(UnityRuntimeServices.GetProperty(RuntimeServices.GetSlice(netSpawnObjs[i], "arr", new object[1] { 0 }), "owner"), info.sender) && RuntimeServices.EqualityOperator(UnityRuntimeServices.GetProperty(netSpawnObjs[i], "objectType"), 1))
			{
				netSpawnObjs.RemoveAt(i);
				break;
			}
		}
	}

	[RPC]
	public virtual void updateAuthValues(int weatherindex, string whirldurl, string whirldmmurl, string whirldname, int maxplayers, int timelimit, string gametype, bool isAIserver, bool ff, string gamenamestring, int curworld, string ainame, string ainame2, string ainame3, bool fpsen, string bList, bool cDam)
	{
		AuthGameObject.weatherindex = weatherindex;
		AuthGameObject.whirldurl = whirldurl;
		AuthGameObject.whirldmmurl = whirldmmurl;
		AuthGameObject.whirldname = whirldname;
		AuthGameObject.maxplayers = maxplayers;
		AuthGameObject.timelimit = timelimit;
		AuthGameObject.gametype = gametype;
		AuthGameObject.isAIserver = isAIserver;
		AuthGameObject.ff = ff;
		MasterServerScript.gamenamestring = gamenamestring;
		MasterServerScript.curworld = curworld;
		MasterServerScript.ainame = ainame;
		MasterServerScript.ainame2 = ainame2;
		MasterServerScript.ainame3 = ainame3;
		AuthGameObject.fpsenabled = fpsen;
		RefreshMasterServer.bannedList = bList;
		AuthGameObject.cDam = cDam;
		Debug.Log("Auth values updated!");
	}

	[RPC]
	public virtual void addNetworkPlayer(PhotonPlayer nplayer, string username, int kills, int deaths, string team, bool isAI)
	{
		Debug.Log("Got non-buffered instant call with vals: " + username + "    " + isAI);
		bool flag = false;
		IEnumerator enumerator = UnityRuntimeServices.GetEnumerator(netPlayers);
		while (enumerator.MoveNext())
		{
			object obj = enumerator.Current;
			if (!(obj is NetPlayer))
			{
				obj = RuntimeServices.Coerce(obj, typeof(NetPlayer));
			}
			NetPlayer netPlayer = (NetPlayer)obj;
			if (netPlayer.username == username)
			{
				flag = true;
			}
		}
		if (!flag)
		{
			NetPlayer value = new NetPlayer(nplayer, username, kills, deaths, team, isAI);
			netPlayers.Add(value);
			return;
		}
		RuntimeServices.SetProperty(netPlayers[usernameToIndex(username)], "username", username);
		RuntimeServices.SetProperty(netPlayers[usernameToIndex(username)], "kills", kills);
		RuntimeServices.SetProperty(netPlayers[usernameToIndex(username)], "deaths", deaths);
		RuntimeServices.SetProperty(netPlayers[usernameToIndex(username)], "team", team);
		RuntimeServices.SetProperty(netPlayers[usernameToIndex(username)], "isAI", isAI);
	}

	public virtual void OnPhotonPlayerConnected(PhotonPlayer p)
	{
		IEnumerator enumerator = UnityRuntimeServices.GetEnumerator(netPlayers);
		while (enumerator.MoveNext())
		{
			object obj = enumerator.Current;
			if (!(obj is NetPlayer))
			{
				obj = RuntimeServices.Coerce(obj, typeof(NetPlayer));
			}
			NetPlayer netPlayer = (NetPlayer)obj;
			((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("addNetworkPlayer", p, netPlayer.nplayer, netPlayer.username, netPlayer.kills, netPlayer.deaths, netPlayer.team, netPlayer.isAI);
			UnityRuntimeServices.Update(enumerator, netPlayer);
		}
	}

	public virtual IEnumerator spawnAI(int i)
	{
		return new _0024spawnAI_00245648(i, this).GetEnumerator();
	}

	[RPC]
	public virtual void createAIPlayer(int i)
	{
		if (i == 1)
		{
			object obj = customNetInstantiateRed(redplayerPrefab, redspawn1.transform.position, redspawn1.transform.rotation, 10);
			if (!(obj is Transform))
			{
				obj = RuntimeServices.Coerce(obj, typeof(Transform));
			}
			player1 = (Transform)obj;
			AIManager aIManager = (AIManager)player1.gameObject.GetComponent("AIManager");
			aIManager.target = playertrans;
			aIManager.isAI = true;
		}
		else
		{
			object obj2 = customNetInstantiateBlue(playerPrefab, spawn1.transform.position, spawn1.transform.rotation, 10);
			if (!(obj2 is Transform))
			{
				obj2 = RuntimeServices.Coerce(obj2, typeof(Transform));
			}
			player1 = (Transform)obj2;
			AIManager aIManager = (AIManager)player1.gameObject.GetComponent("AIManager");
			aIManager.target = playertrans;
			aIManager.isAI = true;
		}
	}

	[RPC]
	public virtual void destroyAIPlayer()
	{
		UnityEngine.Object.Destroy(player1);
	}

	public virtual IEnumerator SpawnNetworkedBots(int i)
	{
		return new _0024SpawnNetworkedBots_00245660(i, this).GetEnumerator();
	}

	public virtual void respawnAIs()
	{
		UnityScript.Lang.Array array = new UnityScript.Lang.Array(redspawn1, redspawn2, redspawn3, redspawn4, redspawn5, redspawn6);
		UnityScript.Lang.Array array2 = new UnityScript.Lang.Array(spawn1, spawn2, spawn3, spawn4, spawn5, spawn6);
		if (aiplayerobjs[0] != null)
		{
			if (aiteamlist == "rbb")
			{
				aiplayerobjs[0].position = (Vector3)UnityRuntimeServices.GetProperty(UnityRuntimeServices.GetProperty(array[UnityEngine.Random.Range(0, 6)], "transform"), "position");
				aiplayerobjs[0].rotation = (Quaternion)UnityRuntimeServices.GetProperty(UnityRuntimeServices.GetProperty(array[UnityEngine.Random.Range(0, 6)], "transform"), "rotation");
			}
			else if (aiteamlist == "brr")
			{
				aiplayerobjs[0].position = (Vector3)UnityRuntimeServices.GetProperty(UnityRuntimeServices.GetProperty(array2[UnityEngine.Random.Range(0, 6)], "transform"), "position");
				aiplayerobjs[0].rotation = (Quaternion)UnityRuntimeServices.GetProperty(UnityRuntimeServices.GetProperty(array2[UnityEngine.Random.Range(0, 6)], "transform"), "rotation");
			}
			aiplayerobjs[0].SendMessage("resetHealth");
		}
		if (aiplayerobjs[1] != null)
		{
			if (aiteamlist == "brr")
			{
				aiplayerobjs[1].position = (Vector3)UnityRuntimeServices.GetProperty(UnityRuntimeServices.GetProperty(array[UnityEngine.Random.Range(0, 6)], "transform"), "position");
				aiplayerobjs[1].rotation = (Quaternion)UnityRuntimeServices.GetProperty(UnityRuntimeServices.GetProperty(array[UnityEngine.Random.Range(0, 6)], "transform"), "rotation");
			}
			else if (aiteamlist == "rbb")
			{
				aiplayerobjs[1].position = (Vector3)UnityRuntimeServices.GetProperty(UnityRuntimeServices.GetProperty(array2[UnityEngine.Random.Range(0, 6)], "transform"), "position");
				aiplayerobjs[1].rotation = (Quaternion)UnityRuntimeServices.GetProperty(UnityRuntimeServices.GetProperty(array2[UnityEngine.Random.Range(0, 6)], "transform"), "rotation");
			}
			aiplayerobjs[1].SendMessage("resetHealth");
		}
		if (aiplayerobjs[2] != null)
		{
			if (aiteamlist == "brr")
			{
				aiplayerobjs[2].position = (Vector3)UnityRuntimeServices.GetProperty(UnityRuntimeServices.GetProperty(array[UnityEngine.Random.Range(0, 6)], "transform"), "position");
				aiplayerobjs[2].rotation = (Quaternion)UnityRuntimeServices.GetProperty(UnityRuntimeServices.GetProperty(array[UnityEngine.Random.Range(0, 6)], "transform"), "rotation");
			}
			else if (aiteamlist == "rbb")
			{
				aiplayerobjs[2].position = (Vector3)UnityRuntimeServices.GetProperty(UnityRuntimeServices.GetProperty(array2[UnityEngine.Random.Range(0, 6)], "transform"), "position");
				aiplayerobjs[2].rotation = (Quaternion)UnityRuntimeServices.GetProperty(UnityRuntimeServices.GetProperty(array2[UnityEngine.Random.Range(0, 6)], "transform"), "rotation");
			}
			aiplayerobjs[2].SendMessage("resetHealth");
		}
	}

	public virtual void sendmessagedel(string i)
	{
		chatscript.SendMessage("OutsideSystemNoRPC", i);
	}

	[RPC]
	public virtual void resetstats()
	{
		IEnumerator enumerator = UnityRuntimeServices.GetEnumerator(netPlayers);
		while (enumerator.MoveNext())
		{
			object obj = enumerator.Current;
			if (!(obj is NetPlayer))
			{
				obj = RuntimeServices.Coerce(obj, typeof(NetPlayer));
			}
			NetPlayer netPlayer = (NetPlayer)obj;
			netPlayer.kills = 0;
			UnityRuntimeServices.Update(enumerator, netPlayer);
			netPlayer.deaths = 0;
			UnityRuntimeServices.Update(enumerator, netPlayer);
		}
	}

	public virtual void addkiller(string p)
	{
		((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("addkillerRPC", PhotonTargets.All, p);
	}

	[RPC]
	public virtual void addkillerRPC(string p)
	{
		IEnumerator enumerator = UnityRuntimeServices.GetEnumerator(netPlayers);
		while (enumerator.MoveNext())
		{
			object obj = enumerator.Current;
			if (!(obj is NetPlayer))
			{
				obj = RuntimeServices.Coerce(obj, typeof(NetPlayer));
			}
			NetPlayer netPlayer = (NetPlayer)obj;
			if (netPlayer.username == p)
			{
				netPlayer.kills++;
				UnityRuntimeServices.Update(enumerator, netPlayer);
			}
		}
	}

	public virtual void addvictim(string p)
	{
		((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("addvictimRPC", PhotonTargets.All, p);
	}

	[RPC]
	public virtual void addvictimRPC(string p)
	{
		IEnumerator enumerator = UnityRuntimeServices.GetEnumerator(netPlayers);
		while (enumerator.MoveNext())
		{
			object obj = enumerator.Current;
			if (!(obj is NetPlayer))
			{
				obj = RuntimeServices.Coerce(obj, typeof(NetPlayer));
			}
			NetPlayer netPlayer = (NetPlayer)obj;
			if (netPlayer.username == p)
			{
				netPlayer.deaths++;
				UnityRuntimeServices.Update(enumerator, netPlayer);
			}
		}
	}

	public virtual void Awake()
	{
		spawnedCars.Clear();
		netSpawnObjs.Clear();
		aiplayerobjs = new Transform[3];
		team2 = string.Empty;
		aiteamlist = string.Empty;
		username = AuthGameObject.username;
	}

	public virtual void setteam(string t)
	{
		team = t;
		((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("thisIsMyName", PhotonTargets.AllBuffered, AuthGameObject.username, team, false);
	}

	public virtual void addme()
	{
	}

	public virtual IEnumerator Start()
	{
		return new _0024Start_00245673(this).GetEnumerator();
	}

	[RPC]
	public virtual IEnumerator setUpNetPlayer(string u, bool isAI, PhotonMessageInfo info)
	{
		return new _0024setUpNetPlayer_00245676(u, isAI, info).GetEnumerator();
	}

	[RPC]
	public virtual void makeexplosion(Vector3 pos, Quaternion rot)
	{
		UnityEngine.Object.Instantiate(expl, pos, rot);
	}

	public virtual void droppedflag(PhotonPlayer p)
	{
		chatscript.SendMessage("OutsideSystemNoRPC", networkPlayerToUsername(p) + " dropped the flag.");
	}

	public virtual IEnumerator Respawn(float t)
	{
		return new _0024Respawn_00245687(t, this).GetEnumerator();
	}

	public virtual void cleanupDelayNetSpawn(Transform trans)
	{
	}

	public virtual void cleanupDelayNetPlayers(PhotonPlayer pp)
	{
	}

	public virtual void Update()
	{
		if (!spawnonce && team != string.Empty && PhotonNetwork.connectionState != ConnectionState.Disconnected)
		{
			Spawn();
			spawnonce = true;
		}
		team2 = team;
		string text = string.Empty;
		string text2 = string.Empty;
		IEnumerator enumerator = UnityRuntimeServices.GetEnumerator(netPlayers);
		while (enumerator.MoveNext())
		{
			object obj = enumerator.Current;
			if (!(obj is NetPlayer))
			{
				obj = RuntimeServices.Coerce(obj, typeof(NetPlayer));
			}
			NetPlayer netPlayer = (NetPlayer)obj;
			if (netPlayer.team == string.Empty)
			{
				if (text2 != string.Empty)
				{
					text2 += ", " + netPlayer.username;
					UnityRuntimeServices.Update(enumerator, netPlayer);
				}
				else
				{
					text2 = netPlayer.username;
					UnityRuntimeServices.Update(enumerator, netPlayer);
				}
			}
			else if (text != string.Empty)
			{
				text += ", " + netPlayer.username;
				UnityRuntimeServices.Update(enumerator, netPlayer);
			}
			else
			{
				text = netPlayer.username;
				UnityRuntimeServices.Update(enumerator, netPlayer);
			}
		}
		if (text2 == string.Empty)
		{
			text2 = "None";
		}
		activeplayers = text;
		spectators = text2;
	}

	[RPC]
	public virtual void customNetDestroy()
	{
		UnityEngine.Object.Destroy(gameObject);
	}

	public virtual void chatsetcontrol(object t)
	{
		if (playertrans != null)
		{
			playertrans.gameObject.SendMessage("setcontrol", t);
		}
	}

	public virtual void returnmaincar(GameObject t)
	{
		if (team != string.Empty)
		{
			t.SendMessage("returnedobj", playertrans);
		}
	}

	[RPC]
	public virtual void createExplosion(Vector3 pos)
	{
		UnityEngine.Object.Instantiate(explosionprefab, pos, transform.rotation);
	}

	public virtual void returnNewTarget()
	{
		GameObject[] array = GameObject.FindGameObjectsWithTag("AttackBot");
		if (UnityScript.Lang.Extensions.get_length((System.Array)array) <= 0)
		{
			return;
		}
		UnityScript.Lang.Array array2 = new UnityScript.Lang.Array();
		int i = 0;
		GameObject[] array3 = (GameObject[])UnityEngine.Object.FindObjectsOfType(typeof(GameObject));
		for (int length = array3.Length; i < length; i++)
		{
			if (array3[i].name == "CarPrefab(Clone)")
			{
				if (team2 == "red" && RuntimeServices.EqualityOperator(RuntimeServices.Invoke(array3[i].GetComponent("PlayerCar_Script"), "returnTeam", new object[0]), "blue"))
				{
					array2.Add(array3[i]);
				}
				if (team2 == "blue" && RuntimeServices.EqualityOperator(RuntimeServices.Invoke(array3[i].GetComponent("PlayerCar_Script"), "returnTeam", new object[0]), "red"))
				{
					array2.Add(array3[i]);
				}
			}
		}
		if (array2.length > 0)
		{
			int index = (int)Mathf.Round(UnityEngine.Random.Range(0, array2.length - 1));
			int j = 0;
			GameObject[] array4 = array;
			for (int length2 = array4.Length; j < length2; j++)
			{
				array4[j].BroadcastMessage("setTarget", UnityRuntimeServices.GetProperty(array2[index], "transform"));
			}
			return;
		}
		int k = 0;
		GameObject[] array5 = array;
		for (int length3 = array5.Length; k < length3; k++)
		{
			((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("createExplosion", PhotonTargets.All, array5[k].transform.position);
			UnityEngine.Object.Destroy(array5[k]);
		}
	}

	public virtual void killAllAttackBots()
	{
		GameObject[] array = GameObject.FindGameObjectsWithTag("AttackBot");
		int i = 0;
		GameObject[] array2 = array;
		for (int length = array2.Length; i < length; i++)
		{
			if (((PhotonView)array2[i].GetComponent(typeof(PhotonView))).isMine)
			{
				PhotonNetwork.Destroy(array2[i]);
			}
		}
	}

	[RPC]
	public virtual void getViewID(PhotonMessageInfo info)
	{
		((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("returnViewID", info.sender, WhirldIn.flagId, WhirldIn.flag2Id);
	}

	[RPC]
	public virtual void returnViewID(PhotonViewID id1, PhotonViewID id2)
	{
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(ctfprefabblue, new Vector3(422.0682f, 107.0283f, 2094.59f), Quaternion.Euler(0f, 270f, 0f));
		GameObject gameObject2 = (GameObject)UnityEngine.Object.Instantiate(ctfprefabred, new Vector3(3503.526f, 107.0283f, 2094.517f), Quaternion.Euler(0f, 90f, 0f));
		RuntimeServices.SetProperty(gameObject.GetComponent("CTFFlagSender"), "otherflagunit", gameObject2.gameObject);
		RuntimeServices.SetProperty(gameObject.GetComponent("CTFFlagSender"), "srcobj", GameObject.Find("/GUI/Chat"));
		RuntimeServices.SetProperty(gameObject.GetComponent("CTFFlagSender"), "igs", GameObject.Find("/GUI/GameScores"));
		((PhotonView)gameObject.GetComponent(typeof(PhotonView))).viewID = id1;
		RuntimeServices.SetProperty(gameObject2.GetComponent("CTFFlagSender"), "otherflagunit", gameObject.gameObject);
		RuntimeServices.SetProperty(gameObject2.GetComponent("CTFFlagSender"), "srcobj", GameObject.Find("/GUI/Chat"));
		RuntimeServices.SetProperty(gameObject2.GetComponent("CTFFlagSender"), "igs", GameObject.Find("/GUI/GameScores"));
		((PhotonView)gameObject2.GetComponent(typeof(PhotonView))).viewID = id2;
		RuntimeServices.SetProperty(GameObject.Find("/Spawn Point").GetComponent("SpawningScript"), "flagbase", gameObject.gameObject);
		gameObject.gameObject.name = "FlagBase";
		gameObject2.gameObject.name = "FlagBase";
	}

	public virtual void Spawn()
	{
		if (!PhotonNetwork.isMasterClient && Application.loadedLevelName == "CCWhirldScene" && AuthGameObject.gametype == "Capture the Flag" && AuthGameObject.whirldname == "Eric's CTF")
		{
			((PhotonView)this.gameObject.GetComponent(typeof(PhotonView))).RPC("getViewID", PhotonTargets.MasterClient);
		}
		int num = UnityEngine.Random.Range(1, 7);
		if (AuthGameObject.showTutorial)
		{
			num = 4;
		}
		if (AuthGameObject.isAIserver && (num == 0 || num == 1 || num == 2))
		{
			num = 4;
		}
		if (AuthGameObject.gametype != "Freeplay" && AuthGameObject.gametype != "Deathmatch" && AuthGameObject.gametype != "Survival")
		{
			if (team == "blue")
			{
				if (num == 1)
				{
					object obj = customNetInstantiateBlue(playerPrefab, spawn1.transform.position, spawn1.transform.rotation, 0);
					if (!(obj is Transform))
					{
						obj = RuntimeServices.Coerce(obj, typeof(Transform));
					}
					playertrans = (Transform)obj;
				}
				if (num == 2)
				{
					object obj2 = customNetInstantiateBlue(playerPrefab, spawn2.transform.position, spawn2.transform.rotation, 0);
					if (!(obj2 is Transform))
					{
						obj2 = RuntimeServices.Coerce(obj2, typeof(Transform));
					}
					playertrans = (Transform)obj2;
				}
				if (num == 3)
				{
					object obj3 = customNetInstantiateBlue(playerPrefab, spawn3.transform.position, spawn3.transform.rotation, 0);
					if (!(obj3 is Transform))
					{
						obj3 = RuntimeServices.Coerce(obj3, typeof(Transform));
					}
					playertrans = (Transform)obj3;
				}
				if (num == 4)
				{
					object obj4 = customNetInstantiateBlue(playerPrefab, spawn4.transform.position, spawn4.transform.rotation, 0);
					if (!(obj4 is Transform))
					{
						obj4 = RuntimeServices.Coerce(obj4, typeof(Transform));
					}
					playertrans = (Transform)obj4;
				}
				if (num == 5)
				{
					object obj5 = customNetInstantiateBlue(playerPrefab, spawn5.transform.position, spawn5.transform.rotation, 0);
					if (!(obj5 is Transform))
					{
						obj5 = RuntimeServices.Coerce(obj5, typeof(Transform));
					}
					playertrans = (Transform)obj5;
				}
				if (num == 6)
				{
					object obj6 = customNetInstantiateBlue(playerPrefab, spawn6.transform.position, spawn6.transform.rotation, 0);
					if (!(obj6 is Transform))
					{
						obj6 = RuntimeServices.Coerce(obj6, typeof(Transform));
					}
					playertrans = (Transform)obj6;
				}
			}
			else
			{
				if (num == 1)
				{
					object obj7 = customNetInstantiateRed(redplayerPrefab, redspawn1.transform.position, redspawn1.transform.rotation, 0);
					if (!(obj7 is Transform))
					{
						obj7 = RuntimeServices.Coerce(obj7, typeof(Transform));
					}
					playertrans = (Transform)obj7;
				}
				if (num == 2)
				{
					object obj8 = customNetInstantiateRed(redplayerPrefab, redspawn2.transform.position, redspawn2.transform.rotation, 0);
					if (!(obj8 is Transform))
					{
						obj8 = RuntimeServices.Coerce(obj8, typeof(Transform));
					}
					playertrans = (Transform)obj8;
				}
				if (num == 3)
				{
					object obj9 = customNetInstantiateRed(redplayerPrefab, redspawn3.transform.position, redspawn3.transform.rotation, 0);
					if (!(obj9 is Transform))
					{
						obj9 = RuntimeServices.Coerce(obj9, typeof(Transform));
					}
					playertrans = (Transform)obj9;
				}
				if (num == 4)
				{
					object obj10 = customNetInstantiateRed(redplayerPrefab, redspawn4.transform.position, redspawn4.transform.rotation, 0);
					if (!(obj10 is Transform))
					{
						obj10 = RuntimeServices.Coerce(obj10, typeof(Transform));
					}
					playertrans = (Transform)obj10;
				}
				if (num == 5)
				{
					object obj11 = customNetInstantiateRed(redplayerPrefab, redspawn5.transform.position, redspawn5.transform.rotation, 0);
					if (!(obj11 is Transform))
					{
						obj11 = RuntimeServices.Coerce(obj11, typeof(Transform));
					}
					playertrans = (Transform)obj11;
				}
				if (num == 6)
				{
					object obj12 = customNetInstantiateRed(redplayerPrefab, redspawn6.transform.position, redspawn6.transform.rotation, 0);
					if (!(obj12 is Transform))
					{
						obj12 = RuntimeServices.Coerce(obj12, typeof(Transform));
					}
					playertrans = (Transform)obj12;
				}
			}
		}
		else
		{
			num = UnityEngine.Random.Range(1, 12);
			if (num == 1)
			{
				object obj13 = customNetInstantiateRed(redplayerPrefab, spawn1.transform.position, spawn1.transform.rotation, 0);
				if (!(obj13 is Transform))
				{
					obj13 = RuntimeServices.Coerce(obj13, typeof(Transform));
				}
				playertrans = (Transform)obj13;
			}
			if (num == 2)
			{
				object obj14 = customNetInstantiateRed(redplayerPrefab, spawn2.transform.position, spawn2.transform.rotation, 0);
				if (!(obj14 is Transform))
				{
					obj14 = RuntimeServices.Coerce(obj14, typeof(Transform));
				}
				playertrans = (Transform)obj14;
			}
			if (num == 3)
			{
				object obj15 = customNetInstantiateRed(redplayerPrefab, spawn3.transform.position, spawn3.transform.rotation, 0);
				if (!(obj15 is Transform))
				{
					obj15 = RuntimeServices.Coerce(obj15, typeof(Transform));
				}
				playertrans = (Transform)obj15;
			}
			if (num == 4)
			{
				object obj16 = customNetInstantiateRed(redplayerPrefab, spawn4.transform.position, spawn4.transform.rotation, 0);
				if (!(obj16 is Transform))
				{
					obj16 = RuntimeServices.Coerce(obj16, typeof(Transform));
				}
				playertrans = (Transform)obj16;
			}
			if (num == 5)
			{
				object obj17 = customNetInstantiateRed(redplayerPrefab, spawn5.transform.position, spawn5.transform.rotation, 0);
				if (!(obj17 is Transform))
				{
					obj17 = RuntimeServices.Coerce(obj17, typeof(Transform));
				}
				playertrans = (Transform)obj17;
			}
			if (num == 6)
			{
				object obj18 = customNetInstantiateRed(redplayerPrefab, spawn6.transform.position, spawn6.transform.rotation, 0);
				if (!(obj18 is Transform))
				{
					obj18 = RuntimeServices.Coerce(obj18, typeof(Transform));
				}
				playertrans = (Transform)obj18;
			}
			if (num == 7)
			{
				object obj19 = customNetInstantiateRed(redplayerPrefab, redspawn1.transform.position, redspawn1.transform.rotation, 0);
				if (!(obj19 is Transform))
				{
					obj19 = RuntimeServices.Coerce(obj19, typeof(Transform));
				}
				playertrans = (Transform)obj19;
			}
			if (num == 8)
			{
				object obj20 = customNetInstantiateRed(redplayerPrefab, redspawn2.transform.position, redspawn2.transform.rotation, 0);
				if (!(obj20 is Transform))
				{
					obj20 = RuntimeServices.Coerce(obj20, typeof(Transform));
				}
				playertrans = (Transform)obj20;
			}
			if (num == 9)
			{
				object obj21 = customNetInstantiateRed(redplayerPrefab, redspawn3.transform.position, redspawn3.transform.rotation, 0);
				if (!(obj21 is Transform))
				{
					obj21 = RuntimeServices.Coerce(obj21, typeof(Transform));
				}
				playertrans = (Transform)obj21;
			}
			if (num == 10)
			{
				object obj22 = customNetInstantiateRed(redplayerPrefab, redspawn4.transform.position, redspawn4.transform.rotation, 0);
				if (!(obj22 is Transform))
				{
					obj22 = RuntimeServices.Coerce(obj22, typeof(Transform));
				}
				playertrans = (Transform)obj22;
			}
			if (num == 11)
			{
				object obj23 = customNetInstantiateRed(redplayerPrefab, redspawn5.transform.position, redspawn5.transform.rotation, 0);
				if (!(obj23 is Transform))
				{
					obj23 = RuntimeServices.Coerce(obj23, typeof(Transform));
				}
				playertrans = (Transform)obj23;
			}
			if (num == 12)
			{
				object obj24 = customNetInstantiateRed(redplayerPrefab, redspawn6.transform.position, redspawn6.transform.rotation, 0);
				if (!(obj24 is Transform))
				{
					obj24 = RuntimeServices.Coerce(obj24, typeof(Transform));
				}
				playertrans = (Transform)obj24;
			}
		}
		playertransCar = playertrans;
		Camera.main.SendMessage("SetTarget", playertrans);
		GameObject gameObject = GameObject.FindWithTag("minimap");
		gameObject.SendMessage("SetTarget", playertrans);
		string value = ((!(AuthGameObject.gametype != "Freeplay") || !(AuthGameObject.gametype != "Deathmatch") || !(AuthGameObject.gametype != "Survival")) ? (username + " has joined the server!") : (username + " has joined the server and is allied with the " + team + " team!"));
		chatscript.SendMessage("OutsideSystem", value, SendMessageOptions.DontRequireReceiver);
		chatscript.SendMessage("ownteam", team, SendMessageOptions.DontRequireReceiver);
		healthbar.SendMessage("setmaincar", playertrans);
	}

	public virtual IEnumerator disconnectAIs(string u)
	{
		return new _0024disconnectAIs_00245699(u, this).GetEnumerator();
	}

	[RPC]
	public virtual void dB()
	{
		AuthGameObject.isAIserver = false;
	}

	public virtual void OnMasterClientSwitched(PhotonPlayer p)
	{
		if (AuthGameObject.isAIserver && PhotonNetwork.isMasterClient)
		{
			IEnumerator enumerator = UnityRuntimeServices.GetEnumerator(netPlayers);
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				if (!(obj is NetPlayer))
				{
					obj = RuntimeServices.Coerce(obj, typeof(NetPlayer));
				}
				NetPlayer netPlayer = (NetPlayer)obj;
				if (netPlayer.isAI)
				{
					StartCoroutine_Auto(disconnectAIs(netPlayer.username));
					UnityRuntimeServices.Update(enumerator, netPlayer);
				}
			}
		}
		AuthGameObject.isAIserver = false;
		MasterServerScript.ainame = string.Empty;
		MasterServerScript.ainame2 = string.Empty;
		MasterServerScript.ainame3 = string.Empty;
		aiplayerobjs = null;
		aiteamlist = string.Empty;
		if (PhotonNetwork.isMasterClient)
		{
			((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("updateAuthValues", PhotonTargets.AllBuffered, AuthGameObject.weatherindex, AuthGameObject.whirldurl, AuthGameObject.whirldmmurl, AuthGameObject.whirldname, AuthGameObject.maxplayers, AuthGameObject.timelimit, AuthGameObject.gametype, AuthGameObject.isAIserver, AuthGameObject.ff, MasterServerScript.gamenamestring, MasterServerScript.curworld, MasterServerScript.ainame, MasterServerScript.ainame2, MasterServerScript.ainame3, AuthGameObject.fpsenabled, RefreshMasterServer.bannedList, AuthGameObject.cDam);
		}
	}

	public virtual IEnumerator OnPhotonPlayerDisconnected(PhotonPlayer playerD)
	{
		return new _0024OnPhotonPlayerDisconnected_00245708(playerD, this).GetEnumerator();
	}

	public virtual string networkPlayerToUsername(PhotonPlayer n)
	{
		IEnumerator enumerator = UnityRuntimeServices.GetEnumerator(netPlayers);
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
				if (RuntimeServices.EqualityOperator(netPlayer.nplayer, n) && !netPlayer.isAI)
				{
					result = netPlayer.username;
					break;
				}
				continue;
			}
			result = null;
			break;
		}
		return (string)result;
	}

	public virtual PhotonPlayer usernameToNetworkPlayer(string u)
	{
		IEnumerator enumerator = UnityRuntimeServices.GetEnumerator(netPlayers);
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

	public virtual string usernameToTeam(string u)
	{
		IEnumerator enumerator = UnityRuntimeServices.GetEnumerator(netPlayers);
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
					result = netPlayer.team;
					break;
				}
				continue;
			}
			result = null;
			break;
		}
		return (string)result;
	}

	public virtual string networkPlayerToTeam(PhotonPlayer n)
	{
		IEnumerator enumerator = UnityRuntimeServices.GetEnumerator(netPlayers);
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
				if (RuntimeServices.EqualityOperator(netPlayer.nplayer, n) && !netPlayer.isAI)
				{
					result = netPlayer.team;
					break;
				}
				continue;
			}
			result = null;
			break;
		}
		return (string)result;
	}

	public virtual int networkPlayerToIndex(PhotonPlayer n)
	{
		int num = 0;
		IEnumerator enumerator = UnityRuntimeServices.GetEnumerator(netPlayers);
		int result;
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
				if (RuntimeServices.EqualityOperator(netPlayer.nplayer, n) && !netPlayer.isAI)
				{
					result = num;
					break;
				}
				num++;
				continue;
			}
			result = 0;
			break;
		}
		return result;
	}

	public virtual int usernameToIndex(string u)
	{
		int num = 0;
		IEnumerator enumerator = UnityRuntimeServices.GetEnumerator(netPlayers);
		int result;
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
					result = num;
					break;
				}
				num++;
				continue;
			}
			result = 0;
			break;
		}
		return result;
	}

	[RPC]
	public virtual IEnumerator thisIsMyName(string n, string team, bool isAI, PhotonMessageInfo s)
	{
		return new _0024thisIsMyName_00245719(n, team, isAI, s, this).GetEnumerator();
	}

	[RPC]
	public virtual void refreshNetworkViews()
	{
		int i = 0;
		GameObject[] array = (GameObject[])UnityEngine.Object.FindObjectsOfType(typeof(GameObject));
		for (int length = array.Length; i < length; i++)
		{
			if (array[i].transform.parent == null)
			{
				if (array[i].name.Contains("CarPrefab") && array[i].GetComponent("PhotonView") != null)
				{
					StartCoroutine_Auto(refreshRecursively(array[i]));
				}
			}
			else if (array[i].transform.parent.gameObject.name.Contains("CarPrefab") && array[i].GetComponent("PhotonView") != null)
			{
				StartCoroutine_Auto(refreshRecursively(array[i]));
			}
		}
	}

	public virtual IEnumerator refreshRecursively(GameObject obj)
	{
		return new _0024refreshRecursively_00245737(obj).GetEnumerator();
	}

	public virtual IEnumerator refreshobj()
	{
		return new _0024refreshobj_00245740(this).GetEnumerator();
	}

	public virtual void returnedcloakstate(bool s)
	{
		playertrans.SendMessage("forceCloak", s);
	}

	public virtual void switchTeams()
	{
		switchteams = true;
	}

	public virtual void setevict(string i)
	{
		netPlayers.RemoveAt(usernameToIndex(i));
	}

	public virtual void Main()
	{
		netCreatedObjects = new Hashtable();
		sentPlayerList = new Hashtable();
	}
}
