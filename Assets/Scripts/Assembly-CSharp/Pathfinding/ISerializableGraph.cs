namespace Pathfinding
{
	public interface ISerializableGraph : ISerializableObject
	{
		void SerializeNodes(Node[] nodes, AstarSerializer serializer);

		void DeSerializeNodes(Node[] nodes, AstarSerializer serializer);

		Node[] CreateNodes(int num);
	}
}
