using System;
using UnityEngine;

[Serializable]
public class FlameLocalScript : MonoBehaviour
{
	private bool penabled;

	public FlameLocalScript()
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
			particleEmitter.useWorldSpace = false;
		}
		if (!penabled && particleEmitter.emit)
		{
			particleEmitter.emit = false;
			particleEmitter.useWorldSpace = true;
		}
	}

	public virtual void Main()
	{
	}
}
