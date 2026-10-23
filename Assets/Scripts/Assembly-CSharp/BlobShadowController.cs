using UnityEngine;

public class BlobShadowController : MonoBehaviour
{
	private void Update()
	{
		base.transform.position = base.transform.parent.position + Vector3.up * 20f;
		base.transform.rotation = Quaternion.LookRotation(-Vector3.up, base.transform.parent.forward);
	}
}
