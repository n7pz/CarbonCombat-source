using System;
using UnityEngine;

[Serializable]
public class TestingScript : MonoBehaviour
{
	public virtual void Update()
	{
		Debug.Log(Vector3.Angle(transform.right, Vector3.up));
	}

	public virtual void Main()
	{
	}
}
