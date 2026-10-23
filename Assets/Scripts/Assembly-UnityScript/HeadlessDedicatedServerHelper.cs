using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using Photon;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class HeadlessDedicatedServerHelper : Photon.MonoBehaviour
{
	[Serializable]
	internal sealed class _0024Start_00243994 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal GameObject _0024spawnpoint_00243995;

			internal HeadlessDedicatedServerHelper _0024self__00243996;

			public _0024(HeadlessDedicatedServerHelper self_)
			{
				_0024self__00243996 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (HeadlesssDedServer.isServerHost)
					{
						PhotonNetwork.sendRate = 11;
						if (Application.loadedLevelName == "CCWhirldScene")
						{
							goto case 2;
						}
						goto IL_0061;
					}
					goto IL_00bc;
				case 2:
					if (!GameObject.Find("/Spawn Point"))
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					goto IL_0061;
				case 1:
					{
						result = 0;
						break;
					}
					IL_00bc:
					YieldDefault(1);
					goto case 1;
					IL_0061:
					_0024spawnpoint_00243995 = GameObject.Find("/Spawn Point");
					if (!(Rigidbody)_0024spawnpoint_00243995.GetComponent(typeof(Rigidbody)))
					{
						_0024spawnpoint_00243995.AddComponent(typeof(Rigidbody));
					}
					_0024spawnpoint_00243995.rigidbody.isKinematic = true;
					goto IL_00bc;
				}
				return (byte)result != 0;
			}
		}

		internal HeadlessDedicatedServerHelper _0024self__00243997;

		public _0024Start_00243994(HeadlessDedicatedServerHelper self_)
		{
			_0024self__00243997 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00243997);
		}
	}

	public HeadlesssDedServer headless;

	public AudioController acon;

	public AuthGameObject authobj;

	public GUIStyle labelStyle;

	public virtual IEnumerator Start()
	{
		return new _0024Start_00243994(this).GetEnumerator();
	}

	public virtual void OnGUI()
	{
		if (HeadlesssDedServer.isServerHost)
		{
			GUI.Label(new Rect(0f, 0f, Screen.width, Screen.height), "Hosting for player " + AuthGameObject.username, labelStyle);
		}
	}

	public virtual void Update()
	{
		if (HeadlesssDedServer.isServerHost)
		{
			AudioController.hideGUI = true;
			AudioListener.volume = 0f;
			if (RuntimeServices.EqualityOperator(UnityRuntimeServices.GetProperty(PhotonNetwork.playerList, "Count"), 1))
			{
				Application.targetFrameRate = 11;
			}
			else
			{
				Application.targetFrameRate = 22;
			}
			if (RuntimeServices.ToBool(RuntimeServices.InvokeBinaryOperator("op_LessThanOrEqual", UnityRuntimeServices.GetProperty(PhotonNetwork.playerList, "Count"), 0)))
			{
				PhotonNetwork.LeaveRoom();
				MasterServer.UnregisterHost();
				Application.LoadLevel("Menu");
			}
		}
	}
}
