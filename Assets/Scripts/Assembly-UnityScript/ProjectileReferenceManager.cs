using System;
using System.Collections;
using Boo.Lang.Runtime;
using Photon;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class ProjectileReferenceManager : Photon.MonoBehaviour
{
	[NonSerialized]
	public static Hashtable itemHashtable = new Hashtable();

	public virtual void Awake()
	{
		itemHashtable.Clear();
	}

	public virtual void AllocateNewId(GameObject obj, int id)
	{
		itemHashtable.Add(id, obj);
	}

	[RPC]
	public virtual void shotgunBulletHit(Vector3 pos, Quaternion rot, string user, int id)
	{
		if (itemHashtable.ContainsKey(id) && RuntimeServices.ToBool(itemHashtable[id]))
		{
			UnityRuntimeServices.Invoke(RuntimeServices.Invoke(itemHashtable[id], "GetComponent", new object[1] { typeof(LowPolyBulletExplode) }), "bulletHit", new object[4] { pos, rot, user, id }, typeof(UnityEngine.MonoBehaviour));
		}
		else
		{
			UnAllocateId(id);
		}
	}

	[RPC]
	public virtual void bulletHit(Vector3 pos, Quaternion rot, string user, int id)
	{
		if (itemHashtable.ContainsKey(id) && RuntimeServices.ToBool(itemHashtable[id]))
		{
			UnityRuntimeServices.Invoke(RuntimeServices.Invoke(itemHashtable[id], "GetComponent", new object[1] { typeof(LowPolyBulletExplode) }), "bulletHit", new object[4] { pos, rot, user, id }, typeof(UnityEngine.MonoBehaviour));
		}
		else
		{
			UnAllocateId(id);
		}
	}

	[RPC]
	public virtual void laserhit(Vector3 pos, Quaternion rot, string user, int id)
	{
		if (itemHashtable.ContainsKey(id) && RuntimeServices.ToBool(itemHashtable[id]))
		{
			UnityRuntimeServices.Invoke(RuntimeServices.Invoke(itemHashtable[id], "GetComponent", new object[1] { typeof(LaserSplat) }), "laserhit", new object[3] { pos, rot, user }, typeof(UnityEngine.MonoBehaviour));
		}
		else
		{
			UnAllocateId(id);
		}
	}

	[RPC]
	public virtual void rocketblowup(Vector3 pos, Quaternion rot, string user, int id)
	{
		if (itemHashtable.ContainsKey(id) && RuntimeServices.ToBool(itemHashtable[id]))
		{
			UnityRuntimeServices.Invoke(RuntimeServices.Invoke(itemHashtable[id], "GetComponent", new object[1] { typeof(RocketBlowup) }), "rocketblowup", new object[3] { pos, rot, user }, typeof(UnityEngine.MonoBehaviour));
		}
		else
		{
			UnAllocateId(id);
		}
	}

	[RPC]
	public virtual void networkExplode(Vector3 pos, Quaternion rot, string user, int id)
	{
		if (itemHashtable.ContainsKey(id) && RuntimeServices.ToBool(itemHashtable[id]))
		{
			UnityRuntimeServices.Invoke(RuntimeServices.Invoke(itemHashtable[id], "GetComponent", new object[1] { typeof(GrenadeExploder) }), "networkExplode", new object[3] { pos, rot, user }, typeof(UnityEngine.MonoBehaviour));
		}
		else
		{
			UnAllocateId(id);
		}
	}

	public virtual void UnAllocateId(int id)
	{
		if (itemHashtable.ContainsKey(id))
		{
			itemHashtable.Remove(id);
		}
	}

	public virtual void Main()
	{
	}
}
