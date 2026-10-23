using System;
using UnityEngine;

[Serializable]
[RequireComponent(typeof(CharacterController))]
public class FPSWalker : MonoBehaviour
{
	public float speed;

	public float jumpSpeed;

	public float gravity;

	private Vector3 moveDirection;

	private bool grounded;

	public FPSWalker()
	{
		speed = 6f;
		jumpSpeed = 8f;
		gravity = 20f;
		moveDirection = Vector3.zero;
	}

	public virtual void FixedUpdate()
	{
		if (grounded)
		{
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;
			if (Input.GetButton("Jump"))
			{
				moveDirection.y = jumpSpeed;
			}
		}
		moveDirection.y -= gravity * Time.deltaTime;
		CharacterController characterController = (CharacterController)GetComponent(typeof(CharacterController));
		CollisionFlags collisionFlags = characterController.Move(moveDirection * Time.deltaTime);
		grounded = (collisionFlags & CollisionFlags.Below) != 0;
	}

	public virtual void Main()
	{
	}
}
