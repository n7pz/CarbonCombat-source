using System;
using UnityEngine;

[Serializable]
public class soldierCamera : MonoBehaviour
{
	public float cameraTiltMultiplier;

	private Vector3 lastPosition;

	private float forwardSpeed;

	private float cameraTilt;

	private float verticalAim;

	private Vector3 localPosition;

	private Vector3 positionOffset;

	private health healthScript;

	private crouchController crouchControllerScript;

	private Transform spine2;

	public soldierCamera()
	{
		cameraTiltMultiplier = 1f;
	}

	public virtual void Start()
	{
		cameraTilt = 0f;
		float num = 0f;
		localPosition = transform.localPosition;
		positionOffset = Vector3.zero;
		healthScript = (health)transform.root.GetComponent("health");
		crouchControllerScript = (crouchController)transform.root.GetComponent("crouchController");
		spine2 = transform.root.Find("smoothWorldPosition/soldierSkeleton/Bip01/Bip01 Pelvis/Bip01 Spine/Bip01 Spine1/Bip01 Spine2");
	}

	public virtual void Update()
	{
		float num = 100f;
		if (healthScript != null)
		{
			num = healthScript.GetHealth();
		}
		float num2 = default(float);
		num2 = Input.GetAxis("Mouse X");
		Vector3 direction = transform.root.position - lastPosition;
		lastPosition = transform.root.position;
		forwardSpeed = transform.InverseTransformDirection(direction).z;
		num2 *= (0f - forwardSpeed) * 60f * cameraTiltMultiplier;
		num2 = Mathf.Clamp(num2, -30f, 30f);
		cameraTilt = Mathf.Lerp(cameraTilt, num2, Time.deltaTime * 3f);
		if (!(num <= 0f))
		{
			float z = cameraTilt;
			Quaternion localRotation = transform.localRotation;
			Vector3 eulerAngles = localRotation.eulerAngles;
			float num3 = (eulerAngles.z = z);
			Vector3 vector = (localRotation.eulerAngles = eulerAngles);
			Quaternion quaternion = (transform.localRotation = localRotation);
		}
		verticalAim -= Input.GetAxis("Mouse Y") * Time.deltaTime * 100f;
		verticalAim = Mathf.Clamp(verticalAim, -40f, 50f);
		float num4 = 0f;
		if (crouchControllerScript != null)
		{
			num4 = (0f - crouchControllerScript.globalCrouchBlend) * 0.2f;
		}
		if (!(num > 0f))
		{
			verticalAim = 0f;
			num4 = 0f;
		}
		if (!(num <= 0f))
		{
			float x = Mathf.LerpAngle(transform.localRotation.eulerAngles.x, verticalAim, Time.deltaTime * 5f);
			Quaternion localRotation2 = transform.localRotation;
			Vector3 eulerAngles2 = localRotation2.eulerAngles;
			float num5 = (eulerAngles2.x = x);
			Vector3 vector3 = (localRotation2.eulerAngles = eulerAngles2);
			Quaternion quaternion3 = (transform.localRotation = localRotation2);
		}
		if (!(verticalAim <= 0f))
		{
			positionOffset.y = verticalAim * 0.03f;
		}
		else
		{
			positionOffset.y = verticalAim * 0.02f;
		}
		positionOffset.y += num4;
		if (!(num <= 0f))
		{
			transform.localPosition = Vector3.Lerp(transform.localPosition, localPosition + positionOffset, Time.deltaTime * 5f);
		}
		if (!(num > 0f))
		{
			Vector3 forward = spine2.position - transform.position;
			Quaternion to = Quaternion.LookRotation(forward);
			transform.rotation = Quaternion.Slerp(transform.rotation, to, Time.deltaTime * 3f);
			transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(2f, 3f, 0f), Time.deltaTime * 3f);
		}
	}

	public virtual void Main()
	{
	}
}
