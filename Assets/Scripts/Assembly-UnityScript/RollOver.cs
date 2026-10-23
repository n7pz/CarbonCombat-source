using System;
using Photon;
using UnityEngine;

[Serializable]
public class RollOver : Photon.MonoBehaviour
{
	public Rigidbody maincar;

	public WheelCollider wheel1;

	public WheelCollider wheel2;

	public WheelCollider wheel3;

	public WheelCollider wheel4;

	private float counter;

	private bool messagesend;

	private bool starttimer;

	private GameObject GUIobj;

	public AIManager aimanager;

	public RollOver()
	{
		counter = 2f;
	}

	public virtual void Start()
	{
		if (photonView.isMine && !aimanager.isAI)
		{
			GUIobj = GameObject.Find("FlipGUI");
		}
		else
		{
			enabled = false;
		}
	}

	public virtual void OnTriggerEnter(Collider objenter)
	{
		if (photonView.isMine && objenter.gameObject.name != "WaterTrigger" && objenter.gameObject.name != "RainDropWater" && objenter.gameObject.name != "RollOverCol" && objenter.gameObject.name != "CarPrefab(Clone)" && objenter.gameObject.name != "LaserPrefab(Clone)" && objenter.gameObject.name != "RocketPrefab(Clone)" && objenter.gameObject.name != "MainBoxCol" && objenter.gameObject.name != "LowPolyCasingPrefab(Clone)" && objenter.gameObject.name != "GrenadePrefab(Clone" && !objenter.attachedRigidbody && !objenter.collider.isTrigger)
		{
			int num = 0;
			if (wheel1.isGrounded)
			{
				num++;
			}
			if (wheel2.isGrounded)
			{
				num++;
			}
			if (wheel3.isGrounded)
			{
				num++;
			}
			if (wheel4.isGrounded)
			{
				num++;
			}
			if (num < 3)
			{
				starttimer = true;
			}
		}
	}

	public virtual void OnTriggerExit(Collider col)
	{
		if (photonView.isMine && !aimanager.isAI)
		{
			GUIobj.SendMessage("disable", gameObject);
			messagesend = false;
			starttimer = false;
		}
	}

	public virtual void Update()
	{
		if (!photonView.isMine)
		{
			return;
		}
		if (wheel1.isGrounded && wheel2.isGrounded && wheel3.isGrounded && wheel4.isGrounded)
		{
			counter = 2f;
			GUIobj.SendMessage("disable", gameObject);
			messagesend = false;
			starttimer = false;
		}
		if (starttimer)
		{
			if (!(counter <= 0f))
			{
				counter -= Time.deltaTime;
				return;
			}
			GUIobj.SendMessage("enable", maincar);
			messagesend = true;
			starttimer = false;
		}
	}

	public virtual void Main()
	{
	}
}
