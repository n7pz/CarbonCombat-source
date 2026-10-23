using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class NetArray
{
	public UnityScript.Lang.Array arr;

	public bool isRed;

	public Transform trans;

	public int objectType;

	public NetArray()
	{
		arr = new UnityScript.Lang.Array();
	}
}
