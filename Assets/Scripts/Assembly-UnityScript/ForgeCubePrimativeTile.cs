using System;
using System.Collections;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class ForgeCubePrimativeTile : MonoBehaviour
{
	private Hashtable ht;

	public ForgeCubePrimativeTile()
	{
		ht = new Hashtable();
	}

	public virtual void Update()
	{
		int i = 0;
		GameObject[] array = GameObject.FindGameObjectsWithTag("AutoTile");
		for (int length = array.Length; i < length; i++)
		{
			if (!array[i].name.Contains("Primative") && !(array[i].transform.root.gameObject.name == "StaticObjectsParent"))
			{
				continue;
			}
			if (ht.ContainsKey(array[i]))
			{
				if (!RuntimeServices.EqualityOperator(array[i].transform.position + array[i].transform.rotation.eulerAngles + array[i].transform.localScale, ht[array[i]]))
				{
					ht[array[i]] = array[i].transform.position + array[i].transform.rotation.eulerAngles + array[i].transform.localScale;
					DoMesh(array[i]);
				}
			}
			else
			{
				ht.Add(array[i], array[i].transform.position + array[i].transform.rotation.eulerAngles + array[i].transform.localScale);
				DoMesh(array[i]);
			}
		}
	}

	public virtual void DoMesh(GameObject go)
	{
		MeshFilter meshFilter = (MeshFilter)go.GetComponent(typeof(MeshFilter));
		if (!meshFilter)
		{
			return;
		}
		Mesh mesh = meshFilter.mesh;
		Vector2[] array = new Vector2[mesh.vertices.Length];
		int[] triangles = mesh.triangles;
		for (int i = 0; i < triangles.Length; i += 3)
		{
			Vector3 vector = go.transform.TransformPoint(mesh.vertices[triangles[i]]);
			Vector3 vector2 = go.transform.TransformPoint(mesh.vertices[triangles[i + 1]]);
			Vector3 vector3 = go.transform.TransformPoint(mesh.vertices[triangles[i + 2]]);
			Vector3 normalized = Vector3.Cross(vector - vector3, vector2 - vector3).normalized;
			if (Vector3.Dot(Vector3.up, normalized) >= 0.5f || !(Vector3.Dot(-Vector3.up, normalized) < 0.5f))
			{
				array[triangles[i]] = new Vector2(vector.x, vector.z);
				array[triangles[i + 1]] = new Vector2(vector2.x, vector2.z);
				array[triangles[i + 2]] = new Vector2(vector3.x, vector3.z);
			}
			else if (Vector3.Dot(Vector3.right, normalized) >= 0.5f || !(Vector3.Dot(Vector3.left, normalized) < 0.5f))
			{
				array[triangles[i]] = new Vector2(vector.y, vector.z);
				array[triangles[i + 1]] = new Vector2(vector2.y, vector2.z);
				array[triangles[i + 2]] = new Vector2(vector3.y, vector3.z);
			}
			else
			{
				array[triangles[i]] = new Vector2(vector.y, vector.x);
				array[triangles[i + 1]] = new Vector2(vector2.y, vector2.x);
				array[triangles[i + 2]] = new Vector2(vector3.y, vector3.x);
			}
		}
		mesh.uv = array;
	}

	public virtual void Main()
	{
	}
}
