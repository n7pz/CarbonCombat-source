using System;
using Photon;
using UnityEngine;

[Serializable]
public class WheelAlignment_Script : Photon.MonoBehaviour
{
	public WheelCollider CorrespondingCollider;

	public GameObject SlipPrefab;

	public GameObject wheelmark;

	public Rigidbody maincar;

	public ParticleEmitter flame;

	private float RotationValue;

	public int theRPM;

	private int theAngle;

	public LayerMask layermask;

	private bool wheelflame;

	public GameObject wheelflameprefab;

	private Vector3 lastpos;

	public bool syncRPM;

	public float capYPos;

	public WheelAlignment_Script()
	{
		lastpos = Vector3.zero;
		capYPos = 0.238f;
	}

	public virtual void startFlame()
	{
		wheelflame = true;
	}

	public virtual void stopFlame()
	{
		wheelflame = false;
		lastpos = Vector3.zero;
	}

	public virtual void Update()
	{
		RaycastHit hitInfo = default(RaycastHit);
		Vector3 vector = CorrespondingCollider.transform.TransformPoint(CorrespondingCollider.center);
		float sqrMagnitude = (transform.position - Camera.main.transform.position).sqrMagnitude;
		if (!flame.emit && !(sqrMagnitude >= 105625f))
		{
			if (Physics.Raycast(vector, -CorrespondingCollider.transform.up, out hitInfo, CorrespondingCollider.suspensionDistance + CorrespondingCollider.radius, layermask))
			{
				transform.position = hitInfo.point + CorrespondingCollider.transform.up * CorrespondingCollider.radius;
			}
			else
			{
				transform.position = vector - CorrespondingCollider.transform.up * CorrespondingCollider.suspensionDistance;
			}
		}
		if (!(transform.localPosition.y <= capYPos))
		{
			float y = capYPos;
			Vector3 localPosition = transform.localPosition;
			float num = (localPosition.y = y);
			Vector3 vector2 = (transform.localPosition = localPosition);
		}
		while (RotationValue > 360f)
		{
			RotationValue -= 360f;
		}
		while (RotationValue < -360f)
		{
			RotationValue += 360f;
		}
		Quaternion rotation = CorrespondingCollider.transform.rotation * Quaternion.Euler(RotationValue, CorrespondingCollider.steerAngle, 0f);
		if (!float.IsNaN(rotation.w))
		{
			transform.rotation = rotation;
		}
		else
		{
			CorrespondingCollider.steerAngle = 0f;
			RotationValue = 0f;
			Vector3 vector4 = new Vector3(0f, 0f, 0f);
			Quaternion rotation2 = CorrespondingCollider.transform.rotation;
			Vector3 vector5 = (rotation2.eulerAngles = vector4);
			Quaternion quaternion = (CorrespondingCollider.transform.rotation = rotation2);
		}
		RotationValue += ((!(Application.loadedLevelName == "Preloader") && !((PhotonView)transform.root.GetComponent(typeof(PhotonView))).isMine) ? ((float)theRPM) : CorrespondingCollider.rpm) * 6f * Time.deltaTime;
		while (RotationValue > 360f)
		{
			RotationValue -= 360f;
		}
		while (RotationValue < -360f)
		{
			RotationValue += 360f;
		}
		WheelHit hit = default(WheelHit);
		CorrespondingCollider.GetGroundHit(out hit);
		if (wheelflame)
		{
			if (lastpos != Vector3.zero)
			{
				UnityEngine.Object.Instantiate(wheelflameprefab, (new Vector3(hit.point.x, hit.point.y + 1f, hit.point.z) + lastpos) / 2f, Quaternion.identity);
			}
			UnityEngine.Object.Instantiate(wheelflameprefab, new Vector3(hit.point.x, hit.point.y + 1f, hit.point.z), Quaternion.identity);
			lastpos = new Vector3(hit.point.x, hit.point.y + 1f, hit.point.z);
		}
		if (Terrain.activeTerrain != null && hit.collider == Terrain.activeTerrain.collider && !(Mathf.Abs(hit.sidewaysSlip) <= 10f) && (bool)SlipPrefab)
		{
			UnityEngine.Object.Instantiate(SlipPrefab, hit.point, Quaternion.identity);
		}
	}

	public virtual void Main()
	{
	}
}
