using System;
using UnityEngine;

[Serializable]
public class DamageObject
{
	public string amount;

	public Vector3 pos;

	public float displayTime;

	public float alpha;

	public Vector2 pOffset;

	public DamageObject(string amount, Vector3 pos, float displayTime, float alpha, Vector2 pOffset)
	{
		this.amount = amount;
		this.pos = pos;
		this.displayTime = displayTime;
		this.alpha = alpha;
		this.pOffset = pOffset;
	}
}
