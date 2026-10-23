using System;
using Boo.Lang.Runtime;
using Photon;
using UnityEngine;

[Serializable]
public class FPMode : Photon.MonoBehaviour
{
	private float rotationX;

	private float rotationY;

	private GameObject camerapoint;

	private GameObject gunbase;

	private GameObject gunbarrel;

	private GameObject gunmain;

	private float tapcounter;

	private int tapstep;

	public CTFFlagSender ctf;

	public SpawningScript spwnsrc;

	public SpectatorController speccon;

	public PlayerCar_Script pcar;

	public GunController gcontroller;

	public ChatScript cscript;

	private float alpha;

	[NonSerialized]
	public static bool focusgui;

	public Texture focusimg;

	private bool waitforup;

	public PauseObject pobj;

	public HealthBar hbar;

	public AudioController acon;

	private Vector3 lookPoint;

	public LayerMask layermask;

	public FPMode()
	{
		tapcounter = 0.7f;
		lookPoint = Vector3.zero;
	}

	public virtual void Awake()
	{
		focusgui = false;
	}

	public virtual void LateUpdate()
	{
		if (!CTFFlagSender.gotflag && !SpectatorController.iscont && SpawningScript.team2 != string.Empty && !HealthBar.isdead && PlayerCar_Script.controlenabled && !AudioController.hideGUI && ChatScript.isCar)
		{
			if (Input.GetAxis("Shift") != 0f || RuntimeServices.ToBool((!(PauseObject.alt_scope != string.Empty)) ? ((object)false) : RuntimeServices.Invoke(typeof(Input), "GetKey", new object[1] { Enum.Parse(typeof(KeyCode), PauseObject.alt_scope) })) || tapstep == 4 || Input.GetKey("z"))
			{
				if (!waitforup && GunController.startvar)
				{
					focusgui = true;
					camerapoint = GameObject.FindWithTag("MyCameraView");
					gunbase = GameObject.FindWithTag("GunBase");
					gunbarrel = GameObject.FindWithTag("GunBarrel");
					gunmain = GameObject.FindWithTag("GunMain");
					this.gameObject.SendMessage("setenable", false);
					gunmain.SendMessage("setfpsmode", true);
					GameObject gameObject = GameObject.FindWithTag("MyCameraView");
					transform.parent = gameObject.transform;
					transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(0f, 0f, 0f), Time.deltaTime * 12f);
					Quaternion to = Quaternion.Euler(0f, 0f, 0f);
					transform.localRotation = Quaternion.Slerp(transform.localRotation, to, Time.deltaTime * 4.5f);
					Screen.lockCursor = true;
					float x = gunbarrel.transform.localRotation.eulerAngles.x + Input.GetAxis("Mouse Y") * -1f * (PauseObject.fpssens / 5f);
					Quaternion localRotation = gunbarrel.transform.localRotation;
					Vector3 eulerAngles = localRotation.eulerAngles;
					float num = (eulerAngles.x = x);
					Vector3 vector = (localRotation.eulerAngles = eulerAngles);
					Quaternion quaternion = (gunbarrel.transform.localRotation = localRotation);
					if (!(gunbarrel.transform.localRotation.eulerAngles.x >= 300f) && !(gunbarrel.transform.localRotation.eulerAngles.x <= 180f))
					{
						int num2 = 300;
						Quaternion localRotation2 = gunbarrel.transform.localRotation;
						Vector3 eulerAngles2 = localRotation2.eulerAngles;
						float num3 = (eulerAngles2.x = num2);
						Vector3 vector3 = (localRotation2.eulerAngles = eulerAngles2);
						Quaternion quaternion3 = (gunbarrel.transform.localRotation = localRotation2);
					}
					if (!(gunbarrel.transform.localRotation.eulerAngles.x <= 20.7f) && !(gunbarrel.transform.localRotation.eulerAngles.x >= 180f))
					{
						float x2 = 20.7f;
						Quaternion localRotation3 = gunbarrel.transform.localRotation;
						Vector3 eulerAngles3 = localRotation3.eulerAngles;
						float num4 = (eulerAngles3.x = x2);
						Vector3 vector5 = (localRotation3.eulerAngles = eulerAngles3);
						Quaternion quaternion5 = (gunbarrel.transform.localRotation = localRotation3);
					}
					if (gunbarrel.transform.localRotation.eulerAngles.x == 180f)
					{
						float x3 = 377.0587f;
						Quaternion localRotation4 = gunbarrel.transform.localRotation;
						Vector3 eulerAngles4 = localRotation4.eulerAngles;
						float num5 = (eulerAngles4.x = x3);
						Vector3 vector7 = (localRotation4.eulerAngles = eulerAngles4);
						Quaternion quaternion7 = (gunbarrel.transform.localRotation = localRotation4);
					}
					float y = gunbase.transform.localRotation.eulerAngles.y + Input.GetAxis("Mouse X") * 1f * (PauseObject.fpssens / 5f);
					Quaternion localRotation5 = gunbase.transform.localRotation;
					Vector3 eulerAngles5 = localRotation5.eulerAngles;
					float num6 = (eulerAngles5.y = y);
					Vector3 vector9 = (localRotation5.eulerAngles = eulerAngles5);
					Quaternion quaternion9 = (gunbase.transform.localRotation = localRotation5);
					if (tapstep == 0)
					{
						tapstep = 1;
					}
					if (tapstep == 2 && !(tapcounter <= 0f))
					{
						tapstep = 3;
					}
					if ((Input.GetAxis("Shift") != 0f || RuntimeServices.ToBool((!(PauseObject.alt_scope != string.Empty)) ? ((object)false) : RuntimeServices.Invoke(typeof(Input), "GetKey", new object[1] { Enum.Parse(typeof(KeyCode), PauseObject.alt_scope) })) || Input.GetKey("z")) && tapstep == 4)
					{
						tapstep = 5;
					}
				}
			}
			else
			{
				if (tapstep == 1)
				{
					tapstep = 2;
				}
				if (tapstep == 3 && !(tapcounter <= 0f))
				{
					tapcounter = 0.3f;
					tapstep = 4;
				}
				if (tapstep == 5)
				{
					tapstep = 0;
				}
				exitFPSmode();
			}
			if (Input.GetKeyDown("escape"))
			{
				exitFPSmode();
				tapstep = 0;
			}
		}
		else
		{
			exitFPSmode();
			tapstep = 0;
		}
	}

	public virtual void Update()
	{
		if (tapstep >= 1 && tapstep <= 3)
		{
			if (!(tapcounter <= 0f))
			{
				tapcounter -= Time.deltaTime;
			}
			else
			{
				tapstep = 0;
				tapcounter = 0.3f;
			}
		}
		if (HealthBar.isdead && photonView.isMine)
		{
			exitFPSmode();
			tapstep = 0;
		}
		if (focusgui)
		{
			if (!(alpha >= 1f))
			{
				alpha += 10f * Time.deltaTime;
			}
			else
			{
				alpha = 1f;
			}
		}
		else if (!(alpha <= 0f))
		{
			alpha -= 15f * Time.deltaTime;
		}
		else
		{
			alpha = 0f;
		}
		if ((waitforup && Input.GetAxis("Shift") == 0f) || !RuntimeServices.ToBool((!(PauseObject.alt_scope != string.Empty)) ? ((object)false) : RuntimeServices.Invoke(typeof(Input), "GetKey", new object[1] { Enum.Parse(typeof(KeyCode), PauseObject.alt_scope) })))
		{
			waitforup = false;
		}
		if ((bool)Camera.main && Camera.main.fieldOfView != 75f - 25f * Mathf.Min(1f, Mathf.Max(0f, alpha)))
		{
			Camera.main.fieldOfView = 75f - 25f * Mathf.Min(1f, Mathf.Max(0f, alpha));
		}
	}

	public virtual void OnGUI()
	{
		if (QualitySettings.GetQualityLevel() != 0)
		{
			float a = alpha * 0.8f;
			Color color = GUI.color;
			float num = (color.a = a);
			Color color2 = (GUI.color = color);
			float num2 = default(float);
			int width = Screen.width;
			int height = Screen.height;
			num2 = ((width > height) ? ((float)width) : ((float)height));
			if (alpha != 0f)
			{
				GUI.DrawTexture(new Rect(-1f * ((num2 - (float)width) / 2f), -1f * ((num2 - (float)height) / 2f), num2, num2), focusimg);
			}
		}
	}

	public virtual void waitForUp()
	{
		waitforup = true;
		tapstep = 0;
	}

	public virtual void exitFPSmode()
	{
		lookPoint = Vector3.zero;
		focusgui = false;
		if (ChatScript.isCar)
		{
			Screen.lockCursor = false;
			transform.parent = null;
		}
		gameObject.SendMessage("setenable", true);
		if ((bool)gunmain)
		{
			gunmain.SendMessage("setfpsmode", false);
		}
	}

	public virtual void Main()
	{
	}
}
