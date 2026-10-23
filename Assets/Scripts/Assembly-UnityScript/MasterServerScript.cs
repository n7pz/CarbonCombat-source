using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using Photon;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class MasterServerScript : Photon.MonoBehaviour
{
	[Serializable]
	internal sealed class _0024fadeInJoinMode_00244840 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal MasterServerScript _0024self__00244841;

			public _0024(MasterServerScript self_)
			{
				_0024self__00244841 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__00244841.joinAlpha < 1f)
					{
						_0024self__00244841.joinAlpha = Mathf.Min(_0024self__00244841.joinAlpha + 4f * Time.deltaTime, 1f);
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024self__00244841.StartCoroutine_Auto(_0024self__00244841.quickJoin(_0024self__00244841.qjData));
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal MasterServerScript _0024self__00244842;

		public _0024fadeInJoinMode_00244840(MasterServerScript self_)
		{
			_0024self__00244842 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00244842);
		}
	}

	[Serializable]
	internal sealed class _0024fadeOutJoinMode_00244843 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal MasterServerScript _0024self__00244844;

			public _0024(MasterServerScript self_)
			{
				_0024self__00244844 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__00244844.joinAlpha > 0f)
					{
						_0024self__00244844.joinAlpha = Mathf.Max(_0024self__00244844.joinAlpha - 2f * Time.deltaTime, 0f);
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

		internal MasterServerScript _0024self__00244845;

		public _0024fadeOutJoinMode_00244843(MasterServerScript self_)
		{
			_0024self__00244845 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00244845);
		}
	}

	[Serializable]
	internal sealed class _0024Start_00244846 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal MasterServerScript _0024self__00244847;

			public _0024(MasterServerScript self_)
			{
				_0024self__00244847 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (!RuntimeServices.EqualityOperator(PhotonNetwork.room, null))
					{
						PhotonNetwork.LeaveRoom();
					}
					UnityEngine.Object.Destroy(GameObject.Find("WhirldIn"));
					UnityEngine.Object.Instantiate(_0024self__00244847.whirldpre, _0024self__00244847.transform.position, _0024self__00244847.transform.rotation);
					conobj = false;
					result = (YieldDefault(2) ? 1 : 0);
					break;
				case 2:
					result = (YieldDefault(3) ? 1 : 0);
					break;
				case 3:
					GameObject.Find("WhirldIn").GetComponent<WhirldIn>().enabled = true;
					if (PhotonNetwork.playerName.Contains("*"))
					{
						PhotonNetwork.playerName = PhotonNetwork.playerName.Replace("*", string.Empty);
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

		internal MasterServerScript _0024self__00244848;

		public _0024Start_00244846(MasterServerScript self_)
		{
			_0024self__00244848 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00244848);
		}
	}

	[Serializable]
	internal sealed class _0024fadeInDed_00244849 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal MasterServerScript _0024self__00244850;

			public _0024(MasterServerScript self_)
			{
				_0024self__00244850 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__00244850.alphaded < 1f)
					{
						_0024self__00244850.alphaded += 4f * Time.deltaTime;
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024self__00244850.alphaded = 1f;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal MasterServerScript _0024self__00244851;

		public _0024fadeInDed_00244849(MasterServerScript self_)
		{
			_0024self__00244851 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00244851);
		}
	}

	[Serializable]
	internal sealed class _0024fadeOutDed_00244852 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal MasterServerScript _0024self__00244853;

			public _0024(MasterServerScript self_)
			{
				_0024self__00244853 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__00244853.alphaded > 0f)
					{
						_0024self__00244853.alphaded -= 10f * Time.deltaTime;
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024self__00244853.alphaded = 0f;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal MasterServerScript _0024self__00244854;

		public _0024fadeOutDed_00244852(MasterServerScript self_)
		{
			_0024self__00244854 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00244854);
		}
	}

	[Serializable]
	internal sealed class _0024remotestartserver_00244855 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal Hashtable _0024h_00244856;

			internal string[] _0024ss_00244857;

			internal MasterServerScript _0024self__00244858;

			public _0024(MasterServerScript self_)
			{
				_0024self__00244858 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (PlayerPrefs.HasKey("tutorialKey"))
					{
						if (_0024self__00244858.mastererror == string.Empty)
						{
							_0024self__00244858.isconnecting = true;
							PhotonNetwork.LeaveRoom();
							goto case 2;
						}
					}
					else
					{
						_0024self__00244858.StartCoroutine_Auto(_0024self__00244858.connectToTutorial());
					}
					goto IL_0287;
				case 2:
					if (PhotonNetwork.connectionStateDetailed != PeerState.JoinedLobby)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024h_00244856 = new Hashtable();
					_0024h_00244856.Add("comment", AuthGameObject.username + "|" + AuthGameObject.gametype + "|" + AuthGameObject.username + "||" + AuthGameObject.whirldurl + ((!(CWFLoader.worldData != string.Empty)) ? string.Empty : "[CustomMap]") + "|||" + DisplayTopPlayers.mypointsStat + "|");
					_0024ss_00244857 = new string[1];
					_0024ss_00244857[0] = "comment";
					Debug.Log("Starting room with base name: " + ((!(gamenamestring == "More Maps")) ? gamenamestring : "Custom World"));
					PhotonNetwork.CreateRoom(((!(gamenamestring == "More Maps")) ? gamenamestring : "Custom World") + ((AuthGameObject.skyboxindex != 2 && AuthGameObject.skyboxindex != 5) ? string.Empty : "[rainy]") + "*" + UnityEngine.Random.Range(0, 999999999).ToString(), true, true, AuthGameObject.maxplayers, _0024h_00244856, _0024ss_00244857);
					if (!AuthGameObject.isAIserver)
					{
						GameObject.Find("/AuthGameObject").SendMessage("gotAch", "I am a Server");
					}
					_0024self__00244858.starthosttimer = true;
					goto case 3;
				case 3:
					if (!_0024self__00244858.continuehost && _0024self__00244858.starthosttimer)
					{
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					if (_0024self__00244858.continuehost)
					{
						_0024self__00244858.worldloading.enabled = true;
					}
					goto IL_0287;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0287:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal MasterServerScript _0024self__00244859;

		public _0024remotestartserver_00244855(MasterServerScript self_)
		{
			_0024self__00244859 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00244859);
		}
	}

	[Serializable]
	internal sealed class _0024connectToTutorial_00244860 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal int _0024i_00244861;

			internal AIPlayer _0024curAI_00244862;

			internal float _0024conTime_00244863;

			internal Hashtable _0024h_00244864;

			internal string[] _0024ss_00244865;

			internal MasterServerScript _0024self__00244866;

			public _0024(MasterServerScript self_)
			{
				_0024self__00244866 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					PlayerPrefs.SetInt("tutorialKey", 0);
					gamenamestring = "Chokepoint (Sunny)";
					_0024self__00244866.authobj.SendMessage("setskybox", (object)0);
					curworld = 3;
					_0024self__00244866.authobj.SendMessage("Gametype", "Team Death-Match");
					_0024self__00244866.authobj.SendMessage("Timelimit", "99");
					_0024self__00244866.authobj.SendMessage("FF", true);
					_0024self__00244866.authobj.SendMessage("FPSen", true);
					AuthGameObject.isAIserver = true;
					for (_0024i_00244861 = 0; _0024i_00244861 < _0024self__00244866.aiArray.length; _0024i_00244861++)
					{
						object obj = _0024self__00244866.aiArray[_0024i_00244861];
						if (!(obj is AIPlayer))
						{
							obj = RuntimeServices.Coerce(obj, typeof(AIPlayer));
						}
						_0024curAI_00244862 = (AIPlayer)obj;
						if (_0024curAI_00244862.ainame3 != string.Empty)
						{
							break;
						}
					}
					AuthGameObject.showTutorial = true;
					AuthGameObject.nextGameJoinBot = true;
					ainame = "TutorialBot0";
					ainame2 = "TutorialBot1";
					ainame3 = "TutorialBot2";
					_0024conTime_00244863 = UnityEngine.Random.Range(1.5f, 3f);
					GameObject.Find("/ConnectionObject").SendMessage("fakeConnect", _0024conTime_00244863);
					result = (Yield(2, new WaitForSeconds(_0024conTime_00244863 + 2.25f)) ? 1 : 0);
					break;
				case 2:
					_0024self__00244866.isconnecting = true;
					_0024h_00244864 = new Hashtable();
					_0024h_00244864.Add("comment", AuthGameObject.username + "|" + AuthGameObject.gametype + "|" + AuthGameObject.username + "||" + AuthGameObject.whirldurl + ((!(CWFLoader.worldData != string.Empty)) ? string.Empty : "[CustomMap]") + "|||" + DisplayTopPlayers.mypointsStat + "|");
					_0024ss_00244865 = new string[1];
					_0024ss_00244865[0] = "comment";
					Debug.Log("Starting room with base name: " + ((!(gamenamestring == "More Maps")) ? gamenamestring : "Custom World"));
					PhotonNetwork.CreateRoom(((!(gamenamestring == "More Maps")) ? gamenamestring : "Custom World") + ((AuthGameObject.skyboxindex != 2 && AuthGameObject.skyboxindex != 5) ? string.Empty : "[rainy]") + "*" + UnityEngine.Random.Range(0, 999999999).ToString(), false, true, AuthGameObject.maxplayers, _0024h_00244864, _0024ss_00244865);
					if (!AuthGameObject.isAIserver)
					{
						GameObject.Find("/AuthGameObject").SendMessage("gotAch", "I am a Server");
					}
					_0024self__00244866.starthosttimer = true;
					goto case 3;
				case 3:
					if (!_0024self__00244866.continuehost && _0024self__00244866.starthosttimer)
					{
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					if (_0024self__00244866.continuehost)
					{
						_0024self__00244866.worldloading.enabled = true;
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

		internal MasterServerScript _0024self__00244867;

		public _0024connectToTutorial_00244860(MasterServerScript self_)
		{
			_0024self__00244867 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00244867);
		}
	}

	[Serializable]
	internal sealed class _0024connectdelegate_00244868 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal string _0024editname_00244869;

			internal string[] _0024commentarr_00244870;

			internal bool _0024iswhirld_00244871;

			internal string _0024murl_00244872;

			internal string _0024wstr_00244873;

			internal AIPlayer _0024curAI_00244874;

			internal float _0024conTime_00244875;

			internal int _0024_00241236_00244876;

			internal string[] _0024_00241237_00244877;

			internal int _0024_00241238_00244878;

			internal HostData _0024element_00244879;

			internal MasterServerScript _0024self__00244880;

			public _0024(HostData element, MasterServerScript self_)
			{
				_0024element_00244879 = element;
				_0024self__00244880 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
				{
					_0024editname_00244869 = _0024element_00244879.gameName.Split("*"[0])[0];
					_0024commentarr_00244870 = _0024element_00244879.comment.Split("|"[0]);
					AuthGameObject.gametype = _0024commentarr_00244870[1];
					gamenamestring = _0024editname_00244869;
					Debug.Log("Joining game with editname: " + _0024editname_00244869);
					if (_0024editname_00244869.Contains("[rainy]"))
					{
						if (_0024editname_00244869.Contains("Overcast"))
						{
							_0024self__00244880.authobj.SendMessage("setskybox", 2);
						}
						else
						{
							_0024self__00244880.authobj.SendMessage("setskybox", 5);
						}
					}
					else
					{
						if (_0024editname_00244869.Contains("Sunny"))
						{
							_0024self__00244880.authobj.SendMessage("setskybox", (object)0);
						}
						if (_0024editname_00244869.Contains("Overcast"))
						{
							_0024self__00244880.authobj.SendMessage("setskybox", 1);
						}
						if (_0024editname_00244869.Contains("Sunset"))
						{
							_0024self__00244880.authobj.SendMessage("setskybox", 3);
						}
						if (_0024editname_00244869.Contains("Night"))
						{
							_0024self__00244880.authobj.SendMessage("setskybox", 4);
						}
					}
					if (_0024editname_00244869.Contains("Battle Island"))
					{
						curworld = 0;
					}
					if (_0024editname_00244869.Contains("Abandoned Silos"))
					{
						curworld = 1;
					}
					if (_0024editname_00244869.Contains("Unity Island"))
					{
						curworld = 2;
					}
					if (_0024editname_00244869.Contains("Chokepoint"))
					{
						curworld = 3;
					}
					if (_0024editname_00244869.Contains("Sanctum"))
					{
						curworld = 4;
					}
					_0024iswhirld_00244871 = false;
					_0024murl_00244872 = string.Empty;
					_0024_00241236_00244876 = 0;
					_0024_00241237_00244877 = WorldWindow.worldarr;
					for (_0024_00241238_00244878 = _0024_00241237_00244877.Length; _0024_00241236_00244876 < _0024_00241238_00244878; _0024_00241236_00244876++)
					{
						if (_0024_00241237_00244877[_0024_00241236_00244876].Replace(" | ", "|").Split("|"[0])[0] == _0024editname_00244869.Replace("[rainy]", string.Empty))
						{
							curworld = 5;
							_0024murl_00244872 = _0024_00241237_00244877[_0024_00241236_00244876].Replace(" | ", "|").Split("|"[0])[2];
							AuthGameObject.whirldname = _0024_00241237_00244877[_0024_00241236_00244876].Replace(" | ", "|").Split("|"[0])[0];
							Debug.Log(AuthGameObject.whirldname);
							_0024iswhirld_00244871 = true;
						}
					}
					if (_0024editname_00244869 == "Custom World")
					{
						curworld = 5;
						_0024iswhirld_00244871 = true;
						_0024murl_00244872 = "none";
					}
					if (_0024element_00244879.comment.Contains("[CustomMap]"))
					{
						CWFLoader.worldData = "[Get]";
					}
					if (!_0024element_00244879.gameType.Contains("AI"))
					{
						if (_0024element_00244879.comment.Split("|"[0])[6].Contains("_AI"))
						{
							joinedAIServer = true;
							hostName = _0024element_00244879.comment.Split("|"[0])[0];
						}
						_0024self__00244880.failedconnect = false;
						_0024self__00244880.isconnecting = true;
						PhotonNetwork.LeaveRoom();
						goto case 2;
					}
					AuthGameObject.isAIserver = true;
					_0024self__00244880.authobj.SendMessage("Gametype", _0024element_00244879.comment.Split("|"[0])[1]);
					object obj = _0024self__00244880.aiArray[UnityBuiltins.parseInt(_0024element_00244879.gameType.Replace("AI", string.Empty)) - 1];
					if (!(obj is AIPlayer))
					{
						obj = RuntimeServices.Coerce(obj, typeof(AIPlayer));
					}
					_0024curAI_00244874 = (AIPlayer)obj;
					ainame = _0024curAI_00244874.ainame;
					ainame2 = _0024curAI_00244874.ainame2;
					ainame3 = _0024curAI_00244874.ainame3;
					_0024self__00244880.aisetting = _0024curAI_00244874.location;
					_0024self__00244880.authobj.SendMessage("Maxplayers", _0024curAI_00244874.maxplayers.ToString());
					_0024self__00244880.authobj.SendMessage("Timelimit", "10");
					_0024self__00244880.authobj.SendMessage("FF", true);
					_0024self__00244880.authobj.SendMessage("FPSen", true);
					_0024conTime_00244875 = UnityEngine.Random.Range(1.5f, 3f);
					GameObject.Find("/ConnectionObject").SendMessage("fakeConnect", _0024conTime_00244875);
					result = (Yield(3, new WaitForSeconds(_0024conTime_00244875 + 2.25f)) ? 1 : 0);
					break;
				}
				case 2:
					if (PhotonNetwork.connectionStateDetailed != PeerState.JoinedLobby)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					PhotonNetwork.JoinRoom(_0024element_00244879.gameName);
					_0024self__00244880.connectattemptdata = _0024element_00244879;
					PhotonNetwork.isMessageQueueRunning = true;
					conobj = true;
					_0024self__00244880.StartCoroutine_Auto(_0024self__00244880.goloadworld(_0024element_00244879, _0024murl_00244872, _0024iswhirld_00244871));
					goto IL_0711;
				case 3:
					_0024self__00244880.StartCoroutine_Auto(_0024self__00244880.remotestartserver());
					if (_0024iswhirld_00244871)
					{
						AuthGameObject.whirldurl = _0024element_00244879.comment.Split("|"[0])[4];
						AuthGameObject.whirldmmurl = _0024murl_00244872;
						Debug.Log(AuthGameObject.whirldurl);
						GameObject.Find("/WhirldIn").SendMessage("Load", AuthGameObject.whirldurl);
					}
					goto IL_0711;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0711:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal HostData _0024element_00244881;

		internal MasterServerScript _0024self__00244882;

		public _0024connectdelegate_00244868(HostData element, MasterServerScript self_)
		{
			_0024element_00244881 = element;
			_0024self__00244882 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024element_00244881, _0024self__00244882);
		}
	}

	[Serializable]
	internal sealed class _0024goloadworld_00244883 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal HostData _0024i_00244884;

			internal string _0024m_00244885;

			internal bool _0024iw_00244886;

			internal MasterServerScript _0024self__00244887;

			public _0024(HostData i, string m, bool iw, MasterServerScript self_)
			{
				_0024i_00244884 = i;
				_0024m_00244885 = m;
				_0024iw_00244886 = iw;
				_0024self__00244887 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					PhotonNetwork.isMessageQueueRunning = true;
					_0024self__00244887.isconnecting = true;
					goto case 2;
				case 2:
					if ((RuntimeServices.EqualityOperator(PhotonNetwork.room, null) && !_0024self__00244887.failedconnect) || conobj)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					if (!conobj && !RuntimeServices.EqualityOperator(PhotonNetwork.room, null))
					{
						PhotonNetwork.isMessageQueueRunning = false;
						PhotonNetwork.SetSendingEnabled(0, false);
						PhotonNetwork.SetSendingEnabled(8, false);
						PhotonNetwork.SetSendingEnabled(9, false);
						PhotonNetwork.SetSendingEnabled(10, false);
						if (_0024iw_00244886)
						{
							AuthGameObject.whirldurl = _0024i_00244884.comment.Split("|"[0])[4];
							AuthGameObject.whirldmmurl = _0024m_00244885;
							GameObject.Find("/WhirldIn").SendMessage("Load", AuthGameObject.whirldurl);
						}
						_0024self__00244887.worldloading.enabled = true;
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					goto IL_0153;
				case 3:
					result = (YieldDefault(4) ? 1 : 0);
					break;
				case 4:
					result = (YieldDefault(5) ? 1 : 0);
					break;
				case 5:
					_0024self__00244887.worldloading.SendMessage("fadein");
					goto IL_0153;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0153:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal HostData _0024i_00244888;

		internal string _0024m_00244889;

		internal bool _0024iw_00244890;

		internal MasterServerScript _0024self__00244891;

		public _0024goloadworld_00244883(HostData i, string m, bool iw, MasterServerScript self_)
		{
			_0024i_00244888 = i;
			_0024m_00244889 = m;
			_0024iw_00244890 = iw;
			_0024self__00244891 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024i_00244888, _0024m_00244889, _0024iw_00244890, _0024self__00244891);
		}
	}

	[Serializable]
	internal sealed class _0024connectTest_00244892 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string _0024editname_00244893;

			internal string[] _0024commentarr_00244894;

			internal bool _0024iswhirld_00244895;

			internal string _0024murl_00244896;

			internal string _0024wstr_00244897;

			internal float _0024fakeyieldTime_00244898;

			internal AIPlayer _0024curAI_00244899;

			internal float _0024waitTime_00244900;

			internal int _0024_00241240_00244901;

			internal string[] _0024_00241241_00244902;

			internal int _0024_00241242_00244903;

			internal HostData _0024hostdata_00244904;

			internal MasterServerScript _0024self__00244905;

			public _0024(HostData hostdata, MasterServerScript self_)
			{
				_0024hostdata_00244904 = hostdata;
				_0024self__00244905 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00244905.currentlyTesting = true;
					PhotonNetwork.isMessageQueueRunning = true;
					_0024self__00244905.quickJoinServerHost = _0024hostdata_00244904.comment.Split("|"[0])[0];
					Debug.Log("Trying to connect to server host: " + _0024hostdata_00244904.comment.Split("|"[0])[0]);
					if (PlayerPrefs.HasKey("tutorialKey"))
					{
						_0024editname_00244893 = _0024hostdata_00244904.gameName.Split("*"[0])[0];
						_0024commentarr_00244894 = _0024hostdata_00244904.comment.Split("|"[0]);
						AuthGameObject.gametype = _0024commentarr_00244894[1];
						gamenamestring = _0024editname_00244893;
						Debug.Log("Quick join game name: " + _0024editname_00244893);
						if (_0024editname_00244893.Contains("[rainy]"))
						{
							if (_0024editname_00244893.Contains("Overcast"))
							{
								_0024self__00244905.authobj.SendMessage("setskybox", 2);
							}
							else
							{
								_0024self__00244905.authobj.SendMessage("setskybox", 5);
							}
						}
						else
						{
							if (_0024editname_00244893.Contains("Sunny"))
							{
								_0024self__00244905.authobj.SendMessage("setskybox", (object)0);
							}
							if (_0024editname_00244893.Contains("Overcast"))
							{
								_0024self__00244905.authobj.SendMessage("setskybox", 1);
							}
							if (_0024editname_00244893.Contains("Sunset"))
							{
								_0024self__00244905.authobj.SendMessage("setskybox", 3);
							}
							if (_0024editname_00244893.Contains("Night"))
							{
								_0024self__00244905.authobj.SendMessage("setskybox", 4);
							}
						}
						if (_0024editname_00244893.Contains("Battle Island"))
						{
							curworld = 0;
						}
						if (_0024editname_00244893.Contains("Abandoned Silos"))
						{
							curworld = 1;
						}
						if (_0024editname_00244893.Contains("Unity Island"))
						{
							curworld = 2;
						}
						if (_0024editname_00244893.Contains("Chokepoint"))
						{
							curworld = 3;
						}
						if (_0024editname_00244893.Contains("Sanctum"))
						{
							curworld = 4;
						}
						_0024iswhirld_00244895 = false;
						_0024murl_00244896 = string.Empty;
						_0024_00241240_00244901 = 0;
						_0024_00241241_00244902 = WorldWindow.worldarr;
						for (_0024_00241242_00244903 = _0024_00241241_00244902.Length; _0024_00241240_00244901 < _0024_00241242_00244903; _0024_00241240_00244901++)
						{
							if (_0024_00241241_00244902[_0024_00241240_00244901].Replace(" | ", "|").Split("|"[0])[0] == _0024editname_00244893)
							{
								curworld = 5;
								_0024murl_00244896 = _0024_00241241_00244902[_0024_00241240_00244901].Replace(" | ", "|").Split("|"[0])[2];
								AuthGameObject.whirldname = _0024_00241241_00244902[_0024_00241240_00244901].Replace(" | ", "|").Split("|"[0])[0];
								_0024iswhirld_00244895 = true;
							}
						}
						if (_0024editname_00244893 == "Custom World")
						{
							curworld = 5;
							_0024iswhirld_00244895 = true;
							_0024murl_00244896 = "none";
						}
						if (_0024hostdata_00244904.comment.Contains("[CustomMap]"))
						{
							CWFLoader.worldData = "[Get]";
						}
					}
					_0024fakeyieldTime_00244898 = 2.44f;
					if (_0024self__00244905.quickJoining)
					{
						_0024self__00244905.yieldTime = 7.44f;
					}
					goto case 2;
				case 2:
					if (!(_0024fakeyieldTime_00244898 <= 0f) && RuntimeServices.EqualityOperator(PhotonNetwork.room, null))
					{
						_0024self__00244905.yieldTime -= Time.deltaTime;
						_0024fakeyieldTime_00244898 -= Time.deltaTime;
						if (_0024self__00244905.quickJoining)
						{
							result = (YieldDefault(2) ? 1 : 0);
							break;
						}
					}
					if (_0024self__00244905.quickJoining && PlayerPrefs.HasKey("tutorialKey"))
					{
						if (!_0024hostdata_00244904.gameType.Contains("AI"))
						{
							if (_0024hostdata_00244904.comment.Split("|"[0])[6].Contains("_AI"))
							{
								joinedAIServer = true;
								hostName = _0024hostdata_00244904.comment.Split("|"[0])[0];
							}
							_0024self__00244905.failedconnect = false;
							PhotonNetwork.SetSendingEnabled(0, false);
							PhotonNetwork.SetSendingEnabled(8, false);
							PhotonNetwork.SetSendingEnabled(9, false);
							PhotonNetwork.SetSendingEnabled(10, false);
							PhotonNetwork.isMessageQueueRunning = true;
							_0024self__00244905.isconnecting = true;
							PhotonNetwork.LeaveRoom();
							goto case 3;
						}
						AuthGameObject.isAIserver = true;
						_0024self__00244905.authobj.SendMessage("Gametype", "Team Death-Match");
						object obj = _0024self__00244905.aiArray[UnityBuiltins.parseInt(_0024hostdata_00244904.gameType.Replace("AI", string.Empty)) - 1];
						if (!(obj is AIPlayer))
						{
							obj = RuntimeServices.Coerce(obj, typeof(AIPlayer));
						}
						_0024curAI_00244899 = (AIPlayer)obj;
						ainame = _0024curAI_00244899.ainame;
						ainame2 = _0024curAI_00244899.ainame2;
						ainame3 = _0024curAI_00244899.ainame3;
						_0024self__00244905.aisetting = _0024curAI_00244899.location;
						_0024self__00244905.authobj.SendMessage("Maxplayers", _0024curAI_00244899.maxplayers.ToString());
						_0024self__00244905.authobj.SendMessage("Timelimit", "10");
						_0024waitTime_00244900 = UnityEngine.Random.Range(2f, 4f);
						goto case 4;
					}
					if (!PlayerPrefs.HasKey("tutorialKey"))
					{
						_0024self__00244905.StartCoroutine_Auto(_0024self__00244905.connectToTutorial());
						_0024self__00244905.StartCoroutine_Auto(_0024self__00244905.fadeOutJoinMode());
						_0024self__00244905.quickJoining = false;
					}
					goto IL_0844;
				case 3:
					if (PhotonNetwork.connectionStateDetailed != PeerState.JoinedLobby)
					{
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					PhotonNetwork.JoinRoom(_0024hostdata_00244904.gameName);
					goto IL_0844;
				case 4:
					if (_0024waitTime_00244900 > 0f)
					{
						_0024self__00244905.yieldTime -= Time.deltaTime;
						_0024waitTime_00244900 -= Time.deltaTime;
						result = (YieldDefault(4) ? 1 : 0);
						break;
					}
					if (_0024self__00244905.quickJoining)
					{
						_0024self__00244905.StartCoroutine_Auto(_0024self__00244905.remotestartserver());
						if (_0024iswhirld_00244895)
						{
							AuthGameObject.whirldurl = _0024hostdata_00244904.comment.Split("|"[0])[4];
							AuthGameObject.whirldmmurl = _0024murl_00244896;
							GameObject.Find("/WhirldIn").SendMessage("Load", AuthGameObject.whirldurl);
						}
						_0024self__00244905.StartCoroutine_Auto(_0024self__00244905.fadeOutJoinMode());
					}
					goto IL_0844;
				case 5:
					if (!(_0024self__00244905.yieldTime <= 0f) && RuntimeServices.EqualityOperator(PhotonNetwork.room, null))
					{
						_0024self__00244905.yieldTime -= Time.deltaTime;
						if (_0024self__00244905.quickJoining)
						{
							result = (YieldDefault(5) ? 1 : 0);
							break;
						}
					}
					_0024self__00244905.currentlyTesting = false;
					if (_0024self__00244905.quickJoining && !AuthGameObject.isAIserver && !RuntimeServices.EqualityOperator(PhotonNetwork.room, null))
					{
						_0024self__00244905.StartCoroutine_Auto(_0024self__00244905.goloadworld(_0024hostdata_00244904, _0024murl_00244896, _0024iswhirld_00244895));
					}
					YieldDefault(1);
					goto case 1;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0844:
					if (_0024self__00244905.quickJoining)
					{
						_0024self__00244905.yieldTime = 5f;
					}
					goto case 5;
				}
				return (byte)result != 0;
			}
		}

		internal HostData _0024hostdata_00244906;

		internal MasterServerScript _0024self__00244907;

		public _0024connectTest_00244892(HostData hostdata, MasterServerScript self_)
		{
			_0024hostdata_00244906 = hostdata;
			_0024self__00244907 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024hostdata_00244906, _0024self__00244907);
		}
	}

	[Serializable]
	internal sealed class _0024quickJoin_00244908 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal UnityScript.Lang.Array _0024ailist_00244909;

			internal HostData _0024host_00244910;

			internal HostData _0024h_00244911;

			internal IEnumerator _0024_0024iterator_0024275_00244912;

			internal int _0024_00241244_00244913;

			internal HostData[] _0024_00241245_00244914;

			internal int _0024_00241246_00244915;

			internal HostData[] _0024hd_00244916;

			internal MasterServerScript _0024self__00244917;

			public _0024(HostData[] hd, MasterServerScript self_)
			{
				_0024hd_00244916 = hd;
				_0024self__00244917 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00244917.joinCount = 0;
					_0024self__00244917.quickJoining = true;
					_0024ailist_00244909 = new UnityScript.Lang.Array();
					_0024_00241244_00244913 = 0;
					_0024_00241245_00244914 = _0024hd_00244916;
					_0024_00241246_00244915 = _0024_00241245_00244914.Length;
					goto IL_0189;
				case 2:
					if (_0024self__00244917.currentlyTesting)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					if (!RuntimeServices.EqualityOperator(PhotonNetwork.room, null) || !_0024self__00244917.quickJoining)
					{
						_0024self__00244917.StartCoroutine_Auto(_0024self__00244917.fadeOutJoinMode());
						goto IL_019a;
					}
					if (!_0024_00241245_00244914[_0024_00241244_00244913].gameType.Contains("AI"))
					{
						if ((!AuthGameObject.nextGameJoinBot || AuthGameObject.showTutorial) && _0024_00241245_00244914[_0024_00241244_00244913].connectedPlayers < _0024_00241245_00244914[_0024_00241244_00244913].playerLimit)
						{
							_0024self__00244917.joinCount++;
							_0024self__00244917.StartCoroutine_Auto(_0024self__00244917.connectTest(_0024_00241245_00244914[_0024_00241244_00244913]));
						}
					}
					else
					{
						_0024ailist_00244909.Add(_0024_00241245_00244914[_0024_00241244_00244913]);
					}
					_0024_00241244_00244913++;
					goto IL_0189;
				case 3:
					if (_0024self__00244917.currentlyTesting)
					{
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					if (!RuntimeServices.EqualityOperator(PhotonNetwork.room, null) || !_0024self__00244917.quickJoining)
					{
						goto IL_0296;
					}
					_0024self__00244917.joinCount++;
					_0024self__00244917.StartCoroutine_Auto(_0024self__00244917.connectTest(_0024h_00244911));
					UnityRuntimeServices.Update(_0024_0024iterator_0024275_00244912, _0024h_00244911);
					goto IL_0286;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0189:
					if (_0024_00241244_00244913 < _0024_00241246_00244915)
					{
						goto case 2;
					}
					goto IL_019a;
					IL_0296:
					_0024self__00244917.quickJoining = false;
					YieldDefault(1);
					goto case 1;
					IL_019a:
					if (AuthGameObject.nextGameJoinBot && !AuthGameObject.showTutorial)
					{
						AuthGameObject.nextGameJoinBot = false;
					}
					_0024_0024iterator_0024275_00244912 = UnityRuntimeServices.GetEnumerator(_0024ailist_00244909);
					goto IL_0286;
					IL_0286:
					if (_0024_0024iterator_0024275_00244912.MoveNext())
					{
						object obj = _0024_0024iterator_0024275_00244912.Current;
						if (!(obj is HostData))
						{
							obj = RuntimeServices.Coerce(obj, typeof(HostData));
						}
						_0024h_00244911 = (HostData)obj;
						goto case 3;
					}
					goto IL_0296;
				}
				return (byte)result != 0;
			}
		}

		internal HostData[] _0024hd_00244918;

		internal MasterServerScript _0024self__00244919;

		public _0024quickJoin_00244908(HostData[] hd, MasterServerScript self_)
		{
			_0024hd_00244918 = hd;
			_0024self__00244919 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024hd_00244918, _0024self__00244919);
		}
	}

	[Serializable]
	internal sealed class _0024tryToReconnect_00244920 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal MasterServerScript _0024self__00244921;

			public _0024(MasterServerScript self_)
			{
				_0024self__00244921 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				case 2:
					Debug.Log("Trying to re-connect using settings: " + PreloaderExplosion.versionNumber);
					PhotonNetwork.ConnectUsingSettings(PreloaderExplosion.versionNumber);
					result = (Yield(3, new WaitForSeconds(8f)) ? 1 : 0);
					break;
				default:
					if (PhotonNetwork.connectionStateDetailed == PeerState.Disconnected || PhotonNetwork.connectionStateDetailed == PeerState.PeerCreated || PhotonNetwork.connectionStateDetailed == PeerState.Uninitialized)
					{
						PhotonNetwork.Disconnect();
						result = (Yield(2, new WaitForSeconds(3f)) ? 1 : 0);
						break;
					}
					Debug.Log("Successfully reconnected!");
					_0024self__00244921.attemptToReconnect = false;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal MasterServerScript _0024self__00244922;

		public _0024tryToReconnect_00244920(MasterServerScript self_)
		{
			_0024self__00244922 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00244922);
		}
	}

	public GUIStyle newskin;

	public GUIStyle buttonskin;

	public GUIStyle largebuttonskin;

	public GUIStyle smallbuttonskin;

	public GUIStyle textskin;

	public GUIStyle textskinButton;

	public GUIStyle labelskin;

	public GUIStyle numberlabel;

	public GUIStyle connectbutton;

	public GUIStyle worldleft;

	public GUIStyle worldright;

	public GUIStyle middlebutton;

	public GUIStyle tooltipstyle;

	public GUIStyle linetex;

	public GUIStyle serverLabel;

	public GUIStyle qjoinstyle;

	public GUIStyle qtextstyle;

	public GUIStyle underTabStyle;

	private HostData[] backdata;

	private int clearbackdata;

	public Behaviour loginwindow;

	public LoginWindow logscript;

	public AuthGameObject authsrc;

	public WhirldWindow wwin;

	public WorldWindow worldwindowsrc;

	public CWFLoader cwf;

	public PreloaderExplosion pex;

	public AdjustCamDistance adjustCam;

	public DisplayTopPlayers dplayer;

	private float timer;

	private string mastererror;

	private string connecterror;

	[NonSerialized]
	public static string gamenamestring = "Battle Island (Sunny)";

	[NonSerialized]
	public static string playername = "Username";

	public Behaviour worldloading;

	private bool continuehost;

	private bool failedconnect;

	public GameObject worldwindow;

	public GameObject authobj;

	public string[] worlds;

	[NonSerialized]
	public static int curworld;

	[NonSerialized]
	public static bool useAlternateHost;

	public GameObject gameoptions;

	public KongregateAPI kongapi;

	[NonSerialized]
	public static bool conobj;

	public ConnectionObject consrc;

	private float toolalpha;

	private bool fadetool;

	private float hosttimer;

	private bool starthosttimer;

	private string dedmessage;

	public GameObject whirlds;

	private HostData connectattemptdata;

	public Texture flippedtooltip;

	public Texture origtooltip;

	public GameObject whirldpre;

	[NonSerialized]
	public static float offset = 1640f;

	private HostData[] data;

	private HostData[] qjData;

	private bool isconnecting;

	public CalculateHealth chealth;

	public GameObject accountsettings;

	[NonSerialized]
	public static NetworkConnectionError connect;

	[NonSerialized]
	public static string hostName = string.Empty;

	[NonSerialized]
	public static bool joinedAIServer;

	[NonSerialized]
	public static string ainame;

	[NonSerialized]
	public static string ainame2;

	[NonSerialized]
	public static string ainame3;

	private string aisetting;

	private float alphaded;

	private HostData[] lastDataOrder;

	private string sortBy;

	public UnityScript.Lang.Array aiArray;

	private bool grabbingDedicatedServers;

	[NonSerialized]
	public static bool connectedToDed;

	private string searchstring;

	private UnityScript.Lang.Array ainamelist;

	public GUISkin scrollstyle;

	public Vector2 scrollPosition;

	public GUIStyle dedWindow;

	[NonSerialized]
	public static UnityScript.Lang.Array ailist = new UnityScript.Lang.Array();

	private Hashtable hostHashtable;

	private bool currentlyTesting;

	private float joinAlpha;

	private int joinCount;

	private bool quickJoining;

	private float yieldTime;

	private string quickJoinServerHost;

	private bool leftRoom;

	private bool attemptToReconnect;

	private float peerstateDebug;

	private string findServerWithUser;

	public MasterServerScript()
	{
		timer = 5f;
		mastererror = string.Empty;
		connecterror = "No servers detected - please check your internet connection.";
		hosttimer = 5f;
		dedmessage = "Finding an available dedicated server to host on...";
		aisetting = "Sunny";
		sortBy = "p";
		aiArray = new UnityScript.Lang.Array();
		searchstring = string.Empty;
		ainamelist = new UnityScript.Lang.Array("evilborn", "shangsaltb", "shangsam", "shangsare", "shangsel", "shangsele", "stomalex", "stepclex", "sterlex", "sublex", "bearincu", "didicthug", "dismissing", "dopemissing", "dysmnmissing", "emilimissing", "enceborn", "estmborn", "estrborn", "euchborn", "fetugame", "fewgame", "fjeldgame", "flergame", "galvogame", "gonvolleyball", "goosebear", "gorybear", "grabbbear", "grambear", "henryrely", "lexsubd", "motyintincr", "merkintincr", "malintincr", "marsintincr", "obloqintincr", "offalpenguin", "omophpenguin", "ormopenguin", "ovulepenguin", "phrapenguin", "pixchunky", "popchunky", "portchunky", "promchunky", "protchunky", "publichunky", "quilhenry", "quiphenry", "rodeouni", "rodeovana", "rodeoving", "rodeoviv", "regihenry", "ragghenry", "slayrarpe", "slayrband", "slayrbarbi", "slayrbehe", "slayrboobi", "slayrboyco", "spuffyinsu", "spuffyint", "spuffyloni", "spuffylect", "spuffylium", "sushysher", "sushysho", "sushysine", "sushysna", "sushysteal", "thugcaril", "thugcomo", "thugcrocu", "thugdec", "trickedacrop", "trickedactua", "volleyballgen", "volleyballgile", "volleyballgist", "volleyballglebe", "volleyballgogo", "worldreta", "worldrety", "worldrob", "worldroman", "worldsaid", "wamrodeo", "whodude", "wicdude", "withdude", "zemedude", "zineader", "zinealie", "zineappro", "zinearcha", "zinearchi", "beskiddo", "berkiddo", "blowgkiddo", "bretkiddo", "cafakiddo", "combdeep", "comdeep", "condeep", "crandeep", "crideep", "deepcrun", "gentimama", "gluttmama", "harrimama", "heamama", "herymama", "houmama", "hvacbing", "inetbing", "kamabing", "kistbing", "lagebing", "lamstfootball", "licenfootball", "lurafootball", "marcfootball", "melfootball", "ocolaquatic", "oseraquatic", "othelaquatic", "pathoaquatic", "payoaquatic", "rotthorray", "readhorray", "retihorray", "radiocar", "radiocele", "radiocent", "radiochole", "radiocol", "ratsound", "runache", "runali", "runanalo", "runani", "sidihorray", "siftnot", "sisterdogi", "sisterensi", "sisterepist", "sisterermin", "sisteresha", "sornot", "sortnot", "soundpeta", "soundprem", "soundpro", "soundprof", "soundrad", "steamnot", "stonot", "studaper", "studappla", "studarfi", "studazine", "studbas", "studchapter", "sulchapter", "toweguanto", "takichapter", "thanfati", "thanfayd", "thanfier", "thanfly", "thanfumi", "thalchapter", "thiechapter", "tinnyscycla", "tinnysdar", "tinnysday", "tinnysdefe", "tinnysdema", "tuatguanto", "upkeguanto", "urmel", "urmig", "urnatr", "urnium", "urnocti", "volsguanto", "vedguanto", "willwenc", "willwife", "willyear", "yogadian", "yogadidic", "yogadine", "yogadis", "yogadmo", "onygenius", "shardacad", "shardanni", "shardapomi", "speaiss", "squiss", "steriss", "stampiss", "bonlike", "belrest", "cerilike", "cadilike", "champlike", "clalike", "corsromantic", "cubbyeat", "cusheat", "custoeat", "dacteat", "duumeat", "hirowise", "inspitimid", "kathmohawk", "leinmohawk", "lerymohawk", "likecom", "loidmohawk", "ludomohawk", "luzipbrace", "majbrace", "maribrace", "matbrace", "michabrace", "migngenius", "mucogenius", "myogrgenius", "newsngenius", "phreekstro", "phreekteum", "phreekthoma", "phreekthruw", "phreektire", "prawnbel", "probabel", "puscbel", "romanticcomm", "romanticconi", "romanticconte", "romanticcoo", "rambel", "raribel", "slipfou", "slipfus", "slipgewe", "slipgiva", "slipgoodb", "srasnowb", "srarodo", "srarogr", "srasatya", "srasion", "stifiss", "sweetaspir", "sweetaya", "sweetbaw", "sweetbed", "sweetbkbn", "timidgrist", "timidguide", "timidhali", "timidhea", "timidhere", "tiviclown", "tomaclown", "trippinella", "trippineme", "trippinemph", "trippinesfa", "trippinfai", "tualclown", "unrclown", "venihiro", "veneclown", "vibrhiro", "vulhiro", "wakeboardpar", "wakeboardpip", "wakeboardpor", "wakeboardpoty", "wallhiro", "whahiro", "wubbawom", "wubbawryn", "wubbaxylop", "zunefer", "zunefill", "zuneflatt", "zunefogy", "zuneforma", "estiforever", "embroforever", "exchaforever", "sharkcroon", "sharkcrowd", "sharkcuse", "sharkdec", "sharkditi", "sparkher", "sparkhyd", "sparkinorg", "sparkinou", "sparkirer", "bannclever", "becuclever", "bewhclever", "bibclever", "bileclever", "cinemarcs", "coadjmarcs", "codemarcs", "colemarcs", "convimarcs", "doleforever", "duceforever", "felilin", "fernlin", "fastforever", "fireslin", "frielin", "frislin", "froash", "gambaash", "giuash", "gooash", "greatash", "knesnsmile", "krisnsmile", "latinsmile", "litensmile", "litnsmile", "moniegurly", "mopergurly", "minislipk", "myeligurly", "myrgurly", "nsmilemago", "noggigurly", "plebbreeze", "plubreeze", "prostbreeze", "quobreeze", "rawste", "rawsto", "rawsuma", "rawtach", "rawtige", "resebreeze", "slipkmelo", "slipkmemo", "slipkment", "slipkmill", "suaveroo", "suaveruma", "suaverush", "suavesain", "suavesatur", "suaveseafo", "thebestbonn", "thebestbox", "thebestcae", "thebestcahow", "thebestchat", "transdigy", "tritejack", "tritejess", "tritejolt", "tritekikum", "triteking", "vapdigy", "velddigy", "vineddigy", "walkershole", "walkersig", "walkersour", "walkersprin", "walkersprit", "willowsnon", "willowsnot", "willowsorge", "willowsorni", "willowsper", "wiredigy", "wizaiwant", "wristiwant", "youhaveambi", "youhaveand", "youhavearee", "youhaveaus", "youhavebagio", "encisis", "euphegirl", "evagirl", "astrkentros", "adobekentros", "algikentros", "annakentros", "axiomkentros", "bricame", "britame", "cadeame", "calame", "capucame", "caradav", "chandav", "cidedav", "clampdav", "coidav", "feasgirl", "fanongirl", "fishpgirl", "gasomajere", "girdemajere", "glomajere", "grounmajere", "hamzamajere", "hostabillion", "huntbillion", "inerbillion", "intebillion", "jambillion", "juniflirty", "koldflirty", "kottaflirty", "kailflirty", "lanflirty", "porthoop", "phonhoop", "phedhoop", "pleasantmetic", "pleasantmil", "pleasantmouth", "pleasantmure", "pleasantnat", "pleasantnene", "predihoop", "pretehoop", "quinnicer", "ravnicer", "refinicer", "remasnicer", "reynanicer", "rulercetic", "ryothtolo", "ryothtrap", "ryothtri", "ryothvarni", "ryothwrel", "santcetic", "scocetic", "sisdunna", "siseco", "sisedi", "siseerin", "sisemee", "somedcetic", "sonnewo", "sonobso", "sonorse", "sonpau", "sonparap", "sorcetic", "stunnayevet", "stunnayork", "tagzspre", "tagzstb", "tagzsta", "tagzsub", "tagzsubt", "tagztali", "tinnycon", "tinnyconta", "tinnycopy", "tinnydai", "tinnydant", "upperlati", "upperleah", "upperling", "uppermamil", "uppermet", "wickedtam", "wickedtamar", "wickedtaunt", "wickedthroe", "wickedtip", "yaudavi", "yaudeem", "yaudrus", "yaudugo", "yaudula");
		yieldTime = 7.44f;
		quickJoinServerHost = string.Empty;
		peerstateDebug = 5f;
		findServerWithUser = string.Empty;
	}

	public virtual void Awake()
	{
		connectedToDed = false;
		joinedAIServer = false;
		hostName = string.Empty;
		AuthGameObject.isAIserver = false;
		AuthGameObject.showTutorial = false;
		ainame = string.Empty;
		ainame2 = string.Empty;
		ainame3 = string.Empty;
		CalculateHealth.goldearned = "a";
		CalculateHealth.bonus = 1f;
		CalculateHealth.killstreak = 0;
		conobj = false;
		offset = (float)Screen.width + 5f;
		if (!RuntimeServices.EqualityOperator(PhotonNetwork.room, null))
		{
			PhotonNetwork.LeaveRoom();
		}
		Screen.showCursor = true;
		ailist.Clear();
		int num = UnityEngine.Random.Range(3, 6);
		for (int i = 0; i < num; i++)
		{
			string empty = string.Empty;
			string text = string.Empty;
			string text2 = string.Empty;
			int num2 = default(int);
			int num4;
			int num3;
			if (UnityEngine.Random.Range(0, 7) == 0)
			{
				empty = "guest_" + UnityEngine.Random.Range(10000, 99999).ToString();
			}
			else
			{
				num3 = UnityEngine.Random.Range(2, 999);
				num4 = UnityEngine.Random.Range(0, 4);
				num2 = UnityEngine.Random.Range(0, ainamelist.length);
				object obj = RuntimeServices.InvokeBinaryOperator("op_Addition", ainamelist[num2], (num4 != 1) ? string.Empty : num3.ToString());
				if (!(obj is string))
				{
					obj = RuntimeServices.Coerce(obj, typeof(string));
				}
				empty = (string)obj;
				ainamelist.RemoveAt(num2);
				if (UnityEngine.Random.Range(0, 7) == 0)
				{
					empty = empty.ToUpper();
				}
			}
			ailist.Add(empty);
			num4 = UnityEngine.Random.Range(0, 4);
			num3 = UnityEngine.Random.Range(2, 999);
			if (UnityEngine.Random.Range(0, 4) != 0)
			{
				if (UnityEngine.Random.Range(0, 7) == 0)
				{
					text = "guest_" + UnityEngine.Random.Range(10000, 99999).ToString();
				}
				else
				{
					num2 = UnityEngine.Random.Range(0, ainamelist.length);
					object obj2 = RuntimeServices.InvokeBinaryOperator("op_Addition", ainamelist[num2], (num4 != 1) ? string.Empty : num3.ToString());
					if (!(obj2 is string))
					{
						obj2 = RuntimeServices.Coerce(obj2, typeof(string));
					}
					text = (string)obj2;
					ainamelist.RemoveAt(num2);
					if (UnityEngine.Random.Range(0, 7) == 0)
					{
						text = text.ToUpper();
					}
				}
				ailist.Add(text);
			}
			if (text != string.Empty)
			{
				num4 = UnityEngine.Random.Range(0, 4);
				num3 = UnityEngine.Random.Range(2, 999);
				if (UnityEngine.Random.Range(0, 3) != 0)
				{
					if (UnityEngine.Random.Range(0, 7) == 0)
					{
						text2 = "guest_" + UnityEngine.Random.Range(10000, 99999).ToString();
					}
					else
					{
						num2 = UnityEngine.Random.Range(0, ainamelist.length);
						object obj3 = RuntimeServices.InvokeBinaryOperator("op_Addition", ainamelist[num2], (num4 != 1) ? string.Empty : num3.ToString());
						if (!(obj3 is string))
						{
							obj3 = RuntimeServices.Coerce(obj3, typeof(string));
						}
						text2 = (string)obj3;
						ainamelist.RemoveAt(num2);
						if (UnityEngine.Random.Range(0, 7) == 0)
						{
							text2 = text2.ToUpper();
						}
					}
					ailist.Add(text2);
				}
			}
			int num5 = UnityEngine.Random.Range(1, 5);
			string text3 = string.Empty;
			if (num5 == 1)
			{
				text3 = "Sunny";
			}
			if (num5 == 2)
			{
				text3 = "Sunset";
			}
			if (num5 == 3)
			{
				text3 = "Overcast";
			}
			if (num5 == 4)
			{
				text3 = "Night";
			}
			int num6 = UnityEngine.Random.Range(0, (UnityEngine.Random.Range(0, 3) != 0) ? 4 : 11);
			string whirldurl = string.Empty;
			switch (num6)
			{
			case 0:
				text3 = "Battle Island (" + text3 + ")";
				break;
			case 1:
				text3 = "Unity Island (" + text3 + ")";
				break;
			case 2:
				text3 = "Chokepoint (" + text3 + ")";
				break;
			case 3:
				text3 = "Sanctum (" + text3 + ")";
				break;
			case 4:
				text3 = "Aubrey's Freestyle";
				whirldurl = "http://map.syn3h.com/Freestyle/Whirld.utw";
				break;
			case 5:
				text3 = "Aubrey's Freestyle";
				whirldurl = "http://map.syn3h.com/Freestyle/Whirld.utw";
				break;
			case 6:
				text3 = "Dude's Sctish Highlands";
				whirldurl = "http://map.syn3h.com/DudesScottishHighlands/Whirld.utw";
				break;
			case 7:
				text3 = "Dude's Sctish Highlands";
				whirldurl = "http://map.syn3h.com/DudesScottishHighlands/Whirld.utw";
				break;
			case 8:
				text3 = "Dude's Sctish Highlands";
				whirldurl = "http://map.syn3h.com/DudesScottishHighlands/Whirld.utw";
				break;
			case 9:
				text3 = "Fai's Sunken Wastes";
				whirldurl = "http://map.syn3h.com/FaisSunkenWastes/Whirld.utw";
				break;
			case 10:
				text3 = "Fai's Sunken Wastes";
				whirldurl = "http://map.syn3h.com/FaisSunkenWastes/Whirld.utw";
				break;
			}
			int num7 = UnityEngine.Random.Range(0, 2);
			string gametype = ((num7 != 1 && (num6 == 2 || num6 == 0)) ? "Capture the Flag" : ((UnityEngine.Random.Range(0, 2) != 0) ? "Team Death-Match" : "Deathmatch"));
			int num8 = UnityEngine.Random.Range(1, 4);
			switch (num8)
			{
			case 0:
				num8 = 8;
				break;
			case 1:
				num8 = 16;
				break;
			case 2:
				num8 = 16;
				break;
			case 3:
				num8 = 20;
				break;
			}
			int num9 = UnityEngine.Random.Range(400, 1000);
			AIPlayer value = new AIPlayer(empty, text3, num8, text, text2, gametype, whirldurl, num9);
			aiArray.Add(value);
		}
	}

	public virtual void OnGUI()
	{
		GUI.BeginGroup(new Rect(0f, 27f, Screen.width, Screen.height));
		GUI.skin = scrollstyle;
		float a = 1f;
		Color color = GUI.color;
		float num = (color.a = a);
		Color color2 = (GUI.color = color);
		if (offset != 1640f)
		{
			GUI.depth = 10;
			GUI.BeginGroup(new Rect(offset, 0f, Screen.width, Screen.height));
			if (!loginwindow.enabled)
			{
				playername = LoginWindow.username;
			}
			if (worldloading.enabled || isconnecting || LoginWindow.pubalpha > 0f || WorldWindow.statalpha != 0f || gameoptions.active || ConnectionObject.pubalpha > 0f || conobj || whirlds.active || accountsettings.active || alphaded > 0f || joinAlpha > 0f || PhotonNetwork.connectionStateDetailed == PeerState.DisconnectingFromGameserver || PhotonNetwork.connectionStateDetailed == PeerState.ConnectingToGameserver)
			{
				GUI.enabled = false;
			}
			else
			{
				GUI.enabled = true;
			}
			if (GUI.GetNameOfFocusedControl() == "username")
			{
				GUI.FocusControl("logusername");
				loginwindow.enabled = true;
				loginwindow.SendMessage("fadein");
			}
			RoomInfo[] roomList = PhotonNetwork.GetRoomList();
			UnityScript.Lang.Array array = new UnityScript.Lang.Array();
			for (int i = 0; i < UnityScript.Lang.Extensions.get_length((System.Array)roomList); i++)
			{
				if (!RuntimeServices.ToBool(roomList[i].customProperties["comment"]))
				{
					continue;
				}
				bool flag = false;
				if (RuntimeServices.ToBool(RuntimeServices.InvokeBinaryOperator("op_GreaterThanOrEqual", UnityRuntimeServices.GetProperty(RuntimeServices.Invoke(roomList[i].customProperties["comment"], "Split", new object[1] { "|"[0] }), "length"), 9)))
				{
					object obj = UnityRuntimeServices.Invoke(RuntimeServices.GetSlice(RuntimeServices.Invoke(roomList[i].customProperties["comment"], "Split", new object[1] { "|"[0] }), string.Empty, new object[1] { 8 }), "Split", new object[1] { ","[0] }, typeof(UnityEngine.MonoBehaviour));
					if (!(obj is string[]))
					{
						obj = RuntimeServices.Coerce(obj, typeof(string[]));
					}
					string[] array2 = (string[])obj;
					for (int j = 0; j < UnityScript.Lang.Extensions.get_length((System.Array)array2); j++)
					{
						if (array2[j] == AuthGameObject.username)
						{
							flag = true;
							break;
						}
					}
				}
				if (roomList[i].name != "chatRoom2" && RuntimeServices.ToBool(RuntimeServices.Invoke(roomList[i].customProperties["comment"], "Contains", new object[1] { "|THIS*SERVER*IS*JOINABLE" })) && !flag)
				{
					HostData hostData = new HostData();
					hostData.gameType = "CarbonCombat";
					hostData.gameName = roomList[i].name;
					hostData.connectedPlayers = roomList[i].playerCount;
					hostData.playerLimit = roomList[i].maxPlayers;
					object obj2 = roomList[i].customProperties["comment"];
					if (!(obj2 is string))
					{
						obj2 = RuntimeServices.Coerce(obj2, typeof(string));
					}
					hostData.comment = (string)obj2;
					array.Add(hostData);
				}
			}
			data = (HostData[])array.ToBuiltin(typeof(HostData));
			GUI.BeginGroup(new Rect(Screen.width / 2 - 400, Screen.height / 2 - 250, 800f, 650f));
			GUI.SetNextControlName("mainbox");
			GUI.Box(new Rect(0f, 50f, 800f, 370f), string.Empty, newskin);
			if (worldloading.enabled || isconnecting || LoginWindow.pubalpha > 0f || WorldWindow.statalpha != 0f || gameoptions.active || ConnectionObject.pubalpha > 0f || conobj || whirlds.active || accountsettings.active || alphaded > 0f || joinAlpha > 0f || PhotonNetwork.connectionStateDetailed == PeerState.DisconnectingFromGameserver || PhotonNetwork.connectionStateDetailed == PeerState.ConnectingToGameserver || PhotonNetwork.connectionStateDetailed != PeerState.JoinedLobby)
			{
				GUI.enabled = false;
			}
			else if (!(Application.GetStreamProgressForLevel("NuclearSilo") >= 1f) && curworld == 1)
			{
				GUI.enabled = false;
			}
			else if (!(Application.GetStreamProgressForLevel("NewIsland") >= 1f) && curworld == 2)
			{
				GUI.enabled = false;
			}
			else if (!(Application.GetStreamProgressForLevel("Sanctum") >= 1f) && curworld == 4)
			{
				GUI.enabled = false;
			}
			else
			{
				GUI.enabled = true;
			}
			if (GUI.Button(new Rect(8f, 60f, 70f, 15f), "Players", textskinButton))
			{
				sortBy = ((!(sortBy == "p")) ? "p" : "P");
			}
			if (GUI.Button(new Rect(90f, 60f, 70f, 15f), "Avg. XP", textskinButton))
			{
				sortBy = ((!(sortBy == "x")) ? "x" : "X");
			}
			if (GUI.Button(new Rect(200f, 60f, 100f, 15f), "World", textskinButton))
			{
				sortBy = ((!(sortBy == "w")) ? "w" : "W");
			}
			if (GUI.Button(new Rect(370f, 60f, 100f, 15f), "Game Type", textskinButton))
			{
				sortBy = ((!(sortBy == "g")) ? "g" : "G");
			}
			GUI.Label(new Rect(548f, 60f, 50f, 15f), "Host", textskin);
			GUI.Box(new Rect(235f, 415f, 560f, 62f), string.Empty, underTabStyle);
			if (GUI.Button(new Rect(577f, 425f, 200f, 35f), new GUIContent("Create Game", "Create a new server for others to join."), largebuttonskin))
			{
				worldwindow.SendMessage("fadein");
			}
			if (worldloading.enabled || isconnecting || LoginWindow.pubalpha > 0f || WorldWindow.statalpha != 0f || gameoptions.active || ConnectionObject.pubalpha > 0f || conobj || whirlds.active || accountsettings.active || alphaded > 0f || joinAlpha > 0f || PhotonNetwork.connectionStateDetailed == PeerState.DisconnectingFromGameserver || PhotonNetwork.connectionStateDetailed == PeerState.ConnectingToGameserver || PhotonNetwork.connectionStateDetailed != PeerState.JoinedLobby)
			{
				GUI.enabled = false;
			}
			else
			{
				GUI.enabled = true;
			}
			GUI.SetNextControlName("gamename");
			string text = gamenamestring.Replace("[rainy]", string.Empty);
			if (curworld == 5)
			{
				text = "More Maps";
				gamenamestring = AuthGameObject.whirldname;
			}
			else
			{
				AuthGameObject.whirldurl = string.Empty;
				AuthGameObject.whirldname = string.Empty;
				AuthGameObject.whirldmmurl = string.Empty;
			}
			if (GUI.Button(new Rect(290f, 425f, 235f, 35f), text, middlebutton))
			{
			}
			if (GUI.GetNameOfFocusedControl() == "gamename")
			{
			}
			if (GUI.Button(new Rect(252f, 425f, 41f, 35f), new GUIContent(string.Empty, "Quickly switch between available maps."), worldleft))
			{
				if (curworld != 0)
				{
					curworld--;
				}
				else
				{
					curworld = UnityScript.Lang.Extensions.get_length((System.Array)worlds) - 1;
				}
				gamenamestring = worlds[curworld];
			}
			if (GUI.Button(new Rect(525f, 425f, 41f, 35f), new GUIContent(string.Empty, "Quickly switch between available maps."), worldright))
			{
				if (curworld != UnityScript.Lang.Extensions.get_length((System.Array)worlds) - 1)
				{
					curworld++;
				}
				else
				{
					curworld = 0;
				}
				gamenamestring = worlds[curworld];
			}
			HostData[] array3 = new HostData[(data != null) ? (UnityScript.Lang.Extensions.get_length((System.Array)data) + aiArray.length) : aiArray.length];
			if (UnityScript.Lang.Extensions.get_length((System.Array)data) > 0)
			{
				int num2 = 0;
				int k = 0;
				HostData[] array4 = data;
				for (int length = array4.Length; k < length; k++)
				{
					if (array4[k].gameName.Contains("|AI"))
					{
						array3[num2] = array4[k];
						array3[num2].gameName = array3[num2].gameName.Replace("|AI", string.Empty);
						array3[num2].connectedPlayers = array3[num2].connectedPlayers + 1;
					}
					else
					{
						array3[num2] = array4[k];
					}
					num2++;
				}
			}
			int num3 = 0;
			IEnumerator enumerator = UnityRuntimeServices.GetEnumerator(aiArray);
			while (enumerator.MoveNext())
			{
				object obj3 = enumerator.Current;
				if (!(obj3 is AIPlayer))
				{
					obj3 = RuntimeServices.Coerce(obj3, typeof(AIPlayer));
				}
				AIPlayer aIPlayer = (AIPlayer)obj3;
				HostData hostData2 = new HostData();
				hostData2.comment = aIPlayer.ainame + "|" + aIPlayer.gametype + "|" + aIPlayer.ainame + ((!(aIPlayer.ainame2 != string.Empty)) ? string.Empty : (", " + aIPlayer.ainame2)) + ((!(aIPlayer.ainame3 != string.Empty)) ? string.Empty : (", " + aIPlayer.ainame3)) + "|None|" + aIPlayer.whirldurl + "|THIS*SERVER*IS*JOINABLE||" + aIPlayer.avgXP;
				UnityRuntimeServices.Update(enumerator, aIPlayer);
				hostData2.gameName = aIPlayer.location + "*AI";
				UnityRuntimeServices.Update(enumerator, aIPlayer);
				hostData2.connectedPlayers = ((!(aIPlayer.ainame2 != string.Empty)) ? 1 : 2) + ((aIPlayer.ainame3 != string.Empty) ? 1 : 0);
				UnityRuntimeServices.Update(enumerator, aIPlayer);
				hostData2.playerLimit = aIPlayer.maxplayers;
				UnityRuntimeServices.Update(enumerator, aIPlayer);
				hostData2.gameType = "AI" + (num3 + 1).ToString();
				array3[UnityScript.Lang.Extensions.get_length((System.Array)array3) - 1 - num3] = hostData2;
				num3++;
			}
			if (!RuntimeServices.EqualityOperator(array3, null))
			{
				HostData hostData3 = default(HostData);
				if (sortBy.ToLower() == "p")
				{
					UnityScript.Lang.Array array5 = new UnityScript.Lang.Array((IEnumerable)array3);
					for (int l = 0; l < UnityScript.Lang.Extensions.get_length((System.Array)array3); l++)
					{
						int num4 = -1;
						hostData3 = null;
						int index = 0;
						int num5 = 0;
						IEnumerator enumerator2 = UnityRuntimeServices.GetEnumerator(array5);
						while (enumerator2.MoveNext())
						{
							object obj4 = enumerator2.Current;
							if (!(obj4 is HostData))
							{
								obj4 = RuntimeServices.Coerce(obj4, typeof(HostData));
							}
							HostData hostData4 = (HostData)obj4;
							int num6 = hostData4.connectedPlayers + (hostData4.comment.Split("|"[0])[6].Contains("_AI") ? 1 : 0) + (hostData4.comment.Split("|"[0])[6].Contains("_AI2") ? 1 : 0) + (hostData4.comment.Split("|"[0])[6].Contains("_AI23") ? 1 : 0);
							UnityRuntimeServices.Update(enumerator2, hostData4);
							if (num6 > num4)
							{
								hostData3 = hostData4;
								UnityRuntimeServices.Update(enumerator2, hostData4);
								index = num5;
								num4 = num6;
							}
							num5++;
						}
						array3[l] = hostData3;
						array5.RemoveAt(index);
					}
				}
				if (sortBy.ToLower() == "w")
				{
					UnityScript.Lang.Array array5 = new UnityScript.Lang.Array((IEnumerable)array3);
					for (int l = 0; l < UnityScript.Lang.Extensions.get_length((System.Array)array3); l++)
					{
						int num4 = -1;
						int index = 0;
						int num5 = 0;
						IEnumerator enumerator3 = UnityRuntimeServices.GetEnumerator(array5);
						while (enumerator3.MoveNext())
						{
							object obj5 = enumerator3.Current;
							if (!(obj5 is HostData))
							{
								obj5 = RuntimeServices.Coerce(obj5, typeof(HostData));
							}
							HostData hostData5 = (HostData)obj5;
							int num7 = UnityScript.Lang.Extensions.get_length(hostData5.gameName.Split("("[0])[0].Split("*"[0])[0]);
							UnityRuntimeServices.Update(enumerator3, hostData5);
							if (num7 > num4)
							{
								hostData3 = hostData5;
								UnityRuntimeServices.Update(enumerator3, hostData5);
								index = num5;
								num4 = num7;
							}
							num5++;
						}
						array3[l] = hostData3;
						array5.RemoveAt(index);
					}
				}
				if (sortBy.ToLower() == "g")
				{
					UnityScript.Lang.Array array5 = new UnityScript.Lang.Array((IEnumerable)array3);
					for (int l = 0; l < UnityScript.Lang.Extensions.get_length((System.Array)array3); l++)
					{
						int num4 = 9999;
						int index = 0;
						int num5 = 0;
						IEnumerator enumerator4 = UnityRuntimeServices.GetEnumerator(array5);
						while (enumerator4.MoveNext())
						{
							object obj6 = enumerator4.Current;
							if (!(obj6 is HostData))
							{
								obj6 = RuntimeServices.Coerce(obj6, typeof(HostData));
							}
							HostData hostData6 = (HostData)obj6;
							int num7 = UnityScript.Lang.Extensions.get_length(hostData6.comment.Split("|"[0])[1].Split(" "[0])[0]);
							UnityRuntimeServices.Update(enumerator4, hostData6);
							if (num7 < num4)
							{
								hostData3 = hostData6;
								UnityRuntimeServices.Update(enumerator4, hostData6);
								index = num5;
								num4 = num7;
							}
							num5++;
						}
						array3[l] = hostData3;
						array5.RemoveAt(index);
					}
				}
				if (sortBy.ToLower() == "x")
				{
					UnityScript.Lang.Array array5 = new UnityScript.Lang.Array((IEnumerable)array3);
					for (int l = 0; l < UnityScript.Lang.Extensions.get_length((System.Array)array3); l++)
					{
						int num4 = -1;
						int index = 0;
						int num5 = 0;
						IEnumerator enumerator5 = UnityRuntimeServices.GetEnumerator(array5);
						while (enumerator5.MoveNext())
						{
							object obj7 = enumerator5.Current;
							if (!(obj7 is HostData))
							{
								obj7 = RuntimeServices.Coerce(obj7, typeof(HostData));
							}
							HostData hostData7 = (HostData)obj7;
							int num7 = UnityBuiltins.parseInt(hostData7.comment.Split("|"[0])[7]);
							UnityRuntimeServices.Update(enumerator5, hostData7);
							if (num7 > num4)
							{
								hostData3 = hostData7;
								UnityRuntimeServices.Update(enumerator5, hostData7);
								index = num5;
								num4 = num7;
							}
							num5++;
						}
						array3[l] = hostData3;
						array5.RemoveAt(index);
					}
				}
				if (sortBy == sortBy.ToUpper())
				{
					UnityScript.Lang.Array array6 = new UnityScript.Lang.Array((IEnumerable)array3);
					array6.Reverse();
					array3 = (HostData[])array6.ToBuiltin(typeof(HostData));
				}
			}
			qjData = array3;
			data = array3;
			UnityScript.Lang.Array array7 = new UnityScript.Lang.Array();
			GUI.SetNextControlName("searchfield");
			searchstring = GUI.TextField(new Rect(670f, 60f, 120f, 20f), searchstring);
			if (GUI.GetNameOfFocusedControl() == "searchfield" && searchstring == "Search...")
			{
				searchstring = string.Empty;
			}
			else if (GUI.GetNameOfFocusedControl() != "searchfield" && searchstring.Replace(" ", string.Empty) == string.Empty)
			{
				searchstring = "Search...";
			}
			GUI.BeginGroup(new Rect(0f, 85f, 800f, 495f));
			int num8 = 0;
			num8 = 0;
			if (!RuntimeServices.EqualityOperator(data, null))
			{
				scrollPosition = GUI.BeginScrollView(new Rect(0f, 0f, 795f, 320f), scrollPosition, new Rect(0f, 0f, 770f, 25 * UnityScript.Lang.Extensions.get_length((System.Array)data) + 55));
				string text2 = "There are currently (" + ((data == null) ? 3 : UnityScript.Lang.Extensions.get_length((System.Array)data)).ToString() + ") servers hosted on Carbon Combat. Click \"Connect\" to join one!";
				GUI.Label(new Rect(0f, 25 * UnityScript.Lang.Extensions.get_length((System.Array)data) - 25, 800f, 75f), text2, serverLabel);
				int m = 0;
				HostData[] array8 = data;
				for (int length2 = array8.Length; m < length2; m++)
				{
					if (findServerWithUser != string.Empty)
					{
						string[] array9 = array8[m].comment.Split("|"[0])[2].Split(","[0]);
						string[] array10 = array8[m].comment.Split("|"[0])[3].Split(","[0]);
						string text3 = null;
						IEnumerator enumerator6 = array9.GetEnumerator();
						while (enumerator6.MoveNext())
						{
							object obj8 = enumerator6.Current;
							if (!(obj8 is string))
							{
								obj8 = RuntimeServices.Coerce(obj8, typeof(string));
							}
							text3 = (string)obj8;
							if (text3.Replace(" ", string.Empty) == findServerWithUser)
							{
								StartCoroutine_Auto(connectdelegate(array8[m]));
								findServerWithUser = string.Empty;
							}
						}
						IEnumerator enumerator7 = array10.GetEnumerator();
						while (enumerator7.MoveNext())
						{
							object obj9 = enumerator7.Current;
							if (!(obj9 is string))
							{
								obj9 = RuntimeServices.Coerce(obj9, typeof(string));
							}
							text3 = (string)obj9;
							if (text3.Replace(" ", string.Empty) == findServerWithUser)
							{
								StartCoroutine_Auto(connectdelegate(array8[m]));
								findServerWithUser = string.Empty;
							}
						}
					}
					bool flag2 = true;
					if (searchstring != string.Empty && searchstring != "Search..." && !array8[m].comment.ToLower().Contains(searchstring.ToLower()) && !array8[m].gameName.ToLower().Contains(searchstring.ToLower()))
					{
						flag2 = false;
					}
					if (!flag2)
					{
						continue;
					}
					string[] array11 = array8[m].comment.Split("|"[0]);
					if (((float)num8 / 2f).ToString().Contains("."))
					{
						float a2 = 0.7f;
						Color color4 = GUI.color;
						float num9 = (color4.a = a2);
						Color color5 = (GUI.color = color4);
						GUI.Box(new Rect(6f, 25 * num8, 788f, 24f), new GUIContent(string.Empty, "Active Players: " + array11[2] + "\nSpectators: " + array11[3]), linetex);
						int num10 = 1;
						Color color7 = GUI.color;
						float num11 = (color7.a = num10);
						Color color8 = (GUI.color = color7);
					}
					if (!((float)num8 / 2f).ToString().Contains("."))
					{
						float a3 = 0f;
						Color color10 = GUI.color;
						float num12 = (color10.a = a3);
						Color color11 = (GUI.color = color10);
						GUI.Box(new Rect(6f, 25 * num8, 788f, 24f), new GUIContent(string.Empty, "Active Players: " + array11[2] + "\nSpectators: " + array11[3]), linetex);
						int num13 = 1;
						Color color13 = GUI.color;
						float num14 = (color13.a = num13);
						Color color14 = (GUI.color = color13);
					}
					GUILayout.BeginHorizontal();
					GUILayout.Space(30f);
					string text4 = (array8[m].connectedPlayers + (array11[6].Contains("_AI") ? 1 : 0) + (array11[6].Contains("_AI2") ? 1 : 0) + (array11[6].Contains("_AI23") ? 1 : 0)).ToString() + " / " + array8[m].playerLimit.ToString();
					if (array8[m].playerLimit < 10)
					{
						text4 = " " + text4;
					}
					GUILayout.Label(text4, numberlabel, GUILayout.Width(30f));
					GUILayout.Space(15f);
					GUILayout.Label(array11[7], labelskin, GUILayout.Width(20f));
					GUILayout.Space(107f);
					string text5 = array8[m].gameName.Split("*"[0])[0];
					if (text5.Contains("[rainy]"))
					{
						text5 = text5.Replace("[rainy]", string.Empty);
					}
					GUILayout.Label(text5, labelskin, GUILayout.Width(160f));
					GUILayout.Space(9f);
					GUILayout.Label(array11[1], labelskin, GUILayout.Width(130f));
					GUILayout.Space(24f);
					GUILayout.Label(array11[0], labelskin, GUILayout.Width(130f));
					GUILayout.Space(22f);
					GUILayout.FlexibleSpace();
					int num15 = array8[m].connectedPlayers + (array11[6].Contains("_AI") ? 1 : 0) + (array11[6].Contains("_AI2") ? 1 : 0) + (array11[6].Contains("_AI23") ? 1 : 0);
					string text6 = "Connect";
					if (worldloading.enabled || isconnecting || LoginWindow.pubalpha > 0f || WorldWindow.statalpha != 0f || gameoptions.active || ConnectionObject.pubalpha > 0f || conobj || whirlds.active || accountsettings.active || alphaded > 0f || joinAlpha > 0f || PhotonNetwork.connectionStateDetailed == PeerState.DisconnectingFromGameserver || PhotonNetwork.connectionStateDetailed == PeerState.ConnectingToGameserver || PhotonNetwork.connectionStateDetailed != PeerState.JoinedLobby)
					{
						GUI.enabled = false;
					}
					else if (num15 >= array8[m].playerLimit)
					{
						GUI.enabled = false;
						text6 = "Full";
					}
					else if (!(Application.GetStreamProgressForLevel("NuclearSilo") >= 1f) && array8[m].gameName.Contains("Abandoned Silos"))
					{
						GUI.enabled = false;
						text6 = "Loading " + Mathf.Round(Application.GetStreamProgressForLevel("NuclearSilo") * 100f).ToString() + "%";
					}
					else if (!(Application.GetStreamProgressForLevel("NewIsland") >= 1f) && array8[m].gameName.Contains("Unity Island"))
					{
						GUI.enabled = false;
						text6 = "Loading " + Mathf.Round(Application.GetStreamProgressForLevel("NewIsland") * 100f).ToString() + "%";
					}
					else if (!(Application.GetStreamProgressForLevel("MainScene") >= 1f) && array8[m].gameName.Contains("MainScene"))
					{
						GUI.enabled = false;
						text6 = "Loading " + Mathf.Round(Application.GetStreamProgressForLevel("MainScene") * 100f).ToString() + "%";
					}
					else if (!(Application.GetStreamProgressForLevel("Sanctum") >= 1f) && array8[m].gameName.Contains("Sanctum"))
					{
						GUI.enabled = false;
						text6 = "Loading " + Mathf.Round(Application.GetStreamProgressForLevel("Sanctum") * 100f).ToString() + "%";
					}
					else
					{
						GUI.enabled = true;
					}
					if (PreloaderExplosion.psAPI)
					{
						GUI.enabled = false;
					}
					if (GUILayout.Button(text6, connectbutton))
					{
						if (PlayerPrefs.HasKey("tutorialKey"))
						{
							StartCoroutine_Auto(connectdelegate(array8[m]));
						}
						else
						{
							StartCoroutine_Auto(connectToTutorial());
						}
					}
					if (worldloading.enabled || isconnecting || LoginWindow.pubalpha > 0f || WorldWindow.statalpha != 0f || gameoptions.active || ConnectionObject.pubalpha > 0f || conobj || whirlds.active || accountsettings.active || alphaded > 0f || joinAlpha > 0f || PhotonNetwork.connectionStateDetailed == PeerState.DisconnectingFromGameserver || PhotonNetwork.connectionStateDetailed == PeerState.ConnectingToGameserver || PhotonNetwork.connectionStateDetailed != PeerState.JoinedLobby)
					{
						GUI.enabled = false;
					}
					else
					{
						GUI.enabled = true;
					}
					GUILayout.EndHorizontal();
					num8++;
				}
				GUI.EndScrollView();
			}
			data = null;
			GUI.EndGroup();
			GUI.EndGroup();
			GUI.EndGroup();
			if (GUI.tooltip != string.Empty)
			{
				fadetool = true;
			}
			else
			{
				fadetool = false;
			}
			float a4 = toolalpha;
			Color color16 = GUI.color;
			float num16 = (color16.a = a4);
			Color color17 = (GUI.color = color16);
			tooltipstyle.normal.background = (Texture2D)origtooltip;
			GUI.Label(new Rect(Mathf.Min(Input.mousePosition.x, Screen.width - 324), Mathf.Min((float)Screen.height - Input.mousePosition.y + 15f - 27f, Screen.height - 70 - 27), 324f, 70f), GUI.tooltip, tooltipstyle);
		}
		if (!(alphaded <= 0f))
		{
			GUI.enabled = true;
			float a5 = alphaded;
			Color color19 = GUI.color;
			float num17 = (color19.a = a5);
			Color color20 = (GUI.color = color19);
			GUI.BeginGroup(new Rect(Screen.width / 2 - 144, Screen.height / 2 - 38, 288f, 76f));
			GUI.Box(new Rect(0f, 0f, 288f, 76f), dedmessage, dedWindow);
			GUI.EndGroup();
		}
		float a6 = joinAlpha;
		Color color22 = GUI.color;
		float num18 = (color22.a = a6);
		Color color23 = (GUI.color = color22);
		GUI.enabled = true;
		if (!(joinAlpha <= 0f))
		{
			GUI.BeginGroup(new Rect(0f, 13f, Screen.width, Screen.height));
			GUI.BeginGroup(new Rect(Screen.width / 2 - 175, Screen.height / 2 - 92, 350f, 185f));
			GUI.Box(new Rect(0f, 0f, 350f, 220f), "Finding Server", qjoinstyle);
			GUI.Label(new Rect(25f, 30f, 300f, 60f), "Quick Play automates the process of joining a server; click \"Play\" in the menubar to manually find a server.", qtextstyle);
			GUI.enabled = false;
			if (GUI.Button(new Rect(25f, 100f, 300f, 25f), "Attempting to join server " + quickJoinServerHost + " - (" + Mathf.Round(yieldTime) + ")", buttonskin))
			{
			}
			if (!(yieldTime <= 5f))
			{
				GUI.enabled = true;
				if (GUI.Button(new Rect(25f, 135f, 300f, 25f), "Cancel Quick Join (manual server joining)", buttonskin))
				{
					quickJoining = false;
					StartCoroutine_Auto(fadeOutJoinMode());
				}
			}
			else
			{
				GUI.enabled = false;
				if (GUI.Button(new Rect(25f, 135f, 300f, 25f), "Cannot abort server join", buttonskin))
				{
					quickJoining = false;
					StartCoroutine_Auto(fadeOutJoinMode());
				}
			}
			GUI.EndGroup();
			GUI.EndGroup();
		}
		GUI.EndGroup();
	}

	public virtual void joinFriendServer(string u)
	{
		findServerWithUser = u;
	}

	public virtual IEnumerator fadeInJoinMode()
	{
		return new _0024fadeInJoinMode_00244840(this).GetEnumerator();
	}

	public virtual IEnumerator fadeOutJoinMode()
	{
		return new _0024fadeOutJoinMode_00244843(this).GetEnumerator();
	}

	public virtual IEnumerator Start()
	{
		return new _0024Start_00244846(this).GetEnumerator();
	}

	public virtual void setworldname(string n)
	{
		int num = 0;
		int i = 0;
		string[] array = worlds;
		for (int length = array.Length; i < length; i++)
		{
			if (num < 5)
			{
				worlds[num] = array[i].Substring(0, array[i].IndexOf("(") - 1) + n;
				num++;
			}
		}
		gamenamestring = worlds[curworld];
	}

	public virtual IEnumerator fadeInDed()
	{
		return new _0024fadeInDed_00244849(this).GetEnumerator();
	}

	public virtual IEnumerator fadeOutDed()
	{
		return new _0024fadeOutDed_00244852(this).GetEnumerator();
	}

	public virtual void OnLeftRoom()
	{
		leftRoom = true;
	}

	public virtual IEnumerator remotestartserver()
	{
		return new _0024remotestartserver_00244855(this).GetEnumerator();
	}

	public virtual IEnumerator connectToTutorial()
	{
		return new _0024connectToTutorial_00244860(this).GetEnumerator();
	}

	public virtual IEnumerator connectdelegate(HostData element)
	{
		return new _0024connectdelegate_00244868(element, this).GetEnumerator();
	}

	public virtual void OnJoinedRoom()
	{
		leftRoom = false;
		if (PhotonNetwork.room.name != "chatRoom2")
		{
			PhotonNetwork.SetSendingEnabled(0, false);
			PhotonNetwork.SetSendingEnabled(8, false);
			PhotonNetwork.SetSendingEnabled(9, false);
			PhotonNetwork.SetSendingEnabled(10, false);
			PhotonNetwork.isMessageQueueRunning = false;
		}
	}

	public virtual IEnumerator goloadworld(HostData i, string m, bool iw)
	{
		return new _0024goloadworld_00244883(i, m, iw, this).GetEnumerator();
	}

	public virtual void setconobj(bool t)
	{
		conobj = t;
	}

	public virtual IEnumerator connectTest(HostData hostdata)
	{
		return new _0024connectTest_00244892(hostdata, this).GetEnumerator();
	}

	public virtual object[] RandomizeBuiltinArray(object[] arr)
	{
		for (int num = arr.Length - 1; num > 0; num--)
		{
			int num2 = UnityEngine.Random.Range(0, num);
			object obj = arr[num];
			arr[num] = arr[num2];
			arr[num2] = obj;
		}
		return arr;
	}

	public virtual IEnumerator quickJoin(HostData[] hd)
	{
		return new _0024quickJoin_00244908(hd, this).GetEnumerator();
	}

	public virtual void OnDisconnectedFromPhoton()
	{
		if (!attemptToReconnect)
		{
			Debug.Log("We got disconnected from Photon! Trying to reconnect...");
			attemptToReconnect = true;
			StartCoroutine_Auto(tryToReconnect());
		}
	}

	public virtual IEnumerator tryToReconnect()
	{
		return new _0024tryToReconnect_00244920(this).GetEnumerator();
	}

	public virtual void Update()
	{
		if ((PhotonNetwork.connectionStateDetailed == PeerState.PeerCreated || PhotonNetwork.connectionStateDetailed == PeerState.Uninitialized || PhotonNetwork.connectionStateDetailed == PeerState.Disconnected) && !attemptToReconnect)
		{
			Debug.Log("We were found to be disconnected, trying to reconnect...");
			attemptToReconnect = true;
			StartCoroutine_Auto(tryToReconnect());
		}
		if (!(peerstateDebug <= 0f))
		{
			peerstateDebug -= Time.deltaTime;
		}
		else
		{
			peerstateDebug = 5f;
			Debug.Log("DebugMessage5Seconds ::: Our PhotonConnectionState is: " + PhotonNetwork.connectionStateDetailed.ToString() + " and our room name is: " + ((PhotonNetwork.room == null) ? "notInARoom" : PhotonNetwork.room.name));
		}
		if (AdjustCamDistance.camstate != 2 && !(joinAlpha < 1f))
		{
			StartCoroutine_Auto(fadeOutJoinMode());
		}
		if (!Screen.showCursor)
		{
			Screen.showCursor = true;
		}
		if (fadetool)
		{
			toolalpha = Mathf.Min(1f, toolalpha + 4f * Time.deltaTime);
		}
		else
		{
			toolalpha = Mathf.Max(0f, toolalpha - 4f * Time.deltaTime);
		}
		if (!(hosttimer <= 0f) && starthosttimer)
		{
			hosttimer -= Time.deltaTime;
			return;
		}
		hosttimer = 5f;
		continuehost = false;
		starthosttimer = false;
	}

	public virtual void OnFailedToConnectToPhoton()
	{
		Debug.Log("Failed to connect to Photon! Trying to reconnect...");
		if (!attemptToReconnect)
		{
			attemptToReconnect = true;
			StartCoroutine_Auto(tryToReconnect());
		}
	}

	public virtual void OnCreatedRoom()
	{
		continuehost = true;
	}

	public virtual void Main()
	{
		hostHashtable = new Hashtable();
	}
}
