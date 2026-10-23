using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Photon;
using UnityEngine;

[Serializable]
public class FlameScript : Photon.MonoBehaviour
{
	[Serializable]
	internal sealed class _0024stopemitting_00245467 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal FlameScript _0024self__00245468;

			public _0024(FlameScript self_)
			{
				_0024self__00245468 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00245468.isActive = false;
					_0024self__00245468.particleEmitter.emit = false;
					if (_0024self__00245468.photonView.isMine)
					{
						FireGun.isfiringflame = false;
					}
					_0024self__00245468.gameObject.BroadcastMessage("setEnable", false);
					goto case 2;
				case 2:
					if (_0024self__00245468.particleEmitter.particles.Length > 0)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					if (_0024self__00245468 != null)
					{
						UnityEngine.Object.Destroy(_0024self__00245468.gameObject);
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

		internal FlameScript _0024self__00245469;

		public _0024stopemitting_00245467(FlameScript self_)
		{
			_0024self__00245469 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00245469);
		}
	}

	public float sizeGrowAtFirst;

	public float scatterVelocity;

	public float flyUpVelocity;

	private bool isPrefab;

	private bool isActive;

	public HealthBar hbar;

	public FireGun fgun;

	public ChatScript cscript;

	public AuthGameObject authobj;

	public PlayerCar_Script pscript;

	private string theuser;

	private int level;

	private string team;

	public GameObject groundFlame;

	public float dM;

	public FlameScript()
	{
		sizeGrowAtFirst = 3.5f;
		scatterVelocity = 50f;
		flyUpVelocity = 8f;
		isPrefab = true;
		isActive = true;
		team = string.Empty;
		dM = 1f;
	}

	public virtual void Start()
	{
		isActive = true;
		if (gameObject.name.Contains("Clone"))
		{
			particleEmitter.emit = true;
		}
	}

	public virtual void Update()
	{
		if ((!Input.GetButton("Fire1") || PlayerCar_Script.empdisable) && photonView.isMine && particleEmitter.emit)
		{
			((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("stopemitting", PhotonTargets.All);
		}
		if (ChatScript.primaryweapon == "flamethrower" && FireGun.guntype == "rocket" && FireGun.rocketreload && particleEmitter.emit)
		{
			((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("stopemitting", PhotonTargets.All);
		}
		if (ChatScript.secondaryweapon == "flamethrower" && FireGun.guntype == "laser" && FireGun.laserreload && particleEmitter.emit)
		{
			((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("stopemitting", PhotonTargets.All);
		}
		if (HealthBar.isdead && particleEmitter.emit)
		{
			((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("stopemitting", PhotonTargets.All);
		}
		if (!isActive)
		{
			particleEmitter.emit = false;
		}
	}

	[RPC]
	public virtual IEnumerator stopemitting()
	{
		return new _0024stopemitting_00245467(this).GetEnumerator();
	}

	public virtual void LateUpdate()
	{
		Particle[] particles = particleEmitter.particles;
		for (int i = 0; i < particles.Length; i++)
		{
			float num = 0.9f;
			if (!(particles[i].energy > num))
			{
				float y = particles[i].position.y + flyUpVelocity * Mathf.Sqrt((num - particles[i].energy) / num) * Time.deltaTime;
				Vector3 position = particles[i].position;
				float num2 = (position.y = y);
				Vector3 vector = (particles[i].position = position);
			}
			float num3 = 1.5f;
			if (!(particles[i].energy > num3) && !(particles[i].velocity.magnitude > 10f))
			{
				float x = particles[i].velocity.x + Time.deltaTime * UnityEngine.Random.Range((num3 - particles[i].energy) * (0f - scatterVelocity), (num3 - particles[i].energy) * scatterVelocity);
				Vector3 velocity = particles[i].velocity;
				float num4 = (velocity.x = x);
				Vector3 vector3 = (particles[i].velocity = velocity);
				float y2 = particles[i].velocity.y + Time.deltaTime * UnityEngine.Random.Range((num3 - particles[i].energy) * (0f - scatterVelocity), (num3 - particles[i].energy) * scatterVelocity);
				Vector3 velocity2 = particles[i].velocity;
				float num5 = (velocity2.y = y2);
				Vector3 vector5 = (particles[i].velocity = velocity2);
				float z = particles[i].velocity.z + Time.deltaTime * UnityEngine.Random.Range((num3 - particles[i].energy) * (0f - scatterVelocity), (num3 - particles[i].energy) * scatterVelocity);
				Vector3 velocity3 = particles[i].velocity;
				float num6 = (velocity3.z = z);
				Vector3 vector7 = (particles[i].velocity = velocity3);
			}
		}
		if (isActive && particleEmitter.emit)
		{
			for (int i = 0; i < particles.Length; i++)
			{
				float num7 = 0.6f;
				if (!(particles[i].energy < particleEmitter.maxEnergy - num7))
				{
					float num8 = Mathf.Clamp((particleEmitter.maxEnergy - particles[i].energy) / num7, 0f, 1f);
					num8 *= num8;
					float num9 = UnityEngine.Random.Range(1f - (particleEmitter.maxEnergy - particles[i].energy) / 4f, 1f + (particleEmitter.maxEnergy - particles[i].energy) / 4f);
					Vector3 vector9 = particleEmitter.transform.position + transform.forward * 2.5f * num9 * ((particleEmitter.maxEnergy - particles[i].energy) / num7);
					particles[i].velocity = transform.forward * 40f;
					float x2 = particles[i].velocity.x + UnityEngine.Random.Range(0f - (particleEmitter.maxEnergy - particles[i].energy) / num7, (particleEmitter.maxEnergy - particles[i].energy) / num7);
					Vector3 velocity4 = particles[i].velocity;
					float num10 = (velocity4.x = x2);
					Vector3 vector10 = (particles[i].velocity = velocity4);
					float y3 = particles[i].velocity.y + UnityEngine.Random.Range(0f - (particleEmitter.maxEnergy - particles[i].energy) / num7, (particleEmitter.maxEnergy - particles[i].energy) / num7);
					Vector3 velocity5 = particles[i].velocity;
					float num11 = (velocity5.y = y3);
					Vector3 vector12 = (particles[i].velocity = velocity5);
					float z2 = particles[i].velocity.z + UnityEngine.Random.Range(0f - (particleEmitter.maxEnergy - particles[i].energy) / num7, (particleEmitter.maxEnergy - particles[i].energy) / num7);
					Vector3 velocity6 = particles[i].velocity;
					float num12 = (velocity6.z = z2);
					Vector3 vector14 = (particles[i].velocity = velocity6);
					if (!(particles[i].size >= 0.2f))
					{
						particles[i].position = particles[i].position * num8 + vector9 * (1f - num8);
					}
					else
					{
						particles[i].position = particles[i].position * num8 + (vector9 + new Vector3(0f, (0f - particles[i].size) / 4f, 0f)) * (1f - num8);
					}
					float y4 = Mathf.Clamp(particles[i].position.y, 0f, 10000f);
					Vector3 position2 = particles[i].position;
					float num13 = (position2.y = y4);
					Vector3 vector16 = (particles[i].position = position2);
				}
			}
			for (int j = 0; (float)j < (float)particles.Length / 2f; j++)
			{
				int num14 = Mathf.Clamp(UnityEngine.Random.Range(1, particles.Length - 1), 0, particles.Length - 1);
				float num15 = 0.04f;
				float num16 = 0.25f;
				if (!(particles[num14].energy < particleEmitter.maxEnergy - num16) && !(particles[num14].energy > particleEmitter.maxEnergy - num15))
				{
					particles[num14].size = particles[num14].size + sizeGrowAtFirst * Time.deltaTime;
					float y5 = particles[num14].position.y - 1f * Time.deltaTime;
					Vector3 position3 = particles[num14].position;
					float num17 = (position3.y = y5);
					Vector3 vector18 = (particles[num14].position = position3);
				}
			}
		}
		particleEmitter.particles = particles;
	}

	public virtual string returnUser()
	{
		return theuser;
	}

	public virtual int returnLevel()
	{
		return level;
	}

	public virtual string returnTeam()
	{
		return team;
	}

	public virtual void setUsername(string user)
	{
		theuser = user;
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

	public virtual void setIsPrefab(bool value)
	{
		isPrefab = value;
	}
}
