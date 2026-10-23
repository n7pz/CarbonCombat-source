using System;
using UnityEngine;

[Serializable]
public class TankController : MonoBehaviour
{
	private int enginetorque;

	private int dragdiv;

	private int steerangle;

	[NonSerialized]
	public static bool pivoting;

	public WheelCollider FR;

	public WheelCollider FL;

	public WheelCollider BL;

	public WheelCollider BR;

	public TankController()
	{
		enginetorque = 600;
		dragdiv = 10;
		steerangle = 10;
	}

	public virtual void Start()
	{
		float y = -1.5f;
		Vector3 centerOfMass = rigidbody.centerOfMass;
		float num = (centerOfMass.y = y);
		Vector3 vector = (rigidbody.centerOfMass = centerOfMass);
	}

	public virtual void FixedUpdate()
	{
		rigidbody.drag = rigidbody.velocity.magnitude / (float)dragdiv;
		FR.steerAngle = (float)steerangle * Input.GetAxis("Horizontal");
		FL.steerAngle = (float)steerangle * Input.GetAxis("Horizontal");
		BR.steerAngle = (float)(-steerangle) * Input.GetAxis("Horizontal");
		BL.steerAngle = (float)(-steerangle) * Input.GetAxis("Horizontal");
		if (Input.GetAxis("Horizontal") != 0f && Input.GetAxis("Vertical") == 0f)
		{
			int num = 0;
			if (FR.isGrounded)
			{
				num++;
			}
			if (FL.isGrounded)
			{
				num++;
			}
			if (BR.isGrounded)
			{
				num++;
			}
			if (BL.isGrounded)
			{
				num++;
			}
			if (num >= 3)
			{
				int num2 = 1000;
				WheelFrictionCurve sidewaysFriction = FR.sidewaysFriction;
				float num3 = (sidewaysFriction.extremumSlip = num2);
				WheelFrictionCurve wheelFrictionCurve = (FR.sidewaysFriction = sidewaysFriction);
				int num5 = 1000;
				WheelFrictionCurve sidewaysFriction2 = FL.sidewaysFriction;
				float num6 = (sidewaysFriction2.extremumSlip = num5);
				WheelFrictionCurve wheelFrictionCurve3 = (FL.sidewaysFriction = sidewaysFriction2);
				int num8 = 1000;
				WheelFrictionCurve sidewaysFriction3 = BR.sidewaysFriction;
				float num9 = (sidewaysFriction3.extremumSlip = num8);
				WheelFrictionCurve wheelFrictionCurve5 = (BR.sidewaysFriction = sidewaysFriction3);
				int num11 = 1000;
				WheelFrictionCurve sidewaysFriction4 = BL.sidewaysFriction;
				float num12 = (sidewaysFriction4.extremumSlip = num11);
				WheelFrictionCurve wheelFrictionCurve7 = (BL.sidewaysFriction = sidewaysFriction4);
				rigidbody.AddRelativeTorque(0f, 50000f * Input.GetAxis("Horizontal"), 0f);
				pivoting = true;
			}
			return;
		}
		pivoting = false;
		if (!(FR.sidewaysFriction.extremumSlip <= 1f))
		{
			float num14 = FR.sidewaysFriction.extremumSlip - 1000f * Time.deltaTime;
			WheelFrictionCurve sidewaysFriction5 = FR.sidewaysFriction;
			float num15 = (sidewaysFriction5.extremumSlip = num14);
			WheelFrictionCurve wheelFrictionCurve9 = (FR.sidewaysFriction = sidewaysFriction5);
			float num17 = FL.sidewaysFriction.extremumSlip - 1000f * Time.deltaTime;
			WheelFrictionCurve sidewaysFriction6 = FL.sidewaysFriction;
			float num18 = (sidewaysFriction6.extremumSlip = num17);
			WheelFrictionCurve wheelFrictionCurve11 = (FL.sidewaysFriction = sidewaysFriction6);
			float num20 = BR.sidewaysFriction.extremumSlip - 1000f * Time.deltaTime;
			WheelFrictionCurve sidewaysFriction7 = BR.sidewaysFriction;
			float num21 = (sidewaysFriction7.extremumSlip = num20);
			WheelFrictionCurve wheelFrictionCurve13 = (BR.sidewaysFriction = sidewaysFriction7);
			float num23 = BL.sidewaysFriction.extremumSlip - 1000f * Time.deltaTime;
			WheelFrictionCurve sidewaysFriction8 = BL.sidewaysFriction;
			float num24 = (sidewaysFriction8.extremumSlip = num23);
			WheelFrictionCurve wheelFrictionCurve15 = (BL.sidewaysFriction = sidewaysFriction8);
		}
		else
		{
			int num26 = 1;
			WheelFrictionCurve sidewaysFriction9 = FR.sidewaysFriction;
			float num27 = (sidewaysFriction9.extremumSlip = num26);
			WheelFrictionCurve wheelFrictionCurve17 = (FR.sidewaysFriction = sidewaysFriction9);
			int num29 = 1;
			WheelFrictionCurve sidewaysFriction10 = FL.sidewaysFriction;
			float num30 = (sidewaysFriction10.extremumSlip = num29);
			WheelFrictionCurve wheelFrictionCurve19 = (FL.sidewaysFriction = sidewaysFriction10);
			int num32 = 1;
			WheelFrictionCurve sidewaysFriction11 = BR.sidewaysFriction;
			float num33 = (sidewaysFriction11.extremumSlip = num32);
			WheelFrictionCurve wheelFrictionCurve21 = (BR.sidewaysFriction = sidewaysFriction11);
			int num35 = 1;
			WheelFrictionCurve sidewaysFriction12 = BL.sidewaysFriction;
			float num36 = (sidewaysFriction12.extremumSlip = num35);
			WheelFrictionCurve wheelFrictionCurve23 = (BL.sidewaysFriction = sidewaysFriction12);
		}
		FR.motorTorque = Input.GetAxis("Vertical") * (float)enginetorque * Time.deltaTime;
		FL.motorTorque = Input.GetAxis("Vertical") * (float)enginetorque * Time.deltaTime;
		BL.motorTorque = Input.GetAxis("Vertical") * (float)enginetorque * Time.deltaTime;
		BR.motorTorque = Input.GetAxis("Vertical") * (float)enginetorque * Time.deltaTime;
	}

	public virtual void Main()
	{
	}
}
