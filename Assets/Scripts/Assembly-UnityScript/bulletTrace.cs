using System;
using Boo.Lang.Runtime;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class bulletTrace : MonoBehaviour
{
	public float life;

	public float bulletSpeed;

	public GameObject dustPrefab;

	public GameObject bulletHolePrefab;

	private float destroyTime;

	private Vector3 velocity;

	private float gravity;

	public bulletTrace()
	{
		life = 0.5f;
		bulletSpeed = 1f;
		gravity = 9.8f;
	}

	public virtual void Start()
	{
		destroyTime = Time.time + life;
		velocity += transform.forward * bulletSpeed;
	}

	public virtual void Update()
	{
		if (!(Time.time <= destroyTime))
		{
			UnityEngine.Object.Destroy(this.gameObject);
		}
		Ray ray = new Ray
		{
			origin = transform.position,
			direction = transform.forward
		};
		RaycastHit hitInfo = default(RaycastHit);
		if (Physics.Raycast(ray, out hitInfo, bulletSpeed * Time.deltaTime))
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
				flag = Physics.Raycast(ray, out hitInfo, bulletSpeed * Time.deltaTime);
			}
			if (flag || component == null)
			{
				UnityEngine.Object.Destroy(this.gameObject);
				bool flag2 = true;
				bool flag3 = true;
				bulletHoleProperty bulletHoleProperty2 = (bulletHoleProperty)hitInfo.transform.root.GetComponent("bulletHoleProperty");
				GameObject gameObject = null;
				float num = 1f;
				Material[] array2 = null;
				Material[] bulletMaterials = default(Material[]);
				if (bulletHoleProperty2 != null)
				{
					flag2 = bulletHoleProperty2.dust;
					flag3 = bulletHoleProperty2.hole;
					gameObject = bulletHoleProperty2.extraPrefab;
					num = bulletHoleProperty2.sizeModifier;
					bulletMaterials = bulletHoleProperty2.bulletMaterials;
				}
				if (gameObject != null)
				{
					UnityEngine.Object.Instantiate(gameObject, transform.position, transform.rotation);
				}
				if (flag2)
				{
					GameObject gameObject2 = (GameObject)UnityEngine.Object.Instantiate(dustPrefab, hitInfo.point - transform.forward * 0.1f, Quaternion.identity);
					RuntimeServices.SetProperty(gameObject2.GetComponent("dustCloudGenerator"), "velocity", hitInfo.normal * (2f + UnityEngine.Random.value * 10f));
				}
				if (flag3)
				{
					GameObject gameObject3 = (GameObject)UnityEngine.Object.Instantiate(bulletHolePrefab, hitInfo.point + hitInfo.normal * 0.01f, Quaternion.identity);
					gameObject3.transform.LookAt(gameObject3.transform.position + hitInfo.normal);
					gameObject3.transform.parent = hitInfo.collider.transform;
					bulletHole bulletHole2 = (bulletHole)gameObject3.GetComponent("bulletHole");
					bulletHole2.size *= num;
					if (bulletHoleProperty2 != null && bulletMaterials.Length > 0)
					{
						bulletHole2.materials = bulletMaterials;
					}
				}
				if (hitInfo.rigidbody != null)
				{
					hitInfo.rigidbody.AddForceAtPosition(velocity * 1.5f, hitInfo.point);
				}
				health health2 = (health)hitInfo.transform.root.GetComponent("health");
				if (health2 != null)
				{
					health2.healthPoints -= 20f;
					health2.SetLastHitTime();
					Vector3 point = hitInfo.point;
					point.y = hitInfo.transform.position.y;
					Vector3 direction = point - hitInfo.transform.position;
					direction.Normalize();
					direction = hitInfo.transform.root.InverseTransformDirection(direction);
					health2.SetHitDirection(direction);
					Vector3 direction2 = hitInfo.transform.position - point;
					direction2.Normalize();
					health2.SetrecoilDirecion(direction2);
				}
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
		velocity.y -= gravity * Time.deltaTime;
		transform.position += velocity * Time.deltaTime;
		transform.LookAt(transform.position + velocity);
	}

	public virtual void Main()
	{
	}
}
