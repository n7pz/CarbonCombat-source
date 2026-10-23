using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using Photon;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class DisplayTopPlayers : Photon.MonoBehaviour
{
	[Serializable]
	internal sealed class _0024enableFunction_00243540 : GenericGenerator<WWW>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WWW>, IEnumerator
		{
			internal bool _0024exists_00243541;

			internal int _0024randomnumber_00243542;

			internal WWW _0024rankings_00243543;

			internal string[] _0024returnArr_00243544;

			internal string _0024str_00243545;

			internal GameObject _0024kongobj_00243546;

			internal WWW _0024friends_00243547;

			internal UnityScript.Lang.Array _0024tempArr_00243548;

			internal string _0024f_00243549;

			internal Friend _0024newFObj_00243550;

			internal int _0024_0024456_00243551;

			internal string[] _0024_0024457_00243552;

			internal int _0024_0024458_00243553;

			internal int _0024_0024460_00243554;

			internal string[] _0024_0024461_00243555;

			internal int _0024_0024462_00243556;

			internal DisplayTopPlayers _0024self__00243557;

			public _0024(DisplayTopPlayers self_)
			{
				_0024self__00243557 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024exists_00243541 = false;
					if (!AuthGameObject.username.Contains("guest_"))
					{
						_0024randomnumber_00243542 = UnityEngine.Random.Range(0, 99999);
						_0024rankings_00243543 = new WWW("http://72.14.184.180/rankingsManager.php?request=returnMyRank&key=" + Md5Sum.ComputeMd5(global::DontDestroyOnLoad.hitcollider + _0024randomnumber_00243542.ToString()) + "&random=" + _0024randomnumber_00243542.ToString() + "&user=" + AuthGameObject.username);
						result = (Yield(2, _0024rankings_00243543) ? 1 : 0);
						break;
					}
					fetchedRankings = true;
					_0024self__00243557.failed = false;
					goto IL_028b;
				case 2:
					if (string.IsNullOrEmpty(_0024rankings_00243543.error))
					{
						_0024returnArr_00243544 = _0024rankings_00243543.text.Split("|"[0]);
						_0024self__00243557.userarr = new string[UnityBuiltins.parseInt(_0024returnArr_00243544[3])];
						_0024_0024456_00243551 = 0;
						_0024_0024457_00243552 = _0024self__00243557.userarr;
						for (_0024_0024458_00243553 = _0024_0024457_00243552.Length; _0024_0024456_00243551 < _0024_0024458_00243553; _0024_0024456_00243551++)
						{
							_0024_0024457_00243552[_0024_0024456_00243551] = "Loading...|--";
						}
						_0024self__00243557.myrank = UnityBuiltins.parseInt(_0024returnArr_00243544[2]) + 1;
						myrankStat = _0024self__00243557.myrank;
						_0024self__00243557.mypoints = UnityBuiltins.parseInt(_0024returnArr_00243544[1]);
						mypointsStat = _0024self__00243557.mypoints;
						_0024self__00243557.userarr[_0024self__00243557.myrank - 1] = AuthGameObject.username + "|" + _0024self__00243557.mypoints.ToString();
						if (Application.isWebPlayer && !AuthGameObject.username.Contains("guest_"))
						{
							_0024kongobj_00243546 = GameObject.Find("KongregateAPI");
							((KongregateAPI)_0024kongobj_00243546.GetComponent(typeof(KongregateAPI))).SubmitStat("Player Rankings", _0024self__00243557.mypoints);
						}
						fetchedRankings = true;
					}
					else
					{
						_0024self__00243557.failed = true;
					}
					goto IL_028b;
				case 3:
					_0024tempArr_00243548 = new UnityScript.Lang.Array();
					Debug.Log(_0024friends_00243547.text);
					if (string.IsNullOrEmpty(_0024friends_00243547.error) && _0024friends_00243547.text != string.Empty)
					{
						_0024_0024460_00243554 = 0;
						_0024_0024461_00243555 = _0024friends_00243547.text.Split(","[0]);
						for (_0024_0024462_00243556 = _0024_0024461_00243555.Length; _0024_0024460_00243554 < _0024_0024462_00243556; _0024_0024460_00243554++)
						{
							_0024newFObj_00243550 = new Friend(_0024_0024461_00243555[_0024_0024460_00243554], false);
							_0024tempArr_00243548.Add(_0024newFObj_00243550);
						}
					}
					AuthGameObject.friendsArr = _0024tempArr_00243548;
					goto IL_03f3;
				case 1:
					{
						result = 0;
						break;
					}
					IL_03f3:
					YieldDefault(1);
					goto case 1;
					IL_028b:
					if (!AuthGameObject.username.Contains("guest_"))
					{
						_0024friends_00243547 = new WWW("http://72.14.184.180/rankingsManager.php?request=returnFriends&key=" + Md5Sum.ComputeMd5(global::DontDestroyOnLoad.hitcollider + _0024randomnumber_00243542.ToString()) + "&random=" + _0024randomnumber_00243542.ToString() + "&user=" + AuthGameObject.username);
						result = (Yield(3, _0024friends_00243547) ? 1 : 0);
						break;
					}
					goto IL_03f3;
				}
				return (byte)result != 0;
			}
		}

		internal DisplayTopPlayers _0024self__00243558;

		public _0024enableFunction_00243540(DisplayTopPlayers self_)
		{
			_0024self__00243558 = self_;
		}

		public override IEnumerator<WWW> GetEnumerator()
		{
			return new _0024(_0024self__00243558);
		}
	}

	[Serializable]
	internal sealed class _0024loadMyWorlds_00243559 : GenericGenerator<WWW>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WWW>, IEnumerator
		{
			internal WWW _0024worlds_00243560;

			internal string _0024world_00243561;

			internal int _0024_0024464_00243562;

			internal string[] _0024_0024465_00243563;

			internal int _0024_0024466_00243564;

			internal string _0024u_00243565;

			internal DisplayTopPlayers _0024self__00243566;

			public _0024(string u, DisplayTopPlayers self_)
			{
				_0024u_00243565 = u;
				_0024self__00243566 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024worlds_00243560 = new WWW("http://72.14.184.180/listWorlds.php?search=" + _0024u_00243565);
					result = (Yield(2, _0024worlds_00243560) ? 1 : 0);
					break;
				case 2:
					if (string.IsNullOrEmpty(_0024worlds_00243560.error) && _0024worlds_00243560.text.Contains("|"))
					{
						_0024self__00243566.showMyWorlds = true;
						myWorldsArr.Clear();
						myWorldsURL.Clear();
						_0024_0024464_00243562 = 0;
						_0024_0024465_00243563 = _0024worlds_00243560.text.Split("|"[0]);
						for (_0024_0024466_00243564 = _0024_0024465_00243563.Length; _0024_0024464_00243562 < _0024_0024466_00243564; _0024_0024464_00243562++)
						{
							if (_0024_0024465_00243563[_0024_0024464_00243562].Contains(","))
							{
								myWorldsArr.Add(WWW.UnEscapeURL(_0024_0024465_00243563[_0024_0024464_00243562].Split(","[0])[0]));
								myWorldsURL.Add(_0024_0024465_00243563[_0024_0024464_00243562].Split(","[0])[1]);
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

		internal string _0024u_00243567;

		internal DisplayTopPlayers _0024self__00243568;

		public _0024loadMyWorlds_00243559(string u, DisplayTopPlayers self_)
		{
			_0024u_00243567 = u;
			_0024self__00243568 = self_;
		}

		public override IEnumerator<WWW> GetEnumerator()
		{
			return new _0024(_0024u_00243567, _0024self__00243568);
		}
	}

	[Serializable]
	internal sealed class _0024fetchRel_00243569 : GenericGenerator<WWW>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WWW>, IEnumerator
		{
			internal int _0024randomnumber_00243570;

			internal WWW _0024rankings_00243571;

			internal string[] _0024splitStr_00243572;

			internal string _0024str_00243573;

			internal string[] _0024subsplit_00243574;

			internal int _0024_0024468_00243575;

			internal string[] _0024_0024469_00243576;

			internal int _0024_0024470_00243577;

			internal DisplayTopPlayers _0024self__00243578;

			public _0024(DisplayTopPlayers self_)
			{
				_0024self__00243578 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (!AuthGameObject.username.Contains("guest_"))
					{
						_0024randomnumber_00243570 = UnityEngine.Random.Range(0, 99999);
						_0024rankings_00243571 = new WWW("http://72.14.184.180/rankingsManager.php?request=returnMyRankRel&key=" + Md5Sum.ComputeMd5(global::DontDestroyOnLoad.hitcollider + _0024randomnumber_00243570.ToString()) + "&random=" + _0024randomnumber_00243570.ToString() + "&user=" + AuthGameObject.username);
						result = (Yield(2, _0024rankings_00243571) ? 1 : 0);
						break;
					}
					goto IL_01a8;
				case 2:
					if (string.IsNullOrEmpty(_0024rankings_00243571.error))
					{
						_0024splitStr_00243572 = _0024rankings_00243571.text.Split(","[0]);
						_0024_0024468_00243575 = 0;
						_0024_0024469_00243576 = _0024splitStr_00243572;
						for (_0024_0024470_00243577 = _0024_0024469_00243576.Length; _0024_0024468_00243575 < _0024_0024470_00243577; _0024_0024468_00243575++)
						{
							_0024subsplit_00243574 = _0024_0024469_00243576[_0024_0024468_00243575].Split("|"[0]);
							Debug.Log(_0024_0024469_00243576[_0024_0024468_00243575]);
							_0024self__00243578.userarr[UnityBuiltins.parseInt(_0024subsplit_00243574[2])] = _0024subsplit_00243574[0] + "|" + _0024subsplit_00243574[1];
						}
					}
					goto IL_01a8;
				case 1:
					{
						result = 0;
						break;
					}
					IL_01a8:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal DisplayTopPlayers _0024self__00243579;

		public _0024fetchRel_00243569(DisplayTopPlayers self_)
		{
			_0024self__00243579 = self_;
		}

		public override IEnumerator<WWW> GetEnumerator()
		{
			return new _0024(_0024self__00243579);
		}
	}

	[Serializable]
	internal sealed class _0024fetchRankings_00243580 : GenericGenerator<WWW>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WWW>, IEnumerator
		{
			internal int _0024randomnumber_00243581;

			internal string _0024users_00243582;

			internal int _0024i_00243583;

			internal WWW _0024rankings_00243584;

			internal string[] _0024splitStr_00243585;

			internal string _0024str_00243586;

			internal string[] _0024subsplit_00243587;

			internal int _0024_0024472_00243588;

			internal string[] _0024_0024473_00243589;

			internal int _0024_0024474_00243590;

			internal int _0024start_00243591;

			internal int _0024stop_00243592;

			internal DisplayTopPlayers _0024self__00243593;

			public _0024(int start, int stop, DisplayTopPlayers self_)
			{
				_0024start_00243591 = start;
				_0024stop_00243592 = stop;
				_0024self__00243593 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024randomnumber_00243581 = UnityEngine.Random.Range(0, 99999);
					_0024users_00243582 = _0024start_00243591.ToString();
					for (_0024i_00243583 = _0024start_00243591 + 1; _0024i_00243583 < _0024stop_00243592 + 1; _0024i_00243583++)
					{
						_0024users_00243582 += "," + _0024i_00243583.ToString();
					}
					_0024rankings_00243584 = new WWW("http://72.14.184.180/rankingsManager.php?request=returnUsersFromRank&key=" + Md5Sum.ComputeMd5(global::DontDestroyOnLoad.hitcollider + _0024randomnumber_00243581.ToString()) + "&random=" + _0024randomnumber_00243581.ToString() + "&user=" + _0024users_00243582);
					result = (Yield(2, _0024rankings_00243584) ? 1 : 0);
					break;
				case 2:
					if (string.IsNullOrEmpty(_0024rankings_00243584.error))
					{
						_0024splitStr_00243585 = _0024rankings_00243584.text.Split(","[0]);
						_0024_0024472_00243588 = 0;
						_0024_0024473_00243589 = _0024splitStr_00243585;
						for (_0024_0024474_00243590 = _0024_0024473_00243589.Length; _0024_0024472_00243588 < _0024_0024474_00243590; _0024_0024472_00243588++)
						{
							_0024subsplit_00243587 = _0024_0024473_00243589[_0024_0024472_00243588].Split("|"[0]);
							_0024self__00243593.userarr[UnityBuiltins.parseInt(_0024subsplit_00243587[2])] = _0024subsplit_00243587[0] + "|" + _0024subsplit_00243587[1];
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

		internal int _0024start_00243594;

		internal int _0024stop_00243595;

		internal DisplayTopPlayers _0024self__00243596;

		public _0024fetchRankings_00243580(int start, int stop, DisplayTopPlayers self_)
		{
			_0024start_00243594 = start;
			_0024stop_00243595 = stop;
			_0024self__00243596 = self_;
		}

		public override IEnumerator<WWW> GetEnumerator()
		{
			return new _0024(_0024start_00243594, _0024stop_00243595, _0024self__00243596);
		}
	}

	[Serializable]
	internal sealed class _0024fadein_00243597 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal DisplayTopPlayers _0024self__00243598;

			public _0024(DisplayTopPlayers self_)
			{
				_0024self__00243598 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00243598.StartCoroutine_Auto(_0024self__00243598.fetchRel());
					_0024self__00243598.StartCoroutine_Auto(_0024self__00243598.fetchRankings(0, 11));
					goto case 2;
				case 2:
					if (_0024self__00243598.alpha < 1f)
					{
						_0024self__00243598.alpha = Mathf.Min(1f, _0024self__00243598.alpha + 4f * Time.deltaTime);
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

		internal DisplayTopPlayers _0024self__00243599;

		public _0024fadein_00243597(DisplayTopPlayers self_)
		{
			_0024self__00243599 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00243599);
		}
	}

	[Serializable]
	internal sealed class _0024fadeOut_00243600 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal DisplayTopPlayers _0024self__00243601;

			public _0024(DisplayTopPlayers self_)
			{
				_0024self__00243601 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__00243601.alpha > 0f)
					{
						_0024self__00243601.alpha = Mathf.Max(0f, _0024self__00243601.alpha - 4f * Time.deltaTime);
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					AdjustCamDistance.showRankWindow = false;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal DisplayTopPlayers _0024self__00243602;

		public _0024fadeOut_00243600(DisplayTopPlayers self_)
		{
			_0024self__00243602 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00243602);
		}
	}

	[Serializable]
	internal sealed class _0024OnPhotonJoinGameFailed_00243603 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					Debug.Log("FAILED TO JOIN CHAT!");
					canChat = false;
					result = (Yield(2, new WaitForSeconds(2f)) ? 1 : 0);
					break;
				case 2:
					if (PhotonNetwork.connectionStateDetailed != PeerState.ConnectingToGameserver && RuntimeServices.EqualityOperator(PhotonNetwork.room, null))
					{
						PhotonNetwork.CreateRoom("chatRoom2", true, true, 100);
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

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024();
		}
	}

	[Serializable]
	internal sealed class _0024OnPhotonCreateGameFailed_00243604 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					Debug.Log("FAILED TO CREATE CHAT!");
					canChat = false;
					result = (Yield(2, new WaitForSeconds(2f)) ? 1 : 0);
					break;
				case 2:
					if (PhotonNetwork.connectionStateDetailed != PeerState.ConnectingToGameserver && RuntimeServices.EqualityOperator(PhotonNetwork.room, null))
					{
						PhotonNetwork.JoinRoom("chatRoom2");
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

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024();
		}
	}

	[Serializable]
	internal sealed class _0024sendChat_00243605 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal bool _0024isPM_00243606;

			internal bool _0024userOnline_00243607;

			internal PhotonPlayer _0024pp_00243608;

			internal int _0024_0024484_00243609;

			internal PhotonPlayer[] _0024_0024485_00243610;

			internal int _0024_0024486_00243611;

			internal string _0024message_00243612;

			internal string _0024user_00243613;

			internal PhotonMessageInfo _0024info_00243614;

			internal DisplayTopPlayers _0024self__00243615;

			public _0024(string message, string user, PhotonMessageInfo info, DisplayTopPlayers self_)
			{
				_0024message_00243612 = message;
				_0024user_00243613 = user;
				_0024info_00243614 = info;
				_0024self__00243615 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024user_00243613 == "CarbonTech" || _0024user_00243613 == "nattyfrank" || _0024user_00243613 == "techietotoro" || _0024user_00243613 == "Apophis" || _0024user_00243613 == "TheGoodGuy" || _0024user_00243613 == "Nattyfrank")
					{
						_0024user_00243613 = "[mod] " + _0024user_00243613;
					}
					_0024isPM_00243606 = false;
					_0024userOnline_00243607 = false;
					if (_0024message_00243612.Contains("|"))
					{
						_0024isPM_00243606 = true;
						_0024_0024484_00243609 = 0;
						_0024_0024485_00243610 = PhotonNetwork.playerList;
						for (_0024_0024486_00243611 = _0024_0024485_00243610.Length; _0024_0024484_00243609 < _0024_0024486_00243611; _0024_0024484_00243609++)
						{
							if (_0024_0024485_00243610[_0024_0024484_00243609].name == _0024message_00243612.Split("|"[0])[1].Replace("|", string.Empty))
							{
								_0024userOnline_00243607 = true;
							}
						}
					}
					if (!_0024isPM_00243606)
					{
						_0024self__00243615.messageArray.Add(_0024user_00243613 + ": " + _0024message_00243612);
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					if (_0024userOnline_00243607)
					{
						if (AuthGameObject.username == _0024message_00243612.Split("|"[0])[1].Replace("|", string.Empty) || RuntimeServices.EqualityOperator(_0024info_00243614.sender, PhotonNetwork.player))
						{
							_0024self__00243615.messageArray.Add("(private) " + _0024user_00243613 + ": " + _0024message_00243612.Split("|"[0])[0].Replace("|", string.Empty));
							result = (YieldDefault(3) ? 1 : 0);
							break;
						}
					}
					else if (RuntimeServices.EqualityOperator(_0024info_00243614.sender, PhotonNetwork.player))
					{
						_0024self__00243615.messageArray.Add("[User is not online]");
						result = (YieldDefault(4) ? 1 : 0);
						break;
					}
					goto IL_030f;
				case 2:
					_0024self__00243615.scrollPos.y = 1000000f;
					goto IL_030f;
				case 3:
					_0024self__00243615.scrollPos.y = 1000000f;
					goto IL_030f;
				case 4:
					_0024self__00243615.scrollPos.y = 1000000f;
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

		internal string _0024message_00243616;

		internal string _0024user_00243617;

		internal PhotonMessageInfo _0024info_00243618;

		internal DisplayTopPlayers _0024self__00243619;

		public _0024sendChat_00243605(string message, string user, PhotonMessageInfo info, DisplayTopPlayers self_)
		{
			_0024message_00243616 = message;
			_0024user_00243617 = user;
			_0024info_00243618 = info;
			_0024self__00243619 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024message_00243616, _0024user_00243617, _0024info_00243618, _0024self__00243619);
		}
	}

	private string[] userarr;

	public LoginWindow lwindow;

	public AuthGameObject authobj;

	public MasterServerScript mserver;

	private AdjustCamDistance adist;

	public GUIStyle loginstyle;

	public GUIStyle textstyle;

	public GUIStyle rankingstyle;

	public GUIStyle rankingstyle2;

	public GUIStyle buttonstyle;

	public GUISkin scrollstyle;

	public GUIStyle tabButton;

	public GUIStyle titleText;

	public GUIStyle rankingstyleButton;

	public Vector2 scrollPosition;

	public Texture greytex;

	private float alpha;

	private int myrank;

	public DontDestroyOnLoad ddol;

	private bool trans;

	private bool startHoverKilling;

	private bool failed;

	private bool isexpanded;

	private int currentindex;

	private int curin;

	private int curin2;

	private int curin3;

	private int mypoints;

	private int currentTab;

	private bool showWorlds;

	[NonSerialized]
	public static UnityScript.Lang.Array topWorldsArr = new UnityScript.Lang.Array();

	[NonSerialized]
	public static UnityScript.Lang.Array topWorldsR = new UnityScript.Lang.Array();

	[NonSerialized]
	public static UnityScript.Lang.Array topWorldsURL = new UnityScript.Lang.Array();

	[NonSerialized]
	public static UnityScript.Lang.Array newWorldsArr = new UnityScript.Lang.Array();

	[NonSerialized]
	public static UnityScript.Lang.Array newWorldsURL = new UnityScript.Lang.Array();

	[NonSerialized]
	public static UnityScript.Lang.Array myWorldsArr = new UnityScript.Lang.Array();

	[NonSerialized]
	public static UnityScript.Lang.Array myWorldsURL = new UnityScript.Lang.Array();

	private bool showMyWorlds;

	private string chatText;

	private UnityScript.Lang.Array messageArray;

	public GUIStyle chatTextStyle;

	public GUIStyle chatTextStyleAlt;

	private Vector2 scrollPos;

	private Vector2 scrollPos2;

	private bool isChatting;

	public GUIStyle sideBarStyle;

	public GUIStyle buttonStyle;

	[NonSerialized]
	public static bool canChat;

	[NonSerialized]
	public static int myrankStat;

	[NonSerialized]
	public static int mypointsStat;

	[NonSerialized]
	public static bool fetchedRankings;

	public HeadlesssDedServer headless;

	public DisplayTopPlayers()
	{
		scrollPosition = Vector2.zero;
		currentindex = 12;
		curin = 5;
		curin2 = 5;
		curin3 = 12;
		chatText = string.Empty;
		messageArray = new UnityScript.Lang.Array("Welcome to the lobby chat! All messages are copy 'n pasteable for your convenience.");
	}

	public virtual void Awake()
	{
		fetchedRankings = false;
		myrankStat = 0;
		mypointsStat = 0;
	}

	public virtual IEnumerator enableFunction()
	{
		return new _0024enableFunction_00243540(this).GetEnumerator();
	}

	public virtual IEnumerator loadMyWorlds(string u)
	{
		return new _0024loadMyWorlds_00243559(u, this).GetEnumerator();
	}

	public virtual IEnumerator fetchRel()
	{
		return new _0024fetchRel_00243569(this).GetEnumerator();
	}

	public virtual IEnumerator fetchRankings(int start, int stop)
	{
		return new _0024fetchRankings_00243580(start, stop, this).GetEnumerator();
	}

	public virtual IEnumerator fadein()
	{
		return new _0024fadein_00243597(this).GetEnumerator();
	}

	public virtual IEnumerator fadeOut()
	{
		return new _0024fadeOut_00243600(this).GetEnumerator();
	}

	public virtual void OnJoinedRoom()
	{
		canChat = true;
	}

	public virtual void OnCreatedRoom()
	{
		canChat = true;
	}

	public virtual IEnumerator OnPhotonJoinGameFailed()
	{
		return new _0024OnPhotonJoinGameFailed_00243603().GetEnumerator();
	}

	public virtual IEnumerator OnPhotonCreateGameFailed()
	{
		return new _0024OnPhotonCreateGameFailed_00243604().GetEnumerator();
	}

	public virtual void OnGUI()
	{
		if (HeadlesssDedServer.isServerHost || failed)
		{
			return;
		}
		GUI.depth = -5;
		GUI.skin = scrollstyle;
		float a = alpha;
		Color color = GUI.color;
		float num = (color.a = a);
		Color color2 = (GUI.color = color);
		if (GUI.color.a == 0f)
		{
			return;
		}
		GUI.enabled = true;
		GUI.BeginGroup(new Rect(((float)Screen.width + Mathf.Max(0f, Mathf.Max(AdjustCamDistance.sideOffset, AdjustCamDistance.sideOffset2) + 400f)) / 2f - 175f, (Screen.height + 75) / 2 - 215, 350f, 430f));
		GUI.Box(new Rect(0f, 0f, 350f, 430f), (currentTab == 0) ? "Top Ranked Players" : ((currentTab == 1) ? "Top Rated Worlds" : ((currentTab != 2) ? "Lobby Chat" : "Your Worlds")), loginstyle);
		GUI.Label(new Rect(15f, 30f, 310f, 60f), (currentTab == 0) ? "The top ranked players in Carbon Combat based on relative XP. Click on name to view profile." : ((currentTab == 1) ? "User created worlds in Carbon Combat (made in the Creator). Click a world to host, rate, and view." : ((currentTab != 2) ? "Chat with other online players (great for organizing battles and meeting new players.)" : "A list of your worlds exported from the Creator (sorted by most recent).")), textstyle);
		if (currentTab == 0)
		{
			if (isexpanded)
			{
				for (int i = 0; i < 12; i++)
				{
					if (!((float)i / 2f).ToString().Contains("."))
					{
						float a2 = alpha * 0.7f;
						Color color4 = GUI.color;
						float num2 = (color4.a = a2);
						Color color5 = (GUI.color = color4);
						GUI.DrawTexture(new Rect(11f, 75 + i * 25, 328f, 25f), greytex);
					}
					float a3 = alpha;
					Color color7 = GUI.color;
					float num3 = (color7.a = a3);
					Color color8 = (GUI.color = color7);
					if (GUI.Button(new Rect(20f, 75 + i * 25, 310f, 25f), (i >= UnityScript.Lang.Extensions.get_length((System.Array)userarr)) ? "--" : ("#" + (i + 1 + (currentindex - 12)).ToString() + ((i + 1 + (currentindex - 12) <= 999) ? "\t" : "\t\t") + userarr[i + (currentindex - 12)].Split("|"[0])[0]), rankingstyle) && i < UnityScript.Lang.Extensions.get_length((System.Array)userarr))
					{
						Camera.main.SendMessage("fetchProfileData", userarr[i + (currentindex - 12)].Split("|"[0])[0]);
						Camera.main.SendMessage("openProfileTab");
					}
					GUI.Label(new Rect(20f, 75 + i * 25, 310f, 23f), "(" + userarr[i + (currentindex - 12)].Split("|"[0])[1] + " total XP)", rankingstyle2);
				}
			}
			else
			{
				for (int i = 0; i < ((!AuthGameObject.username.Contains("guest_") && myrank > 11) ? 9 : 12); i++)
				{
					if (i == 0 || i == 2 || i == 4 || i == 6 || i == 8 || i == 10 || i == 12)
					{
						float a4 = alpha * 0.7f;
						Color color10 = GUI.color;
						float num4 = (color10.a = a4);
						Color color11 = (GUI.color = color10);
						GUI.DrawTexture(new Rect(11f, 75 + i * 25, 328f, 25f), greytex);
					}
					float a5 = alpha;
					Color color13 = GUI.color;
					float num5 = (color13.a = a5);
					Color color14 = (GUI.color = color13);
					if (GUI.Button(new Rect(20f, 75 + i * 25, 310f, 25f), (i >= UnityScript.Lang.Extensions.get_length((System.Array)userarr)) ? "--" : ("#" + (i + 1).ToString() + ((i + 1 <= 999) ? "\t" : "\t\t") + userarr[i].Split("|"[0])[0]), rankingstyle) && i < UnityScript.Lang.Extensions.get_length((System.Array)userarr))
					{
						Camera.main.SendMessage("fetchProfileData", userarr[i].Split("|"[0])[0]);
						Camera.main.SendMessage("openProfileTab");
					}
					GUI.Label(new Rect(20f, 75 + i * 25, 310f, 23f), "(" + userarr[i].Split("|"[0])[1] + " total XP)", rankingstyle2);
				}
				if (!AuthGameObject.username.Contains("guest_") && myrank > 11)
				{
					for (int i = 0; i < 3; i++)
					{
						if (i == 1 || i == 3)
						{
							float a6 = alpha * 0.7f;
							Color color16 = GUI.color;
							float num6 = (color16.a = a6);
							Color color17 = (GUI.color = color16);
							GUI.DrawTexture(new Rect(11f, 75 + (9 + i) * 25, 328f, 25f), greytex);
						}
						float a7 = alpha;
						Color color19 = GUI.color;
						float num7 = (color19.a = a7);
						Color color20 = (GUI.color = color19);
						if (GUI.Button(new Rect(20f, 75 + (9 + i) * 25, 310f, 25f), (myrank - (1 - i) >= UnityScript.Lang.Extensions.get_length((System.Array)userarr)) ? ("#" + (myrank - (1 - i) + 1).ToString() + "\t--") : ("#" + (myrank - (1 - i) + 1).ToString() + "\t" + userarr[myrank - (1 - i)].Split("|"[0])[0]), rankingstyle) && myrank - (1 - i) < UnityScript.Lang.Extensions.get_length((System.Array)userarr))
						{
							Camera.main.SendMessage("fetchProfileData", userarr[myrank - (1 - i)].Split("|"[0])[0]);
							Camera.main.SendMessage("openProfileTab");
						}
						GUI.Label(new Rect(20f, 75 + (9 + i) * 25, 310f, 23f), (myrank - (1 - i) >= UnityScript.Lang.Extensions.get_length((System.Array)userarr)) ? "--" : ("(" + userarr[myrank - (1 - i)].Split("|"[0])[1] + " total XP)"), rankingstyle2);
					}
				}
			}
			if (isexpanded)
			{
				if (currentindex == 12)
				{
					GUI.enabled = false;
				}
				if (GUI.Button(new Rect(20f, 382f, 100f, 14f), "Last 12", buttonstyle))
				{
					currentindex -= 12;
					StartCoroutine_Auto(fetchRankings(currentindex - 12, currentindex - 1));
				}
				GUI.enabled = true;
				if (currentindex == UnityScript.Lang.Extensions.get_length((System.Array)userarr) || currentindex + 12 > UnityScript.Lang.Extensions.get_length((System.Array)userarr))
				{
					GUI.enabled = false;
				}
				if (GUI.Button(new Rect(230f, 382f, 100f, 14f), "Next 12", buttonstyle))
				{
					currentindex += 12;
					StartCoroutine_Auto(fetchRankings(currentindex - 12, currentindex - 1));
				}
				GUI.enabled = true;
			}
			if (GUI.Button(new Rect(125f, 382f, 100f, 14f), (!isexpanded) ? "Expand List" : "Minimize List", buttonstyle))
			{
				isexpanded = !isexpanded;
			}
			if (GUI.Button(new Rect(265f, 399f, 65f, 18f), "Close", buttonstyle))
			{
				StartCoroutine_Auto(fadeOut());
			}
		}
		else if (currentTab == 1)
		{
			for (int i = 0; i < 5; i++)
			{
				if (!((float)i / 2f).ToString().Contains("."))
				{
					float a8 = alpha * 0.7f;
					Color color22 = GUI.color;
					float num8 = (color22.a = a8);
					Color color23 = (GUI.color = color22);
					GUI.DrawTexture(new Rect(11f, 75 + i * 25, 328f, 25f), greytex);
				}
				float a9 = alpha;
				Color color25 = GUI.color;
				float num9 = (color25.a = a9);
				Color color26 = (GUI.color = color25);
				if (RuntimeServices.ToBool(RuntimeServices.Invoke(typeof(GUI), "Button", new object[3]
				{
					new Rect(20f, 75 + i * 25, 310f, 25f),
					(i >= topWorldsArr.length) ? "--" : RuntimeServices.InvokeBinaryOperator("op_Addition", RuntimeServices.InvokeBinaryOperator("op_Addition", RuntimeServices.InvokeBinaryOperator("op_Addition", RuntimeServices.InvokeBinaryOperator("op_Addition", "#" + (i + 1 + (curin2 - 5)).ToString() + ((i + 1 + (curin2 - 5) <= 999) ? "\t" : "\t\t"), topWorldsArr[i + (curin2 - 5)]), " ("), topWorldsR[i + (curin2 - 5)]), "/5)"),
					rankingstyleButton
				})) && i < topWorldsArr.length)
				{
					GameObject.Find("/WorldWindow").SendMessage("outsideOpenWindow", topWorldsURL[i + (curin2 - 5)]);
				}
			}
			if (curin2 == 5)
			{
				GUI.enabled = false;
			}
			if (GUI.Button(new Rect(20f, 205f, 100f, 14f), "Last 5", buttonstyle))
			{
				curin2 -= 5;
			}
			GUI.enabled = true;
			if (curin2 == topWorldsArr.length || curin2 + 5 > topWorldsArr.length)
			{
				GUI.enabled = false;
			}
			if (GUI.Button(new Rect(230f, 205f, 100f, 14f), "Next 5", buttonstyle))
			{
				curin2 += 5;
			}
			GUI.enabled = true;
			GUI.Label(new Rect(20f, 205f, 310f, 30f), "New Worlds", titleText);
			for (int i = 0; i < 5; i++)
			{
				if (!((float)i / 2f).ToString().Contains("."))
				{
					float a10 = alpha * 0.7f;
					Color color28 = GUI.color;
					float num10 = (color28.a = a10);
					Color color29 = (GUI.color = color28);
					GUI.DrawTexture(new Rect(11f, 75 + i * 25 + 160, 328f, 25f), greytex);
				}
				float a11 = alpha;
				Color color31 = GUI.color;
				float num11 = (color31.a = a11);
				Color color32 = (GUI.color = color31);
				if (RuntimeServices.ToBool(RuntimeServices.Invoke(typeof(GUI), "Button", new object[3]
				{
					new Rect(20f, 75 + i * 25 + 160, 310f, 25f),
					(i >= newWorldsArr.length) ? "--" : RuntimeServices.InvokeBinaryOperator("op_Addition", "#" + (i + 1 + (curin - 5)).ToString() + ((i + 1 + (curin - 5) <= 999) ? "\t" : "\t\t"), newWorldsArr[i + (curin - 5)]),
					rankingstyleButton
				})) && i < newWorldsArr.length)
				{
					GameObject.Find("/WorldWindow").SendMessage("outsideOpenWindow", newWorldsURL[i + (curin - 5)]);
				}
			}
			if (curin == 5)
			{
				GUI.enabled = false;
			}
			if (GUI.Button(new Rect(20f, 367f, 100f, 14f), "Last 5", buttonstyle))
			{
				curin -= 5;
			}
			GUI.enabled = true;
			if (curin == newWorldsArr.length || curin + 5 > newWorldsArr.length)
			{
				GUI.enabled = false;
			}
			if (GUI.Button(new Rect(230f, 367f, 100f, 14f), "Next 5", buttonstyle))
			{
				curin += 5;
			}
		}
		else if (currentTab == 2)
		{
			for (int i = 0; i < 12; i++)
			{
				if (!((float)i / 2f).ToString().Contains("."))
				{
					float a12 = alpha * 0.7f;
					Color color34 = GUI.color;
					float num12 = (color34.a = a12);
					Color color35 = (GUI.color = color34);
					GUI.DrawTexture(new Rect(11f, 75 + i * 25, 328f, 25f), greytex);
				}
				float a13 = alpha;
				Color color37 = GUI.color;
				float num13 = (color37.a = a13);
				Color color38 = (GUI.color = color37);
				if (RuntimeServices.ToBool(RuntimeServices.Invoke(typeof(GUI), "Button", new object[3]
				{
					new Rect(20f, 75 + i * 25, 310f, 25f),
					(i >= myWorldsArr.length) ? "--" : RuntimeServices.InvokeBinaryOperator("op_Addition", "#" + (i + 1 + (curin3 - 12)).ToString() + ((i + 1 + (curin3 - 12) <= 999) ? "\t" : "\t\t"), myWorldsArr[i + (curin3 - 12)]),
					rankingstyleButton
				})) && i < myWorldsArr.length)
				{
					GameObject.Find("/WorldWindow").SendMessage("outsideOpenWindow", myWorldsURL[i + (curin3 - 12)]);
				}
			}
			if (curin3 == 12)
			{
				GUI.enabled = false;
			}
			if (GUI.Button(new Rect(20f, 372f, 100f, 14f), "Last 12", buttonstyle))
			{
				curin3 -= 12;
			}
			GUI.enabled = true;
			if (curin3 == topWorldsArr.length || curin3 + 12 > topWorldsArr.length)
			{
				GUI.enabled = false;
			}
			if (GUI.Button(new Rect(230f, 372f, 100f, 14f), "Next 12", buttonstyle))
			{
				curin3 += 12;
			}
		}
		else if (currentTab == 3)
		{
			GUI.SetNextControlName("field");
			chatText = GUI.TextField(new Rect(15f, 365f, 320f, 20f), chatText, 200);
			if (GUI.GetNameOfFocusedControl() == "field")
			{
				isChatting = true;
			}
			if (Event.current.type == EventType.KeyDown && Event.current.character == '\n' && chatText.Replace(" ", string.Empty) != string.Empty)
			{
				GameObject.Find("/AuthGameObject").SendMessage("gotAch", "Socializing");
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("sendChat", PhotonTargets.All, chatText, AuthGameObject.username);
				chatText = string.Empty;
			}
			GUI.BeginGroup(new Rect(25f, 75f, 330f, 350f));
			scrollPos = GUILayout.BeginScrollView(scrollPos, false, true, GUILayout.Width(305f), GUILayout.Height(275f));
			int num14 = 0;
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
				GUILayout.TextArea(text, (!((float)num14 / 2f).ToString().Contains(".")) ? chatTextStyleAlt : chatTextStyle);
				UnityRuntimeServices.Update(enumerator, text);
				GUILayout.FlexibleSpace();
				GUILayout.EndHorizontal();
				num14++;
			}
			GUILayout.EndScrollView();
			GUI.EndGroup();
			GUI.BeginGroup(new Rect(340f, 0f, 150f, 430f));
			GUI.Box(new Rect(0f, 0f, 150f, 430f), "Players Online", sideBarStyle);
			GUI.BeginGroup(new Rect(5f, -220f, 110f, 710f));
			scrollPos2 = GUILayout.BeginScrollView(scrollPos2, false, true, GUILayout.Width(110f), GUILayout.Height(310f));
			GUILayout.BeginHorizontal();
			GUILayout.FlexibleSpace();
			GUILayout.EndHorizontal();
			int j = 0;
			PhotonPlayer[] playerList = PhotonNetwork.playerList;
			for (int length = playerList.Length; j < length; j++)
			{
				if (!playerList[j].name.Contains("*") && GUILayout.Button(playerList[j].name.Replace("*", string.Empty), buttonStyle))
				{
					setPM(playerList[j].name.Replace("*", string.Empty));
					GUI.FocusControl("field");
				}
			}
			int k = 0;
			PhotonPlayer[] playerList2 = PhotonNetwork.playerList;
			for (int length2 = playerList2.Length; k < length2; k++)
			{
				if (playerList2[k].name.Contains("*"))
				{
					GUI.enabled = false;
					if (GUILayout.Button(playerList2[k].name.Replace("*", string.Empty), buttonStyle))
					{
						setPM(playerList2[k].name.Replace("*", string.Empty));
						GUI.FocusControl("field");
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
				GUI.enabled = false;
				if (!GUILayout.Button(text2, buttonStyle))
				{
				}
			}
			GUILayout.EndScrollView();
			GUI.EndGroup();
			GUI.EndGroup();
		}
		GUI.EndGroup();
	}

	public virtual void setPM(string n)
	{
		chatText = " |" + n;
	}

	[RPC]
	public virtual IEnumerator sendChat(string message, string user, PhotonMessageInfo info)
	{
		return new _0024sendChat_00243605(message, user, info, this).GetEnumerator();
	}

	public virtual void Main()
	{
	}
}
