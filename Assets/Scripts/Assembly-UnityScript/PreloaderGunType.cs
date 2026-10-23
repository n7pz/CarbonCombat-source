using System;
using UnityEngine;

[Serializable]
public class PreloaderGunType : MonoBehaviour
{
	public GameObject[] guns;

	public Renderer gunrenderer;

	public virtual void Start()
	{
		int num = UnityEngine.Random.Range(0, 2);
		guns[0].SetActiveRecursively(false);
		guns[1].SetActiveRecursively(false);
		guns[num].SetActiveRecursively(true);
	}

	public virtual void Main()
	{
	}
}
