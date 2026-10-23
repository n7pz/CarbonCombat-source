using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class dustCloudGenerator : MonoBehaviour
{
	public GameObject dustCloudPrefab;

	public float rate;

	public Material[] materials;

	public bool on;

	public float life;

	private float nextdustCloudTime;

	private float destroyTime;

	private Vector3 velocity;

	public dustCloudGenerator()
	{
		rate = 8f;
		on = true;
		life = 0.3f;
	}

	public virtual void Start()
	{
		destroyTime = Time.time + life;
	}

	public virtual void Update()
	{
		if (!(Time.time <= destroyTime))
		{
			UnityEngine.Object.Destroy(this.gameObject);
		}
		if (!(Time.time <= nextdustCloudTime))
		{
			nextdustCloudTime = Time.time + 1f / rate;
			GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(dustCloudPrefab, transform.position, transform.rotation);
			int num = Mathf.RoundToInt(UnityEngine.Random.Range(0, materials.Length - 1));
			gameObject.renderer.material = materials[num];
			RuntimeServices.SetProperty(gameObject.GetComponent("dustCloud"), "velocity", velocity);
		}
	}

	public virtual void Main()
	{
	}
}
