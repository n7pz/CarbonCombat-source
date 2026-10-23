using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using Photon;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class ChatScript : Photon.MonoBehaviour
{
	[Serializable]
	internal sealed class _0024changeArmor_00243443 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal float _0024timer_00243444;

			internal int _0024j_00243445;

			internal int _0024i_00243446;

			internal ChatScript _0024self__00243447;

			public _0024(int i, ChatScript self_)
			{
				_0024i_00243446 = i;
				_0024self__00243447 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024timer_00243444 = 4f;
					goto case 2;
				case 2:
					if (_0024timer_00243444 > 0f)
					{
						_0024timer_00243444 -= Time.deltaTime;
						if (!Input.GetKeyDown("3"))
						{
							result = (YieldDefault(2) ? 1 : 0);
							break;
						}
						isPickingUpTemp = false;
					}
					else
					{
						hasarmor1 = false;
						hasarmor2 = false;
						hasarmor3 = false;
						hasarmor4 = false;
						hasarmor5 = false;
						hasarmor6 = false;
						hasarmor7 = false;
						hasarmor8 = false;
						if (_0024i_00243446 == 1)
						{
							hasarmor1 = true;
						}
						if (_0024i_00243446 == 2)
						{
							hasarmor2 = true;
						}
						if (_0024i_00243446 == 3)
						{
							hasarmor3 = true;
						}
						if (_0024i_00243446 == 4)
						{
							hasarmor4 = true;
						}
						if (_0024i_00243446 == 5)
						{
							hasarmor5 = true;
						}
						for (_0024j_00243445 = 0; _0024j_00243445 < 5; _0024j_00243445++)
						{
							UnityRuntimeServices.Invoke(((PlayerCar_Script)SpawningScript.playertransCar.GetComponent(typeof(PlayerCar_Script))).armorScripts[_0024j_00243445], "Start", new object[0], typeof(UnityEngine.MonoBehaviour));
						}
						((PlayerCar_Script)SpawningScript.playertransCar.GetComponent(typeof(PlayerCar_Script))).recalculateMass();
						YieldDefault(1);
					}
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal int _0024i_00243448;

		internal ChatScript _0024self__00243449;

		public _0024changeArmor_00243443(int i, ChatScript self_)
		{
			_0024i_00243448 = i;
			_0024self__00243449 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024i_00243448, _0024self__00243449);
		}
	}

	[Serializable]
	internal sealed class _0024changeWeapons_00243450 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal float _0024timer_00243451;

			internal bool _0024grappling_00243452;

			internal string _0024s_00243453;

			internal ChatScript _0024self__00243454;

			public _0024(string s, ChatScript self_)
			{
				_0024s_00243453 = s;
				_0024self__00243454 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					isPickingUpTemp = true;
					_0024timer_00243451 = 4f;
					goto case 2;
				case 2:
					if (_0024timer_00243451 > 0f)
					{
						_0024timer_00243451 -= Time.deltaTime;
						if (Input.GetKeyDown("3"))
						{
							isPickingUpTemp = false;
							goto case 1;
						}
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					isPickingUpTemp = false;
					if (_0024s_00243453.Split("|"[0])[1] == "1")
					{
						primaryweapon = _0024s_00243453.Split("|"[0])[0];
						levels[0] = "1";
						if (AuthGameObject.gametype != "Survival")
						{
							dropWepState = 1;
						}
						if (FireGun.guntype == "rocket")
						{
							ToggleGuns.forceRefresh = true;
						}
						if (primaryweapon == "rocket")
						{
							FireGun.rocketammoleft = 6f;
						}
						if (primaryweapon == "launcher")
						{
							FireGun.rocketammoleft = 3f;
						}
						if (primaryweapon == "emplauncher")
						{
							FireGun.rocketammoleft = 3f;
						}
						if (primaryweapon == "flamethrower")
						{
							FireGun.rocketammoleft = 500f;
						}
						if (primaryweapon == "minigun")
						{
							FireGun.rocketammoleft = 150f;
						}
						if (primaryweapon == "laser")
						{
							FireGun.rocketammoleft = 25f;
						}
						if (primaryweapon == "missile")
						{
							FireGun.rocketammoleft = 4f;
						}
						if (primaryweapon == "railgun")
						{
							FireGun.rocketammoleft = 1f;
						}
						if (primaryweapon == "grappling")
						{
							FireGun.rocketammoleft = 1f;
							_0024grappling_00243452 = false;
						}
						if (primaryweapon == "lasercannon")
						{
							FireGun.rocketammoleft = 1f;
						}
						if (primaryweapon == "shotgun")
						{
							FireGun.rocketammoleft = 12f;
						}
					}
					else
					{
						secondaryweapon = _0024s_00243453.Split("|"[0])[0];
						levels[1] = "1";
						if (AuthGameObject.gametype != "Survival")
						{
							dropWepState = 2;
						}
						if (FireGun.guntype == "laser")
						{
							ToggleGuns.forceRefresh = true;
						}
						if (secondaryweapon == "rocket")
						{
							FireGun.laserammoleft = 6f;
						}
						if (secondaryweapon == "launcher")
						{
							FireGun.laserammoleft = 3f;
						}
						if (secondaryweapon == "emplauncher")
						{
							FireGun.laserammoleft = 3f;
						}
						if (secondaryweapon == "flamethrower")
						{
							FireGun.laserammoleft = 500f;
						}
						if (secondaryweapon == "minigun")
						{
							FireGun.laserammoleft = 150f;
						}
						if (secondaryweapon == "laser")
						{
							FireGun.laserammoleft = 25f;
						}
						if (secondaryweapon == "missile")
						{
							FireGun.laserammoleft = 4f;
						}
						if (secondaryweapon == "railgun")
						{
							FireGun.laserammoleft = 1f;
						}
						if (secondaryweapon == "grappling")
						{
							FireGun.laserammoleft = 1f;
							_0024grappling_00243452 = false;
						}
						if (secondaryweapon == "lasercannon")
						{
							FireGun.laserammoleft = 1f;
						}
						if (secondaryweapon == "shotgun")
						{
							FireGun.laserammoleft = 12f;
						}
					}
					if (AuthGameObject.gametype != "Survival")
					{
						waitTime = 45f;
						goto case 3;
					}
					goto IL_0952;
				case 3:
					if (!(waitTime <= 0f) && EndofRound.alphastat == 0f && !HealthBar.isdead)
					{
						waitTime -= Time.deltaTime;
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					GameObject.Find("/GUI/SubMessage").SendMessage("setMessage4", "Unequipping picked-up weapon...");
					dropWepState = 0;
					if (FireGun.guntype == "rocket" && _0024s_00243453.Split("|"[0])[1] == "1")
					{
						FireGun.stopfiring = true;
					}
					if (FireGun.guntype == "laser" && _0024s_00243453.Split("|"[0])[1] == "2")
					{
						FireGun.stopfiring = true;
					}
					result = (YieldDefault(4) ? 1 : 0);
					break;
				case 4:
					if (_0024s_00243453.Split("|"[0])[1] == "1")
					{
						primaryweapon = _0024self__00243454.origwep1;
						levels[0] = _0024self__00243454.origlev1;
					}
					else
					{
						secondaryweapon = _0024self__00243454.origwep2;
						levels[1] = _0024self__00243454.origlev2;
					}
					if (FireGun.guntype == "rocket" && _0024s_00243453.Split("|"[0])[1] == "1")
					{
						ToggleGuns.forceRefresh = true;
					}
					if (_0024s_00243453.Split("|"[0])[1] == "1")
					{
						if (primaryweapon == "rocket")
						{
							FireGun.rocketammoleft = 6f;
						}
						if (primaryweapon == "launcher")
						{
							FireGun.rocketammoleft = 3f;
						}
						if (primaryweapon == "emplauncher")
						{
							FireGun.rocketammoleft = 3f;
						}
						if (primaryweapon == "flamethrower")
						{
							FireGun.rocketammoleft = 500f;
						}
						if (primaryweapon == "minigun")
						{
							FireGun.rocketammoleft = 150f;
						}
						if (primaryweapon == "laser")
						{
							FireGun.rocketammoleft = 25f;
						}
						if (primaryweapon == "missile")
						{
							FireGun.rocketammoleft = 4f;
						}
						if (primaryweapon == "railgun")
						{
							FireGun.rocketammoleft = 1f;
						}
						if (primaryweapon == "grappling")
						{
							FireGun.rocketammoleft = 1f;
							_0024grappling_00243452 = false;
						}
						if (primaryweapon == "lasercannon")
						{
							FireGun.rocketammoleft = 1f;
						}
						if (primaryweapon == "shotgun")
						{
							FireGun.rocketammoleft = 12f;
						}
					}
					if (FireGun.guntype == "laser" && _0024s_00243453.Split("|"[0])[1] == "2")
					{
						ToggleGuns.forceRefresh = true;
					}
					if (_0024s_00243453.Split("|"[0])[1] == "2")
					{
						if (secondaryweapon == "rocket")
						{
							FireGun.laserammoleft = 6f;
						}
						if (secondaryweapon == "launcher")
						{
							FireGun.laserammoleft = 3f;
						}
						if (secondaryweapon == "emplauncher")
						{
							FireGun.laserammoleft = 3f;
						}
						if (secondaryweapon == "flamethrower")
						{
							FireGun.laserammoleft = 500f;
						}
						if (secondaryweapon == "minigun")
						{
							FireGun.laserammoleft = 150f;
						}
						if (secondaryweapon == "laser")
						{
							FireGun.laserammoleft = 25f;
						}
						if (secondaryweapon == "missile")
						{
							FireGun.laserammoleft = 4f;
						}
						if (secondaryweapon == "railgun")
						{
							FireGun.laserammoleft = 1f;
						}
						if (secondaryweapon == "grappling")
						{
							FireGun.laserammoleft = 1f;
							_0024grappling_00243452 = false;
						}
						if (secondaryweapon == "lasercannon")
						{
							FireGun.laserammoleft = 1f;
						}
						if (secondaryweapon == "shotgun")
						{
							FireGun.laserammoleft = 12f;
						}
					}
					goto IL_0952;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0952:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal string _0024s_00243455;

		internal ChatScript _0024self__00243456;

		public _0024changeWeapons_00243450(string s, ChatScript self_)
		{
			_0024s_00243455 = s;
			_0024self__00243456 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024s_00243455, _0024self__00243456);
		}
	}

	[Serializable]
	internal sealed class _0024collapse_00243457 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal ChatScript _0024self__00243458;

			public _0024(ChatScript self_)
			{
				_0024self__00243458 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (!_0024self__00243458.isanimating)
					{
						_0024self__00243458.isanimating = true;
						_0024self__00243458.chatfield = "(Press enter to chat)";
						_0024self__00243458.spawnpoint.gameObject.SendMessage("chatsetcontrol", true);
						chatting = false;
						_0024self__00243458.showbutton = true;
						goto case 2;
					}
					goto IL_00e2;
				case 2:
					if (_0024self__00243458.mainheight > 30f)
					{
						_0024self__00243458.mainheight = Mathf.Lerp(_0024self__00243458.mainheight, 0f, Time.deltaTime * 5f);
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024self__00243458.forceunfocuschat = true;
					chatting = false;
					minimized = true;
					_0024self__00243458.isanimating = false;
					goto IL_00e2;
				case 1:
					{
						result = 0;
						break;
					}
					IL_00e2:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal ChatScript _0024self__00243459;

		public _0024collapse_00243457(ChatScript self_)
		{
			_0024self__00243459 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00243459);
		}
	}

	[Serializable]
	internal sealed class _0024expand_00243460 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal ChatScript _0024self__00243461;

			public _0024(ChatScript self_)
			{
				_0024self__00243461 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00243461.forcefocuschat = true;
					if (!_0024self__00243461.isanimating)
					{
						_0024self__00243461.isanimating = true;
						if (minimized)
						{
							minimized = false;
							_0024self__00243461.showbutton = false;
							goto case 2;
						}
						goto IL_00ab;
					}
					goto IL_00b7;
				case 2:
					if (_0024self__00243461.mainheight < 345.9f)
					{
						_0024self__00243461.mainheight = Mathf.Lerp(_0024self__00243461.mainheight, 346f, Time.deltaTime * 5f);
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					goto IL_00ab;
				case 1:
					{
						result = 0;
						break;
					}
					IL_00ab:
					_0024self__00243461.isanimating = false;
					goto IL_00b7;
					IL_00b7:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal ChatScript _0024self__00243462;

		public _0024expand_00243460(ChatScript self_)
		{
			_0024self__00243462 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00243462);
		}
	}

	[Serializable]
	internal sealed class _0024slidehide_00243463 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal ChatScript _0024self__00243464;

			public _0024(ChatScript self_)
			{
				_0024self__00243464 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (!(_0024self__00243464.xval <= -299.9f) && hide)
					{
						_0024self__00243464.xval = Mathf.Lerp(_0024self__00243464.xval, -300f, Time.deltaTime);
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

		internal ChatScript _0024self__00243465;

		public _0024slidehide_00243463(ChatScript self_)
		{
			_0024self__00243465 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00243465);
		}
	}

	[Serializable]
	internal sealed class _0024unhide_00243466 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal ChatScript _0024self__00243467;

			public _0024(ChatScript self_)
			{
				_0024self__00243467 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (!(_0024self__00243467.xval >= -0.1f) && !hide)
					{
						_0024self__00243467.xval = Mathf.Lerp(_0024self__00243467.xval, 0f, Time.deltaTime);
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

		internal ChatScript _0024self__00243468;

		public _0024unhide_00243466(ChatScript self_)
		{
			_0024self__00243468 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00243468);
		}
	}

	[Serializable]
	internal sealed class _0024unhideAndExpand_00243469 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal bool _0024once_00243470;

			internal ChatScript _0024self__00243471;

			public _0024(ChatScript self_)
			{
				_0024self__00243471 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (!(_0024self__00243471.xval >= -0.1f))
					{
						_0024once_00243470 = false;
						goto case 2;
					}
					_0024self__00243471.StartCoroutine_Auto(_0024self__00243471.showChatForce());
					goto IL_00d6;
				case 2:
					if (_0024self__00243471.xval < -0.1f)
					{
						_0024self__00243471.xval = Mathf.Lerp(_0024self__00243471.xval, 0f, Time.deltaTime * 7f);
						if (!(_0024self__00243471.xval <= -2f) && !_0024once_00243470)
						{
							_0024once_00243470 = true;
							_0024self__00243471.StartCoroutine_Auto(_0024self__00243471.showChatForce());
						}
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					goto IL_00d6;
				case 1:
					{
						result = 0;
						break;
					}
					IL_00d6:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal ChatScript _0024self__00243472;

		public _0024unhideAndExpand_00243469(ChatScript self_)
		{
			_0024self__00243472 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00243472);
		}
	}

	[Serializable]
	internal sealed class _0024showChatForce_00243473 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal ChatScript _0024self__00243474;

			public _0024(ChatScript self_)
			{
				_0024self__00243474 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00243474.showbutton = false;
					_0024self__00243474.forcefocuschat = true;
					goto case 2;
				case 2:
					if (_0024self__00243474.mainheight < 345.9f)
					{
						_0024self__00243474.mainheight = Mathf.Lerp(_0024self__00243474.mainheight, 346f, Time.deltaTime * 5f);
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

		internal ChatScript _0024self__00243475;

		public _0024showChatForce_00243473(ChatScript self_)
		{
			_0024self__00243475 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00243475);
		}
	}

	[Serializable]
	internal sealed class _0024endOfRoundExit_00243476 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal string _0024tempchat_00243477;

			internal ChatScript _0024self__00243478;

			public _0024(ChatScript self_)
			{
				_0024self__00243478 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					result = (Yield(2, new WaitForSeconds(0.2f)) ? 1 : 0);
					break;
				case 2:
					_0024tempchat_00243477 = _0024self__00243478.chatfield.Replace(" ", string.Empty);
					if (_0024tempchat_00243477 == string.Empty || _0024tempchat_00243477 == "(Pressentertochat)")
					{
						_0024self__00243478.resetchat = true;
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

		internal ChatScript _0024self__00243479;

		public _0024endOfRoundExit_00243476(ChatScript self_)
		{
			_0024self__00243479 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00243479);
		}
	}

	[Serializable]
	internal sealed class _0024scrollchange_00243480 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal ChatScript _0024self__00243481;

			public _0024(ChatScript self_)
			{
				_0024self__00243481 = self_;
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
					_0024self__00243481.scrollpos.y = 1000000f;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal ChatScript _0024self__00243482;

		public _0024scrollchange_00243480(ChatScript self_)
		{
			_0024self__00243482 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00243482);
		}
	}

	[Serializable]
	internal sealed class _0024privatemessage_00243483 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string _0024username_00243484;

			internal string _0024user_00243485;

			internal string _0024input_00243486;

			internal int _0024t_00243487;

			internal ChatScript _0024self__00243488;

			public _0024(string user, string input, int t, ChatScript self_)
			{
				_0024user_00243485 = user;
				_0024input_00243486 = input;
				_0024t_00243487 = t;
				_0024self__00243488 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024username_00243484 = AuthGameObject.username;
					if (_0024username_00243484 == _0024user_00243485)
					{
						if (_0024input_00243486.Split(":"[0])[0] == "CarbonTech" || _0024input_00243486.Split(":"[0])[0] == "nattyfrank" || _0024input_00243486.Split(":"[0])[0] == "techietotoro" || _0024input_00243486.Split(":"[0])[0] == "Apophis" || _0024input_00243486.Split(":"[0])[0] == "Nattyfrank" || _0024input_00243486.Split(":"[0])[0] == "TheGoodGuy")
						{
							_0024input_00243486 = "[mod] " + _0024input_00243486;
						}
						_0024self__00243488.chatlist.Add("(private) " + _0024input_00243486);
						if (_0024t_00243487 == 1)
						{
							_0024self__00243488.secchatlist.Add("0");
						}
						else
						{
							_0024self__00243488.secchatlist.Add("3");
						}
						_0024self__00243488.unread++;
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					goto IL_0203;
				case 2:
					_0024self__00243488.scrollpos.y = 1000000f;
					goto IL_0203;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0203:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal string _0024user_00243489;

		internal string _0024input_00243490;

		internal int _0024t_00243491;

		internal ChatScript _0024self__00243492;

		public _0024privatemessage_00243483(string user, string input, int t, ChatScript self_)
		{
			_0024user_00243489 = user;
			_0024input_00243490 = input;
			_0024t_00243491 = t;
			_0024self__00243492 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024user_00243489, _0024input_00243490, _0024t_00243491, _0024self__00243492);
		}
	}

	[Serializable]
	internal sealed class _0024teammessage_00243493 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string _0024input_00243494;

			internal int _0024t_00243495;

			internal ChatScript _0024self__00243496;

			public _0024(string input, int t, ChatScript self_)
			{
				_0024input_00243494 = input;
				_0024t_00243495 = t;
				_0024self__00243496 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024input_00243494.Split(":"[0])[0] == "CarbonTech" || _0024input_00243494.Split(":"[0])[0] == "nattyfrank" || _0024input_00243494.Split(":"[0])[0] == "techietotoro" || _0024input_00243494.Split(":"[0])[0] == "Apophis" || _0024input_00243494.Split(":"[0])[0] == "Nattyfrank" || _0024input_00243494.Split(":"[0])[0] == "TheGoodGuy")
					{
						_0024input_00243494 = "[mod] " + _0024input_00243494;
					}
					if (_0024t_00243495 == 0 && _0024self__00243496.team == "red")
					{
						_0024self__00243496.secchatlist.Add("3");
						_0024self__00243496.chatlist.Add(_0024input_00243494);
					}
					if (_0024t_00243495 == 1 && _0024self__00243496.team == "blue")
					{
						_0024self__00243496.secchatlist.Add("0");
						_0024self__00243496.chatlist.Add(_0024input_00243494);
					}
					_0024self__00243496.unread++;
					result = (YieldDefault(2) ? 1 : 0);
					break;
				case 2:
					_0024self__00243496.scrollpos.y = 1000000f;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal string _0024input_00243497;

		internal int _0024t_00243498;

		internal ChatScript _0024self__00243499;

		public _0024teammessage_00243493(string input, int t, ChatScript self_)
		{
			_0024input_00243497 = input;
			_0024t_00243498 = t;
			_0024self__00243499 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024input_00243497, _0024t_00243498, _0024self__00243499);
		}
	}

	[Serializable]
	internal sealed class _0024checknameBan_00243500 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal string _0024username_00243501;

			internal string _0024message_00243502;

			internal string _0024n_00243503;

			internal ChatScript _0024self__00243504;

			public _0024(string n, ChatScript self_)
			{
				_0024n_00243503 = n;
				_0024self__00243504 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					result = (Yield(2, new WaitForSeconds(0.25f)) ? 1 : 0);
					break;
				case 2:
					_0024username_00243501 = AuthGameObject.username;
					if (_0024username_00243501 == _0024n_00243503)
					{
						AuthGameObject.wasevicted = true;
						_0024message_00243502 = AuthGameObject.username + " was banned from the server.";
						_0024self__00243504.gameObject.SendMessage("OutsideSystem", _0024message_00243502);
						((PhotonView)_0024self__00243504.gameObject.GetComponent(typeof(PhotonView))).RPC("bannedCallback", PhotonTargets.Others, AuthGameObject.username);
						FadeSceneTransition.isfadingout = true;
						PhotonNetwork.RemoveRPCs(PhotonNetwork.player);
						PhotonNetwork.DestroyPlayerObjects(PhotonNetwork.player);
						_0024self__00243504.mainCamNoParent();
						PhotonNetwork.LeaveRoom();
						Application.LoadLevel("Menu");
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

		internal string _0024n_00243505;

		internal ChatScript _0024self__00243506;

		public _0024checknameBan_00243500(string n, ChatScript self_)
		{
			_0024n_00243505 = n;
			_0024self__00243506 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024n_00243505, _0024self__00243506);
		}
	}

	[Serializable]
	internal sealed class _0024checkname_00243507 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal string _0024username_00243508;

			internal string _0024message_00243509;

			internal string _0024n_00243510;

			internal ChatScript _0024self__00243511;

			public _0024(string n, ChatScript self_)
			{
				_0024n_00243510 = n;
				_0024self__00243511 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					result = (Yield(2, new WaitForSeconds(0.25f)) ? 1 : 0);
					break;
				case 2:
					_0024username_00243508 = AuthGameObject.username;
					if (_0024username_00243508 == _0024n_00243510)
					{
						AuthGameObject.wasevicted = true;
						_0024message_00243509 = AuthGameObject.username + " was evicted from the server.";
						_0024self__00243511.gameObject.SendMessage("OutsideSystem", _0024message_00243509);
						FadeSceneTransition.isfadingout = true;
						PhotonNetwork.RemoveRPCs(PhotonNetwork.player);
						PhotonNetwork.DestroyPlayerObjects(PhotonNetwork.player);
						_0024self__00243511.mainCamNoParent();
						PhotonNetwork.LeaveRoom();
						Application.LoadLevel("Menu");
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

		internal string _0024n_00243512;

		internal ChatScript _0024self__00243513;

		public _0024checkname_00243507(string n, ChatScript self_)
		{
			_0024n_00243512 = n;
			_0024self__00243513 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024n_00243512, _0024self__00243513);
		}
	}

	[Serializable]
	internal sealed class _0024sendchat_00243514 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string _0024input_00243515;

			internal int _0024t_00243516;

			internal ChatScript _0024self__00243517;

			public _0024(string input, int t, ChatScript self_)
			{
				_0024input_00243515 = input;
				_0024t_00243516 = t;
				_0024self__00243517 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024input_00243515.Split(":"[0])[0] == "CarbonTech" || _0024input_00243515.Split(":"[0])[0] == "nattyfrank" || _0024input_00243515.Split(":"[0])[0] == "techietotoro" || _0024input_00243515.Split(":"[0])[0] == "Apophis" || _0024input_00243515.Split(":"[0])[0] == "Nattyfrank" || _0024input_00243515.Split(":"[0])[0] == "TheGoodGuy")
					{
						_0024input_00243515 = "[mod] " + _0024input_00243515;
					}
					_0024self__00243517.chatlist.Add(_0024input_00243515);
					if (_0024t_00243516 == 1)
					{
						_0024self__00243517.secchatlist.Add("0");
					}
					else
					{
						_0024self__00243517.secchatlist.Add("3");
					}
					_0024self__00243517.unread++;
					result = (YieldDefault(2) ? 1 : 0);
					break;
				case 2:
					_0024self__00243517.scrollpos.y = 1000000f;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal string _0024input_00243518;

		internal int _0024t_00243519;

		internal ChatScript _0024self__00243520;

		public _0024sendchat_00243514(string input, int t, ChatScript self_)
		{
			_0024input_00243518 = input;
			_0024t_00243519 = t;
			_0024self__00243520 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024input_00243518, _0024t_00243519, _0024self__00243520);
		}
	}

	[Serializable]
	internal sealed class _0024sendsystem_00243521 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string _0024input_00243522;

			internal ChatScript _0024self__00243523;

			public _0024(string input, ChatScript self_)
			{
				_0024input_00243522 = input;
				_0024self__00243523 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00243523.chatlist.Add(_0024input_00243522);
					_0024self__00243523.secchatlist.Add("2");
					_0024self__00243523.unread++;
					result = (YieldDefault(2) ? 1 : 0);
					break;
				case 2:
					_0024self__00243523.scrollpos.y = 1000000f;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal string _0024input_00243524;

		internal ChatScript _0024self__00243525;

		public _0024sendsystem_00243521(string input, ChatScript self_)
		{
			_0024input_00243524 = input;
			_0024self__00243525 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024input_00243524, _0024self__00243525);
		}
	}

	public UnityScript.Lang.Array chatlist;

	public UnityScript.Lang.Array secchatlist;

	public bool relist;

	public string chatfield;

	public Transform spawnpoint;

	public GUIStyle chatskin;

	public GUIStyle chattext;

	public GUIStyle mytext;

	public GUIStyle systext;

	public GUIStyle redother;

	public GUIStyle colbutton;

	public UnityScript.Lang.Array swearlist;

	public AuthGameObject authgameobject;

	public RefreshMasterServer refreshobj;

	public FadeSceneTransition fadestrans;

	public SpawningScript spwnsrc;

	public MasterServerScript mscript;

	public EndofRound endofround;

	public FireGun fgun;

	public ToggleGuns toggun;

	public HealthBar hbar;

	public CalculateHealth chealth;

	public string username;

	public int listcount;

	private string team;

	private Vector2 scrollpos;

	private int unread;

	[NonSerialized]
	public static int unreadstat;

	[NonSerialized]
	public static bool chatting;

	private int mainwidth;

	public float mainheight;

	private int fieldwidth;

	public GUIStyle minbutton;

	[NonSerialized]
	public static bool minimized;

	private bool showbutton;

	[NonSerialized]
	public static float pubheight;

	[NonSerialized]
	public static float pubalpha;

	public float xval;

	[NonSerialized]
	public static bool hide;

	public GameObject bspawner;

	private UnityScript.Lang.Array botarray;

	private bool isMuted;

	[NonSerialized]
	public static bool flylock;

	[NonSerialized]
	public static bool hasarmor1;

	[NonSerialized]
	public static bool hasarmor2;

	[NonSerialized]
	public static bool hasarmor3;

	[NonSerialized]
	public static bool hasarmor4;

	[NonSerialized]
	public static bool hasarmor5;

	[NonSerialized]
	public static bool hasarmor6;

	[NonSerialized]
	public static bool hasarmor7;

	[NonSerialized]
	public static bool hasarmor8;

	[NonSerialized]
	public static bool hasgold;

	[NonSerialized]
	public static bool hasplatinum;

	[NonSerialized]
	public static bool hasfiber;

	[NonSerialized]
	public static bool hascrystal;

	[NonSerialized]
	public static bool hascamo;

	[NonSerialized]
	public static bool hasrust;

	[NonSerialized]
	public static bool hasneon;

	[NonSerialized]
	public static bool hasaqua;

	[NonSerialized]
	public static bool hasmelee;

	[NonSerialized]
	public static bool hasghost;

	[NonSerialized]
	public static bool hasshield;

	[NonSerialized]
	public static bool hasboost;

	[NonSerialized]
	public static bool hasinvinc;

	[NonSerialized]
	public static bool hasrainbow;

	[NonSerialized]
	public static bool hasrapidfire;

	[NonSerialized]
	public static bool hasoffroad;

	[NonSerialized]
	public static bool hasglider;

	[NonSerialized]
	public static bool hasgrib;

	[NonSerialized]
	public static bool hasrrib;

	[NonSerialized]
	public static string primaryweapon = "rocket";

	[NonSerialized]
	public static string secondaryweapon = "laser";

	[NonSerialized]
	public static string[] levels = new string[4];

	private bool disablebotsonce;

	private bool forcefocuschat;

	private bool forceunfocuschat;

	private bool isanimating;

	private bool resetchat;

	[NonSerialized]
	public static int vehicleType;

	[NonSerialized]
	public static bool hasgtrcar;

	[NonSerialized]
	public static int dropWepState;

	[NonSerialized]
	public static float waitTime = 30f;

	[NonSerialized]
	public static bool isPickingUpTemp;

	public GameObject skydome;

	private int sentRate;

	public AudioController acon;

	private string origwep1;

	private string origlev1;

	private string origwep2;

	private string origlev2;

	[NonSerialized]
	public static float alpha;

	private bool firstRoundKill;

	public GUISkin scrollstyle;

	[NonSerialized]
	public static bool debugMissiles;

	[NonSerialized]
	public static bool nicehud;

	[NonSerialized]
	public static bool isCar = true;

	[NonSerialized]
	public static bool isDisconnecting;

	private Color shadowColor;

	public ChatScript()
	{
		chatlist = new UnityScript.Lang.Array();
		secchatlist = new UnityScript.Lang.Array();
		chatfield = "(Press enter to chat)";
		swearlist = new UnityScript.Lang.Array("fuck", "bitch", "bastard", "vagina", "penis", "pen1s", "vgina", "vg1na", "testicle", "test1cle", "masturbate", "cunt", "blowjob", "bl0wj0b", "bl0wjob", "faggot", "fgg0t", "fagg0t", "lesbian", "lesb1an", "hore", "whore", "cock", "c0ck", "xxx", "porn", "p0rn", "nigger", "n1gger", "vag1na", "bastard", "bstard", "bstrd", "nigger", "n1gger", "n1gg3r", "bastard", "b@stard", "b@st@rd", "asshole");
		username = string.Empty;
		listcount = -1;
		mainwidth = 266;
		mainheight = 346f;
		fieldwidth = 240;
		botarray = new UnityScript.Lang.Array();
		disablebotsonce = true;
		origwep1 = string.Empty;
		origlev1 = string.Empty;
		origwep2 = string.Empty;
		origlev2 = string.Empty;
		shadowColor = new Color(0.1f, 0.1f, 0.1f, 1f);
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
	public virtual void gotKill(bool b, string user, PhotonMessageInfo info)
	{
		if (user == AuthGameObject.username && !firstRoundKill && b && AuthGameObject.shop)
		{
			GameObject.Find("/AuthGameObject").SendMessage("displayAlert", "Round Bonus: First kill of the round (+25 credits)");
			CalculateHealth.goldearned = (UnityBuiltins.parseInt(returnGold(CalculateHealth.goldearned)) + 25).ToString();
			CalculateHealth.goldearned = returnGoldEncrypted(CalculateHealth.goldearned);
		}
		firstRoundKill = b;
	}

	public virtual void gotTop()
	{
		GameObject.Find("/AuthGameObject").SendMessage("displayAlert", "Round Bonus: Top player " + ((!(AuthGameObject.gametype == "Deathmatch") && !(AuthGameObject.gametype == "Freeplay") && !(AuthGameObject.gametype == "Survival")) ? "on team" : "in server") + " (+30 credits)");
		CalculateHealth.goldearned = (UnityBuiltins.parseInt(returnGold(CalculateHealth.goldearned)) + 30).ToString();
		CalculateHealth.goldearned = returnGoldEncrypted(CalculateHealth.goldearned);
	}

	public virtual IEnumerator changeArmor(int i)
	{
		return new _0024changeArmor_00243443(i, this).GetEnumerator();
	}

	public virtual IEnumerator changeWeapons(string s)
	{
		return new _0024changeWeapons_00243450(s, this).GetEnumerator();
	}

	[RPC]
	public virtual void toggleDebug(bool t)
	{
		debugMissiles = t;
	}

	[RPC]
	public virtual void netDebug(string s)
	{
		Debug.Log(s);
	}

	public virtual void Awake()
	{
		Input.eatKeyPressOnTextFieldFocus = false;
		isDisconnecting = false;
		PhotonNetwork.playerName = PhotonNetwork.playerName.Replace("*", string.Empty);
		PhotonNetwork.playerName += "*";
		username = AuthGameObject.username;
		debugMissiles = false;
		nicehud = false;
		isCar = true;
		isPickingUpTemp = false;
		alpha = 0f;
		hide = false;
		minimized = false;
		unreadstat = 0;
		dropWepState = 0;
		chatlist.Add("Tip: You can hide this entire sidebar by clicking the \"x\" button at the upper left.");
		secchatlist.Add("2");
		relist = true;
		StartCoroutine_Auto(scrollchange());
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		hasarmor1 = false;
		hasarmor2 = false;
		hasarmor3 = false;
		hasarmor4 = false;
		hasarmor5 = false;
		hasarmor6 = false;
		hasarmor7 = false;
		hasarmor8 = false;
		hasgold = false;
		hasplatinum = false;
		hasfiber = false;
		hascrystal = false;
		hascamo = false;
		hasrust = false;
		hasneon = false;
		hasaqua = false;
		hasmelee = false;
		hasghost = false;
		hasgrib = false;
		hasrrib = false;
		hasrainbow = false;
		hasrapidfire = false;
		hasoffroad = false;
		hasglider = false;
		hasshield = false;
		hasboost = false;
		hasgtrcar = false;
		hasinvinc = false;
		vehicleType = 0;
		primaryweapon = "rocket";
		secondaryweapon = "laser";
		levels[0] = "1";
		levels[1] = "1";
		levels[2] = "1";
		levels[3] = "1";
		if (AuthGameObject.inventory[2].Split("#"[0])[6] == "50")
		{
			vehicleType = 1;
		}
		if (AuthGameObject.inventory[2].Split("#"[0])[6] == "37")
		{
			vehicleType = 2;
		}
		if (AuthGameObject.inventory[2].Split("#"[0])[6] == "52")
		{
			vehicleType = 3;
		}
		if (AuthGameObject.inventory[2].Split("#"[0])[4] == "25")
		{
			hasshield = true;
		}
		if (AuthGameObject.inventory[2].Split("#"[0])[4] == "36")
		{
			hasboost = true;
		}
		if (AuthGameObject.inventory[2].Split("#"[0])[4] == "40")
		{
			hasinvinc = true;
		}
		if (AuthGameObject.shop && AuthGameObject.gametype != "Survival")
		{
			if (AuthGameObject.inventory[2].Split("#"[0])[1] == "4")
			{
				primaryweapon = "launcher";
			}
			if (AuthGameObject.inventory[2].Split("#"[0])[1] == "5")
			{
				primaryweapon = "flamethrower";
			}
			if (AuthGameObject.inventory[2].Split("#"[0])[1] == "6")
			{
				primaryweapon = "minigun";
			}
			if (AuthGameObject.inventory[2].Split("#"[0])[1] == "7")
			{
				primaryweapon = "laser";
			}
			if (AuthGameObject.inventory[2].Split("#"[0])[1] == "18")
			{
				primaryweapon = "missile";
			}
			if (AuthGameObject.inventory[2].Split("#"[0])[1] == "30")
			{
				primaryweapon = "emplauncher";
			}
			if (AuthGameObject.inventory[2].Split("#"[0])[1] == "31")
			{
				primaryweapon = "railgun";
			}
			if (AuthGameObject.inventory[2].Split("#"[0])[1] == "33")
			{
				primaryweapon = "lasercannon";
			}
			if (AuthGameObject.inventory[2].Split("#"[0])[1] == "35")
			{
				primaryweapon = "grappling";
			}
			if (AuthGameObject.inventory[2].Split("#"[0])[1] == "51")
			{
				primaryweapon = "shotgun";
			}
			if (AuthGameObject.inventory[2].Split("#"[0])[2] == "3")
			{
				secondaryweapon = "rocket";
			}
			if (AuthGameObject.inventory[2].Split("#"[0])[2] == "4")
			{
				secondaryweapon = "launcher";
			}
			if (AuthGameObject.inventory[2].Split("#"[0])[2] == "5")
			{
				secondaryweapon = "flamethrower";
			}
			if (AuthGameObject.inventory[2].Split("#"[0])[2] == "6")
			{
				secondaryweapon = "minigun";
			}
			if (AuthGameObject.inventory[2].Split("#"[0])[2] == "18")
			{
				secondaryweapon = "missile";
			}
			if (AuthGameObject.inventory[2].Split("#"[0])[2] == "30")
			{
				secondaryweapon = "emplauncher";
			}
			if (AuthGameObject.inventory[2].Split("#"[0])[2] == "31")
			{
				secondaryweapon = "railgun";
			}
			if (AuthGameObject.inventory[2].Split("#"[0])[2] == "33")
			{
				secondaryweapon = "lasercannon";
			}
			if (AuthGameObject.inventory[2].Split("#"[0])[2] == "35")
			{
				secondaryweapon = "grappling";
			}
			if (AuthGameObject.inventory[2].Split("#"[0])[2] == "51")
			{
				secondaryweapon = "shotgun";
			}
			if (AuthGameObject.inventory[2].Split("#"[0])[3].Split("-"[0])[0] == "14")
			{
				hasarmor1 = true;
			}
			if (AuthGameObject.inventory[2].Split("#"[0])[3].Split("-"[0])[0] == "15")
			{
				hasarmor2 = true;
			}
			if (AuthGameObject.inventory[2].Split("#"[0])[3].Split("-"[0])[0] == "16")
			{
				hasarmor3 = true;
			}
			if (AuthGameObject.inventory[2].Split("#"[0])[3].Split("-"[0])[0] == "17")
			{
				hasarmor4 = true;
			}
			if (AuthGameObject.inventory[2].Split("#"[0])[3].Split("-"[0])[0] == "27")
			{
				hasarmor5 = true;
			}
			if (AuthGameObject.inventory[2].Split("#"[0])[3].Split("-"[0])[0] == "28")
			{
				hasarmor6 = true;
			}
			if (AuthGameObject.inventory[2].Split("#"[0])[3].Split("-"[0])[0] == "39")
			{
				hasarmor7 = true;
			}
			if (AuthGameObject.inventory[2].Split("#"[0])[3].Split("-"[0])[0] == "41")
			{
				hasarmor8 = true;
			}
			if (AuthGameObject.inventory[2].Split("#"[0])[3].Split("-"[0])[1] == "19")
			{
				hasgold = true;
			}
			if (AuthGameObject.inventory[2].Split("#"[0])[3].Split("-"[0])[1] == "20")
			{
				hasplatinum = true;
			}
			if (AuthGameObject.inventory[2].Split("#"[0])[3].Split("-"[0])[1] == "21")
			{
				hasfiber = true;
			}
			if (AuthGameObject.inventory[2].Split("#"[0])[3].Split("-"[0])[1] == "22")
			{
				hascrystal = true;
			}
			if (AuthGameObject.inventory[2].Split("#"[0])[3].Split("-"[0])[1] == "23")
			{
				hascamo = true;
			}
			if (AuthGameObject.inventory[2].Split("#"[0])[3].Split("-"[0])[1] == "24")
			{
				hasrust = true;
			}
			if (AuthGameObject.inventory[2].Split("#"[0])[3].Split("-"[0])[1] == "32")
			{
				hasneon = true;
			}
			if (AuthGameObject.inventory[2].Split("#"[0])[3].Split("-"[0])[1] == "34")
			{
				hasaqua = true;
			}
			if (AuthGameObject.inventory[2].Split("#"[0])[3].Split("-"[0])[1] == "26")
			{
				hasmelee = true;
			}
			if (AuthGameObject.inventory[2].Split("#"[0])[3].Split("-"[0])[1] == "38")
			{
				hasghost = true;
			}
			if (AuthGameObject.inventory[2].Split("#"[0])[3].Split("-"[0])[1] == "42")
			{
				hasgrib = true;
			}
			if (AuthGameObject.inventory[2].Split("#"[0])[3].Split("-"[0])[1] == "43")
			{
				hasrrib = true;
			}
			if (AuthGameObject.inventory[2].Split("#"[0])[3].Split("-"[0])[1] == "44")
			{
				hasrainbow = true;
			}
			if (AuthGameObject.inventory[2].Split("#"[0])[3].Split("-"[0])[1] == "46")
			{
				hasrapidfire = true;
			}
			if (AuthGameObject.inventory[2].Split("#"[0])[3].Split("-"[0])[1] == "47")
			{
				hasoffroad = true;
			}
			if (AuthGameObject.inventory[2].Split("#"[0])[3].Split("-"[0])[1] == "48")
			{
				hasglider = true;
			}
			for (int i = 1; i < 5; i++)
			{
				string text = AuthGameObject.inventory[2].Split("#"[0])[i];
				if (AuthGameObject.inventory[2].Split("#"[0])[i].Contains("-"))
				{
					text = AuthGameObject.inventory[2].Split("#"[0])[i].Split("-"[0])[0];
				}
				if (text != "false")
				{
					levels[i - 1] = AuthGameObject.inventory[UnityBuiltins.parseInt(text)];
				}
			}
		}
		origwep1 = primaryweapon;
		origlev1 = levels[0];
		origwep2 = secondaryweapon;
		origlev2 = levels[1];
	}

	public virtual void OutsideSystemNoRPC(string message)
	{
		chatlist.Add(message);
		secchatlist.Add("2");
		relist = true;
		StartCoroutine_Auto(scrollchange());
	}

	public virtual void OutsideSystem(string message)
	{
		chatlist.Add(message);
		secchatlist.Add("2");
		relist = true;
		((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("sendsystem", PhotonTargets.Others, message);
		StartCoroutine_Auto(scrollchange());
	}

	public virtual void ownteam(string t)
	{
		team = t;
	}

	public virtual IEnumerator collapse()
	{
		return new _0024collapse_00243457(this).GetEnumerator();
	}

	public virtual IEnumerator expand()
	{
		return new _0024expand_00243460(this).GetEnumerator();
	}

	public virtual IEnumerator slidehide()
	{
		return new _0024slidehide_00243463(this).GetEnumerator();
	}

	public virtual IEnumerator unhide()
	{
		return new _0024unhide_00243466(this).GetEnumerator();
	}

	public virtual IEnumerator unhideAndExpand()
	{
		return new _0024unhideAndExpand_00243469(this).GetEnumerator();
	}

	public virtual IEnumerator showChatForce()
	{
		return new _0024showChatForce_00243473(this).GetEnumerator();
	}

	public virtual void OnLeftRoom()
	{
		if (!isDisconnecting)
		{
			Debug.LogError("Got OnLeftRoom callback; bailed from server!");
			AuthGameObject.wasdc = true;
			FadeSceneTransition.isfadingout = true;
			mainCamNoParent();
			Application.LoadLevel("Menu");
		}
	}

	public virtual void OnDisconnectedFromPhoton()
	{
		if (!isDisconnecting)
		{
			Debug.LogError("Got OnDisconnectedFromPhoton callback; bailed from server!");
			AuthGameObject.wasdc = true;
			FadeSceneTransition.isfadingout = true;
			mainCamNoParent();
			Application.LoadLevel("Menu");
		}
	}

	public virtual void OnJoinedLobby()
	{
		Debug.LogError("We joine the lobby while in the game (what in the world...)");
	}

	public virtual void Update()
	{
		if (!(mainheight <= 345f))
		{
			if ((new Rect(18f, Screen.height - 100 - ((alpha <= 0.5f) ? 105 : 346), 266f, (alpha <= 0.5f) ? 105 : 346).Contains(Input.mousePosition) && Input.GetButtonDown("Fire1")) || chatting)
			{
				if (!chatting)
				{
					forcefocuschat = true;
				}
				if (!(alpha >= 1f))
				{
					alpha += 4f * Time.deltaTime;
					if (!(alpha <= 1f))
					{
						alpha = 1f;
					}
				}
				else
				{
					if (alpha != 1f)
					{
						scrollpos.y = 1000000f;
					}
					alpha = 1f;
				}
			}
			else if (!new Rect(18f, Screen.height - 100 - ((alpha <= 0.5f) ? 105 : 346), 266f, (alpha <= 0.5f) ? 105 : 346).Contains(Input.mousePosition))
			{
				if (!(alpha <= 0f))
				{
					scrollpos.y = 1000000f;
					alpha -= 4f * Time.deltaTime;
					if (!(alpha >= 0f))
					{
						alpha = 0f;
					}
				}
				else
				{
					alpha = 0f;
				}
			}
		}
		if (minimized)
		{
			if (Input.mousePosition.x > 266f || !(Input.mousePosition.y >= (float)(Screen.height - 458)))
			{
				hide = true;
				StartCoroutine_Auto(slidehide());
			}
			if (!(Input.mousePosition.x >= 35f) && !(Input.mousePosition.y <= (float)(Screen.height - 150)))
			{
				hide = false;
				StartCoroutine_Auto(unhide());
			}
		}
		else
		{
			unread = 0;
		}
		if (Input.GetKeyDown(KeyCode.Return) && minimized)
		{
			hide = false;
			minimized = false;
			StartCoroutine_Auto(unhideAndExpand());
		}
		if (RefreshMasterServer.personjoined && PhotonNetwork.isMasterClient && disablebotsonce)
		{
			disablebotsonce = false;
			bspawner.active = false;
			GameObject[] array = GameObject.FindGameObjectsWithTag("Bot");
			botarray.Clear();
			int i = 0;
			GameObject[] array2 = array;
			for (int length = array2.Length; i < length; i++)
			{
				botarray.Add(array2[i]);
				array2[i].SetActiveRecursively(false);
			}
		}
		else
		{
			disablebotsonce = true;
		}
		unreadstat = unread;
	}

	public virtual void Start()
	{
		if (PhotonNetwork.isMasterClient && AuthGameObject.isAIserver)
		{
			PhotonNetwork.sendRate = 15;
			PhotonNetwork.sendRateOnSerialize = 15;
		}
		else
		{
			PhotonNetwork.sendRate = 15;
			PhotonNetwork.sendRateOnSerialize = 15;
		}
	}

	[RPC]
	public virtual void getSendrate(PhotonMessageInfo info)
	{
		((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("adjustSendrate", info.sender, UnityBuiltins.parseInt(PhotonNetwork.sendRate));
	}

	[RPC]
	public virtual void adjustSendrate(int i)
	{
		PhotonNetwork.sendRate = i;
		PhotonNetwork.sendRateOnSerialize = i;
		sentRate = i;
	}

	public virtual void OnGUI()
	{
		GUI.skin = scrollstyle;
		if (AudioController.hideGUI || AuthGameObject.showTutorial)
		{
			return;
		}
		if (forcefocuschat)
		{
			forcefocuschat = false;
			GUI.FocusControl("ChatBox");
			spawnpoint.gameObject.SendMessage("chatsetcontrol", false);
			chatting = true;
			StartCoroutine_Auto(scrollchange());
			chatfield = string.Empty;
		}
		if (forceunfocuschat)
		{
			forceunfocuschat = false;
			GUI.FocusControl(string.Empty);
			spawnpoint.gameObject.SendMessage("chatsetcontrol", true);
			chatting = false;
			chatfield = "(Press enter to chat)";
		}
		GUI.depth = -3;
		if (listcount + 1 >= secchatlist.length)
		{
			listcount = -1;
		}
		GUI.BeginGroup(new Rect(xval, 0f, Screen.width, Screen.height));
		float num = mainheight / 345.9f / 1f;
		if (!(num <= 1f))
		{
			num = 1f;
		}
		if (!(num >= 0.1f))
		{
			num = 0f;
		}
		float a = num;
		Color color = GUI.color;
		float num2 = (color.a = a);
		Color color2 = (GUI.color = color);
		pubalpha = num;
		pubheight = mainheight;
		if (!minimized)
		{
			GUI.BeginGroup(new Rect(10f, 93f, mainwidth, mainheight));
			if (!(mainheight <= 345f))
			{
				float a2 = alpha;
				Color color4 = GUI.color;
				float num3 = (color4.a = a2);
				Color color5 = (GUI.color = color4);
			}
			GUI.SetNextControlName("NotChatBox");
			GUI.Box(new Rect(0f, 0f, mainwidth, mainheight), "Chat", chatskin);
			GUI.SetNextControlName("ChatBox");
			chatfield = GUI.TextField(new Rect(13f, 313f, fieldwidth, 20f), chatfield, 350);
			float a3 = num;
			Color color7 = GUI.color;
			float num4 = (color7.a = a3);
			Color color8 = (GUI.color = color7);
			if (chatfield == string.Empty && GUI.GetNameOfFocusedControl() != "ChatBox")
			{
				chatfield = "(Press enter to chat)";
				spawnpoint.gameObject.SendMessage("chatsetcontrol", true);
				chatting = false;
			}
			bool flag = false;
			if (Event.current.type == EventType.KeyDown && Event.current.character == '\n' && !isMuted && !AuthGameObject.isBanned)
			{
				string text = chatfield.Replace(" ", string.Empty);
				if (GUI.GetNameOfFocusedControl() != "ChatBox")
				{
					GUI.FocusControl("ChatBox");
					spawnpoint.gameObject.SendMessage("chatsetcontrol", false);
					chatting = true;
					StartCoroutine_Auto(scrollchange());
					if (text == string.Empty || chatfield == "(Press enter to chat)")
					{
						chatfield = string.Empty;
					}
					flag = true;
				}
				else if (text == string.Empty)
				{
					GUI.FocusControl(string.Empty);
					spawnpoint.gameObject.SendMessage("chatsetcontrol", true);
					chatting = false;
					chatfield = "(Press enter to chat)";
				}
				string text2 = chatfield.Replace(" ", string.Empty);
				if (text2 != string.Empty && !flag && chatfield != "(Press enter to chat)")
				{
					bool flag2 = true;
					string text3 = chatfield;
					text3 = text3.ToLower();
					text3 = text3.Replace(",", string.Empty);
					text3 = text3.Replace(".", string.Empty);
					text3 = text3.Replace("-", string.Empty);
					text3 = text3.Replace("_", string.Empty);
					text3 = text3.Replace("/", string.Empty);
					text3 = text3.Replace("\\", string.Empty);
					text3 = text3.Replace("|", string.Empty);
					text3 = text3.Replace(":", string.Empty);
					text3 = text3.Replace(">", string.Empty);
					text3 = text3.Replace("<", string.Empty);
					text3 = text3.Replace("+", string.Empty);
					text3 = text3.Replace("(", string.Empty);
					text3 = text3.Replace(")", string.Empty);
					text3 = text3.Replace(" ", string.Empty);
					text3 = text3.Replace("[", string.Empty);
					text3 = text3.Replace("]", string.Empty);
					text3 = text3.Replace("{", string.Empty);
					text3 = text3.Replace("}", string.Empty);
					text3 = text3.Replace("#", string.Empty);
					text3 = text3.Replace("*", string.Empty);
					text3 = text3.Replace("^", string.Empty);
					text3 = text3.Replace("$", string.Empty);
					text3 = text3.Replace("!", string.Empty);
					text3 = text3.Replace("@", string.Empty);
					text3 = text3.Replace("&", string.Empty);
					text3 = text3.Replace("~", string.Empty);
					text3 = text3.Replace("`", string.Empty);
					text3 = text3.Replace(";", string.Empty);
					text3 = text3.Replace("'", string.Empty);
					text3 = text3.Replace("\"", string.Empty);
					text3 = text3.Replace("?", string.Empty);
					IEnumerator enumerator = UnityRuntimeServices.GetEnumerator(swearlist);
					while (enumerator.MoveNext())
					{
						object obj = enumerator.Current;
						if (!(obj is string))
						{
							obj = RuntimeServices.Coerce(obj, typeof(string));
						}
						string value = (string)obj;
						if (text3.Contains(value))
						{
							flag2 = false;
							chatfield = string.Empty;
						}
					}
					if (flag2)
					{
						bool flag3 = false;
						if (chatfield.StartsWith("/e ") || chatfield.StartsWith("/E "))
						{
							if (AuthGameObject.username == "CarbonTech" || AuthGameObject.username == "nattyfrank" || AuthGameObject.username == "techietotoro" || AuthGameObject.username == "Apophis" || AuthGameObject.username == "Nattyfrank" || AuthGameObject.username == "TheGoodGuy")
							{
								string text4 = AuthGameObject.username;
								string text5 = chatfield.Replace("/e ", string.Empty);
								text5 = text5.Replace("/E ", string.Empty);
								if (text5 != text4)
								{
									spawnpoint.gameObject.SendMessage("setevict", text5);
									flag3 = true;
									StartCoroutine_Auto(scrollchange());
									GameObject.Find("/AuthGameObject").SendMessage("gotAch", "Server Power");
									if (text5 != MasterServerScript.ainame && text5 != MasterServerScript.ainame2 && text5 != MasterServerScript.ainame3)
									{
										((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("checkname", PhotonTargets.Others, text5);
									}
									else
									{
										OutsideSystemNoRPC("Could not evict " + text5 + "!");
									}
								}
								else
								{
									flag3 = true;
									OutsideSystem(AuthGameObject.username + " tried to evict himself.");
								}
							}
							else
							{
								flag3 = true;
								OutsideSystemNoRPC("Only moderators and administrators can evict other players.");
							}
						}
						if (chatfield.StartsWith("/b ") || chatfield.StartsWith("/B "))
						{
							if (AuthGameObject.username == "CarbonTech" || AuthGameObject.username == "nattyfrank" || AuthGameObject.username == "techietotoro" || AuthGameObject.username == "Apophis" || AuthGameObject.username == "Nattyfrank" || AuthGameObject.username == "TheGoodGuy")
							{
								string text4 = AuthGameObject.username;
								string text5 = chatfield.Replace("/b ", string.Empty);
								text5 = text5.Replace("/B ", string.Empty);
								if (text5 != text4)
								{
									spawnpoint.gameObject.SendMessage("setevict", text5);
									flag3 = true;
									StartCoroutine_Auto(scrollchange());
									if (text5 != MasterServerScript.ainame && text5 != MasterServerScript.ainame2 && text5 != MasterServerScript.ainame3)
									{
										((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("checknameBan", PhotonTargets.Others, text5);
									}
									else
									{
										OutsideSystemNoRPC("Could not ban " + text5 + "!");
									}
								}
								else
								{
									flag3 = true;
									OutsideSystem(AuthGameObject.username + " tried to ban himself.");
								}
							}
							else
							{
								flag3 = true;
								OutsideSystemNoRPC("Only moderators and administrators can ban other players.");
							}
						}
						if (chatfield.StartsWith("/m ") || chatfield.StartsWith("/M "))
						{
							if (AuthGameObject.username == "CarbonTech" || AuthGameObject.username == "nattyfrank" || AuthGameObject.username == "techietotoro" || AuthGameObject.username == "Apophis" || AuthGameObject.username == "Nattyfrank" || AuthGameObject.username == "TheGoodGuy")
							{
								string text4 = AuthGameObject.username;
								string text5 = chatfield.Replace("/m ", string.Empty);
								text5 = text5.Replace("/M ", string.Empty);
								if (text5 != text4)
								{
									flag3 = true;
									StartCoroutine_Auto(scrollchange());
									if (text5 != MasterServerScript.ainame && text5 != MasterServerScript.ainame2 && text5 != MasterServerScript.ainame3)
									{
										((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("checknameMute", PhotonTargets.Others, text5);
									}
									else
									{
										OutsideSystemNoRPC("Could not mute " + text5 + "!");
									}
								}
								else
								{
									flag3 = true;
									OutsideSystem(AuthGameObject.username + " tried to mute himself.");
								}
							}
							else
							{
								flag3 = true;
								OutsideSystemNoRPC("Only moderators and administrators can mute other players.");
							}
						}
						if (chatfield.StartsWith("/ip ") || chatfield.StartsWith("/IP "))
						{
							string text5 = chatfield.Replace("/ip ", string.Empty);
							text5 = text5.Replace("/ip ", string.Empty);
							flag3 = true;
							StartCoroutine_Auto(scrollchange());
							((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("checknameIP", PhotonTargets.All, text5);
						}
						if (chatfield.StartsWith("/gtr34"))
						{
							flag3 = true;
							StartCoroutine_Auto(scrollchange());
							OutsideSystemNoRPC("Custom Devastator mesh enabled.");
							if (AuthGameObject.username == "CarbonTech" || AuthGameObject.username == "GTR34")
							{
								((PhotonView)SpawningScript.playertransCar.gameObject.GetComponent(typeof(PhotonView))).RPC("enableGTRSpecial", PhotonTargets.AllBuffered);
							}
						}
						if (chatfield == "/gtrcar")
						{
							flag3 = true;
							OutsideSystemNoRPC("This prototype is no longer active. Go and buy it in the store! :D");
						}
						if (chatfield == "/nicehud")
						{
							flag3 = true;
							OutsideSystemNoRPC("HUD badges now use the slower system of calculating offsets based on distances.");
							nicehud = true;
						}
						if (chatfield == "/debug")
						{
							flag3 = true;
							OutsideSystemNoRPC("Debugging missile hit script; all debug messages should be networked.");
							debugMissiles = !debugMissiles;
							((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("toggleDebug", PhotonTargets.All, debugMissiles);
						}
						if (chatfield.Contains("/sendrate "))
						{
							flag3 = true;
							int num5 = UnityBuiltins.parseInt(chatfield.Replace("/sendrate ", string.Empty));
							((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("adjustSendrate", PhotonTargets.AllBuffered, num5);
							OutsideSystemNoRPC("PhotonNetwork sendrate adjusted for all clients to " + num5.ToString() + ".");
						}
						if (chatfield == "/flylock")
						{
							flag3 = true;
							if (!flylock)
							{
								flylock = true;
								OutsideSystemNoRPC("Flying is now locked on the x axis (forward rotation). I still strongly suggest that you use the new system which provides a lot more agility and allows you to change altitude without releasing space.");
							}
							else
							{
								flylock = false;
								OutsideSystemNoRPC("Flying is now unlocked on the x axis.");
							}
						}
						if (chatfield.StartsWith("/t ") || chatfield.StartsWith("/T "))
						{
							string rhs = chatfield.Replace("/t ", string.Empty);
							chatlist.Add("(team) " + username + ": " + rhs);
							secchatlist.Add("1");
							StartCoroutine_Auto(scrollchange());
							int num6 = default(int);
							flag3 = true;
							num6 = ((!(team == "red")) ? 1 : 0);
							GameObject.Find("/AuthGameObject").SendMessage("gotAch", "Team Planning");
							((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("teammessage", PhotonTargets.Others, "(team) " + username + ": " + rhs, num6);
						}
						if (chatfield.StartsWith("/framerate "))
						{
							flag3 = true;
							Application.targetFrameRate = UnityBuiltins.parseInt(chatfield.Replace("/framerate ", string.Empty));
							OutsideSystemNoRPC("Framerate is now capped at " + Application.targetFrameRate.ToString() + ".");
						}
						if (chatfield.StartsWith("/bots ") && bspawner.active)
						{
							flag3 = true;
							if (!RefreshMasterServer.personjoined)
							{
								string text6 = chatfield.Replace("/bots ", string.Empty).ToLower();
								if (UnityBuiltins.parseInt(text6) > 0)
								{
									bspawner.SendMessage("chatSpawnBots", UnityBuiltins.parseInt(text6));
									OutsideSystemNoRPC("You just activated " + text6 + " killer drones. Enjoy!");
								}
								else
								{
									OutsideSystemNoRPC("You can't spawn a negative number of drones; please try again.");
								}
							}
							else
							{
								OutsideSystemNoRPC("You can't spawn bots in multi-player mode.");
							}
						}
						if (chatfield.StartsWith("/") && chatfield.IndexOf(" ") != 2 && chatfield.IndexOf(" ") != -1 && !flag3)
						{
							string text4 = AuthGameObject.username;
							int num7 = chatfield.IndexOf(" ");
							string text7 = chatfield.Substring(1, num7 - 1);
							string rhs2 = chatfield.Substring(num7 + 1);
							if (text7 != text4)
							{
								flag3 = true;
								chatlist.Add("(private) " + username + ": " + rhs2);
								secchatlist.Add("1");
								StartCoroutine_Auto(scrollchange());
								int num6 = ((!(team == "red")) ? 1 : 0);
								((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("privatemessage", PhotonTargets.Others, text7, username + ": " + rhs2, num6);
							}
						}
						if (chatfield == "/r" || chatfield == "/R" || chatfield == "/respawn" || chatfield == "respawn")
						{
							chatfield = username + " is respawning in 5 seconds...";
							chatlist.Add(chatfield);
							secchatlist.Add("2");
							StartCoroutine_Auto(scrollchange());
							((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("sendsystem", PhotonTargets.Others, chatfield);
							float num8 = 5f;
							spawnpoint.gameObject.SendMessage("Respawn", num8);
							if ((bool)GameObject.Find("/BattlefieldBounds"))
							{
								GameObject.Find("/BattlefieldBounds").SendMessage("resetStates");
							}
						}
						else if (!flag3)
						{
							chatlist.Add(((!(username == "CarbonTech") && !(username == "nattyfrank") && !(username == "techietotoro") && !(username == "Apophis") && !(username == "Nattyfrank") && !(username == "guest_Rinna") && !(username == "TheGoodGuy"))  ? string.Empty : "[mod] ") + username + ": " + chatfield);
							secchatlist.Add("1");
							StartCoroutine_Auto(scrollchange());
							int num6 = ((!(team == "red")) ? 1 : 0);
							((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("sendchat", PhotonTargets.Others, username + ": " + chatfield, num6);
						}
						chatfield = string.Empty;
					}
				}
			}
			if (Input.GetKeyDown("mouse 0") && !Screen.showCursor)
			{
				chatfield = "(Press enter to chat)";
				GUI.FocusControl(string.Empty);
				spawnpoint.SendMessage("chatsetcontrol", true);
				chatting = false;
			}
			GUI.SetNextControlName("ChatLabel");
			GUILayout.BeginArea(new Rect(8f, 28f, 250f, 300f));
			if (!(mainheight <= 345f))
			{
				float a4 = alpha;
				Color color10 = GUI.color;
				float num9 = (color10.a = a4);
				Color color11 = (GUI.color = color10);
			}
			scrollpos = GUILayout.BeginScrollView(scrollpos, GUILayout.Width(250f), GUILayout.Height(200f * Mathf.Max(0f, alpha) + 75f));
			float a5 = num;
			Color color13 = GUI.color;
			float num10 = (color13.a = a5);
			Color color14 = (GUI.color = color13);
			IEnumerator enumerator2 = UnityRuntimeServices.GetEnumerator(chatlist);
			while (enumerator2.MoveNext())
			{
				object obj2 = enumerator2.Current;
				if (!(obj2 is string))
				{
					obj2 = RuntimeServices.Coerce(obj2, typeof(string));
				}
				string text8 = (string)obj2;
				GUILayout.BeginHorizontal();
				if (listcount + 1 < secchatlist.length)
				{
					listcount++;
				}
				if (RuntimeServices.EqualityOperator(secchatlist[listcount], "0"))
				{
					GUILayout.TextField(text8, chattext);
					UnityRuntimeServices.Update(enumerator2, text8);
				}
				else
				{
					if (RuntimeServices.EqualityOperator(secchatlist[listcount], "1"))
					{
						GUILayout.TextField(text8, mytext);
						UnityRuntimeServices.Update(enumerator2, text8);
					}
					if (RuntimeServices.EqualityOperator(secchatlist[listcount], "2"))
					{
						GUILayout.TextField(text8, systext);
						UnityRuntimeServices.Update(enumerator2, text8);
					}
					if (RuntimeServices.EqualityOperator(secchatlist[listcount], "3"))
					{
						GUILayout.TextField(text8, redother);
						UnityRuntimeServices.Update(enumerator2, text8);
					}
				}
				GUILayout.FlexibleSpace();
				GUILayout.EndHorizontal();
			}
			GUILayout.EndScrollView();
			GUILayout.EndArea();
			GUI.EndGroup();
		}
		if (!minimized && GUI.Button(new Rect(23f, 106f, 13f, 13f), string.Empty, minbutton) && !(mainheight <= 345.9f))
		{
			StartCoroutine_Auto(collapse());
		}
		float num11 = 1f - mainheight / 345.9f / 1f;
		if (!(num11 <= 1f))
		{
			num11 = 1f;
		}
		if (!(num11 >= 0.1f))
		{
			num11 = 0f;
		}
		float a6 = num11;
		Color color16 = GUI.color;
		float num12 = (color16.a = a6);
		Color color17 = (GUI.color = color16);
		if (showbutton)
		{
			string rhs3 = "s";
			if (unread == 1)
			{
				rhs3 = string.Empty;
			}
			if (GUI.Button(new Rect(20f, 100f, 246f, 30f), "Chat - (" + unread + ") Unread Message" + rhs3, colbutton))
			{
				StartCoroutine_Auto(expand());
				unread = 0;
			}
		}
		if (chatlist.length > 20)
		{
			chatlist.RemoveAt(0);
			secchatlist.RemoveAt(0);
		}
		GUI.EndGroup();
		if (resetchat)
		{
			resetchat = false;
			GUI.FocusControl(string.Empty);
			spawnpoint.gameObject.SendMessage("chatsetcontrol", true);
			chatting = false;
			chatfield = "(Press enter to chat)";
		}
		if (Event.current.keyCode == KeyCode.Tab || Event.current.character == '\t' || Input.GetKey(KeyCode.Tab))
		{
			GUI.FocusControl(string.Empty);
			if (chatting)
			{
				spawnpoint.gameObject.SendMessage("chatsetcontrol", true);
				chatting = false;
				chatfield = "(Press enter to chat)";
			}
		}
	}

	[RPC]
	public virtual void evictAll()
	{
		if (!PhotonNetwork.isMasterClient)
		{
			AuthGameObject.wasevicted = true;
			string value = AuthGameObject.username + " was evicted from the server.";
			gameObject.SendMessage("OutsideSystem", value);
			FadeSceneTransition.isfadingout = true;
			PhotonNetwork.RemoveRPCs(PhotonNetwork.player);
			PhotonNetwork.DestroyPlayerObjects(PhotonNetwork.player);
			PhotonNetwork.LeaveRoom();
		}
		else
		{
			PhotonNetwork.LeaveRoom();
		}
		Application.LoadLevel("Menu");
	}

	public virtual IEnumerator endOfRoundExit()
	{
		return new _0024endOfRoundExit_00243476(this).GetEnumerator();
	}

	public virtual IEnumerator scrollchange()
	{
		return new _0024scrollchange_00243480(this).GetEnumerator();
	}

	public virtual void botcon(string tchat)
	{
		if (tchat == "on")
		{
			IEnumerator enumerator = UnityRuntimeServices.GetEnumerator(botarray);
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				if (!(obj is GameObject))
				{
					obj = RuntimeServices.Coerce(obj, typeof(GameObject));
				}
				GameObject gameObject = (GameObject)obj;
				gameObject.SetActiveRecursively(true);
				UnityRuntimeServices.Update(enumerator, gameObject);
			}
			botarray.Clear();
			bspawner.active = true;
			bspawner.SendMessage("chatSpawnBots", -1);
			this.gameObject.SendMessage("OutsideSystem", "All killer drones re-enabled.");
		}
		if (tchat == "off")
		{
			bspawner.active = false;
			GameObject[] array = GameObject.FindGameObjectsWithTag("Bot");
			botarray.Clear();
			int i = 0;
			GameObject[] array2 = array;
			for (int length = array2.Length; i < length; i++)
			{
				botarray.Add(array2[i]);
				array2[i].SetActiveRecursively(false);
			}
			this.gameObject.SendMessage("OutsideSystem", "All killer drones disabled.");
		}
	}

	[RPC]
	public virtual IEnumerator privatemessage(string user, string input, int t)
	{
		return new _0024privatemessage_00243483(user, input, t, this).GetEnumerator();
	}

	[RPC]
	public virtual IEnumerator teammessage(string input, int t)
	{
		return new _0024teammessage_00243493(input, t, this).GetEnumerator();
	}

	[RPC]
	public virtual void bannedCallback(string user)
	{
		RefreshMasterServer.bannedList = ((!(RefreshMasterServer.bannedList == string.Empty)) ? ("," + user) : user);
	}

	[RPC]
	public virtual void returnedIP(string n)
	{
		OutsideSystemNoRPC(n);
	}

	[RPC]
	public virtual void checknameIP(string n, PhotonMessageInfo info)
	{
		if (AuthGameObject.username == n)
		{
			((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("returnedIP", info.sender, "IP for player " + AuthGameObject.username + " is: " + AuthGameObject.myIP);
		}
	}

	[RPC]
	public virtual void checknameMute(string n)
	{
		if (AuthGameObject.username == n)
		{
			OutsideSystem(AuthGameObject.username + " was muted by a moderator.");
			isMuted = !isMuted;
		}
	}

	[RPC]
	public virtual IEnumerator checknameBan(string n)
	{
		return new _0024checknameBan_00243500(n, this).GetEnumerator();
	}

	[RPC]
	public virtual IEnumerator checkname(string n)
	{
		return new _0024checkname_00243507(n, this).GetEnumerator();
	}

	public virtual void aiSpeakingred(string input)
	{
		((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("sendchat", PhotonTargets.All, input, 0);
	}

	public virtual void aiSpeakingblue(string input)
	{
		((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("sendchat", PhotonTargets.All, input, 1);
	}

	[RPC]
	public virtual IEnumerator sendchat(string input, int t)
	{
		return new _0024sendchat_00243514(input, t, this).GetEnumerator();
	}

	[RPC]
	public virtual IEnumerator sendsystem(string input)
	{
		return new _0024sendsystem_00243521(input, this).GetEnumerator();
	}

	public virtual void mainCamNoParent()
	{
		Camera.main.transform.parent = null;
	}

	public virtual void Main()
	{
	}
}
