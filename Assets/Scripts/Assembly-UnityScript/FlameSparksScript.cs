using System;
using UnityEngine;

[Serializable]
public class FlameSparksScript : MonoBehaviour
{
	private bool penabled;

	public FlameSparksScript()
	{
		penabled = true;
	}

	public virtual void setEnable(bool t)
	{
		penabled = t;
	}

	public virtual void Update()
	{
		if (penabled && !particleEmitter.emit)
		{
			particleEmitter.emit = true;
		}
		if (!penabled && particleEmitter.emit)
		{
			particleEmitter.emit = false;
		}
	}

	public virtual void Main()
	{
	}
}
