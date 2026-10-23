using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class WorldWindow : MonoBehaviour
{
	[Serializable]
	internal sealed class _0024setuplist_00244979 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string _0024curselect2_00244980;

			internal string _0024nondefault_00244981;

			internal string _0024curselect3_00244982;

			internal WorldWindow _0024self__00244983;

			public _0024(WorldWindow self_)
			{
				_0024self__00244983 = self_;
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
				{
					if (_0024self__00244983.tog[0] || _0024self__00244983.tog[1] || _0024self__00244983.tog[3])
					{
						_0024self__00244983.list0 = new GUIContent[5];
						_0024self__00244983.list0[0] = new GUIContent("Team Death-Match");
						_0024self__00244983.list0[1] = new GUIContent("Deathmatch");
						_0024self__00244983.list0[2] = new GUIContent("Capture the Flag");
						_0024self__00244983.list0[3] = new GUIContent("Freeplay");
						_0024self__00244983.list0[4] = new GUIContent("Survival");
					}
					else
					{
						_0024self__00244983.list0 = new GUIContent[3];
						_0024self__00244983.list0[0] = new GUIContent("Team Death-Match");
						_0024self__00244983.list0[1] = new GUIContent("Deathmatch");
						_0024self__00244983.list0[2] = new GUIContent("Freeplay");
					}
					_0024self__00244983.list2 = new GUIContent[5];
					_0024self__00244983.list2[0] = new GUIContent("1 player");
					_0024self__00244983.list2[1] = new GUIContent("2 players");
					_0024self__00244983.list2[2] = new GUIContent("8 players");
					_0024self__00244983.list2[3] = new GUIContent("16 players");
					_0024self__00244983.list2[4] = new GUIContent("20 players");
					if (MasterServerScript.gamenamestring.Contains("Battle Island"))
					{
						_0024self__00244983.list2 = new GUIContent[6];
						_0024self__00244983.list2[0] = new GUIContent("1 player");
						_0024self__00244983.list2[1] = new GUIContent("2 players");
						_0024self__00244983.list2[2] = new GUIContent("8 players");
						_0024self__00244983.list2[3] = new GUIContent("16 players");
						_0024self__00244983.list2[4] = new GUIContent("20 players");
						_0024self__00244983.list2[5] = new GUIContent("24 players");
					}
					if (MasterServerScript.gamenamestring.Contains("Abandoned Silos"))
					{
						_0024self__00244983.list2 = new GUIContent[3];
						_0024self__00244983.list2[0] = new GUIContent("1 player");
						_0024self__00244983.list2[1] = new GUIContent("2 players");
						_0024self__00244983.list2[2] = new GUIContent("4 players");
					}
					if (MasterServerScript.gamenamestring.Contains("Unity Island"))
					{
						_0024self__00244983.list2 = new GUIContent[5];
						_0024self__00244983.list2[0] = new GUIContent("1 player");
						_0024self__00244983.list2[1] = new GUIContent("2 players");
						_0024self__00244983.list2[2] = new GUIContent("8 players");
						_0024self__00244983.list2[3] = new GUIContent("16 players");
						_0024self__00244983.list2[4] = new GUIContent("20 players");
					}
					if (MasterServerScript.gamenamestring.Contains("Chokepoint") || MasterServerScript.gamenamestring.Contains("Sanctum"))
					{
						_0024self__00244983.list2 = new GUIContent[5];
						_0024self__00244983.list2[0] = new GUIContent("1 player");
						_0024self__00244983.list2[1] = new GUIContent("2 players");
						_0024self__00244983.list2[2] = new GUIContent("8 players");
						_0024self__00244983.list2[3] = new GUIContent("16 players");
						_0024self__00244983.list2[4] = new GUIContent("20 players");
					}
					_0024self__00244983.list3 = new GUIContent[4];
					_0024self__00244983.list3[0] = new GUIContent("5 minutes");
					_0024self__00244983.list3[1] = new GUIContent("10 minutes");
					_0024self__00244983.list3[2] = new GUIContent("15 minutes");
					_0024self__00244983.list3[3] = new GUIContent("20 minutes");
					RectOffset padding = _0024self__00244983.listStyle1.padding;
					RectOffset padding2 = _0024self__00244983.listStyle1.padding;
					RectOffset padding3 = _0024self__00244983.listStyle1.padding;
					int num = (_0024self__00244983.listStyle1.padding.bottom = 4);
					int num3 = (padding3.top = num);
					int left = (padding2.right = num3);
					padding.left = left;
					_0024self__00244983.listEntry0 = UnityEngine.Random.Range(0, UnityScript.Lang.Extensions.get_length((System.Array)_0024self__00244983.list0));
					_0024self__00244983.listEntry2 = UnityScript.Lang.Extensions.get_length((System.Array)_0024self__00244983.list2) - 1;
					_0024curselect2_00244980 = _0024self__00244983.list2[UnityScript.Lang.Extensions.get_length((System.Array)_0024self__00244983.list2) - 1].text;
					_0024nondefault_00244981 = _0024self__00244983.list2[UnityScript.Lang.Extensions.get_length((System.Array)_0024self__00244983.list2) - 1].text;
					_0024self__00244983.listEntry3 = 1;
					_0024curselect3_00244982 = _0024self__00244983.list2[1].text;
					_0024nondefault_00244981 = _0024self__00244983.list2[1].text;
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

		internal WorldWindow _0024self__00244984;

		public _0024setuplist_00244979(WorldWindow self_)
		{
			_0024self__00244984 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00244984);
		}
	}

	[Serializable]
	internal sealed class _0024fadein_00244985 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal WorldWindow _0024self__00244986;

			public _0024(WorldWindow self_)
			{
				_0024self__00244986 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (MasterServerScript.curworld == 0)
					{
						_0024self__00244986.tog[0] = true;
						_0024self__00244986.tog[1] = false;
						_0024self__00244986.tog[2] = false;
						_0024self__00244986.tog[3] = false;
						_0024self__00244986.tog[4] = false;
						_0024self__00244986.tog[5] = false;
					}
					if (MasterServerScript.curworld == 1)
					{
						_0024self__00244986.tog[0] = false;
						_0024self__00244986.tog[1] = true;
						_0024self__00244986.tog[2] = false;
						_0024self__00244986.tog[3] = false;
						_0024self__00244986.tog[4] = false;
						_0024self__00244986.tog[5] = false;
					}
					if (MasterServerScript.curworld == 2)
					{
						_0024self__00244986.tog[0] = false;
						_0024self__00244986.tog[1] = false;
						_0024self__00244986.tog[2] = true;
						_0024self__00244986.tog[3] = false;
						_0024self__00244986.tog[4] = false;
						_0024self__00244986.tog[5] = false;
					}
					if (MasterServerScript.curworld == 3)
					{
						_0024self__00244986.tog[0] = false;
						_0024self__00244986.tog[1] = false;
						_0024self__00244986.tog[2] = false;
						_0024self__00244986.tog[3] = true;
						_0024self__00244986.tog[4] = false;
						_0024self__00244986.tog[5] = false;
					}
					if (MasterServerScript.curworld == 4)
					{
						_0024self__00244986.tog[0] = false;
						_0024self__00244986.tog[1] = false;
						_0024self__00244986.tog[2] = false;
						_0024self__00244986.tog[3] = false;
						_0024self__00244986.tog[4] = false;
						_0024self__00244986.tog[5] = true;
					}
					if (MasterServerScript.curworld == 5)
					{
						_0024self__00244986.tog[0] = false;
						_0024self__00244986.tog[1] = false;
						_0024self__00244986.tog[2] = false;
						_0024self__00244986.tog[3] = false;
						_0024self__00244986.tog[4] = true;
						_0024self__00244986.tog[5] = false;
					}
					_0024self__00244986.StartCoroutine_Auto(_0024self__00244986.setuplist());
					goto case 2;
				case 2:
					if (_0024self__00244986.alpha < 1f)
					{
						_0024self__00244986.alpha += 2f * Time.deltaTime;
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024self__00244986.alpha = 1f;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal WorldWindow _0024self__00244987;

		public _0024fadein_00244985(WorldWindow self_)
		{
			_0024self__00244987 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00244987);
		}
	}

	[Serializable]
	internal sealed class _0024fadeOut_00244988 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string[] _0024tempstr_00244989;

			internal WorldWindow _0024self__00244990;

			public _0024(WorldWindow self_)
			{
				_0024self__00244990 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__00244990.alpha > 0f)
					{
						_0024self__00244990.alpha -= 4f * Time.deltaTime;
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					if (MasterServerScript.curworld == 5 && !_0024self__00244990.toggleImg2)
					{
						if (_0024self__00244990.toggleImg1)
						{
							AuthGameObject.whirldurl = _0024self__00244990.wurl;
							AuthGameObject.whirldname = "Custom World";
							AuthGameObject.whirldmmurl = "none";
						}
						else
						{
							_0024tempstr_00244989 = worldarr[_0024self__00244990.listEntry9].Replace(" | ", "|").Split("|"[0]);
							AuthGameObject.whirldurl = _0024tempstr_00244989[1];
							AuthGameObject.whirldname = _0024tempstr_00244989[0];
							object obj = _0024self__00244990.mmarr[_0024self__00244990.listEntry9];
							if (!(obj is string))
							{
								obj = RuntimeServices.Coerce(obj, typeof(string));
							}
							AuthGameObject.whirldmmurl = (string)obj;
						}
					}
					if (AuthGameObject.whirldurl != string.Empty)
					{
						GameObject.Find("WhirldIn").SendMessage("Load", AuthGameObject.whirldurl);
					}
					_0024self__00244990.alpha = 0f;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal WorldWindow _0024self__00244991;

		public _0024fadeOut_00244988(WorldWindow self_)
		{
			_0024self__00244991 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00244991);
		}
	}

	[Serializable]
	internal sealed class _0024outsideOpenWindow_00244992 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string _0024curselect2_00244993;

			internal string _0024nondefault_00244994;

			internal string _0024u_00244995;

			internal WorldWindow _0024self__00244996;

			public _0024(string u, WorldWindow self_)
			{
				_0024u_00244995 = u;
				_0024self__00244996 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					GameObject.Find("/LoginWindow/MasterServer").SendMessage("fadeOutJoinMode");
					MasterServerScript.curworld = 5;
					_0024self__00244996.StartCoroutine_Auto(_0024self__00244996.setuplist());
					Camera.main.SendMessage("goToServerList");
					_0024self__00244996.tog[0] = false;
					_0024self__00244996.tog[1] = false;
					_0024self__00244996.tog[2] = false;
					_0024self__00244996.tog[3] = false;
					_0024self__00244996.tog[4] = true;
					_0024self__00244996.toggleImg2 = true;
					_0024self__00244996.toggleImg1 = false;
					_0024self__00244996.wurl2 = "http://72.14.184.180/Worlds/" + _0024u_00244995;
					_0024curselect2_00244993 = "16 players";
					_0024nondefault_00244994 = "16 players";
					_0024self__00244996.listEntry2 = 1;
					goto case 2;
				case 2:
					if (_0024self__00244996.alpha < 1f)
					{
						_0024self__00244996.alpha += 2f * Time.deltaTime;
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024self__00244996.alpha = 1f;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal string _0024u_00244997;

		internal WorldWindow _0024self__00244998;

		public _0024outsideOpenWindow_00244992(string u, WorldWindow self_)
		{
			_0024u_00244997 = u;
			_0024self__00244998 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024u_00244997, _0024self__00244998);
		}
	}

	[Serializable]
	internal sealed class _0024startLoadingCWF_00244999 : GenericGenerator<WWW>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WWW>, IEnumerator
		{
			internal WWW _0024www_00245000;

			internal string[] _0024chunks_00245001;

			internal string _0024s_00245002;

			internal WorldWindow _0024self__00245003;

			public _0024(string s, WorldWindow self_)
			{
				_0024s_00245002 = s;
				_0024self__00245003 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024www_00245000 = new WWW(_0024s_00245002);
					result = (Yield(2, _0024www_00245000) ? 1 : 0);
					break;
				case 2:
					if (string.IsNullOrEmpty(_0024www_00245000.error) && _0024www_00245000.text != string.Empty)
					{
						CWFLoader.worldData = _0024www_00245000.text;
						CWFLoader.worldURL = _0024s_00245002;
						_0024chunks_00245001 = _0024www_00245000.text.Split("$"[0]);
						MasterServerScript.gamenamestring = WWW.UnEscapeURL(_0024chunks_00245001[0].Split("*"[0])[0]).Replace("[Get]", string.Empty);
						_0024self__00245003.masterserver.SendMessage("remotestartserver");
						_0024self__00245003.StartCoroutine_Auto(_0024self__00245003.fadeOut());
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

		internal string _0024s_00245004;

		internal WorldWindow _0024self__00245005;

		public _0024startLoadingCWF_00244999(string s, WorldWindow self_)
		{
			_0024s_00245004 = s;
			_0024self__00245005 = self_;
		}

		public override IEnumerator<WWW> GetEnumerator()
		{
			return new _0024(_0024s_00245004, _0024self__00245005);
		}
	}

	public GUIStyle windowstyle;

	public GUIStyle labelstyle;

	public GUIStyle checkboxstyle;

	public GUIStyle buttonskin;

	public GUIStyle previewstyle;

	public GameObject authgameobj;

	public GameObject masterserverscript;

	private int sindex;

	private UnityScript.Lang.Array descarray;

	private string worldtext;

	private string lastgamename;

	public MasterServerScript mserver;

	public AuthGameObject authobj;

	public CWFLoader cwfloader;

	private bool showList0;

	private int listEntry0;

	private GUIContent[] list0;

	private bool showList2;

	private int listEntry2;

	private GUIContent[] list2;

	private bool showList3;

	private int listEntry3;

	private GUIContent[] list3;

	public GameObject masterserver;

	public GUIStyle listStyle1;

	public GUIStyle buttonStyle1;

	public GUIStyle boxStyle1;

	public GUIStyle labelStyle1;

	public GUIStyle buttonStyle2;

	[NonSerialized]
	public static bool isdoneloading;

	private bool showList;

	private int listEntry;

	private GUIContent[] list;

	public GUIStyle listStyle;

	public GUIStyle buttonStyle;

	public GUIStyle boxStyle;

	public GUIStyle largebuttonskin;

	private Texture texturetodisplay;

	public Texture[] islandpics;

	public Texture[] silopics;

	public Texture[] unitypics;

	public Texture[] chokepics;

	public Texture[] sanctumpics;

	public GameObject gameoptions;

	public string[] worlds;

	public MasterServerScript mscript;

	private float alpha;

	public Color greycolor;

	private bool toggleImg;

	public Texture greybackground;

	public bool[] tog;

	[NonSerialized]
	public static float statalpha;

	private bool toggleImg1;

	private bool toggleImg2;

	[NonSerialized]
	public static string[] worldarr;

	private UnityScript.Lang.Array mmarr;

	[NonSerialized]
	public static bool failed2load;

	private string wurl;

	private string wurl2;

	private bool showList9;

	private int listEntry9;

	private GUIContent[] list9;

	public GUIStyle listStyle9;

	private bool ff;

	private bool fpsenabled;

	private bool cDam;

	public GUISkin scrollstyle;

	public WorldWindow()
	{
		descarray = new UnityScript.Lang.Array("A large island with a crashed space cruiser, abandoned bases, and a waterfall.", "An abandoned military base with several missile silos and bunkers.", "A tropical paradise filled with lush vegetation and craggy mountains.", "Two bases interconnected by a network of bridges and pathways.", "A remote island outpost serving as a junction for oil pipes.");
		worldtext = "Aubrey's Freestyle | http://map.syn3h.com/Freestyle/Whirld.utw | http://i.minus.com/ibmPkT3XmolSHh.png\nSeb's Sky King | http://map.syn3h.com/SebsSkyKing/Whirld.utw | http://i.minus.com/iDLCvLsgIOjSr.png\nGTR's Desert | http://map.syn3h.com/GTRsDesert/Whirld.utw | http://i.minus.com/irlsEazNNL8Tn.png\nDude's Sctish Highlands | http://map.syn3h.com/DudesScottishHighlands/Whirld.utw | http://i.minus.com/ibeUJcP6puGEbH.png\nFai's Sunken Wastes | http://map.syn3h.com/FaisSunkenWastes/Whirld.utw | http://i.minus.com/ibdbBtHhcOoQBn.png\nDude's Olympus Mons | http://map.syn3h.com/DudesOlympusMons/Whirld.utw | http://i.minus.com/ibezebG47HixrY.png\nEric's CTF | http://papawheely.com/EricsCTF/Whirld.utw | http://i.minus.com/iJ1h0KITcoIna.png";
		mmarr = new UnityScript.Lang.Array();
		wurl = string.Empty;
		wurl2 = string.Empty;
		ff = true;
		fpsenabled = true;
		cDam = true;
	}

	public virtual void Awake()
	{
		statalpha = 0f;
		isdoneloading = false;
		failed2load = false;
		CWFLoader.worldData = string.Empty;
		CWFLoader.worldURL = string.Empty;
	}

	public virtual void Start()
	{
		list = new GUIContent[4];
		list[0] = new GUIContent("Sunny");
		list[1] = new GUIContent("Overcast");
		list[2] = new GUIContent("Sunset");
		list[3] = new GUIContent("Night");
		RectOffset padding = listStyle.padding;
		RectOffset padding2 = listStyle.padding;
		RectOffset padding3 = listStyle.padding;
		int num = (listStyle.padding.bottom = 4);
		int num3 = (padding3.top = num);
		int left = (padding2.right = num3);
		padding.left = left;
		listEntry = UnityEngine.Random.Range(0, 4);
		if (listEntry == 1 || listEntry == 3)
		{
			if (UnityEngine.Random.Range(0, 2) == 0)
			{
				masterserverscript.SendMessage("setworldname", " (" + list[listEntry].text + ")");
			}
			else
			{
				masterserverscript.SendMessage("setworldname", " (" + list[listEntry].text + ")" + "[rainy]");
				toggleImg = true;
			}
		}
		else
		{
			masterserverscript.SendMessage("setworldname", " (" + list[listEntry].text + ")");
		}
		string text = list[listEntry].text;
		if (text == "Sunny")
		{
			sindex = 0;
		}
		if (text == "Sunset")
		{
			sindex = 3;
		}
		if (text == "Overcast")
		{
			if (!toggleImg)
			{
				sindex = 1;
			}
			else
			{
				sindex = 2;
			}
		}
		if (text == "Night")
		{
			if (!toggleImg)
			{
				sindex = 4;
			}
			else
			{
				sindex = 5;
			}
		}
		authgameobj.SendMessage("setskybox", sindex);
		AuthGameObject.whirldurl = string.Empty;
		AuthGameObject.whirldname = string.Empty;
		AuthGameObject.whirldmmurl = string.Empty;
		worldarr = worldtext.Split("\n"[0]);
		list9 = new GUIContent[UnityScript.Lang.Extensions.get_length((System.Array)worldarr)];
		int num6 = 0;
		int i = 0;
		string[] array = worldarr;
		for (int length = array.Length; i < length; i++)
		{
			list9[num6] = new GUIContent(array[i].Substring(0, array[i].IndexOf(" | ")));
			string[] array2 = array[i].Replace(" | ", "|").Split("|"[0]);
			mmarr.Add(array2[2]);
			num6++;
		}
		isdoneloading = true;
	}

	public virtual IEnumerator setuplist()
	{
		return new _0024setuplist_00244979(this).GetEnumerator();
	}

	public virtual IEnumerator fadein()
	{
		return new _0024fadein_00244985(this).GetEnumerator();
	}

	public virtual IEnumerator fadeOut()
	{
		return new _0024fadeOut_00244988(this).GetEnumerator();
	}

	public virtual void Update()
	{
		statalpha = alpha;
		if (list9[listEntry9].text == "Eric's CTF" && UnityScript.Lang.Extensions.get_length((System.Array)list0) != 4)
		{
			list0 = new GUIContent[4];
			list0[0] = new GUIContent("Team Death-Match");
			list0[1] = new GUIContent("Deathmatch");
			list0[2] = new GUIContent("Capture the Flag");
			list0[3] = new GUIContent("Freeplay");
		}
	}

	public virtual void OnGUI()
	{
		GUI.skin = scrollstyle;
		GUI.depth = 2;
		float a = alpha;
		Color color = GUI.color;
		float num = (color.a = a);
		Color color2 = (GUI.color = color);
		if (GUI.color.a == 0f)
		{
			return;
		}
		GUI.BeginGroup(new Rect(Screen.width / 2 - 335, Screen.height / 2 - 150, 670f, 500f));
		string text = "Team Death-Match";
		string text2 = null;
		string text3 = "5 minutes";
		string text4 = null;
		if (list0 != null && listEntry0 > UnityScript.Lang.Extensions.get_length((System.Array)list0) - 1)
		{
			listEntry0 = UnityScript.Lang.Extensions.get_length((System.Array)list0) - 1;
		}
		if (alpha != 0f && !RuntimeServices.EqualityOperator(list0, null))
		{
			if (list0[listEntry0].text != "Team Death-Match")
			{
				text = list0[listEntry0].text;
			}
			if (list2[listEntry2].text != text4)
			{
				text2 = list2[listEntry2].text;
			}
			if (list3[listEntry3].text != "5 minutes")
			{
				text3 = list3[listEntry3].text;
			}
		}
		string text5 = "Sunny";
		if (list[listEntry].text != "Sunny")
		{
			text5 = list[listEntry].text;
		}
		if (MasterServerScript.curworld == 0)
		{
			if (text5 == "Sunny")
			{
				texturetodisplay = islandpics[0];
				sindex = 0;
			}
			if (text5 == "Sunset")
			{
				texturetodisplay = islandpics[2];
				sindex = 3;
			}
			if (text5 == "Overcast")
			{
				if (!toggleImg)
				{
					texturetodisplay = islandpics[1];
					sindex = 1;
				}
				else
				{
					texturetodisplay = islandpics[4];
					sindex = 2;
				}
			}
			if (text5 == "Night")
			{
				if (!toggleImg)
				{
					texturetodisplay = islandpics[3];
					sindex = 4;
				}
				else
				{
					texturetodisplay = islandpics[5];
					sindex = 5;
				}
			}
		}
		if (MasterServerScript.curworld == 1)
		{
			if (text5 == "Sunny")
			{
				texturetodisplay = silopics[0];
				sindex = 0;
			}
			if (text5 == "Sunset")
			{
				texturetodisplay = silopics[3];
				sindex = 3;
			}
			if (text5 == "Overcast")
			{
				if (!toggleImg)
				{
					texturetodisplay = silopics[1];
					sindex = 1;
				}
				else
				{
					texturetodisplay = silopics[2];
					sindex = 2;
				}
			}
			if (text5 == "Night")
			{
				if (!toggleImg)
				{
					texturetodisplay = silopics[4];
					sindex = 4;
				}
				else
				{
					texturetodisplay = silopics[5];
					sindex = 5;
				}
			}
		}
		if (MasterServerScript.curworld == 2)
		{
			if (text5 == "Sunny")
			{
				texturetodisplay = unitypics[0];
				sindex = 0;
			}
			if (text5 == "Sunset")
			{
				texturetodisplay = unitypics[3];
				sindex = 3;
			}
			if (text5 == "Overcast")
			{
				if (!toggleImg)
				{
					texturetodisplay = unitypics[1];
					sindex = 1;
				}
				else
				{
					texturetodisplay = unitypics[2];
					sindex = 2;
				}
			}
			if (text5 == "Night")
			{
				if (!toggleImg)
				{
					texturetodisplay = unitypics[4];
					sindex = 4;
				}
				else
				{
					texturetodisplay = unitypics[5];
					sindex = 5;
				}
			}
		}
		if (MasterServerScript.curworld == 3)
		{
			if (text5 == "Sunny")
			{
				texturetodisplay = chokepics[0];
				sindex = 0;
			}
			if (text5 == "Sunset")
			{
				texturetodisplay = chokepics[3];
				sindex = 3;
			}
			if (text5 == "Overcast")
			{
				if (!toggleImg)
				{
					texturetodisplay = chokepics[1];
					sindex = 1;
				}
				else
				{
					texturetodisplay = chokepics[2];
					sindex = 2;
				}
			}
			if (text5 == "Night")
			{
				if (!toggleImg)
				{
					texturetodisplay = chokepics[4];
					sindex = 4;
				}
				else
				{
					texturetodisplay = chokepics[5];
					sindex = 5;
				}
			}
		}
		if (MasterServerScript.curworld == 4)
		{
			if (text5 == "Sunny")
			{
				texturetodisplay = sanctumpics[0];
				sindex = 0;
			}
			if (text5 == "Sunset")
			{
				texturetodisplay = sanctumpics[3];
				sindex = 3;
			}
			if (text5 == "Overcast")
			{
				if (!toggleImg)
				{
					texturetodisplay = sanctumpics[1];
					sindex = 1;
				}
				else
				{
					texturetodisplay = sanctumpics[2];
					sindex = 2;
				}
			}
			if (text5 == "Night")
			{
				if (!toggleImg)
				{
					texturetodisplay = sanctumpics[4];
					sindex = 4;
				}
				else
				{
					texturetodisplay = sanctumpics[5];
					sindex = 5;
				}
			}
		}
		GUI.SetNextControlName("dropdown");
		GUI.Box(new Rect(0f, 0f, 670f, 300f), "Server Settings", windowstyle);
		if (!(Application.GetStreamProgressForLevel("NuclearSilo") >= 1f) && MasterServerScript.curworld == 1)
		{
			GUI.enabled = false;
		}
		else if (!(Application.GetStreamProgressForLevel("NewIsland") >= 1f) && MasterServerScript.curworld == 2)
		{
			GUI.enabled = false;
		}
		else
		{
			GUI.enabled = true;
		}
		UnityScript.Lang.Array array = new UnityScript.Lang.Array("Abandoned Silos", "Unity Island", "Battle Island", "Sanctum");
		object obj;
		if (Application.CanStreamedLevelBeLoaded("MainScene"))
		{
			GUI.enabled = true;
			obj = array[2];
		}
		else
		{
			GUI.enabled = false;
			obj = RuntimeServices.InvokeBinaryOperator("op_Addition", RuntimeServices.InvokeBinaryOperator("op_Addition", RuntimeServices.InvokeBinaryOperator("op_Addition", array[2], " ("), Mathf.Round(Application.GetStreamProgressForLevel("MainScene") * 100f)), "%)");
		}
		tog[0] = RuntimeServices.UnboxBoolean(UnityRuntimeServices.Invoke(typeof(GUI), "Toggle", new object[4]
		{
			new Rect(15f, 45f, 195f, 30f),
			tog[0],
			obj,
			largebuttonskin
		}, typeof(MonoBehaviour)));
		if (tog[0] && alpha == 1f)
		{
			tog[1] = false;
			tog[2] = false;
			tog[3] = false;
			tog[4] = false;
			tog[5] = false;
			if (MasterServerScript.curworld != 0)
			{
				MasterServerScript.curworld = 0;
				StartCoroutine_Auto(setuplist());
			}
		}
		else if (!tog[1] && !tog[2] && !tog[3] && !tog[4] && !tog[5])
		{
			tog[0] = true;
		}
		if (Application.CanStreamedLevelBeLoaded("NuclearSilo"))
		{
			GUI.enabled = true;
			obj = array[0];
		}
		else
		{
			GUI.enabled = false;
			obj = RuntimeServices.InvokeBinaryOperator("op_Addition", RuntimeServices.InvokeBinaryOperator("op_Addition", RuntimeServices.InvokeBinaryOperator("op_Addition", array[0], " ("), Mathf.Round(Application.GetStreamProgressForLevel("NuclearSilo") * 100f)), "%)");
		}
		tog[1] = RuntimeServices.UnboxBoolean(UnityRuntimeServices.Invoke(typeof(GUI), "Toggle", new object[4]
		{
			new Rect(15f, 77f, 195f, 30f),
			tog[1],
			obj,
			largebuttonskin
		}, typeof(MonoBehaviour)));
		if (tog[1] && alpha == 1f)
		{
			tog[0] = false;
			tog[2] = false;
			tog[3] = false;
			tog[4] = false;
			tog[5] = false;
			if (MasterServerScript.curworld != 1)
			{
				StartCoroutine_Auto(setuplist());
				MasterServerScript.curworld = 1;
			}
		}
		else if (!tog[0] && !tog[2] && !tog[3] && !tog[4] && !tog[5])
		{
			tog[1] = true;
		}
		if (Application.CanStreamedLevelBeLoaded("NewIsland"))
		{
			GUI.enabled = true;
			obj = array[1];
		}
		else
		{
			GUI.enabled = false;
			obj = RuntimeServices.InvokeBinaryOperator("op_Addition", RuntimeServices.InvokeBinaryOperator("op_Addition", RuntimeServices.InvokeBinaryOperator("op_Addition", array[1], " ("), Mathf.Round(Application.GetStreamProgressForLevel("NewIsland") * 100f)), "%)");
		}
		tog[2] = RuntimeServices.UnboxBoolean(UnityRuntimeServices.Invoke(typeof(GUI), "Toggle", new object[4]
		{
			new Rect(15f, 109f, 195f, 30f),
			tog[2],
			obj,
			largebuttonskin
		}, typeof(MonoBehaviour)));
		if (tog[2] && alpha == 1f)
		{
			tog[0] = false;
			tog[1] = false;
			tog[3] = false;
			tog[4] = false;
			tog[5] = false;
			if (MasterServerScript.curworld != 2)
			{
				MasterServerScript.curworld = 2;
				StartCoroutine_Auto(setuplist());
			}
		}
		else if (!tog[0] && !tog[1] && !tog[3] && !tog[4] && !tog[5])
		{
			tog[2] = true;
		}
		GUI.enabled = true;
		tog[3] = GUI.Toggle(new Rect(15f, 141f, 195f, 30f), tog[3], "Chokepoint", largebuttonskin);
		if (tog[3] && alpha == 1f)
		{
			tog[0] = false;
			tog[1] = false;
			tog[2] = false;
			tog[4] = false;
			tog[5] = false;
			if (MasterServerScript.curworld != 3)
			{
				MasterServerScript.curworld = 3;
				StartCoroutine_Auto(setuplist());
			}
		}
		else if (!tog[0] && !tog[1] && !tog[2] && !tog[4] && !tog[5])
		{
			tog[3] = true;
		}
		GUI.enabled = true;
		if (Application.CanStreamedLevelBeLoaded("Sanctum"))
		{
			GUI.enabled = true;
			obj = array[3];
		}
		else
		{
			GUI.enabled = false;
			obj = RuntimeServices.InvokeBinaryOperator("op_Addition", RuntimeServices.InvokeBinaryOperator("op_Addition", RuntimeServices.InvokeBinaryOperator("op_Addition", array[3], " ("), Mathf.Round(Application.GetStreamProgressForLevel("Sanctum") * 100f)), "%)");
		}
		tog[5] = RuntimeServices.UnboxBoolean(UnityRuntimeServices.Invoke(typeof(GUI), "Toggle", new object[4]
		{
			new Rect(15f, 173f, 195f, 30f),
			tog[5],
			obj,
			largebuttonskin
		}, typeof(MonoBehaviour)));
		if (tog[5] && alpha == 1f)
		{
			tog[0] = false;
			tog[1] = false;
			tog[2] = false;
			tog[3] = false;
			tog[4] = false;
			if (MasterServerScript.curworld != 4)
			{
				MasterServerScript.curworld = 4;
				StartCoroutine_Auto(setuplist());
			}
		}
		else if (!tog[0] && !tog[1] && !tog[2] && !tog[3] && !tog[4])
		{
			tog[5] = true;
		}
		GUI.enabled = true;
		tog[4] = GUI.Toggle(new Rect(15f, 205f, 195f, 30f), tog[4], "More Maps", largebuttonskin);
		if (tog[4] && alpha == 1f)
		{
			tog[0] = false;
			tog[1] = false;
			tog[2] = false;
			tog[3] = false;
			tog[5] = false;
			if (MasterServerScript.curworld != 5)
			{
				MasterServerScript.curworld = 5;
				StartCoroutine_Auto(setuplist());
				text2 = "4 players";
				text4 = "4 players";
				listEntry2 = 1;
			}
		}
		else if (!tog[0] && !tog[1] && !tog[2] && !tog[3] && !tog[5])
		{
			tog[4] = true;
		}
		GUI.enabled = true;
		if (!(Application.GetStreamProgressForLevel("Forge") >= 1f))
		{
			GUI.enabled = false;
		}
		if (GUI.Button(new Rect(15f, 248f, 195f, 30f), (Application.GetStreamProgressForLevel("Forge") >= 1f) ? "Creator (Map Maker)" : ("Creator (" + Mathf.Round(Application.GetStreamProgressForLevel("Forge") * 100f).ToString() + "%)"), largebuttonskin))
		{
			Application.LoadLevel("Forge");
		}
		GUI.enabled = true;
		GUI.DrawTexture(new Rect(233f, 55f, 2f, 215f), greybackground);
		GUI.DrawTexture(new Rect(435f, 55f, 2f, 215f), greybackground);
		if (toggleImg1 && MasterServerScript.curworld == 5)
		{
			if (wurl == " " || wurl == string.Empty)
			{
				GUI.enabled = false;
			}
			else
			{
				GUI.enabled = true;
			}
		}
		if (toggleImg2)
		{
			if ((!wurl2.Contains("#") || !wurl2.Contains("$") || !wurl2.Contains("*")) && !wurl2.Contains("http://"))
			{
				GUI.enabled = false;
			}
			else
			{
				GUI.enabled = true;
			}
		}
		if (Event.current.type == EventType.KeyDown && Event.current.character == '\n')
		{
			authgameobj.SendMessage("setskybox", sindex);
			if (sindex == 2 || sindex == 5)
			{
				masterserverscript.SendMessage("setworldname", " (" + text5 + ")" + "[rainy]");
			}
			else
			{
				masterserverscript.SendMessage("setworldname", " (" + text5 + ")");
			}
			AuthGameObject.cDam = cDam;
			authgameobj.SendMessage("FF", ff);
			authgameobj.SendMessage("FPSen", fpsenabled);
			authgameobj.SendMessage("Gametype", text);
			authgameobj.SendMessage("Maxplayers", text2);
			authgameobj.SendMessage("Timelimit", text3);
			if (toggleImg2)
			{
				if (!wurl2.Contains("http://"))
				{
					CWFLoader.worldData = wurl2;
					string[] array2 = wurl2.Split("$"[0]);
					MasterServerScript.gamenamestring = WWW.UnEscapeURL(array2[0].Split("*"[0])[0]).Replace("[Get]", string.Empty);
					masterserver.SendMessage("remotestartserver");
					StartCoroutine_Auto(fadeOut());
				}
				else
				{
					StartCoroutine_Auto(startLoadingCWF(wurl2));
				}
			}
			else
			{
				masterserver.SendMessage("remotestartserver");
				StartCoroutine_Auto(fadeOut());
			}
		}
		if (GUI.Button(new Rect(555f, 255f, 90f, 25f), "Start Server", buttonskin))
		{
			authgameobj.SendMessage("setskybox", sindex);
			if (sindex == 2 || sindex == 5)
			{
				masterserverscript.SendMessage("setworldname", " (" + text5 + ")" + "[rainy]");
			}
			else
			{
				masterserverscript.SendMessage("setworldname", " (" + text5 + ")");
			}
			AuthGameObject.cDam = cDam;
			authgameobj.SendMessage("FF", ff);
			authgameobj.SendMessage("FPSen", fpsenabled);
			authgameobj.SendMessage("Gametype", text);
			authgameobj.SendMessage("Maxplayers", text2);
			authgameobj.SendMessage("Timelimit", text3);
			if (toggleImg2)
			{
				if (!wurl2.Contains("http://"))
				{
					CWFLoader.worldData = wurl2;
					string[] array2 = wurl2.Split("$"[0]);
					MasterServerScript.gamenamestring = WWW.UnEscapeURL(array2[0].Split("*"[0])[0]).Replace("[Get]", string.Empty);
					masterserver.SendMessage("remotestartserver");
					StartCoroutine_Auto(fadeOut());
				}
				else
				{
					StartCoroutine_Auto(startLoadingCWF(wurl2));
				}
			}
			else
			{
				masterserver.SendMessage("remotestartserver");
				StartCoroutine_Auto(fadeOut());
			}
		}
		GUI.enabled = true;
		if (GUI.Button(new Rect(460f, 255f, 90f, 25f), "Close", buttonskin))
		{
			if (MasterServerScript.curworld != 5)
			{
				if (sindex == 2 || sindex == 5)
				{
					masterserverscript.SendMessage("setworldname", " (" + text5 + ")" + "[rainy]");
				}
				else
				{
					masterserverscript.SendMessage("setworldname", " (" + text5 + ")");
				}
				authgameobj.SendMessage("setskybox", sindex);
			}
			authgameobj.SendMessage("Gametype", text);
			authgameobj.SendMessage("Maxplayers", text2);
			authgameobj.SendMessage("Timelimit", text3);
			StartCoroutine_Auto(fadeOut());
		}
		GUI.enabled = true;
		ff = GUI.Toggle(new Rect(538f, 200f, 20f, 20f), ff, "Friendly Fire: ", checkboxstyle);
		GUI.enabled = true;
		fpsenabled = GUI.Toggle(new Rect(630f, 200f, 20f, 20f), fpsenabled, "Allow FPS: ", checkboxstyle);
		if (text == "Survival")
		{
			GUI.enabled = false;
			if (cDam)
			{
				cDam = false;
			}
		}
		else
		{
			GUI.enabled = true;
		}
		cDam = GUI.Toggle(new Rect(630f, 225f, 20f, 20f), cDam, "Collision Damage: ", checkboxstyle);
		GUI.enabled = true;
		if (MasterServerScript.curworld != 5)
		{
			GUI.color = greycolor;
			float a2 = alpha;
			Color color4 = GUI.color;
			float num2 = (color4.a = a2);
			Color color5 = (GUI.color = color4);
			UnityRuntimeServices.Invoke(typeof(GUI), "Label", new object[3]
			{
				new Rect(260f, 200f, 150f, 60f),
				descarray[MasterServerScript.curworld],
				labelstyle
			}, typeof(MonoBehaviour));
			GUI.color = Color.white;
			float a3 = alpha;
			Color color7 = GUI.color;
			float num3 = (color7.a = a3);
			Color color8 = (GUI.color = color7);
			if ((bool)texturetodisplay)
			{
				GUI.DrawTexture(new Rect(258f, 63f, 154f, 84f), greybackground);
				GUI.DrawTexture(new Rect(260f, 65f, 150f, 80f), texturetodisplay);
			}
			if (text5 == "Overcast" || text5 == "Night")
			{
				GUI.enabled = true;
			}
			else
			{
				GUI.enabled = false;
			}
			toggleImg = GUI.Toggle(new Rect(305f, 177f, 20f, 20f), toggleImg, "Raining: ", checkboxstyle);
			GUI.enabled = true;
			GUI.Label(new Rect(256f, 154f, 50f, 20f), "Setting: ", labelstyle);
			if (Popup.List(new Rect(311f, 155f, 100f, 20f), ref showList, ref listEntry, new GUIContent(text5), list, buttonStyle, boxStyle, listStyle))
			{
			}
			GUI.enabled = true;
			toggleImg1 = false;
			toggleImg2 = false;
		}
		else
		{
			GUI.color = greycolor;
			float a4 = alpha;
			Color color10 = GUI.color;
			float num4 = (color10.a = a4);
			Color color11 = (GUI.color = color10);
			GUI.color = Color.white;
			float a5 = alpha;
			Color color13 = GUI.color;
			float num5 = (color13.a = a5);
			Color color14 = (GUI.color = color13);
			if (list9 != null)
			{
				string text6 = list9[listEntry9].text;
				GUI.Label(new Rect(255f, 60f, 95f, 20f), "Approved Maps", labelstyle);
				GUI.enabled = !toggleImg2;
				toggleImg1 = GUI.Toggle(new Rect(397f, 125f, 20f, 20f), toggleImg1, "Load custom map from \nURL (.whirld or .utw file):", checkboxstyle);
				GUI.enabled = !toggleImg1;
				toggleImg2 = GUI.Toggle(new Rect(397f, 200f, 20f, 20f), toggleImg2, "Load custom map from \nURL or .cwf data:", checkboxstyle);
				GUI.enabled = !toggleImg2 && toggleImg1;
				wurl = GUI.TextField(new Rect(258f, 155f, 155f, 20f), wurl);
				GUI.enabled = !toggleImg1 && toggleImg2;
				wurl2 = GUI.TextField(new Rect(258f, 230f, 155f, 20f), wurl2);
				GUI.enabled = true;
				GUI.enabled = ((!toggleImg1 && !toggleImg2) ? true : false);
				if (!Popup.List(new Rect(260f, 81f, 150f, 20f), ref showList9, ref listEntry9, new GUIContent(text6), list9, buttonStyle2, boxStyle, listStyle))
				{
				}
			}
			GUI.enabled = true;
		}
		if (text == "Freeplay")
		{
			GUI.enabled = false;
		}
		GUI.Label(new Rect(459f, 150f, 85f, 20f), "Time Limit", labelStyle1);
		if (Popup.List(new Rect(460f, 171f, 180f, 20f), ref showList3, ref listEntry3, new GUIContent(text3), list3, buttonStyle1, boxStyle1, listStyle1))
		{
		}
		GUI.enabled = true;
		GUI.Label(new Rect(459f, 95f, 85f, 20f), "Max Players", labelStyle1);
		if (Popup.List(new Rect(460f, 117f, 180f, 20f), ref showList2, ref listEntry2, new GUIContent(text2), list2, buttonStyle1, boxStyle1, listStyle1))
		{
		}
		if (MasterServerScript.curworld == 5 && list9[listEntry9].text != "Eric's CTF")
		{
			list0 = new GUIContent[3];
			list0[0] = new GUIContent("Team Death-Match");
			list0[1] = new GUIContent("Deathmatch");
			list0[2] = new GUIContent("Freeplay");
		}
		GUI.Label(new Rect(459f, 40f, 70f, 20f), "Game Type", labelStyle1);
		if (Popup.List(new Rect(460f, 61f, 180f, 20f), ref showList0, ref listEntry0, new GUIContent(text), list0, buttonStyle1, boxStyle1, listStyle1))
		{
		}
		GUI.EndGroup();
	}

	public virtual IEnumerator outsideOpenWindow(string u)
	{
		return new _0024outsideOpenWindow_00244992(u, this).GetEnumerator();
	}

	public virtual IEnumerator startLoadingCWF(string s)
	{
		return new _0024startLoadingCWF_00244999(s, this).GetEnumerator();
	}

	public virtual void Main()
	{
	}
}
