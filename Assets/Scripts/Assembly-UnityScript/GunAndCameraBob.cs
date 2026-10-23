using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using Photon;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class GunAndCameraBob : Photon.MonoBehaviour
{
	[Serializable]
	internal sealed class _0024startCrouch_00243966 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal GunAndCameraBob _0024self__00243967;

			public _0024(GunAndCameraBob self_)
			{
				_0024self__00243967 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					Debug.Log("Network crouch!");
					_0024self__00243967.isCrouching = true;
					_0024self__00243967.crouchSpeedMultiplier = 0.45f;
					goto case 2;
				case 2:
					if (!(_0024self__00243967.globalCrouchBlend >= 1f) && _0024self__00243967.isCrouching)
					{
						_0024self__00243967.globalCrouchBlend = Mathf.Min(1f, _0024self__00243967.globalCrouchBlend + 5f * Time.deltaTime);
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal GunAndCameraBob _0024self__00243968;

		public _0024startCrouch_00243966(GunAndCameraBob self_)
		{
			_0024self__00243968 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00243968);
		}
	}

	[Serializable]
	internal sealed class _0024endCrouch_00243969 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal GunAndCameraBob _0024self__00243970;

			public _0024(GunAndCameraBob self_)
			{
				_0024self__00243970 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					Debug.Log("Network end crouch!");
					_0024self__00243970.isCrouching = false;
					_0024self__00243970.crouchSpeedMultiplier = 1f;
					goto case 2;
				case 2:
					if (!(_0024self__00243970.globalCrouchBlend <= 0f) && !_0024self__00243970.isCrouching)
					{
						_0024self__00243970.globalCrouchBlend = Mathf.Max(0f, _0024self__00243970.globalCrouchBlend - 5f * Time.deltaTime);
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal GunAndCameraBob _0024self__00243971;

		public _0024endCrouch_00243969(GunAndCameraBob self_)
		{
			_0024self__00243971 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00243971);
		}
	}

	[Serializable]
	internal sealed class _0024crouch_00243972 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal CharacterController _0024controller_00243973;

			internal CheckIfSpaceIsClear _0024isClearObj_00243974;

			internal float _0024_00242211_00243975;

			internal Vector3 _0024_00242212_00243976;

			internal float _0024_00242213_00243977;

			internal Vector3 _0024_00242214_00243978;

			internal int _0024_00242215_00243979;

			internal Vector3 _0024_00242216_00243980;

			internal GunAndCameraBob _0024self__00243981;

			public _0024(GunAndCameraBob self_)
			{
				_0024self__00243981 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__00243981.photonView.isMine && !_0024self__00243981.triggeredKneeBend)
					{
						_0024self__00243981.triggeredKneeBend = true;
						((PhotonView)_0024self__00243981.gameObject.GetComponent(typeof(PhotonView))).RPC("startCrouch", PhotonTargets.Others);
						_0024controller_00243973 = (CharacterController)_0024self__00243981.GetComponent(typeof(CharacterController));
						((CharacterMotor)_0024self__00243981.gameObject.GetComponent(typeof(CharacterMotor))).movement.maxForwardSpeed = ((CharacterMotor)_0024self__00243981.gameObject.GetComponent(typeof(CharacterMotor))).movement.maxForwardSpeed * 0.45f;
						((CharacterMotor)_0024self__00243981.gameObject.GetComponent(typeof(CharacterMotor))).movement.maxSidewaysSpeed = ((CharacterMotor)_0024self__00243981.gameObject.GetComponent(typeof(CharacterMotor))).movement.maxSidewaysSpeed * 0.45f;
						((CharacterMotor)_0024self__00243981.gameObject.GetComponent(typeof(CharacterMotor))).movement.maxBackwardsSpeed = ((CharacterMotor)_0024self__00243981.gameObject.GetComponent(typeof(CharacterMotor))).movement.maxBackwardsSpeed * 0.45f;
						goto case 2;
					}
					goto IL_061d;
				case 2:
					if (!(_0024controller_00243973.height <= 1.625f) && Input.GetButton("Shift"))
					{
						_0024controller_00243973.height = Mathf.Max(1.625f, _0024controller_00243973.height - 2.5f * Time.deltaTime);
						float num5 = (_0024_00242211_00243975 = _0024self__00243981.crouchObj.localPosition.y - 5f * Time.deltaTime / 2f);
						Vector3 vector7 = (_0024_00242212_00243976 = _0024self__00243981.crouchObj.localPosition);
						float num6 = (_0024_00242212_00243976.y = _0024_00242211_00243975);
						Vector3 vector8 = (_0024self__00243981.crouchObj.localPosition = _0024_00242212_00243976);
						_0024controller_00243973.center -= new Vector3(0f, 2.5f * Time.deltaTime / 2f, 0f);
						if (_0024controller_00243973.height == 1.625f)
						{
							_0024controller_00243973.center = new Vector3(0f, -0.1875f, 0.15f);
						}
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					goto case 3;
				case 3:
					if (Input.GetButton("Shift"))
					{
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					((PhotonView)_0024self__00243981.gameObject.GetComponent(typeof(PhotonView))).RPC("endCrouch", PhotonTargets.Others);
					_0024isClearObj_00243974 = (CheckIfSpaceIsClear)_0024self__00243981.transform.Find("Trigger").GetComponent(typeof(CheckIfSpaceIsClear));
					goto case 4;
				case 4:
					if (_0024controller_00243973.height < 2f)
					{
						if (_0024isClearObj_00243974.isClear)
						{
							_0024controller_00243973.height = Mathf.Min(2f, _0024controller_00243973.height + 2.5f * Time.deltaTime);
							float num = (_0024_00242213_00243977 = _0024self__00243981.crouchObj.localPosition.y + 5f * Time.deltaTime / 2f);
							Vector3 vector = (_0024_00242214_00243978 = _0024self__00243981.crouchObj.localPosition);
							float num2 = (_0024_00242214_00243978.y = _0024_00242213_00243977);
							Vector3 vector2 = (_0024self__00243981.crouchObj.localPosition = _0024_00242214_00243978);
							_0024controller_00243973.center += new Vector3(0f, 2.5f * Time.deltaTime / 2f, 0f);
							if (_0024controller_00243973.height == 2f)
							{
								_0024controller_00243973.center = new Vector3(0f, 0f, 0.15f);
								int num3 = (_0024_00242215_00243979 = 0);
								Vector3 vector4 = (_0024_00242216_00243980 = _0024self__00243981.crouchObj.localPosition);
								float num4 = (_0024_00242216_00243980.y = _0024_00242215_00243979);
								Vector3 vector5 = (_0024self__00243981.crouchObj.localPosition = _0024_00242216_00243980);
							}
						}
						result = (YieldDefault(4) ? 1 : 0);
						break;
					}
					((CharacterMotor)_0024self__00243981.gameObject.GetComponent(typeof(CharacterMotor))).movement.maxForwardSpeed = ((CharacterMotor)_0024self__00243981.gameObject.GetComponent(typeof(CharacterMotor))).movement.maxForwardSpeed / 0.45f;
					((CharacterMotor)_0024self__00243981.gameObject.GetComponent(typeof(CharacterMotor))).movement.maxSidewaysSpeed = ((CharacterMotor)_0024self__00243981.gameObject.GetComponent(typeof(CharacterMotor))).movement.maxSidewaysSpeed / 0.45f;
					((CharacterMotor)_0024self__00243981.gameObject.GetComponent(typeof(CharacterMotor))).movement.maxBackwardsSpeed = ((CharacterMotor)_0024self__00243981.gameObject.GetComponent(typeof(CharacterMotor))).movement.maxBackwardsSpeed / 0.45f;
					_0024self__00243981.triggeredKneeBend = false;
					goto IL_061d;
				case 1:
					{
						result = 0;
						break;
					}
					IL_061d:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal GunAndCameraBob _0024self__00243982;

		public _0024crouch_00243972(GunAndCameraBob self_)
		{
			_0024self__00243982 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00243982);
		}
	}

	[Serializable]
	internal sealed class _0024bendAnimation_00243983 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal CharacterController _0024controller_00243984;

			internal CheckIfSpaceIsClear _0024isClearObj_00243985;

			internal float _0024_00242217_00243986;

			internal Vector3 _0024_00242218_00243987;

			internal float _0024_00242219_00243988;

			internal Vector3 _0024_00242220_00243989;

			internal int _0024_00242221_00243990;

			internal Vector3 _0024_00242222_00243991;

			internal GunAndCameraBob _0024self__00243992;

			public _0024(GunAndCameraBob self_)
			{
				_0024self__00243992 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__00243992.photonView.isMine)
					{
						_0024controller_00243984 = (CharacterController)_0024self__00243992.GetComponent(typeof(CharacterController));
						goto case 2;
					}
					goto IL_03a1;
				case 2:
					if (!_0024controller_00243984.isGrounded)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					goto case 3;
				case 3:
					if (!(_0024controller_00243984.height <= 1.625f) && !Input.GetButton("Shift"))
					{
						_0024controller_00243984.height = Mathf.Max(1.625f, _0024controller_00243984.height - 2.5f * Time.deltaTime);
						float num = (_0024_00242217_00243986 = _0024self__00243992.crouchObj.localPosition.y - 5f * Time.deltaTime / 2f);
						Vector3 vector = (_0024_00242218_00243987 = _0024self__00243992.crouchObj.localPosition);
						float num2 = (_0024_00242218_00243987.y = _0024_00242217_00243986);
						Vector3 vector2 = (_0024self__00243992.crouchObj.localPosition = _0024_00242218_00243987);
						_0024controller_00243984.center -= new Vector3(0f, 2.5f * Time.deltaTime / 2f, 0f);
						if (_0024controller_00243984.height == 1.625f)
						{
							_0024controller_00243984.center = new Vector3(0f, -0.1875f, 0.15f);
						}
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					if (!Input.GetButton("Shift"))
					{
						_0024isClearObj_00243985 = (CheckIfSpaceIsClear)_0024self__00243992.transform.Find("Trigger").GetComponent(typeof(CheckIfSpaceIsClear));
						goto case 4;
					}
					goto IL_0395;
				case 4:
					if (_0024controller_00243984.height < 2f)
					{
						if (_0024isClearObj_00243985.isClear)
						{
							_0024controller_00243984.height = Mathf.Min(2f, _0024controller_00243984.height + 2.5f * Time.deltaTime);
							float num3 = (_0024_00242219_00243988 = _0024self__00243992.crouchObj.localPosition.y + 5f * Time.deltaTime / 2f);
							Vector3 vector4 = (_0024_00242220_00243989 = _0024self__00243992.crouchObj.localPosition);
							float num4 = (_0024_00242220_00243989.y = _0024_00242219_00243988);
							Vector3 vector5 = (_0024self__00243992.crouchObj.localPosition = _0024_00242220_00243989);
							_0024controller_00243984.center += new Vector3(0f, 2.5f * Time.deltaTime / 2f, 0f);
							if (_0024controller_00243984.height == 2f)
							{
								_0024controller_00243984.center = new Vector3(0f, 0f, 0.15f);
								int num5 = (_0024_00242221_00243990 = 0);
								Vector3 vector7 = (_0024_00242222_00243991 = _0024self__00243992.crouchObj.localPosition);
								float num6 = (_0024_00242222_00243991.y = _0024_00242221_00243990);
								Vector3 vector8 = (_0024self__00243992.crouchObj.localPosition = _0024_00242222_00243991);
							}
						}
						result = (YieldDefault(4) ? 1 : 0);
						break;
					}
					goto IL_0395;
				case 1:
					{
						result = 0;
						break;
					}
					IL_03a1:
					YieldDefault(1);
					goto case 1;
					IL_0395:
					_0024self__00243992.triggeredKneeBend = false;
					goto IL_03a1;
				}
				return (byte)result != 0;
			}
		}

		internal GunAndCameraBob _0024self__00243993;

		public _0024bendAnimation_00243983(GunAndCameraBob self_)
		{
			_0024self__00243993 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00243993);
		}
	}

	public Transform gunObj;

	public Transform camObj;

	public Transform crouchObj;

	private int bobState;

	private bool triggeredKneeBend;

	private int idleState;

	private float idleAmount;

	private float initCamY;

	private float initRelY;

	private Vector3 gunOffset;

	private Vector3 origGunPos;

	private Transform relCamObj;

	public bool bulletFire;

	public string team;

	public GameObject soldierAnim;

	private soldierAnimation sAnimScript;

	private SpawningScript spawnsrc;

	private AuthGameObject authobj;

	private PauseObject pobj;

	private ChatScript cscript;

	private EndofRound eor;

	private ConduitInputReciever cInput;

	public Renderer[] rens;

	public Color redColor;

	public Color greyColor;

	public float globalCrouchBlend;

	public float crouchSpeedMultiplier;

	private bool isCrouching;

	public LayerMask layerMask;

	public GunAndCameraBob()
	{
		team = string.Empty;
		crouchSpeedMultiplier = 1f;
	}

	public virtual void Awake()
	{
		sAnimScript = (soldierAnimation)soldierAnim.GetComponent(typeof(soldierAnimation));
		initCamY = camObj.localPosition.y;
		origGunPos = gunObj.parent.localPosition;
		GameObject gameObject = new GameObject("CamObj");
		relCamObj = gameObject.transform;
		relCamObj.position = gunObj.parent.position;
		relCamObj.rotation = gunObj.parent.rotation;
		relCamObj.parent = camObj.transform;
		initRelY = relCamObj.localPosition.y;
	}

	public virtual void Start()
	{
		SpawningScript.spawnedCars.Add(gameObject);
		if (!photonView.isMine)
		{
			UnityEngine.Object.Destroy((MouseLook)gameObject.GetComponent(typeof(MouseLook)));
			UnityEngine.Object.Destroy((FPSInputController)gameObject.GetComponent(typeof(FPSInputController)));
			UnityEngine.Object.Destroy((CharacterMotor)gameObject.GetComponent(typeof(CharacterMotor)));
			gunObj.renderer.enabled = false;
			if (team == "red" && AuthGameObject.gametype != "Freeplay" && AuthGameObject.gametype != "Deathmatch" && AuthGameObject.gametype != "Survival")
			{
				int i = 0;
				Renderer[] array = rens;
				for (int length = array.Length; i < length; i++)
				{
					int j = 0;
					Material[] materials = array[i].materials;
					for (int length2 = materials.Length; j < length2; j++)
					{
						if (materials[j].shader.name == "Reflective/Bumped Specular")
						{
							materials[j].color = redColor;
						}
					}
				}
			}
			if (team == "red" && (AuthGameObject.gametype == "Freeplay" || AuthGameObject.gametype == "Deathmatch" || AuthGameObject.gametype == "Survival"))
			{
				int k = 0;
				Renderer[] array2 = rens;
				for (int length3 = array2.Length; k < length3; k++)
				{
					int l = 0;
					Material[] materials2 = array2[k].materials;
					for (int length4 = materials2.Length; l < length4; l++)
					{
						if (materials2[l].shader.name == "Reflective/Bumped Specular")
						{
							materials2[l].color = greyColor;
						}
					}
				}
			}
		}
		else
		{
			transform.Find("soldier3rdPerson").gameObject.SetActiveRecursively(false);
		}
		if (photonView.isMine)
		{
			Camera.main.nearClipPlane = 0.1f;
		}
		GameObject.Find("/GUI/QualitySettings").SendMessage("preSetAllObj");
		if (QualitySettings.GetQualityLevel() == 0)
		{
			GameObject.Find("/GUI/QualitySettings").SendMessage("setAllObjectsSimp");
		}
	}

	[RPC]
	public virtual void setJumpFlame(bool b)
	{
		sAnimScript.emitParticles = b;
	}

	public virtual void LateUpdate()
	{
		if (photonView.isMine && (EndofRound.alphastat != 0f || PauseObject.pubalpha != 0f))
		{
			Screen.lockCursor = false;
		}
		if (!photonView.isMine || ChatScript.isDisconnecting || PauseObject.pubalpha != 0f || EndofRound.alphastat != 0f)
		{
			return;
		}
		CharacterController characterController = (CharacterController)GetComponent(typeof(CharacterController));
		if (!Screen.showCursor && PauseObject.pubalpha == 0f)
		{
			Screen.lockCursor = true;
		}
		else
		{
			Screen.lockCursor = false;
		}
		if (Input.GetAxis("Mouse X") != 0f || RuntimeServices.ToBool(RuntimeServices.InvokeBinaryOperator("op_GreaterThan", RuntimeServices.Invoke(typeof(Mathf), "Abs", new object[1] { UnityRuntimeServices.GetProperty(ConduitInputReciever.ht["tPad"], "x") }), 0)))
		{
			gunOffset.x = Mathf.Clamp(Mathf.SmoothStep(gunOffset.x, 0.1f * (float)(-Mathf.Clamp(RuntimeServices.UnboxInt32((Input.GetAxis("Mouse X") <= 0f) ? RuntimeServices.InvokeBinaryOperator("op_Division", UnityRuntimeServices.GetProperty(ConduitInputReciever.ht["tPad"], "x"), 3.5f) : ((object)Input.GetAxis("Mouse X"))), -1, 1)), 8f * Time.deltaTime), -0.05f, 0.05f);
		}
		else
		{
			gunOffset.x = Mathf.Clamp(Mathf.SmoothStep(gunOffset.x, 0f, 15f * Time.deltaTime), -0.05f, 0.05f);
		}
		if ((Input.GetButton("Jump") || RuntimeServices.ToBool(ConduitInputReciever.ht["jump"])) && !characterController.isGrounded)
		{
			gunOffset.y = Mathf.Clamp(Mathf.SmoothStep(gunOffset.y, -0.1f, 8f * Time.deltaTime), -0.05f, 0.05f);
			if (!sAnimScript.emitParticles)
			{
				sAnimScript.emitParticles = true;
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("setJumpFlame", PhotonTargets.Others, true);
			}
		}
		if ((!Input.GetButton("Jump") || !RuntimeServices.ToBool(ConduitInputReciever.ht["jump"])) && !characterController.isGrounded)
		{
			gunOffset.y = Mathf.Clamp(Mathf.SmoothStep(gunOffset.y, 0.1f, 8f * Time.deltaTime), -0.05f, 0.05f);
			if (sAnimScript.emitParticles)
			{
				sAnimScript.emitParticles = false;
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("setJumpFlame", PhotonTargets.Others, false);
			}
		}
		if (Input.GetAxis("Mouse Y") != 0f || RuntimeServices.ToBool(RuntimeServices.InvokeBinaryOperator("op_GreaterThan", RuntimeServices.Invoke(typeof(Mathf), "Abs", new object[1] { UnityRuntimeServices.GetProperty(ConduitInputReciever.ht["tPad"], "y") }), 0)))
		{
			gunOffset.y = Mathf.Clamp(Mathf.SmoothStep(gunOffset.y, 0.1f * (float)(-Mathf.Clamp(RuntimeServices.UnboxInt32((Input.GetAxis("Mouse Y") <= 0f) ? RuntimeServices.InvokeBinaryOperator("op_Division", UnityRuntimeServices.GetProperty(ConduitInputReciever.ht["tPad"], "y"), 3.5f) : ((object)Input.GetAxis("Mouse Y"))), -1, 1)), 8f * Time.deltaTime), -0.05f, 0.05f);
		}
		else
		{
			gunOffset.y = Mathf.Clamp(Mathf.SmoothStep(gunOffset.y, 0f, 15f * Time.deltaTime), -0.05f, 0.05f);
		}
		if (bulletFire)
		{
			bulletFire = false;
			gunOffset.z = -0.075f;
		}
		else
		{
			gunOffset.z = Mathf.SmoothStep(gunOffset.z, 0f, 15f * Time.deltaTime);
		}
		if (bobState == 0 && gunObj.localPosition.x != 0.13f)
		{
			if (!(gunObj.localPosition.x <= 0.13f))
			{
				float x = Mathf.Max(gunObj.localPosition.x - 0.08f * Time.deltaTime, 0.13f);
				Vector3 localPosition = gunObj.localPosition;
				float num = (localPosition.x = x);
				Vector3 vector = (gunObj.localPosition = localPosition);
			}
			if (!(gunObj.localPosition.x >= 0.13f))
			{
				float x2 = Mathf.Min(gunObj.localPosition.x + 0.15f * Time.deltaTime, 0.13f);
				Vector3 localPosition2 = gunObj.localPosition;
				float num2 = (localPosition2.x = x2);
				Vector3 vector3 = (gunObj.localPosition = localPosition2);
			}
		}
		if (bobState == -1)
		{
			if (!(gunObj.localPosition.x <= 0.11f))
			{
				float x3 = Mathf.Max(gunObj.localPosition.x - 0.1f * Time.deltaTime, 0.11f);
				Vector3 localPosition3 = gunObj.localPosition;
				float num3 = (localPosition3.x = x3);
				Vector3 vector5 = (gunObj.localPosition = localPosition3);
			}
			if (gunObj.localPosition.x == 0.11f)
			{
				bobState = 1;
			}
		}
		if (bobState == 1)
		{
			if (!(gunObj.localPosition.x >= 0.15f))
			{
				float x4 = Mathf.Min(gunObj.localPosition.x + 0.1f * Time.deltaTime, 0.15f);
				Vector3 localPosition4 = gunObj.localPosition;
				float num4 = (localPosition4.x = x4);
				Vector3 vector7 = (gunObj.localPosition = localPosition4);
			}
			if (gunObj.localPosition.x == 0.15f)
			{
				bobState = -1;
			}
		}
		float y = 0.63f + gunOffset.y + (0f - 50f * ((gunObj.localPosition.x - 0.13f) * (gunObj.localPosition.x - 0.13f)));
		Vector3 localPosition5 = gunObj.localPosition;
		float num5 = (localPosition5.y = y);
		Vector3 vector9 = (gunObj.localPosition = localPosition5);
		if ((Input.GetAxis("Vertical") == 1f || Input.GetAxis("Horizontal") == 1f || Input.GetAxis("Vertical") == -1f || Input.GetAxis("Horizontal") == -1f || RuntimeServices.ToBool(RuntimeServices.InvokeBinaryOperator("op_GreaterThan", RuntimeServices.Invoke(typeof(Mathf), "Abs", new object[1] { UnityRuntimeServices.GetProperty(ConduitInputReciever.ht["dPad"], "x") }), 0)) || RuntimeServices.ToBool(RuntimeServices.InvokeBinaryOperator("op_GreaterThan", RuntimeServices.Invoke(typeof(Mathf), "Abs", new object[1] { UnityRuntimeServices.GetProperty(ConduitInputReciever.ht["dPad"], "y") }), 0))) && bobState == 0 && characterController.isGrounded && !Input.GetButton("Fire1") && !RuntimeServices.ToBool(ConduitInputReciever.ht["tPadState"]))
		{
			bobState = 1;
		}
		else if ((Input.GetAxis("Vertical") != 1f && Input.GetAxis("Horizontal") != 1f && Input.GetAxis("Vertical") != -1f && Input.GetAxis("Horizontal") != -1f && RuntimeServices.EqualityOperator(RuntimeServices.Invoke(typeof(Mathf), "Abs", new object[1] { UnityRuntimeServices.GetProperty(ConduitInputReciever.ht["dPad"], "x") }), 0) && RuntimeServices.EqualityOperator(RuntimeServices.Invoke(typeof(Mathf), "Abs", new object[1] { UnityRuntimeServices.GetProperty(ConduitInputReciever.ht["dPad"], "y") }), 0)) || !characterController.isGrounded || Input.GetButton("Fire1"))
		{
			bobState = 0;
		}
		if (Input.GetAxis("Vertical") == 0f && Input.GetAxis("Horizontal") == 0f && RuntimeServices.EqualityOperator(RuntimeServices.Invoke(typeof(Mathf), "Abs", new object[1] { UnityRuntimeServices.GetProperty(ConduitInputReciever.ht["dPad"], "x") }), 0) && RuntimeServices.EqualityOperator(RuntimeServices.Invoke(typeof(Mathf), "Abs", new object[1] { UnityRuntimeServices.GetProperty(ConduitInputReciever.ht["dPad"], "y") }), 0))
		{
			if (idleState == 0)
			{
				idleState = 1;
			}
		}
		else
		{
			idleState = 0;
		}
		if (idleState == 1)
		{
			if (!(idleAmount >= 0.007f))
			{
				idleAmount = Mathf.SmoothStep(idleAmount, 0.008f, 3.5f * Time.deltaTime);
				float y2 = initCamY + idleAmount;
				Vector3 localPosition6 = camObj.localPosition;
				float num6 = (localPosition6.y = y2);
				Vector3 vector11 = (camObj.localPosition = localPosition6);
				float y3 = initRelY - idleAmount;
				Vector3 localPosition7 = relCamObj.localPosition;
				float num7 = (localPosition7.y = y3);
				Vector3 vector13 = (relCamObj.localPosition = localPosition7);
			}
			else
			{
				idleState = -1;
				idleAmount = 0.007f;
			}
		}
		if (idleState == -1)
		{
			if (!(idleAmount <= 0f))
			{
				idleAmount = Mathf.SmoothStep(idleAmount, -0.001f, 3.5f * Time.deltaTime);
				float y4 = initCamY + idleAmount;
				Vector3 localPosition8 = camObj.localPosition;
				float num8 = (localPosition8.y = y4);
				Vector3 vector15 = (camObj.localPosition = localPosition8);
				float y5 = initRelY - idleAmount;
				Vector3 localPosition9 = relCamObj.localPosition;
				float num9 = (localPosition9.y = y5);
				Vector3 vector17 = (relCamObj.localPosition = localPosition9);
			}
			else
			{
				idleState = 1;
				idleAmount = 0f;
			}
		}
		if (!triggeredKneeBend && !characterController.isGrounded)
		{
			triggeredKneeBend = true;
			StartCoroutine_Auto(bendAnimation());
		}
		if (Input.GetButtonDown("Shift"))
		{
			StartCoroutine_Auto(crouch());
		}
		gunObj.parent.position = relCamObj.position;
		float x5 = gunObj.parent.localPosition.x + gunOffset.x;
		Vector3 localPosition10 = gunObj.parent.localPosition;
		float num10 = (localPosition10.x = x5);
		Vector3 vector19 = (gunObj.parent.localPosition = localPosition10);
		float z = 0.1696574f + gunOffset.z;
		Vector3 localPosition11 = gunObj.localPosition;
		float num11 = (localPosition11.z = z);
		Vector3 vector21 = (gunObj.localPosition = localPosition11);
		float x6 = camObj.localRotation.x;
		Quaternion localRotation = gunObj.parent.localRotation;
		float num12 = (localRotation.x = x6);
		Quaternion quaternion = (gunObj.parent.localRotation = localRotation);
	}

	[RPC]
	public virtual IEnumerator startCrouch()
	{
		return new _0024startCrouch_00243966(this).GetEnumerator();
	}

	[RPC]
	public virtual IEnumerator endCrouch()
	{
		return new _0024endCrouch_00243969(this).GetEnumerator();
	}

	public virtual IEnumerator crouch()
	{
		return new _0024crouch_00243972(this).GetEnumerator();
	}

	public virtual IEnumerator bendAnimation()
	{
		return new _0024bendAnimation_00243983(this).GetEnumerator();
	}
}
