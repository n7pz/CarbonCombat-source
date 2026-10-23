using System;
using UnityEngine;

[Serializable]
public class TurretController : MonoBehaviour
{
	public Transform turret;

	public Transform barrel;

	public GameObject laserprefab;

	public Transform laserspawn;

	public GameObject laseraud;

	public Collider col1;

	public Collider col2;

	public Collider col3;

	public Collider col4;

	public virtual void Update()
	{
		if (Input.GetButtonDown("Fire1"))
		{
			GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(laserprefab, laserspawn.position, laserspawn.rotation);
			Physics.IgnoreCollision(gameObject.collider, col1);
			Physics.IgnoreCollision(gameObject.collider, col2);
			Physics.IgnoreCollision(gameObject.collider, col3);
			Physics.IgnoreCollision(gameObject.collider, col4);
			GameObject gameObject2 = (GameObject)UnityEngine.Object.Instantiate(laseraud, laserspawn.position, laserspawn.rotation);
			gameObject2.SendMessage("sticksound", laserspawn.gameObject);
		}
	}

	public virtual void LateUpdate()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hitInfo = default(RaycastHit);
		if (!Physics.Raycast(ray, out hitInfo))
		{
			return;
		}
		turret.LookAt(hitInfo.point);
		int num = 0;
		Quaternion localRotation = turret.localRotation;
		float num2 = (localRotation.x = num);
		Quaternion quaternion = (turret.localRotation = localRotation);
		int num3 = 0;
		Quaternion localRotation2 = turret.localRotation;
		float num4 = (localRotation2.z = num3);
		Quaternion quaternion3 = (turret.localRotation = localRotation2);
		barrel.LookAt(hitInfo.point);
		bool flag = false;
		if (!(barrel.localRotation.eulerAngles.x >= 360f) && !(barrel.localRotation.eulerAngles.x <= 320f))
		{
			flag = true;
		}
		if (!(barrel.localRotation.eulerAngles.x >= 4f) && !(barrel.localRotation.eulerAngles.x <= 0f))
		{
			flag = true;
		}
		if (!flag)
		{
			if (!(barrel.localRotation.eulerAngles.x <= 4f) && !(barrel.localRotation.eulerAngles.x >= 180f))
			{
				int num5 = 4;
				Quaternion localRotation3 = barrel.localRotation;
				Vector3 eulerAngles = localRotation3.eulerAngles;
				float num6 = (eulerAngles.x = num5);
				Vector3 vector = (localRotation3.eulerAngles = eulerAngles);
				Quaternion quaternion5 = (barrel.localRotation = localRotation3);
			}
			if (!(barrel.localRotation.eulerAngles.x <= 180f) && !(barrel.localRotation.eulerAngles.x >= 320f))
			{
				int num7 = 320;
				Quaternion localRotation4 = barrel.localRotation;
				Vector3 eulerAngles2 = localRotation4.eulerAngles;
				float num8 = (eulerAngles2.x = num7);
				Vector3 vector3 = (localRotation4.eulerAngles = eulerAngles2);
				Quaternion quaternion7 = (barrel.localRotation = localRotation4);
			}
		}
		int num9 = 0;
		Quaternion localRotation5 = barrel.localRotation;
		float num10 = (localRotation5.y = num9);
		Quaternion quaternion9 = (barrel.localRotation = localRotation5);
		int num11 = 0;
		Quaternion localRotation6 = barrel.localRotation;
		float num12 = (localRotation6.z = num11);
		Quaternion quaternion11 = (barrel.localRotation = localRotation6);
		Debug.DrawLine(transform.position, hitInfo.point, Color.red);
	}

	public virtual void Main()
	{
	}
}
