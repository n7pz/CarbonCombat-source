using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using Photon;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class PreloaderExplosion : Photon.MonoBehaviour
{
	[Serializable]
	internal sealed class _0024fadein_00245121 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal PreloaderExplosion _0024self__00245122;

			public _0024(PreloaderExplosion self_)
			{
				_0024self__00245122 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					result = (Yield(2, new WaitForSeconds(1f)) ? 1 : 0);
					break;
				case 2:
				case 3:
					if (_0024self__00245122.alpha < 1f)
					{
						_0024self__00245122.alpha += 4f * Time.deltaTime;
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					_0024self__00245122.alpha = 1f;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal PreloaderExplosion _0024self__00245123;

		public _0024fadein_00245121(PreloaderExplosion self_)
		{
			_0024self__00245123 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00245123);
		}
	}

	[Serializable]
	internal sealed class _0024SpawnObj_00245124 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal int _0024ran_00245125;

			internal int _0024_00242783_00245126;

			internal Quaternion _0024_00242784_00245127;

			internal Vector3 _0024_00242785_00245128;

			internal int _0024d_00245129;

			internal PreloaderExplosion _0024self__00245130;

			public _0024(int d, PreloaderExplosion self_)
			{
				_0024d_00245129 = d;
				_0024self__00245130 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					result = (Yield(2, new WaitForSeconds(_0024d_00245129)) ? 1 : 0);
					break;
				case 2:
				{
					_0024ran_00245125 = UnityEngine.Random.Range(1, 3);
					int num = (_0024_00242783_00245126 = UnityEngine.Random.Range(0, 360));
					Quaternion quaternion = (_0024_00242784_00245127 = _0024self__00245130.spawnpoint.rotation);
					Vector3 vector = (_0024_00242785_00245128 = _0024_00242784_00245127.eulerAngles);
					float num2 = (_0024_00242785_00245128.y = _0024_00242783_00245126);
					Vector3 vector2 = (_0024_00242784_00245127.eulerAngles = _0024_00242785_00245128);
					Quaternion quaternion2 = (_0024self__00245130.spawnpoint.rotation = _0024_00242784_00245127);
					if (_0024ran_00245125 == 1)
					{
						UnityEngine.Object.Instantiate(_0024self__00245130.redprefab, _0024self__00245130.spawnpoint.position, _0024self__00245130.spawnpoint.rotation);
					}
					else
					{
						UnityEngine.Object.Instantiate(_0024self__00245130.blueprefab, _0024self__00245130.spawnpoint.position, _0024self__00245130.spawnpoint.rotation);
					}
					YieldDefault(1);
					goto case 1;
				}
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal int _0024d_00245131;

		internal PreloaderExplosion _0024self__00245132;

		public _0024SpawnObj_00245124(int d, PreloaderExplosion self_)
		{
			_0024d_00245131 = d;
			_0024self__00245132 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024d_00245131, _0024self__00245132);
		}
	}

	[Serializable]
	internal sealed class _0024Start_00245133 : GenericGenerator<WWW>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WWW>, IEnumerator
		{
			internal UnityScript.Lang.Array _0024temparr_00245134;

			internal int _0024ran_00245135;

			internal bool _0024alreadyhas_00245136;

			internal string _0024item_00245137;

			internal IEnumerator _0024_0024iterator_0024350_00245138;

			internal WWW _0024www_00245139;

			internal PreloaderExplosion _0024self__00245140;

			public _0024(PreloaderExplosion self_)
			{
				_0024self__00245140 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00245140.resolutions = Screen.resolutions;
					Application.targetFrameRate = ((!Application.isWebPlayer) ? (-1) : 300);
					Application.ExternalEval("if (location.href.indexOf('kongregate') == -1) {" + "\tunityObject.getObjectById('unityPlayer').SendMessage('Main Camera', 'notKong', 'We are NOT on Kongregate');" + "}");
					_0024self__00245140.StartCoroutine_Auto(_0024self__00245140.SpawnObj(0));
					_0024temparr_00245134 = new UnityScript.Lang.Array();
					goto case 2;
				case 2:
					if (_0024temparr_00245134.length < UnityScript.Lang.Extensions.get_length((System.Array)_0024self__00245140.tips))
					{
						_0024ran_00245135 = UnityEngine.Random.Range(0, UnityScript.Lang.Extensions.get_length((System.Array)_0024self__00245140.tips));
						_0024alreadyhas_00245136 = false;
						_0024_0024iterator_0024350_00245138 = UnityRuntimeServices.GetEnumerator(_0024temparr_00245134);
						while (_0024_0024iterator_0024350_00245138.MoveNext())
						{
							object obj = _0024_0024iterator_0024350_00245138.Current;
							if (!(obj is string))
							{
								obj = RuntimeServices.Coerce(obj, typeof(string));
							}
							_0024item_00245137 = (string)obj;
							if (_0024item_00245137 == _0024self__00245140.tips[_0024ran_00245135])
							{
								_0024alreadyhas_00245136 = true;
							}
						}
						if (!_0024alreadyhas_00245136)
						{
							_0024temparr_00245134.Add(_0024self__00245140.tips[_0024ran_00245135]);
						}
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024self__00245140.tips = (string[])_0024temparr_00245134.ToBuiltin(typeof(string));
					_0024self__00245140.StartCoroutine_Auto(_0024self__00245140.startTips());
					_0024self__00245140.StartCoroutine_Auto(_0024self__00245140.fadein());
					if (!Application.isWebPlayer && Application.platform != RuntimePlatform.OSXDashboardPlayer && !Application.isEditor)
					{
						_0024www_00245139 = new WWW("http://dl.dropbox.com/u/4704910/CarbonCombatVersion.txt");
						result = (Yield(3, _0024www_00245139) ? 1 : 0);
						break;
					}
					goto IL_032a;
				case 3:
					if (string.IsNullOrEmpty(_0024www_00245139.error) && _0024www_00245139.text != string.Empty && _0024www_00245139.text.Split("\n"[0])[0] != versionNumber)
					{
						_0024self__00245140.needsUpdating = true;
						_0024self__00245140.downloadURL = _0024www_00245139.text.Split("\n"[0])[(Application.platform == RuntimePlatform.OSXEditor || Application.platform == RuntimePlatform.OSXPlayer) ? 1 : 2];
						goto case 4;
					}
					goto IL_032a;
				case 4:
					if (_0024self__00245140.updateCounter > 0f)
					{
						_0024self__00245140.updateCounter -= Time.deltaTime;
						result = (YieldDefault(4) ? 1 : 0);
						break;
					}
					Application.OpenURL(_0024self__00245140.downloadURL);
					Application.Quit();
					goto IL_032a;
				case 1:
					{
						result = 0;
						break;
					}
					IL_032a:
					_0024self__00245140.doneStart = true;
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal PreloaderExplosion _0024self__00245141;

		public _0024Start_00245133(PreloaderExplosion self_)
		{
			_0024self__00245141 = self_;
		}

		public override IEnumerator<WWW> GetEnumerator()
		{
			return new _0024(_0024self__00245141);
		}
	}

	[Serializable]
	internal sealed class _0024startTips_00245142 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal PreloaderExplosion _0024self__00245143;

			public _0024(PreloaderExplosion self_)
			{
				_0024self__00245143 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				case 2:
					if (_0024self__00245143.tipalpha < 1f)
					{
						_0024self__00245143.tipalpha += 0.5f * Time.deltaTime;
						result = (YieldDefault(2) ? 1 : 0);
					}
					else
					{
						_0024self__00245143.tipalpha = 1f;
						result = (Yield(3, new WaitForSeconds(8f)) ? 1 : 0);
					}
					break;
				case 3:
				case 4:
					if (_0024self__00245143.tipalpha > 0f)
					{
						_0024self__00245143.tipalpha -= 0.5f * Time.deltaTime;
						result = (YieldDefault(4) ? 1 : 0);
						break;
					}
					_0024self__00245143.tipalpha = 0f;
					_0024self__00245143.currenttip = ((_0024self__00245143.currenttip < UnityScript.Lang.Extensions.get_length((System.Array)_0024self__00245143.tips) - 1) ? (_0024self__00245143.currenttip + 1) : 0);
					goto default;
				default:
					if (_0024self__00245143.blackalpha < 1f)
					{
						goto case 2;
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

		internal PreloaderExplosion _0024self__00245144;

		public _0024startTips_00245142(PreloaderExplosion self_)
		{
			_0024self__00245144 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00245144);
		}
	}

	[Serializable]
	internal sealed class _0024smessagefadeout_00245145 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal PreloaderExplosion _0024self__00245146;

			public _0024(PreloaderExplosion self_)
			{
				_0024self__00245146 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__00245146.smessagealpha > 0f)
					{
						_0024self__00245146.smessagealpha -= 4f * Time.deltaTime;
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024self__00245146.smessagealpha = 0f;
					_0024self__00245146.shootmessage = false;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal PreloaderExplosion _0024self__00245147;

		public _0024smessagefadeout_00245145(PreloaderExplosion self_)
		{
			_0024self__00245147 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00245147);
		}
	}

	[Serializable]
	internal sealed class _0024initPlaysmartAPI_00245148 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					result = (Yield(2, new WaitForSeconds(2f)) ? 1 : 0);
					break;
				case 2:
					if (Input.GetKey(KeyCode.Space))
					{
						Debug.Log("PlaySmart API initialized!");
						psAPI = true;
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

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024();
		}
	}

	[Serializable]
	internal sealed class _0024fadeBlack_00245149 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal PreloaderExplosion _0024self__00245150;

			public _0024(PreloaderExplosion self_)
			{
				_0024self__00245150 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__00245150.blackalpha < 1f)
					{
						_0024self__00245150.blackalpha += 4f * Time.deltaTime;
						result = (YieldDefault(2) ? 1 : 0);
					}
					else
					{
						_0024self__00245150.blackalpha = 1f;
						result = (Yield(3, new WaitForSeconds(0.2f)) ? 1 : 0);
					}
					break;
				case 3:
				case 4:
					if (!_0024self__00245150.doneStart)
					{
						result = (YieldDefault(4) ? 1 : 0);
						break;
					}
					Application.LoadLevel("SplashScreen");
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal PreloaderExplosion _0024self__00245151;

		public _0024fadeBlack_00245149(PreloaderExplosion self_)
		{
			_0024self__00245151 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00245151);
		}
	}

	[Serializable]
	internal sealed class _0024loadlevel_00245152 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal PreloaderExplosion _0024self__00245153;

			public _0024(PreloaderExplosion self_)
			{
				_0024self__00245153 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (!_0024self__00245153.fading)
					{
						_0024self__00245153.fading = true;
						_0024self__00245153.status = "Carbon Combat Loaded!";
						result = (Yield(2, new WaitForSeconds(0.5f)) ? 1 : 0);
						break;
					}
					goto IL_0070;
				case 2:
					_0024self__00245153.StartCoroutine_Auto(_0024self__00245153.fadeBlack());
					goto IL_0070;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0070:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal PreloaderExplosion _0024self__00245154;

		public _0024loadlevel_00245152(PreloaderExplosion self_)
		{
			_0024self__00245154 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00245154);
		}
	}

	public GameObject explosion;

	public Transform spawnpoint;

	public GameObject redprefab;

	public GameObject blueprefab;

	private float alpha;

	private float mywidth;

	private float blackalpha;

	private string status;

	public GUIStyle txt;

	public Texture under;

	public Texture over;

	public GUIStyle background;

	public Texture blacktex;

	private bool fading;

	public LoadMusicDynamically loadmusic;

	public MasterServerScript mserver;

	public ConduitInputReciever cInput;

	private bool shootmessage;

	private float smessagealpha;

	public GUIStyle shootstyle;

	public string[] tips;

	public GUIStyle tipstyle;

	private int currenttip;

	private float tipalpha;

	public GUIStyle updateTxt;

	private bool needsUpdating;

	private string downloadURL;

	private float updateCounter;

	[NonSerialized]
	public static string versionNumber = "2.9.3 Beta";

	[NonSerialized]
	public static bool isKong = true;

	[NonSerialized]
	public static bool psAPI;

	[NonSerialized]
	public static string psParams = "{'userid':'09175657777','opponent':'09162225555','hashKey':'tufisusuaugsid','room':'0916vs0917','auditId':'3'}";

	[NonSerialized]
	public static string auditId = string.Empty;

	[NonSerialized]
	public static string hashKey = string.Empty;

	[NonSerialized]
	public static string myId = string.Empty;

	[NonSerialized]
	public static string otherId = string.Empty;

	[NonSerialized]
	public static bool tryConnect;

	[NonSerialized]
	public static bool wonGame;

	private bool doneStart;

	private bool fullScreenOnce;

	public Resolution[] resolutions;

	public PreloaderExplosion()
	{
		status = "Loading Carbon Combat...";
		shootmessage = true;
		smessagealpha = 1f;
		updateCounter = 5f;
	}

	public virtual IEnumerator fadein()
	{
		return new _0024fadein_00245121(this).GetEnumerator();
	}

	public virtual IEnumerator SpawnObj(int d)
	{
		return new _0024SpawnObj_00245124(d, this).GetEnumerator();
	}

	public virtual void notKong(string s)
	{
		isKong = false;
	}

	public virtual IEnumerator Start()
	{
		return new _0024Start_00245133(this).GetEnumerator();
	}

	public virtual void OnFailedToConnectToPhoton(NetworkConnectionError info)
	{
	}

	public virtual IEnumerator startTips()
	{
		return new _0024startTips_00245142(this).GetEnumerator();
	}

	public virtual void OnGUI()
	{
		if (psAPI)
		{
			psParams = GUILayout.TextField(psParams, GUILayout.Height(20f));
			string[] array = psParams.Replace("'", string.Empty).Split(","[0]);
			auditId = array[4].Split(":"[0])[1];
			hashKey = array[2].Split(":"[0])[1];
			myId = array[0].Split(":"[0])[1];
			otherId = array[1].Split(":"[0])[1];
		}
		float a = alpha;
		Color color = GUI.color;
		float num = (color.a = a);
		Color color2 = (GUI.color = color);
		GUI.Box(new Rect(0f, Screen.height - 55, Screen.width, 55f), string.Empty, background);
		GUI.Label(new Rect(15f, Screen.height - 52, 100f, 50f), status, txt);
		GUI.DrawTexture(new Rect(350f, Screen.height - 37, Screen.width - 350 - 15, 20f), under);
		float num2 = Application.GetStreamProgressForLevel("SplashScreen") * 1.7f + Application.GetStreamProgressForLevel("Menu") * 2.6f;
		if (!(Application.GetStreamProgressForLevel("SplashScreen") + Application.GetStreamProgressForLevel("Menu") < 2f) && !LoadMusicDynamically.isloading)
		{
			StartCoroutine_Auto(loadlevel());
		}
		float num3 = 0f;
		num3 = (float)(Screen.width - 350 - 15) * (num2 / 4.3f);
		mywidth = Mathf.Lerp(mywidth, num3, 1.2f * Time.deltaTime);
		GUI.DrawTexture(new Rect(350f, Screen.height - 37, mywidth, 20f), over);
		float a2 = smessagealpha;
		Color color4 = GUI.color;
		float num4 = (color4.a = a2);
		Color color5 = (GUI.color = color4);
		if (shootmessage && (!LoadMusicDynamically.isloading || LoadMusicDynamically.gotconfirm))
		{
			GUI.Box(new Rect(Screen.width / 2 - 130, Screen.height / 2 - 35 + 70, 260f, 70f), "Click to shoot the car!", shootstyle);
		}
		float a3 = tipalpha;
		Color color7 = GUI.color;
		float num5 = (color7.a = a3);
		Color color8 = (GUI.color = color7);
		GUI.Label(new Rect(20f, 15f, Screen.width - 40, 25f), tips[currenttip], tipstyle);
		float a4 = blackalpha;
		Color color10 = GUI.color;
		float num6 = (color10.a = a4);
		Color color11 = (GUI.color = color10);
		if (!(blackalpha <= 0f))
		{
			GUI.depth = -21;
		}
		GUI.DrawTexture(new Rect(0f, 0f, Screen.width, Screen.height), blacktex);
		float a5 = 1f;
		Color color13 = GUI.color;
		float num7 = (color13.a = a5);
		Color color14 = (GUI.color = color13);
		if (needsUpdating)
		{
			GUI.depth = -40;
			GUI.Box(new Rect(0f, 0f, Screen.width, Screen.height), "You are running an oudated version of Carbon Combat\nAuto-downloading the current version in " + Mathf.Round(updateCounter).ToString(), updateTxt);
		}
	}

	public virtual IEnumerator smessagefadeout()
	{
		return new _0024smessagefadeout_00245145(this).GetEnumerator();
	}

	public virtual IEnumerator initPlaysmartAPI()
	{
		return new _0024initPlaysmartAPI_00245148().GetEnumerator();
	}

	public virtual void Update()
	{
		if (!fullScreenOnce && !Screen.fullScreen && Application.absoluteURL.Contains("Conduit.unity3d"))
		{
			int num = UnityScript.Lang.Extensions.get_length((System.Array)resolutions) - 1;
			Screen.SetResolution(resolutions[num].width, resolutions[num].height, true);
			Screen.fullScreen = true;
		}
		if (Screen.fullScreen)
		{
			fullScreenOnce = true;
		}
		if ((Input.GetButtonDown("Fire1") || RuntimeServices.ToBool(ConduitInputReciever.ht["tPadState"])) && LoadMusicDynamically.alpha == 0f && LoadMusicDynamically.alpha2 == 0f)
		{
			if (RuntimeServices.ToBool(ConduitInputReciever.ht["tPadState"]))
			{
				ConduitInputReciever.ht["tPadState"] = false;
			}
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hitInfo = default(RaycastHit);
			if (Physics.Raycast(ray, out hitInfo))
			{
				Debug.DrawLine(ray.origin, hitInfo.point, Color.red);
				UnityEngine.Object.Instantiate(explosion, hitInfo.point, transform.rotation);
				if (hitInfo.transform.gameObject.name == "PreloaderRed(Clone)" || hitInfo.transform.gameObject.name == "PreloaderBlue(Clone)")
				{
					if (smessagealpha == 1f)
					{
						StartCoroutine_Auto(smessagefadeout());
					}
					hitInfo.transform.gameObject.SendMessage("DoDamage");
				}
			}
		}
		if (LoadMusicDynamically.gotconfirm && LoadMusicDynamically.isloading && !(Application.GetStreamProgressForLevel("SplashScreen") + Application.GetStreamProgressForLevel("Menu") + Application.GetStreamProgressForLevel("ChokePoint") < 3f))
		{
			status = "Loading Game Music (" + LoadMusicDynamically.perDone + "%)";
		}
		if (LoadMusicDynamically.isloading && !LoadMusicDynamically.gotconfirm && !(Application.GetStreamProgressForLevel("SplashScreen") + Application.GetStreamProgressForLevel("Menu") + Application.GetStreamProgressForLevel("ChokePoint") < 3f))
		{
			status = "Waiting for User...";
		}
	}

	public virtual IEnumerator fadeBlack()
	{
		return new _0024fadeBlack_00245149(this).GetEnumerator();
	}

	public virtual IEnumerator loadlevel()
	{
		return new _0024loadlevel_00245152(this).GetEnumerator();
	}
}
