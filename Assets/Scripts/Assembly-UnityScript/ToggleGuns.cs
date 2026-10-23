using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class ToggleGuns : MonoBehaviour
{
	private float wantedheight;

	public Transform maintransform;

	public Renderer maingun;

	public GameObject lasergun;

	public GameObject flamethrower;

	public GameObject launcher;

	public GameObject minigun;

	public GameObject missile;

	public GameObject railgun;

	public GameObject lasercannon;

	public GameObject shotgun;

	public Transform main2;

	private bool correctrotation;

	private bool animatestart;

	private bool animateback;

	private int currentmode;

	[NonSerialized]
	public static int curmode = 1;

	private bool start;

	public bool t1;

	public bool t2;

	private bool ctf;

	public PlayerCar_Script pcscript;

	public ChatScript cscript;

	public FireGun fgun;

	public PauseObject pobj;

	public ConduitInputReciever cInput;

	[NonSerialized]
	public static bool networkswitch;

	public Transform fpspoint;

	public Transform minigunpoint;

	public Transform railgunpoint;

	public AIManager aimanager;

	[NonSerialized]
	public static bool forceRefresh;

	private bool noCancel;

	public ToggleGuns()
	{
		wantedheight = 0.5f;
		currentmode = 1;
	}

	public virtual void Awake()
	{
		networkswitch = false;
		forceRefresh = false;
		curmode = currentmode;
	}

	public virtual void roundreset()
	{
		start = true;
	}

	public virtual void Start()
	{
		if (!((PhotonView)transform.root.GetComponent(typeof(PhotonView))).isMine)
		{
			enabled = false;
		}
		if (((PhotonView)transform.root.GetComponent(typeof(PhotonView))).isMine && !aimanager.isAI)
		{
			if (ChatScript.primaryweapon == "laser")
			{
				maingun.enabled = false;
				lasergun.SetActiveRecursively(true);
				flamethrower.SetActiveRecursively(false);
				minigun.SetActiveRecursively(false);
				launcher.SetActiveRecursively(false);
				missile.SetActiveRecursively(false);
				railgun.SetActiveRecursively(false);
				lasercannon.SetActiveRecursively(false);
				shotgun.SetActiveRecursively(false);
			}
			if (ChatScript.primaryweapon == "flamethrower")
			{
				maingun.enabled = false;
				lasergun.SetActiveRecursively(false);
				flamethrower.SetActiveRecursively(true);
				minigun.SetActiveRecursively(false);
				launcher.SetActiveRecursively(false);
				missile.SetActiveRecursively(false);
				railgun.SetActiveRecursively(false);
				lasercannon.SetActiveRecursively(false);
				shotgun.SetActiveRecursively(false);
			}
			if (ChatScript.primaryweapon == "minigun")
			{
				maingun.enabled = false;
				lasergun.SetActiveRecursively(false);
				flamethrower.SetActiveRecursively(false);
				minigun.SetActiveRecursively(true);
				launcher.SetActiveRecursively(false);
				missile.SetActiveRecursively(false);
				railgun.SetActiveRecursively(false);
				lasercannon.SetActiveRecursively(false);
				shotgun.SetActiveRecursively(false);
			}
			if (ChatScript.primaryweapon == "launcher" || ChatScript.primaryweapon == "emplauncher" || ChatScript.primaryweapon == "grappling")
			{
				maingun.enabled = false;
				lasergun.SetActiveRecursively(false);
				flamethrower.SetActiveRecursively(false);
				minigun.SetActiveRecursively(false);
				launcher.SetActiveRecursively(true);
				missile.SetActiveRecursively(false);
				railgun.SetActiveRecursively(false);
				lasercannon.SetActiveRecursively(false);
				shotgun.SetActiveRecursively(false);
			}
			if (ChatScript.primaryweapon == "rocket")
			{
				maingun.enabled = true;
				lasergun.SetActiveRecursively(false);
				flamethrower.SetActiveRecursively(false);
				minigun.SetActiveRecursively(false);
				launcher.SetActiveRecursively(false);
				missile.SetActiveRecursively(false);
				railgun.SetActiveRecursively(false);
				lasercannon.SetActiveRecursively(false);
				shotgun.SetActiveRecursively(false);
			}
			if (ChatScript.primaryweapon == "missile")
			{
				maingun.enabled = false;
				lasergun.SetActiveRecursively(false);
				flamethrower.SetActiveRecursively(false);
				minigun.SetActiveRecursively(false);
				launcher.SetActiveRecursively(false);
				missile.SetActiveRecursively(true);
				railgun.SetActiveRecursively(false);
				lasercannon.SetActiveRecursively(false);
				shotgun.SetActiveRecursively(false);
			}
			if (ChatScript.primaryweapon == "railgun")
			{
				maingun.enabled = false;
				lasergun.SetActiveRecursively(false);
				flamethrower.SetActiveRecursively(false);
				minigun.SetActiveRecursively(false);
				launcher.SetActiveRecursively(false);
				missile.SetActiveRecursively(false);
				railgun.SetActiveRecursively(true);
				lasercannon.SetActiveRecursively(false);
				shotgun.SetActiveRecursively(false);
			}
			if (ChatScript.primaryweapon == "lasercannon")
			{
				maingun.enabled = false;
				lasergun.SetActiveRecursively(false);
				flamethrower.SetActiveRecursively(false);
				minigun.SetActiveRecursively(false);
				launcher.SetActiveRecursively(false);
				missile.SetActiveRecursively(false);
				railgun.SetActiveRecursively(false);
				lasercannon.SetActiveRecursively(true);
				shotgun.SetActiveRecursively(false);
			}
			if (ChatScript.primaryweapon == "shotgun")
			{
				maingun.enabled = false;
				lasergun.SetActiveRecursively(false);
				flamethrower.SetActiveRecursively(false);
				minigun.SetActiveRecursively(false);
				launcher.SetActiveRecursively(false);
				missile.SetActiveRecursively(false);
				railgun.SetActiveRecursively(false);
				lasercannon.SetActiveRecursively(false);
				shotgun.SetActiveRecursively(true);
			}
		}
	}

	public virtual void setctf(bool t)
	{
		ctf = t;
	}

	public virtual void Update()
	{
		if (!((PhotonView)transform.root.GetComponent(typeof(PhotonView))).isMine || aimanager.isAI)
		{
			return;
		}
		if (forceRefresh)
		{
			forceRefresh = false;
			noCancel = true;
			correctrotation = true;
			start = false;
			maintransform.SendMessage("Starter", start);
			Camera.main.SendMessage("exitFPSmode");
			Camera.main.SendMessage("waitForUp");
		}
		curmode = currentmode;
		if (animatestart)
		{
			correctrotation = false;
			if (!(maintransform.localPosition.y <= wantedheight))
			{
				float y = maintransform.localPosition.y - 2f * Time.deltaTime;
				Vector3 localPosition = maintransform.localPosition;
				float num = (localPosition.y = y);
				Vector3 vector = (maintransform.localPosition = localPosition);
			}
			if (!(maintransform.localPosition.y > wantedheight))
			{
				float y2 = wantedheight;
				Vector3 localPosition2 = maintransform.localPosition;
				float num2 = (localPosition2.y = y2);
				Vector3 vector3 = (maintransform.localPosition = localPosition2);
				if (!ctf)
				{
					networkswitch = true;
					if (currentmode == 2)
					{
						if (ChatScript.secondaryweapon == "laser")
						{
							maingun.enabled = false;
							lasergun.SetActiveRecursively(true);
							flamethrower.SetActiveRecursively(false);
							minigun.SetActiveRecursively(false);
							launcher.SetActiveRecursively(false);
							missile.SetActiveRecursively(false);
							railgun.SetActiveRecursively(false);
							lasercannon.SetActiveRecursively(false);
							shotgun.SetActiveRecursively(false);
						}
						if (ChatScript.secondaryweapon == "flamethrower")
						{
							maingun.enabled = false;
							lasergun.SetActiveRecursively(false);
							flamethrower.SetActiveRecursively(true);
							minigun.SetActiveRecursively(false);
							launcher.SetActiveRecursively(false);
							missile.SetActiveRecursively(false);
							railgun.SetActiveRecursively(false);
							lasercannon.SetActiveRecursively(false);
							shotgun.SetActiveRecursively(false);
						}
						if (ChatScript.secondaryweapon == "minigun")
						{
							maingun.enabled = false;
							lasergun.SetActiveRecursively(false);
							flamethrower.SetActiveRecursively(false);
							minigun.SetActiveRecursively(true);
							launcher.SetActiveRecursively(false);
							missile.SetActiveRecursively(false);
							railgun.SetActiveRecursively(false);
							lasercannon.SetActiveRecursively(false);
							shotgun.SetActiveRecursively(false);
						}
						if (ChatScript.secondaryweapon == "launcher" || ChatScript.secondaryweapon == "emplauncher" || ChatScript.secondaryweapon == "grappling")
						{
							maingun.enabled = false;
							lasergun.SetActiveRecursively(false);
							flamethrower.SetActiveRecursively(false);
							minigun.SetActiveRecursively(false);
							launcher.SetActiveRecursively(true);
							missile.SetActiveRecursively(false);
							railgun.SetActiveRecursively(false);
							lasercannon.SetActiveRecursively(false);
							shotgun.SetActiveRecursively(false);
						}
						if (ChatScript.secondaryweapon == "rocket")
						{
							maingun.enabled = true;
							lasergun.SetActiveRecursively(false);
							flamethrower.SetActiveRecursively(false);
							minigun.SetActiveRecursively(false);
							launcher.SetActiveRecursively(false);
							missile.SetActiveRecursively(false);
							railgun.SetActiveRecursively(false);
							lasercannon.SetActiveRecursively(false);
							shotgun.SetActiveRecursively(false);
						}
						if (ChatScript.secondaryweapon == "missile")
						{
							maingun.enabled = false;
							lasergun.SetActiveRecursively(false);
							flamethrower.SetActiveRecursively(false);
							minigun.SetActiveRecursively(false);
							launcher.SetActiveRecursively(false);
							missile.SetActiveRecursively(true);
							railgun.SetActiveRecursively(false);
							lasercannon.SetActiveRecursively(false);
							shotgun.SetActiveRecursively(false);
						}
						if (ChatScript.secondaryweapon == "railgun")
						{
							maingun.enabled = false;
							lasergun.SetActiveRecursively(false);
							flamethrower.SetActiveRecursively(false);
							minigun.SetActiveRecursively(false);
							launcher.SetActiveRecursively(false);
							missile.SetActiveRecursively(false);
							railgun.SetActiveRecursively(true);
							lasercannon.SetActiveRecursively(false);
							shotgun.SetActiveRecursively(false);
						}
						if (ChatScript.secondaryweapon == "lasercannon")
						{
							maingun.enabled = false;
							lasergun.SetActiveRecursively(false);
							flamethrower.SetActiveRecursively(false);
							minigun.SetActiveRecursively(false);
							launcher.SetActiveRecursively(false);
							missile.SetActiveRecursively(false);
							railgun.SetActiveRecursively(false);
							lasercannon.SetActiveRecursively(true);
							shotgun.SetActiveRecursively(false);
						}
						if (ChatScript.secondaryweapon == "shotgun")
						{
							maingun.enabled = false;
							lasergun.SetActiveRecursively(false);
							flamethrower.SetActiveRecursively(false);
							minigun.SetActiveRecursively(false);
							launcher.SetActiveRecursively(false);
							missile.SetActiveRecursively(false);
							railgun.SetActiveRecursively(false);
							lasercannon.SetActiveRecursively(false);
							shotgun.SetActiveRecursively(true);
						}
					}
					else
					{
						if (ChatScript.primaryweapon == "laser")
						{
							maingun.enabled = false;
							lasergun.SetActiveRecursively(true);
							flamethrower.SetActiveRecursively(false);
							minigun.SetActiveRecursively(false);
							launcher.SetActiveRecursively(false);
							missile.SetActiveRecursively(false);
							railgun.SetActiveRecursively(false);
							lasercannon.SetActiveRecursively(false);
							shotgun.SetActiveRecursively(false);
						}
						if (ChatScript.primaryweapon == "flamethrower")
						{
							maingun.enabled = false;
							lasergun.SetActiveRecursively(false);
							flamethrower.SetActiveRecursively(true);
							minigun.SetActiveRecursively(false);
							launcher.SetActiveRecursively(false);
							missile.SetActiveRecursively(false);
							railgun.SetActiveRecursively(false);
							lasercannon.SetActiveRecursively(false);
							shotgun.SetActiveRecursively(false);
						}
						if (ChatScript.primaryweapon == "minigun")
						{
							maingun.enabled = false;
							lasergun.SetActiveRecursively(false);
							flamethrower.SetActiveRecursively(false);
							minigun.SetActiveRecursively(true);
							launcher.SetActiveRecursively(false);
							missile.SetActiveRecursively(false);
							railgun.SetActiveRecursively(false);
							lasercannon.SetActiveRecursively(false);
							shotgun.SetActiveRecursively(false);
						}
						if (ChatScript.primaryweapon == "launcher" || ChatScript.primaryweapon == "emplauncher" || ChatScript.primaryweapon == "grappling")
						{
							maingun.enabled = false;
							lasergun.SetActiveRecursively(false);
							flamethrower.SetActiveRecursively(false);
							minigun.SetActiveRecursively(false);
							launcher.SetActiveRecursively(true);
							missile.SetActiveRecursively(false);
							railgun.SetActiveRecursively(false);
							lasercannon.SetActiveRecursively(false);
							shotgun.SetActiveRecursively(false);
						}
						if (ChatScript.primaryweapon == "rocket")
						{
							maingun.enabled = true;
							lasergun.SetActiveRecursively(false);
							flamethrower.SetActiveRecursively(false);
							minigun.SetActiveRecursively(false);
							launcher.SetActiveRecursively(false);
							missile.SetActiveRecursively(false);
							railgun.SetActiveRecursively(false);
							lasercannon.SetActiveRecursively(false);
							shotgun.SetActiveRecursively(false);
						}
						if (ChatScript.primaryweapon == "missile")
						{
							maingun.enabled = false;
							lasergun.SetActiveRecursively(false);
							flamethrower.SetActiveRecursively(false);
							minigun.SetActiveRecursively(false);
							launcher.SetActiveRecursively(false);
							missile.SetActiveRecursively(true);
							railgun.SetActiveRecursively(false);
							lasercannon.SetActiveRecursively(false);
							shotgun.SetActiveRecursively(false);
						}
						if (ChatScript.primaryweapon == "railgun")
						{
							maingun.enabled = false;
							lasergun.SetActiveRecursively(false);
							flamethrower.SetActiveRecursively(false);
							minigun.SetActiveRecursively(false);
							launcher.SetActiveRecursively(false);
							missile.SetActiveRecursively(false);
							railgun.SetActiveRecursively(true);
							lasercannon.SetActiveRecursively(false);
							shotgun.SetActiveRecursively(false);
						}
						if (ChatScript.primaryweapon == "lasercannon")
						{
							maingun.enabled = false;
							lasergun.SetActiveRecursively(false);
							flamethrower.SetActiveRecursively(false);
							minigun.SetActiveRecursively(false);
							launcher.SetActiveRecursively(false);
							missile.SetActiveRecursively(false);
							railgun.SetActiveRecursively(false);
							lasercannon.SetActiveRecursively(true);
							shotgun.SetActiveRecursively(false);
						}
						if (ChatScript.primaryweapon == "shotgun")
						{
							maingun.enabled = false;
							lasergun.SetActiveRecursively(false);
							flamethrower.SetActiveRecursively(false);
							minigun.SetActiveRecursively(false);
							launcher.SetActiveRecursively(false);
							missile.SetActiveRecursively(false);
							railgun.SetActiveRecursively(false);
							lasercannon.SetActiveRecursively(false);
							shotgun.SetActiveRecursively(true);
						}
					}
				}
				animatestart = false;
				animateback = true;
			}
		}
		bool flag2;
		if (correctrotation)
		{
			if (!t1)
			{
				bool flag = false;
				if (!(transform.localRotation.eulerAngles.x <= 180f))
				{
					float x = transform.localRotation.eulerAngles.x + 66.6f * Time.deltaTime;
					Quaternion localRotation = transform.localRotation;
					Vector3 eulerAngles = localRotation.eulerAngles;
					float num3 = (eulerAngles.x = x);
					Vector3 vector5 = (localRotation.eulerAngles = eulerAngles);
					Quaternion quaternion = (transform.localRotation = localRotation);
				}
				if (!(transform.localRotation.eulerAngles.x >= 180f))
				{
					if (!(transform.localRotation.eulerAngles.x >= 17.05864f))
					{
						float x2 = transform.localRotation.eulerAngles.x + 66.6f * Time.deltaTime;
						Quaternion localRotation2 = transform.localRotation;
						Vector3 eulerAngles2 = localRotation2.eulerAngles;
						float num4 = (eulerAngles2.x = x2);
						Vector3 vector7 = (localRotation2.eulerAngles = eulerAngles2);
						Quaternion quaternion3 = (transform.localRotation = localRotation2);
						flag = true;
					}
					if (!(transform.localRotation.eulerAngles.x <= 17.05864f))
					{
						float x3 = transform.localRotation.eulerAngles.x - 66.6f * Time.deltaTime;
						Quaternion localRotation3 = transform.localRotation;
						Vector3 eulerAngles3 = localRotation3.eulerAngles;
						float num5 = (eulerAngles3.x = x3);
						Vector3 vector9 = (localRotation3.eulerAngles = eulerAngles3);
						Quaternion quaternion5 = (transform.localRotation = localRotation3);
						if (flag)
						{
							float x4 = 17.05864f;
							Quaternion localRotation4 = transform.localRotation;
							Vector3 eulerAngles4 = localRotation4.eulerAngles;
							float num6 = (eulerAngles4.x = x4);
							Vector3 vector11 = (localRotation4.eulerAngles = eulerAngles4);
							Quaternion quaternion7 = (transform.localRotation = localRotation4);
							t1 = true;
						}
					}
				}
			}
			if (!t2)
			{
				flag2 = false;
				if (!(main2.localRotation.y <= 0f))
				{
					float y3 = main2.localRotation.y - 3f * Time.deltaTime;
					Quaternion localRotation5 = main2.localRotation;
					float num7 = (localRotation5.y = y3);
					Quaternion quaternion9 = (main2.localRotation = localRotation5);
					flag2 = true;
				}
				if (!(main2.localRotation.y >= 0f))
				{
					float y4 = main2.localRotation.y + 3f * Time.deltaTime;
					Quaternion localRotation6 = main2.localRotation;
					float num8 = (localRotation6.y = y4);
					Quaternion quaternion11 = (main2.localRotation = localRotation6);
					if (flag2)
					{
						int num9 = 0;
						Quaternion localRotation7 = main2.localRotation;
						float num10 = (localRotation7.y = num9);
						Quaternion quaternion13 = (main2.localRotation = localRotation7);
						t2 = true;
					}
				}
			}
			if (t1 && t2)
			{
				animatestart = true;
				t1 = false;
				t2 = false;
			}
		}
		flag2 = false;
		if (animateback)
		{
			if (!(maintransform.localPosition.y >= 1.439178f))
			{
				float y5 = maintransform.localPosition.y + 2f * Time.deltaTime;
				Vector3 localPosition3 = maintransform.localPosition;
				float num11 = (localPosition3.y = y5);
				Vector3 vector13 = (maintransform.localPosition = localPosition3);
			}
			if (!(maintransform.localPosition.y < 1.439178f))
			{
				float y6 = 1.439178f;
				Vector3 localPosition4 = maintransform.localPosition;
				float num12 = (localPosition4.y = y6);
				Vector3 vector15 = (maintransform.localPosition = localPosition4);
				animatestart = false;
				animateback = false;
				start = true;
				noCancel = false;
				maintransform.SendMessage("Starter", start);
			}
		}
		if (noCancel || ChatScript.isPickingUpTemp)
		{
			return;
		}
		if (Input.GetKeyDown("2") && PlayerCar_Script.controlenabled && !FireGun.rocketreload && !FireGun.laserreload && !FireGun.grappling && currentmode != 2 && !animatestart && !animateback)
		{
			currentmode = 2;
			correctrotation = true;
			start = false;
			maintransform.SendMessage("Starter", start);
			Camera.main.SendMessage("exitFPSmode");
			Camera.main.SendMessage("waitForUp");
		}
		if (Input.GetKeyDown("1") && PlayerCar_Script.controlenabled && !FireGun.rocketreload && !FireGun.laserreload && !FireGun.grappling && currentmode != 1 && !animatestart && !animateback)
		{
			currentmode = 1;
			correctrotation = true;
			start = false;
			maintransform.SendMessage("Starter", start);
			Camera.main.SendMessage("exitFPSmode");
			Camera.main.SendMessage("waitForUp");
		}
		if ((Input.GetKeyDown("e") || RuntimeServices.ToBool((!(PauseObject.alt_switch != string.Empty)) ? ((object)false) : RuntimeServices.Invoke(typeof(Input), "GetKeyDown", new object[1] { Enum.Parse(typeof(KeyCode), PauseObject.alt_switch) })) || RuntimeServices.ToBool(ConduitInputReciever.ht["sWep"])) && PlayerCar_Script.controlenabled && !FireGun.rocketreload && !FireGun.laserreload && !FireGun.grappling)
		{
			if (RuntimeServices.ToBool(ConduitInputReciever.ht["sWep"]))
			{
				ConduitInputReciever.ht["sWep"] = false;
			}
			if (currentmode == 1)
			{
				if (PlayerCar_Script.controlenabled && !animatestart && !animateback)
				{
					currentmode = 2;
					correctrotation = true;
					start = false;
					maintransform.SendMessage("Starter", start);
					Camera.main.SendMessage("exitFPSmode");
					Camera.main.SendMessage("waitForUp");
				}
			}
			else if (PlayerCar_Script.controlenabled && !animatestart && !animateback)
			{
				currentmode = 1;
				correctrotation = true;
				start = false;
				maintransform.SendMessage("Starter", start);
				Camera.main.SendMessage("exitFPSmode");
				Camera.main.SendMessage("waitForUp");
			}
		}
		if (Input.GetKeyDown("q") && PlayerCar_Script.controlenabled && (correctrotation || animatestart))
		{
			animatestart = false;
			animateback = true;
			if (currentmode == 1)
			{
				currentmode = 2;
			}
			else
			{
				currentmode = 1;
			}
			correctrotation = false;
			start = true;
			maintransform.SendMessage("Starter", start);
		}
	}

	public virtual void Main()
	{
	}
}
