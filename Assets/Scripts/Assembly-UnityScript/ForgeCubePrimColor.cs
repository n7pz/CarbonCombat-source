using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class ForgeCubePrimColor : MonoBehaviour
{
	public int curColor;

	public Color[] colorArr;

	public ForgeCubePrimColor()
	{
		curColor = 6;
		colorArr = new Color[8];
	}

	public virtual void toggleColor()
	{
		if (curColor < UnityScript.Lang.Extensions.get_length((System.Array)colorArr) - 1)
		{
			curColor++;
		}
		else
		{
			curColor = 0;
		}
		renderer.material.color = colorArr[curColor];
	}

	public virtual void setInitColor(int c)
	{
		curColor = c;
		renderer.material.color = colorArr[c];
	}

	public virtual void Main()
	{
	}
}
