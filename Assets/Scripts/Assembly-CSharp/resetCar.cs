using UnityEngine;

public class resetCar : MonoBehaviour
{
	public Transform target;

	private void Start()
	{
	}

	private void Update()
	{
		if (Input.GetKeyDown("r"))
		{
			target.position = new Vector3(0f, 0.2f, 0f);
			target.rotation = Quaternion.identity;
		}
	}
}
