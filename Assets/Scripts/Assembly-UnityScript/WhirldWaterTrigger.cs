using System;
using UnityEngine;

[Serializable]
public class WhirldWaterTrigger : MonoBehaviour
{
	[NonSerialized]
	public static bool isUnderwater;

	[NonSerialized]
	public static bool isUnderwaterCam;

	public AuthGameObject authobj;

	public virtual void Awake()
	{
		isUnderwater = false;
		isUnderwaterCam = false;
		if (gameObject.name == "Cube" && AuthGameObject.whirldname == "Eric's CTF")
		{
			UnityEngine.Object.Destroy(this);
		}
	}

	public virtual void OnTriggerEnter(Collider obj)
	{
		if (renderer.enabled)
		{
			if (obj.gameObject.name == "CarPrefab(Clone)" && ((PhotonView)obj.GetComponent(typeof(PhotonView))).isMine)
			{
				isUnderwater = true;
				PlayerCar_Script playerCar_Script = (PlayerCar_Script)obj.GetComponent("PlayerCar_Script");
				playerCar_Script.isUnderwater = isUnderwater;
			}
			if (obj.gameObject == Camera.main.gameObject)
			{
				isUnderwaterCam = true;
				WaterFogCam waterFogCam = (WaterFogCam)Camera.main.GetComponent("WaterFogCam");
				waterFogCam.isUnderwater = isUnderwaterCam;
			}
		}
	}

	public virtual void OnTriggerExit(Collider obj)
	{
		if (renderer.enabled)
		{
			if (obj.gameObject.name == "CarPrefab(Clone)" && ((PhotonView)obj.GetComponent(typeof(PhotonView))).isMine)
			{
				isUnderwater = false;
				PlayerCar_Script playerCar_Script = (PlayerCar_Script)obj.GetComponent("PlayerCar_Script");
				playerCar_Script.isUnderwater = isUnderwater;
			}
			if (obj.gameObject == Camera.main.gameObject)
			{
				isUnderwaterCam = false;
				WaterFogCam waterFogCam = (WaterFogCam)Camera.main.GetComponent("WaterFogCam");
				waterFogCam.isUnderwater = isUnderwaterCam;
			}
		}
	}

	public virtual void Main()
	{
	}
}
