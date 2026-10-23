using System;
using Photon;
using UnityEngine;

[Serializable]
public class PlayerLocal : Photon.MonoBehaviour
{
	private Vector3 p;

	private Quaternion r;

	private int m;

	public virtual void Start()
	{
		photonView.observed = this;
	}

	public virtual void OnPhotonSerializeView(PhotonStream stream)
	{
		p = rigidbody.position;
		r = rigidbody.rotation;
		m = 0;
		stream.Serialize(ref p);
		stream.Serialize(ref r);
		stream.Serialize(ref m);
	}
}
