using System;
using UnityEngine;

[Serializable]
public class FlameThrowerSoundScript : MonoBehaviour
{
	private bool audenabled;

	public FlameThrowerSoundScript()
	{
		audenabled = true;
	}

	public virtual void setEnable(bool t)
	{
		audenabled = t;
	}

	public virtual void Update()
	{
		if (audenabled)
		{
			audio.volume = Mathf.Clamp01(audio.volume + 5f * Time.deltaTime);
		}
		else
		{
			audio.volume = Mathf.Clamp01(audio.volume - 1f * Time.deltaTime);
		}
	}

	public virtual void Main()
	{
	}
}
