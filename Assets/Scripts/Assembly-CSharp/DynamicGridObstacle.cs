using System;
using System.Collections;
using Pathfinding;
using UnityEngine;

public class DynamicGridObstacle : MonoBehaviour
{
	private Collider col;

	public float updateError = 1f;

	public float checkTime = 0.2f;

	public bool simple;

	private Bounds prevBounds;

	private bool isWaitingForUpdate;

	private void Start()
	{
		col = base.collider;
		if (base.collider == null)
		{
			Debug.LogError("A collider must be attached to the GameObject for DynamicGridObstacle to work");
		}
		StartCoroutine(UpdateGraphs());
	}

	private IEnumerator UpdateGraphs()
	{
		if (col == null || AstarPath.active == null)
		{
			Debug.LogWarning("No collider is attached to the GameObject. Canceling check");
			yield break;
		}
		while (true)
		{
			if (isWaitingForUpdate)
			{
				yield return new WaitForSeconds(checkTime);
				continue;
			}
			Bounds newBounds = col.bounds;
			Bounds merged = newBounds;
			merged.Encapsulate(prevBounds);
			Vector3 minDiff = merged.min - newBounds.min;
			Vector3 maxDiff = merged.max - newBounds.max;
			if (Mathf.Abs(minDiff.x) > updateError || Mathf.Abs(minDiff.y) > updateError || Mathf.Abs(minDiff.z) > updateError || Mathf.Abs(maxDiff.x) > updateError || Mathf.Abs(maxDiff.y) > updateError || Mathf.Abs(maxDiff.z) > updateError)
			{
				isWaitingForUpdate = true;
				AstarPath.active.RegisterCanUpdateGraphs(DoUpdateGraphs, DoUpdateGraphs2);
			}
			yield return new WaitForSeconds(checkTime);
		}
	}

	public void DoUpdateGraphs()
	{
		isWaitingForUpdate = false;
		Bounds bounds = col.bounds;
		if (!simple)
		{
			Bounds bounds2 = bounds;
			bounds2.Encapsulate(prevBounds);
			if (BoundsVolume(bounds2) < BoundsVolume(bounds) + BoundsVolume(prevBounds))
			{
				AstarPath.active.UpdateGraphs(bounds2);
			}
			else
			{
				AstarPath.active.UpdateGraphs(prevBounds);
				AstarPath.active.UpdateGraphs(bounds);
			}
		}
		else
		{
			GraphUpdateObject graphUpdateObject = new GraphUpdateObject(prevBounds);
			graphUpdateObject.updatePhysics = false;
			graphUpdateObject.modifyWalkability = true;
			graphUpdateObject.setWalkability = true;
			AstarPath.active.UpdateGraphs(graphUpdateObject);
		}
		Debug.DrawLine(prevBounds.min, prevBounds.max, Color.yellow);
		Debug.DrawLine(bounds.min, bounds.max, Color.red);
		prevBounds = bounds;
	}

	public void DoUpdateGraphs2()
	{
		if (simple)
		{
			GraphUpdateObject graphUpdateObject = new GraphUpdateObject(col.bounds);
			graphUpdateObject.updatePhysics = false;
			graphUpdateObject.modifyWalkability = true;
			graphUpdateObject.setWalkability = false;
			AstarPath.active.UpdateGraphs(graphUpdateObject);
		}
	}

	public float BoundsVolume(Bounds b)
	{
		return Math.Abs(b.size.x * b.size.y * b.size.z);
	}
}
