using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class SubMessage : MonoBehaviour
{
	[Serializable]
	internal sealed class _0024setMessage_00245749 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal string _0024m_00245750;

			internal SubMessage _0024self__00245751;

			public _0024(string m, SubMessage self_)
			{
				_0024m_00245750 = m;
				_0024self__00245751 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00245751.message = _0024m_00245750;
					_0024self__00245751.fadeType = 1;
					result = (Yield(2, new WaitForSeconds(2.6f)) ? 1 : 0);
					break;
				case 2:
					if (_0024self__00245751.message == _0024m_00245750)
					{
						_0024self__00245751.fadeType = -1;
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

		internal string _0024m_00245752;

		internal SubMessage _0024self__00245753;

		public _0024setMessage_00245749(string m, SubMessage self_)
		{
			_0024m_00245752 = m;
			_0024self__00245753 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024m_00245752, _0024self__00245753);
		}
	}

	[Serializable]
	internal sealed class _0024setMessage4_00245754 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal string _0024m_00245755;

			internal SubMessage _0024self__00245756;

			public _0024(string m, SubMessage self_)
			{
				_0024m_00245755 = m;
				_0024self__00245756 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00245756.message = _0024m_00245755;
					_0024self__00245756.fadeType = 1;
					result = (Yield(2, new WaitForSeconds(4f)) ? 1 : 0);
					break;
				case 2:
					if (_0024self__00245756.message == _0024m_00245755)
					{
						_0024self__00245756.fadeType = -1;
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

		internal string _0024m_00245757;

		internal SubMessage _0024self__00245758;

		public _0024setMessage4_00245754(string m, SubMessage self_)
		{
			_0024m_00245757 = m;
			_0024self__00245758 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024m_00245757, _0024self__00245758);
		}
	}

	[Serializable]
	internal sealed class _0024setMessageTut_00245759 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal string _0024m_00245760;

			internal SubMessage _0024self__00245761;

			public _0024(string m, SubMessage self_)
			{
				_0024m_00245760 = m;
				_0024self__00245761 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00245761.message = _0024m_00245760;
					_0024self__00245761.fadeType = 1;
					result = (Yield(2, new WaitForSeconds(9f)) ? 1 : 0);
					break;
				case 2:
					if (_0024self__00245761.message == _0024m_00245760)
					{
						_0024self__00245761.fadeType = -1;
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

		internal string _0024m_00245762;

		internal SubMessage _0024self__00245763;

		public _0024setMessageTut_00245759(string m, SubMessage self_)
		{
			_0024m_00245762 = m;
			_0024self__00245763 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024m_00245762, _0024self__00245763);
		}
	}

	public GUIStyle textLabel;

	public GUIStyle textLabel2;

	private float alpha;

	private int fadeType;

	private string message;

	public AudioController acon;

	public SubMessage()
	{
		message = string.Empty;
	}

	public virtual IEnumerator setMessage(string m)
	{
		return new _0024setMessage_00245749(m, this).GetEnumerator();
	}

	public virtual IEnumerator setMessage4(string m)
	{
		return new _0024setMessage4_00245754(m, this).GetEnumerator();
	}

	public virtual IEnumerator setMessageTut(string m)
	{
		return new _0024setMessageTut_00245759(m, this).GetEnumerator();
	}

	public virtual void Update()
	{
		if (fadeType == 1)
		{
			if (!(alpha >= 1f))
			{
				alpha += 4f * Time.deltaTime;
			}
			else
			{
				alpha = 1f;
				fadeType = 0;
			}
		}
		if (fadeType == -1)
		{
			if (!(alpha <= 0f))
			{
				alpha -= 4f * Time.deltaTime;
				return;
			}
			alpha = 0f;
			fadeType = 0;
		}
	}

	public virtual void OnGUI()
	{
		float a = alpha;
		Color color = GUI.color;
		float num = (color.a = a);
		Color color2 = (GUI.color = color);
		GUI.depth = -4;
		GUI.Label(new Rect(0f, 0f, Screen.width, Screen.height), message, textLabel2);
		GUI.Label(new Rect(0f, 0f, Screen.width, Screen.height), message, textLabel);
	}

	public virtual void Main()
	{
	}
}
