using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class AmmoDisplay : MonoBehaviour
{
	[Serializable]
	internal sealed class _0024minealphafadein_00244084 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal AmmoDisplay _0024self__00244085;

			public _0024(AmmoDisplay self_)
			{
				_0024self__00244085 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00244085.fadingin = true;
					goto case 2;
				case 2:
					if (_0024self__00244085.minealpha < 1f)
					{
						_0024self__00244085.minealpha += 4f * Time.deltaTime;
						result = (YieldDefault(2) ? 1 : 0);
					}
					else
					{
						_0024self__00244085.minealpha = 1f;
						result = (Yield(3, new WaitForSeconds(0.5f)) ? 1 : 0);
					}
					break;
				case 3:
				case 4:
					if (_0024self__00244085.minealpha > 0f)
					{
						_0024self__00244085.minealpha -= 4f * Time.deltaTime;
						result = (YieldDefault(4) ? 1 : 0);
						break;
					}
					_0024self__00244085.minealpha = 0f;
					_0024self__00244085.fadingin = false;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal AmmoDisplay _0024self__00244086;

		public _0024minealphafadein_00244084(AmmoDisplay self_)
		{
			_0024self__00244086 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00244086);
		}
	}

	[Serializable]
	internal sealed class _0024botalphafadein_00244087 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal AmmoDisplay _0024self__00244088;

			public _0024(AmmoDisplay self_)
			{
				_0024self__00244088 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00244088.fadingin = true;
					goto case 2;
				case 2:
					if (_0024self__00244088.botalpha < 1f)
					{
						_0024self__00244088.botalpha += 4f * Time.deltaTime;
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024self__00244088.botalpha = 1f;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal AmmoDisplay _0024self__00244089;

		public _0024botalphafadein_00244087(AmmoDisplay self_)
		{
			_0024self__00244089 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00244089);
		}
	}

	[Serializable]
	internal sealed class _0024botalphafadeout_00244090 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal AmmoDisplay _0024self__00244091;

			public _0024(AmmoDisplay self_)
			{
				_0024self__00244091 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__00244091.botalpha > 0f)
					{
						_0024self__00244091.botalpha -= 4f * Time.deltaTime;
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024self__00244091.botalpha = 0f;
					_0024self__00244091.fadingin = false;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal AmmoDisplay _0024self__00244092;

		public _0024botalphafadeout_00244090(AmmoDisplay self_)
		{
			_0024self__00244092 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00244092);
		}
	}

	public GUIStyle mainskin;

	public GUIStyle textskin;

	public GUIStyle textskinsmall;

	public Texture rocketicon;

	public Texture lasericon;

	public Texture flameicon;

	public Texture bulleticon;

	public Texture selecticon;

	private string guntype;

	private int rocket1;

	private int rocket2;

	private int rocket3;

	private int rocket4;

	private int laser1;

	private int laser2;

	private int laser3;

	private int laser4;

	public FireGun script;

	private int rocketammoleft;

	private int laserammoleft;

	private bool rocketreload;

	private bool laserreload;

	private float rocketcounter;

	private float lasercounter;

	private int rocketammocount;

	private int laserammocount;

	private string displaytext;

	[NonSerialized]
	public static bool rocketdonereloading;

	[NonSerialized]
	public static bool laserdonereloading;

	[NonSerialized]
	public static int minecount = 10;

	private bool fadingin;

	public AuthGameObject authobj;

	public ChatScript cscript;

	public PlayerCar_Script playercar;

	public CalculateHealth chealth;

	public EndofRound endofround;

	public AudioController acon;

	public PauseObject pobj;

	public ConduitInputReciever cInput;

	public GUIStyle minestyle;

	private float minealpha;

	public GUIStyle botstyle;

	private float botalpha;

	private bool botonce;

	public GUIStyle pickupWep;

	public float xval;

	public AmmoDisplay()
	{
		guntype = "rocket";
		rocket1 = 7;
		rocket2 = 40;
		rocket3 = 246;
		rocket4 = 30;
		laser1 = 7;
		laser2 = 65;
		laser3 = 246;
		laser4 = 30;
		rocketammoleft = 6;
		laserammoleft = 15;
		rocketcounter = ((!ChatScript.hasrapidfire) ? 1f : 0.5f) * 0.3f;
		lasercounter = ((!ChatScript.hasrapidfire) ? 1f : 0.5f) * 0.1f;
		displaytext = string.Empty;
		botonce = true;
		xval = 15f;
	}

	public virtual void Awake()
	{
		rocketdonereloading = false;
		laserdonereloading = false;
		minecount = 10;
	}

	public virtual IEnumerator minealphafadein()
	{
		return new _0024minealphafadein_00244084(this).GetEnumerator();
	}

	public virtual IEnumerator botalphafadein()
	{
		return new _0024botalphafadein_00244087(this).GetEnumerator();
	}

	public virtual IEnumerator botalphafadeout()
	{
		return new _0024botalphafadeout_00244090(this).GetEnumerator();
	}

	public virtual void Update()
	{
		rocketammoleft = (int)FireGun.rocketammoleft;
		laserammoleft = (int)FireGun.laserammoleft;
		guntype = FireGun.guntype;
		rocketreload = FireGun.rocketreload;
		laserreload = FireGun.laserreload;
		if (laserreload && !laserdonereloading && !(lasercounter <= 0f))
		{
			lasercounter -= 1f * Time.deltaTime;
		}
		if (rocketreload && !rocketdonereloading && !(rocketcounter <= 0f))
		{
			rocketcounter -= 1f * Time.deltaTime;
		}
		if ((Input.GetKeyDown("m") || RuntimeServices.ToBool((!(PauseObject.alt_item != string.Empty)) ? ((object)false) : RuntimeServices.Invoke(typeof(Input), "GetKeyDown", new object[1] { Enum.Parse(typeof(KeyCode), PauseObject.alt_item) })) || RuntimeServices.ToBool(ConduitInputReciever.ht["uIt"])) && PlayerCar_Script.controlenabled && AuthGameObject.inventory[2].Split("#"[0])[4] != "false" && minecount <= 0 && !fadingin)
		{
			StartCoroutine_Auto(minealphafadein());
		}
		if (Input.GetKeyDown("b") && PlayerCar_Script.controlenabled && CalculateHealth.killstreak >= 6 && !botonce && !(botalpha < 1f))
		{
			GameObject.Find("/Spawn Point").SendMessage("SpawnNetworkedBots", 3);
			GameObject.Find("/GUI/Chat").SendMessage("OutsideSystem", AuthGameObject.username + " got a 6 kill streak and released a bot attack!");
			StartCoroutine_Auto(botalphafadeout());
		}
		if (!(EndofRound.alphastat <= 0f) && fadingin)
		{
			StartCoroutine_Auto(botalphafadeout());
		}
		if (CalculateHealth.killstreak >= 6 && botonce)
		{
			botonce = false;
			GameObject.Find("/AuthGameObject").SendMessage("gotAch", "Six in a Row");
			StartCoroutine_Auto(botalphafadein());
		}
		if (CalculateHealth.killstreak < 6)
		{
			botonce = true;
		}
	}

	public virtual void OnGUI()
	{
		if (AudioController.hideGUI)
		{
			return;
		}
		GUI.depth = -1;
		float a = minealpha;
		Color color = GUI.color;
		float num = (color.a = a);
		Color color2 = (GUI.color = color);
		GUI.Box(new Rect(Screen.width / 2 - 130, 80f, 260f, 70f), "Out of Item", minestyle);
		float a2 = botalpha;
		Color color4 = GUI.color;
		float num2 = (color4.a = a2);
		Color color5 = (GUI.color = color4);
		GUI.Box(new Rect(Screen.width / 2 - 130, 80f, 260f, 70f), "6 kill streak!\nPress [b] for a drone attack", botstyle);
		float a3 = 1f;
		Color color7 = GUI.color;
		float num3 = (color7.a = a3);
		Color color8 = (GUI.color = color7);
		GUI.BeginGroup(new Rect(Screen.width - 10 - 150, 10f, 150f, 75f));
		GUI.Box(new Rect(0f, 0f, 150f, 75f), string.Empty, mainskin);
		if (rocketdonereloading && !rocketreload)
		{
			rocketdonereloading = false;
		}
		if (laserdonereloading && !laserreload)
		{
			laserdonereloading = false;
		}
		if (ChatScript.isCar)
		{
			if (ChatScript.primaryweapon == "rocket" || ChatScript.primaryweapon == "launcher" || ChatScript.primaryweapon == "missile" || ChatScript.primaryweapon == "emplauncher" || ChatScript.primaryweapon == "grappling")
			{
				GUI.DrawTexture(new Rect(22f, 15f, 32f, 16f), rocketicon);
			}
			if (ChatScript.primaryweapon == "flamethrower")
			{
				GUI.DrawTexture(new Rect(27f, 15f, 24f, 16f), flameicon);
			}
			if (ChatScript.primaryweapon == "minigun" || ChatScript.primaryweapon == "railgun" || ChatScript.primaryweapon == "shotgun")
			{
				GUI.DrawTexture(new Rect(19f, 19f, 32f, 8f), bulleticon);
			}
			if (ChatScript.primaryweapon == "laser" || ChatScript.primaryweapon == "lasercannon")
			{
				GUI.DrawTexture(new Rect(20f, 11f, 37f, 24f), lasericon);
			}
		}
		else
		{
			GUI.DrawTexture(new Rect(19f, 19f, 32f, 8f), bulleticon);
		}
		if (ChatScript.isCar)
		{
			if (ChatScript.secondaryweapon == "rocket" || ChatScript.secondaryweapon == "launcher" || ChatScript.secondaryweapon == "missile" || ChatScript.secondaryweapon == "emplauncher" || ChatScript.secondaryweapon == "grappling")
			{
				GUI.DrawTexture(new Rect(80f, 15f, 32f, 16f), rocketicon);
			}
			if (ChatScript.secondaryweapon == "flamethrower")
			{
				GUI.DrawTexture(new Rect(83f, 15f, 24f, 16f), flameicon);
			}
			if (ChatScript.secondaryweapon == "minigun" || ChatScript.secondaryweapon == "railgun" || ChatScript.secondaryweapon == "shotgun")
			{
				GUI.DrawTexture(new Rect(78f, 19f, 32f, 8f), bulleticon);
			}
			if (ChatScript.secondaryweapon == "laser" || ChatScript.secondaryweapon == "lasercannon")
			{
				GUI.DrawTexture(new Rect(77f, 11f, 37f, 24f), lasericon);
			}
			if (guntype == "rocket")
			{
				xval = Mathf.Lerp(xval, 15f, Time.deltaTime * 3f);
			}
			else
			{
				xval = Mathf.Lerp(xval, 75f, Time.deltaTime * 3f);
			}
			GUI.DrawTexture(new Rect(xval, 11f, 60f, 24f), selecticon);
			if (ChatScript.dropWepState == 1)
			{
				GUI.color = Color.white;
				GUI.Label(new Rect(53f, 14f, 20f, 20f), Mathf.Round(ChatScript.waitTime).ToString(), pickupWep);
				GUI.color = Color.black;
				GUI.Label(new Rect(52f, 13f, 20f, 20f), Mathf.Round(ChatScript.waitTime).ToString(), pickupWep);
			}
			if (ChatScript.dropWepState == 2)
			{
				GUI.color = Color.white;
				GUI.Label(new Rect(110f, 14f, 20f, 20f), Mathf.Round(ChatScript.waitTime).ToString(), pickupWep);
				GUI.color = Color.black;
				GUI.Label(new Rect(109f, 13f, 20f, 20f), Mathf.Round(ChatScript.waitTime).ToString(), pickupWep);
			}
		}
		GUI.color = Color.white;
		if (!rocketreload && ChatScript.isCar)
		{
			if (rocketammoleft > 99)
			{
				GUI.Label(new Rect(52f, 13f, 20f, 20f), rocketammoleft + string.Empty, textskinsmall);
			}
			else
			{
				GUI.Label(new Rect(52f, 13f, 20f, 20f), rocketammoleft + string.Empty, textskin);
			}
		}
		if (!laserreload && ChatScript.isCar)
		{
			if (laserammoleft > 99)
			{
				GUI.Label(new Rect(112f, 13f, 20f, 20f), laserammoleft + string.Empty, textskinsmall);
			}
			else
			{
				GUI.Label(new Rect(112f, 13f, 20f, 20f), laserammoleft + string.Empty, textskin);
			}
		}
		if (!ChatScript.isCar)
		{
			GUI.Label(new Rect(52f, 13f, 80f, 20f), "Infinite", textskin);
			if (rocketreload)
			{
				rocketdonereloading = true;
				rocketreload = false;
				laserdonereloading = true;
				laserreload = false;
			}
		}
		if (rocketreload && !rocketdonereloading)
		{
			if (ChatScript.primaryweapon == "rocket")
			{
				if (!(rocketcounter > 0f))
				{
					rocketammocount++;
					rocketcounter = ((!ChatScript.hasrapidfire) ? 1f : 0.5f) * 0.3f;
				}
				if (rocketammocount == 6)
				{
					rocketdonereloading = true;
					rocketammocount = 0;
					rocketcounter = ((!ChatScript.hasrapidfire) ? 1f : 0.5f) * 0.3f;
				}
			}
			if (ChatScript.primaryweapon == "launcher" || ChatScript.primaryweapon == "emplauncher" || ChatScript.primaryweapon == "grappling")
			{
				if (!(rocketcounter > 0f))
				{
					rocketammocount++;
					rocketcounter = ((!ChatScript.hasrapidfire) ? 1f : 0.5f) * 0.5f;
				}
				if (rocketammocount == 6)
				{
					rocketdonereloading = true;
					rocketammocount = 0;
					rocketcounter = ((!ChatScript.hasrapidfire) ? 1f : 0.5f) * 0.5f;
				}
			}
			if (ChatScript.primaryweapon == "laser")
			{
				if (!(rocketcounter > 0f))
				{
					rocketammocount++;
					rocketcounter = ((!ChatScript.hasrapidfire) ? 1f : 0.5f) * 0.4f;
				}
				if (rocketammocount == 6)
				{
					rocketdonereloading = true;
					rocketammocount = 0;
					rocketcounter = ((!ChatScript.hasrapidfire) ? 1f : 0.5f) * 0.4f;
				}
			}
			if (ChatScript.primaryweapon == "minigun")
			{
				if (!(rocketcounter > 0f))
				{
					rocketammocount++;
					rocketcounter = ((!ChatScript.hasrapidfire) ? 1f : 0.5f) * 0.7f;
				}
				if (rocketammocount == 6)
				{
					rocketdonereloading = true;
					rocketammocount = 0;
					rocketcounter = ((!ChatScript.hasrapidfire) ? 1f : 0.5f) * 0.7f;
				}
			}
			if (ChatScript.primaryweapon == "railgun")
			{
				if (!(rocketcounter > 0f))
				{
					rocketammocount++;
					rocketcounter = ((!ChatScript.hasrapidfire) ? 1f : 0.5f) * 1.15f;
				}
				if (rocketammocount == 6)
				{
					rocketdonereloading = true;
					rocketammocount = 0;
					rocketcounter = ((!ChatScript.hasrapidfire) ? 1f : 0.5f) * 1.15f;
				}
			}
			if (ChatScript.primaryweapon == "lasercannon")
			{
				if (!(rocketcounter > 0f))
				{
					rocketammocount++;
					rocketcounter = ((!ChatScript.hasrapidfire) ? 1f : 0.5f) * 1.1f;
				}
				if (rocketammocount == 6)
				{
					rocketdonereloading = true;
					rocketammocount = 0;
					rocketcounter = ((!ChatScript.hasrapidfire) ? 1f : 0.5f) * 1.1f;
				}
			}
			if (ChatScript.primaryweapon == "flamethrower")
			{
				if (!(rocketcounter > 0f))
				{
					rocketammocount++;
					rocketcounter = ((!ChatScript.hasrapidfire) ? 1f : 0.5f) * 0.7f;
				}
				if (rocketammocount == 6)
				{
					rocketdonereloading = true;
					rocketammocount = 0;
					rocketcounter = ((!ChatScript.hasrapidfire) ? 1f : 0.5f) * 0.7f;
				}
			}
			if (ChatScript.primaryweapon == "missile")
			{
				if (!(rocketcounter > 0f))
				{
					rocketammocount++;
					rocketcounter = ((!ChatScript.hasrapidfire) ? 1f : 0.5f) * 0.5f;
				}
				if (rocketammocount == 6)
				{
					rocketdonereloading = true;
					rocketammocount = 0;
					rocketcounter = ((!ChatScript.hasrapidfire) ? 1f : 0.5f) * 0.5f;
				}
			}
			if (ChatScript.primaryweapon == "shotgun")
			{
				if (!(rocketcounter > 0f))
				{
					rocketammocount++;
					rocketcounter = ((!ChatScript.hasrapidfire) ? 1f : 0.5f) * 0.6f;
				}
				if (rocketammocount == 6)
				{
					rocketdonereloading = true;
					rocketammocount = 0;
					rocketcounter = ((!ChatScript.hasrapidfire) ? 1f : 0.5f) * 0.6f;
				}
			}
			GUI.Label(new Rect(50f, 13f, 20f, 20f), " R", textskin);
		}
		if (laserreload && !laserdonereloading)
		{
			if (ChatScript.secondaryweapon == "rocket")
			{
				if (!(lasercounter > 0f))
				{
					laserammocount++;
					lasercounter = ((!ChatScript.hasrapidfire) ? 1f : 0.5f) * 0.3f;
				}
				if (laserammocount == 6)
				{
					laserdonereloading = true;
					laserammocount = 0;
					lasercounter = ((!ChatScript.hasrapidfire) ? 1f : 0.5f) * 0.3f;
				}
			}
			if (ChatScript.secondaryweapon == "launcher" || ChatScript.secondaryweapon == "emplauncher" || ChatScript.secondaryweapon == "grappling")
			{
				if (!(lasercounter > 0f))
				{
					laserammocount++;
					lasercounter = ((!ChatScript.hasrapidfire) ? 1f : 0.5f) * 0.5f;
				}
				if (laserammocount == 6)
				{
					laserdonereloading = true;
					laserammocount = 0;
					lasercounter = ((!ChatScript.hasrapidfire) ? 1f : 0.5f) * 0.5f;
				}
			}
			if (ChatScript.secondaryweapon == "laser")
			{
				if (!(lasercounter > 0f))
				{
					laserammocount++;
					lasercounter = ((!ChatScript.hasrapidfire) ? 1f : 0.5f) * 0.4f;
				}
				if (laserammocount == 6)
				{
					laserdonereloading = true;
					laserammocount = 0;
					lasercounter = ((!ChatScript.hasrapidfire) ? 1f : 0.5f) * 0.4f;
				}
			}
			if (ChatScript.secondaryweapon == "minigun")
			{
				if (!(lasercounter > 0f))
				{
					laserammocount++;
					lasercounter = ((!ChatScript.hasrapidfire) ? 1f : 0.5f) * 0.7f;
				}
				if (laserammocount == 6)
				{
					laserdonereloading = true;
					laserammocount = 0;
					lasercounter = ((!ChatScript.hasrapidfire) ? 1f : 0.5f) * 0.7f;
				}
			}
			if (ChatScript.secondaryweapon == "railgun")
			{
				if (!(lasercounter > 0f))
				{
					laserammocount++;
					lasercounter = ((!ChatScript.hasrapidfire) ? 1f : 0.5f) * 1.15f;
				}
				if (laserammocount == 6)
				{
					laserdonereloading = true;
					laserammocount = 0;
					lasercounter = ((!ChatScript.hasrapidfire) ? 1f : 0.5f) * 1.15f;
				}
			}
			if (ChatScript.secondaryweapon == "lasercannon")
			{
				if (!(lasercounter > 0f))
				{
					laserammocount++;
					lasercounter = ((!ChatScript.hasrapidfire) ? 1f : 0.5f) * 1.1f;
				}
				if (laserammocount == 6)
				{
					laserdonereloading = true;
					laserammocount = 0;
					lasercounter = ((!ChatScript.hasrapidfire) ? 1f : 0.5f) * 1.1f;
				}
			}
			if (ChatScript.secondaryweapon == "flamethrower")
			{
				if (!(lasercounter > 0f))
				{
					laserammocount++;
					lasercounter = ((!ChatScript.hasrapidfire) ? 1f : 0.5f) * 0.7f;
				}
				if (laserammocount == 6)
				{
					laserdonereloading = true;
					laserammocount = 0;
					lasercounter = ((!ChatScript.hasrapidfire) ? 1f : 0.5f) * 0.7f;
				}
			}
			if (ChatScript.secondaryweapon == "missile")
			{
				if (!(lasercounter > 0f))
				{
					laserammocount++;
					lasercounter = ((!ChatScript.hasrapidfire) ? 1f : 0.5f) * 0.5f;
				}
				if (laserammocount == 6)
				{
					laserdonereloading = true;
					laserammocount = 0;
					lasercounter = ((!ChatScript.hasrapidfire) ? 1f : 0.5f) * 0.5f;
				}
			}
			if (ChatScript.secondaryweapon == "shotgun")
			{
				if (!(lasercounter > 0f))
				{
					laserammocount++;
					lasercounter = ((!ChatScript.hasrapidfire) ? 1f : 0.5f) * 0.6f;
				}
				if (laserammocount == 6)
				{
					laserdonereloading = true;
					laserammocount = 0;
					lasercounter = ((!ChatScript.hasrapidfire) ? 1f : 0.5f) * 0.6f;
				}
			}
			GUI.Label(new Rect(110f, 13f, 20f, 20f), " R", textskin);
		}
		GUI.EndGroup();
	}

	public virtual void Main()
	{
	}
}
