using System;
using UnityEngine;

[Serializable]
public class BlobControllerJS : MonoBehaviour
{
	private Projector proj;

	public LayerMask layermask;

	private float checkCounter;

	public int simpDist;

	public BlobControllerJS()
	{
		checkCounter = 3f;
		simpDist = 505625;
	}

	public virtual void Start()
	{
		proj = (Projector)gameObject.GetComponent(typeof(Projector));
	}

	public virtual void LateUpdate()
	{
		RaycastHit raycastHit = default(RaycastHit);
		transform.rotation = Quaternion.LookRotation(-Vector3.up, transform.parent.forward);
		transform.position = transform.parent.position + Vector3.up * 20f;
		if (!(checkCounter <= 0f))
		{
			checkCounter -= Time.deltaTime;
			return;
		}
		checkCounter = UnityEngine.Random.Range(2f, 4f);
		float sqrMagnitude = (transform.position - Camera.main.transform.position).sqrMagnitude;
		if (!(sqrMagnitude <= (float)simpDist))
		{
			if (proj.enabled)
			{
				proj.enabled = false;
			}
		}
		else if (!proj.enabled)
		{
			proj.enabled = true;
		}
	}

	public virtual void Main()
	{
	}
}
