using System;
using Photon;
using UnityEngine;

[Serializable]
[RequireComponent(typeof(PhotonView))]
public class SetTagBasedOnNV : Photon.MonoBehaviour
{
	public string TagIfTrue;

	public string TagIfFalse;

	public bool clearTagOnLoad;

	public virtual void Awake()
	{
		if (clearTagOnLoad)
		{
			gameObject.tag = "Untagged";
		}
	}

	public virtual void Start()
	{
		if (photonView.isMine)
		{
			gameObject.tag = TagIfTrue;
		}
		else
		{
			gameObject.tag = TagIfFalse;
		}
	}

	public virtual void Main()
	{
	}
}
