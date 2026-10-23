using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class MouseLook : MonoBehaviour
{
	public Axes Axis;

	public float sensitivityX;

	public float sensitivityY;

	public float minimumX;

	public float maximumX;

	public float minimumY;

	public float maximumY;

	public float rotationX;

	public float rotationY;

	private ChatScript cscript;

	private PauseObject pobj;

	private EndofRound eor;

	private ConduitInputReciever cInput;

	public MouseLook()
	{
		Axis = Axes.MouseXandY;
		sensitivityX = 15f;
		sensitivityY = 15f;
		minimumX = -360f;
		maximumX = 360f;
		minimumY = -90f;
		maximumY = 90f;
	}

	public virtual void LateUpdate()
	{
		if (!RuntimeServices.EqualityOperator(ConduitInputReciever.ht["tPadAlt"], Vector2.zero))
		{
			ConduitInputReciever.ht["tPadAlt"] = Vector2.zero;
		}
	}

	public virtual void Update()
	{
		sensitivityX = 2f * (PauseObject.fpssens / 5f);
		sensitivityY = 2f * (PauseObject.fpssens / 5f);
		Vector2 vector = (Vector2)RuntimeServices.InvokeBinaryOperator("op_Division", ConduitInputReciever.ht["tPadAlt"], 3.5f);
		if (!ChatScript.isCar && PauseObject.pubalpha == 0f && EndofRound.alphastat == 0f)
		{
			if (Axis == Axes.MouseXandY)
			{
				rotationX += ((Mathf.Abs(vector.x) <= 0f) ? Input.GetAxis("Mouse X") : vector.x) * sensitivityX;
				rotationY += ((Mathf.Abs(vector.y) <= 0f) ? Input.GetAxis("Mouse Y") : vector.y) * sensitivityY;
				rotationX = ClampAngle(rotationX, minimumX, maximumX);
				rotationY = ClampAngle(rotationY, minimumY, maximumY);
				transform.localRotation = Quaternion.AngleAxis(rotationX, Vector3.up);
				transform.localRotation *= Quaternion.AngleAxis(rotationY, Vector3.left);
			}
			if (Axis == Axes.MouseX)
			{
				rotationX += ((Mathf.Abs(vector.x) <= 0f) ? Input.GetAxis("Mouse X") : vector.x) * sensitivityX;
				rotationX = ClampAngle(rotationX, minimumX, maximumX);
				transform.localRotation = Quaternion.AngleAxis(rotationX, Vector3.up);
			}
			if (Axis == Axes.MouseY)
			{
				rotationY += ((Mathf.Abs(vector.y) <= 0f) ? Input.GetAxis("Mouse Y") : vector.y) * sensitivityY;
				rotationY = ClampAngle(rotationY, minimumY, maximumY);
				transform.localRotation = Quaternion.AngleAxis(rotationY, Vector3.left);
			}
		}
	}

	public virtual void Adjust360andClamp()
	{
		if (!(rotationX >= -360f))
		{
			rotationX += 360f;
		}
		if (!(rotationX <= 360f))
		{
			rotationX -= 360f;
		}
		if (!(rotationY >= -360f))
		{
			rotationY += 360f;
		}
		if (!(rotationY <= 360f))
		{
			rotationY -= 360f;
		}
		rotationX = Mathf.Clamp(rotationX, minimumX, maximumX);
		rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);
	}

	public virtual void Start()
	{
		if ((bool)rigidbody)
		{
			rigidbody.freezeRotation = true;
		}
	}

	public virtual float ClampAngle(float angle, float min, float max)
	{
		if (!(angle >= -360f))
		{
			angle += 360f;
		}
		if (!(angle <= 360f))
		{
			angle -= 360f;
		}
		return Mathf.Clamp(angle, min, max);
	}

	public virtual void Main()
	{
	}
}
