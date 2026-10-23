using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using Photon;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class AdjustCamDistance : Photon.MonoBehaviour
{
	[Serializable]
	internal sealed class _0024setPM_00243026 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string _0024n_00243027;

			internal AdjustCamDistance _0024self__00243028;

			public _0024(string n, AdjustCamDistance self_)
			{
				_0024n_00243027 = n;
				_0024self__00243028 = self_;
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
					_0024self__00243028.chatText = " |" + _0024n_00243027;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal string _0024n_00243029;

		internal AdjustCamDistance _0024self__00243030;

		public _0024setPM_00243026(string n, AdjustCamDistance self_)
		{
			_0024n_00243029 = n;
			_0024self__00243030 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024n_00243029, _0024self__00243030);
		}
	}

	[Serializable]
	internal sealed class _0024errorChatMessage_00243031 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal AdjustCamDistance _0024self__00243032;

			public _0024(AdjustCamDistance self_)
			{
				_0024self__00243032 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00243032.messageArray.Add("Error: Still connecting to the lobby chat! Please wait a few seconds...");
					result = (YieldDefault(2) ? 1 : 0);
					break;
				case 2:
					_0024self__00243032.scrollPos.y = 1000000f;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal AdjustCamDistance _0024self__00243033;

		public _0024errorChatMessage_00243031(AdjustCamDistance self_)
		{
			_0024self__00243033 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00243033);
		}
	}

	[Serializable]
	internal sealed class _0024sendChat_00243034 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal bool _0024isPM_00243035;

			internal bool _0024userOnline_00243036;

			internal PhotonPlayer _0024pp_00243037;

			internal int _0024_0024384_00243038;

			internal PhotonPlayer[] _0024_0024385_00243039;

			internal int _0024_0024386_00243040;

			internal string _0024message_00243041;

			internal string _0024user_00243042;

			internal PhotonMessageInfo _0024info_00243043;

			internal AdjustCamDistance _0024self__00243044;

			public _0024(string message, string user, PhotonMessageInfo info, AdjustCamDistance self_)
			{
				_0024message_00243041 = message;
				_0024user_00243042 = user;
				_0024info_00243043 = info;
				_0024self__00243044 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024user_00243042 == "CarbonTech" || _0024user_00243042 == "nattyfrank" || _0024user_00243042 == "techietotoro" || _0024user_00243042 == "Apophis" || _0024user_00243042 == "TheGoodGuy" || _0024user_00243042 == "Nattyfrank")
					{
						_0024user_00243042 = "[mod] " + _0024user_00243042;
					}
					_0024isPM_00243035 = false;
					_0024userOnline_00243036 = false;
					if (_0024message_00243041.Contains("|"))
					{
						_0024isPM_00243035 = true;
						_0024_0024384_00243038 = 0;
						_0024_0024385_00243039 = PhotonNetwork.playerList;
						for (_0024_0024386_00243040 = _0024_0024385_00243039.Length; _0024_0024384_00243038 < _0024_0024386_00243040; _0024_0024384_00243038++)
						{
							if (_0024_0024385_00243039[_0024_0024384_00243038].name == _0024message_00243041.Split("|"[0])[1].Replace("|", string.Empty))
							{
								_0024userOnline_00243036 = true;
							}
						}
					}
					if (!_0024isPM_00243035)
					{
						_0024self__00243044.messageArray.Add(_0024user_00243042 + ": " + _0024message_00243041);
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					if (_0024userOnline_00243036)
					{
						if (AuthGameObject.username == _0024message_00243041.Split("|"[0])[1].Replace("|", string.Empty) || RuntimeServices.EqualityOperator(_0024info_00243043.sender, PhotonNetwork.player))
						{
							_0024self__00243044.messageArray.Add("(private) " + _0024user_00243042 + ": " + _0024message_00243041.Split("|"[0])[0].Replace("|", string.Empty));
							result = (YieldDefault(3) ? 1 : 0);
							break;
						}
					}
					else if (RuntimeServices.EqualityOperator(_0024info_00243043.sender, PhotonNetwork.player))
					{
						_0024self__00243044.messageArray.Add("[User is not online]");
						result = (YieldDefault(4) ? 1 : 0);
						break;
					}
					goto IL_030f;
				case 2:
					_0024self__00243044.scrollPos.y = 1000000f;
					goto IL_030f;
				case 3:
					_0024self__00243044.scrollPos.y = 1000000f;
					goto IL_030f;
				case 4:
					_0024self__00243044.scrollPos.y = 1000000f;
					goto IL_030f;
				case 1:
					{
						result = 0;
						break;
					}
					IL_030f:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal string _0024message_00243045;

		internal string _0024user_00243046;

		internal PhotonMessageInfo _0024info_00243047;

		internal AdjustCamDistance _0024self__00243048;

		public _0024sendChat_00243034(string message, string user, PhotonMessageInfo info, AdjustCamDistance self_)
		{
			_0024message_00243045 = message;
			_0024user_00243046 = user;
			_0024info_00243047 = info;
			_0024self__00243048 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024message_00243045, _0024user_00243046, _0024info_00243047, _0024self__00243048);
		}
	}

	[Serializable]
	internal sealed class _0024fetchChangelog_00243049 : GenericGenerator<WWW>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WWW>, IEnumerator
		{
			internal WWW _0024www_00243050;

			internal AdjustCamDistance _0024self__00243051;

			public _0024(AdjustCamDistance self_)
			{
				_0024self__00243051 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024www_00243050 = new WWW("http://72.14.184.180/changelog.php");
					result = (Yield(2, _0024www_00243050) ? 1 : 0);
					break;
				case 2:
					if (string.IsNullOrEmpty(_0024www_00243050.error) && _0024www_00243050.text != PreloaderExplosion.versionNumber)
					{
						GameObject.Find("/AuthGameObject").SendMessage("fadeV");
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

		internal AdjustCamDistance _0024self__00243052;

		public _0024fetchChangelog_00243049(AdjustCamDistance self_)
		{
			_0024self__00243052 = self_;
		}

		public override IEnumerator<WWW> GetEnumerator()
		{
			return new _0024(_0024self__00243052);
		}
	}

	[Serializable]
	internal sealed class _0024fetchBanList_00243053 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal int _0024i_00243054;

			internal WWW _0024www_00243055;

			internal string[] _0024str_00243056;

			internal AdjustCamDistance _0024self__00243057;

			public _0024(AdjustCamDistance self_)
			{
				_0024self__00243057 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024i_00243054 = 0;
					goto IL_0119;
				case 2:
					if (string.IsNullOrEmpty(_0024www_00243055.error) && _0024www_00243055.text != string.Empty)
					{
						_0024str_00243056 = _0024www_00243055.text.Split("|"[0]);
						AuthGameObject.myIP = _0024str_00243056[0];
						if (_0024str_00243056[1] == "pass")
						{
							AuthGameObject.isBanned = false;
						}
						else if (_0024str_00243056[1] == "fail")
						{
							AuthGameObject.isBanned = true;
						}
						goto IL_0125;
					}
					result = (Yield(3, new WaitForSeconds(2f)) ? 1 : 0);
					break;
				case 3:
					_0024i_00243054++;
					goto IL_0119;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0119:
					if (_0024i_00243054 < 5)
					{
						_0024www_00243055 = new WWW("http://72.14.184.180/safetyFirst.php");
						result = (Yield(2, _0024www_00243055) ? 1 : 0);
						break;
					}
					goto IL_0125;
					IL_0125:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal AdjustCamDistance _0024self__00243058;

		public _0024fetchBanList_00243053(AdjustCamDistance self_)
		{
			_0024self__00243058 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00243058);
		}
	}

	[Serializable]
	internal sealed class _0024fetchProfileData_00243059 : GenericGenerator<WWW>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WWW>, IEnumerator
		{
			internal WWW _0024www_00243060;

			internal string[] _0024pArr_00243061;

			internal UnityScript.Lang.Array _0024tempDesc_00243062;

			internal UnityScript.Lang.Array _0024tempVal_00243063;

			internal int _0024s_00243064;

			internal string _0024eString_00243065;

			internal string _0024str_00243066;

			internal int _0024_0024388_00243067;

			internal string[] _0024_0024389_00243068;

			internal int _0024_0024390_00243069;

			internal string _0024u_00243070;

			internal AdjustCamDistance _0024self__00243071;

			public _0024(string u, AdjustCamDistance self_)
			{
				_0024u_00243070 = u;
				_0024self__00243071 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024u_00243070.Replace(" ", string.Empty) != string.Empty)
					{
						_0024self__00243071.fetchUsername = _0024u_00243070;
						_0024www_00243060 = new WWW("http://72.14.184.180/profiles.php?username=" + _0024u_00243070);
						result = (Yield(2, _0024www_00243060) ? 1 : 0);
						break;
					}
					goto IL_07fd;
				case 2:
					if (_0024www_00243060.text == "0" || !string.IsNullOrEmpty(_0024www_00243060.error))
					{
						_0024self__00243071.profileData = "Username:" + _0024u_00243070 + ",Ranking:null,Credits:0,Loadout:null,Last_Login:null";
					}
					else
					{
						_0024self__00243071.profileData = _0024www_00243060.text;
						_0024pArr_00243061 = _0024self__00243071.profileData.Split(","[0]);
						_0024tempDesc_00243062 = new UnityScript.Lang.Array();
						_0024tempVal_00243063 = new UnityScript.Lang.Array();
						for (_0024s_00243064 = 7; _0024s_00243064 < UnityScript.Lang.Extensions.get_length((System.Array)_0024pArr_00243061); _0024s_00243064++)
						{
							_0024tempDesc_00243062.Add(_0024pArr_00243061[_0024s_00243064].Split(":"[0])[0] + ":");
							_0024tempVal_00243063.Add(_0024pArr_00243061[_0024s_00243064].Split(":"[0])[1]);
						}
						_0024self__00243071.statsDesc = (string[])_0024tempDesc_00243062.ToBuiltin(typeof(string));
						_0024self__00243071.statsValue = (string[])_0024tempVal_00243063.ToBuiltin(typeof(string));
						_0024self__00243071.profileUsername = _0024pArr_00243061[0].Split(":"[0])[1];
						_0024self__00243071.profileRanking = ((!(_0024pArr_00243061[1].Split(":"[0])[1] != "null")) ? "No Ranking" : _0024pArr_00243061[1].Split(":"[0])[1]);
						_0024self__00243071.profileCredits = UnityBuiltins.parseInt((!(_0024pArr_00243061[2].Split(":"[0])[1] != "null")) ? "0" : _0024pArr_00243061[2].Split(":"[0])[1]);
						_0024eString_00243065 = string.Empty;
						if (_0024pArr_00243061[3].Split(":"[0])[1] != "null")
						{
							_0024_0024388_00243067 = 0;
							_0024_0024389_00243068 = _0024pArr_00243061[3].Split(":"[0])[1].Split("#"[0]);
							for (_0024_0024390_00243069 = _0024_0024389_00243068.Length; _0024_0024388_00243067 < _0024_0024390_00243069; _0024_0024388_00243067++)
							{
								if (!_0024_0024389_00243068[_0024_0024388_00243067].Contains("-"))
								{
									if (_0024_0024389_00243068[_0024_0024388_00243067] != "false")
									{
										if (_0024eString_00243065 != string.Empty)
										{
											_0024eString_00243065 += ", " + _0024self__00243071.shopScript.autharraytoformat[UnityBuiltins.parseInt(_0024_0024389_00243068[_0024_0024388_00243067])];
										}
										else
										{
											_0024eString_00243065 = _0024self__00243071.shopScript.autharraytoformat[UnityBuiltins.parseInt(_0024_0024389_00243068[_0024_0024388_00243067])];
										}
									}
								}
								else
								{
									if (_0024_0024389_00243068[_0024_0024388_00243067].Split("-"[0])[0] != "false")
									{
										_0024eString_00243065 += ", " + _0024self__00243071.shopScript.autharraytoformat[UnityBuiltins.parseInt(_0024_0024389_00243068[_0024_0024388_00243067].Split("-"[0])[0])];
									}
									if (_0024_0024389_00243068[_0024_0024388_00243067].Split("-"[0])[1] != "false")
									{
										_0024eString_00243065 += ", " + _0024self__00243071.shopScript.autharraytoformat[UnityBuiltins.parseInt(_0024_0024389_00243068[_0024_0024388_00243067].Split("-"[0])[1])];
									}
								}
							}
						}
						else
						{
							_0024eString_00243065 = "Rocket Launcher, Plasma Blaster";
						}
						_0024self__00243071.profileEquipped = _0024eString_00243065;
						_0024self__00243071.profileLogin = ((!(_0024pArr_00243061[4].Split(":"[0])[1] != "null")) ? "Not Available" : _0024pArr_00243061[4].Split(":"[0])[1]);
						if (_0024self__00243071.profileLogin == "0")
						{
							_0024self__00243071.profileLogin = "Today";
						}
						else if (_0024self__00243071.profileLogin == "1")
						{
							_0024self__00243071.profileLogin = "Yesterday";
						}
						else if (_0024self__00243071.profileLogin != "Not Available")
						{
							_0024self__00243071.profileLogin += " days ago";
						}
						_0024self__00243071.profileXP = UnityBuiltins.parseInt((!(_0024pArr_00243061[5].Split(":"[0])[1] != "null")) ? "0" : _0024pArr_00243061[5].Split(":"[0])[1]);
						_0024self__00243071.profileItems = UnityBuiltins.parseInt((!(_0024pArr_00243061[6].Split(":"[0])[1] != "null")) ? "0" : _0024pArr_00243061[6].Split(":"[0])[1]);
						Debug.Log(_0024self__00243071.profileData);
						_0024self__00243071.StartCoroutine_Auto(_0024self__00243071.loadMyWorlds(_0024u_00243070));
						_0024self__00243071.StartCoroutine_Auto(_0024self__00243071.loadUserAch(_0024u_00243070));
					}
					goto IL_07fd;
				case 1:
					{
						result = 0;
						break;
					}
					IL_07fd:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal string _0024u_00243072;

		internal AdjustCamDistance _0024self__00243073;

		public _0024fetchProfileData_00243059(string u, AdjustCamDistance self_)
		{
			_0024u_00243072 = u;
			_0024self__00243073 = self_;
		}

		public override IEnumerator<WWW> GetEnumerator()
		{
			return new _0024(_0024u_00243072, _0024self__00243073);
		}
	}

	[Serializable]
	internal sealed class _0024loadUserAch_00243074 : GenericGenerator<WWW>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WWW>, IEnumerator
		{
			internal int _0024i_00243075;

			internal WWWForm _0024form_00243076;

			internal WWW _0024w_00243077;

			internal int _0024c_00243078;

			internal string _0024username_00243079;

			internal AdjustCamDistance _0024self__00243080;

			public _0024(string username, AdjustCamDistance self_)
			{
				_0024username_00243079 = username;
				_0024self__00243080 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00243080.userAchGot.Clear();
					_0024self__00243080.userAchGotCount = 0;
					for (_0024i_00243075 = 0; _0024i_00243075 < UnityScript.Lang.Extensions.get_length((System.Array)AuthGameObject.achStat); _0024i_00243075++)
					{
						_0024self__00243080.userAchGot.Add("0");
					}
					if (!_0024username_00243079.Contains("guest_"))
					{
						_0024form_00243076 = new WWWForm();
						_0024form_00243076.AddField("username", _0024username_00243079);
						_0024form_00243076.AddField("key", Md5Sum.ComputeMd5(_0024username_00243079 + global::DontDestroyOnLoad.hitcollider));
						_0024w_00243077 = new WWW("http://72.14.184.180/achInterface.php", _0024form_00243076);
						result = (Yield(2, _0024w_00243077) ? 1 : 0);
						break;
					}
					goto IL_0298;
				case 2:
					if (_0024w_00243077.error == null && _0024w_00243077.text != string.Empty && _0024w_00243077.text.Contains("|"))
					{
						_0024self__00243080.userAchGot.Clear();
						for (_0024c_00243078 = 0; _0024c_00243078 < UnityScript.Lang.Extensions.get_length((System.Array)AuthGameObject.achStat); _0024c_00243078++)
						{
							if (_0024c_00243078 < UnityScript.Lang.Extensions.get_length((System.Array)_0024w_00243077.text.Split("|"[0])))
							{
								if (_0024w_00243077.text.Split("|"[0])[_0024c_00243078] != "Done")
								{
									_0024self__00243080.userAchGot.Add(_0024w_00243077.text.Split("|"[0])[_0024c_00243078]);
									if (_0024w_00243077.text.Split("|"[0])[_0024c_00243078] == "1")
									{
										_0024self__00243080.userAchGotCount++;
									}
								}
							}
							else
							{
								_0024self__00243080.userAchGot.Add("0");
							}
						}
					}
					goto IL_0298;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0298:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal string _0024username_00243081;

		internal AdjustCamDistance _0024self__00243082;

		public _0024loadUserAch_00243074(string username, AdjustCamDistance self_)
		{
			_0024username_00243081 = username;
			_0024self__00243082 = self_;
		}

		public override IEnumerator<WWW> GetEnumerator()
		{
			return new _0024(_0024username_00243081, _0024self__00243082);
		}
	}

	[Serializable]
	internal sealed class _0024loadMyWorlds_00243083 : GenericGenerator<WWW>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WWW>, IEnumerator
		{
			internal WWW _0024worlds_00243084;

			internal bool _0024showMyWorlds_00243085;

			internal string _0024world_00243086;

			internal int _0024_0024392_00243087;

			internal string[] _0024_0024393_00243088;

			internal int _0024_0024394_00243089;

			internal string _0024u_00243090;

			internal AdjustCamDistance _0024self__00243091;

			public _0024(string u, AdjustCamDistance self_)
			{
				_0024u_00243090 = u;
				_0024self__00243091 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024worlds_00243084 = new WWW("http://72.14.184.180/listWorlds.php?search=" + _0024u_00243090);
					result = (Yield(2, _0024worlds_00243084) ? 1 : 0);
					break;
				case 2:
					if (string.IsNullOrEmpty(_0024worlds_00243084.error) && _0024worlds_00243084.text.Contains("|"))
					{
						_0024showMyWorlds_00243085 = true;
						DisplayTopPlayers.myWorldsArr.Clear();
						DisplayTopPlayers.myWorldsURL.Clear();
						_0024_0024392_00243087 = 0;
						_0024_0024393_00243088 = _0024worlds_00243084.text.Split("|"[0]);
						for (_0024_0024394_00243089 = _0024_0024393_00243088.Length; _0024_0024392_00243087 < _0024_0024394_00243089; _0024_0024392_00243087++)
						{
							if (_0024_0024393_00243088[_0024_0024392_00243087].Contains(","))
							{
								DisplayTopPlayers.myWorldsArr.Add(WWW.UnEscapeURL(_0024_0024393_00243088[_0024_0024392_00243087].Split(","[0])[0]));
								DisplayTopPlayers.myWorldsURL.Add(_0024_0024393_00243088[_0024_0024392_00243087].Split(","[0])[1]);
							}
						}
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

		internal string _0024u_00243092;

		internal AdjustCamDistance _0024self__00243093;

		public _0024loadMyWorlds_00243083(string u, AdjustCamDistance self_)
		{
			_0024u_00243092 = u;
			_0024self__00243093 = self_;
		}

		public override IEnumerator<WWW> GetEnumerator()
		{
			return new _0024(_0024u_00243092, _0024self__00243093);
		}
	}

	[Serializable]
	internal sealed class _0024backToMenu_00243094 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal Renderer _0024ren_00243095;

			internal int _0024_0024396_00243096;

			internal Renderer[] _0024_0024397_00243097;

			internal int _0024_0024398_00243098;

			internal AdjustCamDistance _0024self__00243099;

			public _0024(AdjustCamDistance self_)
			{
				_0024self__00243099 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00243099.menuSel = 0;
					_0024self__00243099.lastSel = 0;
					_0024self__00243099.lerpcounter = 3f;
					_0024self__00243099.lerptimeout = false;
					camstate = 1;
					_0024self__00243099.maincar.SendMessage("startStopRotate", true);
					result = (YieldDefault(2) ? 1 : 0);
					break;
				case 2:
					result = (YieldDefault(3) ? 1 : 0);
					break;
				case 3:
					result = (YieldDefault(4) ? 1 : 0);
					break;
				case 4:
					_0024_0024396_00243096 = 0;
					_0024_0024397_00243097 = _0024self__00243099.mainmeshes;
					for (_0024_0024398_00243098 = _0024_0024397_00243097.Length; _0024_0024396_00243096 < _0024_0024398_00243098; _0024_0024396_00243096++)
					{
						_0024_0024397_00243097[_0024_0024396_00243096].enabled = true;
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

		internal AdjustCamDistance _0024self__00243100;

		public _0024backToMenu_00243094(AdjustCamDistance self_)
		{
			_0024self__00243100 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00243100);
		}
	}

	[Serializable]
	internal sealed class _0024backToMenuReload_00243101 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal AdjustCamDistance _0024self__00243102;

			public _0024(AdjustCamDistance self_)
			{
				_0024self__00243102 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00243102.StartCoroutine_Auto(_0024self__00243102.backToMenu());
					result = (Yield(2, new WaitForSeconds(1f)) ? 1 : 0);
					break;
				case 2:
					RuntimeServices.SetProperty(GameObject.Find("/LoginWindow").GetComponent("LoginWindow"), "enabled", true);
					GameObject.Find("/LoginWindow").SendMessage("fadeOut");
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal AdjustCamDistance _0024self__00243103;

		public _0024backToMenuReload_00243101(AdjustCamDistance self_)
		{
			_0024self__00243103 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00243103);
		}
	}

	[Serializable]
	internal sealed class _0024goldwindow_00243104 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal AdjustCamDistance _0024self__00243105;

			public _0024(AdjustCamDistance self_)
			{
				_0024self__00243105 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__00243105.goldalpha < 1f)
					{
						_0024self__00243105.goldalpha += 4f * Time.deltaTime;
						result = (YieldDefault(2) ? 1 : 0);
					}
					else
					{
						_0024self__00243105.goldalpha = 1f;
						result = (Yield(3, new WaitForSeconds(4.5f)) ? 1 : 0);
					}
					break;
				case 3:
				case 4:
					if (_0024self__00243105.goldalpha > 0f)
					{
						_0024self__00243105.goldalpha -= 4f * Time.deltaTime;
						result = (YieldDefault(4) ? 1 : 0);
						break;
					}
					_0024self__00243105.goldalpha = 0f;
					LoginWindow.dailygold = false;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal AdjustCamDistance _0024self__00243106;

		public _0024goldwindow_00243104(AdjustCamDistance self_)
		{
			_0024self__00243106 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00243106);
		}
	}

	[Serializable]
	internal sealed class _0024startDragEvent_00243107 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal int _0024origposition_00243108;

			internal int _0024origrotation_00243109;

			internal float _0024lastpos_00243110;

			internal float _0024wantedrotation_00243111;

			internal float _0024_00241852_00243112;

			internal Quaternion _0024_00241853_00243113;

			internal Vector3 _0024_00241854_00243114;

			internal AdjustCamDistance _0024self__00243115;

			public _0024(AdjustCamDistance self_)
			{
				_0024self__00243115 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00243115.isdragging = true;
					_0024origposition_00243108 = (int)Input.mousePosition.x;
					_0024origrotation_00243109 = (int)_0024self__00243115.maincar.transform.rotation.eulerAngles.y;
					_0024lastpos_00243110 = (float)_0024origrotation_00243109 + ((float)_0024origposition_00243108 - Input.mousePosition.x) * 0.75f;
					goto case 2;
				case 2:
					if (Input.GetButton("Fire1"))
					{
						_0024wantedrotation_00243111 = (float)_0024origrotation_00243109 + ((float)_0024origposition_00243108 - Input.mousePosition.x) * 0.75f;
						if (_0024wantedrotation_00243111 != _0024lastpos_00243110)
						{
							_0024wantedrotation_00243111 = Mathf.Lerp(_0024lastpos_00243110, _0024wantedrotation_00243111, 5f * Time.deltaTime);
							_0024lastpos_00243110 = _0024wantedrotation_00243111;
						}
						if (!(_0024wantedrotation_00243111 <= 360f))
						{
							_0024wantedrotation_00243111 -= 360f;
						}
						if (!(_0024wantedrotation_00243111 >= 0f))
						{
							_0024wantedrotation_00243111 = 360f + _0024wantedrotation_00243111;
						}
						float num = (_0024_00241852_00243112 = _0024wantedrotation_00243111);
						Quaternion quaternion = (_0024_00241853_00243113 = _0024self__00243115.maincar.transform.rotation);
						Vector3 vector = (_0024_00241854_00243114 = _0024_00241853_00243113.eulerAngles);
						float num2 = (_0024_00241854_00243114.y = _0024_00241852_00243112);
						Vector3 vector2 = (_0024_00241853_00243113.eulerAngles = _0024_00241854_00243114);
						Quaternion quaternion2 = (_0024self__00243115.maincar.transform.rotation = _0024_00241853_00243113);
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024self__00243115.isdragging = false;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal AdjustCamDistance _0024self__00243116;

		public _0024startDragEvent_00243107(AdjustCamDistance self_)
		{
			_0024self__00243116 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00243116);
		}
	}

	[Serializable]
	internal sealed class _0024setUpWorldArrays_00243117 : GenericGenerator<WWW>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WWW>, IEnumerator
		{
			internal WWW _0024worlds_00243118;

			internal int _0024tw_00243119;

			internal AdjustCamDistance _0024self__00243120;

			public _0024(AdjustCamDistance self_)
			{
				_0024self__00243120 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024worlds_00243118 = new WWW("http://72.14.184.180/worldRating.php?query=l");
					result = (Yield(2, _0024worlds_00243118) ? 1 : 0);
					break;
				case 2:
					if (string.IsNullOrEmpty(_0024worlds_00243118.error) && _0024worlds_00243118.text != string.Empty)
					{
						for (_0024tw_00243119 = 0; _0024tw_00243119 < UnityBuiltins.parseInt(_0024worlds_00243118.text); _0024tw_00243119++)
						{
							DisplayTopPlayers.topWorldsArr.Add("Loading...");
							DisplayTopPlayers.topWorldsURL.Add("http://notloaded.notloaded");
							DisplayTopPlayers.topWorldsR.Add("--");
						}
					}
					_0024worlds_00243118 = new WWW("http://72.14.184.180/listWorlds.php?l=1");
					result = (Yield(3, _0024worlds_00243118) ? 1 : 0);
					break;
				case 3:
					if (string.IsNullOrEmpty(_0024worlds_00243118.error) && _0024worlds_00243118.text != string.Empty)
					{
						for (_0024tw_00243119 = 0; _0024tw_00243119 < UnityBuiltins.parseInt(_0024worlds_00243118.text); _0024tw_00243119++)
						{
							DisplayTopPlayers.newWorldsArr.Add("Loading...");
							DisplayTopPlayers.newWorldsURL.Add("http://notloaded.notloaded");
						}
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

		internal AdjustCamDistance _0024self__00243121;

		public _0024setUpWorldArrays_00243117(AdjustCamDistance self_)
		{
			_0024self__00243121 = self_;
		}

		public override IEnumerator<WWW> GetEnumerator()
		{
			return new _0024(_0024self__00243121);
		}
	}

	[Serializable]
	internal sealed class _0024addfriend_00243122 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal int _0024randomnumber_00243123;

			internal WWW _0024friends_00243124;

			internal Friend _0024newF_00243125;

			internal string _0024u_00243126;

			internal AdjustCamDistance _0024self__00243127;

			public _0024(string u, AdjustCamDistance self_)
			{
				_0024u_00243126 = u;
				_0024self__00243127 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00243127.gameObject.SendMessage("showStatus", "Friending...");
					_0024randomnumber_00243123 = UnityEngine.Random.Range(0, 99999);
					_0024friends_00243124 = new WWW("http://72.14.184.180/rankingsManager.php?request=addFriend&key=" + Md5Sum.ComputeMd5(global::DontDestroyOnLoad.hitcollider + _0024randomnumber_00243123.ToString()) + "&random=" + _0024randomnumber_00243123.ToString() + "&user=" + AuthGameObject.username + "&friend=" + _0024u_00243126);
					result = (Yield(2, _0024friends_00243124) ? 1 : 0);
					break;
				case 2:
					if (string.IsNullOrEmpty(_0024friends_00243124.error))
					{
						_0024newF_00243125 = new Friend(_0024u_00243126, false);
						AuthGameObject.friendsArr.Add(_0024newF_00243125);
						_0024self__00243127.gameObject.SendMessage("showStatus", "Friended Player");
						result = (Yield(3, new WaitForSeconds(1.5f)) ? 1 : 0);
					}
					else
					{
						_0024self__00243127.gameObject.SendMessage("showStatus", "Request Failed!");
						result = (Yield(4, new WaitForSeconds(1.5f)) ? 1 : 0);
					}
					break;
				case 3:
					_0024self__00243127.gameObject.SendMessage("hideStatus");
					goto IL_0194;
				case 4:
					_0024self__00243127.gameObject.SendMessage("hideStatus");
					goto IL_0194;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0194:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal string _0024u_00243128;

		internal AdjustCamDistance _0024self__00243129;

		public _0024addfriend_00243122(string u, AdjustCamDistance self_)
		{
			_0024u_00243128 = u;
			_0024self__00243129 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024u_00243128, _0024self__00243129);
		}
	}

	[Serializable]
	internal sealed class _0024unfriend_00243130 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal int _0024randomnumber_00243131;

			internal WWW _0024friends_00243132;

			internal int _0024i_00243133;

			internal string _0024u_00243134;

			internal AdjustCamDistance _0024self__00243135;

			public _0024(string u, AdjustCamDistance self_)
			{
				_0024u_00243134 = u;
				_0024self__00243135 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00243135.gameObject.SendMessage("showStatus", "Unfriending...");
					_0024randomnumber_00243131 = UnityEngine.Random.Range(0, 99999);
					_0024friends_00243132 = new WWW("http://72.14.184.180/rankingsManager.php?request=removeFriend&key=" + Md5Sum.ComputeMd5(global::DontDestroyOnLoad.hitcollider + _0024randomnumber_00243131.ToString()) + "&random=" + _0024randomnumber_00243131.ToString() + "&user=" + AuthGameObject.username + "&friend=" + _0024u_00243134);
					result = (Yield(2, _0024friends_00243132) ? 1 : 0);
					break;
				case 2:
					if (string.IsNullOrEmpty(_0024friends_00243132.error))
					{
						for (_0024i_00243133 = 0; _0024i_00243133 < AuthGameObject.friendsArr.length; _0024i_00243133++)
						{
							if (RuntimeServices.EqualityOperator(UnityRuntimeServices.GetProperty(AuthGameObject.friendsArr[_0024i_00243133], "username"), _0024u_00243134))
							{
								AuthGameObject.friendsArr.RemoveAt(_0024i_00243133);
								break;
							}
						}
						_0024self__00243135.gameObject.SendMessage("showStatus", "Unfriended Player");
						result = (Yield(3, new WaitForSeconds(1.5f)) ? 1 : 0);
					}
					else
					{
						_0024self__00243135.gameObject.SendMessage("showStatus", "Request Failed!");
						result = (Yield(4, new WaitForSeconds(1.5f)) ? 1 : 0);
					}
					break;
				case 3:
					_0024self__00243135.gameObject.SendMessage("hideStatus");
					goto IL_01e0;
				case 4:
					_0024self__00243135.gameObject.SendMessage("hideStatus");
					goto IL_01e0;
				case 1:
					{
						result = 0;
						break;
					}
					IL_01e0:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal string _0024u_00243136;

		internal AdjustCamDistance _0024self__00243137;

		public _0024unfriend_00243130(string u, AdjustCamDistance self_)
		{
			_0024u_00243136 = u;
			_0024self__00243137 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024u_00243136, _0024self__00243137);
		}
	}

	[Serializable]
	internal sealed class _0024loadTopMaps_00243138 : GenericGenerator<WWW>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WWW>, IEnumerator
		{
			internal WWW _0024worlds_00243139;

			internal int _0024counter_00243140;

			internal string _0024world_00243141;

			internal int _0024_0024400_00243142;

			internal string[] _0024_0024401_00243143;

			internal int _0024_0024402_00243144;

			internal int _0024start_00243145;

			internal int _0024stop_00243146;

			internal AdjustCamDistance _0024self__00243147;

			public _0024(int start, int stop, AdjustCamDistance self_)
			{
				_0024start_00243145 = start;
				_0024stop_00243146 = stop;
				_0024self__00243147 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024worlds_00243139 = new WWW("http://72.14.184.180/worldRating.php?query=returnTopConstrained&start=" + _0024start_00243145 + "&stop=" + _0024stop_00243146);
					result = (Yield(2, _0024worlds_00243139) ? 1 : 0);
					break;
				case 2:
					_0024counter_00243140 = 0;
					if (string.IsNullOrEmpty(_0024worlds_00243139.error) && _0024worlds_00243139.text.Contains("="))
					{
						_0024_0024400_00243142 = 0;
						_0024_0024401_00243143 = _0024worlds_00243139.text.Split("|"[0]);
						for (_0024_0024402_00243144 = _0024_0024401_00243143.Length; _0024_0024400_00243142 < _0024_0024402_00243144; _0024_0024400_00243142++)
						{
							if (_0024_0024401_00243143[_0024_0024400_00243142].Contains("="))
							{
								DisplayTopPlayers.topWorldsArr[_0024start_00243145 + _0024counter_00243140] = WWW.UnEscapeURL(_0024_0024401_00243143[_0024_0024400_00243142].Split("="[0])[0].Split(","[0])[0]);
								DisplayTopPlayers.topWorldsURL[_0024start_00243145 + _0024counter_00243140] = _0024_0024401_00243143[_0024_0024400_00243142].Split("="[0])[0].Split(","[0])[1];
								DisplayTopPlayers.topWorldsR[_0024start_00243145 + _0024counter_00243140] = (Mathf.Round(UnityBuiltins.parseFloat(_0024_0024401_00243143[_0024_0024400_00243142].Split("="[0])[1]) * 10f) / 10f).ToString();
							}
							_0024counter_00243140++;
						}
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

		internal int _0024start_00243148;

		internal int _0024stop_00243149;

		internal AdjustCamDistance _0024self__00243150;

		public _0024loadTopMaps_00243138(int start, int stop, AdjustCamDistance self_)
		{
			_0024start_00243148 = start;
			_0024stop_00243149 = stop;
			_0024self__00243150 = self_;
		}

		public override IEnumerator<WWW> GetEnumerator()
		{
			return new _0024(_0024start_00243148, _0024stop_00243149, _0024self__00243150);
		}
	}

	[Serializable]
	internal sealed class _0024loadNewMaps_00243151 : GenericGenerator<WWW>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WWW>, IEnumerator
		{
			internal WWW _0024worlds_00243152;

			internal int _0024counter_00243153;

			internal string _0024world_00243154;

			internal int _0024_0024404_00243155;

			internal string[] _0024_0024405_00243156;

			internal int _0024_0024406_00243157;

			internal int _0024start_00243158;

			internal int _0024stop_00243159;

			internal AdjustCamDistance _0024self__00243160;

			public _0024(int start, int stop, AdjustCamDistance self_)
			{
				_0024start_00243158 = start;
				_0024stop_00243159 = stop;
				_0024self__00243160 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024worlds_00243152 = new WWW("http://72.14.184.180/listWorlds.php?start=" + _0024start_00243158 + "&stop=" + _0024stop_00243159);
					result = (Yield(2, _0024worlds_00243152) ? 1 : 0);
					break;
				case 2:
					_0024counter_00243153 = 0;
					if (string.IsNullOrEmpty(_0024worlds_00243152.error) && _0024worlds_00243152.text.Contains("|"))
					{
						_0024_0024404_00243155 = 0;
						_0024_0024405_00243156 = _0024worlds_00243152.text.Split("|"[0]);
						for (_0024_0024406_00243157 = _0024_0024405_00243156.Length; _0024_0024404_00243155 < _0024_0024406_00243157; _0024_0024404_00243155++)
						{
							if (_0024_0024405_00243156[_0024_0024404_00243155].Contains(","))
							{
								DisplayTopPlayers.newWorldsArr[_0024start_00243158 + _0024counter_00243153] = WWW.UnEscapeURL(_0024_0024405_00243156[_0024_0024404_00243155].Split(","[0])[0]);
								DisplayTopPlayers.newWorldsURL[_0024start_00243158 + _0024counter_00243153] = _0024_0024405_00243156[_0024_0024404_00243155].Split(","[0])[1];
							}
							_0024counter_00243153++;
						}
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

		internal int _0024start_00243161;

		internal int _0024stop_00243162;

		internal AdjustCamDistance _0024self__00243163;

		public _0024loadNewMaps_00243151(int start, int stop, AdjustCamDistance self_)
		{
			_0024start_00243161 = start;
			_0024stop_00243162 = stop;
			_0024self__00243163 = self_;
		}

		public override IEnumerator<WWW> GetEnumerator()
		{
			return new _0024(_0024start_00243161, _0024stop_00243162, _0024self__00243163);
		}
	}

	[Serializable]
	internal sealed class _0024fadeSideOffset2_00243164 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal AdjustCamDistance _0024self__00243165;

			public _0024(AdjustCamDistance self_)
			{
				_0024self__00243165 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00243165.side2Cull = true;
					goto case 2;
				case 2:
					if (!(sideOffset2 >= 0f) && _0024self__00243165.showSide2)
					{
						sideOffset2 = Mathf.Min(0f, sideOffset2 + 2000f * Time.deltaTime);
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

		internal AdjustCamDistance _0024self__00243166;

		public _0024fadeSideOffset2_00243164(AdjustCamDistance self_)
		{
			_0024self__00243166 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00243166);
		}
	}

	[Serializable]
	internal sealed class _0024fadeOutSideOffset2_00243167 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal AdjustCamDistance _0024self__00243168;

			public _0024(AdjustCamDistance self_)
			{
				_0024self__00243168 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (!(sideOffset2 <= (float)(-Screen.height)) && !_0024self__00243168.showSide2)
					{
						sideOffset2 = Mathf.Max(-Screen.height, sideOffset2 - 2000f * Time.deltaTime);
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024self__00243168.side2Cull = false;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal AdjustCamDistance _0024self__00243169;

		public _0024fadeOutSideOffset2_00243167(AdjustCamDistance self_)
		{
			_0024self__00243169 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00243169);
		}
	}

	[Serializable]
	internal sealed class _0024fadeSideOffset_00243170 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal int _0024calcLength_00243171;

			internal string _0024wS_00243172;

			internal IEnumerator _0024_0024iterator_0024232_00243173;

			internal IEnumerator _0024_0024iterator_0024233_00243174;

			internal AdjustCamDistance _0024self__00243175;

			public _0024(AdjustCamDistance self_)
			{
				_0024self__00243175 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00243175.side1Cull = true;
					_0024calcLength_00243171 = 0;
					_0024wS_00243172 = string.Empty;
					_0024_0024iterator_0024232_00243173 = UnityRuntimeServices.GetEnumerator(DisplayTopPlayers.newWorldsURL);
					while (_0024_0024iterator_0024232_00243173.MoveNext())
					{
						object obj = _0024_0024iterator_0024232_00243173.Current;
						if (!(obj is string))
						{
							obj = RuntimeServices.Coerce(obj, typeof(string));
						}
						_0024wS_00243172 = (string)obj;
						if (_0024wS_00243172 == "http://notloaded.notloaded")
						{
							break;
						}
						_0024calcLength_00243171++;
					}
					if (_0024calcLength_00243171 < _0024self__00243175.curin)
					{
						_0024self__00243175.StartCoroutine_Auto(_0024self__00243175.loadNewMaps(_0024self__00243175.curin - 5, _0024self__00243175.curin));
					}
					_0024calcLength_00243171 = 0;
					_0024_0024iterator_0024233_00243174 = UnityRuntimeServices.GetEnumerator(DisplayTopPlayers.topWorldsURL);
					while (_0024_0024iterator_0024233_00243174.MoveNext())
					{
						object obj2 = _0024_0024iterator_0024233_00243174.Current;
						if (!(obj2 is string))
						{
							obj2 = RuntimeServices.Coerce(obj2, typeof(string));
						}
						_0024wS_00243172 = (string)obj2;
						if (_0024wS_00243172 == "http://notloaded.notloaded")
						{
							break;
						}
						_0024calcLength_00243171++;
					}
					if (_0024calcLength_00243171 < _0024self__00243175.curin2)
					{
						_0024self__00243175.StartCoroutine_Auto(_0024self__00243175.loadTopMaps(_0024self__00243175.curin2 - 5, _0024self__00243175.curin));
					}
					goto case 2;
				case 2:
					if (!(sideOffset >= 0f) && _0024self__00243175.showSide)
					{
						sideOffset = Mathf.Min(0f, sideOffset + 2000f * Time.deltaTime);
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

		internal AdjustCamDistance _0024self__00243176;

		public _0024fadeSideOffset_00243170(AdjustCamDistance self_)
		{
			_0024self__00243176 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00243176);
		}
	}

	[Serializable]
	internal sealed class _0024fadeOutSideOffset_00243177 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal AdjustCamDistance _0024self__00243178;

			public _0024(AdjustCamDistance self_)
			{
				_0024self__00243178 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (!(sideOffset <= (float)(-Screen.height)) && !_0024self__00243178.showSide)
					{
						sideOffset = Mathf.Max(-Screen.height, sideOffset - 2000f * Time.deltaTime);
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024self__00243178.side1Cull = false;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal AdjustCamDistance _0024self__00243179;

		public _0024fadeOutSideOffset_00243177(AdjustCamDistance self_)
		{
			_0024self__00243179 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00243179);
		}
	}

	[Serializable]
	internal sealed class _0024fadeChatOffset_00243180 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal AdjustCamDistance _0024self__00243181;

			public _0024(AdjustCamDistance self_)
			{
				_0024self__00243181 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00243181.chatCull = true;
					goto case 2;
				case 2:
					if (!(_0024self__00243181.chatOffset >= 0f) && _0024self__00243181.showChat)
					{
						_0024self__00243181.chatOffset = Mathf.Min(0f, _0024self__00243181.chatOffset + 2000f * Time.deltaTime);
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

		internal AdjustCamDistance _0024self__00243182;

		public _0024fadeChatOffset_00243180(AdjustCamDistance self_)
		{
			_0024self__00243182 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00243182);
		}
	}

	[Serializable]
	internal sealed class _0024fadeOutChatOffset_00243183 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal AdjustCamDistance _0024self__00243184;

			public _0024(AdjustCamDistance self_)
			{
				_0024self__00243184 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (PhotonNetwork.connectionStateDetailed != PeerState.JoinedLobby)
					{
						PhotonNetwork.LeaveRoom();
					}
					goto case 2;
				case 2:
					if (!(_0024self__00243184.chatOffset <= (float)(-Screen.height)) && !_0024self__00243184.showChat)
					{
						_0024self__00243184.chatOffset = Mathf.Max(-Screen.height, _0024self__00243184.chatOffset - 2000f * Time.deltaTime);
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024self__00243184.chatCull = false;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal AdjustCamDistance _0024self__00243185;

		public _0024fadeOutChatOffset_00243183(AdjustCamDistance self_)
		{
			_0024self__00243185 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00243185);
		}
	}

	[Serializable]
	internal sealed class _0024useItem_00243186 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string _0024itemid_00243187;

			internal string _0024amount_00243188;

			internal int _0024i_00243189;

			internal WWW _0024www_00243190;

			internal WWW _0024getKey_00243191;

			internal string _0024escaped_00243192;

			internal WWW _0024bitem_00243193;

			internal string _0024s_00243194;

			internal AdjustCamDistance _0024self__00243195;

			public _0024(string s, AdjustCamDistance self_)
			{
				_0024s_00243194 = s;
				_0024self__00243195 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024itemid_00243187 = _0024s_00243194.Split("|"[0])[0];
					_0024amount_00243188 = _0024s_00243194.Split("|"[0])[1];
					_0024i_00243189 = 0;
					goto IL_058c;
				case 2:
					if (_0024www_00243190.text.Contains("\"success\":true,\"remaining_uses\":0"))
					{
						_0024self__00243195.gameObject.SendMessage("showStatus", "Credits Added!");
						AuthGameObject.inventory[2] = (UnityBuiltins.parseInt(_0024self__00243195.returnGold()) + UnityBuiltins.parseInt(_0024amount_00243188.Split("-"[0])[1])).ToString() + "#" + AuthGameObject.inventory[2].Split("#"[0])[1] + "#" + AuthGameObject.inventory[2].Split("#"[0])[2] + "#" + AuthGameObject.inventory[2].Split("#"[0])[3] + "#" + AuthGameObject.inventory[2].Split("#"[0])[4] + "#" + LoginWindow.curday + "#" + AuthGameObject.inventory[2].Split("#"[0])[6];
						AuthGameObject.inventory[2] = _0024self__00243195.returnGoldEncrypted() + "#" + AuthGameObject.inventory[2].Split("#"[0])[1] + "#" + AuthGameObject.inventory[2].Split("#"[0])[2] + "#" + AuthGameObject.inventory[2].Split("#"[0])[3] + "#" + AuthGameObject.inventory[2].Split("#"[0])[4] + "#" + LoginWindow.curday + "#" + AuthGameObject.inventory[2].Split("#"[0])[6];
						_0024getKey_00243191 = new WWW("http://72.14.184.180/serverKeyGen.php?" + "username=" + Md5Sum.ComputeMd5(AuthGameObject.username + global::DontDestroyOnLoad.hitcollider));
						result = (Yield(3, _0024getKey_00243191) ? 1 : 0);
						break;
					}
					_0024i_00243189++;
					goto IL_058c;
				case 3:
					_0024escaped_00243192 = WWW.EscapeURL("#" + AuthGameObject.inventory[2].Split("#"[0])[1] + "#" + AuthGameObject.inventory[2].Split("#"[0])[2] + "#" + AuthGameObject.inventory[2].Split("#"[0])[3] + "#" + AuthGameObject.inventory[2].Split("#"[0])[4] + "#" + LoginWindow.curday + "#" + AuthGameObject.inventory[2].Split("#"[0])[6]);
					_0024bitem_00243193 = new WWW("http://72.14.184.180/storeInterface.php?" + "username=" + AuthGameObject.username + "&request=changevalue" + "&serverkey=" + Md5Sum.ComputeMd5(_0024getKey_00243191.text + global::DontDestroyOnLoad.hitcollider) + "&field=tokens&changeto=" + UnityBuiltins.parseInt(_0024self__00243195.returnGold()).ToString() + _0024escaped_00243192);
					result = (Yield(4, _0024bitem_00243193) ? 1 : 0);
					break;
				case 4:
					_0024self__00243195.gameObject.SendMessage("hideStatus");
					goto case 1;
				case 5:
					_0024self__00243195.gameObject.SendMessage("hideStatus");
					YieldDefault(1);
					goto case 1;
				case 1:
					{
						result = 0;
						break;
					}
					IL_058c:
					if (_0024i_00243189 < 3)
					{
						_0024www_00243190 = new WWW("http://72.14.184.180/kredsPost.php?gauth=" + KongregateAPI.gameAuthToken + "&uid=" + KongregateAPI.userId + "&iid=" + _0024itemid_00243187);
						result = (Yield(2, _0024www_00243190) ? 1 : 0);
					}
					else
					{
						_0024self__00243195.gameObject.SendMessage("showStatus", "Request Failed!\nTry Again Later");
						result = (Yield(5, new WaitForSeconds(1f)) ? 1 : 0);
					}
					break;
				}
				return (byte)result != 0;
			}
		}

		internal string _0024s_00243196;

		internal AdjustCamDistance _0024self__00243197;

		public _0024useItem_00243186(string s, AdjustCamDistance self_)
		{
			_0024s_00243196 = s;
			_0024self__00243197 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024s_00243196, _0024self__00243197);
		}
	}

	[Serializable]
	internal sealed class _0024buygoldFadeIn_00243198 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal AdjustCamDistance _0024self__00243199;

			public _0024(AdjustCamDistance self_)
			{
				_0024self__00243199 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__00243199.buygoldalpha < 1f)
					{
						_0024self__00243199.buygoldalpha += 4f * Time.deltaTime;
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024self__00243199.buygoldalpha = 1f;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal AdjustCamDistance _0024self__00243200;

		public _0024buygoldFadeIn_00243198(AdjustCamDistance self_)
		{
			_0024self__00243200 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00243200);
		}
	}

	[Serializable]
	internal sealed class _0024buygoldFadeOut_00243201 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal AdjustCamDistance _0024self__00243202;

			public _0024(AdjustCamDistance self_)
			{
				_0024self__00243202 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__00243202.buygoldalpha > 0f)
					{
						_0024self__00243202.buygoldalpha -= 4f * Time.deltaTime;
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024self__00243202.buygoldalpha = 0f;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal AdjustCamDistance _0024self__00243203;

		public _0024buygoldFadeOut_00243201(AdjustCamDistance self_)
		{
			_0024self__00243203 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00243203);
		}
	}

	public Transform spot1;

	public Transform spot2;

	public Transform spot3;

	public GameObject maincar;

	public GameObject maincarfake;

	public GameObject displaytopplayers;

	[NonSerialized]
	public static int camstate = 1;

	private bool lerptimeout;

	private float lerpcounter;

	public GUIStyle startbuttonstyle;

	public GUIStyle startbuttonstylegold;

	public GUIStyle highlightedbutton;

	public GUIStyle loading;

	public GUIStyle displaymessage;

	public GUIStyle labelstyle;

	public GUIStyle credwindow;

	public GUIStyle buttonstyle;

	public GUIStyle goldbuttonstyle;

	public GUIStyle goldlabelstyle;

	public GUIStyle alertStyle;

	public MasterServerScript mscript;

	public LoginWindow lwindow;

	public AuthGameObject authobj;

	public ShopGUI shopgui;

	public KongregateAPI kongapi;

	public DontDestroyOnLoad ddol;

	public PreloaderExplosion pex;

	public DisplayTopPlayers dplayer;

	public HeadlesssDedServer headless;

	private float offset;

	private float armoroffset;

	private float loadingoffset;

	private float creditsoffset;

	private bool lerpdown;

	private bool disponce;

	private float goldalpha;

	private float buygoldalpha;

	public Texture CCoval;

	public Texture goldicon;

	public Color logocolorcorrect;

	private int lastscreenheight;

	private bool isdragging;

	private string statustext;

	private bool noautolerp;

	public Renderer[] mainmeshes;

	public string[] menuStrings;

	public string[] levelTypes;

	public GUIStyle menuStyle;

	public GUIStyle subtoolbarStyle;

	public GUIStyle subtoolbarStyleProfile;

	public GUIStyle subtoolbarStyleButton;

	public GUIStyle classBarUnder;

	public GUIStyle classBarOver;

	public Texture goldTex;

	public Texture goldTexPremium;

	private int menuSel;

	private int lastSel;

	private float chatOffset;

	private bool showChat;

	public GUIStyle chatBackgroundStyle;

	private Vector2 scrollPos;

	private Vector2 scrollPos2;

	public GUISkin scrollBarSkin;

	private string chatText;

	private string searchText;

	private UnityScript.Lang.Array messageArray;

	public GUIStyle chatTextStyle;

	public GUIStyle chatTextStyleAlt;

	public GUIStyle buttonStyle;

	[NonSerialized]
	public static float sideOffset;

	private bool showSide;

	public Texture greytex;

	private int curin;

	private int curin2;

	private int curin3;

	public GUIStyle titleText;

	public GUIStyle rankingstyleButton;

	[NonSerialized]
	public static float sideOffset2;

	private bool showSide2;

	public int profileSel;

	public string[] profileStrings;

	public GUIStyle largeTextStyle;

	public GUIStyle titleTextLeft;

	private Vector2 scrollPos3;

	public Color greenColor;

	public GUIStyle labelStyle;

	public GUIStyle labelStyleAlt;

	public GUIStyle tooltipstyle;

	private float toolalpha;

	private bool fadetool;

	private int lastScreenSize;

	private bool chatCull;

	private bool side1Cull;

	private bool side2Cull;

	private string profileData;

	private string profileUsername;

	private string profileRanking;

	private int profileCredits;

	private string profileEquipped;

	private string profileLogin;

	private int profileXP;

	private int profileItems;

	public GUIStyle subtoolbarStyle2;

	public ShopGUI shopScript;

	private string fetchUsername;

	[NonSerialized]
	public static bool showRankWindow;

	private string changeLogText;

	private string[] changeLogList;

	private int changeLogIndex;

	private bool wasWarned;

	public GUIStyle blankStyle;

	public GUIStyle labelstyleShadow;

	public GUIStyle friendTexture;

	public GUIStyle friendButton;

	public GUIStyle friendButtonOffline;

	public GUIStyle friendButtonSub;

	private int friendStartIndex;

	private Vector2 psPos;

	private string[] statsDesc;

	private string[] statsValue;

	private UnityScript.Lang.Array userAchGot;

	private int userAchGotCount;

	public AdjustCamDistance()
	{
		lerptimeout = true;
		lerpcounter = 3f;
		armoroffset = -21f;
		loadingoffset = -70f;
		creditsoffset = -201f;
		statustext = "Loading Game Store...";
		chatText = "Type your message here; press enter to send";
		searchText = "Search...";
		messageArray = new UnityScript.Lang.Array("Welcome to the lobby chat! All messages are copy 'n pasteable (I hate games with non-selectable text as much as you do.)");
		curin = 5;
		curin2 = 5;
		curin3 = 12;
		profileData = string.Empty;
		profileUsername = string.Empty;
		profileRanking = string.Empty;
		profileEquipped = string.Empty;
		profileLogin = string.Empty;
		fetchUsername = string.Empty;
		changeLogText = "Loading version changelog...";
		psPos = Vector2.zero;
		userAchGot = new UnityScript.Lang.Array();
	}

	public virtual void OnGUI()
	{
		if (!HeadlesssDedServer.isServerHost)
		{
			GUI.depth = 2;
			GUI.skin = scrollBarSkin;
			GUILayout.BeginArea(new Rect(Screen.width / 2 + 170 - 210, (float)(Screen.height - 100) - -100f * (offset / -610f), 420f, 300f));
			if (AuthGameObject.friendsArr.length == 0)
			{
				GUILayout.Box("No friends to display", friendTexture, GUILayout.Width(420f), GUILayout.Height(300f));
			}
			else
			{
				GUILayout.Box(string.Empty, friendTexture, GUILayout.Width(420f), GUILayout.Height(300f));
				GUILayout.BeginArea(new Rect(25f, 15f, 370f, 85f));
				GUILayout.BeginHorizontal();
				GUILayout.FlexibleSpace();
				int num = Mathf.Min(AuthGameObject.friendsArr.length, friendStartIndex + 3);
				for (int i = friendStartIndex; i < num; i++)
				{
					object target = AuthGameObject.friendsArr[i];
					GUILayout.BeginVertical();
					if (RuntimeServices.ToBool(RuntimeServices.Invoke(typeof(GUILayout), "Button", new object[4]
					{
						RuntimeServices.InvokeBinaryOperator("op_Addition", RuntimeServices.InvokeBinaryOperator("op_Addition", UnityRuntimeServices.GetProperty(target, "username"), "\n"), (!RuntimeServices.ToBool(UnityRuntimeServices.GetProperty(target, "online"))) ? "- Offline" : "• Online"),
						(!RuntimeServices.ToBool(UnityRuntimeServices.GetProperty(target, "online"))) ? friendButtonOffline : friendButton,
						GUILayout.Width(105f),
						GUILayout.Height(60f)
					})))
					{
						Camera.main.SendMessage("fetchProfileData", UnityRuntimeServices.GetProperty(target, "username"));
						Camera.main.SendMessage("openProfileTab");
					}
					GUILayout.Space(2f);
					GUILayout.Space(2f);
					if (!RuntimeServices.ToBool(UnityRuntimeServices.GetProperty(target, "online")))
					{
						GUI.enabled = false;
					}
					if (GUILayout.Button("Join Game", friendButtonSub, GUILayout.Width(105f), GUILayout.Height(20f)))
					{
						if (PhotonNetwork.connectionStateDetailed != PeerState.JoinedLobby)
						{
							PhotonNetwork.LeaveRoom();
						}
						lerptimeout = false;
						lerpcounter = 3f;
						camstate = 2;
						menuSel = 1;
						lastSel = 1;
						GameObject.Find("/LoginWindow/MasterServer").SendMessage("joinFriendServer", UnityRuntimeServices.GetProperty(target, "username"));
					}
					GUI.enabled = true;
					GUILayout.EndVertical();
					if (i != num - 1)
					{
						GUILayout.Space(5f);
					}
				}
				GUILayout.FlexibleSpace();
				GUILayout.EndHorizontal();
				GUILayout.EndArea();
			}
			if (friendStartIndex > 0)
			{
				GUI.enabled = true;
			}
			else
			{
				GUI.enabled = false;
			}
			if (GUI.Button(new Rect(15f, 45f, 20f, 30f), "<", friendButtonSub))
			{
				friendStartIndex--;
			}
			if (friendStartIndex < AuthGameObject.friendsArr.length - 3)
			{
				GUI.enabled = true;
			}
			else
			{
				GUI.enabled = false;
			}
			if (GUI.Button(new Rect(385f, 45f, 20f, 30f), ">", friendButtonSub))
			{
				friendStartIndex++;
			}
			GUI.enabled = true;
			GUILayout.EndArea();
			Vector2 contentOffset = labelstyle.contentOffset;
			labelstyle.contentOffset = Vector2.zero;
			GUI.Label(new Rect(Screen.width - 55, Screen.height - 20, 55f, 20f), "v" + PreloaderExplosion.versionNumber.Split(" "[0])[0], labelstyleShadow);
			GUI.Label(new Rect(Screen.width - 55, Screen.height - 20, 55f, 20f), "v" + PreloaderExplosion.versionNumber.Split(" "[0])[0], labelstyle);
			labelstyle.contentOffset = contentOffset;
			if (chatOffset == 0f || sideOffset == 0f || sideOffset2 == 0f)
			{
				GUI.enabled = false;
			}
			if (chatOffset != 0f && sideOffset != 0f && sideOffset2 != 0f)
			{
				GUI.BeginGroup(new Rect(offset, Screen.height / 2 - 150, 450f, 400f));
				if (PhotonNetwork.connectionStateDetailed != PeerState.JoinedLobby)
				{
					GUI.enabled = false;
					if (GUI.Button(new Rect(-1f, 50f, 305f, 62f), new GUIContent("Connecting...", "Your firewall is blocking, or the lobby chat is stuck; try opening & closing the lobby chat"), highlightedbutton))
					{
						if (PhotonNetwork.connectionStateDetailed != PeerState.JoinedLobby)
						{
							PhotonNetwork.LeaveRoom();
						}
						lerptimeout = false;
						lerpcounter = 3f;
						camstate = 2;
						menuSel = 1;
						lastSel = 1;
						GameObject.Find("/LoginWindow/MasterServer").SendMessage("fadeInJoinMode");
					}
				}
				else
				{
					GUI.enabled = true;
					if (GUI.Button(new Rect(-1f, 50f, 305f, 62f), new GUIContent("Quick Play", "Automatically find a server to play in"), highlightedbutton))
					{
						if (!AuthGameObject.username.Contains("guest_") && !AuthGameObject.shop && !wasWarned)
						{
							wasWarned = true;
							GameObject.Find("/AuthGameObject").SendMessage("fadeI");
						}
						else
						{
							if (PhotonNetwork.connectionStateDetailed != PeerState.JoinedLobby)
							{
								PhotonNetwork.LeaveRoom();
							}
							lerptimeout = false;
							lerpcounter = 3f;
							camstate = 2;
							menuSel = 1;
							lastSel = 1;
							GameObject.Find("/LoginWindow/MasterServer").SendMessage("fadeInJoinMode");
						}
					}
				}
				GUI.enabled = true;
				if (!AuthGameObject.shop && AuthGameObject.username != string.Empty && !AuthGameObject.username.Contains("guest_"))
				{
					GUI.enabled = false;
				}
				else
				{
					GUI.enabled = true;
				}
				if (chatOffset == 0f || sideOffset == 0f || sideOffset2 == 0f)
				{
					GUI.enabled = false;
				}
				if (GUI.Button(new Rect(armoroffset, 120f, 305f, 62f), new GUIContent("Guns 'n Armor", "Buy and equip weapons, armor and items in the game store"), startbuttonstyle))
				{
					if (AuthGameObject.shop && !AuthGameObject.username.Contains("guest_"))
					{
						maincar.SendMessage("startStopRotate", false);
						lerptimeout = false;
						lerpcounter = 3f;
						camstate = 3;
						menuSel = 2;
						lastSel = 2;
					}
					else
					{
						RuntimeServices.SetProperty(GameObject.Find("/LoginWindow").GetComponent("LoginWindow"), "enabled", true);
						GameObject.Find("/LoginWindow").SendMessage("fadein");
					}
				}
				if (AuthGameObject.shop && ShopGUI.itemsBuy != 0)
				{
					GUI.Box(new Rect(armoroffset + 285f, 105f, 33f, 33f), ShopGUI.itemsBuy.ToString(), alertStyle);
				}
				GUI.enabled = true;
				if (chatOffset == 0f || sideOffset == 0f || sideOffset2 == 0f)
				{
					GUI.enabled = false;
				}
				if (GUI.Button(new Rect(-1f, 190f, 305f, 62f), new GUIContent("Newbie Training", "Learn the basics of Carbon Combat with this tutorial"), startbuttonstyle))
				{
					if (PhotonNetwork.connectionStateDetailed != PeerState.JoinedLobby)
					{
						PhotonNetwork.LeaveRoom();
					}
					lerptimeout = false;
					lerpcounter = 3f;
					camstate = 2;
					menuSel = 1;
					lastSel = 1;
					GameObject.Find("/LoginWindow/MasterServer").SendMessage("connectToTutorial");
				}
				if (GUI.Button(new Rect(creditsoffset, 280f, 200f, 62f), new GUIContent("Get Credits", "Get free credits or opt to purchase some"), startbuttonstylegold))
				{
					if (AuthGameObject.shop && !AuthGameObject.username.Contains("guest_"))
					{
						if (PreloaderExplosion.isKong)
						{
							if (buygoldalpha == 0f)
							{
								StartCoroutine_Auto(buygoldFadeIn());
							}
						}
						else
						{
							Application.ExternalEval("showCredits(" + AuthGameObject.inventory[0] + ")");
						}
					}
					else
					{
						RuntimeServices.SetProperty(GameObject.Find("/LoginWindow").GetComponent("LoginWindow"), "enabled", true);
						GameObject.Find("/LoginWindow").SendMessage("fadein");
					}
				}
				GUI.enabled = true;
				if (chatOffset == 0f || sideOffset == 0f || sideOffset2 == 0f)
				{
					GUI.enabled = false;
				}
				GUI.EndGroup();
			}
			GUI.color = Color.white;
			if (!(buygoldalpha <= 0f))
			{
				float a = buygoldalpha;
				Color color = GUI.color;
				float num2 = (color.a = a);
				Color color2 = (GUI.color = color);
				GUI.BeginGroup(new Rect(Screen.width / 2 - 225, Screen.height / 2 - 130, 450f, 260f));
				GUI.Box(new Rect(0f, 0f, 450f, 260f), "Buy Credits", credwindow);
				GUI.Label(new Rect(0f, 0f, 450f, 250f), "You can buy game credits with Kongregate kreds. Game credits can be used to purchase epic weapons, armors, and more!", goldlabelstyle);
				if (GUI.Button(new Rect(25f, 80f, 195f, 35f), "2000 credits for 20 kreds", goldbuttonstyle))
				{
					gameObject.SendMessage("showStatus", "Opening Window...");
					Application.ExternalEval("kongregate.mtx.purchaseItems([\"creds-2000\"], function(b){" + "   kongregateUnitySupport.getUnityObject().SendMessage('Main Camera', 'BoughtKreds', b.success.toString());" + "});");
				}
				if (GUI.Button(new Rect(230f, 80f, 195f, 35f), "4500 credits for 40 kreds", goldbuttonstyle))
				{
					gameObject.SendMessage("showStatus", "Opening Window...");
					Application.ExternalEval("kongregate.mtx.purchaseItems([\"creds-4500\"], function(b){" + "   kongregateUnitySupport.getUnityObject().SendMessage('Main Camera', 'BoughtKreds', b.success.toString());" + "});");
				}
				if (GUI.Button(new Rect(25f, 120f, 195f, 35f), "2500 credits for 25 kreds", goldbuttonstyle))
				{
					gameObject.SendMessage("showStatus", "Opening Window...");
					Application.ExternalEval("kongregate.mtx.purchaseItems([\"creds-2500\"], function(b){" + "   kongregateUnitySupport.getUnityObject().SendMessage('Main Camera', 'BoughtKreds', b.success.toString());" + "});");
				}
				if (GUI.Button(new Rect(230f, 120f, 195f, 35f), "6000 credits for 50 kreds", goldbuttonstyle))
				{
					gameObject.SendMessage("showStatus", "Opening Window...");
					Application.ExternalEval("kongregate.mtx.purchaseItems([\"creds-6000\"], function(b){" + "   kongregateUnitySupport.getUnityObject().SendMessage('Main Camera', 'BoughtKreds', b.success.toString());" + "});");
				}
				if (GUI.Button(new Rect(25f, 160f, 195f, 35f), "3250 credits for 30 kreds", goldbuttonstyle))
				{
					gameObject.SendMessage("showStatus", "Opening Window...");
					Application.ExternalEval("kongregate.mtx.purchaseItems([\"creds-3250\"], function(b){" + "   kongregateUnitySupport.getUnityObject().SendMessage('Main Camera', 'BoughtKreds', b.success.toString());" + "});");
				}
				if (GUI.Button(new Rect(230f, 160f, 195f, 35f), "8000 credits for 65 kreds", goldbuttonstyle))
				{
					gameObject.SendMessage("showStatus", "Opening Window...");
					Application.ExternalEval("kongregate.mtx.purchaseItems([\"creds-8000\"], function(b){" + "   kongregateUnitySupport.getUnityObject().SendMessage('Main Camera', 'BoughtKreds', b.success.toString());" + "});");
				}
				if (GUI.Button(new Rect(271f, 210f, 154f, 25f), "Close Window", buttonstyle))
				{
					StartCoroutine_Auto(buygoldFadeOut());
				}
				if (GUI.Button(new Rect(25f, 210f, 235f, 25f), "Click Here to Get More Kreds!", buttonstyle))
				{
					Application.ExternalEval("kongregate.mtx.showKredPurchaseDialog('offers');");
				}
				GUI.EndGroup();
			}
			if (LoginWindow.dailygold)
			{
				GUI.color = logocolorcorrect;
				float a2 = goldalpha;
				Color color4 = GUI.color;
				float num3 = (color4.a = a2);
				Color color5 = (GUI.color = color4);
				GUI.BeginGroup(new Rect(Screen.width / 2 - 225, Screen.height / 2 - 65, 450f, 130f));
				GUI.Box(new Rect(0f, 0f, 450f, 130f), "You Got " + LoginWindow.dailyGoldMult.ToString() + " Credits", displaymessage);
				GUI.Label(new Rect(0f, 0f, 450f, 130f), "You were awarded " + LoginWindow.dailyGoldMult.ToString() + " credits for playing today - come back tomorrow for " + (LoginWindow.dailyGoldMult + 10).ToString() + "!", labelstyle);
				GUI.DrawTexture(new Rect(65f, 25f, 47f, 35f), goldicon);
				GUI.EndGroup();
			}
		}
		GUI.enabled = true;
		if (chatCull)
		{
			GUILayout.BeginArea(new Rect(0f, chatOffset + 75f, Screen.width, Screen.height - 75));
			GUI.Box(new Rect(0f, 0f, Screen.width, Screen.height), "Lobby Chat", chatBackgroundStyle);
			GUI.enabled = true;
			GUILayout.BeginArea(new Rect(75f, Screen.height - 100, Screen.width, 25f));
			GUI.SetNextControlName("field");
			chatText = GUILayout.TextField(chatText, 300, GUILayout.Height(20f), GUILayout.Width(Screen.width - 300));
			if (GUI.GetNameOfFocusedControl() == "field")
			{
				if (chatText == "Type your message here; press enter to send")
				{
					chatText = string.Empty;
				}
			}
			else
			{
				chatText = "Type your message here; press enter to send";
			}
			GUILayout.EndArea();
			GUILayout.BeginArea(new Rect(Screen.width - 205, Screen.height - 100, Screen.width, 25f));
			GUI.SetNextControlName("search");
			searchText = GUILayout.TextField(searchText, 100, GUILayout.Height(20f), GUILayout.Width(190f));
			if (GUI.GetNameOfFocusedControl() == "search")
			{
				if (searchText == "Search...")
				{
					searchText = string.Empty;
				}
			}
			else
			{
				searchText = "Search...";
			}
			GUILayout.EndArea();
			GUILayout.BeginArea(new Rect(0f, 30f, Screen.width, Screen.height));
			GUILayout.BeginHorizontal();
			scrollPos = GUILayout.BeginScrollView(scrollPos, false, true, GUILayout.Height(Screen.height - 145));
			int num4 = 0;
			IEnumerator enumerator = UnityRuntimeServices.GetEnumerator(messageArray);
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				if (!(obj is string))
				{
					obj = RuntimeServices.Coerce(obj, typeof(string));
				}
				string text = (string)obj;
				GUILayout.BeginHorizontal();
				GUILayout.TextArea(text, (!((float)num4 / 2f).ToString().Contains(".")) ? chatTextStyleAlt : chatTextStyle);
				UnityRuntimeServices.Update(enumerator, text);
				GUILayout.EndHorizontal();
				num4++;
			}
			GUILayout.EndScrollView();
			scrollPos2 = GUILayout.BeginScrollView(scrollPos2, false, true, GUILayout.Width(200f), GUILayout.Height(Screen.height - 145));
			int j = 0;
			PhotonPlayer[] playerList = PhotonNetwork.playerList;
			for (int length = playerList.Length; j < length; j++)
			{
				if ((searchText == string.Empty || searchText == "Search..." || playerList[j].name.ToLower().Contains(searchText.ToLower())) && !playerList[j].name.Contains("*"))
				{
					GUI.enabled = true;
					if (GUILayout.Button(playerList[j].name.Replace("*", string.Empty), buttonStyle))
					{
						GUI.FocusControl("field");
						StartCoroutine_Auto(setPM(playerList[j].name.Replace("*", string.Empty)));
					}
				}
			}
			int k = 0;
			PhotonPlayer[] playerList2 = PhotonNetwork.playerList;
			for (int length2 = playerList2.Length; k < length2; k++)
			{
				if ((searchText == string.Empty || searchText == "Search..." || playerList2[k].name.ToLower().Contains(searchText.ToLower())) && playerList2[k].name.Contains("*"))
				{
					GUI.enabled = false;
					if (GUILayout.Button(playerList2[k].name.Replace("*", string.Empty), buttonStyle))
					{
						GUI.FocusControl("field");
						StartCoroutine_Auto(setPM(playerList2[k].name.Replace("*", string.Empty)));
					}
				}
			}
			IEnumerator enumerator2 = UnityRuntimeServices.GetEnumerator(MasterServerScript.ailist);
			while (enumerator2.MoveNext())
			{
				object obj2 = enumerator2.Current;
				if (!(obj2 is string))
				{
					obj2 = RuntimeServices.Coerce(obj2, typeof(string));
				}
				string text2 = (string)obj2;
				if (searchText == string.Empty || searchText == "Search..." || text2.ToLower().Contains(searchText.ToLower()))
				{
					GUI.enabled = false;
					if (!GUILayout.Button(text2, buttonStyle))
					{
					}
				}
			}
			GUILayout.EndScrollView();
			GUILayout.EndHorizontal();
			GUILayout.EndArea();
			GUI.enabled = true;
			GUILayout.EndArea();
		}
		if (Event.current.type == EventType.KeyDown && Event.current.character == '\n' && chatText.Replace(" ", string.Empty) != string.Empty && chatText != "Type your message here; press enter to send" && GUI.GetNameOfFocusedControl() == "field")
		{
			GameObject.Find("/AuthGameObject").SendMessage("gotAch", "Socializing");
			if (PhotonNetwork.connectionStateDetailed == PeerState.Joined)
			{
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("sendChat", PhotonTargets.All, chatText, AuthGameObject.username);
			}
			else
			{
				StartCoroutine_Auto(errorChatMessage());
			}
			chatText = string.Empty;
			GUI.FocusControl("field");
		}
		if (side1Cull)
		{
			int num5 = 0;
			string empty = string.Empty;
			GUILayout.BeginArea(new Rect(sideOffset, 75f, 400f, Screen.height - 75));
			GUI.Box(new Rect(0f, 0f, 400f, Screen.height + 40), "Popular Custom Maps", chatBackgroundStyle);
			for (int l = 0; l < 5; l++)
			{
				if (!((float)l / 2f).ToString().Contains("."))
				{
				}
				float a3 = 1f;
				Color color7 = GUI.color;
				float num6 = (color7.a = a3);
				Color color8 = (GUI.color = color7);
				if (RuntimeServices.ToBool(RuntimeServices.Invoke(typeof(GUI), "Button", new object[3]
				{
					new Rect(20f, 30 + l * 27, 360f, 25f),
					(l >= DisplayTopPlayers.topWorldsArr.length) ? "[Not loaded]" : RuntimeServices.InvokeBinaryOperator("op_Addition", RuntimeServices.InvokeBinaryOperator("op_Addition", RuntimeServices.InvokeBinaryOperator("op_Addition", RuntimeServices.InvokeBinaryOperator("op_Addition", "#" + (l + 1 + (curin2 - 5)).ToString() + ((l + 1 + (curin2 - 5) <= 999) ? "\t" : "\t\t"), DisplayTopPlayers.topWorldsArr[l + (curin2 - 5)]), " ("), DisplayTopPlayers.topWorldsR[l + (curin2 - 5)]), "/5)"),
					rankingstyleButton
				})) && l < DisplayTopPlayers.topWorldsArr.length)
				{
					menuSel = 1;
					StartCoroutine_Auto(fadeOutSideOffset());
					GameObject.Find("/WorldWindow").SendMessage("outsideOpenWindow", DisplayTopPlayers.topWorldsURL[l + (curin2 - 5)]);
				}
			}
			if (curin2 == 5)
			{
				GUI.enabled = false;
			}
			if (GUI.Button(new Rect(20f, 170f, 100f, 20f), "Last 5", buttonstyle))
			{
				curin2 -= 5;
			}
			GUI.enabled = true;
			if (curin2 == DisplayTopPlayers.topWorldsArr.length || curin2 + 5 > DisplayTopPlayers.topWorldsArr.length)
			{
				GUI.enabled = false;
			}
			if (GUI.Button(new Rect(280f, 170f, 100f, 20f), "Next 5", buttonstyle))
			{
				curin2 += 5;
				num5 = 0;
				IEnumerator enumerator3 = UnityRuntimeServices.GetEnumerator(DisplayTopPlayers.topWorldsURL);
				while (enumerator3.MoveNext())
				{
					object obj3 = enumerator3.Current;
					if (!(obj3 is string))
					{
						obj3 = RuntimeServices.Coerce(obj3, typeof(string));
					}
					empty = (string)obj3;
					if (empty == "http://notloaded.notloaded")
					{
						break;
					}
					num5++;
				}
				if (num5 < curin2)
				{
					StartCoroutine_Auto(loadTopMaps(curin2 - 5, curin2 - 1));
				}
			}
			GUI.enabled = true;
			GUI.Label(new Rect(20f, 195f, 360f, 30f), "New Maps", titleText);
			for (int l = 0; l < 5; l++)
			{
				if (!((float)l / 2f).ToString().Contains("."))
				{
				}
				float a4 = 1f;
				Color color10 = GUI.color;
				float num7 = (color10.a = a4);
				Color color11 = (GUI.color = color10);
				if (RuntimeServices.ToBool(RuntimeServices.Invoke(typeof(GUI), "Button", new object[3]
				{
					new Rect(20f, 75 + l * 27 + 140 + 10, 360f, 25f),
					(l >= DisplayTopPlayers.newWorldsArr.length) ? "[Not loaded]" : RuntimeServices.InvokeBinaryOperator("op_Addition", "#" + (l + 1 + (curin - 5)).ToString() + ((l + 1 + (curin - 5) <= 999) ? "\t" : "\t\t"), DisplayTopPlayers.newWorldsArr[l + (curin - 5)]),
					rankingstyleButton
				})) && l < DisplayTopPlayers.newWorldsArr.length)
				{
					menuSel = 1;
					StartCoroutine_Auto(fadeOutSideOffset());
					GameObject.Find("/WorldWindow").SendMessage("outsideOpenWindow", DisplayTopPlayers.newWorldsURL[l + (curin - 5)]);
				}
			}
			if (curin == 5)
			{
				GUI.enabled = false;
			}
			if (GUI.Button(new Rect(20f, 365f, 100f, 20f), "Last 5", buttonstyle))
			{
				curin -= 5;
			}
			GUI.enabled = true;
			if (curin == DisplayTopPlayers.newWorldsArr.length || curin + 5 > DisplayTopPlayers.newWorldsArr.length)
			{
				GUI.enabled = false;
			}
			if (GUI.Button(new Rect(280f, 365f, 100f, 20f), "Next 5", buttonstyle))
			{
				curin += 5;
				num5 = 0;
				IEnumerator enumerator4 = UnityRuntimeServices.GetEnumerator(DisplayTopPlayers.newWorldsURL);
				while (enumerator4.MoveNext())
				{
					object obj4 = enumerator4.Current;
					if (!(obj4 is string))
					{
						obj4 = RuntimeServices.Coerce(obj4, typeof(string));
					}
					empty = (string)obj4;
					if (empty == "http://notloaded.notloaded")
					{
						break;
					}
					num5++;
				}
				if (num5 < curin)
				{
					StartCoroutine_Auto(loadNewMaps(curin - 5, curin));
				}
			}
			GUI.enabled = true;
			if (GUI.Button(new Rect(125f, 395f, 150f, 25f), "Create Your Own", buttonstyle))
			{
				Application.LoadLevel("Forge");
			}
			GUILayout.EndArea();
		}
		GUI.enabled = true;
		if (side2Cull)
		{
			GUILayout.BeginArea(new Rect(sideOffset2, 75f, 400f, Screen.height - 75));
			GUI.Box(new Rect(0f, 0f, 400f, Screen.height + 40), string.Empty, chatBackgroundStyle);
			GUILayout.BeginArea(new Rect(4f, 0f, 400f, Screen.height - 75));
			profileSel = GUILayout.Toolbar(profileSel, profileStrings, menuStyle, GUILayout.Width(392f), GUILayout.Height(25f));
			GUILayout.EndArea();
			if (profileSel == 0)
			{
				bool flag = false;
				IEnumerator enumerator5 = UnityRuntimeServices.GetEnumerator(AuthGameObject.friendsArr);
				while (enumerator5.MoveNext())
				{
					object obj5 = enumerator5.Current;
					if (!(obj5 is Friend))
					{
						obj5 = RuntimeServices.Coerce(obj5, typeof(Friend));
					}
					Friend friend = (Friend)obj5;
					if (friend.username == profileUsername)
					{
						flag = true;
					}
				}
				psPos = GUI.BeginScrollView(new Rect(0f, 40f, 400f, Screen.height - 75 - 40), psPos, new Rect(0f, 0f, 375f, 690f));
				GUI.DrawTexture(new Rect(0f, 60f, 408f, 60f), greytex);
				GUI.DrawTexture(new Rect(0f, 210f, 408f, 340f), greytex);
				GUILayout.BeginArea(new Rect(8f, 0f, 375f, 690f));
				GUILayout.BeginVertical();
				GUILayout.Label("Browse Player Profiles", titleTextLeft);
				GUILayout.BeginHorizontal();
				fetchUsername = GUILayout.TextField(fetchUsername);
				GUILayout.Space(5f);
				GUILayout.BeginVertical(GUILayout.Width(110f));
				GUILayout.Space(5f);
				if (GUILayout.Button("Get Profile", buttonstyle, GUILayout.Width(100f), GUILayout.Height(20f)))
				{
					StartCoroutine_Auto(fetchProfileData(fetchUsername));
					fetchUsername = string.Empty;
				}
				GUILayout.EndVertical();
				GUILayout.Space(20f);
				GUILayout.EndHorizontal();
				GUILayout.Space(35f);
				GUILayout.BeginHorizontal();
				GUILayout.Label("Profile for " + profileUsername, largeTextStyle);
				GUILayout.Space(10f);
				if (!AuthGameObject.username.Contains("guest_") && GUILayout.Button((!flag) ? "Friend" : "Unfriend", buttonstyle, GUILayout.Width(100f), GUILayout.Height(20f)))
				{
					if (flag)
					{
						StartCoroutine_Auto(unfriend(profileUsername));
					}
					else
					{
						StartCoroutine_Auto(addfriend(profileUsername));
					}
				}
				GUILayout.FlexibleSpace();
				GUILayout.EndHorizontal();
				GUILayout.BeginHorizontal();
				GUILayout.Label("Last played: " + profileLogin, subtoolbarStyle2);
				GUILayout.FlexibleSpace();
				GUILayout.Label("Global Rank: " + ((!(profileRanking.ToString() != "No Ranking")) ? string.Empty : "#") + profileRanking.ToString(), subtoolbarStyle2);
				GUILayout.Space(20f);
				GUILayout.EndHorizontal();
				GUILayout.Space(20f);
				GUILayout.Label("Rank & XP", titleTextLeft);
				GUILayout.BeginHorizontal();
				GUILayout.BeginVertical();
				GUILayout.Space(4f);
				GUILayout.Box(string.Empty, classBarUnder, GUILayout.Width(250f));
				GUILayout.EndVertical();
				GUILayout.Space(-25f);
				GUILayout.Label(Mathf.Round((profileXP != 10000) ? ((float)profileXP % 1000f / 1000f * 100f) : 100f).ToString() + "% - " + ((profileXP != 10000) ? (profileXP % 1000) : 1000).ToString() + "/1000", subtoolbarStyle);
				GUILayout.EndHorizontal();
				GUILayout.Space(-5f);
				GUILayout.BeginHorizontal();
				GUILayout.Label("Total XP: " + profileXP.ToString(), subtoolbarStyle);
				GUILayout.EndHorizontal();
				GUILayout.Space(-10f);
				GUILayout.Label("Class: \"" + ((!profileUsername.Contains("guest_")) ? (levelTypes[Mathf.Min(9, (profileXP - profileXP % 1000) / 1000)] + "\" (lvl " + (Mathf.Min(9, (profileXP - profileXP % 1000) / 1000) + 1).ToString() + ")") : "Guest\" (lvl 0)"), subtoolbarStyle);
				GUILayout.Space(20f);
				GUILayout.Label("Game Stats", titleTextLeft);
				GUILayout.BeginVertical();
				GUILayout.Space(9f);
				if (statsDesc != null && statsValue != null)
				{
					for (int m = 0; m < UnityScript.Lang.Extensions.get_length((System.Array)statsDesc); m++)
					{
						GUILayout.BeginHorizontal();
						GUILayout.Label(statsDesc[m], subtoolbarStyleProfile);
						GUILayout.Space(5f);
						GUILayout.Label(statsValue[m], subtoolbarStyle2);
						GUILayout.FlexibleSpace();
						GUILayout.EndHorizontal();
						GUILayout.Space(5f);
					}
				}
				GUILayout.EndVertical();
				GUILayout.Space(20f);
				GUILayout.Label("Game Store", titleTextLeft);
				GUILayout.BeginHorizontal();
				GUILayout.BeginVertical();
				GUILayout.Space(9f);
				GUILayout.BeginHorizontal();
				GUILayout.Label("Credits:", subtoolbarStyleProfile);
				GUILayout.Space(5f);
				GUILayout.Label(profileCredits.ToString(), subtoolbarStyle2);
				GUILayout.FlexibleSpace();
				GUILayout.Space(10f);
				GUILayout.EndHorizontal();
				GUILayout.EndVertical();
				GUILayout.EndHorizontal();
				GUILayout.Space(5f);
				GUILayout.BeginHorizontal();
				GUILayout.Label("Items Owned:", subtoolbarStyleProfile);
				GUILayout.Space(5f);
				GUILayout.Label(profileItems + "/" + "49", subtoolbarStyle2);
				GUILayout.FlexibleSpace();
				GUILayout.Space(10f);
				GUILayout.EndHorizontal();
				GUILayout.Space(5f);
				GUILayout.BeginHorizontal();
				GUILayout.Label("Equipped Items:", subtoolbarStyleProfile);
				GUILayout.Space(5f);
				GUILayout.Label(profileEquipped, subtoolbarStyle2);
				GUILayout.FlexibleSpace();
				GUILayout.Space(10f);
				GUILayout.EndHorizontal();
				GUILayout.EndVertical();
				GUILayout.EndArea();
				GUILayout.BeginArea(new Rect(10f, 1f, 375f, 690f));
				float a5 = 0f;
				Color color13 = GUI.color;
				float num8 = (color13.a = a5);
				Color color14 = (GUI.color = color13);
				GUILayout.BeginVertical();
				GUILayout.Label("Browse Player Profiles", titleTextLeft);
				GUILayout.BeginHorizontal();
				fetchUsername = GUILayout.TextField(fetchUsername);
				GUILayout.Space(5f);
				GUILayout.BeginVertical(GUILayout.Width(110f));
				GUILayout.Space(5f);
				if (GUILayout.Button("Get Profile", buttonstyle, GUILayout.Width(100f), GUILayout.Height(20f)))
				{
					StartCoroutine_Auto(fetchProfileData(fetchUsername));
					fetchUsername = string.Empty;
				}
				GUILayout.EndVertical();
				GUILayout.Space(10f);
				GUILayout.EndHorizontal();
				GUILayout.Space(35f);
				GUILayout.BeginHorizontal();
				GUILayout.Label("Profile for " + profileUsername, largeTextStyle);
				GUILayout.Space(10f);
				if (AuthGameObject.username.Contains("guest_") || GUILayout.Button((!flag) ? "Friend" : "Unfriend", buttonstyle, GUILayout.Width(100f), GUILayout.Height(20f)))
				{
				}
				GUILayout.FlexibleSpace();
				GUILayout.EndHorizontal();
				GUILayout.BeginHorizontal();
				GUILayout.Label("Last played: " + profileLogin, subtoolbarStyle2);
				GUILayout.FlexibleSpace();
				GUILayout.Label("Global Rank: " + ((!(profileRanking.ToString() != "No Ranking")) ? string.Empty : "#") + profileRanking.ToString(), subtoolbarStyle2);
				GUILayout.Space(20f);
				GUILayout.EndHorizontal();
				GUILayout.Space(20f);
				GUILayout.Label("Rank & XP", titleTextLeft);
				GUILayout.BeginVertical();
				GUILayout.Space(4f);
				float a6 = 1f;
				Color color16 = GUI.color;
				float num9 = (color16.a = a6);
				Color color17 = (GUI.color = color16);
				GUILayout.Box(string.Empty, classBarOver, GUILayout.Width((float)profileXP % 1000f / 1000f * 250f), GUILayout.Height(13f));
				GUILayout.EndVertical();
				GUILayout.EndVertical();
				GUILayout.EndArea();
				GUI.EndScrollView();
			}
			if (profileSel == 1)
			{
				GUILayout.BeginArea(new Rect(0f, 0f, 400f, Screen.height));
				GUI.Label(new Rect(10f, 40f, 380f, 20f), "This player has completed the achievements listed below (" + userAchGotCount.ToString() + " of " + userAchGot.length + ").", titleText);
				GUI.BeginGroup(new Rect(10f, 75f, 390f, Screen.height));
				bool flag2 = true;
				int num10 = 0;
				scrollPos3 = GUILayout.BeginScrollView(scrollPos3, false, true, GUILayout.Width(390f), GUILayout.Height(Screen.height - 160));
				GUILayout.BeginVertical();
				int num11 = 0;
				int n = 0;
				string[] achStat = AuthGameObject.achStat;
				for (int length3 = achStat.Length; n < length3; n++)
				{
					flag2 = !flag2;
					if (flag2)
					{
						GUI.color = Color.white;
						float a7 = 0.7f;
						Color color19 = GUI.color;
						float num12 = (color19.a = a7);
						Color color20 = (GUI.color = color19);
						GUI.Box(new Rect(0f, 35 * num10 - 10, 400f, 35f), string.Empty, labelStyleAlt);
					}
					num10++;
					float a8 = 1f;
					Color color22 = GUI.color;
					float num13 = (color22.a = a8);
					Color color23 = (GUI.color = color22);
					if (RuntimeServices.EqualityOperator(userAchGot[num11], "1"))
					{
						GUI.color = greenColor;
					}
					else
					{
						GUI.color = Color.white;
					}
					GUILayout.BeginHorizontal();
					GUILayout.Space(10f);
					GUILayout.Label(achStat[n], labelStyle);
					GUILayout.FlexibleSpace();
					GUILayout.Label((!RuntimeServices.EqualityOperator(AuthGameObject.achGot[num11], "1")) ? "(Description Hidden)" : AuthGameObject.achDescStat[num11], labelStyle);
					num11++;
					GUILayout.Space(15f);
					GUILayout.EndHorizontal();
					GUILayout.Space(20f);
				}
				GUILayout.EndVertical();
				GUILayout.EndScrollView();
				GUI.EndGroup();
				GUILayout.EndArea();
			}
			if (profileSel == 2)
			{
				for (int l = 0; l < 12; l++)
				{
					float a9 = 1f;
					Color color25 = GUI.color;
					float num14 = (color25.a = a9);
					Color color26 = (GUI.color = color25);
					if (RuntimeServices.ToBool(RuntimeServices.Invoke(typeof(GUI), "Button", new object[3]
					{
						new Rect(20f, 40 + l * 27, 360f, 25f),
						(l >= DisplayTopPlayers.myWorldsArr.length) ? "[Not loaded]" : RuntimeServices.InvokeBinaryOperator("op_Addition", "#" + (l + 1 + (curin3 - 12)).ToString() + ((l + 1 + (curin3 - 12) <= 999) ? "\t" : "\t\t"), DisplayTopPlayers.myWorldsArr[l + (curin3 - 12)]),
						rankingstyleButton
					})) && l < DisplayTopPlayers.myWorldsArr.length)
					{
						GameObject.Find("/WorldWindow").SendMessage("outsideOpenWindow", DisplayTopPlayers.myWorldsURL[l + (curin3 - 12)]);
					}
				}
				if (curin3 == 12)
				{
					GUI.enabled = false;
				}
				if (GUI.Button(new Rect(20f, 372f, 100f, 20f), "Last 12", buttonstyle))
				{
					curin3 -= 12;
				}
				GUI.enabled = true;
				if (curin3 == DisplayTopPlayers.myWorldsArr.length || curin3 + 12 > DisplayTopPlayers.myWorldsArr.length)
				{
					GUI.enabled = false;
				}
				if (GUI.Button(new Rect(280f, 372f, 100f, 20f), "Next 12", buttonstyle))
				{
					curin3 += 12;
				}
			}
			GUILayout.EndArea();
		}
		float a10 = 1f;
		Color color28 = GUI.color;
		float num15 = (color28.a = a10);
		Color color29 = (GUI.color = color28);
		GUI.enabled = true;
		GUI.BeginGroup(new Rect(0f, 0f, Screen.width, 75f));
		GUI.DrawTexture(new Rect(0f, 0f, Screen.width, 75f), CCoval);
		GUI.BeginGroup(new Rect(4f, 5f, Screen.width, 75f));
		menuSel = GUILayout.Toolbar(menuSel, menuStrings, menuStyle, GUILayout.Width(Screen.width - 8), GUILayout.Height(40f));
		GUI.EndGroup();
		GUILayout.BeginArea(new Rect(0f, 50f, Screen.width, 25f));
		GUILayout.BeginHorizontal();
		GUILayout.Label((!(AuthGameObject.username == string.Empty)) ? AuthGameObject.username : "Logging In", subtoolbarStyle);
		GUILayout.Space(20f);
		bool flag3 = showRankWindow;
		showRankWindow = GUILayout.Toggle(showRankWindow, AuthGameObject.username.Contains("guest_") ? "Not Ranked" : ((DisplayTopPlayers.myrankStat != 0) ? ("Globally Ranked #" + DisplayTopPlayers.myrankStat + " - " + DisplayTopPlayers.mypointsStat + " XP") : "Loading Rank..."), subtoolbarStyleButton);
		if (showRankWindow != flag3)
		{
			if (AuthGameObject.username != string.Empty && DisplayTopPlayers.fetchedRankings)
			{
				GameObject.Find("/DisplayTopPlayers").SendMessage("fade" + ((!showRankWindow) ? "Out" : "in"));
			}
			else
			{
				showRankWindow = flag3;
			}
		}
		GUILayout.Space(20f);
		string empty2 = string.Empty;
		empty2 = levelTypes[Mathf.Min(9, (DisplayTopPlayers.mypointsStat - DisplayTopPlayers.mypointsStat % 1000) / 1000)];
		GUILayout.Label(AuthGameObject.username.Contains("guest_") ? "\"Guest\" (lvl 0)" : ((DisplayTopPlayers.myrankStat != 0) ? ("\"" + empty2 + "\" (lvl " + (Mathf.Min(9, (DisplayTopPlayers.mypointsStat - DisplayTopPlayers.mypointsStat % 1000) / 1000) + 1).ToString() + ")") : "Loading Class..."), subtoolbarStyle);
		GUILayout.Space(5f);
		GUILayout.BeginVertical();
		GUILayout.Space(4f);
		GUILayout.Box(string.Empty, classBarUnder, GUILayout.Width(100f));
		GUILayout.EndVertical();
		GUILayout.Space(-5f);
		GUILayout.Label(Mathf.Round((!(empty2 == "CarbonTech")) ? ((float)DisplayTopPlayers.mypointsStat % 1000f / 1000f * 100f) : 100f).ToString() + "%", subtoolbarStyle);
		GUILayout.FlexibleSpace();
		GUILayout.BeginVertical();
		GUILayout.Space(1f);
		if (GUILayout.Button(new GUIContent(goldTexPremium, "Premium credits allow you to purchase awesome items like the Sprinter Body Kit. Click here to earn some!"), blankStyle, GUILayout.Width(20f), GUILayout.Height(20f)))
		{
			if (AuthGameObject.shop && !AuthGameObject.username.Contains("guest_"))
			{
				if (PreloaderExplosion.isKong)
				{
					Application.ExternalEval("alert(\"This action is not available on Kongregate. Please go to http://play.carbontechsoftware.com/ to earn free premium credits.\")");
				}
				else
				{
					Application.ExternalEval("showCreditsPrem(" + AuthGameObject.inventory[0] + ")");
				}
			}
			else
			{
				RuntimeServices.SetProperty(GameObject.Find("/LoginWindow").GetComponent("LoginWindow"), "enabled", true);
				GameObject.Find("/LoginWindow").SendMessage("fadein");
			}
		}
		GUILayout.EndVertical();
		GUILayout.Space(-10f);
		if (GUILayout.Button(new GUIContent((!AuthGameObject.shop) ? "0" : AuthGameObject.inventory[45], "Premium credits allow you to purchase awesome items like the Glider Body Kit. Click here to earn some!"), subtoolbarStyle))
		{
			if (AuthGameObject.shop && !AuthGameObject.username.Contains("guest_"))
			{
				if (PreloaderExplosion.isKong)
				{
					Application.ExternalEval("alert(\"This action is not available on Kongregate. Please go to http://play.carbontechsoftware.com/ to earn free premium credits.\")");
				}
				else
				{
					Application.ExternalEval("showCreditsPrem(" + AuthGameObject.inventory[0] + ")");
				}
			}
			else
			{
				RuntimeServices.SetProperty(GameObject.Find("/LoginWindow").GetComponent("LoginWindow"), "enabled", true);
				GameObject.Find("/LoginWindow").SendMessage("fadein");
			}
		}
		GUILayout.Space(10f);
		GUILayout.BeginVertical();
		GUILayout.Space(1f);
		if (GUILayout.Button(new GUIContent(goldTex, "Credits allow you to purchase items in the store. Click here to earn some!"), blankStyle, GUILayout.Width(20f), GUILayout.Height(20f)))
		{
			if (AuthGameObject.shop && !AuthGameObject.username.Contains("guest_"))
			{
				if (PreloaderExplosion.isKong)
				{
					if (buygoldalpha == 0f)
					{
						StartCoroutine_Auto(buygoldFadeIn());
					}
				}
				else
				{
					Application.ExternalEval("showCredits(" + AuthGameObject.inventory[0] + ")");
				}
			}
			else
			{
				RuntimeServices.SetProperty(GameObject.Find("/LoginWindow").GetComponent("LoginWindow"), "enabled", true);
				GameObject.Find("/LoginWindow").SendMessage("fadein");
			}
		}
		GUILayout.EndVertical();
		GUILayout.Space(-10f);
		if (GUILayout.Button(new GUIContent((!AuthGameObject.shop) ? "0" : returnGold(), "Credits allow you to purchase items in the store. Click here to earn some!"), subtoolbarStyle))
		{
			if (AuthGameObject.shop && !AuthGameObject.username.Contains("guest_"))
			{
				if (PreloaderExplosion.isKong)
				{
					if (buygoldalpha == 0f)
					{
						StartCoroutine_Auto(buygoldFadeIn());
					}
				}
				else
				{
					Application.ExternalEval("showCredits(" + AuthGameObject.inventory[0] + ")");
				}
			}
			else
			{
				RuntimeServices.SetProperty(GameObject.Find("/LoginWindow").GetComponent("LoginWindow"), "enabled", true);
				GameObject.Find("/LoginWindow").SendMessage("fadein");
			}
		}
		GUILayout.Space(10f);
		GUILayout.EndHorizontal();
		GUILayout.EndArea();
		GUILayout.BeginArea(new Rect(2f, 51f, Screen.width, 25f));
		float a11 = 0f;
		Color color31 = GUI.color;
		float num16 = (color31.a = a11);
		Color color32 = (GUI.color = color31);
		GUILayout.BeginHorizontal();
		GUILayout.Label((!(AuthGameObject.username == string.Empty)) ? AuthGameObject.username : "Logging In", subtoolbarStyle);
		GUILayout.Space(20f);
		showRankWindow = GUILayout.Toggle(showRankWindow, AuthGameObject.username.Contains("guest_") ? "Not Ranked" : ((DisplayTopPlayers.myrankStat != 0) ? ("Globally Ranked #" + DisplayTopPlayers.myrankStat + " - " + DisplayTopPlayers.mypointsStat + " XP") : "Loading Rank..."), subtoolbarStyleButton);
		GUILayout.Space(20f);
		empty2 = levelTypes[Mathf.Min(9, (DisplayTopPlayers.mypointsStat - DisplayTopPlayers.mypointsStat % 1000) / 1000)];
		GUILayout.Label(AuthGameObject.username.Contains("guest_") ? "\"Guest\" (lvl 0)" : ((DisplayTopPlayers.myrankStat != 0) ? ("\"" + empty2 + "\" (lvl " + (Mathf.Min(9f, ((float)DisplayTopPlayers.mypointsStat - (float)DisplayTopPlayers.mypointsStat % 1000f) / 1000f) + 1f).ToString() + ")") : "Loading Class..."), subtoolbarStyle);
		GUILayout.Space(5f);
		GUILayout.BeginVertical();
		GUILayout.Space(4f);
		float a12 = 1f;
		Color color34 = GUI.color;
		float num17 = (color34.a = a12);
		Color color35 = (GUI.color = color34);
		GUILayout.Box(string.Empty, classBarOver, GUILayout.Width((!(empty2 == "CarbonTech")) ? ((float)DisplayTopPlayers.mypointsStat % 1000f / 1000f * 100f) : 1f), GUILayout.Height(13f));
		GUILayout.EndVertical();
		GUILayout.FlexibleSpace();
		GUILayout.EndHorizontal();
		GUILayout.EndArea();
		GUI.EndGroup();
		if (menuSel != lastSel)
		{
			if (menuSel == 0)
			{
				StartCoroutine_Auto(backToMenu());
			}
			if (menuSel == 1)
			{
				if (!AuthGameObject.username.Contains("guest_") && !AuthGameObject.shop && !wasWarned)
				{
					wasWarned = true;
					menuSel = lastSel;
					GameObject.Find("/AuthGameObject").SendMessage("fadeI");
				}
				else if (PhotonNetwork.connectionStateDetailed == PeerState.JoinedLobby)
				{
					lerptimeout = false;
					lerpcounter = 3f;
					maincar.SendMessage("startStopRotate", true);
					camstate = 2;
				}
				else
				{
					menuSel = lastSel;
					PhotonNetwork.LeaveRoom();
				}
			}
			if (menuSel == 2)
			{
				if (AuthGameObject.shop && !AuthGameObject.username.Contains("guest_"))
				{
					maincar.SendMessage("startStopRotate", false);
					lerptimeout = false;
					lerpcounter = 3f;
					camstate = 3;
				}
				else
				{
					menuSel = 0;
					lastSel = 0;
					if (AuthGameObject.username.Contains("guest_") || AuthGameObject.username == string.Empty)
					{
						RuntimeServices.SetProperty(GameObject.Find("/LoginWindow").GetComponent("LoginWindow"), "enabled", true);
						GameObject.Find("/LoginWindow").SendMessage("fadein");
					}
				}
			}
			if (menuSel == 3)
			{
				showSide = true;
				StartCoroutine_Auto(fadeSideOffset());
			}
			if (menuSel == 4)
			{
				showSide2 = true;
				StartCoroutine_Auto(fadeSideOffset2());
			}
			if (menuSel == 5)
			{
				doChatSwitch();
			}
			lastSel = menuSel;
		}
		if (GUI.tooltip != string.Empty)
		{
			fadetool = true;
		}
		else
		{
			fadetool = false;
		}
		float a13 = toolalpha;
		Color color37 = GUI.color;
		float num18 = (color37.a = a13);
		Color color38 = (GUI.color = color37);
		GUI.Label(new Rect(Mathf.Min(Input.mousePosition.x, Screen.width - 324), Mathf.Min((float)Screen.height - Input.mousePosition.y + 15f - 27f, Screen.height - 70 - 27), 324f, 70f), GUI.tooltip, tooltipstyle);
		float a14 = 1f;
		Color color40 = GUI.color;
		float num19 = (color40.a = a14);
		Color color41 = (GUI.color = color40);
		GUI.enabled = true;
		GUI.BeginGroup(new Rect(Screen.width / 2 - 108, loadingoffset, 300f, 70f));
		GUI.Box(new Rect(0f, 0f, 216f, 88f), statustext, loading);
		GUI.EndGroup();
	}

	public virtual void doChatSwitch()
	{
		if (AuthGameObject.username != string.Empty)
		{
			if (PhotonNetwork.connectionStateDetailed == PeerState.JoinedLobby)
			{
				int i = 0;
				RoomInfo[] roomList = PhotonNetwork.GetRoomList();
				bool flag = default(bool);
				for (int length = roomList.Length; i < length; i++)
				{
					if (roomList[i].name == "chatRoom2")
					{
						flag = true;
					}
				}
				if (!flag)
				{
					PhotonNetwork.CreateRoom("chatRoom2", true, true, 100);
				}
				else
				{
					PhotonNetwork.JoinRoom("chatRoom2");
				}
			}
			showChat = true;
			StartCoroutine_Auto(fadeChatOffset());
		}
		else
		{
			menuSel = 0;
			lastSel = 0;
		}
	}

	public virtual IEnumerator setPM(string n)
	{
		return new _0024setPM_00243026(n, this).GetEnumerator();
	}

	public virtual IEnumerator errorChatMessage()
	{
		return new _0024errorChatMessage_00243031(this).GetEnumerator();
	}

	[RPC]
	public virtual IEnumerator sendChat(string message, string user, PhotonMessageInfo info)
	{
		return new _0024sendChat_00243034(message, user, info, this).GetEnumerator();
	}

	public virtual IEnumerator fetchChangelog()
	{
		return new _0024fetchChangelog_00243049(this).GetEnumerator();
	}

	public virtual IEnumerator fetchBanList()
	{
		return new _0024fetchBanList_00243053(this).GetEnumerator();
	}

	public virtual void openProfileTab()
	{
		if (menuSel != 4)
		{
			menuSel = 4;
			showSide2 = true;
			StartCoroutine_Auto(fadeSideOffset2());
		}
	}

	public virtual IEnumerator fetchProfileData(string u)
	{
		return new _0024fetchProfileData_00243059(u, this).GetEnumerator();
	}

	public virtual IEnumerator loadUserAch(string username)
	{
		return new _0024loadUserAch_00243074(username, this).GetEnumerator();
	}

	public virtual IEnumerator loadMyWorlds(string u)
	{
		return new _0024loadMyWorlds_00243083(u, this).GetEnumerator();
	}

	public virtual IEnumerator backToMenu()
	{
		return new _0024backToMenu_00243094(this).GetEnumerator();
	}

	public virtual IEnumerator backToMenuReload()
	{
		return new _0024backToMenuReload_00243101(this).GetEnumerator();
	}

	public virtual void Awake()
	{
		camstate = 1;
		sideOffset = 0f;
		sideOffset2 = 0f;
		showRankWindow = false;
		lastScreenSize = Screen.width * Screen.height;
	}

	public virtual IEnumerator goldwindow()
	{
		return new _0024goldwindow_00243104(this).GetEnumerator();
	}

	public virtual IEnumerator startDragEvent()
	{
		return new _0024startDragEvent_00243107(this).GetEnumerator();
	}

	public virtual bool checkIfOnline(string u)
	{
		RoomInfo[] roomList = PhotonNetwork.GetRoomList();
		int num = 0;
		int result;
		while (true)
		{
			if (num < UnityScript.Lang.Extensions.get_length((System.Array)roomList))
			{
				object obj = roomList[num].customProperties["comment"];
				if (!(obj is string))
				{
					obj = RuntimeServices.Coerce(obj, typeof(string));
				}
				string text = (string)obj;
				if (!string.IsNullOrEmpty(text))
				{
					string[] array = text.Split("|"[0]);
					string[] array2 = array[2].Split(","[0]);
					string[] array3 = array[3].Split(","[0]);
					string text2 = null;
					IEnumerator enumerator = array2.GetEnumerator();
					while (enumerator.MoveNext())
					{
						object obj2 = enumerator.Current;
						if (!(obj2 is string))
						{
							obj2 = RuntimeServices.Coerce(obj2, typeof(string));
						}
						text2 = (string)obj2;
						if (!(text2.Replace(" ", string.Empty) == u))
						{
							continue;
						}
						goto IL_00f6;
					}
					IEnumerator enumerator2 = array3.GetEnumerator();
					while (enumerator2.MoveNext())
					{
						object obj3 = enumerator2.Current;
						if (!(obj3 is string))
						{
							obj3 = RuntimeServices.Coerce(obj3, typeof(string));
						}
						text2 = (string)obj3;
						if (!(text2.Replace(" ", string.Empty) == u))
						{
							continue;
						}
						goto IL_015a;
					}
				}
				num++;
				continue;
			}
			result = 0;
			break;
			IL_015a:
			result = 1;
			break;
			IL_00f6:
			result = 1;
			break;
		}
		return (byte)result != 0;
	}

	public virtual void Update()
	{
		UnityScript.Lang.Array array = new UnityScript.Lang.Array();
		UnityScript.Lang.Array array2 = new UnityScript.Lang.Array();
		IEnumerator enumerator = UnityRuntimeServices.GetEnumerator(AuthGameObject.friendsArr);
		while (enumerator.MoveNext())
		{
			object obj = enumerator.Current;
			if (!(obj is Friend))
			{
				obj = RuntimeServices.Coerce(obj, typeof(Friend));
			}
			Friend friend = (Friend)obj;
			if (checkIfOnline(friend.username))
			{
				friend.online = true;
				UnityRuntimeServices.Update(enumerator, friend);
				array.Add(friend);
				UnityRuntimeServices.Update(enumerator, friend);
			}
			else
			{
				friend.online = false;
				UnityRuntimeServices.Update(enumerator, friend);
				array2.Add(friend);
				UnityRuntimeServices.Update(enumerator, friend);
			}
		}
		AuthGameObject.friendsArr = array.Concat(array2);
		if (profileUsername == string.Empty && AuthGameObject.username != string.Empty)
		{
			profileUsername = AuthGameObject.username;
			StartCoroutine_Auto(fetchProfileData(AuthGameObject.username));
		}
		if (fadetool)
		{
			toolalpha = Mathf.Min(1f, toolalpha + 4f * Time.deltaTime);
		}
		else
		{
			toolalpha = Mathf.Max(0f, toolalpha - 4f * Time.deltaTime);
		}
		if ((!showChat || menuSel != 5) && chatOffset == 0f)
		{
			showChat = false;
			StartCoroutine_Auto(fadeOutChatOffset());
		}
		if ((!showSide2 || menuSel != 4) && sideOffset2 == 0f)
		{
			showSide2 = false;
			StartCoroutine_Auto(fadeOutSideOffset2());
		}
		if ((!showSide || menuSel != 3) && sideOffset == 0f)
		{
			showSide = false;
			StartCoroutine_Auto(fadeOutSideOffset());
		}
		if (lastScreenSize != Screen.width * Screen.height)
		{
			if (!showChat)
			{
				StartCoroutine_Auto(fadeOutChatOffset());
			}
			else
			{
				StartCoroutine_Auto(fadeChatOffset());
			}
			if (!showSide)
			{
				StartCoroutine_Auto(fadeOutSideOffset());
			}
			else
			{
				StartCoroutine_Auto(fadeSideOffset());
			}
			if (!showSide2)
			{
				StartCoroutine_Auto(fadeOutSideOffset2());
			}
			else
			{
				StartCoroutine_Auto(fadeSideOffset2());
			}
			lastScreenSize = Screen.width * Screen.height;
		}
		if (LoginWindow.dailygold && !disponce)
		{
			disponce = true;
			StartCoroutine_Auto(goldwindow());
		}
		if (camstate != 3 && Screen.height != lastscreenheight)
		{
			lastscreenheight = Screen.height;
			float z = (1f - (float)Screen.height / 500f) * 7f;
			Vector3 localPosition = transform.localPosition;
			float num = (localPosition.z = z);
			Vector3 vector = (transform.localPosition = localPosition);
			float z2 = (1f - (float)Screen.height / 500f) * 7f;
			Vector3 localPosition2 = spot2.localPosition;
			float num2 = (localPosition2.z = z2);
			Vector3 vector3 = (spot2.localPosition = localPosition2);
			float z3 = (1f - (float)Screen.height / 500f) * 7f;
			Vector3 localPosition3 = spot1.localPosition;
			float num3 = (localPosition3.z = z3);
			Vector3 vector5 = (spot1.localPosition = localPosition3);
		}
		if (camstate == 1)
		{
			if (!lerptimeout)
			{
				transform.position = Vector3.Lerp(transform.position, spot1.position, 2.2f * Time.deltaTime);
				if (transform.localRotation.eulerAngles.y != 0f)
				{
					transform.rotation = Quaternion.Slerp(transform.rotation, spot1.rotation, Time.deltaTime * 2.2f);
				}
				offset = Mathf.Lerp(offset, 0f, 2.2f * Time.deltaTime);
				MasterServerScript.offset = Mathf.Lerp(MasterServerScript.offset, 1640f, 2.2f * Time.deltaTime);
				LoginWindow.offset = Mathf.Lerp(LoginWindow.offset, 150f, 2.2f * Time.deltaTime);
				ShopGUI.offset = Mathf.Lerp(ShopGUI.offset, 0f - ((float)Screen.height + 5f), 2.2f * Time.deltaTime);
			}
			else
			{
				offset = 0f;
				MasterServerScript.offset = 1640f;
				LoginWindow.offset = 150f;
				ShopGUI.offset = 0f - ((float)Screen.height + 5f);
				Vector3 vector7 = new Vector3(0f, 0f, -1.525879E-05f);
				Quaternion localRotation = transform.localRotation;
				Vector3 vector8 = (localRotation.eulerAngles = vector7);
				Quaternion quaternion = (transform.localRotation = localRotation);
			}
		}
		if (camstate == 2)
		{
			if (!lerptimeout)
			{
				transform.position = Vector3.Lerp(transform.position, spot2.position, 2.2f * Time.deltaTime);
				if (transform.localRotation.eulerAngles.y != 0f)
				{
					transform.rotation = Quaternion.Slerp(transform.rotation, spot1.rotation, Time.deltaTime * 2.2f);
				}
				offset = Mathf.Lerp(offset, -610f, 2.2f * Time.deltaTime);
				MasterServerScript.offset = Mathf.Lerp(MasterServerScript.offset, -2f, 2.2f * Time.deltaTime);
				LoginWindow.offset = Mathf.Lerp(LoginWindow.offset, 0f, 2.2f * Time.deltaTime);
				ShopGUI.offset = Mathf.Lerp(ShopGUI.offset, 0f - ((float)Screen.height + 5f), 2.2f * Time.deltaTime);
			}
			else
			{
				offset = -610f;
				MasterServerScript.offset = 0f;
				LoginWindow.offset = 0f;
				ShopGUI.offset = 0f - ((float)Screen.height + 5f);
				Vector3 vector10 = new Vector3(0f, 0f, -1.525879E-05f);
				Quaternion localRotation2 = transform.localRotation;
				Vector3 vector11 = (localRotation2.eulerAngles = vector10);
				Quaternion quaternion3 = (transform.localRotation = localRotation2);
			}
		}
		if (camstate == 3)
		{
			if (!lerptimeout)
			{
				transform.position = Vector3.Lerp(transform.position, spot3.position, 2.2f * Time.deltaTime);
				transform.rotation = Quaternion.Slerp(transform.rotation, spot3.rotation, Time.deltaTime * 2.2f);
				offset = Mathf.Lerp(offset, -610f, 2.2f * Time.deltaTime);
				MasterServerScript.offset = Mathf.Lerp(MasterServerScript.offset, 1640f, 2.2f * Time.deltaTime);
				LoginWindow.offset = Mathf.Lerp(LoginWindow.offset, 0f, 2.2f * Time.deltaTime);
				ShopGUI.offset = Mathf.Lerp(ShopGUI.offset, 0f, 4.5f * Time.deltaTime);
			}
			else
			{
				offset = -610f;
				MasterServerScript.offset = 1640f;
				LoginWindow.offset = 0f;
				ShopGUI.offset = 0f;
				if (Input.GetButtonDown("Fire1") && !isdragging && !(Input.mousePosition.y >= (float)(Screen.height - 340)) && !(Input.mousePosition.y <= 45f))
				{
					StartCoroutine_Auto(startDragEvent());
				}
			}
		}
		if (lerpdown)
		{
			loadingoffset = Mathf.Lerp(loadingoffset, -9f, 3.5f * Time.deltaTime);
		}
		else
		{
			loadingoffset = Mathf.Lerp(loadingoffset, -71f, 3.5f * Time.deltaTime);
		}
		if (!lerptimeout)
		{
			if (!(lerpcounter <= 0f))
			{
				lerpcounter -= Time.deltaTime;
			}
			else
			{
				lerpcounter = 3f;
				lerptimeout = true;
			}
		}
		else
		{
			lerpcounter = 3f;
		}
		if (AuthGameObject.username != string.Empty && !(armoroffset >= -1f))
		{
			armoroffset = Mathf.Lerp(armoroffset, 0f, Time.deltaTime * 2.2f);
		}
		if (AuthGameObject.username != string.Empty && !(creditsoffset >= -1f))
		{
			creditsoffset = Mathf.Lerp(creditsoffset, 0f, Time.deltaTime * 2.2f);
		}
	}

	public virtual IEnumerator setUpWorldArrays()
	{
		return new _0024setUpWorldArrays_00243117(this).GetEnumerator();
	}

	public virtual void Start()
	{
		DisplayTopPlayers.topWorldsArr.Clear();
		DisplayTopPlayers.topWorldsR.Clear();
		DisplayTopPlayers.topWorldsURL.Clear();
		DisplayTopPlayers.newWorldsArr.Clear();
		DisplayTopPlayers.newWorldsURL.Clear();
		StartCoroutine_Auto(setUpWorldArrays());
		if (!AuthGameObject.shop && !AuthGameObject.username.Contains("guest_") && AuthGameObject.username != string.Empty)
		{
			StartCoroutine_Auto(backToMenuReload());
		}
		StartCoroutine_Auto(fetchChangelog());
		StartCoroutine_Auto(fetchBanList());
		if (AuthGameObject.username != string.Empty && !(creditsoffset >= -1f) && !AuthGameObject.username.Contains("guest_") && AuthGameObject.shop && Application.isWebPlayer && PreloaderExplosion.isKong)
		{
			Application.ExternalEval("kongregate.mtx.requestUserItemList(null, function(b){" + "   for (var i = 0; i < b.data.length; i++) {" + "   \tkongregateUnitySupport.getUnityObject().SendMessage('Main Camera', 'useItem', b.data[0].id.toString() + '|' + b.data[0].identifier);" + "\t}" + "\t});");
		}
	}

	public virtual IEnumerator addfriend(string u)
	{
		return new _0024addfriend_00243122(u, this).GetEnumerator();
	}

	public virtual IEnumerator unfriend(string u)
	{
		return new _0024unfriend_00243130(u, this).GetEnumerator();
	}

	public virtual void goToServerList()
	{
		lerptimeout = false;
		lerpcounter = 3f;
		camstate = 2;
	}

	public virtual IEnumerator loadTopMaps(int start, int stop)
	{
		return new _0024loadTopMaps_00243138(start, stop, this).GetEnumerator();
	}

	public virtual IEnumerator loadNewMaps(int start, int stop)
	{
		return new _0024loadNewMaps_00243151(start, stop, this).GetEnumerator();
	}

	public virtual IEnumerator fadeSideOffset2()
	{
		return new _0024fadeSideOffset2_00243164(this).GetEnumerator();
	}

	public virtual IEnumerator fadeOutSideOffset2()
	{
		return new _0024fadeOutSideOffset2_00243167(this).GetEnumerator();
	}

	public virtual IEnumerator fadeSideOffset()
	{
		return new _0024fadeSideOffset_00243170(this).GetEnumerator();
	}

	public virtual IEnumerator fadeOutSideOffset()
	{
		return new _0024fadeOutSideOffset_00243177(this).GetEnumerator();
	}

	public virtual IEnumerator fadeChatOffset()
	{
		return new _0024fadeChatOffset_00243180(this).GetEnumerator();
	}

	public virtual IEnumerator fadeOutChatOffset()
	{
		return new _0024fadeOutChatOffset_00243183(this).GetEnumerator();
	}

	public virtual void BoughtKreds(string s)
	{
		if (s == "true")
		{
			gameObject.SendMessage("showStatus", "Sending Request...");
			Application.ExternalEval("kongregate.mtx.requestUserItemList(null, function(b){" + "   for (var i = 0; i < b.data.length; i++) {" + "   \tkongregateUnitySupport.getUnityObject().SendMessage('Main Camera', 'useItem', b.data[i].id.toString() + '|' + b.data[i].identifier);" + "\t}" + "\t});");
		}
	}

	public virtual IEnumerator useItem(string s)
	{
		return new _0024useItem_00243186(s, this).GetEnumerator();
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

	public virtual void showStatus(string s)
	{
		Debug.Log("Got status message: " + s);
		statustext = s;
		if (!(loadingoffset >= -10f))
		{
			lerpdown = true;
		}
	}

	public virtual void hideStatus()
	{
		Debug.Log("Closing status message");
		lerpdown = false;
	}

	public virtual IEnumerator buygoldFadeIn()
	{
		return new _0024buygoldFadeIn_00243198(this).GetEnumerator();
	}

	public virtual IEnumerator buygoldFadeOut()
	{
		return new _0024buygoldFadeOut_00243201(this).GetEnumerator();
	}

	public virtual void Main()
	{
	}
}
