using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using Photon;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class LowPolyBulletExplode : Photon.MonoBehaviour
{
	[Serializable]
	internal sealed class _0024waitDestroy_00244053 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal LowPolyBulletExplode _0024self__00244054;

			public _0024(LowPolyBulletExplode self_)
			{
				_0024self__00244054 = self_;
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
					UnityEngine.Object.Destroy(_0024self__00244054.gameObject);
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal LowPolyBulletExplode _0024self__00244055;

		public _0024waitDestroy_00244053(LowPolyBulletExplode self_)
		{
			_0024self__00244055 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00244055);
		}
	}

	[Serializable]
	internal sealed class _0024bulletHit_00244056 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal bool _0024alreadyhit_00244057;

			internal int _0024someid_00244058;

			internal IEnumerator _0024_0024iterator_0024262_00244059;

			internal int _0024scount_00244060;

			internal GameObject _0024obj_00244061;

			internal IEnumerator _0024_0024iterator_0024263_00244062;

			internal Vector3 _0024pos_00244063;

			internal Quaternion _0024rot_00244064;

			internal string _0024user_00244065;

			internal int _0024id_00244066;

			internal LowPolyBulletExplode _0024self__00244067;

			public _0024(Vector3 pos, Quaternion rot, string user, int id, LowPolyBulletExplode self_)
			{
				_0024pos_00244063 = pos;
				_0024rot_00244064 = rot;
				_0024user_00244065 = user;
				_0024id_00244066 = id;
				_0024self__00244067 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024alreadyhit_00244057 = false;
					_0024_0024iterator_0024262_00244059 = UnityRuntimeServices.GetEnumerator(_0024self__00244067.idlist);
					while (_0024_0024iterator_0024262_00244059.MoveNext())
					{
						_0024someid_00244058 = RuntimeServices.UnboxInt32(_0024_0024iterator_0024262_00244059.Current);
						if (_0024someid_00244058 == _0024id_00244066)
						{
							_0024alreadyhit_00244057 = true;
						}
					}
					if (!_0024alreadyhit_00244057)
					{
						_0024self__00244067.idlist.Add(_0024id_00244066);
						if (_0024user_00244065 != string.Empty)
						{
							_0024scount_00244060 = 0;
							_0024_0024iterator_0024263_00244062 = UnityRuntimeServices.GetEnumerator(SpawningScript.spawnedCars);
							while (_0024_0024iterator_0024263_00244062.MoveNext())
							{
								object obj = _0024_0024iterator_0024263_00244062.Current;
								if (!(obj is GameObject))
								{
									obj = RuntimeServices.Coerce(obj, typeof(GameObject));
								}
								_0024obj_00244061 = (GameObject)obj;
								if ((bool)_0024obj_00244061)
								{
									if ((_0024obj_00244061.name == "CarPrefab(Clone)" || _0024obj_00244061.name == "HumanPrefab(Clone)") && _0024obj_00244061.layer != 16)
									{
										_0024self__00244067.returnname = (ReturnName)_0024obj_00244061.gameObject.GetComponent("ReturnName");
										UnityRuntimeServices.Update(_0024_0024iterator_0024263_00244062, _0024obj_00244061);
										if (_0024user_00244065 == _0024self__00244067.returnname.returnName())
										{
											_0024pos_00244063 = _0024obj_00244061.transform.TransformPoint(_0024pos_00244063);
											UnityRuntimeServices.Update(_0024_0024iterator_0024263_00244062, _0024obj_00244061);
											break;
										}
									}
									_0024scount_00244060++;
								}
								else
								{
									SpawningScript.spawnedCars.RemoveAt(_0024scount_00244060);
								}
							}
						}
						if (!_0024self__00244067.exploded)
						{
							_0024self__00244067.exploded = true;
							UnityEngine.Object.Instantiate(_0024self__00244067.explosion, _0024pos_00244063, _0024rot_00244064);
						}
						else if ((AuthGameObject.username == _0024user_00244065 || _0024user_00244065 == MasterServerScript.ainame || _0024user_00244065 == MasterServerScript.ainame2 || _0024user_00244065 == MasterServerScript.ainame3) && !_0024self__00244067.gavedamage)
						{
							_0024self__00244067.exploded = true;
							UnityEngine.Object.Instantiate(_0024self__00244067.explosion, _0024pos_00244063, _0024rot_00244064);
						}
						if (_0024user_00244065 == MasterServerScript.ainame && !_0024self__00244067.gavedamage && PhotonNetwork.isMasterClient && MasterServerScript.ainame != string.Empty)
						{
							_0024self__00244067.gavedamage = true;
							SpawningScript.aiplayerobjs[0].SendMessage((_0024self__00244067.bType == "railgun") ? "railBulletHit" : ((!(_0024self__00244067.bType == "regular")) ? "shotgunBulletHit" : "bulletHit"), _0024self__00244067.theowner + "|" + _0024self__00244067.level.ToString() + "|" + _0024self__00244067.dM, SendMessageOptions.DontRequireReceiver);
						}
						if (_0024user_00244065 == MasterServerScript.ainame2 && !_0024self__00244067.gavedamage && PhotonNetwork.isMasterClient && MasterServerScript.ainame2 != string.Empty)
						{
							_0024self__00244067.gavedamage = true;
							SpawningScript.aiplayerobjs[1].SendMessage((_0024self__00244067.bType == "railgun") ? "railBulletHit" : ((!(_0024self__00244067.bType == "regular")) ? "shotgunBulletHit" : "bulletHit"), _0024self__00244067.theowner + "|" + _0024self__00244067.level.ToString() + "|" + _0024self__00244067.dM, SendMessageOptions.DontRequireReceiver);
						}
						if (_0024user_00244065 == MasterServerScript.ainame3 && !_0024self__00244067.gavedamage && PhotonNetwork.isMasterClient && MasterServerScript.ainame3 != string.Empty)
						{
							_0024self__00244067.gavedamage = true;
							SpawningScript.aiplayerobjs[2].SendMessage((_0024self__00244067.bType == "railgun") ? "railBulletHit" : ((!(_0024self__00244067.bType == "regular")) ? "shotgunBulletHit" : "bulletHit"), _0024self__00244067.theowner + "|" + _0024self__00244067.level.ToString() + "|" + _0024self__00244067.dM, SendMessageOptions.DontRequireReceiver);
						}
						if (AuthGameObject.username == _0024user_00244065 && !_0024self__00244067.gavedamage)
						{
							_0024self__00244067.gavedamage = true;
							SpawningScript.playertrans.gameObject.SendMessage((_0024self__00244067.bType == "railgun") ? "railBulletHit" : ((!(_0024self__00244067.bType == "regular")) ? "shotgunBulletHit" : "bulletHit"), _0024self__00244067.theowner + "|" + _0024self__00244067.level.ToString() + "|" + _0024self__00244067.dM, SendMessageOptions.DontRequireReceiver);
						}
						if (!(_0024self__00244067.transform.position.y > 11.5f) && _0024self__00244067.cansplash && !_0024self__00244067.splashonce)
						{
							_0024self__00244067.splashonce = true;
							UnityEngine.Object.Instantiate(_0024self__00244067.splashprefab, new Vector3(_0024self__00244067.transform.position.x, 11.5f, _0024self__00244067.transform.position.z), Quaternion.Euler(0f, 0f, 0f));
						}
						_0024self__00244067.transform.DetachChildren();
						result = (Yield(2, new WaitForSeconds(2.5f)) ? 1 : 0);
						break;
					}
					goto IL_0777;
				case 2:
					if ((bool)_0024self__00244067.gameObject)
					{
						UnityEngine.Object.Destroy(_0024self__00244067.gameObject);
					}
					goto IL_0777;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0777:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal Vector3 _0024pos_00244068;

		internal Quaternion _0024rot_00244069;

		internal string _0024user_00244070;

		internal int _0024id_00244071;

		internal LowPolyBulletExplode _0024self__00244072;

		public _0024bulletHit_00244056(Vector3 pos, Quaternion rot, string user, int id, LowPolyBulletExplode self_)
		{
			_0024pos_00244068 = pos;
			_0024rot_00244069 = rot;
			_0024user_00244070 = user;
			_0024id_00244071 = id;
			_0024self__00244072 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024pos_00244068, _0024rot_00244069, _0024user_00244070, _0024id_00244071, _0024self__00244072);
		}
	}

	public string bType;

	private Vector3 lastpos;

	public GameObject explosion;

	public GameObject explosionground;

	private string theowner;

	private float timeout;

	public LayerMask layermask;

	public GameObject splashprefab;

	private bool splashonce;

	private bool cansplash;

	public WhirldIn win;

	public AuthGameObject authobj;

	public ReturnName returnname;

	public PlayerRemote playerremote;

	public SpawningScript spwnsrc;

	public MasterServerScript mserver;

	private int level;

	private string team;

	private int id;

	private UnityScript.Lang.Array idlist;

	private bool exploded;

	private bool gavedamage;

	private bool botfire;

	public GameObject decalPrefab;

	public GameObject firedFromObject;

	public GameObject realFiredFromObject;

	public ProjectileReferenceManager projMan;

	public float dM;

	public LowPolyBulletExplode()
	{
		bType = "regular";
		timeout = 6f;
		team = string.Empty;
		idlist = new UnityScript.Lang.Array();
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

	public virtual void Awake()
	{
		firedFromObject = gameObject;
		lastpos = transform.position;
		transform.Translate(Vector3.forward * 100f * Time.deltaTime);
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
		if (!exploded)
		{
			if (Physics.Linecast(lastpos, transform.position, out hitInfo, layermask))
			{
				if (realFiredFromObject == null || hitInfo.transform.root != realFiredFromObject.transform.root)
				{
					if (((PhotonView)hitInfo.transform.gameObject.GetComponent(typeof(PhotonView)) == null || !((PhotonView)hitInfo.transform.gameObject.GetComponent(typeof(PhotonView))).isMine || ((PhotonView)hitInfo.transform.gameObject.GetComponent(typeof(PhotonView))).isMine || hitInfo.transform.gameObject.name.Contains("Bot") || hitInfo.transform.gameObject.GetComponent<AIManager>().enabled) && hitInfo.transform.gameObject != firedFromObject)
					{
						Quaternion quaternion = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);
						Vector3 point = hitInfo.point;
						string empty = string.Empty;
						string empty2 = string.Empty;
						if (hitInfo.transform.gameObject.name == "CarPrefab(Clone)" || hitInfo.transform.gameObject.name == "MainBoxCol" || hitInfo.transform.gameObject.name == "HumanPrefab(Clone)")
						{
							returnname = (ReturnName)hitInfo.transform.gameObject.GetComponent(typeof(ReturnName));
							empty = returnname.returnName();
							ReturnName returnName = (ReturnName)hitInfo.transform.gameObject.GetComponent(typeof(ReturnName));
							if (!(returnName != null) || !returnName.returnAI())
							{
								if (AuthGameObject.username == theowner)
								{
									point = hitInfo.transform.gameObject.transform.InverseTransformPoint(point);
									((PhotonView)GameObject.Find("/ProjectileMan").GetComponent(typeof(PhotonView))).RPC("bulletHit", PhotonTargets.All, point, quaternion, empty, id);
									if (hitInfo.transform.gameObject.name != "HumanPrefab(Clone)")
									{
										decalHit(point, Quaternion.FromToRotation(Vector3.forward, hitInfo.normal), hitInfo.transform.gameObject);
									}
								}
								else if (empty == AuthGameObject.username && !gavedamage && team != SpawningScript.team2)
								{
									gavedamage = true;
									SpawningScript.playertrans.gameObject.SendMessage((bType == "railgun") ? "railBulletHit" : ((!(bType == "regular")) ? "shotgunBulletHit" : "bulletHit"), theowner + "|" + level.ToString() + "|" + dM, SendMessageOptions.DontRequireReceiver);
									bulletHitLocal(point, quaternion, (bool)Terrain.activeTerrain && ((hitInfo.transform.gameObject == Terrain.activeTerrain.gameObject) ? true : false), Quaternion.FromToRotation(Vector3.forward, hitInfo.normal), hitInfo.transform.gameObject);
								}
							}
							else
							{
								gavedamage = true;
								hitInfo.transform.gameObject.SendMessage((bType == "railgun") ? "railBulletHit" : ((!(bType == "regular")) ? "shotgunBulletHit" : "bulletHit"), theowner + "|" + level.ToString() + "|" + dM, SendMessageOptions.DontRequireReceiver);
								bulletHitLocal(point, quaternion, (bool)Terrain.activeTerrain && ((hitInfo.transform.gameObject == Terrain.activeTerrain.gameObject) ? true : false), Quaternion.FromToRotation(Vector3.forward, hitInfo.normal), hitInfo.transform.gameObject);
							}
						}
						else if (!exploded)
						{
							bulletHitLocal(point, quaternion, (bool)Terrain.activeTerrain && ((hitInfo.transform.gameObject == Terrain.activeTerrain.gameObject) ? true : false), Quaternion.FromToRotation(Vector3.forward, hitInfo.normal), hitInfo.transform.gameObject);
							if (hitInfo.transform.gameObject.name.Contains("Bot") && !botfire)
							{
								hitInfo.transform.gameObject.SendMessage((bType == "railgun") ? "railBulletHit" : ((!(bType == "regular")) ? "shotgunBulletHit" : "bulletHit"), theowner + "*", SendMessageOptions.DontRequireReceiver);
							}
							else
							{
								hitInfo.transform.gameObject.BroadcastMessage((bType == "railgun") ? "railBulletHit" : ((!(bType == "regular")) ? "shotgunBulletHit" : "bulletHit"), theowner + "|" + level.ToString() + "|" + dM, SendMessageOptions.DontRequireReceiver);
							}
						}
					}
					else
					{
						lastpos = transform.position;
						if (bType != "railgun")
						{
							transform.Translate(Vector3.forward * 3000f * Time.deltaTime);
						}
						else
						{
							transform.Translate(Vector3.forward * 10000f * Time.deltaTime);
						}
					}
				}
			}
			else
			{
				lastpos = transform.position;
				if (bType != "railgun")
				{
					transform.Translate(Vector3.forward * 3000f * Time.deltaTime);
				}
				else
				{
					transform.Translate(Vector3.forward * 10000f * Time.deltaTime);
				}
			}
		}
		if (!(timeout <= 0f))
		{
			timeout -= Time.deltaTime;
			return;
		}
		transform.DetachChildren();
		UnityEngine.Object.Destroy(gameObject);
	}

	public virtual void decalHit(Vector3 pos, Quaternion brot, GameObject hitobj)
	{
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(decalPrefab, pos, brot);
		gameObject.transform.Translate(Vector3.forward * 0.055f, Space.Self);
		int num = UnityEngine.Random.Range(0, 360);
		Quaternion localRotation = gameObject.transform.localRotation;
		Vector3 eulerAngles = localRotation.eulerAngles;
		float num2 = (eulerAngles.z = num);
		Vector3 vector = (localRotation.eulerAngles = eulerAngles);
		Quaternion quaternion = (gameObject.transform.localRotation = localRotation);
		gameObject.transform.parent = hitobj.transform;
	}

	public virtual void bulletHitLocal(Vector3 pos, Quaternion rot, bool t, Quaternion brot, GameObject hitobj)
	{
		if (!exploded)
		{
			exploded = true;
			UnityEngine.Object.Instantiate((!t && !(hitobj.name == "HumanPrefab(Clone)")) ? explosion : explosionground, pos, rot);
			if (hitobj.name != "HumanPrefab(Clone)")
			{
				GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(decalPrefab, pos, brot);
				gameObject.transform.Translate(Vector3.forward * 0.055f, Space.Self);
				int num = UnityEngine.Random.Range(0, 360);
				Quaternion localRotation = gameObject.transform.localRotation;
				Vector3 eulerAngles = localRotation.eulerAngles;
				float num2 = (eulerAngles.z = num);
				Vector3 vector = (localRotation.eulerAngles = eulerAngles);
				Quaternion quaternion = (gameObject.transform.localRotation = localRotation);
				gameObject.transform.parent = hitobj.transform;
			}
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
		return new _0024waitDestroy_00244053(this).GetEnumerator();
	}

	public virtual IEnumerator bulletHit(Vector3 pos, Quaternion rot, string user, int id)
	{
		return new _0024bulletHit_00244056(pos, rot, user, id, this).GetEnumerator();
	}

	public virtual void setOwner(string owner)
	{
		exploded = false;
		gavedamage = false;
		theowner = owner;
	}

	public virtual void setlevel(int l)
	{
		level = l;
	}

	public virtual void setID(int i)
	{
		id = i;
	}

	public virtual string returnOwner()
	{
		return theowner;
	}
}
