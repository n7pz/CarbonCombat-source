using System;
using UnityEngine;

[Serializable]
[RequireComponent(typeof(CharacterController))]
public class soldierMovement : MonoBehaviour
{
	public float forwardSpeedMultiplier;

	public float strafeSpeedMultiplier;

	public float turnSpeedMultiplier;

	public float gravity;

	public Transform soldier;

	public float turnSpeed;

	public float forwardSpeed;

	public float strafeSpeed;

	public bool isGrounded;

	private float stopAfterLanding;

	private float fallSpeed;

	private float lastGroundedTime;

	private float lastLandingTime;

	private float targetForwardSpeed;

	private float targetStrafeSpeed;

	private crouchController crouchControllerScript;

	private bool isFalling;

	private health healthScript;

	private float recoilAmount;

	private float recoilAmountTarget;

	public soldierMovement()
	{
		forwardSpeedMultiplier = 3f;
		strafeSpeedMultiplier = 2f;
		turnSpeedMultiplier = 6f;
		gravity = 9.8f;
	}

	public virtual void Start()
	{
		crouchControllerScript = (crouchController)GetComponent("crouchController");
		healthScript = (health)GetComponent("health");
		isFalling = false;
	}

	public virtual void Update()
	{
		float num = 0.5f;
		Vector3 origin = transform.position + Vector3.up * num;
		Ray ray = new Ray(origin, Vector3.down);
		float distance = num * 2f;
		RaycastHit hitInfo = default(RaycastHit);
		if (Physics.Raycast(ray, out hitInfo, distance))
		{
			if (hitInfo.transform.root != transform)
			{
				isGrounded = true;
				float y = hitInfo.point.y;
				Vector3 position = transform.position;
				float num2 = (position.y = y);
				Vector3 vector = (transform.position = position);
			}
		}
		else
		{
			isGrounded = false;
		}
		CharacterController characterController = (CharacterController)GetComponent(typeof(CharacterController));
		Vector3 vector3 = Vector3.zero;
		float num3 = 1f;
		float num4 = 1f;
		if (healthScript != null)
		{
			float lastHitTime = healthScript.GetLastHitTime();
			Vector3 vector4 = healthScript.GetrecoilDirecion();
			float num5 = 0.6f;
			float num6 = Time.time - lastHitTime;
			float num7 = 0f;
			if (!(num6 >= num5) && lastHitTime != 0f)
			{
				num7 = num5 - num6;
				num7 *= 1f - Mathf.Abs(Input.GetAxis("Vertical"));
				num7 *= 1f - Mathf.Abs(Input.GetAxis("Horizontal"));
			}
			if (!(recoilAmount >= num7))
			{
				recoilAmount = Mathf.Lerp(recoilAmount, num7, Time.deltaTime);
			}
			else
			{
				recoilAmount = Mathf.Lerp(recoilAmount, num7, Time.deltaTime * 20f);
			}
			float num8 = recoilAmount;
			num8 /= num5;
			num8 = Mathf.Pow(num8, 2f);
			num8 *= num5;
			vector3 = vector4 * num8;
			num3 = 1f - recoilAmount * 0.65f / num5;
			float num9 = healthScript.healthPoints;
			num4 = ((num9 > 0f) ? 1f : 0f);
		}
		if (isGrounded)
		{
			if (isFalling)
			{
				isFalling = false;
				lastLandingTime = Time.time;
				stopAfterLanding = (lastLandingTime - lastGroundedTime) * 2f;
			}
			fallSpeed = 0f;
		}
		else
		{
			if (!isFalling)
			{
				isFalling = true;
				lastGroundedTime = Time.time;
			}
			fallSpeed += gravity * Time.deltaTime;
		}
		Vector3 vector5 = default(Vector3);
		vector5.y -= fallSpeed;
		if (isGrounded)
		{
			targetForwardSpeed = Input.GetAxis("Vertical");
			targetStrafeSpeed = Input.GetAxis("Horizontal");
			targetForwardSpeed *= forwardSpeedMultiplier;
			targetStrafeSpeed *= strafeSpeedMultiplier;
			if (!(Input.GetAxis("Vertical") >= 0f))
			{
				targetForwardSpeed *= 0.5f;
			}
			if (Input.GetKey(KeyCode.LeftShift))
			{
				targetForwardSpeed *= 1.5f;
				targetStrafeSpeed *= 1.5f;
			}
		}
		if (crouchControllerScript != null)
		{
			targetForwardSpeed = Mathf.Lerp(targetForwardSpeed, targetForwardSpeed * crouchControllerScript.crouchSpeedMultiplier, crouchControllerScript.globalCrouchBlend);
		}
		if (!(Time.time > lastLandingTime + stopAfterLanding) && !(stopAfterLanding <= 0.5f))
		{
			float num10 = Time.time - lastLandingTime;
			float num11 = Mathf.Pow(num10 / stopAfterLanding, 1.5f);
			targetForwardSpeed *= num11;
			targetStrafeSpeed *= num11;
		}
		forwardSpeed = Mathf.Lerp(forwardSpeed, targetForwardSpeed, Time.deltaTime * 15f);
		strafeSpeed = Mathf.Lerp(strafeSpeed, targetStrafeSpeed, Time.deltaTime * 15f);
		vector5 += soldier.forward * forwardSpeed * num3 * num4;
		vector5 += soldier.right * strafeSpeed * num3 * num4;
		vector5 += vector3;
		characterController.Move(vector5 * Time.deltaTime);
		float num12 = 0f;
		num12 = Input.GetAxis("Mouse X");
		num12 *= Mathf.Pow(turnSpeedMultiplier, 3f);
		num12 *= num4;
		turnSpeed = Mathf.Lerp(turnSpeed, num12, Time.deltaTime * 25f);
		float y2 = transform.rotation.eulerAngles.y + turnSpeed * Time.deltaTime;
		Quaternion rotation = transform.rotation;
		Vector3 eulerAngles = rotation.eulerAngles;
		float num13 = (eulerAngles.y = y2);
		Vector3 vector6 = (rotation.eulerAngles = eulerAngles);
		Quaternion quaternion = (transform.rotation = rotation);
	}

	public virtual void Main()
	{
	}
}
