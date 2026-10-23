using System;
using UnityEngine;

[Serializable]
public class ObjectiveArrow : MonoBehaviour
{
	public virtual void OnTriggerEnter()
	{
		GameObject.Find("ObjManager").SendMessage("AddObj");
	}

	public virtual void Main()
	{
	}
}
