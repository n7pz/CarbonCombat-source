using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class smoothfollow : MonoBehaviour
{
	[Serializable]
	internal sealed class _0024Start_00245816 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal smoothfollow _0024self__00245817;

			public _0024(smoothfollow self_)
			{
				_0024self__00245817 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (!_0024self__00245817.target)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024self__00245817.oldRotation = _0024self__00245817.target.rotation;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal smoothfollow _0024self__00245818;

		public _0024Start_00245816(smoothfollow self_)
		{
			_0024self__00245818 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00245818);
		}
	}

	[Serializable]
	internal sealed class _0024tempswitch_00245819 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal GameObject _0024tempTarget_00245820;

			internal smoothfollow _0024self__00245821;

			public _0024(smoothfollow self_)
			{
				_0024self__00245821 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024tempTarget_00245820 = new GameObject("TempCamTarget");
					_0024tempTarget_00245820.transform.position = _0024self__00245821.target.position;
					_0024tempTarget_00245820.transform.rotation = _0024self__00245821.target.rotation;
					_0024self__00245821.target = _0024tempTarget_00245820.transform;
					result = (Yield(2, new WaitForSeconds(4f)) ? 1 : 0);
					break;
				case 2:
					_0024self__00245821.target = _0024self__00245821.backuptarget;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal smoothfollow _0024self__00245822;

		public _0024tempswitch_00245819(smoothfollow self_)
		{
			_0024self__00245822 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00245822);
		}
	}

	[Serializable]
	internal sealed class _0024SetFPSTarget_00245823 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal Transform _0024t_00245824;

			internal smoothfollow _0024self__00245825;

			public _0024(Transform t, smoothfollow self_)
			{
				_0024t_00245824 = t;
				_0024self__00245825 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00245825.target = _0024t_00245824;
					result = (Yield(2, new WaitForSeconds(4f)) ? 1 : 0);
					break;
				case 2:
					_0024self__00245825.target = SpawningScript.playertrans;
					UnityEngine.Object.Destroy(_0024t_00245824.gameObject);
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Transform _0024t_00245826;

		internal smoothfollow _0024self__00245827;

		public _0024SetFPSTarget_00245823(Transform t, smoothfollow self_)
		{
			_0024t_00245826 = t;
			_0024self__00245827 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024t_00245826, _0024self__00245827);
		}
	}

	[Serializable]
	internal sealed class _0024SetFPSTargetRound_00245828 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal Transform _0024t_00245829;

			internal smoothfollow _0024self__00245830;

			public _0024(Transform t, smoothfollow self_)
			{
				_0024t_00245829 = t;
				_0024self__00245830 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00245830.target = _0024t_00245829;
					result = (Yield(2, new WaitForSeconds(0.101f)) ? 1 : 0);
					break;
				case 2:
					_0024self__00245830.target = SpawningScript.playertrans;
					UnityEngine.Object.Destroy(_0024t_00245829.gameObject);
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Transform _0024t_00245831;

		internal smoothfollow _0024self__00245832;

		public _0024SetFPSTargetRound_00245828(Transform t, smoothfollow self_)
		{
			_0024t_00245831 = t;
			_0024self__00245832 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024t_00245831, _0024self__00245832);
		}
	}

	[Serializable]
	internal sealed class _0024camcolstart_00245833 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal smoothfollow _0024self__00245834;

			public _0024(smoothfollow self_)
			{
				_0024self__00245834 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					result = (Yield(2, new WaitForSeconds(0.5f)) ? 1 : 0);
					break;
				case 2:
					_0024self__00245834.camcol = true;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal smoothfollow _0024self__00245835;

		public _0024camcolstart_00245833(smoothfollow self_)
		{
			_0024self__00245835 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00245835);
		}
	}

	[Serializable]
	internal sealed class _0024respawndisable_00245836 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal smoothfollow _0024self__00245837;

			public _0024(smoothfollow self_)
			{
				_0024self__00245837 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00245837.camcol = false;
					_0024self__00245837.heightDamping = 100f;
					_0024self__00245837.rotationDamping = 100f;
					result = (Yield(2, new WaitForSeconds(0.2f)) ? 1 : 0);
					break;
				case 2:
					_0024self__00245837.heightDamping = _0024self__00245837.hDamp;
					_0024self__00245837.rotationDamping = _0024self__00245837.rDamp;
					_0024self__00245837.camcol = true;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal smoothfollow _0024self__00245838;

		public _0024respawndisable_00245836(smoothfollow self_)
		{
			_0024self__00245838 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00245838);
		}
	}

	public Transform target;

	private Transform backuptarget;

	public float distance;

	public float height;

	public float heightDamping;

	public float rotationDamping;

	private float hDamp;

	private float rDamp;

	public LayerMask layermask;

	public bool spawn;

	private bool enable;

	private bool camcol;

	private bool firsttimeonly;

	private float counter;

	private float hitdist;

	private Transform lerppos;

	public PauseObject pobj;

	private ChatScript cscript;

	private SpawningScript spwnsrc;

	private Vector2 startPos;

	private Vector3 lastDir;

	private Vector3 lastDir2;

	private Quaternion oldRotation;

	private Quaternion targetRotation;

	public smoothfollow()
	{
		distance = 10f;
		height = 5f;
		heightDamping = 2f;
		rotationDamping = 3f;
		spawn = true;
		enable = true;
		counter = 1f;
		hitdist = 26.5f;
		lastDir = new Vector3(1f, 1f, 1f);
		lastDir2 = new Vector3(1f, 1f, 1f);
	}

	public virtual IEnumerator Start()
	{
		return new _0024Start_00245816(this).GetEnumerator();
	}

	public virtual IEnumerator tempswitch()
	{
		return new _0024tempswitch_00245819(this).GetEnumerator();
	}

	public virtual void Awake()
	{
		hDamp = heightDamping;
		rDamp = rotationDamping;
		GameObject gameObject = new GameObject("FakeCam");
		lerppos = gameObject.transform;
		lerppos.position = transform.position;
	}

	public virtual IEnumerator SetFPSTarget(Transform t)
	{
		return new _0024SetFPSTarget_00245823(t, this).GetEnumerator();
	}

	public virtual IEnumerator SetFPSTargetRound(Transform t)
	{
		return new _0024SetFPSTargetRound_00245828(t, this).GetEnumerator();
	}

	public virtual void SetTarget(Transform t)
	{
		target = t;
		backuptarget = t;
	}

	public virtual void setenable(bool t)
	{
		enable = t;
	}

	public virtual IEnumerator camcolstart()
	{
		return new _0024camcolstart_00245833(this).GetEnumerator();
	}

	public virtual IEnumerator respawndisable()
	{
		return new _0024respawndisable_00245836(this).GetEnumerator();
	}

	public virtual void Update()
	{
		float[] array = new float[32];
		array[21] = camera.farClipPlane / 8f;
		array[22] = camera.farClipPlane / 8f;
		camera.layerCullDistances = array;
		height = PauseObject.camerafh;
		distance = Mathf.Lerp(distance, PauseObject.camerafd + ((!(target != null) || !((Rigidbody)target.GetComponent(typeof(Rigidbody)) != null)) ? 0f : (target.rigidbody.velocity.magnitude / 88.5f * 8.5f)), 3f * Time.deltaTime);
	}

	public virtual void LateUpdate()
	{
		if (!target || !ChatScript.isCar)
		{
			return;
		}
		if ((bool)target && !firsttimeonly)
		{
			StartCoroutine_Auto(respawndisable());
			firsttimeonly = true;
			StartCoroutine_Auto(camcolstart());
		}
		if (!enable)
		{
			return;
		}
		if (Input.GetButtonDown("Fire2"))
		{
			startPos = Input.mousePosition;
		}
		if (Input.GetButton("Fire2"))
		{
			transform.RotateAround(target.position, Vector3.up, 50f * Time.deltaTime * (Input.mousePosition.x - startPos.x));
			lerppos.rotation = transform.rotation;
			startPos = Input.mousePosition;
		}
		Quaternion rotation = target.rotation;
		float to = target.position.y + height;
		Quaternion quaternion = lerppos.rotation;
		float y = lerppos.position.y;
		if (!Input.GetButton("Fire2"))
		{
			quaternion = Quaternion.Lerp(quaternion, rotation, rotationDamping * Time.deltaTime);
		}
		y = Mathf.Lerp(y, to, heightDamping * Time.deltaTime);
		Quaternion quaternion2 = Quaternion.Euler(0f, quaternion.eulerAngles.y, 0f);
		Vector3 vector = default(Vector3);
		vector = target.position;
		vector -= quaternion2 * Vector3.forward * distance;
		vector.y = y;
		lerppos.position = vector;
		rotation = target.rotation;
		to = target.position.y + height;
		quaternion = transform.rotation;
		y = transform.position.y;
		if (!Input.GetButton("Fire2"))
		{
			quaternion = Quaternion.Lerp(quaternion, rotation, rotationDamping * Time.deltaTime);
		}
		y = Mathf.Lerp(y, to, heightDamping * Time.deltaTime);
		quaternion2 = Quaternion.Euler(0f, quaternion.eulerAngles.y, 0f);
		vector = target.position;
		vector -= quaternion2 * Vector3.forward * distance;
		vector.y = y;
		bool flag = false;
		RaycastHit hitInfo = default(RaycastHit);
		if (camcol)
		{
			if (Physics.Linecast(target.position, lerppos.position, out hitInfo, layermask))
			{
				if (!(Rigidbody)hitInfo.transform.GetComponent(typeof(Rigidbody)))
				{
					vector = hitInfo.point;
					vector -= (vector - target.position).normalized * 1.5f;
					vector.y += (1f - hitInfo.distance / distance) * distance * 0.75f;
					hitdist = Mathf.Lerp(hitdist, hitInfo.distance, Time.deltaTime * 15f);
					transform.position = Vector3.Lerp(transform.position, vector, Time.deltaTime * 10f);
				}
				else
				{
					transform.position = vector;
					hitdist = Mathf.Lerp(hitdist, distance, Time.deltaTime * 15f);
				}
			}
			else
			{
				transform.position = vector;
				hitdist = Mathf.Lerp(hitdist, distance, Time.deltaTime * 15f);
			}
		}
		else
		{
			transform.position = vector;
			hitdist = Mathf.Lerp(hitdist, distance, Time.deltaTime * 15f);
		}
		transform.LookAt(target);
		lerppos.LookAt(target);
	}

	public virtual void Main()
	{
	}
}
