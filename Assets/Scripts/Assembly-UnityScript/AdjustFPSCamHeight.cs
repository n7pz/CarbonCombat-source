using System;
using UnityEngine;

[Serializable]
public class AdjustFPSCamHeight : MonoBehaviour
{
	public Transform lookpoint;

	public GunController gc;

	public ChatScript cscript;

	public ToggleGuns togguns;

	public virtual void Update()
	{
		float num = default(float);
		if (ChatScript.primaryweapon == "minigun" && ToggleGuns.curmode == 1)
		{
			num = 0.9205276f;
		}
		if (ChatScript.secondaryweapon == "minigun" && ToggleGuns.curmode == 2)
		{
			num = 0.9205276f;
		}
		transform.LookAt(new Vector3(lookpoint.position.x, lookpoint.position.y + num, lookpoint.position.z));
		if (transform.localRotation.y != 0f)
		{
			int num2 = 0;
			Quaternion localRotation = transform.localRotation;
			float num3 = (localRotation.y = num2);
			Quaternion quaternion = (transform.localRotation = localRotation);
		}
		if (transform.localRotation.z != 0f)
		{
			int num4 = 0;
			Quaternion localRotation2 = transform.localRotation;
			float num5 = (localRotation2.z = num4);
			Quaternion quaternion3 = (transform.localRotation = localRotation2);
		}
	}

	public virtual void Main()
	{
	}
}
