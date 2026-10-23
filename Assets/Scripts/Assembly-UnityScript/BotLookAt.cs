using System;
using UnityEngine;

[Serializable]
public class BotLookAt : MonoBehaviour
{
	public SpawningScript src;

	public BotSpawner bspawn;

	public BotAI mainsrc;

	private Transform ptarget;

	public virtual void setTarget(Transform t)
	{
		ptarget = t;
	}

	public virtual void Update()
	{
		if (!transform.root.gameObject.name.Contains("Attack"))
		{
			ptarget = BotSpawner.hiveMindTarget;
		}
		if (((PhotonView)transform.parent.GetComponent(typeof(PhotonView))).isMine && ptarget != null)
		{
			if (!BotAI.disbot)
			{
				transform.LookAt(ptarget);
			}
			else
			{
				transform.LookAt(BotAI.lkl);
			}
		}
	}

	public virtual void Main()
	{
	}
}
