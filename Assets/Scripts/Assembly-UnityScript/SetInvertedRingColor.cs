using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class SetInvertedRingColor : MonoBehaviour
{
	[Serializable]
	internal sealed class _0024setcolor_00245501 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal SetInvertedRingColor _0024self__00245502;

			public _0024(SetInvertedRingColor self_)
			{
				_0024self__00245502 = self_;
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
					result = (YieldDefault(3) ? 1 : 0);
					break;
				case 3:
					result = (YieldDefault(4) ? 1 : 0);
					break;
				case 4:
					_0024self__00245502.renderer.material.color = RenderSettings.fogColor;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal SetInvertedRingColor _0024self__00245503;

		public _0024setcolor_00245501(SetInvertedRingColor self_)
		{
			_0024self__00245503 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00245503);
		}
	}

	public virtual void Start()
	{
		StartCoroutine_Auto(setcolor());
	}

	public virtual IEnumerator setcolor()
	{
		return new _0024setcolor_00245501(this).GetEnumerator();
	}

	public virtual void Update()
	{
		if ((bool)Camera.main)
		{
			if (!(Camera.main.transform.position.y <= 11.5f))
			{
				renderer.enabled = false;
			}
			else
			{
				renderer.enabled = true;
			}
		}
	}

	public virtual void Main()
	{
	}
}
