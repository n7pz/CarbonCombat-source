using System;
using System.Collections;
using UnityEngine;

[Serializable]
public class CheckIfSpaceIsClear : MonoBehaviour
{
	public bool isClear;

	private Hashtable colliderArr;

	public CheckIfSpaceIsClear()
	{
		isClear = true;
		colliderArr = new Hashtable();
	}

	public virtual void OnTriggerEnter(Collider col)
	{
		if (!colliderArr.ContainsKey(col) && col.transform.root != transform.root && (Rigidbody)col.GetComponent(typeof(Rigidbody)) == null)
		{
			colliderArr.Add(col, true);
		}
	}

	public virtual void OnTriggerExit(Collider col)
	{
		if (colliderArr.ContainsKey(col) && col.transform.root != transform.root)
		{
			colliderArr.Remove(col);
		}
	}

	public virtual void Update()
	{
		if (colliderArr.Count > 0)
		{
			isClear = false;
		}
		else
		{
			isClear = true;
		}
	}

	public virtual void Main()
	{
	}
}
