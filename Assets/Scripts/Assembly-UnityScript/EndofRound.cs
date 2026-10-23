using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using Photon;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class EndofRound : Photon.MonoBehaviour
{
	[Serializable]
	internal sealed class _0024hbarshow_00243709 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal EndofRound _0024self__00243710;

			public _0024(EndofRound self_)
			{
				_0024self__00243710 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					HealthBar.showendofround = true;
					HealthBar.victory = false;
					HealthBar.tie = false;
					if (InGameScores.redpoints > InGameScores.bluepoints)
					{
						HealthBar.victory = SpawningScript.team2 == "red";
					}
					if (InGameScores.redpoints < InGameScores.bluepoints)
					{
						HealthBar.victory = SpawningScript.team2 == "blue";
					}
					if (InGameScores.redpoints == InGameScores.bluepoints)
					{
						HealthBar.victory = false;
						HealthBar.tie = true;
					}
					result = (Yield(2, new WaitForSeconds(3f)) ? 1 : 0);
					break;
				case 2:
					HealthBar.showendofround = false;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal EndofRound _0024self__00243711;

		public _0024hbarshow_00243709(EndofRound self_)
		{
			_0024self__00243711 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00243711);
		}
	}

	[Serializable]
	internal sealed class _0024fadein_00243712 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal NetPlayer _0024myNetPlayer_00243713;

			internal AuthGameObject _0024authObjScript_00243714;

			internal float _0024_00242039_00243715;

			internal Color _0024_00242040_00243716;

			internal float _0024_00242041_00243717;

			internal Color _0024_00242042_00243718;

			internal EndofRound _0024self__00243719;

			public _0024(EndofRound self_)
			{
				_0024self__00243719 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024myNetPlayer_00243713 = _0024self__00243719.returnLocalNetPlayer();
					_0024authObjScript_00243714 = (AuthGameObject)GameObject.Find("/AuthGameObject").GetComponent(typeof(AuthGameObject));
					if (!RuntimeServices.EqualityOperator(_0024myNetPlayer_00243713, null))
					{
						_0024authObjScript_00243714.StartCoroutine_Auto(_0024authObjScript_00243714.sendStat("avgkdr", (float)_0024myNetPlayer_00243713.kills / Mathf.Max(1f, _0024myNetPlayer_00243713.deaths), 1));
						_0024authObjScript_00243714.StartCoroutine_Auto(_0024authObjScript_00243714.sendStat("avgxp", CalculateHealth.totalXPEarned, 1));
						CalculateHealth.totalXPEarned = 0;
						_0024authObjScript_00243714.StartCoroutine_Auto(_0024authObjScript_00243714.sendStat("avgcredits", UnityBuiltins.parseInt(_0024self__00243719.returnGoldEarned()), 1));
						_0024authObjScript_00243714.StartCoroutine_Auto(_0024authObjScript_00243714.sendStat("totalkills", _0024myNetPlayer_00243713.kills, 0));
						_0024authObjScript_00243714.StartCoroutine_Auto(_0024authObjScript_00243714.sendStat("totaldeaths", _0024myNetPlayer_00243713.deaths, 0));
						_0024authObjScript_00243714.StartCoroutine_Auto(_0024authObjScript_00243714.sendStat("totalrounds", 1, 0));
						_0024authObjScript_00243714.StartCoroutine_Auto(_0024authObjScript_00243714.sendStat("mostkills", _0024myNetPlayer_00243713.kills, 2));
						_0024authObjScript_00243714.StartCoroutine_Auto(_0024authObjScript_00243714.sendStat("mostdeaths", _0024myNetPlayer_00243713.deaths, 2));
						_0024authObjScript_00243714.StartCoroutine_Auto(_0024authObjScript_00243714.sendStat("mostcredits", UnityBuiltins.parseInt(_0024self__00243719.returnGoldEarned()), 2));
						_0024authObjScript_00243714.StartCoroutine_Auto(_0024authObjScript_00243714.sendStat("mostxp", CalculateHealth.totalXPEarned, 2));
					}
					if (PreloaderExplosion.psAPI)
					{
						if (InGameScores.redpoints >= InGameScores.bluepoints && SpawningScript.team2 == "red")
						{
							PreloaderExplosion.wonGame = true;
						}
						if (InGameScores.redpoints <= InGameScores.bluepoints && SpawningScript.team2 == "blue")
						{
							PreloaderExplosion.wonGame = true;
						}
					}
					_0024self__00243719.StartCoroutine_Auto(_0024self__00243719.hbarshow());
					_0024self__00243719.effect.enabled = true;
					_0024self__00243719.sendonce = false;
					_0024self__00243719.setguiactive(true);
					if (PhotonNetwork.isMasterClient)
					{
						((PhotonView)GameObject.Find("/GUI/Chat").GetComponent(typeof(PhotonView))).RPC("gotKill", PhotonTargets.All, false, string.Empty);
					}
					_0024self__00243719.istabbing = false;
					_0024self__00243719.alphatab = 0f;
					_0024self__00243719.goldEarnedThisRound = _0024self__00243719.returnGoldEarned();
					goto case 2;
				case 2:
				{
					if (_0024self__00243719.alpha < 1f)
					{
						_0024self__00243719.alpha += 4f * Time.deltaTime;
						float num = (_0024_00242039_00243715 = _0024self__00243719.alpha * 0.55f);
						Color color = (_0024_00242040_00243716 = _0024self__00243719.effect.color);
						float num2 = (_0024_00242040_00243716.a = _0024_00242039_00243715);
						Color color2 = (_0024self__00243719.effect.color = _0024_00242040_00243716);
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024self__00243719.alpha = 1f;
					float num3 = (_0024_00242041_00243717 = 0.55f);
					Color color4 = (_0024_00242042_00243718 = _0024self__00243719.effect.color);
					float num4 = (_0024_00242042_00243718.a = _0024_00242041_00243717);
					Color color5 = (_0024self__00243719.effect.color = _0024_00242042_00243718);
					_0024self__00243719.numbofrounds++;
					if (!_0024self__00243719.sayonce)
					{
						_0024self__00243719.sayonce = true;
						if (Application.isWebPlayer && PreloaderExplosion.isKong)
						{
							_0024self__00243719.spawnobj.SendMessage("sendmessagedel", "If you're enjoying Carbon Combat please consider rating it; a higher rating equals more players!");
						}
						else
						{
							_0024self__00243719.spawnobj.SendMessage("sendmessagedel", "Access exclusive content on the official forum! http://bit.ly/CCForum");
						}
					}
					if (!AuthGameObject.username.Contains("guest_") && AuthGameObject.shop && !_0024self__00243719.goldsetter)
					{
						_0024self__00243719.goldsetter = true;
						_0024self__00243719.goldearned = UnityBuiltins.parseInt(_0024self__00243719.returnGoldEarned());
						if (_0024self__00243719.goldearned >= 350)
						{
							GameObject.Find("/AuthGameObject").SendMessage("gotAch", "Getting Rich Quick");
						}
						if (InGameScores.redpoints > InGameScores.bluepoints && SpawningScript.team2 == "red")
						{
							_0024self__00243719.StartCoroutine_Auto(_0024self__00243719.sendCredits(30));
						}
						if (InGameScores.redpoints < InGameScores.bluepoints && SpawningScript.team2 == "blue")
						{
							_0024self__00243719.StartCoroutine_Auto(_0024self__00243719.sendCredits(30));
						}
					}
					CalculateHealth.goldearned = "a";
					CalculateHealth.bonus = 1f;
					YieldDefault(1);
					goto case 1;
				}
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal EndofRound _0024self__00243720;

		public _0024fadein_00243712(EndofRound self_)
		{
			_0024self__00243720 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00243720);
		}
	}

	[Serializable]
	internal sealed class _0024sendInCredits_00243721 : GenericGenerator<WWW>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WWW>, IEnumerator
		{
			internal int _0024goldearned_00243722;

			internal int _0024credcap_00243723;

			internal WWW _0024getKey_00243724;

			internal string _0024escaped_00243725;

			internal WWW _0024bitem_00243726;

			internal EndofRound _0024self__00243727;

			public _0024(EndofRound self_)
			{
				_0024self__00243727 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (!AuthGameObject.username.Contains("guest_") && AuthGameObject.shop)
					{
						_0024goldearned_00243722 = UnityBuiltins.parseInt(_0024self__00243727.returnGoldEarned());
						_0024credcap_00243723 = UnityEngine.Random.Range(700, 800);
						if (_0024goldearned_00243722 > _0024credcap_00243723)
						{
							_0024goldearned_00243722 = _0024credcap_00243723;
						}
						if (_0024goldearned_00243722 > 0)
						{
							AuthGameObject.inventory[2] = (UnityBuiltins.parseInt(_0024self__00243727.returnGold()) + _0024goldearned_00243722).ToString() + "#" + AuthGameObject.inventory[2].Split("#"[0])[1] + "#" + AuthGameObject.inventory[2].Split("#"[0])[2] + "#" + AuthGameObject.inventory[2].Split("#"[0])[3] + "#" + AuthGameObject.inventory[2].Split("#"[0])[4] + "#" + LoginWindow.curday + "#" + AuthGameObject.inventory[2].Split("#"[0])[6];
							AuthGameObject.inventory[2] = _0024self__00243727.returnGoldEncrypted() + "#" + AuthGameObject.inventory[2].Split("#"[0])[1] + "#" + AuthGameObject.inventory[2].Split("#"[0])[2] + "#" + AuthGameObject.inventory[2].Split("#"[0])[3] + "#" + AuthGameObject.inventory[2].Split("#"[0])[4] + "#" + LoginWindow.curday + "#" + AuthGameObject.inventory[2].Split("#"[0])[6];
							_0024getKey_00243724 = new WWW(_0024self__00243727.keyGen + "username=" + Md5Sum.ComputeMd5(AuthGameObject.username + global::DontDestroyOnLoad.hitcollider));
							result = (Yield(2, _0024getKey_00243724) ? 1 : 0);
							break;
						}
					}
					goto IL_072c;
				case 2:
					_0024escaped_00243725 = WWW.EscapeURL("#" + AuthGameObject.inventory[2].Split("#"[0])[1] + "#" + AuthGameObject.inventory[2].Split("#"[0])[2] + "#" + AuthGameObject.inventory[2].Split("#"[0])[3] + "#" + AuthGameObject.inventory[2].Split("#"[0])[4] + "#" + LoginWindow.curday);
					_0024bitem_00243726 = new WWW(_0024self__00243727.storeInterface + "username=" + AuthGameObject.username + "&request=changevalue" + "&serverkey=" + Md5Sum.ComputeMd5(_0024getKey_00243724.text + global::DontDestroyOnLoad.hitcollider) + "&field=tokens&changeto=" + (UnityBuiltins.parseInt(_0024self__00243727.returnGold()) + 0).ToString() + _0024escaped_00243725);
					result = (Yield(3, _0024bitem_00243726) ? 1 : 0);
					break;
				case 3:
					if (string.IsNullOrEmpty(_0024bitem_00243726.error) && _0024bitem_00243726.text.Contains("updated"))
					{
						GameObject.Find("/GUI/Chat").SendMessage("OutsideSystemNoRPC", _0024goldearned_00243722.ToString() + " credits were automatically added to your account.");
						goto IL_072c;
					}
					_0024getKey_00243724 = new WWW(_0024self__00243727.keyGen + "username=" + Md5Sum.ComputeMd5(AuthGameObject.username + global::DontDestroyOnLoad.hitcollider));
					result = (Yield(4, _0024getKey_00243724) ? 1 : 0);
					break;
				case 4:
					_0024escaped_00243725 = WWW.EscapeURL("#" + AuthGameObject.inventory[2].Split("#"[0])[1] + "#" + AuthGameObject.inventory[2].Split("#"[0])[2] + "#" + AuthGameObject.inventory[2].Split("#"[0])[3] + "#" + AuthGameObject.inventory[2].Split("#"[0])[4] + "#" + LoginWindow.curday);
					_0024bitem_00243726 = new WWW(_0024self__00243727.storeInterface + "username=" + AuthGameObject.username + "&request=changevalue" + "&serverkey=" + Md5Sum.ComputeMd5(_0024getKey_00243724.text + global::DontDestroyOnLoad.hitcollider) + "&field=tokens&changeto=" + (UnityBuiltins.parseInt(_0024self__00243727.returnGold()) + 0).ToString() + _0024escaped_00243725);
					result = (Yield(5, _0024bitem_00243726) ? 1 : 0);
					break;
				case 5:
					if (string.IsNullOrEmpty(_0024bitem_00243726.error) && _0024bitem_00243726.text.Contains("updated"))
					{
						GameObject.Find("/GUI/Chat").SendMessage("OutsideSystemNoRPC", _0024goldearned_00243722.ToString() + " credits were automatically added to your account.");
					}
					goto IL_072c;
				case 1:
					{
						result = 0;
						break;
					}
					IL_072c:
					CalculateHealth.goldearned = "a";
					CalculateHealth.bonus = 1f;
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal EndofRound _0024self__00243728;

		public _0024sendInCredits_00243721(EndofRound self_)
		{
			_0024self__00243728 = self_;
		}

		public override IEnumerator<WWW> GetEnumerator()
		{
			return new _0024(_0024self__00243728);
		}
	}

	[Serializable]
	internal sealed class _0024fadeOut_00243729 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal GameObject _0024go_00243730;

			internal int _0024_0024516_00243731;

			internal GameObject[] _0024_0024517_00243732;

			internal int _0024_0024518_00243733;

			internal float _0024_00242043_00243734;

			internal Color _0024_00242044_00243735;

			internal float _0024_00242045_00243736;

			internal Color _0024_00242046_00243737;

			internal EndofRound _0024self__00243738;

			public _0024(EndofRound self_)
			{
				_0024self__00243738 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (!PhotonNetwork.isMasterClient)
					{
					}
					goto case 2;
				case 2:
				{
					if (_0024self__00243738.alpha > 0f)
					{
						_0024self__00243738.alpha -= 5f * Time.deltaTime;
						float num = (_0024_00242043_00243734 = _0024self__00243738.alpha * 0.55f);
						Color color = (_0024_00242044_00243735 = _0024self__00243738.effect.color);
						float num2 = (_0024_00242044_00243735.a = _0024_00242043_00243734);
						Color color2 = (_0024self__00243738.effect.color = _0024_00242044_00243735);
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024self__00243738.alpha = 0f;
					CalculateHealth.goldearned = "a";
					CalculateHealth.bonus = 1f;
					GameObject.Find("/GUI/Chat").SendMessage("endOfRoundExit");
					_0024self__00243738.redusr1 = new UnityScript.Lang.Array("--", "--", "--", "--", "--", "--", "--", "--", "--", "--");
					_0024self__00243738.blueusr1 = new UnityScript.Lang.Array("--", "--", "--", "--", "--");
					_0024self__00243738.r1 = new UnityScript.Lang.Array("--", "--", "--");
					_0024self__00243738.r2 = new UnityScript.Lang.Array("--", "--", "--");
					_0024self__00243738.r3 = new UnityScript.Lang.Array("--", "--", "--");
					_0024self__00243738.r4 = new UnityScript.Lang.Array("--", "--", "--");
					_0024self__00243738.r5 = new UnityScript.Lang.Array("--", "--", "--");
					_0024self__00243738.r6 = new UnityScript.Lang.Array("--", "--", "--");
					_0024self__00243738.r7 = new UnityScript.Lang.Array("--", "--", "--");
					_0024self__00243738.r8 = new UnityScript.Lang.Array("--", "--", "--");
					_0024self__00243738.r9 = new UnityScript.Lang.Array("--", "--", "--");
					_0024self__00243738.r10 = new UnityScript.Lang.Array("--", "--", "--");
					_0024self__00243738.b1 = new UnityScript.Lang.Array("--", "--", "--");
					_0024self__00243738.b2 = new UnityScript.Lang.Array("--", "--", "--");
					_0024self__00243738.b3 = new UnityScript.Lang.Array("--", "--", "--");
					_0024self__00243738.b4 = new UnityScript.Lang.Array("--", "--", "--");
					_0024self__00243738.b5 = new UnityScript.Lang.Array("--", "--", "--");
					HealthBar.isdead = false;
					AmmoDisplay.minecount = 10;
					_0024self__00243738.goldsetter = false;
					float num3 = (_0024_00242045_00243736 = 0f);
					Color color4 = (_0024_00242046_00243737 = _0024self__00243738.effect.color);
					float num4 = (_0024_00242046_00243737.a = _0024_00242045_00243736);
					Color color5 = (_0024self__00243738.effect.color = _0024_00242046_00243737);
					_0024self__00243738.effect.enabled = false;
					_0024self__00243738.resetonce = false;
					_0024self__00243738.nxtround = 15f;
					_0024self__00243738.GUIActive = false;
					_0024self__00243738.sayonce = false;
					resetflags = true;
					result = (YieldDefault(3) ? 1 : 0);
					break;
				}
				case 3:
					resetflags = false;
					_0024_0024516_00243731 = 0;
					_0024_0024517_00243732 = (GameObject[])UnityEngine.Object.FindObjectsOfType(typeof(GameObject));
					for (_0024_0024518_00243733 = _0024_0024517_00243732.Length; _0024_0024516_00243731 < _0024_0024518_00243733; _0024_0024516_00243731++)
					{
						if (_0024_0024517_00243732[_0024_0024516_00243731].name == "FlagPrefabBlue(Clone)" || _0024_0024517_00243732[_0024_0024516_00243731].name == "FlagPrefabRed(Clone)")
						{
							PhotonNetwork.Destroy(_0024_0024517_00243732[_0024_0024516_00243731]);
						}
					}
					if (PhotonNetwork.isMasterClient && AuthGameObject.isAIserver)
					{
						GameObject.Find("/Spawn Point").SendMessage("respawnAIs");
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

		internal EndofRound _0024self__00243739;

		public _0024fadeOut_00243729(EndofRound self_)
		{
			_0024self__00243739 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00243739);
		}
	}

	[Serializable]
	internal sealed class _0024formatplayersRPC_00243740 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal UnityScript.Lang.Array _0024redarray_00243741;

			internal UnityScript.Lang.Array _0024bluearray_00243742;

			internal int _0024i_00243743;

			internal object _0024usr_00243744;

			internal int _0024highkill_00243745;

			internal string _0024user_00243746;

			internal int _0024c_00243747;

			internal string _0024s_00243748;

			internal IEnumerator _0024_0024iterator_0024287_00243749;

			internal string _0024s_00243750;

			internal IEnumerator _0024_0024iterator_0024288_00243751;

			internal int _0024kill_00243752;

			internal float _0024death_00243753;

			internal string _0024nameex_00243754;

			internal string _0024curuser_00243755;

			internal PhotonMessageInfo _0024info_00243756;

			internal EndofRound _0024self__00243757;

			public _0024(PhotonMessageInfo info, EndofRound self_)
			{
				_0024info_00243756 = info;
				_0024self__00243757 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (PhotonNetwork.isMasterClient)
					{
						_0024redarray_00243741 = new UnityScript.Lang.Array();
						_0024bluearray_00243742 = new UnityScript.Lang.Array();
						for (_0024i_00243743 = 0; _0024i_00243743 < SpawningScript.netPlayers.length; _0024i_00243743++)
						{
							_0024usr_00243744 = SpawningScript.netPlayers[_0024i_00243743];
							if (RuntimeServices.EqualityOperator(UnityRuntimeServices.GetProperty(_0024usr_00243744, "team"), "red"))
							{
								_0024redarray_00243741.Add(UnityRuntimeServices.GetProperty(_0024usr_00243744, "username"));
							}
							if (RuntimeServices.EqualityOperator(UnityRuntimeServices.GetProperty(_0024usr_00243744, "team"), "blue"))
							{
								_0024bluearray_00243742.Add(UnityRuntimeServices.GetProperty(_0024usr_00243744, "username"));
							}
						}
						_0024highkill_00243745 = default(int);
						_0024user_00243746 = null;
						for (_0024c_00243747 = 0; _0024c_00243747 < ((!(AuthGameObject.gametype == "Freeplay") && !(AuthGameObject.gametype == "Deathmatch") && !(AuthGameObject.gametype == "Survival")) ? 5 : 10); _0024c_00243747++)
						{
							_0024highkill_00243745 = -1;
							_0024_0024iterator_0024287_00243749 = UnityRuntimeServices.GetEnumerator(_0024redarray_00243741);
							while (_0024_0024iterator_0024287_00243749.MoveNext())
							{
								object obj2 = _0024_0024iterator_0024287_00243749.Current;
								if (!(obj2 is string))
								{
									obj2 = RuntimeServices.Coerce(obj2, typeof(string));
								}
								_0024s_00243748 = (string)obj2;
								if (RuntimeServices.ToBool(RuntimeServices.InvokeBinaryOperator("op_GreaterThan", UnityRuntimeServices.GetProperty(SpawningScript.netPlayers[_0024self__00243757.usernameToIndex(_0024s_00243748)], "kills"), _0024highkill_00243745)))
								{
									_0024highkill_00243745 = RuntimeServices.UnboxInt32(UnityRuntimeServices.GetProperty(SpawningScript.netPlayers[_0024self__00243757.usernameToIndex(_0024s_00243748)], "kills"));
									UnityRuntimeServices.Update(_0024_0024iterator_0024287_00243749, _0024s_00243748);
									_0024self__00243757.redusr1[_0024c_00243747] = _0024s_00243748;
									UnityRuntimeServices.Update(_0024_0024iterator_0024287_00243749, _0024s_00243748);
									_0024user_00243746 = _0024s_00243748;
									UnityRuntimeServices.Update(_0024_0024iterator_0024287_00243749, _0024s_00243748);
								}
							}
							for (_0024i_00243743 = 0; _0024i_00243743 < _0024redarray_00243741.length; _0024i_00243743++)
							{
								if (RuntimeServices.EqualityOperator(_0024redarray_00243741[_0024i_00243743], _0024user_00243746))
								{
									_0024redarray_00243741.RemoveAt(_0024i_00243743);
								}
							}
						}
						_0024user_00243746 = string.Empty;
						for (_0024c_00243747 = 0; _0024c_00243747 < 5; _0024c_00243747++)
						{
							_0024highkill_00243745 = -1;
							_0024_0024iterator_0024288_00243751 = UnityRuntimeServices.GetEnumerator(_0024bluearray_00243742);
							while (_0024_0024iterator_0024288_00243751.MoveNext())
							{
								object obj3 = _0024_0024iterator_0024288_00243751.Current;
								if (!(obj3 is string))
								{
									obj3 = RuntimeServices.Coerce(obj3, typeof(string));
								}
								_0024s_00243750 = (string)obj3;
								if (RuntimeServices.ToBool(RuntimeServices.InvokeBinaryOperator("op_GreaterThan", UnityRuntimeServices.GetProperty(SpawningScript.netPlayers[_0024self__00243757.usernameToIndex(_0024s_00243750)], "kills"), _0024highkill_00243745)))
								{
									_0024highkill_00243745 = RuntimeServices.UnboxInt32(UnityRuntimeServices.GetProperty(SpawningScript.netPlayers[_0024self__00243757.usernameToIndex(_0024s_00243750)], "kills"));
									UnityRuntimeServices.Update(_0024_0024iterator_0024288_00243751, _0024s_00243750);
									_0024self__00243757.blueusr1[_0024c_00243747] = _0024s_00243750;
									UnityRuntimeServices.Update(_0024_0024iterator_0024288_00243751, _0024s_00243750);
									_0024user_00243746 = _0024s_00243750;
									UnityRuntimeServices.Update(_0024_0024iterator_0024288_00243751, _0024s_00243750);
								}
							}
							for (_0024i_00243743 = 0; _0024i_00243743 < _0024bluearray_00243742.length; _0024i_00243743++)
							{
								if (RuntimeServices.EqualityOperator(_0024bluearray_00243742[_0024i_00243743], _0024user_00243746))
								{
									_0024bluearray_00243742.RemoveAt(_0024i_00243743);
								}
							}
						}
						_0024kill_00243752 = default(int);
						_0024death_00243753 = default(float);
						_0024nameex_00243754 = null;
						_0024curuser_00243755 = null;
						_0024i_00243743 = 0;
						goto IL_0666;
					}
					goto IL_084c;
				case 2:
					_0024i_00243743++;
					goto IL_0666;
				case 3:
					_0024i_00243743 = 0;
					goto IL_0840;
				case 4:
					_0024i_00243743++;
					goto IL_0840;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0840:
					if (_0024i_00243743 < 5)
					{
						object obj = _0024self__00243757.blueusr1[_0024i_00243743];
						if (!(obj is string))
						{
							obj = RuntimeServices.Coerce(obj, typeof(string));
						}
						_0024curuser_00243755 = (string)obj;
						if (_0024curuser_00243755 != "--")
						{
							_0024kill_00243752 = RuntimeServices.UnboxInt32(UnityRuntimeServices.GetProperty(SpawningScript.netPlayers[_0024self__00243757.usernameToIndex(_0024curuser_00243755)], "kills"));
							_0024death_00243753 = RuntimeServices.UnboxSingle(RuntimeServices.InvokeBinaryOperator("op_Addition", UnityRuntimeServices.GetProperty(SpawningScript.netPlayers[_0024self__00243757.usernameToIndex(_0024curuser_00243755)], "deaths"), 0f));
						}
						else
						{
							_0024kill_00243752 = -100;
							_0024death_00243753 = -100f;
						}
						_0024nameex_00243754 = (_0024i_00243743 + 1).ToString();
						((PhotonView)_0024self__00243757.gameObject.GetComponent(typeof(PhotonView))).RPC("upb" + _0024nameex_00243754, _0024info_00243756.sender, _0024curuser_00243755, _0024kill_00243752, _0024death_00243753);
						result = (YieldDefault(4) ? 1 : 0);
						break;
					}
					goto IL_084c;
					IL_0666:
					if (_0024i_00243743 < ((!(AuthGameObject.gametype == "Freeplay") && !(AuthGameObject.gametype == "Deathmatch") && !(AuthGameObject.gametype == "Survival")) ? 5 : 10))
					{
						object obj4 = _0024self__00243757.redusr1[_0024i_00243743];
						if (!(obj4 is string))
						{
							obj4 = RuntimeServices.Coerce(obj4, typeof(string));
						}
						_0024curuser_00243755 = (string)obj4;
						if (_0024curuser_00243755 != "--")
						{
							_0024kill_00243752 = RuntimeServices.UnboxInt32(UnityRuntimeServices.GetProperty(SpawningScript.netPlayers[_0024self__00243757.usernameToIndex(_0024curuser_00243755)], "kills"));
							_0024death_00243753 = RuntimeServices.UnboxSingle(RuntimeServices.InvokeBinaryOperator("op_Addition", UnityRuntimeServices.GetProperty(SpawningScript.netPlayers[_0024self__00243757.usernameToIndex(_0024curuser_00243755)], "deaths"), 0f));
						}
						else
						{
							_0024kill_00243752 = -100;
							_0024death_00243753 = -100f;
						}
						_0024nameex_00243754 = (_0024i_00243743 + 1).ToString();
						((PhotonView)_0024self__00243757.gameObject.GetComponent(typeof(PhotonView))).RPC("upr" + _0024nameex_00243754, _0024info_00243756.sender, _0024curuser_00243755, _0024kill_00243752, _0024death_00243753);
						result = (YieldDefault(2) ? 1 : 0);
					}
					else
					{
						result = (YieldDefault(3) ? 1 : 0);
					}
					break;
					IL_084c:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal PhotonMessageInfo _0024info_00243758;

		internal EndofRound _0024self__00243759;

		public _0024formatplayersRPC_00243740(PhotonMessageInfo info, EndofRound self_)
		{
			_0024info_00243758 = info;
			_0024self__00243759 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024info_00243758, _0024self__00243759);
		}
	}

	[Serializable]
	internal sealed class _0024formatplayers4Server_00243760 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal UnityScript.Lang.Array _0024redarray_00243761;

			internal UnityScript.Lang.Array _0024bluearray_00243762;

			internal int _0024i_00243763;

			internal object _0024usr_00243764;

			internal int _0024highkill_00243765;

			internal string _0024user_00243766;

			internal int _0024c_00243767;

			internal string _0024s_00243768;

			internal IEnumerator _0024_0024iterator_0024289_00243769;

			internal string _0024s_00243770;

			internal IEnumerator _0024_0024iterator_0024290_00243771;

			internal int _0024kill_00243772;

			internal float _0024death_00243773;

			internal string _0024nameex_00243774;

			internal string _0024curuser_00243775;

			internal EndofRound _0024self__00243776;

			public _0024(EndofRound self_)
			{
				_0024self__00243776 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (PhotonNetwork.isMasterClient)
					{
						_0024redarray_00243761 = new UnityScript.Lang.Array();
						_0024bluearray_00243762 = new UnityScript.Lang.Array();
						for (_0024i_00243763 = 0; _0024i_00243763 < SpawningScript.netPlayers.length; _0024i_00243763++)
						{
							_0024usr_00243764 = SpawningScript.netPlayers[_0024i_00243763];
							if (RuntimeServices.EqualityOperator(UnityRuntimeServices.GetProperty(_0024usr_00243764, "team"), "red"))
							{
								_0024redarray_00243761.Add(UnityRuntimeServices.GetProperty(_0024usr_00243764, "username"));
							}
							if (RuntimeServices.EqualityOperator(UnityRuntimeServices.GetProperty(_0024usr_00243764, "team"), "blue"))
							{
								_0024bluearray_00243762.Add(UnityRuntimeServices.GetProperty(_0024usr_00243764, "username"));
							}
						}
						_0024highkill_00243765 = default(int);
						_0024user_00243766 = null;
						for (_0024c_00243767 = 0; _0024c_00243767 < ((!(AuthGameObject.gametype == "Freeplay") && !(AuthGameObject.gametype == "Deathmatch") && !(AuthGameObject.gametype == "Survival")) ? 5 : 10); _0024c_00243767++)
						{
							_0024highkill_00243765 = -1;
							_0024_0024iterator_0024289_00243769 = UnityRuntimeServices.GetEnumerator(_0024redarray_00243761);
							while (_0024_0024iterator_0024289_00243769.MoveNext())
							{
								object obj3 = _0024_0024iterator_0024289_00243769.Current;
								if (!(obj3 is string))
								{
									obj3 = RuntimeServices.Coerce(obj3, typeof(string));
								}
								_0024s_00243768 = (string)obj3;
								if (RuntimeServices.ToBool(RuntimeServices.InvokeBinaryOperator("op_GreaterThan", UnityRuntimeServices.GetProperty(SpawningScript.netPlayers[_0024self__00243776.usernameToIndex(_0024s_00243768)], "kills"), _0024highkill_00243765)))
								{
									_0024highkill_00243765 = RuntimeServices.UnboxInt32(UnityRuntimeServices.GetProperty(SpawningScript.netPlayers[_0024self__00243776.usernameToIndex(_0024s_00243768)], "kills"));
									UnityRuntimeServices.Update(_0024_0024iterator_0024289_00243769, _0024s_00243768);
									_0024self__00243776.redusr1[_0024c_00243767] = _0024s_00243768;
									UnityRuntimeServices.Update(_0024_0024iterator_0024289_00243769, _0024s_00243768);
									_0024user_00243766 = _0024s_00243768;
									UnityRuntimeServices.Update(_0024_0024iterator_0024289_00243769, _0024s_00243768);
								}
							}
							for (_0024i_00243763 = 0; _0024i_00243763 < _0024redarray_00243761.length; _0024i_00243763++)
							{
								if (RuntimeServices.EqualityOperator(_0024redarray_00243761[_0024i_00243763], _0024user_00243766))
								{
									_0024redarray_00243761.RemoveAt(_0024i_00243763);
								}
							}
						}
						_0024user_00243766 = string.Empty;
						for (_0024c_00243767 = 0; _0024c_00243767 < 5; _0024c_00243767++)
						{
							_0024highkill_00243765 = -1;
							_0024_0024iterator_0024290_00243771 = UnityRuntimeServices.GetEnumerator(_0024bluearray_00243762);
							while (_0024_0024iterator_0024290_00243771.MoveNext())
							{
								object obj4 = _0024_0024iterator_0024290_00243771.Current;
								if (!(obj4 is string))
								{
									obj4 = RuntimeServices.Coerce(obj4, typeof(string));
								}
								_0024s_00243770 = (string)obj4;
								if (RuntimeServices.ToBool(RuntimeServices.InvokeBinaryOperator("op_GreaterThan", UnityRuntimeServices.GetProperty(SpawningScript.netPlayers[_0024self__00243776.usernameToIndex(_0024s_00243770)], "kills"), _0024highkill_00243765)))
								{
									_0024highkill_00243765 = RuntimeServices.UnboxInt32(UnityRuntimeServices.GetProperty(SpawningScript.netPlayers[_0024self__00243776.usernameToIndex(_0024s_00243770)], "kills"));
									UnityRuntimeServices.Update(_0024_0024iterator_0024290_00243771, _0024s_00243770);
									_0024self__00243776.blueusr1[_0024c_00243767] = _0024s_00243770;
									UnityRuntimeServices.Update(_0024_0024iterator_0024290_00243771, _0024s_00243770);
									_0024user_00243766 = _0024s_00243770;
									UnityRuntimeServices.Update(_0024_0024iterator_0024290_00243771, _0024s_00243770);
								}
							}
							for (_0024i_00243763 = 0; _0024i_00243763 < _0024bluearray_00243762.length; _0024i_00243763++)
							{
								if (RuntimeServices.EqualityOperator(_0024bluearray_00243762[_0024i_00243763], _0024user_00243766))
								{
									_0024bluearray_00243762.RemoveAt(_0024i_00243763);
								}
							}
						}
						_0024kill_00243772 = default(int);
						_0024death_00243773 = default(float);
						_0024nameex_00243774 = null;
						_0024curuser_00243775 = null;
						_0024i_00243763 = 0;
						goto IL_0804;
					}
					goto IL_0a69;
				case 2:
					_0024i_00243763++;
					goto IL_0804;
				case 3:
					_0024i_00243763 = 0;
					goto IL_0a5d;
				case 4:
					_0024i_00243763++;
					goto IL_0a5d;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0a5d:
					if (_0024i_00243763 < 5)
					{
						object obj = _0024self__00243776.blueusr1[_0024i_00243763];
						if (!(obj is string))
						{
							obj = RuntimeServices.Coerce(obj, typeof(string));
						}
						_0024curuser_00243775 = (string)obj;
						if (_0024curuser_00243775 != "--")
						{
							_0024kill_00243772 = RuntimeServices.UnboxInt32(UnityRuntimeServices.GetProperty(SpawningScript.netPlayers[_0024self__00243776.usernameToIndex(_0024curuser_00243775)], "kills"));
							_0024death_00243773 = RuntimeServices.UnboxSingle(UnityRuntimeServices.GetProperty(SpawningScript.netPlayers[_0024self__00243776.usernameToIndex(_0024curuser_00243775)], "deaths"));
						}
						else
						{
							_0024kill_00243772 = -100;
							_0024death_00243773 = -100f;
						}
						_0024nameex_00243774 = (_0024i_00243763 + 1).ToString();
						if (_0024nameex_00243774 == "1")
						{
							_0024self__00243776.upb1(_0024curuser_00243775, _0024kill_00243772, _0024death_00243773);
						}
						if (_0024nameex_00243774 == "2")
						{
							_0024self__00243776.upb2(_0024curuser_00243775, _0024kill_00243772, _0024death_00243773);
						}
						if (_0024nameex_00243774 == "3")
						{
							_0024self__00243776.upb3(_0024curuser_00243775, _0024kill_00243772, _0024death_00243773);
						}
						if (_0024nameex_00243774 == "4")
						{
							_0024self__00243776.upb4(_0024curuser_00243775, _0024kill_00243772, _0024death_00243773);
						}
						if (_0024nameex_00243774 == "5")
						{
							_0024self__00243776.upb5(_0024curuser_00243775, _0024kill_00243772, _0024death_00243773);
						}
						result = (YieldDefault(4) ? 1 : 0);
						break;
					}
					goto IL_0a69;
					IL_0804:
					if (_0024i_00243763 < ((!(AuthGameObject.gametype == "Freeplay") && !(AuthGameObject.gametype == "Deathmatch") && !(AuthGameObject.gametype == "Survival")) ? 5 : 10))
					{
						object obj2 = _0024self__00243776.redusr1[_0024i_00243763];
						if (!(obj2 is string))
						{
							obj2 = RuntimeServices.Coerce(obj2, typeof(string));
						}
						_0024curuser_00243775 = (string)obj2;
						if (_0024curuser_00243775 != "--")
						{
							_0024kill_00243772 = RuntimeServices.UnboxInt32(UnityRuntimeServices.GetProperty(SpawningScript.netPlayers[_0024self__00243776.usernameToIndex(_0024curuser_00243775)], "kills"));
							_0024death_00243773 = RuntimeServices.UnboxSingle(RuntimeServices.InvokeBinaryOperator("op_Addition", UnityRuntimeServices.GetProperty(SpawningScript.netPlayers[_0024self__00243776.usernameToIndex(_0024curuser_00243775)], "deaths"), 0f));
						}
						else
						{
							_0024kill_00243772 = -100;
							_0024death_00243773 = -100f;
						}
						_0024nameex_00243774 = (_0024i_00243763 + 1).ToString();
						if (_0024nameex_00243774 == "1")
						{
							_0024self__00243776.upr1(_0024curuser_00243775, _0024kill_00243772, _0024death_00243773);
						}
						if (_0024nameex_00243774 == "2")
						{
							_0024self__00243776.upr2(_0024curuser_00243775, _0024kill_00243772, _0024death_00243773);
						}
						if (_0024nameex_00243774 == "3")
						{
							_0024self__00243776.upr3(_0024curuser_00243775, _0024kill_00243772, _0024death_00243773);
						}
						if (_0024nameex_00243774 == "4")
						{
							_0024self__00243776.upr4(_0024curuser_00243775, _0024kill_00243772, _0024death_00243773);
						}
						if (_0024nameex_00243774 == "5")
						{
							_0024self__00243776.upr5(_0024curuser_00243775, _0024kill_00243772, _0024death_00243773);
						}
						if (AuthGameObject.gametype == "Freeplay")
						{
							if (_0024nameex_00243774 == "6")
							{
								_0024self__00243776.upr6(_0024curuser_00243775, _0024kill_00243772, _0024death_00243773);
							}
							if (_0024nameex_00243774 == "7")
							{
								_0024self__00243776.upr7(_0024curuser_00243775, _0024kill_00243772, _0024death_00243773);
							}
							if (_0024nameex_00243774 == "8")
							{
								_0024self__00243776.upr8(_0024curuser_00243775, _0024kill_00243772, _0024death_00243773);
							}
							if (_0024nameex_00243774 == "9")
							{
								_0024self__00243776.upr9(_0024curuser_00243775, _0024kill_00243772, _0024death_00243773);
							}
							if (_0024nameex_00243774 == "10")
							{
								_0024self__00243776.upr10(_0024curuser_00243775, _0024kill_00243772, _0024death_00243773);
							}
						}
						result = (YieldDefault(2) ? 1 : 0);
					}
					else
					{
						result = (YieldDefault(3) ? 1 : 0);
					}
					break;
					IL_0a69:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal EndofRound _0024self__00243777;

		public _0024formatplayers4Server_00243760(EndofRound self_)
		{
			_0024self__00243777 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00243777);
		}
	}

	[Serializable]
	internal sealed class _0024formatplayers_00243778 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal UnityScript.Lang.Array _0024redarray_00243779;

			internal UnityScript.Lang.Array _0024bluearray_00243780;

			internal int _0024i_00243781;

			internal object _0024usr_00243782;

			internal int _0024highkill_00243783;

			internal string _0024user_00243784;

			internal int _0024c_00243785;

			internal string _0024s_00243786;

			internal IEnumerator _0024_0024iterator_0024291_00243787;

			internal string _0024s_00243788;

			internal IEnumerator _0024_0024iterator_0024292_00243789;

			internal int _0024kill_00243790;

			internal float _0024death_00243791;

			internal string _0024nameex_00243792;

			internal string _0024curuser_00243793;

			internal EndofRound _0024self__00243794;

			public _0024(EndofRound self_)
			{
				_0024self__00243794 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (PhotonNetwork.isMasterClient)
					{
						_0024redarray_00243779 = new UnityScript.Lang.Array();
						_0024bluearray_00243780 = new UnityScript.Lang.Array();
						for (_0024i_00243781 = 0; _0024i_00243781 < SpawningScript.netPlayers.length; _0024i_00243781++)
						{
							_0024usr_00243782 = SpawningScript.netPlayers[_0024i_00243781];
							if (RuntimeServices.EqualityOperator(UnityRuntimeServices.GetProperty(_0024usr_00243782, "team"), "red"))
							{
								_0024redarray_00243779.Add(UnityRuntimeServices.GetProperty(_0024usr_00243782, "username"));
							}
							if (RuntimeServices.EqualityOperator(UnityRuntimeServices.GetProperty(_0024usr_00243782, "team"), "blue"))
							{
								_0024bluearray_00243780.Add(UnityRuntimeServices.GetProperty(_0024usr_00243782, "username"));
							}
						}
						_0024highkill_00243783 = default(int);
						_0024user_00243784 = null;
						for (_0024c_00243785 = 0; _0024c_00243785 < ((!(AuthGameObject.gametype == "Freeplay") && !(AuthGameObject.gametype == "Deathmatch") && !(AuthGameObject.gametype == "Survival")) ? 5 : 10); _0024c_00243785++)
						{
							_0024highkill_00243783 = -1;
							_0024_0024iterator_0024291_00243787 = UnityRuntimeServices.GetEnumerator(_0024redarray_00243779);
							while (_0024_0024iterator_0024291_00243787.MoveNext())
							{
								object obj2 = _0024_0024iterator_0024291_00243787.Current;
								if (!(obj2 is string))
								{
									obj2 = RuntimeServices.Coerce(obj2, typeof(string));
								}
								_0024s_00243786 = (string)obj2;
								if (RuntimeServices.ToBool(RuntimeServices.InvokeBinaryOperator("op_GreaterThan", UnityRuntimeServices.GetProperty(SpawningScript.netPlayers[_0024self__00243794.usernameToIndex(_0024s_00243786)], "kills"), _0024highkill_00243783)))
								{
									_0024highkill_00243783 = RuntimeServices.UnboxInt32(UnityRuntimeServices.GetProperty(SpawningScript.netPlayers[_0024self__00243794.usernameToIndex(_0024s_00243786)], "kills"));
									UnityRuntimeServices.Update(_0024_0024iterator_0024291_00243787, _0024s_00243786);
									_0024self__00243794.redusr1[_0024c_00243785] = _0024s_00243786;
									UnityRuntimeServices.Update(_0024_0024iterator_0024291_00243787, _0024s_00243786);
									_0024user_00243784 = _0024s_00243786;
									UnityRuntimeServices.Update(_0024_0024iterator_0024291_00243787, _0024s_00243786);
								}
							}
							for (_0024i_00243781 = 0; _0024i_00243781 < _0024redarray_00243779.length; _0024i_00243781++)
							{
								if (RuntimeServices.EqualityOperator(_0024redarray_00243779[_0024i_00243781], _0024user_00243784))
								{
									_0024redarray_00243779.RemoveAt(_0024i_00243781);
								}
							}
						}
						_0024user_00243784 = string.Empty;
						for (_0024c_00243785 = 0; _0024c_00243785 < 5; _0024c_00243785++)
						{
							_0024highkill_00243783 = -1;
							_0024_0024iterator_0024292_00243789 = UnityRuntimeServices.GetEnumerator(_0024bluearray_00243780);
							while (_0024_0024iterator_0024292_00243789.MoveNext())
							{
								object obj3 = _0024_0024iterator_0024292_00243789.Current;
								if (!(obj3 is string))
								{
									obj3 = RuntimeServices.Coerce(obj3, typeof(string));
								}
								_0024s_00243788 = (string)obj3;
								if (RuntimeServices.ToBool(RuntimeServices.InvokeBinaryOperator("op_GreaterThan", UnityRuntimeServices.GetProperty(SpawningScript.netPlayers[_0024self__00243794.usernameToIndex(_0024s_00243788)], "kills"), _0024highkill_00243783)))
								{
									_0024highkill_00243783 = RuntimeServices.UnboxInt32(UnityRuntimeServices.GetProperty(SpawningScript.netPlayers[_0024self__00243794.usernameToIndex(_0024s_00243788)], "kills"));
									UnityRuntimeServices.Update(_0024_0024iterator_0024292_00243789, _0024s_00243788);
									_0024self__00243794.blueusr1[_0024c_00243785] = _0024s_00243788;
									UnityRuntimeServices.Update(_0024_0024iterator_0024292_00243789, _0024s_00243788);
									_0024user_00243784 = _0024s_00243788;
									UnityRuntimeServices.Update(_0024_0024iterator_0024292_00243789, _0024s_00243788);
								}
							}
							for (_0024i_00243781 = 0; _0024i_00243781 < _0024bluearray_00243780.length; _0024i_00243781++)
							{
								if (RuntimeServices.EqualityOperator(_0024bluearray_00243780[_0024i_00243781], _0024user_00243784))
								{
									_0024bluearray_00243780.RemoveAt(_0024i_00243781);
								}
							}
						}
						_0024kill_00243790 = default(int);
						_0024death_00243791 = default(float);
						_0024nameex_00243792 = null;
						_0024curuser_00243793 = null;
						_0024i_00243781 = 0;
						goto IL_065c;
					}
					goto IL_0838;
				case 2:
					_0024i_00243781++;
					goto IL_065c;
				case 3:
					_0024i_00243781 = 0;
					goto IL_082c;
				case 4:
					_0024i_00243781++;
					goto IL_082c;
				case 1:
					{
						result = 0;
						break;
					}
					IL_082c:
					if (_0024i_00243781 < 5)
					{
						object obj = _0024self__00243794.blueusr1[_0024i_00243781];
						if (!(obj is string))
						{
							obj = RuntimeServices.Coerce(obj, typeof(string));
						}
						_0024curuser_00243793 = (string)obj;
						if (_0024curuser_00243793 != "--")
						{
							_0024kill_00243790 = RuntimeServices.UnboxInt32(UnityRuntimeServices.GetProperty(SpawningScript.netPlayers[_0024self__00243794.usernameToIndex(_0024curuser_00243793)], "kills"));
							_0024death_00243791 = RuntimeServices.UnboxSingle(RuntimeServices.InvokeBinaryOperator("op_Addition", UnityRuntimeServices.GetProperty(SpawningScript.netPlayers[_0024self__00243794.usernameToIndex(_0024curuser_00243793)], "deaths"), 0f));
						}
						else
						{
							_0024kill_00243790 = -100;
							_0024death_00243791 = -100f;
						}
						_0024nameex_00243792 = (_0024i_00243781 + 1).ToString();
						((PhotonView)_0024self__00243794.gameObject.GetComponent(typeof(PhotonView))).RPC("upb" + _0024nameex_00243792, PhotonTargets.All, _0024curuser_00243793, _0024kill_00243790, _0024death_00243791);
						result = (YieldDefault(4) ? 1 : 0);
						break;
					}
					goto IL_0838;
					IL_065c:
					if (_0024i_00243781 < ((!(AuthGameObject.gametype == "Freeplay") && !(AuthGameObject.gametype == "Deathmatch") && !(AuthGameObject.gametype == "Survival")) ? 5 : 10))
					{
						object obj4 = _0024self__00243794.redusr1[_0024i_00243781];
						if (!(obj4 is string))
						{
							obj4 = RuntimeServices.Coerce(obj4, typeof(string));
						}
						_0024curuser_00243793 = (string)obj4;
						if (_0024curuser_00243793 != "--")
						{
							_0024kill_00243790 = RuntimeServices.UnboxInt32(UnityRuntimeServices.GetProperty(SpawningScript.netPlayers[_0024self__00243794.usernameToIndex(_0024curuser_00243793)], "kills"));
							_0024death_00243791 = RuntimeServices.UnboxSingle(RuntimeServices.InvokeBinaryOperator("op_Addition", UnityRuntimeServices.GetProperty(SpawningScript.netPlayers[_0024self__00243794.usernameToIndex(_0024curuser_00243793)], "deaths"), 0f));
						}
						else
						{
							_0024kill_00243790 = -100;
							_0024death_00243791 = -100f;
						}
						_0024nameex_00243792 = (_0024i_00243781 + 1).ToString();
						((PhotonView)_0024self__00243794.gameObject.GetComponent(typeof(PhotonView))).RPC("upr" + _0024nameex_00243792, PhotonTargets.All, _0024curuser_00243793, _0024kill_00243790, _0024death_00243791);
						result = (YieldDefault(2) ? 1 : 0);
					}
					else
					{
						result = (YieldDefault(3) ? 1 : 0);
					}
					break;
					IL_0838:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal EndofRound _0024self__00243795;

		public _0024formatplayers_00243778(EndofRound self_)
		{
			_0024self__00243795 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00243795);
		}
	}

	[Serializable]
	internal sealed class _0024sendCredits_00243796 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal WWW _0024getKey_00243797;

			internal WWW _0024bitem_00243798;

			internal int _0024amnt_00243799;

			internal EndofRound _0024self__00243800;

			public _0024(int amnt, EndofRound self_)
			{
				_0024amnt_00243799 = amnt;
				_0024self__00243800 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					Debug.Log("Attempting to send " + _0024amnt_00243799.ToString() + " credits to secure server...");
					_0024getKey_00243797 = new WWW(_0024self__00243800.keyGen + "username=" + Md5Sum.ComputeMd5(AuthGameObject.username + global::DontDestroyOnLoad.hitcollider));
					result = (Yield(2, _0024getKey_00243797) ? 1 : 0);
					break;
				case 2:
					_0024bitem_00243798 = new WWW(_0024self__00243800.storeInterface + "username=" + AuthGameObject.username + "&request=addcreds" + "&serverkey=" + Md5Sum.ComputeMd5(_0024getKey_00243797.text + global::DontDestroyOnLoad.hitcollider) + "&changeto=" + _0024amnt_00243799.ToString());
					result = (Yield(3, _0024bitem_00243798) ? 1 : 0);
					break;
				case 3:
					if (string.IsNullOrEmpty(_0024bitem_00243798.error) && _0024bitem_00243798.text.Contains("updated"))
					{
						Debug.Log("Successfully sent " + _0024amnt_00243799.ToString() + " credits!");
						AuthGameObject.inventory[2] = (UnityBuiltins.parseInt(_0024self__00243800.returnGold()) + _0024amnt_00243799).ToString() + "#" + AuthGameObject.inventory[2].Split("#"[0])[1] + "#" + AuthGameObject.inventory[2].Split("#"[0])[2] + "#" + AuthGameObject.inventory[2].Split("#"[0])[3] + "#" + AuthGameObject.inventory[2].Split("#"[0])[4] + "#" + LoginWindow.curday + "#" + AuthGameObject.inventory[2].Split("#"[0])[6];
						AuthGameObject.inventory[2] = _0024self__00243800.returnGoldEncrypted() + "#" + AuthGameObject.inventory[2].Split("#"[0])[1] + "#" + AuthGameObject.inventory[2].Split("#"[0])[2] + "#" + AuthGameObject.inventory[2].Split("#"[0])[3] + "#" + AuthGameObject.inventory[2].Split("#"[0])[4] + "#" + LoginWindow.curday + "#" + AuthGameObject.inventory[2].Split("#"[0])[6];
						goto case 1;
					}
					Debug.Log("Failed sending " + _0024amnt_00243799.ToString() + " credits!");
					result = (Yield(4, new WaitForSeconds(5f)) ? 1 : 0);
					break;
				case 4:
					_0024getKey_00243797 = new WWW(_0024self__00243800.keyGen + "username=" + Md5Sum.ComputeMd5(AuthGameObject.username + global::DontDestroyOnLoad.hitcollider));
					result = (Yield(5, _0024getKey_00243797) ? 1 : 0);
					break;
				case 5:
					_0024bitem_00243798 = new WWW(_0024self__00243800.storeInterface + "username=" + AuthGameObject.username + "&request=addcreds" + "&serverkey=" + Md5Sum.ComputeMd5(_0024getKey_00243797.text + global::DontDestroyOnLoad.hitcollider) + "&changeto=" + _0024amnt_00243799.ToString());
					result = (Yield(6, _0024bitem_00243798) ? 1 : 0);
					break;
				case 6:
					if (string.IsNullOrEmpty(_0024bitem_00243798.error) && _0024bitem_00243798.text.Contains("updated"))
					{
						Debug.Log("Successfully sent " + _0024amnt_00243799.ToString() + " credits!");
						AuthGameObject.inventory[2] = (UnityBuiltins.parseInt(_0024self__00243800.returnGold()) + _0024amnt_00243799).ToString() + "#" + AuthGameObject.inventory[2].Split("#"[0])[1] + "#" + AuthGameObject.inventory[2].Split("#"[0])[2] + "#" + AuthGameObject.inventory[2].Split("#"[0])[3] + "#" + AuthGameObject.inventory[2].Split("#"[0])[4] + "#" + LoginWindow.curday + "#" + AuthGameObject.inventory[2].Split("#"[0])[6];
						AuthGameObject.inventory[2] = _0024self__00243800.returnGoldEncrypted() + "#" + AuthGameObject.inventory[2].Split("#"[0])[1] + "#" + AuthGameObject.inventory[2].Split("#"[0])[2] + "#" + AuthGameObject.inventory[2].Split("#"[0])[3] + "#" + AuthGameObject.inventory[2].Split("#"[0])[4] + "#" + LoginWindow.curday + "#" + AuthGameObject.inventory[2].Split("#"[0])[6];
					}
					else
					{
						Debug.Log("Complete and utter failure in sending " + _0024amnt_00243799.ToString() + " credits.. will try again");
						_0024self__00243800.lastGoldEarned -= _0024amnt_00243799;
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

		internal int _0024amnt_00243801;

		internal EndofRound _0024self__00243802;

		public _0024sendCredits_00243796(int amnt, EndofRound self_)
		{
			_0024amnt_00243801 = amnt;
			_0024self__00243802 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024amnt_00243801, _0024self__00243802);
		}
	}

	[Serializable]
	internal sealed class _0024fadeInNotEnd_00243803 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal EndofRound _0024self__00243804;

			public _0024(EndofRound self_)
			{
				_0024self__00243804 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00243804.istabbing = true;
					if (!PhotonNetwork.isMasterClient)
					{
						((PhotonView)_0024self__00243804.gameObject.GetComponent(typeof(PhotonView))).RPC("formatplayersRPC", PhotonTargets.MasterClient);
					}
					else
					{
						_0024self__00243804.StartCoroutine_Auto(_0024self__00243804.formatplayers4Server());
					}
					goto case 2;
				case 2:
					if (_0024self__00243804.alphatab < 1f)
					{
						_0024self__00243804.alphatab += 4f * Time.deltaTime;
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024self__00243804.alphatab = 1f;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal EndofRound _0024self__00243805;

		public _0024fadeInNotEnd_00243803(EndofRound self_)
		{
			_0024self__00243805 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00243805);
		}
	}

	[Serializable]
	internal sealed class _0024fadeOutNotEnd_00243806 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal EndofRound _0024self__00243807;

			public _0024(EndofRound self_)
			{
				_0024self__00243807 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__00243807.alphatab > 0f)
					{
						_0024self__00243807.alphatab -= 4f * Time.deltaTime;
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024self__00243807.alphatab = 0f;
					_0024self__00243807.istabbing = false;
					_0024self__00243807.redusr1 = new UnityScript.Lang.Array("--", "--", "--", "--", "--", "--", "--", "--", "--", "--");
					_0024self__00243807.blueusr1 = new UnityScript.Lang.Array("--", "--", "--", "--", "--");
					_0024self__00243807.r1 = new UnityScript.Lang.Array("--", "--", "--");
					_0024self__00243807.r2 = new UnityScript.Lang.Array("--", "--", "--");
					_0024self__00243807.r3 = new UnityScript.Lang.Array("--", "--", "--");
					_0024self__00243807.r4 = new UnityScript.Lang.Array("--", "--", "--");
					_0024self__00243807.r5 = new UnityScript.Lang.Array("--", "--", "--");
					_0024self__00243807.b1 = new UnityScript.Lang.Array("--", "--", "--");
					_0024self__00243807.b2 = new UnityScript.Lang.Array("--", "--", "--");
					_0024self__00243807.b3 = new UnityScript.Lang.Array("--", "--", "--");
					_0024self__00243807.b4 = new UnityScript.Lang.Array("--", "--", "--");
					_0024self__00243807.b5 = new UnityScript.Lang.Array("--", "--", "--");
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal EndofRound _0024self__00243808;

		public _0024fadeOutNotEnd_00243806(EndofRound self_)
		{
			_0024self__00243808 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00243808);
		}
	}

	[Serializable]
	internal sealed class _0024addFriend_00243809 : GenericGenerator<WWW>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WWW>, IEnumerator
		{
			internal int _0024randomnumber_00243810;

			internal WWW _0024friends_00243811;

			internal Friend _0024newF_00243812;

			internal string _0024u_00243813;

			internal EndofRound _0024self__00243814;

			public _0024(string u, EndofRound self_)
			{
				_0024u_00243813 = u;
				_0024self__00243814 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00243814.gameObject.SendMessage("showStatus", "Friending...");
					_0024randomnumber_00243810 = UnityEngine.Random.Range(0, 99999);
					_0024friends_00243811 = new WWW("http://72.14.184.180/rankingsManager.php?request=addFriend&key=" + Md5Sum.ComputeMd5(global::DontDestroyOnLoad.hitcollider + _0024randomnumber_00243810.ToString()) + "&random=" + _0024randomnumber_00243810.ToString() + "&user=" + AuthGameObject.username + "&friend=" + _0024u_00243813);
					result = (Yield(2, _0024friends_00243811) ? 1 : 0);
					break;
				case 2:
					if (string.IsNullOrEmpty(_0024friends_00243811.error))
					{
						_0024newF_00243812 = new Friend(_0024u_00243813, false);
						AuthGameObject.friendsArr.Add(_0024newF_00243812);
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

		internal string _0024u_00243815;

		internal EndofRound _0024self__00243816;

		public _0024addFriend_00243809(string u, EndofRound self_)
		{
			_0024u_00243815 = u;
			_0024self__00243816 = self_;
		}

		public override IEnumerator<WWW> GetEnumerator()
		{
			return new _0024(_0024u_00243815, _0024self__00243816);
		}
	}

	public GUIStyle mainskin;

	public GUIStyle txtstyle;

	public GUIStyle titletxt;

	public GUIStyle playertxt;

	public GUIStyle buttonstyle;

	public GUIStyle goldlabel;

	public Color redcolor;

	public Color bluecolor;

	public Color nocolor;

	public Texture redback;

	public Texture blueback;

	public Texture noback;

	private bool readytog;

	private float nxtround;

	public SpawningScript src;

	public AuthGameObject authgameobj;

	public InGameScores igs;

	public LoginWindow lwindow;

	public HealthBar hbar;

	public AmmoDisplay ammocounter;

	public RefreshMasterServer refresh;

	public FadeSceneTransition fadestrans;

	public MasterServerScript mserver;

	public PreloaderExplosion pex;

	public AudioController acon;

	public GameObject spawnobj;

	public GameObject igsobj;

	public KongregateAPI kongapi;

	public GUITexture effect;

	private bool resetonce;

	private UnityScript.Lang.Array redusr1;

	private UnityScript.Lang.Array blueusr1;

	private UnityScript.Lang.Array r1;

	private UnityScript.Lang.Array r2;

	private UnityScript.Lang.Array r3;

	private UnityScript.Lang.Array r4;

	private UnityScript.Lang.Array r5;

	private UnityScript.Lang.Array r6;

	private UnityScript.Lang.Array r7;

	private UnityScript.Lang.Array r8;

	private UnityScript.Lang.Array r9;

	private UnityScript.Lang.Array r10;

	private UnityScript.Lang.Array b1;

	private UnityScript.Lang.Array b2;

	private UnityScript.Lang.Array b3;

	private UnityScript.Lang.Array b4;

	private UnityScript.Lang.Array b5;

	private float alpha;

	[NonSerialized]
	public static float alphastat;

	private float alphatab;

	private bool GUIActive;

	private int numbofrounds;

	[NonSerialized]
	public static bool resetflags;

	private bool sayonce;

	private int goldEarned;

	public CalculateHealth chealth;

	public GUIStyle smallboxstyle;

	public Texture goldicon;

	private int goldearned;

	private bool goldsetter;

	private string keyGen;

	private string storeInterface;

	public DontDestroyOnLoad ddol;

	private bool sendonce;

	private bool istabbing;

	private int lastround;

	private int lastGoldEarned;

	private string goldEarnedThisRound;

	public EndofRound()
	{
		nxtround = 15f;
		redusr1 = new UnityScript.Lang.Array("--", "--", "--", "--", "--", "--", "--", "--", "--", "--");
		blueusr1 = new UnityScript.Lang.Array("--", "--", "--", "--", "--");
		r1 = new UnityScript.Lang.Array("--", "--", "--");
		r2 = new UnityScript.Lang.Array("--", "--", "--");
		r3 = new UnityScript.Lang.Array("--", "--", "--");
		r4 = new UnityScript.Lang.Array("--", "--", "--");
		r5 = new UnityScript.Lang.Array("--", "--", "--");
		r6 = new UnityScript.Lang.Array("--", "--", "--");
		r7 = new UnityScript.Lang.Array("--", "--", "--");
		r8 = new UnityScript.Lang.Array("--", "--", "--");
		r9 = new UnityScript.Lang.Array("--", "--", "--");
		r10 = new UnityScript.Lang.Array("--", "--", "--");
		b1 = new UnityScript.Lang.Array("--", "--", "--");
		b2 = new UnityScript.Lang.Array("--", "--", "--");
		b3 = new UnityScript.Lang.Array("--", "--", "--");
		b4 = new UnityScript.Lang.Array("--", "--", "--");
		b5 = new UnityScript.Lang.Array("--", "--", "--");
		keyGen = "http://72.14.184.180/serverKeyGen.php?";
		storeInterface = "http://72.14.184.180/storeInterface.php?";
		goldEarnedThisRound = string.Empty;
	}

	public virtual void Awake()
	{
		resetflags = false;
		alphastat = 0f;
	}

	public virtual string returnGoldEarned()
	{
		string text = CalculateHealth.goldearned;
		string text2 = string.Empty;
		for (int i = 0; i < UnityScript.Lang.Extensions.get_length(text); i++)
		{
			if (text.Substring(i, 1) == "a")
			{
				text2 += "0";
			}
			if (text.Substring(i, 1) == "b")
			{
				text2 += "1";
			}
			if (text.Substring(i, 1) == "c")
			{
				text2 += "2";
			}
			if (text.Substring(i, 1) == "d")
			{
				text2 += "3";
			}
			if (text.Substring(i, 1) == "e")
			{
				text2 += "4";
			}
			if (text.Substring(i, 1) == "f")
			{
				text2 += "5";
			}
			if (text.Substring(i, 1) == "g")
			{
				text2 += "6";
			}
			if (text.Substring(i, 1) == "h")
			{
				text2 += "7";
			}
			if (text.Substring(i, 1) == "i")
			{
				text2 += "8";
			}
			if (text.Substring(i, 1) == "j")
			{
				text2 += "9";
			}
		}
		return text2;
	}

	public virtual string returnGold()
	{
		string text = AuthGameObject.inventory[2].Split("#"[0])[0];
		string text2 = string.Empty;
		for (int i = 0; i < UnityScript.Lang.Extensions.get_length(text); i++)
		{
			if (text.Substring(i, 1) == "a")
			{
				text2 += "0";
			}
			if (text.Substring(i, 1) == "b")
			{
				text2 += "1";
			}
			if (text.Substring(i, 1) == "c")
			{
				text2 += "2";
			}
			if (text.Substring(i, 1) == "d")
			{
				text2 += "3";
			}
			if (text.Substring(i, 1) == "e")
			{
				text2 += "4";
			}
			if (text.Substring(i, 1) == "f")
			{
				text2 += "5";
			}
			if (text.Substring(i, 1) == "g")
			{
				text2 += "6";
			}
			if (text.Substring(i, 1) == "h")
			{
				text2 += "7";
			}
			if (text.Substring(i, 1) == "i")
			{
				text2 += "8";
			}
			if (text.Substring(i, 1) == "j")
			{
				text2 += "9";
			}
		}
		return text2;
	}

	public virtual string returnGoldEncrypted()
	{
		string[] array = AuthGameObject.inventory[2].Split("#"[0]);
		string text = null;
		for (int i = 0; i < UnityScript.Lang.Extensions.get_length(array[0]); i++)
		{
			if (array[0].Substring(i, 1) == "0")
			{
				text += "a";
			}
			if (array[0].Substring(i, 1) == "1")
			{
				text += "b";
			}
			if (array[0].Substring(i, 1) == "2")
			{
				text += "c";
			}
			if (array[0].Substring(i, 1) == "3")
			{
				text += "d";
			}
			if (array[0].Substring(i, 1) == "4")
			{
				text += "e";
			}
			if (array[0].Substring(i, 1) == "5")
			{
				text += "f";
			}
			if (array[0].Substring(i, 1) == "6")
			{
				text += "g";
			}
			if (array[0].Substring(i, 1) == "7")
			{
				text += "h";
			}
			if (array[0].Substring(i, 1) == "8")
			{
				text += "i";
			}
			if (array[0].Substring(i, 1) == "9")
			{
				text += "j";
			}
		}
		return text;
	}

	[RPC]
	public virtual void fadeOutNetwork(PhotonMessageInfo info)
	{
		((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("updatetime", info.sender, nxtround);
	}

	public virtual IEnumerator hbarshow()
	{
		return new _0024hbarshow_00243709(this).GetEnumerator();
	}

	public virtual NetPlayer returnLocalNetPlayer()
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
				if (netPlayer.username == AuthGameObject.username)
				{
					result = netPlayer;
					break;
				}
				continue;
			}
			result = null;
			break;
		}
		return (NetPlayer)result;
	}

	public virtual void Start()
	{
		AuthGameObject authGameObject = (AuthGameObject)GameObject.Find("/AuthGameObject").GetComponent(typeof(AuthGameObject));
		if (PhotonNetwork.isMasterClient)
		{
			authGameObject.StartCoroutine_Auto(authGameObject.sendStat("totalhosted", 1, 0));
		}
		else
		{
			authGameObject.StartCoroutine_Auto(authGameObject.sendStat("totaljoined", 1, 0));
		}
	}

	public virtual IEnumerator fadein()
	{
		return new _0024fadein_00243712(this).GetEnumerator();
	}

	public virtual IEnumerator sendInCredits()
	{
		return new _0024sendInCredits_00243721(this).GetEnumerator();
	}

	public virtual void setguiactive(bool t)
	{
		GUIActive = t;
	}

	public virtual IEnumerator fadeOut()
	{
		return new _0024fadeOut_00243729(this).GetEnumerator();
	}

	public virtual int usernameToIndex(string u)
	{
		int num = 0;
		IEnumerator enumerator = UnityRuntimeServices.GetEnumerator(SpawningScript.netPlayers);
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
	public virtual IEnumerator formatplayersRPC(PhotonMessageInfo info)
	{
		return new _0024formatplayersRPC_00243740(info, this).GetEnumerator();
	}

	public virtual IEnumerator formatplayers4Server()
	{
		return new _0024formatplayers4Server_00243760(this).GetEnumerator();
	}

	public virtual IEnumerator formatplayers()
	{
		return new _0024formatplayers_00243778(this).GetEnumerator();
	}

	[RPC]
	public virtual void upr1(string p, int k, float d)
	{
		r1[0] = p;
		if (p != "--")
		{
			r1[1] = k.ToString();
			r1[2] = d.ToString();
		}
		else
		{
			r1[1] = "--";
			r1[2] = "--";
		}
		if (p == AuthGameObject.username && AuthGameObject.shop && !istabbing)
		{
			GameObject.Find("/GUI/Chat").SendMessage("gotTop");
		}
	}

	[RPC]
	public virtual void upr2(string p, int k, float d)
	{
		r2[0] = p;
		if (p != "--")
		{
			r2[1] = k.ToString();
			r2[2] = d.ToString();
		}
		else
		{
			r2[1] = "--";
			r2[2] = "--";
		}
	}

	[RPC]
	public virtual void upr3(string p, int k, float d)
	{
		r3[0] = p;
		if (p != "--")
		{
			r3[1] = k.ToString();
			r3[2] = d.ToString();
		}
		else
		{
			r3[1] = "--";
			r3[2] = "--";
		}
	}

	[RPC]
	public virtual void upr4(string p, int k, float d)
	{
		r4[0] = p;
		if (p != "--")
		{
			r4[1] = k.ToString();
			r4[2] = d.ToString();
		}
		else
		{
			r4[1] = "--";
			r4[2] = "--";
		}
	}

	[RPC]
	public virtual void upr5(string p, int k, float d)
	{
		r5[0] = p;
		if (p != "--")
		{
			r5[1] = k.ToString();
			r5[2] = d.ToString();
		}
		else
		{
			r5[1] = "--";
			r5[2] = "--";
		}
	}

	[RPC]
	public virtual void upr6(string p, int k, float d)
	{
		r6[0] = p;
		if (p != "--")
		{
			r6[1] = k.ToString();
			r6[2] = d.ToString();
		}
		else
		{
			r6[1] = "--";
			r6[2] = "--";
		}
	}

	[RPC]
	public virtual void upr7(string p, int k, float d)
	{
		r7[0] = p;
		if (p != "--")
		{
			r7[1] = k.ToString();
			r7[2] = d.ToString();
		}
		else
		{
			r7[1] = "--";
			r7[2] = "--";
		}
	}

	[RPC]
	public virtual void upr8(string p, int k, float d)
	{
		r8[0] = p;
		if (p != "--")
		{
			r8[1] = k.ToString();
			r8[2] = d.ToString();
		}
		else
		{
			r8[1] = "--";
			r8[2] = "--";
		}
	}

	[RPC]
	public virtual void upr9(string p, int k, float d)
	{
		r9[0] = p;
		if (p != "--")
		{
			r9[1] = k.ToString();
			r9[2] = d.ToString();
		}
		else
		{
			r9[1] = "--";
			r9[2] = "--";
		}
	}

	[RPC]
	public virtual void upr10(string p, int k, float d)
	{
		r10[0] = p;
		if (p != "--")
		{
			r10[1] = k.ToString();
			r10[2] = d.ToString();
		}
		else
		{
			r10[1] = "--";
			r10[2] = "--";
		}
	}

	[RPC]
	public virtual void upb1(string p, int k, float d)
	{
		b1[0] = p;
		if (p != "--")
		{
			b1[1] = k.ToString();
			b1[2] = d.ToString();
		}
		else
		{
			b1[1] = "--";
			b1[2] = "--";
		}
		if (p == AuthGameObject.username && AuthGameObject.shop && !istabbing)
		{
			GameObject.Find("/GUI/Chat").SendMessage("gotTop");
		}
	}

	[RPC]
	public virtual void upb2(string p, int k, float d)
	{
		b2[0] = p;
		if (p != "--")
		{
			b2[1] = k.ToString();
			b2[2] = d.ToString();
		}
		else
		{
			b2[1] = "--";
			b2[2] = "--";
		}
	}

	[RPC]
	public virtual void upb3(string p, int k, float d)
	{
		b3[0] = p;
		if (p != "--")
		{
			b3[1] = k.ToString();
			b3[2] = d.ToString();
		}
		else
		{
			b3[1] = "--";
			b3[2] = "--";
		}
	}

	[RPC]
	public virtual void upb4(string p, int k, float d)
	{
		b4[0] = p;
		if (p != "--")
		{
			b4[1] = k.ToString();
			b4[2] = d.ToString();
		}
		else
		{
			b4[1] = "--";
			b4[2] = "--";
		}
	}

	[RPC]
	public virtual void upb5(string p, int k, float d)
	{
		b5[0] = p;
		if (p != "--")
		{
			b5[1] = k.ToString();
			b5[2] = d.ToString();
		}
		else
		{
			b5[1] = "--";
			b5[2] = "--";
		}
	}

	[RPC]
	public virtual void updatetime(float f)
	{
		nxtround = f;
		if (nxtround == 15f)
		{
			everyoneCloseWin();
		}
	}

	public virtual IEnumerator sendCredits(int amnt)
	{
		return new _0024sendCredits_00243796(amnt, this).GetEnumerator();
	}

	public virtual void Update()
	{
		goldearned = UnityBuiltins.parseInt(returnGoldEarned());
		int b = (int)Mathf.Round(700 * (AuthGameObject.timelimit / 10));
		if (Mathf.Min(goldearned, b) > lastGoldEarned)
		{
			StartCoroutine_Auto(sendCredits(Mathf.Max(Mathf.Min(goldearned, b) - lastGoldEarned, 0)));
			lastGoldEarned = goldearned;
		}
		alphastat = alpha;
		if (GUIActive)
		{
			if (!(nxtround <= 0f))
			{
				if (PhotonNetwork.isMasterClient)
				{
					nxtround -= Time.deltaTime;
					if (Mathf.Round(nxtround) != (float)lastround && Mathf.Round(nxtround) != 15f)
					{
						lastround = (int)Mathf.Round(nxtround);
						((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("updatetime", PhotonTargets.Others, Mathf.Round(nxtround));
					}
				}
			}
			else if (PhotonNetwork.isMasterClient && !sendonce)
			{
				sendonce = true;
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("everyoneCloseWin", PhotonTargets.All);
			}
		}
		else if (Input.GetKeyDown(KeyCode.Tab) && SpawningScript.team2 != string.Empty)
		{
			if (alphatab == 0f)
			{
				StartCoroutine_Auto(fadeInNotEnd());
			}
			else if (alphatab == 1f)
			{
				StartCoroutine_Auto(fadeOutNotEnd());
			}
		}
	}

	public virtual IEnumerator fadeInNotEnd()
	{
		return new _0024fadeInNotEnd_00243803(this).GetEnumerator();
	}

	public virtual IEnumerator fadeOutNotEnd()
	{
		return new _0024fadeOutNotEnd_00243806(this).GetEnumerator();
	}

	[RPC]
	public virtual void everyoneCloseWin()
	{
		nxtround = 0f;
		if (!resetonce && alpha != 0f)
		{
			resetonce = true;
			if (SpawningScript.playertransCar != null)
			{
				SpawningScript.playertransCar.gameObject.SendMessage("roundsetter", true);
			}
			igsobj.SendMessage("resetdelegate");
			if (SpawningScript.team2 != string.Empty)
			{
				spawnobj.SendMessage("Respawn", 0.101f);
			}
			if (PhotonNetwork.isMasterClient)
			{
				((PhotonView)spawnobj.GetComponent(typeof(PhotonView))).RPC("resetstats", PhotonTargets.All);
			}
			StartCoroutine_Auto(fadeOut());
		}
	}

	public virtual void OnGUI()
	{
		if (AudioController.hideGUI)
		{
			return;
		}
		int num2;
		if (GUIActive)
		{
			GUI.depth = -5;
			float a = alpha;
			Color color = GUI.color;
			float num = (color.a = a);
			Color color2 = (GUI.color = color);
			if (alpha <= 0f)
			{
				return;
			}
			num2 = 0;
			if (!AuthGameObject.username.Contains("guest_") && AuthGameObject.shop)
			{
				num2 = 50;
				GUI.BeginGroup(new Rect(Screen.width / 2 - 175, Screen.height / 2 - 187 - 35, 350f, 80f));
				GUI.Box(new Rect(0f, 0f, 350f, 80f), "You earned " + goldEarnedThisRound + " credits this round!", smallboxstyle);
				GUI.Label(new Rect(0f, 0f, 350f, 80f), "You now have " + returnGold() + " credits.", goldlabel);
				GUI.DrawTexture(new Rect(20f, 20f, 53f, 40f), goldicon);
				GUI.EndGroup();
			}
			GUI.BeginGroup(new Rect(Screen.width / 2 - 175, Screen.height / 2 - 187 + num2, 350f, 375f));
			GUI.Box(new Rect(0f, 0f, 350f, 375f), "Battle Summary", mainskin);
			GUI.Label(new Rect(12f, 55f, 350f, 15f), "Username\t\t\t\t\tKills\t\tDeaths\t\t\t", txtstyle);
			if (AuthGameObject.gametype == "Freeplay" || AuthGameObject.gametype == "Deathmatch" || AuthGameObject.gametype == "Survival")
			{
				GUI.color = nocolor;
				float a2 = alpha;
				Color color4 = GUI.color;
				float num3 = (color4.a = a2);
				Color color5 = (GUI.color = color4);
				GUI.Label(new Rect(75f, 35f, 20f, 20f), "All Players", titletxt);
				GUI.color = Color.white;
				float a3 = alpha;
				Color color7 = GUI.color;
				float num4 = (color7.a = a3);
				Color color8 = (GUI.color = color7);
				int num5 = 70;
				bool flag = true;
				for (int i = 0; i < 10; i++)
				{
					if (flag)
					{
						flag = false;
						float a4 = 0.7f * alpha;
						Color color10 = GUI.color;
						float num6 = (color10.a = a4);
						Color color11 = (GUI.color = color10);
						GUI.DrawTexture(new Rect(6f, num5 + 2, 338f, 25f), noback);
					}
					else
					{
						flag = true;
					}
					float a5 = alpha;
					Color color13 = GUI.color;
					float num7 = (color13.a = a5);
					Color color14 = (GUI.color = color13);
					GUI.Label(new Rect(30f, num5, 325f, 30f), "#" + (i + 1).ToString(), playertxt);
					string text = "--";
					string text2 = "--";
					string text3 = "--";
					if (i == 0)
					{
						object obj = r1[0];
						if (!(obj is string))
						{
							obj = RuntimeServices.Coerce(obj, typeof(string));
						}
						text = (string)obj;
						object obj2 = r1[1];
						if (!(obj2 is string))
						{
							obj2 = RuntimeServices.Coerce(obj2, typeof(string));
						}
						text2 = (string)obj2;
						object obj3 = r1[2];
						if (!(obj3 is string))
						{
							obj3 = RuntimeServices.Coerce(obj3, typeof(string));
						}
						text3 = (string)obj3;
					}
					if (i == 1)
					{
						object obj4 = r2[0];
						if (!(obj4 is string))
						{
							obj4 = RuntimeServices.Coerce(obj4, typeof(string));
						}
						text = (string)obj4;
						object obj5 = r2[1];
						if (!(obj5 is string))
						{
							obj5 = RuntimeServices.Coerce(obj5, typeof(string));
						}
						text2 = (string)obj5;
						object obj6 = r2[2];
						if (!(obj6 is string))
						{
							obj6 = RuntimeServices.Coerce(obj6, typeof(string));
						}
						text3 = (string)obj6;
					}
					if (i == 2)
					{
						object obj7 = r3[0];
						if (!(obj7 is string))
						{
							obj7 = RuntimeServices.Coerce(obj7, typeof(string));
						}
						text = (string)obj7;
						object obj8 = r3[1];
						if (!(obj8 is string))
						{
							obj8 = RuntimeServices.Coerce(obj8, typeof(string));
						}
						text2 = (string)obj8;
						object obj9 = r3[2];
						if (!(obj9 is string))
						{
							obj9 = RuntimeServices.Coerce(obj9, typeof(string));
						}
						text3 = (string)obj9;
					}
					if (i == 3)
					{
						object obj10 = r4[0];
						if (!(obj10 is string))
						{
							obj10 = RuntimeServices.Coerce(obj10, typeof(string));
						}
						text = (string)obj10;
						object obj11 = r4[1];
						if (!(obj11 is string))
						{
							obj11 = RuntimeServices.Coerce(obj11, typeof(string));
						}
						text2 = (string)obj11;
						object obj12 = r4[2];
						if (!(obj12 is string))
						{
							obj12 = RuntimeServices.Coerce(obj12, typeof(string));
						}
						text3 = (string)obj12;
					}
					if (i == 4)
					{
						object obj13 = r5[0];
						if (!(obj13 is string))
						{
							obj13 = RuntimeServices.Coerce(obj13, typeof(string));
						}
						text = (string)obj13;
						object obj14 = r5[1];
						if (!(obj14 is string))
						{
							obj14 = RuntimeServices.Coerce(obj14, typeof(string));
						}
						text2 = (string)obj14;
						object obj15 = r5[2];
						if (!(obj15 is string))
						{
							obj15 = RuntimeServices.Coerce(obj15, typeof(string));
						}
						text3 = (string)obj15;
					}
					if (i == 5)
					{
						object obj16 = r6[0];
						if (!(obj16 is string))
						{
							obj16 = RuntimeServices.Coerce(obj16, typeof(string));
						}
						text = (string)obj16;
						object obj17 = r6[1];
						if (!(obj17 is string))
						{
							obj17 = RuntimeServices.Coerce(obj17, typeof(string));
						}
						text2 = (string)obj17;
						object obj18 = r6[2];
						if (!(obj18 is string))
						{
							obj18 = RuntimeServices.Coerce(obj18, typeof(string));
						}
						text3 = (string)obj18;
					}
					if (i == 6)
					{
						object obj19 = r7[0];
						if (!(obj19 is string))
						{
							obj19 = RuntimeServices.Coerce(obj19, typeof(string));
						}
						text = (string)obj19;
						object obj20 = r7[1];
						if (!(obj20 is string))
						{
							obj20 = RuntimeServices.Coerce(obj20, typeof(string));
						}
						text2 = (string)obj20;
						object obj21 = r7[2];
						if (!(obj21 is string))
						{
							obj21 = RuntimeServices.Coerce(obj21, typeof(string));
						}
						text3 = (string)obj21;
					}
					if (i == 7)
					{
						object obj22 = r8[0];
						if (!(obj22 is string))
						{
							obj22 = RuntimeServices.Coerce(obj22, typeof(string));
						}
						text = (string)obj22;
						object obj23 = r8[1];
						if (!(obj23 is string))
						{
							obj23 = RuntimeServices.Coerce(obj23, typeof(string));
						}
						text2 = (string)obj23;
						object obj24 = r8[2];
						if (!(obj24 is string))
						{
							obj24 = RuntimeServices.Coerce(obj24, typeof(string));
						}
						text3 = (string)obj24;
					}
					if (i == 8)
					{
						object obj25 = r9[0];
						if (!(obj25 is string))
						{
							obj25 = RuntimeServices.Coerce(obj25, typeof(string));
						}
						text = (string)obj25;
						object obj26 = r9[1];
						if (!(obj26 is string))
						{
							obj26 = RuntimeServices.Coerce(obj26, typeof(string));
						}
						text2 = (string)obj26;
						object obj27 = r9[2];
						if (!(obj27 is string))
						{
							obj27 = RuntimeServices.Coerce(obj27, typeof(string));
						}
						text3 = (string)obj27;
					}
					if (i == 9)
					{
						object obj28 = r10[0];
						if (!(obj28 is string))
						{
							obj28 = RuntimeServices.Coerce(obj28, typeof(string));
						}
						text = (string)obj28;
						object obj29 = r10[1];
						if (!(obj29 is string))
						{
							obj29 = RuntimeServices.Coerce(obj29, typeof(string));
						}
						text2 = (string)obj29;
						object obj30 = r10[2];
						if (!(obj30 is string))
						{
							obj30 = RuntimeServices.Coerce(obj30, typeof(string));
						}
						text3 = (string)obj30;
					}
					text2 = text2.ToString();
					text3 = text3.ToString();
					GUI.Label(new Rect(60f, num5, 325f, 25f), text, playertxt);
					GUI.Label(new Rect(188f, num5, 325f, 25f), text2, playertxt);
					GUI.Label(new Rect(240f, num5, 325f, 25f), text3, playertxt);
					if (text != "--" && GUI.Button(new Rect(270f, num5 + 2, 70f, 21f), (!checkIfFriend(text)) ? "Friend" : "Unfriend", buttonstyle))
					{
						StartCoroutine_Auto(addFriend(text));
					}
					num5 += 25;
				}
			}
			if (AuthGameObject.gametype != "Freeplay" && AuthGameObject.gametype != "Deathmatch" && AuthGameObject.gametype != "Survival")
			{
				GUI.Label(new Rect(12f, 205f, 350f, 15f), "Username\t\t\t\t\tKills\t\tDeaths\t\t\t", txtstyle);
				GUI.color = redcolor;
				float a6 = alpha;
				Color color16 = GUI.color;
				float num8 = (color16.a = a6);
				Color color17 = (GUI.color = color16);
				GUI.Label(new Rect(75f, 35f, 20f, 20f), "Top Red Players", titletxt);
				GUI.color = bluecolor;
				float a7 = alpha;
				Color color19 = GUI.color;
				float num9 = (color19.a = a7);
				Color color20 = (GUI.color = color19);
				GUI.Label(new Rect(75f, 185f, 20f, 20f), "Top Blue Players", titletxt);
				GUI.color = Color.white;
				float a8 = alpha;
				Color color22 = GUI.color;
				float num10 = (color22.a = a8);
				Color color23 = (GUI.color = color22);
				int num5 = 70;
				bool flag = true;
				for (int i = 0; i < 5; i++)
				{
					if (flag)
					{
						flag = false;
						float a9 = 0.3f * alpha;
						Color color25 = GUI.color;
						float num11 = (color25.a = a9);
						Color color26 = (GUI.color = color25);
						GUI.DrawTexture(new Rect(6f, num5 + 2, 338f, 20f), redback);
					}
					else
					{
						flag = true;
					}
					float a10 = alpha;
					Color color28 = GUI.color;
					float num12 = (color28.a = a10);
					Color color29 = (GUI.color = color28);
					GUI.Label(new Rect(30f, num5, 325f, 25f), "#" + (i + 1).ToString(), playertxt);
					string text = "--";
					string text2 = "--";
					string text3 = "--";
					if (i == 0)
					{
						object obj31 = r1[0];
						if (!(obj31 is string))
						{
							obj31 = RuntimeServices.Coerce(obj31, typeof(string));
						}
						text = (string)obj31;
						object obj32 = r1[1];
						if (!(obj32 is string))
						{
							obj32 = RuntimeServices.Coerce(obj32, typeof(string));
						}
						text2 = (string)obj32;
						object obj33 = r1[2];
						if (!(obj33 is string))
						{
							obj33 = RuntimeServices.Coerce(obj33, typeof(string));
						}
						text3 = (string)obj33;
					}
					if (i == 1)
					{
						object obj34 = r2[0];
						if (!(obj34 is string))
						{
							obj34 = RuntimeServices.Coerce(obj34, typeof(string));
						}
						text = (string)obj34;
						object obj35 = r2[1];
						if (!(obj35 is string))
						{
							obj35 = RuntimeServices.Coerce(obj35, typeof(string));
						}
						text2 = (string)obj35;
						object obj36 = r2[2];
						if (!(obj36 is string))
						{
							obj36 = RuntimeServices.Coerce(obj36, typeof(string));
						}
						text3 = (string)obj36;
					}
					if (i == 2)
					{
						object obj37 = r3[0];
						if (!(obj37 is string))
						{
							obj37 = RuntimeServices.Coerce(obj37, typeof(string));
						}
						text = (string)obj37;
						object obj38 = r3[1];
						if (!(obj38 is string))
						{
							obj38 = RuntimeServices.Coerce(obj38, typeof(string));
						}
						text2 = (string)obj38;
						object obj39 = r3[2];
						if (!(obj39 is string))
						{
							obj39 = RuntimeServices.Coerce(obj39, typeof(string));
						}
						text3 = (string)obj39;
					}
					if (i == 3)
					{
						object obj40 = r4[0];
						if (!(obj40 is string))
						{
							obj40 = RuntimeServices.Coerce(obj40, typeof(string));
						}
						text = (string)obj40;
						object obj41 = r4[1];
						if (!(obj41 is string))
						{
							obj41 = RuntimeServices.Coerce(obj41, typeof(string));
						}
						text2 = (string)obj41;
						object obj42 = r4[2];
						if (!(obj42 is string))
						{
							obj42 = RuntimeServices.Coerce(obj42, typeof(string));
						}
						text3 = (string)obj42;
					}
					if (i == 4)
					{
						object obj43 = r5[0];
						if (!(obj43 is string))
						{
							obj43 = RuntimeServices.Coerce(obj43, typeof(string));
						}
						text = (string)obj43;
						object obj44 = r5[1];
						if (!(obj44 is string))
						{
							obj44 = RuntimeServices.Coerce(obj44, typeof(string));
						}
						text2 = (string)obj44;
						object obj45 = r5[2];
						if (!(obj45 is string))
						{
							obj45 = RuntimeServices.Coerce(obj45, typeof(string));
						}
						text3 = (string)obj45;
					}
					text2 = text2.ToString();
					text3 = text3.ToString();
					GUI.Label(new Rect(60f, num5, 325f, 25f), text, playertxt);
					GUI.Label(new Rect(188f, num5, 325f, 25f), text2, playertxt);
					GUI.Label(new Rect(240f, num5, 325f, 25f), text3, playertxt);
					if (text != "--" && GUI.Button(new Rect(270f, num5 + 2, 70f, 21f), (!checkIfFriend(text)) ? "Friend" : "Unfriend", buttonstyle))
					{
						StartCoroutine_Auto(addFriend(text));
					}
					num5 += 20;
				}
				num5 = 220;
				flag = true;
				for (int i = 0; i < 5; i++)
				{
					if (flag)
					{
						flag = false;
						float a11 = 0.3f * alpha;
						Color color31 = GUI.color;
						float num13 = (color31.a = a11);
						Color color32 = (GUI.color = color31);
						GUI.DrawTexture(new Rect(6f, num5 + 2, 338f, 20f), blueback);
					}
					else
					{
						flag = true;
					}
					float a12 = alpha;
					Color color34 = GUI.color;
					float num14 = (color34.a = a12);
					Color color35 = (GUI.color = color34);
					GUI.Label(new Rect(30f, num5, 325f, 25f), "#" + (i + 1).ToString(), playertxt);
					string text = "--";
					string text2 = "--";
					string text3 = "--";
					if (i == 0)
					{
						object obj46 = b1[0];
						if (!(obj46 is string))
						{
							obj46 = RuntimeServices.Coerce(obj46, typeof(string));
						}
						text = (string)obj46;
						object obj47 = b1[1];
						if (!(obj47 is string))
						{
							obj47 = RuntimeServices.Coerce(obj47, typeof(string));
						}
						text2 = (string)obj47;
						object obj48 = b1[2];
						if (!(obj48 is string))
						{
							obj48 = RuntimeServices.Coerce(obj48, typeof(string));
						}
						text3 = (string)obj48;
					}
					if (i == 1)
					{
						object obj49 = b2[0];
						if (!(obj49 is string))
						{
							obj49 = RuntimeServices.Coerce(obj49, typeof(string));
						}
						text = (string)obj49;
						object obj50 = b2[1];
						if (!(obj50 is string))
						{
							obj50 = RuntimeServices.Coerce(obj50, typeof(string));
						}
						text2 = (string)obj50;
						object obj51 = b2[2];
						if (!(obj51 is string))
						{
							obj51 = RuntimeServices.Coerce(obj51, typeof(string));
						}
						text3 = (string)obj51;
					}
					if (i == 2)
					{
						object obj52 = b3[0];
						if (!(obj52 is string))
						{
							obj52 = RuntimeServices.Coerce(obj52, typeof(string));
						}
						text = (string)obj52;
						object obj53 = b3[1];
						if (!(obj53 is string))
						{
							obj53 = RuntimeServices.Coerce(obj53, typeof(string));
						}
						text2 = (string)obj53;
						object obj54 = b3[2];
						if (!(obj54 is string))
						{
							obj54 = RuntimeServices.Coerce(obj54, typeof(string));
						}
						text3 = (string)obj54;
					}
					if (i == 3)
					{
						object obj55 = b4[0];
						if (!(obj55 is string))
						{
							obj55 = RuntimeServices.Coerce(obj55, typeof(string));
						}
						text = (string)obj55;
						object obj56 = b4[1];
						if (!(obj56 is string))
						{
							obj56 = RuntimeServices.Coerce(obj56, typeof(string));
						}
						text2 = (string)obj56;
						object obj57 = b4[2];
						if (!(obj57 is string))
						{
							obj57 = RuntimeServices.Coerce(obj57, typeof(string));
						}
						text3 = (string)obj57;
					}
					if (i == 4)
					{
						object obj58 = b5[0];
						if (!(obj58 is string))
						{
							obj58 = RuntimeServices.Coerce(obj58, typeof(string));
						}
						text = (string)obj58;
						object obj59 = b5[1];
						if (!(obj59 is string))
						{
							obj59 = RuntimeServices.Coerce(obj59, typeof(string));
						}
						text2 = (string)obj59;
						object obj60 = b5[2];
						if (!(obj60 is string))
						{
							obj60 = RuntimeServices.Coerce(obj60, typeof(string));
						}
						text3 = (string)obj60;
					}
					text2 = text2.ToString();
					text3 = text3.ToString();
					GUI.Label(new Rect(60f, num5, 325f, 25f), text, playertxt);
					GUI.Label(new Rect(188f, num5, 325f, 25f), text2, playertxt);
					GUI.Label(new Rect(240f, num5, 325f, 25f), text3, playertxt);
					if (text != "--" && GUI.Button(new Rect(270f, num5 + 2, 70f, 21f), (!checkIfFriend(text)) ? "Friend" : "Unfriend", buttonstyle))
					{
						StartCoroutine_Auto(addFriend(text));
					}
					num5 += 20;
				}
			}
			if (GUIActive)
			{
				GUI.Label(new Rect(25f, 340f, 195f, 15f), "Starting next round in " + Mathf.Round(nxtround) + " second(s)", txtstyle);
			}
			GUI.EndGroup();
			return;
		}
		float a13 = alphatab;
		Color color37 = GUI.color;
		float num15 = (color37.a = a13);
		Color color38 = (GUI.color = color37);
		if (alphatab <= 0f)
		{
			return;
		}
		num2 = 0;
		GUI.BeginGroup(new Rect(Screen.width / 2 - 175, Screen.height / 2 - 187 + num2, 350f, 375f));
		GUI.Box(new Rect(0f, 0f, 350f, 375f), "Battle Summary", mainskin);
		GUI.Label(new Rect(12f, 55f, 350f, 15f), "Username\t\t\t\t\tKills\t\tDeaths\t\t\t", txtstyle);
		if (AuthGameObject.gametype == "Freeplay" || AuthGameObject.gametype == "Deathmatch" || AuthGameObject.gametype == "Survival")
		{
			GUI.color = nocolor;
			float a14 = alphatab;
			Color color40 = GUI.color;
			float num16 = (color40.a = a14);
			Color color41 = (GUI.color = color40);
			GUI.Label(new Rect(75f, 35f, 20f, 20f), "All Players", titletxt);
			GUI.color = Color.white;
			float a15 = alphatab;
			Color color43 = GUI.color;
			float num17 = (color43.a = a15);
			Color color44 = (GUI.color = color43);
			int num5 = 70;
			bool flag = true;
			for (int i = 0; i < 10; i++)
			{
				if (flag)
				{
					flag = false;
					float a16 = 0.7f * alphatab;
					Color color46 = GUI.color;
					float num18 = (color46.a = a16);
					Color color47 = (GUI.color = color46);
					GUI.DrawTexture(new Rect(6f, num5 + 2, 338f, 25f), noback);
				}
				else
				{
					flag = true;
				}
				float a17 = alphatab;
				Color color49 = GUI.color;
				float num19 = (color49.a = a17);
				Color color50 = (GUI.color = color49);
				GUI.Label(new Rect(30f, num5, 325f, 30f), "#" + (i + 1).ToString(), playertxt);
				string text = "--";
				string text2 = "--";
				string text3 = "--";
				if (i == 0)
				{
					object obj61 = r1[0];
					if (!(obj61 is string))
					{
						obj61 = RuntimeServices.Coerce(obj61, typeof(string));
					}
					text = (string)obj61;
					object obj62 = r1[1];
					if (!(obj62 is string))
					{
						obj62 = RuntimeServices.Coerce(obj62, typeof(string));
					}
					text2 = (string)obj62;
					object obj63 = r1[2];
					if (!(obj63 is string))
					{
						obj63 = RuntimeServices.Coerce(obj63, typeof(string));
					}
					text3 = (string)obj63;
				}
				if (i == 1)
				{
					object obj64 = r2[0];
					if (!(obj64 is string))
					{
						obj64 = RuntimeServices.Coerce(obj64, typeof(string));
					}
					text = (string)obj64;
					object obj65 = r2[1];
					if (!(obj65 is string))
					{
						obj65 = RuntimeServices.Coerce(obj65, typeof(string));
					}
					text2 = (string)obj65;
					object obj66 = r2[2];
					if (!(obj66 is string))
					{
						obj66 = RuntimeServices.Coerce(obj66, typeof(string));
					}
					text3 = (string)obj66;
				}
				if (i == 2)
				{
					object obj67 = r3[0];
					if (!(obj67 is string))
					{
						obj67 = RuntimeServices.Coerce(obj67, typeof(string));
					}
					text = (string)obj67;
					object obj68 = r3[1];
					if (!(obj68 is string))
					{
						obj68 = RuntimeServices.Coerce(obj68, typeof(string));
					}
					text2 = (string)obj68;
					object obj69 = r3[2];
					if (!(obj69 is string))
					{
						obj69 = RuntimeServices.Coerce(obj69, typeof(string));
					}
					text3 = (string)obj69;
				}
				if (i == 3)
				{
					object obj70 = r4[0];
					if (!(obj70 is string))
					{
						obj70 = RuntimeServices.Coerce(obj70, typeof(string));
					}
					text = (string)obj70;
					object obj71 = r4[1];
					if (!(obj71 is string))
					{
						obj71 = RuntimeServices.Coerce(obj71, typeof(string));
					}
					text2 = (string)obj71;
					object obj72 = r4[2];
					if (!(obj72 is string))
					{
						obj72 = RuntimeServices.Coerce(obj72, typeof(string));
					}
					text3 = (string)obj72;
				}
				if (i == 4)
				{
					object obj73 = r5[0];
					if (!(obj73 is string))
					{
						obj73 = RuntimeServices.Coerce(obj73, typeof(string));
					}
					text = (string)obj73;
					object obj74 = r5[1];
					if (!(obj74 is string))
					{
						obj74 = RuntimeServices.Coerce(obj74, typeof(string));
					}
					text2 = (string)obj74;
					object obj75 = r5[2];
					if (!(obj75 is string))
					{
						obj75 = RuntimeServices.Coerce(obj75, typeof(string));
					}
					text3 = (string)obj75;
				}
				if (i == 5)
				{
					object obj76 = r6[0];
					if (!(obj76 is string))
					{
						obj76 = RuntimeServices.Coerce(obj76, typeof(string));
					}
					text = (string)obj76;
					object obj77 = r6[1];
					if (!(obj77 is string))
					{
						obj77 = RuntimeServices.Coerce(obj77, typeof(string));
					}
					text2 = (string)obj77;
					object obj78 = r6[2];
					if (!(obj78 is string))
					{
						obj78 = RuntimeServices.Coerce(obj78, typeof(string));
					}
					text3 = (string)obj78;
				}
				if (i == 6)
				{
					object obj79 = r7[0];
					if (!(obj79 is string))
					{
						obj79 = RuntimeServices.Coerce(obj79, typeof(string));
					}
					text = (string)obj79;
					object obj80 = r7[1];
					if (!(obj80 is string))
					{
						obj80 = RuntimeServices.Coerce(obj80, typeof(string));
					}
					text2 = (string)obj80;
					object obj81 = r7[2];
					if (!(obj81 is string))
					{
						obj81 = RuntimeServices.Coerce(obj81, typeof(string));
					}
					text3 = (string)obj81;
				}
				if (i == 7)
				{
					object obj82 = r8[0];
					if (!(obj82 is string))
					{
						obj82 = RuntimeServices.Coerce(obj82, typeof(string));
					}
					text = (string)obj82;
					object obj83 = r8[1];
					if (!(obj83 is string))
					{
						obj83 = RuntimeServices.Coerce(obj83, typeof(string));
					}
					text2 = (string)obj83;
					object obj84 = r8[2];
					if (!(obj84 is string))
					{
						obj84 = RuntimeServices.Coerce(obj84, typeof(string));
					}
					text3 = (string)obj84;
				}
				if (i == 8)
				{
					object obj85 = r9[0];
					if (!(obj85 is string))
					{
						obj85 = RuntimeServices.Coerce(obj85, typeof(string));
					}
					text = (string)obj85;
					object obj86 = r9[1];
					if (!(obj86 is string))
					{
						obj86 = RuntimeServices.Coerce(obj86, typeof(string));
					}
					text2 = (string)obj86;
					object obj87 = r9[2];
					if (!(obj87 is string))
					{
						obj87 = RuntimeServices.Coerce(obj87, typeof(string));
					}
					text3 = (string)obj87;
				}
				if (i == 9)
				{
					object obj88 = r10[0];
					if (!(obj88 is string))
					{
						obj88 = RuntimeServices.Coerce(obj88, typeof(string));
					}
					text = (string)obj88;
					object obj89 = r10[1];
					if (!(obj89 is string))
					{
						obj89 = RuntimeServices.Coerce(obj89, typeof(string));
					}
					text2 = (string)obj89;
					object obj90 = r10[2];
					if (!(obj90 is string))
					{
						obj90 = RuntimeServices.Coerce(obj90, typeof(string));
					}
					text3 = (string)obj90;
				}
				text2 = text2.ToString();
				text3 = text3.ToString();
				GUI.Label(new Rect(60f, num5, 325f, 25f), text, playertxt);
				GUI.Label(new Rect(188f, num5, 325f, 25f), text2, playertxt);
				GUI.Label(new Rect(240f, num5, 325f, 25f), text3, playertxt);
				if (text != "--" && GUI.Button(new Rect(270f, num5 + 2, 70f, 21f), (!checkIfFriend(text)) ? "Friend" : "Unfriend", buttonstyle))
				{
					StartCoroutine_Auto(addFriend(text));
				}
				num5 += 25;
			}
		}
		if (AuthGameObject.gametype != "Freeplay" && AuthGameObject.gametype != "Deathmatch" && AuthGameObject.gametype != "Survival")
		{
			GUI.Label(new Rect(12f, 205f, 350f, 15f), "Username\t\t\t\t\tKills\t\tDeaths\t\t\t", txtstyle);
			GUI.color = redcolor;
			float a18 = alphatab;
			Color color52 = GUI.color;
			float num20 = (color52.a = a18);
			Color color53 = (GUI.color = color52);
			GUI.Label(new Rect(75f, 35f, 20f, 20f), "Top Red Players", titletxt);
			GUI.color = bluecolor;
			float a19 = alphatab;
			Color color55 = GUI.color;
			float num21 = (color55.a = a19);
			Color color56 = (GUI.color = color55);
			GUI.Label(new Rect(75f, 185f, 20f, 20f), "Top Blue Players", titletxt);
			GUI.color = Color.white;
			float a20 = alphatab;
			Color color58 = GUI.color;
			float num22 = (color58.a = a20);
			Color color59 = (GUI.color = color58);
			int num5 = 70;
			bool flag = true;
			for (int i = 0; i < 5; i++)
			{
				if (flag)
				{
					flag = false;
					float a21 = 0.3f * alphatab;
					Color color61 = GUI.color;
					float num23 = (color61.a = a21);
					Color color62 = (GUI.color = color61);
					GUI.DrawTexture(new Rect(6f, num5 + 2, 338f, 20f), redback);
				}
				else
				{
					flag = true;
				}
				float a22 = alphatab;
				Color color64 = GUI.color;
				float num24 = (color64.a = a22);
				Color color65 = (GUI.color = color64);
				GUI.Label(new Rect(30f, num5, 325f, 25f), "#" + (i + 1).ToString(), playertxt);
				string text = "--";
				string text2 = "--";
				string text3 = "--";
				if (i == 0)
				{
					object obj91 = r1[0];
					if (!(obj91 is string))
					{
						obj91 = RuntimeServices.Coerce(obj91, typeof(string));
					}
					text = (string)obj91;
					object obj92 = r1[1];
					if (!(obj92 is string))
					{
						obj92 = RuntimeServices.Coerce(obj92, typeof(string));
					}
					text2 = (string)obj92;
					object obj93 = r1[2];
					if (!(obj93 is string))
					{
						obj93 = RuntimeServices.Coerce(obj93, typeof(string));
					}
					text3 = (string)obj93;
				}
				if (i == 1)
				{
					object obj94 = r2[0];
					if (!(obj94 is string))
					{
						obj94 = RuntimeServices.Coerce(obj94, typeof(string));
					}
					text = (string)obj94;
					object obj95 = r2[1];
					if (!(obj95 is string))
					{
						obj95 = RuntimeServices.Coerce(obj95, typeof(string));
					}
					text2 = (string)obj95;
					object obj96 = r2[2];
					if (!(obj96 is string))
					{
						obj96 = RuntimeServices.Coerce(obj96, typeof(string));
					}
					text3 = (string)obj96;
				}
				if (i == 2)
				{
					object obj97 = r3[0];
					if (!(obj97 is string))
					{
						obj97 = RuntimeServices.Coerce(obj97, typeof(string));
					}
					text = (string)obj97;
					object obj98 = r3[1];
					if (!(obj98 is string))
					{
						obj98 = RuntimeServices.Coerce(obj98, typeof(string));
					}
					text2 = (string)obj98;
					object obj99 = r3[2];
					if (!(obj99 is string))
					{
						obj99 = RuntimeServices.Coerce(obj99, typeof(string));
					}
					text3 = (string)obj99;
				}
				if (i == 3)
				{
					object obj100 = r4[0];
					if (!(obj100 is string))
					{
						obj100 = RuntimeServices.Coerce(obj100, typeof(string));
					}
					text = (string)obj100;
					object obj101 = r4[1];
					if (!(obj101 is string))
					{
						obj101 = RuntimeServices.Coerce(obj101, typeof(string));
					}
					text2 = (string)obj101;
					object obj102 = r4[2];
					if (!(obj102 is string))
					{
						obj102 = RuntimeServices.Coerce(obj102, typeof(string));
					}
					text3 = (string)obj102;
				}
				if (i == 4)
				{
					object obj103 = r5[0];
					if (!(obj103 is string))
					{
						obj103 = RuntimeServices.Coerce(obj103, typeof(string));
					}
					text = (string)obj103;
					object obj104 = r5[1];
					if (!(obj104 is string))
					{
						obj104 = RuntimeServices.Coerce(obj104, typeof(string));
					}
					text2 = (string)obj104;
					object obj105 = r5[2];
					if (!(obj105 is string))
					{
						obj105 = RuntimeServices.Coerce(obj105, typeof(string));
					}
					text3 = (string)obj105;
				}
				text2 = text2.ToString();
				text3 = text3.ToString();
				GUI.Label(new Rect(60f, num5, 325f, 25f), text, playertxt);
				GUI.Label(new Rect(188f, num5, 325f, 25f), text2, playertxt);
				GUI.Label(new Rect(240f, num5, 325f, 25f), text3, playertxt);
				if (text != "--" && GUI.Button(new Rect(270f, num5 + 2, 70f, 21f), (!checkIfFriend(text)) ? "Friend" : "Unfriend", buttonstyle))
				{
					StartCoroutine_Auto(addFriend(text));
				}
				num5 += 20;
			}
			num5 = 220;
			flag = true;
			for (int i = 0; i < 5; i++)
			{
				if (flag)
				{
					flag = false;
					float a23 = 0.3f * alphatab;
					Color color67 = GUI.color;
					float num25 = (color67.a = a23);
					Color color68 = (GUI.color = color67);
					GUI.DrawTexture(new Rect(6f, num5 + 2, 338f, 20f), blueback);
				}
				else
				{
					flag = true;
				}
				float a24 = alphatab;
				Color color70 = GUI.color;
				float num26 = (color70.a = a24);
				Color color71 = (GUI.color = color70);
				GUI.Label(new Rect(30f, num5, 325f, 25f), "#" + (i + 1).ToString(), playertxt);
				string text = "--";
				string text2 = "--";
				string text3 = "--";
				if (i == 0)
				{
					object obj106 = b1[0];
					if (!(obj106 is string))
					{
						obj106 = RuntimeServices.Coerce(obj106, typeof(string));
					}
					text = (string)obj106;
					object obj107 = b1[1];
					if (!(obj107 is string))
					{
						obj107 = RuntimeServices.Coerce(obj107, typeof(string));
					}
					text2 = (string)obj107;
					object obj108 = b1[2];
					if (!(obj108 is string))
					{
						obj108 = RuntimeServices.Coerce(obj108, typeof(string));
					}
					text3 = (string)obj108;
				}
				if (i == 1)
				{
					object obj109 = b2[0];
					if (!(obj109 is string))
					{
						obj109 = RuntimeServices.Coerce(obj109, typeof(string));
					}
					text = (string)obj109;
					object obj110 = b2[1];
					if (!(obj110 is string))
					{
						obj110 = RuntimeServices.Coerce(obj110, typeof(string));
					}
					text2 = (string)obj110;
					object obj111 = b2[2];
					if (!(obj111 is string))
					{
						obj111 = RuntimeServices.Coerce(obj111, typeof(string));
					}
					text3 = (string)obj111;
				}
				if (i == 2)
				{
					object obj112 = b3[0];
					if (!(obj112 is string))
					{
						obj112 = RuntimeServices.Coerce(obj112, typeof(string));
					}
					text = (string)obj112;
					object obj113 = b3[1];
					if (!(obj113 is string))
					{
						obj113 = RuntimeServices.Coerce(obj113, typeof(string));
					}
					text2 = (string)obj113;
					object obj114 = b3[2];
					if (!(obj114 is string))
					{
						obj114 = RuntimeServices.Coerce(obj114, typeof(string));
					}
					text3 = (string)obj114;
				}
				if (i == 3)
				{
					object obj115 = b4[0];
					if (!(obj115 is string))
					{
						obj115 = RuntimeServices.Coerce(obj115, typeof(string));
					}
					text = (string)obj115;
					object obj116 = b4[1];
					if (!(obj116 is string))
					{
						obj116 = RuntimeServices.Coerce(obj116, typeof(string));
					}
					text2 = (string)obj116;
					object obj117 = b4[2];
					if (!(obj117 is string))
					{
						obj117 = RuntimeServices.Coerce(obj117, typeof(string));
					}
					text3 = (string)obj117;
				}
				if (i == 4)
				{
					object obj118 = b5[0];
					if (!(obj118 is string))
					{
						obj118 = RuntimeServices.Coerce(obj118, typeof(string));
					}
					text = (string)obj118;
					object obj119 = b5[1];
					if (!(obj119 is string))
					{
						obj119 = RuntimeServices.Coerce(obj119, typeof(string));
					}
					text2 = (string)obj119;
					object obj120 = b5[2];
					if (!(obj120 is string))
					{
						obj120 = RuntimeServices.Coerce(obj120, typeof(string));
					}
					text3 = (string)obj120;
				}
				text2 = text2.ToString();
				text3 = text3.ToString();
				GUI.Label(new Rect(60f, num5, 325f, 25f), text, playertxt);
				GUI.Label(new Rect(188f, num5, 325f, 25f), text2, playertxt);
				GUI.Label(new Rect(240f, num5, 325f, 25f), text3, playertxt);
				if (text != "--" && GUI.Button(new Rect(270f, num5 + 2, 70f, 21f), (!checkIfFriend(text)) ? "Friend" : "Unfriend", buttonstyle))
				{
					StartCoroutine_Auto(addFriend(text));
				}
				num5 += 20;
			}
		}
		if (GUIActive)
		{
			GUI.Label(new Rect(25f, 340f, 195f, 15f), "Starting next round in " + Mathf.Round(nxtround) + " second(s)", txtstyle);
		}
		else
		{
			GUI.Label(new Rect(25f, 340f, 195f, 15f), "\t  Press [tab] again to close this window.", txtstyle);
		}
		GUI.EndGroup();
	}

	public virtual bool checkIfFriend(string u)
	{
		bool result = false;
		IEnumerator enumerator = UnityRuntimeServices.GetEnumerator(AuthGameObject.friendsArr);
		while (enumerator.MoveNext())
		{
			object obj = enumerator.Current;
			if (!(obj is Friend))
			{
				obj = RuntimeServices.Coerce(obj, typeof(Friend));
			}
			Friend friend = (Friend)obj;
			if (friend.username == u)
			{
				result = true;
			}
		}
		return result;
	}

	public virtual IEnumerator addFriend(string u)
	{
		return new _0024addFriend_00243809(u, this).GetEnumerator();
	}

	public virtual void Main()
	{
	}
}
