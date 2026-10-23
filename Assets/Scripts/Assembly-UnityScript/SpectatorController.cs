using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class SpectatorController : MonoBehaviour
{
	[Serializable]
	internal sealed class _0024Start_00245746 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal SpectatorController _0024self__00245747;

			public _0024(SpectatorController self_)
			{
				_0024self__00245747 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					result = (YieldDefault(2) ? 1 : 0);
					break;
				case 2:
					result = (YieldDefault(3) ? 1 : 0);
					break;
				case 3:
					result = (YieldDefault(4) ? 1 : 0);
					break;
				case 4:
					if ((bool)Camera.main)
					{
						_0024self__00245747.origcampos = Camera.main.transform.position;
						_0024self__00245747.origcamrot = Camera.main.transform.rotation.eulerAngles;
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

		internal SpectatorController _0024self__00245748;

		public _0024Start_00245746(SpectatorController self_)
		{
			_0024self__00245748 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00245748);
		}
	}

	[NonSerialized]
	public static bool iscont;

	public GUIStyle boxstyle;

	public GUIStyle buttonstyle;

	public GameObject botprefab;

	private GameObject target;

	private Vector3 origcampos;

	private Vector3 origcamrot;

	private string buttonstatus;

	public SpawningScript spwnsrc;

	public AudioController acon;

	private ChatScript cscript;

	private Transform blankgo;

	public SpectatorController()
	{
		buttonstatus = "Click Here to Roam";
	}

	public virtual void OnGUI()
	{
		if (AudioController.hideGUI || !(SpawningScript.team2 == string.Empty))
		{
			return;
		}
		GUI.depth = -3;
		GUI.BeginGroup(new Rect(Screen.width / 2 - 108, -10f, 300f, 70f));
		if (GUI.Button(new Rect(0f, 0f, 216f, 88f), buttonstatus, boxstyle))
		{
			if (buttonstatus == "Click Here to Roam")
			{
				buttonstatus = "Press [r]\nTo Stop Roaming";
				spawnbot();
			}
			else
			{
				buttonstatus = "Click Here to Roam";
				destroybot();
			}
			iscont = !iscont;
		}
		GUI.EndGroup();
	}

	public virtual IEnumerator Start()
	{
		return new _0024Start_00245746(this).GetEnumerator();
	}

	public virtual void spawnbot()
	{
		target = (GameObject)UnityEngine.Object.Instantiate(botprefab, transform.position, transform.rotation);
		Camera.main.gameObject.SendMessage("SetTarget", target.transform);
		SpawningScript.playertrans = target.transform;
		GameObject.Find("/MinimapCam").SendMessage("SetTarget", target.transform);
		GameObject.Find("/GUI/QualitySettings").SendMessage("preSetAllObj");
		if (QualitySettings.GetQualityLevel() == 0)
		{
			GameObject.Find("/GUI/QualitySettings").SendMessage("setAllObjectsSimp");
		}
	}

	public virtual void destroybot()
	{
		Camera.main.gameObject.SendMessage("SetTarget", blankgo);
		GameObject.Find("/MinimapCam").SendMessage("SetTarget", Camera.main.gameObject.transform);
		UnityEngine.Object.Destroy(target);
		Camera.main.transform.position = origcampos;
		Vector3 vector = origcamrot;
		Quaternion rotation = Camera.main.transform.rotation;
		Vector3 vector2 = (rotation.eulerAngles = vector);
		Quaternion quaternion = (Camera.main.transform.rotation = rotation);
		SpawningScript.playertrans = null;
	}

	public virtual void Update()
	{
		if (SpawningScript.team2 == string.Empty)
		{
			if (iscont)
			{
				Screen.lockCursor = true;
			}
			else if (ChatScript.isCar)
			{
				Screen.lockCursor = false;
			}
			if (Input.GetKeyDown("r"))
			{
				iscont = false;
				buttonstatus = "Click Here to Roam";
				destroybot();
			}
		}
		else
		{
			iscont = false;
		}
	}

	public virtual void Main()
	{
	}
}
