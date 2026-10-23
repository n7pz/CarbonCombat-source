using System;
using Boo.Lang.Runtime;
using Photon;
using UnityEngine;

[Serializable]
public class SerializeOnlyRotValue : Photon.MonoBehaviour
{
	public string sType;

	public virtual void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		float num = default(float);
		if (stream.isWriting)
		{
			if (sType == "pos y")
			{
				num = Mathf.Round(transform.localPosition.y * 10f) / 10f;
			}
			if (sType == "rot y")
			{
				num = Mathf.Round(transform.localRotation.eulerAngles.y * 10f) / 10f;
			}
			if (sType == "rot x")
			{
				num = Mathf.Round(transform.localRotation.eulerAngles.x * 10f) / 10f;
			}
			stream.SendNext(num);
			return;
		}
		num = RuntimeServices.UnboxSingle(stream.ReceiveNext());
		if (sType == "pos y")
		{
			float y = num;
			Vector3 localPosition = transform.localPosition;
			float num2 = (localPosition.y = y);
			Vector3 vector = (transform.localPosition = localPosition);
		}
		if (sType == "rot y")
		{
			float y2 = num;
			Quaternion localRotation = transform.localRotation;
			Vector3 eulerAngles = localRotation.eulerAngles;
			float num3 = (eulerAngles.y = y2);
			Vector3 vector3 = (localRotation.eulerAngles = eulerAngles);
			Quaternion quaternion = (transform.localRotation = localRotation);
		}
		if (sType == "rot x")
		{
			float x = num;
			Quaternion localRotation2 = transform.localRotation;
			Vector3 eulerAngles2 = localRotation2.eulerAngles;
			float num4 = (eulerAngles2.x = x);
			Vector3 vector5 = (localRotation2.eulerAngles = eulerAngles2);
			Quaternion quaternion3 = (transform.localRotation = localRotation2);
		}
	}
}
