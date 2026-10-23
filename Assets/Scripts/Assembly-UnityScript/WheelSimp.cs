using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class WheelSimp : MonoBehaviour
{
	public Renderer wheel1;

	public Renderer wheel2;

	public Renderer wheel3;

	public Renderer wheel4;

	public Renderer simp1;

	public Renderer simp2;

	public Renderer simp3;

	public Renderer simp4;

	public Renderer shock1;

	public Renderer shock2;

	public Renderer shock3;

	public Renderer shock4;

	public virtual void wheelsimp(object t)
	{
		if (RuntimeServices.EqualityOperator(t, true))
		{
			wheel1.enabled = false;
			wheel2.enabled = false;
			wheel3.enabled = false;
			wheel4.enabled = false;
			simp1.enabled = true;
			simp2.enabled = true;
			simp3.enabled = true;
			simp4.enabled = true;
			shock1.enabled = false;
			shock2.enabled = false;
			shock3.enabled = false;
			shock4.enabled = false;
		}
		else
		{
			wheel1.enabled = true;
			wheel2.enabled = true;
			wheel3.enabled = true;
			wheel4.enabled = true;
			simp1.enabled = false;
			simp2.enabled = false;
			simp3.enabled = false;
			simp4.enabled = false;
			shock1.enabled = true;
			shock2.enabled = true;
			shock3.enabled = true;
			shock4.enabled = true;
		}
	}

	public virtual void Main()
	{
	}
}
