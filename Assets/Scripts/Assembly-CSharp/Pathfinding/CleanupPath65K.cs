using UnityEngine;

namespace Pathfinding
{
	public class CleanupPath65K : Path
	{
		public override void Prepare()
		{
			error = true;
			callback = null;
			Debug.Log("+++ Performing 65k Cleanup Operation +++\n+++ Zeroing All Path IDs +++");
			if (AstarPath.active.astarData.graphs == null)
			{
				Debug.LogError("No Graphs Are Created");
				return;
			}
			NavGraph[] graphs = AstarPath.active.astarData.graphs;
			foreach (NavGraph navGraph in graphs)
			{
				if (navGraph.nodes != null)
				{
					for (int j = 0; j < navGraph.nodes.Length; j++)
					{
						navGraph.nodes[j].pathID = 0;
					}
				}
			}
		}

		public override void Initialize()
		{
			error = true;
		}

		public override float CalculateStep(float t)
		{
			error = true;
			return 1000f;
		}
	}
}
