using System;
using UnityEngine;

[Serializable]
public class RotateMenu : MonoBehaviour
{
	public Light mainsun;

	private bool animateup;

	private bool rotate;

	public RotateMenu()
	{
		animateup = true;
		rotate = true;
	}

	public virtual void Update()
	{
		if (rotate)
		{
			transform.Rotate(0f, 10f * Time.deltaTime, 0f);
		}
		if (animateup)
		{
			if (!(mainsun.intensity >= 1.1f))
			{
				mainsun.intensity += 0.4f * Time.deltaTime;
				return;
			}
			mainsun.intensity = 1.1f;
			animateup = false;
		}
		else if (!(mainsun.intensity <= 0.3f))
		{
			mainsun.intensity -= 0.4f * Time.deltaTime;
		}
		else
		{
			mainsun.intensity = 0.3f;
			animateup = true;
		}
	}

	public virtual void startStopRotate(bool t)
	{
		rotate = t;
	}

	public virtual void Main()
	{
	}
}
