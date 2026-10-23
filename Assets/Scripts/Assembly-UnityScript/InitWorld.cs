using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using Photon;
using UnityEngine;

[Serializable]
public class InitWorld : Photon.MonoBehaviour
{
	[Serializable]
	internal sealed class _0024ExitScene_00244028 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal InitWorld _0024self__00244029;

			public _0024(InitWorld self_)
			{
				_0024self__00244029 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					GameObject.Find("WhirldIn").active = false;
					FadeSceneTransition.isfadingout = true;
					_0024self__00244029.status = "Map Loading Canceled";
					result = (Yield(2, new WaitForSeconds(0.7f)) ? 1 : 0);
					break;
				case 2:
					PhotonNetwork.LeaveRoom();
					if (PhotonNetwork.isMasterClient)
					{
						MasterServer.UnregisterHost();
					}
					Screen.showCursor = true;
					PhotonNetwork.isMessageQueueRunning = true;
					PhotonNetwork.SetSendingEnabled(0, true);
					PhotonNetwork.SetSendingEnabled(10, true);
					PhotonNetwork.SetReceivingEnabled(0, true);
					PhotonNetwork.SetReceivingEnabled(10, true);
					Application.LoadLevel("Menu");
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal InitWorld _0024self__00244030;

		public _0024ExitScene_00244028(InitWorld self_)
		{
			_0024self__00244030 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00244030);
		}
	}

	[Serializable]
	internal sealed class _0024fadeIn_00244031 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal InitWorld _0024self__00244032;

			public _0024(InitWorld self_)
			{
				_0024self__00244032 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__00244032.alpha2 < 1f)
					{
						_0024self__00244032.alpha2 += 1.5f * Time.deltaTime;
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024self__00244032.alpha2 = 1f;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal InitWorld _0024self__00244033;

		public _0024fadeIn_00244031(InitWorld self_)
		{
			_0024self__00244033 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00244033);
		}
	}

	[Serializable]
	internal sealed class _0024FadeOut_00244034 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal InitWorld _0024self__00244035;

			public _0024(InitWorld self_)
			{
				_0024self__00244035 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					result = (Yield(2, new WaitForSeconds(1.5f)) ? 1 : 0);
					break;
				case 2:
					finaldone = true;
					_0024self__00244035.status = "Map Successfully Loaded!";
					goto case 3;
				case 3:
					if (_0024self__00244035.alpha2 < 1f)
					{
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					Debug.Log("Before yield");
					result = (Yield(4, new WaitForSeconds(1f)) ? 1 : 0);
					break;
				case 4:
					Debug.Log("After yield");
					goto case 5;
				case 5:
					if (_0024self__00244035.alpha > 0f)
					{
						_0024self__00244035.alpha -= 1.5f * Time.deltaTime;
						_0024self__00244035.alpha2 = _0024self__00244035.alpha;
						result = (YieldDefault(5) ? 1 : 0);
						break;
					}
					_0024self__00244035.alpha = 0f;
					_0024self__00244035.alpha2 = 0f;
					Debug.Log("afterfade");
					_0024self__00244035.gameObject.active = false;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal InitWorld _0024self__00244036;

		public _0024FadeOut_00244034(InitWorld self_)
		{
			_0024self__00244036 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00244036);
		}
	}

	private float alpha;

	private float alpha2;

	public GUIStyle tex;

	private string status;

	[NonSerialized]
	public static bool doneloading;

	[NonSerialized]
	public static bool finaldone;

	public GameObject wip;

	public WhirldIn win;

	public FadeSceneTransition fadescenetrans;

	private int percent;

	private float fakePercent;

	private bool once;

	[NonSerialized]
	public static float assetLoad;

	[NonSerialized]
	public static float sceneLoad;

	[NonSerialized]
	public static float textureLoad;

	[NonSerialized]
	public static float meshLoad;

	[NonSerialized]
	public static float meshtextureLoad;

	[NonSerialized]
	public static float terrainLoad;

	[NonSerialized]
	public static float skyboxLoad;

	[NonSerialized]
	public static int loadCount;

	public InitWorld()
	{
		alpha = 1f;
		status = string.Empty;
	}

	public virtual IEnumerator ExitScene()
	{
		return new _0024ExitScene_00244028(this).GetEnumerator();
	}

	public virtual void WhirldFail()
	{
		GameObject.Find("WhirldIn").active = false;
		status = "Map Loading Failed!";
		if (!RuntimeServices.EqualityOperator(PhotonNetwork.room, null))
		{
			PhotonNetwork.LeaveRoom();
		}
		Screen.showCursor = true;
		Application.LoadLevel("Menu");
	}

	public virtual IEnumerator fadeIn()
	{
		return new _0024fadeIn_00244031(this).GetEnumerator();
	}

	public virtual void perc(int p)
	{
		percent = p;
	}

	public virtual IEnumerator FadeOut()
	{
		return new _0024FadeOut_00244034(this).GetEnumerator();
	}

	public virtual void dloading()
	{
		status = "Importing Game Structure (" + percent + "%)...\nPress [b] to go back to the main menu.";
		wip.active = true;
		doneloading = true;
	}

	public virtual void OnGUI()
	{
		GUI.depth = -11;
		float a = alpha;
		Color color = GUI.color;
		float num = (color.a = a);
		Color color2 = (GUI.color = color);
		GUI.Box(new Rect(0f, 0f, Screen.width, Screen.height), string.Empty, tex);
		float a2 = alpha2;
		Color color4 = GUI.color;
		float num2 = (color4.a = a2);
		Color color5 = (GUI.color = color4);
		GUI.Box(new Rect(0f, 0f, Screen.width, Screen.height), status, tex);
	}

	public virtual void Awake()
	{
		doneloading = false;
		finaldone = false;
		assetLoad = 0f;
		sceneLoad = 0f;
		textureLoad = 0f;
		meshLoad = 0f;
		meshtextureLoad = 0f;
		terrainLoad = 0f;
		skyboxLoad = 0f;
		loadCount = 0;
	}

	public virtual void Start()
	{
		StartCoroutine_Auto(fadeIn());
	}

	public virtual void Update()
	{
		if (!once && (WhirldIn.status == WhirldInStatus.WWWError || WhirldIn.status == WhirldInStatus.SyntaxError))
		{
			once = true;
			WhirldFail();
		}
		if (Input.GetKeyDown("b"))
		{
			StartCoroutine_Auto(ExitScene());
		}
		if (!finaldone)
		{
			if (!doneloading)
			{
				float f = (assetLoad + sceneLoad + textureLoad + meshLoad + meshtextureLoad + terrainLoad + skyboxLoad) / (float)loadCount * 100f;
				status = "Loading Map Data Files (" + Mathf.Round(f).ToString() + "%)...\nPress [b] to go back to the main menu.";
			}
			else
			{
				fakePercent = Mathf.Lerp(fakePercent, percent, 4f * Time.deltaTime);
				status = "Importing Game Structure (" + Mathf.Round(fakePercent) + "%)...\nPress [b] to go back to the main menu.";
			}
		}
	}

	public virtual void Main()
	{
	}
}
