using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class TerrainDeform : MonoBehaviour
{
	[Serializable]
	internal sealed class _0024textureTerrain_00245764 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal Terrain _0024terr_00245765;

			internal TerrainData _0024tData_00245766;

			internal Vector3 _0024normSize_00245767;

			internal Vector3 _0024normCoor_00245768;

			internal Vector3 _0024normTerrainCoor_00245769;

			internal float[,,] _0024alphas_00245770;

			internal int _0024yC_00245771;

			internal int _0024i_00245772;

			internal int _0024j_00245773;

			internal Vector3 _0024normPos_00245774;

			internal float _0024s_00245775;

			internal float _0024e_00245776;

			internal Vector3 _0024startPos_00245777;

			internal float _0024sizeX_00245778;

			internal float _0024sizeZ_00245779;

			internal TerrainDeform _0024self__00245780;

			public _0024(Vector3 startPos, float sizeX, float sizeZ, TerrainDeform self_)
			{
				_0024startPos_00245777 = startPos;
				_0024sizeX_00245778 = sizeX;
				_0024sizeZ_00245779 = sizeZ;
				_0024self__00245780 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024terr_00245765 = (Terrain)_0024self__00245780.terrainObject.GetComponent(typeof(Terrain));
					_0024tData_00245766 = _0024terr_00245765.terrainData;
					_0024startPos_00245777 = new Vector3(Mathf.Clamp(_0024startPos_00245777.x, _0024terr_00245765.transform.position.x, _0024terr_00245765.transform.position.x + _0024tData_00245766.size.x - _0024sizeX_00245778), 0f, Mathf.Clamp(_0024startPos_00245777.z, _0024terr_00245765.transform.position.z, _0024terr_00245765.transform.position.z + _0024tData_00245766.size.z - _0024sizeZ_00245779));
					_0024normSize_00245767 = new Vector3((float)_0024tData_00245766.alphamapWidth / _0024tData_00245766.size.x, 0f, (float)_0024tData_00245766.alphamapHeight / _0024tData_00245766.size.z);
					_0024normCoor_00245768 = _0024self__00245780.GetRelativeTerrainPositionFromPos(_0024startPos_00245777, _0024terr_00245765, _0024tData_00245766.alphamapWidth, _0024tData_00245766.alphamapHeight);
					_0024normTerrainCoor_00245769 = _0024self__00245780.GetNormalizedPositionRelativeToTerrain(_0024startPos_00245777 - new Vector3(1000f, 0f, 1000f), _0024terr_00245765);
					_0024alphas_00245770 = _0024terr_00245765.terrainData.GetAlphamaps((int)_0024normCoor_00245768.x, (int)_0024normCoor_00245768.z, (int)(_0024normSize_00245767.x * _0024sizeX_00245778), (int)(_0024normSize_00245767.z * _0024sizeZ_00245779));
					_0024yC_00245771 = 0;
					_0024i_00245772 = 0;
					goto IL_039e;
				case 2:
					_0024j_00245773++;
					goto IL_036f;
				case 1:
					{
						result = 0;
						break;
					}
					IL_039e:
					if ((float)_0024i_00245772 < _0024normSize_00245767.z * _0024sizeZ_00245779 - 1f)
					{
						_0024j_00245773 = 0;
						goto IL_036f;
					}
					_0024terr_00245765.terrainData.SetAlphamaps((int)_0024normCoor_00245768.x, (int)_0024normCoor_00245768.z, _0024alphas_00245770);
					_0024terr_00245765.Flush();
					YieldDefault(1);
					goto case 1;
					IL_036f:
					if ((float)_0024j_00245773 < _0024normSize_00245767.x * _0024sizeX_00245778 - 1f)
					{
						_0024normPos_00245774 = _0024self__00245780.GetNormalizedPositionRelativeToTerrain(new Vector3((float)_0024j_00245773 / _0024normSize_00245767.x, 0f, (float)_0024i_00245772 / _0024normSize_00245767.z), _0024terr_00245765) + _0024normTerrainCoor_00245769;
						_0024s_00245775 = _0024tData_00245766.GetSteepness(_0024normPos_00245774.x, _0024normPos_00245774.z);
						_0024e_00245776 = _0024self__00245780.textureCurve.Evaluate(_0024s_00245775);
						_0024alphas_00245770[_0024i_00245772, _0024j_00245773, 0] = Mathf.Clamp(1f - _0024e_00245776, 0f, 1f);
						_0024alphas_00245770[_0024i_00245772, _0024j_00245773, 1] = Mathf.Clamp(_0024e_00245776, 0f, 1f);
						_0024yC_00245771++;
						if (Application.loadedLevelName == "Forge_Scene" && _0024yC_00245771 % 15 == 0)
						{
							result = (YieldDefault(2) ? 1 : 0);
							break;
						}
						goto case 2;
					}
					_0024i_00245772++;
					goto IL_039e;
				}
				return (byte)result != 0;
			}
		}

		internal Vector3 _0024startPos_00245781;

		internal float _0024sizeX_00245782;

		internal float _0024sizeZ_00245783;

		internal TerrainDeform _0024self__00245784;

		public _0024textureTerrain_00245764(Vector3 startPos, float sizeX, float sizeZ, TerrainDeform self_)
		{
			_0024startPos_00245781 = startPos;
			_0024sizeX_00245782 = sizeX;
			_0024sizeZ_00245783 = sizeZ;
			_0024self__00245784 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024startPos_00245781, _0024sizeX_00245782, _0024sizeZ_00245783, _0024self__00245784);
		}
	}

	public Mode mode;

	public string importData;

	public TerrainData initTerrainAsset;

	public GameObject terrainObject;

	private TerrainData tData;

	private ForgeGUI fgui;

	private ForgeCam fcam;

	[NonSerialized]
	public static bool deforming;

	private GameObject brushProj;

	private Projector projectorObject;

	private float[,] ht;

	public AnimationCurve textureCurve;

	public AnimationCurve sandCurve;

	public TerrainDeform()
	{
		importData = string.Empty;
	}

	public virtual void Awake()
	{
		deforming = false;
		brushProj = GameObject.Find("/TerrainBrush");
		if ((bool)brushProj)
		{
			projectorObject = (Projector)brushProj.GetComponent(typeof(Projector));
		}
	}

	public virtual GameObject setMode(string smode)
	{
		object result;
		switch (smode)
		{
		case "export":
			mode = Mode.Export;
			exportTerrain();
			goto default;
		case "import":
			mode = Mode.Import;
			importTerrain(importData);
			StartCoroutine_Auto(textureTerrain(terrainObject.transform.position, tData.size.x, tData.size.z));
			goto default;
		case "create":
			mode = Mode.Create;
			terrainObject = Terrain.CreateTerrainGameObject(initTerrainAsset);
			tData = ((Terrain)terrainObject.GetComponent(typeof(Terrain))).terrainData;
			terrainObject.transform.position = terrainObject.transform.position - new Vector3(tData.size.x / 2f, 0f, tData.size.z / 2f);
			terrainObject.layer = 15;
			flattenTerrain();
			StartCoroutine_Auto(textureTerrain(terrainObject.transform.position, tData.size.x, tData.size.z));
			result = terrainObject;
			break;
		default:
			result = null;
			break;
		}
		return (GameObject)result;
	}

	public virtual void flattenTerrain()
	{
		int heightmapWidth = tData.heightmapWidth;
		int heightmapHeight = tData.heightmapHeight;
		float[,] heights = tData.GetHeights(0, 0, heightmapWidth, heightmapHeight);
		for (int i = 0; i < heightmapWidth; i++)
		{
			for (int j = 0; j < heightmapHeight; j++)
			{
				heights[i, j] = 0f;
			}
		}
		tData.SetHeights(0, 0, heights);
		ht = heights;
		SplatPrototype[] splatPrototypes = tData.splatPrototypes;
		ForgeGUI forgeGUI = (ForgeGUI)Camera.main.gameObject.GetComponent(typeof(ForgeGUI));
		splatPrototypes[0].texture = (Texture2D)forgeGUI.chairlist[forgeGUI.chairvar];
		tData.splatPrototypes = splatPrototypes;
		((Terrain)terrainObject.GetComponent(typeof(Terrain))).Flush();
		tData.RefreshPrototypes();
	}

	public virtual void Update()
	{
		deforming = false;
		if (mode != Mode.Create)
		{
			return;
		}
		Terrain terrain = (Terrain)terrainObject.GetComponent(typeof(Terrain));
		if (Input.GetButtonUp("Fire1"))
		{
			StartCoroutine_Auto(textureTerrain(terrainObject.transform.position, terrain.terrainData.size.x, terrain.terrainData.size.z));
		}
		RaycastHit hitInfo = default(RaycastHit);
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		float num = ForgeCam.brushSize;
		Vector3 vector = new Vector3(num * (terrain.terrainData.size.x / (float)terrain.terrainData.heightmapWidth), 0f, num * (terrain.terrainData.size.z / (float)terrain.terrainData.heightmapHeight) * 1.5f);
		float num2 = 0.01f;
		if (Physics.Raycast(Camera.main.transform.position, ray.direction, out hitInfo, float.PositiveInfinity) && ForgeCam.index == 0)
		{
			if (!projectorObject.enabled)
			{
				projectorObject.enabled = true;
			}
			brushProj.transform.position = new Vector3(hitInfo.point.x, 700f, hitInfo.point.z);
			if (projectorObject.orthographicSize != 50f * num / 5f)
			{
				projectorObject.orthographicSize = 50f * num / 5f;
			}
			if (!Input.GetButton("Fire1") || ForgeCam.isDragging || ForgeCam.isUsingGizmo || ForgeGUI.showMenu || !(hitInfo.transform.gameObject == terrainObject))
			{
				return;
			}
			deforming = true;
			Vector3 vector2 = hitInfo.point - terrain.gameObject.transform.position;
			Vector3 vector3 = default(Vector3);
			int heightmapWidth = tData.heightmapWidth;
			int heightmapHeight = tData.heightmapHeight;
			vector3.x = vector2.x / terrain.terrainData.size.x;
			vector3.y = vector2.y / terrain.terrainData.size.y;
			vector3.z = vector2.z / terrain.terrainData.size.z;
			int num3 = UnityBuiltins.parseInt(vector3.x * (float)heightmapWidth);
			int num4 = UnityBuiltins.parseInt(vector3.z * (float)heightmapHeight);
			int num5 = (int)(num / 2f);
			float[,] heights = terrain.terrainData.GetHeights((int)Mathf.Clamp(num3 - num5, 1f, (float)heightmapWidth - num - 2f), (int)Mathf.Clamp(num4 - num5, 1f, (float)heightmapHeight - num - 2f), (int)num, (int)num);
			for (int i = 0; (float)i < num; i++)
			{
				for (int j = 0; (float)j < num; j++)
				{
					float num6 = ((float)j - num / 2f) / (float)(heightmapWidth / heightmapWidth);
					float num7 = ((float)i - num / 2f) / (float)(heightmapHeight / heightmapHeight);
					float num8 = Mathf.Abs(Mathf.Sqrt(num6 * num6 + num7 * num7));
					if (!(num8 >= num / 2f))
					{
						float value = (num / 2f - ((num8 >= num / 3f) ? num8 : 0f)) / (num / 2f);
						value = Mathf.Clamp(value, 0f, 1f);
						heights[i, j] = Mathf.Clamp(heights[i, j] + num2 * value * (float)((!Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.RightShift)) ? 1 : (-1)), 0f, 1f);
					}
				}
			}
			terrain.terrainData.SetHeights((int)Mathf.Clamp(num3 - num5, 1f, (float)heightmapWidth - num - 2f), (int)Mathf.Clamp(num4 - num5, 1f, (float)heightmapHeight - num - 2f), heights);
			Vector3 startPos = new Vector3(hitInfo.point.x - vector.x / 2f, 0f, hitInfo.point.z - vector.z / 2f);
			StartCoroutine_Auto(textureTerrain(startPos, vector.x * 2f, vector.z * 2f));
		}
		else if (projectorObject.enabled)
		{
			projectorObject.enabled = false;
		}
	}

	public virtual void importTerrain(string data)
	{
		terrainObject = Terrain.CreateTerrainGameObject(initTerrainAsset);
		float y = 100.5f;
		Vector3 position = terrainObject.transform.position;
		float num = (position.y = y);
		Vector3 vector = (terrainObject.transform.position = position);
		tData = ((Terrain)terrainObject.GetComponent(typeof(Terrain))).terrainData;
		terrainObject.transform.position = terrainObject.transform.position - new Vector3(tData.size.x / 2f, 0f, tData.size.z / 2f);
		int heightmapWidth = tData.heightmapWidth;
		int heightmapHeight = tData.heightmapHeight;
		float[,] heights = tData.GetHeights(0, 0, heightmapWidth, heightmapHeight);
		string[] array = data.Split("@"[0]);
		UnityScript.Lang.Array array2 = new UnityScript.Lang.Array();
		for (int i = 0; i < UnityScript.Lang.Extensions.get_length((System.Array)array); i++)
		{
			if (array[i].Contains("z"))
			{
				int num2 = UnityBuiltins.parseInt(array[i].Replace("z", string.Empty));
				for (int j = 0; j < num2; j++)
				{
					array2.Add("0");
				}
			}
			else if (array[i].Contains("."))
			{
				array2.Add("1.0");
			}
			else
			{
				array2.Add("0." + array[i]);
			}
		}
		array = (string[])array2.ToBuiltin(typeof(string));
		int num3 = 0;
		for (int k = 0; k < heightmapWidth; k++)
		{
			for (int l = 0; l < heightmapHeight; l++)
			{
				heights[k, l] = UnityBuiltins.parseFloat(array[num3]);
				num3++;
			}
		}
		tData.SetHeights(0, 0, heights);
		SplatPrototype[] splatPrototypes = tData.splatPrototypes;
		splatPrototypes[0].texture = (Texture2D)GameObject.Find("/Plane").renderer.material.GetTexture("_MainTex");
		tData.splatPrototypes = splatPrototypes;
		((Terrain)terrainObject.GetComponent(typeof(Terrain))).Flush();
		tData.RefreshPrototypes();
		if (Application.loadedLevelName == "Forge_Scene")
		{
			enabled = false;
		}
		else
		{
			mode = Mode.Create;
		}
	}

	public virtual string exportTerrain()
	{
		int heightmapWidth = tData.heightmapWidth;
		int heightmapHeight = tData.heightmapHeight;
		float[,] heights = tData.GetHeights(0, 0, heightmapWidth, heightmapHeight);
		string text = string.Empty;
		int num = 0;
		for (int i = 0; i < heightmapWidth; i++)
		{
			for (int j = 0; j < heightmapHeight; j++)
			{
				if (heights[i, j] != 0f)
				{
					if (num > 0)
					{
						text += ((!(text == string.Empty)) ? "@" : string.Empty) + "z" + num.ToString();
						num = 0;
					}
					float num2 = Mathf.Round(heights[i, j] * 10000f) / 10000f;
					text += ((!(text == string.Empty)) ? "@" : string.Empty) + ((num2 == 1f) ? "1." : num2.ToString().Replace("0.", string.Empty));
				}
				else
				{
					num++;
				}
			}
		}
		if (num > 0)
		{
			text += ((!(text == string.Empty)) ? "@" : string.Empty) + "z" + num.ToString();
			num = 0;
		}
		return text;
	}

	public virtual Vector3 GetNormalizedPositionRelativeToTerrain(Vector3 pos, Terrain terrain)
	{
		Terrain terrain2 = (Terrain)terrainObject.GetComponent(typeof(Terrain));
		Vector3 vector = pos - terrain.gameObject.transform.position;
		return new Vector3
		{
			x = vector.x / terrain2.terrainData.size.x,
			y = vector.y / terrain2.terrainData.size.y,
			z = vector.z / terrain2.terrainData.size.z
		};
	}

	public virtual Vector3 GetRelativeTerrainPositionFromPos(Vector3 pos, Terrain terrain, int mapWidth, int mapHeight)
	{
		Vector3 normalizedPositionRelativeToTerrain = GetNormalizedPositionRelativeToTerrain(pos, terrain);
		return new Vector3(normalizedPositionRelativeToTerrain.x * (float)mapWidth, 0f, normalizedPositionRelativeToTerrain.z * (float)mapHeight);
	}

	public virtual IEnumerator textureTerrain(Vector3 startPos, float sizeX, float sizeZ)
	{
		return new _0024textureTerrain_00245764(startPos, sizeX, sizeZ, this).GetEnumerator();
	}

	public virtual void Main()
	{
	}
}
