using System;
using UnityEngine;

[Serializable]
public class ExplosionDebrisManager : MonoBehaviour
{
	public float radius;

	public float power;

	public ExplosionDebrisManager()
	{
		radius = 5f;
		power = 10f;
	}

	public virtual void Start()
	{
		Vector3 position = transform.position;
		Collider[] array = Physics.OverlapSphere(position, radius);
		int i = 0;
		Collider[] array2 = array;
		for (int length = array2.Length; i < length; i++)
		{
			if ((bool)array2[i] && (bool)array2[i].rigidbody)
			{
				array2[i].rigidbody.AddExplosionForce(power, position, radius, 3f);
			}
		}
	}

	public virtual void Main()
	{
	}
}
