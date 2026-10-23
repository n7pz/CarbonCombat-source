using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class CrossHairDraw : MonoBehaviour
{
	public Rect position;

	public Texture2D crosshairTexture;

	public ChatScript src;

	public AuthGameObject authobj;

	public PauseObject pobj;

	public FPMode fpmode;

	public AudioController acon;

	public FireGun firegun;

	public GunController gcon;

	public SpawningScript spwnsrc;

	public SpectatorController speccon;

	public ConduitInputReciever cInput;

	[NonSerialized]
	public static Vector2 crossHairPos = new Vector2(Screen.width / 2, Screen.height / 2);

	[NonSerialized]
	public static bool useCursor = true;

	public PreloaderExplosion pex;

	public Texture[] reloadingdots;

	private float rotatedotstimer;

	private int dotstate;

	public CrossHairDraw()
	{
		rotatedotstimer = 0.35f;
		dotstate = 1;
	}

	public virtual void Start()
	{
		Screen.showCursor = false;
	}

	public virtual void Update()
	{
		if (!RuntimeServices.EqualityOperator(ConduitInputReciever.ht["tPad"], Vector2.zero))
		{
			Vector2 vector = (Vector2)ConduitInputReciever.ht["tPad"];
			crossHairPos.x = Mathf.Clamp(crossHairPos.x + 315f * (vector.x / 35f), 0f, Screen.width);
			crossHairPos.y = Mathf.Clamp(crossHairPos.y + 175f * (vector.y / 35f), 0f, Screen.height);
			ConduitInputReciever.ht["tPad"] = Vector2.zero;
		}
		if (Input.GetAxis("Mouse X") != 0f || Input.GetAxis("Mouse Y") != 0f)
		{
			useCursor = true;
		}
		if (Application.loadedLevelName != "Preloader")
		{
			crosshairTexture = (Texture2D)PauseObject.chairliststat[PauseObject.chairvar];
		}
		if (FireGun.rocketreload || FireGun.laserreload)
		{
			if (!(rotatedotstimer <= 0f))
			{
				rotatedotstimer -= Time.deltaTime;
				return;
			}
			rotatedotstimer = 0.35f;
			if (dotstate == 1)
			{
				dotstate = 2;
			}
			else if (dotstate == 2)
			{
				dotstate = 3;
			}
			else if (dotstate == 3)
			{
				dotstate = 1;
			}
		}
		else
		{
			dotstate = 1;
		}
	}

	public virtual void OnGUI()
	{
		if (!AudioController.hideGUI)
		{
			bool flag = false;
			float num = default(float);
			float num2 = default(float);
			num = (ChatScript.minimized ? 133f : ((ChatScript.alpha >= 0.5f) ? 458f : 195f));
			num2 = ((!ChatScript.hide) ? 268f : 35f);
			if (Application.loadedLevelName != "Preloader")
			{
				if (!(((!useCursor) ? crossHairPos.x : ((!useCursor) ? new Vector3(crossHairPos.x, crossHairPos.y, 0f) : Input.mousePosition).x) >= num2) && !(((!useCursor) ? crossHairPos.y : ((!useCursor) ? new Vector3(crossHairPos.x, crossHairPos.y, 0f) : Input.mousePosition).y) <= (float)Screen.height - num) && useCursor)
				{
					flag = true;
					Screen.showCursor = true;
				}
				if ((bool)GameObject.FindWithTag("minimap") && GameObject.FindWithTag("minimap").camera.enabled && !(((!useCursor) ? crossHairPos.x : ((!useCursor) ? new Vector3(crossHairPos.x, crossHairPos.y, 0f) : Input.mousePosition).x) <= (float)(Screen.width - 194)) && !(((!useCursor) ? crossHairPos.y : ((!useCursor) ? new Vector3(crossHairPos.x, crossHairPos.y, 0f) : Input.mousePosition).y) >= 175f) && useCursor)
				{
					flag = true;
					Screen.showCursor = true;
				}
				if (new Rect(5f, 0f, 25f, 20f).Contains((!useCursor) ? new Vector3(crossHairPos.x, crossHairPos.y, 0f) : Input.mousePosition) && useCursor)
				{
					flag = true;
					Screen.showCursor = true;
				}
				if (new Rect(39f, 0f, 20f, 20f).Contains((!useCursor) ? new Vector3(crossHairPos.x, crossHairPos.y, 0f) : Input.mousePosition) && useCursor)
				{
					flag = true;
					Screen.showCursor = true;
				}
				if (new Rect(67f, 0f, 30f, 20f).Contains((!useCursor) ? new Vector3(crossHairPos.x, crossHairPos.y, 0f) : Input.mousePosition) && useCursor)
				{
					flag = true;
					Screen.showCursor = true;
				}
				if ((!PreloaderExplosion.isKong || !Application.isWebPlayer) && new Rect(105f, 0f, 20f, 20f).Contains((!useCursor) ? new Vector3(crossHairPos.x, crossHairPos.y, 0f) : Input.mousePosition) && useCursor)
				{
					flag = true;
					Screen.showCursor = true;
				}
			}
			if (PauseObject.pubalpha == 1f && useCursor)
			{
				flag = true;
				Screen.showCursor = true;
			}
			if (flag)
			{
				return;
			}
			Screen.showCursor = false;
			if (SpectatorController.iscont)
			{
				return;
			}
			GUI.depth = -20;
			position = new Rect(((!useCursor) ? crossHairPos.x : ((!useCursor) ? new Vector3(crossHairPos.x, crossHairPos.y, 0f) : Input.mousePosition).x) - (float)(crosshairTexture.width / 2), (float)Screen.height - ((!useCursor) ? crossHairPos.y : ((!useCursor) ? new Vector3(crossHairPos.x, crossHairPos.y, 0f) : Input.mousePosition).y) - (float)(crosshairTexture.height / 2), crosshairTexture.width, crosshairTexture.height);
			if (!FPMode.focusgui && !Screen.lockCursor)
			{
				GUI.DrawTexture(position, crosshairTexture);
				if ((FireGun.rocketreload || FireGun.laserreload) && ChatScript.isCar && SpawningScript.team2 != string.Empty)
				{
					if (dotstate == 1)
					{
						GUI.DrawTexture(new Rect(((!useCursor) ? crossHairPos.x : ((!useCursor) ? new Vector3(crossHairPos.x, crossHairPos.y, 0f) : Input.mousePosition).x) - 9f, (float)Screen.height - ((!useCursor) ? crossHairPos.y : ((!useCursor) ? new Vector3(crossHairPos.x, crossHairPos.y, 0f) : Input.mousePosition).y) + (float)(crosshairTexture.height / 2), reloadingdots[0].width, reloadingdots[0].height), reloadingdots[0]);
						GUI.DrawTexture(new Rect(((!useCursor) ? crossHairPos.x : ((!useCursor) ? new Vector3(crossHairPos.x, crossHairPos.y, 0f) : Input.mousePosition).x) - 4f, (float)Screen.height - ((!useCursor) ? crossHairPos.y : ((!useCursor) ? new Vector3(crossHairPos.x, crossHairPos.y, 0f) : Input.mousePosition).y) + (float)(crosshairTexture.height / 2), reloadingdots[1].width, reloadingdots[1].height), reloadingdots[1]);
						GUI.DrawTexture(new Rect(((!useCursor) ? crossHairPos.x : ((!useCursor) ? new Vector3(crossHairPos.x, crossHairPos.y, 0f) : Input.mousePosition).x) + 1f, (float)Screen.height - ((!useCursor) ? crossHairPos.y : ((!useCursor) ? new Vector3(crossHairPos.x, crossHairPos.y, 0f) : Input.mousePosition).y) + (float)(crosshairTexture.height / 2), reloadingdots[1].width, reloadingdots[1].height), reloadingdots[1]);
					}
					if (dotstate == 2)
					{
						GUI.DrawTexture(new Rect(((!useCursor) ? crossHairPos.x : ((!useCursor) ? new Vector3(crossHairPos.x, crossHairPos.y, 0f) : Input.mousePosition).x) - 9f, (float)Screen.height - ((!useCursor) ? crossHairPos.y : ((!useCursor) ? new Vector3(crossHairPos.x, crossHairPos.y, 0f) : Input.mousePosition).y) + (float)(crosshairTexture.height / 2), reloadingdots[1].width, reloadingdots[1].height), reloadingdots[1]);
						GUI.DrawTexture(new Rect(((!useCursor) ? crossHairPos.x : ((!useCursor) ? new Vector3(crossHairPos.x, crossHairPos.y, 0f) : Input.mousePosition).x) - 4f, (float)Screen.height - ((!useCursor) ? crossHairPos.y : ((!useCursor) ? new Vector3(crossHairPos.x, crossHairPos.y, 0f) : Input.mousePosition).y) + (float)(crosshairTexture.height / 2), reloadingdots[0].width, reloadingdots[0].height), reloadingdots[0]);
						GUI.DrawTexture(new Rect(((!useCursor) ? crossHairPos.x : ((!useCursor) ? new Vector3(crossHairPos.x, crossHairPos.y, 0f) : Input.mousePosition).x) + 1f, (float)Screen.height - ((!useCursor) ? crossHairPos.y : ((!useCursor) ? new Vector3(crossHairPos.x, crossHairPos.y, 0f) : Input.mousePosition).y) + (float)(crosshairTexture.height / 2), reloadingdots[1].width, reloadingdots[1].height), reloadingdots[1]);
					}
					if (dotstate == 3)
					{
						GUI.DrawTexture(new Rect(((!useCursor) ? crossHairPos.x : ((!useCursor) ? new Vector3(crossHairPos.x, crossHairPos.y, 0f) : Input.mousePosition).x) - 9f, (float)Screen.height - ((!useCursor) ? crossHairPos.y : ((!useCursor) ? new Vector3(crossHairPos.x, crossHairPos.y, 0f) : Input.mousePosition).y) + (float)(crosshairTexture.height / 2), reloadingdots[1].width, reloadingdots[1].height), reloadingdots[1]);
						GUI.DrawTexture(new Rect(((!useCursor) ? crossHairPos.x : ((!useCursor) ? new Vector3(crossHairPos.x, crossHairPos.y, 0f) : Input.mousePosition).x) - 4f, (float)Screen.height - ((!useCursor) ? crossHairPos.y : ((!useCursor) ? new Vector3(crossHairPos.x, crossHairPos.y, 0f) : Input.mousePosition).y) + (float)(crosshairTexture.height / 2), reloadingdots[1].width, reloadingdots[1].height), reloadingdots[1]);
						GUI.DrawTexture(new Rect(((!useCursor) ? crossHairPos.x : ((!useCursor) ? new Vector3(crossHairPos.x, crossHairPos.y, 0f) : Input.mousePosition).x) + 1f, (float)Screen.height - ((!useCursor) ? crossHairPos.y : ((!useCursor) ? new Vector3(crossHairPos.x, crossHairPos.y, 0f) : Input.mousePosition).y) + (float)(crosshairTexture.height / 2), reloadingdots[0].width, reloadingdots[0].height), reloadingdots[0]);
					}
				}
				if (!FireGun.rocketreload && !FireGun.laserreload && FireGun.isCharging)
				{
					GUI.DrawTexture(new Rect(((!useCursor) ? crossHairPos.x : ((!useCursor) ? new Vector3(crossHairPos.x, crossHairPos.y, 0f) : Input.mousePosition).x) - 14f, (float)Screen.height - ((!useCursor) ? crossHairPos.y : ((!useCursor) ? new Vector3(crossHairPos.x, crossHairPos.y, 0f) : Input.mousePosition).y) + (float)(crosshairTexture.height / 2), reloadingdots[(FireGun.chargeState <= 0f) ? 1 : 0].width, reloadingdots[(FireGun.chargeState <= 0f) ? 1 : 0].height), reloadingdots[(FireGun.chargeState <= 0f) ? 1 : 0]);
					GUI.DrawTexture(new Rect(((!useCursor) ? crossHairPos.x : ((!useCursor) ? new Vector3(crossHairPos.x, crossHairPos.y, 0f) : Input.mousePosition).x) - 9f, (float)Screen.height - ((!useCursor) ? crossHairPos.y : ((!useCursor) ? new Vector3(crossHairPos.x, crossHairPos.y, 0f) : Input.mousePosition).y) + (float)(crosshairTexture.height / 2), reloadingdots[(FireGun.chargeState <= 1f) ? 1 : 0].width, reloadingdots[(FireGun.chargeState <= 1f) ? 1 : 0].height), reloadingdots[(FireGun.chargeState <= 1f) ? 1 : 0]);
					GUI.DrawTexture(new Rect(((!useCursor) ? crossHairPos.x : ((!useCursor) ? new Vector3(crossHairPos.x, crossHairPos.y, 0f) : Input.mousePosition).x) - 4f, (float)Screen.height - ((!useCursor) ? crossHairPos.y : ((!useCursor) ? new Vector3(crossHairPos.x, crossHairPos.y, 0f) : Input.mousePosition).y) + (float)(crosshairTexture.height / 2), reloadingdots[(FireGun.chargeState <= 2f) ? 1 : 0].width, reloadingdots[(FireGun.chargeState <= 2f) ? 1 : 0].height), reloadingdots[(FireGun.chargeState <= 2f) ? 1 : 0]);
					GUI.DrawTexture(new Rect(((!useCursor) ? crossHairPos.x : ((!useCursor) ? new Vector3(crossHairPos.x, crossHairPos.y, 0f) : Input.mousePosition).x) + 1f, (float)Screen.height - ((!useCursor) ? crossHairPos.y : ((!useCursor) ? new Vector3(crossHairPos.x, crossHairPos.y, 0f) : Input.mousePosition).y) + (float)(crosshairTexture.height / 2), reloadingdots[(FireGun.chargeState <= 3f) ? 1 : 0].width, reloadingdots[(FireGun.chargeState <= 3f) ? 1 : 0].height), reloadingdots[(FireGun.chargeState <= 3f) ? 1 : 0]);
					GUI.DrawTexture(new Rect(((!useCursor) ? crossHairPos.x : ((!useCursor) ? new Vector3(crossHairPos.x, crossHairPos.y, 0f) : Input.mousePosition).x) + 6f, (float)Screen.height - ((!useCursor) ? crossHairPos.y : ((!useCursor) ? new Vector3(crossHairPos.x, crossHairPos.y, 0f) : Input.mousePosition).y) + (float)(crosshairTexture.height / 2), reloadingdots[(FireGun.chargeState <= 4f) ? 1 : 0].width, reloadingdots[(FireGun.chargeState <= 4f) ? 1 : 0].height), reloadingdots[(FireGun.chargeState <= 4f) ? 1 : 0]);
				}
				return;
			}
			GUI.DrawTexture(new Rect(((!Screen.fullScreen) ? Screen.width : Screen.currentResolution.width) / 2 - crosshairTexture.width / 2, ((!Screen.fullScreen) ? Screen.height : Screen.currentResolution.height) / 2 - crosshairTexture.height / 2, crosshairTexture.width, crosshairTexture.height), crosshairTexture);
			if ((FireGun.rocketreload || FireGun.laserreload) && ChatScript.isCar && SpawningScript.team2 != string.Empty)
			{
				if (dotstate == 1)
				{
					GUI.DrawTexture(new Rect(Screen.width / 2 - 9, Screen.height / 2 + crosshairTexture.height / 2, reloadingdots[0].width, reloadingdots[0].height), reloadingdots[0]);
					GUI.DrawTexture(new Rect(Screen.width / 2 - 4, Screen.height / 2 + crosshairTexture.height / 2, reloadingdots[1].width, reloadingdots[1].height), reloadingdots[1]);
					GUI.DrawTexture(new Rect(Screen.width / 2 + 1, Screen.height / 2 + crosshairTexture.height / 2, reloadingdots[1].width, reloadingdots[1].height), reloadingdots[1]);
				}
				if (dotstate == 2)
				{
					GUI.DrawTexture(new Rect(Screen.width / 2 - 9, Screen.height / 2 + crosshairTexture.height / 2, reloadingdots[1].width, reloadingdots[1].height), reloadingdots[1]);
					GUI.DrawTexture(new Rect(Screen.width / 2 - 4, Screen.height / 2 + crosshairTexture.height / 2, reloadingdots[0].width, reloadingdots[0].height), reloadingdots[0]);
					GUI.DrawTexture(new Rect(Screen.width / 2 + 1, Screen.height / 2 + crosshairTexture.height / 2, reloadingdots[1].width, reloadingdots[1].height), reloadingdots[1]);
				}
				if (dotstate == 3)
				{
					GUI.DrawTexture(new Rect(Screen.width / 2 - 9, Screen.height / 2 + crosshairTexture.height / 2, reloadingdots[1].width, reloadingdots[1].height), reloadingdots[1]);
					GUI.DrawTexture(new Rect(Screen.width / 2 - 4, Screen.height / 2 + crosshairTexture.height / 2, reloadingdots[1].width, reloadingdots[1].height), reloadingdots[1]);
					GUI.DrawTexture(new Rect(Screen.width / 2 + 1, Screen.height / 2 + crosshairTexture.height / 2, reloadingdots[0].width, reloadingdots[0].height), reloadingdots[0]);
				}
			}
			if (!FireGun.rocketreload && !FireGun.laserreload && FireGun.isCharging)
			{
				GUI.DrawTexture(new Rect(Screen.width / 2 - 14, Screen.height / 2 + crosshairTexture.height / 2, reloadingdots[(FireGun.chargeState <= 0f) ? 1 : 0].width, reloadingdots[(FireGun.chargeState <= 0f) ? 1 : 0].height), reloadingdots[(FireGun.chargeState <= 0f) ? 1 : 0]);
				GUI.DrawTexture(new Rect(Screen.width / 2 - 9, Screen.height / 2 + crosshairTexture.height / 2, reloadingdots[(FireGun.chargeState <= 1f) ? 1 : 0].width, reloadingdots[(FireGun.chargeState <= 1f) ? 1 : 0].height), reloadingdots[(FireGun.chargeState <= 1f) ? 1 : 0]);
				GUI.DrawTexture(new Rect(Screen.width / 2 - 4, Screen.height / 2 + crosshairTexture.height / 2, reloadingdots[(FireGun.chargeState <= 2f) ? 1 : 0].width, reloadingdots[(FireGun.chargeState <= 2f) ? 1 : 0].height), reloadingdots[(FireGun.chargeState <= 2f) ? 1 : 0]);
				GUI.DrawTexture(new Rect(Screen.width / 2 + 1, Screen.height / 2 + crosshairTexture.height / 2, reloadingdots[(FireGun.chargeState <= 3f) ? 1 : 0].width, reloadingdots[(FireGun.chargeState <= 3f) ? 1 : 0].height), reloadingdots[(FireGun.chargeState <= 3f) ? 1 : 0]);
				GUI.DrawTexture(new Rect(Screen.width / 2 + 6, Screen.height / 2 + crosshairTexture.height / 2, reloadingdots[(FireGun.chargeState <= 4f) ? 1 : 0].width, reloadingdots[(FireGun.chargeState <= 4f) ? 1 : 0].height), reloadingdots[(FireGun.chargeState <= 4f) ? 1 : 0]);
			}
		}
		else if (!Screen.showCursor)
		{
			Screen.showCursor = true;
		}
	}

	public virtual void Main()
	{
	}
}
