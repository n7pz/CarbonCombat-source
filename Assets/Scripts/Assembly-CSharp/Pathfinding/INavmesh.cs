namespace Pathfinding
{
	public interface INavmesh
	{
		Int3[] vertices { get; set; }

		BBTree bbTree { get; set; }
	}
}
