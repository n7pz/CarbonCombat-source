using System;
using UnityEngine;

[Serializable]
[RequireComponent(typeof(CharacterController))]
public class crouchController : MonoBehaviour
{
	public float crouchSpeedMultiplier;

	public float crouchTogglingTime;

	public float globalCrouchBlend;

	private float globalCrouchBlendTarget;

	private float globalCrouchBlendVelocity;

	private bool disable;

	public crouchController()
	{
		crouchSpeedMultiplier = 0.5f;
		crouchTogglingTime = 0.1f;
	}

	public virtual void Update()
	{
		if (Input.GetKeyDown(KeyCode.C))
		{
			if (!disable)
			{
				if (!(globalCrouchBlend >= 0.5f))
				{
					globalCrouchBlendTarget = 1f;
				}
				else
				{
					globalCrouchBlendTarget = 0f;
				}
			}
			disable = true;
		}
		else
		{
			disable = false;
		}
		globalCrouchBlend = Mathf.SmoothDamp(globalCrouchBlend, globalCrouchBlendTarget, ref globalCrouchBlendVelocity, crouchTogglingTime);
	}

	public virtual void Main()
	{
	}
}
