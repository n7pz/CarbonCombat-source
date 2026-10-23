using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using Photon;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class RocketBlowup : Photon.MonoBehaviour
{
	[Serializable]
	internal sealed class _0024waitDestroy_00244709 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal RocketBlowup _0024self__00244710;

			public _0024(RocketBlowup self_)
			{
				_0024self__00244710 = self_;
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
					if (_0024self__00244710 != null)
					{
						UnityEngine.Object.Destroy(_0024self__00244710.gameObject);
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

		internal RocketBlowup _0024self__00244711;

		public _0024waitDestroy_00244709(RocketBlowup self_)
		{
			_0024self__00244711 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00244711);
		}
	}

	[Serializable]
	internal sealed class _0024rocketblowup_00244712 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal int _0024scount_00244713;

			internal GameObject _0024obj_00244714;

			internal IEnumerator _0024_0024iterator_0024268_00244715;

			internal Transform _0024exin_00244716;

			internal Vector3 _0024pos_00244717;

			internal Quaternion _0024rot_00244718;

			internal string _0024user_00244719;

			internal RocketBlowup _0024self__00244720;

			public _0024(Vector3 pos, Quaternion rot, string user, RocketBlowup self_)
			{
				_0024pos_00244717 = pos;
				_0024rot_00244718 = rot;
				_0024user_00244719 = user;
				_0024self__00244720 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024user_00244719 != string.Empty)
					{
						_0024scount_00244713 = 0;
						_0024_0024iterator_0024268_00244715 = UnityRuntimeServices.GetEnumerator(SpawningScript.spawnedCars);
						while (_0024_0024iterator_0024268_00244715.MoveNext())
						{
							object obj = _0024_0024iterator_0024268_00244715.Current;
							if (!(obj is GameObject))
							{
								obj = RuntimeServices.Coerce(obj, typeof(GameObject));
							}
							_0024obj_00244714 = (GameObject)obj;
							if ((bool)_0024obj_00244714)
							{
								if ((_0024obj_00244714.name == "CarPrefab(Clone)" || _0024obj_00244714.name == "HumanPrefab(Clone)") && _0024obj_00244714.layer != 16)
								{
									_0024self__00244720.returnname = (ReturnName)_0024obj_00244714.gameObject.GetComponent("ReturnName");
									UnityRuntimeServices.Update(_0024_0024iterator_0024268_00244715, _0024obj_00244714);
									if (_0024user_00244719 == _0024self__00244720.returnname.returnName())
									{
										_0024pos_00244717 = _0024obj_00244714.transform.TransformPoint(_0024pos_00244717);
										UnityRuntimeServices.Update(_0024_0024iterator_0024268_00244715, _0024obj_00244714);
										break;
									}
								}
								_0024scount_00244713++;
							}
							else
							{
								SpawningScript.spawnedCars.RemoveAt(_0024scount_00244713);
							}
						}
					}
					_0024exin_00244716 = null;
					if (!_0024self__00244720.exploded)
					{
						_0024self__00244720.exploded = true;
						_0024exin_00244716 = (Transform)UnityEngine.Object.Instantiate(_0024self__00244720.explosion, _0024pos_00244717, _0024rot_00244718);
					}
					else if ((AuthGameObject.username == _0024user_00244719 || _0024user_00244719 == MasterServerScript.ainame || _0024user_00244719 == MasterServerScript.ainame2 || _0024user_00244719 == MasterServerScript.ainame3) && !_0024self__00244720.gavedamage)
					{
						_0024self__00244720.exploded = true;
						_0024exin_00244716 = (Transform)UnityEngine.Object.Instantiate(_0024self__00244720.explosion, _0024pos_00244717, _0024rot_00244718);
					}
					if (_0024user_00244719 == MasterServerScript.ainame && !_0024self__00244720.gavedamage && PhotonNetwork.isMasterClient && MasterServerScript.ainame != string.Empty)
					{
						_0024self__00244720.gavedamage = true;
						SpawningScript.aiplayerobjs[0].SendMessage("rockethit", _0024self__00244720.username + "|" + _0024self__00244720.level.ToString() + "|" + _0024self__00244720.dM);
					}
					if (_0024user_00244719 == MasterServerScript.ainame2 && !_0024self__00244720.gavedamage && PhotonNetwork.isMasterClient && MasterServerScript.ainame2 != string.Empty)
					{
						_0024self__00244720.gavedamage = true;
						SpawningScript.aiplayerobjs[1].SendMessage("rockethit", _0024self__00244720.username + "|" + _0024self__00244720.level.ToString() + "|" + _0024self__00244720.dM);
					}
					if (_0024user_00244719 == MasterServerScript.ainame3 && !_0024self__00244720.gavedamage && PhotonNetwork.isMasterClient && MasterServerScript.ainame3 != string.Empty)
					{
						_0024self__00244720.gavedamage = true;
						SpawningScript.aiplayerobjs[2].SendMessage("rockethit", _0024self__00244720.username + "|" + _0024self__00244720.level.ToString() + "|" + _0024self__00244720.dM);
					}
					if (AuthGameObject.username == _0024user_00244719 && !_0024self__00244720.gavedamage && _0024self__00244720.team != SpawningScript.team2)
					{
						_0024self__00244720.gavedamage = true;
						SpawningScript.playertrans.gameObject.SendMessage("rockethit", _0024self__00244720.username + "|" + _0024self__00244720.level.ToString() + "|" + _0024self__00244720.dM);
					}
					if (!(_0024self__00244720.transform.position.y > 11.5f) && _0024self__00244720.cansplash && !_0024self__00244720.splashonce)
					{
						_0024self__00244720.splashonce = true;
						UnityEngine.Object.Instantiate(_0024self__00244720.splashprefab, new Vector3(_0024self__00244720.transform.position.x, 11.5f, _0024self__00244720.transform.position.z), Quaternion.Euler(0f, 0f, 0f));
					}
					_0024self__00244720.transform.DetachChildren();
					_0024self__00244720.rigidbody.isKinematic = true;
					_0024self__00244720.collider.isTrigger = true;
					UnityEngine.Object.Destroy(_0024self__00244720.killp);
					_0024self__00244720.smokepart.emit = false;
					result = (Yield(2, new WaitForSeconds(2.5f)) ? 1 : 0);
					break;
				case 2:
					if (_0024self__00244720 != null)
					{
						UnityEngine.Object.Destroy(_0024self__00244720.gameObject);
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

		internal Vector3 _0024pos_00244721;

		internal Quaternion _0024rot_00244722;

		internal string _0024user_00244723;

		internal RocketBlowup _0024self__00244724;

		public _0024rocketblowup_00244712(Vector3 pos, Quaternion rot, string user, RocketBlowup self_)
		{
			_0024pos_00244721 = pos;
			_0024rot_00244722 = rot;
			_0024user_00244723 = user;
			_0024self__00244724 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024pos_00244721, _0024rot_00244722, _0024user_00244723, _0024self__00244724);
		}
	}

	public Transform explosion;

	public GameObject killp;

	public GameObject smoke;

	public ParticleEmitter smokepart;

	public GameObject splashprefab;

	private bool splashonce;

	private bool cansplash;

	private bool disableray;

	public string username;

	public LayerMask layermask;

	public LayerMask startlayermask;

	public Transform targetpos;

	public WhirldIn win;

	public AuthGameObject authobj;

	public ReturnName returnname;

	public PlayerRemote playerremote;

	public SpawningScript spwnsrc;

	public MasterServerScript mserver;

	private int level;

	private string team;

	private bool exploded;

	private bool gavedamage;

	private bool botfire;

	private Vector3 lastpos;

	public int pid;

	public float dM;

	public RocketBlowup()
	{
		username = string.Empty;
		team = string.Empty;
		lastpos = Vector3.zero;
		dM = 1f;
	}

	public virtual void setBot()
	{
		botfire = true;
	}

	public virtual void setowner(object u)
	{
		exploded = false;
		gavedamage = false;
		object obj = u;
		if (!(obj is string))
		{
			obj = RuntimeServices.Coerce(obj, typeof(string));
		}
		username = (string)obj;
	}

	public virtual void setlevel(int l)
	{
		level = l;
	}

	public virtual void setteam(string t)
	{
		if (!AuthGameObject.ff && AuthGameObject.gametype != "Deathmatch" && AuthGameObject.gametype != "Freeplay" && AuthGameObject.gametype != "Survival")
		{
			team = t;
		}
	}

	public virtual void Update()
	{
		if (WhirldIn.hassea || AuthGameObject.whirldurl == string.Empty)
		{
			if (!(this.transform.position.y <= 11.5f))
			{
				cansplash = true;
			}
			if (!(this.transform.position.y > 11.5f) && cansplash && !splashonce)
			{
				splashonce = true;
				UnityEngine.Object.Instantiate(splashprefab, new Vector3(this.transform.position.x, 11.5f, this.transform.position.z), Quaternion.Euler(0f, 0f, 0f));
			}
		}
		if (lastpos == Vector3.zero)
		{
			lastpos = this.transform.position;
		}
		RaycastHit hitInfo = default(RaycastHit);
		if (disableray)
		{
			return;
		}
		if (Physics.Linecast(lastpos, this.transform.position, out hitInfo, layermask) && ((PhotonView)hitInfo.transform.gameObject.GetComponent(typeof(PhotonView)) == null || !((PhotonView)hitInfo.transform.gameObject.GetComponent(typeof(PhotonView))).isMine || username == "Killer_Drones" || hitInfo.transform.gameObject.name.Contains("Bot") || (hitInfo.transform.gameObject.GetComponent<AIManager>().enabled && ((ReturnName)hitInfo.transform.gameObject.GetComponent(typeof(ReturnName))).returnName() != username) || (((PhotonView)hitInfo.transform.gameObject.GetComponent(typeof(PhotonView))).isMine && ((ReturnName)hitInfo.transform.gameObject.GetComponent(typeof(ReturnName))).returnName() != username)) && hitInfo.transform.gameObject.tag != "WorldColliders" && hitInfo.transform.gameObject.name != "RollOverCol")
		{
			Quaternion rotation = this.transform.rotation;
			Vector3 point = hitInfo.point;
			StartCoroutine_Auto(rocketblowup(point, rotation, string.Empty));
			if (hitInfo.transform.gameObject.name == "OilBarrel")
			{
				Transform transform = hitInfo.transform.Find("BarrelTrigger");
				transform.SendMessage("rockethit", username + "|1");
			}
			if (hitInfo.transform.gameObject.name == "CanisterPrefab")
			{
				hitInfo.transform.gameObject.SendMessage("rockethit", username + "|1");
			}
			if (hitInfo.transform.gameObject.name.Contains("Bot") && !botfire)
			{
				hitInfo.transform.gameObject.SendMessage("rockethit", username + "*", SendMessageOptions.DontRequireReceiver);
			}
			string empty = string.Empty;
			string empty2 = string.Empty;
			if (hitInfo.transform.gameObject.name.Contains("CarPrefab(Clone)") || hitInfo.transform.gameObject.name == "MainBoxCol" || hitInfo.transform.gameObject.name == "HumanPrefab(Clone)")
			{
				ReturnName returnName = (ReturnName)hitInfo.transform.gameObject.GetComponent("ReturnName");
				if (!returnName.returnAI())
				{
					if (!(AuthGameObject.username == username) || !((PhotonView)hitInfo.transform.gameObject.GetComponent(typeof(PhotonView))).isMine)
					{
						returnname = (ReturnName)hitInfo.transform.gameObject.GetComponent("ReturnName");
						empty = returnname.returnName();
						if (AuthGameObject.username == username)
						{
							point = hitInfo.transform.gameObject.transform.InverseTransformPoint(point);
							((PhotonView)GameObject.Find("/ProjectileMan").GetComponent(typeof(PhotonView))).RPC("rocketblowup", PhotonTargets.All, point, rotation, empty, pid);
						}
						else if (empty == AuthGameObject.username && !gavedamage && team != SpawningScript.team2)
						{
							gavedamage = true;
							SpawningScript.playertrans.gameObject.SendMessage("rockethit", username + "|" + level.ToString() + "|" + dM);
							localRocketBlowup(point, rotation);
						}
					}
				}
				else
				{
					gavedamage = true;
					hitInfo.transform.SendMessage("rockethit", username + "|" + level.ToString() + "|" + dM);
					localRocketBlowup(point, rotation);
				}
			}
			else
			{
				localRocketBlowup(point, rotation);
			}
			disableray = true;
		}
		lastpos = this.transform.position;
	}

	public virtual void localRocketBlowup(Vector3 pos, Quaternion rot)
	{
		if (!exploded)
		{
			exploded = true;
			rigidbody.isKinematic = true;
			collider.isTrigger = true;
			UnityEngine.Object.Instantiate(explosion, pos, rot);
			smokepart.emit = false;
			StartCoroutine_Auto(waitDestroy());
		}
		if (!(transform.position.y > 11.5f) && cansplash && !splashonce)
		{
			splashonce = true;
			UnityEngine.Object.Instantiate(splashprefab, new Vector3(transform.position.x, 11.5f, transform.position.z), Quaternion.Euler(0f, 0f, 0f));
		}
		if (!exploded)
		{
			UnityEngine.Object.Destroy(killp);
		}
	}

	public virtual IEnumerator waitDestroy()
	{
		return new _0024waitDestroy_00244709(this).GetEnumerator();
	}

	public virtual IEnumerator rocketblowup(Vector3 pos, Quaternion rot, string user)
	{
		return new _0024rocketblowup_00244712(pos, rot, user, this).GetEnumerator();
	}

	public virtual void Main()
	{
	}
}
