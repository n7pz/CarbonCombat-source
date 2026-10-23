using System;
using UnityEngine;

[Serializable]
public class Shader_0020Movement : MonoBehaviour
{
	public float flowx;

	public float flowy;

	public float offsetx;

	public float offsety;

	public virtual void Update()
	{
		renderer.material.mainTextureOffset = new Vector2(flowx * Time.time + offsetx, flowy * Time.time + offsety);
	}

	public virtual void Main()
	{
	}
}
