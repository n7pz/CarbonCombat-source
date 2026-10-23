using System;
using UnityEngine;

[Serializable]
public class LowPolyExplosion : MonoBehaviour
{
	public virtual void Awake()
	{
		audio.pitch = UnityEngine.Random.Range(0.9f, 1.1f);
		audio.PlayOneShot(audio.clip);
	}

	public virtual void Main()
	{
	}
}
