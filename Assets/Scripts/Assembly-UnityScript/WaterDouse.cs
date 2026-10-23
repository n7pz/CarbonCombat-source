using System;
using UnityEngine;

[Serializable]
public class WaterDouse : MonoBehaviour
{
	public ParticleEmitter part1;

	public ParticleEmitter part2;

	public virtual void killsmoke()
	{
		part1.emit = false;
		part2.emit = false;
	}

	public virtual void Main()
	{
	}
}
