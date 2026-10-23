using System;
using UnityEngine;

[Serializable]
[RequireComponent(typeof(soldierMovement))]
[RequireComponent(typeof(crouchController))]
public class weaponController : MonoBehaviour
{
	public string gunLocaion;

	public float aimSpeed;

	private bool firing;

	private Transform gun;

	private Transform crosshair;

	private float accuracyLoss;

	private float accuracyLossTarget;

	private float shootingAimLoss;

	private float vibratingAimLoss;

	private bool isSprinting;

	private gun gunScript;

	private crosshair crosshairScript;

	private soldierMovement soldierMovementScript;

	private crouchController crouchControllerScript;

	private health healthScript;

	public weaponController()
	{
		gunLocaion = "soldierCharacter/Bip01/Bip01 Pelvis/Bip01 Spine/Bip01 Spine1/Bip01 Spine2/Bip01 Neck/Bip01 R Clavicle/Bip01 R UpperArm/Bip01 R Forearm/Bip01 R Hand/gun";
		aimSpeed = 5f;
	}

	public virtual void Start()
	{
		gun = transform.Find(gunLocaion);
		crosshair = transform.Find("crosshair");
		gunScript = (gun)gun.GetComponent("gun");
		crosshairScript = (crosshair)crosshair.GetComponent("crosshair");
		soldierMovementScript = (soldierMovement)GetComponent("soldierMovement");
		crouchControllerScript = (crouchController)GetComponent("crouchController");
		healthScript = (health)GetComponent("health");
	}

	public virtual void Update()
	{
		float num = 100f;
		if (healthScript != null)
		{
			num = healthScript.GetHealth();
		}
		bool isGrounded = soldierMovementScript.isGrounded;
		if (Input.GetMouseButton(0) && !isSprinting && isGrounded && !(num <= 0f))
		{
			firing = true;
			gunScript.firing = firing;
		}
		else
		{
			firing = false;
			gunScript.firing = firing;
		}
		float num2 = 1f + crouchControllerScript.globalCrouchBlend * 10f;
		float turnSpeed = soldierMovementScript.turnSpeed;
		float forwardSpeed = soldierMovementScript.forwardSpeed;
		float strafeSpeed = soldierMovementScript.strafeSpeed;
		accuracyLossTarget = 1f;
		if (!(forwardSpeed <= soldierMovementScript.forwardSpeedMultiplier * 1.2f))
		{
			isSprinting = true;
			accuracyLossTarget += 1f;
		}
		else
		{
			isSprinting = false;
		}
		if (gunScript.firing)
		{
			shootingAimLoss = Mathf.Lerp(shootingAimLoss, 2f, Time.deltaTime * 2f);
			crosshairScript.yOffset += UnityEngine.Random.Range(0f, 0.5f) * Time.deltaTime;
			crosshairScript.xOffset += UnityEngine.Random.Range(-0.05f, shootingAimLoss * 0.1f) * Time.deltaTime;
		}
		else
		{
			shootingAimLoss = Mathf.Lerp(shootingAimLoss, 0f, Time.deltaTime * 20f);
		}
		vibratingAimLoss = shootingAimLoss + Mathf.Sin(Time.time * 80f) * shootingAimLoss * 0.5f;
		accuracyLossTarget += vibratingAimLoss;
		accuracyLossTarget += Mathf.Pow(Mathf.Abs(forwardSpeed * 2f + strafeSpeed * 2f), 0.1f);
		accuracyLossTarget += Mathf.Pow(Mathf.Pow(Mathf.Abs(turnSpeed), 2.3f) / Mathf.Pow(10f, 4f), 0.35f);
		accuracyLossTarget += (1f - crouchControllerScript.globalCrouchBlend) * 0.5f;
		if (!(accuracyLoss <= accuracyLossTarget))
		{
			accuracyLoss = Mathf.Lerp(accuracyLoss, accuracyLossTarget, Time.deltaTime * aimSpeed * num2 * 0.5f);
		}
		else
		{
			accuracyLoss = Mathf.Lerp(accuracyLoss, accuracyLossTarget, Time.deltaTime * aimSpeed);
		}
		crosshairScript.accuracyLoss = accuracyLoss;
		accuracyLoss = Mathf.Max(accuracyLoss, 1f);
		float accuracy = 1f / accuracyLoss;
		gunScript.accuracy = accuracy;
	}

	public virtual bool isFiring()
	{
		return firing;
	}

	public virtual void Main()
	{
	}
}
