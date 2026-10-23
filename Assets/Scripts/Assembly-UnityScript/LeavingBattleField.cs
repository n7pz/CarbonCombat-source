using System;
using Boo.Lang.Runtime;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class LeavingBattleField : MonoBehaviour
{
	public GameObject borderdel;

	public int id;

	public EndofRound endofround;

	public CalculateHealth calchealth;

	private ChatScript cscript;

	private TutorialManager tMan;

	private AuthGameObject authobj;

	private bool sendonce;

	public LeavingBattleField()
	{
		sendonce = true;
	}

	public virtual void OnTriggerEnter(Collider col)
	{
		if (!(EndofRound.alphastat > 0f))
		{
			if (col.transform.gameObject.name == "CarPrefab(Clone)" && ((PhotonView)col.transform.gameObject.GetComponent(typeof(PhotonView))).isMine && ChatScript.isCar && !RuntimeServices.ToBool(UnityRuntimeServices.GetProperty(col.transform.gameObject.GetComponent("AIManager"), "enabled")))
			{
				borderdel.SendMessage("enter", id);
			}
			if (col.transform.gameObject.name == "HumanPrefab(Clone)" && ((PhotonView)col.transform.gameObject.GetComponent(typeof(PhotonView))).isMine && !ChatScript.isCar)
			{
				borderdel.SendMessage("enter", id);
			}
		}
	}

	public virtual void Start()
	{
		if (AuthGameObject.showTutorial)
		{
			collider.isTrigger = false;
		}
	}

	public virtual void Update()
	{
		if (!(EndofRound.alphastat <= 0f) && sendonce)
		{
			sendonce = false;
			borderdel.SendMessage("exit", id);
		}
		if (CalculateHealth.isafking && sendonce)
		{
			sendonce = false;
			borderdel.SendMessage("exit", id);
		}
		if (!(EndofRound.alphastat > 0f) && !CalculateHealth.isafking)
		{
			sendonce = true;
		}
	}

	public virtual void OnTriggerExit(Collider col)
	{
		if (col.transform.gameObject.name == "CarPrefab(Clone)" && ((PhotonView)col.transform.gameObject.GetComponent(typeof(PhotonView))).isMine && !RuntimeServices.ToBool(UnityRuntimeServices.GetProperty(col.transform.gameObject.GetComponent("AIManager"), "enabled")) && ChatScript.isCar)
		{
			borderdel.SendMessage("exit", id);
		}
		if (col.transform.gameObject.name == "HumanPrefab(Clone)" && ((PhotonView)col.transform.gameObject.GetComponent(typeof(PhotonView))).isMine && !ChatScript.isCar)
		{
			borderdel.SendMessage("exit", id);
		}
	}

	public virtual void Main()
	{
	}
}
