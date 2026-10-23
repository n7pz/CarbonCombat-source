using System.Collections;
using Pathfinding;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Seeker))]
public class AIFollow : MonoBehaviour
{
	public Transform target;

	public float repathRate = 0.1f;

	public float pickNextWaypointDistance = 1f;

	public float speed = 5f;

	public float rotationSpeed = 1f;

	protected Seeker seeker;

	protected CharacterController controller;

	protected NavmeshController navmeshController;

	protected Transform tr;

	protected float lastPathSearch = -9999f;

	protected int pathIndex;

	protected Vector3[] path;

	public void Start()
	{
		seeker = GetComponent<Seeker>();
		controller = GetComponent<CharacterController>();
		navmeshController = GetComponent<NavmeshController>();
		tr = base.transform;
		Repath();
	}

	public void OnPathComplete(Path p)
	{
		StartCoroutine(WaitToRepath());
		if (p.error)
		{
			return;
		}
		path = p.vectorPath;
		float num = float.PositiveInfinity;
		int num2 = 0;
		for (int i = 0; i < path.Length - 1; i++)
		{
			float num3 = Mathfx.DistancePointSegmentStrict(path[i], path[i + 1], tr.position);
			if (num3 < num)
			{
				num2 = 0;
				num = num3;
				pathIndex = i + 1;
			}
			else if (num2 > 6)
			{
				break;
			}
		}
	}

	public IEnumerator WaitToRepath()
	{
		float timeLeft = repathRate - (Time.time - lastPathSearch);
		yield return new WaitForSeconds(timeLeft);
		Repath();
	}

	public void Stop()
	{
		pathIndex = -1;
	}

	public virtual void Repath()
	{
		lastPathSearch = Time.time;
		if (seeker == null || target == null)
		{
			StartCoroutine(WaitToRepath());
		}
		else
		{
			seeker.StartPath(base.transform.position, target.position, OnPathComplete);
		}
	}

	public void PathToTarget(Vector3 targetPoint)
	{
		lastPathSearch = Time.time;
		if (!(seeker == null))
		{
			seeker.StartPath(base.transform.position, targetPoint, OnPathComplete);
		}
	}

	public virtual void ReachedEndOfPath()
	{
	}

	public void Update()
	{
		if (path == null || pathIndex >= path.Length || pathIndex < 0)
		{
			return;
		}
		Vector3 vector = path[pathIndex];
		vector.y = tr.position.y;
		while ((vector - tr.position).sqrMagnitude < pickNextWaypointDistance * pickNextWaypointDistance)
		{
			pathIndex++;
			if (pathIndex >= path.Length)
			{
				if ((double)(vector - tr.position).sqrMagnitude < (double)pickNextWaypointDistance * 0.2 * ((double)pickNextWaypointDistance * 0.2))
				{
					ReachedEndOfPath();
					return;
				}
				pathIndex--;
				break;
			}
			vector = path[pathIndex];
			vector.y = tr.position.y;
		}
		Vector3 vector2 = vector - tr.position;
		tr.rotation = Quaternion.Slerp(tr.rotation, Quaternion.LookRotation(vector2), rotationSpeed * Time.deltaTime);
		tr.eulerAngles = new Vector3(0f, tr.eulerAngles.y, 0f);
		Vector3 forward = base.transform.forward;
		forward *= speed;
		forward *= Mathf.Clamp01(Vector3.Dot(vector2, tr.forward));
		if (navmeshController != null)
		{
			navmeshController.SimpleMove(tr.position, forward);
		}
		else
		{
			controller.SimpleMove(forward);
		}
	}
}
