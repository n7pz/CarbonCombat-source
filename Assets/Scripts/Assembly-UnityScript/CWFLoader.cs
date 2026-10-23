using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using Photon;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class CWFLoader : Photon.MonoBehaviour
{
	[Serializable]
	internal sealed class _0024getRating_00243409 : GenericGenerator<WWW>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WWW>, IEnumerator
		{
			internal WWW _0024www_00243410;

			internal string _0024w_00243411;

			internal CWFLoader _0024self__00243412;

			public _0024(string w, CWFLoader self_)
			{
				_0024w_00243411 = w;
				_0024self__00243412 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024www_00243410 = new WWW("http://72.14.184.180/worldRating.php?query=returnRating&fname=" + _0024w_00243411.Replace("http://72.14.184.180/Worlds/", string.Empty));
					result = (Yield(2, _0024www_00243410) ? 1 : 0);
					break;
				case 2:
					if (string.IsNullOrEmpty(_0024www_00243410.error) && _0024www_00243410.text != string.Empty && _0024www_00243410.text.Contains("R="))
					{
						_0024self__00243412.curRating = "(Rated " + (Mathf.Round(UnityBuiltins.parseFloat(_0024www_00243410.text.Replace("R=", string.Empty).Split("|"[0])[0]) * 10f) / 10f).ToString() + "/5)";
					}
					else
					{
						_0024self__00243412.curRating = "(No rating)";
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

		internal string _0024w_00243413;

		internal CWFLoader _0024self__00243414;

		public _0024getRating_00243409(string w, CWFLoader self_)
		{
			_0024w_00243413 = w;
			_0024self__00243414 = self_;
		}

		public override IEnumerator<WWW> GetEnumerator()
		{
			return new _0024(_0024w_00243413, _0024self__00243414);
		}
	}

	[Serializable]
	internal sealed class _0024setRating_00243415 : GenericGenerator<WWW>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WWW>, IEnumerator
		{
			internal WWW _0024www_00243416;

			internal int _0024i_00243417;

			internal CWFLoader _0024self__00243418;

			public _0024(int i, CWFLoader self_)
			{
				_0024i_00243417 = i;
				_0024self__00243418 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00243418.myRating = _0024i_00243417;
					_0024www_00243416 = new WWW("http://72.14.184.180/worldRating.php?fname=" + worldURL.Replace("http://72.14.184.180/Worlds/", string.Empty) + "&rating=" + _0024self__00243418.myRating.ToString());
					result = (Yield(2, _0024www_00243416) ? 1 : 0);
					break;
				case 2:
					if (string.IsNullOrEmpty(_0024www_00243416.error) && _0024www_00243416.text != string.Empty && _0024www_00243416.text.Contains("R="))
					{
						_0024self__00243418.curRating = "(Rated " + (Mathf.Round(UnityBuiltins.parseFloat(_0024www_00243416.text.Replace("R=", string.Empty).Split("|"[0])[0]) * 10f) / 10f).ToString() + "/5)";
					}
					else
					{
						_0024self__00243418.curRating = "(Loading...)";
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

		internal int _0024i_00243419;

		internal CWFLoader _0024self__00243420;

		public _0024setRating_00243415(int i, CWFLoader self_)
		{
			_0024i_00243419 = i;
			_0024self__00243420 = self_;
		}

		public override IEnumerator<WWW> GetEnumerator()
		{
			return new _0024(_0024i_00243419, _0024self__00243420);
		}
	}

	[Serializable]
	internal sealed class _0024Start_00243421 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string[] _0024chunks_00243422;

			internal string _0024bluespawn_00243423;

			internal string _0024redspawn_00243424;

			internal int _0024counter_00243425;

			internal string _0024str_00243426;

			internal string _0024pos_00243427;

			internal string _0024rot_00243428;

			internal string _0024scale_00243429;

			internal GameObject _0024obj_00243430;

			internal OBJ _0024loadObj_00243431;

			internal int _0024_0024440_00243432;

			internal string[] _0024_0024441_00243433;

			internal int _0024_0024442_00243434;

			internal Vector3 _0024_00241899_00243435;

			internal Quaternion _0024_00241900_00243436;

			internal Vector3 _0024_00241901_00243437;

			internal Quaternion _0024_00241902_00243438;

			internal float _0024_00241903_00243439;

			internal Vector3 _0024_00241904_00243440;

			internal CWFLoader _0024self__00243441;

			public _0024(CWFLoader self_)
			{
				_0024self__00243441 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
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
					if (PhotonNetwork.isMasterClient)
					{
						_0024self__00243441.setUpData();
					}
					goto case 7;
				case 7:
					result = (((!_0024self__00243441.worldDataLoading || PhotonNetwork.isMasterClient) ? YieldDefault(8) : YieldDefault(7)) ? 1 : 0);
					break;
				case 8:
					result = (YieldDefault(9) ? 1 : 0);
					break;
				case 9:
				{
					_0024chunks_00243422 = worldData.Split("$"[0]);
					GameObject.Find("/Plane").renderer.material.SetTexture("_MainTex", _0024self__00243441.planeTex[UnityBuiltins.parseInt(_0024chunks_00243422[0].Split("*"[0])[1])]);
					RuntimeServices.SetProperty(_0024self__00243441.mserver, "gamenamestring", WWW.UnEscapeURL(_0024chunks_00243422[0].Split("*"[0])[0]).Replace("[Get]", string.Empty));
					_0024bluespawn_00243423 = _0024chunks_00243422[0].Split("*"[0])[2];
					_0024redspawn_00243424 = _0024chunks_00243422[0].Split("*"[0])[3];
					GameObject.Find("/BlueSpawn").transform.position = new Vector3(UnityBuiltins.parseFloat(_0024bluespawn_00243423.Split("#"[0])[0].Split(","[0])[0]), UnityBuiltins.parseFloat(_0024bluespawn_00243423.Split("#"[0])[0].Split(","[0])[1]), UnityBuiltins.parseFloat(_0024bluespawn_00243423.Split("#"[0])[0].Split(","[0])[2]));
					Vector3 vector = (_0024_00241899_00243435 = new Vector3(UnityBuiltins.parseFloat(_0024bluespawn_00243423.Split("#"[0])[1].Split(","[0])[0]), UnityBuiltins.parseFloat(_0024bluespawn_00243423.Split("#"[0])[1].Split(","[0])[1]), UnityBuiltins.parseFloat(_0024bluespawn_00243423.Split("#"[0])[1].Split(","[0])[2])));
					Quaternion quaternion = (_0024_00241900_00243436 = GameObject.Find("/BlueSpawn").transform.rotation);
					Vector3 vector2 = (_0024_00241900_00243436.eulerAngles = _0024_00241899_00243435);
					Quaternion quaternion2 = (GameObject.Find("/BlueSpawn").transform.rotation = _0024_00241900_00243436);
					GameObject.Find("/RedSpawn").transform.position = new Vector3(UnityBuiltins.parseFloat(_0024redspawn_00243424.Split("#"[0])[0].Split(","[0])[0]), UnityBuiltins.parseFloat(_0024redspawn_00243424.Split("#"[0])[0].Split(","[0])[1]), UnityBuiltins.parseFloat(_0024redspawn_00243424.Split("#"[0])[0].Split(","[0])[2]));
					Vector3 vector4 = (_0024_00241901_00243437 = new Vector3(UnityBuiltins.parseFloat(_0024redspawn_00243424.Split("#"[0])[1].Split(","[0])[0]), UnityBuiltins.parseFloat(_0024redspawn_00243424.Split("#"[0])[1].Split(","[0])[1]), UnityBuiltins.parseFloat(_0024redspawn_00243424.Split("#"[0])[1].Split(","[0])[2])));
					Quaternion quaternion4 = (_0024_00241902_00243438 = GameObject.Find("/RedSpawn").transform.rotation);
					Vector3 vector5 = (_0024_00241902_00243438.eulerAngles = _0024_00241901_00243437);
					Quaternion quaternion5 = (GameObject.Find("/RedSpawn").transform.rotation = _0024_00241902_00243438);
					Camera.main.transform.position = GameObject.Find("/RedSpawn").transform.position;
					float num = (_0024_00241903_00243439 = Camera.main.transform.position.y + 55f);
					Vector3 vector7 = (_0024_00241904_00243440 = Camera.main.transform.position);
					float num2 = (_0024_00241904_00243440.y = _0024_00241903_00243439);
					Vector3 vector8 = (Camera.main.transform.position = _0024_00241904_00243440);
					Camera.main.transform.LookAt(GameObject.Find("/RedSpawn").transform);
					GameObject.Find("/BotSpectator").transform.position = GameObject.Find("/BlueSpawn").transform.position;
					GameObject.Find("/BotSpectator").transform.rotation = GameObject.Find("/BlueSpawn").transform.rotation;
					_0024counter_00243425 = 0;
					_0024_0024440_00243432 = 0;
					_0024_0024441_00243433 = _0024chunks_00243422[1].Split("*"[0]);
					_0024_0024442_00243434 = _0024_0024441_00243433.Length;
					goto IL_143f;
				}
				case 10:
					if (!(Collider)_0024obj_00243430.GetComponent(typeof(Collider)))
					{
						result = (YieldDefault(10) ? 1 : 0);
						break;
					}
					_0024self__00243441.meshCache.Add(_0024chunks_00243422[2].Split(","[0])[_0024counter_00243425], _0024obj_00243430);
					goto IL_1058;
				case 11:
					_0024_0024440_00243432++;
					goto IL_143f;
				case 12:
					UnityEngine.Object.Destroy(Camera.main.GetComponent("ForgeCubePrimativeTile"));
					_0024self__00243441.statparent.gameObject.AddComponent("CombineChildren");
					GameObject.Find("/GUI/Chat").SendMessage("OutsideSystemNoRPC", RuntimeServices.InvokeBinaryOperator("op_Addition", RuntimeServices.InvokeBinaryOperator("op_Addition", RuntimeServices.InvokeBinaryOperator("op_Addition", RuntimeServices.InvokeBinaryOperator("op_Addition", "Welcome to ", UnityRuntimeServices.GetProperty(_0024self__00243441.mserver, "gamenamestring")), (!(worldURL != string.Empty)) ? string.Empty : (" created by " + worldURL.Replace("http://72.14.184.180/Worlds/", string.Empty).Split("_"[0])[0] + " ")), "!"), (!(worldURL != string.Empty)) ? string.Empty : ("\n\n" + worldURL)));
					isLoading = false;
					YieldDefault(1);
					goto case 1;
				case 1:
					{
						result = 0;
						break;
					}
					IL_143f:
					if (_0024_0024440_00243432 < _0024_0024442_00243434)
					{
						_0024pos_00243427 = _0024_0024441_00243433[_0024_0024440_00243432].Split("#"[0])[0];
						_0024rot_00243428 = _0024_0024441_00243433[_0024_0024440_00243432].Split("#"[0])[1];
						_0024scale_00243429 = _0024_0024441_00243433[_0024_0024440_00243432].Split("#"[0])[2];
						if (_0024chunks_00243422[2].Split(","[0])[_0024counter_00243425].Contains(".obj"))
						{
							if (!_0024self__00243441.meshCache.ContainsKey(_0024chunks_00243422[2].Split(","[0])[_0024counter_00243425]))
							{
								_0024obj_00243430 = (GameObject)UnityEngine.Object.Instantiate(_0024self__00243441.items[10], new Vector3(UnityBuiltins.parseFloat(_0024pos_00243427.Split(","[0])[0]), UnityBuiltins.parseFloat(_0024pos_00243427.Split(","[0])[1]), UnityBuiltins.parseFloat(_0024pos_00243427.Split(","[0])[2])), Quaternion.Euler(new Vector3(UnityBuiltins.parseFloat(_0024rot_00243428.Split(","[0])[0]), UnityBuiltins.parseFloat(_0024rot_00243428.Split(","[0])[1]), UnityBuiltins.parseFloat(_0024rot_00243428.Split(","[0])[2]))));
								_0024obj_00243430.transform.localScale = new Vector3(UnityBuiltins.parseFloat(_0024scale_00243429.Split(","[0])[0]), UnityBuiltins.parseFloat(_0024scale_00243429.Split(","[0])[1]), UnityBuiltins.parseFloat(_0024scale_00243429.Split(","[0])[2]));
								_0024loadObj_00243431 = (OBJ)_0024obj_00243430.GetComponent("OBJ");
								_0024loadObj_00243431.objPath = "http://" + _0024chunks_00243422[2].Split(","[0])[_0024counter_00243425];
								goto case 10;
							}
							object obj = _0024self__00243441.meshCache[_0024chunks_00243422[2].Split(","[0])[_0024counter_00243425]];
							if (!(obj is UnityEngine.Object))
							{
								obj = RuntimeServices.Coerce(obj, typeof(UnityEngine.Object));
							}
							object obj2 = UnityEngine.Object.Instantiate((UnityEngine.Object)obj, new Vector3(UnityBuiltins.parseFloat(_0024pos_00243427.Split(","[0])[0]), UnityBuiltins.parseFloat(_0024pos_00243427.Split(","[0])[1]), UnityBuiltins.parseFloat(_0024pos_00243427.Split(","[0])[2])), Quaternion.Euler(new Vector3(UnityBuiltins.parseFloat(_0024rot_00243428.Split(","[0])[0]), UnityBuiltins.parseFloat(_0024rot_00243428.Split(","[0])[1]), UnityBuiltins.parseFloat(_0024rot_00243428.Split(","[0])[2]))));
							if (!(obj2 is GameObject))
							{
								obj2 = RuntimeServices.Coerce(obj2, typeof(GameObject));
							}
							_0024obj_00243430 = (GameObject)obj2;
							_0024obj_00243430.transform.localScale = new Vector3(UnityBuiltins.parseFloat(_0024scale_00243429.Split(","[0])[0]), UnityBuiltins.parseFloat(_0024scale_00243429.Split(","[0])[1]), UnityBuiltins.parseFloat(_0024scale_00243429.Split(","[0])[2]));
						}
						else if (_0024chunks_00243422[2].Split(","[0])[_0024counter_00243425].Contains("T_R"))
						{
							_0024obj_00243430 = (GameObject)UnityEngine.Object.Instantiate(_0024self__00243441.items[0], new Vector3(UnityBuiltins.parseFloat(_0024pos_00243427.Split(","[0])[0]), UnityBuiltins.parseFloat(_0024pos_00243427.Split(","[0])[1]), UnityBuiltins.parseFloat(_0024pos_00243427.Split(","[0])[2])), Quaternion.Euler(new Vector3(UnityBuiltins.parseFloat(_0024rot_00243428.Split(","[0])[0]), UnityBuiltins.parseFloat(_0024rot_00243428.Split(","[0])[1]), UnityBuiltins.parseFloat(_0024rot_00243428.Split(","[0])[2]))));
							((TerrainDeform)_0024obj_00243430.gameObject.GetComponent(typeof(TerrainDeform))).importData = _0024chunks_00243422[2].Split(","[0])[_0024counter_00243425].Replace("T_R", string.Empty);
							((TerrainDeform)_0024obj_00243430.gameObject.GetComponent(typeof(TerrainDeform))).setMode("import");
						}
						else
						{
							_0024obj_00243430 = (GameObject)UnityEngine.Object.Instantiate(_0024self__00243441.items[UnityBuiltins.parseInt(_0024chunks_00243422[2].Split(","[0])[_0024counter_00243425].Split("-"[0])[0]) + 1], new Vector3(UnityBuiltins.parseFloat(_0024pos_00243427.Split(","[0])[0]), UnityBuiltins.parseFloat(_0024pos_00243427.Split(","[0])[1]), UnityBuiltins.parseFloat(_0024pos_00243427.Split(","[0])[2])), Quaternion.Euler(new Vector3(UnityBuiltins.parseFloat(_0024rot_00243428.Split(","[0])[0]), UnityBuiltins.parseFloat(_0024rot_00243428.Split(","[0])[1]), UnityBuiltins.parseFloat(_0024rot_00243428.Split(","[0])[2]))));
							_0024obj_00243430.transform.localScale = new Vector3(UnityBuiltins.parseFloat(_0024scale_00243429.Split(","[0])[0]), UnityBuiltins.parseFloat(_0024scale_00243429.Split(","[0])[1]), UnityBuiltins.parseFloat(_0024scale_00243429.Split(","[0])[2]));
						}
						goto IL_1058;
					}
					result = (YieldDefault(12) ? 1 : 0);
					break;
					IL_1058:
					if (_0024obj_00243430.name == "CanisterPrefab(Clone)")
					{
						_0024obj_00243430.name = "CanisterPrefab";
					}
					if (_0024obj_00243430.name == "CloakPickupPrefab(Clone)")
					{
						if (!PhotonNetwork.isMasterClient)
						{
							UnityEngine.Object.Destroy(_0024obj_00243430);
						}
						else
						{
							UnityEngine.Object.Destroy(_0024obj_00243430);
							_0024obj_00243430 = ((SpawningScript)GameObject.Find("/Spawn Point").GetComponent(typeof(SpawningScript))).customPickupInstantiate(new Vector3(UnityBuiltins.parseFloat(_0024pos_00243427.Split(","[0])[0]), UnityBuiltins.parseFloat(_0024pos_00243427.Split(","[0])[1]), UnityBuiltins.parseFloat(_0024pos_00243427.Split(","[0])[2])), Quaternion.Euler(new Vector3(UnityBuiltins.parseFloat(_0024rot_00243428.Split(","[0])[0]), UnityBuiltins.parseFloat(_0024rot_00243428.Split(","[0])[1]), UnityBuiltins.parseFloat(_0024rot_00243428.Split(","[0])[2]))), 1);
						}
					}
					if (_0024obj_00243430.name == "HealthPickup Prefab(Clone)")
					{
						if (!PhotonNetwork.isMasterClient)
						{
							UnityEngine.Object.Destroy(_0024obj_00243430);
						}
						else
						{
							UnityEngine.Object.Destroy(_0024obj_00243430);
							_0024obj_00243430 = ((SpawningScript)GameObject.Find("/Spawn Point").GetComponent(typeof(SpawningScript))).customPickupInstantiate(new Vector3(UnityBuiltins.parseFloat(_0024pos_00243427.Split(","[0])[0]), UnityBuiltins.parseFloat(_0024pos_00243427.Split(","[0])[1]), UnityBuiltins.parseFloat(_0024pos_00243427.Split(","[0])[2])), Quaternion.Euler(new Vector3(UnityBuiltins.parseFloat(_0024rot_00243428.Split(","[0])[0]), UnityBuiltins.parseFloat(_0024rot_00243428.Split(","[0])[1]), UnityBuiltins.parseFloat(_0024rot_00243428.Split(","[0])[2]))), 0);
						}
					}
					if (_0024obj_00243430.name == "ForgeCubePrimative(Clone)")
					{
						_0024obj_00243430.SendMessage("setInitColor", (!_0024chunks_00243422[2].Split(","[0])[_0024counter_00243425].Contains("-")) ? 6 : UnityBuiltins.parseInt(_0024chunks_00243422[2].Split(","[0])[_0024counter_00243425].Split("-"[0])[1]));
						_0024obj_00243430.transform.parent = _0024self__00243441.statparent;
					}
					_0024counter_00243425++;
					if (_0024counter_00243425 % 5 == 0)
					{
						result = (YieldDefault(11) ? 1 : 0);
						break;
					}
					goto case 11;
				}
				return (byte)result != 0;
			}
		}

		internal CWFLoader _0024self__00243442;

		public _0024Start_00243421(CWFLoader self_)
		{
			_0024self__00243442 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00243442);
		}
	}

	[NonSerialized]
	public static string worldData = string.Empty;

	[NonSerialized]
	public static string worldURL = string.Empty;

	public GameObject[] items;

	public Texture[] planeTex;

	public Type mserver;

	public SpawningScript spwnsrc;

	public Transform statparent;

	public GUIStyle boxStyle;

	public GUIStyle starButton;

	public Color highlight;

	private string curRating;

	private int myRating;

	private bool worldDataLoading;

	private Hashtable meshCache;

	[NonSerialized]
	public static bool isLoading = true;

	public CWFLoader()
	{
		mserver = typeof(MasterServerScript);
		curRating = "(Loading...)";
		worldDataLoading = true;
	}

	public virtual void setUpData()
	{
		int i = 0;
		((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("setWorldURL", PhotonTargets.OthersBuffered, worldURL);
		for (; i > -1; i += 1024)
		{
			if (i + 1024 < worldData.Length - 1)
			{
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("setWD", PhotonTargets.OthersBuffered, worldData.Substring(i, 1024));
				continue;
			}
			((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("setWD2", PhotonTargets.OthersBuffered, worldData.Substring(i, worldData.Length - i));
			break;
		}
	}

	[RPC]
	public virtual void setWorldURL(string w)
	{
		worldURL = w;
		if (w.Contains("http://72.14.184.180/"))
		{
			StartCoroutine_Auto(getRating(worldURL));
		}
	}

	[RPC]
	public virtual void setWD(string d)
	{
		worldData += d;
	}

	[RPC]
	public virtual void setWD2(string d)
	{
		worldData += d;
		worldDataLoading = false;
	}

	public virtual void Awake()
	{
		if (PhotonNetwork.isMasterClient)
		{
			StartCoroutine_Auto(getRating(worldURL));
		}
		isLoading = true;
	}

	public virtual IEnumerator getRating(string w)
	{
		return new _0024getRating_00243409(w, this).GetEnumerator();
	}

	public virtual IEnumerator setRating(int i)
	{
		return new _0024setRating_00243415(i, this).GetEnumerator();
	}

	public virtual void OnGUI()
	{
		if (!(worldURL != string.Empty))
		{
			return;
		}
		GUI.BeginGroup(new Rect(Screen.width - 10 - 150, Screen.height - 200 - 75, 150f, 75f));
		GUI.Box(new Rect(0f, 0f, 150f, 75f), "Rate World\n" + curRating, boxStyle);
		for (int i = 0; i < 5; i++)
		{
			if (i + 1 <= myRating)
			{
				GUI.color = highlight;
			}
			else
			{
				GUI.color = Color.white;
			}
			if (GUI.Button(new Rect(32 + i * 17, 42f, 15f, 14f), string.Empty, starButton))
			{
				StartCoroutine_Auto(setRating(i + 1));
			}
		}
		GUI.EndGroup();
	}

	public virtual IEnumerator Start()
	{
		return new _0024Start_00243421(this).GetEnumerator();
	}

	public virtual void Main()
	{
		meshCache = new Hashtable();
	}
}
