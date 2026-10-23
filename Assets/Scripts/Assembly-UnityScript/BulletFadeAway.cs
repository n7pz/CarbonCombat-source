using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class BulletFadeAway : MonoBehaviour
{
	[Serializable]
	internal sealed class _0024Start_00245006 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal Color _0024origcolor_00245007;

			internal BulletFadeAway _0024self__00245008;

			public _0024(BulletFadeAway self_)
			{
				_0024self__00245008 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					result = (Yield(2, new WaitForSeconds(20f)) ? 1 : 0);
					break;
				case 2:
					_0024origcolor_00245007 = _0024self__00245008.renderer.material.GetColor("_TintColor");
					goto case 3;
				case 3:
					if (_0024origcolor_00245007.a > 0f)
					{
						_0024origcolor_00245007.a -= 0.5f * Time.deltaTime;
						_0024self__00245008.renderer.material.SetColor("_TintColor", _0024origcolor_00245007);
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					UnityEngine.Object.Destroy(_0024self__00245008.gameObject);
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal BulletFadeAway _0024self__00245009;

		public _0024Start_00245006(BulletFadeAway self_)
		{
			_0024self__00245009 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00245009);
		}
	}

	public virtual IEnumerator Start()
	{
		return new _0024Start_00245006(this).GetEnumerator();
	}

	public virtual void Main()
	{
	}
}
