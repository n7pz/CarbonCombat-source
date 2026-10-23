using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using Photon;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class FPSCounter : Photon.MonoBehaviour
{
	[Serializable]
	internal sealed class _0024Start_00244587 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string _0024temp_00244588;

			internal FPSCounter _0024self__00244589;

			public _0024(FPSCounter self_)
			{
				_0024self__00244589 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00244589.vigObj = (GUITexture)GameObject.Find("VigEff").GetComponent(typeof(GUITexture));
					QualitySettings.SetQualityLevel(3);
					_0024self__00244589.timeleft = _0024self__00244589.updateInterval;
					_0024temp_00244588 = PlayerPrefs.GetString("qualadjust", "auto");
					if (_0024temp_00244588 == "auto")
					{
						_0024self__00244589.autorender = true;
					}
					else
					{
						_0024self__00244589.autorender = false;
					}
					_0024self__00244589.origClip = Camera.main.farClipPlane;
					result = (YieldDefault(2) ? 1 : 0);
					break;
				case 2:
					_0024self__00244589.origFog = RenderSettings.fogDensity;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal FPSCounter _0024self__00244590;

		public _0024Start_00244587(FPSCounter self_)
		{
			_0024self__00244590 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00244590);
		}
	}

	[Serializable]
	internal sealed class _0024slidehide_00244591 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal FPSCounter _0024self__00244592;

			public _0024(FPSCounter self_)
			{
				_0024self__00244592 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (!(_0024self__00244592.xval <= -299.9f) && _0024self__00244592.hide)
					{
						_0024self__00244592.xval = Mathf.Lerp(_0024self__00244592.xval, -300f, Time.deltaTime);
						_0024self__00244592.hval = Mathf.Lerp(_0024self__00244592.hval, -1f, Time.deltaTime);
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal FPSCounter _0024self__00244593;

		public _0024slidehide_00244591(FPSCounter self_)
		{
			_0024self__00244593 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00244593);
		}
	}

	[Serializable]
	internal sealed class _0024unhide_00244594 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal FPSCounter _0024self__00244595;

			public _0024(FPSCounter self_)
			{
				_0024self__00244595 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (!(_0024self__00244595.xval >= -0.1f) && !_0024self__00244595.hide)
					{
						_0024self__00244595.xval = Mathf.Lerp(_0024self__00244595.xval, 0f, Time.deltaTime);
						_0024self__00244595.hval = Mathf.Lerp(_0024self__00244595.hval, -45f, Time.deltaTime);
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal FPSCounter _0024self__00244596;

		public _0024unhide_00244594(FPSCounter self_)
		{
			_0024self__00244596 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00244596);
		}
	}

	[Serializable]
	internal sealed class _0024unhideForce_00244597 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal FPSCounter _0024self__00244598;

			public _0024(FPSCounter self_)
			{
				_0024self__00244598 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__00244598.xval < -0.1f)
					{
						_0024self__00244598.xval = Mathf.Lerp(_0024self__00244598.xval, 0f, Time.deltaTime * 7f);
						_0024self__00244598.hval = Mathf.Lerp(_0024self__00244598.hval, -45f, Time.deltaTime * 7f);
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal FPSCounter _0024self__00244599;

		public _0024unhideForce_00244597(FPSCounter self_)
		{
			_0024self__00244599 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00244599);
		}
	}

	[Serializable]
	internal sealed class _0024flashPointer_00244600 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal FPSCounter _0024self__00244601;

			public _0024(FPSCounter self_)
			{
				_0024self__00244601 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00244601.isflashing = true;
					goto case 2;
				case 2:
					if (_0024self__00244601.pcolor != _0024self__00244601.pred)
					{
						_0024self__00244601.pcolor = Color.Lerp(_0024self__00244601.pcolor, _0024self__00244601.pred, Time.deltaTime * 10f);
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					goto case 3;
				case 3:
					if (_0024self__00244601.pcolor != Color.white)
					{
						_0024self__00244601.pcolor = Color.Lerp(_0024self__00244601.pcolor, Color.white, Time.deltaTime * 10f);
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					_0024self__00244601.isflashing = false;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal FPSCounter _0024self__00244602;

		public _0024flashPointer_00244600(FPSCounter self_)
		{
			_0024self__00244602 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00244602);
		}
	}

	private int updateInterval;

	private float accum;

	private int frames;

	private float timeleft;

	public int curFPS;

	private int qualup;

	private int qualdown;

	public GUIStyle qualityskin;

	public GUIStyle textskin;

	public GUIStyle autoskin;

	public GUIStyle manualskin;

	public GUIStyle autbuttonskin;

	public GUIStyle pointerskin;

	public Texture btex;

	private Color pcolor;

	public Color pred;

	private string autobutton;

	private int autowidth;

	private int autoheight;

	private string manualbutton1;

	private int manualwidth;

	private int manualheight;

	private string manualbutton2;

	private int otherwidth;

	private string otherbutton;

	private int otherheight;

	private bool autorender;

	public GameObject refresh;

	private string leavemessage;

	private float leavecounter;

	private bool leaveconfirm;

	private bool hideworld;

	public ChatScript src;

	private int lastnum;

	public float xval;

	public float hval;

	public bool hide;

	private bool hideminimap;

	public GameObject minimapgloss;

	private bool isflashing;

	private UnityScript.Lang.Array matarr;

	private UnityScript.Lang.Array matgobj;

	private int fasthpix;

	public GUIStyle tooltipstyle;

	private float toolalpha;

	private bool fadetool;

	public AuthGameObject authobj;

	public FadeSceneTransition fadestrans;

	public AudioController acon;

	public CalculateHealth chealth;

	public ChatScript cscript;

	public GameObject chokepointsmoke;

	public DontDestroyOnLoad ddol;

	private float origClip;

	private float origFog;

	private bool fastSettings;

	private int fasthpix2;

	private GUITexture vigObj;

	public FPSCounter()
	{
		updateInterval = 10;
		qualup = 70;
		qualdown = 35;
		pcolor = Color.white;
		autobutton = "Manually Change Quality";
		autowidth = 220;
		autoheight = 30;
		manualbutton1 = string.Empty;
		manualbutton2 = string.Empty;
		otherbutton = string.Empty;
		autorender = true;
		leavemessage = "Leave Current Game";
		leavecounter = 5f;
		hval = -45f;
		hideminimap = true;
		matarr = new UnityScript.Lang.Array();
		matgobj = new UnityScript.Lang.Array();
		fasthpix = 150;
		fastSettings = true;
		fasthpix2 = 150;
	}

	public virtual void Awake()
	{
		if (PhotonNetwork.isMasterClient)
		{
			qualdown = 50;
			qualup = 70;
		}
	}

	public virtual IEnumerator Start()
	{
		return new _0024Start_00244587(this).GetEnumerator();
	}

	public virtual IEnumerator slidehide()
	{
		return new _0024slidehide_00244591(this).GetEnumerator();
	}

	public virtual IEnumerator unhide()
	{
		return new _0024unhide_00244594(this).GetEnumerator();
	}

	public virtual IEnumerator unhideForce()
	{
		return new _0024unhideForce_00244597(this).GetEnumerator();
	}

	public virtual void Update()
	{
		if (ChatScript.minimized)
		{
			if (Input.mousePosition.x > 266f || !(Input.mousePosition.y >= (float)(Screen.height - 458)))
			{
				hide = true;
				StartCoroutine_Auto(slidehide());
			}
			if (!(Input.mousePosition.x >= 35f) && !(Input.mousePosition.y <= (float)(Screen.height - 150)))
			{
				hide = false;
				StartCoroutine_Auto(unhide());
			}
		}
		if (Input.GetKeyDown(KeyCode.Return))
		{
			hide = false;
			StartCoroutine_Auto(unhideForce());
		}
		if (fadetool)
		{
			toolalpha = Mathf.Min(1f, toolalpha + 4f * Time.deltaTime);
		}
		else
		{
			toolalpha = Mathf.Max(0f, toolalpha - 4f * Time.deltaTime);
		}
		if (QualitySettings.GetQualityLevel() == 0 || QualitySettings.GetQualityLevel() == 1)
		{
			if (minimapgloss.active)
			{
				minimapgloss.active = false;
			}
		}
		else if (!minimapgloss.active)
		{
			minimapgloss.active = true;
		}
		if (QualitySettings.GetQualityLevel() == 4 || QualitySettings.GetQualityLevel() == 5)
		{
			if (!vigObj.enabled)
			{
				vigObj.enabled = true;
			}
		}
		else if (vigObj.enabled)
		{
			vigObj.enabled = false;
		}
		if (QualitySettings.GetQualityLevel() == 0)
		{
			if (hideminimap)
			{
				hideminimap = false;
				GameObject.Find("/MinimapCam").camera.enabled = false;
				GameObject.Find("/MinimapCam/MinimapMask").renderer.enabled = false;
				GameObject.Find("/MinimapCam/Outline").renderer.enabled = false;
				if (chokepointsmoke != null && chokepointsmoke.active)
				{
					chokepointsmoke.active = false;
				}
				if ((bool)Terrain.activeTerrain)
				{
					fasthpix = (int)(Terrain.activeTerrain.heightmapPixelError - 22f);
					Terrain.activeTerrain.heightmapPixelError = 200f;
				}
				Camera.main.farClipPlane = 850f;
				Camera.main.clearFlags = CameraClearFlags.Color;
				Camera.main.backgroundColor = RenderSettings.fogColor;
				if (Application.loadedLevelName == "MainScene")
				{
				}
				setAllObjectsSimp();
			}
		}
		else if (!hideminimap)
		{
			hideminimap = true;
		}
		if (QualitySettings.GetQualityLevel() == 1)
		{
			if (fastSettings)
			{
				GameObject.Find("/MinimapCam").camera.enabled = true;
				GameObject.Find("/MinimapCam/MinimapMask").renderer.enabled = true;
				GameObject.Find("/MinimapCam/Outline").renderer.enabled = true;
				fastSettings = false;
				if (chokepointsmoke != null && chokepointsmoke.active)
				{
					chokepointsmoke.active = false;
				}
				if ((bool)Terrain.activeTerrain)
				{
					fasthpix2 = (int)(Terrain.activeTerrain.heightmapPixelError - 22f);
					Terrain.activeTerrain.heightmapPixelError = 150f;
				}
				Camera.main.farClipPlane = 1700f;
				Camera.main.clearFlags = CameraClearFlags.Color;
				Camera.main.backgroundColor = RenderSettings.fogColor;
				setAllObjectsAd();
			}
		}
		else if (!fastSettings)
		{
			fastSettings = true;
			if (QualitySettings.GetQualityLevel() != 0)
			{
				if ((bool)Terrain.activeTerrain)
				{
					Terrain.activeTerrain.heightmapPixelError = fasthpix;
				}
				if (chokepointsmoke != null && !chokepointsmoke.active)
				{
					chokepointsmoke.active = true;
				}
				Camera.main.farClipPlane = origClip;
				Camera.main.clearFlags = CameraClearFlags.Skybox;
			}
		}
		if (leaveconfirm)
		{
			float num = Mathf.Round(leavecounter);
			leavemessage = "Click to Confirm (" + num + ")";
			if (!(leavecounter <= 0f))
			{
				leavecounter -= Time.deltaTime;
			}
			else
			{
				leavecounter = 5f;
				leavemessage = "Leave Current Game";
				leaveconfirm = false;
			}
			if (!(leavecounter > 0f))
			{
				leavecounter = 5f;
				leavemessage = "Leave Current Game";
				leaveconfirm = false;
			}
		}
		timeleft -= Time.deltaTime;
		accum += Time.timeScale / Time.deltaTime;
		frames++;
		if (!(timeleft > 0f))
		{
			curFPS = (int)(accum / (float)frames);
			timeleft = updateInterval;
			accum = 0f;
			frames = 0;
			if (autorender)
			{
				if (curFPS < qualdown && QualitySettings.GetQualityLevel() != 0)
				{
					QualitySettings.DecreaseLevel();
					if ((bool)Terrain.activeTerrain)
					{
						Terrain.activeTerrain.basemapDistance = Terrain.activeTerrain.basemapDistance - 100f;
						Terrain.activeTerrain.treeDistance = Terrain.activeTerrain.treeDistance - 100f;
						Terrain.activeTerrain.treeBillboardDistance = Terrain.activeTerrain.treeBillboardDistance - 100f;
						Terrain.activeTerrain.heightmapPixelError = Terrain.activeTerrain.heightmapPixelError + 22f;
						Terrain.activeTerrain.detailObjectDistance = Terrain.activeTerrain.detailObjectDistance - 25f;
						Terrain.activeTerrain.detailObjectDensity = Terrain.activeTerrain.detailObjectDensity - 0.1f;
					}
					if (Application.loadedLevelName == "MainScene" && QualitySettings.GetQualityLevel() != 1)
					{
					}
				}
				if (curFPS > qualup && QualitySettings.GetQualityLevel() != 5)
				{
					QualitySettings.IncreaseLevel();
					if ((bool)Terrain.activeTerrain)
					{
						Terrain.activeTerrain.basemapDistance = Terrain.activeTerrain.basemapDistance + 100f;
						Terrain.activeTerrain.treeDistance = Terrain.activeTerrain.treeDistance + 100f;
						Terrain.activeTerrain.treeBillboardDistance = Terrain.activeTerrain.treeBillboardDistance + 100f;
						Terrain.activeTerrain.heightmapPixelError = Terrain.activeTerrain.heightmapPixelError - 22f;
						Terrain.activeTerrain.detailObjectDistance = Terrain.activeTerrain.detailObjectDistance + 25f;
						Terrain.activeTerrain.detailObjectDensity = Terrain.activeTerrain.detailObjectDensity + 0.1f;
					}
					if (Application.loadedLevelName == "MainScene" && QualitySettings.GetQualityLevel() != 1)
					{
					}
				}
			}
		}
		if (ChatScript.unreadstat > lastnum)
		{
			lastnum = ChatScript.unreadstat;
			if (!isflashing)
			{
				StartCoroutine_Auto(flashPointer());
			}
		}
		if (ChatScript.unreadstat == 0)
		{
			lastnum = 0;
		}
	}

	public virtual IEnumerator flashPointer()
	{
		return new _0024flashPointer_00244600(this).GetEnumerator();
	}

	public virtual void OnGUI()
	{
		if (AudioController.hideGUI)
		{
			return;
		}
		GUI.depth = -4;
		if (QualitySettings.GetQualityLevel() == 0)
		{
			GUI.Label(new Rect(Screen.width - 180, Screen.height - 90, 180f, 90f), "(Minimap disabled on the\nfastest quality setting)", textskin);
		}
		GUI.color = pcolor;
		GUI.Box(new Rect(hval, 25f, 40f, 100f), string.Empty, pointerskin);
		GUI.color = Color.white;
		GUI.BeginGroup(new Rect(xval, 0f, Screen.width, Screen.height));
		if (AuthGameObject.gametype != "Freeplay" && AuthGameObject.shop)
		{
			if (GUI.Button(new Rect(20f, 20f, 246f, 30f), leavemessage, autoskin))
			{
				if (leavemessage != "Leave Current Game")
				{
					ChatScript.isDisconnecting = true;
					hideworld = true;
					FadeSceneTransition.isfadingout = true;
					Camera.main.transform.parent = null;
					PhotonNetwork.LeaveRoom();
					PhotonNetwork.isMessageQueueRunning = true;
					PhotonNetwork.SetSendingEnabled(0, false);
					PhotonNetwork.SetSendingEnabled(8, false);
					PhotonNetwork.SetSendingEnabled(9, false);
					PhotonNetwork.SetSendingEnabled(10, false);
					if (Application.loadedLevelName == "CCWhirldScene")
					{
						Application.LoadLevel("Menu");
					}
					else
					{
						if (!(CalculateHealth.healthstat >= 40f))
						{
							int num = UnityEngine.Random.Range(0, 99999);
							int num2 = (int)Mathf.Round((1f - CalculateHealth.healthstat / 40f) * 100f);
							WWW wWW = new WWW("http://72.14.184.180/rankingsManager.php?request=submit&key=" + Md5Sum.ComputeMd5(global::DontDestroyOnLoad.hitcollider + num.ToString()) + "&user=" + AuthGameObject.username + "&score=" + num2 + "&random=" + num.ToString());
						}
						GameObject.Find("FadeSceneTrans").SendMessage("startfadeout", 1);
					}
				}
				else
				{
					leaveconfirm = true;
				}
			}
		}
		else if (GUI.Button(new Rect(20f, 20f, 246f, 30f), leavemessage, autoskin))
		{
			if (leavemessage != "Leave Current Game")
			{
				ChatScript.isDisconnecting = true;
				hideworld = true;
				Camera.main.transform.parent = null;
				PhotonNetwork.LeaveRoom();
				PhotonNetwork.isMessageQueueRunning = true;
				PhotonNetwork.SetSendingEnabled(0, false);
				PhotonNetwork.SetSendingEnabled(8, false);
				PhotonNetwork.SetSendingEnabled(9, false);
				PhotonNetwork.SetSendingEnabled(10, false);
				if (Application.loadedLevelName == "CCWhirldScene")
				{
					Application.LoadLevel("Menu");
				}
				else
				{
					GameObject.Find("FadeSceneTrans").SendMessage("startfadeout", 1);
				}
			}
			else
			{
				leaveconfirm = true;
			}
		}
		string text = null;
		text = ((!autorender) ? "Quality Setting (Manual)" : "Quality Setting (Auto)");
		if (!(Input.mousePosition.x <= 20f) && !(Input.mousePosition.x >= 266f) && !(Input.mousePosition.y >= (float)(Screen.height - 60)) && !(Input.mousePosition.y <= (float)(Screen.height - 90)))
		{
			text = QualitySettings.names[QualitySettings.GetQualityLevel()] + " (" + curFPS + " FPS)";
		}
		if (GUI.Button(new Rect(60f, 60f, 166f, 30f), text, autoskin))
		{
			if (autorender)
			{
				autorender = false;
				PlayerPrefs.SetString("qualadjust", "manual");
			}
			else
			{
				autorender = true;
				PlayerPrefs.SetString("qualadjust", "auto");
			}
		}
		if (autorender || QualitySettings.GetQualityLevel() == 0)
		{
			GUI.enabled = false;
		}
		else
		{
			GUI.enabled = true;
		}
		GUI.SetNextControlName("decrease");
		if (GUI.Button(new Rect(20f, 60f, 33f, 30f), "<<", autoskin))
		{
			if (QualitySettings.GetQualityLevel() != 0)
			{
				QualitySettings.DecreaseLevel();
				if ((bool)Terrain.activeTerrain)
				{
					Terrain.activeTerrain.basemapDistance = Terrain.activeTerrain.basemapDistance - 100f;
					Terrain.activeTerrain.treeDistance = Terrain.activeTerrain.treeDistance - 100f;
					Terrain.activeTerrain.treeBillboardDistance = Terrain.activeTerrain.treeBillboardDistance - 100f;
					Terrain.activeTerrain.heightmapPixelError = Terrain.activeTerrain.heightmapPixelError + 22f;
					Terrain.activeTerrain.detailObjectDistance = Terrain.activeTerrain.detailObjectDistance - 25f;
					Terrain.activeTerrain.detailObjectDensity = Terrain.activeTerrain.detailObjectDensity - 0.1f;
				}
				if (Application.loadedLevelName == "MainScene" && QualitySettings.GetQualityLevel() != 1)
				{
				}
			}
			else
			{
				setAllObjectsSimp();
			}
		}
		if (autorender || QualitySettings.GetQualityLevel() == 5)
		{
			GUI.enabled = false;
		}
		else
		{
			GUI.enabled = true;
		}
		GUI.SetNextControlName("increase");
		if (GUI.Button(new Rect(233f, 60f, 33f, 30f), ">>", autoskin) && QualitySettings.GetQualityLevel() != 5)
		{
			QualitySettings.IncreaseLevel();
			if ((bool)Terrain.activeTerrain)
			{
				Terrain.activeTerrain.basemapDistance = Terrain.activeTerrain.basemapDistance + 100f;
				Terrain.activeTerrain.treeDistance = Terrain.activeTerrain.treeDistance + 100f;
				Terrain.activeTerrain.treeBillboardDistance = Terrain.activeTerrain.treeBillboardDistance + 100f;
				Terrain.activeTerrain.heightmapPixelError = Terrain.activeTerrain.heightmapPixelError - 22f;
				Terrain.activeTerrain.detailObjectDistance = Terrain.activeTerrain.detailObjectDistance + 25f;
				Terrain.activeTerrain.detailObjectDensity = Terrain.activeTerrain.detailObjectDensity + 0.1f;
			}
			if (Application.loadedLevelName == "MainScene" && QualitySettings.GetQualityLevel() != 1)
			{
			}
		}
		GUI.enabled = true;
		if (hideworld && Application.loadedLevelName == "CCWhirldScene")
		{
			GUI.depth = -9;
			GUI.DrawTexture(new Rect(0f, 0f, Screen.width, Screen.height), btex);
		}
		GUI.enabled = true;
		GUI.EndGroup();
		if (GUI.tooltip != string.Empty)
		{
			fadetool = true;
		}
		else
		{
			fadetool = false;
		}
		float a = toolalpha;
		Color color = GUI.color;
		float num3 = (color.a = a);
		Color color2 = (GUI.color = color);
		GUI.Label(new Rect(Mathf.Min(Input.mousePosition.x, Screen.width - 324), Mathf.Min((float)Screen.height - Input.mousePosition.y + 15f, Screen.height - 70), 324f, 70f), GUI.tooltip, tooltipstyle);
	}

	public virtual void setAllObjectsSimp()
	{
		Renderer[] array = ((Renderer[])UnityEngine.Object.FindObjectsOfType(typeof(Renderer))) as Renderer[];
		int i = 0;
		Renderer[] array2 = array;
		for (int length = array2.Length; i < length; i++)
		{
			if (!((WheelAlignment_Script)array2[i].gameObject.GetComponent(typeof(WheelAlignment_Script)) == null))
			{
				continue;
			}
			bool flag = false;
			IEnumerator enumerator = UnityRuntimeServices.GetEnumerator(matgobj);
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				if (!(obj is GameObject))
				{
					obj = RuntimeServices.Coerce(obj, typeof(GameObject));
				}
				GameObject gameObject = (GameObject)obj;
				if (gameObject == array2[i].gameObject)
				{
					flag = true;
				}
			}
			int num = 0;
			Material[] materials = array2[i].materials;
			int j = 0;
			Material[] array3 = materials;
			for (int length2 = array3.Length; j < length2; j++)
			{
				if (array3[j].shader.name == "Transparent/GlassShiny")
				{
					if (!flag)
					{
						matarr.Add(array2[i].gameObject.name + "!" + num + "!" + array3[j].shader.name + "!" + array3[j].color.ToString() + "!" + "1337");
						matgobj.Add(array2[i].gameObject);
					}
					array3[j].shader = Shader.Find("Transparent/Diffuse");
					array3[j].SetFloat("_Shininess", 0.35f);
				}
				if (array3[j].shader.name == "CarbonPaint")
				{
					if (!flag)
					{
						matarr.Add(array2[i].gameObject.name + "!" + num + "!" + array3[j].shader.name + "!" + array3[j].color.ToString() + "!" + "1337");
						matgobj.Add(array2[i].gameObject);
					}
					array3[j].shader = Shader.Find("VertexLit");
				}
				if (array3[j].shader.name.Contains("Reflective/") || array3[j].shader.name == "FX/Diamond")
				{
					if (!flag)
					{
						if (array3[j].shader.name.Contains("Specular"))
						{
							matarr.Add(array2[i].gameObject.name + "!" + num + "!" + array3[j].shader.name + "!" + array3[j].color.ToString() + "!" + array3[j].GetFloat("_Shininess"));
						}
						else
						{
							matarr.Add(array2[i].gameObject.name + "!" + num + "!" + array3[j].shader.name + "!" + array3[j].color.ToString() + "!" + "1337");
						}
						matgobj.Add(array2[i].gameObject);
					}
					if (array3[j].HasProperty("_ReflectColor"))
					{
						Color color = Color.Lerp(array3[j].color, array3[j].GetColor("_ReflectColor"), 0.85f);
						array3[j].color = color;
					}
					array3[j].shader = Shader.Find("VertexLit");
					array3[j].SetFloat("_Shininess", 0.35f);
				}
				num++;
			}
			array2[i].materials = materials;
			num = 0;
		}
	}

	public virtual void preSetAllObj()
	{
		Renderer[] array = ((Renderer[])UnityEngine.Object.FindObjectsOfType(typeof(Renderer))) as Renderer[];
		int i = 0;
		Renderer[] array2 = array;
		for (int length = array2.Length; i < length; i++)
		{
			if (!((WheelAlignment_Script)array2[i].gameObject.GetComponent(typeof(WheelAlignment_Script)) == null))
			{
				continue;
			}
			bool flag = false;
			IEnumerator enumerator = UnityRuntimeServices.GetEnumerator(matgobj);
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				if (!(obj is GameObject))
				{
					obj = RuntimeServices.Coerce(obj, typeof(GameObject));
				}
				GameObject gameObject = (GameObject)obj;
				if (gameObject == array2[i].gameObject)
				{
					flag = true;
				}
			}
			int num = 0;
			Material[] materials = array2[i].materials;
			int j = 0;
			Material[] array3 = materials;
			for (int length2 = array3.Length; j < length2; j++)
			{
				if (array3[j].shader.name == "Transparent/GlassShiny" && !flag)
				{
					matarr.Add(array2[i].gameObject.name + "!" + num + "!" + array3[j].shader.name + "!" + array3[j].color.ToString() + "!" + "1337");
					matgobj.Add(array2[i].gameObject);
				}
				if (array3[j].shader.name == "CarbonPaint" && !flag)
				{
					matarr.Add(array2[i].gameObject.name + "!" + num + "!" + array3[j].shader.name + "!" + array3[j].color.ToString() + "!" + "1337");
					matgobj.Add(array2[i].gameObject);
				}
				if (array3[j].shader.name.Contains("Reflective/") || array3[j].shader.name == "FX/Diamond")
				{
					if (!flag)
					{
						if (array3[j].shader.name.Contains("Specular"))
						{
							matarr.Add(array2[i].gameObject.name + "!" + num + "!" + array3[j].shader.name + "!" + array3[j].color.ToString() + "!" + array3[j].GetFloat("_Shininess"));
						}
						else
						{
							matarr.Add(array2[i].gameObject.name + "!" + num + "!" + array3[j].shader.name + "!" + array3[j].color.ToString() + "!" + "1337");
						}
						matgobj.Add(array2[i].gameObject);
					}
					if (!array3[j].HasProperty("_ReflectColor"))
					{
					}
				}
				num++;
			}
			array2[i].materials = materials;
			num = 0;
		}
	}

	public virtual void setAllObjectsAd()
	{
		int num = 0;
		Renderer[] array = ((Renderer[])UnityEngine.Object.FindObjectsOfType(typeof(Renderer))) as Renderer[];
		IEnumerator enumerator = UnityRuntimeServices.GetEnumerator(matarr);
		while (enumerator.MoveNext())
		{
			object obj = enumerator.Current;
			if (!(obj is string))
			{
				obj = RuntimeServices.Coerce(obj, typeof(string));
			}
			string text = (string)obj;
			string[] array2 = text.Split("!"[0]);
			UnityRuntimeServices.Update(enumerator, text);
			int i = 0;
			Renderer[] array3 = array;
			for (int length = array3.Length; i < length; i++)
			{
				if (RuntimeServices.EqualityOperator(array3[i].gameObject, matgobj[num]) && UnityScript.Lang.Extensions.get_length((System.Array)array3[i].materials) > UnityBuiltins.parseInt(array2[1]))
				{
					Material material = array3[i].materials[UnityBuiltins.parseInt(array2[1])];
					material.shader = Shader.Find(array2[2]);
					string text2 = array2[3];
					text2 = text2.Replace("RGBA(", string.Empty);
					text2 = text2.Replace(")", string.Empty);
					string[] array4 = text2.Split(","[0]);
					Color color = new Color(UnityBuiltins.parseFloat(array4[0]), UnityBuiltins.parseFloat(array4[1]), UnityBuiltins.parseFloat(array4[2]), UnityBuiltins.parseFloat(array4[3]));
					material.color = color;
					if (UnityBuiltins.parseFloat(array2[4]) != 1337f)
					{
						material.SetFloat("_Shininess", UnityBuiltins.parseFloat(array2[4]));
					}
					array3[i].materials[UnityBuiltins.parseInt(array2[1])] = material;
				}
			}
			num++;
		}
	}
}
