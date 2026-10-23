using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class ControlsForIdiots : MonoBehaviour
{
	[Serializable]
	internal sealed class _0024fadeOut_00243526 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal ControlsForIdiots _0024self__00243527;

			public _0024(ControlsForIdiots self_)
			{
				_0024self__00243527 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__00243527.alpha > 0f)
					{
						_0024self__00243527.alpha -= 4f * Time.deltaTime;
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024self__00243527.alpha = 0f;
					_0024self__00243527.gameObject.active = false;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal ControlsForIdiots _0024self__00243528;

		public _0024fadeOut_00243526(ControlsForIdiots self_)
		{
			_0024self__00243528 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00243528);
		}
	}

	[Serializable]
	internal sealed class _0024fadein_00243529 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal ControlsForIdiots _0024self__00243530;

			public _0024(ControlsForIdiots self_)
			{
				_0024self__00243530 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__00243530.alpha < 1f)
					{
						_0024self__00243530.alpha += 2f * Time.deltaTime;
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024self__00243530.alpha = 1f;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal ControlsForIdiots _0024self__00243531;

		public _0024fadein_00243529(ControlsForIdiots self_)
		{
			_0024self__00243531 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00243531);
		}
	}

	public GUIStyle overlay;

	public GUIStyle mainwin;

	public GUIStyle buttontex;

	public GUIStyle labeltxt;

	public GUIStyle boldtxt;

	public GUIStyle normtxt;

	public UnityScript.Lang.Array ctrlarray;

	public UnityScript.Lang.Array descarray;

	private float timeleft;

	private float alpha;

	public ControlsForIdiots()
	{
		ctrlarray = new UnityScript.Lang.Array("Driving:", "Flying/Hovering:", "Switch Weapons:", "Scope (aim):", "Brake");
		descarray = new UnityScript.Lang.Array("WASD or Arrow Keys", "Space (double-tap to lock)", "Numbers 1 and 2", "Shift (double-tap to lock)", "Control");
		timeleft = 5f;
	}

	public virtual void Awake()
	{
		timeleft = 0f;
		gameObject.active = false;
	}

	public virtual void OnGUI()
	{
		GUI.depth = -10;
		float a = alpha;
		Color color = GUI.color;
		float num = (color.a = a);
		Color color2 = (GUI.color = color);
		GUI.Box(new Rect(0f, 0f, Screen.width, Screen.height), string.Empty, overlay);
		GUI.BeginGroup(new Rect(Screen.width / 2 - 160, Screen.height / 2 - 125, 320f, 250f));
		GUI.Box(new Rect(0f, 0f, 320f, 250f), "Game Controls", mainwin);
		GUI.Label(new Rect(25f, 35f, 250f, 35f), "Listed below are the basic controls for Carbon Combat", labeltxt);
		int num2 = 0;
		IEnumerator enumerator = UnityRuntimeServices.GetEnumerator(ctrlarray);
		while (enumerator.MoveNext())
		{
			object obj = enumerator.Current;
			if (!(obj is string))
			{
				obj = RuntimeServices.Coerce(obj, typeof(string));
			}
			string text = (string)obj;
			GUI.Label(new Rect(23f, 70 + 25 * num2, 100f, 25f), text, boldtxt);
			UnityRuntimeServices.Update(enumerator, text);
			UnityRuntimeServices.Invoke(typeof(GUI), "Label", new object[3]
			{
				new Rect(143f, 70 + 25 * num2, 150f, 25f),
				descarray[num2],
				normtxt
			}, typeof(MonoBehaviour));
			num2++;
		}
		if (!(timeleft <= 0f))
		{
			GUI.enabled = false;
			if (!GUI.Button(new Rect(175f, 205f, 120f, 25f), "Close Window (" + Mathf.Round(timeleft) + ")", buttontex))
			{
			}
		}
		else
		{
			GUI.enabled = true;
			if (GUI.Button(new Rect(195f, 205f, 100f, 25f), "Close Window", buttontex))
			{
				PlayerPrefs.SetFloat("controlwindow", 999f);
				StartCoroutine_Auto(fadeOut());
			}
		}
		GUI.EndGroup();
	}

	public virtual IEnumerator fadeOut()
	{
		return new _0024fadeOut_00243526(this).GetEnumerator();
	}

	public virtual IEnumerator fadein()
	{
		return new _0024fadein_00243529(this).GetEnumerator();
	}

	public virtual void Update()
	{
		if (!(timeleft <= 0f))
		{
			timeleft -= Time.deltaTime;
		}
		else
		{
			timeleft = 0f;
		}
	}

	public virtual void Main()
	{
	}
}
