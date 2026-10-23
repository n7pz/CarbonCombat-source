using System;
using UnityEngine;

[Serializable]
public class health : MonoBehaviour
{
	public float healthPoints;

	private float lastHitTime;

	private Vector3 hitDirection;

	private Vector3 recoilDirecion;

	private float deathTime;

	private bool alive;

	public health()
	{
		alive = true;
	}

	public virtual void Update()
	{
		if (!(healthPoints > 0f) && alive)
		{
			alive = false;
			deathTime = Time.time;
		}
		if (!(healthPoints <= 0f))
		{
			alive = true;
		}
		healthPoints = Mathf.Max(healthPoints, 0f);
	}

	public virtual void SetLastHitTime()
	{
		lastHitTime = Time.time;
	}

	public virtual void SetLastHitTime(float setTime)
	{
		lastHitTime = setTime;
	}

	public virtual float GetLastHitTime()
	{
		return lastHitTime;
	}

	public virtual void SetHitDirection(Vector3 direction)
	{
		hitDirection = direction;
	}

	public virtual Vector3 GetHitDirection()
	{
		return hitDirection;
	}

	public virtual void SetrecoilDirecion(Vector3 direction)
	{
		recoilDirecion = direction;
	}

	public virtual Vector3 GetrecoilDirecion()
	{
		return recoilDirecion;
	}

	public virtual float GetDeathTime()
	{
		return deathTime;
	}

	public virtual void SetHealth(float newHealth)
	{
		healthPoints = newHealth;
	}

	public virtual float GetHealth()
	{
		return healthPoints;
	}

	public virtual void Main()
	{
	}
}
