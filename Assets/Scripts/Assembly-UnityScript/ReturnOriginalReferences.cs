using System;
using Photon;
using UnityEngine;

[Serializable]
public class ReturnOriginalReferences : Photon.MonoBehaviour
{
	public Component[] origRefs;

	public virtual void Awake()
	{
		origRefs = gameObject.GetComponentsInChildren(typeof(PhotonView), true);
	}

	public virtual void Main()
	{
	}
}
