using System;
using Boo.Lang.Runtime;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class DamageDisplay : MonoBehaviour
{
	[NonSerialized]
	public static UnityScript.Lang.Array uiArr = new UnityScript.Lang.Array();

	public GUIStyle textStyle;

	public GUIStyle textShadowStyle;

	private Vector2 lSize;

	private float displayLength;

	private float offsetMult;

	public DamageDisplay()
	{
		lSize = new Vector2(100f, 40f);
		displayLength = 2f;
		offsetMult = 115f;
	}

	public virtual void addDamage(int amnt, Vector3 pos)
	{
		DamageObject value = new DamageObject(amnt.ToString(), pos, displayLength, 1f, new Vector2(UnityEngine.Random.Range(-25, 25), UnityEngine.Random.Range(-25, 25)));
		uiArr.Add(value);
	}

	public virtual void Update()
	{
		for (int i = 0; i < uiArr.length; i++)
		{
			if (RuntimeServices.ToBool(RuntimeServices.InvokeBinaryOperator("op_GreaterThan", UnityRuntimeServices.GetProperty(uiArr[i], "displayTime"), 0.5f)))
			{
				RuntimeServices.SetProperty(uiArr[i], "displayTime", Mathf.Max(0f, RuntimeServices.UnboxSingle(RuntimeServices.InvokeBinaryOperator("op_Subtraction", UnityRuntimeServices.GetProperty(uiArr[i], "displayTime"), Time.deltaTime))));
				continue;
			}
			RuntimeServices.SetProperty(uiArr[i], "displayTime", Mathf.Max(0f, RuntimeServices.UnboxSingle(RuntimeServices.InvokeBinaryOperator("op_Subtraction", UnityRuntimeServices.GetProperty(uiArr[i], "displayTime"), Time.deltaTime))));
			if (RuntimeServices.ToBool(RuntimeServices.InvokeBinaryOperator("op_GreaterThan", UnityRuntimeServices.GetProperty(uiArr[i], "alpha"), 0)))
			{
				RuntimeServices.SetProperty(uiArr[i], "alpha", RuntimeServices.InvokeBinaryOperator("op_Subtraction", UnityRuntimeServices.GetProperty(uiArr[i], "alpha"), Time.deltaTime * 2.5f));
			}
			else
			{
				uiArr.RemoveAt(i);
			}
		}
	}

	public virtual void OnGUI()
	{
		DamageObject damageObject = null;
		for (int i = 0; i < uiArr.length; i++)
		{
			object obj = uiArr[i];
			if (!(obj is DamageObject))
			{
				obj = RuntimeServices.Coerce(obj, typeof(DamageObject));
			}
			damageObject = (DamageObject)obj;
			Vector3 vector = Camera.main.WorldToScreenPoint(damageObject.pos);
			if (!(vector.z <= 0f))
			{
				vector.y = (float)Screen.height - vector.y;
				Rect position = new Rect(vector.x - lSize.x / 2f + damageObject.pOffset.x, vector.y - lSize.y / 2f - (1f - damageObject.displayTime / displayLength) * offsetMult + damageObject.pOffset.y, lSize.x, lSize.y);
				float alpha = damageObject.alpha;
				Color color = GUI.color;
				float num = (color.a = alpha);
				Color color2 = (GUI.color = color);
				GUI.Label(position, damageObject.amount, textShadowStyle);
				GUI.Label(position, damageObject.amount, textStyle);
			}
		}
	}

	public virtual void Main()
	{
	}
}
