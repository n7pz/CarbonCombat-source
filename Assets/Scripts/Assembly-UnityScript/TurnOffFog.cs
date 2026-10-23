using System;
using UnityEngine;

[Serializable]
[AddComponentMenu("Rendering/Fog Layer")]
[RequireComponent(typeof(Camera))]
public class TurnOffFog : MonoBehaviour
{
	private bool revertFogState;

	public virtual void OnPreRender()
	{
		revertFogState = RenderSettings.fog;
		RenderSettings.fog = enabled;
	}

	public virtual void OnPostRender()
	{
		RenderSettings.fog = revertFogState;
	}

	public virtual void Main()
	{
	}
}
