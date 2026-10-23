using System;
using UnityEngine;

[Serializable]
public class soldierAnimation : MonoBehaviour
{
	public AnimationCurve idleBlendCurve;

	public AnimationCurve walkBlendCurve;

	public AnimationCurve runBlendCurve;

	public AnimationCurve sprintBlendCurve;

	public AnimationCurve strafeBlendCurve;

	public AnimationCurve turnBlendCurve;

	public AnimationCurve animationSpeedCurve;

	public AnimationCurve turnAnimationSpeedCurve;

	public AnimationCurve fallingBlendCurve;

	public AnimationCurve landingDurationCurve;

	public AnimationCurve hitBlendCurve;

	public float tiltMultiplier;

	public float idleBlend;

	public float walkBlend;

	public float runBlend;

	public float sprintBlend;

	public float strafeBlend;

	public float turnBlend;

	public float animationSpeed;

	public float turnAnimationSpeed;

	public float fallingBlend;

	public float landingDuration;

	public float landingInhibit;

	public float landingBlend;

	public float crouchIdleBlend;

	public float crouchRunBlend;

	public float crouchSprintBlend;

	public float crouchStrafeBlend;

	public float crouchTurnBlend;

	public float hitBlend;

	public float dieBlend;

	private Quaternion soldierRotation;

	private float verticalSpeed;

	private Vector3 lastPosition;

	private float lastYRotation;

	private float tilt;

	private bool backward;

	private float backwardBuffer;

	private float lastLandingTime;

	private bool isFalling;

	private float startedFallingTime;

	private bool isGrounded;

	private float hitStartTime;

	private GunAndCameraBob crouchControllerScript;

	private FPSGunFire weaponControllerScript;

	private health healthScript;

	public ParticleEmitter[] feetPackParticles;

	public bool emitParticles;

	public soldierAnimation()
	{
		tiltMultiplier = 1f;
		backwardBuffer = 0.5f;
	}

	public virtual void Start()
	{
		soldierRotation = Quaternion.identity;
		float num = 0f;
		float num2 = 0f;
		float num3 = 0f;
		crouchControllerScript = (GunAndCameraBob)transform.root.GetComponent(typeof(GunAndCameraBob));
		weaponControllerScript = (FPSGunFire)transform.root.GetComponent(typeof(FPSGunFire));
		healthScript = (health)transform.root.GetComponent("health");
	}

	public virtual void LateUpdate()
	{
		bool flag = false;
		if (weaponControllerScript != null)
		{
			flag = weaponControllerScript.firing;
		}
		float num = 1f;
		float num2 = 0f;
		float num3 = 1f;
		if (crouchControllerScript != null)
		{
			num = 1f - crouchControllerScript.globalCrouchBlend;
			num2 = 1f - num;
			num3 = crouchControllerScript.crouchSpeedMultiplier;
		}
		float num4 = default(float);
		Vector3 vector = default(Vector3);
		float num5 = default(float);
		float num6 = default(float);
		if (healthScript != null)
		{
			num4 = healthScript.GetLastHitTime();
			vector = healthScript.GetHitDirection();
			num5 = healthScript.healthPoints;
			num6 = healthScript.GetDeathTime();
		}
		Vector3 direction = (this.transform.position - lastPosition) / Time.deltaTime;
		float num7 = verticalSpeed;
		verticalSpeed = (this.transform.position.y - lastPosition.y) / Time.deltaTime;
		float num8 = (this.transform.position - lastPosition).magnitude / Time.deltaTime;
		lastPosition = this.transform.position;
		float z = default(float);
		float x = default(float);
		float num9 = default(float);
		if (isGrounded)
		{
			z = this.transform.InverseTransformDirection(direction).z;
			x = this.transform.InverseTransformDirection(direction).x;
			num9 = Mathf.DeltaAngle(lastYRotation, this.transform.rotation.eulerAngles.y);
		}
		int i = 0;
		ParticleEmitter[] array = feetPackParticles;
		for (int length = array.Length; i < length; i++)
		{
			if (array[i].emit != emitParticles)
			{
				array[i].emit = emitParticles;
			}
		}
		lastYRotation = this.transform.rotation.eulerAngles.y;
		float num10 = 0.3f;
		Vector3 origin = this.transform.position + Vector3.up * num10;
		Ray ray = new Ray(origin, Vector3.down);
		float distance = num10 * 2f;
		RaycastHit hitInfo = default(RaycastHit);
		if (Physics.Raycast(ray, out hitInfo, distance))
		{
			isGrounded = true;
		}
		else
		{
			isGrounded = false;
		}
		float num11 = -0.5f;
		if (!isFalling && !(verticalSpeed >= num11) && !isGrounded)
		{
			isFalling = true;
			startedFallingTime = Time.time;
		}
		float num12 = 0f;
		if (isFalling && !(verticalSpeed <= num11))
		{
			isFalling = false;
			lastLandingTime = Time.time;
			num12 = lastLandingTime - startedFallingTime;
			landingDuration = landingDurationCurve.Evaluate(num12);
		}
		float num13 = default(float);
		num13 = ((Time.time <= startedFallingTime || !isFalling) ? 0f : (Time.time - startedFallingTime));
		float num14 = 1f - hitBlend;
		float num15 = 1f - dieBlend;
		float num16 = 0.2f;
		fallingBlend = fallingBlendCurve.Evaluate(num13);
		fallingBlend *= num15;
		animation.Blend("soldierFalling", fallingBlend, num16);
		float num17 = Mathf.Pow(Mathf.Abs(1f - fallingBlend), 2f);
		if (!(Time.time >= lastLandingTime + landingDuration))
		{
			float num18 = Time.time - lastLandingTime;
			float f = num18 / landingDuration;
			f = Mathf.Pow(f, 0.6f);
			landingBlend = 1f - f;
			float num19 = Mathf.Clamp01(1f - landingDuration);
			animation["soldierLanding"].time = Mathf.Lerp(num19, 1f, f);
			animation.Blend("soldierLanding", landingBlend, 0.05f);
			landingInhibit = Mathf.Pow(1f - landingBlend, 2f);
		}
		else
		{
			landingBlend = 0f;
			landingDuration = 0f;
			float num19 = 0f;
			landingInhibit = 1f;
		}
		float num20 = idleBlendCurve.Evaluate(Mathf.Abs(z / 5f) + Mathf.Abs(x));
		num20 -= Mathf.Abs(num9) * 0.8f;
		num20 *= num17;
		num20 *= landingInhibit;
		num20 *= num;
		num20 *= num14;
		num20 *= num15;
		animation.Blend("soldierIdle", num20, num16);
		walkBlend = walkBlendCurve.Evaluate(Mathf.Abs(z) / 5f);
		walkBlend *= num17;
		walkBlend *= landingInhibit;
		walkBlend *= num;
		walkBlend *= num15;
		walkBlend = Mathf.Clamp01(walkBlend);
		animation.Blend("soldierWalk", walkBlend, num16);
		runBlend = runBlendCurve.Evaluate(Mathf.Abs(z) / 5f);
		runBlend *= num17;
		runBlend *= landingInhibit;
		runBlend *= num;
		runBlend *= num15;
		animation.Blend("soldierRun", runBlend, num16);
		sprintBlend = sprintBlendCurve.Evaluate(z / 5f);
		sprintBlend *= num17;
		sprintBlend *= landingInhibit;
		sprintBlend *= num;
		sprintBlend *= num15;
		animation.Blend("soldierSprint", sprintBlend, num16);
		strafeBlend = strafeBlendCurve.Evaluate(Mathf.Abs(x));
		strafeBlend *= num17;
		strafeBlend *= landingInhibit;
		strafeBlend *= num;
		strafeBlend *= num15;
		if (!(z <= backwardBuffer))
		{
			backward = false;
		}
		if (!(z >= 0f - backwardBuffer))
		{
			backward = true;
		}
		if (!backward)
		{
			if (!(x <= 0f))
			{
				animation.Blend("soldierStrafeRight", strafeBlend, num16);
				animation.Blend("soldierStrafeLeft", 0f, num16);
			}
			else
			{
				animation.Blend("soldierStrafeLeft", strafeBlend, num16);
				animation.Blend("soldierStrafeRight", 0f, num16);
			}
		}
		else if (!(x <= 0f))
		{
			animation.Blend("soldierStrafeLeft", strafeBlend, num16);
			animation.Blend("soldierStrafeRight", 0f, num16);
		}
		else
		{
			animation.Blend("soldierStrafeRight", strafeBlend, num16);
			animation.Blend("soldierStrafeLeft", 0f, num16);
		}
		turnBlend = turnBlendCurve.Evaluate(Mathf.Abs(num9));
		turnBlend -= num8;
		turnBlend = Mathf.Clamp01(turnBlend);
		turnBlend *= num;
		turnBlend *= num15;
		if (!(num9 <= 0f))
		{
			animation.Blend("soldierSpinRight", turnBlend, num16);
			animation.Blend("soldierSpinLeft", 0f, num16);
		}
		else
		{
			animation.Blend("soldierSpinLeft", turnBlend, num16);
			animation.Blend("soldierSpinRight", 0f, num16);
		}
		if (crouchControllerScript != null)
		{
			float num21 = 1f / num3;
			crouchIdleBlend = idleBlendCurve.Evaluate((Mathf.Abs(z) + Mathf.Abs(x)) * num21);
			crouchIdleBlend -= Mathf.Abs(num9) * 0.8f;
			crouchIdleBlend *= num17;
			crouchIdleBlend *= landingInhibit;
			crouchIdleBlend *= num2;
			crouchIdleBlend *= num15;
			animation.Blend("soldierCrouch", crouchIdleBlend, 0.05f);
			crouchRunBlend = runBlendCurve.Evaluate(Mathf.Abs(z) * num21);
			crouchRunBlend *= num17;
			crouchRunBlend *= landingInhibit;
			crouchRunBlend *= num2;
			crouchRunBlend *= num15;
			animation.Blend("soldierCrouchRun", crouchRunBlend, 0.05f);
			crouchSprintBlend = sprintBlendCurve.Evaluate(z * num21);
			crouchSprintBlend *= num17;
			crouchSprintBlend *= landingInhibit;
			crouchSprintBlend *= num2;
			crouchSprintBlend *= num15;
			animation.Blend("soldierCrouchSprint", crouchSprintBlend, 0.05f);
			crouchStrafeBlend = strafeBlendCurve.Evaluate(Mathf.Abs(x) * num21);
			crouchStrafeBlend *= num17;
			crouchStrafeBlend *= landingInhibit;
			crouchStrafeBlend *= num2;
			crouchStrafeBlend *= num15;
			if (!backward)
			{
				if (!(x <= 0f))
				{
					animation.Blend("soldierCrouchStrafeRight", crouchStrafeBlend, num16 * 2f);
					animation.Blend("soldierCrouchStrafeLeft", 0f, num16 * 2f);
				}
				else
				{
					animation.Blend("soldierCrouchStrafeLeft", crouchStrafeBlend, num16 * 2f);
					animation.Blend("soldierCrouchStrafeRight", 0f, num16 * 2f);
				}
			}
			else if (!(x <= 0f))
			{
				animation.Blend("soldierCrouchStrafeLeft", crouchStrafeBlend, num16 * 2f);
				animation.Blend("soldierCrouchStrafeRight", 0f, num16 * 2f);
			}
			else
			{
				animation.Blend("soldierCrouchStrafeRight", crouchStrafeBlend, num16 * 2f);
				animation.Blend("soldierCrouchStrafeLeft", 0f, num16 * 2f);
			}
			crouchTurnBlend = turnBlendCurve.Evaluate(Mathf.Abs(num9));
			crouchTurnBlend -= num8;
			crouchTurnBlend = Mathf.Clamp01(crouchTurnBlend);
			crouchTurnBlend *= num2;
			crouchTurnBlend *= num15;
			if (!(num9 <= 0f))
			{
				animation.Blend("soldierCrouchSpinRight", crouchTurnBlend, num16);
				animation.Blend("soldierCrouchSpinLeft", 0f, num16);
			}
			else
			{
				animation.Blend("soldierCrouchSpinLeft", crouchTurnBlend, num16);
				animation.Blend("soldierCrouchSpinRight", 0f, num16);
			}
		}
		float time = Time.time - num4;
		float num22 = hitBlendCurve.Evaluate(time);
		hitBlend = num22;
		hitBlend *= num15;
		float targetWeight = hitBlend * Mathf.Max(vector.z, 0f);
		animation.Blend("soldierHitFront", targetWeight, num16);
		float targetWeight2 = hitBlend * (0f - Mathf.Min(vector.z, 0f));
		animation.Blend("soldierHitBack", targetWeight2, num16);
		float targetWeight3 = hitBlend * Mathf.Max(vector.x, 0f);
		animation.Blend("soldierHitRight", targetWeight3, num16);
		float targetWeight4 = hitBlend * (0f - Mathf.Min(vector.x, 0f));
		animation.Blend("soldierHitLeft", targetWeight4, num16);
		float num23 = default(float);
		float num24 = 1.4f;
		num23 = (backward ? (0f - animationSpeedCurve.Evaluate(num8)) : animationSpeedCurve.Evaluate(num8));
		animation["soldierWalk"].speed = num23;
		animation["soldierRun"].speed = num23;
		animation["soldierSprint"].speed = num23;
		animation["soldierStrafeRight"].speed = num23;
		animation["soldierStrafeLeft"].speed = num23;
		animation["soldierCrouchRun"].speed = num23;
		animation["soldierCrouchSprint"].speed = num23;
		animation["soldierCrouchStrafeRight"].speed = num23;
		animation["soldierCrouchStrafeLeft"].speed = num23;
		float speed = turnAnimationSpeedCurve.Evaluate(Mathf.Abs(num9));
		animation["soldierSpinRight"].speed = speed;
		animation["soldierSpinLeft"].speed = speed;
		animation["soldierCrouchSpinRight"].speed = speed;
		animation["soldierCrouchSpinLeft"].speed = speed;
		if (flag)
		{
			Transform transform = this.transform.Find("Bip01/Bip01 Pelvis/Bip01 Spine/Bip01 Spine1");
			Transform transform2 = transform.Find("Bip01 Spine2");
			float z2 = transform.localRotation.eulerAngles.z + Mathf.Sin(Time.time * 50f) * 0.5f;
			Quaternion localRotation = transform.localRotation;
			Vector3 eulerAngles = localRotation.eulerAngles;
			float num25 = (eulerAngles.z = z2);
			Vector3 vector2 = (localRotation.eulerAngles = eulerAngles);
			Quaternion quaternion = (transform.localRotation = localRotation);
			float z3 = transform2.localRotation.eulerAngles.z + Mathf.Sin(Time.time * 50f - 1f) * 0.5f;
			Quaternion localRotation2 = transform2.localRotation;
			Vector3 eulerAngles2 = localRotation2.eulerAngles;
			float num26 = (eulerAngles2.z = z3);
			Vector3 vector4 = (localRotation2.eulerAngles = eulerAngles2);
			Quaternion quaternion3 = (transform2.localRotation = localRotation2);
		}
		float f2 = Mathf.DeltaAngle(this.transform.rotation.eulerAngles.y, this.transform.root.rotation.eulerAngles.y);
		float num27 = Mathf.Pow(Mathf.Abs(f2), 2.5f) * Mathf.Sign(f2) / 80f;
		num27 *= num15;
		float y = soldierRotation.eulerAngles.y + num27 * Time.deltaTime;
		Vector3 eulerAngles3 = soldierRotation.eulerAngles;
		float num28 = (eulerAngles3.y = y);
		Vector3 vector6 = (soldierRotation.eulerAngles = eulerAngles3);
		this.transform.rotation = soldierRotation;
		float value = (0f - num27) * 0.01f * z * tiltMultiplier;
		value = Mathf.Clamp(value, -10f, 10f);
		tilt = Mathf.Lerp(tilt, value, Time.deltaTime * 7f);
		if (!(Mathf.Abs(verticalSpeed) <= 1f))
		{
			tilt /= Mathf.Abs(verticalSpeed);
		}
		float z4 = tilt;
		Quaternion localRotation3 = this.transform.localRotation;
		Vector3 eulerAngles4 = localRotation3.eulerAngles;
		float num29 = (eulerAngles4.z = z4);
		Vector3 vector8 = (localRotation3.eulerAngles = eulerAngles4);
		Quaternion quaternion5 = (this.transform.localRotation = localRotation3);
	}

	public virtual void Main()
	{
	}
}
