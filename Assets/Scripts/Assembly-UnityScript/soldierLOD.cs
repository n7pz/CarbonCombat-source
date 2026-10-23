using System;
using UnityEngine;

[Serializable]
public class soldierLOD : MonoBehaviour
{
	public Transform soldierCamera;

	public GameObject[] lodPrefabs;

	public float[] lodDistances;

	public GameObject soldierCharacter;

	private int currentLod;

	public virtual void Update()
	{
		float num = Vector3.Distance(soldierCamera.position, soldierCharacter.transform.position);
		int num2 = lodPrefabs.Length - 1;
		for (int i = 0; i < lodDistances.Length; i++)
		{
			if (i == 0)
			{
				if (!(num >= lodDistances[i]))
				{
					num2 = 0;
				}
			}
			else if (!(num >= lodDistances[i]) && !(num <= lodDistances[i - 1]))
			{
				num2 = i;
			}
		}
		if (num2 != currentLod)
		{
			SetLod(num2);
		}
	}

	public virtual void SetLod(int lod)
	{
		UnityEngine.Object.Destroy(soldierCharacter);
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(lodPrefabs[lod], transform.position, transform.rotation);
		gameObject.transform.parent = transform;
		gameObject.name = "soldierCharacter";
		soldierCharacter = gameObject;
		currentLod = lod;
	}

	public virtual void Main()
	{
	}
}
