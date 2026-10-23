using System;
using Boo.Lang.Runtime;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class laserSight : MonoBehaviour
{
	public GameObject laserLinePrefab;

	public bool on;

	public bool disableRootCollider;

	private Transform laserPoint;

	private Transform laserPointOrigin;

	private float laserLineRate;

	private float nextLaserLineTime;

	private float positionBuffer;

	public laserSight()
	{
		disableRootCollider = true;
		laserLineRate = 2f;
		positionBuffer = 2f;
	}

	public virtual void Start()
	{
		on = true;
		laserPoint = transform.Find("laserPoint");
		laserPointOrigin = transform.Find("laserPointOrigin");
	}

	public virtual void Update()
	{
		RaycastHit hitInfo = default(RaycastHit);
		float num = 20f;
		if (disableRootCollider)
		{
			transform.root.collider.enabled = false;
		}
		if (Physics.Raycast(transform.position, transform.forward, out hitInfo) && on)
		{
			Component component = hitInfo.transform.root.GetComponent("triggerChildrenCollider");
			bool flag = default(bool);
			Collider collider = hitInfo.collider;
			Collider[] array = default(Collider[]);
			if (component != null)
			{
				hitInfo.collider.enabled = false;
				object obj = UnityRuntimeServices.GetProperty(component, "childrenColliderList");
				if (!(obj is Collider[]))
				{
					obj = RuntimeServices.Coerce(obj, typeof(Collider[]));
				}
				array = (Collider[])obj;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].enabled = true;
				}
				flag = Physics.Raycast(transform.position, transform.forward, out hitInfo);
			}
			if (flag || component == null)
			{
				laserPoint.position = hitInfo.point + hitInfo.normal * 0.03f;
				RuntimeServices.SetProperty(laserPoint.GetComponent("laserPoint"), "on", true);
				num = Mathf.Min(num, Vector3.Distance(transform.position, hitInfo.point));
			}
			else
			{
				RuntimeServices.SetProperty(laserPoint.GetComponent("laserPoint"), "on", false);
			}
			if (component != null)
			{
				collider.enabled = true;
				for (int j = 0; j < array.Length; j++)
				{
					array[j].enabled = false;
				}
			}
		}
		else
		{
			RuntimeServices.SetProperty(laserPoint.GetComponent("laserPoint"), "on", false);
		}
		if (disableRootCollider)
		{
			transform.root.collider.enabled = true;
		}
		laserLineRate = num * 0.5f;
		if (!(Time.time <= nextLaserLineTime) && on)
		{
			nextLaserLineTime = Time.time + 1f / laserLineRate;
			GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(laserLinePrefab, transform.position, Quaternion.identity);
			gameObject.name = "laserLine";
			gameObject.transform.parent = transform;
			gameObject.transform.localRotation = Quaternion.identity;
			float x = gameObject.transform.localRotation.eulerAngles.x + 90f;
			Quaternion localRotation = gameObject.transform.localRotation;
			Vector3 eulerAngles = localRotation.eulerAngles;
			float num2 = (eulerAngles.x = x);
			Vector3 vector = (localRotation.eulerAngles = eulerAngles);
			Quaternion quaternion = (gameObject.transform.localRotation = localRotation);
			if (!(num >= positionBuffer * 2f))
			{
				float z = positionBuffer;
				Vector3 localPosition = gameObject.transform.localPosition;
				float num3 = (localPosition.z = z);
				Vector3 vector3 = (gameObject.transform.localPosition = localPosition);
			}
			else
			{
				float z2 = UnityEngine.Random.Range(positionBuffer, num - positionBuffer);
				Vector3 localPosition2 = gameObject.transform.localPosition;
				float num4 = (localPosition2.z = z2);
				Vector3 vector5 = (gameObject.transform.localPosition = localPosition2);
			}
		}
		if (on)
		{
			RuntimeServices.SetProperty(laserPointOrigin.GetComponent("laserPoint"), "on", true);
		}
		else
		{
			RuntimeServices.SetProperty(laserPoint.GetComponent("laserPoint"), "on", false);
			RuntimeServices.SetProperty(laserPointOrigin.GetComponent("laserPoint"), "on", false);
		}
		if (num <= positionBuffer * 2f)
		{
			return;
		}
		for (int k = 0; k < transform.childCount; k++)
		{
			Transform child = transform.GetChild(k);
			if (!(child.localPosition.z <= num) && child.name == "laserLine")
			{
				UnityEngine.Object.Destroy(child.gameObject);
			}
		}
	}

	public virtual void Main()
	{
	}
}
