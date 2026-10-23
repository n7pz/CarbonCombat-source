using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using Photon;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class GrenadeExploder : Photon.MonoBehaviour
{
	[Serializable]
	internal sealed class _0024networkExplode_00243942 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal int _0024scount_00243943;

			internal GameObject _0024obj_00243944;

			internal IEnumerator _0024_0024iterator_0024269_00243945;

			internal Collider[] _0024colliders_00243946;

			internal Collider _0024hit_00243947;

			internal Collider _0024hit_00243948;

			internal int _0024_0024544_00243949;

			internal Collider[] _0024_0024545_00243950;

			internal int _0024_0024546_00243951;

			internal int _0024_0024548_00243952;

			internal Collider[] _0024_0024549_00243953;

			internal int _0024_0024550_00243954;

			internal Vector3 _0024pos_00243955;

			internal Quaternion _0024rot_00243956;

			internal string _0024user_00243957;

			internal GrenadeExploder _0024self__00243958;

			public _0024(Vector3 pos, Quaternion rot, string user, GrenadeExploder self_)
			{
				_0024pos_00243955 = pos;
				_0024rot_00243956 = rot;
				_0024user_00243957 = user;
				_0024self__00243958 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024user_00243957 != string.Empty)
					{
						_0024scount_00243943 = 0;
						_0024_0024iterator_0024269_00243945 = UnityRuntimeServices.GetEnumerator(SpawningScript.spawnedCars);
						while (_0024_0024iterator_0024269_00243945.MoveNext())
						{
							object obj = _0024_0024iterator_0024269_00243945.Current;
							if (!(obj is GameObject))
							{
								obj = RuntimeServices.Coerce(obj, typeof(GameObject));
							}
							_0024obj_00243944 = (GameObject)obj;
							if ((bool)_0024obj_00243944)
							{
								if ((_0024obj_00243944.name == "CarPrefab(Clone)" || _0024obj_00243944.name == "HumanPrefab(Clone)") && _0024obj_00243944.layer != 16)
								{
									_0024self__00243958.returnname = (ReturnName)_0024obj_00243944.gameObject.GetComponent("ReturnName");
									UnityRuntimeServices.Update(_0024_0024iterator_0024269_00243945, _0024obj_00243944);
									if (_0024user_00243957 == _0024self__00243958.returnname.returnName())
									{
										_0024pos_00243955 = _0024obj_00243944.transform.TransformPoint(_0024pos_00243955);
										UnityRuntimeServices.Update(_0024_0024iterator_0024269_00243945, _0024obj_00243944);
										break;
									}
								}
								_0024scount_00243943++;
							}
							else
							{
								SpawningScript.spawnedCars.RemoveAt(_0024scount_00243943);
							}
						}
					}
					if (!_0024self__00243958.exploded)
					{
						_0024self__00243958.exploded = true;
						UnityEngine.Object.Instantiate((!_0024self__00243958.isemp) ? _0024self__00243958.explosion : _0024self__00243958.empexplosion, _0024pos_00243955, _0024rot_00243956);
						_0024colliders_00243946 = Physics.OverlapSphere(_0024pos_00243955, 25 + _0024self__00243958.level / 2);
						_0024_0024544_00243949 = 0;
						_0024_0024545_00243950 = _0024colliders_00243946;
						for (_0024_0024546_00243951 = _0024_0024545_00243950.Length; _0024_0024544_00243949 < _0024_0024546_00243951; _0024_0024544_00243949++)
						{
							if (_0024_0024545_00243950[_0024_0024544_00243949].gameObject.name.Contains("Bot") && !_0024self__00243958.botfire)
							{
								_0024_0024545_00243950[_0024_0024544_00243949].gameObject.SendMessage("explosionHit", _0024self__00243958.theowner + "|*", SendMessageOptions.DontRequireReceiver);
								if (_0024self__00243958.isemp)
								{
									_0024_0024545_00243950[_0024_0024544_00243949].gameObject.SendMessage("empDisable", (float)(4 + _0024self__00243958.level / 8) * (1f - Vector3.Distance(_0024_0024545_00243950[_0024_0024544_00243949].gameObject.transform.position, _0024self__00243958.transform.position) / 50f), SendMessageOptions.DontRequireReceiver);
								}
							}
							else
							{
								_0024_0024545_00243950[_0024_0024544_00243949].gameObject.SendMessage("explosionHit", _0024self__00243958.theowner + "|" + Mathf.Round((float)((!_0024self__00243958.isemp) ? (30 + _0024self__00243958.level / 2) : 20) * (1f - Vector3.Distance(_0024_0024545_00243950[_0024_0024544_00243949].gameObject.transform.position, _0024self__00243958.transform.position) / 50f)).ToString() + "|" + _0024self__00243958.dM, SendMessageOptions.DontRequireReceiver);
								if (_0024self__00243958.isemp)
								{
									_0024_0024545_00243950[_0024_0024544_00243949].gameObject.SendMessage("empDisable", (float)(4 + _0024self__00243958.level / 8) * (1f - Vector3.Distance(_0024_0024545_00243950[_0024_0024544_00243949].gameObject.transform.position, _0024self__00243958.transform.position) / 50f), SendMessageOptions.DontRequireReceiver);
								}
							}
						}
					}
					else if ((AuthGameObject.username == _0024user_00243957 || _0024user_00243957 == MasterServerScript.ainame || _0024user_00243957 == MasterServerScript.ainame2 || _0024user_00243957 == MasterServerScript.ainame3) && !_0024self__00243958.gavedamage)
					{
						_0024self__00243958.exploded = true;
						UnityEngine.Object.Instantiate((!_0024self__00243958.isemp) ? _0024self__00243958.explosion : _0024self__00243958.empexplosion, _0024pos_00243955, _0024rot_00243956);
						_0024colliders_00243946 = Physics.OverlapSphere(_0024pos_00243955, 25 + _0024self__00243958.level / 2);
						_0024_0024548_00243952 = 0;
						_0024_0024549_00243953 = _0024colliders_00243946;
						for (_0024_0024550_00243954 = _0024_0024549_00243953.Length; _0024_0024548_00243952 < _0024_0024550_00243954; _0024_0024548_00243952++)
						{
							if (_0024_0024549_00243953[_0024_0024548_00243952].gameObject.name.Contains("Bot") && !_0024self__00243958.botfire)
							{
								_0024_0024549_00243953[_0024_0024548_00243952].gameObject.SendMessage("explosionHit", _0024self__00243958.theowner + "|*", SendMessageOptions.DontRequireReceiver);
								if (_0024self__00243958.isemp)
								{
									_0024_0024549_00243953[_0024_0024548_00243952].gameObject.SendMessage("empDisable", (float)(4 + _0024self__00243958.level / 8) * (1f - Vector3.Distance(_0024_0024549_00243953[_0024_0024548_00243952].gameObject.transform.position, _0024self__00243958.transform.position) / 50f), SendMessageOptions.DontRequireReceiver);
								}
							}
							else
							{
								_0024_0024549_00243953[_0024_0024548_00243952].gameObject.SendMessage("explosionHit", _0024self__00243958.theowner + "|" + Mathf.Round((float)((!_0024self__00243958.isemp) ? (30 + _0024self__00243958.level / 2) : 20) * (1f - Vector3.Distance(_0024_0024549_00243953[_0024_0024548_00243952].gameObject.transform.position, _0024self__00243958.transform.position) / 50f)).ToString() + "|" + _0024self__00243958.dM, SendMessageOptions.DontRequireReceiver);
								if (_0024self__00243958.isemp)
								{
									_0024_0024549_00243953[_0024_0024548_00243952].gameObject.SendMessage("empDisable", (float)(4 + _0024self__00243958.level / 8) * (1f - Vector3.Distance(_0024_0024549_00243953[_0024_0024548_00243952].gameObject.transform.position, _0024self__00243958.transform.position) / 50f), SendMessageOptions.DontRequireReceiver);
								}
							}
						}
					}
					if (_0024user_00243957 == MasterServerScript.ainame && !_0024self__00243958.gavedamage && PhotonNetwork.isMasterClient && MasterServerScript.ainame != string.Empty)
					{
						_0024self__00243958.gavedamage = true;
						SpawningScript.aiplayerobjs[0].SendMessage((!_0024self__00243958.isemp) ? "grenadeHit" : "empgrenadeHit", _0024self__00243958.theowner + "|" + _0024self__00243958.level.ToString() + "|" + _0024self__00243958.dM);
					}
					if (_0024user_00243957 == MasterServerScript.ainame2 && !_0024self__00243958.gavedamage && PhotonNetwork.isMasterClient && MasterServerScript.ainame2 != string.Empty)
					{
						_0024self__00243958.gavedamage = true;
						SpawningScript.aiplayerobjs[1].SendMessage((!_0024self__00243958.isemp) ? "grenadeHit" : "empgrenadeHit", _0024self__00243958.theowner + "|" + _0024self__00243958.level.ToString() + "|" + _0024self__00243958.dM);
					}
					if (_0024user_00243957 == MasterServerScript.ainame3 && !_0024self__00243958.gavedamage && PhotonNetwork.isMasterClient && MasterServerScript.ainame3 != string.Empty)
					{
						_0024self__00243958.gavedamage = true;
						SpawningScript.aiplayerobjs[2].SendMessage((!_0024self__00243958.isemp) ? "grenadeHit" : "empgrenadeHit", _0024self__00243958.theowner + "|" + _0024self__00243958.level.ToString() + "|" + _0024self__00243958.dM);
					}
					if (AuthGameObject.username == _0024user_00243957 && !_0024self__00243958.gavedamage && _0024self__00243958.team != SpawningScript.team2)
					{
						_0024self__00243958.gavedamage = true;
						SpawningScript.playertrans.gameObject.SendMessage((!_0024self__00243958.isemp) ? "grenadeHit" : "empgrenadeHit", _0024self__00243958.theowner + "|" + _0024self__00243958.level.ToString() + "|" + _0024self__00243958.dM);
					}
					if (!(_0024self__00243958.transform.position.y > 11.5f) && _0024self__00243958.cansplash && !_0024self__00243958.splashonce)
					{
						_0024self__00243958.splashonce = true;
						UnityEngine.Object.Instantiate(_0024self__00243958.splashprefab, new Vector3(_0024self__00243958.transform.position.x, 11.5f, _0024self__00243958.transform.position.z), Quaternion.Euler(0f, 0f, 0f));
					}
					_0024self__00243958.rigidbody.isKinematic = true;
					_0024self__00243958.collider.isTrigger = true;
					_0024self__00243958.renderer.enabled = false;
					result = (Yield(2, new WaitForSeconds(2.5f)) ? 1 : 0);
					break;
				case 2:
					if (_0024self__00243958 != null)
					{
						UnityEngine.Object.Destroy(_0024self__00243958.gameObject);
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

		internal Vector3 _0024pos_00243959;

		internal Quaternion _0024rot_00243960;

		internal string _0024user_00243961;

		internal GrenadeExploder _0024self__00243962;

		public _0024networkExplode_00243942(Vector3 pos, Quaternion rot, string user, GrenadeExploder self_)
		{
			_0024pos_00243959 = pos;
			_0024rot_00243960 = rot;
			_0024user_00243961 = user;
			_0024self__00243962 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024pos_00243959, _0024rot_00243960, _0024user_00243961, _0024self__00243962);
		}
	}

	[Serializable]
	internal sealed class _0024waitDestroy_00243963 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal GrenadeExploder _0024self__00243964;

			public _0024(GrenadeExploder self_)
			{
				_0024self__00243964 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					result = (Yield(2, new WaitForSeconds(2.5f)) ? 1 : 0);
					break;
				case 2:
					if (_0024self__00243964 != null)
					{
						UnityEngine.Object.Destroy(_0024self__00243964.gameObject);
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

		internal GrenadeExploder _0024self__00243965;

		public _0024waitDestroy_00243963(GrenadeExploder self_)
		{
			_0024self__00243965 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00243965);
		}
	}

	private float timeout;

	private string theowner;

	public GameObject explosion;

	public GameObject empexplosion;

	private bool exploded;

	private bool gavedamage;

	public AuthGameObject authobj;

	public WhirldIn win;

	public ReturnName returnname;

	public PlayerRemote playerremote;

	public SpawningScript spwnsrc;

	public MasterServerScript mserver;

	private bool cansplash;

	private bool splashonce;

	public GameObject splashprefab;

	private Vector3 lastpos;

	public LayerMask layermask;

	private int level;

	private string team;

	private bool bounceonce;

	private bool botfire;

	public bool isemp;

	public int pid;

	public float dM;

	public int chargeAmount;

	public GrenadeExploder()
	{
		timeout = 4.5f;
		theowner = string.Empty;
		lastpos = new Vector3(0f, 0f, 0f);
		team = string.Empty;
		dM = 1f;
	}

	public virtual void setBot()
	{
		botfire = true;
	}

	public virtual void setteam(string t)
	{
		if (!AuthGameObject.ff && AuthGameObject.gametype != "Deathmatch" && AuthGameObject.gametype != "Freeplay" && AuthGameObject.gametype != "Survival")
		{
			team = t;
		}
	}

	public virtual void Start()
	{
		if (!isemp)
		{
			rigidbody.AddRelativeForce(0f, 0f, (130000 + level / 10 * 5000) * (chargeAmount + 1));
		}
		else
		{
			rigidbody.AddRelativeForce(0f, 0f, (100000 + level / 10 * 5000) * (chargeAmount + 1));
		}
	}

	public virtual void Update()
	{
		if (!(timeout <= 0f))
		{
			timeout -= Time.deltaTime;
			return;
		}
		bounceonce = true;
		localExplode(transform.position, transform.rotation);
	}

	public virtual void OnCollisionEnter(Collision collision)
	{
		if (!((PhotonView)collision.transform.gameObject.GetComponent(typeof(PhotonView)) == null) && ((PhotonView)collision.transform.gameObject.GetComponent(typeof(PhotonView))).isMine && !collision.transform.gameObject.GetComponent<AIManager>().enabled)
		{
			return;
		}
		ContactPoint contactPoint = collision.contacts[0];
		Quaternion quaternion = Quaternion.FromToRotation(Vector3.up, contactPoint.normal);
		Vector3 point = contactPoint.point;
		if (bounceonce || collision.gameObject.name == "CarPrefab(Clone)" || collision.gameObject.name == "MainBoxCol" || collision.gameObject.name == "HumanPrefab(Clone)")
		{
			if (!(collision.gameObject.tag != "WorldColliders"))
			{
				return;
			}
			string empty = string.Empty;
			string empty2 = string.Empty;
			if (collision.gameObject.name == "CarPrefab(Clone)" || collision.gameObject.name == "MainBoxCol" || collision.gameObject.name == "HumanPrefab(Clone)")
			{
				returnname = (ReturnName)collision.gameObject.GetComponent("ReturnName");
				empty = returnname.returnName();
				ReturnName returnName = (ReturnName)collision.gameObject.GetComponent("ReturnName");
				if (!returnName.returnAI())
				{
					if (AuthGameObject.username == theowner)
					{
						point = collision.gameObject.transform.InverseTransformPoint(point);
						((PhotonView)GameObject.Find("/ProjectileMan").GetComponent(typeof(PhotonView))).RPC("networkExplode", PhotonTargets.All, point, quaternion, empty, pid);
					}
					else if (empty == AuthGameObject.username && !gavedamage && team != SpawningScript.team2)
					{
						gavedamage = true;
						SpawningScript.playertrans.gameObject.SendMessage((!isemp) ? "grenadeHit" : "empgrenadeHit", theowner + "|" + level.ToString() + "|" + dM);
						localExplode(point, quaternion);
					}
				}
				else
				{
					gavedamage = true;
					collision.gameObject.SendMessage((!isemp) ? "grenadeHit" : "empgrenadeHit", theowner + "|" + level.ToString() + "|" + dM);
					localExplode(point, quaternion);
				}
			}
			else
			{
				localExplode(point, quaternion);
			}
		}
		else
		{
			bounceonce = true;
		}
	}

	public virtual IEnumerator networkExplode(Vector3 pos, Quaternion rot, string user)
	{
		return new _0024networkExplode_00243942(pos, rot, user, this).GetEnumerator();
	}

	public virtual void setowner(string t)
	{
		theowner = t;
	}

	public virtual void setlevel(int l)
	{
		level = l;
	}

	public virtual void Awake()
	{
		lastpos = transform.position;
	}

	public virtual void localExplode(Vector3 pos, Quaternion rot)
	{
		if (bounceonce)
		{
			if (!exploded)
			{
				exploded = true;
				rigidbody.isKinematic = true;
				collider.isTrigger = true;
				renderer.enabled = false;
				UnityEngine.Object.Instantiate((!isemp) ? explosion : empexplosion, pos, rot);
				Collider[] array = Physics.OverlapSphere(pos, 25 + level / 2);
				int i = 0;
				Collider[] array2 = array;
				for (int length = array2.Length; i < length; i++)
				{
					if (array2[i].gameObject.name.Contains("Bot") && !botfire)
					{
						array2[i].gameObject.SendMessage("explosionHit", theowner + "|*", SendMessageOptions.DontRequireReceiver);
						if (isemp)
						{
							array2[i].gameObject.SendMessage("empDisable", (float)(4 + level / 8) * (1f - Vector3.Distance(array2[i].gameObject.transform.position, transform.position) / 50f), SendMessageOptions.DontRequireReceiver);
						}
					}
					else
					{
						array2[i].gameObject.SendMessage("explosionHit", theowner + "|" + Mathf.Round((float)((!isemp) ? (30 + level / 2) : 20) * (1f - Vector3.Distance(array2[i].gameObject.transform.position, transform.position) / 50f)).ToString() + "|" + dM, SendMessageOptions.DontRequireReceiver);
						if (isemp)
						{
							array2[i].gameObject.SendMessage("empDisable", (float)(4 + level / 8) * (1f - Vector3.Distance(array2[i].gameObject.transform.position, transform.position) / 50f), SendMessageOptions.DontRequireReceiver);
						}
					}
				}
				StartCoroutine_Auto(waitDestroy());
			}
			if (!(transform.position.y > 11.5f) && cansplash && !splashonce)
			{
				splashonce = true;
				UnityEngine.Object.Instantiate(splashprefab, new Vector3(transform.position.x, 11.5f, transform.position.z), Quaternion.Euler(0f, 0f, 0f));
			}
		}
		else
		{
			bounceonce = true;
		}
	}

	public virtual IEnumerator waitDestroy()
	{
		return new _0024waitDestroy_00243963(this).GetEnumerator();
	}

	public virtual void LateUpdate()
	{
		if (WhirldIn.hassea || AuthGameObject.whirldurl == string.Empty)
		{
			if (!(transform.position.y <= 11.5f))
			{
				cansplash = true;
			}
			if (!(transform.position.y > 11.5f) && cansplash && !splashonce)
			{
				splashonce = true;
				UnityEngine.Object.Instantiate(splashprefab, new Vector3(transform.position.x, 11.5f, transform.position.z), Quaternion.Euler(0f, 0f, 0f));
			}
		}
		RaycastHit hitInfo = default(RaycastHit);
		if (Physics.Linecast(lastpos, transform.position, out hitInfo, layermask))
		{
			if (hitInfo.transform.gameObject.GetComponent("PhotonView") == null || !((PhotonView)hitInfo.transform.gameObject.GetComponent(typeof(PhotonView))).isMine || RuntimeServices.ToBool(UnityRuntimeServices.GetProperty(hitInfo.transform.gameObject.GetComponent("AIManager"), "enabled")))
			{
				if (hitInfo.transform.gameObject.tag != "WorldColliders")
				{
					bounceonce = true;
					string empty = string.Empty;
					string empty2 = string.Empty;
					Quaternion rotation = transform.rotation;
					Vector3 point = hitInfo.point;
					if (hitInfo.transform.gameObject.name == "CarPrefab(Clone)" || hitInfo.transform.gameObject.name == "MainBoxCol" || hitInfo.transform.gameObject.name == "HumanPrefab(Clone)")
					{
						returnname = (ReturnName)hitInfo.transform.gameObject.GetComponent("ReturnName");
						empty = returnname.returnName();
						ReturnName returnName = (ReturnName)hitInfo.transform.gameObject.GetComponent("ReturnName");
						if (!returnName || !returnName.returnAI())
						{
							if (AuthGameObject.username == theowner)
							{
								point = hitInfo.transform.gameObject.transform.InverseTransformPoint(point);
								((PhotonView)GameObject.Find("/ProjectileMan").GetComponent(typeof(PhotonView))).RPC("networkExplode", PhotonTargets.All, point, rotation, empty, pid);
							}
							else if (empty == AuthGameObject.username && !gavedamage)
							{
								gavedamage = true;
								SpawningScript.playertrans.gameObject.SendMessage((!isemp) ? "grenadeHit" : "empgrenadeHit", theowner + "|" + level.ToString() + "|" + dM);
								localExplode(point, rotation);
							}
						}
						else
						{
							gavedamage = true;
							hitInfo.transform.gameObject.SendMessage((!isemp) ? "grenadeHit" : "empgrenadeHit", theowner + "|" + level.ToString() + "|" + dM);
							localExplode(point, rotation);
						}
					}
					else
					{
						localExplode(point, rotation);
					}
				}
				else
				{
					lastpos = transform.position;
				}
			}
			else
			{
				lastpos = transform.position;
			}
		}
		else
		{
			lastpos = transform.position;
		}
	}
}
