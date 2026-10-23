using System;
using UnityEngine;

[Serializable]
public class ShowCursor : MonoBehaviour
{
	public virtual void Update()
	{
		if (Application.loadedLevelName == "Menu" && !Screen.showCursor)
		{
			Screen.showCursor = true;
		}
	}

	public virtual void Awake()
	{
		if (Application.loadedLevelName == "Menu")
		{
			Application.targetFrameRate = ((!Application.isWebPlayer) ? (-1) : 300);
			Screen.showCursor = true;
		}
		else if (Application.isWebPlayer)
		{
			Application.targetFrameRate = 300;
		}
		else
		{
			Application.targetFrameRate = -1;
		}
	}

	public virtual void Main()
	{
	}
}
