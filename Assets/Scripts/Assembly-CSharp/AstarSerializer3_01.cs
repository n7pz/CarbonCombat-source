using System.IO;
using Pathfinding;
using UnityEngine;

public class AstarSerializer3_01 : AstarSerializer3_04
{
	public AstarSerializer3_01(AstarPath script)
		: base(script)
	{
	}

	public override void SerializeUserConnections(UserConnection[] userConnections)
	{
		Debug.Log("Loading from 3.0.1");
		BinaryWriter binaryWriter = writerStream;
		AddAnchor("UserConnections");
		if (userConnections != null)
		{
			binaryWriter.Write(userConnections.Length);
			foreach (UserConnection userConnection in userConnections)
			{
				binaryWriter.Write(userConnection.p1.x);
				binaryWriter.Write(userConnection.p1.y);
				binaryWriter.Write(userConnection.p1.z);
				binaryWriter.Write(userConnection.p2.x);
				binaryWriter.Write(userConnection.p2.y);
				binaryWriter.Write(userConnection.p2.z);
				binaryWriter.Write(userConnection.overrideCost);
				binaryWriter.Write(userConnection.oneWay);
				binaryWriter.Write(userConnection.width);
				Debug.Log("End - " + binaryWriter.BaseStream.Position);
			}
		}
		else
		{
			binaryWriter.Write(0);
		}
	}

	public override UserConnection[] DeserializeUserConnections()
	{
		BinaryReader binaryReader = readerStream;
		if (MoveToAnchor("UserConnections"))
		{
			int num = binaryReader.ReadInt32();
			UserConnection[] array = new UserConnection[num];
			for (int i = 0; i < num; i++)
			{
				UserConnection userConnection = new UserConnection();
				userConnection.p1 = new Vector3(binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle());
				userConnection.p2 = new Vector3(binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle());
				userConnection.overrideCost = binaryReader.ReadInt32();
				userConnection.oneWay = binaryReader.ReadBoolean();
				userConnection.width = binaryReader.ReadSingle();
				array[i] = userConnection;
			}
			return array;
		}
		return new UserConnection[0];
	}
}
