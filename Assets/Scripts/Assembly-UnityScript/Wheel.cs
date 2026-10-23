using System;
using UnityEngine;

[Serializable]
public class Wheel
{
	public WheelCollider collider;

	public Transform wheelGraphic;

	public Transform tireGraphic;

	public bool driveWheel;

	public bool steerWheel;

	public int lastSkidmark;

	public Vector3 lastEmitPosition;

	public float lastEmitTime;

	public Vector3 wheelVelo;

	public Vector3 groundSpeed;

	public Wheel()
	{
		lastSkidmark = -1;
		lastEmitPosition = Vector3.zero;
		lastEmitTime = Time.time;
		wheelVelo = Vector3.zero;
		groundSpeed = Vector3.zero;
	}
}
