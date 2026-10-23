using System;
using UnityEngine;

[Serializable]
public class PreloaderDamage : MonoBehaviour
{
	private int myhealth;

	public GameObject explosion;

	public GameObject maincar;

	public PreloaderDamage()
	{
		myhealth = 100;
	}

	public virtual void DoDamage()
	{
		myhealth -= 35;
		if (myhealth <= 0)
		{
			UnityEngine.Object.Instantiate(explosion, transform.position, transform.rotation);
			Camera.main.SendMessage("SpawnObj", 1);
			UnityEngine.Object.Destroy(maincar);
		}
	}

	public virtual void Main()
	{
	}
}
