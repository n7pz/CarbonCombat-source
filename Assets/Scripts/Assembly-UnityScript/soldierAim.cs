using System;
using Boo.Lang.Runtime;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class soldierAim : MonoBehaviour
{
	public Transform soldierCamera;

	public Vector3 headRotationFix;

	public Transform crosshair;

	public Transform firePoint;

	private Vector3 target;

	private Vector3 targetTarget;

	private Transform rightUpperArm;

	private Transform rightClavicle;

	private Transform leftUpperArm;

	private Transform leftClavicle;

	private Transform leftForearm;

	private Transform leftFinger;

	private Transform spine1;

	private Transform spine2;

	private Transform head;

	private Transform neck;

	private float cameraYRotation;

	private float cameraPitch;

	private float torsoOffsetAngle;

	private float torsoOffsetPitch;

	private float leanHead;

	private soldierAnimation soldierAnimationScript;

	private MonoBehaviour leftArmIkScript;

	private Transform ikArm;

	private Transform ikUpperArm;

	private Transform ikForearm;

	private float transition;

	private float transitionTarget;

	private float transition2;

	private float transition2Target;

	public soldierAim()
	{
		headRotationFix = new Vector3(180f, 90f, 90f);
	}

	public virtual void Start()
	{
		spine1 = transform.Find("Bip01/Bip01 Pelvis/Bip01 Spine/Bip01 Spine1");
		spine2 = spine1.Find("Bip01 Spine2");
		neck = spine2.Find("Bip01 Neck");
		rightClavicle = neck.Find("Bip01 R Clavicle");
		rightUpperArm = rightClavicle.Find("Bip01 R UpperArm");
		leftClavicle = neck.Find("Bip01 L Clavicle");
		leftUpperArm = leftClavicle.Find("Bip01 L UpperArm");
		leftForearm = leftUpperArm.Find("Bip01 L Forearm");
		leftFinger = leftForearm.Find("Bip01 L Hand/Bip01 L Finger2/Bip01 L Finger21");
		head = neck.Find("Bip01 Head");
		soldierAnimationScript = (soldierAnimation)GetComponent("soldierAnimation");
		ikArm = leftUpperArm.Find("ikArm");
		ikArm.parent = transform.root;
		ikArm.position = leftUpperArm.position;
		ikUpperArm = ikArm.Find("upperArm");
		ikForearm = ikUpperArm.Find("elbow");
		leftArmIkScript = (MonoBehaviour)ikArm.GetComponent("inverseKinematics");
		float num = Vector3.Distance(leftUpperArm.position, leftForearm.position);
		float num2 = Vector3.Distance(leftForearm.position, leftFinger.position);
		ikForearm.parent = null;
		ikUpperArm.localScale = new Vector3(num, num, num);
		ikForearm.localScale = new Vector3(num2, num2, num2);
		ikForearm.parent = ikUpperArm;
		ikForearm.localPosition = Vector3.zero;
		ikForearm.position += ikUpperArm.forward * num;
	}

	public virtual void LateUpdate()
	{
		RaycastHit hitInfo = default(RaycastHit);
		targetTarget = firePoint.position + firePoint.TransformDirection(Vector3.forward) * 9999f;
		if (Physics.Raycast(firePoint.position, firePoint.TransformDirection(Vector3.forward), out hitInfo, 9999f))
		{
			Debug.DrawLine(firePoint.position, hitInfo.point, Color.green);
			float num = Vector3.Distance(hitInfo.point, this.transform.position);
			float num2 = Vector3.Distance(this.transform.position, this.transform.position);
			if (!(num <= num2 * 1f))
			{
				Ray ray = new Ray
				{
					origin = rightUpperArm.position,
					direction = hitInfo.point - rightUpperArm.position
				};
				targetTarget = rightUpperArm.position + (hitInfo.point - rightUpperArm.position).normalized * 9999f;
			}
		}
		target = Vector3.Lerp(target, targetTarget, Time.deltaTime * 10f);
		Transform transform = new GameObject("aidAim").transform;
		transitionTarget = 1f;
		transitionTarget *= 1f - soldierAnimationScript.landingBlend;
		transitionTarget *= 1f - soldierAnimationScript.fallingBlend;
		transitionTarget *= 1f - soldierAnimationScript.sprintBlend;
		transitionTarget *= 1f - soldierAnimationScript.crouchSprintBlend;
		transitionTarget *= 1f - soldierAnimationScript.hitBlend;
		transitionTarget *= 1f - soldierAnimationScript.dieBlend;
		transition2Target = 1f;
		transition2Target *= 1f - soldierAnimationScript.hitBlend;
		transition2Target *= 1f - soldierAnimationScript.dieBlend;
		Quaternion localRotation = rightUpperArm.localRotation;
		Quaternion localRotation2 = leftUpperArm.localRotation;
		Quaternion localRotation3 = leftForearm.localRotation;
		Quaternion localRotation4 = head.localRotation;
		Quaternion localRotation5 = spine1.localRotation;
		Quaternion localRotation6 = spine2.localRotation;
		float y = this.transform.rotation.eulerAngles.y;
		float current = spine1.rotation.eulerAngles.y + 60f;
		cameraYRotation = this.transform.rotation.eulerAngles.y;
		cameraPitch = firePoint.localRotation.eulerAngles.x;
		float to = Mathf.DeltaAngle(current, cameraYRotation);
		torsoOffsetAngle = Mathf.Lerp(torsoOffsetAngle, to, Time.deltaTime * 15f);
		float to2 = Mathf.DeltaAngle(0f, cameraPitch);
		torsoOffsetPitch = Mathf.Lerp(torsoOffsetPitch, to2, Time.deltaTime * 15f);
		float x = spine1.localRotation.eulerAngles.x - torsoOffsetAngle * 0.5f;
		Quaternion localRotation7 = spine1.localRotation;
		Vector3 eulerAngles = localRotation7.eulerAngles;
		float num3 = (eulerAngles.x = x);
		Vector3 vector = (localRotation7.eulerAngles = eulerAngles);
		Quaternion quaternion = (spine1.localRotation = localRotation7);
		float x2 = spine2.localRotation.eulerAngles.x - torsoOffsetAngle * 0.5f;
		Quaternion localRotation8 = spine2.localRotation;
		Vector3 eulerAngles2 = localRotation8.eulerAngles;
		float num4 = (eulerAngles2.x = x2);
		Vector3 vector3 = (localRotation8.eulerAngles = eulerAngles2);
		Quaternion quaternion3 = (spine2.localRotation = localRotation8);
		float z = spine1.localRotation.eulerAngles.z - torsoOffsetPitch * 0.5f;
		Quaternion localRotation9 = spine1.localRotation;
		Vector3 eulerAngles3 = localRotation9.eulerAngles;
		float num5 = (eulerAngles3.z = z);
		Vector3 vector5 = (localRotation9.eulerAngles = eulerAngles3);
		Quaternion quaternion5 = (spine1.localRotation = localRotation9);
		float z2 = spine2.localRotation.eulerAngles.z - torsoOffsetPitch * 0.5f;
		Quaternion localRotation10 = spine2.localRotation;
		Vector3 eulerAngles4 = localRotation10.eulerAngles;
		float num6 = (eulerAngles4.z = z2);
		Vector3 vector7 = (localRotation10.eulerAngles = eulerAngles4);
		Quaternion quaternion7 = (spine2.localRotation = localRotation10);
		transform.position = rightUpperArm.position;
		Transform transform2 = rightUpperArm.Find("Bip01 R Forearm/Bip01 R Hand/gun/gunAim");
		transform.LookAt(transform2);
		rightUpperArm.parent = transform;
		transform.LookAt(target);
		rightUpperArm.parent = rightClavicle;
		transform.position = leftUpperArm.position;
		transform.LookAt(leftForearm);
		leftUpperArm.parent = transform;
		Transform transform3 = rightUpperArm.Find("Bip01 R Forearm/Bip01 R Hand/gun/gunGrab");
		transform.LookAt(transform3);
		leftUpperArm.parent = leftClavicle;
		ikArm.position = leftUpperArm.position;
		Transform transform4 = spine2.Find("leftElbowTarget");
		RuntimeServices.SetProperty(leftArmIkScript, "elbowTarget", transform4.position);
		RuntimeServices.SetProperty(leftArmIkScript, "target", transform3.position);
		UnityRuntimeServices.Invoke(leftArmIkScript, "CalculateIK", new object[0], typeof(MonoBehaviour));
		Quaternion rotation = ikUpperArm.Find("upperArmRotation").rotation;
		Quaternion rotation2 = ikForearm.Find("forearmRotation").rotation;
		leftUpperArm.rotation = rotation;
		leftForearm.rotation = rotation2;
		UnityEngine.Object.Destroy(transform.gameObject);
		if (soldierCamera != null)
		{
			head.LookAt(target);
			head.Rotate(headRotationFix);
			float num7 = 0f;
			float num8 = 120f;
			float num9 = 20f;
			float to3 = 0f;
			if (!(head.localRotation.eulerAngles.x <= num7) && !(head.localRotation.eulerAngles.x >= num8))
			{
				to3 = head.localRotation.eulerAngles.x - num7;
				to3 /= num8;
				to3 *= num9;
			}
			leanHead = Mathf.Lerp(leanHead, to3, Time.deltaTime * 5f);
			head.Rotate(0f, leanHead, 0f);
		}
		transition = Mathf.Lerp(transition, transitionTarget, Time.deltaTime * 5f);
		if (!(transition >= 1f))
		{
			rightUpperArm.localRotation = Quaternion.Lerp(localRotation, rightUpperArm.localRotation, transition);
			leftUpperArm.localRotation = Quaternion.Lerp(localRotation2, leftUpperArm.localRotation, transition);
			leftForearm.localRotation = Quaternion.Lerp(localRotation3, leftForearm.localRotation, transition);
		}
		transition2 = Mathf.Lerp(transition2, transition2Target, Time.deltaTime * 5f);
		if (!(transition2 >= 1f))
		{
			head.localRotation = Quaternion.Lerp(localRotation4, head.localRotation, transition2);
			spine1.localRotation = Quaternion.Lerp(localRotation5, spine1.localRotation, transition2);
			spine2.localRotation = Quaternion.Lerp(localRotation6, spine2.localRotation, transition2);
		}
	}

	public virtual void Main()
	{
	}
}
