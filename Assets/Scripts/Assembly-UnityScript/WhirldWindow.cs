using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class WhirldWindow : MonoBehaviour
{
	[Serializable]
	internal sealed class _0024fadein_00245809 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal WhirldWindow _0024self__00245810;

			public _0024(WhirldWindow self_)
			{
				_0024self__00245810 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__00245810.alpha < 1f)
					{
						_0024self__00245810.alpha += 4f * Time.deltaTime;
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024self__00245810.alpha = 1f;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal WhirldWindow _0024self__00245811;

		public _0024fadein_00245809(WhirldWindow self_)
		{
			_0024self__00245811 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00245811);
		}
	}

	[Serializable]
	internal sealed class _0024fadeOut_00245812 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string[] _0024tempstr_00245813;

			internal WhirldWindow _0024self__00245814;

			public _0024(WhirldWindow self_)
			{
				_0024self__00245814 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__00245814.toggleImg)
					{
						AuthGameObject.whirldurl = _0024self__00245814.wurl;
						AuthGameObject.whirldname = "Custom World";
						AuthGameObject.whirldmmurl = "none";
					}
					else
					{
						_0024tempstr_00245813 = worldarr[_0024self__00245814.listEntry].Replace(" | ", "|").Split("|"[0]);
						AuthGameObject.whirldurl = _0024tempstr_00245813[1];
						AuthGameObject.whirldname = _0024tempstr_00245813[0];
						object obj = _0024self__00245814.mmarr[_0024self__00245814.listEntry];
						if (!(obj is string))
						{
							obj = RuntimeServices.Coerce(obj, typeof(string));
						}
						AuthGameObject.whirldmmurl = (string)obj;
					}
					goto case 2;
				case 2:
					if (_0024self__00245814.alpha > 0f)
					{
						_0024self__00245814.alpha -= 4f * Time.deltaTime;
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024self__00245814.alpha = 0f;
					_0024self__00245814.gameObject.active = false;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal WhirldWindow _0024self__00245815;

		public _0024fadeOut_00245812(WhirldWindow self_)
		{
			_0024self__00245815 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00245815);
		}
	}

	private bool showList;

	private int listEntry;

	private GUIContent[] list;

	public GUIStyle listStyle;

	public GUIStyle buttonStyle;

	public GUIStyle boxStyle;

	public GUIStyle labelStyle;

	public GUIStyle descStyle;

	public GUIStyle checkboxstyle;

	public GUIStyle buttonstyle;

	private bool toggleImg;

	public GUIStyle bkround;

	private string wurl;

	public WhirldIn wsrc;

	public AuthGameObject authobj;

	public GameObject gameoptions;

	[NonSerialized]
	public static string[] worldarr;

	private UnityScript.Lang.Array mmarr;

	private bool failed2load;

	private float alpha;

	public WhirldWindow()
	{
		wurl = string.Empty;
		mmarr = new UnityScript.Lang.Array();
	}

	public virtual void Start()
	{
		gameObject.active = false;
	}

	public virtual IEnumerator fadein()
	{
		return new _0024fadein_00245809(this).GetEnumerator();
	}

	public virtual IEnumerator fadeOut()
	{
		return new _0024fadeOut_00245812(this).GetEnumerator();
	}

	public virtual void OnGUI()
	{
		GUI.depth = 0;
		float a = alpha;
		Color color = GUI.color;
		float num = (color.a = a);
		Color color2 = (GUI.color = color);
		if (alpha <= 0f)
		{
			return;
		}
		GUI.BeginGroup(new Rect(Screen.width / 2 - 175, Screen.height / 2 - 110, 350f, 400f));
		string text = list[listEntry].text;
		GUI.Box(new Rect(0f, 0f, 350f, 220f), "Custom Worlds", bkround);
		GUI.Label(new Rect(25f, 25f, 310f, 60f), "User created worlds using the Whirld system developed by Aubrey Falconer.", labelStyle);
		GUI.Label(new Rect(45f, 60f, 310f, 60f), "Approved Worlds:", descStyle);
		toggleImg = GUI.Toggle(new Rect(285f, 110f, 20f, 20f), toggleImg, "Load world from URL (.whirld or .utw file):", checkboxstyle);
		if (toggleImg)
		{
			if (wurl == " " || wurl == string.Empty)
			{
				GUI.enabled = false;
			}
			else if (failed2load)
			{
				GUI.enabled = false;
			}
			else
			{
				GUI.enabled = true;
			}
		}
		if (GUI.Button(new Rect(230f, 170f, 90f, 25f), "Start Server", buttonstyle))
		{
			gameoptions.active = true;
			gameoptions.SendMessage("fadein");
			StartCoroutine_Auto(fadeOut());
		}
		GUI.enabled = true;
		if (GUI.Button(new Rect(130f, 170f, 90f, 25f), "Close", buttonstyle))
		{
			StartCoroutine_Auto(fadeOut());
		}
		GUI.enabled = toggleImg;
		wurl = GUI.TextField(new Rect(50f, 135f, 250f, 20f), wurl);
		GUI.enabled = true;
		if (Popup.List(new Rect(160f, 80f, 150f, 20f), ref showList, ref listEntry, new GUIContent(text), list, buttonStyle, boxStyle, listStyle))
		{
		}
		GUI.EndGroup();
	}

	public virtual void Main()
	{
	}
}
