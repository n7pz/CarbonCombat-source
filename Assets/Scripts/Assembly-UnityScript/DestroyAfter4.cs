using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class DestroyAfter4 : MonoBehaviour
{
	[Serializable]
	internal sealed class _0024StartDestroy_00243532 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal float _0024t_00243533;

			internal DestroyAfter4 _0024self__00243534;

			public _0024(float t, DestroyAfter4 self_)
			{
				_0024t_00243533 = t;
				_0024self__00243534 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024t_00243533 > 0f)
					{
						_0024t_00243533 -= Time.deltaTime;
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					UnityEngine.Object.Destroy(_0024self__00243534.gameObject);
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal float _0024t_00243535;

		internal DestroyAfter4 _0024self__00243536;

		public _0024StartDestroy_00243532(float t, DestroyAfter4 self_)
		{
			_0024t_00243535 = t;
			_0024self__00243536 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024t_00243535, _0024self__00243536);
		}
	}

	public virtual IEnumerator StartDestroy(float t)
	{
		return new _0024StartDestroy_00243532(t, this).GetEnumerator();
	}

	public virtual void Main()
	{
	}
}
