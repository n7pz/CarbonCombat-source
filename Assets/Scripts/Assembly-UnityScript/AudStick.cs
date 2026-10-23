using System;
using UnityEngine;

[Serializable]
public class AudStick : MonoBehaviour
{
	public GameObject followg;

	public virtual void sticksound(GameObject g)
	{
		followg = g;
	}

	public virtual void Update()
	{
		if (followg != null)
		{
			transform.position = followg.transform.position;
		}
	}

	public virtual void Main()
	{
	}
}
