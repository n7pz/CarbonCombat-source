using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using Photon;
using UnityEngine;

[Serializable]
public class HealthBar : Photon.MonoBehaviour
{
	[Serializable]
	internal sealed class _0024updatehealthNoEx_00244728 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal object _0024h_00244729;

			internal HealthBar _0024self__00244730;

			public _0024(object h, HealthBar self_)
			{
				_0024h_00244729 = h;
				_0024self__00244730 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00244730.currenthealth = RuntimeServices.UnboxSingle(RuntimeServices.InvokeBinaryOperator("op_Division", _0024h_00244729, 100));
					if (RuntimeServices.ToBool(RuntimeServices.InvokeBinaryOperator("op_LessThanOrEqual", _0024h_00244729, 0f)))
					{
						if (AuthGameObject.gametype == "Team Death-Match")
						{
							if (SpawningScript.team2 == "red")
							{
								_0024self__00244730.gamescores.SendMessage("reddeath");
							}
							else
							{
								_0024self__00244730.gamescores.SendMessage("bluedeath");
							}
						}
						isdead = true;
						_0024self__00244730.spawnpoint.SendMessage("Respawn", 4f);
						_0024self__00244730.showrespawn = true;
						_0024self__00244730.respawncount = 4;
						_0024self__00244730.StartCoroutine_Auto(_0024self__00244730.startcounter());
						Camera.main.SendMessage("setenable", false);
						Camera.main.SendMessage("tempswitch");
						result = (Yield(2, new WaitForSeconds(4f)) ? 1 : 0);
						break;
					}
					goto IL_0178;
				case 2:
					isdead = false;
					_0024self__00244730.showrespawn = false;
					_0024self__00244730.currenthealth = 1f;
					Camera.main.SendMessage("setenable", true);
					goto IL_0178;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0178:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal object _0024h_00244731;

		internal HealthBar _0024self__00244732;

		public _0024updatehealthNoEx_00244728(object h, HealthBar self_)
		{
			_0024h_00244731 = h;
			_0024self__00244732 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024h_00244731, _0024self__00244732);
		}
	}

	[Serializable]
	internal sealed class _0024updatehealth_00244733 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal object _0024h_00244734;

			internal HealthBar _0024self__00244735;

			public _0024(object h, HealthBar self_)
			{
				_0024h_00244734 = h;
				_0024self__00244735 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00244735.currenthealth = RuntimeServices.UnboxSingle(RuntimeServices.InvokeBinaryOperator("op_Division", _0024h_00244734, 100));
					if (RuntimeServices.ToBool(RuntimeServices.InvokeBinaryOperator("op_LessThanOrEqual", _0024h_00244734, 0f)))
					{
						if (AuthGameObject.gametype == "Team Death-Match")
						{
							if (SpawningScript.team2 == "red")
							{
								_0024self__00244735.gamescores.SendMessage("reddeath");
							}
							else
							{
								_0024self__00244735.gamescores.SendMessage("bluedeath");
							}
						}
						isdead = true;
						_0024self__00244735.spawnpoint.SendMessage("Respawn", 4f);
						if (ChatScript.isCar)
						{
							((PhotonView)SpawningScript.playertrans.GetComponent(typeof(PhotonView))).RPC("explodeNow", PhotonTargets.All);
						}
						_0024self__00244735.showrespawn = true;
						_0024self__00244735.respawncount = 4;
						_0024self__00244735.StartCoroutine_Auto(_0024self__00244735.startcounter());
						Camera.main.SendMessage("setenable", false);
						Camera.main.SendMessage("tempswitch");
						result = (Yield(2, new WaitForSeconds(4f)) ? 1 : 0);
						break;
					}
					goto IL_01ac;
				case 2:
					isdead = false;
					_0024self__00244735.showrespawn = false;
					_0024self__00244735.currenthealth = 1f;
					Camera.main.SendMessage("setenable", true);
					goto IL_01ac;
				case 1:
					{
						result = 0;
						break;
					}
					IL_01ac:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal object _0024h_00244736;

		internal HealthBar _0024self__00244737;

		public _0024updatehealth_00244733(object h, HealthBar self_)
		{
			_0024h_00244736 = h;
			_0024self__00244737 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024h_00244736, _0024self__00244737);
		}
	}

	[Serializable]
	internal sealed class _0024startcounter_00244738 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal HealthBar _0024self__00244739;

			public _0024(HealthBar self_)
			{
				_0024self__00244739 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				case 2:
					_0024self__00244739.respawncount--;
					goto default;
				default:
					if (_0024self__00244739.respawncount > 0)
					{
						result = (Yield(2, new WaitForSeconds(1f)) ? 1 : 0);
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

		internal HealthBar _0024self__00244740;

		public _0024startcounter_00244738(HealthBar self_)
		{
			_0024self__00244740 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00244740);
		}
	}

	private float currenthealth;

	public GUIStyle backgroundimage;

	public Texture backbar;

	public Texture mainbar;

	public Texture mainbarbad;

	public Texture armorbar;

	public GameObject spawnpoint;

	public GameObject explosion;

	public Transform maincar;

	public GameObject gamescores;

	public SpawningScript spawningscript;

	public AuthGameObject authobj;

	public AudioController acon;

	public CalculateHealth chealth;

	public ChatScript cscript;

	private bool showrespawn;

	private int respawncount;

	private string thekiller;

	public GUIStyle largelabel;

	public GUIStyle largelabel2;

	public Color shadowcolor;

	public Texture blacktexture;

	[NonSerialized]
	public static bool isdead;

	[NonSerialized]
	public static bool showendofround;

	[NonSerialized]
	public static bool victory;

	[NonSerialized]
	public static bool tie;

	private float alpha1;

	private float alpha2;

	private bool showvictory;

	public HealthBar()
	{
		currenthealth = 1f;
		respawncount = 4;
		thekiller = "someone";
	}

	public virtual void Awake()
	{
		isdead = false;
		showendofround = false;
		victory = false;
		tie = false;
	}

	public virtual void setmaincar(Transform t)
	{
		maincar = t;
	}

	public virtual void aiDeath(string i)
	{
		if (AuthGameObject.gametype == "Team Death-Match" && !AuthGameObject.showTutorial)
		{
			gamescores.SendMessage(i + "death");
		}
	}

	public virtual IEnumerator updatehealthNoEx(object h)
	{
		return new _0024updatehealthNoEx_00244728(h, this).GetEnumerator();
	}

	public virtual IEnumerator updatehealth(object h)
	{
		return new _0024updatehealth_00244733(h, this).GetEnumerator();
	}

	public virtual void killerusername(string u)
	{
		thekiller = u;
	}

	public virtual IEnumerator startcounter()
	{
		return new _0024startcounter_00244738(this).GetEnumerator();
	}

	public virtual void sethealthdelegate(Transform t)
	{
		t.gameObject.SendMessage("forceSetHealth", currenthealth * 100f);
	}

	public virtual void OnGUI()
	{
		if (AudioController.hideGUI)
		{
			return;
		}
		GUI.depth = -2;
		GUI.BeginGroup(new Rect(Screen.width - 25 - 120, 10f, 120f, 80f));
		float width = 115f * currenthealth;
		GUI.DrawTexture(new Rect(1f, 41f, 117f, 17f), backbar);
		if (ChatScript.isCar)
		{
			if ((ChatScript.hasarmor1 || ChatScript.hasarmor2 || ChatScript.hasarmor3 || ChatScript.hasarmor4 || ChatScript.hasarmor5 || ChatScript.hasarmor6 || ChatScript.hasarmor7 || ChatScript.hasarmor8) && !(CalculateHealth.armorHealth <= 0f))
			{
				GUI.DrawTexture(new Rect(2f, 42f, width, 10f), (currenthealth > 0.2f) ? mainbar : mainbarbad);
				GUI.DrawTexture(new Rect(2f, 52f, 115f * CalculateHealth.armorHealth, 5f), armorbar);
			}
			else
			{
				GUI.DrawTexture(new Rect(2f, 42f, width, 15f), (currenthealth > 0.2f) ? mainbar : mainbarbad);
			}
		}
		else
		{
			GUI.DrawTexture(new Rect(2f, 42f, width, 10f), (currenthealth > 0.2f) ? mainbar : mainbarbad);
			GUI.DrawTexture(new Rect(2f, 52f, 115f * CalculateHealth.jetFuel, 5f), armorbar);
		}
		GUI.EndGroup();
		if (showrespawn && !showendofround)
		{
			string text = null;
			if (thekiller == "YOU")
			{
				text = "You managed to kill yourself";
				GameObject.Find("/AuthGameObject").SendMessage("gotAch", "Suicide");
			}
			else
			{
				text = "You were killed by " + thekiller;
			}
			float a = 0.65f;
			Color color = GUI.color;
			float num = (color.a = a);
			Color color2 = (GUI.color = color);
			GUI.DrawTexture(new Rect(0f, Screen.height / 2 - 70, Screen.width, 140f), blacktexture);
			int num2 = 1;
			Color color4 = GUI.color;
			float num3 = (color4.a = num2);
			Color color5 = (GUI.color = color4);
			GUI.color = shadowcolor;
			GUI.Label(new Rect(1f, 1f, Screen.width, Screen.height), text, largelabel);
			GUI.Label(new Rect(1f, 1f, Screen.width, Screen.height), "Respawning in " + respawncount, largelabel2);
			GUI.color = Color.white;
			GUI.Label(new Rect(0f, 0f, Screen.width, Screen.height), text, largelabel);
			GUI.Label(new Rect(0f, 0f, Screen.width, Screen.height), "Respawning in " + respawncount, largelabel2);
		}
		if (showvictory && AuthGameObject.gametype != "Deathmatch" && AuthGameObject.gametype != "Survival" && (victory || tie))
		{
			GUI.depth = -6;
			if (!tie)
			{
				float a2 = alpha1;
				Color color7 = GUI.color;
				float num4 = (color7.a = a2);
				Color color8 = (GUI.color = color7);
				GUI.DrawTexture(new Rect(0f, Screen.height / 2 - 70, Screen.width, 140f), blacktexture);
				float a3 = alpha2;
				Color color10 = GUI.color;
				float num5 = (color10.a = a3);
				Color color11 = (GUI.color = color10);
				GUI.color = shadowcolor;
				GUI.Label(new Rect(1f, 1f, Screen.width, Screen.height), (!victory) ? "Your team lost this round" : ("Your team won this round!" + ((!AuthGameObject.shop) ? string.Empty : " (+30 credits)")), largelabel);
				GUI.Label(new Rect(1f, 1f, Screen.width, Screen.height), (!victory) ? "Defeat" : "Victory", largelabel2);
				GUI.color = Color.white;
				GUI.Label(new Rect(0f, 0f, Screen.width, Screen.height), (!victory) ? "Your team lost this round" : ("Your team won this round!" + ((!AuthGameObject.shop) ? string.Empty : " (+30 credits)")), largelabel);
				GUI.Label(new Rect(0f, 0f, Screen.width, Screen.height), (!victory) ? "Defeat" : "Victory", largelabel2);
			}
			else
			{
				float a4 = alpha1;
				Color color13 = GUI.color;
				float num6 = (color13.a = a4);
				Color color14 = (GUI.color = color13);
				GUI.DrawTexture(new Rect(0f, Screen.height / 2 - 70, Screen.width, 140f), blacktexture);
				float a5 = alpha2;
				Color color16 = GUI.color;
				float num7 = (color16.a = a5);
				Color color17 = (GUI.color = color16);
				GUI.color = shadowcolor;
				GUI.Label(new Rect(1f, 1f, Screen.width, Screen.height), "No one won this round", largelabel);
				GUI.Label(new Rect(1f, 1f, Screen.width, Screen.height), "Stalemate", largelabel2);
				GUI.color = Color.white;
				GUI.Label(new Rect(0f, 0f, Screen.width, Screen.height), "No one won this round", largelabel);
				GUI.Label(new Rect(0f, 0f, Screen.width, Screen.height), "Stalemate", largelabel2);
			}
		}
	}

	public virtual void Update()
	{
		if (showendofround)
		{
			showvictory = true;
			if (!(alpha1 >= 0.65f))
			{
				alpha1 += 4f * Time.deltaTime;
			}
			else
			{
				alpha1 = 0.65f;
			}
			if (!(alpha2 >= 1f))
			{
				alpha2 += 4f * Time.deltaTime;
			}
			else
			{
				alpha2 = 1f;
			}
		}
		else
		{
			if (!(alpha1 <= 0f))
			{
				alpha1 -= 4f * Time.deltaTime;
			}
			else
			{
				alpha1 = 0f;
			}
			if (!(alpha2 <= 0f))
			{
				alpha2 -= 4f * Time.deltaTime;
				return;
			}
			alpha2 = 0f;
			showvictory = false;
		}
	}

	[RPC]
	public virtual void makeexplosion(Vector3 pos, Quaternion rot)
	{
		UnityEngine.Object.Instantiate(explosion, pos, rot);
	}
}
