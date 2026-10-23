using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class findcollideparticles : MonoBehaviour
{
	public float burstEnergy;

	public Transform explosionObject;

	public Transform maincar;

	public SpawningScript spwnsrc;

	public findcollideparticles()
	{
		burstEnergy = 10f;
	}

	public virtual void LateUpdate()
	{
		maincar = SpawningScript.playertrans;
		Particle[] particles = particleEmitter.particles;
		int[] array = new int[UnityScript.Lang.Extensions.get_length((System.Array)particles)];
		int num = 0;
		for (int i = 0; i < particleEmitter.particleCount; i++)
		{
			if (!(particles[i].energy <= burstEnergy))
			{
				particles[i].color = Color.yellow;
				if ((bool)explosionObject)
				{
					UnityEngine.Object.Instantiate(explosionObject, particles[i].position, Quaternion.identity);
				}
			}
			else
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
		int num2 = 0;
		Quaternion rotation = transform.rotation;
		Vector3 eulerAngles = rotation.eulerAngles;
		float num3 = (eulerAngles.x = num2);
		Vector3 vector = (rotation.eulerAngles = eulerAngles);
		Quaternion quaternion = (transform.rotation = rotation);
		int num4 = 0;
		Quaternion rotation2 = transform.rotation;
		Vector3 eulerAngles2 = rotation2.eulerAngles;
		float num5 = (eulerAngles2.z = num4);
		Vector3 vector3 = (rotation2.eulerAngles = eulerAngles2);
		Quaternion quaternion3 = (transform.rotation = rotation2);
		if ((bool)maincar)
		{
			float x = maincar.position.x;
			Vector3 position = transform.position;
			float num6 = (position.x = x);
			Vector3 vector5 = (transform.position = position);
			float z = maincar.position.z;
			Vector3 position2 = transform.position;
			float num7 = (position2.z = z);
			Vector3 vector7 = (transform.position = position2);
		}
		int num8 = 140;
		Vector3 localPosition = transform.localPosition;
		float num9 = (localPosition.y = num8);
		Vector3 vector9 = (transform.localPosition = localPosition);
	}

	public virtual void Main()
	{
	}
}
