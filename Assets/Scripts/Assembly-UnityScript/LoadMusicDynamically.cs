using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class LoadMusicDynamically : MonoBehaviour
{
	[Serializable]
	internal sealed class _0024Start_00244043 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal LoadMusicDynamically _0024self__00244044;

			public _0024(LoadMusicDynamically self_)
			{
				_0024self__00244044 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					result = (Yield(2, new WaitForSeconds(0.5f)) ? 1 : 0);
					break;
				case 2:
					if (Application.absoluteURL.Contains("Conduit.unity3d"))
					{
						_0024self__00244044.StartCoroutine_Auto(_0024self__00244044.fadeOut2());
						_0024self__00244044.StartCoroutine_Auto(_0024self__00244044.fadein());
					}
					else
					{
						_0024self__00244044.StartCoroutine_Auto(_0024self__00244044.fadein2());
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

		internal LoadMusicDynamically _0024self__00244045;

		public _0024Start_00244043(LoadMusicDynamically self_)
		{
			_0024self__00244045 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00244045);
		}
	}

	[Serializable]
	internal sealed class _0024fadein2_00244046 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (alpha2 < 1f)
					{
						alpha2 += 4f * Time.deltaTime;
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					alpha2 = 1f;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024();
		}
	}

	[Serializable]
	internal sealed class _0024fadeOut2_00244047 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (alpha2 > 0f)
					{
						alpha2 -= 4f * Time.deltaTime;
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					alpha2 = 0f;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024();
		}
	}

	[Serializable]
	internal sealed class _0024fadein_00244048 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (alpha < 1f)
					{
						alpha += 4f * Time.deltaTime;
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					alpha = 1f;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024();
		}
	}

	[Serializable]
	internal sealed class _0024fadeOut_00244049 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (alpha > 0f)
					{
						alpha -= 4f * Time.deltaTime;
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					alpha = 0f;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024();
		}
	}

	[Serializable]
	internal sealed class _0024loadMusic_00244050 : GenericGenerator<WWW>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WWW>, IEnumerator
		{
			internal LoadMusicDynamically _0024self__00244051;

			public _0024(LoadMusicDynamically self_)
			{
				_0024self__00244051 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					audioArray = new AudioClip[5];
					isloading = true;
					_0024self__00244051.www = new WWW(_0024self__00244051.menumusic);
					result = (Yield(2, _0024self__00244051.www) ? 1 : 0);
					break;
				case 2:
					audioArray[0] = _0024self__00244051.www.audioClip;
					_0024self__00244051.www2 = new WWW(_0024self__00244051.mainmusic);
					result = (Yield(3, _0024self__00244051.www2) ? 1 : 0);
					break;
				case 3:
					audioArray[1] = _0024self__00244051.www2.audioClip;
					_0024self__00244051.www3 = new WWW(_0024self__00244051.underwater);
					result = (Yield(4, _0024self__00244051.www3) ? 1 : 0);
					break;
				case 4:
					audioArray[2] = _0024self__00244051.www3.audioClip;
					_0024self__00244051.www4 = new WWW(_0024self__00244051.rainfx);
					result = (Yield(5, _0024self__00244051.www4) ? 1 : 0);
					break;
				case 5:
					audioArray[3] = _0024self__00244051.www4.audioClip;
					_0024self__00244051.www5 = new WWW(_0024self__00244051.waterfall);
					result = (Yield(6, _0024self__00244051.www5) ? 1 : 0);
					break;
				case 6:
					audioArray[4] = _0024self__00244051.www5.audioClip;
					isloading = false;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal LoadMusicDynamically _0024self__00244052;

		public _0024loadMusic_00244050(LoadMusicDynamically self_)
		{
			_0024self__00244052 = self_;
		}

		public override IEnumerator<WWW> GetEnumerator()
		{
			return new _0024(_0024self__00244052);
		}
	}

	private string menumusic;

	private string mainmusic;

	private string underwater;

	private string rainfx;

	private string waterfall;

	[NonSerialized]
	public static bool isloading = true;

	[NonSerialized]
	public static bool gotconfirm;

	private WWW www;

	private WWW www2;

	private WWW www3;

	private WWW www4;

	private WWW www5;

	[NonSerialized]
	public static int perDone;

	public GUIStyle buttonstyle;

	public GUIStyle buttonstyle2;

	public GUIStyle backgroundstyle;

	public GUIStyle labelstyle;

	[NonSerialized]
	public static AudioClip[] audioArray;

	[NonSerialized]
	public static float alpha;

	[NonSerialized]
	public static float alpha2;

	public LoadMusicDynamically()
	{
		menumusic = "http://ge.tt/api/1/files/7i8kc5U/5/blob?download&f=.ogg";
		mainmusic = "http://ge.tt/api/1/files/7i8kc5U/2/blob?download&f=.ogg";
		underwater = "http://ge.tt/api/1/files/7i8kc5U/3/blob?download&f=.ogg";
		rainfx = "http://ge.tt/api/1/files/7i8kc5U/1/blob?download&f=.ogg";
		waterfall = "http://ge.tt/api/1/files/7i8kc5U/4/blob?download&f=.ogg";
	}

	public virtual IEnumerator Start()
	{
		return new _0024Start_00244043(this).GetEnumerator();
	}

	public virtual IEnumerator fadein2()
	{
		return new _0024fadein2_00244046().GetEnumerator();
	}

	public virtual IEnumerator fadeOut2()
	{
		return new _0024fadeOut2_00244047().GetEnumerator();
	}

	public virtual IEnumerator fadein()
	{
		return new _0024fadein_00244048().GetEnumerator();
	}

	public virtual IEnumerator fadeOut()
	{
		return new _0024fadeOut_00244049().GetEnumerator();
	}

	public virtual IEnumerator loadMusic()
	{
		return new _0024loadMusic_00244050(this).GetEnumerator();
	}

	public virtual void Update()
	{
		if (isloading && gotconfirm)
		{
			if (www5 != null)
			{
				perDone = (int)Mathf.Round((www.progress + www2.progress + www3.progress + www4.progress + www5.progress) / 5f * 100f);
			}
			else if (www4 != null)
			{
				perDone = (int)Mathf.Round((www.progress + www2.progress + www3.progress + www4.progress) / 5f * 100f);
			}
			else if (www3 != null)
			{
				perDone = (int)Mathf.Round((www.progress + www2.progress + www3.progress) / 5f * 100f);
			}
			else if (www2 != null)
			{
				perDone = (int)Mathf.Round((www.progress + www2.progress) / 5f * 100f);
			}
			else if (www != null)
			{
				perDone = (int)Mathf.Round(www.progress / 5f * 100f);
			}
		}
	}

	public virtual void OnGUI()
	{
		float a = alpha;
		Color color = GUI.color;
		float num = (color.a = a);
		Color color2 = (GUI.color = color);
		if (!(alpha <= 0f))
		{
			GUI.BeginGroup(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 75, 300f, 150f));
			GUI.Box(new Rect(0f, 0f, 300f, 150f), "Load Game Music?", backgroundstyle);
			GUI.Label(new Rect(20f, 0f, 260f, 150f), "This allows you to play your own music in the background and load the game faster!", labelstyle);
			if (GUI.Button(new Rect(20f, 75f, 260f, 25f), "Sure, I can wait a bit!", buttonstyle))
			{
				StartCoroutine_Auto(loadMusic());
				StartCoroutine_Auto(fadeOut());
				gotconfirm = true;
			}
			if (GUI.Button(new Rect(20f, 105f, 260f, 25f), "No thanks; I'll pass", buttonstyle2))
			{
				isloading = false;
				StartCoroutine_Auto(fadeOut());
			}
			GUI.EndGroup();
		}
		float a2 = alpha2;
		Color color4 = GUI.color;
		float num2 = (color4.a = a2);
		Color color5 = (GUI.color = color4);
		if (!(alpha2 <= 0f))
		{
			GUI.BeginGroup(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 75, 300f, 150f));
			GUI.Box(new Rect(0f, 0f, 300f, 150f), "Fullscreen?", backgroundstyle);
			GUI.Label(new Rect(20f, 0f, 260f, 150f), "Fullscreen = less lag = awesomeness\n(cmd/ctrl + f)", labelstyle);
			if (GUI.Button(new Rect(20f, 75f, 260f, 25f), "Yes, put me in fullscreen now!", buttonstyle))
			{
				GameObject.Find("/ScreenResSwitch").SendMessage("goFullScreen");
				StartCoroutine_Auto(fadeOut2());
				StartCoroutine_Auto(fadein());
			}
			if (GUI.Button(new Rect(20f, 105f, 260f, 25f), "No thanks; I'll pass", buttonstyle2))
			{
				StartCoroutine_Auto(fadeOut2());
				StartCoroutine_Auto(fadein());
			}
			GUI.EndGroup();
		}
	}

	public virtual void Main()
	{
	}
}
