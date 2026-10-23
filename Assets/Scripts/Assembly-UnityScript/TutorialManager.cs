using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using Photon;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class TutorialManager : Photon.MonoBehaviour
{
	[Serializable]
	public class TutObj
	{
		public string message;

		public UnityScript.Lang.Array controlArray;

		public UnityScript.Lang.Array objEnable;

		public UnityScript.Lang.Array objDisable;

		public TutObj(string message, UnityScript.Lang.Array controlArray, UnityScript.Lang.Array objEnable, UnityScript.Lang.Array objDisable)
		{
			this.message = message;
			this.controlArray = controlArray;
			this.objEnable = objEnable;
			this.objDisable = objDisable;
		}
	}

	[Serializable]
	internal sealed class _0024Start_00245785 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal GameObject _0024obj_00245786;

			internal TutObj _0024newTObj_00245787;

			internal UnityScript.Lang.Array _0024cArr_00245788;

			internal UnityScript.Lang.Array _0024oEn_00245789;

			internal UnityScript.Lang.Array _0024oDis_00245790;

			internal IEnumerator _0024_0024iterator_00243010_00245791;

			internal IEnumerator _0024_0024iterator_00243011_00245792;

			internal TutorialManager _0024self__00245793;

			public _0024(TutorialManager self_)
			{
				_0024self__00245793 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (!AuthGameObject.showTutorial)
					{
						_0024self__00245793.enabled = false;
					}
					else
					{
						_0024obj_00245786 = null;
						_0024_0024iterator_00243010_00245791 = _0024self__00245793.tutorialObjects.GetEnumerator();
						while (_0024_0024iterator_00243010_00245791.MoveNext())
						{
							object obj = _0024_0024iterator_00243010_00245791.Current;
							if (!(obj is GameObject))
							{
								obj = RuntimeServices.Coerce(obj, typeof(GameObject));
							}
							_0024obj_00245786 = (GameObject)obj;
							_0024obj_00245786.active = true;
						}
						_0024_0024iterator_00243011_00245792 = _0024self__00245793.nonTutorialObjects.GetEnumerator();
						while (_0024_0024iterator_00243011_00245792.MoveNext())
						{
							object obj2 = _0024_0024iterator_00243011_00245792.Current;
							if (!(obj2 is GameObject))
							{
								obj2 = RuntimeServices.Coerce(obj2, typeof(GameObject));
							}
							_0024obj_00245786 = (GameObject)obj2;
							_0024obj_00245786.active = false;
						}
					}
					goto case 2;
				case 2:
					if (!AIspawned)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024newTObj_00245787 = null;
					_0024cArr_00245788 = null;
					_0024oEn_00245789 = null;
					_0024oDis_00245790 = null;
					_0024cArr_00245788 = new UnityScript.Lang.Array(false, false, false);
					_0024oEn_00245789 = new UnityScript.Lang.Array();
					_0024oDis_00245790 = new UnityScript.Lang.Array(bots[0]);
					_0024newTObj_00245787 = new TutObj("Welcome to the Carbon Combat tutorial!\nIt shouldn't take more than 5 minutes to complete, so bear with me here ;)\n(Click to continue)", _0024cArr_00245788, _0024oEn_00245789, _0024oDis_00245790);
					tutorialArr.Add(_0024newTObj_00245787);
					_0024cArr_00245788 = new UnityScript.Lang.Array(true, false, false);
					_0024oEn_00245789 = new UnityScript.Lang.Array();
					_0024oDis_00245790 = new UnityScript.Lang.Array();
					_0024newTObj_00245787 = new TutObj("Use WASD to move to that enemy car.", _0024cArr_00245788, _0024oEn_00245789, _0024oDis_00245790);
					tutorialArr.Add(_0024newTObj_00245787);
					_0024cArr_00245788 = new UnityScript.Lang.Array(false, false, true);
					_0024oEn_00245789 = new UnityScript.Lang.Array();
					_0024oDis_00245790 = new UnityScript.Lang.Array();
					_0024newTObj_00245787 = new TutObj("Use your mouse to aim and click to fire at the enemy car.", _0024cArr_00245788, _0024oEn_00245789, _0024oDis_00245790);
					tutorialArr.Add(_0024newTObj_00245787);
					_0024cArr_00245788 = new UnityScript.Lang.Array(false, false, true);
					_0024oEn_00245789 = new UnityScript.Lang.Array();
					_0024oDis_00245790 = new UnityScript.Lang.Array();
					_0024newTObj_00245787 = new TutObj("Now press and hold shift to scope and fire at the other enemy car.", _0024cArr_00245788, _0024oEn_00245789, _0024oDis_00245790);
					tutorialArr.Add(_0024newTObj_00245787);
					_0024cArr_00245788 = new UnityScript.Lang.Array(true, true, true);
					_0024oEn_00245789 = new UnityScript.Lang.Array();
					_0024oDis_00245790 = new UnityScript.Lang.Array();
					_0024newTObj_00245787 = new TutObj("Press and hold space to fly up (whee).", _0024cArr_00245788, _0024oEn_00245789, _0024oDis_00245790);
					tutorialArr.Add(_0024newTObj_00245787);
					_0024cArr_00245788 = new UnityScript.Lang.Array(true, true, true);
					_0024oEn_00245789 = new UnityScript.Lang.Array(_0024self__00245793.nonTutorialObjects[4]);
					_0024oDis_00245790 = new UnityScript.Lang.Array();
					_0024newTObj_00245787 = new TutObj("Try and fly through these hoops.", _0024cArr_00245788, _0024oEn_00245789, _0024oDis_00245790);
					tutorialArr.Add(_0024newTObj_00245787);
					_0024cArr_00245788 = new UnityScript.Lang.Array(true, true, true);
					_0024oEn_00245789 = new UnityScript.Lang.Array();
					_0024oDis_00245790 = new UnityScript.Lang.Array();
					_0024newTObj_00245787 = new TutObj("Press 2 or [e] to switch to your Plasma Blaster (fully automatic).\nTry and hit the enemy car while flying!", _0024cArr_00245788, _0024oEn_00245789, _0024oDis_00245790);
					tutorialArr.Add(_0024newTObj_00245787);
					_0024cArr_00245788 = new UnityScript.Lang.Array(true, true, true);
					_0024oEn_00245789 = new UnityScript.Lang.Array();
					_0024oDis_00245790 = new UnityScript.Lang.Array(_0024self__00245793.tutorialObjects[0]);
					_0024newTObj_00245787 = new TutObj("Good! Looks like you're ready to take on some real bots. Finish them both!", _0024cArr_00245788, _0024oEn_00245789, _0024oDis_00245790);
					tutorialArr.Add(_0024newTObj_00245787);
					_0024cArr_00245788 = new UnityScript.Lang.Array(true, true, true);
					_0024oEn_00245789 = new UnityScript.Lang.Array(_0024self__00245793.nonTutorialObjects[0]);
					_0024oDis_00245790 = new UnityScript.Lang.Array();
					_0024newTObj_00245787 = new TutObj("Oh no, you took damage. Get to the red health pickup to regenerate some health.", _0024cArr_00245788, _0024oEn_00245789, _0024oDis_00245790);
					tutorialArr.Add(_0024newTObj_00245787);
					_0024cArr_00245788 = new UnityScript.Lang.Array(true, true, true);
					_0024oEn_00245789 = new UnityScript.Lang.Array();
					_0024oDis_00245790 = new UnityScript.Lang.Array();
					_0024newTObj_00245787 = new TutObj("Good job! You earned 50 credits from destroying all of the bots. Get more by playing against other players.\n(Click to continue)", _0024cArr_00245788, _0024oEn_00245789, _0024oDis_00245790);
					tutorialArr.Add(_0024newTObj_00245787);
					_0024cArr_00245788 = new UnityScript.Lang.Array(true, true, true);
					_0024oEn_00245789 = new UnityScript.Lang.Array();
					_0024oDis_00245790 = new UnityScript.Lang.Array();
					_0024newTObj_00245787 = new TutObj("Credits can be used to purchase epic weapons and armors and items in the store.\n(Click to continue)", _0024cArr_00245788, _0024oEn_00245789, _0024oDis_00245790);
					tutorialArr.Add(_0024newTObj_00245787);
					_0024cArr_00245788 = new UnityScript.Lang.Array(true, true, true);
					_0024oEn_00245789 = new UnityScript.Lang.Array();
					_0024oDis_00245790 = new UnityScript.Lang.Array();
					_0024newTObj_00245787 = new TutObj("Oh, before I forget, only registered players are able to earn credits and get items (registering is *free*) :)\n(Click to continue)", _0024cArr_00245788, _0024oEn_00245789, _0024oDis_00245790);
					tutorialArr.Add(_0024newTObj_00245787);
					_0024cArr_00245788 = new UnityScript.Lang.Array(true, true, true);
					_0024oEn_00245789 = new UnityScript.Lang.Array();
					_0024oDis_00245790 = new UnityScript.Lang.Array();
					_0024newTObj_00245787 = new TutObj("That's it! You now know all the basics of Carbon Combat. If you have any other questions you can ask the helpful community.\n(Click to end tutorial)", _0024cArr_00245788, _0024oEn_00245789, _0024oDis_00245790);
					tutorialArr.Add(_0024newTObj_00245787);
					((AIManager)bots[1].GetComponent(typeof(AIManager))).hideBadge = true;
					((AIManager)bots[2].GetComponent(typeof(AIManager))).hideBadge = true;
					_0024self__00245793.StartCoroutine_Auto(_0024self__00245793.startTutorial());
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal TutorialManager _0024self__00245794;

		public _0024Start_00245785(TutorialManager self_)
		{
			_0024self__00245794 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00245794);
		}
	}

	[Serializable]
	internal sealed class _0024sendCredits_00245795 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal WWW _0024getKey_00245796;

			internal WWW _0024bitem_00245797;

			internal TutorialManager _0024self__00245798;

			public _0024(TutorialManager self_)
			{
				_0024self__00245798 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024getKey_00245796 = new WWW(_0024self__00245798.keyGen + "username=" + Md5Sum.ComputeMd5(AuthGameObject.username + global::DontDestroyOnLoad.hitcollider));
					result = (Yield(2, _0024getKey_00245796) ? 1 : 0);
					break;
				case 2:
					_0024bitem_00245797 = new WWW(_0024self__00245798.storeInterface + "username=" + AuthGameObject.username + "&request=addcreds" + "&serverkey=" + Md5Sum.ComputeMd5(_0024getKey_00245796.text + global::DontDestroyOnLoad.hitcollider) + "&changeto=50");
					result = (Yield(3, _0024bitem_00245797) ? 1 : 0);
					break;
				case 3:
					if (string.IsNullOrEmpty(_0024bitem_00245797.error) && _0024bitem_00245797.text.Contains("updated"))
					{
						goto case 1;
					}
					result = (Yield(4, new WaitForSeconds(5f)) ? 1 : 0);
					break;
				case 4:
					_0024getKey_00245796 = new WWW(_0024self__00245798.keyGen + "username=" + Md5Sum.ComputeMd5(AuthGameObject.username + global::DontDestroyOnLoad.hitcollider));
					result = (Yield(5, _0024getKey_00245796) ? 1 : 0);
					break;
				case 5:
					_0024bitem_00245797 = new WWW(_0024self__00245798.storeInterface + "username=" + AuthGameObject.username + "&request=addcreds" + "&serverkey=" + Md5Sum.ComputeMd5(_0024getKey_00245796.text + global::DontDestroyOnLoad.hitcollider) + "&changeto=50");
					result = (Yield(6, _0024bitem_00245797) ? 1 : 0);
					break;
				case 6:
					if (string.IsNullOrEmpty(_0024bitem_00245797.error) && !_0024bitem_00245797.text.Contains("updated"))
					{
					}
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal TutorialManager _0024self__00245799;

		public _0024sendCredits_00245795(TutorialManager self_)
		{
			_0024self__00245799 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00245799);
		}
	}

	[Serializable]
	internal sealed class _0024startTutorial_00245800 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal GameObject _0024obj_00245801;

			internal IEnumerator _0024_0024iterator_0024264_00245802;

			internal IEnumerator _0024_0024iterator_0024265_00245803;

			internal TutorialManager _0024self__00245804;

			public _0024(TutorialManager self_)
			{
				_0024self__00245804 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024obj_00245801 = null;
					curTutIndex = 0;
					goto IL_0211;
				case 2:
					if (_0024self__00245804.alpha < 1f)
					{
						_0024self__00245804.alpha = Mathf.Min(1f, _0024self__00245804.alpha + 4f * Time.deltaTime);
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					goto case 3;
				case 3:
					if (!_0024self__00245804.nextOne)
					{
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					_0024self__00245804.nextOne = false;
					curTutIndex++;
					goto IL_0211;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0211:
					if (curTutIndex < tutorialArr.length)
					{
						object obj = UnityRuntimeServices.GetProperty(tutorialArr[curTutIndex], "controlArray");
						if (!(obj is UnityScript.Lang.Array))
						{
							obj = RuntimeServices.Coerce(obj, typeof(UnityScript.Lang.Array));
						}
						curCArr = (UnityScript.Lang.Array)obj;
						_0024_0024iterator_0024264_00245802 = UnityRuntimeServices.GetEnumerator(UnityRuntimeServices.GetProperty(tutorialArr[curTutIndex], "objEnable"));
						while (_0024_0024iterator_0024264_00245802.MoveNext())
						{
							object obj2 = _0024_0024iterator_0024264_00245802.Current;
							if (!(obj2 is GameObject))
							{
								obj2 = RuntimeServices.Coerce(obj2, typeof(GameObject));
							}
							_0024obj_00245801 = (GameObject)obj2;
							_0024obj_00245801.SetActiveRecursively(true);
							UnityRuntimeServices.Update(_0024_0024iterator_0024264_00245802, _0024obj_00245801);
						}
						_0024_0024iterator_0024265_00245803 = UnityRuntimeServices.GetEnumerator(UnityRuntimeServices.GetProperty(tutorialArr[curTutIndex], "objDisable"));
						while (_0024_0024iterator_0024265_00245803.MoveNext())
						{
							object obj3 = _0024_0024iterator_0024265_00245803.Current;
							if (!(obj3 is GameObject))
							{
								obj3 = RuntimeServices.Coerce(obj3, typeof(GameObject));
							}
							_0024obj_00245801 = (GameObject)obj3;
							_0024obj_00245801.SetActiveRecursively(false);
							UnityRuntimeServices.Update(_0024_0024iterator_0024265_00245803, _0024obj_00245801);
						}
						_0024self__00245804.customFunction(curTutIndex);
						goto case 2;
					}
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal TutorialManager _0024self__00245805;

		public _0024startTutorial_00245800(TutorialManager self_)
		{
			_0024self__00245805 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00245805);
		}
	}

	private AuthGameObject authobj;

	private SpawningScript spawnsrc;

	private CalculateHealth chealth;

	private ChatScript cscript;

	private FadeSceneTransition fadestrans;

	private DontDestroyOnLoad ddol;

	public GameObject[] tutorialObjects;

	public GameObject[] nonTutorialObjects;

	[NonSerialized]
	public static GameObject[] bots = new GameObject[3];

	[NonSerialized]
	public static bool AIspawned;

	[NonSerialized]
	public static bool disableBots;

	public Transform[] positions;

	public Transform[] hideBotPositions;

	[NonSerialized]
	public static UnityScript.Lang.Array tutorialArr = new UnityScript.Lang.Array();

	[NonSerialized]
	public static int curTutIndex;

	[NonSerialized]
	public static UnityScript.Lang.Array curCArr = new UnityScript.Lang.Array(false, false, false);

	public GUIStyle textStyle;

	private float alpha;

	public bool nextOne;

	private float origH1;

	public int hoopCounter;

	public int botsDestroyed;

	private string keyGen;

	private string storeInterface;

	public TutorialManager()
	{
		origH1 = 100f;
		keyGen = "http://72.14.184.180/serverKeyGen.php?";
		storeInterface = "http://72.14.184.180/storeInterface.php?";
	}

	public virtual void Awake()
	{
		bots = new GameObject[3];
		bool flag = false;
		disableBots = false;
		tutorialArr = new UnityScript.Lang.Array();
		curTutIndex = 0;
		curCArr = new UnityScript.Lang.Array(false, false, false);
	}

	public virtual IEnumerator Start()
	{
		return new _0024Start_00245785(this).GetEnumerator();
	}

	public virtual void Update()
	{
		if (curTutIndex == 0 && Input.GetButtonDown("Fire1"))
		{
			nextOne = true;
		}
		if (curTutIndex == 1)
		{
		}
		if (curTutIndex == 2)
		{
			bots[1].transform.position = positions[0].position;
			bots[1].transform.rotation = positions[0].rotation;
			if (origH1 != (float)((AIManager)bots[1].gameObject.GetComponent(typeof(AIManager))).aihealth)
			{
				nextOne = true;
				bots[1].transform.position = hideBotPositions[0].position;
				bots[1].transform.rotation = hideBotPositions[0].rotation;
				((AIManager)bots[1].GetComponent(typeof(AIManager))).hideBadge = true;
			}
		}
		if (curTutIndex == 3)
		{
			bots[1].transform.position = positions[1].position;
			bots[1].transform.rotation = positions[1].rotation;
			if (origH1 != (float)((AIManager)bots[1].gameObject.GetComponent(typeof(AIManager))).aihealth)
			{
				nextOne = true;
				bots[1].SendMessage("resetHealth");
				bots[1].transform.position = hideBotPositions[1].position;
				bots[1].transform.rotation = hideBotPositions[1].rotation;
				((AIManager)bots[1].GetComponent(typeof(AIManager))).hideBadge = false;
			}
		}
		if (curTutIndex == 4 && !(SpawningScript.playertrans.position.y < 430f))
		{
			nextOne = true;
		}
		if (curTutIndex == 5 && hoopCounter >= 3)
		{
			nextOne = true;
		}
		if (curTutIndex == 6)
		{
			bots[1].transform.position = positions[2].position;
			bots[1].transform.rotation = positions[2].rotation;
			if (!(origH1 <= (float)((AIManager)bots[1].gameObject.GetComponent(typeof(AIManager))).aihealth))
			{
				nextOne = true;
				bots[1].SendMessage("resetHealth");
			}
		}
		if (curTutIndex == 7 && !(origH1 <= CalculateHealth.healthstat))
		{
			origH1 = CalculateHealth.healthstat;
			nextOne = true;
		}
		if (curTutIndex == 8)
		{
			if (!(origH1 >= CalculateHealth.healthstat))
			{
				RuntimeServices.SetProperty(tutorialArr[8], "message", "Good job! Now get back to destroying those bots!");
			}
			else
			{
				origH1 = CalculateHealth.healthstat;
			}
			if (botsDestroyed == 1)
			{
				RuntimeServices.SetProperty(tutorialArr[8], "message", "One down... You're getting the hang of it!");
			}
			if (!(CalculateHealth.healthstat > 15f))
			{
				RuntimeServices.SetProperty(tutorialArr[8], "message", "You're running low on health... Don't worry though, you can't die in the tutorial :)");
			}
			if (botsDestroyed == 2)
			{
				if (!AuthGameObject.username.Contains("guest_"))
				{
					StartCoroutine_Auto(sendCredits());
				}
				nextOne = true;
			}
		}
		if ((curTutIndex == 9 || curTutIndex == 10 || curTutIndex == 11) && Input.GetButtonDown("Fire1"))
		{
			nextOne = true;
		}
		if (curTutIndex == 12 && Input.GetButtonDown("Fire1"))
		{
			ChatScript.isDisconnecting = true;
			FadeSceneTransition.isfadingout = true;
			Camera.main.transform.parent = null;
			PhotonNetwork.LeaveRoom();
			PhotonNetwork.isMessageQueueRunning = true;
			PhotonNetwork.SetSendingEnabled(0, false);
			PhotonNetwork.SetSendingEnabled(8, false);
			PhotonNetwork.SetSendingEnabled(9, false);
			PhotonNetwork.SetSendingEnabled(10, false);
			GameObject.Find("FadeSceneTrans").SendMessage("startfadeout", 1);
		}
	}

	public virtual void customFunction(int i)
	{
		if (i == 1)
		{
			bots[1].transform.position = positions[0].position;
			bots[1].transform.rotation = positions[0].rotation;
			((AIManager)bots[1].GetComponent(typeof(AIManager))).hideBadge = false;
			bots[2].transform.position = hideBotPositions[1].position;
			bots[2].transform.rotation = hideBotPositions[1].rotation;
			((AIManager)bots[2].GetComponent(typeof(AIManager))).hideBadge = true;
		}
		if (i == 2)
		{
			origH1 = ((AIManager)bots[1].gameObject.GetComponent(typeof(AIManager))).aihealth;
		}
		if (i == 3)
		{
			bots[1].transform.position = positions[1].position;
			bots[1].transform.rotation = positions[1].rotation;
			((AIManager)bots[1].GetComponent(typeof(AIManager))).hideBadge = false;
			origH1 = ((AIManager)bots[1].gameObject.GetComponent(typeof(AIManager))).aihealth;
		}
		if (i == 4)
		{
			bots[1].SendMessage("resetHealth");
			((AIManager)bots[1].GetComponent(typeof(AIManager))).hideBadge = true;
		}
		if (i == 5)
		{
		}
		if (i == 6)
		{
			disableBots = true;
			origH1 = ((AIManager)bots[1].gameObject.GetComponent(typeof(AIManager))).aihealth;
			((AIManager)bots[1].gameObject.GetComponent(typeof(AIManager))).forceEnable = true;
			bots[1].transform.position = positions[2].position;
			bots[1].transform.rotation = positions[2].rotation;
			((AIManager)bots[1].GetComponent(typeof(AIManager))).hideBadge = false;
		}
		if (i == 7)
		{
			disableBots = false;
			bots[1].transform.position = positions[2].position;
			bots[1].transform.rotation = positions[2].rotation;
			((AIManager)bots[1].GetComponent(typeof(AIManager))).hideBadge = false;
			bots[2].transform.position = positions[0].position;
			bots[2].transform.rotation = positions[0].rotation;
			((AIManager)bots[2].GetComponent(typeof(AIManager))).hideBadge = false;
			bots[1].SendMessage("resetHealth");
			bots[2].SendMessage("resetHealth");
			origH1 = CalculateHealth.healthstat;
		}
		if (i == 8)
		{
			disableBots = false;
		}
	}

	public virtual IEnumerator sendCredits()
	{
		return new _0024sendCredits_00245795(this).GetEnumerator();
	}

	public virtual IEnumerator startTutorial()
	{
		return new _0024startTutorial_00245800(this).GetEnumerator();
	}

	public virtual void OnGUI()
	{
		float a = alpha;
		Color color = GUI.color;
		float num = (color.a = a);
		Color color2 = (GUI.color = color);
		GUI.depth = -10;
		if (!(alpha <= 0f))
		{
			UnityRuntimeServices.Invoke(typeof(GUI), "Label", new object[3]
			{
				new Rect(0f, 0f, Screen.width, 95f),
				UnityRuntimeServices.GetProperty(tutorialArr[curTutIndex], "message"),
				textStyle
			}, typeof(UnityEngine.MonoBehaviour));
		}
	}

	public virtual void Main()
	{
	}
}
