using System;
using System.Collections;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class ConduitInputReciever : MonoBehaviour
{
	[NonSerialized]
	public static Hashtable ht = new Hashtable();

	private CrossHairDraw cD;

	public virtual void Start()
	{
		UnityEngine.Object.DontDestroyOnLoad(transform.gameObject);
		ht.Add("sWep", false);
		ht.Add("uIt", false);
		ht.Add("eCar", false);
		ht.Add("jump", false);
		ht.Add("dPad", Vector2.zero);
		ht.Add("tPad", Vector2.zero);
		ht.Add("tPadAlt", Vector2.zero);
		ht.Add("tPadState", false);
	}

	public virtual void setKey(string arg)
	{
		string[] array = arg.Split("|"[0]);
		ht[array[0]] = ((!(array[1] == "0")) ? true : false);
	}

	public virtual void setVector(string arg)
	{
		string[] array = arg.Split("|"[0]);
		Vector2 vector = new Vector2(UnityBuiltins.parseFloat(array[1].Split(","[0])[0]), UnityBuiltins.parseFloat(array[1].Split(","[0])[1]));
		ht[array[0]] = vector;
		if (array[0] == "tPad")
		{
			CrossHairDraw.useCursor = false;
			ht["tPadAlt"] = vector;
		}
	}

	public virtual void Main()
	{
	}
}
