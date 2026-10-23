using System;
using UnityEngine;

[Serializable]
public class MeshLOD : MonoBehaviour
{
	private MeshFilter meshFilter;

	private Mesh regMesh;

	public Mesh simpMesh;

	public int simpDist;

	public float d2C;

	private float checkCounter;

	public MeshLOD()
	{
		simpDist = 105625;
		checkCounter = 3f;
	}

	public virtual void Awake()
	{
		meshFilter = (MeshFilter)gameObject.GetComponent(typeof(MeshFilter));
		regMesh = meshFilter.sharedMesh;
	}

	public virtual void Update()
	{
		if (!(checkCounter <= 0f))
		{
			checkCounter -= Time.deltaTime;
			return;
		}
		checkCounter = UnityEngine.Random.Range(2f, 4f) * ((!renderer.enabled) ? 5f : 1f);
		float sqrMagnitude = (transform.position - Camera.main.transform.position).sqrMagnitude;
		if (!(sqrMagnitude <= (float)simpDist))
		{
			if (meshFilter.sharedMesh != simpMesh)
			{
				meshFilter.sharedMesh = simpMesh;
			}
		}
		else if (meshFilter.sharedMesh != regMesh)
		{
			meshFilter.sharedMesh = regMesh;
		}
	}

	public virtual void Main()
	{
	}
}
