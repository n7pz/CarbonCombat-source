using System.IO;
using Pathfinding;
using UnityEngine;

public class AstarSerializer3_04 : AstarSerializer
{
	public AstarSerializer3_04(AstarPath script)
		: base(script)
	{
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
				userConnection.type = (ConnectionType)binaryReader.ReadInt32();
				array[i] = userConnection;
			}
			return array;
		}
		return new UserConnection[0];
	}
}
