using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class BotOffAim : MonoBehaviour
{
	public SpawningScript src;

	public BotSpawner bspawn;

	public PauseObject pobj;

	private Transform ptarget;

	public virtual void setTarget(Transform t)
	{
		ptarget = t;
	}

	public virtual void Update()
	{
		if (((PhotonView)this.transform.parent.GetComponent(typeof(PhotonView))).isMine)
		{
			GameObject[] a = GameObject.FindGameObjectsWithTag("Bot");
			float num = UnityEngine.Random.Range((float)(-(UnityScript.Lang.Extensions.get_length((System.Array)a) + 5)) * PauseObject.bacc, (float)(UnityScript.Lang.Extensions.get_length((System.Array)a) + 5) * PauseObject.bacc);
			float num2 = UnityEngine.Random.Range((float)(-(UnityScript.Lang.Extensions.get_length((System.Array)a) + 5)) * PauseObject.bacc, (float)(UnityScript.Lang.Extensions.get_length((System.Array)a) + 5) * PauseObject.bacc);
			float num3 = UnityEngine.Random.Range((float)(-(UnityScript.Lang.Extensions.get_length((System.Array)a) + 5)) * PauseObject.bacc, (float)(UnityScript.Lang.Extensions.get_length((System.Array)a) + 5) * PauseObject.bacc);
			if (ptarget != SpawningScript.playertrans)
			{
				a = GameObject.FindGameObjectsWithTag("AttackBot");
				num = UnityEngine.Random.Range((float)(-(UnityScript.Lang.Extensions.get_length((System.Array)a) + 5)) * 0.65f, (float)(UnityScript.Lang.Extensions.get_length((System.Array)a) + 5) * 0.65f);
				num2 = UnityEngine.Random.Range((float)(-(UnityScript.Lang.Extensions.get_length((System.Array)a) + 5)) * 0.65f, (float)(UnityScript.Lang.Extensions.get_length((System.Array)a) + 5) * 0.65f);
				num3 = UnityEngine.Random.Range((float)(-(UnityScript.Lang.Extensions.get_length((System.Array)a) + 5)) * 0.65f, (float)(UnityScript.Lang.Extensions.get_length((System.Array)a) + 5) * 0.65f);
			}
			Transform transform = ((!this.transform.root.gameObject.name.Contains("Attack")) ? BotSpawner.hiveMindTarget : ptarget);
			Vector3 forward = new Vector3(transform.position.x + num, transform.position.y + num3, transform.position.z + num2) - this.transform.position;
			this.transform.rotation = Quaternion.LookRotation(forward);
		}
	}

	public virtual void Main()
	{
	}
}
