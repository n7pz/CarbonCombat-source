using System;
using System.Collections;
using Boo.Lang.Runtime;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class StoreVehicleManager : MonoBehaviour
{
	public Transform mainObj;

	public GameObject invisObj;

	public GameObject regObj;

	public GameObject[] specialMeshes;

	public Transform[] otherTrans;

	private int showLayer;

	private int hideLayer;

	public StoreVehicleManager()
	{
		showLayer = 9;
		hideLayer = 16;
	}

	public virtual void OnEnable()
	{
		gameObject.layer = showLayer;
		Transform transform = null;
		IEnumerator enumerator = UnityRuntimeServices.GetEnumerator(mainObj);
		while (enumerator.MoveNext())
		{
			object obj = enumerator.Current;
			if (!(obj is Transform))
			{
				obj = RuntimeServices.Coerce(obj, typeof(Transform));
			}
			transform = (Transform)obj;
			transform.gameObject.layer = showLayer;
			UnityRuntimeServices.Update(enumerator, transform);
		}
		for (int i = 0; i < UnityScript.Lang.Extensions.get_length((System.Array)specialMeshes); i++)
		{
			specialMeshes[i].layer = showLayer;
		}
		for (int i = 0; i < UnityScript.Lang.Extensions.get_length((System.Array)otherTrans); i++)
		{
			otherTrans[i].gameObject.layer = hideLayer;
			IEnumerator enumerator2 = otherTrans.GetEnumerator();
			while (enumerator2.MoveNext())
			{
				object obj2 = enumerator2.Current;
				if (!(obj2 is Transform))
				{
					obj2 = RuntimeServices.Coerce(obj2, typeof(Transform));
				}
				transform = (Transform)obj2;
				otherTrans[i].gameObject.layer = hideLayer;
			}
		}
	}

	public virtual void Update()
	{
		if (invisObj.active && (bool)regObj && regObj.gameObject.layer != hideLayer)
		{
			regObj.gameObject.layer = hideLayer;
		}
		else if (!invisObj.active && (bool)regObj && regObj.gameObject.layer != showLayer)
		{
			regObj.gameObject.layer = showLayer;
		}
	}

	public virtual void OnDisable()
	{
		gameObject.layer = hideLayer;
		IEnumerator enumerator = UnityRuntimeServices.GetEnumerator(mainObj);
		while (enumerator.MoveNext())
		{
			object current = enumerator.Current;
			int num = hideLayer;
			object property = UnityRuntimeServices.GetProperty(current, "gameObject");
			RuntimeServices.SetProperty(property, "layer", num);
			UnityRuntimeServices.PropagateValueTypeChanges(new UnityRuntimeServices.ValueTypeChange[1]
			{
				new UnityRuntimeServices.MemberValueTypeChange(current, "gameObject", property)
			});
			UnityRuntimeServices.Update(enumerator, current);
		}
	}

	public virtual void Main()
	{
	}
}
