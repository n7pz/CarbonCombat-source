using System;
using UnityEngine;

[Serializable]
[RequireComponent(typeof(CharacterController))]
public class myThirdPersonController : MonoBehaviour
{
	public AnimationClip idleAnimation;

	public AnimationClip walkAnimation;

	public AnimationClip runAnimation;

	public AnimationClip jumpPoseAnimation;

	public AnimationClip fallPoseAnimation;

	public AnimationClip attackPoseAnimation;

	public float walkMaxAnimationSpeed;

	public float trotMaxAnimationSpeed;

	public float runMaxAnimationSpeed;

	public float jumpAnimationSpeed;

	public float fallAnimationSpeed;

	public float attackAnimationSpeed;

	private Animation _animation;

	public CharacterState _characterState;

	public Transform buik;

	public float walkSpeed;

	public float trotSpeed;

	public float runSpeed;

	public float inAirControlAcceleration;

	public float jumpHeight;

	public float gravity;

	public float speedSmoothing;

	public float rotateSpeed;

	public float trotAfterSeconds;

	public bool canJump;

	private float jumpRepeatTime;

	private float jumpTimeout;

	private float groundedTimeout;

	private float lockCameraTimer;

	private Vector3 moveDirection;

	private float verticalSpeed;

	private float moveSpeed;

	private CollisionFlags collisionFlags;

	private bool jumping;

	private bool jumpingReachedApex;

	private bool movingBack;

	private bool isMoving;

	private float walkTimeStart;

	private float lastJumpButtonTime;

	private float lastJumpTime;

	private float lastJumpStartHeight;

	private Vector3 inAirVelocity;

	private float lastGroundedTime;

	public bool isControllable;

	public myThirdPersonController()
	{
		walkMaxAnimationSpeed = 0.75f;
		trotMaxAnimationSpeed = 1f;
		runMaxAnimationSpeed = 1f;
		jumpAnimationSpeed = 1.15f;
		fallAnimationSpeed = 1f;
		attackAnimationSpeed = 1f;
		walkSpeed = 2f;
		trotSpeed = 4f;
		runSpeed = 6f;
		inAirControlAcceleration = 3f;
		jumpHeight = 0.5f;
		gravity = 20f;
		speedSmoothing = 10f;
		rotateSpeed = 500f;
		trotAfterSeconds = 3f;
		canJump = true;
		jumpRepeatTime = 0.05f;
		jumpTimeout = 0.15f;
		groundedTimeout = 0.25f;
		moveDirection = Vector3.zero;
		lastJumpButtonTime = -10f;
		lastJumpTime = -1f;
		inAirVelocity = Vector3.zero;
		isControllable = true;
	}

	public virtual void Awake()
	{
		moveDirection = transform.TransformDirection(Vector3.forward);
		_animation = (Animation)GetComponent(typeof(Animation));
		if (!_animation)
		{
			Debug.Log("The character you would like to control doesn't have animations. Moving her might look weird.");
		}
		if (!idleAnimation)
		{
			_animation = null;
			Debug.Log("No idle animation found. Turning off animations.");
		}
		if (!walkAnimation)
		{
			_animation = null;
			Debug.Log("No walk animation found. Turning off animations.");
		}
		if (!runAnimation)
		{
			_animation = null;
			Debug.Log("No run animation found. Turning off animations.");
		}
		if (!jumpPoseAnimation && canJump)
		{
			_animation = null;
			Debug.Log("No jump animation found and the character has canJump enabled. Turning off animations.");
		}
	}

	public virtual void UpdateSmoothedMovementDirection()
	{
		Transform transform = Camera.main.transform;
		bool flag = IsGrounded();
		Vector3 vector = transform.TransformDirection(Vector3.forward);
		vector.y = 0f;
		vector = vector.normalized;
		Vector3 vector2 = new Vector3(vector.z, 0f, 0f - vector.x);
		int num = 0;
		int num2 = 0;
		if (isControllable)
		{
			num = (int)Input.GetAxisRaw("Vertical");
			num2 = (int)Input.GetAxisRaw("Horizontal");
		}
		if (!((float)num >= -0.2f))
		{
			movingBack = true;
		}
		else
		{
			movingBack = false;
		}
		bool flag2 = isMoving;
		bool num3 = (float)Mathf.Abs(num2) > 0.1f;
		if (!num3)
		{
			num3 = (float)Mathf.Abs(num) > 0.1f;
		}
		isMoving = num3;
		Vector3 vector3 = num2 * vector2 + num * vector;
		if (flag)
		{
			lockCameraTimer += Time.deltaTime;
			if (isMoving != flag2)
			{
				lockCameraTimer = 0f;
			}
			if (vector3 != Vector3.zero)
			{
				if (!(moveSpeed >= walkSpeed * 0.9f) && flag)
				{
					moveDirection = vector3.normalized;
				}
				else
				{
					moveDirection = Vector3.RotateTowards(moveDirection, vector3, rotateSpeed * ((float)Math.PI / 180f) * Time.deltaTime, 1000f);
					moveDirection = moveDirection.normalized;
				}
			}
			float t = speedSmoothing * Time.deltaTime;
			float num4 = Mathf.Min(vector3.magnitude, 1f);
			_characterState = CharacterState.Idle;
			if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
			{
				num4 *= runSpeed;
				_characterState = CharacterState.Running;
			}
			else if (!(Time.time - trotAfterSeconds <= walkTimeStart))
			{
				num4 *= trotSpeed;
				_characterState = CharacterState.Trotting;
			}
			else
			{
				num4 *= walkSpeed;
				_characterState = CharacterState.Walking;
			}
			moveSpeed = Mathf.Lerp(moveSpeed, num4, t);
			if (!(moveSpeed >= walkSpeed * 0.3f))
			{
				walkTimeStart = Time.time;
			}
		}
		else
		{
			if (jumping)
			{
				lockCameraTimer = 0f;
			}
			if (isMoving)
			{
				inAirVelocity += vector3.normalized * Time.deltaTime * inAirControlAcceleration;
			}
		}
	}

	public virtual void ApplyJumping()
	{
		if (lastJumpTime + jumpRepeatTime <= Time.time && IsGrounded() && canJump && !(Time.time >= lastJumpButtonTime + jumpTimeout))
		{
			verticalSpeed = CalculateJumpVerticalSpeed(jumpHeight);
			SendMessage("DidJump", SendMessageOptions.DontRequireReceiver);
		}
	}

	public virtual void ApplyGravity()
	{
		if (isControllable)
		{
			bool button = Input.GetButton("Jump");
			if (jumping && !jumpingReachedApex && !(verticalSpeed > 0f))
			{
				jumpingReachedApex = true;
				SendMessage("DidJumpReachApex", SendMessageOptions.DontRequireReceiver);
			}
			if (IsGrounded())
			{
				verticalSpeed = 0f;
			}
			else
			{
				verticalSpeed -= gravity * Time.deltaTime;
			}
		}
	}

	public virtual float CalculateJumpVerticalSpeed(float targetJumpHeight)
	{
		return Mathf.Sqrt(2f * targetJumpHeight * gravity);
	}

	public virtual void DidJump()
	{
		jumping = true;
		jumpingReachedApex = false;
		lastJumpTime = Time.time;
		lastJumpStartHeight = transform.position.y;
		lastJumpButtonTime = -10f;
		_characterState = CharacterState.Jumping;
	}

	public virtual void Update()
	{
		if (isControllable && Input.GetButtonDown("Jump"))
		{
			lastJumpButtonTime = Time.time;
		}
		UpdateSmoothedMovementDirection();
		ApplyGravity();
		ApplyJumping();
		Vector3 vector = moveDirection * moveSpeed + new Vector3(0f, verticalSpeed, 0f) + inAirVelocity;
		vector *= Time.deltaTime;
		CharacterController characterController = (CharacterController)GetComponent(typeof(CharacterController));
		collisionFlags = characterController.Move(vector);
		if ((bool)_animation)
		{
			if (_characterState == CharacterState.Jumping)
			{
				if (!jumpingReachedApex)
				{
					_animation[jumpPoseAnimation.name].speed = jumpAnimationSpeed;
					_animation[jumpPoseAnimation.name].wrapMode = WrapMode.ClampForever;
					_animation.CrossFade(jumpPoseAnimation.name);
				}
				else
				{
					_animation[jumpPoseAnimation.name].speed = 0f - fallAnimationSpeed;
					_animation[fallPoseAnimation.name].speed = fallAnimationSpeed;
					_animation.CrossFade(fallPoseAnimation.name, 0.1f);
				}
			}
			else if (isControllable && !(characterController.velocity.sqrMagnitude >= 0.5f))
			{
				_animation.CrossFade(idleAnimation.name);
				_characterState = CharacterState.Idle;
			}
			else
			{
				if (_characterState == CharacterState.Idle)
				{
					_animation.CrossFade(idleAnimation.name);
				}
				if (_characterState == CharacterState.Running)
				{
					_animation[runAnimation.name].speed = runMaxAnimationSpeed;
					if (isControllable)
					{
						_animation[runAnimation.name].speed = Mathf.Clamp(characterController.velocity.magnitude, 0f, runMaxAnimationSpeed);
					}
					_animation.CrossFade(runAnimation.name);
				}
				else if (_characterState == CharacterState.Trotting)
				{
					_animation[walkAnimation.name].speed = trotMaxAnimationSpeed;
					if (isControllable)
					{
						_animation[walkAnimation.name].speed = Mathf.Clamp(characterController.velocity.magnitude, 0f, trotMaxAnimationSpeed);
					}
					_animation.CrossFade(walkAnimation.name);
				}
				else if (_characterState == CharacterState.Walking)
				{
					_animation[walkAnimation.name].speed = walkMaxAnimationSpeed;
					if (isControllable)
					{
						_animation[walkAnimation.name].speed = Mathf.Clamp(characterController.velocity.magnitude, 0f, walkMaxAnimationSpeed);
					}
					_animation.CrossFade(walkAnimation.name);
				}
			}
			if (isControllable && Input.GetButton("Fire1"))
			{
				animation[attackPoseAnimation.name].AddMixingTransform(buik);
				animation.CrossFade(attackPoseAnimation.name, 0.2f);
				animation.CrossFadeQueued(idleAnimation.name, 1f);
			}
		}
		if (IsGrounded())
		{
			transform.rotation = Quaternion.LookRotation(moveDirection);
		}
		else
		{
			Vector3 forward = vector;
			forward.y = 0f;
			if (!(forward.sqrMagnitude <= 0.001f))
			{
				transform.rotation = Quaternion.LookRotation(forward);
			}
		}
		if (IsGrounded())
		{
			lastGroundedTime = Time.time;
			inAirVelocity = Vector3.zero;
			if (jumping)
			{
				jumping = false;
				SendMessage("DidLand", SendMessageOptions.DontRequireReceiver);
			}
		}
	}

	public virtual void OnControllerColliderHit(ControllerColliderHit hit)
	{
		if (hit.moveDirection.y <= 0.01f)
		{
		}
	}

	public virtual float GetSpeed()
	{
		return moveSpeed;
	}

	public virtual bool IsJumping()
	{
		return jumping;
	}

	public virtual bool IsGrounded()
	{
		return (collisionFlags & CollisionFlags.Below) != 0;
	}

	public virtual Vector3 GetDirection()
	{
		return moveDirection;
	}

	public virtual bool IsMovingBackwards()
	{
		return movingBack;
	}

	public virtual float GetLockCameraTimer()
	{
		return lockCameraTimer;
	}

	public virtual bool IsMoving()
	{
		return Mathf.Abs(Input.GetAxisRaw("Vertical")) + Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.5f;
	}

	public virtual bool HasJumpReachedApex()
	{
		return jumpingReachedApex;
	}

	public virtual bool IsGroundedWithTimeout()
	{
		return lastGroundedTime + groundedTimeout > Time.time;
	}

	public virtual void Reset()
	{
		gameObject.tag = "Player";
	}

	public virtual void Main()
	{
	}
}
