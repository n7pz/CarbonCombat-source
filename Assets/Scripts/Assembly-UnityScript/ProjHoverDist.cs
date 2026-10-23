using System;
using UnityEngine;

[Serializable]
public class ProjHoverDist : MonoBehaviour
{
	public virtual void LateUpdate()
	{
		if ((bool)Terrain.activeTerrain)
		{
			float num = Terrain.activeTerrain.SampleHeight(transform.position) + Terrain.activeTerrain.transform.position.y;
			float y = num + 20f;
			Vector3 position = transform.position;
			float num2 = (position.y = y);
			Vector3 vector = (transform.position = position);
		}
	}

	public virtual void Main()
	{
	}
}
