using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class WorldLoadingBar : MonoBehaviour
{
	[Serializable]
	internal sealed class _0024startloading_00244970 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal WorldLoadingBar _0024self__00244971;

			public _0024(WorldLoadingBar self_)
			{
				_0024self__00244971 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00244971.StartCoroutine_Auto(_0024self__00244971.fadein());
					result = (Yield(2, new WaitForSeconds(1.5f)) ? 1 : 0);
					break;
				case 2:
					_0024self__00244971.StartCoroutine_Auto(_0024self__00244971.fadeOut());
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal WorldLoadingBar _0024self__00244972;

		public _0024startloading_00244970(WorldLoadingBar self_)
		{
			_0024self__00244972 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00244972);
		}
	}

	[Serializable]
	internal sealed class _0024fadein_00244973 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal WorldLoadingBar _0024self__00244974;

			public _0024(WorldLoadingBar self_)
			{
				_0024self__00244974 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__00244974.alpha < 1f)
					{
						_0024self__00244974.alpha += 2f * Time.deltaTime;
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024self__00244974.alpha = 1f;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal WorldLoadingBar _0024self__00244975;

		public _0024fadein_00244973(WorldLoadingBar self_)
		{
			_0024self__00244975 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00244975);
		}
	}

	[Serializable]
	internal sealed class _0024fadeOut_00244976 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal WorldLoadingBar _0024self__00244977;

			public _0024(WorldLoadingBar self_)
			{
				_0024self__00244977 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__00244977.alpha > 0f)
					{
						_0024self__00244977.alpha -= 4f * Time.deltaTime;
						result = (YieldDefault(2) ? 1 : 0);
					}
					else
					{
						_0024self__00244977.alpha = 0f;
						result = (Yield(3, new WaitForSeconds(0.35f)) ? 1 : 0);
					}
					break;
				case 3:
				case 4:
					if (_0024self__00244977.alpha2 < 1f)
					{
						_0024self__00244977.alpha2 += 2f * Time.deltaTime;
						result = (YieldDefault(4) ? 1 : 0);
						break;
					}
					_0024self__00244977.alpha2 = 1f;
					_0024self__00244977.levelloader.SendMessage("LoadLevel");
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal WorldLoadingBar _0024self__00244978;

		public _0024fadeOut_00244976(WorldLoadingBar self_)
		{
			_0024self__00244978 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00244978);
		}
	}

	public GUIStyle backgroundimage;

	public GUIStyle barimage;

	public GUIStyle underbarimage;

	private float barwidth;

	private float loadper;

	public GameObject levelloader;

	private float alpha;

	private bool onceonly;

	public Texture fadeouttex;

	public float alpha2;

	public AuthGameObject authobj;

	public WhirldIn win;

	public MasterServerScript mserver;

	private float loadperLerp;

	public WorldLoadingBar()
	{
		barwidth = 250f;
	}

	public virtual void Awake()
	{
		enabled = false;
	}

	public virtual void OnGUI()
	{
		GUI.depth = 0;
		float a = alpha;
		Color color = GUI.color;
		float num = (color.a = a);
		Color color2 = (GUI.color = color);
		GUI.BeginGroup(new Rect(Screen.width / 2 - 144, Screen.height / 2 - 38, 288f, 76f));
		int levelIndex = default(int);
		if (MasterServerScript.curworld == 0)
		{
			levelIndex = 5;
		}
		if (MasterServerScript.curworld == 1)
		{
			levelIndex = 6;
		}
		if (MasterServerScript.curworld == 2)
		{
			levelIndex = 7;
		}
		if (MasterServerScript.curworld == 3)
		{
			levelIndex = 3;
		}
		if (MasterServerScript.curworld == 4)
		{
			levelIndex = 8;
		}
		if (MasterServerScript.curworld == 5)
		{
			levelIndex = 4;
		}
		if (AuthGameObject.whirldurl == string.Empty)
		{
			loadper = Application.GetStreamProgressForLevel(levelIndex);
		}
		else
		{
			loadper = WhirldIn.progress;
		}
		barwidth = 250f * Mathf.Lerp(loadperLerp, loadper, 1.5f * Time.deltaTime);
		loadperLerp = Mathf.Lerp(loadperLerp, loadper, 1.5f * Time.deltaTime);
		loadper *= 100f;
		if (Application.CanStreamedLevelBeLoaded(levelIndex) && !onceonly && loadper == 100f)
		{
			onceonly = true;
			StartCoroutine_Auto(startloading());
		}
		string text = "Loading Map - " + loadper + "%";
		GUI.Box(new Rect(0f, 0f, 288f, 76f), text, backgroundimage);
		GUI.Box(new Rect(18.5f, 35f, 250f, 20f), string.Empty, underbarimage);
		GUI.Box(new Rect(18.5f, 35f, barwidth, 20f), string.Empty, barimage);
		GUI.EndGroup();
		if (!(alpha2 <= 0f))
		{
			GUI.depth = -11;
		}
		float a2 = alpha2;
		Color color4 = GUI.color;
		float num2 = (color4.a = a2);
		Color color5 = (GUI.color = color4);
		GUI.DrawTexture(new Rect(0f, 0f, Screen.width, Screen.height), fadeouttex);
	}

	public virtual IEnumerator startloading()
	{
		return new _0024startloading_00244970(this).GetEnumerator();
	}

	public virtual IEnumerator fadein()
	{
		return new _0024fadein_00244973(this).GetEnumerator();
	}

	public virtual IEnumerator fadeOut()
	{
		return new _0024fadeOut_00244976(this).GetEnumerator();
	}

	public virtual void Main()
	{
	}
}
