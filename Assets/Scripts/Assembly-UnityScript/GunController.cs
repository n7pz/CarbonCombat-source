using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using Photon;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class GunController : Photon.MonoBehaviour
{
	[Serializable]
	internal sealed class _0024fadein_00244678 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal float _0024etag_00244679;

			internal int _0024i_00244680;

			internal GunController _0024self__00244681;

			public _0024(int i, GunController self_)
			{
				_0024i_00244680 = i;
				_0024self__00244681 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024etag_00244679 = RuntimeServices.UnboxSingle(_0024self__00244681.enemytagstate[_0024i_00244680]);
					if (_0024etag_00244679 == 0f)
					{
						goto case 2;
					}
					goto IL_00cb;
				case 2:
					if (_0024etag_00244679 < 1f)
					{
						_0024etag_00244679 += 2.5f * Time.deltaTime;
						_0024self__00244681.enemytagstate[_0024i_00244680] = _0024etag_00244679;
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024etag_00244679 = 1f;
					_0024self__00244681.enemytagstate[_0024i_00244680] = _0024etag_00244679;
					goto IL_00cb;
				case 1:
					{
						result = 0;
						break;
					}
					IL_00cb:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal int _0024i_00244682;

		internal GunController _0024self__00244683;

		public _0024fadein_00244678(int i, GunController self_)
		{
			_0024i_00244682 = i;
			_0024self__00244683 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024i_00244682, _0024self__00244683);
		}
	}

	[Serializable]
	internal sealed class _0024fadeout_00244684 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal float _0024etag_00244685;

			internal int _0024i_00244686;

			internal GunController _0024self__00244687;

			public _0024(int i, GunController self_)
			{
				_0024i_00244686 = i;
				_0024self__00244687 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__00244687.enemytagstate.length - 1 >= _0024i_00244686 && _0024i_00244686 >= 0)
					{
						_0024etag_00244685 = RuntimeServices.UnboxSingle(_0024self__00244687.enemytagstate[_0024i_00244686]);
						goto case 2;
					}
					goto IL_021d;
				case 2:
					if (_0024etag_00244685 > 0f)
					{
						_0024etag_00244685 -= 2.5f * Time.deltaTime;
						_0024self__00244687.enemytagstate[_0024i_00244686] = _0024etag_00244685;
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					if (_0024self__00244687.enemytagstate.length - 1 >= _0024i_00244686 && _0024i_00244686 >= 0)
					{
						_0024self__00244687.enemytagstate.RemoveAt(_0024i_00244686);
					}
					if (_0024self__00244687.enemydelete.length - 1 >= _0024i_00244686 && _0024i_00244686 >= 0)
					{
						_0024self__00244687.enemydelete.RemoveAt(_0024i_00244686);
					}
					if (_0024self__00244687.enemylistarray.length - 1 >= _0024i_00244686 && _0024i_00244686 >= 0)
					{
						_0024self__00244687.enemylistarray.RemoveAt(_0024i_00244686);
					}
					if (_0024self__00244687.enemybadgelist.length - 1 >= _0024i_00244686 && _0024i_00244686 >= 0)
					{
						_0024self__00244687.enemybadgelist.RemoveAt(_0024i_00244686);
					}
					if (_0024self__00244687.enemydist.length - 1 >= _0024i_00244686 && _0024i_00244686 >= 0)
					{
						_0024self__00244687.enemydist.RemoveAt(_0024i_00244686);
					}
					_0024self__00244687.enemylist = (GameObject[])_0024self__00244687.enemylistarray.ToBuiltin(typeof(GameObject));
					goto IL_021d;
				case 1:
					{
						result = 0;
						break;
					}
					IL_021d:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal int _0024i_00244688;

		internal GunController _0024self__00244689;

		public _0024fadeout_00244684(int i, GunController self_)
		{
			_0024i_00244688 = i;
			_0024self__00244689 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024i_00244688, _0024self__00244689);
		}
	}

	public Transform guntrans;

	public Transform maingun;

	public Transform playerT;

	public bool start;

	[NonSerialized]
	public static bool startvar;

	[NonSerialized]
	public static bool isOutOfRange;

	private bool IDenabled;

	private string hitusername;

	public Transform currentuser;

	public GUIStyle badgeskin;

	public GUIStyle redbadgeskin;

	public GUIStyle enallblue;

	public GUIStyle enallred;

	public LayerMask layermask;

	public int team;

	public float GUIscale;

	public GameObject[] teamlist;

	public UnityScript.Lang.Array badgelist;

	public UnityScript.Lang.Array distances;

	public GameObject[] enemylist;

	public UnityScript.Lang.Array enemylistarray;

	public UnityScript.Lang.Array enemybadgelist;

	public UnityScript.Lang.Array enemydist;

	public UnityScript.Lang.Array enemydelete;

	public UnityScript.Lang.Array enemytagstate;

	public LayerMask teammask;

	public SpawningScript spawnscript;

	public AuthGameObject authobj;

	public RefreshMasterServer refreshsrc;

	public HeadlesssDedServer headless;

	public CrossHairDraw cHD;

	public ChatScript cscript;

	public GameObject[] enemylistall;

	public UnityScript.Lang.Array enlistalldist;

	private string myteam;

	private bool fpsmode;

	public GameObject[] flagsred;

	public GameObject[] flagsblue;

	public GUIStyle redflagskin;

	public GUIStyle blueflagskin;

	public GameObject[] alldead;

	public GUIStyle deadskin;

	public AIManager aimanager;

	private Vector3 offsetAim;

	private float offsetCounter;

	public Transform firePointObj;

	public GunController()
	{
		start = true;
		hitusername = string.Empty;
		GUIscale = 1f;
		badgelist = new UnityScript.Lang.Array();
		distances = new UnityScript.Lang.Array();
		enemylistarray = new UnityScript.Lang.Array();
		enemybadgelist = new UnityScript.Lang.Array();
		enemydist = new UnityScript.Lang.Array();
		enemydelete = new UnityScript.Lang.Array();
		enemytagstate = new UnityScript.Lang.Array();
		enlistalldist = new UnityScript.Lang.Array();
		myteam = string.Empty;
		offsetAim = Vector3.zero;
		offsetCounter = 2f;
	}

	public virtual void Start()
	{
		if (!((PhotonView)transform.root.GetComponent(typeof(PhotonView))).isMine && !aimanager.isAI)
		{
			enabled = false;
		}
		if (!((PhotonView)transform.root.GetComponent(typeof(PhotonView))).isMine)
		{
			return;
		}
		isOutOfRange = false;
		if (AuthGameObject.gametype != "Deathmatch" && AuthGameObject.gametype != "Survival" && !aimanager.isAI)
		{
			if (SpawningScript.team2 == "red")
			{
				myteam = "RedTeam";
			}
			else
			{
				myteam = "BlueTeam";
			}
		}
		if (!aimanager.isAI)
		{
			SpawningScript.playertrans.gameObject.tag = "Untagged";
		}
	}

	public virtual void Starter(bool start1)
	{
		start = start1;
	}

	public virtual void returnedname(string n)
	{
		enemybadgelist.Add(n);
	}

	public virtual void returnedteam(int t)
	{
		team = t;
	}

	public virtual void OnGUI()
	{
		if (HeadlesssDedServer.isServerHost || aimanager.isAI)
		{
			return;
		}
		GUI.depth = 0;
		int num = 155;
		int num2 = 30;
		float num3 = 0f;
		Vector3 vector = default(Vector3);
		int num4 = 0;
		IEnumerator enumerator = UnityRuntimeServices.GetEnumerator(enemybadgelist);
		while (enumerator.MoveNext())
		{
			object obj = enumerator.Current;
			if (!(obj is string))
			{
				obj = RuntimeServices.Coerce(obj, typeof(string));
			}
			string text = (string)obj;
			GameObject gameObject = enemylist[num4];
			UnityScript.Lang.Array array;
			if (gameObject != null)
			{
				vector = Camera.main.WorldToScreenPoint((!(gameObject.name == "HumanPrefab(Clone)")) ? gameObject.transform.position : gameObject.transform.Find("BadgePos").position);
				float num5 = RuntimeServices.UnboxSingle(enemydist[num4]);
				num3 = 1f - num5 / 650f;
				num3 = 80f * num3;
				if (!(num3 >= 40f))
				{
					num3 = 40f;
				}
				if (RuntimeServices.EqualityOperator(enemytagstate[num4], null))
				{
					array = new UnityScript.Lang.Array((IEnumerable)enemylist);
					array.RemoveAt(num4);
					enemylist = (GameObject[])array.ToBuiltin(typeof(GameObject));
					enemytagstate.RemoveAt(num4);
					enemydelete.RemoveAt(num4);
					enemylistarray.RemoveAt(num4);
					enemybadgelist.RemoveAt(num4);
					enemydist.RemoveAt(num4);
					continue;
				}
				float num6 = RuntimeServices.UnboxSingle(enemytagstate[num4]);
				if (AuthGameObject.gametype != "Freeplay" && AuthGameObject.gametype != "Deathmatch" && AuthGameObject.gametype != "Survival")
				{
					if (myteam == "BlueTeam")
					{
						GUI.color = Color.black;
						float a = num6;
						Color color = GUI.color;
						float num7 = (color.a = a);
						Color color2 = (GUI.color = color);
						GUILayout.BeginArea(new Rect(vector.x - 200f + 1f, (float)Screen.height - vector.y - num3 + 1f, 400f, num2));
						GUILayout.BeginHorizontal();
						GUILayout.FlexibleSpace();
						GUILayout.Label(text, redbadgeskin, GUILayout.Height(num2));
						UnityRuntimeServices.Update(enumerator, text);
						GUILayout.FlexibleSpace();
						GUILayout.EndHorizontal();
						GUILayout.EndArea();
						GUI.color = Color.white;
						float a2 = num6;
						Color color4 = GUI.color;
						float num8 = (color4.a = a2);
						Color color5 = (GUI.color = color4);
						GUILayout.BeginArea(new Rect(vector.x - 200f, (float)Screen.height - vector.y - num3, 400f, num2));
						GUILayout.BeginHorizontal();
						GUILayout.FlexibleSpace();
						GUILayout.Label(text, redbadgeskin, GUILayout.Height(num2));
						UnityRuntimeServices.Update(enumerator, text);
						GUILayout.FlexibleSpace();
						GUILayout.EndHorizontal();
						GUILayout.EndArea();
					}
					else
					{
						GUI.color = Color.black;
						float a3 = num6;
						Color color7 = GUI.color;
						float num9 = (color7.a = a3);
						Color color8 = (GUI.color = color7);
						GUILayout.BeginArea(new Rect(vector.x - 200f + 1f, (float)Screen.height - vector.y - num3 + 1f, 400f, num2));
						GUILayout.BeginHorizontal();
						GUILayout.FlexibleSpace();
						GUILayout.Label(text, badgeskin, GUILayout.Height(num2));
						UnityRuntimeServices.Update(enumerator, text);
						GUILayout.FlexibleSpace();
						GUILayout.EndHorizontal();
						GUILayout.EndArea();
						GUI.color = Color.white;
						float a4 = num6;
						Color color10 = GUI.color;
						float num10 = (color10.a = a4);
						Color color11 = (GUI.color = color10);
						GUILayout.BeginArea(new Rect(vector.x - 200f, (float)Screen.height - vector.y - num3, 400f, num2));
						GUILayout.BeginHorizontal();
						GUILayout.FlexibleSpace();
						GUILayout.Label(text, badgeskin, GUILayout.Height(num2));
						UnityRuntimeServices.Update(enumerator, text);
						GUILayout.FlexibleSpace();
						GUILayout.EndHorizontal();
						GUILayout.EndArea();
					}
				}
				else if (RefreshMasterServer.personjoined)
				{
					GUI.color = Color.black;
					float a5 = num6;
					Color color13 = GUI.color;
					float num11 = (color13.a = a5);
					Color color14 = (GUI.color = color13);
					GUILayout.BeginArea(new Rect(vector.x - 200f + 1f, (float)Screen.height - vector.y - num3 + 1f, 400f, num2));
					GUILayout.BeginHorizontal();
					GUILayout.FlexibleSpace();
					GUILayout.Label(text, redbadgeskin, GUILayout.Height(num2));
					UnityRuntimeServices.Update(enumerator, text);
					GUILayout.FlexibleSpace();
					GUILayout.EndHorizontal();
					GUILayout.EndArea();
					GUI.color = Color.white;
					float a6 = num6;
					Color color16 = GUI.color;
					float num12 = (color16.a = a6);
					Color color17 = (GUI.color = color16);
					GUILayout.BeginArea(new Rect(vector.x - 200f, (float)Screen.height - vector.y - num3, 400f, num2));
					GUILayout.BeginHorizontal();
					GUILayout.FlexibleSpace();
					GUILayout.Label(text, redbadgeskin, GUILayout.Height(num2));
					UnityRuntimeServices.Update(enumerator, text);
					GUILayout.FlexibleSpace();
					GUILayout.EndHorizontal();
					GUILayout.EndArea();
				}
				else
				{
					GUI.color = Color.black;
					float a7 = num6;
					Color color19 = GUI.color;
					float num13 = (color19.a = a7);
					Color color20 = (GUI.color = color19);
					GUILayout.BeginArea(new Rect(vector.x - 200f + 1f, (float)Screen.height - vector.y - num3 + 1f, 400f, num2));
					GUILayout.BeginHorizontal();
					GUILayout.FlexibleSpace();
					GUILayout.Label(text, badgeskin, GUILayout.Height(num2));
					UnityRuntimeServices.Update(enumerator, text);
					GUILayout.FlexibleSpace();
					GUILayout.EndHorizontal();
					GUILayout.EndArea();
					GUI.color = Color.white;
					float a8 = num6;
					Color color22 = GUI.color;
					float num14 = (color22.a = a8);
					Color color23 = (GUI.color = color22);
					GUILayout.BeginArea(new Rect(vector.x - 200f, (float)Screen.height - vector.y - num3, 400f, num2));
					GUILayout.BeginHorizontal();
					GUILayout.FlexibleSpace();
					GUILayout.Label(text, badgeskin, GUILayout.Height(num2));
					UnityRuntimeServices.Update(enumerator, text);
					GUILayout.FlexibleSpace();
					GUILayout.EndHorizontal();
					GUILayout.EndArea();
				}
				num4++;
				continue;
			}
			array = new UnityScript.Lang.Array((IEnumerable)enemylist);
			int num15 = 0;
			IEnumerator enumerator2 = UnityRuntimeServices.GetEnumerator(array);
			while (enumerator2.MoveNext())
			{
				object obj2 = enumerator2.Current;
				if (!(obj2 is GameObject))
				{
					obj2 = RuntimeServices.Coerce(obj2, typeof(GameObject));
				}
				GameObject gameObject2 = (GameObject)obj2;
				if (gameObject2 == gameObject)
				{
					array.RemoveAt(num15);
					enemytagstate.RemoveAt(num15);
					enemydelete.RemoveAt(num15);
					enemylistarray.RemoveAt(num15);
					enemybadgelist.RemoveAt(num15);
					enemydist.RemoveAt(num15);
				}
				num15++;
			}
			enemylist = (GameObject[])array.ToBuiltin(typeof(GameObject));
		}
		float a9 = 1f;
		Color color25 = GUI.color;
		float num16 = (color25.a = a9);
		Color color26 = (GUI.color = color25);
		if (AuthGameObject.gametype == "Capture the Flag")
		{
			int i = 0;
			GameObject[] array2 = flagsred;
			for (int length = array2.Length; i < length; i++)
			{
				if (!(array2[i] != null))
				{
					continue;
				}
				Transform transform = array2[i].transform;
				vector = Camera.main.WorldToScreenPoint(transform.position);
				if (!(vector.z <= 0f))
				{
					float sqrMagnitude;
					if (ChatScript.nicehud)
					{
						sqrMagnitude = (transform.transform.position - this.transform.position).sqrMagnitude;
						sqrMagnitude = Mathf.Sqrt(sqrMagnitude) - 5f;
					}
					else
					{
						sqrMagnitude = 150f;
					}
					sqrMagnitude -= sqrMagnitude / 650f * 5f;
					num3 = 1f - sqrMagnitude / 650f;
					num3 = 80f * num3;
					if (!(num3 >= 40f))
					{
						num3 = 40f;
					}
					GUI.Box(new Rect(vector.x - 8f, (float)Screen.height - vector.y - num3, 15f, 17f), string.Empty, redflagskin);
				}
			}
			int j = 0;
			GameObject[] array3 = flagsblue;
			for (int length2 = array3.Length; j < length2; j++)
			{
				if (!(array3[j] != null))
				{
					continue;
				}
				Transform transform = array3[j].transform;
				vector = Camera.main.WorldToScreenPoint(transform.position);
				if (!(vector.z <= 0f))
				{
					float sqrMagnitude;
					if (ChatScript.nicehud)
					{
						sqrMagnitude = (transform.transform.position - this.transform.position).sqrMagnitude;
						sqrMagnitude = Mathf.Sqrt(sqrMagnitude) - 5f;
					}
					else
					{
						sqrMagnitude = 150f;
					}
					sqrMagnitude -= sqrMagnitude / 650f * 5f;
					num3 = 1f - sqrMagnitude / 650f;
					num3 = 80f * num3;
					if (!(num3 >= 40f))
					{
						num3 = 40f;
					}
					GUI.Box(new Rect(vector.x - 8f, (float)Screen.height - vector.y - num3, 15f, 17f), string.Empty, blueflagskin);
				}
			}
		}
		int k = 0;
		GameObject[] array4 = alldead;
		for (int length3 = array4.Length; k < length3; k++)
		{
			if (!(array4[k] != null))
			{
				continue;
			}
			Transform transform2 = array4[k].transform;
			if (!transform2)
			{
				continue;
			}
			vector = Camera.main.WorldToScreenPoint(transform2.position);
			if (!(vector.z <= 0f))
			{
				float sqrMagnitude;
				if (ChatScript.nicehud)
				{
					sqrMagnitude = (transform2.transform.position - this.transform.position).sqrMagnitude;
					sqrMagnitude = Mathf.Sqrt(sqrMagnitude) - 5f;
				}
				else
				{
					sqrMagnitude = 150f;
				}
				sqrMagnitude -= sqrMagnitude / 650f * 5f;
				num3 = 1f - sqrMagnitude / 650f;
				num3 = 80f * num3;
				if (!(num3 >= 40f))
				{
					num3 = 40f;
				}
				GUI.Box(new Rect(vector.x - 8f, (float)Screen.height - vector.y - num3, 20f, 20f), string.Empty, deadskin);
			}
		}
		float a10 = 1f;
		Color color28 = GUI.color;
		float num17 = (color28.a = a10);
		Color color29 = (GUI.color = color28);
		float num18 = num3;
		int num19 = 0;
		IEnumerator enumerator3 = UnityRuntimeServices.GetEnumerator(badgelist);
		while (enumerator3.MoveNext())
		{
			object obj3 = enumerator3.Current;
			if (!(obj3 is string))
			{
				obj3 = RuntimeServices.Coerce(obj3, typeof(string));
			}
			string text2 = (string)obj3;
			if (!(text2 != null) || !(teamlist[num19] != null))
			{
				continue;
			}
			Transform transform3 = null;
			transform3 = ((teamlist[num19].name == "CarPrefab(Clone)") ? teamlist[num19].transform.Find("Colliders/MainBoxCol") : ((!(teamlist[num19].name == "HumanPrefab(Clone)")) ? teamlist[num19].transform : teamlist[num19].transform.Find("BadgePos")));
			vector = Camera.main.WorldToScreenPoint(transform3.position);
			if (!(vector.z <= 0f))
			{
				float num20 = RuntimeServices.UnboxSingle(distances[num19]);
				num3 = 1f - num20 / 650f;
				num3 = 80f * num3;
				if (!(num3 >= 40f))
				{
					num3 = 40f;
				}
				if (myteam == "RedTeam")
				{
					GUI.color = Color.black;
					GUILayout.BeginArea(new Rect(vector.x - 200f + 1f, (float)Screen.height - vector.y - num3 + 1f, 400f, num2));
					GUILayout.BeginHorizontal();
					GUILayout.FlexibleSpace();
					GUILayout.Label(text2, redbadgeskin, GUILayout.Height(num2));
					UnityRuntimeServices.Update(enumerator3, text2);
					GUILayout.FlexibleSpace();
					GUILayout.EndHorizontal();
					GUILayout.EndArea();
					GUI.color = Color.white;
					GUILayout.BeginArea(new Rect(vector.x - 200f, (float)Screen.height - vector.y - num3, 400f, num2));
					GUILayout.BeginHorizontal();
					GUILayout.FlexibleSpace();
					GUILayout.Label(text2, redbadgeskin, GUILayout.Height(num2));
					UnityRuntimeServices.Update(enumerator3, text2);
					GUILayout.FlexibleSpace();
					GUILayout.EndHorizontal();
					GUILayout.EndArea();
				}
				else
				{
					GUI.color = Color.black;
					GUILayout.BeginArea(new Rect(vector.x - 200f + 1f, (float)Screen.height - vector.y - num3 + 1f, 400f, num2));
					GUILayout.BeginHorizontal();
					GUILayout.FlexibleSpace();
					GUILayout.Label(text2, badgeskin, GUILayout.Height(num2));
					UnityRuntimeServices.Update(enumerator3, text2);
					GUILayout.FlexibleSpace();
					GUILayout.EndHorizontal();
					GUILayout.EndArea();
					GUI.color = Color.white;
					GUILayout.BeginArea(new Rect(vector.x - 200f, (float)Screen.height - vector.y - num3, 400f, num2));
					GUILayout.BeginHorizontal();
					GUILayout.FlexibleSpace();
					GUILayout.Label(text2, badgeskin, GUILayout.Height(num2));
					UnityRuntimeServices.Update(enumerator3, text2);
					GUILayout.FlexibleSpace();
					GUILayout.EndHorizontal();
					GUILayout.EndArea();
				}
			}
			num19++;
		}
		num4 = 0;
		int l = 0;
		GameObject[] array5 = enemylistall;
		for (int length4 = array5.Length; l < length4; l++)
		{
			if (array5[l] != null)
			{
				bool flag = default(bool);
				flag = false;
				int m = 0;
				GameObject[] array6 = enemylist;
				for (int length5 = array6.Length; m < length5; m++)
				{
					if (array6[m] == array5[l])
					{
						flag = true;
					}
				}
				if (!flag)
				{
					vector = Camera.main.WorldToScreenPoint((!(array5[l].name == "HumanPrefab(Clone)")) ? array5[l].transform.position : array5[l].transform.Find("BadgePos").position);
					if (!(vector.z <= 0f))
					{
						float num5 = RuntimeServices.UnboxSingle(enlistalldist[num4]);
						num3 = 1f - num5 / 650f;
						num3 = 80f * num3;
						num3 -= 5f;
						if (!(num3 >= 40f))
						{
							num3 = 40f;
						}
						if (AuthGameObject.gametype != "Freeplay" && AuthGameObject.gametype != "Deathmatch" && AuthGameObject.gametype != "Survival")
						{
							if (myteam == "BlueTeam")
							{
								GUI.Box(new Rect(vector.x - 10f, (float)Screen.height - vector.y - num3, 20f, 15f), string.Empty, enallred);
							}
							else
							{
								GUI.Box(new Rect(vector.x - 10f, (float)Screen.height - vector.y - num3, 20f, 15f), string.Empty, enallblue);
							}
						}
						else if (RefreshMasterServer.personjoined)
						{
							GUI.Box(new Rect(vector.x - 10f, (float)Screen.height - vector.y - num3, 20f, 15f), string.Empty, enallred);
						}
						else
						{
							GUI.Box(new Rect(vector.x - 10f, (float)Screen.height - vector.y - num3, 20f, 15f), string.Empty, enallblue);
						}
					}
				}
			}
			num4++;
		}
	}

	public virtual void returnedbadge(object n)
	{
		badgelist.Add(n);
	}

	public virtual IEnumerator fadein(int i)
	{
		return new _0024fadein_00244678(i, this).GetEnumerator();
	}

	public virtual IEnumerator fadeout(int i)
	{
		return new _0024fadeout_00244684(i, this).GetEnumerator();
	}

	public virtual void Update()
	{
		if (HeadlesssDedServer.isServerHost)
		{
			return;
		}
		startvar = start;
		if (!aimanager.isAI && ((PhotonView)transform.root.GetComponent(typeof(PhotonView))).isMine && start)
		{
			if (AuthGameObject.gametype == "Capture the Flag")
			{
				flagsred = GameObject.FindGameObjectsWithTag("RedFlag");
				flagsblue = GameObject.FindGameObjectsWithTag("BlueFlag");
			}
			alldead = GameObject.FindGameObjectsWithTag("DeadCars");
			GameObject[] array = GameObject.FindGameObjectsWithTag("minimap");
			if (RefreshMasterServer.personjoined)
			{
				if (myteam == "RedTeam" && AuthGameObject.gametype != "Freeplay" && AuthGameObject.gametype != "Deathmatch" && AuthGameObject.gametype != "Survival")
				{
					teamlist = GameObject.FindGameObjectsWithTag("RedTeam");
					enemylistall = GameObject.FindGameObjectsWithTag("BlueObjects");
					GameObject[] array2 = GameObject.FindGameObjectsWithTag("AttackBot");
					UnityScript.Lang.Array array3 = new UnityScript.Lang.Array((IEnumerable)teamlist);
					UnityScript.Lang.Array array4 = new UnityScript.Lang.Array((IEnumerable)enemylistall);
					int i = 0;
					GameObject[] array5 = array2;
					for (int length = array5.Length; i < length; i++)
					{
						if (array5[i].name == "BotRedAttack(Clone)")
						{
							array3.Add(array5[i]);
						}
						if (array5[i].name == "BotBlueAttack(Clone)")
						{
							array4.Add(array5[i]);
						}
					}
					int num = 0;
					UnityScript.Lang.Array array6 = new UnityScript.Lang.Array();
					IEnumerator enumerator = UnityRuntimeServices.GetEnumerator(array4);
					while (enumerator.MoveNext())
					{
						object current = enumerator.Current;
						if (RuntimeServices.EqualityOperator(UnityRuntimeServices.GetProperty(UnityRuntimeServices.GetProperty(current, "gameObject"), "name"), "MainBoxCol"))
						{
							object target = UnityRuntimeServices.Invoke(current, "GetComponent", new object[1] { typeof(CloakPickup) }, typeof(UnityEngine.MonoBehaviour));
							UnityRuntimeServices.Update(enumerator, current);
							if (RuntimeServices.EqualityOperator(RuntimeServices.Invoke(target, "returnCloakState", new object[0]), false))
							{
								array6.Add(current);
								UnityRuntimeServices.Update(enumerator, current);
							}
						}
						else
						{
							array6.Add(current);
							UnityRuntimeServices.Update(enumerator, current);
						}
						num++;
					}
					array4 = array6;
					teamlist = (GameObject[])array3.ToBuiltin(typeof(GameObject));
					enemylistall = (GameObject[])array4.ToBuiltin(typeof(GameObject));
				}
				else
				{
					teamlist = GameObject.FindGameObjectsWithTag("BlueTeam");
					enemylistall = GameObject.FindGameObjectsWithTag("RedObjects");
					GameObject[] array2 = GameObject.FindGameObjectsWithTag("AttackBot");
					UnityScript.Lang.Array array3 = new UnityScript.Lang.Array((IEnumerable)teamlist);
					UnityScript.Lang.Array array4 = new UnityScript.Lang.Array((IEnumerable)enemylistall);
					int j = 0;
					GameObject[] array7 = array2;
					for (int length2 = array7.Length; j < length2; j++)
					{
						if (array7[j].name == "BotRedAttack(Clone)")
						{
							array4.Add(array7[j]);
						}
						if (array7[j].name == "BotBlueAttack(Clone)")
						{
							array3.Add(array7[j]);
						}
					}
					int num = 0;
					UnityScript.Lang.Array array6 = new UnityScript.Lang.Array();
					IEnumerator enumerator2 = UnityRuntimeServices.GetEnumerator(array4);
					while (enumerator2.MoveNext())
					{
						object current2 = enumerator2.Current;
						if (RuntimeServices.EqualityOperator(UnityRuntimeServices.GetProperty(UnityRuntimeServices.GetProperty(current2, "gameObject"), "name"), "MainBoxCol"))
						{
							object target = UnityRuntimeServices.Invoke(current2, "GetComponent", new object[1] { typeof(CloakPickup) }, typeof(UnityEngine.MonoBehaviour));
							UnityRuntimeServices.Update(enumerator2, current2);
							if (RuntimeServices.EqualityOperator(RuntimeServices.Invoke(target, "returnCloakState", new object[0]), false))
							{
								array6.Add(current2);
								UnityRuntimeServices.Update(enumerator2, current2);
							}
						}
						else
						{
							array6.Add(current2);
							UnityRuntimeServices.Update(enumerator2, current2);
						}
						num++;
					}
					array4 = array6;
					teamlist = (GameObject[])array3.ToBuiltin(typeof(GameObject));
					enemylistall = (GameObject[])array4.ToBuiltin(typeof(GameObject));
				}
			}
			else
			{
				enemylistall = GameObject.FindGameObjectsWithTag("Bot");
			}
			UnityScript.Lang.Array array8 = new UnityScript.Lang.Array((IEnumerable)enemylist);
			int k = 0;
			GameObject[] array9 = array;
			for (int length3 = array9.Length; k < length3; k++)
			{
				if (!(array9[k].name == "CarPrefab(Clone)") && !(array9[k].name == "MainBoxCol") && !(array9[k].name == "HumanPrefab(Clone)"))
				{
					continue;
				}
				int num2 = 0;
				IEnumerator enumerator3 = UnityRuntimeServices.GetEnumerator(array8);
				while (enumerator3.MoveNext())
				{
					object obj = enumerator3.Current;
					if (!(obj is GameObject))
					{
						obj = RuntimeServices.Coerce(obj, typeof(GameObject));
					}
					GameObject gameObject = (GameObject)obj;
					if (array9[k] == gameObject)
					{
						array8.RemoveAt(num2);
						enemytagstate.RemoveAt(num2);
						enemydelete.RemoveAt(num2);
						enemylistarray.RemoveAt(num2);
						enemybadgelist.RemoveAt(num2);
						enemydist.RemoveAt(num2);
					}
					num2++;
				}
			}
			enemylist = (GameObject[])array8.ToBuiltin(typeof(GameObject));
			array8 = new UnityScript.Lang.Array((IEnumerable)teamlist);
			int l = 0;
			GameObject[] array10 = array;
			for (int length4 = array10.Length; l < length4; l++)
			{
				if (!(array10[l].name == "CarPrefab(Clone)") && !(array10[l].name == "MainBoxCol") && !(array10[l].name == "HumanPrefab(Clone)"))
				{
					continue;
				}
				int num2 = 0;
				IEnumerator enumerator4 = UnityRuntimeServices.GetEnumerator(array8);
				while (enumerator4.MoveNext())
				{
					object current3 = enumerator4.Current;
					if (RuntimeServices.EqualityOperator(array10[l], current3))
					{
						array8.RemoveAt(num2);
						badgelist.RemoveAt(num2);
						distances.RemoveAt(num2);
					}
					num2++;
				}
			}
			teamlist = (GameObject[])array8.ToBuiltin(typeof(GameObject));
			badgelist.Clear();
			int num3 = 0;
			int m = 0;
			GameObject[] array11 = teamlist;
			for (int length5 = array11.Length; m < length5; m++)
			{
				if ((bool)array11[m])
				{
					array11[m].SendMessage("returnbadge", this.gameObject, SendMessageOptions.DontRequireReceiver);
				}
				else
				{
					UnityScript.Lang.Array array12 = new UnityScript.Lang.Array((IEnumerable)teamlist);
					array12.RemoveAt(num3);
					teamlist = (GameObject[])array12.ToBuiltin(typeof(GameObject));
				}
				num3++;
			}
			distances.Clear();
			for (int n = 0; n < badgelist.length; n++)
			{
				float sqrMagnitude;
				if (ChatScript.nicehud)
				{
					sqrMagnitude = (teamlist[n].transform.position - transform.position).sqrMagnitude;
					sqrMagnitude = Mathf.Sqrt(sqrMagnitude) - 5f;
				}
				else
				{
					sqrMagnitude = 150f;
				}
				sqrMagnitude -= sqrMagnitude / 650f * 5f;
				distances.Add(sqrMagnitude);
			}
			enlistalldist.Clear();
			for (int n = 0; n < UnityScript.Lang.Extensions.get_length((System.Array)enemylistall); n++)
			{
				float sqrMagnitude;
				if (ChatScript.nicehud)
				{
					sqrMagnitude = (enemylistall[n].transform.position - transform.position).sqrMagnitude;
					sqrMagnitude = Mathf.Sqrt(sqrMagnitude) - 5f;
				}
				else
				{
					sqrMagnitude = 150f;
				}
				sqrMagnitude -= sqrMagnitude / 650f * 5f;
				enlistalldist.Add(sqrMagnitude);
			}
			Ray ray = Camera.main.ScreenPointToRay(Screen.lockCursor ? new Vector3(Screen.width / 2, Screen.height / 2, 0f) : ((!CrossHairDraw.useCursor) ? new Vector3(CrossHairDraw.crossHairPos.x, CrossHairDraw.crossHairPos.y, 0f) : Input.mousePosition));
			RaycastHit hitInfo = default(RaycastHit);
			if (Physics.Raycast(ray, out hitInfo, float.PositiveInfinity, layermask))
			{
				Debug.DrawLine(transform.position, hitInfo.point, Color.red);
				if (!(hitInfo.distance > 650f))
				{
					if (hitInfo.collider.gameObject.name == "MainBoxCol")
					{
						object target = hitInfo.collider.GetComponent("CloakPickup");
						if (RuntimeServices.EqualityOperator(RuntimeServices.Invoke(target, "returnCloakState", new object[0]), false))
						{
							if (myteam == "RedTeam" && AuthGameObject.gametype != "Freeplay" && AuthGameObject.gametype != "Deathmatch" && AuthGameObject.gametype != "Survival")
							{
								if (hitInfo.collider.gameObject.tag != "RedObjects" && hitInfo.collider.gameObject.tag != "RedInvis" && (hitInfo.collider.gameObject.tag == "BlueObjects" || hitInfo.collider.gameObject.tag == "BlueInvis"))
								{
									GUIscale = 1f - hitInfo.distance / 650f;
									bool flag = false;
									int num4 = 0;
									int num5 = 0;
									GameObject[] array13 = enemylist;
									for (int length6 = array13.Length; num5 < length6; num5++)
									{
										if (array13[num5] == hitInfo.collider.transform.gameObject)
										{
											flag = true;
											enemydelete[num4] = 5f;
										}
										num4++;
									}
									if (!flag)
									{
										enemylistarray.Add(hitInfo.collider.transform.gameObject);
										enemydelete.Add(5f);
										enemytagstate.Add(0f);
										StartCoroutine_Auto(fadein(enemytagstate.length - 1));
										enemylist = (GameObject[])enemylistarray.ToBuiltin(typeof(GameObject));
									}
								}
							}
							else if (hitInfo.collider.gameObject.tag != "BlueObjects" && hitInfo.collider.gameObject.tag != "BlueInvis" && (hitInfo.collider.gameObject.tag == "RedObjects" || hitInfo.collider.gameObject.tag == "RedInvis"))
							{
								GUIscale = 1f - hitInfo.distance / 650f;
								bool flag = false;
								int num4 = 0;
								int num6 = 0;
								GameObject[] array14 = enemylist;
								for (int length7 = array14.Length; num6 < length7; num6++)
								{
									if (array14[num6] == hitInfo.collider.transform.gameObject)
									{
										flag = true;
										enemydelete[num4] = 5f;
									}
									num4++;
								}
								if (!flag)
								{
									enemylistarray.Add(hitInfo.collider.transform.gameObject);
									enemydelete.Add(5f);
									enemytagstate.Add(0f);
									StartCoroutine_Auto(fadein(enemytagstate.length - 1));
									enemylist = (GameObject[])enemylistarray.ToBuiltin(typeof(GameObject));
								}
							}
						}
					}
					if (hitInfo.collider.gameObject.name == "HumanPrefab(Clone)")
					{
						if (myteam == "RedTeam" && AuthGameObject.gametype != "Freeplay" && AuthGameObject.gametype != "Deathmatch" && AuthGameObject.gametype != "Survival")
						{
							if (hitInfo.collider.gameObject.tag != "RedObjects" && hitInfo.collider.gameObject.tag != "RedInvis" && (hitInfo.collider.gameObject.tag == "BlueObjects" || hitInfo.collider.gameObject.tag == "BlueInvis"))
							{
								GUIscale = 1f - hitInfo.distance / 650f;
								bool flag = false;
								int num4 = 0;
								int num7 = 0;
								GameObject[] array15 = enemylist;
								for (int length8 = array15.Length; num7 < length8; num7++)
								{
									if (array15[num7] == hitInfo.collider.transform.gameObject)
									{
										flag = true;
										enemydelete[num4] = 5f;
									}
									num4++;
								}
								if (!flag)
								{
									enemylistarray.Add(hitInfo.collider.transform.gameObject);
									enemydelete.Add(5f);
									enemytagstate.Add(0f);
									StartCoroutine_Auto(fadein(enemytagstate.length - 1));
									enemylist = (GameObject[])enemylistarray.ToBuiltin(typeof(GameObject));
								}
							}
						}
						else if (hitInfo.collider.gameObject.tag != "BlueObjects" && hitInfo.collider.gameObject.tag != "BlueInvis" && (hitInfo.collider.gameObject.tag == "RedObjects" || hitInfo.collider.gameObject.tag == "RedInvis"))
						{
							GUIscale = 1f - hitInfo.distance / 650f;
							bool flag = false;
							int num4 = 0;
							int num8 = 0;
							GameObject[] array16 = enemylist;
							for (int length9 = array16.Length; num8 < length9; num8++)
							{
								if (array16[num8] == hitInfo.collider.transform.gameObject)
								{
									flag = true;
									enemydelete[num4] = 5f;
								}
								num4++;
							}
							if (!flag)
							{
								enemylistarray.Add(hitInfo.collider.transform.gameObject);
								enemydelete.Add(5f);
								enemytagstate.Add(0f);
								StartCoroutine_Auto(fadein(enemytagstate.length - 1));
								enemylist = (GameObject[])enemylistarray.ToBuiltin(typeof(GameObject));
							}
						}
					}
				}
				enemybadgelist.Clear();
				int num9 = 0;
				GameObject[] array17 = enemylist;
				for (int length10 = array17.Length; num9 < length10; num9++)
				{
					array17[num9].SendMessage("returnpname", this.gameObject, SendMessageOptions.DontRequireReceiver);
					float sqrMagnitude;
					if (ChatScript.nicehud)
					{
						sqrMagnitude = (array17[num9].transform.position - transform.position).sqrMagnitude;
						sqrMagnitude = Mathf.Sqrt(sqrMagnitude) - 5f;
					}
					else
					{
						sqrMagnitude = 150f;
					}
					sqrMagnitude -= sqrMagnitude / 650f * 5f;
					enemydist.Add(sqrMagnitude);
				}
				int num10 = 0;
				IEnumerator enumerator5 = UnityRuntimeServices.GetEnumerator(enemydelete);
				while (enumerator5.MoveNext())
				{
					float num11 = RuntimeServices.UnboxSingle(enumerator5.Current);
					float num12 = RuntimeServices.UnboxSingle(enemydelete[num10]);
					bool flag2 = false;
					if (!(num11 <= 0f))
					{
						enemydelete[num10] = num12 - Time.deltaTime;
					}
					else
					{
						flag2 = true;
					}
					if (!(Camera.main.WorldToScreenPoint(enemylist[num10].transform.position).z >= 0f))
					{
						flag2 = true;
					}
					if (flag2)
					{
						StartCoroutine_Auto(fadeout(num10));
					}
					flag2 = false;
					num10++;
				}
				if (!fpsmode)
				{
					maingun.LookAt(hitInfo.point);
					int num13 = 0;
					Quaternion localRotation = maingun.localRotation;
					float num14 = (localRotation.x = num13);
					Quaternion quaternion = (maingun.localRotation = localRotation);
					int num15 = 0;
					Quaternion localRotation2 = maingun.localRotation;
					float num16 = (localRotation2.z = num15);
					Quaternion quaternion3 = (maingun.localRotation = localRotation2);
					float x = guntrans.localRotation.x;
					if (!(x > 0.18f))
					{
						float y = guntrans.InverseTransformPoint(playerT.position).y;
						guntrans.LookAt(hitInfo.point + new Vector3(0f, y, 0f));
						int num17 = 0;
						Quaternion localRotation3 = guntrans.localRotation;
						float num18 = (localRotation3.y = num17);
						Quaternion quaternion5 = (guntrans.localRotation = localRotation3);
						int num19 = 0;
						Quaternion localRotation4 = guntrans.localRotation;
						float num20 = (localRotation4.z = num19);
						Quaternion quaternion7 = (guntrans.localRotation = localRotation4);
					}
					x = guntrans.localRotation.x;
					if (!(x < 0.18f))
					{
						float x2 = 0.18f;
						Quaternion localRotation5 = guntrans.localRotation;
						float num21 = (localRotation5.x = x2);
						Quaternion quaternion9 = (guntrans.localRotation = localRotation5);
						int num22 = 0;
						Quaternion localRotation6 = guntrans.localRotation;
						float num23 = (localRotation6.y = num22);
						Quaternion quaternion11 = (guntrans.localRotation = localRotation6);
						int num24 = 0;
						Quaternion localRotation7 = guntrans.localRotation;
						float num25 = (localRotation7.z = num24);
						Quaternion quaternion13 = (guntrans.localRotation = localRotation7);
					}
					firePointObj.LookAt(hitInfo.point);
				}
				else
				{
					firePointObj.localRotation = Quaternion.identity;
				}
			}
		}
		if (aimanager.isAI && (bool)aimanager.target)
		{
			Vector3 vector = default(Vector3);
			vector = ((!(aimanager.target.gameObject.name == "HumanPrefab(Clone)")) ? (aimanager.target.position + new Vector3(0f, (aimanager.firetype != 0) ? 1 : 2, 0f) + aimanager.target.rigidbody.velocity * (Vector3.Distance(transform.position, aimanager.target.position) / 500f)) : aimanager.target.position);
			if (!(offsetCounter <= 0f))
			{
				offsetCounter -= Time.deltaTime;
			}
			else
			{
				offsetCounter = 0.5f;
				offsetAim = Vector3.Lerp(offsetAim, new Vector3(UnityEngine.Random.Range(5f * (30f / (float)(aimanager.aiDiff + 1)), -5f * (30f / (float)(aimanager.aiDiff + 1))), UnityEngine.Random.Range(5f * (30f / (float)(aimanager.aiDiff + 1)), -5f * (30f / (float)(aimanager.aiDiff + 1))), UnityEngine.Random.Range(5f * (30f / (float)(aimanager.aiDiff + 1)), -5f * (30f / (float)(aimanager.aiDiff + 1)))), 5f * Time.deltaTime);
			}
			vector += offsetAim;
			Debug.DrawLine(transform.position, vector, Color.white);
			maingun.LookAt(vector);
			int num26 = 0;
			Quaternion localRotation8 = maingun.localRotation;
			float num27 = (localRotation8.x = num26);
			Quaternion quaternion15 = (maingun.localRotation = localRotation8);
			int num28 = 0;
			Quaternion localRotation9 = maingun.localRotation;
			float num29 = (localRotation9.z = num28);
			Quaternion quaternion17 = (maingun.localRotation = localRotation9);
			float x = guntrans.localRotation.x;
			if (!(x > 0.18f))
			{
				guntrans.LookAt(vector);
				int num30 = 0;
				Quaternion localRotation10 = guntrans.localRotation;
				float num31 = (localRotation10.y = num30);
				Quaternion quaternion19 = (guntrans.localRotation = localRotation10);
				int num32 = 0;
				Quaternion localRotation11 = guntrans.localRotation;
				float num33 = (localRotation11.z = num32);
				Quaternion quaternion21 = (guntrans.localRotation = localRotation11);
			}
			x = guntrans.localRotation.x;
			if (!(x < 0.18f))
			{
				float x3 = 0.18f;
				Quaternion localRotation12 = guntrans.localRotation;
				float num34 = (localRotation12.x = x3);
				Quaternion quaternion23 = (guntrans.localRotation = localRotation12);
				int num35 = 0;
				Quaternion localRotation13 = guntrans.localRotation;
				float num36 = (localRotation13.y = num35);
				Quaternion quaternion25 = (guntrans.localRotation = localRotation13);
				int num37 = 0;
				Quaternion localRotation14 = guntrans.localRotation;
				float num38 = (localRotation14.z = num37);
				Quaternion quaternion27 = (guntrans.localRotation = localRotation14);
			}
		}
	}

	public virtual void setfpsmode(bool t)
	{
		fpsmode = t;
	}

	public virtual void Main()
	{
	}
}
