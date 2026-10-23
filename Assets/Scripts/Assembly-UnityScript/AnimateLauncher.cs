using System;
using UnityEngine;

[Serializable]
public class AnimateLauncher : MonoBehaviour
{
	private int upordown;

	public int startingval;

	public virtual void Awake()
	{
		upordown = startingval;
	}

	public virtual void Update()
	{
		if (upordown == 0)
		{
			renderer.material.SetTextureOffset("_SurfaceTex", new Vector2(1f, renderer.material.GetTextureOffset("_SurfaceTex").y - 0.05f * Time.deltaTime));
			if (!(renderer.material.GetTextureOffset("_SurfaceTex").y > 0.65f))
			{
				upordown = 1;
			}
		}
		else
		{
			renderer.material.SetTextureOffset("_SurfaceTex", new Vector2(1f, renderer.material.GetTextureOffset("_SurfaceTex").y + 0.05f * Time.deltaTime));
			if (!(renderer.material.GetTextureOffset("_SurfaceTex").y < 0.71f))
			{
				upordown = 0;
			}
		}
	}

	public virtual void Main()
	{
	}
}
