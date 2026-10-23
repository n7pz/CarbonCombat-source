using System;
using UnityEngine;

[Serializable]
public class muzzleFlashGenerator : MonoBehaviour
{
	public GameObject muzzleFlashPrefab;

	public Material[] materials;

	public float rate;

	public bool on;

	private float nextMuzzleFlashTime;

	public muzzleFlashGenerator()
	{
		rate = 8f;
		on = true;
	}

	public virtual void Update()
	{
		if (on && !(Time.time <= nextMuzzleFlashTime))
		{
			nextMuzzleFlashTime = Time.time + 1f / rate;
			GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(muzzleFlashPrefab, transform.position, transform.rotation);
			int num = Mathf.RoundToInt(UnityEngine.Random.Range(0, materials.Length));
			gameObject.renderer.material = materials[num];
			gameObject.transform.parent = transform;
		}
	}

	public virtual void Main()
	{
	}
}
