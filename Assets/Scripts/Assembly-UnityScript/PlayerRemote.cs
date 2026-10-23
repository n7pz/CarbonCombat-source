using System;
using Boo.Lang.Runtime;
using Photon;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class PlayerRemote : Photon.MonoBehaviour
{
	private Vector3 p;

	private Quaternion r;

	private State[] buffer;

	public double smoothedPacketTime;

	private int frameCounter;

	public float smoothExtrapAmount;

	private Vector3 smoothedVel;

	public Transform posY;

	public Transform rotY;

	public Transform rotX;

	private float pY;

	private float rY;

	private float rX;

	public WheelCollider[] wheelCols;

	public GameObject[] wheelMeshes;

	private Behaviour[] wheelScripts;

	private int wRPM;

	public GameObject healthObj;

	private int health;

	private int syncMethod;

	private float syncCounter;

	private AuthGameObject authobj;

	private MasterServerScript mserver;

	private double lerpTime;

	private double lerpTimeCounter;

	private double rCounter;

	private double smoothedInterpTime;

	private double smoothedNetworkTime;

	private double lastNetTime;

	private double smoothedDeltaNetTime;

	private double deltaCounter;

	private float timeSinceLastUpdate;

	public string networkStatus;

	private int updateInterval;

	private float calcFPS;

	private float accum;

	private int frames;

	private float timeleft;

	public PlayerRemote()
	{
		buffer = new State[10];
		smoothedPacketTime = 6.0;
		frameCounter = 1;
		smoothExtrapAmount = 12.5f;
		wheelCols = new WheelCollider[4];
		wheelMeshes = new GameObject[4];
		wheelScripts = new Behaviour[4];
		smoothedInterpTime = 0.07999999821186066;
		deltaCounter = 1.0;
		networkStatus = string.Empty;
		updateInterval = 5;
		calcFPS = 60f;
	}

	[RPC]
	public virtual void setRPCSync()
	{
		photonView.synchronization = ViewSynchronization.Off;
		syncMethod = 1;
	}

	public virtual void Start()
	{
		if (!photonView.isMine)
		{
			int i = 0;
			WheelCollider[] array = wheelCols;
			for (int length = array.Length; i < length; i++)
			{
				array[i].gameObject.active = false;
			}
		}
		for (int j = 0; j < 4; j++)
		{
			wheelScripts[j] = (WheelAlignment_Script)wheelMeshes[j].GetComponent(typeof(WheelAlignment_Script));
		}
	}

	public virtual void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if (syncMethod != 0)
		{
			return;
		}
		if (stream.isWriting)
		{
			p = rigidbody.position;
			r = rigidbody.rotation;
			pY = posY.localPosition.y;
			rY = rotY.localRotation.eulerAngles.y;
			rX = rotX.localRotation.eulerAngles.x;
			wRPM = (int)Mathf.Round((wheelCols[0].rpm + wheelCols[1].rpm + wheelCols[2].rpm + wheelCols[3].rpm) / 4f);
			health = UnityBuiltins.parseInt(healthObj.name);
			stream.SendNext(p);
			stream.SendNext(r);
			stream.SendNext(pY);
			stream.SendNext(rY);
			stream.SendNext(rX);
			stream.SendNext(wRPM);
			stream.SendNext(health);
		}
		else
		{
			if (photonView.isMine)
			{
				return;
			}
			p = (Vector3)stream.ReceiveNext();
			r = (Quaternion)stream.ReceiveNext();
			pY = RuntimeServices.UnboxSingle(stream.ReceiveNext());
			rY = RuntimeServices.UnboxSingle(stream.ReceiveNext());
			rX = RuntimeServices.UnboxSingle(stream.ReceiveNext());
			wRPM = RuntimeServices.UnboxInt32(stream.ReceiveNext());
			health = RuntimeServices.UnboxInt32(stream.ReceiveNext());
			State state = new State(p, r, (float)info.timestamp, rigidbody.position, rigidbody.rotation);
			if (rCounter == 0.0)
			{
				rCounter = PhotonNetwork.time;
			}
			smoothedInterpTime = Mathf.Lerp((float)smoothedInterpTime, (float)((PhotonNetwork.time - rCounter) * 2.5), 0.035f);
			rCounter = PhotonNetwork.time;
			timeSinceLastUpdate = 0f;
			for (int num = buffer.Length - 1; num > 0; num--)
			{
				buffer[num] = buffer[num - 1];
			}
			buffer[0] = state;
			if (buffer[1] != null)
			{
				smoothedPacketTime = Mathf.Max(frameCounter, Mathf.Lerp((float)smoothedPacketTime, frameCounter, 0.35f));
				lerpTime = buffer[0].ntime - buffer[1].ntime;
				lerpTimeCounter = lerpTime;
				frameCounter = 1;
			}
			float y = pY;
			Vector3 localPosition = posY.localPosition;
			float num2 = (localPosition.y = y);
			Vector3 vector = (posY.localPosition = localPosition);
			float y2 = rY;
			Quaternion localRotation = rotY.localRotation;
			Vector3 eulerAngles = localRotation.eulerAngles;
			float num3 = (eulerAngles.y = y2);
			Vector3 vector3 = (localRotation.eulerAngles = eulerAngles);
			Quaternion quaternion = (rotY.localRotation = localRotation);
			float x = rX;
			Quaternion localRotation2 = rotX.localRotation;
			Vector3 eulerAngles2 = localRotation2.eulerAngles;
			float num4 = (eulerAngles2.x = x);
			Vector3 vector5 = (localRotation2.eulerAngles = eulerAngles2);
			Quaternion quaternion3 = (rotX.localRotation = localRotation2);
			for (int num = 0; num < 4; num++)
			{
				if ((bool)wheelScripts[num])
				{
					RuntimeServices.SetProperty(wheelScripts[num], "theRPM", wRPM);
				}
			}
			if (healthObj.name != health.ToString())
			{
				healthObj.name = health.ToString();
			}
		}
	}

	[RPC]
	public virtual void stateUpdate(Vector3 p, Quaternion r, float pY, float rY, float rX, int wRPM, PhotonMessageInfo info)
	{
		if (photonView.isMine)
		{
			return;
		}
		State state = new State(p, r, (float)info.timestamp, rigidbody.position, rigidbody.rotation);
		smoothedInterpTime = Mathf.Lerp((float)smoothedInterpTime, (float)(PhotonNetwork.time - rCounter), 0.15f);
		rCounter = PhotonNetwork.time;
		State[] array = buffer;
		for (int i = 0; i < buffer.Length; i++)
		{
			if (buffer[i] != null && i + 1 < buffer.Length)
			{
				array[i + 1] = buffer[i];
			}
		}
		array[0] = state;
		buffer = array;
		if (buffer[1] != null)
		{
			smoothedPacketTime = Mathf.Max(frameCounter, Mathf.Lerp((float)smoothedPacketTime, frameCounter, 0.35f));
			lerpTime = buffer[0].ntime - buffer[1].ntime;
			lerpTimeCounter = lerpTime;
			frameCounter = 1;
		}
		Vector3 localPosition = posY.localPosition;
		float num = (localPosition.y = pY);
		Vector3 vector = (posY.localPosition = localPosition);
		Quaternion localRotation = rotY.localRotation;
		Vector3 eulerAngles = localRotation.eulerAngles;
		float num2 = (eulerAngles.y = rY);
		Vector3 vector3 = (localRotation.eulerAngles = eulerAngles);
		Quaternion quaternion = (rotY.localRotation = localRotation);
		Quaternion localRotation2 = rotX.localRotation;
		Vector3 eulerAngles2 = localRotation2.eulerAngles;
		float num3 = (eulerAngles2.x = rX);
		Vector3 vector5 = (localRotation2.eulerAngles = eulerAngles2);
		Quaternion quaternion3 = (rotX.localRotation = localRotation2);
		int j = 0;
		GameObject[] array2 = wheelMeshes;
		for (int length = array2.Length; j < length; j++)
		{
			RuntimeServices.SetProperty(array2[j].GetComponent("WheelAlignment_Script"), "theRPM", wRPM);
		}
	}

	public virtual void Update()
	{
		if (!photonView.isMine)
		{
			timeSinceLastUpdate += Time.deltaTime;
			timeleft -= Time.deltaTime;
			accum += Time.timeScale / Time.deltaTime;
			frames++;
			if (!(timeleft > 0f))
			{
				calcFPS = accum / (float)frames;
				timeleft = updateInterval;
				accum = 0f;
				frames = 0;
			}
		}
	}

	public virtual void FixedUpdate()
	{
		if (photonView.isMine)
		{
			return;
		}
		if (!(timeSinceLastUpdate < 1f))
		{
			networkStatus = "(Buffering Position)";
		}
		else if (!(timeSinceLastUpdate <= 0.5f) && !(timeSinceLastUpdate >= 1f))
		{
			networkStatus = "(Delayed)";
		}
		else
		{
			networkStatus = string.Empty;
		}
		frameCounter++;
		lerpTimeCounter -= Time.deltaTime;
		for (int i = 0; i < buffer.Length; i++)
		{
			if (buffer[i] != null && !photonView.isMine && !((double)buffer[i].ltime >= (double)Time.time - smoothedInterpTime))
			{
				float num = Mathf.Min(1f, (float)((double)frameCounter / smoothedPacketTime));
				float t = (float)(((double)Time.time - smoothedInterpTime - (double)buffer[i].ltime) / (double)(buffer[Mathf.Max(0, i - 1)].ltime - buffer[i].ltime));
				Vector3 vector = buffer[Mathf.Max(0, i - 1)].pos - buffer[i].pos;
				rigidbody.position = Vector3.Lerp(rigidbody.position, Vector3.Lerp(buffer[i].pos, buffer[Mathf.Max(0, i - 1)].pos, t), smoothExtrapAmount * Time.deltaTime);
				rigidbody.rotation = Quaternion.Slerp(rigidbody.rotation, Quaternion.Slerp(buffer[i].rot, buffer[Mathf.Max(0, i - 1)].rot, t), smoothExtrapAmount * Time.deltaTime);
				if (!rigidbody.isKinematic)
				{
					rigidbody.velocity = Vector3.zero;
					rigidbody.angularVelocity = Vector3.zero;
				}
				break;
			}
		}
	}

	public virtual void Main()
	{
	}
}
