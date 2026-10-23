using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using Photon;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class MissileTrack : Photon.MonoBehaviour
{
	[Serializable]
	internal sealed class _0024everyoneExplode_00245010 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal int _0024scount_00245011;

			internal GameObject _0024obj_00245012;

			internal IEnumerator _0024_0024iterator_0024330_00245013;

			internal bool _0024gavedamage_00245014;

			internal Collider[] _0024colliders_00245015;

			internal Collider _0024hit_00245016;

			internal int _0024_00241280_00245017;

			internal Collider[] _0024_00241281_00245018;

			internal int _0024_00241282_00245019;

			internal Vector3 _0024pos_00245020;

			internal Quaternion _0024rot_00245021;

			internal string _0024user_00245022;

			internal MissileTrack _0024self__00245023;

			public _0024(Vector3 pos, Quaternion rot, string user, MissileTrack self_)
			{
				_0024pos_00245020 = pos;
				_0024rot_00245021 = rot;
				_0024user_00245022 = user;
				_0024self__00245023 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00245023.exploded = true;
					if (ChatScript.debugMissiles)
					{
						((PhotonView)GameObject.Find("/GUI/Chat").GetComponent(typeof(PhotonView))).RPC("netDebug", PhotonTargets.All, AuthGameObject.username + " on team " + SpawningScript.team2 + " got an everyoneExplode RPC with the arguments: pos=" + _0024pos_00245020 + " rot=" + _0024rot_00245021 + " user=" + _0024user_00245022 + " team=" + _0024self__00245023.team);
					}
					if (_0024user_00245022 != string.Empty)
					{
						_0024scount_00245011 = 0;
						_0024_0024iterator_0024330_00245013 = UnityRuntimeServices.GetEnumerator(SpawningScript.spawnedCars);
						while (_0024_0024iterator_0024330_00245013.MoveNext())
						{
							object obj = _0024_0024iterator_0024330_00245013.Current;
							if (!(obj is GameObject))
							{
								obj = RuntimeServices.Coerce(obj, typeof(GameObject));
							}
							_0024obj_00245012 = (GameObject)obj;
							if ((bool)_0024obj_00245012)
							{
								if ((_0024obj_00245012.name == "CarPrefab(Clone)" || _0024obj_00245012.name == "HumanPrefab(Clone)") && _0024obj_00245012.layer != 16)
								{
									_0024self__00245023.returnname = (ReturnName)_0024obj_00245012.gameObject.GetComponent(typeof(ReturnName));
									UnityRuntimeServices.Update(_0024_0024iterator_0024330_00245013, _0024obj_00245012);
									if (_0024user_00245022 == _0024self__00245023.returnname.returnName())
									{
										_0024pos_00245020 = _0024obj_00245012.transform.TransformPoint(_0024pos_00245020);
										UnityRuntimeServices.Update(_0024_0024iterator_0024330_00245013, _0024obj_00245012);
										break;
									}
								}
								_0024scount_00245011++;
							}
							else
							{
								SpawningScript.spawnedCars.RemoveAt(_0024scount_00245011);
							}
						}
					}
					if (_0024user_00245022 == MasterServerScript.ainame && PhotonNetwork.isMasterClient && MasterServerScript.ainame != string.Empty)
					{
						_0024gavedamage_00245014 = true;
						SpawningScript.aiplayerobjs[0].SendMessage("missileHit", _0024self__00245023.theowner + "|" + _0024self__00245023.level.ToString() + "|" + _0024self__00245023.dM, SendMessageOptions.DontRequireReceiver);
					}
					if (_0024user_00245022 == MasterServerScript.ainame2 && PhotonNetwork.isMasterClient && MasterServerScript.ainame2 != string.Empty)
					{
						_0024gavedamage_00245014 = true;
						SpawningScript.aiplayerobjs[1].SendMessage("missileHit", _0024self__00245023.theowner + "|" + _0024self__00245023.level.ToString() + "|" + _0024self__00245023.dM, SendMessageOptions.DontRequireReceiver);
					}
					if (_0024user_00245022 == MasterServerScript.ainame3 && PhotonNetwork.isMasterClient && MasterServerScript.ainame3 != string.Empty)
					{
						_0024gavedamage_00245014 = true;
						SpawningScript.aiplayerobjs[2].SendMessage("missileHit", _0024self__00245023.theowner + "|" + _0024self__00245023.level.ToString() + "|" + _0024self__00245023.dM, SendMessageOptions.DontRequireReceiver);
					}
					if (AuthGameObject.username == _0024user_00245022 && _0024self__00245023.team != SpawningScript.team2)
					{
						if (ChatScript.debugMissiles)
						{
							((PhotonView)GameObject.Find("/GUI/Chat").GetComponent(typeof(PhotonView))).RPC("netDebug", PhotonTargets.All, AuthGameObject.username + " is sending the hit message to their local car with the string: " + _0024self__00245023.theowner + "|" + _0024self__00245023.level.ToString() + "|" + _0024self__00245023.dM);
						}
						SpawningScript.playertrans.gameObject.SendMessage("missileHit", _0024self__00245023.theowner + "|" + _0024self__00245023.level.ToString() + "|" + _0024self__00245023.dM, SendMessageOptions.DontRequireReceiver);
					}
					_0024colliders_00245015 = Physics.OverlapSphere(_0024pos_00245020, 20 + _0024self__00245023.level / 2);
					_0024_00241280_00245017 = 0;
					_0024_00241281_00245018 = _0024colliders_00245015;
					for (_0024_00241282_00245019 = _0024_00241281_00245018.Length; _0024_00241280_00245017 < _0024_00241282_00245019; _0024_00241280_00245017++)
					{
						_0024_00241281_00245018[_0024_00241280_00245017].gameObject.SendMessage("explosionHit", _0024self__00245023.theowner + "|" + Mathf.Round(5 + _0024self__00245023.level / 10).ToString() + "|" + _0024self__00245023.dM, SendMessageOptions.DontRequireReceiver);
					}
					UnityEngine.Object.Instantiate(_0024self__00245023.explosion, _0024pos_00245020, _0024rot_00245021);
					if ((bool)_0024self__00245023.flame)
					{
						_0024self__00245023.flame.emit = false;
					}
					if ((bool)_0024self__00245023.smoke)
					{
						_0024self__00245023.smoke.emit = false;
					}
					_0024self__00245023.transform.DetachChildren();
					UnityEngine.Object.Destroy(_0024self__00245023.gameObject.collider);
					_0024self__00245023.renderer.enabled = false;
					_0024self__00245023.rigidbody.isKinematic = true;
					result = (Yield(2, new WaitForSeconds(2.5f)) ? 1 : 0);
					break;
				case 2:
					if (_0024self__00245023 != null)
					{
						UnityEngine.Object.Destroy(_0024self__00245023.gameObject);
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

		internal Vector3 _0024pos_00245024;

		internal Quaternion _0024rot_00245025;

		internal string _0024user_00245026;

		internal MissileTrack _0024self__00245027;

		public _0024everyoneExplode_00245010(Vector3 pos, Quaternion rot, string user, MissileTrack self_)
		{
			_0024pos_00245024 = pos;
			_0024rot_00245025 = rot;
			_0024user_00245026 = user;
			_0024self__00245027 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024pos_00245024, _0024rot_00245025, _0024user_00245026, _0024self__00245027);
		}
	}

	private Transform target;

	private Vector3 targetpoint;

	private bool useobj;

	public GameObject explosion;

	private string theowner;

	private int level;

	private string team;

	public ParticleEmitter flame;

	public ParticleEmitter smoke;

	public AuthGameObject authobj;

	public WhirldIn win;

	public ReturnName returnname;

	public ChatScript cscript;

	private bool cansplash;

	private bool splashonce;

	public GameObject splashprefab;

	private Vector3 lastpos;

	private float timeout;

	public SpawningScript spawnsrc;

	public MasterServerScript mserver;

	public LayerMask layermask;

	private Vector3 wantedPos;

	private Quaternion wantedRot;

	private bool exploded;

	public float dM;

	public MissileTrack()
	{
		team = string.Empty;
		lastpos = new Vector3(0f, 0f, 0f);
		timeout = 15f;
		dM = 1f;
	}

	public virtual void setTarget(Transform t)
	{
		target = t;
		useobj = true;
	}

	public virtual void setTargetPoint(Vector3 v)
	{
		targetpoint = v;
		useobj = false;
	}

	public virtual void setowner(string s)
	{
		theowner = s;
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

	public virtual void OnCollisionEnter(Collision collision)
	{
		if (photonView.isMine)
		{
			string text = string.Empty;
			Vector3 vector = transform.position;
			if (collision.gameObject.name.Contains("Bot"))
			{
				collision.gameObject.SendMessage("missileHit", theowner + "|" + level.ToString() + "|" + dM, SendMessageOptions.DontRequireReceiver);
			}
			if (collision.gameObject.name == "CarPrefab(Clone)" || collision.gameObject.name == "MainBoxCol" || collision.gameObject.name == "HumanPrefab(Clone)")
			{
				returnname = (ReturnName)collision.gameObject.GetComponent("ReturnName");
				text = returnname.returnName();
				vector = collision.gameObject.transform.InverseTransformPoint(vector);
			}
			((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("everyoneExplode", PhotonTargets.All, vector, transform.rotation, text);
		}
	}

	[RPC]
	public virtual IEnumerator everyoneExplode(Vector3 pos, Quaternion rot, string user)
	{
		return new _0024everyoneExplode_00245010(pos, rot, user, this).GetEnumerator();
	}

	public virtual void Update()
	{
		if (exploded)
		{
			return;
		}
		if (photonView.isMine)
		{
			Quaternion to = default(Quaternion);
			if (useobj)
			{
				if ((bool)target)
				{
					to = Quaternion.LookRotation(target.position - transform.position);
				}
				else
				{
					((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("everyoneExplode", PhotonTargets.All, transform.position, transform.rotation, string.Empty);
				}
			}
			else
			{
				to = Quaternion.LookRotation(targetpoint - transform.position);
			}
			transform.rotation = Quaternion.Slerp(transform.rotation, to, Time.deltaTime * (8.3f + (float)level / 5f));
			transform.Translate(0f, 0f, (float)(200 + level * 5) * Time.deltaTime);
		}
		if (!(timeout <= 0f))
		{
			timeout -= Time.deltaTime;
		}
		else if (photonView.isMine)
		{
			((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("everyoneExplode", PhotonTargets.All, transform.position, transform.rotation, string.Empty);
		}
	}

	public virtual void Awake()
	{
		lastpos = transform.position;
		transform.Translate(0f, 0f, 200f * Time.deltaTime);
	}

	public virtual void LateUpdate()
	{
		if (exploded)
		{
			return;
		}
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
		if (!photonView.isMine)
		{
			return;
		}
		RaycastHit hitInfo = default(RaycastHit);
		if (Physics.Linecast(lastpos, transform.position, out hitInfo, layermask))
		{
			string text = string.Empty;
			Vector3 vector = hitInfo.point;
			if (hitInfo.transform.gameObject.name == "CarPrefab(Clone)" || hitInfo.transform.gameObject.name == "MainBoxCol" || hitInfo.transform.gameObject.name == "HumanPrefab(Clone)")
			{
				returnname = (ReturnName)hitInfo.transform.gameObject.GetComponent("ReturnName");
				text = returnname.returnName();
				if (text != AuthGameObject.username)
				{
					ReturnName returnName = (ReturnName)hitInfo.transform.gameObject.GetComponent("ReturnName");
					if (returnName.returnAI())
					{
						hitInfo.transform.SendMessage("missileHit", theowner + "|" + level.ToString() + "|" + dM, SendMessageOptions.DontRequireReceiver);
						Collider[] array = Physics.OverlapSphere(vector, 20 + level / 2);
						int i = 0;
						Collider[] array2 = array;
						for (int length = array2.Length; i < length; i++)
						{
							array2[i].gameObject.SendMessage("explosionHit", theowner + "|" + Mathf.Round(5 + level / 10).ToString() + "|" + dM, SendMessageOptions.DontRequireReceiver);
						}
					}
					vector = hitInfo.transform.gameObject.transform.InverseTransformPoint(vector);
				}
			}
			if (hitInfo.transform.gameObject.name.Contains("Bot"))
			{
				hitInfo.transform.gameObject.SendMessage("explosionHit", theowner + "|*");
				hitInfo.transform.gameObject.SendMessage("missilehit", theowner + "|" + level.ToString() + "|" + dM);
			}
			((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("everyoneExplode", PhotonTargets.All, vector, transform.rotation, text);
		}
		else
		{
			lastpos = transform.position;
		}
	}
}
