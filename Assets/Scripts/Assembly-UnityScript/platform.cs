using System;
using UnityEngine;

[Serializable]
public class platform : MonoBehaviour
{
	public float maxHeight;

	public float minHeight;

	public float speed;

	private bool rising;

	private float velocity;

	public platform()
	{
		maxHeight = 5f;
		minHeight = 1f;
		speed = 2f;
	}

	public virtual void Start()
	{
		rising = true;
	}

	public virtual void Update()
	{
		if (rising)
		{
			float y = Mathf.SmoothDamp(transform.position.y, maxHeight, ref velocity, 1f / speed);
			Vector3 position = transform.position;
			float num = (position.y = y);
			Vector3 vector = (transform.position = position);
			if (!(Mathf.Abs(transform.position.y - maxHeight) >= 0.1f))
			{
				rising = false;
			}
		}
		else
		{
			float y2 = Mathf.SmoothDamp(transform.position.y, minHeight, ref velocity, 1f / speed);
			Vector3 position2 = transform.position;
			float num2 = (position2.y = y2);
			Vector3 vector3 = (transform.position = position2);
			if (!(Mathf.Abs(transform.position.y - minHeight) >= 0.1f))
			{
				rising = true;
			}
		}
	}

	public virtual void Main()
	{
	}
}
