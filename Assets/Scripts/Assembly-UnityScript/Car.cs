using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class Car : MonoBehaviour
{
	[Serializable]
	internal sealed class _0024StopHandbraking_00245470 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal float _0024diff_00245471;

			internal float _0024seconds_00245472;

			internal Car _0024self__00245473;

			public _0024(float seconds, Car self_)
			{
				_0024seconds_00245472 = seconds;
				_0024self__00245473 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024diff_00245471 = _0024self__00245473.initialDragMultiplierX - _0024self__00245473.dragMultiplier.x;
					_0024self__00245473.handbrakeTimer = 1f;
					goto case 2;
				case 2:
					if (!(_0024self__00245473.dragMultiplier.x >= _0024self__00245473.initialDragMultiplierX) && !_0024self__00245473.handbrake)
					{
						_0024self__00245473.dragMultiplier.x = _0024self__00245473.dragMultiplier.x + _0024diff_00245471 * (Time.deltaTime / _0024seconds_00245472);
						_0024self__00245473.handbrakeTimer -= Time.deltaTime / _0024seconds_00245472;
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024self__00245473.dragMultiplier.x = _0024self__00245473.initialDragMultiplierX;
					_0024self__00245473.handbrakeTimer = 0f;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal float _0024seconds_00245474;

		internal Car _0024self__00245475;

		public _0024StopHandbraking_00245470(float seconds, Car self_)
		{
			_0024seconds_00245474 = seconds;
			_0024self__00245475 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024seconds_00245474, _0024self__00245475);
		}
	}

	private float wheelRadius;

	public float suspensionRange;

	public float suspensionDamper;

	public float suspensionSpringFront;

	public float suspensionSpringRear;

	public Material brakeLights;

	public Vector3 dragMultiplier;

	public float throttle;

	private float steer;

	private bool handbrake;

	public Transform centerOfMass;

	public Transform[] frontWheels;

	public Transform[] rearWheels;

	private Wheel[] wheels;

	private WheelFrictionCurve wfc;

	public float topSpeed;

	public int numberOfGears;

	public int maximumTurn;

	public int minimumTurn;

	public float resetTime;

	private float resetTimer;

	private float[] engineForceValues;

	private float[] gearSpeeds;

	private int currentGear;

	private float currentEnginePower;

	private float handbrakeXDragFactor;

	private float initialDragMultiplierX;

	private float handbrakeTime;

	private float handbrakeTimer;

	private Skidmarks skidmarks;

	private ParticleEmitter skidSmoke;

	public float[] skidmarkTime;

	private SoundController sound;

	private bool canSteer;

	private bool canDrive;

	public float wheelCount;

	public Car()
	{
		wheelRadius = 0.4f;
		suspensionRange = 0.1f;
		suspensionDamper = 50f;
		suspensionSpringFront = 18500f;
		suspensionSpringRear = 9000f;
		dragMultiplier = new Vector3(2f, 5f, 1f);
		topSpeed = 160f;
		numberOfGears = 5;
		maximumTurn = 15;
		minimumTurn = 10;
		resetTime = 5f;
		handbrakeXDragFactor = 0.5f;
		initialDragMultiplierX = 10f;
		handbrakeTimer = 1f;
	}

	public virtual void Start()
	{
		float time = Time.time;
		SetupWheelColliders();
		SetupCenterOfMass();
		topSpeed = Convert_Miles_Per_Hour_To_Meters_Per_Second(topSpeed);
		SetupGears();
		SetUpSkidmarks();
		initialDragMultiplierX = dragMultiplier.x;
	}

	public virtual void Update()
	{
		Vector3 relativeVelocity = transform.InverseTransformDirection(rigidbody.velocity);
		GetInput();
		Check_If_Car_Is_Flipped();
		UpdateWheelGraphics(relativeVelocity);
		UpdateGear(relativeVelocity);
	}

	public virtual void FixedUpdate()
	{
		Vector3 relativeVelocity = transform.InverseTransformDirection(rigidbody.velocity);
		CalculateState();
		UpdateFriction(relativeVelocity);
		UpdateDrag(relativeVelocity);
		CalculateEnginePower(relativeVelocity);
		ApplyThrottle(canDrive, relativeVelocity);
		ApplySteering(canSteer, relativeVelocity);
	}

	public virtual void SetupWheelColliders()
	{
		SetupWheelFrictionCurve();
		int num = 0;
		int i = 0;
		Transform[] array = frontWheels;
		for (int length = array.Length; i < length; i++)
		{
			wheels[num] = SetupWheel(array[i], true);
			num++;
		}
		int j = 0;
		Transform[] array2 = rearWheels;
		for (int length2 = array2.Length; j < length2; j++)
		{
			wheels[num] = SetupWheel(array2[j], false);
			num++;
		}
	}

	public virtual void SetupWheelFrictionCurve()
	{
		wfc = default(WheelFrictionCurve);
		wfc.extremumSlip = 1f;
		wfc.extremumValue = 50f;
		wfc.asymptoteSlip = 2f;
		wfc.asymptoteValue = 25f;
		wfc.stiffness = 1f;
	}

	public virtual Wheel SetupWheel(Transform wheelTransform, bool isFrontWheel)
	{
		GameObject gameObject = new GameObject(wheelTransform.name + " Collider");
		gameObject.transform.position = wheelTransform.position;
		gameObject.transform.parent = transform;
		gameObject.transform.rotation = wheelTransform.rotation;
		WheelCollider wheelCollider = ((WheelCollider)gameObject.AddComponent(typeof(WheelCollider))) as WheelCollider;
		wheelCollider.suspensionDistance = suspensionRange;
		JointSpring suspensionSpring = wheelCollider.suspensionSpring;
		if (isFrontWheel)
		{
			suspensionSpring.spring = suspensionSpringFront;
		}
		else
		{
			suspensionSpring.spring = suspensionSpringRear;
		}
		suspensionSpring.damper = suspensionDamper;
		wheelCollider.suspensionSpring = suspensionSpring;
		Wheel wheel = new Wheel();
		wheel.collider = wheelCollider;
		wheelCollider.sidewaysFriction = wfc;
		wheel.wheelGraphic = wheelTransform;
		wheel.tireGraphic = (Transform)wheelTransform.GetComponentsInChildren(typeof(Transform))[1];
		wheelRadius = wheel.tireGraphic.renderer.bounds.size.y / 2f;
		wheel.collider.radius = wheelRadius;
		if (isFrontWheel)
		{
			wheel.steerWheel = true;
			gameObject = new GameObject(wheelTransform.name + " Steer Column");
			gameObject.transform.position = wheelTransform.position;
			gameObject.transform.rotation = wheelTransform.rotation;
			gameObject.transform.parent = transform;
			wheelTransform.parent = gameObject.transform;
		}
		else
		{
			wheel.driveWheel = true;
		}
		return wheel;
	}

	public virtual void SetupCenterOfMass()
	{
		if (centerOfMass != null)
		{
			rigidbody.centerOfMass = centerOfMass.localPosition;
		}
	}

	public virtual void SetupGears()
	{
		engineForceValues = new float[numberOfGears];
		gearSpeeds = new float[numberOfGears];
		float num = topSpeed;
		for (int i = 0; i < numberOfGears; i++)
		{
			if (i > 0)
			{
				gearSpeeds[i] = num / 4f + gearSpeeds[i - 1];
			}
			else
			{
				gearSpeeds[i] = num / 4f;
			}
			num -= num / 4f;
		}
		float num2 = topSpeed / gearSpeeds[gearSpeeds.Length - 1];
		for (int i = 0; i < numberOfGears; i++)
		{
			float num3 = gearSpeeds[i] * gearSpeeds[i];
			engineForceValues[i] = num3 * num2;
		}
	}

	public virtual void SetUpSkidmarks()
	{
		if ((bool)(Skidmarks)UnityEngine.Object.FindObjectOfType(typeof(Skidmarks)))
		{
			skidmarks = (Skidmarks)UnityEngine.Object.FindObjectOfType(typeof(Skidmarks));
			skidSmoke = (ParticleEmitter)skidmarks.GetComponentInChildren(typeof(ParticleEmitter));
		}
		else
		{
			Debug.Log("No skidmarks object found. Skidmarks will not be drawn");
		}
		skidmarkTime = new float[4];
		int i = 0;
		float[] array = skidmarkTime;
		for (int length = array.Length; i < length; i++)
		{
			array[i] = 0f;
		}
	}

	public virtual void GetInput()
	{
		throttle = Input.GetAxis("Vertical");
		steer = Input.GetAxis("Horizontal");
		if (!(throttle >= 0f))
		{
			brakeLights.SetFloat("_Intensity", Mathf.Abs(throttle));
		}
		else
		{
			brakeLights.SetFloat("_Intensity", 0f);
		}
		CheckHandbrake();
	}

	public virtual void CheckHandbrake()
	{
		if (Input.GetKey("space"))
		{
			if (!handbrake)
			{
				handbrake = true;
				handbrakeTime = Time.time;
				dragMultiplier.x = initialDragMultiplierX * handbrakeXDragFactor;
			}
		}
		else if (handbrake)
		{
			handbrake = false;
			StartCoroutine(StopHandbraking(Mathf.Min(5f, Time.time - handbrakeTime)));
		}
	}

	public virtual IEnumerator StopHandbraking(float seconds)
	{
		return new _0024StopHandbraking_00245470(seconds, this).GetEnumerator();
	}

	public virtual void Check_If_Car_Is_Flipped()
	{
		if (!(transform.localEulerAngles.z <= 80f) && !(transform.localEulerAngles.z >= 280f))
		{
			resetTimer += Time.deltaTime;
		}
		else
		{
			resetTimer = 0f;
		}
		if (!(resetTimer <= resetTime))
		{
			FlipCar();
		}
	}

	public virtual void FlipCar()
	{
		transform.rotation = Quaternion.LookRotation(transform.forward);
		transform.position += Vector3.up * 0.5f;
		rigidbody.velocity = Vector3.zero;
		rigidbody.angularVelocity = Vector3.zero;
		resetTimer = 0f;
		currentEnginePower = 0f;
	}

	public virtual void UpdateWheelGraphics(Vector3 relativeVelocity)
	{
		wheelCount = -1f;
		int i = 0;
		Wheel[] array = wheels;
		for (int length = array.Length; i < length; i++)
		{
			wheelCount += 1f;
			WheelCollider wheelCollider = array[i].collider;
			WheelHit hit = default(WheelHit);
			if (wheelCollider.GetGroundHit(out hit))
			{
				array[i].wheelGraphic.localPosition = wheelCollider.transform.up * (wheelRadius + wheelCollider.transform.InverseTransformPoint(hit.point).y);
				array[i].wheelVelo = rigidbody.GetPointVelocity(hit.point);
				array[i].groundSpeed = array[i].wheelGraphic.InverseTransformDirection(array[i].wheelVelo);
				if ((bool)skidmarks)
				{
					if (!(skidmarkTime[(int)wheelCount] >= 0.02f) && array[i].lastSkidmark != -1)
					{
						skidmarkTime[(int)wheelCount] = skidmarkTime[(int)wheelCount] + Time.deltaTime;
					}
					else
					{
						float num = ((skidmarkTime[(int)wheelCount] != 0f) ? skidmarkTime[(int)wheelCount] : Time.deltaTime);
						skidmarkTime[(int)wheelCount] = 0f;
						float num2 = ((!handbrake || !array[i].driveWheel) ? 0f : (array[i].wheelVelo.magnitude * 0.3f));
						float num3 = Mathf.Abs(array[i].groundSpeed.x) - 15f;
						if (num3 > 0f || !(num2 <= 0f))
						{
							Vector3 vector = transform.TransformDirection(skidSmoke.localVelocity) + skidSmoke.worldVelocity;
							if (array[i].lastSkidmark != -1)
							{
								float num4 = UnityEngine.Random.Range(skidSmoke.minEmission, skidSmoke.maxEmission);
								float num5 = array[i].lastEmitTime * num4;
								float num6 = Time.time * num4;
								int num7 = Mathf.CeilToInt(num6) - Mathf.CeilToInt(num5);
								int num8 = Mathf.CeilToInt(num5);
								for (int j = 0; j <= num7; j++)
								{
									float t = Mathf.InverseLerp(num5, num6, num8 + j);
									skidSmoke.Emit(Vector3.Lerp(array[i].lastEmitPosition, hit.point, t) + new Vector3(UnityEngine.Random.Range(-0.1f, 0.1f), UnityEngine.Random.Range(-0.1f, 0.1f), UnityEngine.Random.Range(-0.1f, 0.1f)), vector + array[i].wheelVelo * 0.05f, UnityEngine.Random.Range(skidSmoke.minSize, skidSmoke.maxSize) * Mathf.Clamp(num3 * 0.1f, 0.5f, 1f), UnityEngine.Random.Range(skidSmoke.minEnergy, skidSmoke.maxEnergy), Color.white);
								}
							}
							else
							{
								skidSmoke.Emit(hit.point + new Vector3(UnityEngine.Random.Range(-0.1f, 0.1f), UnityEngine.Random.Range(-0.1f, 0.1f), UnityEngine.Random.Range(-0.1f, 0.1f)), vector + array[i].wheelVelo * 0.05f, UnityEngine.Random.Range(skidSmoke.minSize, skidSmoke.maxSize) * Mathf.Clamp(num3 * 0.1f, 0.5f, 1f), UnityEngine.Random.Range(skidSmoke.minEnergy, skidSmoke.maxEnergy), Color.white);
							}
							array[i].lastEmitPosition = hit.point;
							array[i].lastEmitTime = Time.time;
							array[i].lastSkidmark = skidmarks.AddSkidMark(hit.point + rigidbody.velocity * num, hit.normal, (num3 * 0.1f + num2) * Mathf.Clamp01(hit.force / wheelCollider.suspensionSpring.spring), array[i].lastSkidmark);
							sound.Skid(true, Mathf.Clamp01(num3 * 0.1f));
						}
						else
						{
							array[i].lastSkidmark = -1;
							sound.Skid(false, 0f);
						}
					}
				}
			}
			else
			{
				array[i].wheelGraphic.position = wheelCollider.transform.position + -wheelCollider.transform.up * suspensionRange;
				if (array[i].steerWheel)
				{
					array[i].wheelVelo = array[i].wheelVelo * 0.9f;
				}
				else
				{
					array[i].wheelVelo = array[i].wheelVelo * (0.9f * (1f - throttle));
				}
				if ((bool)skidmarks)
				{
					array[i].lastSkidmark = -1;
					sound.Skid(false, 0f);
				}
			}
			if (array[i].steerWheel)
			{
				Vector3 localEulerAngles = array[i].wheelGraphic.parent.localEulerAngles;
				localEulerAngles.y = steer * (float)maximumTurn;
				array[i].wheelGraphic.parent.localEulerAngles = localEulerAngles;
				array[i].tireGraphic.Rotate(Vector3.right * (array[i].groundSpeed.z / wheelRadius) * Time.deltaTime * 57.29578f);
			}
			else if (!handbrake && array[i].driveWheel)
			{
				array[i].tireGraphic.Rotate(Vector3.right * (array[i].groundSpeed.z / wheelRadius) * Time.deltaTime * 57.29578f);
			}
		}
	}

	public virtual void UpdateGear(Vector3 relativeVelocity)
	{
		currentGear = 0;
		for (int i = 0; i < numberOfGears - 1; i++)
		{
			if (!(relativeVelocity.z <= gearSpeeds[i]))
			{
				currentGear = i + 1;
			}
		}
	}

	public virtual void UpdateDrag(Vector3 relativeVelocity)
	{
		Vector3 b = new Vector3((0f - relativeVelocity.x) * Mathf.Abs(relativeVelocity.x), (0f - relativeVelocity.y) * Mathf.Abs(relativeVelocity.y), (0f - relativeVelocity.z) * Mathf.Abs(relativeVelocity.z));
		Vector3 direction = Vector3.Scale(dragMultiplier, b);
		if (!(initialDragMultiplierX <= dragMultiplier.x))
		{
			direction.x /= relativeVelocity.magnitude / (topSpeed / (1f + 2f * handbrakeXDragFactor));
			direction.z *= 1f + Mathf.Abs(Vector3.Dot(rigidbody.velocity.normalized, transform.forward));
			direction += rigidbody.velocity * Mathf.Clamp01(rigidbody.velocity.magnitude / topSpeed);
		}
		else
		{
			direction.x *= topSpeed / relativeVelocity.magnitude;
		}
		if (!(Mathf.Abs(relativeVelocity.x) >= 5f) && !handbrake)
		{
			direction.x = (0f - relativeVelocity.x) * dragMultiplier.x;
		}
		rigidbody.AddForce(transform.TransformDirection(direction) * rigidbody.mass * Time.deltaTime);
	}

	public virtual void UpdateFriction(Vector3 relativeVelocity)
	{
		float num = relativeVelocity.x * relativeVelocity.x;
		wfc.extremumValue = Mathf.Clamp(300f - num, 0f, 300f);
		wfc.asymptoteValue = Mathf.Clamp(150f - num / 2f, 0f, 150f);
		int i = 0;
		Wheel[] array = wheels;
		for (int length = array.Length; i < length; i++)
		{
			array[i].collider.sidewaysFriction = wfc;
			array[i].collider.forwardFriction = wfc;
		}
	}

	public virtual void CalculateEnginePower(Vector3 relativeVelocity)
	{
		if (throttle == 0f)
		{
			currentEnginePower -= Time.deltaTime * 200f;
		}
		else if (HaveTheSameSign(relativeVelocity.z, throttle))
		{
			float normPower = currentEnginePower / engineForceValues[engineForceValues.Length - 1] * 2f;
			currentEnginePower += Time.deltaTime * 200f * EvaluateNormPower(normPower);
		}
		else
		{
			currentEnginePower -= Time.deltaTime * 300f;
		}
		if (currentGear == 0)
		{
			currentEnginePower = Mathf.Clamp(currentEnginePower, 0f, engineForceValues[0]);
		}
		else
		{
			currentEnginePower = Mathf.Clamp(currentEnginePower, engineForceValues[currentGear - 1], engineForceValues[currentGear]);
		}
	}

	public virtual void CalculateState()
	{
		canDrive = false;
		canSteer = false;
		int i = 0;
		Wheel[] array = wheels;
		for (int length = array.Length; i < length; i++)
		{
			if (array[i].collider.isGrounded)
			{
				if (array[i].steerWheel)
				{
					canSteer = true;
				}
				if (array[i].driveWheel)
				{
					canDrive = true;
				}
			}
		}
	}

	public virtual void ApplyThrottle(bool canDrive, Vector3 relativeVelocity)
	{
		if (!canDrive)
		{
			return;
		}
		float num = 0f;
		float num2 = 0f;
		if (HaveTheSameSign(relativeVelocity.z, throttle))
		{
			if (!handbrake)
			{
				num = Mathf.Sign(throttle) * currentEnginePower * rigidbody.mass;
			}
		}
		else
		{
			num2 = Mathf.Sign(throttle) * engineForceValues[0] * rigidbody.mass;
		}
		rigidbody.AddForce(transform.forward * Time.deltaTime * (num + num2));
	}

	public virtual void ApplySteering(bool canSteer, Vector3 relativeVelocity)
	{
		if (!canSteer)
		{
			return;
		}
		float num = 3f / Mathf.Sin((90f - steer * 30f) * ((float)Math.PI / 180f));
		float num2 = EvaluateSpeedToTurn(rigidbody.velocity.magnitude);
		float num3 = Mathf.Clamp(relativeVelocity.z / num, (0f - num2) / 10f, num2 / 10f);
		transform.RotateAround(transform.position + transform.right * num * steer, transform.up, num3 * 57.29578f * Time.deltaTime * steer);
		Vector3 vector = transform.position + transform.right * num * steer;
		Vector3 end = vector + Vector3.up * 5f;
		Debug.DrawLine(vector, end, Color.red);
		if (!(initialDragMultiplierX <= dragMultiplier.x))
		{
			float num4 = Mathf.Sign(steer);
			if (steer == 0f)
			{
				num4 = ((rigidbody.angularVelocity.y >= 1f) ? rigidbody.angularVelocity.y : UnityEngine.Random.Range(-1f, 1f));
			}
			transform.RotateAround(transform.TransformPoint((frontWheels[0].localPosition + frontWheels[1].localPosition) * 0.5f), transform.up, rigidbody.velocity.magnitude * Mathf.Clamp01(1f - rigidbody.velocity.magnitude / topSpeed) * num4 * Time.deltaTime * 2f);
		}
	}

	public virtual float Convert_Miles_Per_Hour_To_Meters_Per_Second(float value)
	{
		return value * 0.44704f;
	}

	public virtual float Convert_Meters_Per_Second_To_Miles_Per_Hour(float value)
	{
		return value * 2.2369363f;
	}

	public virtual bool HaveTheSameSign(float first, float second)
	{
		return (Mathf.Sign(first) == Mathf.Sign(second)) ? true : false;
	}

	public virtual float EvaluateSpeedToTurn(float speed)
	{
		float result;
		if (!(speed <= topSpeed / 2f))
		{
			result = minimumTurn;
		}
		else
		{
			float num = 1f - speed / (topSpeed / 2f);
			result = (float)minimumTurn + num * (float)(maximumTurn - minimumTurn);
		}
		return result;
	}

	public virtual float EvaluateNormPower(float normPower)
	{
		return (normPower >= 1f) ? (1.9f - normPower * 0.9f) : (10f - normPower * 9f);
	}

	public virtual float GetGearState()
	{
		Vector3 vector = transform.InverseTransformDirection(rigidbody.velocity);
		float num = ((currentGear != 0) ? gearSpeeds[currentGear - 1] : 0f);
		return (vector.z - num) / gearSpeeds[(int)((float)currentGear - num)] * (1f - (float)currentGear * 0.1f) + (float)currentGear * 0.1f;
	}

	public virtual void Main()
	{
		wheels = new Wheel[frontWheels.Length + rearWheels.Length];
		sound = (SoundController)transform.GetComponent(typeof(SoundController));
	}
}
