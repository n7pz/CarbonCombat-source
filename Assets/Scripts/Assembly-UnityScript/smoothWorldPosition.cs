using System;
using UnityEngine;

[Serializable]
public class smoothWorldPosition : MonoBehaviour
{
	public float horizontalSmooth;

	public float verticalUpSmooth;

	public float verticalDownSmooth;

	private Vector3 worldPosition;

	public smoothWorldPosition()
	{
		horizontalSmooth = 3f;
		verticalUpSmooth = 10f;
		verticalDownSmooth = 1f;
	}

	public virtual void LateUpdate()
	{
		horizontalSmooth = Mathf.Max(horizontalSmooth, 0f);
		verticalUpSmooth = Mathf.Max(verticalUpSmooth, 0f);
		verticalDownSmooth = Mathf.Max(verticalDownSmooth, 0f);
		if (horizontalSmooth == 0f)
		{
			worldPosition.x = transform.parent.position.x;
			worldPosition.z = transform.parent.position.z;
		}
		else
		{
			worldPosition.x = Mathf.Lerp(worldPosition.x, transform.parent.position.x, Time.deltaTime * 50f / horizontalSmooth);
			worldPosition.z = Mathf.Lerp(worldPosition.z, transform.parent.position.z, Time.deltaTime * 50f / verticalUpSmooth);
		}
		if (!(worldPosition.y >= transform.parent.position.y))
		{
			if (verticalUpSmooth == 0f)
			{
				worldPosition.y = transform.parent.position.y;
			}
			else
			{
				worldPosition.y = Mathf.Lerp(worldPosition.y, transform.parent.position.y, Time.deltaTime * 50f / verticalUpSmooth);
			}
		}
		else if (verticalDownSmooth == 0f)
		{
			worldPosition.y = transform.parent.position.y;
		}
		else
		{
			worldPosition.y = Mathf.Lerp(worldPosition.y, transform.parent.position.y, Time.deltaTime * 50f / verticalDownSmooth);
		}
		transform.position = worldPosition;
	}

	public virtual void Main()
	{
	}
}
