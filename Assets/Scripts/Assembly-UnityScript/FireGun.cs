using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using Photon;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class FireGun : Photon.MonoBehaviour
{
	[Serializable]
	internal sealed class _0024yieldStop_00244609 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					result = (Yield(2, new WaitForSeconds(0.15f)) ? 1 : 0);
					break;
				case 2:
					stopgrapple = false;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024();
		}
	}

	[Serializable]
	internal sealed class _0024startBoost_00244610 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal GameObject _0024wheel_00244611;

			internal float _0024boostcounter_00244612;

			internal int _0024_00241116_00244613;

			internal GameObject[] _0024_00241117_00244614;

			internal int _0024_00241118_00244615;

			internal int _0024i_00244616;

			internal FireGun _0024self__00244617;

			public _0024(int i, FireGun self_)
			{
				_0024i_00244616 = i;
				_0024self__00244617 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_00241116_00244613 = 0;
					_0024_00241117_00244614 = _0024self__00244617.wheels;
					for (_0024_00241118_00244615 = _0024_00241117_00244614.Length; _0024_00241116_00244613 < _0024_00241118_00244615; _0024_00241116_00244613++)
					{
						_0024_00241117_00244614[_0024_00241116_00244613].SendMessage("startFlame");
					}
					if (_0024self__00244617.photonView.isMine && ChatScript.isCar && !_0024self__00244617.aimanager.isAI)
					{
						isboosting = true;
						_0024self__00244617.maincar.mass = _0024self__00244617.maincar.mass - 80f;
						_0024boostcounter_00244612 = 5f + 5f * (float)(_0024i_00244616 / 20);
						goto case 2;
					}
					goto IL_0189;
				case 2:
					if (!(_0024boostcounter_00244612 <= 0f) && isboosting)
					{
						_0024boostcounter_00244612 -= Time.deltaTime;
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024self__00244617.maincar.mass = _0024self__00244617.maincar.mass + 80f;
					isboosting = false;
					((PhotonView)_0024self__00244617.gameObject.GetComponent(typeof(PhotonView))).RPC("stopBoost", PhotonTargets.All);
					goto IL_0189;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0189:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal int _0024i_00244618;

		internal FireGun _0024self__00244619;

		public _0024startBoost_00244610(int i, FireGun self_)
		{
			_0024i_00244618 = i;
			_0024self__00244619 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024i_00244618, _0024self__00244619);
		}
	}

	[Serializable]
	internal sealed class _0024tempInvinc_00244620 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal float _0024counter_00244621;

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					isInvincible = true;
					_0024counter_00244621 = 5f;
					goto case 2;
				case 2:
					if (_0024counter_00244621 > 0f)
					{
						_0024counter_00244621 -= Time.deltaTime;
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					isInvincible = false;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024();
		}
	}

	[Serializable]
	internal sealed class _0024goInvincible_00244622 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal int _0024level_00244623;

			internal int _0024vtype_00244624;

			internal FireGun _0024self__00244625;

			public _0024(int level, int vtype, FireGun self_)
			{
				_0024level_00244623 = level;
				_0024vtype_00244624 = vtype;
				_0024self__00244625 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__00244625.photonView.isMine && ChatScript.isCar)
					{
						isInvincible = true;
					}
					_0024self__00244625.regMeshes[_0024vtype_00244624].enabled = false;
					_0024self__00244625.invincMeshes[_0024vtype_00244624].enabled = true;
					result = (Yield(2, new WaitForSeconds(9f + (float)_0024level_00244623 / 2.5f)) ? 1 : 0);
					break;
				case 2:
					_0024self__00244625.regMeshes[_0024vtype_00244624].enabled = true;
					_0024self__00244625.invincMeshes[_0024vtype_00244624].enabled = false;
					if (_0024self__00244625.photonView.isMine && ChatScript.isCar)
					{
						isInvincible = false;
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

		internal int _0024level_00244626;

		internal int _0024vtype_00244627;

		internal FireGun _0024self__00244628;

		public _0024goInvincible_00244622(int level, int vtype, FireGun self_)
		{
			_0024level_00244626 = level;
			_0024vtype_00244627 = vtype;
			_0024self__00244628 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024level_00244626, _0024vtype_00244627, _0024self__00244628);
		}
	}

	[Serializable]
	internal sealed class _0024startChargingLaser_00244629 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal LineRenderer _0024lcannonobj_00244630;

			internal Light _0024lightobj_00244631;

			internal GameObject _0024initaud_00244632;

			internal float _0024i_00244633;

			internal Vector3 _0024fwd_00244634;

			internal RaycastHit _0024hit_00244635;

			internal GameObject _0024blastaud_00244636;

			internal ReturnName _0024rname_00244637;

			internal string _0024user_00244638;

			internal int _0024level_00244639;

			internal string _0024team_00244640;

			internal float _0024dM_00244641;

			internal FireGun _0024self__00244642;

			public _0024(string user, int level, string team, float dM, FireGun self_)
			{
				_0024user_00244638 = user;
				_0024level_00244639 = level;
				_0024team_00244640 = team;
				_0024dM_00244641 = dM;
				_0024self__00244642 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00244642.charginglaser = true;
					if (_0024self__00244642.photonView.isMine)
					{
						isCharging = true;
					}
					_0024lcannonobj_00244630 = (LineRenderer)_0024self__00244642.lasercannonobj.GetComponent(typeof(LineRenderer));
					_0024lightobj_00244631 = (Light)_0024self__00244642.lasercannonobj.GetComponent(typeof(Light));
					_0024lcannonobj_00244630.enabled = true;
					_0024lightobj_00244631.enabled = true;
					_0024initaud_00244632 = (GameObject)UnityEngine.Object.Instantiate(_0024self__00244642.laserlargeaud[0], _0024self__00244642.lasercannonobj.transform.position, _0024self__00244642.lasercannonobj.transform.rotation);
					_0024initaud_00244632.SendMessage("sticksound", _0024self__00244642.lasercannonobj);
					_0024i_00244633 = 0f;
					goto IL_0227;
				case 2:
					_0024i_00244633 += 0.2f * Time.deltaTime * (1f / _0024dM_00244641);
					goto IL_0227;
				case 3:
					_0024i_00244633 -= 5f * Time.deltaTime;
					goto IL_085b;
				case 1:
					{
						result = 0;
						break;
					}
					IL_085b:
					if (_0024i_00244633 > 0f)
					{
						_0024lcannonobj_00244630.SetWidth(_0024i_00244633, _0024i_00244633);
						_0024lightobj_00244631.intensity = _0024i_00244633 * 4f;
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					_0024lcannonobj_00244630.SetColors(_0024self__00244642.lcorig[0], _0024self__00244642.lcorig[1]);
					_0024lightobj_00244631.color = _0024self__00244642.lcorig[0];
					_0024lcannonobj_00244630.enabled = false;
					_0024lightobj_00244631.enabled = false;
					YieldDefault(1);
					goto case 1;
					IL_0227:
					if (_0024i_00244633 < 0.4f)
					{
						if (_0024self__00244642.charginglaser)
						{
							_0024lcannonobj_00244630.SetWidth(_0024i_00244633, _0024i_00244633);
							_0024lightobj_00244631.intensity = _0024i_00244633 * 4f;
							chargeState = _0024i_00244633 / 0.4f * 5f;
							_0024fwd_00244634 = _0024lcannonobj_00244630.transform.TransformDirection(Vector3.forward);
							_0024hit_00244635 = default(RaycastHit);
							if (Physics.Raycast(_0024lcannonobj_00244630.transform.position, _0024fwd_00244634, out _0024hit_00244635, float.PositiveInfinity))
							{
								_0024lcannonobj_00244630.SetPosition(1, _0024lcannonobj_00244630.transform.InverseTransformPoint(_0024hit_00244635.point));
							}
							result = (YieldDefault(2) ? 1 : 0);
							break;
						}
						UnityEngine.Object.Destroy(_0024initaud_00244632);
						goto case 1;
					}
					_0024lightobj_00244631.intensity = 3f;
					_0024lcannonobj_00244630.SetWidth(2f, 2f);
					_0024lcannonobj_00244630.SetColors(_0024self__00244642.lc[0], _0024self__00244642.lc[1]);
					_0024lightobj_00244631.color = _0024self__00244642.lc[0];
					if (_0024self__00244642.photonView.isMine)
					{
						isCharging = false;
					}
					UnityEngine.Object.Destroy(_0024initaud_00244632);
					_0024blastaud_00244636 = (GameObject)UnityEngine.Object.Instantiate(_0024self__00244642.laserlargeaud[1], _0024self__00244642.lasercannonobj.transform.position, _0024self__00244642.lasercannonobj.transform.rotation);
					_0024blastaud_00244636.SendMessage("sticksound", _0024self__00244642.lasercannonobj);
					_0024fwd_00244634 = _0024lcannonobj_00244630.transform.TransformDirection(Vector3.forward);
					if (Physics.Raycast(_0024lcannonobj_00244630.transform.position, _0024fwd_00244634, out _0024hit_00244635, float.PositiveInfinity))
					{
						UnityEngine.Object.Instantiate(_0024self__00244642.megalaserhit, _0024hit_00244635.point, _0024self__00244642.transform.rotation);
						if (_0024self__00244642.photonView.isMine && ChatScript.isCar && !_0024self__00244642.aimanager.isAI)
						{
							if ((_0024hit_00244635.transform.gameObject.name == "CarPrefab(Clone)" || _0024hit_00244635.transform.gameObject.name == "MainBoxCol") && ((!((PhotonView)_0024hit_00244635.transform.root.gameObject.GetComponent(typeof(PhotonView))).isMine && ChatScript.isCar) || RuntimeServices.ToBool(UnityRuntimeServices.GetProperty(_0024hit_00244635.transform.gameObject.GetComponent("AIManager"), "enabled"))))
							{
								_0024rname_00244637 = (ReturnName)_0024hit_00244635.transform.gameObject.GetComponent("ReturnName");
								if (_0024rname_00244637.returnAI())
								{
									_0024hit_00244635.transform.gameObject.SendMessage("laserCannonHit", _0024user_00244638 + "|" + _0024level_00244639.ToString() + "|" + _0024team_00244640 + "|" + _0024dM_00244641, SendMessageOptions.DontRequireReceiver);
								}
								else
								{
									((PhotonView)_0024self__00244642.gameObject.GetComponent(typeof(PhotonView))).RPC("laserCannonHit", PhotonTargets.All, _0024rname_00244637.returnName(), _0024user_00244638 + "|" + _0024level_00244639.ToString() + "|" + _0024team_00244640 + "|" + _0024dM_00244641, _0024hit_00244635.transform.InverseTransformPoint(_0024hit_00244635.point));
								}
							}
							else
							{
								_0024hit_00244635.transform.gameObject.BroadcastMessage("laserCannonHit", _0024user_00244638 + "|" + _0024level_00244639.ToString() + "|" + _0024team_00244640 + "|" + _0024dM_00244641, SendMessageOptions.DontRequireReceiver);
							}
						}
						else if (_0024hit_00244635.transform.gameObject.name != "CarPrefab(Clone)" && _0024hit_00244635.transform.gameObject.name != "MainBoxCol")
						{
							_0024hit_00244635.transform.gameObject.SendMessage("laserCannonHit", _0024user_00244638 + "|" + _0024level_00244639.ToString() + "|" + _0024team_00244640 + "|" + _0024dM_00244641, SendMessageOptions.DontRequireReceiver);
						}
					}
					_0024self__00244642.charginglaser = false;
					if (_0024self__00244642.photonView.isMine && ChatScript.isCar && !_0024self__00244642.aimanager.isAI)
					{
						if (ChatScript.primaryweapon == "lasercannon")
						{
							_0024self__00244642.rocketcounter = ((!ChatScript.hasrapidfire) ? 1f : 0.5f) * 0.685f;
							rocketammoleft -= 1f;
						}
						if (ChatScript.secondaryweapon == "lasercannon")
						{
							_0024self__00244642.lasercounter = ((!ChatScript.hasrapidfire) ? 1f : 0.5f) * 0.685f;
							laserammoleft -= 1f;
						}
					}
					_0024self__00244642.StartCoroutine_Auto(_0024self__00244642.decreaseBlastAud(_0024blastaud_00244636));
					_0024i_00244633 = 2f;
					goto IL_085b;
				}
				return (byte)result != 0;
			}
		}

		internal string _0024user_00244643;

		internal int _0024level_00244644;

		internal string _0024team_00244645;

		internal float _0024dM_00244646;

		internal FireGun _0024self__00244647;

		public _0024startChargingLaser_00244629(string user, int level, string team, float dM, FireGun self_)
		{
			_0024user_00244643 = user;
			_0024level_00244644 = level;
			_0024team_00244645 = team;
			_0024dM_00244646 = dM;
			_0024self__00244647 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024user_00244643, _0024level_00244644, _0024team_00244645, _0024dM_00244646, _0024self__00244647);
		}
	}

	[Serializable]
	internal sealed class _0024decreaseBlastAud_00244648 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal GameObject _0024g_00244649;

			public _0024(GameObject g)
			{
				_0024g_00244649 = g;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					result = (Yield(2, new WaitForSeconds(1.8f)) ? 1 : 0);
					break;
				case 2:
					if ((bool)_0024g_00244649)
					{
						UnityEngine.Object.Destroy(_0024g_00244649);
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

		internal GameObject _0024g_00244650;

		public _0024decreaseBlastAud_00244648(GameObject g)
		{
			_0024g_00244650 = g;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024g_00244650);
		}
	}

	[Serializable]
	internal sealed class _0024stopfireminigun_00244651 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal FireGun _0024self__00244652;

			public _0024(FireGun self_)
			{
				_0024self__00244652 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00244652.firingminigun = false;
					goto case 2;
				case 2:
					if (!(_0024self__00244652.rotspeed <= 0f) && !_0024self__00244652.firingminigun)
					{
						_0024self__00244652.minigunrotator.Rotate(-Vector3.forward * _0024self__00244652.rotspeed * Time.deltaTime);
						_0024self__00244652.rotspeed -= 570f * Time.deltaTime;
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024self__00244652.rotspeed = 0f;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal FireGun _0024self__00244653;

		public _0024stopfireminigun_00244651(FireGun self_)
		{
			_0024self__00244653 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00244653);
		}
	}

	[Serializable]
	internal sealed class _0024fireminigun_00244654 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal int _0024idcount_00244655;

			internal GameObject _0024clone_00244656;

			internal GameObject _0024casing_00244657;

			internal GameObject _0024flash_00244658;

			internal LowPolyBulletExplode _0024comp_00244659;

			internal float _0024frate_00244660;

			internal string _0024user_00244661;

			internal int _0024id_00244662;

			internal int _0024level_00244663;

			internal string _0024team_00244664;

			internal float _0024dM_00244665;

			internal FireGun _0024self__00244666;

			public _0024(string user, int id, int level, string team, float dM, FireGun self_)
			{
				_0024user_00244661 = user;
				_0024id_00244662 = id;
				_0024level_00244663 = level;
				_0024team_00244664 = team;
				_0024dM_00244665 = dM;
				_0024self__00244666 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00244666.theid = _0024id_00244662;
					_0024self__00244666.firingminigun = true;
					_0024self__00244666.StartCoroutine_Auto(_0024self__00244666.startrotating(_0024id_00244662));
					_0024idcount_00244655 = _0024id_00244662;
					goto IL_034e;
				case 2:
					if (_0024frate_00244660 > 0f)
					{
						_0024frate_00244660 -= Time.deltaTime;
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					goto IL_034e;
				case 1:
					{
						result = 0;
						break;
					}
					IL_034e:
					if (_0024self__00244666.firingminigun && _0024self__00244666.theid == _0024id_00244662)
					{
						if (_0024self__00244666.photonView.isMine && ChatScript.isCar && !_0024self__00244666.aimanager.isAI)
						{
							if (ChatScript.primaryweapon == "minigun")
							{
								rocketammoleft -= 1f;
							}
							else
							{
								laserammoleft -= 1f;
							}
						}
						_0024clone_00244656 = (GameObject)UnityEngine.Object.Instantiate(_0024self__00244666.bullet, _0024self__00244666.minigunfirepoint.position, _0024self__00244666.minigunfirepoint.rotation);
						_0024casing_00244657 = (GameObject)UnityEngine.Object.Instantiate(_0024self__00244666.bulletcasing, _0024self__00244666.casingspawn.position, _0024self__00244666.casingspawn.rotation);
						_0024flash_00244658 = (GameObject)UnityEngine.Object.Instantiate(_0024self__00244666.minigunflash, _0024self__00244666.minigunfirepoint.position, _0024self__00244666.minigunfirepoint.rotation);
						_0024flash_00244658.transform.parent = _0024self__00244666.minigunfirepoint;
						_0024casing_00244657.rigidbody.AddRelativeForce(Vector3.right * UnityEngine.Random.Range(200f, 300f));
						_0024self__00244666.minigunfirepoint.audio.PlayOneShot(_0024self__00244666.minigunfirepoint.audio.clip);
						_0024clone_00244656.gameObject.SendMessage("setOwner", _0024user_00244661);
						_0024clone_00244656.gameObject.SendMessage("setlevel", _0024level_00244663);
						_0024clone_00244656.gameObject.SendMessage("setteam", _0024team_00244664);
						_0024self__00244666.projMan.AllocateNewId(_0024clone_00244656, _0024idcount_00244655);
						_0024clone_00244656.gameObject.SendMessage("setID", _0024idcount_00244655);
						_0024comp_00244659 = (LowPolyBulletExplode)_0024clone_00244656.gameObject.GetComponent(typeof(LowPolyBulletExplode));
						_0024comp_00244659.projMan = _0024self__00244666.projMan;
						_0024comp_00244659.dM = _0024dM_00244665;
						_0024comp_00244659.realFiredFromObject = _0024self__00244666.gameObject;
						_0024idcount_00244655++;
						_0024frate_00244660 = (1f - _0024self__00244666.rotspeed / 750f) / 10f + 0.065f * _0024dM_00244665;
						goto case 2;
					}
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal string _0024user_00244667;

		internal int _0024id_00244668;

		internal int _0024level_00244669;

		internal string _0024team_00244670;

		internal float _0024dM_00244671;

		internal FireGun _0024self__00244672;

		public _0024fireminigun_00244654(string user, int id, int level, string team, float dM, FireGun self_)
		{
			_0024user_00244667 = user;
			_0024id_00244668 = id;
			_0024level_00244669 = level;
			_0024team_00244670 = team;
			_0024dM_00244671 = dM;
			_0024self__00244672 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024user_00244667, _0024id_00244668, _0024level_00244669, _0024team_00244670, _0024dM_00244671, _0024self__00244672);
		}
	}

	[Serializable]
	internal sealed class _0024startrotating_00244673 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal int _0024id_00244674;

			internal FireGun _0024self__00244675;

			public _0024(int id, FireGun self_)
			{
				_0024id_00244674 = id;
				_0024self__00244675 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00244675.rotspeed = 0f;
					goto case 2;
				case 2:
					if (_0024self__00244675.firingminigun && _0024self__00244675.theid == _0024id_00244674)
					{
						if (!(_0024self__00244675.rotspeed >= 750f))
						{
							_0024self__00244675.rotspeed += 500f * Time.deltaTime;
						}
						else
						{
							_0024self__00244675.rotspeed = 750f;
						}
						_0024self__00244675.minigunrotator.Rotate(-Vector3.forward * _0024self__00244675.rotspeed * Time.deltaTime);
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

		internal int _0024id_00244676;

		internal FireGun _0024self__00244677;

		public _0024startrotating_00244673(int id, FireGun self_)
		{
			_0024id_00244676 = id;
			_0024self__00244677 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024id_00244676, _0024self__00244677);
		}
	}

	public Rigidbody rocket;

	public Rigidbody rocketsimp;

	public GameObject laser;

	public Rigidbody maincar;

	public GameObject lasergun;

	[NonSerialized]
	public static float rocketammoleft = 6f;

	[NonSerialized]
	public static float laserammoleft = 25f;

	[NonSerialized]
	public static bool rocketreload;

	[NonSerialized]
	public static bool laserreload;

	[NonSerialized]
	public static string guntype = "rocket";

	public AmmoDisplay script;

	private float rocketcounter;

	private float lasercounter;

	public Collider col1;

	public Collider col2;

	public Collider col3;

	public Collider[] wheelcols;

	public Collider maincarcol;

	public Collider guncol;

	public GameObject rocketaud;

	public GameObject laseraud;

	private bool mousestate;

	public string username;

	public AuthGameObject authobj;

	public HealthBar hbar;

	public ChatScript cscript;

	public ToggleGuns togguns;

	public PlayerCar_Script pscript;

	public SpawningScript spawnscript;

	public AmmoDisplay ammocount;

	public EndofRound endofround;

	public CTFFlagSender ctfflagsender;

	public MasterServerScript mserver;

	public CloakPickup cloakscript;

	public InGameScores igs;

	public PauseObject pobj;

	private bool controlen;

	public GunController gcsrc;

	public ConduitInputReciever cInput;

	public TutorialManager tMan;

	private bool ctf;

	[NonSerialized]
	public static bool isInvincible;

	public GameObject[] mines;

	[NonSerialized]
	public static bool respawngrapplestop;

	[NonSerialized]
	public static bool forceInvinc;

	public GameObject flamethrower;

	public GameObject[] missilespots;

	public GameObject[] missileprefab;

	public GameObject[] missileprefabsimp;

	public GameObject FlamePrefab;

	public Transform flameparent;

	public GameObject minigun;

	public GameObject bullet;

	public Transform minigunfirepoint;

	public GameObject bulletcasing;

	public Transform casingspawn;

	private int theid;

	private float rotspeed;

	public Transform minigunrotator;

	public GameObject minigunflash;

	private bool firingminigun;

	[NonSerialized]
	public static bool isfiringflame;

	[NonSerialized]
	public static bool respawnreload;

	public GameObject launcher;

	public GameObject grenadeprefab;

	public GameObject empgrenadeprefab;

	public GameObject launcheraud;

	public GameObject shotgunAudio;

	public GameObject shotgunbullet;

	public GameObject shotgunflash;

	public Transform shotgunfirepoint;

	public Transform launcherfirepoint;

	private int lastmode;

	public PlayerCar_Script playercar;

	private bool candropmine;

	private float minecounter;

	public LineRenderer laserpointer;

	public Color[] redcolor;

	public Color[] greencolor;

	public LayerMask missilelayermask;

	public GameObject shieldobject;

	public GameObject railbullet;

	public GameObject railgun;

	public GameObject railgunfirepoint;

	public GameObject lasercannonobj;

	public bool charginglaser;

	public Color[] lc;

	public Color[] lcorig;

	public GameObject megalaserhit;

	public GameObject[] laserlargeaud;

	public GameObject grappler;

	public Transform grapplefirepoint;

	[NonSerialized]
	public static bool grappling;

	[NonSerialized]
	public static bool stopgrapple;

	[NonSerialized]
	public static bool stopgrappleyield;

	[NonSerialized]
	public static bool stopfiring;

	public GameObject grappleitem;

	[NonSerialized]
	public static bool isboosting;

	public GameObject[] wheels;

	private float firecounter;

	private int aiAmmoCounter;

	public AIManager aimanager;

	public LayerMask somelayermask;

	public Renderer regCarMesh;

	public Renderer invincCarMesh;

	public Renderer regCarMeshGTR;

	public Renderer invincCarMeshGTR;

	private ProjectileReferenceManager projMan;

	[NonSerialized]
	public static bool oncePerRound;

	public Renderer[] regMeshes;

	public Renderer[] invincMeshes;

	[NonSerialized]
	public static float chargeState;

	[NonSerialized]
	public static bool isCharging;

	public FireGun()
	{
		rocketcounter = ((!ChatScript.hasrapidfire) ? 1f : 0.5f) * 0.685f;
		lasercounter = ((!ChatScript.hasrapidfire) ? 1f : 0.5f) * 0.34f;
		username = string.Empty;
		controlen = true;
		lastmode = 1;
		candropmine = true;
		minecounter = 2f;
		firecounter = 5f;
		aiAmmoCounter = 6;
	}

	public virtual void setctf(bool t)
	{
		ctf = t;
	}

	public virtual void setcontrol(bool t)
	{
		controlen = t;
	}

	public virtual void Awake()
	{
		projMan = (ProjectileReferenceManager)GameObject.Find("/ProjectileMan").GetComponent(typeof(ProjectileReferenceManager));
	}

	public virtual void Start()
	{
		if (photonView.isMine && !aimanager.isAI && !AuthGameObject.isAIserver)
		{
			username = AuthGameObject.username;
			rocketammoleft = 6f;
			laserammoleft = 25f;
			rocketreload = false;
			laserreload = false;
		}
		if (photonView.isMine && !aimanager.isAI)
		{
			grappling = false;
			stopgrapple = false;
			stopgrappleyield = false;
			isboosting = false;
			respawngrapplestop = false;
			isInvincible = false;
			forceInvinc = false;
			oncePerRound = false;
			chargeState = 0f;
			isCharging = false;
		}
		if (!photonView.isMine && ChatScript.isCar && !aimanager.isAI)
		{
			if (!aimanager.isAI)
			{
				enabled = false;
			}
		}
		else
		{
			username = ((!aimanager.isAI) ? AuthGameObject.username : aimanager.ainame);
		}
		if (photonView.isMine && ChatScript.isCar && !aimanager.isAI)
		{
			rocketammoleft = 6f;
			laserammoleft = 25f;
			rocketreload = false;
			laserreload = false;
			guntype = "rocket";
			isfiringflame = false;
			if (ChatScript.primaryweapon == "rocket")
			{
				rocketammoleft = 6f;
			}
			if (ChatScript.primaryweapon == "launcher")
			{
				rocketammoleft = 3f;
			}
			if (ChatScript.primaryweapon == "emplauncher")
			{
				rocketammoleft = 3f;
			}
			if (ChatScript.primaryweapon == "flamethrower")
			{
				rocketammoleft = 500f;
			}
			if (ChatScript.primaryweapon == "minigun")
			{
				rocketammoleft = 150f;
			}
			if (ChatScript.primaryweapon == "laser")
			{
				rocketammoleft = 25f;
			}
			if (ChatScript.primaryweapon == "missile")
			{
				rocketammoleft = 4f;
			}
			if (ChatScript.primaryweapon == "railgun")
			{
				rocketammoleft = 1f;
			}
			if (ChatScript.primaryweapon == "grappling")
			{
				rocketammoleft = 1f;
			}
			if (ChatScript.primaryweapon == "lasercannon")
			{
				rocketammoleft = 1f;
			}
			if (ChatScript.primaryweapon == "shotgun")
			{
				rocketammoleft = 12f;
			}
			if (ChatScript.secondaryweapon == "rocket")
			{
				laserammoleft = 6f;
			}
			if (ChatScript.secondaryweapon == "launcher")
			{
				laserammoleft = 3f;
			}
			if (ChatScript.secondaryweapon == "emplauncher")
			{
				laserammoleft = 3f;
			}
			if (ChatScript.secondaryweapon == "flamethrower")
			{
				laserammoleft = 500f;
			}
			if (ChatScript.secondaryweapon == "minigun")
			{
				laserammoleft = 150f;
			}
			if (ChatScript.secondaryweapon == "laser")
			{
				laserammoleft = 25f;
			}
			if (ChatScript.secondaryweapon == "missile")
			{
				laserammoleft = 4f;
			}
			if (ChatScript.secondaryweapon == "railgun")
			{
				laserammoleft = 1f;
			}
			if (ChatScript.secondaryweapon == "grappling")
			{
				laserammoleft = 1f;
			}
			if (ChatScript.secondaryweapon == "lasercannon")
			{
				laserammoleft = 1f;
			}
			if (ChatScript.secondaryweapon == "shotgun")
			{
				laserammoleft = 12f;
			}
		}
	}

	public virtual IEnumerator yieldStop()
	{
		return new _0024yieldStop_00244609().GetEnumerator();
	}

	[RPC]
	public virtual IEnumerator startBoost(int i)
	{
		return new _0024startBoost_00244610(i, this).GetEnumerator();
	}

	[RPC]
	public virtual void stopBoost()
	{
		int i = 0;
		GameObject[] array = wheels;
		for (int length = array.Length; i < length; i++)
		{
			array[i].SendMessage("stopFlame");
		}
	}

	public virtual void Update()
	{
		if (photonView.isMine && ChatScript.isCar && !aimanager.isAI)
		{
			if (stopgrappleyield)
			{
				stopgrappleyield = false;
				grappling = false;
				if (ChatScript.primaryweapon == "grappling")
				{
					rocketammoleft = 0f;
				}
				if (ChatScript.secondaryweapon == "grappling")
				{
					laserammoleft = 0f;
				}
				StartCoroutine_Auto(yieldStop());
			}
			if (forceInvinc)
			{
				forceInvinc = false;
				StartCoroutine_Auto(tempInvinc());
			}
		}
		if (photonView.isMine && ChatScript.isCar && !aimanager.isAI && respawnreload)
		{
			respawnreload = false;
			rocketreload = false;
			laserreload = false;
			if (ChatScript.primaryweapon == "rocket")
			{
				rocketammoleft = 6f;
			}
			if (ChatScript.primaryweapon == "launcher")
			{
				rocketammoleft = 3f;
			}
			if (ChatScript.primaryweapon == "emplauncher")
			{
				rocketammoleft = 3f;
			}
			if (ChatScript.primaryweapon == "flamethrower")
			{
				rocketammoleft = 500f;
			}
			if (ChatScript.primaryweapon == "minigun")
			{
				rocketammoleft = 150f;
			}
			if (ChatScript.primaryweapon == "laser")
			{
				rocketammoleft = 25f;
			}
			if (ChatScript.primaryweapon == "missile")
			{
				rocketammoleft = 4f;
			}
			if (ChatScript.primaryweapon == "railgun")
			{
				rocketammoleft = 1f;
			}
			if (ChatScript.primaryweapon == "grappling")
			{
				rocketammoleft = 1f;
				grappling = false;
			}
			if (ChatScript.primaryweapon == "lasercannon")
			{
				rocketammoleft = 1f;
			}
			if (ChatScript.primaryweapon == "shotgun")
			{
				rocketammoleft = 12f;
			}
			if (ChatScript.secondaryweapon == "rocket")
			{
				laserammoleft = 6f;
			}
			if (ChatScript.secondaryweapon == "launcher")
			{
				laserammoleft = 3f;
			}
			if (ChatScript.secondaryweapon == "emplauncher")
			{
				laserammoleft = 3f;
			}
			if (ChatScript.secondaryweapon == "flamethrower")
			{
				laserammoleft = 500f;
			}
			if (ChatScript.secondaryweapon == "minigun")
			{
				laserammoleft = 150f;
			}
			if (ChatScript.secondaryweapon == "laser")
			{
				laserammoleft = 25f;
			}
			if (ChatScript.secondaryweapon == "missile")
			{
				laserammoleft = 4f;
			}
			if (ChatScript.secondaryweapon == "railgun")
			{
				laserammoleft = 1f;
			}
			if (ChatScript.secondaryweapon == "grappling")
			{
				laserammoleft = 1f;
				grappling = false;
			}
			if (ChatScript.secondaryweapon == "lasercannon")
			{
				laserammoleft = 1f;
			}
			if (ChatScript.secondaryweapon == "shotgun")
			{
				laserammoleft = 12f;
			}
		}
		if (photonView.isMine && ChatScript.isCar && !aimanager.isAI && ctf)
		{
			laserpointer.enabled = false;
		}
		if ((!controlen || ctf || HealthBar.isdead || PlayerCar_Script.empdisable || EndofRound.alphastat > 0f || stopfiring || !ChatScript.isCar) && photonView.isMine && !aimanager.isAI)
		{
			if (stopfiring)
			{
				stopfiring = false;
			}
			if (ChatScript.primaryweapon == "minigun" && firingminigun)
			{
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("stopfireminigun", PhotonTargets.All);
			}
			if (ChatScript.secondaryweapon == "minigun" && firingminigun)
			{
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("stopfireminigun", PhotonTargets.All);
			}
			if (ChatScript.primaryweapon == "lasercannon" && charginglaser)
			{
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("stopfirelasercannon", PhotonTargets.All);
			}
			if (ChatScript.secondaryweapon == "lasercannon" && charginglaser)
			{
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("stopfirelasercannon", PhotonTargets.All);
			}
			if (grappling)
			{
				grappling = false;
				stopgrapple = true;
			}
		}
		if ((!controlen || HealthBar.isdead || PlayerCar_Script.empdisable || EndofRound.alphastat > 0f || stopfiring || !ChatScript.isCar) && photonView.isMine && !aimanager.isAI && isboosting)
		{
			isboosting = false;
		}
		if (photonView.isMine && ChatScript.isCar && !aimanager.isAI && controlen && GunController.startvar && !HealthBar.isdead && !PlayerCar_Script.empdisable)
		{
			if ((Input.GetKeyDown("m") || RuntimeServices.ToBool((!(PauseObject.alt_item != string.Empty)) ? ((object)false) : RuntimeServices.Invoke(typeof(Input), "GetKeyDown", new object[1] { Enum.Parse(typeof(KeyCode), PauseObject.alt_item) })) || RuntimeServices.ToBool(ConduitInputReciever.ht["uIt"])) && PlayerCar_Script.controlenabled && candropmine && !ChatScript.hasshield && !ChatScript.hasboost && !ChatScript.hasinvinc && AuthGameObject.inventory[2].Split("#"[0])[4] != "false" && AmmoDisplay.minecount > 0)
			{
				if (RuntimeServices.ToBool(ConduitInputReciever.ht["uIt"]))
				{
					ConduitInputReciever.ht["uIt"] = false;
				}
				candropmine = false;
				AmmoDisplay.minecount--;
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("dropMine", PhotonTargets.All, username, UnityBuiltins.parseInt(ChatScript.levels[3]), maincar.transform.position, maincar.transform.rotation, UnityBuiltins.parseInt(AuthGameObject.inventory[2].Split("#"[0])[4]) - 8, SpawningScript.team2, PhotonNetwork.AllocateViewID());
			}
			if ((Input.GetKeyDown("m") || RuntimeServices.ToBool((!(PauseObject.alt_item != string.Empty)) ? ((object)false) : RuntimeServices.Invoke(typeof(Input), "GetKeyDown", new object[1] { Enum.Parse(typeof(KeyCode), PauseObject.alt_item) })) || RuntimeServices.ToBool(ConduitInputReciever.ht["uIt"])) && PlayerCar_Script.controlenabled && !shieldobject.active && ChatScript.hasshield && AmmoDisplay.minecount > 0 && !oncePerRound)
			{
				oncePerRound = true;
				if (RuntimeServices.ToBool(ConduitInputReciever.ht["uIt"]))
				{
					ConduitInputReciever.ht["uIt"] = false;
				}
				AmmoDisplay.minecount -= 3;
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("enableShield", PhotonTargets.All, username, UnityBuiltins.parseInt(ChatScript.levels[3]));
			}
			if ((Input.GetKeyDown("m") || RuntimeServices.ToBool((!(PauseObject.alt_item != string.Empty)) ? ((object)false) : RuntimeServices.Invoke(typeof(Input), "GetKeyDown", new object[1] { Enum.Parse(typeof(KeyCode), PauseObject.alt_item) })) || RuntimeServices.ToBool(ConduitInputReciever.ht["uIt"])) && PlayerCar_Script.controlenabled && !isboosting && ChatScript.hasboost && AmmoDisplay.minecount > 0)
			{
				if (RuntimeServices.ToBool(ConduitInputReciever.ht["uIt"]))
				{
					ConduitInputReciever.ht["uIt"] = false;
				}
				isboosting = true;
				AmmoDisplay.minecount -= 2;
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("startBoost", PhotonTargets.All, UnityBuiltins.parseInt(ChatScript.levels[3]));
			}
			if ((Input.GetKeyDown("m") || RuntimeServices.ToBool((!(PauseObject.alt_item != string.Empty)) ? ((object)false) : RuntimeServices.Invoke(typeof(Input), "GetKeyDown", new object[1] { Enum.Parse(typeof(KeyCode), PauseObject.alt_item) })) || RuntimeServices.ToBool(ConduitInputReciever.ht["uIt"])) && PlayerCar_Script.controlenabled && ChatScript.hasinvinc && AmmoDisplay.minecount > 0 && !oncePerRound)
			{
				oncePerRound = true;
				if (RuntimeServices.ToBool(ConduitInputReciever.ht["uIt"]))
				{
					ConduitInputReciever.ht["uIt"] = false;
				}
				AmmoDisplay.minecount -= 4;
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("goInvincible", PhotonTargets.All, UnityBuiltins.parseInt(ChatScript.levels[3]), ChatScript.vehicleType);
			}
			if (!candropmine)
			{
				if (!(minecounter <= 0f))
				{
					minecounter -= Time.deltaTime;
				}
				else
				{
					minecounter = 2f;
					candropmine = true;
				}
			}
		}
		if (aimanager.isAI && !aimanager.isDead && photonView.isMine && !aimanager.stopFiring && !HealthBar.isdead && EndofRound.alphastat == 0f && (bool)aimanager.target && aimanager.target != transform.root.transform)
		{
			if (!(firecounter > 0f))
			{
				float sqrMagnitude = (aimanager.target.position - transform.position).sqrMagnitude;
				firecounter = Mathf.Max(1f, Mathf.Min(2f, sqrMagnitude / 90000f)) * ((aimanager.firetype != 0) ? 0.34f : 0.685f);
				firecounter *= 3.5f * (1f - (float)aimanager.aiDiff / 10f);
				if (!(firecounter >= ((aimanager.firetype != 0) ? 0.34f : 0.685f)))
				{
					firecounter = ((aimanager.firetype != 0) ? 0.34f : 0.685f);
				}
				aiAmmoCounter--;
				if (aiAmmoCounter <= 0)
				{
					if (aimanager.firetype == 0)
					{
						aiAmmoCounter = 6;
						firecounter = 1.8f;
					}
					if (aimanager.firetype == 1)
					{
						aiAmmoCounter = 20;
						firecounter = 2.4f;
					}
				}
				else if (aimanager.target.gameObject.name != "HumanPrefab(Clone)" && CloakPickup.iscloakedstat)
				{
					firecounter *= 3.5f;
				}
				if ((bool)aimanager.target && !(sqrMagnitude >= 640000f * ((!CloakPickup.iscloakedstat) ? 1f : 0.5f)))
				{
					if (aimanager.firetype == 0)
					{
						((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("firerocket", PhotonTargets.All, username, transform.position, transform.rotation, maincar.velocity, aimanager.aiDiff * 2, UnityEngine.Random.Range(-999999999, 999999999), aimanager.aiteam, 1f);
					}
					else
					{
						((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("firelaser", PhotonTargets.All, username, transform.position, transform.rotation, aimanager.aiDiff * 2, UnityEngine.Random.Range(-999999999, 999999999), aimanager.aiteam, 1f);
					}
				}
			}
			else
			{
				firecounter -= Time.deltaTime;
			}
		}
		if (photonView.isMine && ChatScript.isCar && !aimanager.isAI && controlen && GunController.startvar && !ctf && !HealthBar.isdead && !PlayerCar_Script.empdisable && (!AuthGameObject.showTutorial || RuntimeServices.ToBool(TutorialManager.curCArr[2])))
		{
			if (ToggleGuns.curmode == 1 && ChatScript.primaryweapon == "missile" && rocketammoleft != 4f)
			{
				missilespots[(int)(4f - (rocketammoleft + 1f))].active = false;
			}
			if (ToggleGuns.curmode == 2 && ChatScript.secondaryweapon == "missile" && laserammoleft != 4f)
			{
				missilespots[(int)(4f - (laserammoleft + 1f))].active = false;
			}
			if (ToggleGuns.curmode == 1)
			{
				int num = -3;
				Vector3 localPosition = transform.localPosition;
				float num2 = (localPosition.z = num);
				Vector3 vector = (transform.localPosition = localPosition);
				guntype = "rocket";
			}
			else
			{
				int num3 = -3;
				Vector3 localPosition2 = transform.localPosition;
				float num4 = (localPosition2.z = num3);
				Vector3 vector3 = (transform.localPosition = localPosition2);
				guntype = "laser";
			}
			if (ToggleGuns.curmode != lastmode)
			{
				lastmode = ToggleGuns.curmode;
				if (charginglaser)
				{
					((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("stopfirelasercannon", PhotonTargets.All);
				}
			}
			if (AmmoDisplay.rocketdonereloading)
			{
				if (ChatScript.primaryweapon == "rocket")
				{
					rocketammoleft = 6f;
				}
				if (ChatScript.primaryweapon == "launcher")
				{
					rocketammoleft = 3f;
				}
				if (ChatScript.primaryweapon == "emplauncher")
				{
					rocketammoleft = 3f;
				}
				if (ChatScript.primaryweapon == "flamethrower")
				{
					rocketammoleft = 500f;
				}
				if (ChatScript.primaryweapon == "minigun")
				{
					rocketammoleft = 150f;
				}
				if (ChatScript.primaryweapon == "laser")
				{
					rocketammoleft = 25f;
				}
				if (ChatScript.primaryweapon == "railgun")
				{
					rocketammoleft = 1f;
				}
				if (ChatScript.primaryweapon == "grappling")
				{
					rocketammoleft = 1f;
					grappling = false;
				}
				if (ChatScript.primaryweapon == "lasercannon")
				{
					rocketammoleft = 1f;
				}
				if (ChatScript.primaryweapon == "shotgun")
				{
					rocketammoleft = 12f;
				}
				if (ChatScript.primaryweapon == "missile")
				{
					rocketammoleft = 4f;
					missilespots[0].active = true;
					missilespots[1].active = true;
					missilespots[2].active = true;
					missilespots[3].active = true;
				}
				rocketreload = false;
			}
			if (!(rocketammoleft > 0f))
			{
				rocketreload = true;
			}
			if (!(rocketcounter <= 0f))
			{
				rocketcounter -= Time.deltaTime;
			}
			if ((Input.GetKeyDown("r") || RuntimeServices.ToBool((!(PauseObject.alt_reload != string.Empty)) ? ((object)false) : RuntimeServices.Invoke(typeof(Input), "GetKeyDown", new object[1] { Enum.Parse(typeof(KeyCode), PauseObject.alt_reload) }))) && !grappling)
			{
				if (guntype == "rocket")
				{
					rocketammoleft = 0f;
				}
				else
				{
					laserammoleft = 0f;
				}
			}
			if (AmmoDisplay.laserdonereloading)
			{
				if (ChatScript.secondaryweapon == "rocket")
				{
					laserammoleft = 6f;
				}
				if (ChatScript.secondaryweapon == "launcher")
				{
					laserammoleft = 3f;
				}
				if (ChatScript.secondaryweapon == "emplauncher")
				{
					laserammoleft = 3f;
				}
				if (ChatScript.secondaryweapon == "flamethrower")
				{
					laserammoleft = 500f;
				}
				if (ChatScript.secondaryweapon == "minigun")
				{
					laserammoleft = 150f;
				}
				if (ChatScript.secondaryweapon == "laser")
				{
					laserammoleft = 25f;
				}
				if (ChatScript.secondaryweapon == "railgun")
				{
					laserammoleft = 1f;
				}
				if (ChatScript.secondaryweapon == "grappling")
				{
					laserammoleft = 1f;
					grappling = false;
				}
				if (ChatScript.secondaryweapon == "lasercannon")
				{
					laserammoleft = 1f;
				}
				if (ChatScript.secondaryweapon == "shotgun")
				{
					laserammoleft = 12f;
				}
				if (ChatScript.secondaryweapon == "missile")
				{
					laserammoleft = 4f;
					missilespots[0].active = true;
					missilespots[1].active = true;
					missilespots[2].active = true;
					missilespots[3].active = true;
				}
				laserreload = false;
			}
			if (!(laserammoleft > 0f))
			{
				laserreload = true;
			}
			if (!(lasercounter <= 0f))
			{
				lasercounter -= Time.deltaTime;
			}
			if ((Input.GetButtonDown("Fire1") || RuntimeServices.ToBool(ConduitInputReciever.ht["tPadState"])) && guntype == "rocket" && !(rocketcounter > 0f) && !Screen.showCursor && ChatScript.primaryweapon == "rocket" && !(rocketammoleft < 1f))
			{
				if (RuntimeServices.ToBool(ConduitInputReciever.ht["tPadState"]))
				{
					ConduitInputReciever.ht["tPadState"] = false;
				}
				rocketcounter = ((!ChatScript.hasrapidfire) ? 1f : 0.5f) * 0.685f;
				rocketammoleft -= 1f;
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("firerocket", PhotonTargets.All, username, transform.position, transform.rotation, maincar.velocity, UnityBuiltins.parseInt(ChatScript.levels[0]), UnityEngine.Random.Range(-999999999, 999999999), SpawningScript.team2, (!ChatScript.hasrapidfire) ? 1f : 0.5f);
			}
			if ((Input.GetButtonDown("Fire1") || RuntimeServices.ToBool(ConduitInputReciever.ht["tPadState"])) && guntype == "rocket" && !(rocketcounter > 0f) && !Screen.showCursor && ChatScript.primaryweapon == "shotgun" && !(rocketammoleft < 1f))
			{
				if (RuntimeServices.ToBool(ConduitInputReciever.ht["tPadState"]))
				{
					ConduitInputReciever.ht["tPadState"] = false;
				}
				rocketcounter = ((!ChatScript.hasrapidfire) ? 1f : 0.5f) * 2f;
				rocketammoleft -= 1f;
				int num5 = UnityEngine.Random.Range(-999999999, 999999999);
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("fireShotgun", PhotonTargets.All, username, transform.position, transform.rotation, UnityBuiltins.parseInt(ChatScript.levels[0]), SpawningScript.team2, num5, (!ChatScript.hasrapidfire) ? 1f : 0.5f);
			}
			if ((Input.GetButtonDown("Fire1") || RuntimeServices.ToBool(ConduitInputReciever.ht["tPadState"])) && guntype == "rocket" && !(rocketcounter > 0f) && !Screen.showCursor && ChatScript.primaryweapon == "railgun" && !(rocketammoleft < 1f))
			{
				if (RuntimeServices.ToBool(ConduitInputReciever.ht["tPadState"]))
				{
					ConduitInputReciever.ht["tPadState"] = false;
				}
				rocketcounter = ((!ChatScript.hasrapidfire) ? 1f : 0.5f) * 0.685f;
				rocketammoleft -= 1f;
				int num5 = UnityEngine.Random.Range(-999999999, 999999999);
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("fireRailgun", PhotonTargets.All, username, transform.position, transform.rotation, UnityBuiltins.parseInt(ChatScript.levels[0]), SpawningScript.team2, num5, (!ChatScript.hasrapidfire) ? 1f : 0.5f);
			}
			if ((Input.GetButtonDown("Fire1") || RuntimeServices.ToBool(ConduitInputReciever.ht["tPadState"])) && guntype == "rocket" && !(rocketcounter > 0f) && !Screen.showCursor && ChatScript.primaryweapon == "lasercannon" && !(rocketammoleft < 1f))
			{
				if (RuntimeServices.ToBool(ConduitInputReciever.ht["tPadState"]))
				{
					ConduitInputReciever.ht["tPadState"] = false;
				}
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("startChargingLaser", PhotonTargets.All, username, UnityBuiltins.parseInt(ChatScript.levels[0]), SpawningScript.team2, (!ChatScript.hasrapidfire) ? 1f : 0.5f);
			}
			if ((Input.GetButtonDown("Fire1") || RuntimeServices.ToBool(ConduitInputReciever.ht["tPadState"])) && guntype == "rocket" && !(rocketcounter > 0f) && !Screen.showCursor && ChatScript.primaryweapon == "missile" && !(rocketammoleft < 1f))
			{
				if (RuntimeServices.ToBool(ConduitInputReciever.ht["tPadState"]))
				{
					ConduitInputReciever.ht["tPadState"] = false;
				}
				rocketcounter = ((!ChatScript.hasrapidfire) ? 1f : 0.5f) * 0.8f;
				PhotonViewID photonViewID = PhotonNetwork.AllocateViewID();
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("firemissile", PhotonTargets.All, username, missilespots[(int)(4f - rocketammoleft)].transform.position, transform.rotation, UnityBuiltins.parseInt(ChatScript.levels[0]), photonViewID, SpawningScript.team2, (!ChatScript.hasrapidfire) ? 1f : 0.5f);
				rocketammoleft -= 1f;
			}
			RaycastHit hitInfo;
			if (guntype == "rocket" && ChatScript.primaryweapon == "missile")
			{
				laserpointer.enabled = true;
				Vector3 direction = laserpointer.transform.TransformDirection(Vector3.forward);
				hitInfo = default(RaycastHit);
				if (Physics.Raycast(laserpointer.transform.position, direction, out hitInfo, float.PositiveInfinity))
				{
					laserpointer.SetPosition(1, laserpointer.transform.InverseTransformPoint(hitInfo.point));
					if ((bool)(PhotonView)hitInfo.transform.gameObject.GetComponent(typeof(PhotonView)) && ((PhotonView)hitInfo.transform.gameObject.GetComponent(typeof(PhotonView))).isMine && ChatScript.isCar)
					{
						if (hitInfo.transform.gameObject.name == "CarPrefab(Clone)" || hitInfo.transform.gameObject.name == "MainBoxCol" || hitInfo.transform.gameObject.name == "HumanPrefab(Clone)")
						{
							ReturnName returnName = (ReturnName)hitInfo.transform.gameObject.GetComponent("ReturnName");
							if (returnName.returnAI())
							{
								laserpointer.SetColors(redcolor[0], redcolor[1]);
							}
							else
							{
								laserpointer.SetColors(greencolor[0], greencolor[1]);
								if (Physics.Raycast(laserpointer.transform.position, direction, out hitInfo, float.PositiveInfinity, somelayermask))
								{
									laserpointer.SetPosition(1, laserpointer.transform.InverseTransformPoint(hitInfo.point));
								}
							}
						}
						else
						{
							laserpointer.SetColors(greencolor[0], greencolor[1]);
							if (Physics.Raycast(laserpointer.transform.position, direction, out hitInfo, float.PositiveInfinity, somelayermask))
							{
								laserpointer.SetPosition(1, laserpointer.transform.InverseTransformPoint(hitInfo.point));
							}
						}
					}
					else if (hitInfo.transform.gameObject.name == "MainBoxCol" || hitInfo.transform.gameObject.name == "CarPrefab(Clone)" || hitInfo.transform.gameObject.name == "BotBlue(Clone)" || hitInfo.transform.gameObject.name == "BotRed(Clone)" || hitInfo.transform.gameObject.name == "BotBlueAttack(Clone)" || hitInfo.transform.gameObject.name == "BotRedAttack(Clone)" || hitInfo.transform.gameObject.name == "HumanPrefab(Clone)")
					{
						if (hitInfo.transform.gameObject.name == "MainBoxCol")
						{
							CloakPickup cloakPickup = (CloakPickup)hitInfo.transform.gameObject.GetComponent("CloakPickup");
							if (!cloakPickup.returnCloakState() && !(hitInfo.distance >= 650f))
							{
								laserpointer.SetColors(redcolor[0], redcolor[1]);
							}
							else
							{
								laserpointer.SetColors(greencolor[0], greencolor[1]);
							}
						}
						else if (!(hitInfo.distance >= 650f))
						{
							laserpointer.SetColors(redcolor[0], redcolor[1]);
						}
					}
					else if (hitInfo.transform.gameObject.name == "CarPrefab(Clone)")
					{
						PlayerCar_Script playerCar_Script = (PlayerCar_Script)hitInfo.transform.gameObject.GetComponent("PlayerCar_Script");
						if (!playerCar_Script.returnCloakState() && !(hitInfo.distance >= 650f))
						{
							laserpointer.SetColors(redcolor[0], redcolor[1]);
						}
						else
						{
							laserpointer.SetColors(greencolor[0], greencolor[1]);
						}
					}
					else
					{
						laserpointer.SetColors(greencolor[0], greencolor[1]);
					}
				}
			}
			else if (guntype != "rocket" && ChatScript.primaryweapon == "missile" && laserpointer.enabled)
			{
				laserpointer.enabled = false;
			}
			if ((Input.GetButtonUp("Fire1") || RuntimeServices.ToBool(ConduitInputReciever.ht["tPadState"])) && guntype == "rocket" && ChatScript.primaryweapon == "launcher" && !(rocketcounter > 0f) && !(rocketammoleft < 1f) && !Screen.showCursor)
			{
				if (RuntimeServices.ToBool(ConduitInputReciever.ht["tPadState"]))
				{
					ConduitInputReciever.ht["tPadState"] = false;
				}
				rocketcounter = ((!ChatScript.hasrapidfire) ? 1f : 0.5f) * 0.8f;
				rocketammoleft -= 1f;
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("firelauncher", PhotonTargets.All, username, launcherfirepoint.position, launcherfirepoint.rotation, maincar.velocity, maincar.angularVelocity, UnityBuiltins.parseInt(ChatScript.levels[0]), UnityEngine.Random.Range(-999999999, 999999999), SpawningScript.team2, (!ChatScript.hasrapidfire) ? 1f : 0.5f, Mathf.RoundToInt(chargeState));
				chargeState = 0f;
				isCharging = false;
			}
			if ((Input.GetButtonUp("Fire1") || RuntimeServices.ToBool(ConduitInputReciever.ht["tPadState"])) && guntype == "rocket" && ChatScript.primaryweapon == "emplauncher" && !(rocketcounter > 0f) && !(rocketammoleft < 1f) && !Screen.showCursor)
			{
				if (RuntimeServices.ToBool(ConduitInputReciever.ht["tPadState"]))
				{
					ConduitInputReciever.ht["tPadState"] = false;
				}
				rocketcounter = ((!ChatScript.hasrapidfire) ? 1f : 0.5f) * 0.8f;
				rocketammoleft -= 1f;
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("fireemplauncher", PhotonTargets.All, username, launcherfirepoint.position, launcherfirepoint.rotation, maincar.velocity, maincar.angularVelocity, UnityBuiltins.parseInt(ChatScript.levels[0]), UnityEngine.Random.Range(-999999999, 999999999), SpawningScript.team2, (!ChatScript.hasrapidfire) ? 1f : 0.5f, Mathf.RoundToInt(chargeState));
				chargeState = 0f;
				isCharging = false;
			}
			if (Input.GetButton("Fire1") && guntype == "rocket" && (ChatScript.primaryweapon == "emplauncher" || ChatScript.primaryweapon == "launcher") && !(rocketammoleft < 1f) && !Screen.showCursor)
			{
				if (!isCharging)
				{
					isCharging = true;
				}
				chargeState += Time.deltaTime;
			}
			if (guntype == "rocket" && ChatScript.primaryweapon == "grappling" && rocketammoleft == 1f && !grappling)
			{
				grappleitem.active = true;
			}
			if (guntype == "laser" && ChatScript.primaryweapon == "grappling")
			{
				grappleitem.active = false;
			}
			if (ChatScript.primaryweapon != "grappling" && ChatScript.secondaryweapon != "grappling")
			{
				grappleitem.active = false;
			}
			if (rocketammoleft != 1f && ChatScript.primaryweapon == "grappling")
			{
				grappleitem.active = false;
			}
			if (guntype == "rocket" && ChatScript.primaryweapon == "grappling" && grappling)
			{
				grappleitem.active = false;
			}
			if ((Input.GetButtonDown("Fire1") || RuntimeServices.ToBool(ConduitInputReciever.ht["tPadState"])) && guntype == "rocket" && ChatScript.primaryweapon == "grappling" && !(rocketcounter > 0f) && !(rocketammoleft < 1f) && !Screen.showCursor)
			{
				if (RuntimeServices.ToBool(ConduitInputReciever.ht["tPadState"]))
				{
					ConduitInputReciever.ht["tPadState"] = false;
				}
				if (!grappling)
				{
					grappling = true;
					PhotonViewID photonViewID = PhotonNetwork.AllocateViewID();
					((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("fireGrappler", PhotonTargets.All, username, launcherfirepoint.position, launcherfirepoint.rotation, maincar.velocity, maincar.angularVelocity, photonViewID, UnityBuiltins.parseInt(ChatScript.levels[0]), SpawningScript.team2, (!ChatScript.hasrapidfire) ? 1f : 0.5f);
				}
				else
				{
					grappling = false;
					stopgrapple = true;
					rocketcounter = ((!ChatScript.hasrapidfire) ? 1f : 0.5f) * 0.8f;
					rocketammoleft -= 1f;
				}
			}
			if (ChatScript.primaryweapon == "laser" && guntype == "rocket" && (Input.GetButton("Fire1") || RuntimeServices.ToBool(ConduitInputReciever.ht["tPadState"])) && !Screen.showCursor && !(rocketcounter > 0f) && !(rocketammoleft < 1f))
			{
				rocketcounter = ((!ChatScript.hasrapidfire) ? 1f : 0.5f) * 0.34f;
				rocketammoleft -= 1f;
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("firelaser", PhotonTargets.All, username, transform.position, transform.rotation, UnityBuiltins.parseInt(ChatScript.levels[0]), UnityEngine.Random.Range(-999999999, 999999999), SpawningScript.team2, (!ChatScript.hasrapidfire) ? 1f : 0.5f);
			}
			if (ChatScript.primaryweapon == "flamethrower" && guntype == "rocket" && !Screen.showCursor && (Input.GetButtonDown("Fire1") || RuntimeServices.ToBool(ConduitInputReciever.ht["tPadState"])) && !(rocketcounter > 0f) && !(rocketammoleft < 1f))
			{
				if (RuntimeServices.ToBool(ConduitInputReciever.ht["tPadState"]))
				{
					ConduitInputReciever.ht["tPadState"] = false;
				}
				PhotonViewID photonViewID = PhotonNetwork.AllocateViewID();
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("fireflamethrower", PhotonTargets.All, username, photonViewID, UnityBuiltins.parseInt(ChatScript.levels[0]), SpawningScript.team2, (!ChatScript.hasrapidfire) ? 1f : 0.5f);
			}
			if (ChatScript.primaryweapon == "flamethrower" && guntype == "rocket" && (Input.GetButton("Fire1") || RuntimeServices.ToBool(ConduitInputReciever.ht["tPadState"])) && !(rocketammoleft <= 0f) && !Screen.showCursor && isfiringflame)
			{
				rocketammoleft -= 1f * Time.deltaTime * 80f;
			}
			if (ChatScript.primaryweapon == "minigun" && guntype == "rocket" && !Screen.showCursor && (Input.GetButtonDown("Fire1") || RuntimeServices.ToBool(ConduitInputReciever.ht["tPadState"])) && !firingminigun && !(rocketcounter > 0f) && !(rocketammoleft < 1f))
			{
				if (RuntimeServices.ToBool(ConduitInputReciever.ht["tPadState"]))
				{
					ConduitInputReciever.ht["tPadState"] = false;
				}
				Vector3 vector5 = transform.TransformDirection(Vector3.forward);
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("fireminigun", PhotonTargets.All, username, UnityEngine.Random.Range(-999999999, 999999999), UnityBuiltins.parseInt(ChatScript.levels[0]), SpawningScript.team2, (!ChatScript.hasrapidfire) ? 1f : 0.5f);
			}
			if ((Input.GetButtonDown("Fire1") || RuntimeServices.ToBool(ConduitInputReciever.ht["tPadState"])) && guntype == "laser" && !(lasercounter > 0f) && !Screen.showCursor && ChatScript.secondaryweapon == "rocket" && !(laserammoleft < 1f))
			{
				if (RuntimeServices.ToBool(ConduitInputReciever.ht["tPadState"]))
				{
					ConduitInputReciever.ht["tPadState"] = false;
				}
				lasercounter = ((!ChatScript.hasrapidfire) ? 1f : 0.5f) * 0.685f;
				laserammoleft -= 1f;
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("firerocket", PhotonTargets.All, username, transform.position, transform.rotation, maincar.velocity, UnityBuiltins.parseInt(ChatScript.levels[1]), UnityEngine.Random.Range(-999999999, 999999999), SpawningScript.team2, (!ChatScript.hasrapidfire) ? 1f : 0.5f);
			}
			if ((Input.GetButtonDown("Fire1") || RuntimeServices.ToBool(ConduitInputReciever.ht["tPadState"])) && guntype == "laser" && !(lasercounter > 0f) && !Screen.showCursor && ChatScript.secondaryweapon == "shotgun" && !(laserammoleft < 1f))
			{
				if (RuntimeServices.ToBool(ConduitInputReciever.ht["tPadState"]))
				{
					ConduitInputReciever.ht["tPadState"] = false;
				}
				lasercounter = ((!ChatScript.hasrapidfire) ? 1f : 0.5f) * 2f;
				laserammoleft -= 1f;
				int num5 = UnityEngine.Random.Range(-999999999, 999999999);
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("fireShotgun", PhotonTargets.All, username, transform.position, transform.rotation, UnityBuiltins.parseInt(ChatScript.levels[1]), SpawningScript.team2, num5, (!ChatScript.hasrapidfire) ? 1f : 0.5f);
			}
			if ((Input.GetButtonDown("Fire1") || RuntimeServices.ToBool(ConduitInputReciever.ht["tPadState"])) && guntype == "laser" && !(lasercounter > 0f) && !Screen.showCursor && ChatScript.secondaryweapon == "railgun" && !(laserammoleft < 1f))
			{
				if (RuntimeServices.ToBool(ConduitInputReciever.ht["tPadState"]))
				{
					ConduitInputReciever.ht["tPadState"] = false;
				}
				lasercounter = ((!ChatScript.hasrapidfire) ? 1f : 0.5f) * 0.685f;
				laserammoleft -= 1f;
				int num5 = UnityEngine.Random.Range(-999999999, 999999999);
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("fireRailgun", PhotonTargets.All, username, transform.position, transform.rotation, UnityBuiltins.parseInt(ChatScript.levels[1]), SpawningScript.team2, num5, (!ChatScript.hasrapidfire) ? 1f : 0.5f);
			}
			if ((Input.GetButtonDown("Fire1") || RuntimeServices.ToBool(ConduitInputReciever.ht["tPadState"])) && guntype == "laser" && !(lasercounter > 0f) && !Screen.showCursor && ChatScript.secondaryweapon == "lasercannon" && !(laserammoleft < 1f))
			{
				if (RuntimeServices.ToBool(ConduitInputReciever.ht["tPadState"]))
				{
					ConduitInputReciever.ht["tPadState"] = false;
				}
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("startChargingLaser", PhotonTargets.All, username, UnityBuiltins.parseInt(ChatScript.levels[0]), SpawningScript.team2, (!ChatScript.hasrapidfire) ? 1f : 0.5f);
			}
			if ((Input.GetButtonDown("Fire1") || RuntimeServices.ToBool(ConduitInputReciever.ht["tPadState"])) && guntype == "laser" && !(lasercounter > 0f) && !Screen.showCursor && ChatScript.secondaryweapon == "missile" && !(laserammoleft < 1f))
			{
				if (RuntimeServices.ToBool(ConduitInputReciever.ht["tPadState"]))
				{
					ConduitInputReciever.ht["tPadState"] = false;
				}
				lasercounter = ((!ChatScript.hasrapidfire) ? 1f : 0.5f) * 0.8f;
				PhotonViewID photonViewID = PhotonNetwork.AllocateViewID();
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("firemissile", PhotonTargets.All, username, missilespots[(int)(4f - laserammoleft)].transform.position, transform.rotation, UnityBuiltins.parseInt(ChatScript.levels[1]), photonViewID, SpawningScript.team2, (!ChatScript.hasrapidfire) ? 1f : 0.5f);
				laserammoleft -= 1f;
			}
			if (guntype == "laser" && ChatScript.secondaryweapon == "missile")
			{
				laserpointer.enabled = true;
				Vector3 direction = laserpointer.transform.TransformDirection(Vector3.forward);
				if (Physics.Raycast(laserpointer.transform.position, direction, out hitInfo, float.PositiveInfinity))
				{
					laserpointer.SetPosition(1, laserpointer.transform.InverseTransformPoint(hitInfo.point));
					if ((bool)(PhotonView)hitInfo.transform.gameObject.GetComponent(typeof(PhotonView)) && ((PhotonView)hitInfo.transform.gameObject.GetComponent(typeof(PhotonView))).isMine && ChatScript.isCar)
					{
						if (hitInfo.transform.gameObject.name == "CarPrefab(Clone)" || hitInfo.transform.gameObject.name == "MainBoxCol" || hitInfo.transform.gameObject.name == "HumanPrefab(Clone)")
						{
							ReturnName returnName = (ReturnName)hitInfo.transform.gameObject.GetComponent("ReturnName");
							if (returnName.returnAI())
							{
								laserpointer.SetColors(redcolor[0], redcolor[1]);
							}
							else
							{
								laserpointer.SetColors(greencolor[0], greencolor[1]);
								if (Physics.Raycast(laserpointer.transform.position, direction, out hitInfo, float.PositiveInfinity, somelayermask))
								{
									laserpointer.SetPosition(1, laserpointer.transform.InverseTransformPoint(hitInfo.point));
								}
							}
						}
						else
						{
							laserpointer.SetColors(greencolor[0], greencolor[1]);
							if (Physics.Raycast(laserpointer.transform.position, direction, out hitInfo, float.PositiveInfinity, somelayermask))
							{
								laserpointer.SetPosition(1, laserpointer.transform.InverseTransformPoint(hitInfo.point));
							}
						}
					}
					else if (hitInfo.transform.gameObject.name == "MainBoxCol" || hitInfo.transform.gameObject.name == "CarPrefab(Clone)" || hitInfo.transform.gameObject.name == "BotBlue(Clone)" || hitInfo.transform.gameObject.name == "BotRed(Clone)" || hitInfo.transform.gameObject.name == "BotBlueAttack(Clone)" || hitInfo.transform.gameObject.name == "BotRedAttack(Clone)" || hitInfo.transform.gameObject.name == "HumanPrefab(Clone)")
					{
						if (hitInfo.transform.gameObject.name == "MainBoxCol")
						{
							CloakPickup cloakPickup = (CloakPickup)hitInfo.transform.gameObject.GetComponent("CloakPickup");
							Debug.Log(cloakPickup.returnCloakState());
							if (!cloakPickup.returnCloakState() && !(hitInfo.distance >= 650f))
							{
								laserpointer.SetColors(redcolor[0], redcolor[1]);
							}
							else
							{
								laserpointer.SetColors(greencolor[0], greencolor[1]);
							}
						}
						else if (hitInfo.transform.gameObject.name == "CarPrefab(Clone)")
						{
							PlayerCar_Script playerCar_Script = (PlayerCar_Script)hitInfo.transform.gameObject.GetComponent("PlayerCar_Script");
							if (!playerCar_Script.returnCloakState() && !(hitInfo.distance >= 650f))
							{
								laserpointer.SetColors(redcolor[0], redcolor[1]);
							}
							else
							{
								laserpointer.SetColors(greencolor[0], greencolor[1]);
							}
						}
						else if (!(hitInfo.distance >= 650f))
						{
							laserpointer.SetColors(redcolor[0], redcolor[1]);
						}
					}
					else
					{
						laserpointer.SetColors(greencolor[0], greencolor[1]);
					}
				}
			}
			else if (guntype != "laser" && ChatScript.secondaryweapon == "missile" && laserpointer.enabled)
			{
				laserpointer.enabled = false;
			}
			if (ChatScript.secondaryweapon != "missile" && ChatScript.primaryweapon != "missile" && laserpointer.enabled)
			{
				laserpointer.enabled = false;
			}
			if ((Input.GetButtonUp("Fire1") || RuntimeServices.ToBool(ConduitInputReciever.ht["tPadState"])) && guntype == "laser" && ChatScript.secondaryweapon == "launcher" && !(lasercounter > 0f) && !(laserammoleft < 1f) && !Screen.showCursor)
			{
				if (RuntimeServices.ToBool(ConduitInputReciever.ht["tPadState"]))
				{
					ConduitInputReciever.ht["tPadState"] = false;
				}
				lasercounter = ((!ChatScript.hasrapidfire) ? 1f : 0.5f) * 0.8f;
				laserammoleft -= 1f;
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("firelauncher", PhotonTargets.All, username, launcherfirepoint.position, launcherfirepoint.rotation, maincar.velocity, maincar.angularVelocity, UnityBuiltins.parseInt(ChatScript.levels[1]), UnityEngine.Random.Range(-999999999, 999999999), SpawningScript.team2, (!ChatScript.hasrapidfire) ? 1f : 0.5f, Mathf.RoundToInt(chargeState));
				chargeState = 0f;
				isCharging = false;
			}
			if ((Input.GetButtonUp("Fire1") || RuntimeServices.ToBool(ConduitInputReciever.ht["tPadState"])) && guntype == "laser" && ChatScript.secondaryweapon == "emplauncher" && !(lasercounter > 0f) && !(laserammoleft < 1f) && !Screen.showCursor)
			{
				if (RuntimeServices.ToBool(ConduitInputReciever.ht["tPadState"]))
				{
					ConduitInputReciever.ht["tPadState"] = false;
				}
				lasercounter = ((!ChatScript.hasrapidfire) ? 1f : 0.5f) * 0.8f;
				laserammoleft -= 1f;
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("fireemplauncher", PhotonTargets.All, username, launcherfirepoint.position, launcherfirepoint.rotation, maincar.velocity, maincar.angularVelocity, UnityBuiltins.parseInt(ChatScript.levels[1]), UnityEngine.Random.Range(-999999999, 999999999), SpawningScript.team2, (!ChatScript.hasrapidfire) ? 1f : 0.5f, Mathf.RoundToInt(chargeState));
				chargeState = 0f;
				isCharging = false;
			}
			if (Input.GetButton("Fire1") && guntype == "laser" && (ChatScript.secondaryweapon == "emplauncher" || ChatScript.secondaryweapon == "launcher") && !(laserammoleft < 1f) && !Screen.showCursor)
			{
				if (!isCharging)
				{
					isCharging = true;
				}
				chargeState += Time.deltaTime;
			}
			if (guntype == "laser" && ChatScript.secondaryweapon == "grappling" && laserammoleft == 1f && !grappling)
			{
				grappleitem.active = true;
			}
			if (guntype == "rocket" && ChatScript.secondaryweapon == "grappling")
			{
				grappleitem.active = false;
			}
			if (laserammoleft != 1f && ChatScript.secondaryweapon == "grappling")
			{
				grappleitem.active = false;
			}
			if (guntype == "laser" && ChatScript.secondaryweapon == "grappling" && grappling)
			{
				grappleitem.active = false;
			}
			if ((Input.GetButtonDown("Fire1") || RuntimeServices.ToBool(ConduitInputReciever.ht["tPadState"])) && guntype == "laser" && ChatScript.secondaryweapon == "grappling" && !(lasercounter > 0f) && !(laserammoleft < 1f) && !Screen.showCursor)
			{
				if (RuntimeServices.ToBool(ConduitInputReciever.ht["tPadState"]))
				{
					ConduitInputReciever.ht["tPadState"] = false;
				}
				if (!grappling)
				{
					grappling = true;
					PhotonViewID photonViewID = PhotonNetwork.AllocateViewID();
					((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("fireGrappler", PhotonTargets.All, username, launcherfirepoint.position, launcherfirepoint.rotation, maincar.velocity, maincar.angularVelocity, photonViewID, UnityBuiltins.parseInt(ChatScript.levels[1]), SpawningScript.team2, (!ChatScript.hasrapidfire) ? 1f : 0.5f);
				}
				else
				{
					grappling = false;
					stopgrapple = true;
					lasercounter = ((!ChatScript.hasrapidfire) ? 1f : 0.5f) * 0.8f;
					laserammoleft -= 1f;
				}
			}
			if (ChatScript.secondaryweapon == "laser" && guntype == "laser" && (Input.GetButton("Fire1") || RuntimeServices.ToBool(ConduitInputReciever.ht["tPadState"])) && !Screen.showCursor && !(lasercounter > 0f) && !(laserammoleft < 1f))
			{
				lasercounter = ((!ChatScript.hasrapidfire) ? 1f : 0.5f) * 0.34f;
				laserammoleft -= 1f;
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("firelaser", PhotonTargets.All, username, transform.position, transform.rotation, UnityBuiltins.parseInt(ChatScript.levels[1]), UnityEngine.Random.Range(-999999999, 999999999), SpawningScript.team2, (!ChatScript.hasrapidfire) ? 1f : 0.5f);
			}
			if (ChatScript.secondaryweapon == "flamethrower" && guntype == "laser" && !Screen.showCursor && (Input.GetButtonDown("Fire1") || RuntimeServices.ToBool(ConduitInputReciever.ht["tPadState"])) && !HealthBar.isdead && !(lasercounter > 0f) && !(laserammoleft < 1f))
			{
				if (RuntimeServices.ToBool(ConduitInputReciever.ht["tPadState"]))
				{
					ConduitInputReciever.ht["tPadState"] = false;
				}
				PhotonViewID photonViewID = PhotonNetwork.AllocateViewID();
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("fireflamethrower", PhotonTargets.All, username, photonViewID, UnityBuiltins.parseInt(ChatScript.levels[1]), SpawningScript.team2, (!ChatScript.hasrapidfire) ? 1f : 0.5f);
			}
			if (ChatScript.secondaryweapon == "flamethrower" && guntype == "laser" && (Input.GetButton("Fire1") || RuntimeServices.ToBool(ConduitInputReciever.ht["tPadState"])) && !(laserammoleft <= 0f) && !Screen.showCursor && isfiringflame)
			{
				laserammoleft -= 1f * Time.deltaTime * 80f;
			}
			if (ChatScript.secondaryweapon == "minigun" && guntype == "laser" && !Screen.showCursor && (Input.GetButtonDown("Fire1") || RuntimeServices.ToBool(ConduitInputReciever.ht["tPadState"])) && !firingminigun && !HealthBar.isdead && !(lasercounter > 0f) && !(laserammoleft < 1f))
			{
				if (RuntimeServices.ToBool(ConduitInputReciever.ht["tPadState"]))
				{
					ConduitInputReciever.ht["tPadState"] = false;
				}
				Vector3 vector5 = transform.TransformDirection(Vector3.forward);
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("fireminigun", PhotonTargets.All, username, UnityEngine.Random.Range(-999999999, 999999999), UnityBuiltins.parseInt(ChatScript.levels[1]), SpawningScript.team2, (!ChatScript.hasrapidfire) ? 1f : 0.5f);
			}
			if (ChatScript.secondaryweapon == "minigun" && guntype == "laser" && firingminigun && !(laserammoleft > 0f))
			{
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("stopfireminigun", PhotonTargets.All);
			}
			if (ChatScript.secondaryweapon == "minigun" && ToggleGuns.curmode == 1 && firingminigun)
			{
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("stopfireminigun", PhotonTargets.All);
			}
			if (ChatScript.secondaryweapon == "minigun" && CTFFlagSender.gotflag && firingminigun)
			{
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("stopfireminigun", PhotonTargets.All);
			}
			if (ChatScript.primaryweapon == "minigun" && guntype == "rocket" && firingminigun && !(rocketammoleft > 0f))
			{
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("stopfireminigun", PhotonTargets.All);
			}
			if (ChatScript.primaryweapon == "minigun" && ToggleGuns.curmode == 2 && firingminigun)
			{
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("stopfireminigun", PhotonTargets.All);
			}
			if (ChatScript.primaryweapon == "minigun" && CTFFlagSender.gotflag && firingminigun)
			{
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("stopfireminigun", PhotonTargets.All);
			}
			if (ChatScript.primaryweapon == "grappling" && ToggleGuns.curmode == 2 && grappling)
			{
				grappling = false;
				stopgrapple = true;
			}
			if (ChatScript.primaryweapon == "grappling" && CTFFlagSender.gotflag && grappling)
			{
				grappling = false;
				stopgrapple = true;
			}
			if (ChatScript.secondaryweapon == "grappling" && ToggleGuns.curmode == 1 && grappling)
			{
				grappling = false;
				stopgrapple = true;
			}
			if (ChatScript.secondaryweapon == "grappling" && CTFFlagSender.gotflag && grappling)
			{
				grappling = false;
				stopgrapple = true;
			}
			if (ChatScript.primaryweapon == "lasercannon" && guntype == "rocket" && charginglaser && !(rocketammoleft > 0f))
			{
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("stopfirelasercannon", PhotonTargets.All);
			}
			if (ChatScript.primaryweapon == "lasercannon" && ToggleGuns.curmode == 2 && charginglaser)
			{
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("stopfirelasercannon", PhotonTargets.All);
			}
			if (ChatScript.primaryweapon == "lasercannon" && CTFFlagSender.gotflag && charginglaser)
			{
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("stopfirelasercannon", PhotonTargets.All);
			}
			if (ChatScript.secondaryweapon == "lasercannon" && guntype == "laser" && charginglaser && !(laserammoleft > 0f))
			{
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("stopfirelasercannon", PhotonTargets.All);
			}
			if (ChatScript.secondaryweapon == "lasercannon" && ToggleGuns.curmode == 1 && charginglaser)
			{
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("stopfirelasercannon", PhotonTargets.All);
			}
			if (ChatScript.secondaryweapon == "lasercannon" && CTFFlagSender.gotflag && charginglaser)
			{
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("stopfirelasercannon", PhotonTargets.All);
			}
		}
		if ((Input.GetMouseButtonUp(0) || HealthBar.isdead) && photonView.isMine && ChatScript.isCar && !aimanager.isAI)
		{
			if (firingminigun)
			{
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("stopfireminigun", PhotonTargets.All);
			}
			if (charginglaser)
			{
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("stopfirelasercannon", PhotonTargets.All);
			}
		}
		if (photonView.isMine && ChatScript.isCar && !aimanager.isAI && HealthBar.isdead && grappling)
		{
			grappling = false;
			stopgrapple = true;
		}
	}

	public virtual IEnumerator tempInvinc()
	{
		return new _0024tempInvinc_00244620().GetEnumerator();
	}

	[RPC]
	public virtual IEnumerator goInvincible(int level, int vtype)
	{
		return new _0024goInvincible_00244622(level, vtype, this).GetEnumerator();
	}

	[RPC]
	public virtual void fireGrappler(string user, Vector3 pos, Quaternion rot, Vector3 vel, Vector3 angvel, PhotonViewID id, int level, string team, float dM)
	{
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(grappler, launcherfirepoint.position, launcherfirepoint.rotation);
		gameObject.rigidbody.AddRelativeForce(0f, 0f, 50000 + 10000 * level / 20);
		gameObject.rigidbody.velocity = vel;
		gameObject.rigidbody.angularVelocity = angvel;
		((PhotonView)gameObject.GetComponent(typeof(PhotonView))).viewID = id;
		gameObject.SendMessage("setowner", user);
		gameObject.SendMessage("sethome", maincar);
		gameObject.SendMessage("setteam", team);
		gameObject.SendMessage("setfirepoint", grapplefirepoint);
		GameObject gameObject2 = (GameObject)UnityEngine.Object.Instantiate(launcheraud, pos, rot);
		gameObject2.SendMessage("sticksound", this.gameObject);
	}

	[RPC]
	public virtual void stopfirelasercannon()
	{
		LineRenderer lineRenderer = (LineRenderer)lasercannonobj.GetComponent(typeof(LineRenderer));
		Light light = (Light)lasercannonobj.GetComponent(typeof(Light));
		lineRenderer.enabled = false;
		light.enabled = false;
		charginglaser = false;
		if (photonView.isMine)
		{
			isCharging = false;
		}
	}

	[RPC]
	public virtual IEnumerator startChargingLaser(string user, int level, string team, float dM)
	{
		return new _0024startChargingLaser_00244629(user, level, team, dM, this).GetEnumerator();
	}

	public virtual IEnumerator decreaseBlastAud(GameObject g)
	{
		return new _0024decreaseBlastAud_00244648(g).GetEnumerator();
	}

	[RPC]
	public virtual void laserCannonHit(string hitname, string username, Vector3 relpos)
	{
		if (hitname == AuthGameObject.username)
		{
			SpawningScript.playertrans.SendMessage("laserCannonHit", username);
			UnityEngine.Object.Instantiate(megalaserhit, SpawningScript.playertrans.TransformPoint(relpos), transform.rotation);
		}
		if (hitname == MasterServerScript.ainame && PhotonNetwork.isMasterClient)
		{
			SpawningScript.aiplayerobjs[0].SendMessage("laserCannonHit", username);
			UnityEngine.Object.Instantiate(megalaserhit, SpawningScript.aiplayerobjs[0].TransformPoint(relpos), transform.rotation);
		}
		if (hitname == MasterServerScript.ainame2 && PhotonNetwork.isMasterClient)
		{
			SpawningScript.aiplayerobjs[1].SendMessage("laserCannonHit", username);
			UnityEngine.Object.Instantiate(megalaserhit, SpawningScript.aiplayerobjs[1].TransformPoint(relpos), transform.rotation);
		}
		if (hitname == MasterServerScript.ainame3 && PhotonNetwork.isMasterClient)
		{
			SpawningScript.aiplayerobjs[2].SendMessage("laserCannonHit", username);
			UnityEngine.Object.Instantiate(megalaserhit, SpawningScript.aiplayerobjs[2].TransformPoint(relpos), transform.rotation);
		}
	}

	[RPC]
	public virtual void enableShield(string user, int l)
	{
		shieldobject.active = true;
		if (photonView.isMine && ChatScript.isCar && !aimanager.isAI)
		{
			((PhotonView)shieldobject.GetComponent(typeof(PhotonView))).RPC("setLevel", PhotonTargets.All, l);
		}
	}

	[RPC]
	public virtual void firemissile(string user, Vector3 pos, Quaternion rot, int level, PhotonViewID id, string team, float dM)
	{
		GameObject gameObject = null;
		gameObject = ((QualitySettings.GetQualityLevel() == 0) ? ((!(SpawningScript.team2 == "red")) ? ((GameObject)UnityEngine.Object.Instantiate(missileprefabsimp[1], pos, rot)) : ((GameObject)UnityEngine.Object.Instantiate(missileprefabsimp[0], pos, rot))) : ((!(SpawningScript.team2 == "red")) ? ((GameObject)UnityEngine.Object.Instantiate(missileprefab[1], pos, rot)) : ((GameObject)UnityEngine.Object.Instantiate(missileprefab[0], pos, rot))));
		if (photonView.isMine && ChatScript.isCar && !aimanager.isAI)
		{
			Vector3 direction = transform.TransformDirection(Vector3.forward);
			RaycastHit hitInfo = default(RaycastHit);
			if (Physics.Raycast(transform.position, direction, out hitInfo, float.PositiveInfinity, missilelayermask))
			{
				if (hitInfo.transform.gameObject.name == "MainBoxCol" || hitInfo.transform.gameObject.name == "CarPrefab(Clone)" || hitInfo.transform.gameObject.name == "BotBlue(Clone)" || hitInfo.transform.gameObject.name == "BotRed(Clone)" || hitInfo.transform.gameObject.name == "BotBlueAttack(Clone)" || hitInfo.transform.gameObject.name == "BotRedAttack(Clone)")
				{
					if (hitInfo.transform.gameObject.name == "MainBoxCol")
					{
						CloakPickup cloakPickup = (CloakPickup)hitInfo.transform.gameObject.GetComponent("CloakPickup");
						if (!cloakPickup.returnCloakState())
						{
							gameObject.SendMessage("setTarget", hitInfo.transform);
						}
						else
						{
							gameObject.SendMessage("setTargetPoint", hitInfo.point);
						}
					}
					else if (hitInfo.transform.gameObject.name == "CarPrefab(Clone)")
					{
						PlayerCar_Script playerCar_Script = (PlayerCar_Script)hitInfo.transform.gameObject.GetComponent("PlayerCar_Script");
						if (!playerCar_Script.returnCloakState())
						{
							gameObject.SendMessage("setTarget", hitInfo.transform);
						}
						else
						{
							gameObject.SendMessage("setTargetPoint", hitInfo.point);
						}
					}
					else
					{
						gameObject.SendMessage("setTarget", hitInfo.transform);
					}
				}
				else
				{
					gameObject.SendMessage("setTargetPoint", hitInfo.point);
				}
			}
		}
		gameObject.SendMessage("setowner", user);
		gameObject.SendMessage("setlevel", level);
		gameObject.gameObject.SendMessage("setteam", team);
		GameObject gameObject2 = (GameObject)UnityEngine.Object.Instantiate(rocketaud, pos, rot);
		gameObject2.SendMessage("sticksound", this.gameObject);
		if (col1.gameObject.active)
		{
			Physics.IgnoreCollision(gameObject.collider, col1.collider);
			Physics.IgnoreCollision(gameObject.collider, col2.collider);
		}
		int i = 0;
		Collider[] array = wheelcols;
		for (int length = array.Length; i < length; i++)
		{
			if (array[i].gameObject.active)
			{
				Physics.IgnoreCollision(gameObject.collider, array[i].collider);
			}
		}
		Physics.IgnoreCollision(gameObject.collider, col3.collider);
		Physics.IgnoreCollision(gameObject.collider, maincarcol.collider);
		Physics.IgnoreCollision(gameObject.collider, guncol.collider);
		((PhotonView)gameObject.GetComponent(typeof(PhotonView))).viewID = id;
		((MissileTrack)gameObject.GetComponent(typeof(MissileTrack))).dM = dM;
	}

	[RPC]
	public virtual void firelauncher(string user, Vector3 pos, Quaternion rot, Vector3 v, Vector3 av, int level, int id, string team, float dM, int chargeAmount)
	{
		GameObject gameObject = null;
		gameObject = (GameObject)UnityEngine.Object.Instantiate(grenadeprefab, pos, rot);
		gameObject.SendMessage("setowner", user);
		gameObject.SendMessage("setlevel", level);
		gameObject.gameObject.SendMessage("setteam", team);
		GameObject gameObject2 = (GameObject)UnityEngine.Object.Instantiate(launcheraud, pos, rot);
		gameObject2.SendMessage("sticksound", this.gameObject);
		if (col1.gameObject.active)
		{
			Physics.IgnoreCollision(gameObject.collider, col1.collider);
			Physics.IgnoreCollision(gameObject.collider, col2.collider);
		}
		int i = 0;
		Collider[] array = wheelcols;
		for (int length = array.Length; i < length; i++)
		{
			if (array[i].gameObject.active)
			{
				Physics.IgnoreCollision(gameObject.collider, array[i].collider);
			}
		}
		Physics.IgnoreCollision(gameObject.collider, col3.collider);
		Physics.IgnoreCollision(gameObject.collider, maincarcol.collider);
		Physics.IgnoreCollision(gameObject.collider, guncol.collider);
		((GrenadeExploder)gameObject.GetComponent(typeof(GrenadeExploder))).pid = id;
		((GrenadeExploder)gameObject.GetComponent(typeof(GrenadeExploder))).dM = dM;
		((GrenadeExploder)gameObject.GetComponent(typeof(GrenadeExploder))).chargeAmount = chargeAmount;
		projMan.AllocateNewId(gameObject, id);
		gameObject.rigidbody.velocity = v;
		gameObject.rigidbody.angularVelocity = av;
	}

	[RPC]
	public virtual void fireemplauncher(string user, Vector3 pos, Quaternion rot, Vector3 v, Vector3 av, int level, int id, string team, float dM, int chargeAmount)
	{
		Debug.Log("Charge amount: " + chargeAmount);
		GameObject gameObject = null;
		gameObject = (GameObject)UnityEngine.Object.Instantiate(empgrenadeprefab, pos, rot);
		gameObject.SendMessage("setowner", user);
		gameObject.SendMessage("setlevel", level);
		gameObject.gameObject.SendMessage("setteam", team);
		GameObject gameObject2 = (GameObject)UnityEngine.Object.Instantiate(launcheraud, pos, rot);
		gameObject2.SendMessage("sticksound", this.gameObject);
		if (col1.gameObject.active)
		{
			Physics.IgnoreCollision(gameObject.collider, col1.collider);
			Physics.IgnoreCollision(gameObject.collider, col2.collider);
		}
		int i = 0;
		Collider[] array = wheelcols;
		for (int length = array.Length; i < length; i++)
		{
			if (array[i].gameObject.active)
			{
				Physics.IgnoreCollision(gameObject.collider, array[i].collider);
			}
		}
		Physics.IgnoreCollision(gameObject.collider, col3.collider);
		Physics.IgnoreCollision(gameObject.collider, maincarcol.collider);
		Physics.IgnoreCollision(gameObject.collider, guncol.collider);
		((GrenadeExploder)gameObject.GetComponent(typeof(GrenadeExploder))).pid = id;
		((GrenadeExploder)gameObject.GetComponent(typeof(GrenadeExploder))).dM = dM;
		((GrenadeExploder)gameObject.GetComponent(typeof(GrenadeExploder))).chargeAmount = chargeAmount;
		projMan.AllocateNewId(gameObject, id);
		gameObject.rigidbody.velocity = v;
		gameObject.rigidbody.angularVelocity = av;
	}

	[RPC]
	public virtual void dropMine(string u, int l, Vector3 p, Quaternion r, int i, string team, PhotonViewID id)
	{
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(mines[i], p, r);
		IEnumerator enumerator = UnityRuntimeServices.GetEnumerator(gameObject.transform);
		while (enumerator.MoveNext())
		{
			object obj = enumerator.Current;
			if (!(obj is Transform))
			{
				obj = RuntimeServices.Coerce(obj, typeof(Transform));
			}
			Transform transform = (Transform)obj;
			((PhotonView)transform.GetComponent(typeof(PhotonView))).viewID = id;
			UnityRuntimeServices.Update(enumerator, transform);
			transform.gameObject.SendMessage("setowner", u);
			UnityRuntimeServices.Update(enumerator, transform);
			transform.gameObject.SendMessage("setlevel", l);
			UnityRuntimeServices.Update(enumerator, transform);
			transform.gameObject.SendMessage("setteam", team);
			UnityRuntimeServices.Update(enumerator, transform);
			if (col1.gameObject.active)
			{
				Physics.IgnoreCollision(transform.collider, col1.collider);
				UnityRuntimeServices.Update(enumerator, transform);
				Physics.IgnoreCollision(transform.collider, col2.collider);
				UnityRuntimeServices.Update(enumerator, transform);
			}
			int j = 0;
			Collider[] array = wheelcols;
			for (int length = array.Length; j < length; j++)
			{
				if (array[j].gameObject.active)
				{
					Physics.IgnoreCollision(transform.collider, array[j].collider);
					UnityRuntimeServices.Update(enumerator, transform);
				}
			}
			Physics.IgnoreCollision(transform.collider, col3.collider);
			UnityRuntimeServices.Update(enumerator, transform);
			Physics.IgnoreCollision(transform.collider, maincarcol.collider);
			UnityRuntimeServices.Update(enumerator, transform);
			Physics.IgnoreCollision(transform.collider, guncol.collider);
			UnityRuntimeServices.Update(enumerator, transform);
		}
	}

	[RPC]
	public virtual void fireflamethrower(string user, PhotonViewID id, int level, string team, float dM)
	{
		if (photonView.isMine && ChatScript.isCar && !aimanager.isAI)
		{
			isfiringflame = true;
		}
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(FlamePrefab, flameparent.position, flameparent.rotation);
		gameObject.transform.parent = flameparent;
		UnityRuntimeServices.Invoke(gameObject.GetComponent("FlameScript"), "setIsPrefab", new object[1] { false }, typeof(UnityEngine.MonoBehaviour));
		UnityRuntimeServices.Invoke(gameObject.GetComponent("FlameScript"), "setUsername", new object[1] { user }, typeof(UnityEngine.MonoBehaviour));
		gameObject.SendMessage("setlevel", level);
		gameObject.gameObject.SendMessage("setteam", team);
		((PhotonView)gameObject.GetComponent(typeof(PhotonView))).viewID = id;
		((FlameScript)gameObject.gameObject.GetComponent(typeof(FlameScript))).dM = dM;
	}

	[RPC]
	public virtual IEnumerator stopfireminigun()
	{
		return new _0024stopfireminigun_00244651(this).GetEnumerator();
	}

	[RPC]
	public virtual IEnumerator fireminigun(string user, int id, int level, string team, float dM)
	{
		return new _0024fireminigun_00244654(user, id, level, team, dM, this).GetEnumerator();
	}

	public virtual IEnumerator startrotating(int id)
	{
		return new _0024startrotating_00244673(id, this).GetEnumerator();
	}

	[RPC]
	public virtual void firerocket(string user, Vector3 pos, Quaternion rot, Vector3 v, int level, int id, string team, float dM)
	{
		Rigidbody rigidbody = null;
		rigidbody = ((QualitySettings.GetQualityLevel() != 0) ? ((Rigidbody)UnityEngine.Object.Instantiate(rocket, pos, rot)) : ((Rigidbody)UnityEngine.Object.Instantiate(rocketsimp, pos, rot)));
		rigidbody.gameObject.SendMessage("setowner", user);
		rigidbody.gameObject.SendMessage("setlevel", level);
		rigidbody.gameObject.SendMessage("setteam", team);
		((RocketBlowup)rigidbody.GetComponent(typeof(RocketBlowup))).pid = id;
		((RocketBlowup)rigidbody.GetComponent(typeof(RocketBlowup))).dM = dM;
		projMan.AllocateNewId(rigidbody.gameObject, id);
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(rocketaud, pos, rot);
		gameObject.SendMessage("sticksound", this.gameObject);
		if (col1.gameObject.active)
		{
			Physics.IgnoreCollision(rigidbody.collider, col1.collider);
			Physics.IgnoreCollision(rigidbody.collider, col2.collider);
		}
		Physics.IgnoreCollision(rigidbody.collider, col3.collider);
		Physics.IgnoreCollision(rigidbody.collider, maincarcol.collider);
		Physics.IgnoreCollision(rigidbody.collider, guncol.collider);
		int i = 0;
		Collider[] array = wheelcols;
		for (int length = array.Length; i < length; i++)
		{
			if (array[i].gameObject.active)
			{
				Physics.IgnoreCollision(rigidbody.collider, array[i].collider);
			}
		}
		if (aimanager.isAI)
		{
		}
	}

	[RPC]
	public virtual void fireShotgun(string user, Vector3 pos, Quaternion rot, int level, string team, int id, float dM)
	{
		for (int i = 0; i < 10; i++)
		{
			Vector3 vector = transform.InverseTransformDirection(rot.eulerAngles);
			Vector3 euler = transform.TransformDirection(new Vector3(vector.x + UnityEngine.Random.Range(-5f, 5f), vector.y + UnityEngine.Random.Range(-5f, 5f), vector.z));
			GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(shotgunbullet, pos, Quaternion.Euler(euler));
			gameObject.gameObject.SendMessage("setOwner", user);
			gameObject.gameObject.SendMessage("setlevel", level);
			gameObject.gameObject.SendMessage("setteam", team);
			projMan.AllocateNewId(gameObject, id + i);
			gameObject.gameObject.SendMessage("setID", id + i);
			LowPolyBulletExplode lowPolyBulletExplode = (LowPolyBulletExplode)gameObject.gameObject.GetComponent(typeof(LowPolyBulletExplode));
			lowPolyBulletExplode.projMan = projMan;
			lowPolyBulletExplode.dM = dM;
			lowPolyBulletExplode.realFiredFromObject = this.gameObject;
		}
		GameObject gameObject2 = (GameObject)UnityEngine.Object.Instantiate(bulletcasing, casingspawn.position, casingspawn.rotation);
		GameObject gameObject3 = (GameObject)UnityEngine.Object.Instantiate(shotgunflash, minigunfirepoint.position, minigunfirepoint.rotation);
		gameObject3.transform.parent = shotgunfirepoint;
		gameObject2.rigidbody.AddRelativeForce(Vector3.right * UnityEngine.Random.Range(200f, 300f));
		GameObject gameObject4 = (GameObject)UnityEngine.Object.Instantiate(shotgunAudio, pos, rot);
		gameObject4.SendMessage("sticksound", this.gameObject);
	}

	[RPC]
	public virtual void fireRailgun(string user, Vector3 pos, Quaternion rot, int level, string team, int id, float dM)
	{
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(railbullet, pos, rot);
		gameObject.gameObject.SendMessage("setOwner", user);
		gameObject.gameObject.SendMessage("setlevel", level);
		gameObject.gameObject.SendMessage("setteam", team);
		projMan.AllocateNewId(gameObject, id);
		gameObject.gameObject.SendMessage("setID", id);
		LowPolyBulletExplode lowPolyBulletExplode = (LowPolyBulletExplode)gameObject.gameObject.GetComponent(typeof(LowPolyBulletExplode));
		lowPolyBulletExplode.projMan = projMan;
		lowPolyBulletExplode.dM = dM;
		lowPolyBulletExplode.realFiredFromObject = this.gameObject;
		railgunfirepoint.audio.PlayOneShot(railgunfirepoint.audio.clip);
	}

	[RPC]
	public virtual void firelaser(string user, Vector3 pos, Quaternion rot, int level, int id, string team, float dM)
	{
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(laser, pos, rot);
		gameObject.gameObject.SendMessage("setowner", user);
		gameObject.gameObject.SendMessage("setlevel", level);
		gameObject.gameObject.SendMessage("setteam", team);
		((LaserSplat)gameObject.GetComponent(typeof(LaserSplat))).pid = id;
		((LaserSplat)gameObject.GetComponent(typeof(LaserSplat))).dM = dM;
		projMan.AllocateNewId(gameObject.gameObject, id);
		GameObject gameObject2 = (GameObject)UnityEngine.Object.Instantiate(laseraud, pos, rot);
		gameObject2.SendMessage("sticksound", this.gameObject);
	}
}
