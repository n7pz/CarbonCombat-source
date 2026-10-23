using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class GameOptions : MonoBehaviour
{
	[Serializable]
	internal sealed class _0024Start_00243919 : GenericGenerator<WWW>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WWW>, IEnumerator
		{
			internal WWW _0024getlist_00243920;

			internal int _0024trycount_00243921;

			internal int _0024counter_00243922;

			internal string _0024txt_00243923;

			internal string[] _0024temptxt_00243924;

			internal int _0024_0024540_00243925;

			internal string[] _0024_0024541_00243926;

			internal int _0024_0024542_00243927;

			internal GameOptions _0024self__00243928;

			public _0024(GameOptions self_)
			{
				_0024self__00243928 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					AuthGameObject.whirldurl = string.Empty;
					AuthGameObject.whirldname = string.Empty;
					AuthGameObject.whirldmmurl = string.Empty;
					_0024getlist_00243920 = new WWW("http://dl.dropbox.com/u/4704910/WhirldList.txt");
					result = (Yield(2, _0024getlist_00243920) ? 1 : 0);
					break;
				case 2:
					_0024trycount_00243921 = 0;
					goto IL_0097;
				case 3:
					_0024trycount_00243921++;
					goto IL_0097;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0097:
					if (_0024getlist_00243920.error != null && _0024trycount_00243921 < 3)
					{
						_0024getlist_00243920 = new WWW("http://dl.dropbox.com/u/4704910/WhirldList.txt");
						result = (Yield(3, _0024getlist_00243920) ? 1 : 0);
						break;
					}
					if (!_0024getlist_00243920.text.Contains("<"))
					{
						worldarr = _0024getlist_00243920.text.Split("\n"[0]);
						_0024self__00243928.list9 = new GUIContent[UnityScript.Lang.Extensions.get_length((System.Array)worldarr)];
						_0024counter_00243922 = 0;
						_0024_0024540_00243925 = 0;
						_0024_0024541_00243926 = worldarr;
						for (_0024_0024542_00243927 = _0024_0024541_00243926.Length; _0024_0024540_00243925 < _0024_0024542_00243927; _0024_0024540_00243925++)
						{
							_0024self__00243928.list9[_0024counter_00243922] = new GUIContent(_0024_0024541_00243926[_0024_0024540_00243925].Substring(0, _0024_0024541_00243926[_0024_0024540_00243925].IndexOf(" | ")));
							_0024temptxt_00243924 = _0024_0024541_00243926[_0024_0024540_00243925].Replace(" | ", "|").Split("|"[0]);
							_0024self__00243928.mmarr.Add(_0024temptxt_00243924[2]);
							_0024counter_00243922++;
						}
					}
					else
					{
						_0024self__00243928.list = new GUIContent[1];
						_0024self__00243928.list[0] = new GUIContent("Failed to Load");
						_0024self__00243928.failed2load = true;
					}
					_0024self__00243928.StartCoroutine_Auto(_0024self__00243928.fadein());
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal GameOptions _0024self__00243929;

		public _0024Start_00243919(GameOptions self_)
		{
			_0024self__00243929 = self_;
		}

		public override IEnumerator<WWW> GetEnumerator()
		{
			return new _0024(_0024self__00243929);
		}
	}

	[Serializable]
	internal sealed class _0024fadein_00243930 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal GameOptions _0024self__00243931;

			public _0024(GameOptions self_)
			{
				_0024self__00243931 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00243931.setuplist();
					goto case 2;
				case 2:
					if (_0024self__00243931.alpha < 1f)
					{
						_0024self__00243931.alpha += 4f * Time.deltaTime;
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024self__00243931.alpha = 1f;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal GameOptions _0024self__00243932;

		public _0024fadein_00243930(GameOptions self_)
		{
			_0024self__00243932 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00243932);
		}
	}

	[Serializable]
	internal sealed class _0024fadeOut_00243933 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal GameOptions _0024self__00243934;

			public _0024(GameOptions self_)
			{
				_0024self__00243934 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__00243934.alpha > 0f)
					{
						_0024self__00243934.alpha -= 4f * Time.deltaTime;
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024self__00243934.alpha = 0f;
					_0024self__00243934.gameObject.active = false;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal GameOptions _0024self__00243935;

		public _0024fadeOut_00243933(GameOptions self_)
		{
			_0024self__00243935 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00243935);
		}
	}

	public GUIStyle windowstyle;

	public GUIStyle labelstyle;

	public GUIStyle checkboxstyle;

	public GUIStyle buttonskin;

	public AuthGameObject authgameobj;

	public GameObject authobj;

	private bool showList;

	private int listEntry;

	private GUIContent[] list;

	private bool showList2;

	private int listEntry2;

	private GUIContent[] list2;

	private bool showList3;

	private int listEntry3;

	private GUIContent[] list3;

	public MasterServerScript mserver;

	public GameObject masterserver;

	public GUIStyle listStyle;

	public GUIStyle buttonStyle;

	public GUIStyle boxStyle;

	public GameObject worldoptions;

	private float alpha;

	private bool toggleImg1;

	[NonSerialized]
	public static string[] worldarr;

	private UnityScript.Lang.Array mmarr;

	private bool failed2load;

	private string wurl;

	private bool showList9;

	private int listEntry9;

	private GUIContent[] list9;

	public GUIStyle listStyle9;

	public GameOptions()
	{
		mmarr = new UnityScript.Lang.Array();
		wurl = string.Empty;
	}

	public virtual IEnumerator Start()
	{
		return new _0024Start_00243919(this).GetEnumerator();
	}

	public virtual void setuplist()
	{
		if (MasterServerScript.gamenamestring.Contains("Battle Island"))
		{
			list = new GUIContent[2];
			list[0] = new GUIContent("Team Death-Match");
			list[1] = new GUIContent("Capture the Flag");
		}
		else
		{
			list = new GUIContent[1];
			list[0] = new GUIContent("Team Death-Match");
			listEntry = 0;
		}
		if (MasterServerScript.gamenamestring.Contains("Battle Island"))
		{
			list2 = new GUIContent[3];
			list2[0] = new GUIContent("6 players");
			list2[1] = new GUIContent("8 players");
			list2[2] = new GUIContent("10 players");
		}
		if (MasterServerScript.gamenamestring.Contains("Abandoned Silos"))
		{
			list2 = new GUIContent[2];
			list2[0] = new GUIContent("2 players");
			list2[1] = new GUIContent("4 players");
			listEntry2 = 0;
		}
		if (MasterServerScript.gamenamestring.Contains("Unity Island"))
		{
			list2 = new GUIContent[3];
			list2[0] = new GUIContent("4 players");
			list2[1] = new GUIContent("6 players");
			list2[2] = new GUIContent("8 players");
		}
		if (MasterServerScript.gamenamestring.Contains("Chokepoint"))
		{
			list2 = new GUIContent[3];
			list2[0] = new GUIContent("4 players");
			list2[1] = new GUIContent("6 players");
			list2[2] = new GUIContent("8 players");
		}
		if (AuthGameObject.whirldurl != string.Empty)
		{
			list2 = new GUIContent[3];
			list2[0] = new GUIContent("4 players");
			list2[1] = new GUIContent("6 players");
			list2[2] = new GUIContent("8 players");
		}
		list3 = new GUIContent[3];
		list3[0] = new GUIContent("10 minutes");
		list3[1] = new GUIContent("15 minutes");
		list3[2] = new GUIContent("20 minutes");
		RectOffset padding = listStyle.padding;
		RectOffset padding2 = listStyle.padding;
		RectOffset padding3 = listStyle.padding;
		int num = (listStyle.padding.bottom = 4);
		int num3 = (padding3.top = num);
		int left = (padding2.right = num3);
		padding.left = left;
	}

	public virtual IEnumerator fadein()
	{
		return new _0024fadein_00243930(this).GetEnumerator();
	}

	public virtual IEnumerator fadeOut()
	{
		return new _0024fadeOut_00243933(this).GetEnumerator();
	}

	public virtual void OnGUI()
	{
		GUI.depth = 0;
		float a = alpha;
		Color color = GUI.color;
		float num = (color.a = a);
		Color color2 = (GUI.color = color);
		string text = "Team Death-Match";
		string text2 = null;
		string text3 = "5 minutes";
		string text4 = null;
		if (MasterServerScript.gamenamestring.Contains("Battle Island"))
		{
			text2 = "6 players";
			text4 = "6 players";
		}
		if (MasterServerScript.gamenamestring.Contains("Abandoned Silos"))
		{
			text2 = "2 players";
			text4 = "2 players";
		}
		if (MasterServerScript.gamenamestring.Contains("Unity Island"))
		{
			text2 = "4 players";
			text4 = "4 players";
		}
		if (MasterServerScript.gamenamestring.Contains("Chokepoint"))
		{
			text2 = "4 players";
			text4 = "4 players";
		}
		if (AuthGameObject.whirldurl != string.Empty)
		{
			text2 = "4 players";
			text4 = "4 players";
		}
		if (list[listEntry].text != "Team Death-Match")
		{
			text = list[listEntry].text;
		}
		if (list2[listEntry2].text != text4)
		{
			text2 = list2[listEntry2].text;
		}
		if (list3[listEntry3].text != "5 minutes")
		{
			text3 = list3[listEntry3].text;
		}
		GUI.BeginGroup(new Rect(Screen.width / 2 - 175, Screen.height / 2 - 110, 350f, 250f));
		GUI.SetNextControlName("dropdown2");
		GUI.Box(new Rect(0f, 0f, 350f, 220f), "Game Options", windowstyle);
		if (GUI.Button(new Rect(230f, 170f, 90f, 25f), "Start Server", buttonskin))
		{
			authobj.SendMessage("Gametype", text);
			authobj.SendMessage("Maxplayers", text2);
			authobj.SendMessage("Timelimit", text3);
			masterserver.SendMessage("remotestartserver");
			if (AuthGameObject.whirldurl != string.Empty)
			{
				GameObject.Find("WhirldIn").SendMessage("Load", AuthGameObject.whirldurl);
			}
			StartCoroutine_Auto(fadeOut());
		}
		if (GUI.Button(new Rect(30f, 170f, 90f, 25f), "Close", buttonskin))
		{
			authobj.SendMessage("Gametype", text);
			authobj.SendMessage("Maxplayers", text2);
			authobj.SendMessage("Timelimit", text3);
			StartCoroutine_Auto(fadeOut());
		}
		if (MasterServerScript.curworld == 5)
		{
			GUI.enabled = false;
		}
		else
		{
			GUI.enabled = true;
		}
		if (GUI.Button(new Rect(130f, 170f, 90f, 25f), "World Options", buttonskin))
		{
			worldoptions.active = true;
			worldoptions.SendMessage("fadein");
			StartCoroutine_Auto(fadeOut());
		}
		GUI.enabled = true;
		GUI.Label(new Rect(25f, 25f, 300f, 60f), "You can change the game type, maximum players, and the time limit for the server you are about to host.", labelstyle);
		GUI.Label(new Rect(56f, 130f, 85f, 20f), "Time Limit:", labelstyle);
		if (Popup.List(new Rect(150f, 131f, 150f, 20f), ref showList3, ref listEntry3, new GUIContent(text3), list3, buttonStyle, boxStyle, listStyle))
		{
		}
		GUI.Label(new Rect(51f, 105f, 85f, 20f), "Max Players:", labelstyle);
		if (Popup.List(new Rect(150f, 106f, 150f, 20f), ref showList2, ref listEntry2, new GUIContent(text2), list2, buttonStyle, boxStyle, listStyle))
		{
		}
		GUI.Label(new Rect(60f, 80f, 70f, 20f), "Game Type:", labelstyle);
		if (Popup.List(new Rect(150f, 81f, 150f, 20f), ref showList, ref listEntry, new GUIContent(text), list, buttonStyle, boxStyle, listStyle))
		{
		}
		GUI.EndGroup();
	}

	public virtual void Main()
	{
	}
}
