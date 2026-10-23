using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public interface IFunnelGraph
{
	void BuildFunnelCorridor(Node[] path, int sIndex, int eIndex, List<Vector3> left, List<Vector3> right);

	void AddPortal(Node n1, Node n2, List<Vector3> left, List<Vector3> right);
}
