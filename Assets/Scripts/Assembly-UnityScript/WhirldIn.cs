using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Boo.Lang;
using Boo.Lang.Runtime;
using Ionic.Zlib;
using Photon;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class WhirldIn : Photon.MonoBehaviour
{
	[Serializable]
	internal sealed class _0024Load_00245163 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string[] _0024ext_00245164;

			internal bool _0024isBundle_00245165;

			internal WWW _0024www_00245166;

			internal string _0024u_00245167;

			internal WhirldIn _0024self__00245168;

			public _0024(string u, WhirldIn self_)
			{
				_0024u_00245167 = u;
				_0024self__00245168 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					UnloadAllBundles();
					status = WhirldInStatus.Working;
					_0024self__00245168.url = _0024u_00245167;
					if (_0024self__00245168.url.Length < 5)
					{
						_0024self__00245168.info = "No Whirld provided to load\n";
						status = WhirldInStatus.WWWError;
						goto case 2;
					}
					_0024ext_00245164 = Path.GetExtension(_0024self__00245168.url).Split("?"[0]);
					_0024isBundle_00245165 = _0024ext_00245164[0] == ".whirld";
					_0024self__00245168.statusTxt = "Downloading Whirld Data";
					_0024self__00245168.info = string.Empty;
					_0024self__00245168.urlPath = _0024self__00245168.url.Substring(0, _0024self__00245168.url.LastIndexOf("/") + 1);
					if (_0024isBundle_00245165)
					{
						_0024www_00245166 = new WWW(_0024self__00245168.url);
						goto case 3;
					}
					_0024www_00245166 = new WWW(_0024self__00245168.url);
					goto case 5;
				case 2:
					if (GameObject.Find("/InitializingWorld") == null)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					GameObject.Find("/InitializingWorld").SendMessage("WhirldFail");
					_0024self__00245168.enabled = false;
					goto case 1;
				case 3:
					if (!_0024www_00245166.isDone)
					{
						progress = _0024www_00245166.progress;
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					progress = 1f;
					if (_0024www_00245166.error != null)
					{
						_0024self__00245168.info = "Failed to download Whirld: " + _0024self__00245168.url + "\n(" + _0024www_00245166.error + ")\n";
						status = WhirldInStatus.WWWError;
						GameObject.Find("/InitializingWorld").SendMessage("WhirldFail");
						_0024self__00245168.enabled = false;
						goto case 1;
					}
					goto case 4;
				case 4:
					if (Application.loadedLevelName != "CCWhirldScene")
					{
						result = (YieldDefault(4) ? 1 : 0);
						break;
					}
					_0024self__00245168.StartCoroutine_Auto(_0024self__00245168.LoadBundle(_0024www_00245166.assetBundle));
					goto IL_03bd;
				case 5:
					if (!_0024www_00245166.isDone)
					{
						progress = _0024www_00245166.progress;
						result = (YieldDefault(5) ? 1 : 0);
						break;
					}
					progress = 1f;
					if (_0024www_00245166.error != null)
					{
						_0024self__00245168.info = "Failed to download Whirld: " + _0024self__00245168.url + "\n(" + _0024www_00245166.error + ")\n";
						status = WhirldInStatus.WWWError;
						goto case 6;
					}
					goto case 7;
				case 6:
					if (GameObject.Find("/InitializingWorld") == null)
					{
						result = (YieldDefault(6) ? 1 : 0);
						break;
					}
					GameObject.Find("/InitializingWorld").SendMessage("WhirldFail");
					_0024self__00245168.enabled = false;
					goto case 1;
				case 7:
					if (Application.loadedLevelName != "CCWhirldScene")
					{
						result = (YieldDefault(7) ? 1 : 0);
						break;
					}
					_0024self__00245168.StartCoroutine_Auto(_0024self__00245168.LoadOpen(_0024www_00245166.text));
					goto IL_03bd;
				case 1:
					{
						result = 0;
						break;
					}
					IL_03bd:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal string _0024u_00245169;

		internal WhirldIn _0024self__00245170;

		public _0024Load_00245163(string u, WhirldIn self_)
		{
			_0024u_00245169 = u;
			_0024self__00245170 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024u_00245169, _0024self__00245170);
		}
	}

	[Serializable]
	internal sealed class _0024LoadBundle_00245171 : GenericGenerator<WWW>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WWW>, IEnumerator
		{
			internal float _0024tme_00245172;

			internal Transform _0024goobj_00245173;

			internal Whirld _0024whirld_00245174;

			internal Terrain _0024terr_00245175;

			internal TreePrototype[] _0024tarr_00245176;

			internal TreePrototype _0024tproto_00245177;

			internal GameObject _0024obj_00245178;

			internal Transform _0024goobj_00245179;

			internal Renderer _0024obj_00245180;

			internal Material[] _0024objmats_00245181;

			internal Material _0024mat_00245182;

			internal GameObject _0024spawnPointGameObj_00245183;

			internal GameObject _0024redSpawn_00245184;

			internal GameObject _0024blueSpawn_00245185;

			internal GameObject _0024blueFlag_00245186;

			internal GameObject _0024redFlag_00245187;

			internal Light _0024lights_00245188;

			internal Light _0024clone_00245189;

			internal Light _0024clone2_00245190;

			internal GameObject _0024mmobj_00245191;

			internal WWW _0024mmwww_00245192;

			internal GameObject _0024floor_00245193;

			internal GameObject _0024floorclone_00245194;

			internal int _0024_00241368_00245195;

			internal Transform[] _0024_00241369_00245196;

			internal int _0024_00241370_00245197;

			internal int _0024_00241372_00245198;

			internal TreePrototype[] _0024_00241373_00245199;

			internal int _0024_00241374_00245200;

			internal int _0024_00241376_00245201;

			internal Terrain[] _0024_00241377_00245202;

			internal int _0024_00241378_00245203;

			internal int _0024_00241380_00245204;

			internal Transform[] _0024_00241381_00245205;

			internal int _0024_00241382_00245206;

			internal int _0024_00241384_00245207;

			internal GameObject[] _0024_00241385_00245208;

			internal int _0024_00241386_00245209;

			internal int _0024_00241388_00245210;

			internal Material[] _0024_00241389_00245211;

			internal int _0024_00241390_00245212;

			internal int _0024_00241392_00245213;

			internal Renderer[] _0024_00241393_00245214;

			internal int _0024_00241394_00245215;

			internal int _0024_00241396_00245216;

			internal Light[] _0024_00241397_00245217;

			internal int _0024_00241398_00245218;

			internal object _0024_00242820_00245219;

			internal Vector3 _0024_00242821_00245220;

			internal float _0024_00242822_00245221;

			internal Vector3 _0024_00242823_00245222;

			internal float _0024_00242824_00245223;

			internal Vector3 _0024_00242825_00245224;

			internal float _0024_00242826_00245225;

			internal Vector3 _0024_00242827_00245226;

			internal float _0024_00242828_00245227;

			internal Vector3 _0024_00242829_00245228;

			internal float _0024_00242830_00245229;

			internal Vector3 _0024_00242831_00245230;

			internal Vector3 _0024_00242832_00245231;

			internal Quaternion _0024_00242833_00245232;

			internal Vector3 _0024_00242834_00245233;

			internal Quaternion _0024_00242835_00245234;

			internal int _0024_00242836_00245235;

			internal Quaternion _0024_00242837_00245236;

			internal Vector3 _0024_00242838_00245237;

			internal int _0024_00242839_00245238;

			internal Vector3 _0024_00242840_00245239;

			internal int _0024_00242841_00245240;

			internal Vector3 _0024_00242842_00245241;

			internal AssetBundle _0024assetBundle_00245242;

			internal WhirldIn _0024self__00245243;

			public _0024(AssetBundle assetBundle, WhirldIn self_)
			{
				_0024assetBundle_00245242 = assetBundle;
				_0024self__00245243 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00245243.statusTxt = "Initializing World";
					if (!_0024assetBundle_00245242)
					{
						_0024self__00245243.info = "Whirld Bundle appears to be corrupted\n";
						status = WhirldInStatus.SyntaxError;
						goto case 2;
					}
					UnityEngine.Object.DontDestroyOnLoad(_0024self__00245243.gameObject);
					Application.backgroundLoadingPriority = ThreadPriority.High;
					Application.LoadLevel("CCWhirldScene");
					_0024tme_00245172 = Time.time;
					progress = 1f;
					_0024self__00245243.TrackBundle(_0024assetBundle_00245242);
					if (!Whirld.Controller)
					{
						_0024self__00245243.info = "Whirld Bundle contains broken controller\n";
						status = WhirldInStatus.SyntaxError;
						goto case 3;
					}
					Whirld.Controller.SendMessage("OnSceneGenerated", SendMessageOptions.DontRequireReceiver);
					_0024_00241368_00245195 = 0;
					_0024_00241369_00245196 = (Transform[])UnityEngine.Object.FindObjectsOfType(typeof(Transform));
					for (_0024_00241370_00245197 = _0024_00241369_00245196.Length; _0024_00241368_00245195 < _0024_00241370_00245197; _0024_00241368_00245195++)
					{
						if (_0024_00241369_00245196[_0024_00241368_00245195] != _0024self__00245243.transform && _0024_00241369_00245196[_0024_00241368_00245195].parent == null && _0024_00241369_00245196[_0024_00241368_00245195].gameObject.name != "WhirldItemsPrefab")
						{
							if (RuntimeServices.ToBool(_0024self__00245243.whirldController.@params["seaAlt"]))
							{
								object obj = (_0024_00242820_00245219 = RuntimeServices.InvokeBinaryOperator("op_Subtraction", _0024_00241369_00245196[_0024_00241368_00245195].position.y, _0024self__00245243.whirldController.@params["seaAlt"]));
								Vector3 vector22 = (_0024_00242821_00245220 = _0024_00241369_00245196[_0024_00241368_00245195].position);
								float num15 = (_0024_00242821_00245220.y = RuntimeServices.UnboxSingle(_0024_00242820_00245219));
								Vector3 vector23 = (_0024_00241369_00245196[_0024_00241368_00245195].position = _0024_00242821_00245220);
							}
							float num16 = (_0024_00242822_00245221 = _0024_00241369_00245196[_0024_00241368_00245195].position.y + 11.5f);
							Vector3 vector25 = (_0024_00242823_00245222 = _0024_00241369_00245196[_0024_00241368_00245195].position);
							float num17 = (_0024_00242823_00245222.y = _0024_00242822_00245221);
							Vector3 vector26 = (_0024_00241369_00245196[_0024_00241368_00245195].position = _0024_00242823_00245222);
							if ((bool)(MeshCollider)_0024_00241369_00245196[_0024_00241368_00245195].GetComponent(typeof(MeshCollider)))
							{
								((MeshCollider)_0024_00241369_00245196[_0024_00241368_00245195].GetComponent(typeof(MeshCollider))).smoothSphereCollisions = false;
							}
							if ((bool)_0024_00241369_00245196[_0024_00241368_00245195].camera)
							{
								UnityEngine.Object.Destroy(_0024_00241369_00245196[_0024_00241368_00245195].gameObject);
							}
						}
					}
					status = WhirldInStatus.Success;
					_0024self__00245243.statusTxt = "World Loaded Successfully";
					_0024whirld_00245174 = (Whirld)GameObject.Find("_Whirld").GetComponent("Whirld");
					if (_0024whirld_00245174.whirldFloor)
					{
						UnityEngine.Object.Instantiate(_0024self__00245243.whirldFloorPrefab, new Vector3(0f, _0024whirld_00245174.whirldFloorAlt, 0f), Quaternion.identity);
					}
					_0024_00241376_00245201 = 0;
					_0024_00241377_00245202 = (Terrain[])UnityEngine.Object.FindObjectsOfType(typeof(Terrain));
					_0024_00241378_00245203 = _0024_00241377_00245202.Length;
					goto IL_08dc;
				case 2:
					if (GameObject.Find("/InitializingWorld") == null)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					GameObject.Find("/InitializingWorld").SendMessage("WhirldFail");
					_0024self__00245243.enabled = false;
					goto case 1;
				case 3:
					if (GameObject.Find("/InitializingWorld") == null)
					{
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					GameObject.Find("/InitializingWorld").SendMessage("WhirldFail");
					_0024self__00245243.enabled = false;
					goto case 1;
				case 4:
					_0024_00241376_00245201++;
					goto IL_08dc;
				case 5:
					result = (YieldDefault(6) ? 1 : 0);
					break;
				case 6:
					_0024_00241392_00245213 = 0;
					_0024_00241393_00245214 = (Renderer[])UnityEngine.Object.FindObjectsOfType(typeof(Renderer));
					for (_0024_00241394_00245215 = _0024_00241393_00245214.Length; _0024_00241392_00245213 < _0024_00241394_00245215; _0024_00241392_00245213++)
					{
						_0024objmats_00245181 = _0024_00241393_00245214[_0024_00241392_00245213].renderer.materials;
						_0024_00241388_00245210 = 0;
						_0024_00241389_00245211 = _0024objmats_00245181;
						for (_0024_00241390_00245212 = _0024_00241389_00245211.Length; _0024_00241388_00245210 < _0024_00241390_00245212; _0024_00241388_00245210++)
						{
							if (!_0024_00241389_00245211[_0024_00241388_00245210].shader || string.IsNullOrEmpty(_0024_00241389_00245211[_0024_00241388_00245210].shader.name))
							{
								_0024_00241389_00245211[_0024_00241388_00245210].shader = Shader.Find("Diffuse");
							}
							if (_0024_00241389_00245211[_0024_00241388_00245210].shader.name == "Shield")
							{
								_0024_00241389_00245211[_0024_00241388_00245210].shader = Shader.Find("Shield");
							}
							if (_0024_00241389_00245211[_0024_00241388_00245210].shader.name == "FX/Lava")
							{
								_0024_00241389_00245211[_0024_00241388_00245210].shader = Shader.Find("Transparent/VertexLit");
								if (AuthGameObject.whirldname == "Eric's CTF")
								{
									if ((bool)(Collider)_0024_00241393_00245214[_0024_00241392_00245213].GetComponent(typeof(Collider)))
									{
										_0024_00241393_00245214[_0024_00241392_00245213].collider.isTrigger = true;
										UnityRuntimeServices.Invoke(_0024_00241393_00245214[_0024_00241392_00245213], "AddComponent", new object[1] { "WhirldWaterTrigger" }, typeof(UnityEngine.MonoBehaviour));
									}
								}
								else
								{
									_0024_00241393_00245214[_0024_00241392_00245213].collider.isTrigger = false;
								}
							}
							if (_0024_00241389_00245211[_0024_00241388_00245210].shader.name == "Transparent/GlassShiny")
							{
								_0024_00241389_00245211[_0024_00241388_00245210].shader = Shader.Find("Transparent/GlassShiny");
							}
							if (_0024_00241389_00245211[_0024_00241388_00245210].name == "skyking-glass (Instance)")
							{
								_0024_00241389_00245211[_0024_00241388_00245210].shader = Shader.Find("Transparent/GlassShiny");
							}
							if (_0024_00241389_00245211[_0024_00241388_00245210].shader.name == "Transparent/GlassGlowing")
							{
								_0024_00241389_00245211[_0024_00241388_00245210].shader = Shader.Find("Transparent/GlassShiny");
							}
							if (_0024_00241389_00245211[_0024_00241388_00245210].shader.name == "Transparent/GlassGlowing")
							{
								_0024_00241389_00245211[_0024_00241388_00245210].shader = Shader.Find("Transparent/GlassShiny");
							}
						}
					}
					if (AuthGameObject.whirldname == "Fai's Sunken Wastes")
					{
						GameObject.Find("/Bridge").renderer.material = _0024self__00245243.faibridgemat;
					}
					_0024spawnPointGameObj_00245183 = GameObject.Find("/Spawn Point");
					_0024spawnPointGameObj_00245183.transform.position = GameObject.Find("Base").transform.position;
					if (AuthGameObject.whirldname == "Eric's CTF")
					{
						_0024redSpawn_00245184 = new GameObject("RedSpawn");
						_0024redSpawn_00245184.transform.position = new Vector3(3499.902f, 25f, 2095.467f);
						Vector3 vector28 = (_0024_00242832_00245231 = new Vector3(0f, -90f, 0f));
						Quaternion quaternion4 = (_0024_00242833_00245232 = _0024redSpawn_00245184.transform.rotation);
						Vector3 vector29 = (_0024_00242833_00245232.eulerAngles = _0024_00242832_00245231);
						Quaternion quaternion5 = (_0024redSpawn_00245184.transform.rotation = _0024_00242833_00245232);
						_0024blueSpawn_00245185 = new GameObject("BlueSpawn");
						_0024blueSpawn_00245185.transform.position = new Vector3(423.0586f, 25f, 2095.467f);
						Vector3 vector31 = (_0024_00242834_00245233 = new Vector3(0f, 90f, 0f));
						Quaternion quaternion7 = (_0024_00242835_00245234 = _0024blueSpawn_00245185.transform.rotation);
						Vector3 vector32 = (_0024_00242835_00245234.eulerAngles = _0024_00242834_00245233);
						Quaternion quaternion8 = (_0024blueSpawn_00245185.transform.rotation = _0024_00242835_00245234);
						RuntimeServices.SetProperty(_0024spawnPointGameObj_00245183.GetComponent("SpawningScript"), "redspawn1", _0024redSpawn_00245184);
						RuntimeServices.SetProperty(_0024spawnPointGameObj_00245183.GetComponent("SpawningScript"), "redspawn2", _0024redSpawn_00245184);
						RuntimeServices.SetProperty(_0024spawnPointGameObj_00245183.GetComponent("SpawningScript"), "redspawn3", _0024redSpawn_00245184);
						RuntimeServices.SetProperty(_0024spawnPointGameObj_00245183.GetComponent("SpawningScript"), "redspawn4", _0024redSpawn_00245184);
						RuntimeServices.SetProperty(_0024spawnPointGameObj_00245183.GetComponent("SpawningScript"), "redspawn5", _0024redSpawn_00245184);
						RuntimeServices.SetProperty(_0024spawnPointGameObj_00245183.GetComponent("SpawningScript"), "redspawn6", _0024redSpawn_00245184);
						RuntimeServices.SetProperty(_0024spawnPointGameObj_00245183.GetComponent("SpawningScript"), "spawn1", _0024blueSpawn_00245185);
						RuntimeServices.SetProperty(_0024spawnPointGameObj_00245183.GetComponent("SpawningScript"), "spawn2", _0024blueSpawn_00245185);
						RuntimeServices.SetProperty(_0024spawnPointGameObj_00245183.GetComponent("SpawningScript"), "spawn3", _0024blueSpawn_00245185);
						RuntimeServices.SetProperty(_0024spawnPointGameObj_00245183.GetComponent("SpawningScript"), "spawn4", _0024blueSpawn_00245185);
						RuntimeServices.SetProperty(_0024spawnPointGameObj_00245183.GetComponent("SpawningScript"), "spawn5", _0024blueSpawn_00245185);
						RuntimeServices.SetProperty(_0024spawnPointGameObj_00245183.GetComponent("SpawningScript"), "spawn6", _0024blueSpawn_00245185);
						if (AuthGameObject.gametype == "Capture the Flag" && PhotonNetwork.isMasterClient)
						{
							flagId = PhotonNetwork.AllocateViewID();
							flag2Id = PhotonNetwork.AllocateViewID();
							_0024blueFlag_00245186 = (GameObject)UnityEngine.Object.Instantiate(_0024self__00245243.ctfprefabblue, new Vector3(422.0682f, 107.0283f, 2094.59f), Quaternion.Euler(0f, 270f, 0f));
							_0024redFlag_00245187 = (GameObject)UnityEngine.Object.Instantiate(_0024self__00245243.ctfprefabred, new Vector3(3503.526f, 107.0283f, 2094.517f), Quaternion.Euler(0f, 90f, 0f));
							RuntimeServices.SetProperty(_0024blueFlag_00245186.GetComponent("CTFFlagSender"), "otherflagunit", _0024redFlag_00245187.gameObject);
							RuntimeServices.SetProperty(_0024blueFlag_00245186.GetComponent("CTFFlagSender"), "srcobj", GameObject.Find("/GUI/Chat"));
							RuntimeServices.SetProperty(_0024blueFlag_00245186.GetComponent("CTFFlagSender"), "igs", GameObject.Find("/GUI/GameScores"));
							((PhotonView)_0024blueFlag_00245186.GetComponent(typeof(PhotonView))).viewID = flagId;
							RuntimeServices.SetProperty(_0024redFlag_00245187.GetComponent("CTFFlagSender"), "otherflagunit", _0024blueFlag_00245186.gameObject);
							RuntimeServices.SetProperty(_0024redFlag_00245187.GetComponent("CTFFlagSender"), "srcobj", GameObject.Find("/GUI/Chat"));
							RuntimeServices.SetProperty(_0024redFlag_00245187.GetComponent("CTFFlagSender"), "igs", GameObject.Find("/GUI/GameScores"));
							RuntimeServices.SetProperty(_0024spawnPointGameObj_00245183.GetComponent("SpawningScript"), "flagbase", _0024blueFlag_00245186.gameObject);
							((PhotonView)_0024redFlag_00245187.GetComponent(typeof(PhotonView))).viewID = flag2Id;
							_0024blueFlag_00245186.gameObject.name = "FlagBase";
							_0024redFlag_00245187.gameObject.name = "FlagBase";
						}
					}
					if ((bool)GameObject.Find("BotSpawner"))
					{
						GameObject.Find("BotSpawner").transform.position = GameObject.Find("Base").transform.position;
					}
					GameObject.Find("BotSpectator").transform.position = GameObject.Find("Base").transform.position;
					GameObject.Find("/MinimapCam").transform.position = new Vector3(GameObject.Find("Base").transform.position.x, GameObject.Find("/MinimapCam").transform.position.y, GameObject.Find("Base").transform.position.z);
					Camera.main.transform.position = new Vector3(GameObject.Find("Base").transform.position.x, GameObject.Find("Base").transform.position.y + 100f, GameObject.Find("Base").transform.position.z);
					Camera.main.transform.LookAt(GameObject.Find("Base").transform);
					UnityEngine.Object.Destroy(GameObject.Find("/World/Base"));
					Debug.Log("CCAssets 2");
					GameObject.Find("/InitializingWorld").SendMessage("perc", 40);
					result = (YieldDefault(7) ? 1 : 0);
					break;
				case 7:
					_0024_00241396_00245216 = 0;
					_0024_00241397_00245217 = (Light[])UnityEngine.Object.FindObjectsOfType(typeof(Light));
					for (_0024_00241398_00245218 = _0024_00241397_00245217.Length; _0024_00241396_00245216 < _0024_00241398_00245218; _0024_00241396_00245216++)
					{
						_0024_00241397_00245217[_0024_00241396_00245216].cullingMask = _0024self__00245243.pixelLight.value;
						_0024_00241397_00245217[_0024_00241396_00245216].renderMode = LightRenderMode.Auto;
						_0024clone_00245189 = (Light)UnityEngine.Object.Instantiate(_0024_00241397_00245217[_0024_00241396_00245216], _0024_00241397_00245217[_0024_00241396_00245216].transform.position, _0024_00241397_00245217[_0024_00241396_00245216].transform.rotation);
						_0024clone_00245189.cullingMask = _0024self__00245243.vertLight.value;
						_0024clone_00245189.renderMode = LightRenderMode.ForceVertex;
						_0024clone2_00245190 = (Light)UnityEngine.Object.Instantiate(_0024_00241397_00245217[_0024_00241396_00245216], _0024_00241397_00245217[_0024_00241396_00245216].transform.position, _0024_00241397_00245217[_0024_00241396_00245216].transform.rotation);
						_0024clone2_00245190.cullingMask = _0024self__00245243.minimapLight.value;
						_0024clone2_00245190.renderMode = LightRenderMode.ForceVertex;
						_0024clone2_00245190.intensity = 0.5f;
						_0024clone2_00245190.color = Color.white;
					}
					if (RenderSettings.skybox == null)
					{
						RenderSettings.skybox = _0024self__00245243.spaceskybox;
						RenderSettings.fogColor = _0024self__00245243.fogcolor;
						RenderSettings.fog = true;
						RenderSettings.fogDensity = 0.0002f;
					}
					Debug.Log("CCAssets 3");
					GameObject.Find("/InitializingWorld").SendMessage("perc", 60);
					result = (YieldDefault(8) ? 1 : 0);
					break;
				case 8:
					if (!hassea)
					{
						GameObject.Find("/Water").SetActiveRecursively(false);
					}
					if (AuthGameObject.whirldname == "Eric's CTF")
					{
						hassea = true;
					}
					Debug.Log("CCAssets 4");
					GameObject.Find("/InitializingWorld").SendMessage("perc", 80);
					result = (YieldDefault(9) ? 1 : 0);
					break;
				case 9:
					if (_0024self__00245243.authobjwname != "Custom World")
					{
						_0024mmobj_00245191 = GameObject.Find("/MinimapPlane");
						_0024mmobj_00245191.renderer.material.mainTexture = new Texture2D(4, 4, TextureFormat.ARGB32, false);
						_0024mmwww_00245192 = new WWW(_0024self__00245243.authobjwurl);
						result = (Yield(10, _0024mmwww_00245192) ? 1 : 0);
						break;
					}
					GameObject.Find("/MinimapPlane").transform.position = new Vector3(0f, -800f, 0f);
					GameObject.Find("/MinimapPlane").transform.localScale = new Vector3(5000f, 1f, 5000f);
					GameObject.Find("/MinimapPlane").renderer.material.mainTexture = _0024self__00245243.gridTexture;
					GameObject.Find("/MinimapPlane").renderer.material.mainTextureScale = new Vector2(50f, 50f);
					goto IL_1fbb;
				case 10:
					result = (YieldDefault(11) ? 1 : 0);
					break;
				case 11:
					if (_0024mmwww_00245192.error == null)
					{
						_0024mmwww_00245192.LoadImageIntoTexture((Texture2D)_0024mmobj_00245191.renderer.material.mainTexture);
						if (_0024self__00245243.authobjwname == "Seb's Sky King" || _0024self__00245243.authobjwname == "Doug's Floating Islands" || _0024self__00245243.authobjwname == "Seb's Cliff Hangers" || _0024self__00245243.authobjwname == "Abister's Asteroids")
						{
							if (_0024self__00245243.authobjwname == "Seb's Sky King")
							{
								_0024mmobj_00245191.transform.position = new Vector3(63.26446f, -800f, -19.53878f);
								_0024mmobj_00245191.transform.localScale = new Vector3(298.0172f, 1f, 271.0456f);
							}
							if (_0024self__00245243.authobjwname == "Doug's Floating Islands")
							{
								_0024mmobj_00245191.transform.position = new Vector3(1396.008f, -800f, 1716.506f);
								int num = (_0024_00242836_00245235 = 90);
								Quaternion quaternion = (_0024_00242837_00245236 = _0024mmobj_00245191.transform.localRotation);
								Vector3 vector = (_0024_00242838_00245237 = _0024_00242837_00245236.eulerAngles);
								float num2 = (_0024_00242838_00245237.y = _0024_00242836_00245235);
								Vector3 vector2 = (_0024_00242837_00245236.eulerAngles = _0024_00242838_00245237);
								Quaternion quaternion2 = (_0024mmobj_00245191.transform.localRotation = _0024_00242837_00245236);
								_0024mmobj_00245191.transform.localScale = new Vector3(928f, 1f, 928f);
							}
							if (_0024self__00245243.authobjwname == "Seb's Cliff Hangers")
							{
								_0024mmobj_00245191.transform.localScale = new Vector3(950f, 1f, 950f);
							}
							if (_0024self__00245243.authobjwname == "Abister's Asteroids")
							{
								_0024mmobj_00245191.transform.position = new Vector3(42.69141f, -800f, -184.0637f);
								_0024mmobj_00245191.transform.localScale = new Vector3(109.2793f, 1f, 98.20826f);
							}
						}
						else if ((bool)Terrain.activeTerrain)
						{
							_0024mmobj_00245191.transform.position = new Vector3(Terrain.activeTerrain.transform.position.x + Terrain.activeTerrain.terrainData.size.x / 2f, -800f, Terrain.activeTerrain.transform.position.z + Terrain.activeTerrain.terrainData.size.z / 2f);
							_0024mmobj_00245191.transform.localScale = new Vector3(Terrain.activeTerrain.terrainData.size.x / 10f, 1f, Terrain.activeTerrain.terrainData.size.z / 10f);
						}
					}
					else
					{
						GameObject.Find("/MinimapPlane").transform.position = new Vector3(0f, -800f, 0f);
						GameObject.Find("/MinimapPlane").transform.localScale = new Vector3(5000f, 1f, 5000f);
						GameObject.Find("/MinimapPlane").renderer.material.mainTexture = _0024self__00245243.gridTexture;
						GameObject.Find("/MinimapPlane").renderer.material.mainTextureScale = new Vector2(50f, 50f);
					}
					goto IL_1fbb;
				case 12:
					GameObject.Find("/InitializingWorld").SendMessage("FadeOut");
					Debug.Log("CCAssets 6");
					YieldDefault(1);
					goto case 1;
				case 1:
					{
						result = 0;
						break;
					}
					IL_08dc:
					if (_0024_00241376_00245201 < _0024_00241378_00245203)
					{
						_0024tarr_00245176 = _0024_00241377_00245202[_0024_00241376_00245201].terrainData.treePrototypes;
						if (UnityScript.Lang.Extensions.get_length((System.Array)_0024tarr_00245176) > 0)
						{
							_0024_00241372_00245198 = 0;
							_0024_00241373_00245199 = _0024tarr_00245176;
							for (_0024_00241374_00245200 = _0024_00241373_00245199.Length; _0024_00241372_00245198 < _0024_00241374_00245200; _0024_00241372_00245198++)
							{
								if (_0024_00241373_00245199[_0024_00241372_00245198].prefab.name == "Palm")
								{
									_0024_00241373_00245199[_0024_00241372_00245198].prefab = _0024self__00245243.tprefabs[0];
								}
								if (_0024_00241373_00245199[_0024_00241372_00245198].prefab.name.Contains("Alder"))
								{
									_0024_00241373_00245199[_0024_00241372_00245198].prefab = _0024self__00245243.tprefabs[1];
								}
								if (_0024_00241373_00245199[_0024_00241372_00245198].prefab.name == "Bamboo")
								{
									_0024_00241373_00245199[_0024_00241372_00245198].prefab = _0024self__00245243.tprefabs[2];
								}
								if (_0024_00241373_00245199[_0024_00241372_00245198].prefab.name == "Banyan" || _0024_00241373_00245199[_0024_00241372_00245198].prefab.name == "BanyanTree")
								{
									_0024_00241373_00245199[_0024_00241372_00245198].prefab = _0024self__00245243.tprefabs[3];
								}
								if (_0024_00241373_00245199[_0024_00241372_00245198].prefab.name == "JapaneseMaple")
								{
									_0024_00241373_00245199[_0024_00241372_00245198].prefab = _0024self__00245243.tprefabs[4];
								}
								if (_0024_00241373_00245199[_0024_00241372_00245198].prefab.name.Contains("Mimosa"))
								{
									_0024_00241373_00245199[_0024_00241372_00245198].prefab = _0024self__00245243.tprefabs[5];
								}
								if (_0024_00241373_00245199[_0024_00241372_00245198].prefab.name == "Palm (group)")
								{
									_0024_00241373_00245199[_0024_00241372_00245198].prefab = _0024self__00245243.tprefabs[6];
								}
								if (_0024_00241373_00245199[_0024_00241372_00245198].prefab.name == "ScotsPineTypeA")
								{
									_0024_00241373_00245199[_0024_00241372_00245198].prefab = _0024self__00245243.tprefabs[7];
								}
								if (_0024_00241373_00245199[_0024_00241372_00245198].prefab.name == "ScotsPineTypeB")
								{
									_0024_00241373_00245199[_0024_00241372_00245198].prefab = _0024self__00245243.tprefabs[8];
								}
								if (_0024_00241373_00245199[_0024_00241372_00245198].prefab.name.Contains("Sycamore"))
								{
									_0024_00241373_00245199[_0024_00241372_00245198].prefab = _0024self__00245243.tprefabs[9];
								}
								if (_0024_00241373_00245199[_0024_00241372_00245198].prefab.name.Contains("Willow"))
								{
									_0024_00241373_00245199[_0024_00241372_00245198].prefab = _0024self__00245243.tprefabs[9];
								}
								if (_0024_00241373_00245199[_0024_00241372_00245198].prefab.name == "ThinTree")
								{
									_0024_00241373_00245199[_0024_00241372_00245198].prefab = _0024self__00245243.tprefabs[10];
								}
							}
						}
						_0024_00241377_00245202[_0024_00241376_00245201].terrainData.treePrototypes = _0024tarr_00245176;
						_0024_00241377_00245202[_0024_00241376_00245201].terrainData.RefreshPrototypes();
						result = (YieldDefault(4) ? 1 : 0);
						break;
					}
					_0024_00241384_00245207 = 0;
					_0024_00241385_00245208 = (GameObject[])UnityEngine.Object.FindObjectsOfType(typeof(GameObject));
					for (_0024_00241386_00245209 = _0024_00241385_00245208.Length; _0024_00241384_00245207 < _0024_00241386_00245209; _0024_00241384_00245207++)
					{
						if (_0024_00241385_00245208[_0024_00241384_00245207].tag == "minimap")
						{
							_0024_00241385_00245208[_0024_00241384_00245207].tag = "Untagged";
						}
						if (_0024_00241385_00245208[_0024_00241384_00245207].tag == "BlueObjects")
						{
							_0024_00241385_00245208[_0024_00241384_00245207].tag = "Untagged";
						}
						if (_0024_00241385_00245208[_0024_00241384_00245207].layer == 4)
						{
							_0024_00241385_00245208[_0024_00241384_00245207].layer = 0;
						}
						if (_0024_00241385_00245208[_0024_00241384_00245207].name == "CamoTower" && AuthGameObject.whirldname == "Eric's CTF")
						{
							UnityEngine.Object.Destroy(_0024_00241385_00245208[_0024_00241384_00245207]);
						}
						if (_0024_00241385_00245208[_0024_00241384_00245207].name == "Lava" && AuthGameObject.whirldname == "Eric's CTF")
						{
							float num3 = (_0024_00242824_00245223 = 200f);
							Vector3 vector4 = (_0024_00242825_00245224 = _0024_00241385_00245208[_0024_00241384_00245207].transform.localScale);
							float num4 = (_0024_00242825_00245224.y = _0024_00242824_00245223);
							Vector3 vector5 = (_0024_00241385_00245208[_0024_00241384_00245207].transform.localScale = _0024_00242825_00245224);
							float num5 = (_0024_00242826_00245225 = _0024_00241385_00245208[_0024_00241384_00245207].transform.position.y - 100f);
							Vector3 vector7 = (_0024_00242827_00245226 = _0024_00241385_00245208[_0024_00241384_00245207].transform.position);
							float num6 = (_0024_00242827_00245226.y = _0024_00242826_00245225);
							Vector3 vector8 = (_0024_00241385_00245208[_0024_00241384_00245207].transform.position = _0024_00242827_00245226);
						}
						if (!hassea && _0024_00241385_00245208[_0024_00241384_00245207].name == "Sea")
						{
							hassea = true;
							_0024_00241380_00245204 = 0;
							_0024_00241381_00245205 = (Transform[])UnityEngine.Object.FindObjectsOfType(typeof(Transform));
							for (_0024_00241382_00245206 = _0024_00241381_00245205.Length; _0024_00241380_00245204 < _0024_00241382_00245206; _0024_00241380_00245204++)
							{
								if (_0024_00241381_00245205[_0024_00241380_00245204] != _0024self__00245243.transform && _0024_00241381_00245205[_0024_00241380_00245204].parent == null && _0024_00241381_00245205[_0024_00241380_00245204].gameObject.name != "WhirldItemsPrefab")
								{
									float num7 = (_0024_00242828_00245227 = _0024_00241381_00245205[_0024_00241380_00245204].position.y - _0024_00241385_00245208[_0024_00241384_00245207].transform.position.y);
									Vector3 vector10 = (_0024_00242829_00245228 = _0024_00241381_00245205[_0024_00241380_00245204].position);
									float num8 = (_0024_00242829_00245228.y = _0024_00242828_00245227);
									Vector3 vector11 = (_0024_00241381_00245205[_0024_00241380_00245204].position = _0024_00242829_00245228);
									float num9 = (_0024_00242830_00245229 = _0024_00241381_00245205[_0024_00241380_00245204].position.y + 11.5f);
									Vector3 vector13 = (_0024_00242831_00245230 = _0024_00241381_00245205[_0024_00241380_00245204].position);
									float num10 = (_0024_00242831_00245230.y = _0024_00242830_00245229);
									Vector3 vector14 = (_0024_00241381_00245205[_0024_00241380_00245204].position = _0024_00242831_00245230);
								}
							}
							UnityEngine.Object.Destroy(_0024_00241385_00245208[_0024_00241384_00245207]);
						}
						else if (_0024_00241385_00245208[_0024_00241384_00245207].name == "Sea")
						{
							UnityEngine.Object.Destroy(_0024_00241385_00245208[_0024_00241384_00245207]);
						}
					}
					GameObject.Find("/InitializingWorld").SendMessage("dloading");
					Debug.Log("CCAssets 1");
					GameObject.Find("/InitializingWorld").SendMessage("perc", 20);
					result = (YieldDefault(5) ? 1 : 0);
					break;
					IL_1fbb:
					if (_0024self__00245243.whirldController.whirldFloor && (bool)Terrain.activeTerrain)
					{
						_0024floor_00245193 = GameObject.CreatePrimitive(PrimitiveType.Plane);
						_0024floor_00245193.transform.position = new Vector3(0f, Terrain.activeTerrain.transform.position.y - 0.125f, 0f);
						int num11 = (_0024_00242839_00245238 = 9999);
						Vector3 vector16 = (_0024_00242840_00245239 = _0024floor_00245193.transform.localScale);
						float num12 = (_0024_00242840_00245239.x = _0024_00242839_00245238);
						Vector3 vector17 = (_0024floor_00245193.transform.localScale = _0024_00242840_00245239);
						int num13 = (_0024_00242841_00245240 = 9999);
						Vector3 vector19 = (_0024_00242842_00245241 = _0024floor_00245193.transform.localScale);
						float num14 = (_0024_00242842_00245241.z = _0024_00242841_00245240);
						Vector3 vector20 = (_0024floor_00245193.transform.localScale = _0024_00242842_00245241);
						_0024floor_00245193.renderer.material.mainTexture = Terrain.activeTerrain.terrainData.splatPrototypes[0].texture;
						_0024floor_00245193.renderer.material.mainTextureScale = Terrain.activeTerrain.terrainData.splatPrototypes[0].tileSize / 15f * 6000f;
						_0024floorclone_00245194 = (GameObject)UnityEngine.Object.Instantiate(_0024floor_00245193, new Vector3(_0024floor_00245193.transform.position.x, GameObject.Find("/MinimapPlane").transform.position.y - 50f, _0024floor_00245193.transform.position.z), _0024floor_00245193.transform.rotation);
						_0024floorclone_00245194.gameObject.layer = 9;
						_0024floorclone_00245194.renderer.material.shader = Shader.Find("Example/Diffuse Texture");
						UnityEngine.Object.Destroy((MeshCollider)_0024floorclone_00245194.gameObject.GetComponent(typeof(MeshCollider)));
					}
					Debug.Log("CCAssets 5");
					GameObject.Find("/InitializingWorld").SendMessage("perc", 100);
					result = (YieldDefault(12) ? 1 : 0);
					break;
				}
				return (byte)result != 0;
			}
		}

		internal AssetBundle _0024assetBundle_00245244;

		internal WhirldIn _0024self__00245245;

		public _0024LoadBundle_00245171(AssetBundle assetBundle, WhirldIn self_)
		{
			_0024assetBundle_00245244 = assetBundle;
			_0024self__00245245 = self_;
		}

		public override IEnumerator<WWW> GetEnumerator()
		{
			return new _0024(_0024assetBundle_00245244, _0024self__00245245);
		}
	}

	[Serializable]
	internal sealed class _0024LoadOpen_00245246 : GenericGenerator<WWW>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WWW>, IEnumerator
		{
			internal Match _0024m_00245247;

			internal string[] _0024alt_00245248;

			internal UnityEngine.Object _0024floorTex_00245249;

			internal char _0024s_00245250;

			internal string _0024n_00245251;

			internal string _0024v_00245252;

			internal string[] _0024vS_00245253;

			internal Light _0024light_00245254;

			internal GameObject _0024go_00245255;

			internal Transform _0024goobj_00245256;

			internal Whirld _0024whirld_00245257;

			internal Terrain _0024terr_00245258;

			internal TreePrototype[] _0024tarr_00245259;

			internal TreePrototype _0024tproto_00245260;

			internal GameObject _0024obj_00245261;

			internal Transform _0024goobj_00245262;

			internal Renderer _0024obj_00245263;

			internal Material[] _0024objmats_00245264;

			internal Material _0024mat_00245265;

			internal GameObject _0024spawnPointGameObj_00245266;

			internal GameObject _0024redSpawn_00245267;

			internal GameObject _0024blueSpawn_00245268;

			internal GameObject _0024blueFlag_00245269;

			internal GameObject _0024redFlag_00245270;

			internal Light _0024lights_00245271;

			internal Light _0024clone_00245272;

			internal Light _0024clone2_00245273;

			internal GameObject _0024mmobj_00245274;

			internal WWW _0024mmwww_00245275;

			internal GameObject _0024floor_00245276;

			internal GameObject _0024floorclone_00245277;

			internal int _0024_00241400_00245278;

			internal GameObject[] _0024_00241401_00245279;

			internal int _0024_00241402_00245280;

			internal int _0024_00241404_00245281;

			internal Transform[] _0024_00241405_00245282;

			internal int _0024_00241406_00245283;

			internal int _0024_00241408_00245284;

			internal TreePrototype[] _0024_00241409_00245285;

			internal int _0024_00241410_00245286;

			internal int _0024_00241412_00245287;

			internal Terrain[] _0024_00241413_00245288;

			internal int _0024_00241414_00245289;

			internal int _0024_00241416_00245290;

			internal Transform[] _0024_00241417_00245291;

			internal int _0024_00241418_00245292;

			internal int _0024_00241420_00245293;

			internal GameObject[] _0024_00241421_00245294;

			internal int _0024_00241422_00245295;

			internal int _0024_00241424_00245296;

			internal Material[] _0024_00241425_00245297;

			internal int _0024_00241426_00245298;

			internal int _0024_00241428_00245299;

			internal Renderer[] _0024_00241429_00245300;

			internal int _0024_00241430_00245301;

			internal int _0024_00241432_00245302;

			internal Light[] _0024_00241433_00245303;

			internal int _0024_00241434_00245304;

			internal Vector3 _0024_00242843_00245305;

			internal Quaternion _0024_00242844_00245306;

			internal object _0024_00242845_00245307;

			internal Vector3 _0024_00242846_00245308;

			internal float _0024_00242847_00245309;

			internal Vector3 _0024_00242848_00245310;

			internal float _0024_00242849_00245311;

			internal Vector3 _0024_00242850_00245312;

			internal float _0024_00242851_00245313;

			internal Vector3 _0024_00242852_00245314;

			internal float _0024_00242853_00245315;

			internal Vector3 _0024_00242854_00245316;

			internal float _0024_00242855_00245317;

			internal Vector3 _0024_00242856_00245318;

			internal Vector3 _0024_00242857_00245319;

			internal Quaternion _0024_00242858_00245320;

			internal Vector3 _0024_00242859_00245321;

			internal Quaternion _0024_00242860_00245322;

			internal int _0024_00242861_00245323;

			internal Quaternion _0024_00242862_00245324;

			internal Vector3 _0024_00242863_00245325;

			internal int _0024_00242864_00245326;

			internal Vector3 _0024_00242865_00245327;

			internal int _0024_00242866_00245328;

			internal Vector3 _0024_00242867_00245329;

			internal string _0024d_00245330;

			internal WhirldIn _0024self__00245331;

			public _0024(string d, WhirldIn self_)
			{
				_0024d_00245330 = d;
				_0024self__00245331 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00245331.data = _0024d_00245330;
					if (!_0024self__00245331.whirldController)
					{
						_0024self__00245331.whirldControllerObject = GameObject.Find("/_Whirld");
						if (!_0024self__00245331.whirldControllerObject)
						{
							_0024self__00245331.whirldControllerObject = new GameObject("_Whirld");
							_0024self__00245331.whirldController = ((Whirld)_0024self__00245331.whirldControllerObject.AddComponent(typeof(Whirld))) as Whirld;
						}
						else
						{
							_0024self__00245331.whirldController = (Whirld)_0024self__00245331.whirldControllerObject.GetComponent(typeof(Whirld));
						}
						_0024self__00245331.whirldBuffer = new GameObject("Buffer");
						_0024self__00245331.whirldBuffer.transform.parent = _0024self__00245331.whirldControllerObject.transform;
					}
					_0024self__00245331.readChr = 0;
					_0024self__00245331.world = GameObject.Find("World");
					if ((bool)_0024self__00245331.world)
					{
						UnityEngine.Object.Destroy(_0024self__00245331.world);
					}
					_0024self__00245331.world = new GameObject("World");
					_0024self__00245331.statusTxt = "Parsing World Definition";
					if (string.IsNullOrEmpty(_0024self__00245331.data) || UnityScript.Lang.Extensions.get_length(_0024self__00245331.data) < 10 || (_0024self__00245331.data[0] != '[' && _0024self__00245331.data[0] != '{'))
					{
						status = WhirldInStatus.SyntaxError;
						goto case 2;
					}
					_0024m_00245247 = Regex.Match(_0024self__00245331.data, "{(Sea|Floor);([^;]+);([^;]+);([^;]+);([^:]+):([^}]+)}", RegexOptions.IgnoreCase);
					while (_0024m_00245247.Success)
					{
						if (_0024m_00245247.Groups[1].ToString().Equals("Sea"))
						{
							hassea = true;
							_0024alt_00245248 = _0024m_00245247.Groups[2].ToString().Split(","[0]);
							if (UnityScript.Lang.Extensions.get_length((System.Array)_0024alt_00245248) > 1)
							{
								_0024self__00245331.whirldController.@params["seaAlt"] = UnityBuiltins.parseFloat(_0024alt_00245248[1]);
							}
						}
						else if (_0024m_00245247.Groups[1].ToString().Equals("Floor"))
						{
							_0024self__00245331.whirldController.whirldFloor = true;
							if (_0024m_00245247.Groups[7] != null)
							{
								_0024floorTex_00245249 = _0024self__00245331.GetAsset(_0024m_00245247.Groups[6].ToString());
								if (_0024floorTex_00245249 != null)
								{
									_0024self__00245331.whirldController.whirldFloorTexture = (Texture2D)_0024floorTex_00245249;
								}
							}
							_0024alt_00245248 = _0024m_00245247.Groups[2].ToString().Split(","[0]);
							if (_0024alt_00245248.Length > 1)
							{
								_0024self__00245331.whirldController.whirldFloorAlt = UnityBuiltins.parseFloat(_0024alt_00245248[1]);
							}
						}
						_0024m_00245247 = _0024m_00245247.NextMatch();
					}
					_0024self__00245331.data = Regex.Replace(_0024self__00245331.data, "{(Sea|Floor)[^}]*}", string.Empty, RegexOptions.IgnoreCase);
					while (true)
					{
						_0024s_00245250 = _0024self__00245331.data[_0024self__00245331.readChr];
						_0024self__00245331.readChr++;
						if (_0024self__00245331.readChr >= UnityScript.Lang.Extensions.get_length(_0024self__00245331.data))
						{
							break;
						}
						if (_0024s_00245250 == '\n' || _0024s_00245250 == '\t')
						{
							continue;
						}
						if (_0024s_00245250 == '{')
						{
							goto IL_09a1;
						}
						if (_0024s_00245250 == '[')
						{
							_0024n_00245251 = string.Empty;
							_0024v_00245252 = string.Empty;
						}
						else if (_0024s_00245250 == ':' && _0024n_00245251 == string.Empty)
						{
							_0024n_00245251 = _0024v_00245252;
							_0024v_00245252 = string.Empty;
						}
						else if (_0024s_00245250 == ']')
						{
							if (_0024n_00245251 == string.Empty)
							{
								_0024n_00245251 = _0024v_00245252;
								_0024v_00245252 = string.Empty;
							}
							if (_0024n_00245251 == "ab")
							{
								_0024self__00245331.StartCoroutine(_0024self__00245331.LoadAssetBundle(_0024v_00245252));
							}
							if (_0024n_00245251 == "ss")
							{
								_0024self__00245331.StartCoroutine(_0024self__00245331.LoadStreamedScene(_0024v_00245252));
							}
							else if (_0024n_00245251 == "rndSkybox")
							{
								_0024self__00245331.StartCoroutine(_0024self__00245331.LoadSkybox(_0024v_00245252));
							}
							else if (_0024n_00245251 == "txt")
							{
								_0024self__00245331.StartCoroutine(_0024self__00245331.LoadTexture(_0024v_00245252));
							}
							else if (_0024n_00245251 == "msh")
							{
								_0024self__00245331.StartCoroutine(_0024self__00245331.LoadMesh(_0024v_00245252));
							}
							else if (_0024n_00245251 == "trn")
							{
								_0024self__00245331.StartCoroutine(_0024self__00245331.LoadTerrain(_0024v_00245252));
							}
							else if (_0024n_00245251 == "rndFogColor" || _0024n_00245251 == "rndFogDensity" || _0024n_00245251 == "rndAmbientLight" || _0024n_00245251 == "rndHaloStrength" || _0024n_00245251 == "rndFlareStrength")
							{
								_0024vS_00245253 = _0024v_00245252.Split(","[0]);
								if (_0024n_00245251 == "rndFogColor")
								{
									_0024self__00245331.whirldController.fogColor = new Color(UnityBuiltins.parseFloat(_0024vS_00245253[0]), UnityBuiltins.parseFloat(_0024vS_00245253[1]), UnityBuiltins.parseFloat(_0024vS_00245253[2]), 1f);
								}
								else if (_0024n_00245251 == "rndFogDensity")
								{
									_0024self__00245331.whirldController.fogDensity = UnityBuiltins.parseFloat(_0024v_00245252);
								}
								else if (_0024n_00245251 == "rndAmbientLight")
								{
									_0024self__00245331.whirldController.ambientLight = new Color(UnityBuiltins.parseFloat(_0024vS_00245253[0]), UnityBuiltins.parseFloat(_0024vS_00245253[1]), UnityBuiltins.parseFloat(_0024vS_00245253[2]), UnityBuiltins.parseFloat(_0024vS_00245253[3]));
								}
								else if (_0024n_00245251 == "rndHaloStrength")
								{
									_0024self__00245331.whirldController.haloStrength = UnityBuiltins.parseFloat(_0024v_00245252);
								}
								else if (_0024n_00245251 == "rndFlareStrength")
								{
									_0024self__00245331.whirldController.flareStrength = UnityBuiltins.parseFloat(_0024v_00245252);
								}
							}
							else
							{
								_0024self__00245331.whirldController.@params.Add(_0024n_00245251, _0024v_00245252);
							}
						}
						else
						{
							_0024v_00245252 += _0024s_00245250;
						}
					}
					status = WhirldInStatus.SyntaxError;
					goto case 3;
				case 2:
					if (GameObject.Find("/InitializingWorld") == null)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					GameObject.Find("/InitializingWorld").SendMessage("WhirldFail");
					_0024self__00245331.enabled = false;
					goto case 1;
				case 3:
					if (GameObject.Find("/InitializingWorld") == null)
					{
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					GameObject.Find("/InitializingWorld").SendMessage("WhirldFail");
					_0024self__00245331.enabled = false;
					goto case 1;
				case 4:
					if (_0024self__00245331.threads.Count > 0)
					{
						result = (YieldDefault(4) ? 1 : 0);
						break;
					}
					_0024self__00245331.statusTxt = "Initializing World";
					_0024self__00245331.ReadObject(_0024self__00245331.world.transform);
					UnityEngine.Object.Destroy(_0024self__00245331.whirldBuffer);
					if (!RuntimeServices.ToBool(_0024self__00245331.whirldController.@params["nofloor"]) && (!RuntimeServices.ToBool(_0024self__00245331.whirldController.@params["floor"]) || RuntimeServices.EqualityOperator(_0024self__00245331.whirldController.@params["floor"], "0")) && !(Terrain)UnityEngine.Object.FindObjectOfType(typeof(Terrain)) && !_0024self__00245331.whirldController.whirldSea)
					{
						_0024self__00245331.whirldController.whirldFloor = true;
					}
					if (!(Light)UnityEngine.Object.FindObjectOfType(typeof(Light)))
					{
						_0024light_00245254 = (Light)new GameObject("Light", typeof(Light)).GetComponent(typeof(Light));
						Vector3 vector4 = (_0024_00242843_00245305 = new Vector3(30f, 270f, 0f));
						Quaternion quaternion4 = (_0024_00242844_00245306 = _0024light_00245254.gameObject.transform.rotation);
						Vector3 vector5 = (_0024_00242844_00245306.eulerAngles = _0024_00242843_00245305);
						Quaternion quaternion5 = (_0024light_00245254.gameObject.transform.rotation = _0024_00242844_00245306);
						_0024light_00245254.type = LightType.Directional;
						_0024light_00245254.intensity = 0.5f;
						_0024light_00245254.color = Color.white;
					}
					if (!(_0024self__00245331.whirldController.fogDensity > 0f))
					{
						_0024self__00245331.whirldController.UpdateRenderingSettings();
					}
					_0024self__00245331.statusTxt = "Finalizing World";
					_0024_00241400_00245278 = 0;
					_0024_00241401_00245279 = (GameObject[])UnityEngine.Object.FindObjectsOfType(typeof(GameObject));
					for (_0024_00241402_00245280 = _0024_00241401_00245279.Length; _0024_00241400_00245278 < _0024_00241402_00245280; _0024_00241400_00245278++)
					{
						if ((!_0024_00241401_00245279[_0024_00241400_00245278].transform.parent && (bool)_0024_00241401_00245279[_0024_00241400_00245278].camera && _0024_00241401_00245279[_0024_00241400_00245278].camera != Camera.main) || !RuntimeServices.ToBool(_0024self__00245331.whirldController.@params["seaAlt"]) || !_0024_00241401_00245279[_0024_00241400_00245278].transform.parent)
						{
						}
					}
					_0024_00241404_00245281 = 0;
					_0024_00241405_00245282 = (Transform[])UnityEngine.Object.FindObjectsOfType(typeof(Transform));
					for (_0024_00241406_00245283 = _0024_00241405_00245282.Length; _0024_00241404_00245281 < _0024_00241406_00245283; _0024_00241404_00245281++)
					{
						if (_0024_00241405_00245282[_0024_00241404_00245281] != _0024self__00245331.transform)
						{
							if (_0024_00241405_00245282[_0024_00241404_00245281].parent == null && _0024_00241405_00245282[_0024_00241404_00245281].gameObject.name != "WhirldItemsPrefab")
							{
								if (RuntimeServices.ToBool(_0024self__00245331.whirldController.@params["seaAlt"]))
								{
									object obj = (_0024_00242845_00245307 = RuntimeServices.InvokeBinaryOperator("op_Subtraction", _0024_00241405_00245282[_0024_00241404_00245281].position.y, _0024self__00245331.whirldController.@params["seaAlt"]));
									Vector3 vector7 = (_0024_00242846_00245308 = _0024_00241405_00245282[_0024_00241404_00245281].position);
									float num3 = (_0024_00242846_00245308.y = RuntimeServices.UnboxSingle(_0024_00242845_00245307));
									Vector3 vector8 = (_0024_00241405_00245282[_0024_00241404_00245281].position = _0024_00242846_00245308);
								}
								float num4 = (_0024_00242847_00245309 = _0024_00241405_00245282[_0024_00241404_00245281].position.y + 11.5f);
								Vector3 vector10 = (_0024_00242848_00245310 = _0024_00241405_00245282[_0024_00241404_00245281].position);
								float num5 = (_0024_00242848_00245310.y = _0024_00242847_00245309);
								Vector3 vector11 = (_0024_00241405_00245282[_0024_00241404_00245281].position = _0024_00242848_00245310);
							}
							if ((bool)(MeshCollider)_0024_00241405_00245282[_0024_00241404_00245281].GetComponent(typeof(MeshCollider)))
							{
								((MeshCollider)_0024_00241405_00245282[_0024_00241404_00245281].GetComponent(typeof(MeshCollider))).smoothSphereCollisions = false;
							}
							if ((bool)_0024_00241405_00245282[_0024_00241404_00245281].camera)
							{
								UnityEngine.Object.Destroy(_0024_00241405_00245282[_0024_00241404_00245281].gameObject);
							}
						}
					}
					_0024self__00245331.whirldController.OnSceneGenerated();
					status = WhirldInStatus.Success;
					_0024self__00245331.statusTxt = "World Loaded Successfully";
					if (_0024self__00245331.info != string.Empty)
					{
						Debug.Log("Whirld Loading Info: " + _0024self__00245331.info);
					}
					_0024whirld_00245257 = (Whirld)GameObject.Find("_Whirld").GetComponent("Whirld");
					if (_0024whirld_00245257.whirldFloor)
					{
						UnityEngine.Object.Instantiate(_0024self__00245331.whirldFloorPrefab, new Vector3(0f, _0024whirld_00245257.whirldFloorAlt, 0f), Quaternion.identity);
					}
					_0024_00241412_00245287 = 0;
					_0024_00241413_00245288 = (Terrain[])UnityEngine.Object.FindObjectsOfType(typeof(Terrain));
					_0024_00241414_00245289 = _0024_00241413_00245288.Length;
					goto IL_149f;
				case 5:
					_0024_00241412_00245287++;
					goto IL_149f;
				case 6:
					result = (YieldDefault(7) ? 1 : 0);
					break;
				case 7:
					_0024_00241428_00245299 = 0;
					_0024_00241429_00245300 = (Renderer[])UnityEngine.Object.FindObjectsOfType(typeof(Renderer));
					for (_0024_00241430_00245301 = _0024_00241429_00245300.Length; _0024_00241428_00245299 < _0024_00241430_00245301; _0024_00241428_00245299++)
					{
						_0024objmats_00245264 = _0024_00241429_00245300[_0024_00241428_00245299].renderer.materials;
						_0024_00241424_00245296 = 0;
						_0024_00241425_00245297 = _0024objmats_00245264;
						for (_0024_00241426_00245298 = _0024_00241425_00245297.Length; _0024_00241424_00245296 < _0024_00241426_00245298; _0024_00241424_00245296++)
						{
							if (!_0024_00241425_00245297[_0024_00241424_00245296].shader || string.IsNullOrEmpty(_0024_00241425_00245297[_0024_00241424_00245296].shader.name))
							{
								_0024_00241425_00245297[_0024_00241424_00245296].shader = Shader.Find("Diffuse");
							}
							if (_0024_00241425_00245297[_0024_00241424_00245296].shader.name == "Shield")
							{
								_0024_00241425_00245297[_0024_00241424_00245296].shader = Shader.Find("Shield");
							}
							if (_0024_00241425_00245297[_0024_00241424_00245296].shader.name == "FX/Lava")
							{
								_0024_00241425_00245297[_0024_00241424_00245296].shader = Shader.Find("Transparent/VertexLit");
								if (AuthGameObject.whirldname == "Eric's CTF")
								{
									if ((bool)(Collider)_0024_00241429_00245300[_0024_00241428_00245299].GetComponent(typeof(Collider)))
									{
										_0024_00241429_00245300[_0024_00241428_00245299].collider.isTrigger = true;
										UnityRuntimeServices.Invoke(_0024_00241429_00245300[_0024_00241428_00245299], "AddComponent", new object[1] { "WhirldWaterTrigger" }, typeof(UnityEngine.MonoBehaviour));
									}
								}
								else
								{
									_0024_00241429_00245300[_0024_00241428_00245299].collider.isTrigger = false;
								}
							}
							if (_0024_00241425_00245297[_0024_00241424_00245296].name == "skyking-glass (Instance)")
							{
								_0024_00241425_00245297[_0024_00241424_00245296].shader = Shader.Find("Transparent/GlassShiny");
							}
							if (_0024_00241425_00245297[_0024_00241424_00245296].shader.name == "Transparent/GlassShiny")
							{
								_0024_00241425_00245297[_0024_00241424_00245296].shader = Shader.Find("Transparent/GlassShiny");
							}
							if (_0024_00241425_00245297[_0024_00241424_00245296].shader.name == "Transparent/GlassGlowing")
							{
								_0024_00241425_00245297[_0024_00241424_00245296].shader = Shader.Find("Transparent/GlassShiny");
							}
							if (_0024_00241425_00245297[_0024_00241424_00245296].shader.name == "Transparent/GlassGlowing")
							{
								_0024_00241425_00245297[_0024_00241424_00245296].shader = Shader.Find("Transparent/GlassShiny");
							}
						}
					}
					if (AuthGameObject.whirldname == "Fai's Sunken Wastes")
					{
						GameObject.Find("/Bridge").renderer.material = _0024self__00245331.faibridgemat;
					}
					_0024spawnPointGameObj_00245266 = GameObject.Find("/Spawn Point");
					_0024spawnPointGameObj_00245266.transform.position = GameObject.Find("Base").transform.position;
					if (AuthGameObject.whirldname == "Eric's CTF")
					{
						_0024redSpawn_00245267 = new GameObject("RedSpawn");
						_0024redSpawn_00245267.transform.position = new Vector3(3499.902f, 25f, 2095.467f);
						Vector3 vector19 = (_0024_00242857_00245319 = new Vector3(0f, -90f, 0f));
						Quaternion quaternion7 = (_0024_00242858_00245320 = _0024redSpawn_00245267.transform.rotation);
						Vector3 vector20 = (_0024_00242858_00245320.eulerAngles = _0024_00242857_00245319);
						Quaternion quaternion8 = (_0024redSpawn_00245267.transform.rotation = _0024_00242858_00245320);
						_0024blueSpawn_00245268 = new GameObject("BlueSpawn");
						_0024blueSpawn_00245268.transform.position = new Vector3(423.0586f, 25f, 2095.467f);
						Vector3 vector22 = (_0024_00242859_00245321 = new Vector3(0f, 90f, 0f));
						Quaternion quaternion10 = (_0024_00242860_00245322 = _0024blueSpawn_00245268.transform.rotation);
						Vector3 vector23 = (_0024_00242860_00245322.eulerAngles = _0024_00242859_00245321);
						Quaternion quaternion11 = (_0024blueSpawn_00245268.transform.rotation = _0024_00242860_00245322);
						RuntimeServices.SetProperty(_0024spawnPointGameObj_00245266.GetComponent("SpawningScript"), "redspawn1", _0024redSpawn_00245267);
						RuntimeServices.SetProperty(_0024spawnPointGameObj_00245266.GetComponent("SpawningScript"), "redspawn2", _0024redSpawn_00245267);
						RuntimeServices.SetProperty(_0024spawnPointGameObj_00245266.GetComponent("SpawningScript"), "redspawn3", _0024redSpawn_00245267);
						RuntimeServices.SetProperty(_0024spawnPointGameObj_00245266.GetComponent("SpawningScript"), "redspawn4", _0024redSpawn_00245267);
						RuntimeServices.SetProperty(_0024spawnPointGameObj_00245266.GetComponent("SpawningScript"), "redspawn5", _0024redSpawn_00245267);
						RuntimeServices.SetProperty(_0024spawnPointGameObj_00245266.GetComponent("SpawningScript"), "redspawn6", _0024redSpawn_00245267);
						RuntimeServices.SetProperty(_0024spawnPointGameObj_00245266.GetComponent("SpawningScript"), "spawn1", _0024blueSpawn_00245268);
						RuntimeServices.SetProperty(_0024spawnPointGameObj_00245266.GetComponent("SpawningScript"), "spawn2", _0024blueSpawn_00245268);
						RuntimeServices.SetProperty(_0024spawnPointGameObj_00245266.GetComponent("SpawningScript"), "spawn3", _0024blueSpawn_00245268);
						RuntimeServices.SetProperty(_0024spawnPointGameObj_00245266.GetComponent("SpawningScript"), "spawn4", _0024blueSpawn_00245268);
						RuntimeServices.SetProperty(_0024spawnPointGameObj_00245266.GetComponent("SpawningScript"), "spawn5", _0024blueSpawn_00245268);
						RuntimeServices.SetProperty(_0024spawnPointGameObj_00245266.GetComponent("SpawningScript"), "spawn6", _0024blueSpawn_00245268);
						if (AuthGameObject.gametype == "Capture the Flag" && PhotonNetwork.isMasterClient)
						{
							flagId = PhotonNetwork.AllocateViewID();
							flag2Id = PhotonNetwork.AllocateViewID();
							_0024blueFlag_00245269 = (GameObject)UnityEngine.Object.Instantiate(_0024self__00245331.ctfprefabblue, new Vector3(422.0682f, 107.0283f, 2094.59f), Quaternion.Euler(0f, 270f, 0f));
							_0024redFlag_00245270 = (GameObject)UnityEngine.Object.Instantiate(_0024self__00245331.ctfprefabred, new Vector3(3503.526f, 107.0283f, 2094.517f), Quaternion.Euler(0f, 90f, 0f));
							RuntimeServices.SetProperty(_0024blueFlag_00245269.GetComponent("CTFFlagSender"), "otherflagunit", _0024redFlag_00245270.gameObject);
							RuntimeServices.SetProperty(_0024blueFlag_00245269.GetComponent("CTFFlagSender"), "srcobj", GameObject.Find("/GUI/Chat"));
							RuntimeServices.SetProperty(_0024blueFlag_00245269.GetComponent("CTFFlagSender"), "igs", GameObject.Find("/GUI/GameScores"));
							((PhotonView)_0024blueFlag_00245269.GetComponent(typeof(PhotonView))).viewID = flagId;
							RuntimeServices.SetProperty(_0024redFlag_00245270.GetComponent("CTFFlagSender"), "otherflagunit", _0024blueFlag_00245269.gameObject);
							RuntimeServices.SetProperty(_0024redFlag_00245270.GetComponent("CTFFlagSender"), "srcobj", GameObject.Find("/GUI/Chat"));
							RuntimeServices.SetProperty(_0024redFlag_00245270.GetComponent("CTFFlagSender"), "igs", GameObject.Find("/GUI/GameScores"));
							RuntimeServices.SetProperty(_0024spawnPointGameObj_00245266.GetComponent("SpawningScript"), "flagbase", _0024blueFlag_00245269.gameObject);
							((PhotonView)_0024redFlag_00245270.GetComponent(typeof(PhotonView))).viewID = flag2Id;
							_0024blueFlag_00245269.gameObject.name = "FlagBase";
							_0024redFlag_00245270.gameObject.name = "FlagBase";
						}
					}
					if ((bool)GameObject.Find("BotSpawner"))
					{
						GameObject.Find("BotSpawner").transform.position = GameObject.Find("Base").transform.position;
					}
					GameObject.Find("BotSpectator").transform.position = GameObject.Find("Base").transform.position;
					GameObject.Find("/MinimapCam").transform.position = new Vector3(GameObject.Find("Base").transform.position.x, GameObject.Find("/MinimapCam").transform.position.y, GameObject.Find("Base").transform.position.z);
					Camera.main.transform.position = new Vector3(GameObject.Find("Base").transform.position.x, GameObject.Find("Base").transform.position.y + 100f, GameObject.Find("Base").transform.position.z);
					Camera.main.transform.LookAt(GameObject.Find("Base").transform);
					UnityEngine.Object.Destroy(GameObject.Find("/World/Base"));
					Debug.Log("CCAssets 2");
					GameObject.Find("/InitializingWorld").SendMessage("perc", 40);
					result = (YieldDefault(8) ? 1 : 0);
					break;
				case 8:
					_0024_00241432_00245302 = 0;
					_0024_00241433_00245303 = (Light[])UnityEngine.Object.FindObjectsOfType(typeof(Light));
					for (_0024_00241434_00245304 = _0024_00241433_00245303.Length; _0024_00241432_00245302 < _0024_00241434_00245304; _0024_00241432_00245302++)
					{
						_0024_00241433_00245303[_0024_00241432_00245302].cullingMask = _0024self__00245331.pixelLight.value;
						_0024_00241433_00245303[_0024_00241432_00245302].renderMode = LightRenderMode.Auto;
						_0024clone_00245272 = (Light)UnityEngine.Object.Instantiate(_0024_00241433_00245303[_0024_00241432_00245302], _0024_00241433_00245303[_0024_00241432_00245302].transform.position, _0024_00241433_00245303[_0024_00241432_00245302].transform.rotation);
						_0024clone_00245272.cullingMask = _0024self__00245331.vertLight.value;
						_0024clone_00245272.renderMode = LightRenderMode.ForceVertex;
						_0024clone2_00245273 = (Light)UnityEngine.Object.Instantiate(_0024_00241433_00245303[_0024_00241432_00245302], _0024_00241433_00245303[_0024_00241432_00245302].transform.position, _0024_00241433_00245303[_0024_00241432_00245302].transform.rotation);
						_0024clone2_00245273.cullingMask = _0024self__00245331.minimapLight.value;
						_0024clone2_00245273.renderMode = LightRenderMode.ForceVertex;
						_0024clone2_00245273.intensity = 0.5f;
						_0024clone2_00245273.color = Color.white;
					}
					if (RenderSettings.skybox == null)
					{
						RenderSettings.skybox = _0024self__00245331.spaceskybox;
						RenderSettings.fogColor = _0024self__00245331.fogcolor;
						RenderSettings.fog = true;
						RenderSettings.fogDensity = 0.0002f;
					}
					Debug.Log("CCAssets 3");
					GameObject.Find("/InitializingWorld").SendMessage("perc", 60);
					result = (YieldDefault(9) ? 1 : 0);
					break;
				case 9:
					if (!hassea)
					{
						GameObject.Find("/Water").SetActiveRecursively(false);
					}
					if (AuthGameObject.whirldname == "Eric's CTF")
					{
						hassea = true;
					}
					Debug.Log("CCAssets 4");
					GameObject.Find("/InitializingWorld").SendMessage("perc", 80);
					result = (YieldDefault(10) ? 1 : 0);
					break;
				case 10:
					if (_0024self__00245331.authobjwname != "Custom World")
					{
						_0024mmobj_00245274 = GameObject.Find("/MinimapPlane");
						_0024mmobj_00245274.renderer.material.mainTexture = new Texture2D(4, 4, TextureFormat.ARGB32, false);
						_0024mmwww_00245275 = new WWW(_0024self__00245331.authobjwurl);
						result = (Yield(11, _0024mmwww_00245275) ? 1 : 0);
						break;
					}
					GameObject.Find("/MinimapPlane").transform.position = new Vector3(0f, -800f, 0f);
					GameObject.Find("/MinimapPlane").transform.localScale = new Vector3(5000f, 1f, 5000f);
					GameObject.Find("/MinimapPlane").renderer.material.mainTexture = _0024self__00245331.gridTexture;
					GameObject.Find("/MinimapPlane").renderer.material.mainTextureScale = new Vector2(50f, 50f);
					goto IL_2b7f;
				case 11:
					result = (YieldDefault(12) ? 1 : 0);
					break;
				case 12:
					if (_0024mmwww_00245275.error == null)
					{
						_0024mmwww_00245275.LoadImageIntoTexture((Texture2D)_0024mmobj_00245274.renderer.material.mainTexture);
						if (_0024self__00245331.authobjwname == "Seb's Sky King" || _0024self__00245331.authobjwname == "Doug's Floating Islands" || _0024self__00245331.authobjwname == "Seb's Cliff Hangers" || _0024self__00245331.authobjwname == "Abister's Asteroids")
						{
							if (_0024self__00245331.authobjwname == "Seb's Sky King")
							{
								_0024mmobj_00245274.transform.position = new Vector3(63.26446f, -800f, -19.53878f);
								_0024mmobj_00245274.transform.localScale = new Vector3(298.0172f, 1f, 271.0456f);
							}
							if (_0024self__00245331.authobjwname == "Doug's Floating Islands")
							{
								_0024mmobj_00245274.transform.position = new Vector3(1396.008f, -800f, 1716.506f);
								int num = (_0024_00242861_00245323 = 90);
								Quaternion quaternion = (_0024_00242862_00245324 = _0024mmobj_00245274.transform.localRotation);
								Vector3 vector = (_0024_00242863_00245325 = _0024_00242862_00245324.eulerAngles);
								float num2 = (_0024_00242863_00245325.y = _0024_00242861_00245323);
								Vector3 vector2 = (_0024_00242862_00245324.eulerAngles = _0024_00242863_00245325);
								Quaternion quaternion2 = (_0024mmobj_00245274.transform.localRotation = _0024_00242862_00245324);
								_0024mmobj_00245274.transform.localScale = new Vector3(928f, 1f, 928f);
							}
							if (_0024self__00245331.authobjwname == "Seb's Cliff Hangers")
							{
								_0024mmobj_00245274.transform.localScale = new Vector3(950f, 1f, 950f);
							}
							if (_0024self__00245331.authobjwname == "Abister's Asteroids")
							{
								_0024mmobj_00245274.transform.position = new Vector3(42.69141f, -800f, -184.0637f);
								_0024mmobj_00245274.transform.localScale = new Vector3(109.2793f, 1f, 98.20826f);
							}
						}
						else if ((bool)Terrain.activeTerrain)
						{
							_0024mmobj_00245274.transform.position = new Vector3(Terrain.activeTerrain.transform.position.x + Terrain.activeTerrain.terrainData.size.x / 2f, -800f, Terrain.activeTerrain.transform.position.z + Terrain.activeTerrain.terrainData.size.z / 2f);
							_0024mmobj_00245274.transform.localScale = new Vector3(Terrain.activeTerrain.terrainData.size.x / 10f, 1f, Terrain.activeTerrain.terrainData.size.z / 10f);
						}
					}
					else
					{
						GameObject.Find("/MinimapPlane").transform.position = new Vector3(0f, -800f, 0f);
						GameObject.Find("/MinimapPlane").transform.localScale = new Vector3(5000f, 1f, 5000f);
						GameObject.Find("/MinimapPlane").renderer.material.mainTexture = _0024self__00245331.gridTexture;
						GameObject.Find("/MinimapPlane").renderer.material.mainTextureScale = new Vector2(50f, 50f);
					}
					goto IL_2b7f;
				case 13:
					GameObject.Find("/InitializingWorld").SendMessage("FadeOut");
					Debug.Log("CCAssets 6");
					YieldDefault(1);
					goto case 1;
				case 1:
					{
						result = 0;
						break;
					}
					IL_2b7f:
					if (_0024self__00245331.whirldController.whirldFloor && (bool)Terrain.activeTerrain)
					{
						_0024floor_00245276 = GameObject.CreatePrimitive(PrimitiveType.Plane);
						_0024floor_00245276.transform.position = new Vector3(0f, Terrain.activeTerrain.transform.position.y - 0.125f, 0f);
						int num6 = (_0024_00242864_00245326 = 9999);
						Vector3 vector13 = (_0024_00242865_00245327 = _0024floor_00245276.transform.localScale);
						float num7 = (_0024_00242865_00245327.x = _0024_00242864_00245326);
						Vector3 vector14 = (_0024floor_00245276.transform.localScale = _0024_00242865_00245327);
						int num8 = (_0024_00242866_00245328 = 9999);
						Vector3 vector16 = (_0024_00242867_00245329 = _0024floor_00245276.transform.localScale);
						float num9 = (_0024_00242867_00245329.z = _0024_00242866_00245328);
						Vector3 vector17 = (_0024floor_00245276.transform.localScale = _0024_00242867_00245329);
						_0024floor_00245276.renderer.material.mainTexture = Terrain.activeTerrain.terrainData.splatPrototypes[0].texture;
						_0024floor_00245276.renderer.material.mainTextureScale = Terrain.activeTerrain.terrainData.splatPrototypes[0].tileSize / 15f * 6000f;
						_0024floorclone_00245277 = (GameObject)UnityEngine.Object.Instantiate(_0024floor_00245276, new Vector3(_0024floor_00245276.transform.position.x, GameObject.Find("/MinimapPlane").transform.position.y - 50f, _0024floor_00245276.transform.position.z), _0024floor_00245276.transform.rotation);
						_0024floorclone_00245277.gameObject.layer = 9;
						_0024floorclone_00245277.renderer.material.shader = Shader.Find("Example/Diffuse Texture");
						UnityEngine.Object.Destroy((MeshCollider)_0024floorclone_00245277.gameObject.GetComponent(typeof(MeshCollider)));
					}
					Debug.Log("CCAssets 5");
					GameObject.Find("/InitializingWorld").SendMessage("perc", 100);
					result = (YieldDefault(13) ? 1 : 0);
					break;
					IL_09a1:
					_0024self__00245331.statusTxt = "Streaming Whirld Assets";
					goto case 4;
					IL_149f:
					if (_0024_00241412_00245287 < _0024_00241414_00245289)
					{
						_0024_00241413_00245288[_0024_00241412_00245287].heightmapPixelError = 59f;
						_0024tarr_00245259 = _0024_00241413_00245288[_0024_00241412_00245287].terrainData.treePrototypes;
						if (UnityScript.Lang.Extensions.get_length((System.Array)_0024tarr_00245259) > 0)
						{
							_0024_00241408_00245284 = 0;
							_0024_00241409_00245285 = _0024tarr_00245259;
							for (_0024_00241410_00245286 = _0024_00241409_00245285.Length; _0024_00241408_00245284 < _0024_00241410_00245286; _0024_00241408_00245284++)
							{
								if (_0024_00241409_00245285[_0024_00241408_00245284].prefab.name == "Palm")
								{
									_0024_00241409_00245285[_0024_00241408_00245284].prefab = _0024self__00245331.tprefabs[0];
								}
								if (_0024_00241409_00245285[_0024_00241408_00245284].prefab.name.Contains("Alder"))
								{
									_0024_00241409_00245285[_0024_00241408_00245284].prefab = _0024self__00245331.tprefabs[1];
								}
								if (_0024_00241409_00245285[_0024_00241408_00245284].prefab.name == "Bamboo")
								{
									_0024_00241409_00245285[_0024_00241408_00245284].prefab = _0024self__00245331.tprefabs[2];
								}
								if (_0024_00241409_00245285[_0024_00241408_00245284].prefab.name == "Banyan" || _0024_00241409_00245285[_0024_00241408_00245284].prefab.name == "BanyanTree")
								{
									_0024_00241409_00245285[_0024_00241408_00245284].prefab = _0024self__00245331.tprefabs[3];
								}
								if (_0024_00241409_00245285[_0024_00241408_00245284].prefab.name == "JapaneseMaple")
								{
									_0024_00241409_00245285[_0024_00241408_00245284].prefab = _0024self__00245331.tprefabs[4];
								}
								if (_0024_00241409_00245285[_0024_00241408_00245284].prefab.name.Contains("Mimosa"))
								{
									_0024_00241409_00245285[_0024_00241408_00245284].prefab = _0024self__00245331.tprefabs[5];
								}
								if (_0024_00241409_00245285[_0024_00241408_00245284].prefab.name == "Palm (group)")
								{
									_0024_00241409_00245285[_0024_00241408_00245284].prefab = _0024self__00245331.tprefabs[6];
								}
								if (_0024_00241409_00245285[_0024_00241408_00245284].prefab.name == "ScotsPineTypeA")
								{
									_0024_00241409_00245285[_0024_00241408_00245284].prefab = _0024self__00245331.tprefabs[7];
								}
								if (_0024_00241409_00245285[_0024_00241408_00245284].prefab.name == "ScotsPineTypeB")
								{
									_0024_00241409_00245285[_0024_00241408_00245284].prefab = _0024self__00245331.tprefabs[8];
								}
								if (_0024_00241409_00245285[_0024_00241408_00245284].prefab.name.Contains("Sycamore"))
								{
									_0024_00241409_00245285[_0024_00241408_00245284].prefab = _0024self__00245331.tprefabs[9];
								}
								if (_0024_00241409_00245285[_0024_00241408_00245284].prefab.name.Contains("Willow"))
								{
									_0024_00241409_00245285[_0024_00241408_00245284].prefab = _0024self__00245331.tprefabs[9];
								}
								if (_0024_00241409_00245285[_0024_00241408_00245284].prefab.name == "ThinTree")
								{
									_0024_00241409_00245285[_0024_00241408_00245284].prefab = _0024self__00245331.tprefabs[10];
								}
							}
						}
						_0024_00241413_00245288[_0024_00241412_00245287].terrainData.treePrototypes = _0024tarr_00245259;
						_0024_00241413_00245288[_0024_00241412_00245287].terrainData.RefreshPrototypes();
						result = (YieldDefault(5) ? 1 : 0);
						break;
					}
					_0024_00241420_00245293 = 0;
					_0024_00241421_00245294 = (GameObject[])UnityEngine.Object.FindObjectsOfType(typeof(GameObject));
					for (_0024_00241422_00245295 = _0024_00241421_00245294.Length; _0024_00241420_00245293 < _0024_00241422_00245295; _0024_00241420_00245293++)
					{
						if (_0024_00241421_00245294[_0024_00241420_00245293].tag == "minimap")
						{
							_0024_00241421_00245294[_0024_00241420_00245293].tag = "Untagged";
						}
						if (_0024_00241421_00245294[_0024_00241420_00245293].tag == "BlueObjects")
						{
							_0024_00241421_00245294[_0024_00241420_00245293].tag = "Untagged";
						}
						if (_0024_00241421_00245294[_0024_00241420_00245293].layer == 4)
						{
							_0024_00241421_00245294[_0024_00241420_00245293].layer = 0;
						}
						if (_0024_00241421_00245294[_0024_00241420_00245293].name == "CamoTower" && AuthGameObject.whirldname == "Eric's CTF")
						{
							UnityEngine.Object.Destroy(_0024_00241421_00245294[_0024_00241420_00245293]);
						}
						if (_0024_00241421_00245294[_0024_00241420_00245293].name == "Lava" && AuthGameObject.whirldname == "Eric's CTF")
						{
							float num10 = (_0024_00242849_00245311 = 200f);
							Vector3 vector25 = (_0024_00242850_00245312 = _0024_00241421_00245294[_0024_00241420_00245293].transform.localScale);
							float num11 = (_0024_00242850_00245312.y = _0024_00242849_00245311);
							Vector3 vector26 = (_0024_00241421_00245294[_0024_00241420_00245293].transform.localScale = _0024_00242850_00245312);
							float num12 = (_0024_00242851_00245313 = _0024_00241421_00245294[_0024_00241420_00245293].transform.position.y - 100f);
							Vector3 vector28 = (_0024_00242852_00245314 = _0024_00241421_00245294[_0024_00241420_00245293].transform.position);
							float num13 = (_0024_00242852_00245314.y = _0024_00242851_00245313);
							Vector3 vector29 = (_0024_00241421_00245294[_0024_00241420_00245293].transform.position = _0024_00242852_00245314);
						}
						if (!hassea && _0024_00241421_00245294[_0024_00241420_00245293].name == "Sea")
						{
							hassea = true;
							_0024_00241416_00245290 = 0;
							_0024_00241417_00245291 = (Transform[])UnityEngine.Object.FindObjectsOfType(typeof(Transform));
							for (_0024_00241418_00245292 = _0024_00241417_00245291.Length; _0024_00241416_00245290 < _0024_00241418_00245292; _0024_00241416_00245290++)
							{
								if (_0024_00241417_00245291[_0024_00241416_00245290] != _0024self__00245331.transform && _0024_00241417_00245291[_0024_00241416_00245290].parent == null && _0024_00241417_00245291[_0024_00241416_00245290].gameObject.name != "WhirldItemsPrefab")
								{
									float num14 = (_0024_00242853_00245315 = _0024_00241417_00245291[_0024_00241416_00245290].position.y - _0024_00241421_00245294[_0024_00241420_00245293].transform.position.y);
									Vector3 vector31 = (_0024_00242854_00245316 = _0024_00241417_00245291[_0024_00241416_00245290].position);
									float num15 = (_0024_00242854_00245316.y = _0024_00242853_00245315);
									Vector3 vector32 = (_0024_00241417_00245291[_0024_00241416_00245290].position = _0024_00242854_00245316);
									float num16 = (_0024_00242855_00245317 = _0024_00241417_00245291[_0024_00241416_00245290].position.y + 11.5f);
									Vector3 vector34 = (_0024_00242856_00245318 = _0024_00241417_00245291[_0024_00241416_00245290].position);
									float num17 = (_0024_00242856_00245318.y = _0024_00242855_00245317);
									Vector3 vector35 = (_0024_00241417_00245291[_0024_00241416_00245290].position = _0024_00242856_00245318);
								}
							}
							UnityEngine.Object.Destroy(_0024_00241421_00245294[_0024_00241420_00245293]);
						}
						else if (_0024_00241421_00245294[_0024_00241420_00245293].name == "Sea")
						{
							UnityEngine.Object.Destroy(_0024_00241421_00245294[_0024_00241420_00245293]);
						}
					}
					GameObject.Find("/InitializingWorld").SendMessage("dloading");
					Debug.Log("CCAssets 1");
					GameObject.Find("/InitializingWorld").SendMessage("perc", 20);
					result = (YieldDefault(6) ? 1 : 0);
					break;
				}
				return (byte)result != 0;
			}
		}

		internal string _0024d_00245332;

		internal WhirldIn _0024self__00245333;

		public _0024LoadOpen_00245246(string d, WhirldIn self_)
		{
			_0024d_00245332 = d;
			_0024self__00245333 = self_;
		}

		public override IEnumerator<WWW> GetEnumerator()
		{
			return new _0024(_0024d_00245332, _0024self__00245333);
		}
	}

	[Serializable]
	internal sealed class _0024LoadAssetBundle_00245334 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string _0024thread_00245335;

			internal string _0024url_00245336;

			internal WWW _0024www_00245337;

			internal int _0024trycount_00245338;

			internal string _0024p_00245339;

			internal WhirldIn _0024self__00245340;

			public _0024(string p, WhirldIn self_)
			{
				_0024p_00245339 = p;
				_0024self__00245340 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00245340.threadAssetBundles++;
					InitWorld.loadCount++;
					goto case 2;
				case 2:
					if (_0024self__00245340.threads.Count >= _0024self__00245340.maxThreads)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024thread_00245335 = Path.GetFileNameWithoutExtension(_0024p_00245339);
					_0024self__00245340.threads.Add(_0024thread_00245335, string.Empty);
					_0024url_00245336 = _0024p_00245339;
					_0024url_00245336 = _0024self__00245340.GetURL(_0024url_00245336);
					_0024www_00245337 = new WWW(_0024self__00245340.Cache(_0024url_00245336));
					goto case 3;
				case 3:
					if (!_0024www_00245337.isDone)
					{
						InitWorld.assetLoad = _0024www_00245337.progress;
						_0024self__00245340.threads[_0024thread_00245335] = _0024www_00245337.progress;
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					_0024trycount_00245338 = 0;
					goto IL_01dc;
				case 4:
					if (!_0024www_00245337.isDone)
					{
						InitWorld.assetLoad = _0024www_00245337.progress;
						_0024self__00245340.threads[_0024thread_00245335] = _0024www_00245337.progress;
						result = (YieldDefault(4) ? 1 : 0);
						break;
					}
					_0024trycount_00245338++;
					goto IL_01dc;
				case 5:
					if (GameObject.Find("/InitializingWorld") == null)
					{
						result = (YieldDefault(5) ? 1 : 0);
						break;
					}
					GameObject.Find("/InitializingWorld").SendMessage("WhirldFail");
					_0024self__00245340.threads.Remove(_0024thread_00245335);
					_0024self__00245340.threadAssetBundles--;
					_0024self__00245340.enabled = false;
					goto case 1;
				case 1:
					{
						result = 0;
						break;
					}
					IL_01dc:
					if (!string.IsNullOrEmpty(_0024www_00245337.error) && _0024trycount_00245338 < 2)
					{
						if (!string.IsNullOrEmpty(_0024www_00245337.error))
						{
							_0024www_00245337 = new WWW(_0024self__00245340.Cache(_0024url_00245336));
						}
						goto case 4;
					}
					if (!string.IsNullOrEmpty(_0024www_00245337.error) || !_0024www_00245337.assetBundle)
					{
						if (!_0024www_00245337.assetBundle)
						{
							_0024self__00245340.info += "Referenced file is not an AssetBundle: " + _0024url_00245336 + "\n";
						}
						else
						{
							_0024self__00245340.info += "Failed to download asset file: " + _0024url_00245336 + " (" + _0024www_00245337.error + ")\n";
						}
						goto case 5;
					}
					_0024self__00245340.CacheStore(_0024url_00245336, _0024www_00245337.bytes);
					_0024self__00245340.threads[_0024thread_00245335] = "Initializing Bundle";
					_0024self__00245340.TrackBundle(_0024www_00245337.assetBundle);
					_0024self__00245340.threads.Remove(_0024thread_00245335);
					_0024self__00245340.threadAssetBundles--;
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal string _0024p_00245341;

		internal WhirldIn _0024self__00245342;

		public _0024LoadAssetBundle_00245334(string p, WhirldIn self_)
		{
			_0024p_00245341 = p;
			_0024self__00245342 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024p_00245341, _0024self__00245342);
		}
	}

	[Serializable]
	internal sealed class _0024LoadStreamedScene_00245343 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string _0024thread_00245344;

			internal string _0024nme_00245345;

			internal string _0024url_00245346;

			internal string[] _0024pS_00245347;

			internal WWW _0024www_00245348;

			internal AssetBundle _0024blah_00245349;

			internal AsyncOperation _0024async_00245350;

			internal float _0024tme_00245351;

			internal string _0024p_00245352;

			internal WhirldIn _0024self__00245353;

			public _0024(string p, WhirldIn self_)
			{
				_0024p_00245352 = p;
				_0024self__00245353 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					InitWorld.loadCount++;
					goto case 2;
				case 2:
					if (_0024self__00245353.threads.Count >= _0024self__00245353.maxThreads)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024thread_00245344 = "SceneData";
					_0024self__00245353.threads.Add(_0024thread_00245344, string.Empty);
					_0024nme_00245345 = "World";
					_0024url_00245346 = "Whirld.unity3d";
					if (_0024p_00245352 != string.Empty)
					{
						_0024pS_00245347 = _0024p_00245352.Split(","[0]);
						if (!string.IsNullOrEmpty(_0024pS_00245347[0]))
						{
							_0024nme_00245345 = _0024pS_00245347[0];
						}
						if (!string.IsNullOrEmpty(_0024pS_00245347[1]))
						{
							_0024url_00245346 = _0024pS_00245347[1];
						}
					}
					_0024url_00245346 = _0024self__00245353.GetURL(_0024url_00245346);
					_0024www_00245348 = new WWW(_0024self__00245353.Cache(_0024url_00245346));
					goto case 3;
				case 3:
					if (!_0024www_00245348.isDone)
					{
						InitWorld.sceneLoad = _0024www_00245348.progress;
						_0024self__00245353.threads[_0024thread_00245344] = _0024www_00245348.progress;
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					Debug.Log("Loading from url: " + _0024url_00245346);
					if (!string.IsNullOrEmpty(_0024www_00245348.error) || !_0024www_00245348.assetBundle)
					{
						if (!_0024www_00245348.assetBundle)
						{
							_0024self__00245353.info += "StreamedScene file contains no scenes: " + _0024url_00245346 + "\n";
						}
						else
						{
							_0024self__00245353.info += "Failed to download asset file: " + _0024url_00245346 + " (" + _0024www_00245348.error + ")\n";
						}
						goto case 4;
					}
					_0024self__00245353.CacheStore(_0024url_00245346, _0024www_00245348.bytes);
					_0024self__00245353.threads[_0024thread_00245344] = "Loading Asset Dependencies";
					goto case 5;
				case 4:
					if (GameObject.Find("/InitializingWorld") == null)
					{
						result = (YieldDefault(4) ? 1 : 0);
						break;
					}
					GameObject.Find("/InitializingWorld").SendMessage("WhirldFail");
					_0024self__00245353.threads.Remove(_0024thread_00245344);
					_0024self__00245353.enabled = false;
					goto case 1;
				case 5:
					if (_0024self__00245353.threadAssetBundles > 0)
					{
						result = (YieldDefault(5) ? 1 : 0);
						break;
					}
					_0024self__00245353.threads.Remove(_0024thread_00245344);
					_0024thread_00245344 = "SceneInit - May Take a While";
					_0024self__00245353.threads.Add(_0024thread_00245344, "...");
					_0024blah_00245349 = _0024www_00245348.assetBundle;
					Application.backgroundLoadingPriority = ThreadPriority.High;
					_0024async_00245350 = Application.LoadLevelAdditiveAsync(_0024nme_00245345);
					_0024tme_00245351 = Time.time;
					goto case 6;
				case 6:
					if (!_0024async_00245350.isDone)
					{
						_0024self__00245353.threads[_0024thread_00245344] = Time.time - _0024tme_00245351 + "...";
						result = (YieldDefault(6) ? 1 : 0);
						break;
					}
					_0024self__00245353.TrackBundle(_0024www_00245348.assetBundle);
					_0024self__00245353.threads.Remove(_0024thread_00245344);
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal string _0024p_00245354;

		internal WhirldIn _0024self__00245355;

		public _0024LoadStreamedScene_00245343(string p, WhirldIn self_)
		{
			_0024p_00245354 = p;
			_0024self__00245355 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024p_00245354, _0024self__00245355);
		}
	}

	[Serializable]
	internal sealed class _0024LoadTexture_00245356 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string[] _0024vS_00245357;

			internal string _0024thread_00245358;

			internal string _0024url_00245359;

			internal WWW _0024www_00245360;

			internal Texture2D _0024txt_00245361;

			internal string _0024p_00245362;

			internal WhirldIn _0024self__00245363;

			public _0024(string p, WhirldIn self_)
			{
				_0024p_00245362 = p;
				_0024self__00245363 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00245363.threadTextures++;
					InitWorld.loadCount++;
					goto case 2;
				case 2:
					if (_0024self__00245363.threads.Count >= _0024self__00245363.maxThreads)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024vS_00245357 = _0024p_00245362.Split(","[0]);
					_0024thread_00245358 = "Txt" + _0024self__00245363.threadTextures + " - " + _0024vS_00245357[0];
					_0024self__00245363.threads.Add(_0024thread_00245358, string.Empty);
					_0024url_00245359 = _0024self__00245363.GetURL(_0024vS_00245357[1]);
					_0024www_00245360 = new WWW(_0024self__00245363.Cache(_0024url_00245359));
					goto case 3;
				case 3:
					if (!_0024www_00245360.isDone)
					{
						InitWorld.textureLoad = _0024www_00245360.progress;
						_0024self__00245363.threads[_0024thread_00245358] = _0024www_00245360.progress;
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					if (!string.IsNullOrEmpty(_0024www_00245360.error))
					{
						_0024self__00245363.info += "Failed to download texture: " + _0024url_00245359 + " (" + _0024www_00245360.error + ")\n";
						_0024self__00245363.threads.Remove(_0024thread_00245358);
						_0024self__00245363.threadTextures--;
					}
					else
					{
						_0024self__00245363.CacheStore(_0024url_00245359, _0024www_00245360.bytes);
						_0024self__00245363.threads[_0024thread_00245358] = "Initializing";
						_0024txt_00245361 = new Texture2D(4, 4, TextureFormat.DXT1, true);
						_0024www_00245360.LoadImageIntoTexture(_0024txt_00245361);
						_0024txt_00245361.wrapMode = ((string.IsNullOrEmpty(_0024vS_00245357[2]) || UnityBuiltins.parseInt(_0024vS_00245357[2]) == 0) ? TextureWrapMode.Clamp : TextureWrapMode.Repeat);
						_0024txt_00245361.anisoLevel = (string.IsNullOrEmpty(_0024vS_00245357[3]) ? 1 : UnityBuiltins.parseInt(_0024vS_00245357[3]));
						_0024txt_00245361.Apply(true);
						_0024txt_00245361.Compress(true);
						_0024self__00245363.textures.Add(_0024vS_00245357[0], _0024txt_00245361);
						_0024self__00245363.threads.Remove(_0024thread_00245358);
						_0024self__00245363.threadTextures--;
						YieldDefault(1);
					}
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal string _0024p_00245364;

		internal WhirldIn _0024self__00245365;

		public _0024LoadTexture_00245356(string p, WhirldIn self_)
		{
			_0024p_00245364 = p;
			_0024self__00245365 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024p_00245364, _0024self__00245365);
		}
	}

	[Serializable]
	internal sealed class _0024LoadMeshTexture_00245366 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string _0024thread_00245367;

			internal WWW _0024www_00245368;

			internal Texture2D _0024mshTxt_00245369;

			internal string _0024url_00245370;

			internal string _0024materialName_00245371;

			internal WhirldIn _0024self__00245372;

			public _0024(string url, string materialName, WhirldIn self_)
			{
				_0024url_00245370 = url;
				_0024materialName_00245371 = materialName;
				_0024self__00245372 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00245372.threadTextures++;
					InitWorld.loadCount++;
					goto case 2;
				case 2:
					if (_0024self__00245372.threads.Count >= _0024self__00245372.maxThreads)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024thread_00245367 = "MshTxt" + _0024self__00245372.threadTextures + " - " + _0024materialName_00245371;
					_0024self__00245372.threads.Add(_0024thread_00245367, string.Empty);
					_0024url_00245370 = _0024self__00245372.GetURL(_0024url_00245370);
					_0024www_00245368 = new WWW(_0024self__00245372.Cache(_0024url_00245370));
					goto case 3;
				case 3:
					if (!_0024www_00245368.isDone)
					{
						RuntimeServices.SetProperty(_0024self__00245372.initworld, "sharedMeshtextureLoad", _0024www_00245368.progress);
						_0024self__00245372.threads[_0024thread_00245367] = _0024www_00245368.progress;
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					if (!string.IsNullOrEmpty(_0024www_00245368.error))
					{
						_0024self__00245372.info += "Failed to download mesh texture: " + _0024url_00245370 + " (" + _0024www_00245368.error + ")\n";
						_0024self__00245372.threads.Remove(_0024thread_00245367);
						_0024self__00245372.threadTextures--;
					}
					else
					{
						_0024self__00245372.CacheStore(_0024url_00245370, _0024www_00245368.bytes);
						_0024self__00245372.threads[_0024thread_00245367] = "Initializing";
						_0024mshTxt_00245369 = new Texture2D(4, 4, TextureFormat.DXT1, true);
						_0024www_00245368.LoadImageIntoTexture(_0024mshTxt_00245369);
						_0024mshTxt_00245369.wrapMode = TextureWrapMode.Repeat;
						_0024mshTxt_00245369.Apply(true);
						_0024mshTxt_00245369.Compress(true);
						RuntimeServices.SetProperty(_0024self__00245372.meshMaterials[_0024materialName_00245371], "mainTexture", _0024mshTxt_00245369);
						_0024self__00245372.threads.Remove(_0024thread_00245367);
						_0024self__00245372.threadTextures--;
						YieldDefault(1);
					}
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal string _0024url_00245373;

		internal string _0024materialName_00245374;

		internal WhirldIn _0024self__00245375;

		public _0024LoadMeshTexture_00245366(string url, string materialName, WhirldIn self_)
		{
			_0024url_00245373 = url;
			_0024materialName_00245374 = materialName;
			_0024self__00245375 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024url_00245373, _0024materialName_00245374, _0024self__00245375);
		}
	}

	[Serializable]
	internal sealed class _0024LoadMesh_00245376 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string[] _0024vS_00245377;

			internal string _0024thread_00245378;

			internal int _0024hasCollider_00245379;

			internal WWW _0024www_00245380;

			internal int _0024lastDot_00245381;

			internal string _0024data_00245382;

			internal string _0024ext_00245383;

			internal Mesh _0024msh_00245384;

			internal UnityScript.Lang.Array _0024verts_00245385;

			internal UnityScript.Lang.Array _0024norms_00245386;

			internal UnityScript.Lang.Array _0024uvs_00245387;

			internal UnityScript.Lang.Array _0024tris_00245388;

			internal UnityScript.Lang.Array _0024triangles_00245389;

			internal UnityScript.Lang.Array _0024mats_00245390;

			internal float _0024timer_00245391;

			internal string[] _0024file_00245392;

			internal string _0024str_00245393;

			internal string[] _0024l_00245394;

			internal int _0024i_00245395;

			internal string[] _0024meshlib_00245396;

			internal Material _0024curMat_00245397;

			internal int _0024offset_00245398;

			internal string _0024meshline_00245399;

			internal string[] _0024ml_00245400;

			internal string _0024shdr_00245401;

			internal GameObject _0024mshObj_00245402;

			internal int _0024_00241436_00245403;

			internal string[] _0024_00241437_00245404;

			internal int _0024_00241438_00245405;

			internal int _0024_00241440_00245406;

			internal string[] _0024_00241441_00245407;

			internal int _0024_00241442_00245408;

			internal string _0024v_00245409;

			internal WhirldIn _0024self__00245410;

			public _0024(string v, WhirldIn self_)
			{
				_0024v_00245409 = v;
				_0024self__00245410 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					InitWorld.loadCount++;
					Debug.Log("Loading Mesh: " + _0024v_00245409);
					goto case 2;
				case 2:
					if (_0024self__00245410.threads.Count >= _0024self__00245410.maxThreads)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024vS_00245377 = _0024v_00245409.Split(","[0]);
					_0024thread_00245378 = _0024vS_00245377[0];
					_0024self__00245410.threads.Add(_0024thread_00245378, string.Empty);
					_0024hasCollider_00245379 = ((UnityScript.Lang.Extensions.get_length((System.Array)_0024vS_00245377) > 2) ? UnityBuiltins.parseInt(_0024vS_00245377[2]) : 0);
					_0024www_00245380 = new WWW(_0024self__00245410.GetURL(_0024vS_00245377[1]));
					goto case 3;
				case 3:
					if (!_0024www_00245380.isDone)
					{
						RuntimeServices.SetProperty(_0024self__00245410.initworld, "sharedMeshLoad", _0024www_00245380.progress);
						_0024self__00245410.threads[_0024thread_00245378] = _0024www_00245380.progress;
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					if (!string.IsNullOrEmpty(_0024www_00245380.error))
					{
						_0024self__00245410.info += "Failed to download mesh: " + _0024self__00245410.url + " (" + _0024www_00245380.error + ")\n";
						_0024self__00245410.threads.Remove(_0024thread_00245378);
						goto case 1;
					}
					_0024self__00245410.CacheStore(_0024self__00245410.url, _0024www_00245380.bytes);
					_0024self__00245410.threads[_0024thread_00245378] = "Decompressing";
					result = (YieldDefault(4) ? 1 : 0);
					break;
				case 4:
					_0024lastDot_00245381 = _0024vS_00245377[1].LastIndexOf(".");
					if (_0024vS_00245377[1].Substring(_0024lastDot_00245381 + 1) == "gz")
					{
						_0024data_00245382 = GZipStream.UncompressString(_0024www_00245380.bytes);
						_0024vS_00245377[1] = _0024vS_00245377[1].Substring(0, _0024lastDot_00245381);
					}
					else
					{
						_0024data_00245382 = _0024www_00245380.text;
					}
					_0024self__00245410.threads[_0024thread_00245378] = "Generating";
					_0024lastDot_00245381 = _0024vS_00245377[1].LastIndexOf(".");
					_0024ext_00245383 = _0024vS_00245377[1].Substring(_0024lastDot_00245381 + 1);
					if (!(_0024ext_00245383 == "utm"))
					{
						if (_0024ext_00245383 == "obj")
						{
							_0024msh_00245384 = new Mesh();
							_0024verts_00245385 = new UnityScript.Lang.Array();
							_0024norms_00245386 = new UnityScript.Lang.Array();
							_0024uvs_00245387 = new UnityScript.Lang.Array();
							_0024tris_00245388 = new UnityScript.Lang.Array();
							_0024triangles_00245389 = new UnityScript.Lang.Array();
							_0024mats_00245390 = new UnityScript.Lang.Array();
							_0024timer_00245391 = Time.time + 0.1f;
							_0024file_00245392 = _0024data_00245382.Split("\n"[0]);
							_0024_00241440_00245406 = 0;
							_0024_00241441_00245407 = _0024file_00245392;
							_0024_00241442_00245408 = _0024_00241441_00245407.Length;
							goto IL_0dd3;
						}
						_0024self__00245410.info += "Mesh Type Unrecognized: " + _0024vS_00245377[0] + " " + _0024vS_00245377[1] + " (." + _0024ext_00245383 + ")\n";
					}
					goto IL_0f38;
				case 5:
					_0024_00241440_00245406++;
					goto IL_0dd3;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0f38:
					if (_0024hasCollider_00245379 != 1)
					{
						_0024mshObj_00245402 = new GameObject(_0024vS_00245377[0]);
						_0024mshObj_00245402.AddComponent(typeof(MeshFilter));
						((MeshFilter)_0024mshObj_00245402.GetComponent(typeof(MeshFilter))).sharedMesh = _0024msh_00245384;
						_0024mshObj_00245402.AddComponent(typeof(MeshRenderer));
						((MeshRenderer)_0024mshObj_00245402.GetComponent(typeof(MeshRenderer))).materials = (Material[])_0024mats_00245390.ToBuiltin(typeof(Material));
						if (_0024hasCollider_00245379 != -1)
						{
							_0024mshObj_00245402.AddComponent(typeof(MeshCollider));
							((MeshCollider)_0024mshObj_00245402.GetComponent(typeof(MeshCollider))).sharedMesh = _0024msh_00245384;
						}
						if (UnityScript.Lang.Extensions.get_length((System.Array)_0024msh_00245384.uv) < 1)
						{
							_0024self__00245410.TextureObject(_0024mshObj_00245402);
						}
						_0024self__00245410.objects.Add(_0024vS_00245377[0], _0024mshObj_00245402);
						_0024mshObj_00245402.transform.parent = _0024self__00245410.whirldBuffer.transform;
					}
					else if (_0024self__00245410.objects.ContainsKey(_0024vS_00245377[0]))
					{
						object obj = _0024self__00245410.objects[_0024vS_00245377[0]];
						if (!(obj is GameObject))
						{
							obj = RuntimeServices.Coerce(obj, typeof(GameObject));
						}
						_0024mshObj_00245402 = (GameObject)obj;
						_0024mshObj_00245402.AddComponent(typeof(MeshCollider));
						((MeshCollider)_0024mshObj_00245402.GetComponent(typeof(MeshCollider))).sharedMesh = _0024msh_00245384;
					}
					else
					{
						_0024mshObj_00245402 = new GameObject(_0024vS_00245377[0]);
						_0024mshObj_00245402.AddComponent(typeof(MeshCollider));
						((MeshCollider)_0024mshObj_00245402.GetComponent(typeof(MeshCollider))).sharedMesh = _0024msh_00245384;
						_0024self__00245410.objects.Add(_0024vS_00245377[0], _0024mshObj_00245402);
						_0024mshObj_00245402.transform.parent = _0024self__00245410.whirldBuffer.transform;
					}
					_0024msh_00245384.Optimize();
					_0024self__00245410.threads.Remove(_0024thread_00245378);
					YieldDefault(1);
					goto case 1;
					IL_0dd3:
					if (_0024_00241440_00245406 < _0024_00241442_00245408)
					{
						if (!(_0024_00241441_00245407[_0024_00241440_00245406] == string.Empty))
						{
							_0024l_00245394 = _0024_00241441_00245407[_0024_00241440_00245406].Split(" "[0]);
							if (_0024l_00245394[0] == "v")
							{
								_0024verts_00245385.Add(new Vector3(0f - UnityBuiltins.parseFloat(_0024l_00245394[1]), UnityBuiltins.parseFloat(_0024l_00245394[2]), UnityBuiltins.parseFloat(_0024l_00245394[3])));
							}
							else if (_0024l_00245394[0] == "vn")
							{
								_0024norms_00245386.Add(new Vector3(UnityBuiltins.parseFloat(_0024l_00245394[1]), UnityBuiltins.parseFloat(_0024l_00245394[2]), UnityBuiltins.parseFloat(_0024l_00245394[3])));
							}
							else if (_0024l_00245394[0] == "vt")
							{
								_0024uvs_00245387.Add(new Vector2(UnityBuiltins.parseFloat(_0024l_00245394[1]), UnityBuiltins.parseFloat(_0024l_00245394[2])));
							}
							else if (_0024l_00245394[0] == "f")
							{
								if (UnityScript.Lang.Extensions.get_length((System.Array)_0024l_00245394) == 4)
								{
									_0024tris_00245388.Add(UnityBuiltins.parseInt(_0024l_00245394[2].Substring(0, _0024l_00245394[2].IndexOf("/"))) - 1);
									_0024tris_00245388.Add(UnityBuiltins.parseInt(_0024l_00245394[1].Substring(0, _0024l_00245394[1].IndexOf("/"))) - 1);
									_0024tris_00245388.Add(UnityBuiltins.parseInt(_0024l_00245394[3].Substring(0, _0024l_00245394[3].IndexOf("/"))) - 1);
								}
								else
								{
									for (_0024i_00245395 = 2; _0024i_00245395 < UnityScript.Lang.Extensions.get_length((System.Array)_0024l_00245394); _0024i_00245395++)
									{
										_0024tris_00245388.Add(UnityBuiltins.parseInt(_0024l_00245394[_0024i_00245395].Substring(0, _0024l_00245394[_0024i_00245395].IndexOf("/"))) - 1);
										if (_0024i_00245395 % 2 == 0)
										{
											_0024tris_00245388.Add(UnityBuiltins.parseInt(_0024l_00245394[1].Substring(0, _0024l_00245394[1].IndexOf("/"))) - 1);
										}
									}
									while (_0024tris_00245388.length % 3 != 0)
									{
										_0024tris_00245388.Add(UnityBuiltins.parseInt(_0024l_00245394[_0024i_00245395 - 2].Substring(0, _0024l_00245394[_0024i_00245395 - 2].IndexOf("/"))) - 1);
									}
								}
							}
							else if (_0024l_00245394[0] == "usemtl")
							{
								if (_0024self__00245410.meshMaterials.ContainsKey(_0024l_00245394[1]))
								{
									_0024mats_00245390.Add(_0024self__00245410.meshMaterials[_0024l_00245394[1]]);
								}
								else
								{
									_0024self__00245410.info += "Mesh Material Missing: " + _0024l_00245394[1] + "\n";
									Debug.Log("Mesh Material Missing");
									_0024mats_00245390.Add(null);
								}
								if (_0024tris_00245388.length > 0)
								{
									_0024triangles_00245389.Add(_0024tris_00245388);
									_0024tris_00245388 = new UnityScript.Lang.Array();
								}
							}
							else if (_0024l_00245394[0] == "mtllib" && !_0024self__00245410.meshMatLibs.ContainsKey(_0024l_00245394[1]))
							{
								_0024self__00245410.meshMatLibs.Add(_0024l_00245394[1], true);
								_0024www_00245380 = new WWW(_0024self__00245410.GetURL(_0024l_00245394[1]));
								while (!_0024www_00245380.isDone)
								{
									_0024self__00245410.threads[_0024thread_00245378] = "Downloading Material Library (" + Mathf.RoundToInt(_0024www_00245380.progress * 100f) + "%)";
								}
								if (_0024www_00245380.error != null)
								{
									_0024self__00245410.info += "Mesh Material Library Undownloadable: " + _0024self__00245410.GetURL(_0024l_00245394[1]) + " (" + _0024www_00245380.error + ")\n";
								}
								else
								{
									_0024self__00245410.CacheStore(_0024self__00245410.url, _0024www_00245380.bytes);
									_0024self__00245410.threads[_0024thread_00245378] = "Initializing " + _0024vS_00245377[0] + string.Empty;
									_0024meshlib_00245396 = _0024www_00245380.text.Split("\n"[0]);
									_0024curMat_00245397 = null;
									_0024offset_00245398 = -1;
									do
									{
										_0024offset_00245398 = _0024www_00245380.text.IndexOf("map_Ka", _0024offset_00245398 + 1);
									}
									while (_0024offset_00245398 != -1);
									_0024_00241436_00245403 = 0;
									_0024_00241437_00245404 = _0024meshlib_00245396;
									for (_0024_00241438_00245405 = _0024_00241437_00245404.Length; _0024_00241436_00245403 < _0024_00241438_00245405; _0024_00241436_00245403++)
									{
										_0024ml_00245400 = _0024_00241437_00245404[_0024_00241436_00245403].Split(" "[0]);
										if (_0024ml_00245400[0] == "newmtl")
										{
											if ((bool)_0024curMat_00245397)
											{
												_0024self__00245410.meshMaterials.Add(_0024curMat_00245397.name, _0024curMat_00245397);
											}
											_0024curMat_00245397 = new Material(Shader.Find("VertexLit"));
											_0024curMat_00245397.name = _0024ml_00245400[1];
										}
										else if (_0024ml_00245400[0] == "#Shader")
										{
											_0024shdr_00245401 = _0024_00241437_00245404[_0024_00241436_00245403].Substring(8).Replace("Diffuse", "VertexLit");
											if (_0024shdr_00245401 != "VertexLit" && _0024shdr_00245401 != "VertexLit Fast")
											{
												_0024curMat_00245397.shader = Shader.Find(_0024shdr_00245401);
											}
										}
										else if (_0024ml_00245400[0] == "Ka")
										{
											_0024curMat_00245397.color = new Color(UnityBuiltins.parseFloat(_0024ml_00245400[1]), UnityBuiltins.parseFloat(_0024ml_00245400[2]), UnityBuiltins.parseFloat(_0024ml_00245400[3]), 1f);
										}
										else if (_0024ml_00245400[0] == "Kd")
										{
											_0024curMat_00245397.SetColor("_Emission", new Color(UnityBuiltins.parseFloat(_0024ml_00245400[1]), UnityBuiltins.parseFloat(_0024ml_00245400[2]), UnityBuiltins.parseFloat(_0024ml_00245400[3]), 1f));
										}
										else if (_0024ml_00245400[0] == "Ks")
										{
											_0024curMat_00245397.SetColor("_SpecColor", new Color(UnityBuiltins.parseFloat(_0024ml_00245400[1]), UnityBuiltins.parseFloat(_0024ml_00245400[2]), UnityBuiltins.parseFloat(_0024ml_00245400[3]), 1f));
										}
										else if (_0024ml_00245400[0] == "Ns")
										{
											_0024curMat_00245397.SetFloat("_Shininess", UnityBuiltins.parseFloat(_0024ml_00245400[1]));
										}
										else if (_0024ml_00245400[0] == "map_Ka")
										{
											_0024curMat_00245397.mainTextureOffset = new Vector2(UnityBuiltins.parseFloat(_0024ml_00245400[2]), UnityBuiltins.parseFloat(_0024ml_00245400[3]));
											_0024curMat_00245397.mainTextureScale = new Vector2(UnityBuiltins.parseFloat(_0024ml_00245400[5]), UnityBuiltins.parseFloat(_0024ml_00245400[6]));
											_0024self__00245410.StartCoroutine(_0024self__00245410.LoadMeshTexture(_0024ml_00245400[7], _0024curMat_00245397.name));
										}
										else if (!(_0024ml_00245400[0] == "d"))
										{
										}
									}
									if ((bool)_0024curMat_00245397)
									{
										_0024self__00245410.meshMaterials.Add(_0024curMat_00245397.name, _0024curMat_00245397);
									}
								}
							}
							if (!(Time.time <= _0024timer_00245391))
							{
								_0024timer_00245391 = Time.time + 0.1f;
								result = (YieldDefault(5) ? 1 : 0);
								break;
							}
						}
						goto case 5;
					}
					_0024self__00245410.threads[_0024thread_00245378] = "Initializing";
					_0024msh_00245384.vertices = _0024verts_00245385.ToBuiltin(typeof(Vector3)) as Vector3[];
					_0024msh_00245384.normals = _0024norms_00245386.ToBuiltin(typeof(Vector3)) as Vector3[];
					_0024msh_00245384.uv = _0024uvs_00245387.ToBuiltin(typeof(Vector2)) as Vector2[];
					if (_0024triangles_00245389.length > 0)
					{
						_0024triangles_00245389.Add(_0024tris_00245388);
						_0024msh_00245384.subMeshCount = _0024triangles_00245389.length;
					}
					else
					{
						_0024msh_00245384.triangles = _0024tris_00245388.ToBuiltin(typeof(int)) as int[];
					}
					goto IL_0f38;
				}
				return (byte)result != 0;
			}
		}

		internal string _0024v_00245411;

		internal WhirldIn _0024self__00245412;

		public _0024LoadMesh_00245376(string v, WhirldIn self_)
		{
			_0024v_00245411 = v;
			_0024self__00245412 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024v_00245411, _0024self__00245412);
		}
	}

	[Serializable]
	internal sealed class _0024LoadTerrain_00245413 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string[] _0024vS2_00245414;

			internal string _0024tName_00245415;

			internal int _0024i2_00245416;

			internal string[] _0024str_00245417;

			internal string[] _0024tRes_00245418;

			internal string _0024tHtmp_00245419;

			internal string _0024tLtmp_00245420;

			internal string _0024tSpmp_00245421;

			internal string _0024tSpmp2_00245422;

			internal string[] _0024tTxts_00245423;

			internal string _0024tDtmp_00245424;

			internal string _0024thread_00245425;

			internal WWW _0024www_00245426;

			internal int _0024tWidth_00245427;

			internal int _0024tHeight_00245428;

			internal int _0024tLength_00245429;

			internal int _0024tHRes_00245430;

			internal TerrainData _0024trnDat_00245431;

			internal float[,] _0024hmap_00245432;

			internal BinaryReader _0024br_00245433;

			internal int _0024x_00245434;

			internal int _0024y_00245435;

			internal SplatPrototype[] _0024splatPrototypes_00245436;

			internal int _0024i_00245437;

			internal string[] _0024splatTxt_00245438;

			internal string[] _0024splatTxtSize_00245439;

			internal Color[] _0024mapColors2_00245440;

			internal float[,,] _0024splatmapData_00245441;

			internal Color[] _0024mapColors_00245442;

			internal int _0024ht_00245443;

			internal int _0024wd_00245444;

			internal int _0024z_00245445;

			internal GameObject _0024trnObj_00245446;

			internal string _0024v_00245447;

			internal WhirldIn _0024self__00245448;

			public _0024(string v, WhirldIn self_)
			{
				_0024v_00245447 = v;
				_0024self__00245448 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					InitWorld.loadCount++;
					_0024vS2_00245414 = _0024v_00245447.Split(";"[0]);
					_0024tName_00245415 = _0024vS2_00245414[0];
					for (_0024i2_00245416 = 1; _0024i2_00245416 < UnityScript.Lang.Extensions.get_length((System.Array)_0024vS2_00245414); _0024i2_00245416++)
					{
						_0024str_00245417 = _0024vS2_00245414[_0024i2_00245416].Split(":"[0]);
						if (_0024str_00245417[0] == "r")
						{
							_0024tRes_00245418 = _0024str_00245417[1].Split(","[0]);
						}
						else if (_0024str_00245417[0] == "h")
						{
							_0024tHtmp_00245419 = _0024self__00245448.GetURL(_0024str_00245417[1]);
						}
						else if (_0024str_00245417[0] == "l")
						{
							_0024tLtmp_00245420 = _0024self__00245448.GetURL(_0024str_00245417[1]);
						}
						else if (_0024str_00245417[0] == "s")
						{
							_0024tSpmp_00245421 = _0024self__00245448.GetURL(_0024str_00245417[1]);
						}
						else if (_0024str_00245417[0] == "s2")
						{
							_0024tSpmp2_00245422 = _0024self__00245448.GetURL(_0024str_00245417[1]);
						}
						else if (_0024str_00245417[0] == "t")
						{
							_0024tTxts_00245423 = _0024str_00245417[1].Split(","[0]);
						}
						else if (_0024str_00245417[0] == "d")
						{
							_0024tDtmp_00245424 = _0024self__00245448.GetURL(_0024str_00245417[1]);
						}
					}
					_0024thread_00245425 = _0024tName_00245415;
					_0024self__00245448.threads.Add(_0024thread_00245425, string.Empty);
					_0024www_00245426 = new WWW(_0024tHtmp_00245419);
					goto case 2;
				case 2:
					if (!_0024www_00245426.isDone)
					{
						InitWorld.terrainLoad = _0024www_00245426.progress;
						_0024self__00245448.threads[_0024thread_00245425] = _0024www_00245426.progress;
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					if (_0024www_00245426.error != null)
					{
						_0024self__00245448.info += "Terrain Undownloadable: " + _0024tName_00245415 + " " + _0024tHtmp_00245419 + " (" + _0024www_00245426.error + ")\n";
					}
					else
					{
						_0024self__00245448.CacheStore(_0024self__00245448.url, _0024www_00245426.bytes);
						_0024self__00245448.threads[_0024thread_00245425] = "Initializing";
						_0024tWidth_00245427 = UnityBuiltins.parseInt(_0024tRes_00245418[0]);
						_0024tHeight_00245428 = UnityBuiltins.parseInt(_0024tRes_00245418[1]);
						_0024tLength_00245429 = UnityBuiltins.parseInt(_0024tRes_00245418[2]);
						_0024tHRes_00245430 = UnityBuiltins.parseInt(_0024tRes_00245418[3]);
						_0024trnDat_00245431 = new TerrainData();
						_0024trnDat_00245431.heightmapResolution = _0024tHRes_00245430;
						_0024hmap_00245432 = _0024trnDat_00245431.GetHeights(0, 0, _0024tHRes_00245430, _0024tHRes_00245430);
						_0024br_00245433 = null;
						_0024br_00245433 = new BinaryReader(new MemoryStream(GZipStream.UncompressBuffer(_0024www_00245426.bytes)));
						for (_0024x_00245434 = 0; _0024x_00245434 < _0024tHRes_00245430; _0024x_00245434++)
						{
							for (_0024y_00245435 = 0; _0024y_00245435 < _0024tHRes_00245430; _0024y_00245435++)
							{
								_0024hmap_00245432[_0024x_00245434, _0024y_00245435] = (float)(int)_0024br_00245433.ReadUInt16() / 65535f;
							}
						}
						_0024trnDat_00245431.SetHeights(0, 0, _0024hmap_00245432);
						_0024trnDat_00245431.size = new Vector3(_0024tWidth_00245427, _0024tHeight_00245428, _0024tLength_00245429);
						if (_0024tTxts_00245423 != null)
						{
							_0024splatPrototypes_00245436 = new SplatPrototype[UnityScript.Lang.Extensions.get_length((System.Array)_0024tTxts_00245423)];
							for (_0024i_00245437 = 0; _0024i_00245437 < UnityScript.Lang.Extensions.get_length((System.Array)_0024tTxts_00245423); _0024i_00245437++)
							{
								_0024splatTxt_00245438 = _0024tTxts_00245423[_0024i_00245437].Split("="[0]);
								_0024splatTxtSize_00245439 = _0024splatTxt_00245438[1].Split("x"[0]);
								_0024www_00245426 = new WWW(_0024self__00245448.GetURL(_0024splatTxt_00245438[0]));
								while (!_0024www_00245426.isDone)
								{
								}
								if (_0024www_00245426.error != null)
								{
									_0024self__00245448.info += "Terrain Texture Undownloadable: #" + (_0024i_00245437 + 1) + " (" + _0024splatTxt_00245438[0] + ")\n";
								}
								else
								{
									_0024self__00245448.CacheStore(_0024self__00245448.url, _0024www_00245426.bytes);
									_0024splatPrototypes_00245436[_0024i_00245437] = new SplatPrototype();
									_0024splatPrototypes_00245436[_0024i_00245437].texture = new Texture2D(4, 4, TextureFormat.DXT1, true);
									_0024www_00245426.LoadImageIntoTexture(_0024splatPrototypes_00245436[_0024i_00245437].texture);
									_0024splatPrototypes_00245436[_0024i_00245437].texture.Apply(true);
									_0024splatPrototypes_00245436[_0024i_00245437].texture.Compress(true);
									_0024splatPrototypes_00245436[_0024i_00245437].tileSize = new Vector2(UnityBuiltins.parseInt(_0024splatTxtSize_00245439[0]), UnityBuiltins.parseInt(_0024splatTxtSize_00245439[1]));
								}
							}
						}
						_0024trnDat_00245431.splatPrototypes = _0024splatPrototypes_00245436;
						if (!string.IsNullOrEmpty(_0024tSpmp_00245421))
						{
							if (!string.IsNullOrEmpty(_0024tSpmp2_00245422))
							{
								_0024www_00245426 = new WWW(_0024tSpmp2_00245422);
								while (!_0024www_00245426.isDone)
								{
								}
								_0024self__00245448.CacheStore(_0024self__00245448.url, _0024www_00245426.bytes);
								_0024mapColors2_00245440 = _0024www_00245426.texture.GetPixels();
							}
							_0024www_00245426 = new WWW(_0024tSpmp_00245421);
							while (!_0024www_00245426.isDone)
							{
							}
							if (_0024www_00245426.error != null)
							{
								_0024self__00245448.info += "Terrain Texturemap Undownloadable: " + _0024tName_00245415 + " " + _0024tLtmp_00245420 + " (" + _0024www_00245426.error + ")\n";
							}
							else if (_0024www_00245426.texture.format != TextureFormat.ARGB32 || _0024www_00245426.texture.width != _0024www_00245426.texture.height || Mathf.ClosestPowerOfTwo(_0024www_00245426.texture.width) != _0024www_00245426.texture.width)
							{
								_0024self__00245448.info += "Terrain Splatmap Unusable: Splatmap must be in RGBA 32 bit format, square, and it's size a power of 2\n";
							}
							else
							{
								_0024self__00245448.CacheStore(_0024self__00245448.url, _0024www_00245426.bytes);
								_0024trnDat_00245431.alphamapResolution = _0024www_00245426.texture.width;
								_0024splatmapData_00245441 = _0024trnDat_00245431.GetAlphamaps(0, 0, _0024www_00245426.texture.width, _0024www_00245426.texture.width);
								_0024mapColors_00245442 = _0024www_00245426.texture.GetPixels();
								_0024ht_00245443 = _0024www_00245426.texture.height;
								_0024wd_00245444 = _0024www_00245426.texture.width;
								for (_0024y_00245435 = 0; _0024y_00245435 < _0024ht_00245443; _0024y_00245435++)
								{
									for (_0024x_00245434 = 0; _0024x_00245434 < _0024wd_00245444; _0024x_00245434++)
									{
										for (_0024z_00245445 = 0; _0024z_00245445 < _0024trnDat_00245431.alphamapLayers; _0024z_00245445++)
										{
											if (_0024z_00245445 < 4)
											{
												_0024splatmapData_00245441[_0024x_00245434, _0024y_00245435, _0024z_00245445] = _0024mapColors_00245442[_0024x_00245434 * _0024wd_00245444 + _0024y_00245435][_0024z_00245445];
											}
											else
											{
												_0024splatmapData_00245441[_0024x_00245434, _0024y_00245435, _0024z_00245445] = _0024mapColors2_00245440[_0024x_00245434 * _0024wd_00245444 + _0024y_00245435][_0024z_00245445 - 4];
											}
										}
									}
								}
								_0024trnDat_00245431.SetAlphamaps(0, 0, _0024splatmapData_00245441);
							}
						}
						_0024trnObj_00245446 = new GameObject(_0024tName_00245415);
						_0024trnObj_00245446.AddComponent(typeof(Terrain));
						((Terrain)_0024trnObj_00245446.GetComponent(typeof(Terrain))).terrainData = _0024trnDat_00245431;
						_0024trnObj_00245446.AddComponent(typeof(TerrainCollider));
						((TerrainCollider)_0024trnObj_00245446.GetComponent(typeof(TerrainCollider))).terrainData = _0024trnDat_00245431;
						_0024self__00245448.objects.Add(_0024tName_00245415, _0024trnObj_00245446);
						_0024trnObj_00245446.transform.parent = _0024self__00245448.whirldBuffer.transform;
					}
					_0024self__00245448.threads.Remove(_0024thread_00245425);
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal string _0024v_00245449;

		internal WhirldIn _0024self__00245450;

		public _0024LoadTerrain_00245413(string v, WhirldIn self_)
		{
			_0024v_00245449 = v;
			_0024self__00245450 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024v_00245449, _0024self__00245450);
		}
	}

	[Serializable]
	internal sealed class _0024LoadSkyboxTexture_00245451 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string _0024thread_00245452;

			internal WWW _0024www_00245453;

			internal Texture2D _0024txt_00245454;

			internal string _0024url_00245455;

			internal int _0024dest_00245456;

			internal WhirldIn _0024self__00245457;

			public _0024(string url, int dest, WhirldIn self_)
			{
				_0024url_00245455 = url;
				_0024dest_00245456 = dest;
				_0024self__00245457 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00245457.threadTextures++;
					InitWorld.loadCount++;
					goto case 2;
				case 2:
					if (_0024self__00245457.threads.Count >= _0024self__00245457.maxThreads)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024thread_00245452 = "Skybox" + _0024dest_00245456;
					_0024self__00245457.threads.Add(_0024thread_00245452, string.Empty);
					_0024url_00245455 = _0024self__00245457.GetURL(_0024url_00245455);
					_0024www_00245453 = new WWW(_0024self__00245457.Cache(_0024url_00245455));
					goto case 3;
				case 3:
					if (!_0024www_00245453.isDone)
					{
						InitWorld.skyboxLoad = _0024www_00245453.progress;
						_0024self__00245457.threads[_0024thread_00245452] = _0024www_00245453.progress;
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					_0024self__00245457.threads.Remove(_0024thread_00245452);
					_0024self__00245457.threadTextures--;
					if (!string.IsNullOrEmpty(_0024www_00245453.error))
					{
						_0024self__00245457.info += "Failed to download skybox # " + _0024dest_00245456 + ": " + _0024url_00245455 + " (" + _0024www_00245453.error + ")\n";
					}
					else
					{
						_0024self__00245457.CacheStore(_0024url_00245455, _0024www_00245453.bytes);
						_0024txt_00245454 = new Texture2D(4, 4, TextureFormat.DXT1, true);
						_0024www_00245453.LoadImageIntoTexture(_0024txt_00245454);
						_0024txt_00245454.wrapMode = TextureWrapMode.Clamp;
						_0024txt_00245454.Apply(true);
						_0024txt_00245454.Compress(true);
						if (_0024dest_00245456 == 0 || _0024dest_00245456 == 1)
						{
							_0024self__00245457.whirldController.skybox.SetTexture("_FrontTex", _0024txt_00245454);
						}
						if (_0024dest_00245456 == 0 || _0024dest_00245456 == 2)
						{
							_0024self__00245457.whirldController.skybox.SetTexture("_BackTex", _0024txt_00245454);
						}
						if (_0024dest_00245456 == 0 || _0024dest_00245456 == 3)
						{
							_0024self__00245457.whirldController.skybox.SetTexture("_LeftTex", _0024txt_00245454);
						}
						if (_0024dest_00245456 == 0 || _0024dest_00245456 == 4)
						{
							_0024self__00245457.whirldController.skybox.SetTexture("_RightTex", _0024txt_00245454);
						}
						if (_0024dest_00245456 == 0 || _0024dest_00245456 == 5)
						{
							_0024self__00245457.whirldController.skybox.SetTexture("_UpTex", _0024txt_00245454);
						}
						if (_0024dest_00245456 == 0 || _0024dest_00245456 == 6)
						{
							_0024self__00245457.whirldController.skybox.SetTexture("_DownTex", _0024txt_00245454);
						}
						YieldDefault(1);
					}
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal string _0024url_00245458;

		internal int _0024dest_00245459;

		internal WhirldIn _0024self__00245460;

		public _0024LoadSkyboxTexture_00245451(string url, int dest, WhirldIn self_)
		{
			_0024url_00245458 = url;
			_0024dest_00245459 = dest;
			_0024self__00245460 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024url_00245458, _0024dest_00245459, _0024self__00245460);
		}
	}

	[Serializable]
	internal sealed class _0024LoadSkybox_00245461 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string[] _0024vS_00245462;

			internal string _0024v_00245463;

			internal WhirldIn _0024self__00245464;

			public _0024(string v, WhirldIn self_)
			{
				_0024v_00245463 = v;
				_0024self__00245464 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024vS_00245462 = _0024v_00245463.Split(","[0]);
					if (UnityScript.Lang.Extensions.get_length((System.Array)_0024vS_00245462) > 5)
					{
						if (!_0024self__00245464.whirldController.skybox)
						{
							_0024self__00245464.whirldController.skybox = new Material(Shader.Find("RenderFX/Skybox"));
						}
						_0024self__00245464.StartCoroutine_Auto(_0024self__00245464.LoadSkyboxTexture(_0024vS_00245462[0], 1));
						_0024self__00245464.StartCoroutine_Auto(_0024self__00245464.LoadSkyboxTexture(_0024vS_00245462[1], 2));
						_0024self__00245464.StartCoroutine_Auto(_0024self__00245464.LoadSkyboxTexture(_0024vS_00245462[2], 3));
						_0024self__00245464.StartCoroutine_Auto(_0024self__00245464.LoadSkyboxTexture(_0024vS_00245462[3], 4));
						_0024self__00245464.StartCoroutine_Auto(_0024self__00245464.LoadSkyboxTexture(_0024vS_00245462[4], 5));
						_0024self__00245464.StartCoroutine_Auto(_0024self__00245464.LoadSkyboxTexture(_0024vS_00245462[5], 6));
					}
					else
					{
						if (!(_0024vS_00245462[0].Substring(_0024vS_00245462[0].LastIndexOf(".") + 1) == "jpg"))
						{
							goto case 2;
						}
						if (!_0024self__00245464.whirldController.skybox)
						{
							_0024self__00245464.whirldController.skybox = new Material(Shader.Find("RenderFX/Skybox"));
						}
						_0024self__00245464.StartCoroutine_Auto(_0024self__00245464.LoadSkyboxTexture(_0024vS_00245462[0], 0));
					}
					goto IL_0275;
				case 2:
					if (_0024self__00245464.threads.Count > 0)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024self__00245464.whirldController.skybox = _0024self__00245464.GetAsset(_0024v_00245463) as Material;
					if (!_0024self__00245464.whirldController.skybox)
					{
						_0024self__00245464.info += "Skybox not found: " + _0024v_00245463 + "\n";
					}
					goto IL_0275;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0275:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal string _0024v_00245465;

		internal WhirldIn _0024self__00245466;

		public _0024LoadSkybox_00245461(string v, WhirldIn self_)
		{
			_0024v_00245465 = v;
			_0024self__00245466 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024v_00245465, _0024self__00245466);
		}
	}

	[NonSerialized]
	public static WhirldInStatus status = WhirldInStatus.Idle;

	public string statusTxt;

	[NonSerialized]
	public static float progress;

	private GameObject ccobj;

	private string authobjwname;

	private string authobjwurl;

	public LayerMask pixelLight;

	public LayerMask vertLight;

	public LayerMask minimapLight;

	public Texture gridTexture;

	private Material spaceskybox;

	public Color fogcolor;

	[NonSerialized]
	public static bool hassea;

	[NonSerialized]
	public static PhotonViewID flagId;

	[NonSerialized]
	public static PhotonViewID flag2Id;

	public AuthGameObject authobj;

	public InitWorld initworld;

	public Material seaMaterial;

	public GameObject ctfprefabblue;

	public GameObject ctfprefabred;

	public Texture fresnelA;

	public Texture bumpMap;

	public Texture reflectionColor;

	public Color horizonColor;

	public GameObject whirldFloorPrefab;

	public Material faibridgemat;

	public string info;

	public string url;

	public string data;

	public GameObject world;

	public GameObject whirldBuffer;

	public string worldName;

	public string urlPath;

	public Hashtable threads;

	public int threadAssetBundles;

	public int threadTextures;

	public int maxThreads;

	public UnityScript.Lang.Array loadingAssetBundles;

	public AssetBundle[] loadedAssetBundles;

	// Every bundle any WhirldIn has loaded. The instance list above is lost when the menu destroys a disabled
	// WhirldIn (OnDisable doesn't run then) or a failed load deactivates it, which left the old map's bundle
	// loaded and made the next map fail with "another asset bundle with the same files are already loaded".
	private static System.Collections.Generic.List<AssetBundle> allLoadedBundles = new System.Collections.Generic.List<AssetBundle>();

	public Hashtable objects;

	public Hashtable textures;

	public Hashtable meshMaterials;

	public Hashtable meshMatLibs;

	public Whirld whirldController;

	public GameObject whirldControllerObject;

	public int readChr;

	[NonSerialized]
	public static string[] cacheList;

	[NonSerialized]
	public static int cacheSize;

	[NonSerialized]
	public static string cachePath = string.Empty;

	public Shader[] shaders;

	public GameObject[] tprefabs;

	public UnityScript.Lang.Array shaderarr;

	public WhirldIn()
	{
		statusTxt = string.Empty;
		info = string.Empty;
		url = string.Empty;
		worldName = "World";
		threads = new Hashtable();
		maxThreads = 5;
		loadingAssetBundles = new UnityScript.Lang.Array();
		objects = new Hashtable();
		textures = new Hashtable();
		meshMaterials = new Hashtable();
		meshMatLibs = new Hashtable();
		shaderarr = new UnityScript.Lang.Array();
	}

	public virtual void AssignFromEditorWhenSavingScene()
	{
		shaderarr.Add(Shader.Find("Hidden/Nature/Tree Soft Occlusion Bark Rendertex"), Shader.Find("Hidden/Nature/Tree Soft Occlusion Leaves Rendertex"), Shader.Find("Legacy Shaders/Lightmapped/VertexLit"), Shader.Find("Legacy Shaders/Lightmapped/Diffuse"), Shader.Find("Legacy Shaders/Lightmapped/Specular"), Shader.Find("Legacy Shaders/Lightmapped/Bumped Specular"), Shader.Find("Legacy Shaders/Lightmapped/Bumped Diffuse"), Shader.Find("Legacy Shaders/Diffuse Fast"), Shader.Find("Nature/Tree Soft Occlusion Leaves"), Shader.Find("Nature/Tree Soft Occlusion Bark"));
		shaders = (Shader[])shaderarr.ToBuiltin(typeof(Shader));
	}

	public virtual void OnDisable()
	{
		Cleanup();
	}

	public virtual void OnDestroy()
	{
		Cleanup();
	}

	public virtual void TrackBundle(AssetBundle bundle)
	{
		loadingAssetBundles.Add(bundle);
		if ((bool)bundle && !allLoadedBundles.Contains(bundle))
		{
			allLoadedBundles.Add(bundle);
		}
	}

	public static void UnloadAllBundles()
	{
		for (int i = 0; i < allLoadedBundles.Count; i++)
		{
			if ((bool)allLoadedBundles[i])
			{
				allLoadedBundles[i].Unload(true);
			}
		}
		allLoadedBundles.Clear();
	}

	public virtual void Cleanup()
	{
		if (loadingAssetBundles.length > 0)
		{
			loadedAssetBundles = loadingAssetBundles.ToBuiltin(typeof(AssetBundle)) as AssetBundle[];
			int i = 0;
			AssetBundle[] array = loadedAssetBundles;
			for (int length = array.Length; i < length; i++)
			{
				if ((bool)array[i])
				{
					allLoadedBundles.Remove(array[i]);
					array[i].Unload(true);
				}
			}
			loadingAssetBundles.Clear();
		}
		Resources.UnloadUnusedAssets();
	}

	public virtual void setwname(string s)
	{
		authobjwname = s;
	}

	public virtual void setwurl(string s)
	{
		authobjwurl = s;
	}

	public virtual void Awake()
	{
		spaceskybox = (Material)Resources.Load("Space", typeof(Material));
	}

	public virtual void Start()
	{
		UnityEngine.Object.DontDestroyOnLoad(this);
	}

	public virtual void Update()
	{
		// Only reset while no load tasks are running: a map's streamed scene is loaded additively inside
		// CCWhirldScene, and switching off then ran Cleanup(), unloading the map's texture bundle mid-load
		// ("Terrain splat 0 is null", pink terrain on maps like Freestyle).
		if (Application.isLoadingLevel && Application.loadedLevelName == "CCWhirldScene" && threads.Count == 0)
		{
			hassea = false;
			progress = 0f;
			enabled = false;
		}
	}

	public virtual IEnumerator Load(string u)
	{
		return new _0024Load_00245163(u, this).GetEnumerator();
	}

	public virtual IEnumerator LoadBundle(AssetBundle assetBundle)
	{
		return new _0024LoadBundle_00245171(assetBundle, this).GetEnumerator();
	}

	public virtual IEnumerator LoadOpen(string d)
	{
		return new _0024LoadOpen_00245246(d, this).GetEnumerator();
	}

	public virtual IEnumerator LoadAssetBundle(string p)
	{
		return new _0024LoadAssetBundle_00245334(p, this).GetEnumerator();
	}

	public virtual IEnumerator LoadStreamedScene(string p)
	{
		return new _0024LoadStreamedScene_00245343(p, this).GetEnumerator();
	}

	public virtual IEnumerator LoadTexture(string p)
	{
		return new _0024LoadTexture_00245356(p, this).GetEnumerator();
	}

	public virtual IEnumerator LoadMeshTexture(string url, string materialName)
	{
		return new _0024LoadMeshTexture_00245366(url, materialName, this).GetEnumerator();
	}

	public virtual IEnumerator LoadMesh(string v)
	{
		return new _0024LoadMesh_00245376(v, this).GetEnumerator();
	}

	public virtual IEnumerator LoadTerrain(string v)
	{
		return new _0024LoadTerrain_00245413(v, this).GetEnumerator();
	}

	public virtual IEnumerator LoadSkyboxTexture(string url, int dest)
	{
		return new _0024LoadSkyboxTexture_00245451(url, dest, this).GetEnumerator();
	}

	public virtual IEnumerator LoadSkybox(string v)
	{
		return new _0024LoadSkybox_00245461(v, this).GetEnumerator();
	}

	public virtual UnityEngine.Object GetAsset(string str)
	{
		loadedAssetBundles = loadingAssetBundles.ToBuiltin(typeof(AssetBundle)) as AssetBundle[];
		int num;
		AssetBundle[] array;
		if (UnityScript.Lang.Extensions.get_length((System.Array)loadedAssetBundles) > 0)
		{
			num = 0;
			array = loadedAssetBundles;
			int length = array.Length;
			while (num < length)
			{
				if (!array[num].Contains(str))
				{
					num++;
					continue;
				}
				goto IL_0054;
			}
		}
		object result = null;
		goto IL_006e;
		IL_006e:
		return (UnityEngine.Object)result;
		IL_0054:
		result = array[num].Load(str);
		goto IL_006e;
	}

	public virtual void ReadObject(Transform parent)
	{
		string text = null;
		int num = 0;
		string text2 = string.Empty;
		string text3 = string.Empty;
		UnityScript.Lang.Array array = new UnityScript.Lang.Array();
		GameObject gameObject = null;
		GameObject gameObject2 = default(GameObject);
		WhirldObject whirldObject = default(WhirldObject);
		Light light = default(Light);
		while (true)
		{
			if (readChr >= UnityScript.Lang.Extensions.get_length(data))
			{
				return;
			}
			char c = data[readChr];
			if (!(c == ' ') && !(c == '\n') && !(c == '\t'))
			{
				if (c == ':')
				{
					text2 = text3;
					text3 = string.Empty;
				}
				else if (c == ',')
				{
					array.Add(text3);
					text3 = string.Empty;
				}
				else
				{
					if (c == '{')
					{
						readChr++;
						ReadObject(gameObject.transform);
						continue;
					}
					if (c == ';' || c == '}')
					{
						if (!gameObject)
						{
							if (objects.ContainsKey(text3))
							{
								if (!RuntimeServices.EqualityOperator(objects[text3], null))
								{
									object obj = objects[text3];
									if (!(obj is GameObject))
									{
										obj = RuntimeServices.Coerce(obj, typeof(GameObject));
									}
									gameObject2 = (GameObject)obj;
								}
								else
								{
									Debug.Log("Whirld: Objects[" + text3 + "] is null");
								}
							}
							else
							{
								gameObject2 = (GameObject)Resources.Load("Whirld" + text3);
								if ((bool)gameObject2)
								{
									objects.Add(text3, gameObject2);
								}
							}
							if ((bool)gameObject2)
							{
								gameObject = (GameObject)UnityEngine.Object.Instantiate(gameObject2);
								gameObject.name = text3;
							}
							else
							{
								gameObject = new GameObject(text3);
								objects.Add(text3, gameObject);
							}
							gameObject.transform.parent = parent;
							whirldObject = ((WhirldObject)gameObject.GetComponent(typeof(WhirldObject))) as WhirldObject;
							light = ((Light)gameObject.GetComponent(typeof(Light))) as Light;
						}
						else
						{
							string[] array2 = array.ToBuiltin(typeof(string)) as string[];
							if ((text2 == "p" || (text2 == string.Empty && num == 1)) && array.length == 2)
							{
								gameObject.transform.localPosition = new Vector3(UnityBuiltins.parseFloat(array2[0]), UnityBuiltins.parseFloat(array2[1]), UnityBuiltins.parseFloat(text3));
							}
							else if (text2 == "p" || (text2 == string.Empty && num == 1))
							{
								gameObject.transform.localPosition = Vector3.one * UnityBuiltins.parseFloat(text3);
							}
							else if ((text2 == "r" || (text2 == string.Empty && num == 2)) && array.length == 3)
							{
								gameObject.transform.rotation = new Quaternion(UnityBuiltins.parseFloat(array2[0]), UnityBuiltins.parseFloat(array2[1]), UnityBuiltins.parseFloat(array2[2]), UnityBuiltins.parseFloat(text3));
							}
							else if ((text2 == "r" || (text2 == string.Empty && num == 2)) && array.length == 2)
							{
								gameObject.transform.rotation = Quaternion.Euler(UnityBuiltins.parseFloat(array2[0]), UnityBuiltins.parseFloat(array2[1]), UnityBuiltins.parseFloat(text3));
							}
							else if ((text2 == "r" || (text2 == string.Empty && num == 2)) && array.length == 0)
							{
								gameObject.transform.rotation = Quaternion.identity;
							}
							else if ((text2 == "s" || (text2 == string.Empty && num == 3)) && array.length == 0)
							{
								gameObject.transform.localScale = Vector3.one * UnityBuiltins.parseFloat(text3);
							}
							else if (text2 == "s" || (text2 == string.Empty && num == 3))
							{
								gameObject.transform.localScale = new Vector3(UnityBuiltins.parseFloat(array2[0]), UnityBuiltins.parseFloat(array2[1]), UnityBuiltins.parseFloat(text3));
							}
							else if (!(text2 == "cc"))
							{
								if (text2 == "m")
								{
									info += "Inline Whirld mesh generation not supported\n";
								}
								else if ((bool)light && text2 == "color")
								{
									float r = UnityBuiltins.parseFloat(array2[0]);
									Color color = light.color;
									float num2 = (color.r = r);
									Color color2 = (light.color = color);
									float g = UnityBuiltins.parseFloat(array2[1]);
									Color color4 = light.color;
									float num3 = (color4.g = g);
									Color color5 = (light.color = color4);
									float b = UnityBuiltins.parseFloat(text3);
									Color color7 = light.color;
									float num4 = (color7.b = b);
									Color color8 = (light.color = color7);
								}
								else if ((bool)light && text2 == "intensity")
								{
									light.intensity = UnityBuiltins.parseFloat(text3);
								}
								else if ((bool)whirldObject)
								{
									if (text3.Substring(0, 1) == "#")
									{
										whirldObject.@params.Add(text2, GetAsset(text3.Substring(1)));
									}
									else
									{
										whirldObject.@params.Add(text2, text3);
									}
								}
								else if (text2 != string.Empty)
								{
									Debug.Log(gameObject.name + " Unknown Param: " + text2 + " > " + text3);
								}
							}
						}
						text3 = string.Empty;
						text2 = string.Empty;
						if (array.length > 0)
						{
							array = new UnityScript.Lang.Array();
						}
						num++;
						if (c == '}')
						{
							break;
						}
					}
					else
					{
						text3 += c;
					}
				}
			}
			readChr++;
		}
		readChr++;
		while (readChr < UnityScript.Lang.Extensions.get_length(data) && (data[readChr] == ' ' || data[readChr] == '\n' || data[readChr] == '\t'))
		{
			readChr++;
		}
		if (readChr < UnityScript.Lang.Extensions.get_length(data) && data[readChr] == '{')
		{
			readChr++;
			ReadObject(parent);
		}
	}

	public virtual void TextureObject(GameObject go)
	{
		MeshFilter meshFilter = ((MeshFilter)go.GetComponent(typeof(MeshFilter))) as MeshFilter;
		if (!meshFilter)
		{
			return;
		}
		Mesh sharedMesh = meshFilter.sharedMesh;
		Vector2[] array = new Vector2[sharedMesh.vertices.Length];
		int[] triangles = sharedMesh.triangles;
		for (int i = 0; i < triangles.Length; i += 3)
		{
			Vector3 vector = go.transform.TransformPoint(sharedMesh.vertices[triangles[i]]);
			Vector3 vector2 = go.transform.TransformPoint(sharedMesh.vertices[triangles[i + 1]]);
			Vector3 vector3 = go.transform.TransformPoint(sharedMesh.vertices[triangles[i + 2]]);
			Vector3 normalized = Vector3.Cross(vector - vector3, vector2 - vector3).normalized;
			if (Vector3.Dot(Vector3.up, normalized) >= 0.5f || !(Vector3.Dot(-Vector3.up, normalized) < 0.5f))
			{
				array[triangles[i]] = new Vector2(vector.x, vector.z);
				array[triangles[i + 1]] = new Vector2(vector2.x, vector2.z);
				array[triangles[i + 2]] = new Vector2(vector3.x, vector3.z);
			}
			else if (Vector3.Dot(Vector3.right, normalized) >= 0.5f || !(Vector3.Dot(Vector3.left, normalized) < 0.5f))
			{
				array[triangles[i]] = new Vector2(vector.y, vector.z);
				array[triangles[i + 1]] = new Vector2(vector2.y, vector2.z);
				array[triangles[i + 2]] = new Vector2(vector3.y, vector3.z);
			}
			else
			{
				array[triangles[i]] = new Vector2(vector.y, vector.x);
				array[triangles[i + 1]] = new Vector2(vector2.y, vector2.x);
				array[triangles[i + 2]] = new Vector2(vector3.y, vector3.x);
			}
		}
		sharedMesh.uv = array;
	}

	public virtual string GetURL(string url)
	{
		if (url.Substring(0, 4) != "http")
		{
			url = urlPath + url;
		}
		return url;
	}

	public static string GetCacheURL(string url)
	{
		url = url.Replace("http://", string.Empty);
		string[] array = url.Replace("https://", string.Empty).Split("?"[0]);
		url = cachePath + array[0];
		return url;
	}

	public virtual string CheckLocalURL(string url)
	{
		url = url.Replace("\\", "/");
		return url.StartsWith("file:///") ? url : (url.StartsWith("file://") ? url.Replace("file://", "file:///") : (url.StartsWith("http") ? string.Empty : ("file:///" + url)));
	}

	public virtual string Cache(string url)
	{
		return url;
	}

	public static bool CacheCheck(string url)
	{
		return false;
	}

	public virtual bool CacheStore(string url, byte[] data)
	{
		return false;
	}

	public static bool CacheList()
	{
		return false;
	}

	public static float DirSize(DirectoryInfo d)
	{
		return 0f;
	}

	public static bool CacheClear()
	{
		return false;
	}

	public static bool CacheClear(string url)
	{
		return false;
	}

	public virtual void Main()
	{
	}
}
