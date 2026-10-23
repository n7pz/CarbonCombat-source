using System;
using Boo.Lang.Runtime;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
[RequireComponent(typeof(CharacterMotor))]
[AddComponentMenu("Character/FPS Input Controller")]
public class FPSInputController : MonoBehaviour
{
	private CharacterMotor motor;

	private CalculateHealth chealth;

	private EndofRound eor;

	private ConduitInputReciever cInput;

	[NonSerialized]
	public static float jumpAmt;

	private bool isControlling;

	public FPSInputController()
	{
		isControlling = true;
	}

	public virtual void setcontrol(bool t)
	{
		isControlling = t;
	}

	public virtual void Awake()
	{
		motor = (CharacterMotor)GetComponent(typeof(CharacterMotor));
	}

	public virtual void Update()
	{
		if (isControlling && EndofRound.alphastat == 0f)
		{
			Vector3 vector = new Vector3(RuntimeServices.UnboxSingle((!RuntimeServices.ToBool(RuntimeServices.InvokeBinaryOperator("op_GreaterThan", RuntimeServices.Invoke(typeof(Mathf), "Abs", new object[1] { UnityRuntimeServices.GetProperty(ConduitInputReciever.ht["dPad"], "x") }), 0))) ? ((object)Input.GetAxis("Horizontal")) : RuntimeServices.InvokeBinaryOperator("op_Division", UnityRuntimeServices.GetProperty(ConduitInputReciever.ht["dPad"], "x"), 50f)), 0f, RuntimeServices.UnboxSingle((!RuntimeServices.ToBool(RuntimeServices.InvokeBinaryOperator("op_GreaterThan", RuntimeServices.Invoke(typeof(Mathf), "Abs", new object[1] { UnityRuntimeServices.GetProperty(ConduitInputReciever.ht["dPad"], "y") }), 0))) ? ((object)Input.GetAxis("Vertical")) : RuntimeServices.InvokeBinaryOperator("op_Division", UnityRuntimeServices.GetProperty(ConduitInputReciever.ht["dPad"], "y"), 50f)));
			if (vector != Vector3.zero)
			{
				float magnitude = vector.magnitude;
				vector /= magnitude;
				magnitude = Mathf.Min(1f, magnitude);
				magnitude *= magnitude;
				vector *= magnitude;
			}
			motor.inputMoveDirection = transform.rotation * vector;
			if (Input.GetButton("Jump") || RuntimeServices.ToBool(ConduitInputReciever.ht["jump"]))
			{
				CalculateHealth.jetFuel = Mathf.Max(0f, CalculateHealth.jetFuel - Time.deltaTime * 0.08f);
			}
			else
			{
				CalculateHealth.jetFuel = Mathf.Min(1f, CalculateHealth.jetFuel + Time.deltaTime * 0.045f);
			}
			motor.inputJump = RuntimeServices.UnboxBoolean((CalculateHealth.jetFuel <= 0f) ? ((object)false) : ((!Input.GetButton("Jump")) ? ConduitInputReciever.ht["jump"] : ((object)Input.GetButton("Jump"))));
			if (Input.GetButton("Jump") || RuntimeServices.ToBool(ConduitInputReciever.ht["jump"]))
			{
				jumpAmt = Mathf.SmoothStep(jumpAmt, 1f, 6f * Time.deltaTime);
			}
			else
			{
				jumpAmt = Mathf.SmoothStep(jumpAmt, 0f, 18f * Time.deltaTime);
			}
		}
		else
		{
			motor.inputMoveDirection = transform.rotation * Vector3.zero;
			motor.inputJump = false;
		}
	}

	public virtual void Main()
	{
	}
}
