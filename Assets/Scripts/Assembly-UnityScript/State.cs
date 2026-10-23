using System;
using UnityEngine;

[Serializable]
public class State
{
	public Vector3 pos;

	public Quaternion rot;

	public float ntime;

	public Vector3 cpos;

	public Quaternion crot;

	public float ltime;

	public State(Vector3 pos, Quaternion rot, float ntime, Vector3 cpos, Quaternion crot)
	{
		this.pos = pos;
		this.rot = rot;
		this.ntime = ntime;
		this.cpos = cpos;
		this.crot = crot;
		ltime = Time.time;
	}
}
