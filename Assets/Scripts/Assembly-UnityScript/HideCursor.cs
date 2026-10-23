using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class HideCursor : MonoBehaviour
{
	[Serializable]
	internal sealed class _0024Start_00244749 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal HideCursor _0024self__00244750;

			public _0024(HideCursor self_)
			{
				_0024self__00244750 = self_;
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
					_0024self__00244750.backaud.Play();
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal HideCursor _0024self__00244751;

		public _0024Start_00244749(HideCursor self_)
		{
			_0024self__00244751 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00244751);
		}
	}

	public AudioSource backaud;

	public virtual IEnumerator Start()
	{
		return new _0024Start_00244749(this).GetEnumerator();
	}

	public virtual void Awake()
	{
		Application.targetFrameRate = 300;
	}

	public virtual void Main()
	{
	}
}
