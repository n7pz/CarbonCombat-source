using System;
using UnityEngine;

[Serializable]
public class SetCameraFPSTag : MonoBehaviour
{
	public string whattag;

	public AIManager aimanager;

	public SetCameraFPSTag()
	{
		whattag = "MyCameraView";
	}

	public virtual void Start()
	{
		if (((PhotonView)transform.root.gameObject.GetComponent(typeof(PhotonView))).isMine && !aimanager.isAI)
		{
			gameObject.tag = whattag;
		}
		else
		{
			gameObject.tag = "Untagged";
		}
	}

	public virtual void Main()
	{
	}
}
