using System;
using UnityEngine;

[Serializable]
public class WInRefresher : MonoBehaviour
{
	public virtual void Awake()
	{
		UnityEngine.Object.DontDestroyOnLoad(this);
		if (gameObject.name.Contains("Clone"))
		{
			gameObject.name = "WhirldIn";
		}
	}

	public virtual void Main()
	{
	}
}
