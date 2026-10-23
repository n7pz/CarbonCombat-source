using System;
using UnityEngine;

[Serializable]
public class DisableNotVisible : MonoBehaviour
{
	public virtual void OnBecameInvisible()
	{
		enabled = false;
	}

	public virtual void OnBecameVisible()
	{
		enabled = true;
	}

	public virtual void Main()
	{
	}
}
