using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class StartCarAudio : MonoBehaviour
{
	[Serializable]
	internal sealed class _0024Start_00244944 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal StartCarAudio _0024self__00244945;

			public _0024(StartCarAudio self_)
			{
				_0024self__00244945 = self_;
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
					_0024self__00244945.audio.Play();
					_0024self__00244945.audio.pitch = 1f;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal StartCarAudio _0024self__00244946;

		public _0024Start_00244944(StartCarAudio self_)
		{
			_0024self__00244946 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00244946);
		}
	}

	public virtual IEnumerator Start()
	{
		return new _0024Start_00244944(this).GetEnumerator();
	}

	public virtual void Main()
	{
	}
}
