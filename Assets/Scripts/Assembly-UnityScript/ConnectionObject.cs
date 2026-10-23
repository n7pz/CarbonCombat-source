using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Photon;
using UnityEngine;

[Serializable]
public class ConnectionObject : Photon.MonoBehaviour
{
	[Serializable]
	internal sealed class _0024fakeConnect_00244576 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal float _0024t_00244577;

			internal ConnectionObject _0024self__00244578;

			public _0024(float t, ConnectionObject self_)
			{
				_0024t_00244577 = t;
				_0024self__00244578 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00244578.isconnectingtoai = true;
					_0024self__00244578.status = "Attempting to connect to the player's server. This might take a moment.";
					_0024self__00244578.StartCoroutine_Auto(_0024self__00244578.fadein());
					result = (Yield(2, new WaitForSeconds(_0024t_00244577)) ? 1 : 0);
					break;
				case 2:
					_0024self__00244578.status = "Successfully connected! Joining the game...";
					_0024self__00244578.StartCoroutine_Auto(_0024self__00244578.fadeOut());
					_0024self__00244578.isconnectingtoai = false;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal float _0024t_00244579;

		internal ConnectionObject _0024self__00244580;

		public _0024fakeConnect_00244576(float t, ConnectionObject self_)
		{
			_0024t_00244579 = t;
			_0024self__00244580 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024t_00244579, _0024self__00244580);
		}
	}

	[Serializable]
	internal sealed class _0024fadein_00244581 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal ConnectionObject _0024self__00244582;

			public _0024(ConnectionObject self_)
			{
				_0024self__00244582 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__00244582.alpha < 1f)
					{
						_0024self__00244582.alpha += 2f * Time.deltaTime;
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024self__00244582.alpha = 1f;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal ConnectionObject _0024self__00244583;

		public _0024fadein_00244581(ConnectionObject self_)
		{
			_0024self__00244583 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00244583);
		}
	}

	[Serializable]
	internal sealed class _0024fadeOut_00244584 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal ConnectionObject _0024self__00244585;

			public _0024(ConnectionObject self_)
			{
				_0024self__00244585 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					result = (Yield(2, new WaitForSeconds(2f)) ? 1 : 0);
					break;
				case 2:
				case 3:
					if (_0024self__00244585.alpha > 0f)
					{
						_0024self__00244585.alpha -= 2f * Time.deltaTime;
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					_0024self__00244585.alpha = 0f;
					_0024self__00244585.fadeonce = false;
					_0024self__00244585.fadeoutonce = false;
					_0024self__00244585.timeout = 10f;
					_0024self__00244585.succon = false;
					_0024self__00244585.firstattempt = false;
					_0024self__00244585.status = "Attempting to connect to the player's server. This might take a moment.";
					_0024self__00244585.msc.SendMessage("setconobj", false);
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal ConnectionObject _0024self__00244586;

		public _0024fadeOut_00244584(ConnectionObject self_)
		{
			_0024self__00244586 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00244586);
		}
	}

	public GUIStyle backgroundimage;

	public GUIStyle txtstyle;

	private float alpha;

	private string status;

	public Color normcolor;

	public Color warningcolor;

	public Color goodcolor;

	public Color badcolor;

	public GameObject msc;

	public MasterServerScript mscsrc;

	private bool fadeonce;

	private bool fadeoutonce;

	private float timeout;

	[NonSerialized]
	public static float pubalpha;

	private bool succon;

	private bool firstattempt;

	private bool isconnecting;

	private bool isconnectingtoai;

	public ConnectionObject()
	{
		status = "Attempting to connect to the player's server. This might take a moment.";
		timeout = 10f;
	}

	public virtual void OnGUI()
	{
		GUI.depth = 0;
		float a = alpha;
		Color color = GUI.color;
		float num = (color.a = a);
		Color color2 = (GUI.color = color);
		GUI.BeginGroup(new Rect(Screen.width / 2 - 144, Screen.height / 2 - 50, 288f, 100f));
		GUI.Box(new Rect(0f, 0f, 288f, 100f), "Connecting To Server", backgroundimage);
		if (status == "Attempting to connect to the player's server. This might take a moment.")
		{
			GUI.color = normcolor;
		}
		if (status == "Connection failed! The server is probably full.")
		{
			GUI.color = badcolor;
		}
		if (status == "Successfully connected! Joining the game...")
		{
			GUI.color = goodcolor;
		}
		float a2 = alpha;
		Color color4 = GUI.color;
		float num2 = (color4.a = a2);
		Color color5 = (GUI.color = color4);
		GUI.Label(new Rect(14f, 45f, 260f, 25f), status, txtstyle);
		GUI.EndGroup();
	}

	public virtual IEnumerator fakeConnect(float t)
	{
		return new _0024fakeConnect_00244576(t, this).GetEnumerator();
	}

	public virtual void Update()
	{
		pubalpha = alpha;
		if (MasterServerScript.conobj && !fadeonce)
		{
			fadeonce = true;
			StartCoroutine_Auto(fadein());
		}
	}

	public virtual void OnPhotonJoinRoomFailed()
	{
		status = "Connection failed! The server is probably full.";
		StartCoroutine_Auto(fadeOut());
	}

	public virtual void Awake()
	{
		fadeonce = false;
		alpha = 0f;
	}

	public virtual void OnFailedToConnect_OBSELETE()
	{
		if (!firstattempt)
		{
			firstattempt = true;
			status = "Re-attempting to connect to the player's server. This might take a moment.";
			timeout = 10f;
		}
		else
		{
			status = "Connection failed. Please turn off your NAT firewall or try another server.";
			StartCoroutine_Auto(fadeOut());
		}
	}

	public virtual void OnJoinedRoom()
	{
		if (PhotonNetwork.room.name != "chatRoom2")
		{
			succon = true;
			status = "Successfully connected! Joining the game...";
			StartCoroutine_Auto(fadeOut());
		}
	}

	public virtual IEnumerator fadein()
	{
		return new _0024fadein_00244581(this).GetEnumerator();
	}

	public virtual IEnumerator fadeOut()
	{
		return new _0024fadeOut_00244584(this).GetEnumerator();
	}
}
