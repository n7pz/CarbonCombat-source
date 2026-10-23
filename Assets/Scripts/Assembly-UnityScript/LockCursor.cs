using System;
using UnityEngine;

[Serializable]
public class LockCursor : MonoBehaviour
{
	public virtual void Start()
	{
		Screen.lockCursor = true;
	}

	public virtual void Update()
	{
		if (Input.GetAxis("Fire1") != 0f)
		{
			Screen.lockCursor = true;
		}
	}

	public virtual void Main()
	{
	}
}
