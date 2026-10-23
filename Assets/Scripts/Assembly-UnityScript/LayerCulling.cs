using System;
using UnityEngine;

[Serializable]
public class LayerCulling : MonoBehaviour
{
	public virtual void Start()
	{
		float[] array = new float[32];
		array[14] = 750f;
		camera.layerCullDistances = array;
	}

	public virtual void Main()
	{
	}
}
