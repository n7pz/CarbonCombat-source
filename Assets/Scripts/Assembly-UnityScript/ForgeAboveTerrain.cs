using System;
using UnityEngine;

[Serializable]
public class ForgeAboveTerrain : MonoBehaviour
{
	public virtual void LateUpdate()
	{
		if ((bool)Terrain.activeTerrain)
		{
			float num = Terrain.activeTerrain.SampleHeight(transform.position) + Terrain.activeTerrain.transform.position.y;
			if (!(num + 2f <= transform.position.y))
			{
				float y = num + 2f;
				Vector3 position = transform.position;
				float num2 = (position.y = y);
				Vector3 vector = (transform.position = position);
			}
		}
	}

	public virtual void Main()
	{
	}
}
