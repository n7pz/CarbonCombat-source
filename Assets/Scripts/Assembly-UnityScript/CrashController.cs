using System;
using UnityEngine;

[Serializable]
public class CrashController : MonoBehaviour
{
	public SoundController sound;

	private Car car;

	public virtual void OnCollisionEnter(Collision collInfo)
	{
		if (enabled && collInfo.contacts.Length > 0)
		{
			float num = Mathf.Clamp01(collInfo.relativeVelocity.magnitude * 0.08f);
			num *= Mathf.Clamp01(0.3f + Mathf.Abs(Vector3.Dot(collInfo.relativeVelocity.normalized, collInfo.contacts[0].normal)));
			num = num * 0.5f + 0.5f;
			sound.StartCoroutine_Auto(sound.Crash(num));
		}
	}

	public virtual void Main()
	{
		sound = (SoundController)transform.root.GetComponent(typeof(SoundController));
		car = (Car)transform.GetComponent(typeof(Car));
	}
}
