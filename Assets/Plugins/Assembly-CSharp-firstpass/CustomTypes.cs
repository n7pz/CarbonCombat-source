using System;
using System.IO;
using ExitGames.Client.Photon;
using UnityEngine;

public static class CustomTypes
{
	public static void Register()
	{
		PhotonPeer.RegisterType(typeof(Vector2), 87, SerializeVector2, DeserializeVector2);
		PhotonPeer.RegisterType(typeof(Vector3), 86, SerializeVector3, DeserializeVector3);
		PhotonPeer.RegisterType(typeof(Transform), 84, SerializeTransform, DeserializeTransform);
		PhotonPeer.RegisterType(typeof(Quaternion), 81, SerializeQuaternion, DeserializeQuaternion);
		PhotonPeer.RegisterType(typeof(PhotonPlayer), 80, SerializePhotonPlayer, DeserializePhotonPlayer);
		PhotonPeer.RegisterType(typeof(PhotonViewID), 73, SerializePhotonViewID, DeserializePhotonViewID);
	}

	private static byte[] SerializeTransform(object customobject)
	{
		Transform transform = (Transform)customobject;
		return Protocol.Serialize(new Vector3[2] { transform.position, transform.eulerAngles });
	}

	private static object DeserializeTransform(byte[] serializedcustomobject)
	{
		return Protocol.Deserialize(serializedcustomobject);
	}

	private static byte[] SerializeVector3(object customobject)
	{
		Vector3 vector = (Vector3)customobject;
		MemoryStream memoryStream = new MemoryStream(12);
		memoryStream.Write(BitConverter.GetBytes(vector.x), 0, 4);
		memoryStream.Write(BitConverter.GetBytes(vector.y), 0, 4);
		memoryStream.Write(BitConverter.GetBytes(vector.z), 0, 4);
		return memoryStream.ToArray();
	}

	private static object DeserializeVector3(byte[] bytes)
	{
		return new Vector3
		{
			x = BitConverter.ToSingle(bytes, 0),
			y = BitConverter.ToSingle(bytes, 4),
			z = BitConverter.ToSingle(bytes, 8)
		};
	}

	private static byte[] SerializeVector2(object customobject)
	{
		Vector2 vector = (Vector2)customobject;
		MemoryStream memoryStream = new MemoryStream(8);
		memoryStream.Write(BitConverter.GetBytes(vector.x), 0, 4);
		memoryStream.Write(BitConverter.GetBytes(vector.y), 0, 4);
		return memoryStream.ToArray();
	}

	private static object DeserializeVector2(byte[] bytes)
	{
		return new Vector2
		{
			x = BitConverter.ToSingle(bytes, 0),
			y = BitConverter.ToSingle(bytes, 4)
		};
	}

	public static byte[] SerializeQuaternion(object obj)
	{
		Quaternion quaternion = (Quaternion)obj;
		MemoryStream memoryStream = new MemoryStream(12);
		memoryStream.Write(BitConverter.GetBytes(quaternion.w), 0, 4);
		memoryStream.Write(BitConverter.GetBytes(quaternion.x), 0, 4);
		memoryStream.Write(BitConverter.GetBytes(quaternion.y), 0, 4);
		memoryStream.Write(BitConverter.GetBytes(quaternion.z), 0, 4);
		return memoryStream.ToArray();
	}

	public static object DeserializeQuaternion(byte[] bytes)
	{
		return new Quaternion
		{
			w = BitConverter.ToSingle(bytes, 0),
			x = BitConverter.ToSingle(bytes, 4),
			y = BitConverter.ToSingle(bytes, 8),
			z = BitConverter.ToSingle(bytes, 12)
		};
	}

	private static byte[] SerializePhotonPlayer(object customobject)
	{
		int iD = ((PhotonPlayer)customobject).ID;
		return BitConverter.GetBytes(iD);
	}

	private static object DeserializePhotonPlayer(byte[] bytes)
	{
		int key = BitConverter.ToInt32(bytes, 0);
		if (PhotonNetwork.networkingPeer.mActors.ContainsKey(key))
		{
			return PhotonNetwork.networkingPeer.mActors[key];
		}
		return null;
	}

	private static byte[] SerializePhotonViewID(object customobject)
	{
		int iD = ((PhotonViewID)customobject).ID;
		return BitConverter.GetBytes(iD);
	}

	private static object DeserializePhotonViewID(byte[] bytes)
	{
		int num = BitConverter.ToInt32(bytes, 0);
		int iD = num % PhotonNetwork.MAX_VIEW_IDS;
		int num2 = num / PhotonNetwork.MAX_VIEW_IDS;
		PhotonPlayer owner = null;
		if (num2 > 0)
		{
			owner = PhotonPlayer.Find(num2);
		}
		return new PhotonViewID(iD, owner);
	}
}
