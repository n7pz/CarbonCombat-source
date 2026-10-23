using System;
using Pathfinding;
using UnityEngine;

[Serializable]
public class AlternativePath : MonoModifier
{
	public int penalty = 1000;

	public int randomStep = 10;

	private Node[] prevNodes;

	private int prevSeed;

	private int prevPenalty;

	private bool waitingForApply;

	private object lockObject = new object();

	private Node[] toBeApplied;

	public override ModifierData input
	{
		get
		{
			return ModifierData.Original;
		}
	}

	public override ModifierData output
	{
		get
		{
			return ModifierData.All;
		}
	}

	public override void Apply(Path p, ModifierData source)
	{
		lock (lockObject)
		{
			toBeApplied = p.path;
			if (!waitingForApply)
			{
				waitingForApply = true;
				AstarPath.OnPathPreSearch = (OnPathDelegate)Delegate.Combine(AstarPath.OnPathPreSearch, new OnPathDelegate(ApplyNow));
			}
		}
	}

	private void ApplyNow(Path somePath)
	{
		lock (lockObject)
		{
			waitingForApply = false;
			AstarPath.OnPathPreSearch = (OnPathDelegate)Delegate.Remove(AstarPath.OnPathPreSearch, new OnPathDelegate(ApplyNow));
			int num = prevSeed;
			UnityEngine.Random.seed = prevSeed;
			if (prevNodes != null)
			{
				int num2 = UnityEngine.Random.Range(0, randomStep);
				for (int i = num2; i < prevNodes.Length; i += UnityEngine.Random.Range(1, randomStep))
				{
					prevNodes[i].penalty -= prevPenalty;
				}
			}
			num = (UnityEngine.Random.seed = UnityEngine.Random.Range(0, 10000));
			if (toBeApplied != null)
			{
				int num4 = UnityEngine.Random.Range(0, randomStep);
				for (int j = num4; j < toBeApplied.Length; j += UnityEngine.Random.Range(1, randomStep))
				{
					toBeApplied[j].penalty += penalty;
				}
			}
			prevPenalty = penalty;
			prevSeed = num;
			prevNodes = toBeApplied;
		}
	}
}
