using System.Collections;
using UnityEngine;

[ExecuteInEditMode]
public class HeatmapEmitter : MonoBehaviour
{
	public TextAsset textSet;

	public string URL;

	public string heatmapName;

	public float particleSize = 5f;

	public float zPositionOfHeatMap;

	public char splitValue = ',';

	public GameObject emitterPrefab;

	public bool off;

	public int xColumn;

	public int yColumn = 1;

	public int aColumn = 2;

	public int rColumn = 3;

	public int bColumn = 4;

	public int gColumn = 5;

	private float x;

	private float y;

	private float r;

	private float g;

	private float b;

	private float a;

	private Transform emitterTransform;

	private int count;

	private string dataSet;

	private bool created;

	private GameObject emitterObject;

	private ParticleEmitter emitter;

	private Vector3 emitterPosition;

	private bool starting = true;

	private IEnumerator Start()
	{
		GameObject[] heatMapEmitters = GameObject.FindGameObjectsWithTag("HeatMapEmitter");
		GameObject[] array = heatMapEmitters;
		foreach (GameObject heatMapEmitter in array)
		{
			Object.DestroyImmediate(heatMapEmitter);
		}
		if (textSet != null)
		{
			dataSet = textSet.text;
			starting = true;
		}
		else if (URL != null)
		{
			if (heatmapName != null)
			{
				URL += heatmapName;
			}
			WWW www = new WWW(URL);
			starting = true;
			yield return www;
			dataSet = www.text;
			starting = false;
		}
		else
		{
			Debug.Log("No Data Set");
		}
		if (!off)
		{
			emitMap();
		}
	}

	private void Update()
	{
		if (off)
		{
			GameObject[] array = GameObject.FindGameObjectsWithTag("HeatMapEmitter");
			GameObject[] array2 = array;
			foreach (GameObject gameObject in array2)
			{
				if (gameObject != null)
				{
					Object.DestroyImmediate(gameObject);
				}
			}
			created = false;
			count = 0;
		}
		else if (!created && !starting)
		{
			emitMap();
		}
	}

	public void emitMap()
	{
		emitterObject = Object.Instantiate(emitterPrefab, base.gameObject.transform.position, base.gameObject.transform.rotation) as GameObject;
		emitterPosition = base.gameObject.transform.position;
		emitter = emitterObject.particleEmitter;
		created = true;
		string[] array = dataSet.Split('\n');
		string[] array2 = array;
		foreach (string text in array2)
		{
			if (!string.IsNullOrEmpty(text))
			{
				count++;
				string[] array3 = text.Split(splitValue);
				if (array3[xColumn] != null)
				{
					float.TryParse(array3[xColumn], out x);
				}
				if (array3[yColumn] != null)
				{
					float.TryParse(array3[yColumn], out y);
				}
				if (array3[aColumn] != null)
				{
					float.TryParse(array3[aColumn], out a);
				}
				if (array3[rColumn] != null)
				{
					float.TryParse(array3[rColumn], out r);
				}
				if (array3[bColumn] != null)
				{
					float.TryParse(array3[bColumn], out b);
				}
				if (array3[gColumn] != null)
				{
					float.TryParse(array3[gColumn], out g);
				}
				if (r > 1f)
				{
					r /= 255f;
				}
				if (g > 1f)
				{
					g /= 255f;
				}
				if (b > 1f)
				{
					b /= 255f;
				}
				if (a > 1f)
				{
					a /= 255f;
				}
				if (count % 13000 == 0)
				{
					emitterObject = Object.Instantiate(emitterPrefab, base.gameObject.transform.position, base.gameObject.transform.rotation) as GameObject;
					emitter = emitterObject.particleEmitter;
					emitter.Emit(new Vector3(x, y, zPositionOfHeatMap), emitterPosition, particleSize, 1E+09f, new Vector4(r, g, b, a));
				}
				else
				{
					emitter.Emit(new Vector3(x, y, zPositionOfHeatMap), emitterPosition, particleSize, 1E+09f, new Vector4(r, g, b, a));
				}
			}
		}
	}
}
