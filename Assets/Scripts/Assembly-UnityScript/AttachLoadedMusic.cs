using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class AttachLoadedMusic : MonoBehaviour
{
	[Serializable]
	internal sealed class _0024Start_00243204 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal AttachLoadedMusic _0024self__00243205;

			public _0024(AttachLoadedMusic self_)
			{
				_0024self__00243205 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (LoadMusicDynamically.gotconfirm)
					{
						_0024self__00243205.audioSource.clip = LoadMusicDynamically.audioArray[_0024self__00243205.musicindex];
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					goto IL_005e;
				case 2:
					_0024self__00243205.audioSource.Play();
					goto IL_005e;
				case 1:
					{
						result = 0;
						break;
					}
					IL_005e:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal AttachLoadedMusic _0024self__00243206;

		public _0024Start_00243204(AttachLoadedMusic self_)
		{
			_0024self__00243206 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00243206);
		}
	}

	public int musicindex;

	public AudioSource audioSource;

	public LoadMusicDynamically lmusic;

	public virtual IEnumerator Start()
	{
		return new _0024Start_00243204(this).GetEnumerator();
	}

	public virtual void Main()
	{
	}
}
