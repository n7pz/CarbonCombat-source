using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class FadeSceneTransition : MonoBehaviour
{
	[Serializable]
	internal sealed class _0024startfadeout_00243850 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal int _0024i_00243851;

			internal FadeSceneTransition _0024self__00243852;

			public _0024(int i, FadeSceneTransition self_)
			{
				_0024i_00243851 = i;
				_0024self__00243852 = self_;
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
					if (_0024i_00243851 == 0)
					{
						goto case 3;
					}
					isfadingout = true;
					goto case 4;
				case 3:
					if (_0024self__00243852.alpha > 0f)
					{
						_0024self__00243852.alpha -= 2f * Time.deltaTime;
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					_0024self__00243852.alpha = 0f;
					goto IL_0105;
				case 4:
					if (_0024self__00243852.alpha < 1f)
					{
						_0024self__00243852.alpha += 2f * Time.deltaTime;
						result = (YieldDefault(4) ? 1 : 0);
						break;
					}
					_0024self__00243852.alpha = 1f;
					Screen.showCursor = true;
					Application.LoadLevel("Menu");
					goto IL_0105;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0105:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal int _0024i_00243853;

		internal FadeSceneTransition _0024self__00243854;

		public _0024startfadeout_00243850(int i, FadeSceneTransition self_)
		{
			_0024i_00243853 = i;
			_0024self__00243854 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024i_00243853, _0024self__00243854);
		}
	}

	public Texture blacktexture;

	private float alpha;

	[NonSerialized]
	public static bool isfadingout;

	public FadeSceneTransition()
	{
		alpha = 1f;
	}

	public virtual void OnGUI()
	{
		GUI.depth = -15;
		float a = alpha;
		Color color = GUI.color;
		float num = (color.a = a);
		Color color2 = (GUI.color = color);
		if (alpha != 0f)
		{
			GUI.DrawTexture(new Rect(0f, 0f, Screen.width, Screen.height), blacktexture);
		}
	}

	public virtual void Start()
	{
		isfadingout = false;
		StartCoroutine_Auto(startfadeout(0));
	}

	public virtual IEnumerator startfadeout(int i)
	{
		return new _0024startfadeout_00243850(i, this).GetEnumerator();
	}

	public virtual void Main()
	{
	}
}
