using System;
using System.Collections;
using Boo.Lang.Runtime;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class WheelLODScript : MonoBehaviour
{
	public GameObject[] tires;

	public Mesh regMesh;

	public Mesh simpMesh;

	public Material[] regMats;

	public Material[] regMatsFast;

	public Material[] simpMats;

	public Material[] simpMatsFast;

	public GameObject regTire;

	public GameObject simpTire;

	private int tireState;

	public CloakPickup cloakscript;

	public Material cloakMaterial;

	public WheelLODScript()
	{
		tireState = 1;
	}

	public virtual void Awake()
	{
		regMats = regTire.renderer.sharedMaterials;
		regMatsFast = regTire.renderer.sharedMaterials;
		simpMats = simpTire.renderer.sharedMaterials;
		simpMatsFast = simpTire.renderer.sharedMaterials;
		Material material = null;
		for (int i = 0; i < UnityScript.Lang.Extensions.get_length((System.Array)regMats); i++)
		{
			Material material2 = new Material(regMats[i].shader);
			material2.CopyPropertiesFromMaterial(regMats[i]);
			regMats[i] = material2;
		}
		for (int i = 0; i < UnityScript.Lang.Extensions.get_length((System.Array)regMatsFast); i++)
		{
			Material material2 = new Material(regMatsFast[i].shader);
			material2.CopyPropertiesFromMaterial(regMatsFast[i]);
			regMatsFast[i] = material2;
		}
		for (int i = 0; i < UnityScript.Lang.Extensions.get_length((System.Array)simpMats); i++)
		{
			Material material2 = new Material(simpMats[i].shader);
			material2.CopyPropertiesFromMaterial(simpMats[i]);
			simpMats[i] = material2;
		}
		for (int i = 0; i < UnityScript.Lang.Extensions.get_length((System.Array)simpMatsFast); i++)
		{
			Material material2 = new Material(simpMatsFast[i].shader);
			material2.CopyPropertiesFromMaterial(simpMatsFast[i]);
			simpMatsFast[i] = material2;
		}
		for (int i = 0; i < UnityScript.Lang.Extensions.get_length((System.Array)regMatsFast); i++)
		{
			if (regMatsFast[i].shader.name == "Reflective/Specular" || regMatsFast[i].shader.name == "Reflective/Diffuse" || regMatsFast[i].shader.name == "FX/Diamond")
			{
				if (regMatsFast[i].HasProperty("_ReflectColor"))
				{
					Color color = Color.Lerp(regMatsFast[i].color, regMatsFast[i].GetColor("_ReflectColor"), 0.85f);
					regMatsFast[i].color = color;
				}
				regMatsFast[i].shader = Shader.Find("VertexLit");
				regMatsFast[i].SetFloat("_Shininess", 0.35f);
			}
		}
		for (int i = 0; i < UnityScript.Lang.Extensions.get_length((System.Array)simpMatsFast); i++)
		{
			if (simpMatsFast[i].shader.name == "Reflective/Specular" || simpMatsFast[i].shader.name == "Reflective/Diffuse" || simpMatsFast[i].shader.name == "FX/Diamond")
			{
				if (simpMatsFast[i].HasProperty("_ReflectColor"))
				{
					Color color = Color.Lerp(simpMatsFast[i].color, simpMatsFast[i].GetColor("_ReflectColor"), 0.85f);
					simpMatsFast[i].color = color;
				}
				simpMatsFast[i].shader = Shader.Find("VertexLit");
				simpMatsFast[i].SetFloat("_Shininess", 0.35f);
			}
		}
	}

	public virtual void LateUpdate()
	{
		GameObject gameObject = null;
		Material[] array = null;
		int num = default(int);
		float sqrMagnitude = (transform.position - Camera.main.transform.position).sqrMagnitude;
		if ((QualitySettings.GetQualityLevel() == 3 || QualitySettings.GetQualityLevel() == 4 || QualitySettings.GetQualityLevel() == 5) && !(sqrMagnitude >= 105625f))
		{
			if (tireState == 0)
			{
				tireState = 1;
				IEnumerator enumerator = tires.GetEnumerator();
				while (enumerator.MoveNext())
				{
					object obj = enumerator.Current;
					if (!(obj is GameObject))
					{
						obj = RuntimeServices.Coerce(obj, typeof(GameObject));
					}
					gameObject = (GameObject)obj;
					((MeshFilter)gameObject.GetComponent(typeof(MeshFilter))).mesh = regMesh;
				}
			}
			if (!cloakscript.returnCloakState())
			{
				if (QualitySettings.GetQualityLevel() == 0)
				{
					IEnumerator enumerator2 = tires.GetEnumerator();
					while (enumerator2.MoveNext())
					{
						object obj2 = enumerator2.Current;
						if (!(obj2 is GameObject))
						{
							obj2 = RuntimeServices.Coerce(obj2, typeof(GameObject));
						}
						gameObject = (GameObject)obj2;
						if (gameObject.renderer.sharedMaterials[0] != regMatsFast[0])
						{
							gameObject.renderer.materials = regMatsFast;
						}
					}
					return;
				}
				IEnumerator enumerator3 = tires.GetEnumerator();
				while (enumerator3.MoveNext())
				{
					object obj3 = enumerator3.Current;
					if (!(obj3 is GameObject))
					{
						obj3 = RuntimeServices.Coerce(obj3, typeof(GameObject));
					}
					gameObject = (GameObject)obj3;
					if (gameObject.renderer.sharedMaterials[0] != regMats[0])
					{
						gameObject.renderer.materials = regMats;
					}
				}
				return;
			}
			IEnumerator enumerator4 = tires.GetEnumerator();
			while (enumerator4.MoveNext())
			{
				object obj4 = enumerator4.Current;
				if (!(obj4 is GameObject))
				{
					obj4 = RuntimeServices.Coerce(obj4, typeof(GameObject));
				}
				gameObject = (GameObject)obj4;
				if (gameObject.renderer.sharedMaterials[0] != cloakMaterial)
				{
					Material[] array2 = new Material[UnityScript.Lang.Extensions.get_length((System.Array)gameObject.renderer.sharedMaterials)];
					for (num = 0; num < UnityScript.Lang.Extensions.get_length((System.Array)gameObject.renderer.sharedMaterials); num++)
					{
						array2[num] = cloakMaterial;
					}
					gameObject.renderer.materials = array2;
				}
			}
			return;
		}
		if (tireState == 1)
		{
			tireState = 0;
			IEnumerator enumerator5 = tires.GetEnumerator();
			while (enumerator5.MoveNext())
			{
				object obj5 = enumerator5.Current;
				if (!(obj5 is GameObject))
				{
					obj5 = RuntimeServices.Coerce(obj5, typeof(GameObject));
				}
				gameObject = (GameObject)obj5;
				((MeshFilter)gameObject.GetComponent(typeof(MeshFilter))).mesh = simpMesh;
			}
		}
		if (!cloakscript.returnCloakState())
		{
			if (QualitySettings.GetQualityLevel() == 0)
			{
				IEnumerator enumerator6 = tires.GetEnumerator();
				while (enumerator6.MoveNext())
				{
					object obj6 = enumerator6.Current;
					if (!(obj6 is GameObject))
					{
						obj6 = RuntimeServices.Coerce(obj6, typeof(GameObject));
					}
					gameObject = (GameObject)obj6;
					if (gameObject.renderer.sharedMaterials[0] != simpMatsFast[0])
					{
						gameObject.renderer.materials = simpMatsFast;
					}
				}
				return;
			}
			IEnumerator enumerator7 = tires.GetEnumerator();
			while (enumerator7.MoveNext())
			{
				object obj7 = enumerator7.Current;
				if (!(obj7 is GameObject))
				{
					obj7 = RuntimeServices.Coerce(obj7, typeof(GameObject));
				}
				gameObject = (GameObject)obj7;
				if (gameObject.renderer.sharedMaterials[0] != simpMats[0])
				{
					gameObject.renderer.materials = simpMats;
				}
			}
			return;
		}
		IEnumerator enumerator8 = tires.GetEnumerator();
		while (enumerator8.MoveNext())
		{
			object obj8 = enumerator8.Current;
			if (!(obj8 is GameObject))
			{
				obj8 = RuntimeServices.Coerce(obj8, typeof(GameObject));
			}
			gameObject = (GameObject)obj8;
			if (gameObject.renderer.sharedMaterials[0] != cloakMaterial)
			{
				Material[] array2 = new Material[UnityScript.Lang.Extensions.get_length((System.Array)gameObject.renderer.sharedMaterials)];
				for (num = 0; num < UnityScript.Lang.Extensions.get_length((System.Array)gameObject.renderer.sharedMaterials); num++)
				{
					array2[num] = cloakMaterial;
				}
				gameObject.renderer.materials = array2;
			}
		}
	}

	public virtual void Main()
	{
	}
}
