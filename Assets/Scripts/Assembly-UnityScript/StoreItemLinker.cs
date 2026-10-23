using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class StoreItemLinker : MonoBehaviour
{
	public GameObject[] linkedItems;

	public virtual void OnEnable()
	{
		for (int i = 0; i < UnityScript.Lang.Extensions.get_length((System.Array)linkedItems); i++)
		{
			if (!linkedItems[i].active)
			{
				linkedItems[i].active = true;
			}
		}
	}

	public virtual void OnDisable()
	{
		for (int i = 0; i < UnityScript.Lang.Extensions.get_length((System.Array)linkedItems); i++)
		{
			if (linkedItems[i].active)
			{
				linkedItems[i].active = false;
			}
		}
	}

	public virtual void Main()
	{
	}
}
