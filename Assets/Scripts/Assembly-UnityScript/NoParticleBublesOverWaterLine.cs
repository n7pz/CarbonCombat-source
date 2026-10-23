using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class NoParticleBublesOverWaterLine : MonoBehaviour
{
	public virtual void Update()
	{
		Particle[] particles = particleEmitter.particles;
		int[] array = new int[UnityScript.Lang.Extensions.get_length((System.Array)particles)];
		int num = 0;
		for (int i = 0; i < particleEmitter.particleCount; i++)
		{
			if (!(particles[i].position.y >= 11.5f))
			{
				array[num++] = i;
			}
		}
		Particle[] array2 = new Particle[num];
		for (int j = 0; j < num; j++)
		{
			array2[j] = particles[array[j]];
		}
		particleEmitter.particles = array2;
	}

	public virtual void Main()
	{
	}
}
