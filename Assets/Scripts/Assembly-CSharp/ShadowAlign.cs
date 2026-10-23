using UnityEngine;

public class ShadowAlign : MonoBehaviour
{
	public Light lightSource;

	private void LateUpdate()
	{
		if (lightSource.type == LightType.Directional)
		{
			base.transform.rotation = lightSource.transform.rotation;
		}
		else
		{
			base.transform.LookAt(base.transform.position + (base.transform.position - lightSource.transform.position));
		}
	}
}
