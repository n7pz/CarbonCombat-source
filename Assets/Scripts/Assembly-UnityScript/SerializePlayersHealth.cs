using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class SerializePlayersHealth : MonoBehaviour
{
	public virtual void updatehealth(object i)
	{
		if (((PhotonView)transform.root.GetComponent(typeof(PhotonView))).isMine)
		{
			gameObject.name = Mathf.Round(RuntimeServices.UnboxSingle(i)).ToString();
		}
	}

	public virtual void Main()
	{
	}
}
