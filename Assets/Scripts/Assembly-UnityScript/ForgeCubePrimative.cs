using System;
using UnityEngine;

[Serializable]
public class ForgeCubePrimative : MonoBehaviour
{
	private Vector3 origPos;

	public virtual void Awake()
	{
		origPos = transform.localPosition;
		float x = 0.4f / (transform.parent.parent.transform.localScale.x / 10f);
		Vector3 localScale = transform.localScale;
		float num = (localScale.x = x);
		Vector3 vector = (transform.localScale = localScale);
		float y = 0.4f / (transform.parent.parent.transform.localScale.y / 1f);
		Vector3 localScale2 = transform.localScale;
		float num2 = (localScale2.y = y);
		Vector3 vector3 = (transform.localScale = localScale2);
		float z = 0.4f / (transform.parent.parent.transform.localScale.z / 10f);
		Vector3 localScale3 = transform.localScale;
		float num3 = (localScale3.z = z);
		Vector3 vector5 = (transform.localScale = localScale3);
		float x2 = ((origPos.x <= 0f) ? (origPos.x + (0.4f - transform.localScale.x) / 2f) : (origPos.x - (0.4f - transform.localScale.x) / 2f));
		Vector3 localPosition = transform.localPosition;
		float num4 = (localPosition.x = x2);
		Vector3 vector7 = (transform.localPosition = localPosition);
		if (origPos.y != 0f)
		{
			float y2 = ((origPos.y <= 0f) ? (origPos.y + (0.4f - transform.localScale.y) / 2f) : (origPos.y - (0.4f - transform.localScale.y) / 2f));
			Vector3 localPosition2 = transform.localPosition;
			float num5 = (localPosition2.y = y2);
			Vector3 vector9 = (transform.localPosition = localPosition2);
		}
		float z2 = ((origPos.z <= 0f) ? (origPos.z + (0.4f - transform.localScale.z) / 2f) : (origPos.z - (0.4f - transform.localScale.z) / 2f));
		Vector3 localPosition3 = transform.localPosition;
		float num6 = (localPosition3.z = z2);
		Vector3 vector11 = (transform.localPosition = localPosition3);
	}

	public virtual void Update()
	{
		float x = 0.4f / (transform.parent.parent.transform.localScale.x / 10f);
		Vector3 localScale = transform.localScale;
		float num = (localScale.x = x);
		Vector3 vector = (transform.localScale = localScale);
		float y = 0.4f / (transform.parent.parent.transform.localScale.y / 1f);
		Vector3 localScale2 = transform.localScale;
		float num2 = (localScale2.y = y);
		Vector3 vector3 = (transform.localScale = localScale2);
		float z = 0.4f / (transform.parent.parent.transform.localScale.z / 10f);
		Vector3 localScale3 = transform.localScale;
		float num3 = (localScale3.z = z);
		Vector3 vector5 = (transform.localScale = localScale3);
		float x2 = ((origPos.x <= 0f) ? (origPos.x + (0.4f - transform.localScale.x) / 2f) : (origPos.x - (0.4f - transform.localScale.x) / 2f));
		Vector3 localPosition = transform.localPosition;
		float num4 = (localPosition.x = x2);
		Vector3 vector7 = (transform.localPosition = localPosition);
		if (origPos.y != 0f)
		{
			float y2 = ((origPos.y <= 0f) ? (origPos.y + (0.4f - transform.localScale.y) / 2f) : (origPos.y - (0.4f - transform.localScale.y) / 2f));
			Vector3 localPosition2 = transform.localPosition;
			float num5 = (localPosition2.y = y2);
			Vector3 vector9 = (transform.localPosition = localPosition2);
		}
		float z2 = ((origPos.z <= 0f) ? (origPos.z + (0.4f - transform.localScale.z) / 2f) : (origPos.z - (0.4f - transform.localScale.z) / 2f));
		Vector3 localPosition3 = transform.localPosition;
		float num6 = (localPosition3.z = z2);
		Vector3 vector11 = (transform.localPosition = localPosition3);
	}

	public virtual void Main()
	{
	}
}
