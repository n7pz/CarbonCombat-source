using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class ScreenRes : MonoBehaviour
{
	public Resolution[] resolutions;

	public virtual void Start()
	{
		UnityEngine.Object.DontDestroyOnLoad(transform.gameObject);
		resolutions = Screen.resolutions;
	}

	public virtual void Update()
	{
		if (Input.GetKeyDown("f") && Input.GetAxis("Brake") != 0f)
		{
			int num = UnityScript.Lang.Extensions.get_length((System.Array)resolutions) - 1;
			if (!Screen.fullScreen)
			{
				Screen.SetResolution(resolutions[num].width, resolutions[num].height, true);
			}
			Screen.fullScreen = !Screen.fullScreen;
		}
	}

	public virtual void goFullScreen()
	{
		int num = UnityScript.Lang.Extensions.get_length((System.Array)resolutions) - 1;
		if (!Screen.fullScreen)
		{
			Screen.SetResolution(resolutions[num].width, resolutions[num].height, true);
		}
		Screen.fullScreen = true;
	}

	public virtual void Main()
	{
	}
}
