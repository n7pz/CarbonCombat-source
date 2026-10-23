using System;
using Photon;
using UnityEngine;

[Serializable]
public class HumanSplash : Photon.MonoBehaviour
{
	public GameObject splashPrefab;

	private WhirldIn win;

	private AuthGameObject authobj;

	private bool isUnderwater;

	public virtual void Update()
	{
		if (!(transform.position.y - 3f > 11.5f) && (WhirldIn.hassea || AuthGameObject.whirldurl == string.Empty) && !isUnderwater)
		{
			isUnderwater = true;
			UnityEngine.Object.Instantiate(splashPrefab, new Vector3(transform.position.x, 11.5f, transform.position.z), Quaternion.Euler(0f, 0f, 0f));
			if (photonView.isMine)
			{
				((CharacterMotor)gameObject.GetComponent(typeof(CharacterMotor))).movement.maxForwardSpeed = ((CharacterMotor)gameObject.GetComponent(typeof(CharacterMotor))).movement.maxForwardSpeed / 2.5f;
				((CharacterMotor)gameObject.GetComponent(typeof(CharacterMotor))).movement.maxSidewaysSpeed = ((CharacterMotor)gameObject.GetComponent(typeof(CharacterMotor))).movement.maxSidewaysSpeed / 2.5f;
				((CharacterMotor)gameObject.GetComponent(typeof(CharacterMotor))).movement.maxBackwardsSpeed = ((CharacterMotor)gameObject.GetComponent(typeof(CharacterMotor))).movement.maxBackwardsSpeed / 2.5f;
				((CharacterMotor)gameObject.GetComponent(typeof(CharacterMotor))).movement.maxGroundAcceleration = ((CharacterMotor)gameObject.GetComponent(typeof(CharacterMotor))).movement.maxGroundAcceleration / 2.5f;
				((CharacterMotor)gameObject.GetComponent(typeof(CharacterMotor))).movement.maxAirAcceleration = ((CharacterMotor)gameObject.GetComponent(typeof(CharacterMotor))).movement.maxAirAcceleration / 2.5f;
				((CharacterMotor)gameObject.GetComponent(typeof(CharacterMotor))).movement.gravity = ((CharacterMotor)gameObject.GetComponent(typeof(CharacterMotor))).movement.gravity / 2.5f;
				((CharacterMotor)gameObject.GetComponent(typeof(CharacterMotor))).movement.maxFallSpeed = ((CharacterMotor)gameObject.GetComponent(typeof(CharacterMotor))).movement.maxFallSpeed / 2.5f;
			}
		}
		if (!(transform.position.y - 3f <= 11.5f) && (WhirldIn.hassea || AuthGameObject.whirldurl == string.Empty) && isUnderwater)
		{
			isUnderwater = false;
			UnityEngine.Object.Instantiate(splashPrefab, new Vector3(transform.position.x, 11.5f, transform.position.z), Quaternion.Euler(0f, 0f, 0f));
			if (photonView.isMine)
			{
				((CharacterMotor)gameObject.GetComponent(typeof(CharacterMotor))).movement.maxForwardSpeed = ((CharacterMotor)gameObject.GetComponent(typeof(CharacterMotor))).movement.maxForwardSpeed * 2.5f;
				((CharacterMotor)gameObject.GetComponent(typeof(CharacterMotor))).movement.maxSidewaysSpeed = ((CharacterMotor)gameObject.GetComponent(typeof(CharacterMotor))).movement.maxSidewaysSpeed * 2.5f;
				((CharacterMotor)gameObject.GetComponent(typeof(CharacterMotor))).movement.maxBackwardsSpeed = ((CharacterMotor)gameObject.GetComponent(typeof(CharacterMotor))).movement.maxBackwardsSpeed * 2.5f;
				((CharacterMotor)gameObject.GetComponent(typeof(CharacterMotor))).movement.maxGroundAcceleration = ((CharacterMotor)gameObject.GetComponent(typeof(CharacterMotor))).movement.maxGroundAcceleration * 2.5f;
				((CharacterMotor)gameObject.GetComponent(typeof(CharacterMotor))).movement.maxAirAcceleration = ((CharacterMotor)gameObject.GetComponent(typeof(CharacterMotor))).movement.maxAirAcceleration * 2.5f;
				((CharacterMotor)gameObject.GetComponent(typeof(CharacterMotor))).movement.gravity = ((CharacterMotor)gameObject.GetComponent(typeof(CharacterMotor))).movement.gravity * 2.5f;
				((CharacterMotor)gameObject.GetComponent(typeof(CharacterMotor))).movement.maxFallSpeed = ((CharacterMotor)gameObject.GetComponent(typeof(CharacterMotor))).movement.maxFallSpeed * 2.5f;
			}
		}
	}

	public virtual void Main()
	{
	}
}
