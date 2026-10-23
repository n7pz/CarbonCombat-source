using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class grenade : MonoBehaviour
{
	[Serializable]
	internal sealed class _0024OnCollisionEnter_00244725 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal grenade _0024self__00244726;

			public _0024(grenade self_)
			{
				_0024self__00244726 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__00244726.hasCollided || !_0024self__00244726.explodeAfterBounce)
					{
						_0024self__00244726.DestroyNow();
					}
					result = (Yield(2, new WaitForSeconds(_0024self__00244726.timeOut)) ? 1 : 0);
					break;
				case 2:
					_0024self__00244726.hasCollided = true;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal grenade _0024self__00244727;

		public _0024OnCollisionEnter_00244725(grenade self_)
		{
			_0024self__00244727 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00244727);
		}
	}

	public float timeOut;

	public bool detachChildren;

	public Transform explosion;

	public bool explodeAfterBounce;

	private bool hasCollided;

	private float explodeTime;

	public grenade()
	{
		timeOut = 1f;
	}

	public virtual IEnumerator OnCollisionEnter(Collision collision)
	{
		return new _0024OnCollisionEnter_00244725(this).GetEnumerator();
	}

	public virtual void DestroyNow()
	{
		if (detachChildren)
		{
			transform.DetachChildren();
		}
		rigidbody.isKinematic = true;
		if ((bool)explosion)
		{
			UnityEngine.Object.Instantiate(explosion, transform.position, transform.rotation);
		}
	}

	public virtual void Update()
	{
		Vector3 direction = transform.TransformDirection(Vector3.forward);
		RaycastHit hitInfo = default(RaycastHit);
		if (Physics.Raycast(transform.position, direction, out hitInfo, 2f))
		{
			StartCoroutine_Auto(OnCollisionEnter(null));
		}
	}

	public virtual void Main()
	{
	}
}
