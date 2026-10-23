using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using Photon;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class CalculateHealth : Photon.MonoBehaviour
{
	[Serializable]
	internal sealed class _0024HealthUp_00244093 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal float _0024healthrange_00244094;

			internal int _0024i_00244095;

			internal CalculateHealth _0024self__00244096;

			public _0024(int i, CalculateHealth self_)
			{
				_0024i_00244095 = i;
				_0024self__00244096 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if ((_0024i_00244095 == 1692 && _0024self__00244096.photonView.isMine) || _0024self__00244096.aimanager.isAI)
					{
						_0024healthrange_00244094 = (100f - _0024self__00244096.currenthealth) / 1.4f;
						if (!(_0024healthrange_00244094 + _0024self__00244096.currenthealth <= 100f))
						{
							_0024self__00244096.currenthealth = 100f;
						}
						else
						{
							_0024self__00244096.currenthealth += _0024healthrange_00244094;
						}
						armorHealth = Mathf.Min(1f, armorHealth + (1f - armorHealth) / 1.4f);
						if (!(_0024self__00244096.currenthealth <= 15f))
						{
							if (!_0024self__00244096.aimanager.isAI)
							{
								GameObject.Find("HealthEffect").SendMessage("setnfo");
								GameObject.Find("HealthEffect").SendMessage("Fadeout");
							}
							_0024self__00244096.reseteffects = false;
						}
						((PhotonView)_0024self__00244096.gameObject.GetComponent(typeof(PhotonView))).RPC("setsmoke", PhotonTargets.All, _0024self__00244096.currenthealth);
						((PhotonView)_0024self__00244096.gameObject.GetComponent(typeof(PhotonView))).RPC("stopBurn", PhotonTargets.All);
						_0024self__00244096.updatehealth = true;
						_0024self__00244096.healthglow.emit = true;
						result = (Yield(2, new WaitForSeconds(1f)) ? 1 : 0);
						break;
					}
					goto IL_01ee;
				case 2:
					_0024self__00244096.healthglow.emit = false;
					goto IL_01ee;
				case 1:
					{
						result = 0;
						break;
					}
					IL_01ee:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal int _0024i_00244097;

		internal CalculateHealth _0024self__00244098;

		public _0024HealthUp_00244093(int i, CalculateHealth self_)
		{
			_0024i_00244097 = i;
			_0024self__00244098 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024i_00244097, _0024self__00244098);
		}
	}

	[Serializable]
	internal sealed class _0024Start_00244099 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal CalculateHealth _0024self__00244100;

			public _0024(CalculateHealth self_)
			{
				_0024self__00244100 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__00244100.photonView.isMine || _0024self__00244100.aimanager.isAI)
					{
						stallGlider = false;
						isafking = false;
						_0024self__00244100.healthGUI = GameObject.Find("HealthDisplay");
						_0024self__00244100.chatGUI = GameObject.Find("Chat");
						_0024self__00244100.tchooseGUI = GameObject.Find("TeamChooseGUI");
						_0024self__00244100.username = ((!_0024self__00244100.aimanager.isAI) ? AuthGameObject.username : _0024self__00244100.aimanager.ainame);
						if (!_0024self__00244100.aimanager.isAI)
						{
							healthstat = 100f;
							armorHealth = 1f;
							_0024self__00244100.gameObject.layer = 18;
						}
					}
					if (!_0024self__00244100.photonView.isMine || !_0024self__00244100.aimanager.isAI)
					{
					}
					result = (YieldDefault(2) ? 1 : 0);
					break;
				case 2:
					result = (YieldDefault(3) ? 1 : 0);
					break;
				case 3:
					result = (YieldDefault(4) ? 1 : 0);
					break;
				case 4:
					result = (YieldDefault(5) ? 1 : 0);
					break;
				case 5:
					result = (YieldDefault(6) ? 1 : 0);
					break;
				case 6:
					result = (YieldDefault(7) ? 1 : 0);
					break;
				case 7:
					result = (YieldDefault(8) ? 1 : 0);
					break;
				case 8:
					result = (YieldDefault(9) ? 1 : 0);
					break;
				case 9:
					_0024self__00244100.AddAllGameObjects(_0024self__00244100.maincar.transform);
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal CalculateHealth _0024self__00244101;

		public _0024Start_00244099(CalculateHealth self_)
		{
			_0024self__00244101 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00244101);
		}
	}

	[Serializable]
	internal sealed class _0024sayDead_00244102 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal CalculateHealth _0024self__00244103;

			public _0024(CalculateHealth self_)
			{
				_0024self__00244103 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					result = (Yield(2, new WaitForSeconds(UnityEngine.Random.Range(2f, 4f))) ? 1 : 0);
					break;
				case 2:
					GameObject.Find("/GUI/Chat").SendMessage("aiSpeaking" + _0024self__00244103.aimanager.aiteam, RuntimeServices.InvokeBinaryOperator("op_Addition", _0024self__00244103.aimanager.ainame + ": ", _0024self__00244103.dead[UnityEngine.Random.Range(0, _0024self__00244103.dead.length)]));
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal CalculateHealth _0024self__00244104;

		public _0024sayDead_00244102(CalculateHealth self_)
		{
			_0024self__00244104 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00244104);
		}
	}

	[Serializable]
	internal sealed class _0024delayregenFPS_00244105 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal Vector3 _0024pos_00244106;

			internal CalculateHealth _0024self__00244107;

			public _0024(Vector3 pos, CalculateHealth self_)
			{
				_0024pos_00244106 = pos;
				_0024self__00244107 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					((PhotonView)_0024self__00244107.gameObject.GetComponent(typeof(PhotonView))).RPC("killonallFPS", PhotonTargets.All, _0024pos_00244106);
					result = (Yield(2, new WaitForSeconds(4f)) ? 1 : 0);
					break;
				case 2:
					_0024self__00244107.currenthealth = 100f;
					_0024self__00244107.updatehealth = true;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Vector3 _0024pos_00244108;

		internal CalculateHealth _0024self__00244109;

		public _0024delayregenFPS_00244105(Vector3 pos, CalculateHealth self_)
		{
			_0024pos_00244108 = pos;
			_0024self__00244109 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024pos_00244108, _0024self__00244109);
		}
	}

	[Serializable]
	internal sealed class _0024delayregen_00244110 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal CalculateHealth _0024self__00244111;

			public _0024(CalculateHealth self_)
			{
				_0024self__00244111 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					((PhotonView)_0024self__00244111.gameObject.GetComponent(typeof(PhotonView))).RPC("killonall", PhotonTargets.All, _0024self__00244111.transform.position);
					result = (Yield(2, new WaitForSeconds(4f)) ? 1 : 0);
					break;
				case 2:
					_0024self__00244111.currenthealth = 100f;
					_0024self__00244111.updatehealth = true;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal CalculateHealth _0024self__00244112;

		public _0024delayregen_00244110(CalculateHealth self_)
		{
			_0024self__00244112 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00244112);
		}
	}

	[Serializable]
	internal sealed class _0024EnableAllFPS_00244113 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal GameObject _0024obj_00244114;

			internal IEnumerator _0024_0024iterator_0024310_00244115;

			internal GameObject _0024obj_00244116;

			internal int _0024_0024592_00244117;

			internal GameObject[] _0024_0024593_00244118;

			internal int _0024_0024594_00244119;

			internal CalculateHealth _0024self__00244120;

			public _0024(CalculateHealth self_)
			{
				_0024self__00244120 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					result = (Yield(2, new WaitForSeconds(5f)) ? 1 : 0);
					break;
				case 2:
					if (!_0024self__00244120.photonView.isMine || _0024self__00244120.aimanager.isAI)
					{
						result = (Yield(3, new WaitForSeconds(0.85f)) ? 1 : 0);
						break;
					}
					goto case 3;
				case 3:
					_0024_0024iterator_0024310_00244115 = UnityRuntimeServices.GetEnumerator(_0024self__00244120.thegameobjects);
					while (_0024_0024iterator_0024310_00244115.MoveNext())
					{
						object obj = _0024_0024iterator_0024310_00244115.Current;
						if (!(obj is GameObject))
						{
							obj = RuntimeServices.Coerce(obj, typeof(GameObject));
						}
						_0024obj_00244114 = (GameObject)obj;
						_0024obj_00244114.layer = RuntimeServices.UnboxInt32(_0024self__00244120.origtags[_0024obj_00244114]);
						UnityRuntimeServices.Update(_0024_0024iterator_0024310_00244115, _0024obj_00244114);
						GameObject gameObject = _0024obj_00244114;
						object obj2 = _0024self__00244120.origtagsreal[_0024obj_00244114];
						if (!(obj2 is string))
						{
							obj2 = RuntimeServices.Coerce(obj2, typeof(string));
						}
						gameObject.tag = (string)obj2;
						UnityRuntimeServices.Update(_0024_0024iterator_0024310_00244115, _0024obj_00244114);
					}
					_0024_0024592_00244117 = 0;
					_0024_0024593_00244118 = _0024self__00244120.glowObjs;
					for (_0024_0024594_00244119 = _0024_0024593_00244118.Length; _0024_0024592_00244117 < _0024_0024594_00244119; _0024_0024592_00244117++)
					{
						if ((bool)_0024_0024593_00244118[_0024_0024592_00244117])
						{
							_0024_0024593_00244118[_0024_0024592_00244117].active = true;
						}
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

		internal CalculateHealth _0024self__00244121;

		public _0024EnableAllFPS_00244113(CalculateHealth self_)
		{
			_0024self__00244121 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00244121);
		}
	}

	[Serializable]
	internal sealed class _0024EnableAll_00244122 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal GameObject _0024obj_00244123;

			internal IEnumerator _0024_0024iterator_0024311_00244124;

			internal GameObject _0024obj_00244125;

			internal int _0024_0024596_00244126;

			internal GameObject[] _0024_0024597_00244127;

			internal int _0024_0024598_00244128;

			internal CalculateHealth _0024self__00244129;

			public _0024(CalculateHealth self_)
			{
				_0024self__00244129 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (!_0024self__00244129.photonView.isMine || _0024self__00244129.aimanager.isAI)
					{
						result = (Yield(2, new WaitForSeconds(0.85f)) ? 1 : 0);
						break;
					}
					goto case 2;
				case 2:
					_0024_0024iterator_0024311_00244124 = UnityRuntimeServices.GetEnumerator(_0024self__00244129.thegameobjects);
					while (_0024_0024iterator_0024311_00244124.MoveNext())
					{
						object obj = _0024_0024iterator_0024311_00244124.Current;
						if (!(obj is GameObject))
						{
							obj = RuntimeServices.Coerce(obj, typeof(GameObject));
						}
						_0024obj_00244123 = (GameObject)obj;
						_0024obj_00244123.layer = RuntimeServices.UnboxInt32(_0024self__00244129.origtags[_0024obj_00244123]);
						UnityRuntimeServices.Update(_0024_0024iterator_0024311_00244124, _0024obj_00244123);
						GameObject gameObject = _0024obj_00244123;
						object obj2 = _0024self__00244129.origtagsreal[_0024obj_00244123];
						if (!(obj2 is string))
						{
							obj2 = RuntimeServices.Coerce(obj2, typeof(string));
						}
						gameObject.tag = (string)obj2;
						UnityRuntimeServices.Update(_0024_0024iterator_0024311_00244124, _0024obj_00244123);
					}
					_0024_0024596_00244126 = 0;
					_0024_0024597_00244127 = _0024self__00244129.glowObjs;
					for (_0024_0024598_00244128 = _0024_0024597_00244127.Length; _0024_0024596_00244126 < _0024_0024598_00244128; _0024_0024596_00244126++)
					{
						if ((bool)_0024_0024597_00244127[_0024_0024596_00244126])
						{
							_0024_0024597_00244127[_0024_0024596_00244126].active = true;
						}
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

		internal CalculateHealth _0024self__00244130;

		public _0024EnableAll_00244122(CalculateHealth self_)
		{
			_0024self__00244130 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00244130);
		}
	}

	[Serializable]
	internal sealed class _0024killonallFPS_00244131 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal GameObject _0024icon_00244132;

			internal int _0024ran_00244133;

			internal SpawningScript _0024spwnsrc_00244134;

			internal Vector3 _0024pos_00244135;

			internal CalculateHealth _0024self__00244136;

			public _0024(Vector3 pos, CalculateHealth self_)
			{
				_0024pos_00244135 = pos;
				_0024self__00244136 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024icon_00244132 = new GameObject("DeathIcon");
					_0024icon_00244132.transform.position = _0024pos_00244135;
					_0024icon_00244132.tag = "DeadCars";
					_0024self__00244136.DisableAll();
					result = (Yield(2, new WaitForSeconds(4f)) ? 1 : 0);
					break;
				case 2:
					if (_0024self__00244136.aimanager.isAI)
					{
						_0024self__00244136.aimanager.isDead = false;
						_0024ran_00244133 = UnityEngine.Random.Range(0, 5);
						_0024spwnsrc_00244134 = (SpawningScript)GameObject.Find("/Spawn Point").GetComponent("SpawningScript");
						if (_0024self__00244136.teamtype == "red")
						{
							if (_0024ran_00244133 == 0)
							{
								_0024self__00244136.maincar.transform.position = _0024spwnsrc_00244134.redspawn1.transform.position;
								_0024self__00244136.maincar.transform.rotation = _0024spwnsrc_00244134.redspawn1.transform.rotation;
							}
							if (_0024ran_00244133 == 1)
							{
								_0024self__00244136.maincar.transform.position = _0024spwnsrc_00244134.redspawn2.transform.position;
								_0024self__00244136.maincar.transform.rotation = _0024spwnsrc_00244134.redspawn2.transform.rotation;
							}
							if (_0024ran_00244133 == 2)
							{
								_0024self__00244136.maincar.transform.position = _0024spwnsrc_00244134.redspawn3.transform.position;
								_0024self__00244136.maincar.transform.rotation = _0024spwnsrc_00244134.redspawn3.transform.rotation;
							}
							if (_0024ran_00244133 == 3)
							{
								_0024self__00244136.maincar.transform.position = _0024spwnsrc_00244134.redspawn4.transform.position;
								_0024self__00244136.maincar.transform.rotation = _0024spwnsrc_00244134.redspawn4.transform.rotation;
							}
							if (_0024ran_00244133 == 4)
							{
								_0024self__00244136.maincar.transform.position = _0024spwnsrc_00244134.redspawn5.transform.position;
								_0024self__00244136.maincar.transform.rotation = _0024spwnsrc_00244134.redspawn5.transform.rotation;
							}
							if (_0024ran_00244133 == 5)
							{
								_0024self__00244136.maincar.transform.position = _0024spwnsrc_00244134.redspawn6.transform.position;
								_0024self__00244136.maincar.transform.rotation = _0024spwnsrc_00244134.redspawn6.transform.rotation;
							}
						}
						else
						{
							if (_0024ran_00244133 == 0)
							{
								_0024self__00244136.maincar.transform.position = _0024spwnsrc_00244134.spawn1.transform.position;
								_0024self__00244136.maincar.transform.rotation = _0024spwnsrc_00244134.spawn1.transform.rotation;
							}
							if (_0024ran_00244133 == 1)
							{
								_0024self__00244136.maincar.transform.position = _0024spwnsrc_00244134.spawn2.transform.position;
								_0024self__00244136.maincar.transform.rotation = _0024spwnsrc_00244134.spawn2.transform.rotation;
							}
							if (_0024ran_00244133 == 2)
							{
								_0024self__00244136.maincar.transform.position = _0024spwnsrc_00244134.spawn3.transform.position;
								_0024self__00244136.maincar.transform.rotation = _0024spwnsrc_00244134.spawn3.transform.rotation;
							}
							if (_0024ran_00244133 == 3)
							{
								_0024self__00244136.maincar.transform.position = _0024spwnsrc_00244134.spawn4.transform.position;
								_0024self__00244136.maincar.transform.rotation = _0024spwnsrc_00244134.spawn4.transform.rotation;
							}
							if (_0024ran_00244133 == 4)
							{
								_0024self__00244136.maincar.transform.position = _0024spwnsrc_00244134.spawn5.transform.position;
								_0024self__00244136.maincar.transform.rotation = _0024spwnsrc_00244134.spawn5.transform.rotation;
							}
							if (_0024ran_00244133 == 5)
							{
								_0024self__00244136.maincar.transform.position = _0024spwnsrc_00244134.spawn6.transform.position;
								_0024self__00244136.maincar.transform.rotation = _0024spwnsrc_00244134.spawn6.transform.rotation;
							}
						}
						_0024self__00244136.maincar.isKinematic = false;
					}
					_0024icon_00244132.AddComponent("DestroyAfter4");
					_0024icon_00244132.SendMessage("StartDestroy", 25f);
					_0024self__00244136.maincounter = 0;
					_0024self__00244136.StartCoroutine_Auto(_0024self__00244136.EnableAll());
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Vector3 _0024pos_00244137;

		internal CalculateHealth _0024self__00244138;

		public _0024killonallFPS_00244131(Vector3 pos, CalculateHealth self_)
		{
			_0024pos_00244137 = pos;
			_0024self__00244138 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024pos_00244137, _0024self__00244138);
		}
	}

	[Serializable]
	internal sealed class _0024killonall_00244139 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal GameObject _0024icon_00244140;

			internal int _0024ran_00244141;

			internal SpawningScript _0024spwnsrc_00244142;

			internal Vector3 _0024pos_00244143;

			internal CalculateHealth _0024self__00244144;

			public _0024(Vector3 pos, CalculateHealth self_)
			{
				_0024pos_00244143 = pos;
				_0024self__00244144 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__00244144.aimanager.isAI && PhotonNetwork.isMasterClient)
					{
						((PhotonView)_0024self__00244144.gameObject.GetComponent(typeof(PhotonView))).RPC("aiBlowupNetwork", PhotonTargets.All);
						_0024self__00244144.aimanager.isDead = true;
						_0024self__00244144.everyoneKillSmoke();
					}
					_0024icon_00244140 = new GameObject("DeathIcon");
					_0024icon_00244140.transform.position = _0024pos_00244143;
					_0024icon_00244140.tag = "DeadCars";
					_0024self__00244144.DisableAll();
					result = (Yield(2, new WaitForSeconds(4f)) ? 1 : 0);
					break;
				case 2:
					if (_0024self__00244144.aimanager.isAI)
					{
						_0024self__00244144.aimanager.isDead = false;
						_0024ran_00244141 = UnityEngine.Random.Range(0, 5);
						_0024spwnsrc_00244142 = (SpawningScript)GameObject.Find("/Spawn Point").GetComponent("SpawningScript");
						if (_0024self__00244144.teamtype == "red")
						{
							if (_0024ran_00244141 == 0)
							{
								_0024self__00244144.maincar.transform.position = _0024spwnsrc_00244142.redspawn1.transform.position;
								_0024self__00244144.maincar.transform.rotation = _0024spwnsrc_00244142.redspawn1.transform.rotation;
							}
							if (_0024ran_00244141 == 1)
							{
								_0024self__00244144.maincar.transform.position = _0024spwnsrc_00244142.redspawn2.transform.position;
								_0024self__00244144.maincar.transform.rotation = _0024spwnsrc_00244142.redspawn2.transform.rotation;
							}
							if (_0024ran_00244141 == 2)
							{
								_0024self__00244144.maincar.transform.position = _0024spwnsrc_00244142.redspawn3.transform.position;
								_0024self__00244144.maincar.transform.rotation = _0024spwnsrc_00244142.redspawn3.transform.rotation;
							}
							if (_0024ran_00244141 == 3)
							{
								_0024self__00244144.maincar.transform.position = _0024spwnsrc_00244142.redspawn4.transform.position;
								_0024self__00244144.maincar.transform.rotation = _0024spwnsrc_00244142.redspawn4.transform.rotation;
							}
							if (_0024ran_00244141 == 4)
							{
								_0024self__00244144.maincar.transform.position = _0024spwnsrc_00244142.redspawn5.transform.position;
								_0024self__00244144.maincar.transform.rotation = _0024spwnsrc_00244142.redspawn5.transform.rotation;
							}
							if (_0024ran_00244141 == 5)
							{
								_0024self__00244144.maincar.transform.position = _0024spwnsrc_00244142.redspawn6.transform.position;
								_0024self__00244144.maincar.transform.rotation = _0024spwnsrc_00244142.redspawn6.transform.rotation;
							}
						}
						else
						{
							if (_0024ran_00244141 == 0)
							{
								_0024self__00244144.maincar.transform.position = _0024spwnsrc_00244142.spawn1.transform.position;
								_0024self__00244144.maincar.transform.rotation = _0024spwnsrc_00244142.spawn1.transform.rotation;
							}
							if (_0024ran_00244141 == 1)
							{
								_0024self__00244144.maincar.transform.position = _0024spwnsrc_00244142.spawn2.transform.position;
								_0024self__00244144.maincar.transform.rotation = _0024spwnsrc_00244142.spawn2.transform.rotation;
							}
							if (_0024ran_00244141 == 2)
							{
								_0024self__00244144.maincar.transform.position = _0024spwnsrc_00244142.spawn3.transform.position;
								_0024self__00244144.maincar.transform.rotation = _0024spwnsrc_00244142.spawn3.transform.rotation;
							}
							if (_0024ran_00244141 == 3)
							{
								_0024self__00244144.maincar.transform.position = _0024spwnsrc_00244142.spawn4.transform.position;
								_0024self__00244144.maincar.transform.rotation = _0024spwnsrc_00244142.spawn4.transform.rotation;
							}
							if (_0024ran_00244141 == 4)
							{
								_0024self__00244144.maincar.transform.position = _0024spwnsrc_00244142.spawn5.transform.position;
								_0024self__00244144.maincar.transform.rotation = _0024spwnsrc_00244142.spawn5.transform.rotation;
							}
							if (_0024ran_00244141 == 5)
							{
								_0024self__00244144.maincar.transform.position = _0024spwnsrc_00244142.spawn6.transform.position;
								_0024self__00244144.maincar.transform.rotation = _0024spwnsrc_00244142.spawn6.transform.rotation;
							}
						}
						_0024self__00244144.maincar.isKinematic = false;
					}
					_0024icon_00244140.AddComponent("DestroyAfter4");
					_0024icon_00244140.SendMessage("StartDestroy", 25f);
					_0024self__00244144.maincounter = 0;
					if ((bool)_0024self__00244144)
					{
						_0024self__00244144.StartCoroutine_Auto(_0024self__00244144.EnableAll());
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

		internal Vector3 _0024pos_00244145;

		internal CalculateHealth _0024self__00244146;

		public _0024killonall_00244139(Vector3 pos, CalculateHealth self_)
		{
			_0024pos_00244145 = pos;
			_0024self__00244146 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024pos_00244145, _0024self__00244146);
		}
	}

	[Serializable]
	internal sealed class _0024aiWin_00244147 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal string _0024aiteam_00244148;

			internal string _0024s_00244149;

			internal CalculateHealth _0024self__00244150;

			public _0024(string s, CalculateHealth self_)
			{
				_0024s_00244149 = s;
				_0024self__00244150 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					result = (Yield(2, new WaitForSeconds(UnityEngine.Random.Range(2, 5))) ? 1 : 0);
					break;
				case 2:
					_0024aiteam_00244148 = string.Empty;
					if (_0024s_00244149 == MasterServerScript.ainame)
					{
						if (SpawningScript.aiteamlist == "rbb")
						{
							_0024aiteam_00244148 = "red";
						}
						else
						{
							_0024aiteam_00244148 = "blue";
						}
					}
					if (_0024s_00244149 == MasterServerScript.ainame2)
					{
						if (SpawningScript.aiteamlist == "rbb")
						{
							_0024aiteam_00244148 = "blue";
						}
						else
						{
							_0024aiteam_00244148 = "red";
						}
					}
					if (_0024s_00244149 == MasterServerScript.ainame3)
					{
						if (SpawningScript.aiteamlist == "rbb")
						{
							_0024aiteam_00244148 = "blue";
						}
						else
						{
							_0024aiteam_00244148 = "red";
						}
					}
					GameObject.Find("/GUI/Chat").SendMessage("aiSpeaking" + ((!(_0024self__00244150.aimanager.aiteam == string.Empty)) ? _0024self__00244150.aimanager.aiteam : "red"), RuntimeServices.InvokeBinaryOperator("op_Addition", _0024s_00244149 + ": ", _0024self__00244150.winMessage[UnityEngine.Random.Range(0, _0024self__00244150.winMessage.length)]));
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal string _0024s_00244151;

		internal CalculateHealth _0024self__00244152;

		public _0024aiWin_00244147(string s, CalculateHealth self_)
		{
			_0024s_00244151 = s;
			_0024self__00244152 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024s_00244151, _0024self__00244152);
		}
	}

	[Serializable]
	internal sealed class _0024findkiller_00244153 : GenericGenerator<WWW>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WWW>, IEnumerator
		{
			internal bool _0024isalias_00244154;

			internal string _0024uname_00244155;

			internal bool _0024isownteam_00244156;

			internal int _0024randomnumber_00244157;

			internal WWW _0024rankings_00244158;

			internal int _0024actualGoldEarned_00244159;

			internal int _0024killedscore_00244160;

			internal int _0024myscore_00244161;

			internal float _0024calcscore_00244162;

			internal GameObject _0024kongobj_00244163;

			internal int _0024_0024600_00244164;

			internal string[] _0024_0024601_00244165;

			internal int _0024_0024602_00244166;

			internal string _0024u_00244167;

			internal string _0024deaduser_00244168;

			internal bool _0024team_00244169;

			internal string _0024action_00244170;

			internal CalculateHealth _0024self__00244171;

			public _0024(string u, string deaduser, bool team, string action, CalculateHealth self_)
			{
				_0024u_00244167 = u;
				_0024deaduser_00244168 = deaduser;
				_0024team_00244169 = team;
				_0024action_00244170 = action;
				_0024self__00244171 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (UnityEngine.Random.Range(0, 4) == 0 && PhotonNetwork.isMasterClient)
					{
						if (_0024u_00244167 == MasterServerScript.ainame)
						{
							_0024self__00244171.StartCoroutine_Auto(_0024self__00244171.aiWin(MasterServerScript.ainame));
						}
						if (_0024u_00244167 == MasterServerScript.ainame2)
						{
							_0024self__00244171.StartCoroutine_Auto(_0024self__00244171.aiWin(MasterServerScript.ainame2));
						}
						if (_0024u_00244167 == MasterServerScript.ainame3)
						{
							_0024self__00244171.StartCoroutine_Auto(_0024self__00244171.aiWin(MasterServerScript.ainame3));
						}
					}
					_0024isalias_00244154 = false;
					_0024_0024600_00244164 = 0;
					_0024_0024601_00244165 = PlayerPrefs.GetString("alias", string.Empty).Split("|"[0]);
					for (_0024_0024602_00244166 = _0024_0024601_00244165.Length; _0024_0024600_00244164 < _0024_0024602_00244166; _0024_0024600_00244164++)
					{
						if (_0024_0024601_00244165[_0024_0024600_00244164] == _0024deaduser_00244168 && AuthGameObject.username != "CarbonTech")
						{
							_0024isalias_00244154 = true;
						}
					}
					if (AuthGameObject.username == _0024u_00244167 && !_0024isalias_00244154)
					{
						killstreak++;
					}
					_0024isownteam_00244156 = false;
					if (AuthGameObject.gametype != "Deathmatch" && AuthGameObject.gametype != "Freeplay" && AuthGameObject.gametype != "Survival")
					{
						if (SpawningScript.team2 == "red" && !_0024team_00244169)
						{
							_0024isownteam_00244156 = true;
						}
						if (SpawningScript.team2 == "blue" && _0024team_00244169)
						{
							_0024isownteam_00244156 = true;
						}
					}
					if (AuthGameObject.username == _0024u_00244167 && _0024isownteam_00244156)
					{
						GameObject.Find("/AuthGameObject").SendMessage("gotAch", "Accidents Happen");
					}
					if ((_0024deaduser_00244168 == MasterServerScript.ainame || _0024deaduser_00244168 == MasterServerScript.ainame2 || _0024deaduser_00244168 == MasterServerScript.ainame3) && PhotonNetwork.isMasterClient)
					{
						((PhotonView)_0024self__00244171.gameObject.GetComponent(typeof(PhotonView))).RPC("dropWeapon", PhotonTargets.All, (_0024self__00244171.aimanager.firetype != 0) ? "laser" : "rocket", _0024self__00244171.transform.position, _0024self__00244171.aimanager.aiteam, PhotonNetwork.AllocateViewID());
					}
					if ((_0024u_00244167 == MasterServerScript.ainame || _0024u_00244167 == MasterServerScript.ainame2 || _0024u_00244167 == MasterServerScript.ainame3) && PhotonNetwork.isMasterClient && !_0024deaduser_00244168.Contains("guest_"))
					{
						_0024randomnumber_00244157 = UnityEngine.Random.Range(0, 99999);
						_0024rankings_00244158 = new WWW("http://72.14.184.180/rankingsManager.php?request=submit&key=" + Md5Sum.ComputeMd5(global::DontDestroyOnLoad.hitcollider + _0024randomnumber_00244157.ToString()) + "&user=" + _0024deaduser_00244168 + "&score=" + (-3).ToString() + "&random=" + _0024randomnumber_00244157.ToString());
						result = (Yield(2, _0024rankings_00244158) ? 1 : 0);
						break;
					}
					goto case 2;
				case 2:
					if (AuthGameObject.username == _0024u_00244167 && !AuthGameObject.username.Contains("guest_") && !_0024isalias_00244154 && AuthGameObject.gametype != "Freeplay")
					{
						roundkills++;
						((PhotonView)GameObject.Find("/GUI/Chat").GetComponent(typeof(PhotonView))).RPC("gotKill", PhotonTargets.All, true, AuthGameObject.username);
						if (AuthGameObject.shop)
						{
							_0024actualGoldEarned_00244159 = 0;
							if (!_0024isownteam_00244156)
							{
								goldearned = ((float)UnityBuiltins.parseInt(_0024self__00244171.returnGold()) + Mathf.Round(20f + 10f * bonus)).ToString();
								goldearned = _0024self__00244171.returnGoldEncrypted();
								_0024actualGoldEarned_00244159 = (int)((float)_0024actualGoldEarned_00244159 + Mathf.Round(20f + 10f * bonus * (float)((!RefreshMasterServer.isunderdog) ? 1 : 2)));
								bonus = Mathf.Clamp(bonus + 0.3f, 0.5f, 2f);
							}
							else
							{
								bonus = Mathf.Clamp(bonus - 0.2f, 0.5f, 2f);
							}
							_0024randomnumber_00244157 = UnityEngine.Random.Range(0, 99999);
							_0024rankings_00244158 = new WWW("http://72.14.184.180/rankingsManager.php?request=returnspecific&key=" + Md5Sum.ComputeMd5(global::DontDestroyOnLoad.hitcollider + _0024randomnumber_00244157.ToString()) + "&random=" + _0024randomnumber_00244157.ToString() + "&user=" + _0024deaduser_00244168);
							result = (Yield(3, _0024rankings_00244158) ? 1 : 0);
							break;
						}
						goto case 6;
					}
					goto IL_0991;
				case 3:
					_0024killedscore_00244160 = 500;
					_0024myscore_00244161 = 500;
					if (string.IsNullOrEmpty(_0024rankings_00244158.error))
					{
						_0024killedscore_00244160 = UnityBuiltins.parseInt(_0024rankings_00244158.text);
					}
					_0024rankings_00244158 = new WWW("http://72.14.184.180/rankingsManager.php?request=returnspecific&key=" + Md5Sum.ComputeMd5(global::DontDestroyOnLoad.hitcollider + _0024randomnumber_00244157.ToString()) + "&random=" + _0024randomnumber_00244157.ToString() + "&user=" + AuthGameObject.username);
					result = (Yield(4, _0024rankings_00244158) ? 1 : 0);
					break;
				case 4:
					if (string.IsNullOrEmpty(_0024rankings_00244158.error))
					{
						_0024myscore_00244161 = UnityBuiltins.parseInt(_0024rankings_00244158.text);
					}
					_0024randomnumber_00244157 = UnityEngine.Random.Range(0, 99999);
					_0024calcscore_00244162 = ((_0024killedscore_00244160 > _0024myscore_00244161) ? Mathf.Round(5f + (float)(_0024killedscore_00244160 - _0024myscore_00244161) / Mathf.Sqrt((float)(_0024killedscore_00244160 - _0024myscore_00244161) * 1f)) : 3f) * ((!_0024isownteam_00244156) ? 1f : (-1f));
					if (!_0024isownteam_00244156)
					{
						goldearned = ((float)UnityBuiltins.parseInt(_0024self__00244171.returnGold()) + Mathf.Round(_0024calcscore_00244162 - 2f)).ToString();
						_0024actualGoldEarned_00244159 = (int)((float)_0024actualGoldEarned_00244159 + Mathf.Round(_0024calcscore_00244162 - 2f));
						goldearned = _0024self__00244171.returnGoldEncrypted();
					}
					totalXPEarned = (int)((float)totalXPEarned + _0024calcscore_00244162);
					if (!_0024isownteam_00244156)
					{
						totalCKills++;
					}
					_0024rankings_00244158 = new WWW("http://72.14.184.180/rankingsManager.php?request=submit&key=" + Md5Sum.ComputeMd5(global::DontDestroyOnLoad.hitcollider + _0024randomnumber_00244157.ToString()) + "&user=" + AuthGameObject.username + "&score=" + _0024calcscore_00244162.ToString() + "&random=" + _0024randomnumber_00244157.ToString());
					result = (Yield(5, _0024rankings_00244158) ? 1 : 0);
					break;
				case 5:
					if (!_0024deaduser_00244168.Contains("guest_") && !_0024isownteam_00244156)
					{
						_0024randomnumber_00244157 = UnityEngine.Random.Range(0, 99999);
						_0024rankings_00244158 = new WWW("http://72.14.184.180/rankingsManager.php?request=submit&key=" + Md5Sum.ComputeMd5(global::DontDestroyOnLoad.hitcollider + _0024randomnumber_00244157.ToString()) + "&user=" + _0024deaduser_00244168 + "&score=" + (-0.5f * _0024calcscore_00244162).ToString() + "&random=" + _0024randomnumber_00244157.ToString());
						result = (Yield(6, _0024rankings_00244158) ? 1 : 0);
						break;
					}
					goto case 6;
				case 6:
					if (Application.isWebPlayer)
					{
						_0024kongobj_00244163 = GameObject.Find("KongregateAPI");
						((KongregateAPI)_0024kongobj_00244163.GetComponent(typeof(KongregateAPI))).SubmitStat("TotalKillsEver", 1);
					}
					goto IL_0991;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0991:
					if (AuthGameObject.username == _0024u_00244167 && AuthGameObject.username != _0024deaduser_00244168)
					{
						GameObject.Find("/GUI/SubMessage").SendMessage("setMessage", "You " + _0024action_00244170 + " " + _0024deaduser_00244168 + ((!_0024isownteam_00244156) ? string.Empty : " (your own teammate)") + "!" + ((_0024calcscore_00244162 == 0f) ? string.Empty : ("\n+" + _0024actualGoldEarned_00244159.ToString() + " credits  " + ((_0024calcscore_00244162 <= 0f) ? string.Empty : "+") + _0024calcscore_00244162.ToString() + " XP")));
					}
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal string _0024u_00244172;

		internal string _0024deaduser_00244173;

		internal bool _0024team_00244174;

		internal string _0024action_00244175;

		internal CalculateHealth _0024self__00244176;

		public _0024findkiller_00244153(string u, string deaduser, bool team, string action, CalculateHealth self_)
		{
			_0024u_00244172 = u;
			_0024deaduser_00244173 = deaduser;
			_0024team_00244174 = team;
			_0024action_00244175 = action;
			_0024self__00244176 = self_;
		}

		public override IEnumerator<WWW> GetEnumerator()
		{
			return new _0024(_0024u_00244172, _0024deaduser_00244173, _0024team_00244174, _0024action_00244175, _0024self__00244176);
		}
	}

	private float currenthealth;

	private bool updatehealth;

	[NonSerialized]
	public static float healthstat = 100f;

	[NonSerialized]
	public static float armorHealth = 1f;

	public GameObject healthGUI;

	public GameObject chatGUI;

	public GameObject tchooseGUI;

	public Rigidbody maincar;

	public string username;

	public GameObject carnameobj;

	public GameObject serialize;

	public AuthGameObject authgameobject;

	public SpawningScript spwnsrc;

	public RefreshMasterServer refreshmserver;

	public MasterServerScript mserver;

	public FireGun firegun;

	public AudioController acon;

	public HealthBar hbar;

	public PreloaderExplosion pex;

	private TutorialManager tMan;

	private ChatScript cscript;

	public ConduitInputReciever cInput;

	public ParticleEmitter healthglow;

	private bool hardhit;

	public CTFFlagSender ctf;

	[NonSerialized]
	public static int roundkills;

	[NonSerialized]
	public static int rounddeaths;

	public InGameScores igs;

	public ParticleEmitter enginesmoke;

	private bool reseteffects;

	private Hashtable origtags;

	private Hashtable origtagsreal;

	private UnityScript.Lang.Array thegameobjects;

	private int maincounter;

	[NonSerialized]
	public static string goldearned = "a";

	[NonSerialized]
	public static float bonus = 1f;

	private string keyGen;

	private string storeInterface;

	public GUIStyle creditsstyle;

	public Texture tex;

	private Hashtable killedby;

	private UnityScript.Lang.Array killerarr;

	public DontDestroyOnLoad ddol;

	[NonSerialized]
	public static bool isafking;

	private float isafkingtimer;

	[NonSerialized]
	public static int killstreak;

	public GameObject shieldobject;

	private bool isburning;

	private float burntimeleft;

	private string curBurnner;

	public ParticleEmitter burnflames;

	public AIManager aimanager;

	public GameObject explosion;

	public string teamtype;

	public GameObject weaponDropPrefab;

	public GameObject goldPrefab;

	private SerializePlayersHealth seriObj;

	private UnityScript.Lang.Array dead;

	private UnityScript.Lang.Array winMessage;

	public GameObject[] glowObjs;

	[NonSerialized]
	public static float jetFuel = 1f;

	[NonSerialized]
	public static bool stallGlider;

	[NonSerialized]
	public static int totalXPEarned;

	[NonSerialized]
	public static int totalCKills;

	private DamageDisplay damageDisplay;

	public CalculateHealth()
	{
		currenthealth = 100f;
		username = string.Empty;
		reseteffects = true;
		thegameobjects = new UnityScript.Lang.Array();
		keyGen = "http://72.14.184.180/serverKeyGen.php?";
		storeInterface = "http://72.14.184.180/storeInterface.php?";
		killerarr = new UnityScript.Lang.Array();
		isafkingtimer = 60f;
		burntimeleft = 15f;
		curBurnner = string.Empty;
		dead = new UnityScript.Lang.Array("ow", "grr", "darn", "argh!", "nice shot", "good shot", "nice hit", "good hit", "mmph", "oof", "I'll get you next time", ":(", "D:", ":O", ":[");
		winMessage = new UnityScript.Lang.Array("haha", "pwned", "hehe", "heh", "gotcha", "boom!", "boom", "kaboom", ">:)", "die", "DIE", "lol", "i win", "I win", ":D", ":)", ">:D", ":]");
	}

	public virtual void AddAllGameObjects(Transform t)
	{
		bool flag = false;
		IEnumerator enumerator = UnityRuntimeServices.GetEnumerator(thegameobjects);
		while (enumerator.MoveNext())
		{
			object obj = enumerator.Current;
			if (!(obj is GameObject))
			{
				obj = RuntimeServices.Coerce(obj, typeof(GameObject));
			}
			GameObject gameObject = (GameObject)obj;
			if (gameObject == t.gameObject)
			{
				flag = true;
			}
		}
		if (flag)
		{
			return;
		}
		thegameobjects.Add(t.gameObject);
		origtags.Add(t.gameObject, t.gameObject.layer);
		IEnumerator enumerator2 = UnityRuntimeServices.GetEnumerator(t);
		while (enumerator2.MoveNext())
		{
			object obj2 = enumerator2.Current;
			if (!(obj2 is Transform))
			{
				obj2 = RuntimeServices.Coerce(obj2, typeof(Transform));
			}
			Transform transform = (Transform)obj2;
			AddAllGameObjects(transform);
			UnityRuntimeServices.Update(enumerator2, transform);
		}
		origtagsreal.Add(t.gameObject, t.gameObject.tag);
	}

	[RPC]
	public virtual void startBurn()
	{
		isburning = true;
		burntimeleft = 15f;
	}

	[RPC]
	public virtual void stopBurn()
	{
		isburning = false;
		burntimeleft = 15f;
	}

	public virtual void OnGUI()
	{
		if (!AudioController.hideGUI && !aimanager.isAI && AuthGameObject.gametype != "Freeplay")
		{
			GUI.depth = -4;
			if (photonView.isMine && AuthGameObject.shop)
			{
				GUI.BeginGroup(new Rect(Screen.width - 186, 150f, 187f, 71f));
				GUI.Box(new Rect(0f, 0f, 187f, 71f), "Credits Earned: " + returnGold() + "\nStreak Bonus: " + bonus + "x", creditsstyle);
				GUI.DrawTexture(new Rect(40f, 28f, 20f, 15f), tex);
				GUI.EndGroup();
			}
		}
	}

	public virtual void resetforround()
	{
		if (Application.isWebPlayer && PreloaderExplosion.isKong)
		{
			GameObject gameObject = GameObject.Find("KongregateAPI");
			((KongregateAPI)gameObject.GetComponent(typeof(KongregateAPI))).SubmitStat("MostKillsOneRound", roundkills);
			((KongregateAPI)gameObject.GetComponent(typeof(KongregateAPI))).SubmitStat("MostDeathsOneRound", rounddeaths);
		}
		roundkills = 0;
		rounddeaths = 0;
	}

	public virtual void hardimpact(object i)
	{
		if ((!photonView.isMine && !aimanager.isAI) || (!ChatScript.isCar && !aimanager.isAI) || currenthealth == 0f || (isafking && !aimanager.isAI) || (!aimanager.isAI && !RuntimeServices.EqualityOperator(i, 6025) && FireGun.isInvincible))
		{
			return;
		}
		if (RuntimeServices.EqualityOperator(i, 6025))
		{
			currenthealth = 0f;
			GameObject.Find("/GUI/HealthDisplay").SendMessage("killerusername", "YOU");
		}
		else if (!AuthGameObject.showTutorial && AuthGameObject.cDam)
		{
			currenthealth = RuntimeServices.UnboxSingle(RuntimeServices.InvokeBinaryOperator("op_Subtraction", currenthealth, (!aimanager.isAI || TutorialManager.curTutIndex >= 7 || !AuthGameObject.showTutorial) ? RuntimeServices.InvokeBinaryOperator("op_Multiply", i, 0.0085f) : ((object)1)));
		}
		if (!(currenthealth > 0f))
		{
			currenthealth = 0f;
			if (!RuntimeServices.EqualityOperator(i, 6025))
			{
				chatGUI.SendMessage("OutsideSystem", username + " crashed his car!");
				GameObject.Find("/GUI/HealthDisplay").SendMessage("killerusername", "YOU");
			}
			rounddeaths++;
			if (Application.isWebPlayer)
			{
				GameObject gameObject = GameObject.Find("KongregateAPI");
				((KongregateAPI)gameObject.GetComponent(typeof(KongregateAPI))).SubmitStat("TotalDeathsEver", 1);
			}
			if (CTFFlagSender.gotflag && !RuntimeServices.EqualityOperator(i, 6025) && AuthGameObject.gametype == "Capture the Flag")
			{
				this.gameObject.SendMessage("setctf", false);
				this.gameObject.SendMessage("dropflagdel", maincar.transform.position);
				chatGUI.SendMessage("OutsideSystem", username + " dropped the flag.");
			}
		}
		else
		{
			if (!aimanager.isAI && !(currenthealth > 15f))
			{
				GameObject.Find("HealthEffect").SendMessage("FadeAt", 65f);
				reseteffects = true;
			}
			((PhotonView)this.gameObject.GetComponent(typeof(PhotonView))).RPC("setsmoke", PhotonTargets.All, currenthealth);
		}
		updatehealth = true;
	}

	public virtual void forcehealth(float h)
	{
		currenthealth = h;
		updatehealth = true;
	}

	public virtual void resethealth()
	{
		currenthealth = 100f;
		armorHealth = 1f;
		if (!aimanager.isAI)
		{
			GameObject.Find("HealthEffect").SendMessage("FadeTo", (100f - currenthealth) / 1.3f);
		}
		((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("setsmoke", PhotonTargets.All, currenthealth);
		((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("stopBurn", PhotonTargets.All);
		updatehealth = true;
		killerarr.Clear();
		killedby.Clear();
	}

	public virtual IEnumerator HealthUp(int i)
	{
		return new _0024HealthUp_00244093(i, this).GetEnumerator();
	}

	public virtual void RegenHealth(int i)
	{
		if (!photonView.isMine && !aimanager.isAI)
		{
			return;
		}
		if (!((float)i + currenthealth <= 100f))
		{
			currenthealth = 100f;
		}
		else
		{
			currenthealth += i;
		}
		if (!(currenthealth <= 15f))
		{
			if (!aimanager.isAI)
			{
				GameObject.Find("HealthEffect").SendMessage("setnfo");
				GameObject.Find("HealthEffect").SendMessage("Fadeout");
			}
			reseteffects = false;
		}
		((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("setsmoke", PhotonTargets.All, currenthealth);
		updatehealth = true;
	}

	public virtual IEnumerator Start()
	{
		return new _0024Start_00244099(this).GetEnumerator();
	}

	[RPC]
	public virtual void addIdle(int i)
	{
		if (i == 0)
		{
			carnameobj.name += " (Idle)";
		}
		if (i == 1)
		{
			carnameobj.name = carnameobj.name.Replace(" (Idle)", string.Empty);
		}
	}

	public virtual void Update()
	{
		if (!(burntimeleft <= 0f) && isburning && !(maincar.transform.position.y <= 7.2f) && !maincar.rigidbody.isKinematic)
		{
			if (!burnflames.emit)
			{
				burnflames.emit = true;
			}
			burntimeleft -= Time.deltaTime;
			if (photonView.isMine || aimanager.isAI)
			{
				burnHit(curBurnner);
			}
		}
		else
		{
			burntimeleft = 15f;
			isburning = false;
			if (burnflames.emit)
			{
				burnflames.emit = false;
			}
		}
		if (photonView.isMine && !aimanager.isAI)
		{
			healthstat = currenthealth;
			if (Input.GetAxis("Horizontal") != 0f || Input.GetAxis("Vertical") != 0f || Input.GetKeyDown("m") || Input.GetButtonDown("Fire1") || RuntimeServices.ToBool(RuntimeServices.InvokeBinaryOperator("op_GreaterThan", RuntimeServices.Invoke(typeof(Mathf), "Abs", new object[1] { UnityRuntimeServices.GetProperty(ConduitInputReciever.ht["dPad"], "y") }), 0)) || RuntimeServices.ToBool(RuntimeServices.InvokeBinaryOperator("op_GreaterThan", RuntimeServices.Invoke(typeof(Mathf), "Abs", new object[1] { UnityRuntimeServices.GetProperty(ConduitInputReciever.ht["dPad"], "x") }), 0)) || RuntimeServices.ToBool(ConduitInputReciever.ht["tPadState"]))
			{
				if (isafking)
				{
					((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("addIdle", PhotonTargets.All, 1);
				}
				isafkingtimer = 60f;
				isafking = false;
			}
			else if (!(isafkingtimer <= 0f))
			{
				isafkingtimer -= Time.deltaTime;
			}
			else
			{
				isafkingtimer = 0f;
				if ((!isafking || aimanager.isAI) && (aimanager.isAI || !FireGun.isInvincible))
				{
					((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("addIdle", PhotonTargets.All, 0);
				}
				isafking = true;
			}
			if (InGameScores.resethealthscript)
			{
				resetforround();
			}
			if (updatehealth)
			{
				updatehealth = false;
				if (!(currenthealth <= 100f))
				{
					currenthealth = 100f;
				}
				healthGUI.SendMessage("updatehealth", currenthealth);
				serialize.SendMessage("updatehealth", currenthealth);
				if (!(currenthealth > 0f))
				{
					if (photonView.isMine && !aimanager.isAI)
					{
						string empty = string.Empty;
						empty = ((!(FireGun.guntype == "rocket")) ? ChatScript.secondaryweapon : ChatScript.primaryweapon);
						((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("dropWeapon", PhotonTargets.All, empty, transform.position, SpawningScript.team2, PhotonNetwork.AllocateViewID());
					}
					currenthealth = 0f;
					bonus = 1f;
					if (!aimanager.isAI)
					{
						tchooseGUI.SendMessage("addvictim", username);
					}
					StartCoroutine_Auto(delayregen());
				}
			}
			if (!(currenthealth < 100f) && reseteffects)
			{
				reseteffects = false;
				if (!aimanager.isAI)
				{
					GameObject.Find("HealthEffect").SendMessage("setnfo");
					GameObject.Find("HealthEffect").SendMessage("Fadeout");
				}
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("setsmoke", PhotonTargets.All, 100f);
			}
		}
		if (!aimanager.isAI || !updatehealth)
		{
			return;
		}
		updatehealth = false;
		seriObj.updatehealth(currenthealth);
		if (!(currenthealth > 0f))
		{
			currenthealth = 0f;
			tchooseGUI.SendMessage("addvictim", username);
			if (UnityEngine.Random.Range(0, 4) == 1)
			{
				StartCoroutine_Auto(sayDead());
			}
			StartCoroutine_Auto(delayregen());
		}
	}

	public virtual void Awake()
	{
		totalXPEarned = 0;
		totalCKills = 0;
		seriObj = (SerializePlayersHealth)serialize.GetComponent(typeof(SerializePlayersHealth));
		damageDisplay = (DamageDisplay)GameObject.Find("/DamageDisplay").GetComponent(typeof(DamageDisplay));
	}

	public virtual IEnumerator sayDead()
	{
		return new _0024sayDead_00244102(this).GetEnumerator();
	}

	public virtual void everyoneKillSmoke()
	{
		((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("setsmoke", PhotonTargets.All, 100f);
	}

	[RPC]
	public virtual void dropGold(int num, Vector3 pos)
	{
		for (int i = 0; i < num; i++)
		{
			UnityEngine.Object.Instantiate(goldPrefab, pos, Quaternion.identity);
		}
	}

	public virtual void delayregenFPSQuick(Vector3 pos)
	{
		currenthealth = 100f;
		updatehealth = true;
	}

	public virtual IEnumerator delayregenFPS(Vector3 pos)
	{
		return new _0024delayregenFPS_00244105(pos, this).GetEnumerator();
	}

	public virtual IEnumerator delayregen()
	{
		return new _0024delayregen_00244110(this).GetEnumerator();
	}

	public virtual void DisableAll()
	{
		int num = 0;
		IEnumerator enumerator = UnityRuntimeServices.GetEnumerator(thegameobjects);
		while (enumerator.MoveNext())
		{
			object obj = enumerator.Current;
			if (!(obj is GameObject))
			{
				obj = RuntimeServices.Coerce(obj, typeof(GameObject));
			}
			GameObject gameObject = (GameObject)obj;
			if ((bool)gameObject)
			{
				gameObject.layer = 16;
				UnityRuntimeServices.Update(enumerator, gameObject);
				gameObject.tag = "minimap";
				UnityRuntimeServices.Update(enumerator, gameObject);
			}
			else
			{
				thegameobjects.RemoveAt(num);
			}
			num++;
		}
		int i = 0;
		GameObject[] array = glowObjs;
		for (int length = array.Length; i < length; i++)
		{
			if ((bool)array[i])
			{
				array[i].active = false;
			}
		}
	}

	[RPC]
	public virtual IEnumerator EnableAllFPS()
	{
		return new _0024EnableAllFPS_00244113(this).GetEnumerator();
	}

	[RPC]
	public virtual IEnumerator EnableAll()
	{
		return new _0024EnableAll_00244122(this).GetEnumerator();
	}

	[RPC]
	public virtual void aiBlowupNetwork()
	{
		UnityEngine.Object.Instantiate(explosion, transform.position, transform.rotation);
	}

	[RPC]
	public virtual IEnumerator killonallFPS(Vector3 pos)
	{
		return new _0024killonallFPS_00244131(pos, this).GetEnumerator();
	}

	[RPC]
	public virtual IEnumerator killonall(Vector3 pos)
	{
		return new _0024killonall_00244139(pos, this).GetEnumerator();
	}

	public virtual void externaldrop()
	{
		if (CTFFlagSender.gotflag && AuthGameObject.gametype == "Capture the Flag" && !aimanager.isAI && !aimanager.isAI)
		{
			gameObject.SendMessage("setctf", false);
			gameObject.SendMessage("dropflagdel", maincar.transform.position);
			chatGUI.SendMessage("OutsideSystem", username + " dropped the flag.");
		}
	}

	public virtual void explosionHit(string u)
	{
		string[] array = u.Split("|"[0]);
		gameObject.SendMessage("flash");
		if ((!photonView.isMine && !aimanager.isAI) || (!ChatScript.isCar && !aimanager.isAI) || currenthealth == 0f || (isafking && !aimanager.isAI) || (!aimanager.isAI && FireGun.isInvincible))
		{
			return;
		}
		float num = 0f;
		if (shieldobject.active)
		{
			shieldobject.SendMessage("takeDamage", UnityBuiltins.parseInt(array[1]));
		}
		if ((ChatScript.hasarmor1 && !aimanager.isAI) || (aimanager.isAI && aimanager.armorLevel == 0))
		{
			num += 0.1f + UnityBuiltins.parseFloat(ChatScript.levels[2]) / 300f;
		}
		if ((ChatScript.hasarmor2 && !aimanager.isAI) || (aimanager.isAI && aimanager.armorLevel == 1))
		{
			num += 0.2f + UnityBuiltins.parseFloat(ChatScript.levels[2]) / 300f;
		}
		if ((ChatScript.hasarmor3 && !aimanager.isAI) || (aimanager.isAI && aimanager.armorLevel == 2))
		{
			num += 0.45f + UnityBuiltins.parseFloat(ChatScript.levels[2]) / 300f;
		}
		if ((ChatScript.hasarmor4 && !aimanager.isAI) || (aimanager.isAI && aimanager.armorLevel == 3))
		{
			num += 0.65f + UnityBuiltins.parseFloat(ChatScript.levels[2]) / 300f;
		}
		if ((ChatScript.hasarmor5 && !aimanager.isAI) || (ChatScript.hasarmor6 && !aimanager.isAI) || (aimanager.isAI && aimanager.armorLevel == 4))
		{
			num += 0.35f + UnityBuiltins.parseFloat(ChatScript.levels[2]) / 300f;
		}
		if (ChatScript.hasarmor7 && !aimanager.isAI)
		{
			num += 0.2f + UnityBuiltins.parseFloat(ChatScript.levels[2]) / 300f;
		}
		if (ChatScript.hasarmor8 && !aimanager.isAI)
		{
			num += 0.3f + UnityBuiltins.parseFloat(ChatScript.levels[2]) / 300f;
		}
		if (!ChatScript.hasgtrcar || !aimanager.isAI)
		{
		}
		if (!(num <= 1f))
		{
			num = 1f;
		}
		if (FireGun.grappling)
		{
			FireGun.grappling = false;
			FireGun.stopgrapple = true;
		}
		float num2 = currenthealth;
		currenthealth -= Mathf.Abs((!aimanager.isAI || TutorialManager.curTutIndex >= 7 || !AuthGameObject.showTutorial) ? (((UnityScript.Lang.Extensions.get_length((System.Array)u.Split("|"[0])) <= 2) ? 1f : UnityBuiltins.parseFloat(u.Split("|"[0])[2])) * Mathf.Round(UnityBuiltins.parseFloat(array[1])) * (1f - Mathf.Min(num * armorHealth + ((!shieldobject.active) ? 0f : 0.85f), 1f))) : 1f);
		PhotonPlayer photonPlayer = usernameToPlayer(array[0]);
		if (photonPlayer != null)
		{
			((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("hD", photonPlayer, Mathf.RoundToInt(num2 - currenthealth));
		}
		stallGlider = true;
		if (!aimanager.isAI)
		{
			if (ChatScript.hasarmor1 || ChatScript.hasarmor2 || ChatScript.hasarmor3 || ChatScript.hasarmor4 || ChatScript.hasarmor5 || ChatScript.hasarmor6 || ChatScript.hasarmor7 || ChatScript.hasarmor8)
			{
				armorHealth -= Mathf.Round(UnityBuiltins.parseFloat(array[1])) * (1f - num) / 1.5f / 100f;
				armorHealth = Mathf.Max(0f, armorHealth);
			}
			else
			{
				armorHealth = 1f;
			}
		}
		if (!(currenthealth > 0f))
		{
			if ((!isafking || aimanager.isAI) && (aimanager.isAI || !FireGun.isInvincible))
			{
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("findkiller", PhotonTargets.All, array[0], (!aimanager.isAI) ? AuthGameObject.username : aimanager.ainame, (!aimanager.isAI) ? ((!(SpawningScript.team2 == "red")) ? true : false) : ((!(aimanager.aiteam == "red")) ? true : false), "fragged");
			}
			if (!aimanager.isAI)
			{
				GameObject.Find("HealthEffect").SendMessage("setnfo");
				GameObject.Find("HealthEffect").SendMessage("Fadeout");
			}
			else
			{
				GameObject.Find("/GUI/HealthDisplay").SendMessage("aiDeath", aimanager.aiteam);
			}
			currenthealth = 0f;
			if (AuthGameObject.username == array[0] || aimanager.ainame == array[0])
			{
				chatGUI.SendMessage("OutsideSystem", username + " killed himself!");
				GameObject.Find("/GUI/HealthDisplay").SendMessage("killerusername", "YOU");
			}
			else
			{
				chatGUI.SendMessage("OutsideSystem", array[0] + " fragged " + username + "!");
				GameObject.Find("/GUI/HealthDisplay").SendMessage("killerusername", array[0] + " (explosion damage)");
			}
			if (CTFFlagSender.gotflag && AuthGameObject.gametype == "Capture the Flag" && !aimanager.isAI)
			{
				gameObject.SendMessage("setctf", false);
				gameObject.SendMessage("dropflagdel", maincar.transform.position);
				chatGUI.SendMessage("OutsideSystem", username + " dropped the flag.");
			}
			if ((!isafking || aimanager.isAI) && (aimanager.isAI || !FireGun.isInvincible))
			{
				tchooseGUI.SendMessage("addkiller", array[0]);
			}
			rounddeaths++;
			updatehealth = true;
			maincar.isKinematic = true;
			if (AuthGameObject.username != array[0])
			{
				IEnumerator enumerator = UnityRuntimeServices.GetEnumerator(killerarr);
				while (enumerator.MoveNext())
				{
					object obj = enumerator.Current;
					if (!(obj is string))
					{
						obj = RuntimeServices.Coerce(obj, typeof(string));
					}
					string text = (string)obj;
					if (text != array[0] && (!isafking || aimanager.isAI) && !aimanager.isAI && FireGun.isInvincible)
					{
					}
				}
				killerarr.Clear();
				killedby.Clear();
			}
		}
		else
		{
			if (AuthGameObject.username != array[0])
			{
				if (!killedby.ContainsKey(array[0]))
				{
					killedby.Add(array[0], UnityBuiltins.parseInt(array[1]));
					killerarr.Add(array[0]);
				}
				else
				{
					killedby[array[0]] = RuntimeServices.InvokeBinaryOperator("op_Addition", killedby[array[0]], UnityBuiltins.parseInt(array[1]));
				}
			}
			((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("setsmoke", PhotonTargets.All, currenthealth);
			if (!aimanager.isAI)
			{
				if (!(currenthealth > 15f))
				{
					GameObject.Find("HealthEffect").SendMessage("FadeAt", 65f);
					reseteffects = true;
				}
				else
				{
					GameObject.Find("HealthEffect").SendMessage("FadeTo", (100f - currenthealth) / 1.3f);
				}
			}
		}
		updatehealth = true;
	}

	public virtual void bladeHitLarge(string u)
	{
		string text = u.Split("|"[0])[0];
		int num = UnityBuiltins.parseInt(u.Split("|"[0])[1]);
		gameObject.SendMessage("flash");
		if ((!photonView.isMine && !aimanager.isAI) || (!ChatScript.isCar && !aimanager.isAI) || currenthealth == 0f || (isafking && !aimanager.isAI) || (!aimanager.isAI && FireGun.isInvincible) || !(text != AuthGameObject.username))
		{
			return;
		}
		float num2 = 0f;
		if (shieldobject.active)
		{
			shieldobject.SendMessage("takeDamage", UnityBuiltins.parseInt(65 + num / 2));
		}
		if ((ChatScript.hasarmor1 && !aimanager.isAI) || (aimanager.isAI && aimanager.armorLevel == 0))
		{
			num2 += 0.1f + UnityBuiltins.parseFloat(ChatScript.levels[2]) / 300f;
		}
		if ((ChatScript.hasarmor2 && !aimanager.isAI) || (aimanager.isAI && aimanager.armorLevel == 1))
		{
			num2 += 0.2f + UnityBuiltins.parseFloat(ChatScript.levels[2]) / 300f;
		}
		if ((ChatScript.hasarmor3 && !aimanager.isAI) || (aimanager.isAI && aimanager.armorLevel == 2))
		{
			num2 += 0.45f + UnityBuiltins.parseFloat(ChatScript.levels[2]) / 300f;
		}
		if ((ChatScript.hasarmor4 && !aimanager.isAI) || (aimanager.isAI && aimanager.armorLevel == 3))
		{
			num2 += 0.65f + UnityBuiltins.parseFloat(ChatScript.levels[2]) / 300f;
		}
		if ((ChatScript.hasarmor5 && !aimanager.isAI) || (ChatScript.hasarmor6 && !aimanager.isAI) || (aimanager.isAI && aimanager.armorLevel == 4))
		{
			num2 += 0.35f + UnityBuiltins.parseFloat(ChatScript.levels[2]) / 300f;
		}
		if (ChatScript.hasarmor7 && !aimanager.isAI)
		{
			num2 += 0.2f + UnityBuiltins.parseFloat(ChatScript.levels[2]) / 300f;
		}
		if (ChatScript.hasarmor8 && !aimanager.isAI)
		{
			num2 += 0.3f + UnityBuiltins.parseFloat(ChatScript.levels[2]) / 300f;
		}
		if (!ChatScript.hasgtrcar || !aimanager.isAI)
		{
		}
		if (!(num2 <= 1f))
		{
			num2 = 1f;
		}
		if (FireGun.grappling)
		{
			FireGun.grappling = false;
			FireGun.stopgrapple = true;
		}
		float num3 = UnityEngine.Random.Range((20f * Time.deltaTime + (float)(num / 2)) * (1f - Mathf.Min(num2 * armorHealth + ((!shieldobject.active) ? 0f : 0.85f), 1f)), (36f * Time.deltaTime + (float)(num / 2)) * (1f - Mathf.Min(num2 * armorHealth + ((!shieldobject.active) ? 0f : 0.85f), 1f)));
		currenthealth -= ((!aimanager.isAI || TutorialManager.curTutIndex >= 7 || !AuthGameObject.showTutorial) ? num3 : 1f);
		stallGlider = true;
		if (!aimanager.isAI)
		{
			if (ChatScript.hasarmor1 || ChatScript.hasarmor2 || ChatScript.hasarmor3 || ChatScript.hasarmor4 || ChatScript.hasarmor5 || ChatScript.hasarmor6 || ChatScript.hasarmor7 || ChatScript.hasarmor8)
			{
				armorHealth -= UnityEngine.Random.Range(20f * Time.deltaTime + (float)(num / 2), 36f * Time.deltaTime + (float)(num / 2)) * (1f - num2) / 1.5f / 100f;
				armorHealth = Mathf.Max(0f, armorHealth);
			}
			else
			{
				armorHealth = 1f;
			}
		}
		if (!(currenthealth > 0f))
		{
			if ((!isafking || aimanager.isAI) && (aimanager.isAI || !FireGun.isInvincible))
			{
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("findkiller", PhotonTargets.All, text, (!aimanager.isAI) ? AuthGameObject.username : aimanager.ainame, (!aimanager.isAI) ? ((!(SpawningScript.team2 == "red")) ? true : false) : ((!(aimanager.aiteam == "red")) ? true : false), "sliced");
			}
			if (!aimanager.isAI)
			{
				GameObject.Find("HealthEffect").SendMessage("setnfo");
				GameObject.Find("HealthEffect").SendMessage("Fadeout");
			}
			else
			{
				GameObject.Find("/GUI/HealthDisplay").SendMessage("aiDeath", aimanager.aiteam);
			}
			currenthealth = 0f;
			if (AuthGameObject.username == text || aimanager.ainame == text)
			{
				chatGUI.SendMessage("OutsideSystem", username + " killed himself!");
				GameObject.Find("/GUI/HealthDisplay").SendMessage("killerusername", "YOU");
			}
			else
			{
				chatGUI.SendMessage("OutsideSystem", text + " sliced " + username + "!");
				GameObject.Find("/GUI/HealthDisplay").SendMessage("killerusername", text + " (lvl " + num + " Melee Slicer Armor)");
			}
			if (CTFFlagSender.gotflag && AuthGameObject.gametype == "Capture the Flag" && !aimanager.isAI)
			{
				gameObject.SendMessage("setctf", false);
				gameObject.SendMessage("dropflagdel", maincar.transform.position);
				chatGUI.SendMessage("OutsideSystem", username + " dropped the flag.");
			}
			if ((!isafking || aimanager.isAI) && (aimanager.isAI || !FireGun.isInvincible))
			{
				tchooseGUI.SendMessage("addkiller", text);
			}
			rounddeaths++;
			updatehealth = true;
			maincar.isKinematic = true;
			if (AuthGameObject.username != text)
			{
				IEnumerator enumerator = UnityRuntimeServices.GetEnumerator(killerarr);
				while (enumerator.MoveNext())
				{
					object obj = enumerator.Current;
					if (!(obj is string))
					{
						obj = RuntimeServices.Coerce(obj, typeof(string));
					}
					string text2 = (string)obj;
					if (text2 != text && (!isafking || aimanager.isAI) && !aimanager.isAI && FireGun.isInvincible)
					{
					}
				}
				killerarr.Clear();
				killedby.Clear();
			}
		}
		else
		{
			if (AuthGameObject.username != text)
			{
				if (!killedby.ContainsKey(text))
				{
					killedby.Add(text, 10 + num / 2);
					killerarr.Add(text);
				}
				else
				{
					killedby[text] = RuntimeServices.InvokeBinaryOperator("op_Addition", killedby[text], 10 + num / 2);
				}
			}
			((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("setsmoke", PhotonTargets.All, currenthealth);
			if (!aimanager.isAI)
			{
				if (!(currenthealth > 15f))
				{
					GameObject.Find("HealthEffect").SendMessage("FadeAt", 65f);
					reseteffects = true;
				}
				else
				{
					GameObject.Find("HealthEffect").SendMessage("FadeTo", (100f - currenthealth) / 1.3f);
				}
			}
		}
		updatehealth = true;
	}

	public virtual void bladeHit(string u)
	{
		string text = u.Split("|"[0])[0];
		int num = UnityBuiltins.parseInt(u.Split("|"[0])[1]);
		gameObject.SendMessage("flash");
		if ((!photonView.isMine && !aimanager.isAI) || (!ChatScript.isCar && !aimanager.isAI) || currenthealth == 0f || (isafking && !aimanager.isAI) || (!aimanager.isAI && FireGun.isInvincible) || (!(text != AuthGameObject.username) && !aimanager.isAI))
		{
			return;
		}
		float num2 = 0f;
		if (shieldobject.active)
		{
			shieldobject.SendMessage("takeDamage", UnityBuiltins.parseInt(65 + num / 2));
		}
		if ((ChatScript.hasarmor1 && !aimanager.isAI) || (aimanager.isAI && aimanager.armorLevel == 0))
		{
			num2 += 0.1f + UnityBuiltins.parseFloat(ChatScript.levels[2]) / 300f;
		}
		if ((ChatScript.hasarmor2 && !aimanager.isAI) || (aimanager.isAI && aimanager.armorLevel == 1))
		{
			num2 += 0.2f + UnityBuiltins.parseFloat(ChatScript.levels[2]) / 300f;
		}
		if ((ChatScript.hasarmor3 && !aimanager.isAI) || (aimanager.isAI && aimanager.armorLevel == 2))
		{
			num2 += 0.45f + UnityBuiltins.parseFloat(ChatScript.levels[2]) / 300f;
		}
		if ((ChatScript.hasarmor4 && !aimanager.isAI) || (aimanager.isAI && aimanager.armorLevel == 3))
		{
			num2 += 0.65f + UnityBuiltins.parseFloat(ChatScript.levels[2]) / 300f;
		}
		if ((ChatScript.hasarmor5 && !aimanager.isAI) || (ChatScript.hasarmor6 && !aimanager.isAI) || (aimanager.isAI && aimanager.armorLevel == 4))
		{
			num2 += 0.35f + UnityBuiltins.parseFloat(ChatScript.levels[2]) / 300f;
		}
		if (ChatScript.hasarmor7 && !aimanager.isAI)
		{
			num2 += 0.2f + UnityBuiltins.parseFloat(ChatScript.levels[2]) / 300f;
		}
		if (ChatScript.hasarmor8 && !aimanager.isAI)
		{
			num2 += 0.3f + UnityBuiltins.parseFloat(ChatScript.levels[2]) / 300f;
		}
		if (!ChatScript.hasgtrcar || !aimanager.isAI)
		{
		}
		if (!(num2 <= 1f))
		{
			num2 = 1f;
		}
		if (FireGun.grappling)
		{
			FireGun.grappling = false;
			FireGun.stopgrapple = true;
		}
		float num3 = UnityEngine.Random.Range((10f * Time.deltaTime + (float)(num / 2)) * (1f - Mathf.Min(num2 * armorHealth + ((!shieldobject.active) ? 0f : 0.85f), 1f)), (18f * Time.deltaTime + (float)(num / 2)) * (1f - Mathf.Min(num2 * armorHealth + ((!shieldobject.active) ? 0f : 0.85f), 1f)));
		currenthealth -= ((!aimanager.isAI || TutorialManager.curTutIndex >= 7 || !AuthGameObject.showTutorial) ? num3 : 1f);
		stallGlider = true;
		if (!aimanager.isAI)
		{
			if (ChatScript.hasarmor1 || ChatScript.hasarmor2 || ChatScript.hasarmor3 || ChatScript.hasarmor4 || ChatScript.hasarmor5 || ChatScript.hasarmor6 || ChatScript.hasarmor7 || ChatScript.hasarmor8)
			{
				armorHealth -= UnityEngine.Random.Range(10f * Time.deltaTime + (float)(num / 2), 18f * Time.deltaTime + (float)(num / 2)) * (1f - num2) / 1.5f / 100f;
				armorHealth = Mathf.Max(0f, armorHealth);
			}
			else
			{
				armorHealth = 1f;
			}
		}
		if (!(currenthealth > 0f))
		{
			if ((!isafking || aimanager.isAI) && (aimanager.isAI || !FireGun.isInvincible))
			{
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("findkiller", PhotonTargets.All, text, (!aimanager.isAI) ? AuthGameObject.username : aimanager.ainame, (!aimanager.isAI) ? ((!(SpawningScript.team2 == "red")) ? true : false) : ((!(aimanager.aiteam == "red")) ? true : false), "sliced");
			}
			if (!aimanager.isAI)
			{
				GameObject.Find("HealthEffect").SendMessage("setnfo");
				GameObject.Find("HealthEffect").SendMessage("Fadeout");
			}
			else
			{
				GameObject.Find("/GUI/HealthDisplay").SendMessage("aiDeath", aimanager.aiteam);
			}
			currenthealth = 0f;
			if (AuthGameObject.username == text || aimanager.ainame == text)
			{
				chatGUI.SendMessage("OutsideSystem", username + " killed himself!");
				GameObject.Find("/GUI/HealthDisplay").SendMessage("killerusername", "YOU");
			}
			else
			{
				chatGUI.SendMessage("OutsideSystem", text + " sliced " + username + "!");
				GameObject.Find("/GUI/HealthDisplay").SendMessage("killerusername", text + " (lvl " + num + " Melee Ramming Blade)");
			}
			if (CTFFlagSender.gotflag && AuthGameObject.gametype == "Capture the Flag" && !aimanager.isAI)
			{
				gameObject.SendMessage("setctf", false);
				gameObject.SendMessage("dropflagdel", maincar.transform.position);
				chatGUI.SendMessage("OutsideSystem", username + " dropped the flag.");
			}
			if ((!isafking || aimanager.isAI) && (aimanager.isAI || !FireGun.isInvincible))
			{
				tchooseGUI.SendMessage("addkiller", text);
			}
			rounddeaths++;
			updatehealth = true;
			maincar.isKinematic = true;
			if (AuthGameObject.username != text)
			{
				IEnumerator enumerator = UnityRuntimeServices.GetEnumerator(killerarr);
				while (enumerator.MoveNext())
				{
					object obj = enumerator.Current;
					if (!(obj is string))
					{
						obj = RuntimeServices.Coerce(obj, typeof(string));
					}
					string text2 = (string)obj;
					if (text2 != text && (!isafking || aimanager.isAI) && !aimanager.isAI && FireGun.isInvincible)
					{
					}
				}
				killerarr.Clear();
				killedby.Clear();
			}
		}
		else
		{
			if (AuthGameObject.username != text)
			{
				if (!killedby.ContainsKey(text))
				{
					killedby.Add(text, 5 + num / 2);
					killerarr.Add(text);
				}
				else
				{
					killedby[text] = RuntimeServices.InvokeBinaryOperator("op_Addition", killedby[text], 5 + num / 2);
				}
			}
			((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("setsmoke", PhotonTargets.All, currenthealth);
			if (!aimanager.isAI)
			{
				if (!(currenthealth > 15f))
				{
					GameObject.Find("HealthEffect").SendMessage("FadeAt", 65f);
					reseteffects = true;
				}
				else
				{
					GameObject.Find("HealthEffect").SendMessage("FadeTo", (100f - currenthealth) / 1.3f);
				}
			}
		}
		updatehealth = true;
	}

	public virtual void empgrenadeHit(string u)
	{
		string text = u.Split("|"[0])[0];
		int num = UnityBuiltins.parseInt(u.Split("|"[0])[1]);
		gameObject.SendMessage("flash");
		if ((!photonView.isMine && !aimanager.isAI) || (!ChatScript.isCar && !aimanager.isAI) || currenthealth == 0f || (isafking && !aimanager.isAI) || (!aimanager.isAI && FireGun.isInvincible) || !(text != AuthGameObject.username))
		{
			return;
		}
		float num2 = 0f;
		if (shieldobject.active)
		{
			shieldobject.SendMessage("takeDamage", UnityBuiltins.parseInt(65 + num / 2));
		}
		if ((ChatScript.hasarmor1 && !aimanager.isAI) || (aimanager.isAI && aimanager.armorLevel == 0))
		{
			num2 += 0.1f + UnityBuiltins.parseFloat(ChatScript.levels[2]) / 300f;
		}
		if ((ChatScript.hasarmor2 && !aimanager.isAI) || (aimanager.isAI && aimanager.armorLevel == 1))
		{
			num2 += 0.2f + UnityBuiltins.parseFloat(ChatScript.levels[2]) / 300f;
		}
		if ((ChatScript.hasarmor3 && !aimanager.isAI) || (aimanager.isAI && aimanager.armorLevel == 2))
		{
			num2 += 0.45f + UnityBuiltins.parseFloat(ChatScript.levels[2]) / 300f;
		}
		if ((ChatScript.hasarmor4 && !aimanager.isAI) || (aimanager.isAI && aimanager.armorLevel == 3))
		{
			num2 += 0.65f + UnityBuiltins.parseFloat(ChatScript.levels[2]) / 300f;
		}
		if ((ChatScript.hasarmor5 && !aimanager.isAI) || (ChatScript.hasarmor6 && !aimanager.isAI) || (aimanager.isAI && aimanager.armorLevel == 4))
		{
			num2 += 0.35f + UnityBuiltins.parseFloat(ChatScript.levels[2]) / 300f;
		}
		if (ChatScript.hasarmor7 && !aimanager.isAI)
		{
			num2 += 0.2f + UnityBuiltins.parseFloat(ChatScript.levels[2]) / 300f;
		}
		if (ChatScript.hasarmor8 && !aimanager.isAI)
		{
			num2 += 0.3f + UnityBuiltins.parseFloat(ChatScript.levels[2]) / 300f;
		}
		if (!ChatScript.hasgtrcar || !aimanager.isAI)
		{
		}
		if (!(num2 <= 1f))
		{
			num2 = 1f;
		}
		if (FireGun.grappling)
		{
			FireGun.grappling = false;
			FireGun.stopgrapple = true;
		}
		float num3 = ((UnityScript.Lang.Extensions.get_length((System.Array)u.Split("|"[0])) <= 2) ? 1f : UnityBuiltins.parseFloat(u.Split("|"[0])[2])) * UnityEngine.Random.Range((float)(15 + num / 2) * (1f - Mathf.Min(num2 * armorHealth + ((!shieldobject.active) ? 0f : 0.85f), 1f)), (float)(20 + num / 2) * (1f - Mathf.Min(num2 * armorHealth + ((!shieldobject.active) ? 0f : 0.85f), 1f)));
		float num4 = currenthealth;
		currenthealth -= ((!aimanager.isAI || TutorialManager.curTutIndex >= 7 || !AuthGameObject.showTutorial) ? num3 : 1f);
		if (text != MasterServerScript.ainame && text != MasterServerScript.ainame2 && text != MasterServerScript.ainame3)
		{
			PhotonPlayer photonPlayer = usernameToPlayer(text);
			if (photonPlayer != null)
			{
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("hD", photonPlayer, Mathf.RoundToInt(num4 - currenthealth));
			}
		}
		stallGlider = true;
		if (!aimanager.isAI)
		{
			if (ChatScript.hasarmor1 || ChatScript.hasarmor2 || ChatScript.hasarmor3 || ChatScript.hasarmor4 || ChatScript.hasarmor5 || ChatScript.hasarmor6 || ChatScript.hasarmor7 || ChatScript.hasarmor8)
			{
				armorHealth -= (float)UnityEngine.Random.Range(15 + num / 2, 20 + num / 2) * (1f - num2) / 1.5f / 100f;
				armorHealth = Mathf.Max(0f, armorHealth);
			}
			else
			{
				armorHealth = 1f;
			}
		}
		if (!(currenthealth > 0f))
		{
			if ((!isafking || aimanager.isAI) && (aimanager.isAI || !FireGun.isInvincible))
			{
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("findkiller", PhotonTargets.All, text, (!aimanager.isAI) ? AuthGameObject.username : aimanager.ainame, (!aimanager.isAI) ? ((!(SpawningScript.team2 == "red")) ? true : false) : ((!(aimanager.aiteam == "red")) ? true : false), "fragged");
			}
			if (!aimanager.isAI)
			{
				GameObject.Find("HealthEffect").SendMessage("setnfo");
				GameObject.Find("HealthEffect").SendMessage("Fadeout");
			}
			else
			{
				GameObject.Find("/GUI/HealthDisplay").SendMessage("aiDeath", aimanager.aiteam);
			}
			currenthealth = 0f;
			if (AuthGameObject.username == text || aimanager.ainame == text)
			{
				chatGUI.SendMessage("OutsideSystem", username + " killed himself!");
				GameObject.Find("/GUI/HealthDisplay").SendMessage("killerusername", "YOU");
			}
			else
			{
				chatGUI.SendMessage("OutsideSystem", text + " fragged " + username + "!");
				GameObject.Find("/GUI/HealthDisplay").SendMessage("killerusername", text + " (lvl " + num + " EMP Grenade Launcher)");
			}
			if (CTFFlagSender.gotflag && AuthGameObject.gametype == "Capture the Flag" && !aimanager.isAI)
			{
				gameObject.SendMessage("setctf", false);
				gameObject.SendMessage("dropflagdel", maincar.transform.position);
				chatGUI.SendMessage("OutsideSystem", username + " dropped the flag.");
			}
			if ((!isafking || aimanager.isAI) && (aimanager.isAI || !FireGun.isInvincible))
			{
				tchooseGUI.SendMessage("addkiller", text);
			}
			rounddeaths++;
			updatehealth = true;
			maincar.isKinematic = true;
			if (AuthGameObject.username != text)
			{
				IEnumerator enumerator = UnityRuntimeServices.GetEnumerator(killerarr);
				while (enumerator.MoveNext())
				{
					object obj = enumerator.Current;
					if (!(obj is string))
					{
						obj = RuntimeServices.Coerce(obj, typeof(string));
					}
					string text2 = (string)obj;
					if (text2 != text && (!isafking || aimanager.isAI) && !aimanager.isAI && FireGun.isInvincible)
					{
					}
				}
				killerarr.Clear();
				killedby.Clear();
			}
		}
		else
		{
			if (AuthGameObject.username != text)
			{
				if (!killedby.ContainsKey(text))
				{
					killedby.Add(text, 30 + num / 2);
					killerarr.Add(text);
				}
				else
				{
					killedby[text] = RuntimeServices.InvokeBinaryOperator("op_Addition", killedby[text], 30 + num / 2);
				}
			}
			((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("setsmoke", PhotonTargets.All, currenthealth);
			if (!aimanager.isAI)
			{
				if (!(currenthealth > 15f))
				{
					GameObject.Find("HealthEffect").SendMessage("FadeAt", 65f);
					reseteffects = true;
				}
				else
				{
					GameObject.Find("HealthEffect").SendMessage("FadeTo", (100f - currenthealth) / 1.3f);
				}
			}
		}
		updatehealth = true;
	}

	public virtual void grenadeHit(string u)
	{
		string text = u.Split("|"[0])[0];
		int num = UnityBuiltins.parseInt(u.Split("|"[0])[1]);
		gameObject.SendMessage("flash");
		if ((!photonView.isMine && !aimanager.isAI) || (!ChatScript.isCar && !aimanager.isAI) || currenthealth == 0f || (isafking && !aimanager.isAI) || (!aimanager.isAI && FireGun.isInvincible) || !(text != AuthGameObject.username))
		{
			return;
		}
		float num2 = 0f;
		if (shieldobject.active)
		{
			shieldobject.SendMessage("takeDamage", UnityBuiltins.parseInt(65 + num / 2));
		}
		if ((ChatScript.hasarmor1 && !aimanager.isAI) || (aimanager.isAI && aimanager.armorLevel == 0))
		{
			num2 += 0.1f + UnityBuiltins.parseFloat(ChatScript.levels[2]) / 300f;
		}
		if ((ChatScript.hasarmor2 && !aimanager.isAI) || (aimanager.isAI && aimanager.armorLevel == 1))
		{
			num2 += 0.2f + UnityBuiltins.parseFloat(ChatScript.levels[2]) / 300f;
		}
		if ((ChatScript.hasarmor3 && !aimanager.isAI) || (aimanager.isAI && aimanager.armorLevel == 2))
		{
			num2 += 0.45f + UnityBuiltins.parseFloat(ChatScript.levels[2]) / 300f;
		}
		if ((ChatScript.hasarmor4 && !aimanager.isAI) || (aimanager.isAI && aimanager.armorLevel == 3))
		{
			num2 += 0.65f + UnityBuiltins.parseFloat(ChatScript.levels[2]) / 300f;
		}
		if ((ChatScript.hasarmor5 && !aimanager.isAI) || (ChatScript.hasarmor6 && !aimanager.isAI) || (aimanager.isAI && aimanager.armorLevel == 4))
		{
			num2 += 0.35f + UnityBuiltins.parseFloat(ChatScript.levels[2]) / 300f;
		}
		if (ChatScript.hasarmor7 && !aimanager.isAI)
		{
			num2 += 0.2f + UnityBuiltins.parseFloat(ChatScript.levels[2]) / 300f;
		}
		if (ChatScript.hasarmor8 && !aimanager.isAI)
		{
			num2 += 0.3f + UnityBuiltins.parseFloat(ChatScript.levels[2]) / 300f;
		}
		if (!ChatScript.hasgtrcar || !aimanager.isAI)
		{
		}
		if (!(num2 <= 1f))
		{
			num2 = 1f;
		}
		if (FireGun.grappling)
		{
			FireGun.grappling = false;
			FireGun.stopgrapple = true;
		}
		float num3 = ((UnityScript.Lang.Extensions.get_length((System.Array)u.Split("|"[0])) <= 2) ? 1f : UnityBuiltins.parseFloat(u.Split("|"[0])[2])) * UnityEngine.Random.Range((float)(30 + num / 2) * (1f - Mathf.Min(num2 * armorHealth + ((!shieldobject.active) ? 0f : 0.85f), 1f)), (float)(45 + num / 2) * (1f - Mathf.Min(num2 * armorHealth + ((!shieldobject.active) ? 0f : 0.85f), 1f)));
		float num4 = currenthealth;
		currenthealth -= ((!aimanager.isAI || TutorialManager.curTutIndex >= 7 || !AuthGameObject.showTutorial) ? num3 : 1f);
		if (text != MasterServerScript.ainame && text != MasterServerScript.ainame2 && text != MasterServerScript.ainame3)
		{
			PhotonPlayer photonPlayer = usernameToPlayer(text);
			if (photonPlayer != null)
			{
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("hD", photonPlayer, Mathf.RoundToInt(num4 - currenthealth));
			}
		}
		stallGlider = true;
		if (!aimanager.isAI)
		{
			if (ChatScript.hasarmor1 || ChatScript.hasarmor2 || ChatScript.hasarmor3 || ChatScript.hasarmor4 || ChatScript.hasarmor5 || ChatScript.hasarmor6 || ChatScript.hasarmor7 || ChatScript.hasarmor8)
			{
				armorHealth -= (float)UnityEngine.Random.Range(30 + num / 2, 45 + num / 2) * (1f - num2) / 1.5f / 100f;
				armorHealth = Mathf.Max(0f, armorHealth);
			}
			else
			{
				armorHealth = 1f;
			}
		}
		if (!(currenthealth > 0f))
		{
			if ((!isafking || aimanager.isAI) && (aimanager.isAI || !FireGun.isInvincible))
			{
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("findkiller", PhotonTargets.All, text, (!aimanager.isAI) ? AuthGameObject.username : aimanager.ainame, (!aimanager.isAI) ? ((!(SpawningScript.team2 == "red")) ? true : false) : ((!(aimanager.aiteam == "red")) ? true : false), "fragged");
			}
			if (!aimanager.isAI)
			{
				GameObject.Find("HealthEffect").SendMessage("setnfo");
				GameObject.Find("HealthEffect").SendMessage("Fadeout");
			}
			else
			{
				GameObject.Find("/GUI/HealthDisplay").SendMessage("aiDeath", aimanager.aiteam);
			}
			currenthealth = 0f;
			if (AuthGameObject.username == text || aimanager.ainame == text)
			{
				chatGUI.SendMessage("OutsideSystem", username + " killed himself!");
				GameObject.Find("/GUI/HealthDisplay").SendMessage("killerusername", "YOU");
			}
			else
			{
				chatGUI.SendMessage("OutsideSystem", text + " fragged " + username + "!");
				GameObject.Find("/GUI/HealthDisplay").SendMessage("killerusername", text + " (lvl " + num + " Grenade Launcher)");
			}
			if (CTFFlagSender.gotflag && AuthGameObject.gametype == "Capture the Flag" && !aimanager.isAI)
			{
				gameObject.SendMessage("setctf", false);
				gameObject.SendMessage("dropflagdel", maincar.transform.position);
				chatGUI.SendMessage("OutsideSystem", username + " dropped the flag.");
			}
			if ((!isafking || aimanager.isAI) && (aimanager.isAI || !FireGun.isInvincible))
			{
				tchooseGUI.SendMessage("addkiller", text);
			}
			rounddeaths++;
			updatehealth = true;
			maincar.isKinematic = true;
			if (AuthGameObject.username != text)
			{
				IEnumerator enumerator = UnityRuntimeServices.GetEnumerator(killerarr);
				while (enumerator.MoveNext())
				{
					object obj = enumerator.Current;
					if (!(obj is string))
					{
						obj = RuntimeServices.Coerce(obj, typeof(string));
					}
					string text2 = (string)obj;
					if (text2 != text && (!isafking || aimanager.isAI) && !aimanager.isAI && FireGun.isInvincible)
					{
					}
				}
				killerarr.Clear();
				killedby.Clear();
			}
		}
		else
		{
			if (AuthGameObject.username != text)
			{
				if (!killedby.ContainsKey(text))
				{
					killedby.Add(text, 30 + num / 2);
					killerarr.Add(text);
				}
				else
				{
					killedby[text] = RuntimeServices.InvokeBinaryOperator("op_Addition", killedby[text], 30 + num / 2);
				}
			}
			((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("setsmoke", PhotonTargets.All, currenthealth);
			if (!aimanager.isAI)
			{
				if (!(currenthealth > 15f))
				{
					GameObject.Find("HealthEffect").SendMessage("FadeAt", 65f);
					reseteffects = true;
				}
				else
				{
					GameObject.Find("HealthEffect").SendMessage("FadeTo", (100f - currenthealth) / 1.3f);
				}
			}
		}
		updatehealth = true;
	}

	public virtual void bulletHit(string u)
	{
		string text = u.Split("|"[0])[0];
		int num = UnityBuiltins.parseInt(u.Split("|"[0])[1]);
		if (!(text != AuthGameObject.username) && !aimanager.isAI)
		{
			return;
		}
		gameObject.SendMessage("flash");
		if ((!photonView.isMine && !aimanager.isAI) || (!ChatScript.isCar && !aimanager.isAI) || currenthealth == 0f || (isafking && !aimanager.isAI) || (!aimanager.isAI && FireGun.isInvincible))
		{
			return;
		}
		float num2 = 0f;
		if (shieldobject.active)
		{
			shieldobject.SendMessage("takeDamage", UnityBuiltins.parseInt(5f + (float)(num / 15)));
		}
		if ((ChatScript.hasarmor1 && !aimanager.isAI) || (aimanager.isAI && aimanager.armorLevel == 0))
		{
			num2 += 0.1f + UnityBuiltins.parseFloat(ChatScript.levels[2]) / 300f;
		}
		if ((ChatScript.hasarmor2 && !aimanager.isAI) || (aimanager.isAI && aimanager.armorLevel == 1))
		{
			num2 += 0.2f + UnityBuiltins.parseFloat(ChatScript.levels[2]) / 300f;
		}
		if ((ChatScript.hasarmor3 && !aimanager.isAI) || (aimanager.isAI && aimanager.armorLevel == 2))
		{
			num2 += 0.45f + UnityBuiltins.parseFloat(ChatScript.levels[2]) / 300f;
		}
		if ((ChatScript.hasarmor4 && !aimanager.isAI) || (aimanager.isAI && aimanager.armorLevel == 3))
		{
			num2 += 0.65f + UnityBuiltins.parseFloat(ChatScript.levels[2]) / 300f;
		}
		if ((ChatScript.hasarmor5 && !aimanager.isAI) || (ChatScript.hasarmor6 && !aimanager.isAI) || (aimanager.isAI && aimanager.armorLevel == 4))
		{
			num2 += 0.35f + UnityBuiltins.parseFloat(ChatScript.levels[2]) / 300f;
		}
		if (ChatScript.hasarmor7 && !aimanager.isAI)
		{
			num2 += 0.2f + UnityBuiltins.parseFloat(ChatScript.levels[2]) / 300f;
		}
		if (ChatScript.hasarmor8 && !aimanager.isAI)
		{
			num2 += 0.3f + UnityBuiltins.parseFloat(ChatScript.levels[2]) / 300f;
		}
		if (!ChatScript.hasgtrcar || !aimanager.isAI)
		{
		}
		if (!(num2 <= 1f))
		{
			num2 = 1f;
		}
		if (FireGun.grappling)
		{
			FireGun.grappling = false;
			FireGun.stopgrapple = true;
		}
		float num3 = currenthealth;
		currenthealth -= ((!aimanager.isAI || TutorialManager.curTutIndex >= 7 || !AuthGameObject.showTutorial) ? (((UnityScript.Lang.Extensions.get_length((System.Array)u.Split("|"[0])) <= 2) ? 1f : UnityBuiltins.parseFloat(u.Split("|"[0])[2])) * (1.5f + (float)(num / 15)) * (1f - Mathf.Min(num2 * armorHealth + ((!shieldobject.active) ? 0f : 0.85f), 1f))) : 1f);
		if (text != MasterServerScript.ainame && text != MasterServerScript.ainame2 && text != MasterServerScript.ainame3)
		{
			PhotonPlayer photonPlayer = usernameToPlayer(text);
			if (photonPlayer != null)
			{
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("hD", photonPlayer, Mathf.RoundToInt(num3 - currenthealth));
			}
		}
		stallGlider = true;
		if (!aimanager.isAI)
		{
			if (ChatScript.hasarmor1 || ChatScript.hasarmor2 || ChatScript.hasarmor3 || ChatScript.hasarmor4 || ChatScript.hasarmor5 || ChatScript.hasarmor6 || ChatScript.hasarmor7 || ChatScript.hasarmor8)
			{
				armorHealth -= (1.5f + (float)(num / 15)) * (1f - num2) / 1.5f / 100f;
				armorHealth = Mathf.Max(0f, armorHealth);
			}
			else
			{
				armorHealth = 1f;
			}
		}
		if (!(currenthealth > 0f))
		{
			if ((!isafking || aimanager.isAI) && (aimanager.isAI || !FireGun.isInvincible))
			{
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("findkiller", PhotonTargets.All, text, (!aimanager.isAI) ? AuthGameObject.username : aimanager.ainame, (!aimanager.isAI) ? ((!(SpawningScript.team2 == "red")) ? true : false) : ((!(aimanager.aiteam == "red")) ? true : false), "gunned down");
			}
			if (!aimanager.isAI)
			{
				GameObject.Find("HealthEffect").SendMessage("setnfo");
				GameObject.Find("HealthEffect").SendMessage("Fadeout");
			}
			else
			{
				GameObject.Find("/GUI/HealthDisplay").SendMessage("aiDeath", aimanager.aiteam);
			}
			currenthealth = 0f;
			chatGUI.SendMessage("OutsideSystem", text + " gunned down " + username + "!");
			GameObject.Find("/GUI/HealthDisplay").SendMessage("killerusername", text + " (lvl " + num + " Minigun/Assault Rifle)");
			if (CTFFlagSender.gotflag && AuthGameObject.gametype == "Capture the Flag" && !aimanager.isAI)
			{
				gameObject.SendMessage("setctf", false);
				gameObject.SendMessage("dropflagdel", maincar.transform.position);
				chatGUI.SendMessage("OutsideSystem", username + " dropped the flag.");
			}
			if ((!isafking || aimanager.isAI) && (aimanager.isAI || !FireGun.isInvincible))
			{
				tchooseGUI.SendMessage("addkiller", text);
			}
			rounddeaths++;
			updatehealth = true;
			maincar.isKinematic = true;
			IEnumerator enumerator = UnityRuntimeServices.GetEnumerator(killerarr);
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				if (!(obj is string))
				{
					obj = RuntimeServices.Coerce(obj, typeof(string));
				}
				string text2 = (string)obj;
				if (text2 != text && (!isafking || aimanager.isAI) && !aimanager.isAI && FireGun.isInvincible)
				{
				}
			}
			killerarr.Clear();
			killedby.Clear();
		}
		else
		{
			if (!killedby.ContainsKey(text))
			{
				killedby.Add(text, 3.5f + (float)(num / 5));
				killerarr.Add(text);
			}
			else
			{
				killedby[text] = RuntimeServices.InvokeBinaryOperator("op_Addition", killedby[text], 3.5f + (float)(num / 5));
			}
			((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("setsmoke", PhotonTargets.All, currenthealth);
			if (!aimanager.isAI)
			{
				if (!(currenthealth > 15f))
				{
					GameObject.Find("HealthEffect").SendMessage("FadeAt", 65f);
					reseteffects = true;
				}
				else
				{
					GameObject.Find("HealthEffect").SendMessage("FadeTo", (100f - currenthealth) / 1.3f);
				}
			}
		}
		updatehealth = true;
	}

	public virtual void shotgunBulletHit(string u)
	{
		string text = u.Split("|"[0])[0];
		int num = UnityBuiltins.parseInt(u.Split("|"[0])[1]);
		if (!(text != AuthGameObject.username) && !aimanager.isAI)
		{
			return;
		}
		gameObject.SendMessage("flash");
		if ((!photonView.isMine && !aimanager.isAI) || (!ChatScript.isCar && !aimanager.isAI) || currenthealth == 0f || (isafking && !aimanager.isAI) || (!aimanager.isAI && FireGun.isInvincible))
		{
			return;
		}
		float num2 = 0f;
		if (shieldobject.active)
		{
			shieldobject.SendMessage("takeDamage", UnityBuiltins.parseInt(8.5f + (float)num / 5f));
		}
		if ((ChatScript.hasarmor1 && !aimanager.isAI) || (aimanager.isAI && aimanager.armorLevel == 0))
		{
			num2 += 0.1f + UnityBuiltins.parseFloat(ChatScript.levels[2]) / 300f;
		}
		if ((ChatScript.hasarmor2 && !aimanager.isAI) || (aimanager.isAI && aimanager.armorLevel == 1))
		{
			num2 += 0.2f + UnityBuiltins.parseFloat(ChatScript.levels[2]) / 300f;
		}
		if ((ChatScript.hasarmor3 && !aimanager.isAI) || (aimanager.isAI && aimanager.armorLevel == 2))
		{
			num2 += 0.45f + UnityBuiltins.parseFloat(ChatScript.levels[2]) / 300f;
		}
		if ((ChatScript.hasarmor4 && !aimanager.isAI) || (aimanager.isAI && aimanager.armorLevel == 3))
		{
			num2 += 0.65f + UnityBuiltins.parseFloat(ChatScript.levels[2]) / 300f;
		}
		if ((ChatScript.hasarmor5 && !aimanager.isAI) || (ChatScript.hasarmor6 && !aimanager.isAI) || (aimanager.isAI && aimanager.armorLevel == 4))
		{
			num2 += 0.35f + UnityBuiltins.parseFloat(ChatScript.levels[2]) / 300f;
		}
		if (ChatScript.hasarmor7 && !aimanager.isAI)
		{
			num2 += 0.2f + UnityBuiltins.parseFloat(ChatScript.levels[2]) / 300f;
		}
		if (ChatScript.hasarmor8 && !aimanager.isAI)
		{
			num2 += 0.3f + UnityBuiltins.parseFloat(ChatScript.levels[2]) / 300f;
		}
		if (!ChatScript.hasgtrcar || !aimanager.isAI)
		{
		}
		if (!(num2 <= 1f))
		{
			num2 = 1f;
		}
		if (FireGun.grappling)
		{
			FireGun.grappling = false;
			FireGun.stopgrapple = true;
		}
		float num3 = currenthealth;
		currenthealth -= ((!aimanager.isAI || TutorialManager.curTutIndex >= 7 || !AuthGameObject.showTutorial) ? (((UnityScript.Lang.Extensions.get_length((System.Array)u.Split("|"[0])) <= 2) ? 1f : UnityBuiltins.parseFloat(u.Split("|"[0])[2])) * (5f + (float)num / 8f) * (1f - Mathf.Min(num2 * armorHealth + ((!shieldobject.active) ? 0f : 0.85f), 1f))) : 1f);
		if (text != MasterServerScript.ainame && text != MasterServerScript.ainame2 && text != MasterServerScript.ainame3)
		{
			PhotonPlayer photonPlayer = usernameToPlayer(text);
			if (photonPlayer != null)
			{
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("hD", photonPlayer, Mathf.RoundToInt(num3 - currenthealth));
			}
		}
		stallGlider = true;
		if (!aimanager.isAI)
		{
			if (ChatScript.hasarmor1 || ChatScript.hasarmor2 || ChatScript.hasarmor3 || ChatScript.hasarmor4 || ChatScript.hasarmor5 || ChatScript.hasarmor6 || ChatScript.hasarmor7 || ChatScript.hasarmor8)
			{
				armorHealth -= (8.5f + (float)num / 5f) * (1f - num2) / 1.5f / 100f;
				armorHealth = Mathf.Max(0f, armorHealth);
			}
			else
			{
				armorHealth = 1f;
			}
		}
		if (!(currenthealth > 0f))
		{
			if ((!isafking || aimanager.isAI) && (aimanager.isAI || !FireGun.isInvincible))
			{
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("findkiller", PhotonTargets.All, text, (!aimanager.isAI) ? AuthGameObject.username : aimanager.ainame, (!aimanager.isAI) ? ((!(SpawningScript.team2 == "red")) ? true : false) : ((!(aimanager.aiteam == "red")) ? true : false), "blasted");
			}
			if (!aimanager.isAI)
			{
				GameObject.Find("HealthEffect").SendMessage("setnfo");
				GameObject.Find("HealthEffect").SendMessage("Fadeout");
			}
			else
			{
				GameObject.Find("/GUI/HealthDisplay").SendMessage("aiDeath", aimanager.aiteam);
			}
			currenthealth = 0f;
			chatGUI.SendMessage("OutsideSystem", text + " blasted " + username + "!");
			GameObject.Find("/GUI/HealthDisplay").SendMessage("killerusername", text + " (lvl " + num + " Shotgun)");
			if (CTFFlagSender.gotflag && AuthGameObject.gametype == "Capture the Flag" && !aimanager.isAI)
			{
				gameObject.SendMessage("setctf", false);
				gameObject.SendMessage("dropflagdel", maincar.transform.position);
				chatGUI.SendMessage("OutsideSystem", username + " dropped the flag.");
			}
			if ((!isafking || aimanager.isAI) && (aimanager.isAI || !FireGun.isInvincible))
			{
				tchooseGUI.SendMessage("addkiller", text);
			}
			rounddeaths++;
			updatehealth = true;
			maincar.isKinematic = true;
			IEnumerator enumerator = UnityRuntimeServices.GetEnumerator(killerarr);
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				if (!(obj is string))
				{
					obj = RuntimeServices.Coerce(obj, typeof(string));
				}
				string text2 = (string)obj;
				if (text2 != text && (!isafking || aimanager.isAI) && !aimanager.isAI && FireGun.isInvincible)
				{
				}
			}
			killerarr.Clear();
			killedby.Clear();
		}
		else
		{
			((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("setsmoke", PhotonTargets.All, currenthealth);
			if (!aimanager.isAI)
			{
				if (!(currenthealth > 15f))
				{
					GameObject.Find("HealthEffect").SendMessage("FadeAt", 65f);
					reseteffects = true;
				}
				else
				{
					GameObject.Find("HealthEffect").SendMessage("FadeTo", (100f - currenthealth) / 1.3f);
				}
			}
		}
		updatehealth = true;
	}

	public virtual void railBulletHit(string u)
	{
		string text = u.Split("|"[0])[0];
		int num = UnityBuiltins.parseInt(u.Split("|"[0])[1]);
		if (!(text != AuthGameObject.username) && !aimanager.isAI)
		{
			return;
		}
		gameObject.SendMessage("flash");
		if ((!photonView.isMine && !aimanager.isAI) || (!ChatScript.isCar && !aimanager.isAI) || currenthealth == 0f || (isafking && !aimanager.isAI) || (!aimanager.isAI && FireGun.isInvincible))
		{
			return;
		}
		float num2 = 0f;
		if (shieldobject.active)
		{
			shieldobject.SendMessage("takeDamage", UnityBuiltins.parseInt(75 + num / 2));
		}
		if ((ChatScript.hasarmor1 && !aimanager.isAI) || (aimanager.isAI && aimanager.armorLevel == 0))
		{
			num2 += 0.1f + UnityBuiltins.parseFloat(ChatScript.levels[2]) / 300f;
		}
		if ((ChatScript.hasarmor2 && !aimanager.isAI) || (aimanager.isAI && aimanager.armorLevel == 1))
		{
			num2 += 0.2f + UnityBuiltins.parseFloat(ChatScript.levels[2]) / 300f;
		}
		if ((ChatScript.hasarmor3 && !aimanager.isAI) || (aimanager.isAI && aimanager.armorLevel == 2))
		{
			num2 += 0.45f + UnityBuiltins.parseFloat(ChatScript.levels[2]) / 300f;
		}
		if ((ChatScript.hasarmor4 && !aimanager.isAI) || (aimanager.isAI && aimanager.armorLevel == 3))
		{
			num2 += 0.65f + UnityBuiltins.parseFloat(ChatScript.levels[2]) / 300f;
		}
		if ((ChatScript.hasarmor5 && !aimanager.isAI) || (ChatScript.hasarmor6 && !aimanager.isAI) || (aimanager.isAI && aimanager.armorLevel == 4))
		{
			num2 += 0.35f + UnityBuiltins.parseFloat(ChatScript.levels[2]) / 300f;
		}
		if (ChatScript.hasarmor7 && !aimanager.isAI)
		{
			num2 += 0.2f + UnityBuiltins.parseFloat(ChatScript.levels[2]) / 300f;
		}
		if (ChatScript.hasarmor8 && !aimanager.isAI)
		{
			num2 += 0.3f + UnityBuiltins.parseFloat(ChatScript.levels[2]) / 300f;
		}
		if (!ChatScript.hasgtrcar || !aimanager.isAI)
		{
		}
		if (!(num2 <= 1f))
		{
			num2 = 1f;
		}
		if (FireGun.grappling)
		{
			FireGun.grappling = false;
			FireGun.stopgrapple = true;
		}
		float num3 = currenthealth;
		currenthealth -= ((!aimanager.isAI || TutorialManager.curTutIndex >= 7 || !AuthGameObject.showTutorial) ? (((UnityScript.Lang.Extensions.get_length((System.Array)u.Split("|"[0])) <= 2) ? 1f : UnityBuiltins.parseFloat(u.Split("|"[0])[2])) * (float)(75 + num / 2) * (1f - Mathf.Min(num2 * armorHealth + ((!shieldobject.active) ? 0f : 0.85f), 1f))) : 1f);
		if (text != MasterServerScript.ainame && text != MasterServerScript.ainame2 && text != MasterServerScript.ainame3)
		{
			PhotonPlayer photonPlayer = usernameToPlayer(text);
			if (photonPlayer != null)
			{
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("hD", photonPlayer, Mathf.RoundToInt(num3 - currenthealth));
			}
		}
		stallGlider = true;
		if (!aimanager.isAI)
		{
			if (ChatScript.hasarmor1 || ChatScript.hasarmor2 || ChatScript.hasarmor3 || ChatScript.hasarmor4 || ChatScript.hasarmor5 || ChatScript.hasarmor6 || ChatScript.hasarmor7 || ChatScript.hasarmor8)
			{
				armorHealth -= (float)(75 + num / 2) * (1f - num2) / 1.5f / 100f;
				armorHealth = Mathf.Max(0f, armorHealth);
			}
			else
			{
				armorHealth = 1f;
			}
		}
		if (!(currenthealth > 0f))
		{
			if ((!isafking || aimanager.isAI) && (aimanager.isAI || !FireGun.isInvincible))
			{
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("findkiller", PhotonTargets.All, text, (!aimanager.isAI) ? AuthGameObject.username : aimanager.ainame, (!aimanager.isAI) ? ((!(SpawningScript.team2 == "red")) ? true : false) : ((!(aimanager.aiteam == "red")) ? true : false), "sniped");
			}
			if (!aimanager.isAI)
			{
				GameObject.Find("HealthEffect").SendMessage("setnfo");
				GameObject.Find("HealthEffect").SendMessage("Fadeout");
			}
			else
			{
				GameObject.Find("/GUI/HealthDisplay").SendMessage("aiDeath", aimanager.aiteam);
			}
			currenthealth = 0f;
			chatGUI.SendMessage("OutsideSystem", text + " sniped " + username + "!");
			GameObject.Find("/GUI/HealthDisplay").SendMessage("killerusername", text + " (lvl " + num + " Railgun)");
			if (CTFFlagSender.gotflag && AuthGameObject.gametype == "Capture the Flag" && !aimanager.isAI)
			{
				gameObject.SendMessage("setctf", false);
				gameObject.SendMessage("dropflagdel", maincar.transform.position);
				chatGUI.SendMessage("OutsideSystem", username + " dropped the flag.");
			}
			if ((!isafking || aimanager.isAI) && (aimanager.isAI || !FireGun.isInvincible))
			{
				tchooseGUI.SendMessage("addkiller", text);
			}
			rounddeaths++;
			updatehealth = true;
			maincar.isKinematic = true;
			IEnumerator enumerator = UnityRuntimeServices.GetEnumerator(killerarr);
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				if (!(obj is string))
				{
					obj = RuntimeServices.Coerce(obj, typeof(string));
				}
				string text2 = (string)obj;
				if (text2 != text && (!isafking || aimanager.isAI) && !aimanager.isAI && FireGun.isInvincible)
				{
				}
			}
			killerarr.Clear();
			killedby.Clear();
		}
		else
		{
			if (!killedby.ContainsKey(text))
			{
				killedby.Add(text, 75 + num / 2);
				killerarr.Add(text);
			}
			else
			{
				killedby[text] = RuntimeServices.InvokeBinaryOperator("op_Addition", killedby[text], 75 + num / 2);
			}
			((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("setsmoke", PhotonTargets.All, currenthealth);
			if (!aimanager.isAI)
			{
				if (!(currenthealth > 15f))
				{
					GameObject.Find("HealthEffect").SendMessage("FadeAt", 65f);
					reseteffects = true;
				}
				else
				{
					GameObject.Find("HealthEffect").SendMessage("FadeTo", (100f - currenthealth) / 1.3f);
				}
			}
		}
		updatehealth = true;
	}

	public virtual void burnHit(string u)
	{
		if (!(u != AuthGameObject.username))
		{
			return;
		}
		gameObject.SendMessage("flash");
		if ((!photonView.isMine && !aimanager.isAI) || (!ChatScript.isCar && !aimanager.isAI) || currenthealth == 0f || (isafking && !aimanager.isAI) || (!aimanager.isAI && FireGun.isInvincible))
		{
			return;
		}
		float num = 0f;
		if (shieldobject.active)
		{
			shieldobject.SendMessage("takeDamage", Time.deltaTime);
		}
		if ((ChatScript.hasarmor1 && !aimanager.isAI) || (aimanager.isAI && aimanager.armorLevel == 0))
		{
			num += 0.1f + UnityBuiltins.parseFloat(ChatScript.levels[2]) / 300f;
		}
		if ((ChatScript.hasarmor2 && !aimanager.isAI) || (aimanager.isAI && aimanager.armorLevel == 1))
		{
			num += 0.2f + UnityBuiltins.parseFloat(ChatScript.levels[2]) / 300f;
		}
		if ((ChatScript.hasarmor3 && !aimanager.isAI) || (aimanager.isAI && aimanager.armorLevel == 2))
		{
			num += 0.45f + UnityBuiltins.parseFloat(ChatScript.levels[2]) / 300f;
		}
		if ((ChatScript.hasarmor4 && !aimanager.isAI) || (aimanager.isAI && aimanager.armorLevel == 3))
		{
			num += 0.65f + UnityBuiltins.parseFloat(ChatScript.levels[2]) / 300f;
		}
		if ((ChatScript.hasarmor5 && !aimanager.isAI) || (ChatScript.hasarmor6 && !aimanager.isAI) || (aimanager.isAI && aimanager.armorLevel == 4))
		{
			num += 0.35f + UnityBuiltins.parseFloat(ChatScript.levels[2]) / 300f;
		}
		if (ChatScript.hasarmor7 && !aimanager.isAI)
		{
			num += 0.2f + UnityBuiltins.parseFloat(ChatScript.levels[2]) / 300f;
		}
		if (ChatScript.hasarmor8 && !aimanager.isAI)
		{
			num += 0.3f + UnityBuiltins.parseFloat(ChatScript.levels[2]) / 300f;
		}
		if (!ChatScript.hasgtrcar || !aimanager.isAI)
		{
		}
		if (!(num <= 1f))
		{
			num = 1f;
		}
		if (FireGun.grappling)
		{
			FireGun.grappling = false;
			FireGun.stopgrapple = true;
		}
		float num2 = currenthealth;
		currenthealth -= ((!aimanager.isAI || TutorialManager.curTutIndex >= 7 || !AuthGameObject.showTutorial) ? Time.deltaTime : 1f);
		if (u != MasterServerScript.ainame && u != MasterServerScript.ainame2 && u != MasterServerScript.ainame3)
		{
			PhotonPlayer photonPlayer = usernameToPlayer(u);
			if (photonPlayer != null)
			{
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("hD", photonPlayer, Mathf.RoundToInt(num2 - currenthealth));
			}
		}
		if (!aimanager.isAI)
		{
			if (ChatScript.hasarmor1 || ChatScript.hasarmor2 || ChatScript.hasarmor3 || ChatScript.hasarmor4 || ChatScript.hasarmor5 || ChatScript.hasarmor6 || ChatScript.hasarmor7 || ChatScript.hasarmor8)
			{
				armorHealth -= Time.deltaTime * (1f - num) / 1.5f / 100f;
				armorHealth = Mathf.Max(0f, armorHealth);
			}
			else
			{
				armorHealth = 1f;
			}
		}
		if (!(currenthealth > 0f))
		{
			if ((!isafking || aimanager.isAI) && (aimanager.isAI || !FireGun.isInvincible))
			{
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("findkiller", PhotonTargets.All, u, (!aimanager.isAI) ? AuthGameObject.username : aimanager.ainame, (!aimanager.isAI) ? ((!(SpawningScript.team2 == "red")) ? true : false) : ((!(aimanager.aiteam == "red")) ? true : false), "burned");
			}
			if (!aimanager.isAI)
			{
				GameObject.Find("HealthEffect").SendMessage("setnfo");
				GameObject.Find("HealthEffect").SendMessage("Fadeout");
			}
			else
			{
				GameObject.Find("/GUI/HealthDisplay").SendMessage("aiDeath", aimanager.aiteam);
			}
			currenthealth = 0f;
			chatGUI.SendMessage("OutsideSystem", u + " burned " + username + "!");
			GameObject.Find("/GUI/HealthDisplay").SendMessage("killerusername", u + " (burn damage)");
			if (CTFFlagSender.gotflag && AuthGameObject.gametype == "Capture the Flag" && !aimanager.isAI)
			{
				gameObject.SendMessage("setctf", false);
				gameObject.SendMessage("dropflagdel", maincar.transform.position);
				chatGUI.SendMessage("OutsideSystem", username + " dropped the flag.");
			}
			if ((!isafking || aimanager.isAI) && (aimanager.isAI || !FireGun.isInvincible))
			{
				tchooseGUI.SendMessage("addkiller", u);
			}
			rounddeaths++;
			updatehealth = true;
			maincar.isKinematic = true;
			IEnumerator enumerator = UnityRuntimeServices.GetEnumerator(killerarr);
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				if (!(obj is string))
				{
					obj = RuntimeServices.Coerce(obj, typeof(string));
				}
				string text = (string)obj;
				if (text != u && (!isafking || aimanager.isAI) && !aimanager.isAI && FireGun.isInvincible)
				{
				}
			}
			killerarr.Clear();
			killedby.Clear();
		}
		else
		{
			if (!killedby.ContainsKey(u))
			{
				killedby.Add(u, Time.deltaTime);
				killerarr.Add(u);
			}
			else
			{
				killedby[u] = RuntimeServices.InvokeBinaryOperator("op_Addition", killedby[u], Time.deltaTime);
			}
			((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("setsmoke", PhotonTargets.All, currenthealth);
			if (!aimanager.isAI)
			{
				if (!(currenthealth > 15f))
				{
					GameObject.Find("HealthEffect").SendMessage("FadeAt", 65f);
					reseteffects = true;
				}
				else
				{
					GameObject.Find("HealthEffect").SendMessage("FadeTo", (100f - currenthealth) / 1.3f);
				}
			}
		}
		updatehealth = true;
	}

	public virtual void OnParticleCollision(GameObject theparticle)
	{
		if (!(theparticle.name == "flameprefab(Clone)"))
		{
			return;
		}
		gameObject.SendMessage("flash");
		object obj = UnityRuntimeServices.Invoke(theparticle.GetComponent("FlameScript"), "returnUser", new object[0], typeof(UnityEngine.MonoBehaviour));
		int num = RuntimeServices.UnboxInt32(UnityRuntimeServices.Invoke(theparticle.GetComponent("FlameScript"), "returnLevel", new object[0], typeof(UnityEngine.MonoBehaviour)));
		object obj2 = UnityRuntimeServices.Invoke(theparticle.GetComponent("FlameScript"), "returnTeam", new object[0], typeof(UnityEngine.MonoBehaviour));
		if (!(obj2 is string))
		{
			obj2 = RuntimeServices.Coerce(obj2, typeof(string));
		}
		string text = (string)obj2;
		if ((RuntimeServices.EqualityOperator(obj, AuthGameObject.username) && !aimanager.isAI) || !(text != SpawningScript.team2) || (!photonView.isMine && !aimanager.isAI) || (!ChatScript.isCar && !aimanager.isAI) || currenthealth == 0f || (isafking && !aimanager.isAI) || (!aimanager.isAI && FireGun.isInvincible))
		{
			return;
		}
		if (!isburning)
		{
			object obj3 = obj;
			if (!(obj3 is string))
			{
				obj3 = RuntimeServices.Coerce(obj3, typeof(string));
			}
			curBurnner = (string)obj3;
			((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("startBurn", PhotonTargets.All);
		}
		float num2 = 0f;
		if (shieldobject.active)
		{
			shieldobject.SendMessage("takeDamage", UnityBuiltins.parseInt(0.7f + (float)(num / 160)));
		}
		if ((ChatScript.hasarmor1 && !aimanager.isAI) || (aimanager.isAI && aimanager.armorLevel == 0))
		{
			num2 += 0.1f + UnityBuiltins.parseFloat(ChatScript.levels[2]) / 300f;
		}
		if ((ChatScript.hasarmor2 && !aimanager.isAI) || (aimanager.isAI && aimanager.armorLevel == 1))
		{
			num2 += 0.2f + UnityBuiltins.parseFloat(ChatScript.levels[2]) / 300f;
		}
		if ((ChatScript.hasarmor3 && !aimanager.isAI) || (aimanager.isAI && aimanager.armorLevel == 2))
		{
			num2 += 0.45f + UnityBuiltins.parseFloat(ChatScript.levels[2]) / 300f;
		}
		if ((ChatScript.hasarmor4 && !aimanager.isAI) || (aimanager.isAI && aimanager.armorLevel == 3))
		{
			num2 += 0.65f + UnityBuiltins.parseFloat(ChatScript.levels[2]) / 300f;
		}
		if ((ChatScript.hasarmor5 && !aimanager.isAI) || (ChatScript.hasarmor6 && !aimanager.isAI) || (aimanager.isAI && aimanager.armorLevel == 4))
		{
			num2 += 0.35f + UnityBuiltins.parseFloat(ChatScript.levels[2]) / 300f;
		}
		if (ChatScript.hasarmor7 && !aimanager.isAI)
		{
			num2 += 0.2f + UnityBuiltins.parseFloat(ChatScript.levels[2]) / 300f;
		}
		if (ChatScript.hasarmor8 && !aimanager.isAI)
		{
			num2 += 0.3f + UnityBuiltins.parseFloat(ChatScript.levels[2]) / 300f;
		}
		if (!ChatScript.hasgtrcar || !aimanager.isAI)
		{
		}
		if (!(num2 <= 1f))
		{
			num2 = 1f;
		}
		if (FireGun.grappling)
		{
			FireGun.grappling = false;
			FireGun.stopgrapple = true;
		}
		currenthealth -= ((!aimanager.isAI || TutorialManager.curTutIndex >= 7 || !AuthGameObject.showTutorial) ? ((0.35f + (float)(num / 160)) * (1f - Mathf.Min(num2 * armorHealth + ((!shieldobject.active) ? 0f : 0.85f), 1f))) : 1f);
		stallGlider = true;
		if (!aimanager.isAI)
		{
			if (ChatScript.hasarmor1 || ChatScript.hasarmor2 || ChatScript.hasarmor3 || ChatScript.hasarmor4 || ChatScript.hasarmor5 || ChatScript.hasarmor6 || ChatScript.hasarmor7 || ChatScript.hasarmor8)
			{
				armorHealth -= (0.35f + (float)(num / 160)) * (1f - num2) / 1.5f / 100f;
				armorHealth = Mathf.Max(0f, armorHealth);
			}
			else
			{
				armorHealth = 1f;
			}
		}
		if (!(currenthealth > 0f))
		{
			if ((!isafking || aimanager.isAI) && (aimanager.isAI || !FireGun.isInvincible))
			{
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("findkiller", PhotonTargets.All, obj, (!aimanager.isAI) ? AuthGameObject.username : aimanager.ainame, (!aimanager.isAI) ? ((!(SpawningScript.team2 == "red")) ? true : false) : ((!(aimanager.aiteam == "red")) ? true : false), "burned");
			}
			if (!aimanager.isAI)
			{
				GameObject.Find("HealthEffect").SendMessage("setnfo");
				GameObject.Find("HealthEffect").SendMessage("Fadeout");
			}
			else
			{
				GameObject.Find("/GUI/HealthDisplay").SendMessage("aiDeath", aimanager.aiteam);
			}
			currenthealth = 0f;
			chatGUI.SendMessage("OutsideSystem", RuntimeServices.InvokeBinaryOperator("op_Addition", RuntimeServices.InvokeBinaryOperator("op_Addition", RuntimeServices.InvokeBinaryOperator("op_Addition", obj, " burned "), username), "!"));
			GameObject.Find("/GUI/HealthDisplay").SendMessage("killerusername", RuntimeServices.InvokeBinaryOperator("op_Addition", RuntimeServices.InvokeBinaryOperator("op_Addition", RuntimeServices.InvokeBinaryOperator("op_Addition", obj, " (lvl "), num), " Flamethrower)"));
			if (CTFFlagSender.gotflag && AuthGameObject.gametype == "Capture the Flag" && !aimanager.isAI)
			{
				gameObject.SendMessage("setctf", false);
				gameObject.SendMessage("dropflagdel", maincar.transform.position);
				chatGUI.SendMessage("OutsideSystem", username + " dropped the flag.");
			}
			if ((!isafking || aimanager.isAI) && (aimanager.isAI || !FireGun.isInvincible))
			{
				tchooseGUI.SendMessage("addkiller", obj);
			}
			rounddeaths++;
			updatehealth = true;
			maincar.isKinematic = true;
			IEnumerator enumerator = UnityRuntimeServices.GetEnumerator(killerarr);
			while (enumerator.MoveNext())
			{
				object obj4 = enumerator.Current;
				if (!(obj4 is string))
				{
					obj4 = RuntimeServices.Coerce(obj4, typeof(string));
				}
				string lhs = (string)obj4;
				if (!RuntimeServices.EqualityOperator(lhs, obj) && (!isafking || aimanager.isAI) && !aimanager.isAI && FireGun.isInvincible)
				{
				}
			}
			killerarr.Clear();
			killedby.Clear();
		}
		else
		{
			if (!killedby.ContainsKey(obj))
			{
				killedby.Add(obj, 0.1f + (float)(num / 60));
				killerarr.Add(obj);
			}
			else
			{
				killedby[obj] = RuntimeServices.InvokeBinaryOperator("op_Addition", killedby[obj], 0.1f + (float)(num / 60));
			}
			((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("setsmoke", PhotonTargets.All, currenthealth);
			if (!aimanager.isAI)
			{
				if (!(currenthealth > 15f))
				{
					GameObject.Find("HealthEffect").SendMessage("FadeAt", 65f);
					reseteffects = true;
				}
				else
				{
					GameObject.Find("HealthEffect").SendMessage("FadeTo", (100f - currenthealth) / 1.3f);
				}
			}
		}
		updatehealth = true;
	}

	public virtual void missileHit(string u)
	{
		string text = u.Split("|"[0])[0];
		int num = UnityBuiltins.parseInt(u.Split("|"[0])[1]);
		gameObject.SendMessage("flash");
		if ((!photonView.isMine && !aimanager.isAI) || (!ChatScript.isCar && !aimanager.isAI) || currenthealth == 0f || (isafking && !aimanager.isAI) || (!aimanager.isAI && FireGun.isInvincible))
		{
			return;
		}
		float num2 = 0f;
		if (shieldobject.active)
		{
			shieldobject.SendMessage("takeDamage", UnityBuiltins.parseInt(30 + num / 8));
		}
		if ((ChatScript.hasarmor1 && !aimanager.isAI) || (aimanager.isAI && aimanager.armorLevel == 0))
		{
			num2 += 0.1f + UnityBuiltins.parseFloat(ChatScript.levels[2]) / 300f;
		}
		if ((ChatScript.hasarmor2 && !aimanager.isAI) || (aimanager.isAI && aimanager.armorLevel == 1))
		{
			num2 += 0.2f + UnityBuiltins.parseFloat(ChatScript.levels[2]) / 300f;
		}
		if ((ChatScript.hasarmor3 && !aimanager.isAI) || (aimanager.isAI && aimanager.armorLevel == 2))
		{
			num2 += 0.45f + UnityBuiltins.parseFloat(ChatScript.levels[2]) / 300f;
		}
		if ((ChatScript.hasarmor4 && !aimanager.isAI) || (aimanager.isAI && aimanager.armorLevel == 3))
		{
			num2 += 0.65f + UnityBuiltins.parseFloat(ChatScript.levels[2]) / 300f;
		}
		if ((ChatScript.hasarmor5 && !aimanager.isAI) || (ChatScript.hasarmor6 && !aimanager.isAI) || (aimanager.isAI && aimanager.armorLevel == 4))
		{
			num2 += 0.35f + UnityBuiltins.parseFloat(ChatScript.levels[2]) / 300f;
		}
		if (ChatScript.hasarmor7 && !aimanager.isAI)
		{
			num2 += 0.2f + UnityBuiltins.parseFloat(ChatScript.levels[2]) / 300f;
		}
		if (ChatScript.hasarmor8 && !aimanager.isAI)
		{
			num2 += 0.3f + UnityBuiltins.parseFloat(ChatScript.levels[2]) / 300f;
		}
		if (!ChatScript.hasgtrcar || !aimanager.isAI)
		{
		}
		if (!(num2 <= 1f))
		{
			num2 = 1f;
		}
		if (FireGun.grappling)
		{
			FireGun.grappling = false;
			FireGun.stopgrapple = true;
		}
		float num3 = ((UnityScript.Lang.Extensions.get_length((System.Array)u.Split("|"[0])) <= 2) ? 1f : UnityBuiltins.parseFloat(u.Split("|"[0])[2])) * UnityEngine.Random.Range((float)(10 + num / 8) * (1f - Mathf.Min(num2 * armorHealth + ((!shieldobject.active) ? 0f : 0.85f), 1f)), (float)(15 + num / 8) * (1f - Mathf.Min(num2 * armorHealth + ((!shieldobject.active) ? 0f : 0.85f), 1f)));
		float num4 = num3;
		float num5 = currenthealth;
		currenthealth -= ((!aimanager.isAI || TutorialManager.curTutIndex >= 7 || !AuthGameObject.showTutorial) ? num3 : 1f);
		if (text != MasterServerScript.ainame && text != MasterServerScript.ainame2 && text != MasterServerScript.ainame3)
		{
			PhotonPlayer photonPlayer = usernameToPlayer(text);
			if (photonPlayer != null)
			{
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("hD", photonPlayer, Mathf.RoundToInt(num5 - currenthealth));
			}
		}
		stallGlider = true;
		if (!aimanager.isAI)
		{
			if (ChatScript.hasarmor1 || ChatScript.hasarmor2 || ChatScript.hasarmor3 || ChatScript.hasarmor4 || ChatScript.hasarmor5 || ChatScript.hasarmor6 || ChatScript.hasarmor7 || ChatScript.hasarmor8)
			{
				armorHealth -= (float)UnityEngine.Random.Range(10 + num / 8, 15 + num / 8) * (1f - num2) / 1.5f / 100f;
				armorHealth = Mathf.Max(0f, armorHealth);
			}
			else
			{
				armorHealth = 1f;
			}
		}
		if (!(currenthealth > 0f))
		{
			if ((!isafking || aimanager.isAI) && (aimanager.isAI || !FireGun.isInvincible))
			{
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("findkiller", PhotonTargets.All, text, (!aimanager.isAI) ? AuthGameObject.username : aimanager.ainame, (!aimanager.isAI) ? ((!(SpawningScript.team2 == "red")) ? true : false) : ((!(aimanager.aiteam == "red")) ? true : false), "blew up");
			}
			if (!aimanager.isAI)
			{
				GameObject.Find("HealthEffect").SendMessage("setnfo");
				GameObject.Find("HealthEffect").SendMessage("Fadeout");
			}
			else
			{
				GameObject.Find("/GUI/HealthDisplay").SendMessage("aiDeath", aimanager.aiteam);
			}
			currenthealth = 0f;
			chatGUI.SendMessage("OutsideSystem", text + " blew up " + username + "!");
			GameObject.Find("/GUI/HealthDisplay").SendMessage("killerusername", text + " (lvl " + num + " Missile Launcher)");
			if (CTFFlagSender.gotflag && AuthGameObject.gametype == "Capture the Flag" && !aimanager.isAI)
			{
				gameObject.SendMessage("setctf", false);
				gameObject.SendMessage("dropflagdel", maincar.transform.position);
				chatGUI.SendMessage("OutsideSystem", username + " dropped the flag.");
			}
			if ((!isafking || aimanager.isAI) && (aimanager.isAI || !FireGun.isInvincible))
			{
				tchooseGUI.SendMessage("addkiller", text);
			}
			rounddeaths++;
			updatehealth = true;
			maincar.isKinematic = true;
			IEnumerator enumerator = UnityRuntimeServices.GetEnumerator(killerarr);
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				if (!(obj is string))
				{
					obj = RuntimeServices.Coerce(obj, typeof(string));
				}
				string text2 = (string)obj;
				if (text2 != text && (!isafking || aimanager.isAI) && !aimanager.isAI && FireGun.isInvincible)
				{
				}
			}
			killerarr.Clear();
			killedby.Clear();
		}
		else
		{
			if (!killedby.ContainsKey(text))
			{
				killedby.Add(text, 12 + num / 2);
				killerarr.Add(text);
			}
			else
			{
				killedby[text] = RuntimeServices.InvokeBinaryOperator("op_Addition", killedby[text], 12 + num / 2);
			}
			((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("setsmoke", PhotonTargets.All, currenthealth);
			if (!aimanager.isAI)
			{
				if (!(currenthealth > 15f))
				{
					GameObject.Find("HealthEffect").SendMessage("FadeAt", 65f);
					reseteffects = true;
				}
				else
				{
					GameObject.Find("HealthEffect").SendMessage("FadeTo", (100f - currenthealth) / 1.3f);
				}
			}
		}
		updatehealth = true;
	}

	public virtual void rockethit(string u)
	{
		string text = u.Split("|"[0])[0];
		int num = UnityBuiltins.parseInt(u.Split("|"[0])[1]);
		gameObject.SendMessage("flash");
		if ((!photonView.isMine && !aimanager.isAI) || (!ChatScript.isCar && !aimanager.isAI) || currenthealth == 0f || (isafking && !aimanager.isAI) || (!aimanager.isAI && FireGun.isInvincible))
		{
			return;
		}
		float num2 = 0f;
		if (shieldobject.active)
		{
			shieldobject.SendMessage("takeDamage", UnityBuiltins.parseInt(50 + num / 5));
		}
		if ((ChatScript.hasarmor1 && !aimanager.isAI) || (aimanager.isAI && aimanager.armorLevel == 0))
		{
			num2 += 0.1f + UnityBuiltins.parseFloat(ChatScript.levels[2]) / 300f;
		}
		if ((ChatScript.hasarmor2 && !aimanager.isAI) || (aimanager.isAI && aimanager.armorLevel == 1))
		{
			num2 += 0.2f + UnityBuiltins.parseFloat(ChatScript.levels[2]) / 300f;
		}
		if ((ChatScript.hasarmor3 && !aimanager.isAI) || (aimanager.isAI && aimanager.armorLevel == 2))
		{
			num2 += 0.45f + UnityBuiltins.parseFloat(ChatScript.levels[2]) / 300f;
		}
		if ((ChatScript.hasarmor4 && !aimanager.isAI) || (aimanager.isAI && aimanager.armorLevel == 3))
		{
			num2 += 0.65f + UnityBuiltins.parseFloat(ChatScript.levels[2]) / 300f;
		}
		if ((ChatScript.hasarmor5 && !aimanager.isAI) || (ChatScript.hasarmor6 && !aimanager.isAI) || (aimanager.isAI && aimanager.armorLevel == 4))
		{
			num2 += 0.35f + UnityBuiltins.parseFloat(ChatScript.levels[2]) / 300f;
		}
		if (ChatScript.hasarmor7 && !aimanager.isAI)
		{
			num2 += 0.2f + UnityBuiltins.parseFloat(ChatScript.levels[2]) / 300f;
		}
		if (ChatScript.hasarmor8 && !aimanager.isAI)
		{
			num2 += 0.3f + UnityBuiltins.parseFloat(ChatScript.levels[2]) / 300f;
		}
		if (!ChatScript.hasgtrcar || !aimanager.isAI)
		{
		}
		if (!(num2 <= 1f))
		{
			num2 = 1f;
		}
		if (FireGun.grappling)
		{
			FireGun.grappling = false;
			FireGun.stopgrapple = true;
		}
		float num3 = ((UnityScript.Lang.Extensions.get_length((System.Array)u.Split("|"[0])) <= 2) ? 1f : UnityBuiltins.parseFloat(u.Split("|"[0])[2])) * UnityEngine.Random.Range((float)(30 + num / 5) * (1f - Mathf.Min(num2 * armorHealth + ((!shieldobject.active) ? 0f : 0.85f), 1f)), (float)(40 + num / 5) * (1f - Mathf.Min(num2 * armorHealth + ((!shieldobject.active) ? 0f : 0.85f), 1f)));
		float num4 = num3;
		float num5 = currenthealth;
		currenthealth -= ((!aimanager.isAI || TutorialManager.curTutIndex >= 7 || !AuthGameObject.showTutorial) ? num4 : 1f);
		if (text != MasterServerScript.ainame && text != MasterServerScript.ainame2 && text != MasterServerScript.ainame3)
		{
			PhotonPlayer photonPlayer = usernameToPlayer(text);
			if (photonPlayer != null)
			{
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("hD", photonPlayer, Mathf.RoundToInt(num5 - currenthealth));
			}
		}
		stallGlider = true;
		if (AuthGameObject.showTutorial && !aimanager.isAI)
		{
			currenthealth = Mathf.Max(currenthealth, 5f);
		}
		if (!aimanager.isAI)
		{
			if (ChatScript.hasarmor1 || ChatScript.hasarmor2 || ChatScript.hasarmor3 || ChatScript.hasarmor4 || ChatScript.hasarmor5 || ChatScript.hasarmor6 || ChatScript.hasarmor7 || ChatScript.hasarmor8)
			{
				armorHealth -= (float)UnityEngine.Random.Range(30 + num / 5, 40 + num / 5) * (1f - num2) / 1.5f / 100f;
				armorHealth = Mathf.Max(0f, armorHealth);
			}
			else
			{
				armorHealth = 1f;
			}
		}
		if (!(currenthealth > 0f))
		{
			if ((!isafking || aimanager.isAI) && (aimanager.isAI || !FireGun.isInvincible))
			{
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("findkiller", PhotonTargets.All, text, (!aimanager.isAI) ? AuthGameObject.username : aimanager.ainame, (!aimanager.isAI) ? ((!(SpawningScript.team2 == "red")) ? true : false) : ((!(aimanager.aiteam == "red")) ? true : false), "blew up");
			}
			if (!aimanager.isAI)
			{
				GameObject.Find("HealthEffect").SendMessage("setnfo");
				GameObject.Find("HealthEffect").SendMessage("Fadeout");
			}
			else
			{
				GameObject.Find("/GUI/HealthDisplay").SendMessage("aiDeath", aimanager.aiteam);
			}
			currenthealth = 0f;
			chatGUI.SendMessage("OutsideSystem", text + " blew up " + username + "!");
			GameObject.Find("/GUI/HealthDisplay").SendMessage("killerusername", text + " (lvl " + num + " Rocket Launcher)");
			if (CTFFlagSender.gotflag && AuthGameObject.gametype == "Capture the Flag" && !aimanager.isAI)
			{
				gameObject.SendMessage("setctf", false);
				gameObject.SendMessage("dropflagdel", maincar.transform.position);
				chatGUI.SendMessage("OutsideSystem", username + " dropped the flag.");
			}
			if ((!isafking || aimanager.isAI) && (aimanager.isAI || !FireGun.isInvincible))
			{
				tchooseGUI.SendMessage("addkiller", text);
			}
			rounddeaths++;
			maincar.isKinematic = true;
			updatehealth = true;
			IEnumerator enumerator = UnityRuntimeServices.GetEnumerator(killerarr);
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				if (!(obj is string))
				{
					obj = RuntimeServices.Coerce(obj, typeof(string));
				}
				string text2 = (string)obj;
				if (text2 != text && (!isafking || aimanager.isAI) && !aimanager.isAI && FireGun.isInvincible)
				{
				}
			}
			killerarr.Clear();
			killedby.Clear();
		}
		else
		{
			if (!killedby.ContainsKey(text))
			{
				killedby.Add(text, 30 + num / 5);
				killerarr.Add(text);
			}
			else
			{
				killedby[text] = RuntimeServices.InvokeBinaryOperator("op_Addition", killedby[text], 30 + num / 5);
			}
			((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("setsmoke", PhotonTargets.All, currenthealth);
			if (!aimanager.isAI)
			{
				if (!(currenthealth > 15f))
				{
					GameObject.Find("HealthEffect").SendMessage("FadeAt", 65f);
					reseteffects = true;
				}
				else
				{
					GameObject.Find("HealthEffect").SendMessage("FadeTo", (100f - currenthealth) / 1.3f);
				}
			}
		}
		updatehealth = true;
	}

	public virtual void laserCannonHit(string u)
	{
		string text = u.Split("|"[0])[0];
		int num = UnityBuiltins.parseInt(u.Split("|"[0])[1]);
		string text2 = u.Split("|"[0])[2];
		gameObject.SendMessage("flash");
		if ((!photonView.isMine && !aimanager.isAI) || (!ChatScript.isCar && !aimanager.isAI) || currenthealth == 0f || (isafking && !aimanager.isAI) || (!aimanager.isAI && FireGun.isInvincible) || (!(text2 != SpawningScript.team2) && !AuthGameObject.ff && !aimanager.isAI))
		{
			return;
		}
		float num2 = 0f;
		if (shieldobject.active)
		{
			shieldobject.SendMessage("takeDamage", UnityBuiltins.parseInt(100 + num / 2));
		}
		if ((ChatScript.hasarmor1 && !aimanager.isAI) || (aimanager.isAI && aimanager.armorLevel == 0))
		{
			num2 += 0.1f + UnityBuiltins.parseFloat(ChatScript.levels[2]) / 300f;
		}
		if ((ChatScript.hasarmor2 && !aimanager.isAI) || (aimanager.isAI && aimanager.armorLevel == 1))
		{
			num2 += 0.2f + UnityBuiltins.parseFloat(ChatScript.levels[2]) / 300f;
		}
		if ((ChatScript.hasarmor3 && !aimanager.isAI) || (aimanager.isAI && aimanager.armorLevel == 2))
		{
			num2 += 0.45f + UnityBuiltins.parseFloat(ChatScript.levels[2]) / 300f;
		}
		if ((ChatScript.hasarmor4 && !aimanager.isAI) || (aimanager.isAI && aimanager.armorLevel == 3))
		{
			num2 += 0.65f + UnityBuiltins.parseFloat(ChatScript.levels[2]) / 300f;
		}
		if ((ChatScript.hasarmor5 && !aimanager.isAI) || (ChatScript.hasarmor6 && !aimanager.isAI) || (aimanager.isAI && aimanager.armorLevel == 4))
		{
			num2 += 0.35f + UnityBuiltins.parseFloat(ChatScript.levels[2]) / 300f;
		}
		if (ChatScript.hasarmor7 && !aimanager.isAI)
		{
			num2 += 0.2f + UnityBuiltins.parseFloat(ChatScript.levels[2]) / 300f;
		}
		if (ChatScript.hasarmor8 && !aimanager.isAI)
		{
			num2 += 0.3f + UnityBuiltins.parseFloat(ChatScript.levels[2]) / 300f;
		}
		if (!ChatScript.hasgtrcar || !aimanager.isAI)
		{
		}
		if (!(num2 <= 1f))
		{
			num2 = 1f;
		}
		if (FireGun.grappling)
		{
			FireGun.grappling = false;
			FireGun.stopgrapple = true;
		}
		float f = ((UnityScript.Lang.Extensions.get_length((System.Array)u.Split("|"[0])) <= 3) ? 1f : UnityBuiltins.parseFloat(u.Split("|"[0])[3])) * (float)UnityBuiltins.parseInt(100 + num / 2) * (1f - Mathf.Min(num2 * armorHealth + ((!shieldobject.active) ? 0f : 0.85f), 1f));
		float num3 = currenthealth;
		currenthealth -= ((!aimanager.isAI || TutorialManager.curTutIndex >= 7 || !AuthGameObject.showTutorial) ? Mathf.Round(f) : 1f);
		if (text != MasterServerScript.ainame && text != MasterServerScript.ainame2 && text != MasterServerScript.ainame3)
		{
			PhotonPlayer photonPlayer = usernameToPlayer(text);
			if (photonPlayer != null)
			{
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("hD", photonPlayer, Mathf.RoundToInt(num3 - currenthealth));
			}
		}
		stallGlider = true;
		if (!aimanager.isAI)
		{
			if (ChatScript.hasarmor1 || ChatScript.hasarmor2 || ChatScript.hasarmor3 || ChatScript.hasarmor4 || ChatScript.hasarmor5 || ChatScript.hasarmor6 || ChatScript.hasarmor7 || ChatScript.hasarmor8)
			{
				armorHealth -= (float)UnityBuiltins.parseInt(100 + num / 2) * (1f - num2) / 1.5f / 100f;
				armorHealth = Mathf.Max(0f, armorHealth);
			}
			else
			{
				armorHealth = 1f;
			}
		}
		if (!(currenthealth > 0f))
		{
			if ((!isafking || aimanager.isAI) && (aimanager.isAI || !FireGun.isInvincible))
			{
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("findkiller", PhotonTargets.All, text, (!aimanager.isAI) ? AuthGameObject.username : aimanager.ainame, (!aimanager.isAI) ? ((!(SpawningScript.team2 == "red")) ? true : false) : ((!(aimanager.aiteam == "red")) ? true : false), "fried");
			}
			if (!aimanager.isAI)
			{
				GameObject.Find("HealthEffect").SendMessage("setnfo");
				GameObject.Find("HealthEffect").SendMessage("Fadeout");
			}
			else
			{
				GameObject.Find("/GUI/HealthDisplay").SendMessage("aiDeath", aimanager.aiteam);
			}
			currenthealth = 0f;
			chatGUI.SendMessage("OutsideSystem", text + " fried " + username + "!");
			GameObject.Find("/GUI/HealthDisplay").SendMessage("killerusername", text + " (lvl " + num + " Laser Cannon)");
			if (CTFFlagSender.gotflag && AuthGameObject.gametype == "Capture the Flag" && !aimanager.isAI)
			{
				gameObject.SendMessage("setctf", false);
				gameObject.SendMessage("dropflagdel", maincar.transform.position);
				chatGUI.SendMessage("OutsideSystem", username + " dropped the flag.");
			}
			if ((!isafking || aimanager.isAI) && (aimanager.isAI || !FireGun.isInvincible))
			{
				tchooseGUI.SendMessage("addkiller", text);
			}
			rounddeaths++;
			updatehealth = true;
			maincar.isKinematic = true;
			IEnumerator enumerator = UnityRuntimeServices.GetEnumerator(killerarr);
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				if (!(obj is string))
				{
					obj = RuntimeServices.Coerce(obj, typeof(string));
				}
				string text3 = (string)obj;
				if (text3 != text && (!isafking || aimanager.isAI) && !aimanager.isAI && FireGun.isInvincible)
				{
				}
			}
			killerarr.Clear();
			killedby.Clear();
		}
		else
		{
			if (!killedby.ContainsKey(text))
			{
				killedby.Add(text, 100 + num / 2);
				killerarr.Add(text);
			}
			else
			{
				killedby[text] = RuntimeServices.InvokeBinaryOperator("op_Addition", killedby[text], 100 + num / 2);
			}
			((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("setsmoke", PhotonTargets.All, currenthealth);
			if (!aimanager.isAI)
			{
				if (!(currenthealth > 15f))
				{
					GameObject.Find("HealthEffect").SendMessage("FadeAt", 65f);
					reseteffects = true;
				}
				else
				{
					GameObject.Find("HealthEffect").SendMessage("FadeTo", (100f - currenthealth) / 1.3f);
				}
			}
		}
		updatehealth = true;
	}

	public virtual void laserhit(string u)
	{
		string text = u.Split("|"[0])[0];
		int num = UnityBuiltins.parseInt(u.Split("|"[0])[1]);
		gameObject.SendMessage("flash");
		if ((!photonView.isMine && !aimanager.isAI) || (!ChatScript.isCar && !aimanager.isAI) || currenthealth == 0f || (isafking && !aimanager.isAI) || (!aimanager.isAI && FireGun.isInvincible))
		{
			return;
		}
		float num2 = 0f;
		if (shieldobject.active)
		{
			shieldobject.SendMessage("takeDamage", UnityBuiltins.parseInt(15 + num / 5));
		}
		if ((ChatScript.hasarmor1 && !aimanager.isAI) || (aimanager.isAI && aimanager.armorLevel == 0))
		{
			num2 += 0.1f + UnityBuiltins.parseFloat(ChatScript.levels[2]) / 300f;
		}
		if ((ChatScript.hasarmor2 && !aimanager.isAI) || (aimanager.isAI && aimanager.armorLevel == 1))
		{
			num2 += 0.2f + UnityBuiltins.parseFloat(ChatScript.levels[2]) / 300f;
		}
		if ((ChatScript.hasarmor3 && !aimanager.isAI) || (aimanager.isAI && aimanager.armorLevel == 2))
		{
			num2 += 0.45f + UnityBuiltins.parseFloat(ChatScript.levels[2]) / 300f;
		}
		if ((ChatScript.hasarmor4 && !aimanager.isAI) || (aimanager.isAI && aimanager.armorLevel == 3))
		{
			num2 += 0.65f + UnityBuiltins.parseFloat(ChatScript.levels[2]) / 300f;
		}
		if ((ChatScript.hasarmor5 && !aimanager.isAI) || (ChatScript.hasarmor6 && !aimanager.isAI) || (aimanager.isAI && aimanager.armorLevel == 4))
		{
			num2 += 0.35f + UnityBuiltins.parseFloat(ChatScript.levels[2]) / 300f;
		}
		if (ChatScript.hasarmor7 && !aimanager.isAI)
		{
			num2 += 0.2f + UnityBuiltins.parseFloat(ChatScript.levels[2]) / 300f;
		}
		if (ChatScript.hasarmor8 && !aimanager.isAI)
		{
			num2 += 0.3f + UnityBuiltins.parseFloat(ChatScript.levels[2]) / 300f;
		}
		if (!ChatScript.hasgtrcar || !aimanager.isAI)
		{
		}
		if (!(num2 <= 1f))
		{
			num2 = 1f;
		}
		if (FireGun.grappling)
		{
			FireGun.grappling = false;
			FireGun.stopgrapple = true;
		}
		float num3 = ((UnityScript.Lang.Extensions.get_length((System.Array)u.Split("|"[0])) <= 2) ? 1f : UnityBuiltins.parseFloat(u.Split("|"[0])[2])) * UnityEngine.Random.Range((float)(3 + num / 5) * (1f - Mathf.Min(num2 * armorHealth + ((!shieldobject.active) ? 0f : 0.85f), 1f)), (float)(6 + num / 5) * (1f - Mathf.Min(num2 * armorHealth + ((!shieldobject.active) ? 0f : 0.85f), 1f)));
		float num4 = num3;
		float num5 = currenthealth;
		currenthealth -= ((!aimanager.isAI || TutorialManager.curTutIndex >= 7 || !AuthGameObject.showTutorial) ? num4 : 1f);
		if (text != MasterServerScript.ainame && text != MasterServerScript.ainame2 && text != MasterServerScript.ainame3)
		{
			PhotonPlayer photonPlayer = usernameToPlayer(text);
			if (photonPlayer != null)
			{
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("hD", photonPlayer, Mathf.RoundToInt(num5 - currenthealth));
			}
		}
		stallGlider = true;
		if (AuthGameObject.showTutorial && !aimanager.isAI)
		{
			currenthealth = Mathf.Max(currenthealth, 5f);
		}
		if (!aimanager.isAI)
		{
			if (ChatScript.hasarmor1 || ChatScript.hasarmor2 || ChatScript.hasarmor3 || ChatScript.hasarmor4 || ChatScript.hasarmor5 || ChatScript.hasarmor6 || ChatScript.hasarmor7 || ChatScript.hasarmor8)
			{
				armorHealth -= (float)UnityEngine.Random.Range(3 + num / 5, 6 + num / 5) * (1f - num2) / 1.5f / 100f;
				armorHealth = Mathf.Max(0f, armorHealth);
			}
			else
			{
				armorHealth = 1f;
			}
		}
		if (!(currenthealth > 0f))
		{
			if ((!isafking || aimanager.isAI) && (aimanager.isAI || !FireGun.isInvincible))
			{
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("findkiller", PhotonTargets.All, text, (!aimanager.isAI) ? AuthGameObject.username : aimanager.ainame, (!aimanager.isAI) ? ((!(SpawningScript.team2 == "red")) ? true : false) : ((!(aimanager.aiteam == "red")) ? true : false), "zapped");
			}
			if (!aimanager.isAI)
			{
				GameObject.Find("HealthEffect").SendMessage("setnfo");
				GameObject.Find("HealthEffect").SendMessage("Fadeout");
			}
			else
			{
				GameObject.Find("/GUI/HealthDisplay").SendMessage("aiDeath", aimanager.aiteam);
			}
			currenthealth = 0f;
			chatGUI.SendMessage("OutsideSystem", text + " zapped " + username + "!");
			GameObject.Find("/GUI/HealthDisplay").SendMessage("killerusername", text + " (lvl " + num + " Plasma Blaster)");
			if (CTFFlagSender.gotflag && AuthGameObject.gametype == "Capture the Flag" && !aimanager.isAI)
			{
				gameObject.SendMessage("setctf", false);
				gameObject.SendMessage("dropflagdel", maincar.transform.position);
				chatGUI.SendMessage("OutsideSystem", username + " dropped the flag.");
			}
			if ((!isafking || aimanager.isAI) && (aimanager.isAI || !FireGun.isInvincible))
			{
				tchooseGUI.SendMessage("addkiller", text);
			}
			rounddeaths++;
			updatehealth = true;
			maincar.isKinematic = true;
			IEnumerator enumerator = UnityRuntimeServices.GetEnumerator(killerarr);
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				if (!(obj is string))
				{
					obj = RuntimeServices.Coerce(obj, typeof(string));
				}
				string text2 = (string)obj;
				if (text2 != text && (!isafking || aimanager.isAI) && !aimanager.isAI && FireGun.isInvincible)
				{
				}
			}
			killerarr.Clear();
			killedby.Clear();
		}
		else
		{
			if (!killedby.ContainsKey(text))
			{
				killedby.Add(text, 5 + num / 3);
				killerarr.Add(text);
			}
			else
			{
				killedby[text] = RuntimeServices.InvokeBinaryOperator("op_Addition", killedby[text], 5 + num / 3);
			}
			((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("setsmoke", PhotonTargets.All, currenthealth);
			if (!aimanager.isAI)
			{
				if (!(currenthealth > 15f))
				{
					GameObject.Find("HealthEffect").SendMessage("FadeAt", 65f);
					reseteffects = true;
				}
				else
				{
					GameObject.Find("HealthEffect").SendMessage("FadeTo", (100f - currenthealth) / 1.3f);
				}
			}
		}
		updatehealth = true;
	}

	[RPC]
	public virtual void youHelpedToKill(string u, int i, string deaduser, bool team)
	{
	}

	[RPC]
	public virtual void dropWeapon(string s, Vector3 t, string team, PhotonViewID id)
	{
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(weaponDropPrefab, t, Quaternion.identity);
		((PhotonView)gameObject.GetComponent(typeof(PhotonView))).viewID = id;
		UnityRuntimeServices.Invoke(gameObject.GetComponent("DroppedWeaponScript"), "setWeapon", new object[2] { s, team }, typeof(UnityEngine.MonoBehaviour));
	}

	[RPC]
	public virtual void setsmoke(float i)
	{
		if (!(i <= 40f))
		{
			enginesmoke.emit = false;
			return;
		}
		enginesmoke.emit = true;
		if (!(i >= 15f))
		{
			i = 15f;
		}
		enginesmoke.minEmission = 60f * (1f - (i - 15f) / 25f);
		enginesmoke.maxEmission = 80f * (1f - (i - 15f) / 25f);
	}

	public virtual string returnGold()
	{
		string text = goldearned;
		string text2 = string.Empty;
		for (int i = 0; i < UnityScript.Lang.Extensions.get_length(text); i++)
		{
			if (text.Substring(i, 1) == "a")
			{
				text2 += "0";
			}
			if (text.Substring(i, 1) == "b")
			{
				text2 += "1";
			}
			if (text.Substring(i, 1) == "c")
			{
				text2 += "2";
			}
			if (text.Substring(i, 1) == "d")
			{
				text2 += "3";
			}
			if (text.Substring(i, 1) == "e")
			{
				text2 += "4";
			}
			if (text.Substring(i, 1) == "f")
			{
				text2 += "5";
			}
			if (text.Substring(i, 1) == "g")
			{
				text2 += "6";
			}
			if (text.Substring(i, 1) == "h")
			{
				text2 += "7";
			}
			if (text.Substring(i, 1) == "i")
			{
				text2 += "8";
			}
			if (text.Substring(i, 1) == "j")
			{
				text2 += "9";
			}
		}
		return text2;
	}

	public virtual string returnGoldEncrypted()
	{
		string text = goldearned;
		string text2 = null;
		for (int i = 0; i < UnityScript.Lang.Extensions.get_length(text); i++)
		{
			if (text.Substring(i, 1) == "0")
			{
				text2 += "a";
			}
			if (text.Substring(i, 1) == "1")
			{
				text2 += "b";
			}
			if (text.Substring(i, 1) == "2")
			{
				text2 += "c";
			}
			if (text.Substring(i, 1) == "3")
			{
				text2 += "d";
			}
			if (text.Substring(i, 1) == "4")
			{
				text2 += "e";
			}
			if (text.Substring(i, 1) == "5")
			{
				text2 += "f";
			}
			if (text.Substring(i, 1) == "6")
			{
				text2 += "g";
			}
			if (text.Substring(i, 1) == "7")
			{
				text2 += "h";
			}
			if (text.Substring(i, 1) == "8")
			{
				text2 += "i";
			}
			if (text.Substring(i, 1) == "9")
			{
				text2 += "j";
			}
		}
		return text2;
	}

	public virtual void grabGold()
	{
	}

	public virtual IEnumerator aiWin(string s)
	{
		return new _0024aiWin_00244147(s, this).GetEnumerator();
	}

	[RPC]
	public virtual IEnumerator findkiller(string u, string deaduser, bool team, string action, PhotonMessageInfo info)
	{
		return new _0024findkiller_00244153(u, deaduser, team, action, this).GetEnumerator();
	}

	[RPC]
	public virtual void hD(int amnt)
	{
		damageDisplay.addDamage(amnt, transform.position);
	}

	public virtual PhotonPlayer usernameToPlayer(string u)
	{
		IEnumerator enumerator = UnityRuntimeServices.GetEnumerator(SpawningScript.netPlayers);
		object result;
		while (true)
		{
			if (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				if (!(obj is NetPlayer))
				{
					obj = RuntimeServices.Coerce(obj, typeof(NetPlayer));
				}
				NetPlayer netPlayer = (NetPlayer)obj;
				if (netPlayer.username == u)
				{
					result = netPlayer.nplayer;
					break;
				}
				continue;
			}
			result = null;
			break;
		}
		return (PhotonPlayer)result;
	}

	public virtual void Main()
	{
		origtags = new Hashtable();
		origtagsreal = new Hashtable();
		killedby = new Hashtable();
	}
}
