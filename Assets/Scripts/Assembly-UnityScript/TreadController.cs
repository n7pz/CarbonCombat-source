using System;
using Boo.Lang.Runtime;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class TreadController : MonoBehaviour
{
	public GameObject cortread;

	private Vector3 origpos;

	public GameObject dustprefab;

	public Rigidbody maintank;

	public Renderer realmesh;

	public Collider realmeshcol;

	public Collider terrain;

	private Vector2 offset;

	public TankController tcontroller;

	public virtual void Start()
	{
		origpos = cortread.transform.localPosition;
		Physics.IgnoreCollision(realmeshcol.transform.collider, terrain.collider);
	}

	public virtual void FixedUpdate()
	{
		if (!(transform.InverseTransformDirection(maintank.velocity).z <= 0f))
		{
			offset.y += Time.deltaTime * (0f - maintank.velocity.magnitude * 0.5f);
		}
		else
		{
			offset.y -= Time.deltaTime * (0f - maintank.velocity.magnitude * 0.5f);
		}
		Material[] materials = realmesh.materials;
		materials[1].SetTextureOffset("_MainTex", offset);
		materials[1].SetTextureOffset("_BumpMap", offset);
	}

	public virtual void LateUpdate()
	{
		Vector3 direction = transform.TransformDirection(-Vector3.up);
		RaycastHit hitInfo = default(RaycastHit);
		Vector3 vector = collider.transform.TransformPoint((Vector3)UnityRuntimeServices.GetProperty(collider, "center"));
		object value = RuntimeServices.InvokeBinaryOperator("op_Addition", UnityRuntimeServices.GetProperty(collider, "suspensionDistance"), UnityRuntimeServices.GetProperty(collider, "radius"));
		if (Physics.Raycast(vector, direction, out hitInfo, RuntimeServices.UnboxSingle(value)))
		{
			object value2 = RuntimeServices.InvokeBinaryOperator("op_Subtraction", RuntimeServices.InvokeBinaryOperator("op_Addition", hitInfo.point.y, UnityRuntimeServices.GetProperty(collider, "radius")), 0.25f);
			Vector3 position = cortread.transform.position;
			float num = (position.y = RuntimeServices.UnboxSingle(value2));
			Vector3 vector2 = (cortread.transform.position = position);
			Vector3 forward = cortread.transform.forward;
			Vector3 forward2 = forward - Vector3.Dot(forward, hitInfo.normal) * hitInfo.normal;
			Quaternion to = Quaternion.LookRotation(forward2, hitInfo.normal);
			if (!(maintank.velocity.magnitude < 10f))
			{
				UnityEngine.Object.Instantiate(dustprefab, hitInfo.point, transform.rotation);
			}
			if (!(maintank.velocity.magnitude >= 10f) && TankController.pivoting)
			{
				UnityEngine.Object.Instantiate(dustprefab, hitInfo.point, transform.rotation);
			}
			cortread.transform.rotation = Quaternion.Slerp(cortread.transform.rotation, to, Time.deltaTime * 3.5f);
			Debug.DrawLine(vector, hitInfo.point, Color.red);
		}
		else
		{
			Quaternion to = Quaternion.Euler(0f, 0f, 0f);
			cortread.transform.localRotation = Quaternion.Slerp(cortread.transform.localRotation, to, Time.deltaTime * 3.5f);
		}
		float x = origpos.x;
		Vector3 localPosition = cortread.transform.localPosition;
		float num2 = (localPosition.x = x);
		Vector3 vector4 = (cortread.transform.localPosition = localPosition);
		float z = origpos.z;
		Vector3 localPosition2 = cortread.transform.localPosition;
		float num3 = (localPosition2.z = z);
		Vector3 vector6 = (cortread.transform.localPosition = localPosition2);
		int num4 = 0;
		Quaternion localRotation = cortread.transform.localRotation;
		float num5 = (localRotation.z = num4);
		Quaternion quaternion = (cortread.transform.localRotation = localRotation);
		int num6 = 0;
		Quaternion localRotation2 = cortread.transform.localRotation;
		float num7 = (localRotation2.y = num6);
		Quaternion quaternion3 = (cortread.transform.localRotation = localRotation2);
	}

	public virtual void Main()
	{
	}
}
