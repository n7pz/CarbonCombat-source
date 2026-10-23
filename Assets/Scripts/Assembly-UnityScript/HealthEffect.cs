using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class HealthEffect : MonoBehaviour
{
	[Serializable]
	internal sealed class _0024FadeTo_00243998 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal float _0024_00242223_00243999;

			internal Color _0024_00242224_00244000;

			internal float _0024_00242225_00244001;

			internal Color _0024_00242226_00244002;

			internal float _0024i_00244003;

			internal HealthEffect _0024self__00244004;

			public _0024(float i, HealthEffect self_)
			{
				_0024i_00244003 = i;
				_0024self__00244004 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (!_0024self__00244004.onein)
					{
						_0024self__00244004.onein = true;
						_0024self__00244004.guiTexture.enabled = true;
						goto case 2;
					}
					goto IL_018c;
				case 2:
					if (_0024self__00244004.guiTexture.color.a < _0024i_00244003 / 100f)
					{
						float num = (_0024_00242223_00243999 = _0024self__00244004.guiTexture.color.a + 1.2f * Time.deltaTime);
						Color color = (_0024_00242224_00244000 = _0024self__00244004.guiTexture.color);
						float num2 = (_0024_00242224_00244000.a = _0024_00242223_00243999);
						Color color2 = (_0024self__00244004.guiTexture.color = _0024_00242224_00244000);
						result = (YieldDefault(2) ? 1 : 0);
					}
					else
					{
						float num3 = (_0024_00242225_00244001 = _0024i_00244003 / 100f);
						Color color4 = (_0024_00242226_00244002 = _0024self__00244004.guiTexture.color);
						float num4 = (_0024_00242226_00244002.a = _0024_00242225_00244001);
						Color color5 = (_0024self__00244004.guiTexture.color = _0024_00242226_00244002);
						result = (Yield(3, new WaitForSeconds(0.15f)) ? 1 : 0);
					}
					break;
				case 3:
					_0024self__00244004.StartCoroutine_Auto(_0024self__00244004.Fadeout());
					goto IL_018c;
				case 1:
					{
						result = 0;
						break;
					}
					IL_018c:
					_0024self__00244004.onein = false;
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal float _0024i_00244005;

		internal HealthEffect _0024self__00244006;

		public _0024FadeTo_00243998(float i, HealthEffect self_)
		{
			_0024i_00244005 = i;
			_0024self__00244006 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024i_00244005, _0024self__00244006);
		}
	}

	[Serializable]
	internal sealed class _0024FadeAt_00244007 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal float _0024_00242227_00244008;

			internal Color _0024_00242228_00244009;

			internal float _0024_00242229_00244010;

			internal Color _0024_00242230_00244011;

			internal float _0024i_00244012;

			internal HealthEffect _0024self__00244013;

			public _0024(float i, HealthEffect self_)
			{
				_0024i_00244012 = i;
				_0024self__00244013 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00244013.nofadeout = true;
					_0024self__00244013.guiTexture.enabled = true;
					goto case 2;
				case 2:
				{
					if (_0024self__00244013.guiTexture.color.a < _0024i_00244012 / 100f)
					{
						float num = (_0024_00242227_00244008 = _0024self__00244013.guiTexture.color.a + 1.2f * Time.deltaTime);
						Color color = (_0024_00242228_00244009 = _0024self__00244013.guiTexture.color);
						float num2 = (_0024_00242228_00244009.a = _0024_00242227_00244008);
						Color color2 = (_0024self__00244013.guiTexture.color = _0024_00242228_00244009);
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					float num3 = (_0024_00242229_00244010 = _0024i_00244012 / 100f);
					Color color4 = (_0024_00242230_00244011 = _0024self__00244013.guiTexture.color);
					float num4 = (_0024_00242230_00244011.a = _0024_00242229_00244010);
					Color color5 = (_0024self__00244013.guiTexture.color = _0024_00242230_00244011);
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

		internal float _0024i_00244014;

		internal HealthEffect _0024self__00244015;

		public _0024FadeAt_00244007(float i, HealthEffect self_)
		{
			_0024i_00244014 = i;
			_0024self__00244015 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024i_00244014, _0024self__00244015);
		}
	}

	[Serializable]
	internal sealed class _0024Fadeout_00244016 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal float _0024_00242231_00244017;

			internal Color _0024_00242232_00244018;

			internal float _0024_00242233_00244019;

			internal Color _0024_00242234_00244020;

			internal HealthEffect _0024self__00244021;

			public _0024(HealthEffect self_)
			{
				_0024self__00244021 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (!_0024self__00244021.oneout)
					{
						_0024self__00244021.oneout = true;
						goto case 2;
					}
					goto IL_0168;
				case 2:
					if (!(_0024self__00244021.guiTexture.color.a <= 0f) && !_0024self__00244021.nofadeout)
					{
						float num = (_0024_00242231_00244017 = _0024self__00244021.guiTexture.color.a - 1f * Time.deltaTime);
						Color color = (_0024_00242232_00244018 = _0024self__00244021.guiTexture.color);
						float num2 = (_0024_00242232_00244018.a = _0024_00242231_00244017);
						Color color2 = (_0024self__00244021.guiTexture.color = _0024_00242232_00244018);
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					if (!_0024self__00244021.nofadeout)
					{
						float num3 = (_0024_00242233_00244019 = 0f);
						Color color4 = (_0024_00242234_00244020 = _0024self__00244021.guiTexture.color);
						float num4 = (_0024_00242234_00244020.a = _0024_00242233_00244019);
						Color color5 = (_0024self__00244021.guiTexture.color = _0024_00242234_00244020);
						_0024self__00244021.guiTexture.enabled = false;
					}
					goto IL_0168;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0168:
					_0024self__00244021.oneout = false;
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal HealthEffect _0024self__00244022;

		public _0024Fadeout_00244016(HealthEffect self_)
		{
			_0024self__00244022 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00244022);
		}
	}

	private bool onein;

	private bool oneout;

	private bool nofadeout;

	public virtual IEnumerator FadeTo(float i)
	{
		return new _0024FadeTo_00243998(i, this).GetEnumerator();
	}

	public virtual IEnumerator FadeAt(float i)
	{
		return new _0024FadeAt_00244007(i, this).GetEnumerator();
	}

	public virtual void setnfo()
	{
		nofadeout = false;
	}

	public virtual IEnumerator Fadeout()
	{
		return new _0024Fadeout_00244016(this).GetEnumerator();
	}

	public virtual void Main()
	{
	}
}
