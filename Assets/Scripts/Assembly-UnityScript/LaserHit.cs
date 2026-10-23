using System;
using Boo.Lang.Runtime;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class LaserHit : MonoBehaviour
{
	public float radius;

	public float power;

	public LaserHit()
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
				if (array2[i].gameObject.name == "CarPrefab(Clone)" && RuntimeServices.ToBool(UnityRuntimeServices.GetProperty(array2[i].gameObject.GetComponent("PlayerCar_Script"), "isShockResistant")))
				{
					power *= 0.2f;
				}
				array2[i].rigidbody.AddExplosionForce(power, position, radius);
			}
		}
	}

	public virtual void Main()
	{
	}
}
