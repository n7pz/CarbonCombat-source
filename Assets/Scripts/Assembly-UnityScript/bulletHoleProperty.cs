using System;
using UnityEngine;

[Serializable]
public class bulletHoleProperty : MonoBehaviour
{
	public GameObject extraPrefab;

	public Material[] bulletMaterials;

	public float sizeModifier;

	public bool dust;

	public bool hole;

	public bulletHoleProperty()
	{
		sizeModifier = 1f;
		dust = true;
		hole = true;
	}

	public virtual void Main()
	{
	}
}
