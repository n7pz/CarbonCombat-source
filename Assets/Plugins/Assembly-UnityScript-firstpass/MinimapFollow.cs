using System;
using UnityEngine;

[Serializable]
public class MinimapFollow : MonoBehaviour
{
	public Transform target;

	public Transform minimap;

	public bool spawn;

	public MinimapFollow()
	{
		spawn = true;
	}

	public virtual void Start()
	{
		target = Camera.main.transform;
	}

	public virtual void SetTarget(Transform t)
	{
	}

	public virtual void LateUpdate()
	{
		if ((bool)target)
		{
			transform.position = target.position;
			float y = target.position.y + 2500f;
			Vector3 position = transform.position;
			float num = (position.y = y);
			Vector3 vector = (transform.position = position);
			transform.LookAt(target);
			float y2 = target.rotation.eulerAngles.y;
			Quaternion rotation = transform.rotation;
			Vector3 eulerAngles = rotation.eulerAngles;
			float num2 = (eulerAngles.y = y2);
			Vector3 vector3 = (rotation.eulerAngles = eulerAngles);
			Quaternion quaternion = (transform.rotation = rotation);
		}
	}

	public virtual void Main()
	{
	}
}
