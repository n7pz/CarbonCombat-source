using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class DontDestroyOnLoad : MonoBehaviour
{
	[NonSerialized]
	public static string hitcollider;

	public virtual void Awake()
	{
		string text = gameObject.name;
		string[] array = text.Split("|"[0]);
		string lhs = string.Empty;
		for (int num = UnityScript.Lang.Extensions.get_length((System.Array)array) - 1; num > -1; num--)
		{
			lhs += array[num];
		}
		hitcollider = lhs;
	}

	public virtual void Main()
	{
	}
}
