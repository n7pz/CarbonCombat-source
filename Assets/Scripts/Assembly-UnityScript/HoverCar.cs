using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using Photon;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class HoverCar : Photon.MonoBehaviour
{
	[Serializable]
	internal sealed class _0024startCountdownEmp_00244752 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal float _0024t_00244753;

			internal HoverCar _0024self__00244754;

			public _0024(float t, HoverCar self_)
			{
				_0024t_00244753 = t;
				_0024self__00244754 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00244754.empcount = _0024t_00244753;
					goto case 2;
				case 2:
					if (_0024self__00244754.empcount > 0f)
					{
						_0024self__00244754.empcount -= Time.deltaTime;
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024self__00244754.empdisable = false;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal float _0024t_00244755;

		internal HoverCar _0024self__00244756;

		public _0024startCountdownEmp_00244752(float t, HoverCar self_)
		{
			_0024t_00244755 = t;
			_0024self__00244756 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024t_00244755, _0024self__00244756);
		}
	}

	public ParticleEmitter flame1;

	public ParticleEmitter flame2;

	public ParticleEmitter flame3;

	public ParticleEmitter flame4;

	public ParticleEmitter spark1;

	public ParticleEmitter spark2;

	public ParticleEmitter spark3;

	public ParticleEmitter spark4;

	public GameObject wheelcolparent;

	public HealthBar hbar;

	public Transform wheelBR;

	public Transform wheelBL;

	public Transform wheelFR;

	public Transform wheelFL;

	public Rigidbody maincar;

	public bool hoverstart;

	public GameObject collider1;

	public GameObject collider2;

	public bool resetonce;

	public bool resetdone;

	public bool newhoverstart;

	public WheelCollider FrontLeftWheel;

	public WheelCollider FrontRightWheel;

	public WheelCollider BackLeftWheel;

	public WheelCollider BackRightWheel;

	public Renderer rocketgun;

	public GameObject lasergun;

	private float counter;

	private bool setupsus;

	private bool controlenabled;

	private bool lastflameemit;

	private int lastrocketenabled;

	private bool lastcolactive;

	private bool lastlightactive;

	public Light blight1;

	public Light blight2;

	private bool waitforspace;

	private bool controlen;

	[NonSerialized]
	public static bool statcontrol = true;

	private bool hovtog;

	private int hovtogstate;

	private float hovtimer;

	public GameObject flamethrower;

	public GameObject minigun;

	public GameObject launcher;

	public GameObject missile;

	public GameObject railgun;

	public GameObject lasercannon;

	public GameObject shotgun;

	public ChatScript cscript;

	public ToggleGuns toggun;

	public EndofRound endofround;

	public FPMode fpmode;

	public ConduitInputReciever cInput;

	public GliderController gC;

	private float empcount;

	private bool empdisable;

	[NonSerialized]
	public static bool maincardisdrag;

	private int netHorz;

	public int netVert;

	private bool netSpace;

	public AIManager aimanager;

	public PauseObject pobj;

	public TutorialManager tMan;

	public AuthGameObject authobj;

	public HoverCar()
	{
		counter = 0.2f;
		setupsus = true;
		controlenabled = true;
		lastrocketenabled = 1;
		lastcolactive = true;
		controlen = true;
		hovtimer = 0.7f;
	}

	public virtual void empDisable(float t)
	{
		empdisable = true;
		hovtogstate = 0;
		StartCoroutine_Auto(startCountdownEmp(t));
	}

	public virtual IEnumerator startCountdownEmp(float t)
	{
		return new _0024startCountdownEmp_00244752(t, this).GetEnumerator();
	}

	public virtual void setcontrol(object t)
	{
		if (RuntimeServices.EqualityOperator(t, true) && hoverstart)
		{
			waitforspace = true;
		}
		else
		{
			controlenabled = RuntimeServices.UnboxBoolean(t);
		}
	}

	public virtual void forcedisable()
	{
		waitforspace = false;
		controlenabled = true;
		hovtimer = 0.7f;
		hovtogstate = 0;
		hovtog = false;
	}

	public virtual void Start()
	{
		collider1.active = false;
		collider2.active = false;
		aimanager = (AIManager)maincar.GetComponent("AIManager");
		if (aimanager.isAI)
		{
			controlen = true;
		}
	}

	[RPC]
	public virtual void syncInputHorz(int horz)
	{
		netHorz = horz;
		if (!photonView.isMine && !flame1.emit)
		{
			if (horz == 0)
			{
				RuntimeServices.SetProperty(wheelFR.collider, "steerAngle", 0);
				RuntimeServices.SetProperty(wheelFL.collider, "steerAngle", 0);
			}
			if (horz == 1)
			{
				RuntimeServices.SetProperty(wheelFR.collider, "steerAngle", 11);
				RuntimeServices.SetProperty(wheelFL.collider, "steerAngle", 11);
			}
			if (horz == -1)
			{
				RuntimeServices.SetProperty(wheelFR.collider, "steerAngle", -11);
				RuntimeServices.SetProperty(wheelFL.collider, "steerAngle", -11);
			}
		}
	}

	[RPC]
	public virtual void syncInputVert(int vert)
	{
		netVert = vert;
	}

	[RPC]
	public virtual void syncInputSpace(bool space)
	{
		netSpace = space;
	}

	[RPC]
	public virtual void updateflame(string t)
	{
		if (t == "1")
		{
			flame1.emit = true;
			flame2.emit = true;
			flame3.emit = true;
			flame4.emit = true;
			spark1.emit = true;
			spark2.emit = true;
			spark3.emit = true;
			spark4.emit = true;
		}
		else
		{
			flame1.emit = false;
			flame2.emit = false;
			flame3.emit = false;
			flame4.emit = false;
			spark1.emit = false;
			spark2.emit = false;
			spark3.emit = false;
			spark4.emit = false;
		}
	}

	[RPC]
	public virtual void updategun(string t, string i)
	{
		if (i == "rocket")
		{
			rocketgun.enabled = true;
			lasergun.SetActiveRecursively(false);
			flamethrower.SetActiveRecursively(false);
			minigun.SetActiveRecursively(false);
			launcher.SetActiveRecursively(false);
			missile.SetActiveRecursively(false);
			railgun.SetActiveRecursively(false);
			lasercannon.SetActiveRecursively(false);
			shotgun.SetActiveRecursively(false);
		}
		if (i == "laser")
		{
			rocketgun.enabled = false;
			lasergun.SetActiveRecursively(true);
			flamethrower.SetActiveRecursively(false);
			minigun.SetActiveRecursively(false);
			launcher.SetActiveRecursively(false);
			missile.SetActiveRecursively(false);
			railgun.SetActiveRecursively(false);
			lasercannon.SetActiveRecursively(false);
			shotgun.SetActiveRecursively(false);
		}
		if (i == "minigun")
		{
			rocketgun.enabled = false;
			lasergun.SetActiveRecursively(false);
			flamethrower.SetActiveRecursively(false);
			minigun.SetActiveRecursively(true);
			launcher.SetActiveRecursively(false);
			missile.SetActiveRecursively(false);
			railgun.SetActiveRecursively(false);
			lasercannon.SetActiveRecursively(false);
			shotgun.SetActiveRecursively(false);
		}
		if (i == "flamethrower")
		{
			rocketgun.enabled = false;
			lasergun.SetActiveRecursively(false);
			flamethrower.SetActiveRecursively(true);
			minigun.SetActiveRecursively(false);
			launcher.SetActiveRecursively(false);
			missile.SetActiveRecursively(false);
			railgun.SetActiveRecursively(false);
			lasercannon.SetActiveRecursively(false);
			shotgun.SetActiveRecursively(false);
		}
		switch (i)
		{
		case "launcher":
		case "emplauncher":
		case "grappling":
			rocketgun.enabled = false;
			lasergun.SetActiveRecursively(false);
			flamethrower.SetActiveRecursively(false);
			minigun.SetActiveRecursively(false);
			launcher.SetActiveRecursively(true);
			missile.SetActiveRecursively(false);
			railgun.SetActiveRecursively(false);
			lasercannon.SetActiveRecursively(false);
			shotgun.SetActiveRecursively(false);
			break;
		}
		if (i == "missile")
		{
			rocketgun.enabled = false;
			lasergun.SetActiveRecursively(false);
			flamethrower.SetActiveRecursively(false);
			minigun.SetActiveRecursively(false);
			launcher.SetActiveRecursively(false);
			missile.SetActiveRecursively(true);
			railgun.SetActiveRecursively(false);
			lasercannon.SetActiveRecursively(false);
			shotgun.SetActiveRecursively(false);
		}
		if (i == "railgun")
		{
			rocketgun.enabled = false;
			lasergun.SetActiveRecursively(false);
			flamethrower.SetActiveRecursively(false);
			minigun.SetActiveRecursively(false);
			launcher.SetActiveRecursively(false);
			missile.SetActiveRecursively(false);
			railgun.SetActiveRecursively(true);
			lasercannon.SetActiveRecursively(false);
			shotgun.SetActiveRecursively(false);
		}
		if (i == "lasercannon")
		{
			rocketgun.enabled = false;
			lasergun.SetActiveRecursively(false);
			flamethrower.SetActiveRecursively(false);
			minigun.SetActiveRecursively(false);
			launcher.SetActiveRecursively(false);
			missile.SetActiveRecursively(false);
			railgun.SetActiveRecursively(false);
			lasercannon.SetActiveRecursively(true);
			shotgun.SetActiveRecursively(false);
		}
		if (i == "shotgun")
		{
			rocketgun.enabled = false;
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

	[RPC]
	public virtual void updatecollider(string t)
	{
		if (t == "1")
		{
			collider1.active = true;
			collider2.active = true;
		}
		else
		{
			collider1.active = false;
			collider2.active = false;
		}
	}

	[RPC]
	public virtual void updatelight(string t)
	{
		if (t == "1")
		{
			blight1.enabled = true;
			blight2.enabled = true;
		}
		else
		{
			blight1.enabled = false;
			blight2.enabled = false;
		}
	}

	public virtual void deactivate(bool t)
	{
		controlen = t;
	}

	public virtual void rampdisable()
	{
		hovtogstate = 0;
		hoverstart = false;
		maincardisdrag = false;
	}

	public virtual void Update()
	{
		if (photonView.isMine)
		{
			if (Mathf.Round(RuntimeServices.UnboxSingle(aimanager.isAI ? ((object)aimanager.verticalInput) : ((!RuntimeServices.ToBool(RuntimeServices.InvokeBinaryOperator("op_GreaterThan", RuntimeServices.Invoke(typeof(Mathf), "Abs", new object[1] { UnityRuntimeServices.GetProperty(ConduitInputReciever.ht["dPad"], "y") }), 0))) ? ((object)Input.GetAxis("Vertical")) : RuntimeServices.InvokeBinaryOperator("op_Division", UnityRuntimeServices.GetProperty(ConduitInputReciever.ht["dPad"], "y"), 50f)))) != (float)netVert)
			{
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("syncInputVert", PhotonTargets.All, UnityBuiltins.parseInt(Mathf.Round(RuntimeServices.UnboxSingle((!RuntimeServices.ToBool(RuntimeServices.InvokeBinaryOperator("op_GreaterThan", RuntimeServices.Invoke(typeof(Mathf), "Abs", new object[1] { UnityRuntimeServices.GetProperty(ConduitInputReciever.ht["dPad"], "y") }), 0))) ? ((object)Input.GetAxis("Vertical")) : RuntimeServices.InvokeBinaryOperator("op_Division", UnityRuntimeServices.GetProperty(ConduitInputReciever.ht["dPad"], "y"), 50f)))));
			}
			if (Mathf.Round(RuntimeServices.UnboxSingle(aimanager.isAI ? ((object)aimanager.horizontalInput) : ((!RuntimeServices.ToBool(RuntimeServices.InvokeBinaryOperator("op_GreaterThan", RuntimeServices.Invoke(typeof(Mathf), "Abs", new object[1] { UnityRuntimeServices.GetProperty(ConduitInputReciever.ht["dPad"], "x") }), 0))) ? ((object)Input.GetAxis("Horizontal")) : RuntimeServices.InvokeBinaryOperator("op_Division", UnityRuntimeServices.GetProperty(ConduitInputReciever.ht["dPad"], "x"), 50f)))) != (float)netHorz)
			{
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("syncInputHorz", PhotonTargets.All, UnityBuiltins.parseInt(Mathf.Round(RuntimeServices.UnboxSingle((!RuntimeServices.ToBool(RuntimeServices.InvokeBinaryOperator("op_GreaterThan", RuntimeServices.Invoke(typeof(Mathf), "Abs", new object[1] { UnityRuntimeServices.GetProperty(ConduitInputReciever.ht["dPad"], "x") }), 0))) ? ((object)Input.GetAxis("Horizontal")) : RuntimeServices.InvokeBinaryOperator("op_Division", UnityRuntimeServices.GetProperty(ConduitInputReciever.ht["dPad"], "x"), 50f)))));
			}
			bool flag = false;
			flag = ((((!aimanager.isAI) ? Input.GetAxis("Jump") : ((float)(aimanager.spaceButton ? 1 : 0))) != 0f || RuntimeServices.ToBool((!(PauseObject.alt_fly != string.Empty) || aimanager.isAI) ? ((object)false) : RuntimeServices.Invoke(typeof(Input), "GetKey", new object[1] { Enum.Parse(typeof(KeyCode), PauseObject.alt_fly) })) || RuntimeServices.ToBool(ConduitInputReciever.ht["jump"]) || flame1.emit) ? true : false);
			if (flag != netSpace)
			{
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("syncInputSpace", PhotonTargets.All, flag);
			}
		}
		if (!empdisable && (RuntimeServices.ToBool(TutorialManager.curCArr[1]) || !AuthGameObject.showTutorial))
		{
			if (photonView.isMine)
			{
				statcontrol = controlen;
			}
			if (HealthBar.isdead || !(EndofRound.alphastat <= 0f))
			{
				hovtogstate = 0;
				hoverstart = false;
				maincardisdrag = false;
				empdisable = false;
				empcount = 0f;
			}
			if (controlenabled && controlen && !empdisable && !aimanager.isAI && (RuntimeServices.ToBool(TutorialManager.curCArr[1]) || !AuthGameObject.showTutorial) && !gC.gliderState)
			{
				object value;
				if (photonView.isMine)
				{
					if (ChatScript.isCar)
					{
						float axis = Input.GetAxis("Jump");
						value = ((axis != 0f) ? ((object)axis) : ((!(PauseObject.alt_fly != string.Empty)) ? ((object)false) : RuntimeServices.Invoke(typeof(Input), "GetKey", new object[1] { Enum.Parse(typeof(KeyCode), PauseObject.alt_fly) })));
						if (!RuntimeServices.ToBool(value))
						{
							value = ConduitInputReciever.ht["jump"];
						}
					}
					else
					{
						value = false;
					}
				}
				else
				{
					value = netSpace;
				}
				if (RuntimeServices.ToBool(value))
				{
					if (hovtogstate == 0)
					{
						hovtogstate = 1;
					}
					if (hovtogstate == 2)
					{
						hovtogstate = 3;
					}
					if (hovtogstate == 4)
					{
						hovtog = false;
						hovtogstate = 0;
						hovtimer = 0.7f;
					}
				}
				bool num;
				if (photonView.isMine)
				{
					float axis2 = Input.GetAxis("Jump");
					object value2 = ((axis2 != 0f) ? ((object)axis2) : ((!(PauseObject.alt_fly != string.Empty)) ? ((object)false) : RuntimeServices.Invoke(typeof(Input), "GetKey", new object[1] { Enum.Parse(typeof(KeyCode), PauseObject.alt_fly) })));
					if (!RuntimeServices.ToBool(value2))
					{
						value2 = ConduitInputReciever.ht["jump"];
					}
					num = !RuntimeServices.ToBool(value2);
				}
				else
				{
					num = !netSpace;
				}
				if (num)
				{
					if (hovtogstate == 1)
					{
						hovtogstate = 2;
					}
					if (hovtogstate == 3)
					{
						hovtogstate = 4;
						hovtog = true;
					}
				}
				if (hovtogstate != 0 && hovtogstate != 4)
				{
					if (!(hovtimer <= 0f))
					{
						hovtimer -= Time.deltaTime;
					}
					else
					{
						hovtimer = 0.7f;
						hovtogstate = 0;
					}
				}
			}
			object value3;
			if (!aimanager.isAI)
			{
				if (photonView.isMine)
				{
					if (ChatScript.isCar)
					{
						float axis3 = Input.GetAxis("Jump");
						value3 = ((axis3 != 0f) ? ((object)axis3) : ((!(PauseObject.alt_fly != string.Empty)) ? ((object)false) : RuntimeServices.Invoke(typeof(Input), "GetKey", new object[1] { Enum.Parse(typeof(KeyCode), PauseObject.alt_fly) })));
						if (!RuntimeServices.ToBool(value3))
						{
							value3 = ConduitInputReciever.ht["jump"];
						}
					}
					else
					{
						value3 = false;
					}
				}
				else
				{
					value3 = netSpace;
				}
			}
			else
			{
				value3 = aimanager.spaceButton;
			}
			if (RuntimeServices.ToBool(value3) && waitforspace)
			{
				waitforspace = false;
				controlenabled = true;
			}
			if (photonView.isMine)
			{
				string text = null;
				if (lastflameemit != flame1.emit)
				{
					lastflameemit = flame1.emit;
					text = ((!flame1.emit) ? "0" : "1");
					((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("updateflame", PhotonTargets.Others, text);
				}
				if (lastrocketenabled != ToggleGuns.curmode && ToggleGuns.networkswitch)
				{
					ToggleGuns.networkswitch = false;
					lastrocketenabled = ToggleGuns.curmode;
					text = ((ToggleGuns.curmode != 1) ? "0" : "1");
					if (ToggleGuns.curmode == 1)
					{
						((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("updategun", PhotonTargets.Others, text, ChatScript.primaryweapon);
					}
					else
					{
						((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("updategun", PhotonTargets.Others, text, ChatScript.secondaryweapon);
					}
				}
				if (lastcolactive != collider1.active)
				{
					lastcolactive = collider1.active;
					text = ((!collider1.active) ? "0" : "1");
					((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("updatecollider", PhotonTargets.Others, text);
				}
				if (lastlightactive != blight1.enabled)
				{
					lastlightactive = blight1.enabled;
					text = ((!blight1.enabled) ? "0" : "1");
					((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("updatelight", PhotonTargets.Others, text);
				}
			}
			if (controlenabled)
			{
				if (Input.GetAxis("Brake") == 0f || !hoverstart || aimanager.isAI)
				{
					object value4;
					if (!aimanager.isAI)
					{
						if (photonView.isMine)
						{
							if (ChatScript.isCar)
							{
								float axis4 = Input.GetAxis("Jump");
								value4 = ((axis4 != 0f) ? ((object)axis4) : ((!(PauseObject.alt_fly != string.Empty)) ? ((object)false) : RuntimeServices.Invoke(typeof(Input), "GetKey", new object[1] { Enum.Parse(typeof(KeyCode), PauseObject.alt_fly) })));
								if (!RuntimeServices.ToBool(value4))
								{
									value4 = ConduitInputReciever.ht["jump"];
								}
							}
							else
							{
								value4 = false;
							}
						}
						else
						{
							value4 = netSpace;
						}
					}
					else
					{
						value4 = aimanager.spaceButton;
					}
					if ((RuntimeServices.ToBool(value4) || hovtog) && !gC.gliderState)
					{
						if (controlen)
						{
							maincardisdrag = false;
							if (setupsus)
							{
								FrontLeftWheel.steerAngle = 0f;
								FrontRightWheel.steerAngle = 0f;
								FrontLeftWheel.suspensionDistance = 0.11f;
								FrontRightWheel.suspensionDistance = 0.11f;
								BackLeftWheel.suspensionDistance = 0.11f;
								BackRightWheel.suspensionDistance = 0.11f;
							}
							if (!setupsus && photonView.isMine)
							{
								maincar.AddRelativeForce(0f, 3000000f * Time.deltaTime * ((!FPMode.focusgui) ? 1f : 0.7f), 0f);
								flame1.emit = true;
								flame2.emit = true;
								flame3.emit = true;
								flame4.emit = true;
								spark1.emit = true;
								spark2.emit = true;
								spark3.emit = true;
								spark4.emit = true;
							}
						}
					}
					else
					{
						if (controlen)
						{
							maincardisdrag = false;
						}
						setupsus = true;
						if (photonView.isMine)
						{
							flame1.emit = false;
							flame2.emit = false;
							flame3.emit = false;
							flame4.emit = false;
							spark1.emit = false;
							spark2.emit = false;
							spark3.emit = false;
							spark4.emit = false;
						}
					}
				}
				else if (Input.GetAxis("Brake") != 0f && hoverstart && !aimanager.isAI)
				{
					maincardisdrag = true;
					if (photonView.isMine)
					{
						maincar.AddRelativeForce(0f, 1450000f * Time.deltaTime, 0f);
					}
					maincar.drag = 1f;
				}
			}
			else if (hoverstart)
			{
				maincardisdrag = true;
				if (photonView.isMine)
				{
					maincar.AddRelativeForce(0f, 1450000f * Time.deltaTime, 0f);
				}
				maincar.drag = 1f;
			}
			if (!flame1.emit)
			{
				hoverstart = false;
				newhoverstart = false;
				if (!resetdone && !resetonce)
				{
					int num2 = 0;
					Quaternion localRotation = wheelBR.localRotation;
					float num3 = (localRotation.x = num2);
					Quaternion quaternion = (wheelBR.localRotation = localRotation);
					int num4 = 0;
					Quaternion localRotation2 = wheelBL.localRotation;
					float num5 = (localRotation2.x = num4);
					Quaternion quaternion3 = (wheelBL.localRotation = localRotation2);
					int num6 = 0;
					Quaternion localRotation3 = wheelFR.localRotation;
					float num7 = (localRotation3.x = num6);
					Quaternion quaternion5 = (wheelFR.localRotation = localRotation3);
					int num8 = 0;
					Quaternion localRotation4 = wheelFL.localRotation;
					float num9 = (localRotation4.x = num8);
					Quaternion quaternion7 = (wheelFL.localRotation = localRotation4);
					bool flag2 = false;
					bool flag3 = false;
					bool flag4 = false;
					bool flag5 = false;
					if (!(wheelBR.localRotation.y <= 0f))
					{
						wheelBR.Rotate(0f, Time.deltaTime * -120f, 0f, Space.Self);
						flag2 = true;
					}
					if (!(wheelBL.localRotation.y <= 0f))
					{
						wheelBL.Rotate(0f, Time.deltaTime * -120f, 0f, Space.Self);
						flag3 = true;
					}
					if (!(wheelFR.localRotation.y <= 0f))
					{
						wheelFR.Rotate(0f, Time.deltaTime * -120f, 0f, Space.Self);
						flag4 = true;
					}
					if (!(wheelFL.localRotation.y <= 0f))
					{
						wheelFL.Rotate(0f, Time.deltaTime * -120f, 0f, Space.Self);
						flag5 = true;
					}
					if (!(wheelBR.localRotation.y >= 0f))
					{
						wheelBR.Rotate(0f, Time.deltaTime * 120f, 0f, Space.Self);
						if (flag2)
						{
							int num10 = 0;
							Quaternion localRotation5 = wheelBR.localRotation;
							float num11 = (localRotation5.y = num10);
							Quaternion quaternion9 = (wheelBR.localRotation = localRotation5);
						}
					}
					if (!(wheelBL.localRotation.y >= 0f))
					{
						wheelBL.Rotate(0f, Time.deltaTime * 120f, 0f, Space.Self);
						if (flag3)
						{
							int num12 = 0;
							Quaternion localRotation6 = wheelBL.localRotation;
							float num13 = (localRotation6.y = num12);
							Quaternion quaternion11 = (wheelBL.localRotation = localRotation6);
						}
					}
					if (!(wheelFR.localRotation.y >= 0f))
					{
						wheelFR.Rotate(0f, Time.deltaTime * 120f, 0f, Space.Self);
						if (flag4)
						{
							int num14 = 0;
							Quaternion localRotation7 = wheelFR.localRotation;
							float num15 = (localRotation7.y = num14);
							Quaternion quaternion13 = (wheelFR.localRotation = localRotation7);
						}
					}
					if (!(wheelFL.localRotation.y >= 0f))
					{
						wheelFL.Rotate(0f, Time.deltaTime * 120f, 0f, Space.Self);
						if (flag5)
						{
							int num16 = 0;
							Quaternion localRotation8 = wheelFL.localRotation;
							float num17 = (localRotation8.y = num16);
							Quaternion quaternion15 = (wheelFL.localRotation = localRotation8);
						}
					}
					if (flag2 && flag3 && flag4 && flag5 && wheelFL.localRotation.y == 0f)
					{
						resetdone = true;
					}
					if (wheelBL.localRotation.y == 0f && wheelBR.localRotation.y == 0f && wheelFL.localRotation.y == 0f && wheelFR.localRotation.y == 0f)
					{
						resetdone = true;
					}
					flag2 = false;
					flag3 = false;
					flag4 = false;
					flag5 = false;
				}
				if (resetdone)
				{
					if (!resetonce && !(wheelBL.localRotation.z >= 0f))
					{
						wheelBR.Rotate(0f, 0f, Time.deltaTime * -160f, Space.Self);
						wheelBL.Rotate(0f, 0f, Time.deltaTime * 160f, Space.Self);
						wheelFL.Rotate(0f, 0f, Time.deltaTime * 160f, Space.Self);
						wheelFR.Rotate(0f, 0f, Time.deltaTime * -160f, Space.Self);
					}
					if (!(wheelBL.localRotation.z <= 0f))
					{
						if (!resetonce)
						{
							maincar.angularDrag = 0.05f;
							resetonce = true;
						}
						int num18 = 0;
						Quaternion localRotation9 = wheelBR.localRotation;
						float num19 = (localRotation9.z = num18);
						Quaternion quaternion17 = (wheelBR.localRotation = localRotation9);
						int num20 = 0;
						Quaternion localRotation10 = wheelBL.localRotation;
						float num21 = (localRotation10.z = num20);
						Quaternion quaternion19 = (wheelBL.localRotation = localRotation10);
						int num22 = 0;
						Quaternion localRotation11 = wheelFR.localRotation;
						float num23 = (localRotation11.z = num22);
						Quaternion quaternion21 = (wheelFR.localRotation = localRotation11);
						int num24 = 0;
						Quaternion localRotation12 = wheelFL.localRotation;
						float num25 = (localRotation12.z = num24);
						Quaternion quaternion23 = (wheelFL.localRotation = localRotation12);
						int num26 = 0;
						Quaternion localRotation13 = wheelBR.localRotation;
						float num27 = (localRotation13.x = num26);
						Quaternion quaternion25 = (wheelBR.localRotation = localRotation13);
						int num28 = 0;
						Quaternion localRotation14 = wheelBL.localRotation;
						float num29 = (localRotation14.x = num28);
						Quaternion quaternion27 = (wheelBL.localRotation = localRotation14);
						int num30 = 0;
						Quaternion localRotation15 = wheelFR.localRotation;
						float num31 = (localRotation15.x = num30);
						Quaternion quaternion29 = (wheelFR.localRotation = localRotation15);
						int num32 = 0;
						Quaternion localRotation16 = wheelFL.localRotation;
						float num33 = (localRotation16.x = num32);
						Quaternion quaternion31 = (wheelFL.localRotation = localRotation16);
						int num34 = 0;
						Quaternion localRotation17 = wheelBR.localRotation;
						float num35 = (localRotation17.y = num34);
						Quaternion quaternion33 = (wheelBR.localRotation = localRotation17);
						int num36 = 0;
						Quaternion localRotation18 = wheelBL.localRotation;
						float num37 = (localRotation18.y = num36);
						Quaternion quaternion35 = (wheelBL.localRotation = localRotation18);
						int num38 = 0;
						Quaternion localRotation19 = wheelFR.localRotation;
						float num39 = (localRotation19.y = num38);
						Quaternion quaternion37 = (wheelFR.localRotation = localRotation19);
						int num40 = 0;
						Quaternion localRotation20 = wheelFL.localRotation;
						float num41 = (localRotation20.y = num40);
						Quaternion quaternion39 = (wheelFL.localRotation = localRotation20);
					}
					if (wheelBL.localRotation.z == 0f && collider1.active)
					{
						collider1.active = false;
						collider2.active = false;
					}
				}
			}
			else if (!setupsus)
			{
				resetonce = false;
				resetdone = false;
				int num42 = 2;
				if (FPMode.focusgui || ChatScript.flylock || aimanager.isAI)
				{
					if (!(maincar.rotation.eulerAngles.x <= 20f) && !(maincar.rotation.eulerAngles.x >= 180f))
					{
						num42 = 0;
					}
					else if (!(maincar.rotation.eulerAngles.x >= 340f) && !(maincar.rotation.eulerAngles.x <= 180f))
					{
						num42 = 1;
					}
				}
				if (num42 == 0 && RuntimeServices.ToBool(RuntimeServices.InvokeBinaryOperator("op_LessThan", aimanager.isAI ? ((object)aimanager.verticalInput) : ((!photonView.isMine) ? ((object)netVert) : ((!RuntimeServices.ToBool(RuntimeServices.InvokeBinaryOperator("op_GreaterThan", RuntimeServices.Invoke(typeof(Mathf), "Abs", new object[1] { UnityRuntimeServices.GetProperty(ConduitInputReciever.ht["dPad"], "y") }), 0))) ? ((object)Input.GetAxis("Vertical")) : RuntimeServices.InvokeBinaryOperator("op_Division", UnityRuntimeServices.GetProperty(ConduitInputReciever.ht["dPad"], "y"), 50f))), 0)) && photonView.isMine)
				{
					maincar.AddRelativeTorque(RuntimeServices.UnboxSingle(RuntimeServices.InvokeBinaryOperator("op_Multiply", RuntimeServices.InvokeBinaryOperator("op_Multiply", 1500000, aimanager.isAI ? ((object)aimanager.verticalInput) : ((!RuntimeServices.ToBool(RuntimeServices.InvokeBinaryOperator("op_GreaterThan", RuntimeServices.Invoke(typeof(Mathf), "Abs", new object[1] { UnityRuntimeServices.GetProperty(ConduitInputReciever.ht["dPad"], "y") }), 0))) ? ((object)Input.GetAxis("Vertical")) : RuntimeServices.InvokeBinaryOperator("op_Division", UnityRuntimeServices.GetProperty(ConduitInputReciever.ht["dPad"], "y"), 50f))), Time.deltaTime)), 0f, 0f);
				}
				if (num42 == 1 && RuntimeServices.ToBool(RuntimeServices.InvokeBinaryOperator("op_GreaterThan", aimanager.isAI ? ((object)aimanager.verticalInput) : ((!photonView.isMine) ? ((object)netVert) : ((!RuntimeServices.ToBool(RuntimeServices.InvokeBinaryOperator("op_GreaterThan", RuntimeServices.Invoke(typeof(Mathf), "Abs", new object[1] { UnityRuntimeServices.GetProperty(ConduitInputReciever.ht["dPad"], "y") }), 0))) ? ((object)Input.GetAxis("Vertical")) : RuntimeServices.InvokeBinaryOperator("op_Division", UnityRuntimeServices.GetProperty(ConduitInputReciever.ht["dPad"], "y"), 50f))), 0)) && photonView.isMine)
				{
					maincar.AddRelativeTorque(RuntimeServices.UnboxSingle(RuntimeServices.InvokeBinaryOperator("op_Multiply", RuntimeServices.InvokeBinaryOperator("op_Multiply", 1500000, aimanager.isAI ? ((object)aimanager.verticalInput) : ((!RuntimeServices.ToBool(RuntimeServices.InvokeBinaryOperator("op_GreaterThan", RuntimeServices.Invoke(typeof(Mathf), "Abs", new object[1] { UnityRuntimeServices.GetProperty(ConduitInputReciever.ht["dPad"], "y") }), 0))) ? ((object)Input.GetAxis("Vertical")) : RuntimeServices.InvokeBinaryOperator("op_Division", UnityRuntimeServices.GetProperty(ConduitInputReciever.ht["dPad"], "y"), 50f))), Time.deltaTime)), 0f, 0f);
				}
				int num43 = 2;
				if (!(maincar.rotation.eulerAngles.x <= 1.5f) && !(maincar.rotation.eulerAngles.x >= 180f))
				{
					num43 = 0;
				}
				if (!(maincar.rotation.eulerAngles.x <= -1.5f) && !(maincar.rotation.eulerAngles.x <= 180f))
				{
					num43 = 1;
				}
				if (RuntimeServices.EqualityOperator(aimanager.isAI ? ((object)aimanager.verticalInput) : ((!RuntimeServices.ToBool(RuntimeServices.InvokeBinaryOperator("op_GreaterThan", RuntimeServices.Invoke(typeof(Mathf), "Abs", new object[1] { UnityRuntimeServices.GetProperty(ConduitInputReciever.ht["dPad"], "y") }), 0))) ? ((object)Input.GetAxis("Vertical")) : RuntimeServices.InvokeBinaryOperator("op_Division", UnityRuntimeServices.GetProperty(ConduitInputReciever.ht["dPad"], "y"), 50f)), 0) && num43 == 0 && photonView.isMine)
				{
					maincar.AddRelativeTorque(1000000f * Time.deltaTime * -1f, 0f, 0f);
				}
				if (RuntimeServices.EqualityOperator(aimanager.isAI ? ((object)aimanager.verticalInput) : ((!RuntimeServices.ToBool(RuntimeServices.InvokeBinaryOperator("op_GreaterThan", RuntimeServices.Invoke(typeof(Mathf), "Abs", new object[1] { UnityRuntimeServices.GetProperty(ConduitInputReciever.ht["dPad"], "y") }), 0))) ? ((object)Input.GetAxis("Vertical")) : RuntimeServices.InvokeBinaryOperator("op_Division", UnityRuntimeServices.GetProperty(ConduitInputReciever.ht["dPad"], "y"), 50f)), 0) && num43 == 1 && photonView.isMine)
				{
					maincar.AddRelativeTorque(1000000f * Time.deltaTime, 0f, 0f);
				}
				if (num42 == 2 && photonView.isMine)
				{
					maincar.AddRelativeTorque(RuntimeServices.UnboxSingle(RuntimeServices.InvokeBinaryOperator("op_Multiply", RuntimeServices.InvokeBinaryOperator("op_Multiply", 5000000, aimanager.isAI ? ((object)aimanager.verticalInput) : ((!RuntimeServices.ToBool(RuntimeServices.InvokeBinaryOperator("op_GreaterThan", RuntimeServices.Invoke(typeof(Mathf), "Abs", new object[1] { UnityRuntimeServices.GetProperty(ConduitInputReciever.ht["dPad"], "y") }), 0))) ? ((object)Input.GetAxis("Vertical")) : RuntimeServices.InvokeBinaryOperator("op_Division", UnityRuntimeServices.GetProperty(ConduitInputReciever.ht["dPad"], "y"), 50f))), Time.deltaTime)), 0f, 0f);
				}
				int num44 = 0;
				if (RuntimeServices.ToBool(aimanager.isAI ? ((object)aimanager.verticalInput) : ((!photonView.isMine) ? ((object)netVert) : ((!RuntimeServices.ToBool(RuntimeServices.InvokeBinaryOperator("op_GreaterThan", RuntimeServices.Invoke(typeof(Mathf), "Abs", new object[1] { UnityRuntimeServices.GetProperty(ConduitInputReciever.ht["dPad"], "y") }), 0))) ? ((object)Input.GetAxis("Vertical")) : RuntimeServices.InvokeBinaryOperator("op_Division", UnityRuntimeServices.GetProperty(ConduitInputReciever.ht["dPad"], "y"), 50f)))))
				{
					num44 = 1;
				}
				if (RuntimeServices.ToBool(aimanager.isAI ? ((object)aimanager.horizontalInput) : ((!photonView.isMine) ? ((object)netHorz) : ((!RuntimeServices.ToBool(RuntimeServices.InvokeBinaryOperator("op_GreaterThan", RuntimeServices.Invoke(typeof(Mathf), "Abs", new object[1] { UnityRuntimeServices.GetProperty(ConduitInputReciever.ht["dPad"], "x") }), 0))) ? ((object)Input.GetAxis("Horizontal")) : RuntimeServices.InvokeBinaryOperator("op_Division", UnityRuntimeServices.GetProperty(ConduitInputReciever.ht["dPad"], "x"), 50f)))) && num44 == 0)
				{
					num44 = 1;
				}
				maincar.AddRelativeForce(0f, (float)(-415000 * num44) * Time.deltaTime, RuntimeServices.UnboxSingle(RuntimeServices.InvokeBinaryOperator("op_Multiply", 502400f * Time.deltaTime, aimanager.isAI ? ((object)aimanager.verticalInput) : ((!photonView.isMine) ? ((object)netVert) : ((!RuntimeServices.ToBool(RuntimeServices.InvokeBinaryOperator("op_GreaterThan", RuntimeServices.Invoke(typeof(Mathf), "Abs", new object[1] { UnityRuntimeServices.GetProperty(ConduitInputReciever.ht["dPad"], "y") }), 0))) ? ((object)Input.GetAxis("Vertical")) : RuntimeServices.InvokeBinaryOperator("op_Division", UnityRuntimeServices.GetProperty(ConduitInputReciever.ht["dPad"], "y"), 50f))))));
				int num45 = 2;
				if (!(maincar.rotation.eulerAngles.z <= 30f) && !(maincar.rotation.eulerAngles.z >= 180f))
				{
					num45 = 1;
				}
				else if (!(maincar.rotation.eulerAngles.z >= 330f) && !(maincar.rotation.eulerAngles.z <= 180f))
				{
					num45 = 0;
				}
				if (num45 == 0 && RuntimeServices.ToBool(RuntimeServices.InvokeBinaryOperator("op_LessThan", aimanager.isAI ? ((object)aimanager.horizontalInput) : ((!photonView.isMine) ? ((object)netHorz) : ((!RuntimeServices.ToBool(RuntimeServices.InvokeBinaryOperator("op_GreaterThan", RuntimeServices.Invoke(typeof(Mathf), "Abs", new object[1] { UnityRuntimeServices.GetProperty(ConduitInputReciever.ht["dPad"], "x") }), 0))) ? ((object)Input.GetAxis("Horizontal")) : RuntimeServices.InvokeBinaryOperator("op_Division", UnityRuntimeServices.GetProperty(ConduitInputReciever.ht["dPad"], "x"), 50f))), 0)) && photonView.isMine)
				{
					maincar.AddRelativeTorque(0f, 0f, 1500000f * Time.deltaTime);
				}
				if (num45 == 1 && RuntimeServices.ToBool(RuntimeServices.InvokeBinaryOperator("op_GreaterThan", aimanager.isAI ? ((object)aimanager.horizontalInput) : ((!photonView.isMine) ? ((object)netHorz) : ((!RuntimeServices.ToBool(RuntimeServices.InvokeBinaryOperator("op_GreaterThan", RuntimeServices.Invoke(typeof(Mathf), "Abs", new object[1] { UnityRuntimeServices.GetProperty(ConduitInputReciever.ht["dPad"], "x") }), 0))) ? ((object)Input.GetAxis("Horizontal")) : RuntimeServices.InvokeBinaryOperator("op_Division", UnityRuntimeServices.GetProperty(ConduitInputReciever.ht["dPad"], "x"), 50f))), 0)) && photonView.isMine)
				{
					maincar.AddRelativeTorque(0f, 0f, -1500000f * Time.deltaTime);
				}
				if (num45 == 2 && photonView.isMine)
				{
					maincar.AddRelativeTorque(0f, 0f, RuntimeServices.UnboxSingle(RuntimeServices.InvokeBinaryOperator("op_Multiply", -1500000f * Time.deltaTime, aimanager.isAI ? ((object)aimanager.horizontalInput) : ((!photonView.isMine) ? ((object)netHorz) : ((!RuntimeServices.ToBool(RuntimeServices.InvokeBinaryOperator("op_GreaterThan", RuntimeServices.Invoke(typeof(Mathf), "Abs", new object[1] { UnityRuntimeServices.GetProperty(ConduitInputReciever.ht["dPad"], "x") }), 0))) ? ((object)Input.GetAxis("Horizontal")) : RuntimeServices.InvokeBinaryOperator("op_Division", UnityRuntimeServices.GetProperty(ConduitInputReciever.ht["dPad"], "x"), 50f))))));
				}
				int num46 = 2;
				if (!(maincar.rotation.eulerAngles.z <= 1.5f) && !(maincar.rotation.eulerAngles.z >= 135f))
				{
					num46 = 0;
				}
				if (!(maincar.rotation.eulerAngles.z <= -1.5f) && !(maincar.rotation.eulerAngles.z <= 225f))
				{
					num46 = 1;
				}
				if (RuntimeServices.EqualityOperator(aimanager.isAI ? ((object)aimanager.horizontalInput) : ((!RuntimeServices.ToBool(RuntimeServices.InvokeBinaryOperator("op_GreaterThan", RuntimeServices.Invoke(typeof(Mathf), "Abs", new object[1] { UnityRuntimeServices.GetProperty(ConduitInputReciever.ht["dPad"], "x") }), 0))) ? ((object)Input.GetAxis("Horizontal")) : RuntimeServices.InvokeBinaryOperator("op_Division", UnityRuntimeServices.GetProperty(ConduitInputReciever.ht["dPad"], "x"), 50f)), 0) && num46 == 0 && photonView.isMine)
				{
					maincar.AddRelativeTorque(0f, 0f, 900000f * Time.deltaTime * -1f);
				}
				if (RuntimeServices.EqualityOperator(aimanager.isAI ? ((object)aimanager.horizontalInput) : ((!RuntimeServices.ToBool(RuntimeServices.InvokeBinaryOperator("op_GreaterThan", RuntimeServices.Invoke(typeof(Mathf), "Abs", new object[1] { UnityRuntimeServices.GetProperty(ConduitInputReciever.ht["dPad"], "x") }), 0))) ? ((object)Input.GetAxis("Horizontal")) : RuntimeServices.InvokeBinaryOperator("op_Division", UnityRuntimeServices.GetProperty(ConduitInputReciever.ht["dPad"], "x"), 50f)), 0) && num46 == 1 && photonView.isMine)
				{
					maincar.AddRelativeTorque(0f, 0f, 900000f * Time.deltaTime);
				}
				bool flag6 = false;
				if (!(maincar.rotation.eulerAngles.x >= 5f) && !(maincar.rotation.eulerAngles.x <= 0f) && RuntimeServices.EqualityOperator(aimanager.isAI ? ((object)aimanager.verticalInput) : ((!RuntimeServices.ToBool(RuntimeServices.InvokeBinaryOperator("op_GreaterThan", RuntimeServices.Invoke(typeof(Mathf), "Abs", new object[1] { UnityRuntimeServices.GetProperty(ConduitInputReciever.ht["dPad"], "y") }), 0))) ? ((object)Input.GetAxis("Vertical")) : RuntimeServices.InvokeBinaryOperator("op_Division", UnityRuntimeServices.GetProperty(ConduitInputReciever.ht["dPad"], "y"), 50f)), 0))
				{
					flag6 = true;
					if (photonView.isMine)
					{
						maincar.AddTorque(0f, RuntimeServices.UnboxSingle(RuntimeServices.InvokeBinaryOperator("op_Multiply", RuntimeServices.InvokeBinaryOperator("op_Multiply", 4500000, aimanager.isAI ? ((object)aimanager.horizontalInput) : ((!RuntimeServices.ToBool(RuntimeServices.InvokeBinaryOperator("op_GreaterThan", RuntimeServices.Invoke(typeof(Mathf), "Abs", new object[1] { UnityRuntimeServices.GetProperty(ConduitInputReciever.ht["dPad"], "x") }), 0))) ? ((object)Input.GetAxis("Horizontal")) : RuntimeServices.InvokeBinaryOperator("op_Division", UnityRuntimeServices.GetProperty(ConduitInputReciever.ht["dPad"], "x"), 50f))), Time.deltaTime)), 0f);
					}
				}
				if (!(maincar.rotation.eulerAngles.x <= 0f) && !(maincar.rotation.eulerAngles.x <= 355f) && RuntimeServices.EqualityOperator(aimanager.isAI ? ((object)aimanager.verticalInput) : ((!RuntimeServices.ToBool(RuntimeServices.InvokeBinaryOperator("op_GreaterThan", RuntimeServices.Invoke(typeof(Mathf), "Abs", new object[1] { UnityRuntimeServices.GetProperty(ConduitInputReciever.ht["dPad"], "y") }), 0))) ? ((object)Input.GetAxis("Vertical")) : RuntimeServices.InvokeBinaryOperator("op_Division", UnityRuntimeServices.GetProperty(ConduitInputReciever.ht["dPad"], "y"), 50f)), 0))
				{
					flag6 = true;
					if (photonView.isMine)
					{
						maincar.AddTorque(0f, RuntimeServices.UnboxSingle(RuntimeServices.InvokeBinaryOperator("op_Multiply", RuntimeServices.InvokeBinaryOperator("op_Multiply", 4500000, aimanager.isAI ? ((object)aimanager.horizontalInput) : ((!RuntimeServices.ToBool(RuntimeServices.InvokeBinaryOperator("op_GreaterThan", RuntimeServices.Invoke(typeof(Mathf), "Abs", new object[1] { UnityRuntimeServices.GetProperty(ConduitInputReciever.ht["dPad"], "x") }), 0))) ? ((object)Input.GetAxis("Horizontal")) : RuntimeServices.InvokeBinaryOperator("op_Division", UnityRuntimeServices.GetProperty(ConduitInputReciever.ht["dPad"], "x"), 50f))), Time.deltaTime)), 0f);
					}
				}
				if (!flag6 && photonView.isMine)
				{
					maincar.AddRelativeTorque(0f, RuntimeServices.UnboxSingle(RuntimeServices.InvokeBinaryOperator("op_Multiply", RuntimeServices.InvokeBinaryOperator("op_Multiply", 4500000, aimanager.isAI ? ((object)aimanager.horizontalInput) : ((!RuntimeServices.ToBool(RuntimeServices.InvokeBinaryOperator("op_GreaterThan", RuntimeServices.Invoke(typeof(Mathf), "Abs", new object[1] { UnityRuntimeServices.GetProperty(ConduitInputReciever.ht["dPad"], "x") }), 0))) ? ((object)Input.GetAxis("Horizontal")) : RuntimeServices.InvokeBinaryOperator("op_Division", UnityRuntimeServices.GetProperty(ConduitInputReciever.ht["dPad"], "x"), 50f))), Time.deltaTime)), 0f);
				}
				if (!hoverstart)
				{
					int num47 = 0;
					Quaternion localRotation21 = wheelBR.localRotation;
					float num48 = (localRotation21.x = num47);
					Quaternion quaternion41 = (wheelBR.localRotation = localRotation21);
					int num49 = 0;
					Quaternion localRotation22 = wheelBR.localRotation;
					float num50 = (localRotation22.y = num49);
					Quaternion quaternion43 = (wheelBR.localRotation = localRotation22);
					int num51 = 0;
					Quaternion localRotation23 = wheelBL.localRotation;
					float num52 = (localRotation23.x = num51);
					Quaternion quaternion45 = (wheelBL.localRotation = localRotation23);
					int num53 = 0;
					Quaternion localRotation24 = wheelBL.localRotation;
					float num54 = (localRotation24.y = num53);
					Quaternion quaternion47 = (wheelBL.localRotation = localRotation24);
					int num55 = 0;
					Quaternion localRotation25 = wheelFR.localRotation;
					float num56 = (localRotation25.x = num55);
					Quaternion quaternion49 = (wheelFR.localRotation = localRotation25);
					int num57 = 0;
					Quaternion localRotation26 = wheelFR.localRotation;
					float num58 = (localRotation26.y = num57);
					Quaternion quaternion51 = (wheelFR.localRotation = localRotation26);
					int num59 = 0;
					Quaternion localRotation27 = wheelFL.localRotation;
					float num60 = (localRotation27.x = num59);
					Quaternion quaternion53 = (wheelFL.localRotation = localRotation27);
					int num61 = 0;
					Quaternion localRotation28 = wheelFL.localRotation;
					float num62 = (localRotation28.y = num61);
					Quaternion quaternion55 = (wheelFL.localRotation = localRotation28);
					hoverstart = true;
					maincar.angularDrag = 4.6f;
					resetonce = false;
				}
				if (!(wheelBL.localRotation.z <= -0.71f))
				{
					int num63 = 0;
					Quaternion localRotation29 = wheelBR.localRotation;
					float num64 = (localRotation29.x = num63);
					Quaternion quaternion57 = (wheelBR.localRotation = localRotation29);
					int num65 = 0;
					Quaternion localRotation30 = wheelBL.localRotation;
					float num66 = (localRotation30.x = num65);
					Quaternion quaternion59 = (wheelBL.localRotation = localRotation30);
					int num67 = 0;
					Quaternion localRotation31 = wheelFR.localRotation;
					float num68 = (localRotation31.x = num67);
					Quaternion quaternion61 = (wheelFR.localRotation = localRotation31);
					int num69 = 0;
					Quaternion localRotation32 = wheelFL.localRotation;
					float num70 = (localRotation32.x = num69);
					Quaternion quaternion63 = (wheelFL.localRotation = localRotation32);
					wheelBR.Rotate(0f, 0f, Time.deltaTime * 80f, Space.Self);
					wheelBL.Rotate(0f, 0f, Time.deltaTime * -80f, Space.Self);
					wheelFL.Rotate(0f, 0f, Time.deltaTime * -80f, Space.Self);
					wheelFR.Rotate(0f, 0f, Time.deltaTime * 80f, Space.Self);
				}
				if (!(wheelBL.localRotation.z >= -0.71f))
				{
					float z = 0.71f;
					Quaternion localRotation33 = wheelBR.localRotation;
					float num71 = (localRotation33.z = z);
					Quaternion quaternion65 = (wheelBR.localRotation = localRotation33);
					float z2 = -0.71f;
					Quaternion localRotation34 = wheelBL.localRotation;
					float num72 = (localRotation34.z = z2);
					Quaternion quaternion67 = (wheelBL.localRotation = localRotation34);
					float z3 = 0.71f;
					Quaternion localRotation35 = wheelFR.localRotation;
					float num73 = (localRotation35.z = z3);
					Quaternion quaternion69 = (wheelFR.localRotation = localRotation35);
					float z4 = -0.71f;
					Quaternion localRotation36 = wheelFL.localRotation;
					float num74 = (localRotation36.z = z4);
					Quaternion quaternion71 = (wheelFL.localRotation = localRotation36);
					newhoverstart = true;
				}
				if (hoverstart && newhoverstart)
				{
					if (RuntimeServices.EqualityOperator(aimanager.isAI ? ((object)aimanager.horizontalInput) : ((!photonView.isMine) ? ((object)netHorz) : ((!RuntimeServices.ToBool(RuntimeServices.InvokeBinaryOperator("op_GreaterThan", RuntimeServices.Invoke(typeof(Mathf), "Abs", new object[1] { UnityRuntimeServices.GetProperty(ConduitInputReciever.ht["dPad"], "x") }), 0))) ? ((object)Input.GetAxis("Horizontal")) : RuntimeServices.InvokeBinaryOperator("op_Division", UnityRuntimeServices.GetProperty(ConduitInputReciever.ht["dPad"], "x"), 50f))), 0))
					{
						if (RuntimeServices.ToBool(RuntimeServices.InvokeBinaryOperator("op_LessThan", aimanager.isAI ? ((object)aimanager.verticalInput) : ((!photonView.isMine) ? ((object)netVert) : ((!RuntimeServices.ToBool(RuntimeServices.InvokeBinaryOperator("op_GreaterThan", RuntimeServices.Invoke(typeof(Mathf), "Abs", new object[1] { UnityRuntimeServices.GetProperty(ConduitInputReciever.ht["dPad"], "y") }), 0))) ? ((object)Input.GetAxis("Vertical")) : RuntimeServices.InvokeBinaryOperator("op_Division", UnityRuntimeServices.GetProperty(ConduitInputReciever.ht["dPad"], "y"), 50f))), 0)))
						{
							int num75 = 0;
							Quaternion localRotation37 = wheelBR.localRotation;
							float num76 = (localRotation37.x = num75);
							Quaternion quaternion73 = (wheelBR.localRotation = localRotation37);
							int num77 = 0;
							Quaternion localRotation38 = wheelBL.localRotation;
							float num78 = (localRotation38.x = num77);
							Quaternion quaternion75 = (wheelBL.localRotation = localRotation38);
							int num79 = 0;
							Quaternion localRotation39 = wheelFR.localRotation;
							float num80 = (localRotation39.x = num79);
							Quaternion quaternion77 = (wheelFR.localRotation = localRotation39);
							int num81 = 0;
							Quaternion localRotation40 = wheelFL.localRotation;
							float num82 = (localRotation40.x = num81);
							Quaternion quaternion79 = (wheelFL.localRotation = localRotation40);
							if (!(wheelBR.localRotation.y >= 0.35f))
							{
								wheelBR.Rotate(0f, Time.deltaTime * 120f, 0f, Space.Self);
							}
							if (!(wheelBL.localRotation.y <= -0.35f))
							{
								wheelBL.Rotate(0f, Time.deltaTime * -120f, 0f, Space.Self);
							}
							if (!(wheelFR.localRotation.y >= 0.35f))
							{
								wheelFR.Rotate(0f, Time.deltaTime * 120f, 0f, Space.Self);
							}
							if (!(wheelFL.localRotation.y <= -0.35f))
							{
								wheelFL.Rotate(0f, Time.deltaTime * -120f, 0f, Space.Self);
							}
						}
						if (RuntimeServices.ToBool(RuntimeServices.InvokeBinaryOperator("op_GreaterThan", aimanager.isAI ? ((object)aimanager.verticalInput) : ((!photonView.isMine) ? ((object)netVert) : ((!RuntimeServices.ToBool(RuntimeServices.InvokeBinaryOperator("op_GreaterThan", RuntimeServices.Invoke(typeof(Mathf), "Abs", new object[1] { UnityRuntimeServices.GetProperty(ConduitInputReciever.ht["dPad"], "y") }), 0))) ? ((object)Input.GetAxis("Vertical")) : RuntimeServices.InvokeBinaryOperator("op_Division", UnityRuntimeServices.GetProperty(ConduitInputReciever.ht["dPad"], "y"), 50f))), 0)))
						{
							int num83 = 0;
							Quaternion localRotation41 = wheelBR.localRotation;
							float num84 = (localRotation41.x = num83);
							Quaternion quaternion81 = (wheelBR.localRotation = localRotation41);
							int num85 = 0;
							Quaternion localRotation42 = wheelBL.localRotation;
							float num86 = (localRotation42.x = num85);
							Quaternion quaternion83 = (wheelBL.localRotation = localRotation42);
							int num87 = 0;
							Quaternion localRotation43 = wheelFR.localRotation;
							float num88 = (localRotation43.x = num87);
							Quaternion quaternion85 = (wheelFR.localRotation = localRotation43);
							int num89 = 0;
							Quaternion localRotation44 = wheelFL.localRotation;
							float num90 = (localRotation44.x = num89);
							Quaternion quaternion87 = (wheelFL.localRotation = localRotation44);
							if (!(wheelBR.localRotation.y <= -0.35f))
							{
								wheelBR.Rotate(0f, Time.deltaTime * -120f, 0f, Space.Self);
							}
							if (!(wheelBL.localRotation.y >= 0.35f))
							{
								wheelBL.Rotate(0f, Time.deltaTime * 120f, 0f, Space.Self);
							}
							if (!(wheelFR.localRotation.y <= -0.35f))
							{
								wheelFR.Rotate(0f, Time.deltaTime * -120f, 0f, Space.Self);
							}
							if (!(wheelFL.localRotation.y >= 0.35f))
							{
								wheelFL.Rotate(0f, Time.deltaTime * 120f, 0f, Space.Self);
							}
						}
					}
					if (RuntimeServices.ToBool(RuntimeServices.InvokeBinaryOperator("op_LessThan", aimanager.isAI ? ((object)aimanager.horizontalInput) : ((!photonView.isMine) ? ((object)netHorz) : ((!RuntimeServices.ToBool(RuntimeServices.InvokeBinaryOperator("op_GreaterThan", RuntimeServices.Invoke(typeof(Mathf), "Abs", new object[1] { UnityRuntimeServices.GetProperty(ConduitInputReciever.ht["dPad"], "x") }), 0))) ? ((object)Input.GetAxis("Horizontal")) : RuntimeServices.InvokeBinaryOperator("op_Division", UnityRuntimeServices.GetProperty(ConduitInputReciever.ht["dPad"], "x"), 50f))), 0)))
					{
						int num91 = 0;
						Quaternion localRotation45 = wheelBR.localRotation;
						float num92 = (localRotation45.x = num91);
						Quaternion quaternion89 = (wheelBR.localRotation = localRotation45);
						int num93 = 0;
						Quaternion localRotation46 = wheelBL.localRotation;
						float num94 = (localRotation46.x = num93);
						Quaternion quaternion91 = (wheelBL.localRotation = localRotation46);
						int num95 = 0;
						Quaternion localRotation47 = wheelFR.localRotation;
						float num96 = (localRotation47.x = num95);
						Quaternion quaternion93 = (wheelFR.localRotation = localRotation47);
						int num97 = 0;
						Quaternion localRotation48 = wheelFL.localRotation;
						float num98 = (localRotation48.x = num97);
						Quaternion quaternion95 = (wheelFL.localRotation = localRotation48);
						if (!(wheelBR.localRotation.y <= -0.35f))
						{
							wheelBR.Rotate(0f, Time.deltaTime * -120f, 0f, Space.Self);
						}
						if (!(wheelBL.localRotation.y <= -0.35f))
						{
							wheelBL.Rotate(0f, Time.deltaTime * -120f, 0f, Space.Self);
						}
						if (!(wheelFR.localRotation.y <= -0.35f))
						{
							wheelFR.Rotate(0f, Time.deltaTime * -120f, 0f, Space.Self);
						}
						if (!(wheelFL.localRotation.y <= -0.35f))
						{
							wheelFL.Rotate(0f, Time.deltaTime * -120f, 0f, Space.Self);
						}
					}
					if (RuntimeServices.ToBool(RuntimeServices.InvokeBinaryOperator("op_GreaterThan", aimanager.isAI ? ((object)aimanager.horizontalInput) : ((!photonView.isMine) ? ((object)netHorz) : ((!RuntimeServices.ToBool(RuntimeServices.InvokeBinaryOperator("op_GreaterThan", RuntimeServices.Invoke(typeof(Mathf), "Abs", new object[1] { UnityRuntimeServices.GetProperty(ConduitInputReciever.ht["dPad"], "x") }), 0))) ? ((object)Input.GetAxis("Horizontal")) : RuntimeServices.InvokeBinaryOperator("op_Division", UnityRuntimeServices.GetProperty(ConduitInputReciever.ht["dPad"], "x"), 50f))), 0)))
					{
						int num99 = 0;
						Quaternion localRotation49 = wheelBR.localRotation;
						float num100 = (localRotation49.x = num99);
						Quaternion quaternion97 = (wheelBR.localRotation = localRotation49);
						int num101 = 0;
						Quaternion localRotation50 = wheelBL.localRotation;
						float num102 = (localRotation50.x = num101);
						Quaternion quaternion99 = (wheelBL.localRotation = localRotation50);
						int num103 = 0;
						Quaternion localRotation51 = wheelFR.localRotation;
						float num104 = (localRotation51.x = num103);
						Quaternion quaternion101 = (wheelFR.localRotation = localRotation51);
						int num105 = 0;
						Quaternion localRotation52 = wheelFL.localRotation;
						float num106 = (localRotation52.x = num105);
						Quaternion quaternion103 = (wheelFL.localRotation = localRotation52);
						if (!(wheelBR.localRotation.y >= 0.35f))
						{
							wheelBR.Rotate(0f, Time.deltaTime * 120f, 0f, Space.Self);
						}
						if (!(wheelBL.localRotation.y >= 0.35f))
						{
							wheelBL.Rotate(0f, Time.deltaTime * 120f, 0f, Space.Self);
						}
						if (!(wheelFR.localRotation.y >= 0.35f))
						{
							wheelFR.Rotate(0f, Time.deltaTime * 120f, 0f, Space.Self);
						}
						if (!(wheelFL.localRotation.y >= 0.35f))
						{
							wheelFL.Rotate(0f, Time.deltaTime * 120f, 0f, Space.Self);
						}
					}
				}
				if (RuntimeServices.EqualityOperator(aimanager.isAI ? ((object)aimanager.verticalInput) : ((!photonView.isMine) ? ((object)netVert) : ((!RuntimeServices.ToBool(RuntimeServices.InvokeBinaryOperator("op_GreaterThan", RuntimeServices.Invoke(typeof(Mathf), "Abs", new object[1] { UnityRuntimeServices.GetProperty(ConduitInputReciever.ht["dPad"], "y") }), 0))) ? ((object)Input.GetAxis("Vertical")) : RuntimeServices.InvokeBinaryOperator("op_Division", UnityRuntimeServices.GetProperty(ConduitInputReciever.ht["dPad"], "y"), 50f))), 0) && RuntimeServices.EqualityOperator(aimanager.isAI ? ((object)aimanager.horizontalInput) : ((!photonView.isMine) ? ((object)netHorz) : ((!RuntimeServices.ToBool(RuntimeServices.InvokeBinaryOperator("op_GreaterThan", RuntimeServices.Invoke(typeof(Mathf), "Abs", new object[1] { UnityRuntimeServices.GetProperty(ConduitInputReciever.ht["dPad"], "x") }), 0))) ? ((object)Input.GetAxis("Horizontal")) : RuntimeServices.InvokeBinaryOperator("op_Division", UnityRuntimeServices.GetProperty(ConduitInputReciever.ht["dPad"], "x"), 50f))), 0))
				{
					bool flag7 = false;
					bool flag8 = false;
					bool flag9 = false;
					bool flag10 = false;
					if (!(wheelBR.localRotation.y <= 0f))
					{
						wheelBR.Rotate(0f, Time.deltaTime * -120f, 0f, Space.Self);
						flag7 = true;
					}
					if (!(wheelBL.localRotation.y <= 0f))
					{
						wheelBL.Rotate(0f, Time.deltaTime * -120f, 0f, Space.Self);
						flag8 = true;
					}
					if (!(wheelFR.localRotation.y <= 0f))
					{
						wheelFR.Rotate(0f, Time.deltaTime * -120f, 0f, Space.Self);
						flag9 = true;
					}
					if (!(wheelFL.localRotation.y <= 0f))
					{
						wheelFL.Rotate(0f, Time.deltaTime * -120f, 0f, Space.Self);
						flag10 = true;
					}
					if (!(wheelBR.localRotation.y >= 0f))
					{
						wheelBR.Rotate(0f, Time.deltaTime * 120f, 0f, Space.Self);
						if (flag7)
						{
							int num107 = 0;
							Quaternion localRotation53 = wheelBR.localRotation;
							float num108 = (localRotation53.y = num107);
							Quaternion quaternion105 = (wheelBR.localRotation = localRotation53);
						}
					}
					if (!(wheelBL.localRotation.y >= 0f))
					{
						wheelBL.Rotate(0f, Time.deltaTime * 120f, 0f, Space.Self);
						if (flag8)
						{
							int num109 = 0;
							Quaternion localRotation54 = wheelBL.localRotation;
							float num110 = (localRotation54.y = num109);
							Quaternion quaternion107 = (wheelBL.localRotation = localRotation54);
						}
					}
					if (!(wheelFR.localRotation.y >= 0f))
					{
						wheelFR.Rotate(0f, Time.deltaTime * 120f, 0f, Space.Self);
						if (flag9)
						{
							int num111 = 0;
							Quaternion localRotation55 = wheelFR.localRotation;
							float num112 = (localRotation55.y = num111);
							Quaternion quaternion109 = (wheelFR.localRotation = localRotation55);
						}
					}
					if (!(wheelFL.localRotation.y >= 0f))
					{
						wheelFL.Rotate(0f, Time.deltaTime * 120f, 0f, Space.Self);
						if (flag10)
						{
							int num113 = 0;
							Quaternion localRotation56 = wheelFL.localRotation;
							float num114 = (localRotation56.y = num113);
							Quaternion quaternion111 = (wheelFL.localRotation = localRotation56);
						}
					}
					flag7 = false;
					flag8 = false;
					flag9 = false;
					flag10 = false;
				}
				if (wheelBL.localRotation.z == -0.71f && !collider1.active)
				{
					collider1.active = true;
					collider2.active = true;
				}
			}
			if (setupsus)
			{
				if (!(counter <= 0f))
				{
					counter -= Time.deltaTime;
				}
				if (!(counter > 0f))
				{
					setupsus = false;
					counter = 0.2f;
				}
			}
		}
		else if (photonView.isMine && empdisable)
		{
			flame1.emit = false;
			flame2.emit = false;
			flame3.emit = false;
			flame4.emit = false;
			spark1.emit = false;
			spark2.emit = false;
			spark3.emit = false;
			spark4.emit = false;
		}
	}
}
