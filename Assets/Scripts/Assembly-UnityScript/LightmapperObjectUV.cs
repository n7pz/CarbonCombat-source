using System;
using UnityEngine;

[Serializable]
[ExecuteInEditMode]
public class LightmapperObjectUV : MonoBehaviour
{
	public float fudgeScale;

	public Transform theObject;

	public Vector3 terrainSize;

	public LightmapperObjectUV()
	{
		fudgeScale = 1f;
		terrainSize = new Vector3(1450f, 1450f, -1450f);
	}

	public virtual void Start()
	{
		if (!theObject)
		{
			theObject = transform;
		}
	}

	public virtual void OnRenderObject()
	{
		Vector3 vector = new Vector3(1f / terrainSize.x, 1f / terrainSize.y, 1f / terrainSize.z);
		Matrix4x4 mat = Matrix4x4.TRS(Vector3.Scale(new Vector3(theObject.position.x, theObject.position.z, theObject.position.y), vector), Quaternion.Euler(90f, 0f, 0f) * Quaternion.Inverse(theObject.rotation), vector * fudgeScale);
		Shader.SetGlobalMatrix("_LightmapMatrix", mat);
	}

	public virtual void Main()
	{
	}
}
