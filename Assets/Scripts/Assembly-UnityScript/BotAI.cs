using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using Photon;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class BotAI : Photon.MonoBehaviour
{
	[Serializable]
	internal sealed class _0024Start_00243303 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal BotAI _0024self__00243304;

			public _0024(BotAI self_)
			{
				_0024self__00243304 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (GameObject.Find("/ProjectileMan") == null)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024self__00243304.projMan = (ProjectileReferenceManager)GameObject.Find("/ProjectileMan").GetComponent(typeof(ProjectileReferenceManager));
					if (!_0024self__00243304.gameObject.name.Contains("Attack") && PhotonNetwork.isMasterClient)
					{
						_0024self__00243304.photonView.viewID = PhotonNetwork.AllocateViewID();
					}
					result = (YieldDefault(3) ? 1 : 0);
					break;
				case 3:
					result = (YieldDefault(4) ? 1 : 0);
					break;
				case 4:
					if (!_0024self__00243304.photonView.isMine && _0024self__00243304.gameObject.name.Contains("Attack"))
					{
						((PhotonView)_0024self__00243304.gameObject.GetComponent(typeof(PhotonView))).RPC("doesThisExist", PhotonTargets.MasterClient);
						result = (Yield(5, new WaitForSeconds(2.5f)) ? 1 : 0);
						break;
					}
					goto IL_0162;
				case 5:
					if (!_0024self__00243304.doesexist)
					{
						UnityEngine.Object.Destroy(_0024self__00243304.gameObject);
					}
					goto IL_0162;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0162:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal BotAI _0024self__00243305;

		public _0024Start_00243303(BotAI self_)
		{
			_0024self__00243305 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00243305);
		}
	}

	[Serializable]
	internal sealed class _0024grenadeHit_00243306 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string _0024username_00243307;

			internal BotAI _0024self__00243308;

			public _0024(string username, BotAI self_)
			{
				_0024username_00243307 = username;
				_0024self__00243308 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (!_0024username_00243307.Contains("Killer_Drones"))
					{
						if (_0024self__00243308.photonView.isMine || MasterServerScript.connectedToDed)
						{
							if (_0024self__00243308.ptarget == SpawningScript.playertrans || _0024username_00243307.Contains("*"))
							{
								_0024self__00243308.health -= 100;
								if (_0024self__00243308.health <= 0 && !_0024self__00243308.alreadyExploded)
								{
									_0024self__00243308.alreadyExploded = true;
									((PhotonView)_0024self__00243308.gameObject.GetComponent(typeof(PhotonView))).RPC("createExplosion", PhotonTargets.All, _0024self__00243308.transform.position);
									if (_0024self__00243308.gameObject.name.Contains("Attack"))
									{
										result = (YieldDefault(2) ? 1 : 0);
										break;
									}
									UnityEngine.Object.Destroy(_0024self__00243308.gameObject);
								}
							}
						}
						else
						{
							((PhotonView)_0024self__00243308.gameObject.GetComponent(typeof(PhotonView))).RPC("grenadeHit", _0024self__00243308.photonView.owner, _0024username_00243307);
						}
					}
					goto IL_01a5;
				case 2:
					PhotonNetwork.Destroy(_0024self__00243308.gameObject);
					goto IL_01a5;
				case 1:
					{
						result = 0;
						break;
					}
					IL_01a5:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal string _0024username_00243309;

		internal BotAI _0024self__00243310;

		public _0024grenadeHit_00243306(string username, BotAI self_)
		{
			_0024username_00243309 = username;
			_0024self__00243310 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024username_00243309, _0024self__00243310);
		}
	}

	[Serializable]
	internal sealed class _0024missileHit_00243311 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string _0024username_00243312;

			internal BotAI _0024self__00243313;

			public _0024(string username, BotAI self_)
			{
				_0024username_00243312 = username;
				_0024self__00243313 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (!_0024username_00243312.Contains("Killer_Drones"))
					{
						if (_0024self__00243313.photonView.isMine || MasterServerScript.connectedToDed)
						{
							if (_0024self__00243313.ptarget == SpawningScript.playertrans || _0024username_00243312.Contains("*"))
							{
								_0024self__00243313.health -= 100;
								if (_0024self__00243313.health <= 0 && !_0024self__00243313.alreadyExploded)
								{
									_0024self__00243313.alreadyExploded = true;
									((PhotonView)_0024self__00243313.gameObject.GetComponent(typeof(PhotonView))).RPC("createExplosion", PhotonTargets.All, _0024self__00243313.transform.position);
									if (_0024self__00243313.gameObject.name.Contains("Attack"))
									{
										result = (YieldDefault(2) ? 1 : 0);
										break;
									}
									UnityEngine.Object.Destroy(_0024self__00243313.gameObject);
								}
							}
						}
						else
						{
							((PhotonView)_0024self__00243313.gameObject.GetComponent(typeof(PhotonView))).RPC("missileHit", _0024self__00243313.photonView.owner, _0024username_00243312);
						}
					}
					goto IL_01a5;
				case 2:
					PhotonNetwork.Destroy(_0024self__00243313.gameObject);
					goto IL_01a5;
				case 1:
					{
						result = 0;
						break;
					}
					IL_01a5:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal string _0024username_00243314;

		internal BotAI _0024self__00243315;

		public _0024missileHit_00243311(string username, BotAI self_)
		{
			_0024username_00243314 = username;
			_0024self__00243315 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024username_00243314, _0024self__00243315);
		}
	}

	[Serializable]
	internal sealed class _0024laserCannonHit_00243316 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string _0024username_00243317;

			internal BotAI _0024self__00243318;

			public _0024(string username, BotAI self_)
			{
				_0024username_00243317 = username;
				_0024self__00243318 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (!_0024username_00243317.Contains("Killer_Drones"))
					{
						if (_0024self__00243318.photonView.isMine || MasterServerScript.connectedToDed)
						{
							if (_0024self__00243318.ptarget == SpawningScript.playertrans || _0024username_00243317.Contains("*"))
							{
								_0024self__00243318.health -= 100;
								if (_0024self__00243318.health <= 0 && !_0024self__00243318.alreadyExploded)
								{
									_0024self__00243318.alreadyExploded = true;
									((PhotonView)_0024self__00243318.gameObject.GetComponent(typeof(PhotonView))).RPC("createExplosion", PhotonTargets.All, _0024self__00243318.transform.position);
									if (_0024self__00243318.gameObject.name.Contains("Attack"))
									{
										result = (YieldDefault(2) ? 1 : 0);
										break;
									}
									UnityEngine.Object.Destroy(_0024self__00243318.gameObject);
								}
							}
						}
						else
						{
							((PhotonView)_0024self__00243318.gameObject.GetComponent(typeof(PhotonView))).RPC("laserCannonHit", _0024self__00243318.photonView.owner, _0024username_00243317);
						}
					}
					goto IL_01a5;
				case 2:
					PhotonNetwork.Destroy(_0024self__00243318.gameObject);
					goto IL_01a5;
				case 1:
					{
						result = 0;
						break;
					}
					IL_01a5:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal string _0024username_00243319;

		internal BotAI _0024self__00243320;

		public _0024laserCannonHit_00243316(string username, BotAI self_)
		{
			_0024username_00243319 = username;
			_0024self__00243320 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024username_00243319, _0024self__00243320);
		}
	}

	[Serializable]
	internal sealed class _0024explosionHit_00243321 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string _0024username_00243322;

			internal BotAI _0024self__00243323;

			public _0024(string username, BotAI self_)
			{
				_0024username_00243322 = username;
				_0024self__00243323 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (!_0024username_00243322.Contains("Killer_Drones"))
					{
						if ((_0024self__00243323.photonView.isMine || MasterServerScript.connectedToDed) && (_0024self__00243323.ptarget == SpawningScript.playertrans || _0024username_00243322.Contains("*")))
						{
							_0024self__00243323.health -= 70;
							if (_0024self__00243323.health <= 0 && !_0024self__00243323.alreadyExploded)
							{
								_0024self__00243323.alreadyExploded = true;
								((PhotonView)_0024self__00243323.gameObject.GetComponent(typeof(PhotonView))).RPC("createExplosion", PhotonTargets.All, _0024self__00243323.transform.position);
								if (_0024self__00243323.gameObject.name.Contains("Attack"))
								{
									result = (YieldDefault(2) ? 1 : 0);
									break;
								}
								UnityEngine.Object.Destroy(_0024self__00243323.gameObject);
							}
						}
					}
					else
					{
						((PhotonView)_0024self__00243323.gameObject.GetComponent(typeof(PhotonView))).RPC("explosionHit", _0024self__00243323.photonView.owner, _0024username_00243322);
					}
					goto IL_01a5;
				case 2:
					PhotonNetwork.Destroy(_0024self__00243323.gameObject);
					goto IL_01a5;
				case 1:
					{
						result = 0;
						break;
					}
					IL_01a5:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal string _0024username_00243324;

		internal BotAI _0024self__00243325;

		public _0024explosionHit_00243321(string username, BotAI self_)
		{
			_0024username_00243324 = username;
			_0024self__00243325 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024username_00243324, _0024self__00243325);
		}
	}

	[Serializable]
	internal sealed class _0024shotgunBulletHit_00243326 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string _0024username_00243327;

			internal BotAI _0024self__00243328;

			public _0024(string username, BotAI self_)
			{
				_0024username_00243327 = username;
				_0024self__00243328 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (!_0024username_00243327.Contains("Killer_Drones"))
					{
						if (_0024self__00243328.photonView.isMine || MasterServerScript.connectedToDed)
						{
							if (_0024self__00243328.ptarget == SpawningScript.playertrans || _0024username_00243327.Contains("*"))
							{
								_0024self__00243328.health -= 40;
								if (_0024self__00243328.health <= 0 && !_0024self__00243328.alreadyExploded)
								{
									_0024self__00243328.alreadyExploded = true;
									((PhotonView)_0024self__00243328.gameObject.GetComponent(typeof(PhotonView))).RPC("createExplosion", PhotonTargets.All, _0024self__00243328.transform.position);
									if (_0024self__00243328.gameObject.name.Contains("Attack"))
									{
										result = (YieldDefault(2) ? 1 : 0);
										break;
									}
									UnityEngine.Object.Destroy(_0024self__00243328.gameObject);
								}
							}
						}
						else
						{
							((PhotonView)_0024self__00243328.gameObject.GetComponent(typeof(PhotonView))).RPC("shotgunBulletHit", _0024self__00243328.photonView.owner, _0024username_00243327);
						}
					}
					goto IL_01a5;
				case 2:
					PhotonNetwork.Destroy(_0024self__00243328.gameObject);
					goto IL_01a5;
				case 1:
					{
						result = 0;
						break;
					}
					IL_01a5:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal string _0024username_00243329;

		internal BotAI _0024self__00243330;

		public _0024shotgunBulletHit_00243326(string username, BotAI self_)
		{
			_0024username_00243329 = username;
			_0024self__00243330 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024username_00243329, _0024self__00243330);
		}
	}

	[Serializable]
	internal sealed class _0024bulletHit_00243331 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string _0024username_00243332;

			internal BotAI _0024self__00243333;

			public _0024(string username, BotAI self_)
			{
				_0024username_00243332 = username;
				_0024self__00243333 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (!_0024username_00243332.Contains("Killer_Drones"))
					{
						if (_0024self__00243333.photonView.isMine || MasterServerScript.connectedToDed)
						{
							if (_0024self__00243333.ptarget == SpawningScript.playertrans || _0024username_00243332.Contains("*"))
							{
								_0024self__00243333.health -= 20;
								if (_0024self__00243333.health <= 0 && !_0024self__00243333.alreadyExploded)
								{
									_0024self__00243333.alreadyExploded = true;
									((PhotonView)_0024self__00243333.gameObject.GetComponent(typeof(PhotonView))).RPC("createExplosion", PhotonTargets.All, _0024self__00243333.transform.position);
									if (_0024self__00243333.gameObject.name.Contains("Attack"))
									{
										result = (YieldDefault(2) ? 1 : 0);
										break;
									}
									UnityEngine.Object.Destroy(_0024self__00243333.gameObject);
								}
							}
						}
						else
						{
							((PhotonView)_0024self__00243333.gameObject.GetComponent(typeof(PhotonView))).RPC("bulletHit", _0024self__00243333.photonView.owner, _0024username_00243332);
						}
					}
					goto IL_01a5;
				case 2:
					PhotonNetwork.Destroy(_0024self__00243333.gameObject);
					goto IL_01a5;
				case 1:
					{
						result = 0;
						break;
					}
					IL_01a5:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal string _0024username_00243334;

		internal BotAI _0024self__00243335;

		public _0024bulletHit_00243331(string username, BotAI self_)
		{
			_0024username_00243334 = username;
			_0024self__00243335 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024username_00243334, _0024self__00243335);
		}
	}

	[Serializable]
	internal sealed class _0024railBulletHit_00243336 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string _0024username_00243337;

			internal BotAI _0024self__00243338;

			public _0024(string username, BotAI self_)
			{
				_0024username_00243337 = username;
				_0024self__00243338 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (!_0024username_00243337.Contains("Killer_Drones"))
					{
						if (_0024self__00243338.photonView.isMine || MasterServerScript.connectedToDed)
						{
							if (_0024self__00243338.ptarget == SpawningScript.playertrans || _0024username_00243337.Contains("*"))
							{
								_0024self__00243338.health -= 100;
								if (_0024self__00243338.health <= 0 && !_0024self__00243338.alreadyExploded)
								{
									_0024self__00243338.alreadyExploded = true;
									((PhotonView)_0024self__00243338.gameObject.GetComponent(typeof(PhotonView))).RPC("createExplosion", PhotonTargets.All, _0024self__00243338.transform.position);
									if (_0024self__00243338.gameObject.name.Contains("Attack"))
									{
										result = (YieldDefault(2) ? 1 : 0);
										break;
									}
									UnityEngine.Object.Destroy(_0024self__00243338.gameObject);
								}
							}
						}
						else
						{
							((PhotonView)_0024self__00243338.gameObject.GetComponent(typeof(PhotonView))).RPC("railBulletHit", _0024self__00243338.photonView.owner, _0024username_00243337);
						}
					}
					goto IL_01a5;
				case 2:
					PhotonNetwork.Destroy(_0024self__00243338.gameObject);
					goto IL_01a5;
				case 1:
					{
						result = 0;
						break;
					}
					IL_01a5:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal string _0024username_00243339;

		internal BotAI _0024self__00243340;

		public _0024railBulletHit_00243336(string username, BotAI self_)
		{
			_0024username_00243339 = username;
			_0024self__00243340 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024username_00243339, _0024self__00243340);
		}
	}

	[Serializable]
	internal sealed class _0024OnParticleCollision_00243341 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal object _0024username_00243342;

			internal GameObject _0024theparticle_00243343;

			internal BotAI _0024self__00243344;

			public _0024(GameObject theparticle, BotAI self_)
			{
				_0024theparticle_00243343 = theparticle;
				_0024self__00243344 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024theparticle_00243343.name == "flameprefab(Clone)" && !((float)_0024self__00243344.health <= 0f))
					{
						_0024username_00243342 = UnityRuntimeServices.Invoke(_0024theparticle_00243343.GetComponent("FlameScript"), "returnUser", new object[0], typeof(UnityEngine.MonoBehaviour));
						if (!RuntimeServices.ToBool(RuntimeServices.Invoke(_0024username_00243342, "Contains", new object[1] { "Killer_Drones" })))
						{
							if (_0024self__00243344.photonView.isMine || MasterServerScript.connectedToDed)
							{
								_0024self__00243344.health -= 30;
								if (_0024self__00243344.health <= 0 && !_0024self__00243344.alreadyExploded)
								{
									_0024self__00243344.alreadyExploded = true;
									((PhotonView)_0024self__00243344.gameObject.GetComponent(typeof(PhotonView))).RPC("createExplosion", PhotonTargets.All, _0024self__00243344.transform.position);
									if (_0024self__00243344.gameObject.name.Contains("Attack"))
									{
										result = (YieldDefault(2) ? 1 : 0);
										break;
									}
									UnityEngine.Object.Destroy(_0024self__00243344.gameObject);
								}
							}
							else
							{
								((PhotonView)_0024self__00243344.gameObject.GetComponent(typeof(PhotonView))).RPC("Phit", _0024self__00243344.photonView.owner, _0024username_00243342);
							}
						}
					}
					goto IL_01e6;
				case 2:
					PhotonNetwork.Destroy(_0024self__00243344.gameObject);
					goto IL_01e6;
				case 1:
					{
						result = 0;
						break;
					}
					IL_01e6:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal GameObject _0024theparticle_00243345;

		internal BotAI _0024self__00243346;

		public _0024OnParticleCollision_00243341(GameObject theparticle, BotAI self_)
		{
			_0024theparticle_00243345 = theparticle;
			_0024self__00243346 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024theparticle_00243345, _0024self__00243346);
		}
	}

	[Serializable]
	internal sealed class _0024Phit_00243347 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal BotAI _0024self__00243348;

			public _0024(BotAI self_)
			{
				_0024self__00243348 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (!((float)_0024self__00243348.health <= 0f))
					{
						_0024self__00243348.health -= 30;
						if (_0024self__00243348.health <= 0 && !_0024self__00243348.alreadyExploded)
						{
							_0024self__00243348.alreadyExploded = true;
							((PhotonView)_0024self__00243348.gameObject.GetComponent(typeof(PhotonView))).RPC("createExplosion", PhotonTargets.All, _0024self__00243348.transform.position);
							if (_0024self__00243348.gameObject.name.Contains("Attack"))
							{
								result = (YieldDefault(2) ? 1 : 0);
								break;
							}
							UnityEngine.Object.Destroy(_0024self__00243348.gameObject);
						}
					}
					goto IL_0108;
				case 2:
					PhotonNetwork.Destroy(_0024self__00243348.gameObject);
					goto IL_0108;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0108:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal BotAI _0024self__00243349;

		public _0024Phit_00243347(BotAI self_)
		{
			_0024self__00243349 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00243349);
		}
	}

	[Serializable]
	internal sealed class _0024laserhit_00243350 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string _0024username_00243351;

			internal BotAI _0024self__00243352;

			public _0024(string username, BotAI self_)
			{
				_0024username_00243351 = username;
				_0024self__00243352 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (!_0024username_00243351.Contains("Killer_Drones"))
					{
						if (_0024self__00243352.photonView.isMine || MasterServerScript.connectedToDed)
						{
							if (_0024self__00243352.ptarget == SpawningScript.playertrans || _0024username_00243351.Contains("*"))
							{
								_0024self__00243352.health -= 50;
								if (_0024self__00243352.health <= 0 && !_0024self__00243352.alreadyExploded)
								{
									_0024self__00243352.alreadyExploded = true;
									((PhotonView)_0024self__00243352.gameObject.GetComponent(typeof(PhotonView))).RPC("createExplosion", PhotonTargets.All, _0024self__00243352.transform.position);
									if (_0024self__00243352.gameObject.name.Contains("Attack"))
									{
										result = (YieldDefault(2) ? 1 : 0);
										break;
									}
									UnityEngine.Object.Destroy(_0024self__00243352.gameObject);
								}
							}
						}
						else
						{
							((PhotonView)_0024self__00243352.gameObject.GetComponent(typeof(PhotonView))).RPC("laserhit", _0024self__00243352.photonView.owner, _0024username_00243351);
						}
					}
					goto IL_01a5;
				case 2:
					PhotonNetwork.Destroy(_0024self__00243352.gameObject);
					goto IL_01a5;
				case 1:
					{
						result = 0;
						break;
					}
					IL_01a5:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal string _0024username_00243353;

		internal BotAI _0024self__00243354;

		public _0024laserhit_00243350(string username, BotAI self_)
		{
			_0024username_00243353 = username;
			_0024self__00243354 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024username_00243353, _0024self__00243354);
		}
	}

	public Transform lookatobj;

	public Transform firepoint;

	public Transform aimer;

	private float yVelocity;

	public SpawningScript src;

	public LayerMask layermask;

	private float speedmult;

	public GameObject laserprefab;

	public GameObject rocketprefab;

	public GameObject laseraud;

	public GameObject rocketaud;

	public AuthGameObject authobj;

	public PauseObject pauseobj;

	public EndofRound endofround;

	public MasterServerScript mserver;

	public BotSpawner bspawn;

	private float timer;

	private int health;

	public GameObject explosion;

	public string botteam;

	private bool disablebot;

	[NonSerialized]
	public static bool disbot;

	private Vector3 lastknownloc;

	[NonSerialized]
	public static Vector3 lkl;

	private Transform ptarget;

	private bool isrocket;

	private bool doesexist;

	private InterpNetTrans pRemote;

	private ProjectileReferenceManager projMan;

	private bool alreadyExploded;

	public BotAI()
	{
		speedmult = 1f;
		timer = 1.2f;
		health = 100;
		botteam = string.Empty;
	}

	public virtual void Awake()
	{
		pRemote = (InterpNetTrans)gameObject.GetComponent(typeof(InterpNetTrans));
	}

	public virtual void setTarget(Transform t)
	{
		ptarget = t;
	}

	public virtual void setToRocket()
	{
		isrocket = true;
	}

	[RPC]
	public virtual void customNetDestroy()
	{
		UnityEngine.Object.Destroy(gameObject);
	}

	public virtual IEnumerator Start()
	{
		return new _0024Start_00243303(this).GetEnumerator();
	}

	[RPC]
	public virtual void doesThisExist(PhotonMessageInfo info)
	{
		((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("stopDestroy", info.sender);
	}

	[RPC]
	public virtual void stopDestroy()
	{
		doesexist = true;
	}

	[RPC]
	public virtual void rockethit(string username)
	{
		if (username.Contains("Killer_Drones"))
		{
			return;
		}
		if (photonView.isMine || MasterServerScript.connectedToDed)
		{
			if (!(ptarget == SpawningScript.playertrans) && !username.Contains("*"))
			{
				return;
			}
			Debug.Log(health);
			health -= 100;
			if (health <= 0 && !alreadyExploded)
			{
				alreadyExploded = true;
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("createExplosion", PhotonTargets.All, transform.position);
				if (gameObject.name.Contains("Attack"))
				{
					PhotonNetwork.Destroy(gameObject);
				}
				else
				{
					UnityEngine.Object.Destroy(gameObject);
				}
			}
		}
		else
		{
			((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("rockethit", photonView.owner, username);
		}
	}

	public virtual void PlayerCloak(bool i)
	{
		if (photonView.isMine && ptarget == SpawningScript.playertrans)
		{
			disablebot = i;
			lastknownloc = ptarget.position;
		}
		else
		{
			((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("playerCloakRPC", photonView.owner, i, AuthGameObject.username);
		}
	}

	[RPC]
	public virtual void playerCloakRPC(bool i, string u)
	{
		PlayerCar_Script playerCar_Script = (PlayerCar_Script)ptarget.GetComponent("PlayerCar_Script");
		if (playerCar_Script.returnName() == u)
		{
			disablebot = i;
			lastknownloc = ptarget.position;
		}
	}

	[RPC]
	public virtual IEnumerator grenadeHit(string username)
	{
		return new _0024grenadeHit_00243306(username, this).GetEnumerator();
	}

	[RPC]
	public virtual IEnumerator missileHit(string username)
	{
		return new _0024missileHit_00243311(username, this).GetEnumerator();
	}

	[RPC]
	public virtual IEnumerator laserCannonHit(string username)
	{
		return new _0024laserCannonHit_00243316(username, this).GetEnumerator();
	}

	[RPC]
	public virtual IEnumerator explosionHit(string username)
	{
		return new _0024explosionHit_00243321(username, this).GetEnumerator();
	}

	[RPC]
	public virtual IEnumerator shotgunBulletHit(string username)
	{
		return new _0024shotgunBulletHit_00243326(username, this).GetEnumerator();
	}

	[RPC]
	public virtual IEnumerator bulletHit(string username)
	{
		return new _0024bulletHit_00243331(username, this).GetEnumerator();
	}

	[RPC]
	public virtual IEnumerator railBulletHit(string username)
	{
		return new _0024railBulletHit_00243336(username, this).GetEnumerator();
	}

	public virtual IEnumerator OnParticleCollision(GameObject theparticle)
	{
		return new _0024OnParticleCollision_00243341(theparticle, this).GetEnumerator();
	}

	[RPC]
	public virtual void createExplosion(Vector3 pos)
	{
		UnityEngine.Object.Instantiate(explosion, pos, transform.rotation);
	}

	[RPC]
	public virtual void createExplosionandKill(Vector3 pos)
	{
		UnityEngine.Object.Instantiate(explosion, pos, transform.rotation);
		if (photonView.isMine)
		{
			PhotonNetwork.Destroy(gameObject);
		}
	}

	[RPC]
	public virtual IEnumerator Phit(string username)
	{
		return new _0024Phit_00243347(this).GetEnumerator();
	}

	[RPC]
	public virtual IEnumerator laserhit(string username)
	{
		return new _0024laserhit_00243350(username, this).GetEnumerator();
	}

	public virtual void returnbadge(GameObject t)
	{
		t.SendMessage("returnedbadge", "Killer Drone" + " - " + health.ToString() + "%" + ((!(pRemote.networkStatus != string.Empty)) ? string.Empty : ("\n" + pRemote.networkStatus)));
	}

	public virtual void Update()
	{
		if (!this.gameObject.name.Contains("Attack"))
		{
			ptarget = BotSpawner.hiveMindTarget;
		}
		if (ptarget != null && (photonView.isMine || MasterServerScript.connectedToDed))
		{
			disbot = disablebot;
			lkl = lastknownloc;
			float sqrMagnitude;
			float num;
			Vector3 direction;
			Vector3 direction3;
			RaycastHit hitInfo;
			if (!disablebot)
			{
				sqrMagnitude = (ptarget.position - transform.position).sqrMagnitude;
				if (!(sqrMagnitude <= 80000f))
				{
					speedmult = 3f;
				}
				else
				{
					speedmult = 1f;
				}
				if (!(EndofRound.alphastat <= 0f) && this.gameObject.name.Contains("Attack"))
				{
					((PhotonView)this.gameObject.GetComponent(typeof(PhotonView))).RPC("createExplosionandKill", PhotonTargets.All, transform.position);
				}
				num = Mathf.SmoothDampAngle(transform.eulerAngles.y, lookatobj.eulerAngles.y, ref yVelocity, 0.15f);
				float y = num;
				Quaternion rotation = transform.rotation;
				Vector3 eulerAngles = rotation.eulerAngles;
				float num2 = (eulerAngles.y = y);
				Vector3 vector = (rotation.eulerAngles = eulerAngles);
				Quaternion quaternion = (transform.rotation = rotation);
				direction = transform.TransformDirection(Vector3.forward);
				hitInfo = default(RaycastHit);
				if (Physics.Raycast(transform.position, direction, out hitInfo, 15f, layermask))
				{
					Vector3 direction2 = transform.TransformDirection(Vector3.right);
					if (Physics.Raycast(transform.position, direction2, 50f, layermask))
					{
						rigidbody.AddRelativeForce(-210000f * Time.deltaTime * speedmult, 0f, 0f);
					}
					else
					{
						rigidbody.AddRelativeForce(210000f * Time.deltaTime * speedmult, 0f, 0f);
					}
					if (!Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up), 100f, layermask))
					{
						rigidbody.AddRelativeForce(0f, 280000f * Time.deltaTime * speedmult, 0f);
					}
				}
				else
				{
					rigidbody.AddRelativeForce(0f, 0f, 210000f * Time.deltaTime * speedmult);
				}
				direction3 = transform.TransformDirection(-Vector3.up);
				if (Physics.Raycast(transform.position, direction3, out hitInfo, 15f, layermask))
				{
					Debug.DrawLine(transform.position, hitInfo.point, Color.blue);
					rigidbody.AddRelativeForce(0f, 140000f * Time.deltaTime * speedmult, 0f);
				}
				else if (!(transform.position.y <= ptarget.position.y + 5f))
				{
					rigidbody.AddRelativeForce(0f, -140000f * Time.deltaTime * speedmult, 0f);
				}
				else
				{
					rigidbody.AddRelativeForce(0f, 140000f * Time.deltaTime * speedmult, 0f);
				}
				if ((PauseObject.pubalpha == 1f && !this.gameObject.name.Contains("Attack")) || EndofRound.alphastat > 0f || !Physics.Linecast(transform.position, ptarget.position, out hitInfo, layermask))
				{
					return;
				}
				Debug.DrawLine(transform.position, hitInfo.point, Color.green);
				if (!(hitInfo.transform.gameObject.name == "MainBoxCol") && !(hitInfo.transform.gameObject.name == "CarPrefab(Clone)") && !(hitInfo.transform.gameObject.name == "HumanPrefab(Clone)"))
				{
					return;
				}
				if (!(timer <= 0f))
				{
					timer -= Time.deltaTime;
					return;
				}
				timer = 1.2f;
				GameObject gameObject = null;
				if (ptarget == SpawningScript.playertrans)
				{
					gameObject = (GameObject)UnityEngine.Object.Instantiate(laserprefab, firepoint.position, aimer.rotation);
					gameObject.SendMessage("setowner", "Killer_Drones");
					gameObject.SendMessage("setlevel", 1);
					((LaserSplat)gameObject.GetComponent(typeof(LaserSplat))).firedFrom = this.gameObject;
					GameObject gameObject2 = (GameObject)UnityEngine.Object.Instantiate(laseraud, lookatobj.position, lookatobj.rotation);
					gameObject2.SendMessage("sticksound", this.gameObject);
				}
				else if (!isrocket)
				{
					((PhotonView)this.gameObject.GetComponent(typeof(PhotonView))).RPC("firelaser", PhotonTargets.All, firepoint.position, aimer.rotation, AuthGameObject.username, UnityEngine.Random.Range(-999999999, 999999999));
				}
				else
				{
					((PhotonView)this.gameObject.GetComponent(typeof(PhotonView))).RPC("firerocket", PhotonTargets.All, firepoint.position, aimer.rotation, AuthGameObject.username, UnityEngine.Random.Range(-999999999, 999999999));
				}
				return;
			}
			sqrMagnitude = (lastknownloc - transform.position).sqrMagnitude;
			if (!(sqrMagnitude <= 80000f))
			{
				speedmult = 3.2f;
			}
			else
			{
				speedmult = 1f;
			}
			num = Mathf.SmoothDampAngle(transform.eulerAngles.y, lookatobj.eulerAngles.y, ref yVelocity, 0.3f);
			float y2 = num;
			Quaternion rotation2 = transform.rotation;
			Vector3 eulerAngles2 = rotation2.eulerAngles;
			float num3 = (eulerAngles2.y = y2);
			Vector3 vector3 = (rotation2.eulerAngles = eulerAngles2);
			Quaternion quaternion3 = (transform.rotation = rotation2);
			direction = transform.TransformDirection(Vector3.forward);
			if (Physics.Raycast(transform.position, direction, 15f, layermask))
			{
				Vector3 direction2 = transform.TransformDirection(Vector3.right);
				if (Physics.Raycast(transform.position, direction2, 50f, layermask))
				{
					rigidbody.AddRelativeForce(-210000f * Time.deltaTime * speedmult, 0f, 0f);
				}
				else
				{
					rigidbody.AddRelativeForce(210000f * Time.deltaTime * speedmult, 0f, 0f);
				}
			}
			else
			{
				rigidbody.AddRelativeForce(0f, 0f, 210000f * Time.deltaTime * speedmult);
			}
			direction3 = transform.TransformDirection(-Vector3.up);
			if (Physics.Raycast(transform.position, direction3, out hitInfo, 15f, layermask))
			{
				Debug.DrawLine(transform.position, hitInfo.point, Color.blue);
				rigidbody.AddRelativeForce(0f, 140000f * Time.deltaTime * speedmult, 0f);
			}
			else if (!(transform.position.y <= lastknownloc.y + 5f))
			{
				rigidbody.AddRelativeForce(0f, -140000f * Time.deltaTime * speedmult, 0f);
			}
			else
			{
				rigidbody.AddRelativeForce(0f, 140000f * Time.deltaTime * speedmult, 0f);
			}
		}
		else if (ptarget == null && photonView.isMine)
		{
			GameObject.Find("/Spawn Point").SendMessage("returnNewTarget");
		}
	}

	[RPC]
	public virtual void firerocket(Vector3 pos, Quaternion rot, string user, int id)
	{
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(rocketprefab, pos, rot);
		gameObject.SendMessage("setowner", user);
		gameObject.SendMessage("setlevel", 10);
		gameObject.SendMessage("setBot");
		projMan.AllocateNewId(gameObject.gameObject, id);
		((RocketBlowup)gameObject.GetComponent(typeof(RocketBlowup))).pid = id;
		Physics.IgnoreCollision(gameObject.collider, collider);
		GameObject gameObject2 = (GameObject)UnityEngine.Object.Instantiate(rocketaud, pos, rot);
		gameObject2.SendMessage("sticksound", this.gameObject);
	}

	[RPC]
	public virtual void firelaser(Vector3 pos, Quaternion rot, string user, int id)
	{
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(laserprefab, pos, rot);
		gameObject.SendMessage("setowner", user);
		gameObject.SendMessage("setlevel", 10);
		gameObject.SendMessage("setBot");
		projMan.AllocateNewId(gameObject.gameObject, id);
		((LaserSplat)gameObject.GetComponent(typeof(LaserSplat))).pid = id;
		GameObject gameObject2 = (GameObject)UnityEngine.Object.Instantiate(laseraud, pos, rot);
		gameObject2.SendMessage("sticksound", this.gameObject);
	}
}
