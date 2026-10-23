using System;
using UnityEngine;

[Serializable]
public class SpectatorBot : MonoBehaviour
{
	public AuthGameObject authobj;

	public WhirldIn win;

	public PauseObject pobj;

	public virtual void Update()
	{
		rigidbody.AddRelativeForce(Input.GetAxis("Horizontal") * 1100000f * Time.deltaTime, Input.GetAxis("Mouse Y") * 137500f * Time.deltaTime * (PauseObject.fpssens / 5f), Input.GetAxis("Vertical") * 1100000f * Time.deltaTime);
		rigidbody.AddRelativeTorque(0f, Input.GetAxis("Mouse X") * 33000f * Time.deltaTime * (PauseObject.fpssens / 5f), 0f);
		if (!(transform.position.y >= 11.5f))
		{
			if (WhirldIn.hassea || AuthGameObject.whirldurl == string.Empty)
			{
				rigidbody.drag = 3.1f;
				rigidbody.angularDrag = 4.5f;
			}
			else
			{
				rigidbody.drag = 0.8f;
				rigidbody.angularDrag = 2f;
			}
		}
		else
		{
			rigidbody.drag = 0.8f;
			rigidbody.angularDrag = 2f;
		}
	}

	public virtual void Main()
	{
	}
}
