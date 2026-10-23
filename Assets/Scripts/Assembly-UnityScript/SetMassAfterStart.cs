using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class SetMassAfterStart : MonoBehaviour
{
	[Serializable]
	internal sealed class _0024Start_00245504 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal SetMassAfterStart _0024self__00245505;

			public _0024(SetMassAfterStart self_)
			{
				_0024self__00245505 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					result = (YieldDefault(2) ? 1 : 0);
					break;
				case 2:
					_0024self__00245505.rigidbody.mass = 2f;
					_0024self__00245505.rigidbody.drag = 0.25f;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal SetMassAfterStart _0024self__00245506;

		public _0024Start_00245504(SetMassAfterStart self_)
		{
			_0024self__00245506 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00245506);
		}
	}

	public virtual IEnumerator Start()
	{
		return new _0024Start_00245504(this).GetEnumerator();
	}

	public virtual void Main()
	{
	}
}
