using System;
using System.Collections;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
[ExecuteInEditMode]
public class Whirld : MonoBehaviour
{
	[NonSerialized]
	public static Whirld Controller;

	[NonSerialized]
	public static int lodDist;

	[NonSerialized]
	public Transform @base;

	[NonSerialized]
	public GameObject[] bases;

	[NonSerialized]
	public Terrain[] terrains;

	[NonSerialized]
	public GameObject sunLight;

	public Hashtable @params;

	[NonSerialized]
	public GameObject sea;

	public bool whirldSea;

	public Color whirldWaterColorLight;

	public Color whirldWaterColorDark;

	public float whirldWaterWaveSize;

	public Texture2D whirldWaterTexture;

	public float whirldWaterTextureStrength;

	[NonSerialized]
	public GameObject floor;

	public bool whirldFloor;

	public Color whirldFloorTint;

	public Texture2D whirldFloorTexture;

	public float whirldFloorAlt;

	public WhirldWeatherTypes WhirldWeather;

	public string title;

	public string desc;

	public string credits;

	public string welcome;

	public string prefs;

	public Color fogColor;

	public float fogDensity;

	public Color ambientLight;

	public float haloStrength;

	public float flareStrength;

	public Material skybox;

	private Vector3 camPos;

	private Vector3 camUpdatePos;

	private int camUpdateThreshold;

	private float updateTime;

	[NonSerialized]
	public static bool isExporting;

	[NonSerialized]
	public Cubemap whirldCubemap;

	public Whirld()
	{
		bases = new GameObject[1];
		@params = new Hashtable();
		whirldFloorTint = Color.white;
		WhirldWeather = WhirldWeatherTypes.Clear;
		title = "My Whirld";
		desc = string.Empty;
		credits = string.Empty;
		welcome = string.Empty;
		prefs = string.Empty;
		camUpdatePos = Vector3.zero;
		camUpdateThreshold = 500;
	}

	public virtual void OnEnable()
	{
		UpdateWhirld();
	}

	public virtual void OnDisable()
	{
		Cleanup();
	}

	public virtual void Update()
	{
	}

	public virtual void UpdateCubemap()
	{
		whirldCubemap = new Cubemap(128, TextureFormat.RGB24, false);
		GameObject gameObject = new GameObject("CubemapCamera", typeof(Camera));
		gameObject.transform.position = Vector3.up * 150f;
		gameObject.transform.rotation = Quaternion.identity;
		Camera camera = gameObject.camera;
		camera.farClipPlane = 5000f;
		camera.RenderToCubemap(whirldCubemap);
		UnityEngine.Object.DestroyImmediate(gameObject);
	}

	public virtual void Cleanup()
	{
		UnityEngine.Object.DestroyImmediate(sea);
		UnityEngine.Object.DestroyImmediate(floor);
	}

	public virtual void OnSceneGenerated()
	{
		bool flag = false;
		int i = 0;
		Light[] array = (Light[])UnityEngine.Object.FindObjectsOfType(typeof(Light));
		for (int length = array.Length; i < length; i++)
		{
			flag = true;
			if (array[i].type == LightType.Directional)
			{
				sunLight = array[i].gameObject;
			}
		}
		RenderSettings.fog = true;
		RenderSettings.fogColor = fogColor;
		RenderSettings.fogDensity = fogDensity;
		RenderSettings.ambientLight = ambientLight;
		RenderSettings.haloStrength = haloStrength;
		RenderSettings.flareStrength = flareStrength;
		RenderSettings.skybox = skybox;
		terrains = (Terrain[])UnityEngine.Object.FindObjectsOfType(typeof(Terrain));
		UnityScript.Lang.Array array2 = new UnityScript.Lang.Array();
		int j = 0;
		GameObject[] array3 = (GameObject[])UnityEngine.Object.FindObjectsOfType(typeof(GameObject));
		for (int length2 = array3.Length; j < length2; j++)
		{
			if (array3[j].name == "WhirldBase" || array3[j].name == "WhirldBase(Clone)")
			{
				array2.Add(array3[j]);
			}
		}
		if (array2.length < 1)
		{
			int k = 0;
			GameObject[] array4 = (GameObject[])UnityEngine.Object.FindObjectsOfType(typeof(GameObject));
			for (int length3 = array4.Length; k < length3; k++)
			{
				if (array4[k].name == "Base")
				{
					array2.Add(array4[k]);
				}
			}
		}
		if (array2.length < 1)
		{
			array2.Add(UnityEngine.Object.Instantiate(Resources.Load("WhirldBase"), Vector3.up * 5f, Quaternion.identity));
		}
		bases = (GameObject[])array2.ToBuiltin(typeof(GameObject));
		@base = bases[0].transform;
		int l = 0;
		GameObject[] array5 = (GameObject[])UnityEngine.Object.FindObjectsOfType(typeof(GameObject));
		for (int length4 = array5.Length; l < length4; l++)
		{
			if (array5[l] == gameObject)
			{
				continue;
			}
			Renderer renderer = (Renderer)array5[l].GetComponent(typeof(Renderer));
			if ((bool)renderer)
			{
				bool num = renderer.lightmapIndex != 255;
				if (num)
				{
					num = renderer.lightmapIndex != -1;
				}
				renderer.castShadows = num;
			}
			array5[l].SendMessage("OnSceneGenerated", SendMessageOptions.DontRequireReceiver);
		}
	}

	public virtual void UpdateRenderingSettings()
	{
		fogColor = RenderSettings.fogColor;
		fogDensity = RenderSettings.fogDensity;
		ambientLight = RenderSettings.ambientLight;
		haloStrength = RenderSettings.haloStrength;
		flareStrength = RenderSettings.flareStrength;
		skybox = RenderSettings.skybox;
	}

	public virtual void UpdateWhirld()
	{
	}

	[DuckTyped]
	public virtual object mRound(object num, object rnd)
	{
		return RuntimeServices.InvokeBinaryOperator("op_Subtraction", num, RuntimeServices.InvokeBinaryOperator("op_Modulus", num, rnd));
	}

	public virtual bool AddTerrainSeaFloor()
	{
		int result;
		if (!whirldSea || !whirldFloor || !whirldFloorTexture)
		{
			Debug.Log("You need a Sea, a Floor, and a Floor Texture before the seafloor texture can be added.");
			result = 0;
		}
		else
		{
			Terrain activeTerrain = Terrain.activeTerrain;
			TerrainData terrainData = activeTerrain.terrainData;
			float num = 0f;
			float num2 = num + 0f;
			float num3 = num + -1.5f;
			int num4 = -1;
			for (int i = 0; i < UnityScript.Lang.Extensions.get_length((System.Array)terrainData.splatPrototypes); i++)
			{
				if (terrainData.splatPrototypes[i].texture == whirldFloorTexture)
				{
					num4 = i;
					break;
				}
			}
			if (num4 == -1)
			{
				SplatPrototype[] array = new SplatPrototype[UnityScript.Lang.Extensions.get_length((System.Array)terrainData.splatPrototypes) + 1];
				num4 = UnityScript.Lang.Extensions.get_length((System.Array)array) - 1;
				for (int i = 0; i < UnityScript.Lang.Extensions.get_length((System.Array)terrainData.splatPrototypes); i++)
				{
					array[i] = terrainData.splatPrototypes[i];
				}
				array[num4] = new SplatPrototype();
				array[num4].texture = whirldFloorTexture;
			}
			TerrainControllerData terrainControllerData = new TerrainControllerData();
			terrainControllerData.alphaMap = terrainData.GetAlphamaps(0, 0, terrainData.alphamapResolution, terrainData.alphamapResolution);
			terrainControllerData.heightMap = terrainData.GetHeights(0, 0, terrainData.heightmapWidth, terrainData.heightmapHeight);
			float[,,] alphaMap = terrainControllerData.alphaMap;
			for (int j = 0; j < terrainData.alphamapResolution; j++)
			{
				for (int k = 0; k < terrainData.alphamapResolution; k++)
				{
					bool flag = false;
					float num5 = 0f;
					float num6 = activeTerrain.transform.position.y + UnityBuiltins.parseFloat(terrainControllerData.heightMap[(int)(UnityBuiltins.parseFloat((float)k / UnityBuiltins.parseFloat(terrainData.alphamapResolution)) * (float)terrainData.heightmapWidth), (int)(UnityBuiltins.parseFloat((float)j / UnityBuiltins.parseFloat(terrainData.alphamapResolution)) * (float)terrainData.heightmapHeight)] * terrainData.size.y);
					if (!(num6 >= num2))
					{
						flag = true;
						num5 = Mathf.Lerp(0f, 1f, num6 / num3);
					}
					if (flag)
					{
						if (!(num5 >= 1f) && k > 1 && j > 1 && j < terrainData.alphamapResolution - 1 && k < terrainData.alphamapResolution - 1)
						{
							float[] array2 = new float[terrainData.alphamapLayers];
							float num7 = 0f;
							for (int l = 0; l < terrainData.alphamapLayers; l++)
							{
								if (l != num4)
								{
									array2[l] += alphaMap[k - 1, j - 1, l];
									array2[l] += alphaMap[k - 1, j + 1, l];
									array2[l] += alphaMap[k + 1, j - 1, l];
									array2[l] += alphaMap[k + 1, j + 1, l];
									num7 += array2[l];
								}
							}
							for (int l = 0; l < terrainData.alphamapLayers; l++)
							{
								if (l == num4)
								{
									alphaMap[k, j, l] = num5;
								}
								else
								{
									alphaMap[k, j, l] = (1f - num5) * (array2[l] / num7);
								}
							}
						}
						else
						{
							for (int l = 0; l < terrainData.alphamapLayers; l++)
							{
								alphaMap[k, j, l] = ((l == num4) ? 1 : 0);
							}
						}
						continue;
					}
					float num8 = 0f;
					alphaMap[k, j, num4] = 0f;
					for (int l = 0; l < terrainData.alphamapLayers; l++)
					{
						num8 += alphaMap[k, j, l];
					}
					if (!(num8 >= 0.5f))
					{
						for (int l = 0; l < terrainData.alphamapLayers; l++)
						{
							alphaMap[k, j, l] = ((l == 0) ? 1 : 0);
						}
					}
					else
					{
						for (int l = 0; l < terrainData.alphamapLayers; l++)
						{
							alphaMap[k, j, l] = terrainControllerData.alphaMap[k, j, l];
						}
					}
				}
			}
			terrainData.SetAlphamaps(0, 0, alphaMap);
			result = 1;
		}
		return (byte)result != 0;
	}

	public virtual void Main()
	{
	}
}
