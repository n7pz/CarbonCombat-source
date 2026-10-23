using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class AIManager : MonoBehaviour
{
	[Serializable]
	internal sealed class _0024stopSteer_00244073 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal AIManager _0024self__00244074;

			public _0024(AIManager self_)
			{
				_0024self__00244074 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (!_0024self__00244074.stopsteer && Application.loadedLevelName == "MainScene")
					{
						_0024self__00244074.stopsteer = true;
						result = (Yield(2, new WaitForSeconds(8f)) ? 1 : 0);
						break;
					}
					goto IL_0066;
				case 2:
					_0024self__00244074.stopsteer = false;
					goto IL_0066;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0066:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal AIManager _0024self__00244075;

		public _0024stopSteer_00244073(AIManager self_)
		{
			_0024self__00244075 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00244075);
		}
	}

	[Serializable]
	internal sealed class _0024startRoll_00244076 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal int _0024howManyG_00244077;

			internal WheelCollider _0024wheel_00244078;

			internal int _0024_0024580_00244079;

			internal WheelCollider[] _0024_0024581_00244080;

			internal int _0024_0024582_00244081;

			internal AIManager _0024self__00244082;

			public _0024(AIManager self_)
			{
				_0024self__00244082 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00244082.rollDisable = true;
					result = (Yield(2, new WaitForSeconds(1.2f)) ? 1 : 0);
					break;
				case 2:
					_0024howManyG_00244077 = 0;
					_0024_0024580_00244079 = 0;
					_0024_0024581_00244080 = _0024self__00244082.wheels;
					for (_0024_0024582_00244081 = _0024_0024581_00244080.Length; _0024_0024580_00244079 < _0024_0024582_00244081; _0024_0024580_00244079++)
					{
						if (_0024_0024581_00244080[_0024_0024580_00244079].isGrounded)
						{
							_0024howManyG_00244077++;
						}
					}
					if (_0024howManyG_00244077 <= 1)
					{
						_0024self__00244082.rigidbody.AddForce(0f, 350000f, 0f);
						_0024self__00244082.rigidbody.AddRelativeTorque(0f, 0f, 20000000f);
					}
					_0024self__00244082.startedRoll = false;
					result = (Yield(3, new WaitForSeconds(UnityEngine.Random.Range(1f, 2f))) ? 1 : 0);
					break;
				case 3:
					_0024self__00244082.rollDisable = false;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal AIManager _0024self__00244083;

		public _0024startRoll_00244076(AIManager self_)
		{
			_0024self__00244083 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00244083);
		}
	}

	public float horizontalInput;

	public float verticalInput;

	public bool spaceButton;

	public int firetype;

	public Transform[] rayPoints;

	public LayerMask layermask;

	private float timeBetweenControl;

	private Vector3 lastPos;

	private float lastPosCheck;

	public Transform target;

	public string aiteam;

	public string ainame;

	public bool isAI;

	public WheelCollider[] wheels;

	private bool startedRoll;

	public bool isDead;

	private bool stopsteer;

	public bool stopFiring;

	public bool stopMoving;

	public int aihealth;

	public bool hideBadge;

	private GameObject badgeObj;

	public bool forceEnable;

	private bool rollDisable;

	public AuthGameObject authobj;

	public SpawningScript spwnsrc;

	private float targetCounter;

	public EndofRound endofround;

	public DisplayTopPlayers dplayer;

	public TutorialManager tMan;

	public int armorLevel;

	public int aiDiff;

	public GameObject localHealthObj;

	public AIManager()
	{
		verticalInput = 1f;
		timeBetweenControl = 0.5f;
		lastPos = Vector3.zero;
		lastPosCheck = 1.5f;
		aihealth = 100;
		targetCounter = 1f;
	}

	public virtual void resetHealth()
	{
		((HardImpactSend)gameObject.GetComponent(typeof(HardImpactSend))).resethealth();
	}

	public virtual void Start()
	{
		if (!isAI)
		{
			enabled = false;
			return;
		}
		badgeObj = transform.Find("Colliders/MainBoxCol").gameObject;
		StartCoroutine_Auto(stopSteer());
		firetype = UnityEngine.Random.Range(0, 2);
		aiDiff = Mathf.Min(9, (DisplayTopPlayers.mypointsStat - DisplayTopPlayers.mypointsStat % 1000) / 1000) + 1;
		if (aiDiff >= 1 && aiDiff <= 3)
		{
			armorLevel = 0;
		}
		if (aiDiff >= 4 && aiDiff <= 5)
		{
			armorLevel = 1;
		}
		if (aiDiff == 6)
		{
			armorLevel = 2;
		}
		if (aiDiff >= 7 && aiDiff <= 8)
		{
			armorLevel = 3;
		}
		if (aiDiff >= 9 && aiDiff <= 10)
		{
			armorLevel = 4;
		}
		if (UnityEngine.Random.Range(0, 5) == 0)
		{
			armorLevel = Mathf.Max(0, armorLevel - 1);
		}
		if (UnityEngine.Random.Range(0, 4) == 0)
		{
			armorLevel = -1;
		}
		if (ainame.Contains("guest_"))
		{
			armorLevel = -1;
		}
	}

	public virtual void Update()
	{
		if (AuthGameObject.showTutorial)
		{
			if (hideBadge)
			{
				badgeObj.tag = "minimap";
			}
			else
			{
				badgeObj.tag = "BlueObjects";
			}
			if (aihealth <= 0)
			{
				((TutorialManager)GameObject.Find("/TutorialManager").GetComponent(typeof(TutorialManager))).botsDestroyed = ((TutorialManager)GameObject.Find("/TutorialManager").GetComponent(typeof(TutorialManager))).botsDestroyed + 1;
				this.gameObject.SetActiveRecursively(false);
			}
			if (TutorialManager.curTutIndex == 6 && forceEnable)
			{
				stopFiring = true;
				stopMoving = false;
				rigidbody.isKinematic = false;
			}
			else if (TutorialManager.curTutIndex > 6 && !TutorialManager.disableBots)
			{
				stopFiring = false;
				stopMoving = false;
				rigidbody.isKinematic = false;
			}
			else
			{
				stopFiring = true;
				stopMoving = true;
				rigidbody.isKinematic = true;
			}
		}
		if (aihealth.ToString() != localHealthObj.name)
		{
			aihealth = UnityBuiltins.parseInt(localHealthObj.name);
		}
		if (isDead && !stopsteer)
		{
			StartCoroutine_Auto(stopSteer());
		}
		if (!(targetCounter <= 0f))
		{
			targetCounter -= Time.deltaTime;
			return;
		}
		targetCounter = 1f;
		float num = 1E+13f;
		Transform transform = null;
		IEnumerator enumerator = UnityRuntimeServices.GetEnumerator(SpawningScript.spawnedCars);
		while (enumerator.MoveNext())
		{
			object obj = enumerator.Current;
			if (!(obj is GameObject))
			{
				obj = RuntimeServices.Coerce(obj, typeof(GameObject));
			}
			GameObject gameObject = (GameObject)obj;
			if ((bool)gameObject && (gameObject.name == "CarPrefab(Clone)" || gameObject.name == "HumanPrefab(Clone)") && gameObject != this.gameObject && (((ReturnName)gameObject.GetComponent(typeof(ReturnName))).team != aiteam || AuthGameObject.gametype == "Deathmatch" || AuthGameObject.gametype == "Survival") && gameObject.transform.root.gameObject.layer != 16)
			{
				float sqrMagnitude = (gameObject.transform.position - this.transform.position).sqrMagnitude;
				UnityRuntimeServices.Update(enumerator, gameObject);
				if (sqrMagnitude < num || num == 1E+13f)
				{
					transform = gameObject.transform;
					UnityRuntimeServices.Update(enumerator, gameObject);
					num = sqrMagnitude;
				}
			}
		}
		if ((bool)transform)
		{
			target = transform;
		}
	}

	public virtual IEnumerator stopSteer()
	{
		return new _0024stopSteer_00244073(this).GetEnumerator();
	}

	public virtual void LateUpdate()
	{
		if (stopMoving)
		{
			horizontalInput = 0f;
			verticalInput = 0f;
			spaceButton = false;
		}
		if (EndofRound.alphastat != 0f || stopMoving)
		{
			return;
		}
		float num = -1f;
		float num2 = float.PositiveInfinity;
		int num3 = 0;
		int num4 = 0;
		RaycastHit hitInfo = default(RaycastHit);
		if (!(timeBetweenControl > 0f) && (bool)target)
		{
			int i = 0;
			Transform[] array = rayPoints;
			for (int length = array.Length; i < length; i++)
			{
				if (Physics.Raycast(array[i].parent.position, new Vector3((array[i].position - array[i].parent.position).normalized.x, 0f, (array[i].position - array[i].parent.position).normalized.z), out hitInfo, 250f, layermask))
				{
					Debug.DrawLine(hitInfo.point, array[i].parent.position, Color.green);
					if (!(hitInfo.distance <= num))
					{
						num3 = num4;
						num = hitInfo.distance;
					}
					if (!(hitInfo.distance >= num2))
					{
						num2 = hitInfo.distance;
					}
				}
				else
				{
					num = 250f;
					num3 = num4;
				}
				num4++;
			}
			timeBetweenControl = UnityEngine.Random.Range(0.2f, 0.65f);
			float x = transform.InverseTransformPoint(target.position).x;
			if (!(x <= 0f))
			{
				horizontalInput = Mathf.Lerp(horizontalInput, 1f, 2f * Mathf.Abs(x) / 300f);
			}
			else
			{
				horizontalInput = Mathf.Lerp(horizontalInput, -1f, 2f * Mathf.Abs(x) / 300f);
			}
			if (num2 / num <= 0.85f)
			{
				if (num3 < 1)
				{
					horizontalInput = Mathf.Lerp(horizontalInput, -1f, (num2 >= 50f) ? 0.3f : 1f);
				}
				if (num3 == 1)
				{
					horizontalInput = Mathf.Lerp(horizontalInput, 0f, (num2 >= 50f) ? 0.3f : 1f);
				}
				if (num3 > 1)
				{
					horizontalInput = Mathf.Lerp(horizontalInput, 1f, (num2 >= 50f) ? 0.3f : 1f);
				}
			}
			if (!Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up), out hitInfo, 250f, layermask) && !startedRoll && !((target.position - transform.position).sqrMagnitude >= 500000f))
			{
				if (!(target.position.y <= transform.position.y))
				{
					if (!((target.position - transform.position).sqrMagnitude >= 500000f) && !(target.position.y - transform.position.y <= 50f))
					{
						verticalInput = 0f;
					}
					else if (!(target.position.y > transform.position.y))
					{
						verticalInput *= 0.5f;
					}
					spaceButton = true;
				}
				else
				{
					spaceButton = false;
				}
			}
			else
			{
				Debug.DrawLine(transform.position, hitInfo.point, Color.white);
				spaceButton = false;
			}
		}
		else
		{
			timeBetweenControl -= Time.deltaTime;
		}
		if (!(lastPosCheck > 0f))
		{
			lastPosCheck = 1.5f;
			if (!((lastPos - transform.position).sqrMagnitude >= 50f))
			{
				verticalInput = -1f;
			}
			else
			{
				verticalInput = 1f;
			}
			lastPos = transform.position;
			if (verticalInput == -1f)
			{
				int num5 = 0;
				int j = 0;
				WheelCollider[] array2 = wheels;
				for (int length2 = array2.Length; j < length2; j++)
				{
					if (array2[j].isGrounded)
					{
						num5++;
					}
				}
				if (num5 <= 2 && !startedRoll)
				{
					startedRoll = true;
					spaceButton = false;
					StartCoroutine_Auto(startRoll());
				}
			}
		}
		else
		{
			lastPosCheck -= Time.deltaTime;
		}
		if (spaceButton && Physics.Raycast(transform.position, -Vector3.up, out hitInfo, 15f, layermask))
		{
			verticalInput = 0f;
			horizontalInput = 0f;
		}
		if (!(transform.position.y > 325f) && Application.loadedLevelName == "ChokePoint" && !rollDisable)
		{
			spaceButton = true;
		}
		if (!(transform.position.y > 95f) && Application.loadedLevelName == "Sanctum" && !rollDisable)
		{
			spaceButton = true;
		}
		if (stopsteer)
		{
			horizontalInput = 0f;
		}
		if (rollDisable)
		{
			spaceButton = false;
		}
	}

	public virtual IEnumerator startRoll()
	{
		return new _0024startRoll_00244076(this).GetEnumerator();
	}

	public virtual void Main()
	{
	}
}
