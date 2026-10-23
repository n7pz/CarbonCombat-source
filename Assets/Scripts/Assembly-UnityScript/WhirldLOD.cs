using System;
using UnityEngine;

[Serializable]
public class WhirldLOD : MonoBehaviour
{
	public GameObject[] lodObjs;

	public int lodLevMax;

	[HideInInspector]
	public int level;

	private int lastLevel;

	public WhirldLOD()
	{
		lastLevel = -1;
	}

	public virtual void Start()
	{
	}

	public virtual void SetLOD()
	{
	}

	public virtual void Main()
	{
	}
}
