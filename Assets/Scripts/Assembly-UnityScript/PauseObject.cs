using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class PauseObject : MonoBehaviour
{
	[Serializable]
	internal sealed class _0024fadeInBind_00245039 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal PauseObject _0024self__00245040;

			public _0024(PauseObject self_)
			{
				_0024self__00245040 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__00245040.alpha2 < 1f)
					{
						_0024self__00245040.alpha2 += 4f * Time.deltaTime;
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024self__00245040.alpha2 = 1f;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal PauseObject _0024self__00245041;

		public _0024fadeInBind_00245039(PauseObject self_)
		{
			_0024self__00245041 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00245041);
		}
	}

	[Serializable]
	internal sealed class _0024fadeOutBind_00245042 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal PauseObject _0024self__00245043;

			public _0024(PauseObject self_)
			{
				_0024self__00245043 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__00245043.alpha2 > 0f)
					{
						_0024self__00245043.alpha2 -= 4f * Time.deltaTime;
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024self__00245043.alpha2 = 0f;
					PlayerPrefs.SetString("alt_fly", alt_fly);
					PlayerPrefs.SetString("alt_reload", alt_reload);
					PlayerPrefs.SetString("alt_switch", alt_switch);
					PlayerPrefs.SetString("alt_scope", alt_scope);
					PlayerPrefs.SetString("alt_item", alt_item);
					PlayerPrefs.SetString("alt_brake", alt_brake);
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal PauseObject _0024self__00245044;

		public _0024fadeOutBind_00245042(PauseObject self_)
		{
			_0024self__00245044 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00245044);
		}
	}

	[Serializable]
	internal sealed class _0024fadeOut_00245045 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal PauseObject _0024self__00245046;

			public _0024(PauseObject self_)
			{
				_0024self__00245046 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__00245046.alpha > 0f)
					{
						_0024self__00245046.alpha -= 4f * Time.deltaTime;
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					PlayerPrefs.SetFloat("camerafd", camerafd);
					PlayerPrefs.SetFloat("camerafh", camerafh);
					PlayerPrefs.SetFloat("fpssens", fpssens);
					PlayerPrefs.SetFloat("bacc", bacc);
					PlayerPrefs.SetInt("crnum", chairvar);
					_0024self__00245046.alpha = 0f;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal PauseObject _0024self__00245047;

		public _0024fadeOut_00245045(PauseObject self_)
		{
			_0024self__00245047 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00245047);
		}
	}

	[Serializable]
	internal sealed class _0024fadein_00245048 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal PauseObject _0024self__00245049;

			public _0024(PauseObject self_)
			{
				_0024self__00245049 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__00245049.alpha < 1f)
					{
						_0024self__00245049.alpha += 2f * Time.deltaTime;
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024self__00245049.Awake();
					_0024self__00245049.alpha = 1f;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal PauseObject _0024self__00245050;

		public _0024fadein_00245048(PauseObject self_)
		{
			_0024self__00245050 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00245050);
		}
	}

	public GUIStyle backgroundtex;

	public GUIStyle sliderbk;

	public GUIStyle sliderbut;

	public GUIStyle prefbk;

	public GUIStyle boxtx;

	public GUIStyle labelstyle;

	public GUIStyle checkboxstyle;

	public GUIStyle btstyle;

	public GUIStyle largelabel;

	private float alpha;

	[NonSerialized]
	public static float pubalpha;

	public GameObject spawnpoint;

	public GameObject boverlay;

	public PlayerCar_Script playercar;

	public SpawningScript spwnsrc;

	[NonSerialized]
	public static float camerafd = 30f;

	[NonSerialized]
	public static float camerafh = 5.5f;

	[NonSerialized]
	public static float fpssens = 5f;

	[NonSerialized]
	public static int chairvar;

	public Texture[] chairlist;

	[NonSerialized]
	public static Texture[] chairliststat;

	[NonSerialized]
	public static bool tog1 = true;

	[NonSerialized]
	public static bool tog2;

	[NonSerialized]
	public static bool tog3;

	[NonSerialized]
	public static float bacc = 1f;

	[NonSerialized]
	public static string alt_fly = string.Empty;

	[NonSerialized]
	public static string alt_reload = string.Empty;

	[NonSerialized]
	public static string alt_switch = string.Empty;

	[NonSerialized]
	public static string alt_scope = string.Empty;

	[NonSerialized]
	public static string alt_item = string.Empty;

	[NonSerialized]
	public static string alt_brake = string.Empty;

	private float alpha2;

	public GUIStyle bindBox;

	public GUIStyle bindLabel;

	public GUIStyle bindLabel2;

	public virtual void Awake()
	{
		camerafd = PlayerPrefs.GetFloat("camerafd", 30f);
		camerafh = PlayerPrefs.GetFloat("camerafh", 5.5f);
		fpssens = PlayerPrefs.GetFloat("fpssens", 5f);
		bacc = PlayerPrefs.GetFloat("bacc", 1f);
		chairvar = PlayerPrefs.GetInt("crnum", 1);
		alt_fly = PlayerPrefs.GetString("alt_fly", string.Empty);
		alt_reload = PlayerPrefs.GetString("alt_reload", string.Empty);
		alt_switch = PlayerPrefs.GetString("alt_switch", string.Empty);
		alt_scope = PlayerPrefs.GetString("alt_scope", string.Empty);
		alt_item = PlayerPrefs.GetString("alt_item", string.Empty);
		alt_brake = PlayerPrefs.GetString("alt_brake", string.Empty);
		if (chairvar == 0)
		{
			tog1 = true;
			tog2 = false;
			tog3 = false;
		}
		if (chairvar == 1)
		{
			tog1 = false;
			tog2 = true;
			tog3 = false;
		}
		if (chairvar == 2)
		{
			tog1 = false;
			tog2 = false;
			tog3 = true;
		}
		pubalpha = 0f;
		chairliststat = chairlist;
	}

	public virtual void OnGUI()
	{
		GUI.depth = -8;
		float a = alpha;
		Color color = GUI.color;
		float num = (color.a = a);
		Color color2 = (GUI.color = color);
		if (alpha == 0f)
		{
			return;
		}
		GUI.Box(new Rect(0f, 0f, Screen.width, Screen.height), string.Empty, backgroundtex);
		if (!(alpha2 <= 0f))
		{
			GUI.enabled = false;
		}
		GUI.Label(new Rect(Screen.width / 2 - 185, Screen.height / 2 - 103 - 43, 370f, 35f), "Game paused. Press [esc] or [p] to resume game", largelabel);
		float a2 = alpha;
		Color color4 = GUI.color;
		float num2 = (color4.a = a2);
		Color color5 = (GUI.color = color4);
		GUI.BeginGroup(new Rect(Screen.width / 2 - 196, Screen.height / 2 - 73 - 43, 393f, 260f));
		float a3 = alpha;
		Color color7 = GUI.color;
		float num3 = (color7.a = a3);
		Color color8 = (GUI.color = color7);
		GUI.Box(new Rect(0f, 0f, 393f, 260f), "In-Game Options", boxtx);
		camerafd = GUI.HorizontalSlider(new Rect(120f, 35f, 250f, 32f), camerafd, 16.5f, 36.5f, sliderbk, sliderbut);
		GUI.Label(new Rect(15f, 32f, 105f, 35f), "Cam Follow Dist.\n(" + Mathf.Round(camerafd).ToString() + " meters)", labelstyle);
		camerafh = GUI.HorizontalSlider(new Rect(120f, 70f, 250f, 32f), camerafh, 2.5f, 10.5f, sliderbk, sliderbut);
		GUI.Label(new Rect(15f, 67f, 105f, 35f), "Cam Height\n(" + Mathf.Round(camerafh).ToString() + " meters)", labelstyle);
		fpssens = GUI.HorizontalSlider(new Rect(120f, 105f, 250f, 32f), fpssens, 1f, 15f, sliderbk, sliderbut);
		GUI.Label(new Rect(15f, 102f, 105f, 35f), "Mouse Sensitivity", labelstyle);
		string rhs = "less";
		float num4;
		if (!(bacc >= 1f))
		{
			num4 = 1f + (1f - bacc);
			rhs = "more";
		}
		else
		{
			num4 = bacc;
		}
		bacc = GUI.HorizontalSlider(new Rect(120f, 140f, 250f, 32f), bacc, 0f, 3f, sliderbk, sliderbut);
		GUI.Label(new Rect(15f, 137f, 105f, 35f), "Bot Accuracy\n(" + (Mathf.Round(num4 * 10f) / 10f).ToString() + "x " + rhs + " acc.)", labelstyle);
		GUI.Label(new Rect(15f, 170f, 105f, 35f), "Crosshair Style", labelstyle);
		if (tog1)
		{
			GUI.enabled = false;
		}
		else
		{
			GUI.enabled = true;
		}
		tog1 = GUI.Toggle(new Rect(130f, 180f, 20f, 20f), tog1, string.Empty, checkboxstyle);
		GUI.enabled = true;
		GUI.DrawTexture(new Rect(155f, 173f, chairlist[0].width, chairlist[0].height), chairlist[0]);
		if (tog1)
		{
			tog2 = false;
			tog3 = false;
			chairvar = 0;
		}
		if (tog2)
		{
			GUI.enabled = false;
		}
		else
		{
			GUI.enabled = true;
		}
		tog2 = GUI.Toggle(new Rect(230f, 180f, 20f, 20f), tog2, string.Empty, checkboxstyle);
		GUI.enabled = true;
		GUI.DrawTexture(new Rect(255f, 175f, chairlist[1].width, chairlist[1].height), chairlist[1]);
		if (tog2)
		{
			tog1 = false;
			tog3 = false;
			chairvar = 1;
		}
		if (tog3)
		{
			GUI.enabled = false;
		}
		else
		{
			GUI.enabled = true;
		}
		tog3 = GUI.Toggle(new Rect(310f, 180f, 20f, 20f), tog3, string.Empty, checkboxstyle);
		GUI.enabled = true;
		GUI.DrawTexture(new Rect(335f, 173f, chairlist[2].width, chairlist[2].height), chairlist[2]);
		if (tog3)
		{
			tog1 = false;
			tog2 = false;
			chairvar = 2;
		}
		if (GUI.Button(new Rect(250f, 215f, 120f, 25f), "Restore Defaults", btstyle))
		{
			camerafd = 26.5f;
			camerafh = 4.5f;
			fpssens = 5f;
			chairvar = 0;
			bacc = 1f;
			tog1 = false;
			tog2 = true;
			tog3 = false;
		}
		if (GUI.Button(new Rect(125f, 215f, 120f, 25f), "Controls Help", btstyle))
		{
			boverlay.active = true;
			boverlay.SendMessage("fadein");
		}
		if (GUI.Button(new Rect(20f, 215f, 100f, 25f), "Edit Controls", btstyle))
		{
			StartCoroutine_Auto(fadeInBind());
		}
		GUI.EndGroup();
		GUI.enabled = true;
		float a4 = alpha2;
		Color color10 = GUI.color;
		float num5 = (color10.a = a4);
		Color color11 = (GUI.color = color10);
		if (alpha2 <= 0f)
		{
			return;
		}
		GUI.BeginGroup(new Rect(Screen.width / 2 - 160, Screen.height / 2 - 185, 320f, 370f));
		GUI.Box(new Rect(0f, 0f, 320f, 370f), "Custom Game Controls", bindBox);
		GUI.Label(new Rect(0f, 0f, 320f, 370f), "You can set (bind) custom controls here. Original controls will still work.", bindLabel);
		UnityScript.Lang.Array array = new UnityScript.Lang.Array("Fly: Space", "Reload: r", "Switch Weapons: e", "Scope: Shift", "Use Item: m", "Brake: cmd/ctrl");
		for (int i = 0; i < array.length; i++)
		{
			UnityRuntimeServices.Invoke(typeof(GUI), "Label", new object[3]
			{
				new Rect(25f, 95 + i * 35, 150f, 15f),
				array[i],
				bindLabel2
			}, typeof(MonoBehaviour));
			GUI.SetNextControlName(i.ToString());
			if (i == 0)
			{
				GUI.TextField(new Rect(155f, 90 + i * 35, 140f, 20f), alt_fly);
			}
			if (i == 1)
			{
				GUI.TextField(new Rect(155f, 90 + i * 35, 140f, 20f), alt_reload);
			}
			if (i == 2)
			{
				GUI.TextField(new Rect(155f, 90 + i * 35, 140f, 20f), alt_switch);
			}
			if (i == 3)
			{
				GUI.TextField(new Rect(155f, 90 + i * 35, 140f, 20f), alt_scope);
			}
			if (i == 4)
			{
				GUI.TextField(new Rect(155f, 90 + i * 35, 140f, 20f), alt_item);
			}
			if (i == 5)
			{
				GUI.TextField(new Rect(155f, 90 + i * 35, 140f, 20f), alt_brake);
			}
		}
		Event current = Event.current;
		if (current.isKey)
		{
			if (GUI.GetNameOfFocusedControl() == "0")
			{
				alt_fly = current.keyCode.ToString();
			}
			if (GUI.GetNameOfFocusedControl() == "1")
			{
				alt_reload = current.keyCode.ToString();
			}
			if (GUI.GetNameOfFocusedControl() == "2")
			{
				alt_switch = current.keyCode.ToString();
			}
			if (GUI.GetNameOfFocusedControl() == "3")
			{
				alt_scope = current.keyCode.ToString();
			}
			if (GUI.GetNameOfFocusedControl() == "4")
			{
				alt_item = current.keyCode.ToString();
			}
			if (GUI.GetNameOfFocusedControl() == "5")
			{
				alt_brake = current.keyCode.ToString();
			}
		}
		if (current.shift)
		{
			if (GUI.GetNameOfFocusedControl() == "0")
			{
				alt_fly = KeyCode.LeftShift.ToString();
			}
			if (GUI.GetNameOfFocusedControl() == "1")
			{
				alt_reload = KeyCode.LeftShift.ToString();
			}
			if (GUI.GetNameOfFocusedControl() == "2")
			{
				alt_switch = KeyCode.LeftShift.ToString();
			}
			if (GUI.GetNameOfFocusedControl() == "3")
			{
				alt_scope = KeyCode.LeftShift.ToString();
			}
			if (GUI.GetNameOfFocusedControl() == "4")
			{
				alt_item = KeyCode.LeftShift.ToString();
			}
			if (GUI.GetNameOfFocusedControl() == "5")
			{
				alt_brake = KeyCode.LeftShift.ToString();
			}
		}
		if (GUI.Button(new Rect(200f, 325f, 100f, 25f), "Close Window", btstyle))
		{
			StartCoroutine_Auto(fadeOutBind());
		}
		if (GUI.Button(new Rect(80f, 325f, 115f, 25f), "Clear All Controls", btstyle))
		{
			alt_fly = string.Empty;
			alt_reload = string.Empty;
			alt_switch = string.Empty;
			alt_scope = string.Empty;
			alt_item = string.Empty;
			alt_brake = string.Empty;
		}
		GUI.EndGroup();
	}

	public virtual void Update()
	{
		if ((Input.GetKeyDown("p") || Input.GetKeyDown("escape")) && (PlayerCar_Script.controlenabled || alpha == 1f))
		{
			if (alpha == 0f)
			{
				spawnpoint.gameObject.SendMessage("chatsetcontrol", false);
				StartCoroutine_Auto(fadein());
			}
			if (alpha == 1f)
			{
				spawnpoint.gameObject.SendMessage("chatsetcontrol", true);
				StartCoroutine_Auto(fadeOut());
				StartCoroutine_Auto(fadeOutBind());
			}
		}
		pubalpha = alpha;
	}

	public virtual IEnumerator fadeInBind()
	{
		return new _0024fadeInBind_00245039(this).GetEnumerator();
	}

	public virtual IEnumerator fadeOutBind()
	{
		return new _0024fadeOutBind_00245042(this).GetEnumerator();
	}

	public virtual IEnumerator fadeOut()
	{
		return new _0024fadeOut_00245045(this).GetEnumerator();
	}

	public virtual IEnumerator fadein()
	{
		return new _0024fadein_00245048(this).GetEnumerator();
	}

	public virtual void Main()
	{
	}
}
