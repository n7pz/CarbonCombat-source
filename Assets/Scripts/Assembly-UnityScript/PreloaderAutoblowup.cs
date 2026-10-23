using System;
using UnityEngine;

[Serializable]
public class PreloaderAutoblowup : MonoBehaviour
{
	public GameObject explosion;

	public virtual void OnTriggerExit(Collider col)
	{
		if (col.gameObject.name == "PreloaderRed(Clone)" || col.gameObject.name == "PreloaderBlue(Clone)")
		{
			UnityEngine.Object.Instantiate(explosion, col.transform.position, col.transform.rotation);
			UnityEngine.Object.Destroy(col.gameObject);
			Camera.main.SendMessage("SpawnObj", 1);
		}
	}

	public virtual void Main()
	{
	}
}
