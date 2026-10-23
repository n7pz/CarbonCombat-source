using System;
using UnityEngine;

[Serializable]
public class ChangeMinimapteTexture : MonoBehaviour
{
	public Texture tex;

	public virtual void Start()
	{
		renderer.material.mainTexture = tex;
	}

	public virtual void Main()
	{
	}
}
