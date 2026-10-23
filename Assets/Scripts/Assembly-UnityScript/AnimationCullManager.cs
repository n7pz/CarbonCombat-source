using System;
using UnityEngine;

[Serializable]
public class AnimationCullManager : MonoBehaviour
{
	private float checkCounter;

	public AnimationCullManager()
	{
		checkCounter = 2f;
	}

	public virtual void Update()
	{
		if (QualitySettings.GetQualityLevel() == 0)
		{
			if (animation.isPlaying)
			{
				animation.Stop();
			}
			return;
		}
		if (!(checkCounter <= 0f))
		{
			checkCounter -= Time.deltaTime;
			return;
		}
		checkCounter = 2f;
		float sqrMagnitude = (Camera.main.transform.position - transform.position).sqrMagnitude;
		if (!(sqrMagnitude >= 9000f))
		{
			if (!animation.isPlaying)
			{
				animation.Play();
			}
		}
		else if (animation.isPlaying)
		{
			animation.Stop();
		}
	}

	public virtual void Main()
	{
	}
}
