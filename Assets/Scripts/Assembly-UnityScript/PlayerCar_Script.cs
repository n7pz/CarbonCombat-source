using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using Photon;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class PlayerCar_Script : Photon.MonoBehaviour
{
	[Serializable]
	internal sealed class _0024startCountdownEmpAI_00245062 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal float _0024t_00245063;

			internal PlayerCar_Script _0024self__00245064;

			public _0024(float t, PlayerCar_Script self_)
			{
				_0024t_00245063 = t;
				_0024self__00245064 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00245064.empcount = _0024t_00245063;
					goto case 2;
				case 2:
					if (_0024self__00245064.empcount > 0f)
					{
						_0024self__00245064.empcount -= Time.deltaTime;
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024self__00245064.empdisableai = false;
					_0024self__00245064.aimanager.stopFiring = false;
					_0024self__00245064.aimanager.stopMoving = false;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal float _0024t_00245065;

		internal PlayerCar_Script _0024self__00245066;

		public _0024startCountdownEmpAI_00245062(float t, PlayerCar_Script self_)
		{
			_0024t_00245065 = t;
			_0024self__00245066 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024t_00245065, _0024self__00245066);
		}
	}

	[Serializable]
	internal sealed class _0024startCountdownEmp_00245067 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal float _0024t_00245068;

			internal PlayerCar_Script _0024self__00245069;

			public _0024(float t, PlayerCar_Script self_)
			{
				_0024t_00245068 = t;
				_0024self__00245069 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00245069.empcount = _0024t_00245068;
					goto case 2;
				case 2:
					if (_0024self__00245069.empcount > 0f)
					{
						_0024self__00245069.empcount -= Time.deltaTime;
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					empdisable = false;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal float _0024t_00245070;

		internal PlayerCar_Script _0024self__00245071;

		public _0024startCountdownEmp_00245067(float t, PlayerCar_Script self_)
		{
			_0024t_00245070 = t;
			_0024self__00245071 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024t_00245070, _0024self__00245071);
		}
	}

	[Serializable]
	internal sealed class _0024stopCollisions_00245072 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal CheckIfSpaceIsClear _0024is_00245073;

			internal float _0024t_00245074;

			internal PlayerCar_Script _0024self__00245075;

			public _0024(float t, PlayerCar_Script self_)
			{
				_0024t_00245074 = t;
				_0024self__00245075 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					Physics.IgnoreLayerCollision(10, 10, true);
					result = (Yield(2, new WaitForSeconds(_0024t_00245074 + 2f)) ? 1 : 0);
					break;
				case 2:
					_0024is_00245073 = (CheckIfSpaceIsClear)_0024self__00245075.ignoreTrigger.GetComponent(typeof(CheckIfSpaceIsClear));
					goto case 3;
				case 3:
					if (!_0024is_00245073.isClear)
					{
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					Physics.IgnoreLayerCollision(10, 10, false);
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal float _0024t_00245076;

		internal PlayerCar_Script _0024self__00245077;

		public _0024stopCollisions_00245072(float t, PlayerCar_Script self_)
		{
			_0024t_00245076 = t;
			_0024self__00245077 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024t_00245076, _0024self__00245077);
		}
	}

	[Serializable]
	internal sealed class _0024SetKinematic_00245078 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal float _0024t_00245079;

			internal PlayerCar_Script _0024self__00245080;

			public _0024(float t, PlayerCar_Script self_)
			{
				_0024t_00245079 = t;
				_0024self__00245080 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (!ChatScript.isCar && (bool)_0024self__00245080.bufferedHumanObj)
					{
						if (_0024t_00245079 != 0.101f)
						{
							_0024self__00245080.bufferedHumanObj.SendMessage("safeDestroy");
						}
						else
						{
							_0024self__00245080.bufferedHumanObj.SendMessage("safeDestroyRound");
						}
					}
					if (_0024self__00245080.photonView.isMine)
					{
						_0024self__00245080.StartCoroutine_Auto(_0024self__00245080.stopCollisions(_0024t_00245079));
					}
					_0024self__00245080.bufferedHuman = false;
					_0024self__00245080.rigidbody.isKinematic = true;
					_0024self__00245080.respawning = true;
					result = (Yield(2, new WaitForSeconds(_0024t_00245079)) ? 1 : 0);
					break;
				case 2:
					_0024self__00245080.respawning = false;
					_0024self__00245080.enginesmoke.emit = false;
					GameObject.Find("HealthEffect").SendMessage("Fadeout");
					GameObject.Find("HealthEffect").SendMessage("setnfo");
					_0024self__00245080.shieldobject.SendMessage("dropShieldsRPC", SendMessageOptions.DontRequireReceiver);
					((PhotonView)_0024self__00245080.gameObject.GetComponent(typeof(PhotonView))).RPC("setclientcloak", PhotonTargets.Others);
					_0024self__00245080.boxcollider.SendMessage("cloakkill");
					_0024self__00245080.hoverscript.SendMessage("forcedisable");
					result = (YieldDefault(3) ? 1 : 0);
					break;
				case 3:
					_0024self__00245080.rigidbody.isKinematic = false;
					if (_0024self__00245080.photonView.isMine && !_0024self__00245080.aimanager.isAI)
					{
						FireGun.forceInvinc = true;
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

		internal float _0024t_00245081;

		internal PlayerCar_Script _0024self__00245082;

		public _0024SetKinematic_00245078(float t, PlayerCar_Script self_)
		{
			_0024t_00245081 = t;
			_0024self__00245082 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024t_00245081, _0024self__00245082);
		}
	}

	[Serializable]
	internal sealed class _0024sS_00245083 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal bool _0024i_00245084;

			internal PlayerCar_Script _0024self__00245085;

			public _0024(bool i, PlayerCar_Script self_)
			{
				_0024i_00245084 = i;
				_0024self__00245085 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00245085.gliderControllerScript.gliderState = _0024i_00245084;
					result = (YieldDefault(2) ? 1 : 0);
					break;
				case 2:
					if (!_0024i_00245084)
					{
						_0024self__00245085.rigidbody.angularDrag = 0.05f;
						_0024self__00245085.rigidbody.drag = _0024self__00245085.rigidbody.velocity.magnitude / (285f - (_0024self__00245085.rigidbody.mass - 926f) / 2.5f) * ((!FireGun.isboosting) ? 1f : 0.5f);
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

		internal bool _0024i_00245086;

		internal PlayerCar_Script _0024self__00245087;

		public _0024sS_00245083(bool i, PlayerCar_Script self_)
		{
			_0024i_00245086 = i;
			_0024self__00245087 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024i_00245086, _0024self__00245087);
		}
	}

	[Serializable]
	internal sealed class _0024returnedInCarTrue_00245088 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal PlayerCar_Script _0024self__00245089;

			public _0024(PlayerCar_Script self_)
			{
				_0024self__00245089 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					result = (Yield(2, new WaitForSeconds(1f)) ? 1 : 0);
					break;
				case 2:
					_0024self__00245089.bufferedHuman = true;
					_0024self__00245089.maincol.SendMessage("DisableAll");
					_0024self__00245089.rigidbody.isKinematic = true;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal PlayerCar_Script _0024self__00245090;

		public _0024returnedInCarTrue_00245088(PlayerCar_Script self_)
		{
			_0024self__00245090 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00245090);
		}
	}

	[Serializable]
	internal sealed class _0024Start_00245091 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal Renderer _0024render_00245092;

			internal Material _0024mat_00245093;

			internal UnityScript.Lang.Array _0024cArr_00245094;

			internal int _0024i_00245095;

			internal Color _0024c_00245096;

			internal UnityScript.Lang.Array _0024dC_00245097;

			internal int _0024index_00245098;

			internal int _0024_00241316_00245099;

			internal Material[] _0024_00241317_00245100;

			internal int _0024_00241318_00245101;

			internal int _0024_00241320_00245102;

			internal Renderer[] _0024_00241321_00245103;

			internal int _0024_00241322_00245104;

			internal PlayerCar_Script _0024self__00245105;

			public _0024(PlayerCar_Script self_)
			{
				_0024self__00245105 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00245105.gliderControllerScript = (GliderController)_0024self__00245105.transform.Find("Mesh/Glider").GetComponent(typeof(GliderController));
					if (!_0024self__00245105.photonView.isMine && !PhotonNetwork.isMasterClient)
					{
						((PhotonView)_0024self__00245105.gameObject.GetComponent(typeof(PhotonView))).RPC("returnInCar", PhotonTargets.MasterClient);
					}
					_0024self__00245105.aimanager = (AIManager)_0024self__00245105.gameObject.GetComponent("AIManager");
					if (!_0024self__00245105.photonView.isMine)
					{
						_0024self__00245105.otherdot.active = true;
						_0024self__00245105.mydot.active = false;
						_0024self__00245105.guncollider.layer = 10;
						_0024self__00245105.boxcollider.layer = 10;
						empdisable = false;
						controlenabled = true;
						UnityEngine.Object.Destroy(_0024self__00245105.rainno);
						UnityEngine.Object.Destroy(_0024self__00245105.rainobj);
						UnityEngine.Object.Destroy(_0024self__00245105.lensflares);
					}
					else
					{
						_0024self__00245105.gameObject.layer = 2;
						_0024self__00245105.otherdot.active = false;
						_0024self__00245105.mydot.active = true;
						_0024self__00245105.rainno.active = false;
						if (AuthGameObject.weatherindex != 2 && AuthGameObject.weatherindex != 5)
						{
							UnityEngine.Object.Destroy(_0024self__00245105.rainno);
							UnityEngine.Object.Destroy(_0024self__00245105.rainobj);
						}
						empdisable = false;
						if (ChatScript.hasoffroad)
						{
							((PhotonView)_0024self__00245105.gameObject.GetComponent(typeof(PhotonView))).RPC("sR", PhotonTargets.AllBuffered);
						}
						if (!_0024self__00245105.aimanager.isAI)
						{
							((PhotonView)_0024self__00245105.gameObject.GetComponent(typeof(PhotonView))).RPC("setVehicleType", PhotonTargets.AllBuffered, ChatScript.vehicleType);
						}
						else
						{
							((PhotonView)_0024self__00245105.gameObject.GetComponent(typeof(PhotonView))).RPC("setVehicleType", PhotonTargets.AllBuffered, 0);
						}
					}
					controlenabled = true;
					SpawningScript.spawnedCars.Add(_0024self__00245105.gameObject);
					_0024self__00245105.lastCheckedPos = _0024self__00245105.transform.position;
					if (_0024self__00245105.aimanager.isAI)
					{
						_0024self__00245105.playernameobj.name = _0024self__00245105.aimanager.ainame;
						_0024self__00245105.otherdot.active = true;
						_0024self__00245105.mydot.active = false;
						_0024self__00245105.guncollider.layer = 10;
						_0024self__00245105.boxcollider.layer = 10;
						empdisable = false;
						controlenabled = true;
						UnityEngine.Object.Destroy(_0024self__00245105.rainno);
						UnityEngine.Object.Destroy(_0024self__00245105.rainobj);
						UnityEngine.Object.Destroy(_0024self__00245105.lensflares);
					}
					if (AuthGameObject.gametype == "Freeplay" || AuthGameObject.gametype == "Deathmatch" || AuthGameObject.gametype == "Survival")
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					goto IL_0758;
				case 2:
					result = (YieldDefault(3) ? 1 : 0);
					break;
				case 3:
					_0024_00241320_00245102 = 0;
					_0024_00241321_00245103 = _0024self__00245105.mainmeshes;
					for (_0024_00241322_00245104 = _0024_00241321_00245103.Length; _0024_00241320_00245102 < _0024_00241322_00245104; _0024_00241320_00245102++)
					{
						_0024_00241316_00245099 = 0;
						_0024_00241317_00245100 = _0024_00241321_00245103[_0024_00241320_00245102].materials;
						for (_0024_00241318_00245101 = _0024_00241317_00245100.Length; _0024_00241316_00245099 < _0024_00241318_00245101; _0024_00241316_00245099++)
						{
							if (_0024_00241317_00245100[_0024_00241316_00245099].name.Contains("porsche-textured-gloss blue") || _0024_00241317_00245100[_0024_00241316_00245099].name.Contains("RedCarMaterial"))
							{
								_0024cArr_00245094 = new UnityScript.Lang.Array("_Color", "_SecondaryColor", "_RefColor", "_RefColorInverse", "_Specular");
								for (_0024i_00245095 = 0; _0024i_00245095 < _0024cArr_00245094.length; _0024i_00245095++)
								{
									Material obj = _0024_00241317_00245100[_0024_00241316_00245099];
									object obj2 = _0024cArr_00245094[_0024i_00245095];
									if (!(obj2 is string))
									{
										obj2 = RuntimeServices.Coerce(obj2, typeof(string));
									}
									_0024c_00245096 = obj.GetColor((string)obj2);
									_0024dC_00245097 = _0024self__00245105.desaturate(_0024c_00245096.r, _0024c_00245096.g, _0024c_00245096.b);
									_0024c_00245096.r = RuntimeServices.UnboxSingle(_0024dC_00245097[0]);
									_0024c_00245096.g = RuntimeServices.UnboxSingle(_0024dC_00245097[1]);
									_0024c_00245096.b = RuntimeServices.UnboxSingle(_0024dC_00245097[2]);
									Material obj3 = _0024_00241317_00245100[_0024_00241316_00245099];
									object obj4 = _0024cArr_00245094[_0024i_00245095];
									if (!(obj4 is string))
									{
										obj4 = RuntimeServices.Coerce(obj4, typeof(string));
									}
									obj3.SetColor((string)obj4, _0024c_00245096);
								}
							}
							if (_0024_00241317_00245100[_0024_00241316_00245099].name.Contains("neon"))
							{
								_0024_00241317_00245100[_0024_00241316_00245099].SetColor("_Color", _0024self__00245105.freeplayneon);
							}
							if (_0024_00241317_00245100[_0024_00241316_00245099].name.Contains("BasicCarArmor-ArmorDiffuseRed"))
							{
								_0024_00241317_00245100[_0024_00241316_00245099].SetColor("_Color", _0024self__00245105.armorcolor);
							}
							if (_0024_00241317_00245100[_0024_00241316_00245099].name.Contains("BasicCarArmor-ArmorDiffuseBlueRed"))
							{
								_0024_00241317_00245100[_0024_00241316_00245099].SetColor("_Color", _0024self__00245105.armorcolorblue);
							}
						}
					}
					goto IL_0758;
				case 4:
					result = (YieldDefault(5) ? 1 : 0);
					break;
				case 5:
					result = (YieldDefault(6) ? 1 : 0);
					break;
				case 6:
					result = (YieldDefault(7) ? 1 : 0);
					break;
				case 7:
					if (!_0024self__00245105.aimanager.isAI)
					{
						((PhotonView)_0024self__00245105.gameObject.GetComponent(typeof(PhotonView))).RPC("returnShieldState", _0024self__00245105.photonView.owner);
					}
					result = (YieldDefault(8) ? 1 : 0);
					break;
				case 8:
					result = (YieldDefault(9) ? 1 : 0);
					break;
				case 9:
					result = (YieldDefault(10) ? 1 : 0);
					break;
				case 10:
					result = (YieldDefault(11) ? 1 : 0);
					break;
				case 11:
					GameObject.Find("/GUI/QualitySettings").SendMessage("preSetAllObj");
					if (QualitySettings.GetQualityLevel() == 0)
					{
						GameObject.Find("/GUI/QualitySettings").SendMessage("setAllObjectsSimp");
					}
					goto IL_0993;
				case 12:
					result = (YieldDefault(13) ? 1 : 0);
					break;
				case 13:
					if (_0024self__00245105.aimanager.isAI)
					{
						_0024self__00245105.playernameobj.name = _0024self__00245105.aimanager.ainame;
					}
					goto case 14;
				case 14:
					if (SpawningScript.team2 == string.Empty)
					{
						result = (YieldDefault(14) ? 1 : 0);
						break;
					}
					if (AuthGameObject.isAIserver && _0024self__00245105.aimanager.isAI && PhotonNetwork.isMasterClient && !AuthGameObject.showTutorial)
					{
						if (!MasterServerScript.connectedToDed && !HeadlesssDedServer.isServerHost && UnityEngine.Random.Range(0, 2) == 1)
						{
							result = (Yield(15, new WaitForSeconds(UnityEngine.Random.Range(2, 10))) ? 1 : 0);
							break;
						}
						goto IL_0af4;
					}
					goto IL_0bb8;
				case 15:
					if (AuthGameObject.isAIserver)
					{
						GameObject.Find("/GUI/Chat").SendMessage("aiSpeaking" + _0024self__00245105.aimanager.aiteam, RuntimeServices.InvokeBinaryOperator("op_Addition", _0024self__00245105.aimanager.ainame + ": ", _0024self__00245105.welcome[UnityEngine.Random.Range(0, _0024self__00245105.welcome.length)]));
					}
					goto IL_0af4;
				case 16:
					if (AuthGameObject.isAIserver)
					{
						GameObject.Find("/GUI/Chat").SendMessage("aiSpeaking" + _0024self__00245105.aimanager.aiteam, RuntimeServices.InvokeBinaryOperator("op_Addition", _0024self__00245105.aimanager.ainame + ": ", _0024self__00245105.welcome[UnityEngine.Random.Range(0, _0024self__00245105.welcome.length)]));
					}
					goto IL_0bb8;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0758:
					if (_0024self__00245105.photonView.isMine || _0024self__00245105.aimanager.isAI)
					{
						((PhotonView)_0024self__00245105.gameObject.GetComponent(typeof(PhotonView))).RPC("shieldState", PhotonTargets.All, false);
						_0024self__00245105.audio.dopplerLevel = 0f;
						if (!_0024self__00245105.aimanager.isAI)
						{
							_0024index_00245098 = AuthGameObject.weatherindex;
							if (_0024index_00245098 != 2 && _0024index_00245098 != 5)
							{
								UnityEngine.Object.Destroy(_0024self__00245105.rainobj);
							}
							_0024self__00245105.recalculateMass();
							if ((bool)GameObject.Find("/GUI/Chat"))
							{
								GameObject.Find("/GUI/Chat").SendMessage("endOfRoundExit");
							}
						}
						else
						{
							UnityEngine.Object.Destroy(_0024self__00245105.rainobj);
						}
						GameObject.Find("/GUI/QualitySettings").SendMessage("preSetAllObj");
						if (QualitySettings.GetQualityLevel() == 0)
						{
							GameObject.Find("/GUI/QualitySettings").SendMessage("setAllObjectsSimp");
						}
						goto IL_0993;
					}
					_0024self__00245105.rigidbody.useGravity = false;
					result = (YieldDefault(4) ? 1 : 0);
					break;
					IL_0af4:
					if (MasterServerScript.connectedToDed && _0024self__00245105.photonView.isMine && UnityEngine.Random.Range(0, 2) == 1)
					{
						result = (Yield(16, new WaitForSeconds(UnityEngine.Random.Range(2, 10))) ? 1 : 0);
						break;
					}
					goto IL_0bb8;
					IL_0993:
					result = (YieldDefault(12) ? 1 : 0);
					break;
					IL_0bb8:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal PlayerCar_Script _0024self__00245106;

		public _0024Start_00245091(PlayerCar_Script self_)
		{
			_0024self__00245106 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00245106);
		}
	}

	[Serializable]
	internal sealed class _0024exitCar_00245107 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal bool _0024continueExit_00245108;

			internal Transform _0024spwnPoint_00245109;

			internal RaycastHit _0024hit_00245110;

			internal GameObject _0024hpre_00245111;

			internal IEnumerator _0024_0024iterator_0024257_00245112;

			internal Transform _0024lf_00245113;

			internal IEnumerator _0024_0024iterator_0024258_00245114;

			internal Transform _0024camLoc_00245115;

			internal float _0024_00242756_00245116;

			internal Quaternion _0024_00242757_00245117;

			internal Vector3 _0024_00242758_00245118;

			internal PlayerCar_Script _0024self__00245119;

			public _0024(PlayerCar_Script self_)
			{
				_0024self__00245119 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024continueExit_00245108 = false;
					_0024_0024iterator_0024257_00245112 = UnityRuntimeServices.GetEnumerator(_0024self__00245119.humanSpawnPointParent.transform);
					while (_0024_0024iterator_0024257_00245112.MoveNext())
					{
						object obj = _0024_0024iterator_0024257_00245112.Current;
						if (!(obj is Transform))
						{
							obj = RuntimeServices.Coerce(obj, typeof(Transform));
						}
						_0024spwnPoint_00245109 = (Transform)obj;
						if (((CheckIfSpaceIsClear)_0024spwnPoint_00245109.GetComponent(typeof(CheckIfSpaceIsClear))).isClear)
						{
							_0024hit_00245110 = default(RaycastHit);
							if (!Physics.Linecast(_0024self__00245119.transform.position, _0024spwnPoint_00245109.position, out _0024hit_00245110, _0024self__00245119.layermaskExit))
							{
								_0024hpre_00245111 = ((SpawningScript)GameObject.Find("/Spawn Point").GetComponent(typeof(SpawningScript))).customHumanInstantiate(_0024spwnPoint_00245109.position, Quaternion.identity, _0024self__00245119.teamobj.name);
								UnityRuntimeServices.Update(_0024_0024iterator_0024257_00245112, _0024spwnPoint_00245109);
								_0024self__00245119.bufferedHumanObj = _0024hpre_00245111.gameObject;
								float num = (_0024_00242756_00245116 = _0024spwnPoint_00245109.rotation.eulerAngles.y);
								Quaternion quaternion = (_0024_00242757_00245117 = _0024hpre_00245111.transform.rotation);
								Vector3 vector = (_0024_00242758_00245118 = _0024_00242757_00245117.eulerAngles);
								float num2 = (_0024_00242758_00245118.y = _0024_00242756_00245116);
								Vector3 vector2 = (_0024_00242757_00245117.eulerAngles = _0024_00242758_00245118);
								Quaternion quaternion2 = (_0024hpre_00245111.transform.rotation = _0024_00242757_00245117);
								UnityRuntimeServices.Update(_0024_0024iterator_0024257_00245112, _0024spwnPoint_00245109);
								_0024hpre_00245111.SendMessage("SetVelocity", SpawningScript.playertrans.rigidbody.velocity, SendMessageOptions.DontRequireReceiver);
								_0024continueExit_00245108 = true;
								break;
							}
						}
					}
					if (_0024continueExit_00245108)
					{
						Debug.Log("Attempting to exit the car");
						_0024self__00245119.inCar = false;
						ChatScript.isCar = false;
						CalculateHealth.jetFuel = 1f;
						_0024self__00245119.bufferedHuman = true;
						_0024_0024iterator_0024258_00245114 = UnityRuntimeServices.GetEnumerator(_0024self__00245119.transform.Find("LensFlaresBack"));
						while (_0024_0024iterator_0024258_00245114.MoveNext())
						{
							object obj2 = _0024_0024iterator_0024258_00245114.Current;
							if (!(obj2 is Transform))
							{
								obj2 = RuntimeServices.Coerce(obj2, typeof(Transform));
							}
							_0024lf_00245113 = (Transform)obj2;
							_0024lf_00245113.gameObject.layer = 9;
							UnityRuntimeServices.Update(_0024_0024iterator_0024258_00245114, _0024lf_00245113);
						}
						_0024camLoc_00245115 = _0024hpre_00245111.transform.Find("CrouchObjects/CamPoint");
						Camera.main.transform.parent = _0024camLoc_00245115.parent;
						Camera.main.transform.localPosition = _0024camLoc_00245115.localPosition;
						Camera.main.transform.localRotation = _0024camLoc_00245115.localRotation;
						GameObject.Find("/MinimapCam").SendMessage("SetTarget", _0024hpre_00245111.transform);
						_0024camLoc_00245115.Find("CamObj").parent = Camera.main.transform;
						((GunAndCameraBob)_0024hpre_00245111.GetComponent(typeof(GunAndCameraBob))).camObj = Camera.main.transform;
						((GunAndCameraBob)_0024hpre_00245111.GetComponent(typeof(GunAndCameraBob))).team = SpawningScript.team2;
						((FPSCalculateHealth)_0024hpre_00245111.GetComponent(typeof(FPSCalculateHealth))).spawnedFromCar = _0024self__00245119.gameObject;
						SpawningScript.playertrans = _0024hpre_00245111.transform;
						BotSpawner.hiveMindTarget = _0024hpre_00245111.transform;
						result = (Yield(2, new WaitForSeconds(5f)) ? 1 : 0);
						break;
					}
					GameObject.Find("/GUI/SubMessage").SendMessage("setMessage", "No empty space to exit the car!");
					goto IL_04ea;
				case 2:
					if (!HealthBar.isdead)
					{
						((PhotonView)_0024self__00245119.gameObject.GetComponent(typeof(PhotonView))).RPC("explodeNowAndDisable", PhotonTargets.All);
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					goto IL_04ea;
				case 3:
					result = (YieldDefault(4) ? 1 : 0);
					break;
				case 4:
					result = (YieldDefault(5) ? 1 : 0);
					break;
				case 5:
					_0024self__00245119.photonView.synchronization = ViewSynchronization.Off;
					goto IL_04ea;
				case 1:
					{
						result = 0;
						break;
					}
					IL_04ea:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal PlayerCar_Script _0024self__00245120;

		public _0024exitCar_00245107(PlayerCar_Script self_)
		{
			_0024self__00245120 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00245120);
		}
	}

	public WheelCollider FrontLeftWheel;

	public WheelCollider FrontRightWheel;

	public WheelCollider BackLeftWheel;

	public WheelCollider BackRightWheel;

	public float[] GearRatio;

	public int CurrentGear;

	public Light light1;

	public Light light2;

	private bool respawning;

	public ParticleEmitter flame;

	public WheelCollider wheelhit1;

	public WheelCollider wheelhit2;

	public WheelCollider wheelhit3;

	public WheelCollider wheelhit4;

	public GameObject otherdot;

	public GameObject mydot;

	public GameObject guncollider;

	public GameObject boxcollider;

	public float EngineTorque;

	public float MaxEngineRPM;

	public float MinEngineRPM;

	private float EngineRPM;

	[NonSerialized]
	public static int mph;

	[NonSerialized]
	public static int altvar;

	public GameObject playernameobj;

	public GameObject playerhealth;

	[NonSerialized]
	public static bool controlenabled = true;

	public GameObject hoverscript;

	public GameObject teamobj;

	public GameObject rainobj;

	public GameObject rainno;

	public AuthGameObject authobj;

	public WhirldIn win;

	public EndofRound endofround;

	public HoverCar hcar;

	public SpawningScript spwnsrc;

	public ChatScript cscript;

	public FireGun firegun;

	public MasterServerScript mserver;

	public PauseObject pobj;

	public CalculateHealth chealth;

	public HealthBar hbar;

	public HeadlesssDedServer headless;

	public CTFFlagSender ctf;

	public BotSpawner bspawn;

	public ConduitInputReciever cInput;

	public ParticleEmitter bubble1;

	public ParticleEmitter bubble2;

	public GameObject firepoint;

	public GameObject maincol;

	private bool controlen;

	private float brakeforce;

	public ParticleEmitter enginesmoke;

	private bool dragen;

	private float empcount;

	[NonSerialized]
	public static bool empdisable;

	private bool empdisableai;

	public GameObject gcontroller;

	public GameObject togglegun;

	public GameObject redbot;

	public GameObject bluebot;

	private float botcounter;

	public GameObject explosionprefab;

	public GameObject shieldobject;

	public GameObject lensflares;

	public Renderer[] mainmeshes;

	public Color freeplaycolor;

	public Color freeplaycolorref;

	public Color armorcolor;

	public Color armorcolorblue;

	public Color freeplayneon;

	public Color windshieldcolor;

	private float underwaterCounter;

	public Renderer[] maincarstuff;

	public Renderer[] gtrcarstuff;

	public Renderer[] racerstuff;

	public Renderer[] devstuff;

	public Transform[] origshocks;

	public Transform[] gtrshocks;

	public Transform[] racershocks;

	public Transform[] devshocks;

	public Transform[] wheelColTrans;

	public Transform[] wheelMeshTrans;

	public Transform[] racerwheelPos;

	public Transform[] devwheelPos;

	public Transform[] regshocks;

	public Renderer[] armors;

	private int armortype;

	public AIManager aimanager;

	private UnityScript.Lang.Array welcome;

	private bool altAch;

	public bool isUnderwater;

	public bool isShockResistant;

	public LayerMask layermask;

	private Vector3 lastCheckedPos;

	public GameObject humanPrefab;

	public Transform humanSpawnPointParent;

	public bool inCar;

	public LayerMask layermaskExit;

	private bool bufferedHuman;

	private PhotonViewID[] netViewArr;

	private GameObject bufferedHumanObj;

	public Collider ignoreTrigger;

	private PlayerRemote pRemote;

	private TutorialManager tMan;

	private GliderController gliderControllerScript;

	public float cOM;

	public int vehicleType;

	private bool setVehType;

	private bool hasOffroadSus;

	public Behaviour[] armorScripts;

	public GameObject specialDevastator;

	public PlayerCar_Script()
	{
		EngineTorque = 400f;
		MaxEngineRPM = 10000f;
		MinEngineRPM = 1000f;
		controlen = true;
		dragen = true;
		botcounter = 45f;
		underwaterCounter = 60f;
		welcome = new UnityScript.Lang.Array("hello", "Hi", "hai", "Hai", "hiyah", "Hiyah", "hullo", "Hullo", "ello", "'ello", "yo", "Hello", "watup", "sup", "Sup", "hey", "Hey", "howdy", "Howdy");
		inCar = true;
		cOM = -0.8f;
	}

	[RPC]
	public virtual void remoteInstantiateDelRed(Vector3 pos, Quaternion rot, int id, int objType, Hashtable ht)
	{
		((SpawningScript)GameObject.Find("/Spawn Point").GetComponent(typeof(SpawningScript))).remoteInstantiateRed(pos, rot, id, objType, ht);
	}

	[RPC]
	public virtual void remoteInstantiateDelBlue(Vector3 pos, Quaternion rot, int id, int objType, Hashtable ht)
	{
		((SpawningScript)GameObject.Find("/Spawn Point").GetComponent(typeof(SpawningScript))).remoteInstantiateBlue(pos, rot, id, objType, ht);
	}

	public virtual void LateUpdate()
	{
		RaycastHit hitInfo = default(RaycastHit);
		if (!RuntimeServices.EqualityOperator(lastCheckedPos, null) && !rigidbody.isKinematic && photonView.isMine && !aimanager.isAI && Physics.Linecast(lastCheckedPos, transform.position, out hitInfo, layermask))
		{
			transform.position = hitInfo.point - (hitInfo.point - lastCheckedPos).normalized * 1.5f;
		}
		lastCheckedPos = transform.position;
	}

	[RPC]
	public virtual void setVehicleType(int t)
	{
		if (setVehType)
		{
			return;
		}
		setVehType = true;
		Renderer renderer = null;
		int num = default(int);
		Transform transform = null;
		vehicleType = t;
		switch (t)
		{
		case 1:
		{
			for (num = 0; num < 4; num++)
			{
				regshocks[num].localPosition = racershocks[num].localPosition;
				regshocks[num].localScale = racershocks[num].localScale;
			}
			IEnumerator enumerator8 = maincarstuff.GetEnumerator();
			while (enumerator8.MoveNext())
			{
				object obj8 = enumerator8.Current;
				if (!(obj8 is Renderer))
				{
					obj8 = RuntimeServices.Coerce(obj8, typeof(Renderer));
				}
				renderer = (Renderer)obj8;
				renderer.enabled = false;
			}
			IEnumerator enumerator9 = gtrcarstuff.GetEnumerator();
			while (enumerator9.MoveNext())
			{
				object obj9 = enumerator9.Current;
				if (!(obj9 is Renderer))
				{
					obj9 = RuntimeServices.Coerce(obj9, typeof(Renderer));
				}
				renderer = (Renderer)obj9;
				renderer.enabled = false;
			}
			IEnumerator enumerator10 = racerstuff.GetEnumerator();
			while (enumerator10.MoveNext())
			{
				object obj10 = enumerator10.Current;
				if (!(obj10 is Renderer))
				{
					obj10 = RuntimeServices.Coerce(obj10, typeof(Renderer));
				}
				renderer = (Renderer)obj10;
				renderer.enabled = true;
			}
			IEnumerator enumerator11 = devstuff.GetEnumerator();
			while (enumerator11.MoveNext())
			{
				object obj11 = enumerator11.Current;
				if (!(obj11 is Renderer))
				{
					obj11 = RuntimeServices.Coerce(obj11, typeof(Renderer));
				}
				renderer = (Renderer)obj11;
				renderer.enabled = false;
			}
			for (num = 0; num < 4; num++)
			{
				wheelColTrans[num].position = racerwheelPos[num].position;
			}
			for (num = 0; num < 4; num++)
			{
				wheelMeshTrans[num].position = racerwheelPos[num].position;
			}
			((WheelAlignment_Script)wheelMeshTrans[2].GetComponent(typeof(WheelAlignment_Script))).capYPos = 0.01976352f;
			((WheelAlignment_Script)wheelMeshTrans[3].GetComponent(typeof(WheelAlignment_Script))).capYPos = 0.01976352f;
			GearRatio[0] = 1.25f;
			GearRatio[1] = 1.15f;
			GearRatio[2] = 1.15f;
			GearRatio[3] = 1.1f;
			GearRatio[4] = 1.1f;
			GearRatio[5] = 1.1f;
			cOM = -0.65f;
			break;
		}
		case 2:
		{
			for (num = 0; num < 4; num++)
			{
				regshocks[num].localPosition = gtrshocks[num].localPosition;
				regshocks[num].localScale = gtrshocks[num].localScale;
			}
			IEnumerator enumerator4 = maincarstuff.GetEnumerator();
			while (enumerator4.MoveNext())
			{
				object obj4 = enumerator4.Current;
				if (!(obj4 is Renderer))
				{
					obj4 = RuntimeServices.Coerce(obj4, typeof(Renderer));
				}
				renderer = (Renderer)obj4;
				renderer.enabled = false;
			}
			IEnumerator enumerator5 = gtrcarstuff.GetEnumerator();
			while (enumerator5.MoveNext())
			{
				object obj5 = enumerator5.Current;
				if (!(obj5 is Renderer))
				{
					obj5 = RuntimeServices.Coerce(obj5, typeof(Renderer));
				}
				renderer = (Renderer)obj5;
				renderer.enabled = true;
			}
			IEnumerator enumerator6 = racerstuff.GetEnumerator();
			while (enumerator6.MoveNext())
			{
				object obj6 = enumerator6.Current;
				if (!(obj6 is Renderer))
				{
					obj6 = RuntimeServices.Coerce(obj6, typeof(Renderer));
				}
				renderer = (Renderer)obj6;
				renderer.enabled = false;
			}
			IEnumerator enumerator7 = devstuff.GetEnumerator();
			while (enumerator7.MoveNext())
			{
				object obj7 = enumerator7.Current;
				if (!(obj7 is Renderer))
				{
					obj7 = RuntimeServices.Coerce(obj7, typeof(Renderer));
				}
				renderer = (Renderer)obj7;
				renderer.enabled = false;
			}
			GearRatio[0] = 4f;
			GearRatio[1] = 3.5f;
			GearRatio[2] = 2.5f;
			GearRatio[3] = 2f;
			GearRatio[4] = 1.5f;
			GearRatio[5] = 1f;
			cOM = -0.7f;
			break;
		}
		case 3:
		{
			for (num = 0; num < 4; num++)
			{
				regshocks[num].localPosition = devshocks[num].localPosition;
				regshocks[num].localScale = devshocks[num].localScale;
			}
			IEnumerator enumerator12 = maincarstuff.GetEnumerator();
			while (enumerator12.MoveNext())
			{
				object obj12 = enumerator12.Current;
				if (!(obj12 is Renderer))
				{
					obj12 = RuntimeServices.Coerce(obj12, typeof(Renderer));
				}
				renderer = (Renderer)obj12;
				renderer.enabled = false;
			}
			IEnumerator enumerator13 = gtrcarstuff.GetEnumerator();
			while (enumerator13.MoveNext())
			{
				object obj13 = enumerator13.Current;
				if (!(obj13 is Renderer))
				{
					obj13 = RuntimeServices.Coerce(obj13, typeof(Renderer));
				}
				renderer = (Renderer)obj13;
				renderer.enabled = false;
			}
			IEnumerator enumerator14 = racerstuff.GetEnumerator();
			while (enumerator14.MoveNext())
			{
				object obj14 = enumerator14.Current;
				if (!(obj14 is Renderer))
				{
					obj14 = RuntimeServices.Coerce(obj14, typeof(Renderer));
				}
				renderer = (Renderer)obj14;
				renderer.enabled = false;
			}
			IEnumerator enumerator15 = devstuff.GetEnumerator();
			while (enumerator15.MoveNext())
			{
				object obj15 = enumerator15.Current;
				if (!(obj15 is Renderer))
				{
					obj15 = RuntimeServices.Coerce(obj15, typeof(Renderer));
				}
				renderer = (Renderer)obj15;
				renderer.enabled = true;
			}
			for (num = 0; num < 4; num++)
			{
				wheelColTrans[num].position = devwheelPos[num].position;
			}
			for (num = 0; num < 4; num++)
			{
				wheelMeshTrans[num].position = devwheelPos[num].position;
			}
			((WheelAlignment_Script)wheelMeshTrans[2].GetComponent(typeof(WheelAlignment_Script))).capYPos = 0.08460865f;
			((WheelAlignment_Script)wheelMeshTrans[3].GetComponent(typeof(WheelAlignment_Script))).capYPos = 0.08460865f;
			GearRatio[0] = 1.25f;
			GearRatio[1] = 1.15f;
			GearRatio[2] = 1.15f;
			GearRatio[3] = 1.1f;
			GearRatio[4] = 1.1f;
			GearRatio[5] = 1.1f;
			cOM = -0.65f;
			break;
		}
		case 0:
		{
			cOM = -0.8f;
			IEnumerator enumerator = gtrcarstuff.GetEnumerator();
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				if (!(obj is Renderer))
				{
					obj = RuntimeServices.Coerce(obj, typeof(Renderer));
				}
				renderer = (Renderer)obj;
				renderer.enabled = false;
			}
			IEnumerator enumerator2 = racerstuff.GetEnumerator();
			while (enumerator2.MoveNext())
			{
				object obj2 = enumerator2.Current;
				if (!(obj2 is Renderer))
				{
					obj2 = RuntimeServices.Coerce(obj2, typeof(Renderer));
				}
				renderer = (Renderer)obj2;
				renderer.enabled = false;
			}
			IEnumerator enumerator3 = devstuff.GetEnumerator();
			while (enumerator3.MoveNext())
			{
				object obj3 = enumerator3.Current;
				if (!(obj3 is Renderer))
				{
					obj3 = RuntimeServices.Coerce(obj3, typeof(Renderer));
				}
				renderer = (Renderer)obj3;
				renderer.enabled = false;
			}
			break;
		}
		}
	}

	public virtual bool returnCloakState()
	{
		CloakPickup cloakPickup = (CloakPickup)maincol.GetComponent("CloakPickup");
		return cloakPickup.returnCloakState();
	}

	[RPC]
	public virtual void shieldState(bool t)
	{
		shieldobject.active = t;
	}

	[RPC]
	public virtual void returnShieldState(PhotonMessageInfo info)
	{
		((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("shieldState", info.sender, shieldobject.active);
	}

	public virtual void spawnRedBot(Vector3 pos, Quaternion rot, bool r, Transform thetarget)
	{
		GameObject gameObject = null;
		gameObject = PhotonNetwork.Instantiate(redbot.name, pos, rot, 0);
		gameObject.gameObject.BroadcastMessage("setTarget", thetarget.transform);
		if (r)
		{
			gameObject.SendMessage("setToRocket");
		}
	}

	public virtual void spawnBlueBot(Vector3 pos, Quaternion rot, bool r, Transform thetarget)
	{
		GameObject gameObject = null;
		gameObject = PhotonNetwork.Instantiate(bluebot.name, pos, rot, 0);
		gameObject.gameObject.BroadcastMessage("setTarget", thetarget.transform);
		if (r)
		{
			gameObject.SendMessage("setToRocket");
		}
	}

	public virtual void empDisable(float t)
	{
		if (photonView.isMine && !aimanager.isAI)
		{
			empdisable = true;
			hoverscript.SendMessage("empDisable", t);
			StartCoroutine_Auto(startCountdownEmp(t));
		}
		if (aimanager.isAI)
		{
			empdisableai = true;
			aimanager.stopFiring = true;
			aimanager.stopMoving = true;
			hoverscript.SendMessage("empDisable", t);
			StartCoroutine_Auto(startCountdownEmpAI(t));
		}
	}

	public virtual IEnumerator startCountdownEmpAI(float t)
	{
		return new _0024startCountdownEmpAI_00245062(t, this).GetEnumerator();
	}

	public virtual IEnumerator startCountdownEmp(float t)
	{
		return new _0024startCountdownEmp_00245067(t, this).GetEnumerator();
	}

	public virtual void disableDrag(bool i)
	{
		dragen = i;
	}

	public virtual void sendAMessage(string i)
	{
		string[] array = i.Split("|"[0]);
		maincol.SendMessage(array[0]);
	}

	public virtual IEnumerator stopCollisions(float t)
	{
		return new _0024stopCollisions_00245072(t, this).GetEnumerator();
	}

	public virtual IEnumerator SetKinematic(float t)
	{
		return new _0024SetKinematic_00245078(t, this).GetEnumerator();
	}

	[RPC]
	public virtual void rsS(PhotonMessageInfo info)
	{
		((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("sS", info.sender, gliderControllerScript.gliderState);
	}

	[RPC]
	public virtual IEnumerator sS(bool i)
	{
		return new _0024sS_00245083(i, this).GetEnumerator();
	}

	[RPC]
	public virtual void explodeNow()
	{
		UnityEngine.Object.Instantiate(explosionprefab, transform.position, transform.rotation);
	}

	[RPC]
	public virtual void explodeNowAndDisable()
	{
		bufferedHuman = true;
		audio.volume = 0f;
		UnityEngine.Object.Instantiate(explosionprefab, transform.position, transform.rotation);
		Collider[] array = Physics.OverlapSphere(transform.position, 30f);
		int i = 0;
		Collider[] array2 = array;
		for (int length = array2.Length; i < length; i++)
		{
			if (array2[i].transform.root != transform)
			{
				array2[i].gameObject.SendMessage("explosionHit", playernameobj.name + "|" + 75.ToString(), SendMessageOptions.DontRequireReceiver);
			}
		}
		maincol.SendMessage("DisableAll");
		rigidbody.isKinematic = true;
	}

	public virtual void setcontrol(object t)
	{
		controlenabled = RuntimeServices.UnboxBoolean(t);
		controlen = RuntimeServices.UnboxBoolean(t);
		hoverscript.SendMessage("setcontrol", t);
	}

	public virtual void disableHover()
	{
		hoverscript.SendMessage("rampdisable");
	}

	public virtual void roundsetter(bool t)
	{
		controlen = t;
		controlenabled = t;
		hoverscript.SendMessage("deactivate", t);
		firepoint.SendMessage("setcontrol", t);
		gcontroller.SendMessage("Starter", true);
		togglegun.SendMessage("roundreset");
	}

	public virtual void Awake()
	{
		pRemote = (PlayerRemote)gameObject.GetComponent(typeof(PlayerRemote));
		netViewArr = new PhotonViewID[UnityScript.Lang.Extensions.get_length((System.Array)humanPrefab.gameObject.GetComponentsInChildren(typeof(PhotonView), true))];
	}

	[RPC]
	public virtual void updateWeight(int i)
	{
		rigidbody.mass = i;
	}

	[RPC]
	public virtual IEnumerator returnedInCarTrue()
	{
		return new _0024returnedInCarTrue_00245088(this).GetEnumerator();
	}

	[RPC]
	public virtual void returnInCar(PhotonMessageInfo info)
	{
		if (bufferedHuman)
		{
			((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("returnedInCarTrue", info.sender);
		}
	}

	[RPC]
	public virtual void sR()
	{
		hasOffroadSus = true;
	}

	public virtual void recalculateMass()
	{
		int num = 800;
		if (ChatScript.hasarmor1)
		{
			num += 40;
		}
		if (ChatScript.hasarmor2)
		{
			num += 50;
		}
		if (ChatScript.hasarmor3)
		{
			num += 60;
		}
		if (ChatScript.hasarmor4)
		{
			num += 70;
		}
		if (ChatScript.hasarmor5 || ChatScript.hasarmor6)
		{
			num += 10;
		}
		if (ChatScript.hasarmor7)
		{
			num += 20;
		}
		if (ChatScript.hasarmor8)
		{
			num += 20;
		}
		if (ChatScript.hasfiber)
		{
			num -= 60;
		}
		if (ChatScript.vehicleType == 2)
		{
			num -= 116;
		}
		if (ChatScript.vehicleType == 3)
		{
			num += 50;
		}
		if (ChatScript.hasarmor8)
		{
			isShockResistant = true;
		}
		if (num != 800)
		{
			((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("updateWeight", PhotonTargets.All, num);
		}
	}

	public virtual IEnumerator Start()
	{
		return new _0024Start_00245091(this).GetEnumerator();
	}

	public virtual UnityScript.Lang.Array desaturate(object r, object g, object b)
	{
		float num = RuntimeServices.UnboxSingle(RuntimeServices.InvokeBinaryOperator("op_Addition", RuntimeServices.InvokeBinaryOperator("op_Addition", RuntimeServices.InvokeBinaryOperator("op_Multiply", 0.3f, r), RuntimeServices.InvokeBinaryOperator("op_Multiply", 0.59f, g)), RuntimeServices.InvokeBinaryOperator("op_Multiply", 0.11f, b)));
		float num2 = 1f;
		r = RuntimeServices.InvokeBinaryOperator("op_Addition", num * num2, RuntimeServices.InvokeBinaryOperator("op_Multiply", r, 1f - num2));
		g = RuntimeServices.InvokeBinaryOperator("op_Addition", num * num2, RuntimeServices.InvokeBinaryOperator("op_Multiply", g, 1f - num2));
		b = RuntimeServices.InvokeBinaryOperator("op_Addition", num * num2, RuntimeServices.InvokeBinaryOperator("op_Multiply", b, 1f - num2));
		return new UnityScript.Lang.Array(r, g, b);
	}

	[RPC]
	public virtual void enableGTRSpecial()
	{
		transform.Find("Mesh").gameObject.SetActiveRecursively(false);
		specialDevastator.renderer.enabled = true;
		specialDevastator.active = true;
	}

	[RPC]
	public virtual void createExplosion(Vector3 pos)
	{
		UnityEngine.Object.Instantiate(explosionprefab, pos, transform.rotation);
	}

	public virtual IEnumerator exitCar()
	{
		return new _0024exitCar_00245107(this).GetEnumerator();
	}

	public virtual void Update()
	{
		rigidbody.centerOfMass = new Vector3(0f, cOM, 0f);
		if (photonView.isMine && photonView.synchronization != ViewSynchronization.Unreliable && ChatScript.isCar)
		{
			photonView.synchronization = ViewSynchronization.Unreliable;
		}
		if (hasOffroadSus)
		{
			cOM = -1.6f;
			if (FrontLeftWheel.suspensionSpring.spring != 5000f)
			{
				int num = 5000;
				JointSpring suspensionSpring = FrontLeftWheel.suspensionSpring;
				float num2 = (suspensionSpring.spring = num);
				JointSpring jointSpring = (FrontLeftWheel.suspensionSpring = suspensionSpring);
				int num3 = 5000;
				JointSpring suspensionSpring2 = FrontRightWheel.suspensionSpring;
				float num4 = (suspensionSpring2.spring = num3);
				JointSpring jointSpring3 = (FrontRightWheel.suspensionSpring = suspensionSpring2);
				int num5 = 5000;
				JointSpring suspensionSpring3 = BackLeftWheel.suspensionSpring;
				float num6 = (suspensionSpring3.spring = num5);
				JointSpring jointSpring5 = (BackLeftWheel.suspensionSpring = suspensionSpring3);
				int num7 = 5000;
				JointSpring suspensionSpring4 = BackRightWheel.suspensionSpring;
				float num8 = (suspensionSpring4.spring = num7);
				JointSpring jointSpring7 = (BackRightWheel.suspensionSpring = suspensionSpring4);
			}
		}
		if (photonView.isMine && !aimanager.isAI && ChatScript.isCar)
		{
			if (Camera.main.nearClipPlane != 0.3f)
			{
				Camera.main.nearClipPlane = 0.3f;
			}
			if ((Input.GetKeyDown("g") || RuntimeServices.ToBool(ConduitInputReciever.ht["eCar"])) && inCar && !CTFFlagSender.gotflag && AuthGameObject.fpsenabled && !rigidbody.isKinematic && controlenabled && controlen && !AuthGameObject.showTutorial)
			{
				if (RuntimeServices.ToBool(ConduitInputReciever.ht["eCar"]))
				{
					ConduitInputReciever.ht["eCar"] = false;
				}
				StartCoroutine_Auto(exitCar());
			}
			GameObject[] array = GameObject.FindGameObjectsWithTag("AttackBot");
			if (UnityScript.Lang.Extensions.get_length((System.Array)array) > 0)
			{
				if (!(botcounter > 0f))
				{
					botcounter = 45f;
					UnityScript.Lang.Array array2 = new UnityScript.Lang.Array();
					int i = 0;
					GameObject[] array3 = (GameObject[])UnityEngine.Object.FindObjectsOfType(typeof(GameObject));
					for (int length = array3.Length; i < length; i++)
					{
						if (array3[i].name == "CarPrefab(Clone)")
						{
							PlayerCar_Script playerCar_Script = (PlayerCar_Script)array3[i].GetComponent("PlayerCar_Script");
							if (SpawningScript.team2 == "red" && playerCar_Script.returnTeam() == "blue")
							{
								array2.Add(array3[i]);
							}
							if (SpawningScript.team2 == "blue" && playerCar_Script.returnTeam() == "red")
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
					}
					else
					{
						int k = 0;
						GameObject[] array5 = array;
						for (int length3 = array5.Length; k < length3; k++)
						{
							((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("createExplosion", PhotonTargets.All, array5[k].transform.position);
							UnityEngine.Object.Destroy(array5[k]);
						}
					}
				}
				else
				{
					botcounter -= Time.deltaTime;
				}
			}
			if (!(EndofRound.alphastat <= 0f))
			{
				controlenabled = false;
				controlen = false;
			}
			controlenabled = controlen;
			if (AuthGameObject.weatherindex == 2 || AuthGameObject.weatherindex == 5)
			{
				if (QualitySettings.GetQualityLevel() == 5 || QualitySettings.GetQualityLevel() == 4)
				{
					if (!rainobj.active)
					{
						rainobj.active = true;
						rainno.active = false;
					}
				}
				else if (rainobj.active)
				{
					rainobj.active = false;
					rainno.active = true;
				}
			}
			altvar = (int)Mathf.Round(transform.position.y);
			mph = (int)Mathf.Round(rigidbody.velocity.magnitude * 2.2369363f / 3.3f);
			if (!((transform.position.y - 11.5f) / 2.5f < 1000f) && !altAch)
			{
				altAch = true;
				GameObject.Find("/AuthGameObject").SendMessage("gotAch", "To Infinity & Beyond");
			}
			if (mph >= 100)
			{
				GameObject.Find("/AuthGameObject").SendMessage("gotAch", "Ol' One-Hundred");
			}
			if (transform.position.y <= 7.2f || isUnderwater)
			{
				if (WhirldIn.hassea || AuthGameObject.whirldurl == string.Empty)
				{
					if (!(underwaterCounter <= 0f))
					{
						underwaterCounter -= Time.deltaTime;
					}
					else
					{
						underwaterCounter = 60f;
						GameObject.Find("/AuthGameObject").SendMessage("gotAch", "I am a Fish");
					}
					rigidbody.drag = rigidbody.velocity.magnitude / (20f * ((!ChatScript.hasaqua) ? 1f : 3.5f));
					bubble1.emit = true;
					bubble2.emit = true;
					float num9 = rigidbody.velocity.magnitude / 34f * 15f;
					float num10 = rigidbody.velocity.magnitude / 34f * 20f;
					if (!(num9 >= 2f))
					{
						num9 = 2f;
					}
					if (!(num10 >= 3f))
					{
						num10 = 3f;
					}
					bubble1.minEmission = num9;
					bubble1.maxEmission = num10;
					bubble2.minEmission = num9;
					bubble2.maxEmission = num10;
				}
				else
				{
					bubble1.emit = false;
					bubble2.emit = false;
					if (!HoverCar.maincardisdrag)
					{
						if (dragen)
						{
							rigidbody.drag = rigidbody.velocity.magnitude / (285f - (rigidbody.mass - 926f) / 2.5f) * ((!FireGun.isboosting) ? 1f : 0.5f);
						}
						else
						{
							rigidbody.drag = 0.1f;
						}
					}
				}
			}
			else
			{
				underwaterCounter = 60f;
				bubble1.emit = false;
				bubble2.emit = false;
				if (!HoverCar.maincardisdrag && (!RuntimeServices.ToBool(UnityRuntimeServices.GetProperty(gliderControllerScript, "glideState")) || BackLeftWheel.isGrounded))
				{
					if (dragen)
					{
						rigidbody.drag = rigidbody.velocity.magnitude / (285f - (rigidbody.mass - 926f) / 2.5f) * ((!FireGun.isboosting) ? 1f : 0.5f);
					}
					else
					{
						rigidbody.drag = 0.1f;
					}
				}
			}
			EngineRPM = (BackLeftWheel.rpm + BackRightWheel.rpm) / 2f * GearRatio[CurrentGear];
			ShiftGears();
			if (flame.particleCount == 0)
			{
				if (!(FrontLeftWheel.suspensionDistance >= ((!ChatScript.hasoffroad) ? 0.45f : 1.36f)))
				{
					FrontLeftWheel.suspensionDistance += 0.03f;
					FrontRightWheel.suspensionDistance += 0.03f;
					BackLeftWheel.suspensionDistance += 0.03f;
					BackRightWheel.suspensionDistance += 0.03f;
				}
				if (!(FrontLeftWheel.suspensionDistance <= ((!ChatScript.hasoffroad) ? 0.45f : 1.36f)))
				{
					FrontLeftWheel.suspensionDistance = ((!ChatScript.hasoffroad) ? 0.45f : 1.36f);
					FrontRightWheel.suspensionDistance = ((!ChatScript.hasoffroad) ? 0.45f : 1.36f);
					BackLeftWheel.suspensionDistance = ((!ChatScript.hasoffroad) ? 0.45f : 1.36f);
					BackRightWheel.suspensionDistance = ((!ChatScript.hasoffroad) ? 0.45f : 1.36f);
				}
				float num11 = 0f;
				if (!(Input.GetAxis("Vertical") <= 0f))
				{
					num11 = 0f;
				}
				if (!(Input.GetAxis("Vertical") >= 0f))
				{
					num11 = 0.25f;
				}
				num11 += ((rigidbody.mass - 800f >= 0f) ? (rigidbody.mass - 800f) : 0f) / 450f;
				if (!respawning && !empdisable && (!AuthGameObject.showTutorial || RuntimeServices.ToBool(TutorialManager.curCArr[0])))
				{
					if (controlenabled && controlen)
					{
						BackLeftWheel.motorTorque = RuntimeServices.UnboxSingle(RuntimeServices.InvokeBinaryOperator("op_Multiply", RuntimeServices.InvokeBinaryOperator("op_Multiply", RuntimeServices.InvokeBinaryOperator("op_Multiply", RuntimeServices.InvokeBinaryOperator("op_Multiply", RuntimeServices.InvokeBinaryOperator("op_Multiply", EngineTorque / GearRatio[CurrentGear], (!RuntimeServices.ToBool(RuntimeServices.InvokeBinaryOperator("op_GreaterThan", RuntimeServices.Invoke(typeof(Mathf), "Abs", new object[1] { UnityRuntimeServices.GetProperty(ConduitInputReciever.ht["dPad"], "y") }), 0))) ? ((object)Input.GetAxis("Vertical")) : RuntimeServices.InvokeBinaryOperator("op_Division", UnityRuntimeServices.GetProperty(ConduitInputReciever.ht["dPad"], "y"), 50f)), 0.642f - num11), (!FireGun.isboosting) ? 1 : 2), (ChatScript.vehicleType != 1) ? 1f : 1.35f), (ChatScript.vehicleType != 3) ? 1f : 1.15f));
						BackRightWheel.motorTorque = RuntimeServices.UnboxSingle(RuntimeServices.InvokeBinaryOperator("op_Multiply", RuntimeServices.InvokeBinaryOperator("op_Multiply", RuntimeServices.InvokeBinaryOperator("op_Multiply", RuntimeServices.InvokeBinaryOperator("op_Multiply", RuntimeServices.InvokeBinaryOperator("op_Multiply", EngineTorque / GearRatio[CurrentGear], (!RuntimeServices.ToBool(RuntimeServices.InvokeBinaryOperator("op_GreaterThan", RuntimeServices.Invoke(typeof(Mathf), "Abs", new object[1] { UnityRuntimeServices.GetProperty(ConduitInputReciever.ht["dPad"], "y") }), 0))) ? ((object)Input.GetAxis("Vertical")) : RuntimeServices.InvokeBinaryOperator("op_Division", UnityRuntimeServices.GetProperty(ConduitInputReciever.ht["dPad"], "y"), 50f)), 0.642f - num11), (!FireGun.isboosting) ? 1 : 2), (ChatScript.vehicleType != 1) ? 1f : 1.35f), (ChatScript.vehicleType != 3) ? 1f : 1.15f));
						FrontLeftWheel.steerAngle = RuntimeServices.UnboxSingle(RuntimeServices.InvokeBinaryOperator("op_Multiply", RuntimeServices.InvokeBinaryOperator("op_Multiply", RuntimeServices.InvokeBinaryOperator("op_Multiply", 9 + Mathf.Max(0, 11 * (1 - mph / 100)), (!RuntimeServices.ToBool(RuntimeServices.InvokeBinaryOperator("op_GreaterThan", RuntimeServices.Invoke(typeof(Mathf), "Abs", new object[1] { UnityRuntimeServices.GetProperty(ConduitInputReciever.ht["dPad"], "x") }), 0))) ? ((object)Input.GetAxis("Horizontal")) : RuntimeServices.InvokeBinaryOperator("op_Division", UnityRuntimeServices.GetProperty(ConduitInputReciever.ht["dPad"], "x"), 50f)), (ChatScript.vehicleType != 1) ? 1f : 1.7f), (ChatScript.vehicleType != 3) ? 1f : 0.4f));
						FrontRightWheel.steerAngle = RuntimeServices.UnboxSingle(RuntimeServices.InvokeBinaryOperator("op_Multiply", RuntimeServices.InvokeBinaryOperator("op_Multiply", RuntimeServices.InvokeBinaryOperator("op_Multiply", 9 + Mathf.Max(0, 11 * (1 - mph / 100)), (!RuntimeServices.ToBool(RuntimeServices.InvokeBinaryOperator("op_GreaterThan", RuntimeServices.Invoke(typeof(Mathf), "Abs", new object[1] { UnityRuntimeServices.GetProperty(ConduitInputReciever.ht["dPad"], "x") }), 0))) ? ((object)Input.GetAxis("Horizontal")) : RuntimeServices.InvokeBinaryOperator("op_Division", UnityRuntimeServices.GetProperty(ConduitInputReciever.ht["dPad"], "x"), 50f)), (ChatScript.vehicleType != 1) ? 1f : 1.7f), (ChatScript.vehicleType != 3) ? 1f : 0.4f));
					}
					else
					{
						BackLeftWheel.motorTorque = EngineTorque / GearRatio[CurrentGear] * 0f * (0.642f - num11);
						BackRightWheel.motorTorque = EngineTorque / GearRatio[CurrentGear] * 0f * (0.642f - num11);
						FrontLeftWheel.steerAngle = 0f;
						FrontRightWheel.steerAngle = 0f;
					}
				}
				if (empdisable || (AuthGameObject.showTutorial && !RuntimeServices.ToBool(TutorialManager.curCArr[0])))
				{
					BackLeftWheel.motorTorque = 0f;
					BackRightWheel.motorTorque = 0f;
				}
			}
			else
			{
				FrontLeftWheel.steerAngle = 0f;
				FrontRightWheel.steerAngle = 0f;
				FrontLeftWheel.suspensionDistance = 0.11f;
				FrontRightWheel.suspensionDistance = 0.11f;
				BackLeftWheel.suspensionDistance = 0.11f;
				BackRightWheel.suspensionDistance = 0.11f;
			}
			if (Input.GetAxis("Vertical") != 0f || RuntimeServices.ToBool(RuntimeServices.InvokeBinaryOperator("op_GreaterThan", UnityRuntimeServices.GetProperty(ConduitInputReciever.ht["dPad"], "y"), 5f)))
			{
				if (Input.GetAxis("Jump") != 1f && BackLeftWheel.isGrounded && BackLeftWheel.isGrounded && !RuntimeServices.ToBool(ConduitInputReciever.ht["jump"]))
				{
					audio.pitch = Mathf.Abs(EngineRPM / MaxEngineRPM) + 1f;
					audio.volume = Mathf.Abs(EngineRPM / MaxEngineRPM) * 0.3f + 0.6f;
					if (!(audio.pitch <= 1.7f))
					{
						audio.pitch = 1.7f;
					}
					if (!(audio.pitch >= 1.15f))
					{
						audio.pitch = 1.15f;
					}
				}
				else
				{
					loweraudio();
				}
			}
			else
			{
				loweraudio();
			}
			if (!(audio.volume >= 0.6f))
			{
				audio.volume = 0.6f;
			}
			if (!(audio.pitch >= 1.15f))
			{
				audio.pitch = 1.15f;
			}
			light1.enabled = false;
			light2.enabled = false;
			if (Input.GetButton("Brake") || RuntimeServices.ToBool((!(PauseObject.alt_brake != string.Empty)) ? ((object)false) : RuntimeServices.Invoke(typeof(Input), "GetKey", new object[1] { Enum.Parse(typeof(KeyCode), PauseObject.alt_brake) })))
			{
				BackLeftWheel.brakeTorque = brakeforce;
				BackRightWheel.brakeTorque = brakeforce;
				FrontLeftWheel.brakeTorque = brakeforce;
				FrontRightWheel.brakeTorque = brakeforce;
				brakeforce = Mathf.Lerp(brakeforce, 500f, 0.85f * Time.deltaTime);
				light1.enabled = true;
				light2.enabled = true;
			}
			else
			{
				brakeforce = 0f;
				BackLeftWheel.brakeTorque = brakeforce;
				BackRightWheel.brakeTorque = brakeforce;
				FrontLeftWheel.brakeTorque = brakeforce;
				FrontRightWheel.brakeTorque = brakeforce;
			}
		}
		else if (aimanager.isAI)
		{
			if (!(transform.position.y > 7.2f))
			{
				if (WhirldIn.hassea || AuthGameObject.whirldurl == string.Empty)
				{
					rigidbody.drag = rigidbody.velocity.magnitude / (20f * ((!ChatScript.hasaqua) ? 1f : 3.5f));
					bubble1.emit = true;
					bubble2.emit = true;
					float num9 = rigidbody.velocity.magnitude / 34f * 15f;
					float num10 = rigidbody.velocity.magnitude / 34f * 20f;
					if (!(num9 >= 2f))
					{
						num9 = 2f;
					}
					if (!(num10 >= 3f))
					{
						num10 = 3f;
					}
					bubble1.minEmission = num9;
					bubble1.maxEmission = num10;
					bubble2.minEmission = num9;
					bubble2.maxEmission = num10;
				}
				else
				{
					bubble1.emit = false;
					bubble2.emit = false;
					if (!HoverCar.maincardisdrag)
					{
						if (dragen)
						{
							rigidbody.drag = rigidbody.velocity.magnitude / (285f - (rigidbody.mass - 926f) / 2.5f) * ((!FireGun.isboosting) ? 1f : 0.5f);
						}
						else
						{
							rigidbody.drag = 0.1f;
						}
					}
				}
			}
			else
			{
				bubble1.emit = false;
				bubble2.emit = false;
				if (!HoverCar.maincardisdrag)
				{
					if (dragen)
					{
						rigidbody.drag = rigidbody.velocity.magnitude / (285f - (rigidbody.mass - 926f) / 2.5f) * ((!FireGun.isboosting) ? 1f : 0.5f);
					}
					else
					{
						rigidbody.drag = 0.1f;
					}
				}
			}
			if (aimanager.horizontalInput != 0f)
			{
				if (BackLeftWheel.isGrounded && BackLeftWheel.isGrounded)
				{
					audio.pitch = Mathf.Abs(EngineRPM / MaxEngineRPM) + 1f;
					audio.volume = Mathf.Abs(EngineRPM / MaxEngineRPM) * 0.3f + 0.6f;
					if (!(audio.pitch <= 1.7f))
					{
						audio.pitch = 1.7f;
					}
					if (!(audio.pitch >= 1.15f))
					{
						audio.pitch = 1.15f;
					}
				}
				else
				{
					loweraudio();
				}
			}
			else
			{
				loweraudio();
			}
			if (!(audio.volume >= 0.6f))
			{
				audio.volume = 0.6f;
			}
			if (!(audio.pitch >= 1.15f))
			{
				audio.pitch = 1.15f;
			}
			EngineRPM = (BackLeftWheel.rpm + BackRightWheel.rpm) / 2f * GearRatio[CurrentGear];
			ShiftGears();
			if (flame.particleCount == 0 && !empdisableai)
			{
				if (!(FrontLeftWheel.suspensionDistance >= 0.45f))
				{
					FrontLeftWheel.suspensionDistance += 0.03f;
					FrontRightWheel.suspensionDistance += 0.03f;
					BackLeftWheel.suspensionDistance += 0.03f;
					BackRightWheel.suspensionDistance += 0.03f;
				}
				if (!(FrontLeftWheel.suspensionDistance <= 0.45f))
				{
					FrontLeftWheel.suspensionDistance = 0.45f;
					FrontRightWheel.suspensionDistance = 0.45f;
					BackLeftWheel.suspensionDistance = 0.45f;
					BackRightWheel.suspensionDistance = 0.45f;
				}
				float num11 = 0f;
				if (Input.GetAxis("Vertical") > 0f || RuntimeServices.ToBool(RuntimeServices.InvokeBinaryOperator("op_GreaterThan", UnityRuntimeServices.GetProperty(ConduitInputReciever.ht["dPad"], "y"), 0)))
				{
					num11 = 0f;
				}
				if (Input.GetAxis("Vertical") < 0f || RuntimeServices.ToBool(RuntimeServices.InvokeBinaryOperator("op_LessThan", UnityRuntimeServices.GetProperty(ConduitInputReciever.ht["dPad"], "y"), 0)))
				{
					num11 = 0.25f;
				}
				num11 += ((rigidbody.mass - 926f >= 0f) ? (rigidbody.mass - 926f) : 0f) / 450f;
				BackLeftWheel.motorTorque = EngineTorque / GearRatio[CurrentGear] * aimanager.verticalInput * (0.642f - num11) * (float)((!FireGun.isboosting) ? 1 : 2) * ((ChatScript.vehicleType != 1) ? 1f : 1.35f);
				BackRightWheel.motorTorque = EngineTorque / GearRatio[CurrentGear] * aimanager.verticalInput * (0.642f - num11) * (float)((!FireGun.isboosting) ? 1 : 2) * ((ChatScript.vehicleType != 1) ? 1f : 1.35f);
				FrontLeftWheel.steerAngle = 11f * aimanager.horizontalInput * ((ChatScript.vehicleType != 1) ? 1f : 1.7f);
				FrontRightWheel.steerAngle = 11f * aimanager.horizontalInput * ((ChatScript.vehicleType != 1) ? 1f : 1.7f);
			}
			else
			{
				FrontLeftWheel.steerAngle = 0f;
				FrontRightWheel.steerAngle = 0f;
				FrontLeftWheel.suspensionDistance = 0.11f;
				FrontRightWheel.suspensionDistance = 0.11f;
				BackLeftWheel.suspensionDistance = 0.11f;
				BackRightWheel.suspensionDistance = 0.11f;
			}
		}
		else
		{
			BackLeftWheel.motorTorque = 0f;
			BackRightWheel.motorTorque = 0f;
		}
	}

	public virtual void loweraudio()
	{
		if (!(audio.pitch <= 0.8f))
		{
			audio.pitch -= Time.deltaTime * 60f;
		}
		if (!(audio.volume <= 0.6f))
		{
			audio.volume -= Time.deltaTime * 60f;
		}
		if (!(audio.volume >= 0.6f))
		{
			audio.volume = 0.6f;
		}
		if (!(audio.pitch >= 1.15f))
		{
			audio.pitch = 1.15f;
		}
	}

	public virtual void returnpname(GameObject t)
	{
		int num = default(int);
		if (teamobj.name == "red")
		{
			num = 0;
		}
		if (teamobj.name == "blue")
		{
			num = 1;
		}
		t.SendMessage("returnedname", ((!(playernameobj.name == "CarbonTech") && !(playernameobj.name == "nattyfrank") && !(playernameobj.name == "techietotoro") && !(playernameobj.name == "Apophis") && !(playernameobj.name == "Nattyfrank") && !(playernameobj.name == "TheGoodGuy")) ? string.Empty : "[mod] ") + playernameobj.name + " - " + playerhealth.name + "%" + ((!(pRemote.networkStatus != string.Empty)) ? string.Empty : ("\n" + pRemote.networkStatus)));
		t.SendMessage("returnedteam", num);
	}

	public virtual string returnName()
	{
		return playernameobj.name;
	}

	public virtual string returnTeam()
	{
		return teamobj.name;
	}

	public virtual void returnbadge(GameObject t)
	{
		if (SpawningScript.team2 == "red")
		{
			t.SendMessage("returnedbadge", ((!(playernameobj.name == "CarbonTech") && !(playernameobj.name == "nattyfrank") && !(playernameobj.name == "techietotoro") && !(playernameobj.name == "Apophis") && !(playernameobj.name == "Nattyfrank") && !(playernameobj.name == "TheGoodGuy")) ? string.Empty : "[mod] ") + playernameobj.name + " - " + playerhealth.name + "%" + ((!(pRemote.networkStatus != string.Empty)) ? string.Empty : ("\n" + pRemote.networkStatus)));
		}
		else if (SpawningScript.team2 == "blue")
		{
			t.SendMessage("returnedbadge", ((!(playernameobj.name == "CarbonTech") && !(playernameobj.name == "nattyfrank") && !(playernameobj.name == "techietotoro") && !(playernameobj.name == "Apophis") && !(playernameobj.name == "Nattyfrank") && !(playernameobj.name == "TheGoodGuy")) ? string.Empty : "[mod] ") + playernameobj.name + " - " + playerhealth.name + "%" + ((!(pRemote.networkStatus != string.Empty)) ? string.Empty : ("\n" + pRemote.networkStatus)));
		}
	}

	public virtual void ShiftGears()
	{
		int currentGear;
		if (!(EngineRPM < MaxEngineRPM))
		{
			currentGear = CurrentGear;
			for (int i = 0; i < UnityScript.Lang.Extensions.get_length((System.Array)GearRatio); i++)
			{
				if (!(FrontLeftWheel.rpm * GearRatio[i] >= MaxEngineRPM))
				{
					currentGear = i;
					break;
				}
			}
			CurrentGear = currentGear;
		}
		if (EngineRPM > MinEngineRPM)
		{
			return;
		}
		currentGear = CurrentGear;
		for (int num = UnityScript.Lang.Extensions.get_length((System.Array)GearRatio) - 1; num >= 0; num--)
		{
			if (!(FrontLeftWheel.rpm * GearRatio[num] <= MinEngineRPM))
			{
				currentGear = num;
				break;
			}
		}
		CurrentGear = currentGear;
	}

	[RPC]
	public virtual void setclientcloak()
	{
		gameObject.SendMessage("setcloak", false);
		boxcollider.SendMessage("cloakkill");
	}
}
