using System;
using UnityEngine;

[Serializable]
public class particleAutoDestroy : MonoBehaviour
{
	public float life;

	private float destroyTime;

	public virtual void Start()
	{
		destroyTime = Time.time + life;
	}

	public virtual void Update()
	{
		if (!(Time.time <= destroyTime))
		{
			UnityEngine.Object.Destroy(gameObject);
		}
		if (!(Time.time <= destroyTime - particleEmitter.maxEnergy))
		{
			particleEmitter.emit = false;
		}
	}

	public virtual void Main()
	{
	}
}
