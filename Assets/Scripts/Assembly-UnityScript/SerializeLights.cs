using System;
using Boo.Lang.Runtime;
using Photon;
using UnityEngine;

[Serializable]
public class SerializeLights : Photon.MonoBehaviour
{
	public Light l1;

	public Light l2;

	public virtual void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		bool flag = false;
		if (stream.isWriting)
		{
			flag = l1.enabled;
			stream.SendNext(flag);
		}
		else
		{
			flag = RuntimeServices.UnboxBoolean(stream.ReceiveNext());
			l1.enabled = flag;
			l2.enabled = flag;
		}
	}
}
