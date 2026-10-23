using System;
using UnityEngine;

[Serializable]
public class FPSObjectManager : MonoBehaviour
{
	public Renderer minimapArrow;

	public Renderer minimapDot;

	public Material blueArrowMat;

	public Material blueDotMat;

	private SpawningScript spawnsrc;

	public virtual void Start()
	{
		if (((PhotonView)transform.root.GetComponent(typeof(PhotonView))).isMine)
		{
			minimapArrow.enabled = true;
		}
		else
		{
			minimapDot.enabled = true;
		}
		if (((GunAndCameraBob)transform.root.gameObject.GetComponent(typeof(GunAndCameraBob))).team == "blue")
		{
			minimapArrow.material = blueArrowMat;
			minimapDot.material = blueDotMat;
		}
	}

	public virtual void Main()
	{
	}
}
