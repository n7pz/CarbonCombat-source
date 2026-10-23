using System;
using UnityEngine;

[Serializable]
public class JumpPoint : MonoBehaviour
{
	public int delay;

	public int velocityMin;

	public int velocityMax;

	private float lastBlast;

	public JumpPoint()
	{
		delay = 500;
		velocityMin = 50;
	}

	public virtual void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer != 14)
		{
			lastBlast = Time.time + (float)(delay / 1000);
		}
	}

	public virtual void OnTriggerStay(Collider other)
	{
		if (other.gameObject.layer != 14 && !(Time.time - 0.1f < lastBlast) && (bool)other.attachedRigidbody)
		{
			lastBlast = Time.time + (float)(delay / 1000);
			other.attachedRigidbody.AddForce(transform.up * ((velocityMin < velocityMax) ? UnityEngine.Random.Range(velocityMin, velocityMax) : velocityMin), ForceMode.VelocityChange);
		}
	}

	public virtual void OnDrawGizmos()
	{
	}

	public virtual void Main()
	{
	}
}
