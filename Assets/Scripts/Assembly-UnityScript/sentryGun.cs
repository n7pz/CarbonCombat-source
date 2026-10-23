using System;
using UnityEngine;

[Serializable]
public class sentryGun : MonoBehaviour
{
	public string[] targetRootName;

	public GameObject explosionPrefab;

	public GameObject blackSmokePrefab;

	private float rotatorAngleScan;

	private float rotatorAcceleration;

	private bool firing;

	private bulletTraceGenerator bulletTraceGeneratorScript;

	private muzzleFlashGenerator muzzleFlashGeneratorScript;

	private spinningTurret spinningTurretScript;

	private Transform @base;

	private Transform rotator;

	private Transform pitch;

	private Transform barrel;

	private Transform bulletTraceGenerator;

	private Transform muzzleFlashGenerator;

	private Transform laserSight;

	private laserSight laserSightScript;

	private bool exploded;

	private bool foundTarget;

	private float lastTargetfoundTime;

	private float targetBufferTime;

	private Transform targetTransform;

	private float sentryHealth;

	private health healthScript;

	private float rotatorSpeed;

	private float rotatorMaxSpeed;

	private float rotatorAngleTarget;

	private float rotatorDirection;

	private float rotatorChangeDirectionTime;

	private float rotatorChangeDirectionDelay;

	private float pitchAngle;

	private float pitchVelocity;

	private float pitchTarget;

	private float deadPitchAngle;

	public sentryGun()
	{
		rotatorAngleScan = 35f;
		rotatorAcceleration = 5f;
		rotatorMaxSpeed = 60f;
		rotatorDirection = 1f;
		rotatorChangeDirectionDelay = 1f;
		deadPitchAngle = 30f;
	}

	public virtual void Start()
	{
		@base = transform.Find("sentryGunBase");
		rotator = @base.Find("sentryGunRotator");
		pitch = rotator.Find("sentryGunPitch");
		barrel = pitch.Find("sentryGunBarrel");
		bulletTraceGenerator = barrel.Find("bulletTraceGenerator");
		muzzleFlashGenerator = barrel.Find("muzzleFlashGenerator");
		spinningTurretScript = (spinningTurret)barrel.GetComponent("spinningTurret");
		bulletTraceGeneratorScript = (bulletTraceGenerator)bulletTraceGenerator.GetComponent("bulletTraceGenerator");
		muzzleFlashGeneratorScript = (muzzleFlashGenerator)muzzleFlashGenerator.GetComponent("muzzleFlashGenerator");
		laserSight = pitch.Find("laserSight");
		laserSightScript = (laserSight)laserSight.GetComponent("laserSight");
		targetBufferTime = 2f;
		healthScript = (health)GetComponent("health");
	}

	public virtual void Update()
	{
		float num = healthScript.healthPoints;
		float speed = spinningTurretScript.speed;
		float maxSpeed = spinningTurretScript.maxSpeed;
		if (!(speed <= maxSpeed * 0.8f))
		{
			bulletTraceGeneratorScript.on = firing;
			muzzleFlashGeneratorScript.on = firing;
		}
		else
		{
			bulletTraceGeneratorScript.on = false;
			muzzleFlashGeneratorScript.on = false;
		}
		spinningTurretScript.on = firing;
		if (bulletTraceGeneratorScript.on)
		{
			rigidbody.AddForceAtPosition(bulletTraceGenerator.up * Time.deltaTime * UnityEngine.Random.value * 1900f, bulletTraceGenerator.position);
		}
		if (!(num > 0f) && !exploded)
		{
			exploded = true;
			UnityEngine.Object.Instantiate(explosionPrefab, pitch.position, pitch.rotation);
			rigidbody.AddForce(Vector3.up * 400f);
			GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(blackSmokePrefab, pitch.position, pitch.rotation);
			gameObject.transform.parent = transform;
		}
		if (barrel.position.y < transform.position.y + 0.2f || num == 0f)
		{
			collider.enabled = false;
			@base.collider.enabled = true;
			@base.collider.isTrigger = false;
			rotator.collider.enabled = true;
			rotator.collider.isTrigger = false;
			pitch.collider.enabled = true;
			pitch.collider.isTrigger = false;
			barrel.collider.enabled = true;
			barrel.collider.isTrigger = false;
			firing = false;
			laserSightScript.on = false;
			rotatorSpeed = Mathf.Lerp(rotatorSpeed, 0f, Time.deltaTime * rotatorAcceleration);
		}
		else
		{
			sentryAI();
		}
		float z = rotator.localRotation.eulerAngles.z + rotatorSpeed * Time.deltaTime;
		Quaternion localRotation = rotator.localRotation;
		Vector3 eulerAngles = localRotation.eulerAngles;
		float num2 = (eulerAngles.z = z);
		Vector3 vector = (localRotation.eulerAngles = eulerAngles);
		Quaternion quaternion = (rotator.localRotation = localRotation);
		if (!(num <= 0f))
		{
			pitchAngle = 4f;
		}
		else
		{
			pitchTarget = deadPitchAngle;
			if (!(pitchAngle <= pitchTarget + 1f))
			{
				pitchVelocity -= 3f * Time.deltaTime;
			}
			if (!(pitchAngle >= pitchTarget - 1f))
			{
				pitchVelocity += 3f * Time.deltaTime;
			}
			pitchVelocity = Mathf.Lerp(pitchVelocity, 0f, Time.deltaTime * 5f);
			pitchAngle += pitchVelocity;
		}
		if (!(pitchAngle <= deadPitchAngle))
		{
			pitchVelocity *= -1f;
		}
		float x = pitchAngle;
		Quaternion localRotation2 = pitch.localRotation;
		Vector3 eulerAngles2 = localRotation2.eulerAngles;
		float num3 = (eulerAngles2.x = x);
		Vector3 vector3 = (localRotation2.eulerAngles = eulerAngles2);
		Quaternion quaternion3 = (pitch.localRotation = localRotation2);
	}

	public virtual void sentryAI()
	{
		RaycastHit hitInfo = default(RaycastHit);
		if (Physics.Raycast(bulletTraceGenerator.position, bulletTraceGenerator.forward, out hitInfo))
		{
			bool flag = false;
			for (int i = 0; i < targetRootName.Length; i++)
			{
				if (hitInfo.transform.root.name == targetRootName[i])
				{
					flag = true;
				}
			}
			if (flag)
			{
				foundTarget = true;
				lastTargetfoundTime = Time.time;
				if (targetTransform == null)
				{
					targetTransform = hitInfo.transform;
				}
			}
		}
		if (targetTransform == null)
		{
			foundTarget = false;
			firing = false;
		}
		if (foundTarget)
		{
			firing = true;
			Vector3 position = targetTransform.position;
			position.y = rotator.position.y;
			Vector3 vector = position - rotator.position;
			float num = Vector3.Angle(vector, -rotator.up);
			float x = rotator.InverseTransformPoint(position).x;
			if (!(x <= 0f))
			{
				rotatorSpeed = Mathf.Lerp(rotatorSpeed, rotatorMaxSpeed, Time.deltaTime * rotatorAcceleration);
			}
			else
			{
				rotatorSpeed = Mathf.Lerp(rotatorSpeed, 0f - rotatorMaxSpeed, Time.deltaTime * rotatorAcceleration);
			}
		}
		if (!(Time.time <= lastTargetfoundTime + targetBufferTime))
		{
			foundTarget = false;
			targetTransform = null;
			firing = false;
			float num2 = rotator.localRotation.eulerAngles.z;
			if (!(num2 <= 180f))
			{
				num2 -= 360f;
			}
			if (rotatorDirection == 0f)
			{
				rotatorChangeDirectionTime = Time.time + rotatorChangeDirectionDelay;
				if (!(num2 <= 0f))
				{
					rotatorDirection = -1f;
				}
				else
				{
					rotatorDirection = 1f;
				}
			}
			if (!(Time.time >= rotatorChangeDirectionTime))
			{
				rotatorSpeed = Mathf.Lerp(rotatorSpeed, 0f, Time.deltaTime * rotatorAcceleration);
			}
			if (!(rotatorDirection <= 0f) && !(Time.time <= rotatorChangeDirectionTime))
			{
				if (!(num2 <= rotatorAngleScan * 0.95f))
				{
					rotatorDirection = 0f;
				}
				rotatorSpeed = Mathf.Lerp(rotatorSpeed, rotatorMaxSpeed, Time.deltaTime * rotatorAcceleration);
			}
			if (!(rotatorDirection >= 0f) && !(Time.time <= rotatorChangeDirectionTime))
			{
				if (!(num2 >= (0f - rotatorAngleScan) * 0.95f))
				{
					rotatorDirection = 0f;
				}
				rotatorSpeed = Mathf.Lerp(rotatorSpeed, 0f - rotatorMaxSpeed, Time.deltaTime * rotatorAcceleration);
			}
		}
		else
		{
			rotatorSpeed = Mathf.Lerp(rotatorSpeed, 0f, Time.deltaTime * rotatorAcceleration);
		}
	}

	public virtual void Main()
	{
	}
}
