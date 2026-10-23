using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using Photon;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class LaserSplat : Photon.MonoBehaviour
{
	[Serializable]
	internal sealed class _0024waitDestroy_00244690 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal LaserSplat _0024self__00244691;

			public _0024(LaserSplat self_)
			{
				_0024self__00244691 = self_;
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
					if (_0024self__00244691 != null)
					{
						UnityEngine.Object.Destroy(_0024self__00244691.gameObject);
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

		internal LaserSplat _0024self__00244692;

		public _0024waitDestroy_00244690(LaserSplat self_)
		{
			_0024self__00244692 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00244692);
		}
	}

	[Serializable]
	internal sealed class _0024laserhit_00244693 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal int _0024scount_00244694;

			internal GameObject _0024obj_00244695;

			internal IEnumerator _0024_0024iterator_0024267_00244696;

			internal Transform _0024exin_00244697;

			internal Vector3 _0024pos_00244698;

			internal Quaternion _0024rot_00244699;

			internal string _0024user_00244700;

			internal LaserSplat _0024self__00244701;

			public _0024(Vector3 pos, Quaternion rot, string user, LaserSplat self_)
			{
				_0024pos_00244698 = pos;
				_0024rot_00244699 = rot;
				_0024user_00244700 = user;
				_0024self__00244701 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024user_00244700 != string.Empty)
					{
						_0024scount_00244694 = 0;
						_0024_0024iterator_0024267_00244696 = UnityRuntimeServices.GetEnumerator(SpawningScript.spawnedCars);
						while (_0024_0024iterator_0024267_00244696.MoveNext())
						{
							object obj = _0024_0024iterator_0024267_00244696.Current;
							if (!(obj is GameObject))
							{
								obj = RuntimeServices.Coerce(obj, typeof(GameObject));
							}
							_0024obj_00244695 = (GameObject)obj;
							if ((bool)_0024obj_00244695)
							{
								if ((_0024obj_00244695.name == "CarPrefab(Clone)" || _0024obj_00244695.name == "HumanPrefab(Clone)") && _0024obj_00244695.layer != 16)
								{
									_0024self__00244701.returnname = (ReturnName)_0024obj_00244695.gameObject.GetComponent("ReturnName");
									UnityRuntimeServices.Update(_0024_0024iterator_0024267_00244696, _0024obj_00244695);
									if (_0024user_00244700 == _0024self__00244701.returnname.returnName())
									{
										_0024pos_00244698 = _0024obj_00244695.transform.TransformPoint(_0024pos_00244698);
										UnityRuntimeServices.Update(_0024_0024iterator_0024267_00244696, _0024obj_00244695);
										break;
									}
								}
								_0024scount_00244694++;
							}
							else
							{
								SpawningScript.spawnedCars.RemoveAt(_0024scount_00244694);
							}
						}
					}
					_0024exin_00244697 = null;
					if (!_0024self__00244701.explode)
					{
						_0024self__00244701.explode = true;
						_0024exin_00244697 = (Transform)UnityEngine.Object.Instantiate(_0024self__00244701.explosion, _0024pos_00244698, _0024rot_00244699);
					}
					else if ((AuthGameObject.username == _0024user_00244700 || _0024user_00244700 == MasterServerScript.ainame || _0024user_00244700 == MasterServerScript.ainame2 || _0024user_00244700 == MasterServerScript.ainame3) && !_0024self__00244701.gavedamage)
					{
						_0024self__00244701.explode = true;
						_0024exin_00244697 = (Transform)UnityEngine.Object.Instantiate(_0024self__00244701.explosion, _0024pos_00244698, _0024rot_00244699);
					}
					if (_0024user_00244700 == MasterServerScript.ainame && !_0024self__00244701.gavedamage && PhotonNetwork.isMasterClient && MasterServerScript.ainame != string.Empty)
					{
						_0024self__00244701.gavedamage = true;
						SpawningScript.aiplayerobjs[0].SendMessage("rockethit", _0024self__00244701.username + "|" + _0024self__00244701.level.ToString() + "|" + _0024self__00244701.dM);
					}
					if (_0024user_00244700 == MasterServerScript.ainame2 && !_0024self__00244701.gavedamage && PhotonNetwork.isMasterClient && MasterServerScript.ainame2 != string.Empty)
					{
						_0024self__00244701.gavedamage = true;
						SpawningScript.aiplayerobjs[1].SendMessage("rockethit", _0024self__00244701.username + "|" + _0024self__00244701.level.ToString() + "|" + _0024self__00244701.dM);
					}
					if (_0024user_00244700 == MasterServerScript.ainame3 && !_0024self__00244701.gavedamage && PhotonNetwork.isMasterClient && MasterServerScript.ainame3 != string.Empty)
					{
						_0024self__00244701.gavedamage = true;
						SpawningScript.aiplayerobjs[2].SendMessage("rockethit", _0024self__00244701.username + "|" + _0024self__00244701.level.ToString() + "|" + _0024self__00244701.dM);
					}
					if (AuthGameObject.username == _0024user_00244700 && !_0024self__00244701.gavedamage && _0024self__00244701.team != SpawningScript.team2)
					{
						_0024self__00244701.gavedamage = true;
						SpawningScript.playertrans.gameObject.SendMessage("laserhit", _0024self__00244701.username + "|" + _0024self__00244701.level.ToString() + "|" + _0024self__00244701.dM);
					}
					if (!(_0024self__00244701.transform.position.y > 11.5f) && _0024self__00244701.cansplash && !_0024self__00244701.splashonce)
					{
						_0024self__00244701.splashonce = true;
						UnityEngine.Object.Instantiate(_0024self__00244701.splashprefab, new Vector3(_0024self__00244701.transform.position.x, 11.5f, _0024self__00244701.transform.position.z), Quaternion.Euler(0f, 0f, 0f));
					}
					_0024self__00244701.transform.DetachChildren();
					_0024self__00244701.explode = true;
					_0024self__00244701.rigidbody.isKinematic = true;
					_0024self__00244701.collider.isTrigger = true;
					result = (Yield(2, new WaitForSeconds(2.5f)) ? 1 : 0);
					break;
				case 2:
					if (_0024self__00244701 != null)
					{
						UnityEngine.Object.Destroy(_0024self__00244701.gameObject);
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

		internal Vector3 _0024pos_00244702;

		internal Quaternion _0024rot_00244703;

		internal string _0024user_00244704;

		internal LaserSplat _0024self__00244705;

		public _0024laserhit_00244693(Vector3 pos, Quaternion rot, string user, LaserSplat self_)
		{
			_0024pos_00244702 = pos;
			_0024rot_00244703 = rot;
			_0024user_00244704 = user;
			_0024self__00244705 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024pos_00244702, _0024rot_00244703, _0024user_00244704, _0024self__00244705);
		}
	}

	public Transform explosion;

	private bool explode;

	private bool disableray;

	public string username;

	public LayerMask layermask;

	public GameObject splashprefab;

	private bool splashonce;

	private bool cansplash;

	private Vector3 lastpos;

	public AuthGameObject authobj;

	public SpawningScript spwnsrc;

	public ReturnName returnname;

	public PlayerRemote playerremote;

	public WhirldIn win;

	public MasterServerScript mserver;

	private int level;

	private string team;

	private bool gavedamage;

	private bool botfire;

	public int pid;

	public float dM;

	public GameObject firedFrom;

	public LaserSplat()
	{
		username = string.Empty;
		lastpos = new Vector3(0f, 0f, 0f);
		team = string.Empty;
		dM = 1f;
	}

	public virtual void setBot()
	{
		botfire = true;
	}

	public virtual void setowner(string u)
	{
		username = u;
		gavedamage = false;
		explode = false;
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
		RaycastHit hitInfo = default(RaycastHit);
		if (!explode)
		{
			lastpos = this.transform.position;
			this.transform.Translate(new Vector3(0f, 0f, 1000f * Time.deltaTime));
		}
		if (!(lastpos != new Vector3(0f, 0f, 0f)) || disableray || !Physics.Linecast(lastpos, this.transform.position, out hitInfo, layermask) || (!((PhotonView)hitInfo.transform.gameObject.GetComponent(typeof(PhotonView)) == null) && ((PhotonView)hitInfo.transform.gameObject.GetComponent(typeof(PhotonView))).isMine && !(username == "Killer_Drones") && !hitInfo.transform.gameObject.name.Contains("Bot") && (!(AIManager)hitInfo.transform.gameObject.GetComponent(typeof(AIManager)) || !hitInfo.transform.gameObject.GetComponent<AIManager>().enabled) && (!((PhotonView)hitInfo.transform.gameObject.GetComponent(typeof(PhotonView))).isMine || !(username != AuthGameObject.username))) || !(hitInfo.transform.gameObject.tag != "WorldColliders") || !(hitInfo.transform.gameObject.name != "RollOverCol") || !(hitInfo.transform.gameObject != firedFrom))
		{
			return;
		}
		Quaternion quaternion = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);
		Vector3 point = hitInfo.point;
		point -= (point - lastpos).normalized * 0.2f;
		if (hitInfo.transform.gameObject.name == "OilBarrel")
		{
			Transform transform = hitInfo.transform.Find("BarrelTrigger");
			transform.SendMessage("laserhit", username + "|1");
		}
		if (hitInfo.transform.gameObject.name == "CanisterPrefab")
		{
			hitInfo.transform.gameObject.SendMessage("laserhit", username + "|1");
		}
		if (hitInfo.transform.gameObject.name.Contains("Bot") && !botfire)
		{
			hitInfo.transform.gameObject.SendMessage("laserhit", username + "*", SendMessageOptions.DontRequireReceiver);
		}
		string empty = string.Empty;
		string empty2 = string.Empty;
		if (hitInfo.transform.gameObject.name == "CarPrefab(Clone)" || hitInfo.transform.gameObject.name == "MainBoxCol" || hitInfo.transform.gameObject.name == "HumanPrefab(Clone)")
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
						((PhotonView)GameObject.Find("/ProjectileMan").GetComponent(typeof(PhotonView))).RPC("laserhit", PhotonTargets.All, point, quaternion, empty, pid);
					}
					else if (empty == AuthGameObject.username && !gavedamage && team != SpawningScript.team2)
					{
						gavedamage = true;
						SpawningScript.playertrans.gameObject.SendMessage("laserhit", username + "|" + level.ToString() + "|" + dM);
						localLaserHit(point, quaternion);
					}
				}
			}
			else
			{
				gavedamage = true;
				hitInfo.transform.SendMessage("laserhit", username + "|" + level.ToString() + "|" + dM);
				localLaserHit(point, quaternion);
			}
		}
		else
		{
			localLaserHit(point, quaternion);
		}
		disableray = true;
	}

	public virtual void OnCollisionEnter(Collision collision)
	{
		ContactPoint contactPoint = collision.contacts[0];
		Quaternion quaternion = Quaternion.FromToRotation(Vector3.up, contactPoint.normal);
		Vector3 point = contactPoint.point;
		if (!(collision.gameObject.tag != "WorldColliders"))
		{
			return;
		}
		if (collision.gameObject.name.Contains("Bot") && !botfire)
		{
			collision.gameObject.SendMessage("laserhit", username + "*", SendMessageOptions.DontRequireReceiver);
		}
		string empty = string.Empty;
		string empty2 = string.Empty;
		if (collision.gameObject.name == "CarPrefab(Clone)" || collision.gameObject.name == "MainBoxCol" || collision.gameObject.name == "HumanPrefab(Clone)")
		{
			returnname = (ReturnName)collision.gameObject.GetComponent("ReturnName");
			empty = returnname.returnName();
			if (AuthGameObject.username == username)
			{
				point = collision.gameObject.transform.InverseTransformPoint(point);
				((PhotonView)GameObject.Find("/ProjectileMan").GetComponent(typeof(PhotonView))).RPC("laserhit", PhotonTargets.All, point, quaternion, empty, pid);
			}
			else if (empty == AuthGameObject.username && !gavedamage)
			{
				gavedamage = true;
				SpawningScript.playertrans.gameObject.SendMessage("laserhit", username + "|" + level.ToString() + "|" + dM);
				localLaserHit(point, quaternion);
			}
		}
		else
		{
			localLaserHit(point, quaternion);
		}
		disableray = true;
	}

	public virtual void localLaserHit(Vector3 pos, Quaternion rot)
	{
		if (!explode)
		{
			explode = true;
			UnityEngine.Object.Instantiate(explosion, pos, rot);
			StartCoroutine_Auto(waitDestroy());
		}
		if (!(transform.position.y > 11.5f) && cansplash && !splashonce)
		{
			splashonce = true;
			UnityEngine.Object.Instantiate(splashprefab, new Vector3(transform.position.x, 11.5f, transform.position.z), Quaternion.Euler(0f, 0f, 0f));
		}
	}

	public virtual IEnumerator waitDestroy()
	{
		return new _0024waitDestroy_00244690(this).GetEnumerator();
	}

	public virtual IEnumerator laserhit(Vector3 pos, Quaternion rot, string user)
	{
		return new _0024laserhit_00244693(pos, rot, user, this).GetEnumerator();
	}
}
