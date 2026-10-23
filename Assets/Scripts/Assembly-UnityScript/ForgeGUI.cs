using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class ForgeGUI : MonoBehaviour
{
	[Serializable]
	internal sealed class _0024createMeshObject_00243855 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal GameObject _0024customObj_00243856;

			internal OBJ _0024obj_00243857;

			internal string _0024murl_00243858;

			internal storeText _0024st_00243859;

			internal ForgeGUI _0024self__00243860;

			public _0024(ForgeGUI self_)
			{
				_0024self__00243860 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024customObj_00243856 = (GameObject)UnityEngine.Object.Instantiate(_0024self__00243860.customMeshObject, _0024self__00243860.meshPos, _0024self__00243860.meshRot);
					_0024obj_00243857 = (OBJ)_0024customObj_00243856.GetComponent("OBJ");
					_0024obj_00243857.objPath = _0024self__00243860.meshUrl;
					_0024murl_00243858 = _0024self__00243860.meshUrl;
					goto case 2;
				case 2:
					if (!(Collider)_0024customObj_00243856.GetComponent(typeof(Collider)))
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024st_00243859 = (storeText)_0024customObj_00243856.AddComponent("storeText");
					_0024st_00243859.text = _0024murl_00243858.Replace("http://", string.Empty);
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal ForgeGUI _0024self__00243861;

		public _0024createMeshObject_00243855(ForgeGUI self_)
		{
			_0024self__00243861 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00243861);
		}
	}

	[Serializable]
	internal sealed class _0024loadDataFunc_00243862 : GenericGenerator<WWW>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WWW>, IEnumerator
		{
			internal string[] _0024chunks_00243863;

			internal WWW _0024www_00243864;

			internal string _0024bluespawn_00243865;

			internal string _0024redspawn_00243866;

			internal int _0024counter_00243867;

			internal string _0024str_00243868;

			internal string _0024pos_00243869;

			internal string _0024rot_00243870;

			internal string _0024scale_00243871;

			internal GameObject _0024obj_00243872;

			internal OBJ _0024loadObj_00243873;

			internal Transform _0024trans_00243874;

			internal IEnumerator _0024_0024iterator_0024278_00243875;

			internal int _0024_0024536_00243876;

			internal string[] _0024_0024537_00243877;

			internal int _0024_0024538_00243878;

			internal Vector3 _0024_00242181_00243879;

			internal Quaternion _0024_00242182_00243880;

			internal Vector3 _0024_00242183_00243881;

			internal Quaternion _0024_00242184_00243882;

			internal string _0024t_00243883;

			internal ForgeGUI _0024self__00243884;

			public _0024(string t, ForgeGUI self_)
			{
				_0024t_00243883 = t;
				_0024self__00243884 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				Vector3 vector;
				Quaternion quaternion;
				Vector3 vector2;
				Quaternion quaternion2;
				Vector3 vector4;
				Quaternion quaternion4;
				Vector3 vector5;
				Quaternion quaternion5;
				switch (_state)
				{
				default:
					_0024chunks_00243863 = null;
					if (_0024t_00243883.Contains("http://"))
					{
						_0024www_00243864 = new WWW(_0024t_00243883);
						result = (Yield(2, _0024www_00243864) ? 1 : 0);
						break;
					}
					_0024chunks_00243863 = _0024t_00243883.Split("$"[0]);
					goto IL_00ae;
				case 2:
					_0024chunks_00243863 = _0024www_00243864.text.Split("$"[0]);
					goto IL_00ae;
				case 3:
					if (!(Collider)_0024obj_00243872.GetComponent(typeof(Collider)))
					{
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					_0024self__00243884.meshCache.Add(_0024chunks_00243863[2].Split(","[0])[_0024counter_00243867], _0024obj_00243872);
					goto IL_1015;
				case 1:
					{
						result = 0;
						break;
					}
					IL_1181:
					if (_0024_0024536_00243876 < _0024_0024538_00243878)
					{
						_0024pos_00243869 = _0024_0024537_00243877[_0024_0024536_00243876].Split("#"[0])[0];
						_0024rot_00243870 = _0024_0024537_00243877[_0024_0024536_00243876].Split("#"[0])[1];
						_0024scale_00243871 = _0024_0024537_00243877[_0024_0024536_00243876].Split("#"[0])[2];
						if (_0024chunks_00243863[2].Split(","[0])[_0024counter_00243867].Contains(".obj"))
						{
							if (!_0024self__00243884.meshCache.ContainsKey(_0024chunks_00243863[2].Split(","[0])[_0024counter_00243867]))
							{
								_0024obj_00243872 = (GameObject)UnityEngine.Object.Instantiate(_0024self__00243884.itemObjects[10], new Vector3(UnityBuiltins.parseFloat(_0024pos_00243869.Split(","[0])[0]), UnityBuiltins.parseFloat(_0024pos_00243869.Split(","[0])[1]), UnityBuiltins.parseFloat(_0024pos_00243869.Split(","[0])[2])), Quaternion.Euler(new Vector3(UnityBuiltins.parseFloat(_0024rot_00243870.Split(","[0])[0]), UnityBuiltins.parseFloat(_0024rot_00243870.Split(","[0])[1]), UnityBuiltins.parseFloat(_0024rot_00243870.Split(","[0])[2]))));
								_0024obj_00243872.transform.localScale = new Vector3(UnityBuiltins.parseFloat(_0024scale_00243871.Split(","[0])[0]), UnityBuiltins.parseFloat(_0024scale_00243871.Split(","[0])[1]), UnityBuiltins.parseFloat(_0024scale_00243871.Split(","[0])[2]));
								_0024loadObj_00243873 = (OBJ)_0024obj_00243872.GetComponent("OBJ");
								_0024loadObj_00243873.objPath = "http://" + _0024chunks_00243863[2].Split(","[0])[_0024counter_00243867];
								goto case 3;
							}
							object obj = _0024self__00243884.meshCache[_0024chunks_00243863[2].Split(","[0])[_0024counter_00243867]];
							if (!(obj is UnityEngine.Object))
							{
								obj = RuntimeServices.Coerce(obj, typeof(UnityEngine.Object));
							}
							object obj2 = UnityEngine.Object.Instantiate((UnityEngine.Object)obj, new Vector3(UnityBuiltins.parseFloat(_0024pos_00243869.Split(","[0])[0]), UnityBuiltins.parseFloat(_0024pos_00243869.Split(","[0])[1]), UnityBuiltins.parseFloat(_0024pos_00243869.Split(","[0])[2])), Quaternion.Euler(new Vector3(UnityBuiltins.parseFloat(_0024rot_00243870.Split(","[0])[0]), UnityBuiltins.parseFloat(_0024rot_00243870.Split(","[0])[1]), UnityBuiltins.parseFloat(_0024rot_00243870.Split(","[0])[2]))));
							if (!(obj2 is GameObject))
							{
								obj2 = RuntimeServices.Coerce(obj2, typeof(GameObject));
							}
							_0024obj_00243872 = (GameObject)obj2;
							_0024obj_00243872.transform.localScale = new Vector3(UnityBuiltins.parseFloat(_0024scale_00243871.Split(","[0])[0]), UnityBuiltins.parseFloat(_0024scale_00243871.Split(","[0])[1]), UnityBuiltins.parseFloat(_0024scale_00243871.Split(","[0])[2]));
						}
						else if (_0024chunks_00243863[2].Split(","[0])[_0024counter_00243867].Contains("T_R"))
						{
							_0024obj_00243872 = (GameObject)UnityEngine.Object.Instantiate(_0024self__00243884.itemObjects[0], new Vector3(UnityBuiltins.parseFloat(_0024pos_00243869.Split(","[0])[0]), UnityBuiltins.parseFloat(_0024pos_00243869.Split(","[0])[1]), UnityBuiltins.parseFloat(_0024pos_00243869.Split(","[0])[2])), Quaternion.Euler(new Vector3(UnityBuiltins.parseFloat(_0024rot_00243870.Split(","[0])[0]), UnityBuiltins.parseFloat(_0024rot_00243870.Split(","[0])[1]), UnityBuiltins.parseFloat(_0024rot_00243870.Split(","[0])[2]))));
							((TerrainDeform)_0024obj_00243872.gameObject.GetComponent(typeof(TerrainDeform))).importData = _0024chunks_00243863[2].Split(","[0])[_0024counter_00243867].Replace("T_R", string.Empty);
							((TerrainDeform)_0024obj_00243872.gameObject.GetComponent(typeof(TerrainDeform))).setMode("import");
						}
						else
						{
							_0024obj_00243872 = (GameObject)UnityEngine.Object.Instantiate(_0024self__00243884.itemObjects[UnityBuiltins.parseInt(_0024chunks_00243863[2].Split(","[0])[_0024counter_00243867].Split("-"[0])[0]) + 1], new Vector3(UnityBuiltins.parseFloat(_0024pos_00243869.Split(","[0])[0]), UnityBuiltins.parseFloat(_0024pos_00243869.Split(","[0])[1]), UnityBuiltins.parseFloat(_0024pos_00243869.Split(","[0])[2])), Quaternion.Euler(new Vector3(UnityBuiltins.parseFloat(_0024rot_00243870.Split(","[0])[0]), UnityBuiltins.parseFloat(_0024rot_00243870.Split(","[0])[1]), UnityBuiltins.parseFloat(_0024rot_00243870.Split(","[0])[2]))));
							_0024obj_00243872.transform.localScale = new Vector3(UnityBuiltins.parseFloat(_0024scale_00243871.Split(","[0])[0]), UnityBuiltins.parseFloat(_0024scale_00243871.Split(","[0])[1]), UnityBuiltins.parseFloat(_0024scale_00243871.Split(","[0])[2]));
						}
						goto IL_1015;
					}
					YieldDefault(1);
					goto case 1;
					IL_00ae:
					_0024self__00243884.wname = WWW.UnEscapeURL(_0024chunks_00243863[0].Split("*"[0])[0]);
					GameObject.Find("/Plane").renderer.material.SetTexture("_MainTex", _0024self__00243884.chairlist[UnityBuiltins.parseInt(_0024chunks_00243863[0].Split("*"[0])[1])]);
					_0024self__00243884.chairvar = UnityBuiltins.parseInt(_0024chunks_00243863[0].Split("*"[0])[1]);
					if (UnityBuiltins.parseInt(_0024chunks_00243863[0].Split("*"[0])[1]) == 0)
					{
						_0024self__00243884.tog1 = true;
						_0024self__00243884.tog2 = false;
						_0024self__00243884.tog3 = false;
					}
					if (UnityBuiltins.parseInt(_0024chunks_00243863[0].Split("*"[0])[1]) == 1)
					{
						_0024self__00243884.tog1 = false;
						_0024self__00243884.tog2 = true;
						_0024self__00243884.tog3 = false;
					}
					if (UnityBuiltins.parseInt(_0024chunks_00243863[0].Split("*"[0])[1]) == 2)
					{
						_0024self__00243884.tog1 = false;
						_0024self__00243884.tog2 = false;
						_0024self__00243884.tog3 = true;
					}
					_0024bluespawn_00243865 = _0024chunks_00243863[0].Split("*"[0])[2];
					_0024redspawn_00243866 = _0024chunks_00243863[0].Split("*"[0])[3];
					GameObject.Find("/BlueSpawn(Clone)").transform.position = new Vector3(UnityBuiltins.parseFloat(_0024bluespawn_00243865.Split("#"[0])[0].Split(","[0])[0]), UnityBuiltins.parseFloat(_0024bluespawn_00243865.Split("#"[0])[0].Split(","[0])[1]), UnityBuiltins.parseFloat(_0024bluespawn_00243865.Split("#"[0])[0].Split(","[0])[2]));
					vector = (_0024_00242181_00243879 = new Vector3(UnityBuiltins.parseFloat(_0024bluespawn_00243865.Split("#"[0])[1].Split(","[0])[0]), UnityBuiltins.parseFloat(_0024bluespawn_00243865.Split("#"[0])[1].Split(","[0])[1]), UnityBuiltins.parseFloat(_0024bluespawn_00243865.Split("#"[0])[1].Split(","[0])[2])));
					quaternion = (_0024_00242182_00243880 = GameObject.Find("/BlueSpawn(Clone)").transform.rotation);
					vector2 = (_0024_00242182_00243880.eulerAngles = _0024_00242181_00243879);
					quaternion2 = (GameObject.Find("/BlueSpawn(Clone)").transform.rotation = _0024_00242182_00243880);
					GameObject.Find("/RedSpawn(Clone)").transform.position = new Vector3(UnityBuiltins.parseFloat(_0024redspawn_00243866.Split("#"[0])[0].Split(","[0])[0]), UnityBuiltins.parseFloat(_0024redspawn_00243866.Split("#"[0])[0].Split(","[0])[1]), UnityBuiltins.parseFloat(_0024redspawn_00243866.Split("#"[0])[0].Split(","[0])[2]));
					vector4 = (_0024_00242183_00243881 = new Vector3(UnityBuiltins.parseFloat(_0024redspawn_00243866.Split("#"[0])[1].Split(","[0])[0]), UnityBuiltins.parseFloat(_0024redspawn_00243866.Split("#"[0])[1].Split(","[0])[1]), UnityBuiltins.parseFloat(_0024redspawn_00243866.Split("#"[0])[1].Split(","[0])[2])));
					quaternion4 = (_0024_00242184_00243882 = GameObject.Find("/RedSpawn(Clone)").transform.rotation);
					vector5 = (_0024_00242184_00243882.eulerAngles = _0024_00242183_00243881);
					quaternion5 = (GameObject.Find("/RedSpawn(Clone)").transform.rotation = _0024_00242184_00243882);
					_0024counter_00243867 = 0;
					_0024_0024536_00243876 = 0;
					_0024_0024537_00243877 = _0024chunks_00243863[1].Split("*"[0]);
					_0024_0024538_00243878 = _0024_0024537_00243877.Length;
					goto IL_1181;
					IL_1015:
					if (_0024obj_00243872.name.Contains("Primative"))
					{
						_0024obj_00243872.SendMessage("setInitColor", (!_0024chunks_00243863[2].Split(","[0])[_0024counter_00243867].Contains("-")) ? 6 : UnityBuiltins.parseInt(_0024chunks_00243863[2].Split(","[0])[_0024counter_00243867].Split("-"[0])[1]));
						_0024obj_00243872.renderer.material.shader = Shader.Find("Diffuse");
						_0024_0024iterator_0024278_00243875 = UnityRuntimeServices.GetEnumerator(_0024obj_00243872.transform);
						while (_0024_0024iterator_0024278_00243875.MoveNext())
						{
							object obj3 = _0024_0024iterator_0024278_00243875.Current;
							if (!(obj3 is Transform))
							{
								obj3 = RuntimeServices.Coerce(obj3, typeof(Transform));
							}
							_0024trans_00243874 = (Transform)obj3;
							_0024trans_00243874.gameObject.SetActiveRecursively(false);
							UnityRuntimeServices.Update(_0024_0024iterator_0024278_00243875, _0024trans_00243874);
						}
					}
					_0024counter_00243867++;
					_0024_0024536_00243876++;
					goto IL_1181;
				}
				return (byte)result != 0;
			}
		}

		internal string _0024t_00243885;

		internal ForgeGUI _0024self__00243886;

		public _0024loadDataFunc_00243862(string t, ForgeGUI self_)
		{
			_0024t_00243885 = t;
			_0024self__00243886 = self_;
		}

		public override IEnumerator<WWW> GetEnumerator()
		{
			return new _0024(_0024t_00243885, _0024self__00243886);
		}
	}

	[Serializable]
	internal sealed class _0024exportWorld_00243887 : GenericGenerator<WWW>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WWW>, IEnumerator
		{
			internal Transform _0024spawnPosRed_00243888;

			internal Transform _0024spawnPosBlue_00243889;

			internal UnityScript.Lang.Array _0024objList_00243890;

			internal string _0024txtGen_00243891;

			internal GameObject _0024obj_00243892;

			internal Transform _0024wobj_00243893;

			internal IEnumerator _0024_0024iterator_0024276_00243894;

			internal Transform _0024wobj_00243895;

			internal ForgeCubePrimColor _0024cNum_00243896;

			internal storeText _0024obj_00243897;

			internal IEnumerator _0024_0024iterator_0024277_00243898;

			internal WWWForm _0024form_00243899;

			internal WWW _0024w_00243900;

			internal IEnumerator _0024_0024iterator_00242990_00243901;

			internal int _0024i_00243902;

			internal ForgeGUI _0024self__00243903;

			public _0024(int i, ForgeGUI self_)
			{
				_0024i_00243902 = i;
				_0024self__00243903 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024spawnPosRed_00243888 = GameObject.Find("/RedSpawn(Clone)").transform;
					_0024spawnPosBlue_00243889 = GameObject.Find("/BlueSpawn(Clone)").transform;
					_0024objList_00243890 = new UnityScript.Lang.Array();
					_0024txtGen_00243891 = string.Empty;
					_0024_0024iterator_00242990_00243901 = ((GameObject[])UnityEngine.Object.FindObjectsOfType(typeof(GameObject))).GetEnumerator();
					while (_0024_0024iterator_00242990_00243901.MoveNext())
					{
						object obj = _0024_0024iterator_00242990_00243901.Current;
						if (!(obj is GameObject))
						{
							obj = RuntimeServices.Coerce(obj, typeof(GameObject));
						}
						_0024obj_00243892 = (GameObject)obj;
						if (_0024obj_00243892.name.Contains("(Clone)") && !_0024obj_00243892.name.Contains("Spawn") && _0024obj_00243892.transform.parent == null)
						{
							_0024objList_00243890.Add(_0024obj_00243892.transform);
						}
					}
					_0024txtGen_00243891 = WWW.EscapeURL(_0024self__00243903.wname) + "*" + _0024self__00243903.chairvar.ToString() + "*" + (Mathf.Round(_0024spawnPosRed_00243888.position.x * 10f) / 10f).ToString() + "," + (Mathf.Round(_0024spawnPosRed_00243888.position.y * 10f) / 10f).ToString() + "," + (Mathf.Round(_0024spawnPosRed_00243888.position.z * 10f) / 10f).ToString() + "#" + (Mathf.Round(_0024spawnPosRed_00243888.rotation.eulerAngles.x * 10f) / 10f).ToString() + "," + (Mathf.Round(_0024spawnPosRed_00243888.rotation.eulerAngles.y * 10f) / 10f).ToString() + "," + (Mathf.Round(_0024spawnPosRed_00243888.rotation.eulerAngles.z * 10f) / 10f).ToString() + "*" + (Mathf.Round(_0024spawnPosBlue_00243889.position.x * 10f) / 10f).ToString() + "," + (Mathf.Round(_0024spawnPosBlue_00243889.position.y * 10f) / 10f).ToString() + "," + (Mathf.Round(_0024spawnPosBlue_00243889.position.z * 10f) / 10f).ToString() + "#" + (Mathf.Round(_0024spawnPosBlue_00243889.rotation.eulerAngles.x * 10f) / 10f).ToString() + "," + (Mathf.Round(_0024spawnPosBlue_00243889.rotation.eulerAngles.y * 10f) / 10f).ToString() + "," + (Mathf.Round(_0024spawnPosBlue_00243889.rotation.eulerAngles.z * 10f) / 10f).ToString() + "$";
					_0024_0024iterator_0024276_00243894 = UnityRuntimeServices.GetEnumerator(_0024objList_00243890);
					while (_0024_0024iterator_0024276_00243894.MoveNext())
					{
						object obj2 = _0024_0024iterator_0024276_00243894.Current;
						if (!(obj2 is Transform))
						{
							obj2 = RuntimeServices.Coerce(obj2, typeof(Transform));
						}
						_0024wobj_00243893 = (Transform)obj2;
						_0024txtGen_00243891 += (Mathf.Round(_0024wobj_00243893.position.x * 10f) / 10f).ToString() + "," + (Mathf.Round(_0024wobj_00243893.position.y * 10f) / 10f).ToString() + "," + (Mathf.Round(_0024wobj_00243893.position.z * 10f) / 10f).ToString() + "#" + (Mathf.Round(_0024wobj_00243893.rotation.eulerAngles.x * 10f) / 10f).ToString() + "," + (Mathf.Round(_0024wobj_00243893.rotation.eulerAngles.y * 10f) / 10f).ToString() + "," + (Mathf.Round(_0024wobj_00243893.rotation.eulerAngles.z * 10f) / 10f).ToString() + "#" + (Mathf.Round(_0024wobj_00243893.localScale.x * 10f) / 10f).ToString() + "," + (Mathf.Round(_0024wobj_00243893.localScale.y * 10f) / 10f).ToString() + "," + (Mathf.Round(_0024wobj_00243893.localScale.z * 10f) / 10f).ToString() + "*";
						UnityRuntimeServices.Update(_0024_0024iterator_0024276_00243894, _0024wobj_00243893);
					}
					_0024txtGen_00243891 = _0024txtGen_00243891.Substring(0, UnityScript.Lang.Extensions.get_length(_0024txtGen_00243891) - 1);
					_0024txtGen_00243891 += "$";
					_0024_0024iterator_0024277_00243898 = UnityRuntimeServices.GetEnumerator(_0024objList_00243890);
					while (_0024_0024iterator_0024277_00243898.MoveNext())
					{
						object obj3 = _0024_0024iterator_0024277_00243898.Current;
						if (!(obj3 is Transform))
						{
							obj3 = RuntimeServices.Coerce(obj3, typeof(Transform));
						}
						_0024wobj_00243895 = (Transform)obj3;
						if (_0024wobj_00243895.gameObject.name == "ForgeCubePrimative(Clone)")
						{
							_0024cNum_00243896 = (ForgeCubePrimColor)_0024wobj_00243895.gameObject.GetComponent(typeof(ForgeCubePrimColor));
							UnityRuntimeServices.Update(_0024_0024iterator_0024277_00243898, _0024wobj_00243895);
							_0024txtGen_00243891 += "0-" + _0024cNum_00243896.curColor + ",";
						}
						if (_0024wobj_00243895.gameObject.name == "Barracade(Clone)")
						{
							_0024txtGen_00243891 += "1,";
						}
						if (_0024wobj_00243895.gameObject.name == "CratePrefab(Clone)")
						{
							_0024txtGen_00243891 += "2,";
						}
						if (_0024wobj_00243895.gameObject.name == "CanisterPrefab(Clone)")
						{
							_0024txtGen_00243891 += "3,";
						}
						if (_0024wobj_00243895.gameObject.name == "ForgeHealthItem(Clone)")
						{
							_0024txtGen_00243891 += "4,";
						}
						if (_0024wobj_00243895.gameObject.name == "ForgeInvisItem(Clone)")
						{
							_0024txtGen_00243891 += "5,";
						}
						if (_0024wobj_00243895.gameObject.name == "ScotsPineTypeB (With Collider)(Clone)")
						{
							_0024txtGen_00243891 += "6,";
						}
						if (_0024wobj_00243895.gameObject.name == "Mimosa (With Collider)(Clone)")
						{
							_0024txtGen_00243891 += "7,";
						}
						if (_0024wobj_00243895.gameObject.name == "Willow (With Collider)(Clone)")
						{
							_0024txtGen_00243891 += "8,";
						}
						if (_0024wobj_00243895.gameObject.name == "CustomMeshPrefab(Clone)")
						{
							_0024obj_00243897 = (storeText)_0024wobj_00243895.GetComponent("storeText");
							UnityRuntimeServices.Update(_0024_0024iterator_0024277_00243898, _0024wobj_00243895);
							_0024txtGen_00243891 += _0024obj_00243897.text + ",";
						}
						if (_0024wobj_00243895.gameObject.name == "ForgeTerrainObject(Clone)")
						{
							_0024txtGen_00243891 += "T_R" + ((TerrainDeform)_0024wobj_00243895.gameObject.GetComponent(typeof(TerrainDeform))).exportTerrain() + ",";
							UnityRuntimeServices.Update(_0024_0024iterator_0024277_00243898, _0024wobj_00243895);
						}
					}
					_0024txtGen_00243891 = _0024txtGen_00243891.Substring(0, UnityScript.Lang.Extensions.get_length(_0024txtGen_00243891) - 1);
					if (_0024i_00243902 == 0)
					{
						_0024form_00243899 = new WWWForm();
						_0024form_00243899.AddField("username", (!(AuthGameObject.username != string.Empty)) ? "NO_NAME" : AuthGameObject.username);
						_0024form_00243899.AddField("data", _0024txtGen_00243891);
						_0024w_00243900 = new WWW("http://72.14.184.180/creator.php", _0024form_00243899);
						result = (Yield(2, _0024w_00243900) ? 1 : 0);
						break;
					}
					_0024self__00243903.exportedText = _0024txtGen_00243891;
					goto IL_0b8c;
				case 2:
					Debug.Log(_0024w_00243900.text);
					if (_0024w_00243900.text.Contains("http://"))
					{
						_0024self__00243903.exportedText = _0024w_00243900.text;
						_0024self__00243903.isError = false;
					}
					else
					{
						_0024self__00243903.isError = true;
					}
					goto IL_0b8c;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0b8c:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal int _0024i_00243904;

		internal ForgeGUI _0024self__00243905;

		public _0024exportWorld_00243887(int i, ForgeGUI self_)
		{
			_0024i_00243904 = i;
			_0024self__00243905 = self_;
		}

		public override IEnumerator<WWW> GetEnumerator()
		{
			return new _0024(_0024i_00243904, _0024self__00243905);
		}
	}

	[Serializable]
	internal sealed class _0024fadeInMesh_00243906 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal ForgeGUI _0024self__00243907;

			public _0024(ForgeGUI self_)
			{
				_0024self__00243907 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					Screen.lockCursor = false;
					_0024self__00243907.meshUrl = string.Empty;
					showMeshWindow = true;
					goto case 2;
				case 2:
					if (_0024self__00243907.alpha2 < 1f)
					{
						_0024self__00243907.alpha2 += 4f * Time.deltaTime;
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024self__00243907.alpha2 = 1f;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal ForgeGUI _0024self__00243908;

		public _0024fadeInMesh_00243906(ForgeGUI self_)
		{
			_0024self__00243908 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00243908);
		}
	}

	[Serializable]
	internal sealed class _0024fadeOutMesh_00243909 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal ForgeGUI _0024self__00243910;

			public _0024(ForgeGUI self_)
			{
				_0024self__00243910 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__00243910.alpha2 > 0f)
					{
						_0024self__00243910.alpha2 -= 4f * Time.deltaTime;
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024self__00243910.alpha2 = 0f;
					Screen.lockCursor = true;
					showMeshWindow = false;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal ForgeGUI _0024self__00243911;

		public _0024fadeOutMesh_00243909(ForgeGUI self_)
		{
			_0024self__00243911 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00243911);
		}
	}

	[Serializable]
	internal sealed class _0024fadeIn_00243912 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal ForgeGUI _0024self__00243913;

			public _0024(ForgeGUI self_)
			{
				_0024self__00243913 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__00243913.alpha < 1f)
					{
						_0024self__00243913.alpha += 4f * Time.deltaTime;
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024self__00243913.alpha = 1f;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal ForgeGUI _0024self__00243914;

		public _0024fadeIn_00243912(ForgeGUI self_)
		{
			_0024self__00243914 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00243914);
		}
	}

	[Serializable]
	internal sealed class _0024fadeOut_00243915 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal SplatPrototype[] _0024sP_00243916;

			internal ForgeGUI _0024self__00243917;

			public _0024(ForgeGUI self_)
			{
				_0024self__00243917 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__00243917.alpha > 0f)
					{
						_0024self__00243917.alpha -= 4f * Time.deltaTime;
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024self__00243917.alpha = 0f;
					GameObject.Find("/Plane").renderer.material.SetTexture("_MainTex", _0024self__00243917.chairlist[_0024self__00243917.chairvar]);
					if ((bool)Terrain.activeTerrain)
					{
						_0024sP_00243916 = Terrain.activeTerrain.terrainData.splatPrototypes;
						_0024sP_00243916[0].texture = (Texture2D)_0024self__00243917.chairlist[_0024self__00243917.chairvar];
						Terrain.activeTerrain.terrainData.splatPrototypes = _0024sP_00243916;
						Terrain.activeTerrain.Flush();
						Terrain.activeTerrain.terrainData.RefreshPrototypes();
					}
					_0024self__00243917.exportedText = string.Empty;
					showMenu = false;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal ForgeGUI _0024self__00243918;

		public _0024fadeOut_00243915(ForgeGUI self_)
		{
			_0024self__00243918 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00243918);
		}
	}

	public GUIStyle textStyle;

	public GUIStyle textStyleShadow;

	public GUIStyle gridSnapStyle;

	public GUIStyle gridSnapStyleShadow;

	public GUIStyle quitStyle;

	public GUIStyle quitStyleShadow;

	public Texture[] icons;

	public string[] items;

	public GameObject[] itemObjects;

	public GUIStyle itemBoxStyle;

	public Color blueColor;

	public ForgeCam fcam;

	public Texture overlayTex;

	[NonSerialized]
	public static bool showMenu;

	private float alpha;

	public GUIStyle menuBox;

	public GUIStyle labelstyle;

	public GUIStyle checkboxstyle;

	public GUIStyle buttonStyle;

	public GUIStyle exportLabel;

	private bool tog1;

	private bool tog2;

	private bool tog3;

	public int chairvar;

	public Texture[] chairlist;

	private string quitMessage;

	private float quitCount;

	private string wname;

	public GUIStyle popupWindowStyle;

	private string exportedText;

	private bool isError;

	private bool loadData;

	private string loadDataText;

	[NonSerialized]
	public static bool showMeshWindow;

	public GUIStyle meshWindow;

	private float alpha2;

	private Vector3 meshPos;

	private Quaternion meshRot;

	private string meshUrl;

	public AuthGameObject authobj;

	public GameObject customMeshObject;

	private Hashtable meshCache;

	public GUISkin scrollstyle;

	public GUIStyle sliderbk;

	public GUIStyle sliderbut;

	[NonSerialized]
	public static float cspeed = 1f;

	public ForgeGUI()
	{
		tog1 = true;
		tog2 = true;
		tog3 = true;
		quitMessage = "Quit Creator";
		quitCount = 5f;
		wname = string.Empty;
		exportedText = string.Empty;
		loadDataText = string.Empty;
		meshUrl = string.Empty;
	}

	public virtual void Awake()
	{
		showMenu = false;
		wname = AuthGameObject.username + "'s Cool Map";
	}

	public virtual IEnumerator createMeshObject()
	{
		return new _0024createMeshObject_00243855(this).GetEnumerator();
	}

	public virtual void OnGUI()
	{
		GUI.skin = scrollstyle;
		GUI.Label(new Rect(0f, Screen.height - 70, 400f, 70f), "WASD & mouse = move around\nAlt/Option = rotate camera\nCmd/Ctrl = pan camera\nRIGHT click to spawn objects; backspace to delete", textStyleShadow);
		GUI.Label(new Rect(0f, Screen.height - 70, 400f, 70f), "WASD & mouse = move around\nAlt/Option = rotate camera\nCmd/Ctrl = pan camera\nRIGHT click to spawn objects; backspace to delete", textStyle);
		GUI.Label(new Rect(0f, 20f, 200f, 25f), "Press [m] to Open Menu", quitStyleShadow);
		GUI.Label(new Rect(0f, 20f, 200f, 25f), "Press [m] to Open Menu", quitStyle);
		GUI.Label(new Rect(20f, Screen.height - 150, 400f, 70f), "Grid Snapping " + ((!ForgeCam.snap) ? "OFF" : "ON") + "\n[g] to toggle", gridSnapStyleShadow);
		GUI.Label(new Rect(20f, Screen.height - 150, 400f, 70f), "Grid Snapping " + ((!ForgeCam.snap) ? "OFF" : "ON") + "\n[g] to toggle", gridSnapStyle);
		GUI.Label(new Rect(Screen.width - 355, Screen.height - 30, 100f, 35f), "Sensitivity", textStyleShadow);
		GUI.Label(new Rect(Screen.width - 355, Screen.height - 30, 100f, 35f), "Sensitivity", textStyle);
		cspeed = GUI.HorizontalSlider(new Rect(Screen.width - 255, Screen.height - 37, 250f, 32f), cspeed, 0.1f, 2.1f, sliderbk, sliderbut);
		int num = ForgeCam.index - 1;
		if (num < 0)
		{
			num = 0;
		}
		for (int i = 0; i < 4; i++)
		{
			if (num < UnityScript.Lang.Extensions.get_length((System.Array)itemObjects))
			{
				if (num == ForgeCam.index)
				{
					GUI.color = blueColor;
				}
				else
				{
					GUI.color = Color.white;
					float a = 0.85f;
					Color color = GUI.color;
					float num2 = (color.a = a);
					Color color2 = (GUI.color = color);
				}
				GUI.BeginGroup(new Rect(15f, 65 * i + 55, 150f, 65f));
				GUI.Box(new Rect(0f, 0f, 150f, 65f), items[num] + ((num == ForgeCam.index || (num + 1 != ForgeCam.index && num - 1 != ForgeCam.index)) ? string.Empty : ("\n(" + ((num + 1 != ForgeCam.index) ? "Press 3" : "Press 1") + ")")), itemBoxStyle);
				GUI.DrawTexture(new Rect(0f, 0f, icons[num].width, icons[num].height), icons[num]);
				GUI.EndGroup();
			}
			num++;
		}
		GUI.color = Color.white;
		float a2 = alpha2;
		Color color4 = GUI.color;
		float num3 = (color4.a = a2);
		Color color5 = (GUI.color = color4);
		if (showMeshWindow)
		{
			GUI.enabled = true;
			GUI.BeginGroup(new Rect(Screen.width / 2 - 137, Screen.height / 2 - 77, 275f, 155f));
			GUI.Box(new Rect(0f, 0f, 275f, 155f), "Custom Mesh Loader", popupWindowStyle);
			GUI.Label(new Rect(0f, 0f, 275f, 200f), "Paste .obj URLs here. For best results, combine all submeshes and include the .mtl file.", exportLabel);
			meshUrl = GUI.TextField(new Rect(20f, 85f, 235f, 20f), meshUrl);
			if (GUI.Button(new Rect(50f, 115f, 100f, 25f), "Cancel", buttonStyle))
			{
				StartCoroutine_Auto(fadeOutMesh());
			}
			if (meshUrl.Contains("http://") && meshUrl.Contains(".obj"))
			{
				GUI.enabled = true;
			}
			else
			{
				GUI.enabled = false;
			}
			if (GUI.Button(new Rect(155f, 115f, 100f, 25f), "Load", buttonStyle))
			{
				StartCoroutine_Auto(fadeOutMesh());
				StartCoroutine_Auto(createMeshObject());
			}
			GUI.EndGroup();
		}
		GUI.enabled = true;
		float a3 = alpha;
		Color color7 = GUI.color;
		float num4 = (color7.a = a3);
		Color color8 = (GUI.color = color7);
		if (!showMenu)
		{
			return;
		}
		if (exportedText != string.Empty || loadData)
		{
			GUI.enabled = false;
		}
		GUI.DrawTexture(new Rect(0f, 0f, Screen.width, Screen.height), overlayTex);
		GUI.BeginGroup(new Rect(Screen.width / 2 - 196, Screen.height / 2 - 130, 393f, 260f));
		GUI.Box(new Rect(0f, 0f, 393f, 260f), "Creator Menu", menuBox);
		GUI.Label(new Rect(20f, 35f, 105f, 35f), "Name Your World", labelstyle);
		wname = GUI.TextField(new Rect(20f, 50f, 353f, 20f), wname, 25);
		wname = wname.Replace("(", string.Empty);
		wname = wname.Replace(")", string.Empty);
		wname = wname.Replace("[", string.Empty);
		wname = wname.Replace("]", string.Empty);
		wname = wname.Replace("*", string.Empty);
		wname = wname.Replace("%", string.Empty);
		wname = wname.Replace("$", string.Empty);
		wname = wname.Replace("#", string.Empty);
		wname = wname.Replace(".", string.Empty);
		wname = wname.Replace("-", string.Empty);
		wname = wname.Replace(",", string.Empty);
		wname = wname.Replace("?", string.Empty);
		wname = wname.Replace("/", string.Empty);
		wname = wname.Replace("{", string.Empty);
		wname = wname.Replace("}", string.Empty);
		wname = wname.Replace("|", string.Empty);
		wname = wname.Replace("_", string.Empty);
		GUI.Label(new Rect(20f, 85f, 105f, 35f), "Ground Texture", labelstyle);
		if (tog1 || exportedText != string.Empty || loadData)
		{
			GUI.enabled = false;
		}
		else
		{
			GUI.enabled = true;
		}
		tog1 = GUI.Toggle(new Rect(110f, 115f, 20f, 20f), tog1, string.Empty, checkboxstyle);
		GUI.enabled = true;
		GUI.DrawTexture(new Rect(70f, 108f, 35f, 35f), chairlist[0]);
		if (tog1)
		{
			tog2 = false;
			tog3 = false;
			chairvar = 0;
		}
		if (tog2 || exportedText != string.Empty || loadData)
		{
			GUI.enabled = false;
		}
		else
		{
			GUI.enabled = true;
		}
		tog2 = GUI.Toggle(new Rect(210f, 115f, 20f, 20f), tog2, string.Empty, checkboxstyle);
		GUI.enabled = true;
		GUI.DrawTexture(new Rect(170f, 108f, 35f, 35f), chairlist[1]);
		if (tog2)
		{
			tog1 = false;
			tog3 = false;
			chairvar = 1;
		}
		if (tog3 || exportedText != string.Empty || loadData)
		{
			GUI.enabled = false;
		}
		else
		{
			GUI.enabled = true;
		}
		tog3 = GUI.Toggle(new Rect(310f, 115f, 20f, 20f), tog3, string.Empty, checkboxstyle);
		GUI.enabled = true;
		GUI.DrawTexture(new Rect(270f, 108f, 35f, 35f), chairlist[2]);
		if (tog3)
		{
			tog1 = false;
			tog2 = false;
			chairvar = 2;
		}
		if (exportedText != string.Empty || loadData)
		{
			GUI.enabled = false;
		}
		GUI.Label(new Rect(20f, 160f, 105f, 35f), "Export/Save Map", labelstyle);
		if (GUI.Button(new Rect(20f, 180f, 173f, 25f), (!isError) ? "To URL (online)" : "Error (upload failed)", buttonStyle))
		{
			if ((bool)GameObject.Find("/AuthGameObject"))
			{
				GameObject.Find("/AuthGameObject").SendMessage("gotAch", "Playing God");
			}
			StartCoroutine_Auto(exportWorld(0));
		}
		if (GUI.Button(new Rect(198f, 180f, 173f, 25f), "To Text (copy 'n paste)", buttonStyle))
		{
			if ((bool)GameObject.Find("/AuthGameObject"))
			{
				GameObject.Find("/AuthGameObject").SendMessage("gotAch", "Playing God");
			}
			StartCoroutine_Auto(exportWorld(1));
		}
		if (GUI.Button(new Rect(20f, 220f, 100f, 25f), quitMessage + ((!quitMessage.Contains("Confirm")) ? string.Empty : (Mathf.Round(quitCount).ToString() + ")")), buttonStyle))
		{
			if (quitMessage.Contains("Confirm"))
			{
				Application.LoadLevel("Menu");
			}
			else
			{
				quitMessage = "Confirm (";
			}
		}
		if (GUI.Button(new Rect(145f, 220f, 100f, 25f), "Load Map", buttonStyle))
		{
			loadData = true;
		}
		if (GUI.Button(new Rect(250f, 220f, 120f, 25f), "Close Window", buttonStyle))
		{
			StartCoroutine_Auto(fadeOut());
			Screen.lockCursor = true;
		}
		GUI.EndGroup();
		if (exportedText != string.Empty)
		{
			GUI.enabled = true;
			GUI.BeginGroup(new Rect(Screen.width / 2 - 137, Screen.height / 2 - 77, 275f, 155f));
			GUI.Box(new Rect(0f, 0f, 275f, 155f), "Exported Content (ctrl + a, ctrl + c)", popupWindowStyle);
			GUI.Label(new Rect(0f, 0f, 275f, 200f), "To play in map, click Start Server in the menu; More Maps; then paste text below into CWF slot.", exportLabel);
			GUI.TextField(new Rect(20f, 85f, 235f, 20f), exportedText);
			if (GUI.Button(new Rect(155f, 115f, 100f, 25f), "Done", buttonStyle))
			{
				exportedText = string.Empty;
			}
			GUI.EndGroup();
		}
		if (loadData)
		{
			GUI.enabled = true;
			GUI.BeginGroup(new Rect(Screen.width / 2 - 137, Screen.height / 2 - 50, 275f, 100f));
			GUI.Box(new Rect(0f, 0f, 275f, 100f), "Paste URL or .cwf data", popupWindowStyle);
			loadDataText = GUI.TextField(new Rect(20f, 35f, 235f, 20f), loadDataText);
			if (GUI.Button(new Rect(155f, 60f, 100f, 25f), "Load", buttonStyle))
			{
				loadData = false;
				StartCoroutine_Auto(loadDataFunc(loadDataText));
				loadDataText = string.Empty;
			}
			GUI.EndGroup();
		}
	}

	public virtual IEnumerator loadDataFunc(string t)
	{
		return new _0024loadDataFunc_00243862(t, this).GetEnumerator();
	}

	public virtual IEnumerator exportWorld(int i)
	{
		return new _0024exportWorld_00243887(i, this).GetEnumerator();
	}

	public virtual void Update()
	{
		if (Input.GetKeyDown("m"))
		{
			if (!showMenu)
			{
				StartCoroutine_Auto(fadeIn());
				showMenu = true;
				if (showMeshWindow)
				{
					StartCoroutine_Auto(fadeOutMesh());
				}
				Screen.lockCursor = false;
			}
			else
			{
				StartCoroutine_Auto(fadeOut());
				Screen.lockCursor = true;
			}
		}
		if (quitMessage.Contains("Confirm"))
		{
			if (!(quitCount <= 0f))
			{
				quitCount -= Time.deltaTime;
				return;
			}
			quitCount = 5f;
			quitMessage = "Quit Creator";
		}
	}

	public virtual void setMeshPos(Vector3 t)
	{
		meshPos = t;
	}

	public virtual void setMeshRot(Quaternion r)
	{
		meshRot = r;
	}

	public virtual IEnumerator fadeInMesh()
	{
		return new _0024fadeInMesh_00243906(this).GetEnumerator();
	}

	public virtual IEnumerator fadeOutMesh()
	{
		return new _0024fadeOutMesh_00243909(this).GetEnumerator();
	}

	public virtual IEnumerator fadeIn()
	{
		return new _0024fadeIn_00243912(this).GetEnumerator();
	}

	public virtual IEnumerator fadeOut()
	{
		return new _0024fadeOut_00243915(this).GetEnumerator();
	}

	public virtual void Main()
	{
		meshCache = new Hashtable();
	}
}
