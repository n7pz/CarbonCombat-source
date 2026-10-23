namespace Pathfinding
{
	public interface ISerializableGraphEditor
	{
		void SerializeSettings(NavGraph target, AstarSerializer serializer);

		void DeSerializeSettings(NavGraph target, AstarSerializer serializer);
	}
}
