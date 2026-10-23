using System;
using UnityEngine;

[Serializable]
public class HumanRamdeath : MonoBehaviour
{
	public virtual void OnTriggerEnter(Collider col)
	{
		if (!(col.gameObject.name == "MainBoxCol") && !(col.gameObject.name == "CarPrefab(Clone)"))
		{
			return;
		}
		if (((PhotonView)transform.root.gameObject.GetComponent(typeof(PhotonView))).isMine)
		{
			if (col.transform.root != ((FPSCalculateHealth)transform.root.gameObject.GetComponent(typeof(FPSCalculateHealth))).spawnedFromCar.transform)
			{
				string user = ((ReturnName)col.gameObject.GetComponent(typeof(ReturnName))).nameobject.name;
				int level = 1;
				float damage = 150f;
				string action = "rammed";
				string weaponUsed = "vehicle";
				bool hasLevel = false;
				((FPSCalculateHealth)transform.root.gameObject.GetComponent(typeof(FPSCalculateHealth))).damageDelegate(user, level, damage, action, weaponUsed, hasLevel);
			}
		}
		else if (((PhotonView)col.gameObject.GetComponent(typeof(PhotonView))).isMine)
		{
			((CharacterController)transform.parent.GetComponent(typeof(CharacterController))).detectCollisions = false;
			if (col.gameObject.name == "CarPrefab(Clone)")
			{
				col.rigidbody.velocity = col.rigidbody.velocity * 0.45f;
			}
			else
			{
				col.transform.root.rigidbody.velocity = col.transform.root.rigidbody.velocity * 0.45f;
			}
			((PhotonView)transform.root.gameObject.GetComponent(typeof(PhotonView))).RPC("networkedRam", PhotonTargets.All, ((ReturnName)col.gameObject.GetComponent(typeof(ReturnName))).nameobject.name);
		}
	}

	public virtual void OnTriggerExit(Collider col)
	{
		if ((col.gameObject.name == "MainBoxCol" || col.gameObject.name == "CarPrefab(Clone)") && ((PhotonView)col.gameObject.GetComponent(typeof(PhotonView))).isMine)
		{
			((CharacterController)transform.parent.GetComponent(typeof(CharacterController))).detectCollisions = true;
		}
	}

	public virtual void Main()
	{
	}
}
