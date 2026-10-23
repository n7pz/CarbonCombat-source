using System;
using UnityEngine;

[Serializable]
public class fadeParticles : MonoBehaviour
{
	public AnimationCurve particleFade;

	public Color color;

	public float minSize;

	public float maxSize;

	public virtual void Update()
	{
		Particle[] particles = particleEmitter.particles;
		for (int i = 0; i < particles.Length; i++)
		{
			particles[i].color = this.color;
			float a = particleFade.Evaluate(1f - particles[i].energy / particles[i].startEnergy);
			Color color = particles[i].color;
			float num = (color.a = a);
			Color color2 = (particles[i].color = color);
			float num2 = particleEmitter.maxEnergy - particleEmitter.minEnergy;
			float num3 = particles[i].startEnergy - particleEmitter.minEnergy;
			float t = num3 / num2;
			particles[i].size = Mathf.Lerp(minSize, maxSize, t);
		}
		particleEmitter.particles = particles;
	}

	public virtual void Main()
	{
	}
}
