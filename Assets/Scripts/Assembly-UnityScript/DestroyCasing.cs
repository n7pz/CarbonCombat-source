using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class DestroyCasing : MonoBehaviour
{
	[Serializable]
	internal sealed class _0024Start_00243537 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal DestroyCasing _0024self__00243538;

			public _0024(DestroyCasing self_)
			{
				_0024self__00243538 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					result = (Yield(2, new WaitForSeconds(0.3f)) ? 1 : 0);
					break;
				case 2:
					UnityEngine.Object.Destroy(_0024self__00243538.gameObject);
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal DestroyCasing _0024self__00243539;

		public _0024Start_00243537(DestroyCasing self_)
		{
			_0024self__00243539 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00243539);
		}
	}

	public virtual IEnumerator Start()
	{
		return new _0024Start_00243537(this).GetEnumerator();
	}

	public virtual void Main()
	{
	}
}
