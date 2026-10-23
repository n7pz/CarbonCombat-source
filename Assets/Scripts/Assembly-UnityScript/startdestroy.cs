using System;
using UnityEngine;

[Serializable]
public class startdestroy : MonoBehaviour
{
	public Transform[] effects;

	public virtual void Awake()
	{
		gameObject.SetActiveRecursively(true);
		transform.DetachChildren();
		int i = 0;
		Transform[] array = effects;
		for (int length = array.Length; i < length; i++)
		{
			array[i].transform.position = new Vector3(0.5f, 0.5f, 0f);
		}
		UnityEngine.Object.Destroy(gameObject);
	}

	public virtual void Main()
	{
	}
}
