using System;
using UnityEngine;

[Serializable]
public class crosshair : MonoBehaviour
{
	public Vector2 crosshairCenter;

	public float offseting;

	public Texture textureUp;

	public Texture textureDown;

	public Texture textureRight;

	public Texture textureLeft;

	public float accuracyLoss;

	public float xOffset;

	public float yOffset;

	private Vector3 position;

	private float xOffsetSpeed;

	private float yOffsetSpeed;

	private Color crosshairColor;

	private float crosshairAlpha;

	private health healthScript;

	public crosshair()
	{
		crosshairCenter = new Vector2(0.5f, 0.6f);
		offseting = 2f;
		crosshairColor = Color.white;
		crosshairAlpha = 1f;
	}

	public virtual void Start()
	{
		healthScript = (health)transform.root.GetComponent("health");
	}

	public virtual void LateUpdate()
	{
		float num = 100f;
		if (healthScript != null)
		{
			num = healthScript.GetHealth();
		}
		if (!(num <= 0f))
		{
			xOffsetSpeed += Input.GetAxis("Mouse X") * Time.deltaTime * 0.2f;
			yOffsetSpeed += Input.GetAxis("Mouse Y") * Time.deltaTime * 0.2f;
		}
		xOffsetSpeed = Mathf.Lerp(xOffsetSpeed, 0f, Time.deltaTime * 20f);
		yOffsetSpeed = Mathf.Lerp(yOffsetSpeed, 0f, Time.deltaTime * 20f);
		xOffset += xOffsetSpeed;
		yOffset += yOffsetSpeed;
		xOffset = Mathf.Lerp(xOffset, 0f, Time.deltaTime * Mathf.Pow(Mathf.Abs(xOffset), offseting) * offseting * 100f);
		yOffset = Mathf.Lerp(yOffset, 0f, Time.deltaTime * Mathf.Pow(Mathf.Abs(yOffset), offseting) * offseting * 100f);
		position = new Vector3(crosshairCenter.x + xOffset, crosshairCenter.y + yOffset, 0f);
		transform.position = position;
	}

	public virtual void OnGUI()
	{
		float num = 100f;
		if (healthScript != null)
		{
			num = healthScript.GetHealth();
		}
		float num2 = 0.1f;
		if (!(num <= 0f))
		{
			crosshairAlpha = Mathf.Sin(Time.time) * num2 + (1f - num2);
		}
		else
		{
			crosshairAlpha = Mathf.Lerp(crosshairAlpha, 0f, Time.deltaTime);
		}
		crosshairColor.a = crosshairAlpha;
		GUI.color = crosshairColor;
		float num3 = (float)Screen.width * 0.03f;
		float num4 = (float)Screen.width * crosshairCenter.x + xOffset * (float)Screen.width - num3 * 0.5f;
		float num5 = (float)Screen.height * (1f - crosshairCenter.y) - yOffset * (float)Screen.height - num3 * 0.5f;
		float num6 = accuracyLoss * (float)Screen.width / 40f;
		GUI.DrawTexture(new Rect(num4, num5 + num6, num3, num3), textureUp);
		GUI.DrawTexture(new Rect(num4, num5 - num6, num3, num3), textureDown);
		GUI.DrawTexture(new Rect(num4 - num6, num5, num3, num3), textureRight);
		GUI.DrawTexture(new Rect(num4 + num6, num5, num3, num3), textureLeft);
	}

	public virtual void Main()
	{
	}
}
