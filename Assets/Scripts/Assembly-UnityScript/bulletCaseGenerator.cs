using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class bulletCaseGenerator : MonoBehaviour
{
	public GameObject bulletCasePrefab;

	public float rate;

	public Vector3 velocity;

	public bool on;

	private float nextbulletCaseTime;

	public bulletCaseGenerator()
	{
		rate = 8f;
		on = true;
	}

	public virtual void Update()
	{
		if (on && !(Time.time <= nextbulletCaseTime))
		{
			nextbulletCaseTime = Time.time + 1f / rate;
			GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(bulletCasePrefab, transform.position, transform.rotation);
			RuntimeServices.SetProperty(gameObject.GetComponent("bulletCase"), "velocity", transform.TransformDirection(velocity) + UnityEngine.Random.insideUnitSphere * 0.3f);
		}
	}

	public virtual void Main()
	{
	}
}
