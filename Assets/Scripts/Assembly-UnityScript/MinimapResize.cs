using System;
using UnityEngine;

[Serializable]
public class MinimapResize : MonoBehaviour
{
	public GUIStyle zoombutton;

	public GUIStyle textstyle;

	public GUIStyle backgroundstyle;

	private float zoomlevel;

	public MinimapResize()
	{
		zoomlevel = 1f;
	}

	public virtual void Update()
	{
		float num = 220f / ((float)Screen.width * 1f);
		float num2 = (float)(Screen.height - 5) / ((float)Screen.height * 1f);
		float width = 220f / ((float)Screen.width * 1f);
		float height = 175f / ((float)Screen.height * 1f);
		camera.rect = new Rect(1f - num, 1f - num2, width, height);
	}

	public virtual void OnGUI()
	{
		if (!gameObject.camera.enabled)
		{
			return;
		}
		GUI.Box(new Rect(Screen.width - 85, Screen.height - 10 - 50, 82f, 48f), string.Empty, backgroundstyle);
		if (GUI.Button(new Rect(Screen.width - 37, Screen.height - 10 - 33, 16f, 16f), string.Empty, zoombutton))
		{
			zoomlevel += 0.5f;
			if (!(zoomlevel <= 2f))
			{
				zoomlevel = 1f;
			}
			float x = zoomlevel;
			Vector3 localScale = transform.localScale;
			float num = (localScale.x = x);
			Vector3 vector = (transform.localScale = localScale);
			float y = zoomlevel;
			Vector3 localScale2 = transform.localScale;
			float num2 = (localScale2.y = y);
			Vector3 vector3 = (transform.localScale = localScale2);
			float z = zoomlevel;
			Vector3 localScale3 = transform.localScale;
			float num3 = (localScale3.z = z);
			Vector3 vector5 = (transform.localScale = localScale3);
			camera.orthographicSize = 510f * zoomlevel;
		}
	}

	public virtual void Main()
	{
	}
}
