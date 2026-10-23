using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Photon;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class EnableDisableArmor01 : Photon.MonoBehaviour
{
	[Serializable]
	internal sealed class _0024setRenderer_00243630 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal int _0024i_00243631;

			internal bool _0024t_00243632;

			internal int _0024vt_00243633;

			internal EnableDisableArmor01 _0024self__00243634;

			public _0024(bool t, int vt, EnableDisableArmor01 self_)
			{
				_0024t_00243632 = t;
				_0024vt_00243633 = vt;
				_0024self__00243634 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00243634.armor = _0024t_00243632;
					if (_0024t_00243632)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					for (_0024i_00243631 = 0; _0024i_00243631 < UnityScript.Lang.Extensions.get_length((System.Array)_0024self__00243634.armorArr); _0024i_00243631++)
					{
						_0024self__00243634.armorArr[_0024i_00243631].enabled = false;
						_0024self__00243634.armorArr[_0024i_00243631].gameObject.layer = 16;
					}
					goto IL_0193;
				case 2:
					result = (YieldDefault(3) ? 1 : 0);
					break;
				case 3:
					for (_0024i_00243631 = 0; _0024i_00243631 < UnityScript.Lang.Extensions.get_length((System.Array)_0024self__00243634.armorArr); _0024i_00243631++)
					{
						if (_0024vt_00243633 == _0024i_00243631)
						{
							_0024self__00243634.armorArr[_0024i_00243631].enabled = true;
							_0024self__00243634.armorArr[_0024i_00243631].gameObject.active = true;
							_0024self__00243634.armorArr[_0024i_00243631].gameObject.layer = 10;
						}
						else
						{
							_0024self__00243634.armorArr[_0024i_00243631].enabled = false;
							_0024self__00243634.armorArr[_0024i_00243631].gameObject.layer = 16;
						}
					}
					goto IL_0193;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0193:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal bool _0024t_00243635;

		internal int _0024vt_00243636;

		internal EnableDisableArmor01 _0024self__00243637;

		public _0024setRenderer_00243630(bool t, int vt, EnableDisableArmor01 self_)
		{
			_0024t_00243635 = t;
			_0024vt_00243636 = vt;
			_0024self__00243637 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024t_00243635, _0024vt_00243636, _0024self__00243637);
		}
	}

	[Serializable]
	internal sealed class _0024Start_00243638 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal EnableDisableArmor01 _0024self__00243639;

			public _0024(EnableDisableArmor01 self_)
			{
				_0024self__00243639 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__00243639.photonView.isMine && !_0024self__00243639.aimanager.isAI)
					{
						PhotonNetwork.RemoveRPCs(_0024self__00243639.photonView);
						if (!ChatScript.hasghost)
						{
							((PhotonView)_0024self__00243639.gameObject.GetComponent(typeof(PhotonView))).RPC("setRenderer", PhotonTargets.AllBuffered, ChatScript.hasarmor1, ChatScript.vehicleType);
						}
						if (ChatScript.hasgold)
						{
							((PhotonView)_0024self__00243639.gameObject.GetComponent(typeof(PhotonView))).RPC("setPlating", PhotonTargets.AllBuffered, "gold");
						}
						if (ChatScript.hasplatinum)
						{
							((PhotonView)_0024self__00243639.gameObject.GetComponent(typeof(PhotonView))).RPC("setPlating", PhotonTargets.AllBuffered, "platinum");
						}
						if (ChatScript.hasfiber)
						{
							((PhotonView)_0024self__00243639.gameObject.GetComponent(typeof(PhotonView))).RPC("setPlating", PhotonTargets.AllBuffered, "fiber");
						}
						if (ChatScript.hascrystal)
						{
							((PhotonView)_0024self__00243639.gameObject.GetComponent(typeof(PhotonView))).RPC("setPlating", PhotonTargets.AllBuffered, "crystal");
						}
						if (ChatScript.hascamo)
						{
							((PhotonView)_0024self__00243639.gameObject.GetComponent(typeof(PhotonView))).RPC("setPlating", PhotonTargets.AllBuffered, "camo");
						}
						if (ChatScript.hasrust)
						{
							((PhotonView)_0024self__00243639.gameObject.GetComponent(typeof(PhotonView))).RPC("setPlating", PhotonTargets.AllBuffered, "rust");
						}
						if (ChatScript.hasneon)
						{
							((PhotonView)_0024self__00243639.gameObject.GetComponent(typeof(PhotonView))).RPC("setPlating", PhotonTargets.AllBuffered, "neon");
						}
						if (ChatScript.hasaqua)
						{
							((PhotonView)_0024self__00243639.gameObject.GetComponent(typeof(PhotonView))).RPC("setPlating", PhotonTargets.AllBuffered, "aqua");
						}
						if (ChatScript.hasgrib)
						{
							((PhotonView)_0024self__00243639.gameObject.GetComponent(typeof(PhotonView))).RPC("setRibbon", PhotonTargets.AllBuffered, "g");
						}
						if (ChatScript.hasrrib)
						{
							((PhotonView)_0024self__00243639.gameObject.GetComponent(typeof(PhotonView))).RPC("setRibbon", PhotonTargets.AllBuffered, "r");
						}
						if (ChatScript.hasmelee)
						{
							((PhotonView)_0024self__00243639.gameObject.GetComponent(typeof(PhotonView))).RPC("setBody", PhotonTargets.AllBuffered);
						}
						if (ChatScript.hasghost)
						{
							((PhotonView)_0024self__00243639.gameObject.GetComponent(typeof(PhotonView))).RPC("setGhost", PhotonTargets.AllBuffered);
						}
						if (ChatScript.hasglider)
						{
							((PhotonView)_0024self__00243639.gameObject.GetComponent(typeof(PhotonView))).RPC("setGlider", PhotonTargets.AllBuffered);
						}
					}
					result = (YieldDefault(2) ? 1 : 0);
					break;
				case 2:
					if (PhotonNetwork.isMasterClient && _0024self__00243639.aimanager.isAI && _0024self__00243639.aimanager.armorLevel == 0)
					{
						((PhotonView)_0024self__00243639.gameObject.GetComponent(typeof(PhotonView))).RPC("setRenderer", PhotonTargets.AllBuffered, true, 0);
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

		internal EnableDisableArmor01 _0024self__00243640;

		public _0024Start_00243638(EnableDisableArmor01 self_)
		{
			_0024self__00243640 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00243640);
		}
	}

	public ChatScript cscript;

	public GameObject maincar;

	public Renderer[] meshes;

	public Material goldmat;

	public Material platinummat;

	public Material carbonfibermat;

	public Material crystalmat;

	public Material camomat;

	public Material rustmat;

	public Material neonmat;

	public Material aquamat;

	public GameObject meleeblade;

	public Renderer gtrbasic;

	public AIManager aimanager;

	public GameObject ghost;

	public GameObject[] ghostWheels;

	public GameObject greenribbon;

	public GameObject redribbon;

	public GameObject glider;

	private bool hasgtrcar;

	private string platingType;

	private bool armor;

	private bool melee;

	private bool ghostb;

	private string ribbonType;

	public Renderer[] armorArr;

	[RPC]
	public virtual IEnumerator setRenderer(bool t, int vt)
	{
		return new _0024setRenderer_00243630(t, vt, this).GetEnumerator();
	}

	public virtual void Awake()
	{
		ghost.active = false;
		meleeblade.SetActiveRecursively(false);
		glider.active = false;
	}

	public virtual IEnumerator Start()
	{
		return new _0024Start_00243638(this).GetEnumerator();
	}

	[RPC]
	public virtual void setRibbon(string t)
	{
		if (t == "g")
		{
			greenribbon.renderer.enabled = true;
			ribbonType = "g";
		}
		else if (t == "r")
		{
			redribbon.renderer.enabled = true;
			ribbonType = "r";
		}
	}

	[RPC]
	public virtual void setBody()
	{
		meleeblade.SetActiveRecursively(true);
		melee = true;
	}

	[RPC]
	public virtual void setGlider()
	{
		glider.active = true;
	}

	[RPC]
	public virtual void setGhost()
	{
		ghost.active = true;
		ghostb = true;
	}

	[RPC]
	public virtual void setPlating(string t)
	{
		platingType = t;
		int i = 0;
		Renderer[] array = meshes;
		for (int length = array.Length; i < length; i++)
		{
			UnityScript.Lang.Array array2 = new UnityScript.Lang.Array();
			int j = 0;
			Material[] materials = array[i].materials;
			for (int length2 = materials.Length; j < length2; j++)
			{
				if (materials[j].name.Contains("porsche-textured-default"))
				{
					if (t == "gold")
					{
						array2.Add(goldmat);
					}
					if (t == "platinum")
					{
						array2.Add(platinummat);
					}
					if (t == "fiber")
					{
						array2.Add(carbonfibermat);
					}
					if (t == "crystal")
					{
						array2.Add(crystalmat);
					}
					if (t == "camo")
					{
						array2.Add(camomat);
					}
					if (t == "rust")
					{
						array2.Add(rustmat);
					}
					if (t == "neon")
					{
						array2.Add(neonmat);
					}
					if (t == "aqua")
					{
						array2.Add(aquamat);
					}
				}
				else
				{
					array2.Add(materials[j]);
				}
			}
			array[i].materials = (Material[])array2.ToBuiltin(typeof(Material));
		}
	}
}
