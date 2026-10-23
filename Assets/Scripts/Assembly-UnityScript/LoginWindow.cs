using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Boo.Lang;
using Boo.Lang.Runtime;
using Photon;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class LoginWindow : Photon.MonoBehaviour
{
	[Serializable]
	internal sealed class _0024fadein_00244760 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal LoginWindow _0024self__00244761;

			public _0024(LoginWindow self_)
			{
				_0024self__00244761 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__00244761.alpha < 1f)
					{
						_0024self__00244761.alpha += 4f * Time.deltaTime;
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024self__00244761.alpha = 1f;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal LoginWindow _0024self__00244762;

		public _0024fadein_00244760(LoginWindow self_)
		{
			_0024self__00244762 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00244762);
		}
	}

	[Serializable]
	internal sealed class _0024fadeOut_00244763 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal bool _0024hasname_00244764;

			internal string _0024uname_00244765;

			internal WWW _0024submitUser_00244766;

			internal int _0024randomnumber_00244767;

			internal WWW _0024rankings_00244768;

			internal WWW _0024getKey_00244769;

			internal int _0024countertimeout_00244770;

			internal WWW _0024inventory_00244771;

			internal WWW _0024rentarr_00244772;

			internal UnityScript.Lang.Array _0024renttemp_00244773;

			internal UnityScript.Lang.Array _0024temparr_00244774;

			internal string[] _0024tokenarr_00244775;

			internal string[] _0024hashgold_00244776;

			internal string _0024temphash_00244777;

			internal int _0024i_00244778;

			internal string _0024finalhash_00244779;

			internal bool _0024firstone_00244780;

			internal string _0024str_00244781;

			internal string[] _0024goldarr_00244782;

			internal string _0024escaped_00244783;

			internal WWW _0024bitem_00244784;

			internal string _0024str_00244785;

			internal UnityScript.Lang.Array _0024guestinventory_00244786;

			internal int _0024_00241212_00244787;

			internal string[] _0024_00241213_00244788;

			internal int _0024_00241214_00244789;

			internal int _0024_00241216_00244790;

			internal string[] _0024_00241217_00244791;

			internal int _0024_00241218_00244792;

			internal int _0024_00241220_00244793;

			internal string[] _0024_00241221_00244794;

			internal int _0024_00241222_00244795;

			internal LoginWindow _0024self__00244796;

			public _0024(LoginWindow self_)
			{
				_0024self__00244796 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					Camera.main.SendMessage("showStatus", "Loading Game Store...");
					GameObject.Find("AuthGameObject").SendMessage("grabAch");
					_0024hasname_00244764 = false;
					_0024_00241212_00244787 = 0;
					_0024_00241213_00244788 = PlayerPrefs.GetString("alias", string.Empty).Split("|"[0]);
					for (_0024_00241214_00244789 = _0024_00241213_00244788.Length; _0024_00241212_00244787 < _0024_00241214_00244789; _0024_00241212_00244787++)
					{
						if (_0024_00241213_00244788[_0024_00241212_00244787] == AuthGameObject.username)
						{
							_0024hasname_00244764 = true;
						}
					}
					if (!_0024hasname_00244764)
					{
						PlayerPrefs.SetString("alias", PlayerPrefs.GetString("alias") + AuthGameObject.username + "|");
					}
					PhotonNetwork.playerName = ((!(AuthGameObject.username == "CarbonTech") && !(AuthGameObject.username == "nattyfrank") && !(AuthGameObject.username == "techietotoro") && !(AuthGameObject.username == "Apophis") && !(AuthGameObject.username == "Nattyfrank") && !(AuthGameObject.username == "TheGoodGuy")) ? string.Empty : "[mod] ") + AuthGameObject.username;
					if (AuthGameObject.username == string.Empty)
					{
						if (_0024self__00244796.iskong)
						{
							if (KongregateAPI.loggedin && KongregateAPI.username != "Guest")
							{
								username = KongregateAPI.username;
								AuthGameObject.username = KongregateAPI.username;
							}
							else
							{
								_0024self__00244796.makeguestglitch();
							}
						}
						else
						{
							_0024self__00244796.makeguestglitch();
						}
						logincookie = true;
					}
					goto case 2;
				case 2:
					if (_0024self__00244796.alpha > 0f)
					{
						_0024self__00244796.alpha -= 4f * Time.deltaTime;
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024self__00244796.alpha = 0f;
					pubalpha = _0024self__00244796.alpha;
					if (!AuthGameObject.username.Contains("guest_"))
					{
						_0024submitUser_00244766 = new WWW("http://72.14.184.180/storeInterface.php?username=" + AuthGameObject.username + "&request=checkforuser&type=newsystem");
						result = (Yield(3, _0024submitUser_00244766) ? 1 : 0);
						break;
					}
					_0024guestinventory_00244786 = new UnityScript.Lang.Array("0", "guest", "0#3#7#false-false#false#0#49", "false", "false", "false", "false", "false", "false", "false", "false", "false", "false", "false", "false", "false", "false", "false");
					AuthGameObject.inventory = (string[])_0024guestinventory_00244786.ToBuiltin(typeof(string));
					AuthGameObject.shop = false;
					AuthGameObject.shopfailed = false;
					Camera.main.SendMessage("hideStatus");
					goto IL_180c;
				case 3:
					_0024randomnumber_00244767 = UnityEngine.Random.Range(0, 99999);
					_0024rankings_00244768 = new WWW("http://72.14.184.180/rankingsManager.php?request=submit&key=" + Md5Sum.ComputeMd5(global::DontDestroyOnLoad.hitcollider + _0024randomnumber_00244767.ToString()) + "&user=" + AuthGameObject.username + "&score=0&random=" + _0024randomnumber_00244767.ToString());
					result = (Yield(4, _0024rankings_00244768) ? 1 : 0);
					break;
				case 4:
					if (_0024submitUser_00244766.text == "User created." || _0024submitUser_00244766.text.Contains("User exists."))
					{
						goto case 6;
					}
					_0024submitUser_00244766 = new WWW("http://72.14.184.180/storeInterface.php?username=" + AuthGameObject.username + "&request=checkforuser&type=newsystem");
					result = (Yield(5, _0024submitUser_00244766) ? 1 : 0);
					break;
				case 5:
					if (_0024submitUser_00244766.text == "User created." || _0024submitUser_00244766.text.Contains("User exists."))
					{
						goto case 6;
					}
					_0024submitUser_00244766 = new WWW("http://72.14.184.180/storeInterface.php?username=" + AuthGameObject.username + "&request=checkforuser&type=newsystem");
					result = (Yield(6, _0024submitUser_00244766) ? 1 : 0);
					break;
				case 6:
					_0024getKey_00244769 = new WWW("http://72.14.184.180/serverKeyGen.php?username=" + Md5Sum.ComputeMd5(AuthGameObject.username + global::DontDestroyOnLoad.hitcollider));
					result = (Yield(7, _0024getKey_00244769) ? 1 : 0);
					break;
				case 7:
					_0024countertimeout_00244770 = 0;
					goto IL_04ec;
				case 8:
					_0024countertimeout_00244770++;
					goto IL_04ec;
				case 9:
					_0024countertimeout_00244770 = 0;
					goto IL_0624;
				case 10:
					_0024inventory_00244771 = new WWW("http://72.14.184.180/storeInterface.php?username=" + AuthGameObject.username + "&request=getinventoryNew&serverkey=" + Md5Sum.ComputeMd5(_0024getKey_00244769.text + global::DontDestroyOnLoad.hitcollider));
					result = (Yield(11, _0024inventory_00244771) ? 1 : 0);
					break;
				case 11:
					_0024countertimeout_00244770++;
					goto IL_0624;
				case 12:
					_0024rentarr_00244772 = new WWW("http://72.14.184.180/storeInterface.php?username=" + AuthGameObject.username + "&request=getrenttableNew&serverkey=" + Md5Sum.ComputeMd5(_0024getKey_00244769.text + global::DontDestroyOnLoad.hitcollider));
					result = (Yield(13, _0024rentarr_00244772) ? 1 : 0);
					break;
				case 13:
					_0024renttemp_00244773 = new UnityScript.Lang.Array((IEnumerable)_0024rentarr_00244772.text.Split("|"[0]));
					AuthGameObject.rentarr = (string[])_0024renttemp_00244773.ToBuiltin(typeof(string));
					_0024temparr_00244774 = new UnityScript.Lang.Array((IEnumerable)_0024inventory_00244771.text.Split("|"[0]));
					if (RuntimeServices.EqualityOperator(_0024temparr_00244774[45], "false"))
					{
						_0024temparr_00244774[45] = "0";
					}
					_0024temparr_00244774.RemoveAt(_0024temparr_00244774.length - 1);
					AuthGameObject.inventory = (string[])_0024temparr_00244774.ToBuiltin(typeof(string));
					if (UnityScript.Lang.Extensions.get_length((System.Array)AuthGameObject.inventory[2].Split("#"[0])[3].Split("-"[0])) == 1)
					{
						_0024tokenarr_00244775 = AuthGameObject.inventory[2].Split("#"[0]);
						AuthGameObject.inventory[2] = _0024tokenarr_00244775[0] + "#" + _0024tokenarr_00244775[1] + "#" + _0024tokenarr_00244775[2] + "#" + _0024tokenarr_00244775[3] + "-false#" + _0024tokenarr_00244775[4] + "#" + _0024tokenarr_00244775[5] + "#" + ((UnityScript.Lang.Extensions.get_length((System.Array)_0024tokenarr_00244775) <= 6) ? "49" : _0024tokenarr_00244775[6]);
					}
					if (AuthGameObject.inventory[2].Split("#"[0])[3].Split("-"[0])[1] == "37")
					{
						_0024tokenarr_00244775 = AuthGameObject.inventory[2].Split("#"[0]);
						AuthGameObject.inventory[2] = _0024tokenarr_00244775[0] + "#" + _0024tokenarr_00244775[1] + "#" + _0024tokenarr_00244775[2] + "#" + _0024tokenarr_00244775[3] + "#" + _0024tokenarr_00244775[4] + "#" + _0024tokenarr_00244775[5] + "#" + ((UnityScript.Lang.Extensions.get_length((System.Array)_0024tokenarr_00244775) <= 6) ? "49" : _0024tokenarr_00244775[6]);
					}
					if (UnityScript.Lang.Extensions.get_length((System.Array)AuthGameObject.inventory[2].Split("#"[0])) < 7)
					{
						AuthGameObject.inventory[2] = AuthGameObject.inventory[2] + "#49";
					}
					AuthGameObject.shop = true;
					_0024hashgold_00244776 = AuthGameObject.inventory[2].Split("#"[0]);
					_0024temphash_00244777 = null;
					for (_0024i_00244778 = 0; _0024i_00244778 < UnityScript.Lang.Extensions.get_length(_0024hashgold_00244776[0]); _0024i_00244778++)
					{
						if (_0024hashgold_00244776[0].Substring(_0024i_00244778, 1) == "0")
						{
							_0024temphash_00244777 += "a";
						}
						if (_0024hashgold_00244776[0].Substring(_0024i_00244778, 1) == "1")
						{
							_0024temphash_00244777 += "b";
						}
						if (_0024hashgold_00244776[0].Substring(_0024i_00244778, 1) == "2")
						{
							_0024temphash_00244777 += "c";
						}
						if (_0024hashgold_00244776[0].Substring(_0024i_00244778, 1) == "3")
						{
							_0024temphash_00244777 += "d";
						}
						if (_0024hashgold_00244776[0].Substring(_0024i_00244778, 1) == "4")
						{
							_0024temphash_00244777 += "e";
						}
						if (_0024hashgold_00244776[0].Substring(_0024i_00244778, 1) == "5")
						{
							_0024temphash_00244777 += "f";
						}
						if (_0024hashgold_00244776[0].Substring(_0024i_00244778, 1) == "6")
						{
							_0024temphash_00244777 += "g";
						}
						if (_0024hashgold_00244776[0].Substring(_0024i_00244778, 1) == "7")
						{
							_0024temphash_00244777 += "h";
						}
						if (_0024hashgold_00244776[0].Substring(_0024i_00244778, 1) == "8")
						{
							_0024temphash_00244777 += "i";
						}
						if (_0024hashgold_00244776[0].Substring(_0024i_00244778, 1) == "9")
						{
							_0024temphash_00244777 += "j";
						}
					}
					_0024hashgold_00244776[0] = _0024temphash_00244777;
					_0024finalhash_00244779 = null;
					_0024firstone_00244780 = true;
					_0024_00241216_00244790 = 0;
					_0024_00241217_00244791 = _0024hashgold_00244776;
					for (_0024_00241218_00244792 = _0024_00241217_00244791.Length; _0024_00241216_00244790 < _0024_00241218_00244792; _0024_00241216_00244790++)
					{
						if (_0024firstone_00244780)
						{
							_0024finalhash_00244779 = _0024_00241217_00244791[_0024_00241216_00244790];
							_0024firstone_00244780 = false;
						}
						else
						{
							_0024finalhash_00244779 = _0024finalhash_00244779 + "#" + _0024_00241217_00244791[_0024_00241216_00244790];
						}
					}
					AuthGameObject.inventory[2] = _0024finalhash_00244779;
					if (!check4gold)
					{
						check4gold = true;
						_0024goldarr_00244782 = AuthGameObject.inventory[2].Split("#"[0]);
						curday = _0024submitUser_00244766.text.Replace("User exists.", string.Empty).Split("|"[0])[0];
						curday = curday.Replace("\t\t", string.Empty);
						if (UnityScript.Lang.Extensions.get_length((System.Array)_0024goldarr_00244782) != 5 && _0024goldarr_00244782[5] != curday)
						{
							_0024getKey_00244769 = new WWW("http://72.14.184.180/serverKeyGen.php?username=" + Md5Sum.ComputeMd5(AuthGameObject.username + "1s8dn32"));
							result = (Yield(14, _0024getKey_00244769) ? 1 : 0);
							break;
						}
					}
					goto IL_14e9;
				case 14:
					dailyGoldMult = ((!_0024submitUser_00244766.text.Contains("|")) ? 50 : UnityBuiltins.parseInt(_0024submitUser_00244766.text.Split("|"[0])[1]));
					_0024escaped_00244783 = WWW.EscapeURL((UnityBuiltins.parseInt(_0024self__00244796.returnGold()) + dailyGoldMult + UnityBuiltins.parseInt(_0024self__00244796.gotreferred ? 250 : 0)).ToString() + "#" + _0024goldarr_00244782[1] + "#" + _0024goldarr_00244782[2] + "#" + _0024goldarr_00244782[3] + "#" + _0024goldarr_00244782[4] + "#" + curday + "#" + ((UnityScript.Lang.Extensions.get_length((System.Array)_0024goldarr_00244782) <= 6) ? "49" : _0024goldarr_00244782[6]));
					_0024bitem_00244784 = new WWW("http://72.14.184.180/storeInterface.php?username=" + AuthGameObject.username + "&request=changevalue" + "&serverkey=" + Md5Sum.ComputeMd5(_0024getKey_00244769.text + "1s8dn32") + "&field=tokens&changeto=" + _0024escaped_00244783);
					result = (Yield(15, _0024bitem_00244784) ? 1 : 0);
					break;
				case 15:
					if (string.IsNullOrEmpty(_0024bitem_00244784.error) && _0024bitem_00244784.text.Contains("updated"))
					{
						AuthGameObject.inventory[2] = (UnityBuiltins.parseInt(_0024self__00244796.returnGold()) + dailyGoldMult).ToString() + "#" + _0024goldarr_00244782[1] + "#" + _0024goldarr_00244782[2] + "#" + _0024goldarr_00244782[3] + "#" + _0024goldarr_00244782[4] + "#" + _0024goldarr_00244782[5] + "#" + ((UnityScript.Lang.Extensions.get_length((System.Array)_0024goldarr_00244782) <= 6) ? "49" : _0024goldarr_00244782[6]);
						dailygold = true;
						_0024temphash_00244777 = string.Empty;
						_0024hashgold_00244776 = AuthGameObject.inventory[2].Split("#"[0]);
						for (_0024i_00244778 = 0; _0024i_00244778 < UnityScript.Lang.Extensions.get_length(_0024hashgold_00244776[0]); _0024i_00244778++)
						{
							if (_0024hashgold_00244776[0].Substring(_0024i_00244778, 1) == "0")
							{
								_0024temphash_00244777 += "a";
							}
							if (_0024hashgold_00244776[0].Substring(_0024i_00244778, 1) == "1")
							{
								_0024temphash_00244777 += "b";
							}
							if (_0024hashgold_00244776[0].Substring(_0024i_00244778, 1) == "2")
							{
								_0024temphash_00244777 += "c";
							}
							if (_0024hashgold_00244776[0].Substring(_0024i_00244778, 1) == "3")
							{
								_0024temphash_00244777 += "d";
							}
							if (_0024hashgold_00244776[0].Substring(_0024i_00244778, 1) == "4")
							{
								_0024temphash_00244777 += "e";
							}
							if (_0024hashgold_00244776[0].Substring(_0024i_00244778, 1) == "5")
							{
								_0024temphash_00244777 += "f";
							}
							if (_0024hashgold_00244776[0].Substring(_0024i_00244778, 1) == "6")
							{
								_0024temphash_00244777 += "g";
							}
							if (_0024hashgold_00244776[0].Substring(_0024i_00244778, 1) == "7")
							{
								_0024temphash_00244777 += "h";
							}
							if (_0024hashgold_00244776[0].Substring(_0024i_00244778, 1) == "8")
							{
								_0024temphash_00244777 += "i";
							}
							if (_0024hashgold_00244776[0].Substring(_0024i_00244778, 1) == "9")
							{
								_0024temphash_00244777 += "j";
							}
						}
						_0024hashgold_00244776[0] = _0024temphash_00244777;
						_0024firstone_00244780 = true;
						_0024_00241220_00244793 = 0;
						_0024_00241221_00244794 = _0024hashgold_00244776;
						for (_0024_00241222_00244795 = _0024_00241221_00244794.Length; _0024_00241220_00244793 < _0024_00241222_00244795; _0024_00241220_00244793++)
						{
							if (_0024firstone_00244780)
							{
								_0024finalhash_00244779 = _0024_00241221_00244794[_0024_00241220_00244793];
								_0024firstone_00244780 = false;
							}
							else
							{
								_0024finalhash_00244779 = _0024finalhash_00244779 + "#" + _0024_00241221_00244794[_0024_00241220_00244793];
							}
						}
						AuthGameObject.inventory[2] = _0024finalhash_00244779;
					}
					goto IL_14e9;
				case 16:
					Camera.main.SendMessage("hideStatus");
					goto IL_180c;
				case 17:
					Camera.main.SendMessage("hideStatus");
					goto IL_180c;
				case 1:
					{
						result = 0;
						break;
					}
					IL_180c:
					_0024self__00244796.displaytop.active = true;
					GameObject.Find("/DisplayTopPlayers").SendMessage("enableFunction");
					_0024self__00244796.enabled = false;
					YieldDefault(1);
					goto case 1;
					IL_14e9:
					Camera.main.SendMessage("hideStatus");
					goto IL_180c;
					IL_04ec:
					if (!string.IsNullOrEmpty(_0024getKey_00244769.error) && _0024countertimeout_00244770 < 5)
					{
						_0024getKey_00244769 = new WWW("http://72.14.184.180/serverKeyGen.php?username=" + Md5Sum.ComputeMd5(AuthGameObject.username + global::DontDestroyOnLoad.hitcollider));
						result = (Yield(8, _0024getKey_00244769) ? 1 : 0);
						break;
					}
					if (string.IsNullOrEmpty(_0024getKey_00244769.error))
					{
						_0024inventory_00244771 = new WWW("http://72.14.184.180/storeInterface.php?username=" + AuthGameObject.username + "&request=getinventoryNew&serverkey=" + Md5Sum.ComputeMd5(_0024getKey_00244769.text + global::DontDestroyOnLoad.hitcollider));
						result = (Yield(9, _0024inventory_00244771) ? 1 : 0);
						break;
					}
					_0024guestinventory_00244786 = new UnityScript.Lang.Array("0", "guest", "0#3#7#false-false#false#0#49", "false", "false", "false", "false", "false", "false", "false", "false", "false", "false", "false", "false", "false", "false", "false");
					AuthGameObject.inventory = (string[])_0024guestinventory_00244786.ToBuiltin(typeof(string));
					AuthGameObject.shop = false;
					AuthGameObject.shopfailed = false;
					Camera.main.SendMessage("showStatus", "Store Loading Failed!");
					result = (Yield(17, new WaitForSeconds(3f)) ? 1 : 0);
					break;
					IL_0624:
					if (!_0024inventory_00244771.text.Contains("|inventory") && !string.IsNullOrEmpty(_0024inventory_00244771.error) && _0024countertimeout_00244770 < 5)
					{
						_0024getKey_00244769 = new WWW("http://72.14.184.180/serverKeyGen.php?username=" + Md5Sum.ComputeMd5(AuthGameObject.username + global::DontDestroyOnLoad.hitcollider));
						result = (Yield(10, _0024getKey_00244769) ? 1 : 0);
						break;
					}
					if (string.IsNullOrEmpty(_0024inventory_00244771.error) && _0024inventory_00244771.text.Contains("|"))
					{
						_0024getKey_00244769 = new WWW("http://72.14.184.180/serverKeyGen.php?username=" + Md5Sum.ComputeMd5(AuthGameObject.username + global::DontDestroyOnLoad.hitcollider));
						result = (Yield(12, _0024getKey_00244769) ? 1 : 0);
						break;
					}
					_0024guestinventory_00244786 = new UnityScript.Lang.Array("0", "guest", "0#3#7#false-false#false#0#49", "false", "false", "false", "false", "false", "false", "false", "false", "false", "false", "false", "false", "false", "false", "false");
					AuthGameObject.inventory = (string[])_0024guestinventory_00244786.ToBuiltin(typeof(string));
					AuthGameObject.shop = false;
					AuthGameObject.shopfailed = false;
					Camera.main.SendMessage("showStatus", "Store Loading Failed!");
					result = (Yield(16, new WaitForSeconds(3f)) ? 1 : 0);
					break;
				}
				return (byte)result != 0;
			}
		}

		internal LoginWindow _0024self__00244797;

		public _0024fadeOut_00244763(LoginWindow self_)
		{
			_0024self__00244797 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00244797);
		}
	}

	[Serializable]
	internal sealed class _0024makeguest_00244798 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal LoginWindow _0024self__00244799;

			public _0024(LoginWindow self_)
			{
				_0024self__00244799 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00244799.progresslab = "Generating guest ID...";
					_0024self__00244799.colorstate = 0;
					result = (Yield(2, new WaitForSeconds(0.5f)) ? 1 : 0);
					break;
				case 2:
					username = "guest_" + username.Split("_"[0])[UnityScript.Lang.Extensions.get_length((System.Array)username.Split("_"[0])) - 1];
					AuthGameObject.username = username;
					_0024self__00244799.progresslab = "Guest ID created!";
					logincookie = true;
					_0024self__00244799.colorstate = 2;
					result = (Yield(3, new WaitForSeconds(0.4f)) ? 1 : 0);
					break;
				case 3:
					_0024self__00244799.StartCoroutine_Auto(_0024self__00244799.fadeoutguest());
					_0024self__00244799.StartCoroutine_Auto(_0024self__00244799.fadeOut());
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal LoginWindow _0024self__00244800;

		public _0024makeguest_00244798(LoginWindow self_)
		{
			_0024self__00244800 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00244800);
		}
	}

	[Serializable]
	internal sealed class _0024fadeinguest_00244801 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal LoginWindow _0024self__00244802;

			public _0024(LoginWindow self_)
			{
				_0024self__00244802 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__00244802.guestalpha < 1f)
					{
						_0024self__00244802.guestalpha = Mathf.Min(1f, _0024self__00244802.guestalpha + Time.deltaTime * 4f);
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

		internal LoginWindow _0024self__00244803;

		public _0024fadeinguest_00244801(LoginWindow self_)
		{
			_0024self__00244803 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00244803);
		}
	}

	[Serializable]
	internal sealed class _0024fadeoutguest_00244804 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal LoginWindow _0024self__00244805;

			public _0024(LoginWindow self_)
			{
				_0024self__00244805 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__00244805.guestalpha > 0f)
					{
						_0024self__00244805.guestalpha = Mathf.Max(0f, _0024self__00244805.guestalpha - Time.deltaTime * 4f);
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

		internal LoginWindow _0024self__00244806;

		public _0024fadeoutguest_00244804(LoginWindow self_)
		{
			_0024self__00244806 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00244806);
		}
	}

	[Serializable]
	internal sealed class _0024login_00244807 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string _0024escapedusername_00244808;

			internal string _0024hash_00244809;

			internal string _0024finalurl_00244810;

			internal WWW _0024loginwww_00244811;

			internal int _0024endindex_00244812;

			internal string _0024compiledpass_00244813;

			internal string _0024username_00244814;

			internal string _0024password_00244815;

			internal LoginWindow _0024self__00244816;

			public _0024(string username, string password, LoginWindow self_)
			{
				_0024username_00244814 = username;
				_0024password_00244815 = password;
				_0024self__00244816 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024password_00244815 = Md5Sum.ComputeMd5(_0024password_00244815 + global::DontDestroyOnLoad.hitcollider);
					_0024escapedusername_00244808 = WWW.EscapeURL(_0024username_00244814);
					_0024hash_00244809 = Md5Sum.ComputeMd5(_0024username_00244814 + global::DontDestroyOnLoad.hitcollider);
					_0024finalurl_00244810 = _0024self__00244816.loginurl + "username=" + _0024escapedusername_00244808 + "&key=" + _0024hash_00244809;
					_0024loginwww_00244811 = new WWW(_0024finalurl_00244810);
					_0024self__00244816.progresslab = "Authenticating...";
					_0024self__00244816.colorstate = 0;
					result = (Yield(2, _0024loginwww_00244811) ? 1 : 0);
					break;
				case 2:
					if (!string.IsNullOrEmpty(_0024loginwww_00244811.error))
					{
						_0024self__00244816.progresslab = "Authentication server down!";
						_0024self__00244816.colorstate = 1;
					}
					if (_0024loginwww_00244811.text.Contains("PHP Error Message"))
					{
						_0024self__00244816.progresslab = "Authentication server down!";
						_0024self__00244816.colorstate = 1;
					}
					if (_0024loginwww_00244811.text.Contains("FAIL") && !_0024loginwww_00244811.text.Contains("PHP Error Message"))
					{
						_0024self__00244816.progresslab = "Invalid username or password.";
						_0024self__00244816.colorstate = 1;
					}
					else if (_0024loginwww_00244811.text.Contains("END"))
					{
						_0024endindex_00244812 = _0024loginwww_00244811.text.IndexOf("END");
						_0024compiledpass_00244813 = _0024loginwww_00244811.text.Substring(0, _0024endindex_00244812);
						if (_0024compiledpass_00244813 == _0024password_00244815)
						{
							AuthGameObject.username = _0024username_00244814;
							_0024self__00244816.progresslab = "Login successful!";
							logincookie = true;
							_0024self__00244816.colorstate = 2;
							result = (Yield(3, new WaitForSeconds(0.4f)) ? 1 : 0);
							break;
						}
						_0024self__00244816.progresslab = "Invalid username or password.";
						_0024self__00244816.colorstate = 1;
					}
					goto IL_028b;
				case 3:
					PlayerPrefs.SetString("playername", _0024username_00244814);
					_0024self__00244816.StartCoroutine_Auto(_0024self__00244816.fadeOut());
					goto IL_028b;
				case 1:
					{
						result = 0;
						break;
					}
					IL_028b:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal string _0024username_00244817;

		internal string _0024password_00244818;

		internal LoginWindow _0024self__00244819;

		public _0024login_00244807(string username, string password, LoginWindow self_)
		{
			_0024username_00244817 = username;
			_0024password_00244818 = password;
			_0024self__00244819 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024username_00244817, _0024password_00244818, _0024self__00244819);
		}
	}

	[Serializable]
	internal sealed class _0024register_00244820 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string _0024escapedusername_00244821;

			internal string _0024hash_00244822;

			internal string _0024finalurl_00244823;

			internal WWW _0024registerwww_00244824;

			internal string _0024username_00244825;

			internal string _0024password_00244826;

			internal LoginWindow _0024self__00244827;

			public _0024(string username, string password, LoginWindow self_)
			{
				_0024username_00244825 = username;
				_0024password_00244826 = password;
				_0024self__00244827 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024password_00244826 = Md5Sum.ComputeMd5(_0024password_00244826 + global::DontDestroyOnLoad.hitcollider);
					_0024escapedusername_00244821 = WWW.EscapeURL(_0024username_00244825);
					_0024hash_00244822 = Md5Sum.ComputeMd5(_0024username_00244825 + _0024password_00244826 + global::DontDestroyOnLoad.hitcollider);
					_0024finalurl_00244823 = _0024self__00244827.registerurl + "username=" + _0024escapedusername_00244821 + "&password=" + _0024password_00244826 + "&key=" + _0024hash_00244822;
					_0024registerwww_00244824 = new WWW(_0024finalurl_00244823);
					_0024self__00244827.progresslab = "Sending request...";
					_0024self__00244827.colorstate = 0;
					result = (Yield(2, _0024registerwww_00244824) ? 1 : 0);
					break;
				case 2:
					if (!string.IsNullOrEmpty(_0024registerwww_00244824.error))
					{
						_0024self__00244827.progresslab = "Registration server down!";
						_0024self__00244827.colorstate = 1;
					}
					if (_0024registerwww_00244824.text.Contains("PHP Error Message"))
					{
						_0024self__00244827.progresslab = "Registration server down!";
						_0024self__00244827.colorstate = 1;
					}
					if (_0024registerwww_00244824.text.Contains("FAIL"))
					{
						_0024self__00244827.progresslab = "Registration server down!";
						_0024self__00244827.colorstate = 1;
						goto IL_0226;
					}
					_0024self__00244827.progresslab = "Registration successful!";
					Application.ExternalEval("unityObject.getObjectById('unityPlayer').SendMessage('LoginWindow', 'setRef', location.href)");
					logincookie = true;
					_0024self__00244827.colorstate = 2;
					AuthGameObject.username = _0024username_00244825;
					PlayerPrefs.SetString("playername", _0024username_00244825);
					result = (Yield(3, new WaitForSeconds(0.4f)) ? 1 : 0);
					break;
				case 3:
					_0024self__00244827.StartCoroutine_Auto(_0024self__00244827.fadeOut());
					goto IL_0226;
				case 4:
					_0024self__00244827.progresslab = "Re-attempting connection in 3";
					_0024self__00244827.colorstate = 0;
					result = (Yield(5, new WaitForSeconds(1f)) ? 1 : 0);
					break;
				case 5:
					_0024self__00244827.progresslab = "Re-attempting connection in 2";
					_0024self__00244827.colorstate = 0;
					result = (Yield(6, new WaitForSeconds(1f)) ? 1 : 0);
					break;
				case 6:
					_0024self__00244827.progresslab = "Re-attempting connection in 1";
					_0024self__00244827.colorstate = 0;
					result = (Yield(7, new WaitForSeconds(1f)) ? 1 : 0);
					break;
				case 7:
					_0024registerwww_00244824 = new WWW(_0024finalurl_00244823);
					_0024self__00244827.progresslab = "Sending request...";
					_0024self__00244827.colorstate = 0;
					result = (Yield(8, _0024registerwww_00244824) ? 1 : 0);
					break;
				case 8:
					if (!string.IsNullOrEmpty(_0024registerwww_00244824.error))
					{
						_0024self__00244827.progresslab = "Registration server down!";
						_0024self__00244827.colorstate = 1;
					}
					if (_0024registerwww_00244824.text.Contains("FAIL"))
					{
						_0024self__00244827.progresslab = "Registration server down!";
						_0024self__00244827.colorstate = 1;
					}
					else
					{
						_0024self__00244827.progresslab = "Registration sucessful!";
						logincookie = true;
						_0024self__00244827.colorstate = 2;
						AuthGameObject.username = _0024username_00244825;
						PlayerPrefs.SetString("playername", _0024username_00244825);
						_0024self__00244827.windowtype = 0;
						if (Application.isWebPlayer)
						{
							Application.ExternalEval("var exdate=new Date();" + "exdate.setDate(exdate.getDate() + 360);" + "var c_value=escape('" + _0024username_00244825 + "') + ((360==null) ? '' : '; expires='+exdate.toUTCString());" + "document.cookie='sysLogin' + '=' + c_value;");
						}
						_0024self__00244827.StartCoroutine_Auto(_0024self__00244827.fadeOut());
					}
					goto IL_0435;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0226:
					if (_0024self__00244827.progresslab == "Registration server down!")
					{
						result = (Yield(4, new WaitForSeconds(0.4f)) ? 1 : 0);
						break;
					}
					goto IL_0435;
					IL_0435:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal string _0024username_00244828;

		internal string _0024password_00244829;

		internal LoginWindow _0024self__00244830;

		public _0024register_00244820(string username, string password, LoginWindow self_)
		{
			_0024username_00244828 = username;
			_0024password_00244829 = password;
			_0024self__00244830 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024username_00244828, _0024password_00244829, _0024self__00244830);
		}
	}

	[Serializable]
	internal sealed class _0024checkuser_00244831 : GenericGenerator<WWW>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WWW>, IEnumerator
		{
			internal string _0024escapedusername_00244832;

			internal string _0024hash_00244833;

			internal string _0024finalurl_00244834;

			internal WWW _0024checkerwww_00244835;

			internal string _0024username_00244836;

			internal LoginWindow _0024self__00244837;

			public _0024(string username, LoginWindow self_)
			{
				_0024username_00244836 = username;
				_0024self__00244837 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024escapedusername_00244832 = WWW.EscapeURL(_0024username_00244836);
					_0024hash_00244833 = Md5Sum.ComputeMd5(_0024username_00244836 + global::DontDestroyOnLoad.hitcollider);
					_0024finalurl_00244834 = _0024self__00244837.checkerurl + "username=" + _0024escapedusername_00244832 + "&key=" + _0024hash_00244833;
					_0024checkerwww_00244835 = new WWW(_0024finalurl_00244834);
					_0024self__00244837.progresslab = "Validating username...";
					_0024self__00244837.colorstate = 0;
					result = (Yield(2, _0024checkerwww_00244835) ? 1 : 0);
					break;
				case 2:
					if (!string.IsNullOrEmpty(_0024checkerwww_00244835.error))
					{
						_0024self__00244837.progresslab = "Registration server down!";
						_0024self__00244837.colorstate = 1;
					}
					if (_0024checkerwww_00244835.text.Contains("SUCCESS"))
					{
						_0024self__00244837.progresslab = "Username is taken.";
						_0024self__00244837.colorstate = 1;
					}
					else
					{
						_0024self__00244837.StartCoroutine_Auto(_0024self__00244837.register(_0024username_00244836, _0024self__00244837.password));
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

		internal string _0024username_00244838;

		internal LoginWindow _0024self__00244839;

		public _0024checkuser_00244831(string username, LoginWindow self_)
		{
			_0024username_00244838 = username;
			_0024self__00244839 = self_;
		}

		public override IEnumerator<WWW> GetEnumerator()
		{
			return new _0024(_0024username_00244838, _0024self__00244839);
		}
	}

	[NonSerialized]
	public static string username = "Username";

	private string password;

	private string confirmpass;

	private int windowtype;

	public GUIStyle loginstyle;

	public GUIStyle loginguestStyle;

	public GUIStyle textstyle;

	public GUIStyle buttonskin;

	public GUIStyle progressstyle;

	private int boxheight;

	private int extraheight;

	private int buttonheight;

	private int textfieldwidth;

	private int textfieldoffset;

	private string loginorreg;

	private string keyhash;

	private string checkerurl;

	private string loginurl;

	private string registerurl;

	public AuthGameObject authgameobject;

	public HeadlesssDedServer headless;

	public Color errorcolor;

	public Color goodcolor;

	private int colorstate;

	private string progresslab;

	private bool dontreplace;

	private string clearfield;

	private float alpha;

	[NonSerialized]
	public static float pubalpha;

	[NonSerialized]
	public static bool logincookie;

	private string message;

	public UnityScript.Lang.Array swearlist;

	public KongregateAPI kongapi;

	private bool iskong;

	[NonSerialized]
	public static float offset = 150f;

	[NonSerialized]
	public static bool check4gold;

	[NonSerialized]
	public static bool displaygold;

	public PreloaderExplosion pex;

	[NonSerialized]
	public static bool dailygold;

	[NonSerialized]
	public static int dailyGoldMult = 500;

	[NonSerialized]
	public static string curday;

	public DontDestroyOnLoad ddol;

	public GameObject ircwin;

	private bool gotreferred;

	private string referredby;

	public Texture lightBox;

	public GameObject displaytop;

	public GUISkin scrollstyle;

	private float guestalpha;

	public LoginWindow()
	{
		password = "1PaSsVaR3";
		confirmpass = "1PaSsVaR3";
		boxheight = 220;
		buttonheight = 170;
		textfieldwidth = 300;
		loginorreg = string.Empty;
		keyhash = "2db1zt9zt3av";
		checkerurl = "http://72.14.184.180/Checker.php?";
		loginurl = "http://72.14.184.180/Login.php?";
		registerurl = "http://72.14.184.180/Register.php?";
		progresslab = string.Empty;
		clearfield = string.Empty;
		message = "You must login to your account to buy items and get credits.";
		swearlist = new UnityScript.Lang.Array("fuck", "damn", "shit", "sh1t", "bitch", "b1tch", "bastard", "b@stard", "bas.tard", "b.astard", "bast.ard", " ass ", "@ss", "@55", "a55", "sex", "xxx", "porn", "p0rn", "p.0rn", "p0.rn", "vagina", "vag.ina", "pe.nis", "penis", "pen1s", "p.enis", "tes.ticle", "testicle", "ballsack", "b00b", "boob", "bo.ob", "butt ", "bu.tt", "crap", "cr@p", "cr.ap", "cra.p", "ahole", "ash0le", "ash0les", "asholes", "ass monkey", "assface", "assh0le", "assh0lez", "asshole", "assholes", "assholz", "asswipe", "azzhole", "bassterds", "bastard", "bastards", "bastardz", "basterds", "basterdz", "biatch", "bitch", "bitches", "blow job", "boffing", "butthole", "buttwipe", "c0ck", "c0cks", "c0k", "carpet muncher", "cawks", "clit", "cnts", "cntz", "cock", "cocksucker", "cock-sucker", "crap", "cunt", "cunts", "cuntz", "dick", "dild0", "dild0s", "dildo", "dildos", "dilld0", "dilld0s", "dominatricks", "dominatrics", "dominatrix", "dyke", "enema", "f u c k", "f u c k e r", "fag ", "fag1t", "faget", "fagg1t", "faggit", "faggot", "fagit", "fagz", "faig", "faigs", "flipping the bird", "fudge packer", "fuk", "g00k", "gay", "h00r", "h0ar", "h0re", "jackoff", "jerk-off", "jisim", "jiss", "jizm", "jizz", "lesbian", "lezzian", "lipshitz", "masochist", "masokist", "massterbait", "masstrbait", "masstrbate", "masterbaiter", "masterbate", "masterbates", "motha fucker", "motha fuker", "motha fukkah", "motha fukker", "mother fucker", "mother fukah", "mother fuker", "mother fukkah", "mother fukker", "mother-fucker", "mutha fucker", "mutha fukah", "mutha fuker", "mutha fukkah", "mutha fukker", "n1gr", "nastt", "orgasim;", "orgasm", "orgasum", "peeenus", "peeenusss", "peenus", "peinus", "pen1s", "penas", "penis", "penus", "penuus", "pr1c", "pr1ck", "pr1k", "pusse", "pussee", "pussy", "puuke", "puuker", "recktum", "rectum", "screwing", "semen", "sh!t", "sh1t", "sh1ter", "sh1ts", "sh1tter", "sh1tz", "shits", "shitter", "shitty", "shity", "shitz", "shyt", "shyte", "shytty", "shyty", "skanck", "skank", "skankee", "skankey", "skanks", "skanky", "slut", "sluts", "slutty", "slutz", "son-of-a-bitch", " turd ", "va1jina", "vag1na", "vagiina", "vagina", "vaj1na", "vajina", "w0p", "wh00r", "wh0re", "whore", "xrated", "xxx", "b!+ch", "bitch", "blowjob", "clit", "arschloch", "b!tch", "b17ch", "b1tch", "bastard", "bi+ch", "boiolas", "buceta", "c0ck", "cawk", "clits", "cock", "cum", "cunt", "dildo", "dirsa", "ejakulate", "fatass", "fcuk", "fuk", "fux0r", "hoer", "hore", "jism", "kawk", "l3itch", "l3i+ch", "lesbian", "masturbate", "masterbat", "masterbat3", "motherfucker", "s.o.b.", "mofo", "nazi", "nigga", "nigger", "nutsack", "phuck", "pimpis", "pusse", "pussy", "scrotum", "sh!t", "shemale", "shi+", "sh!+", "slut", "testical", "testicle", "w00se", "jackoff", "whore", "@$$", "amcik", "andskota", "arse", "bi7ch", "bitch", "bollock", "breasts", "butt-pirate", "cunt", "d4mn", "dick", "ejackulate", "fu(", "fuk", "h0r", "h4x0r", "jizz", "klootzak", "knulle", "kuksuger", "lesbo", "masturbat", "nepesaurio", "nigger", "poop", "porn", "p0rn", "pr0n", "sh!t", "b00b", " titt", "twat", "vittu", "wank", "wetback", "wichser", "zabourah", "f.u.k", "ji.zz", "co.ck", "c.ock", "n.igger", "n1gger", "m@sterbate", "bre@st", "transvestite", "tr@nsvestite", "brastrap", "blue waffle", "blue w@ffle", "pedofile", "ped0f1le", "pedof1ile", "jiz", "fuck", "damn", "shit", "fuck", "damn", "shit", "bastard", "bastard", "bitch", "bitch", "bitch", "b1tch", "bitch", "vagina", "vagina", "vagina", "breast", "brest", "br3st", "breast", "pussy", "penis", "p3nis", "penis", "penis", "penis", "cum ", "c.um", "slut", "slut", "s1ut", "slut", " tit ", "t1t", "t33t", "teet", "a55", "jizz", "jizz", "j1zz", "j1z", "j1z", "be@st", "semen", "smen", "ballsack", "ballsack", "ball.sack", "fuk", "fuck", "breast", "damn", "sh1t", "sh#t", "sh#t", "crap", "crap", "cr@p", "cr@p", "cr#p", "fu#k", "f#ck", "f#ck", "f#ck", "fu#k", "a$$", "$h1+", "$h1t", "$h1t", "$#it", "pu#sy", "da#n", "dam#", "d#mn", "d#mn", "pen#s", "pen#s", "p#nis", "p#nis", "v@g1n@", " vag ", "b#stard", "b#stard", "b#tch", "erection", "blue-waffle", "bl.ue-waffle", "ere.ction", "blow-job", "blow.job", "blow/job", "bl0w j0b", "$hit", "cr@p", "a$$", "a$$", " ass");
		referredby = string.Empty;
	}

	public virtual void Update()
	{
		pubalpha = alpha;
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

	public virtual void Start()
	{
		gotreferred = false;
		referredby = string.Empty;
		progresslab = string.Empty;
		colorstate = 0;
		if (Application.isWebPlayer && PreloaderExplosion.isKong)
		{
			iskong = true;
		}
		if (iskong)
		{
			if (KongregateAPI.loggedin && KongregateAPI.username != "Guest")
			{
				username = KongregateAPI.username;
				AuthGameObject.username = KongregateAPI.username;
				logincookie = true;
				alpha = 0f;
				StartCoroutine_Auto(fadeOut());
			}
			else
			{
				if (logincookie)
				{
					alpha = 0f;
					displaytop.active = true;
					enabled = false;
				}
				else
				{
					username = PlayerPrefs.GetString("playername", "Username");
				}
				string text = PlayerPrefs.GetString("resetpname", "none");
				if (text == "none")
				{
					PlayerPrefs.SetString("resetpname", "namereset");
					PlayerPrefs.SetString("playername", "Username");
					username = "Username";
				}
			}
		}
		else
		{
			if (logincookie)
			{
				displaytop.active = true;
				enabled = false;
				alpha = 0f;
			}
			else
			{
				username = PlayerPrefs.GetString("playername", "Username");
				if (username == "Username" && KongregateAPI.alreadyreg)
				{
					username = KongregateAPI.regname;
					PlayerPrefs.SetString("playername", KongregateAPI.regname);
					PlayerPrefs.SetString("resetpname", "namereset");
				}
				else if (!KongregateAPI.alreadyreg && Application.isWebPlayer)
				{
					Application.ExternalEval("var exdate=new Date();" + "exdate.setDate(exdate.getDate() + 360);" + "var c_value=escape('" + username + "') + ((360==null) ? '' : '; expires='+exdate.toUTCString());" + "document.cookie='sysLogin' + '=' + c_value;");
				}
			}
			string text = PlayerPrefs.GetString("resetpname", "none");
			if (text == "none")
			{
				PlayerPrefs.SetString("resetpname", "namereset");
				PlayerPrefs.SetString("playername", "Username");
				username = "Username";
			}
		}
		if (username != "Username")
		{
			windowtype = 0;
			loginorreg = "Login";
			message = "You must login to your account to buy items and get credits.";
			boxheight = 220;
			buttonheight = 170;
			extraheight = 0;
			textfieldwidth = 300;
			textfieldoffset = 0;
		}
		else
		{
			windowtype = 1;
			loginorreg = "Register";
			message = "Please register; it's free and only takes a few seconds!";
			boxheight = 260;
			buttonheight = 210;
			extraheight = 35;
			textfieldwidth = 230;
			textfieldoffset = 70;
		}
		if ((iskong && !KongregateAPI.loggedin) || KongregateAPI.username == "Guest")
		{
			StartCoroutine_Auto(fadein());
		}
		if (!iskong)
		{
			StartCoroutine_Auto(fadein());
		}
	}

	public virtual IEnumerator fadein()
	{
		return new _0024fadein_00244760(this).GetEnumerator();
	}

	public virtual IEnumerator fadeOut()
	{
		return new _0024fadeOut_00244763(this).GetEnumerator();
	}

	public virtual void OnGUI()
	{
		GUI.skin = scrollstyle;
		if (!HeadlesssDedServer.isServerHost)
		{
			GUI.depth = -1;
			float a = alpha;
			Color color = GUI.color;
			float num = (color.a = a);
			Color color2 = (GUI.color = color);
			if (GUI.color.a != 0f)
			{
				GUI.DrawTexture(new Rect(0f, 0f, Screen.width, Screen.height), lightBox);
				if (!(guestalpha <= 0f))
				{
					GUI.enabled = false;
				}
				GUI.BeginGroup(new Rect((float)(Screen.width / 2 - 175) + offset, Screen.height / 2 - boxheight / 2, 350f, boxheight));
				GUI.Box(new Rect(0f, 0f, 350f, boxheight), loginorreg, loginstyle);
				GUI.Label(new Rect(25f, 30f, 300f, 60f), message, textstyle);
				if (windowtype == 1)
				{
					GUI.Label(new Rect(25f, 100f, 310f, 20f), "Username:", textstyle);
					GUI.Label(new Rect(25f, 135f, 310f, 20f), "Password:", textstyle);
					GUI.Label(new Rect(25f, 170f, 310f, 20f), "Confirm:", textstyle);
				}
				if (colorstate == 1)
				{
					GUI.color = errorcolor;
				}
				if (colorstate == 2)
				{
					GUI.color = goodcolor;
				}
				float a2 = alpha;
				Color color4 = GUI.color;
				float num2 = (color4.a = a2);
				Color color5 = (GUI.color = color4);
				GUI.Label(new Rect(25f, 173 + extraheight, 205f, 20f), progresslab, progressstyle);
				GUI.color = Color.white;
				float a3 = alpha;
				Color color7 = GUI.color;
				float num3 = (color7.a = a3);
				Color color8 = (GUI.color = color7);
				if (iskong)
				{
				}
				if (!(guestalpha > 0f))
				{
					GUI.SetNextControlName("logusername");
				}
				username = GUI.TextField(new Rect(25 + textfieldoffset, 100f, textfieldwidth, 20f), username, 20);
				GUI.SetNextControlName("logpassword");
				password = GUI.PasswordField(new Rect(25 + textfieldoffset, 135f, textfieldwidth, 20f), password, "•"[0], 20);
				if (windowtype == 1)
				{
					GUI.SetNextControlName("confirmpassword");
					confirmpass = GUI.PasswordField(new Rect(25 + textfieldoffset, 170f, textfieldwidth, 20f), confirmpass, "•"[0], 20);
				}
				if (iskong)
				{
				}
				if (Event.current.type == EventType.KeyDown && Event.current.character == '\t' && GUI.GetNameOfFocusedControl() == "logusername")
				{
					GUI.FocusControl("logpassword");
				}
				if (GUI.GetNameOfFocusedControl() == "logusername")
				{
					if (clearfield != "username")
					{
						clearfield = "username";
						if (username == "Username" || username == "username")
						{
							username = string.Empty;
						}
					}
					if (password == string.Empty)
					{
						password = "1PaSsVaR3";
					}
					if (confirmpass == string.Empty)
					{
						confirmpass = "1PaSsVaR3";
					}
				}
				if (GUI.GetNameOfFocusedControl() == "logpassword")
				{
					if (clearfield != "password")
					{
						clearfield = "password";
						if (password == "1PaSsVaR3")
						{
							password = string.Empty;
						}
					}
					if (username == string.Empty)
					{
						username = "Username";
					}
					if (confirmpass == string.Empty)
					{
						confirmpass = "1PaSsVaR3";
					}
				}
				if (GUI.GetNameOfFocusedControl() == "confirmpassword")
				{
					if (clearfield != "passwordcon")
					{
						clearfield = "passwordcon";
						if (confirmpass == "1PaSsVaR3")
						{
							confirmpass = string.Empty;
						}
					}
					if (username == string.Empty)
					{
						username = "Username";
					}
					if (password == string.Empty)
					{
						password = "1PaSsVaR3";
					}
				}
				if (GUI.GetNameOfFocusedControl() != "logusername" && GUI.GetNameOfFocusedControl() != "logpassword" && GUI.GetNameOfFocusedControl() != "confirmpassword")
				{
					if (username == string.Empty)
					{
						username = "Username";
					}
					if (password == string.Empty)
					{
						password = "1PaSsVaR3";
					}
					if (confirmpass == string.Empty)
					{
						confirmpass = "1PaSsVaR3";
					}
					clearfield = string.Empty;
				}
				if (!dontreplace && username != "Username_Temp")
				{
					username = escapeUsername(username);
				}
				if (Event.current.type == EventType.KeyDown && Event.current.character == '\n')
				{
					if (GUI.GetNameOfFocusedControl() == "logpassword")
					{
						dontreplace = false;
						if (boxheight == 260 || boxheight == 275)
						{
							boxheight = 275;
							buttonheight = 225;
						}
						else
						{
							buttonheight = 190;
							boxheight = 240;
						}
						buttondelegate();
					}
					if (GUI.GetNameOfFocusedControl() == "confirmpassword")
					{
						dontreplace = false;
						if (boxheight == 260 || boxheight == 275)
						{
							boxheight = 275;
							buttonheight = 225;
						}
						else
						{
							buttonheight = 190;
							boxheight = 240;
						}
						buttondelegate();
					}
				}
				if (GUI.Button(new Rect(125f, buttonheight, 100f, 25f), "Play as Guest", buttonskin))
				{
					StartCoroutine_Auto(fadeinguest());
				}
				if (windowtype == 1)
				{
					if (GUI.Button(new Rect(30f, buttonheight, 90f, 25f), "Login", buttonskin))
					{
						dontreplace = false;
						progresslab = string.Empty;
						colorstate = 0;
						PlayerPrefs.SetString("playername", "Username_Temp");
						logincookie = false;
						Start();
					}
				}
				else if ((PlayerPrefs.GetString("playername", "Username") == "Username_Temp" || PlayerPrefs.GetString("playername", "Username").Contains("guest_")) && GUI.Button(new Rect(30f, buttonheight, 90f, 25f), "Register", buttonskin))
				{
					dontreplace = true;
					PlayerPrefs.SetString("playername", "Username");
					logincookie = false;
					Start();
				}
				if (iskong)
				{
				}
				if (GUI.Button(new Rect(230f, buttonheight, 90f, 25f), loginorreg, buttonskin))
				{
					dontreplace = false;
					if (boxheight == 260 || boxheight == 275)
					{
						boxheight = 275;
						buttonheight = 225;
					}
					else
					{
						buttonheight = 190;
						boxheight = 240;
					}
					buttondelegate();
				}
				GUI.EndGroup();
			}
		}
		float a4 = guestalpha;
		Color color10 = GUI.color;
		float num4 = (color10.a = a4);
		Color color11 = (GUI.color = color10);
		if (guestalpha <= 0f)
		{
			return;
		}
		GUI.enabled = true;
		GUI.BeginGroup(new Rect((float)(Screen.width / 2 - 175) + offset, Screen.height / 2 - 85, 350f, 170f));
		GUI.Box(new Rect(0f, 0f, 350f, 170f), "Guest Login", loginguestStyle);
		GUI.Label(new Rect(25f, 30f, 300f, 60f), "Enter a name and you can start playing right away!", textstyle);
		GUI.SetNextControlName("logusername");
		username = GUI.TextField(new Rect(25f, 85f, 300f, 20f), username, 20);
		if (GUI.Button(new Rect(220f, 120f, 100f, 25f), "Play as Guest", buttonskin))
		{
			dontreplace = true;
			if (boxheight == 260 || boxheight == 275)
			{
				boxheight = 275;
				buttonheight = 225;
			}
			else
			{
				buttonheight = 190;
				boxheight = 240;
			}
			StartCoroutine_Auto(makeguest());
		}
		GUI.EndGroup();
	}

	public virtual string escapeUsername(string str)
	{
		return Regex.Replace(str, "[^a-zA-Z0-9]", string.Empty);
	}

	public virtual void makeguestglitch()
	{
		StartCoroutine_Auto(makeguest());
	}

	public virtual IEnumerator makeguest()
	{
		return new _0024makeguest_00244798(this).GetEnumerator();
	}

	public virtual IEnumerator fadeinguest()
	{
		return new _0024fadeinguest_00244801(this).GetEnumerator();
	}

	public virtual IEnumerator fadeoutguest()
	{
		return new _0024fadeoutguest_00244804(this).GetEnumerator();
	}

	public virtual void buttondelegate()
	{
		if (windowtype == 0)
		{
			if (username != string.Empty)
			{
				StartCoroutine_Auto(login(username, password));
				return;
			}
			progresslab = "Invalid username or password.";
			colorstate = 1;
			return;
		}
		bool flag = false;
		string text = username;
		text = text.ToLower();
		IEnumerator enumerator = UnityRuntimeServices.GetEnumerator(swearlist);
		while (enumerator.MoveNext())
		{
			object obj = enumerator.Current;
			if (!(obj is string))
			{
				obj = RuntimeServices.Coerce(obj, typeof(string));
			}
			string value = (string)obj;
			if (text.Contains(value))
			{
				flag = true;
			}
		}
		if (username != "Username" && username != string.Empty && !flag)
		{
			if (password == confirmpass)
			{
				StartCoroutine_Auto(checkuser(username));
			}
			else
			{
				progresslab = "Passwords do not match!";
				colorstate = 1;
			}
		}
		if (username == "Username")
		{
			progresslab = "\"Username\" is not allowed.";
			colorstate = 1;
		}
		if (username == string.Empty)
		{
			progresslab = "\"\" is not allowed.";
			colorstate = 1;
		}
		if (flag)
		{
			progresslab = "Profanity is not allowed.";
			colorstate = 1;
		}
		flag = false;
	}

	public virtual IEnumerator login(string username, string password)
	{
		return new _0024login_00244807(username, password, this).GetEnumerator();
	}

	public virtual IEnumerator register(string username, string password)
	{
		return new _0024register_00244820(username, password, this).GetEnumerator();
	}

	public virtual void setRef(string s)
	{
		if (s.Contains("?r="))
		{
			s = s.Replace("?r=", "|");
			gotreferred = true;
			referredby = s.Split("|"[0])[1];
		}
	}

	public virtual IEnumerator checkuser(string username)
	{
		return new _0024checkuser_00244831(username, this).GetEnumerator();
	}

	public virtual void Main()
	{
	}
}
