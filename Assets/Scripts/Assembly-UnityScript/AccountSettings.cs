using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class AccountSettings : MonoBehaviour
{
	[Serializable]
	internal sealed class _0024fadein_00243020 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal AccountSettings _0024self__00243021;

			public _0024(AccountSettings self_)
			{
				_0024self__00243021 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__00243021.alpha < 1f)
					{
						_0024self__00243021.alpha += 4f * Time.deltaTime;
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024self__00243021.alpha = 1f;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal AccountSettings _0024self__00243022;

		public _0024fadein_00243020(AccountSettings self_)
		{
			_0024self__00243022 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00243022);
		}
	}

	[Serializable]
	internal sealed class _0024fadeOut_00243023 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal AccountSettings _0024self__00243024;

			public _0024(AccountSettings self_)
			{
				_0024self__00243024 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__00243024.alpha > 0f)
					{
						_0024self__00243024.alpha -= 4f * Time.deltaTime;
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024self__00243024.alpha = 0f;
					_0024self__00243024.gameObject.active = false;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal AccountSettings _0024self__00243025;

		public _0024fadeOut_00243023(AccountSettings self_)
		{
			_0024self__00243025 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00243025);
		}
	}

	public GUIStyle loginstyle;

	public GUIStyle textstyle;

	public GUIStyle buttonskin;

	public GUIStyle labelStyle;

	private float alpha;

	public AuthGameObject authobj;

	public GUISkin scrollskin;

	private Vector2 scrollPos;

	public Color greenColor;

	public virtual IEnumerator fadein()
	{
		return new _0024fadein_00243020(this).GetEnumerator();
	}

	public virtual IEnumerator fadeOut()
	{
		return new _0024fadeOut_00243023(this).GetEnumerator();
	}

	public virtual void OnGUI()
	{
		GUI.skin = scrollskin;
		if (alpha <= 0f)
		{
			return;
		}
		float a = alpha;
		Color color = GUI.color;
		float num = (color.a = a);
		Color color2 = (GUI.color = color);
		GUI.depth = -1;
		GUI.BeginGroup(new Rect(Screen.width / 2 - 300, Screen.height / 2 - 150, 600f, 300f));
		GUI.Box(new Rect(0f, 0f, 600f, 300f), "Achievements and Awards", loginstyle);
		GUI.Label(new Rect(25f, 30f, 550f, 20f), "A list of the current achievements that can be aquired by performing tasks in-game.", textstyle);
		GUI.BeginGroup(new Rect(25f, 70f, 555f, 170f));
		scrollPos = GUILayout.BeginScrollView(scrollPos, false, true, GUILayout.Width(555f), GUILayout.Height(170f));
		GUILayout.BeginVertical();
		int num2 = 0;
		int i = 0;
		string[] achStat = AuthGameObject.achStat;
		for (int length = achStat.Length; i < length; i++)
		{
			if (RuntimeServices.EqualityOperator(AuthGameObject.achGot[num2], "1"))
			{
				GUI.color = greenColor;
				float a2 = alpha;
				Color color4 = GUI.color;
				float num3 = (color4.a = a2);
				Color color5 = (GUI.color = color4);
			}
			else
			{
				GUI.color = Color.white;
				float a3 = alpha;
				Color color7 = GUI.color;
				float num4 = (color7.a = a3);
				Color color8 = (GUI.color = color7);
			}
			GUILayout.BeginHorizontal();
			GUILayout.Label(achStat[i], labelStyle);
			GUILayout.FlexibleSpace();
			GUILayout.Label((!RuntimeServices.EqualityOperator(AuthGameObject.achGot[num2], "1")) ? "(Description Hidden)" : AuthGameObject.achDescStat[num2], labelStyle);
			num2++;
			GUILayout.Space(15f);
			GUILayout.EndHorizontal();
			GUILayout.Space(20f);
		}
		GUILayout.EndVertical();
		GUILayout.EndScrollView();
		GUI.EndGroup();
		if (GUI.Button(new Rect(460f, 250f, 110f, 25f), "Close Window", buttonskin))
		{
			StartCoroutine_Auto(fadeOut());
		}
		GUI.EndGroup();
	}

	public virtual void Main()
	{
	}
}
