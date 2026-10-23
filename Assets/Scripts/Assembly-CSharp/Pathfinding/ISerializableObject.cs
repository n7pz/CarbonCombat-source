namespace Pathfinding
{
	public interface ISerializableObject
	{
		void SerializeSettings(AstarSerializer serializer);

		void DeSerializeSettings(AstarSerializer serializer);
	}
}
