using System;
using Boo.Lang.Runtime;
using Photon;
using UnityEngine;

[Serializable]
public class InterpNetTrans : Photon.MonoBehaviour
{
	[Serializable]
	public class BState
	{
		public Vector3 pos;

		public Quaternion rot;

		public float ntime;

		public Vector3 cpos;

		public Quaternion crot;

		public float ltime;

		public BState(Vector3 pos, Quaternion rot, float ntime, Vector3 cpos, Quaternion crot)
		{
			this.pos = pos;
			this.rot = rot;
			this.ntime = ntime;
			this.cpos = cpos;
			this.crot = crot;
			ltime = Time.time;
		}
	}

	private Vector3 p;

	private Quaternion r;

	private BState[] buffer;

	public double smoothedPacketTime;

	private int frameCounter;

	private float smoothExtrapAmount;

	private Vector3 smoothedVel;

	private int syncMethod;

	private float syncCounter;

	private double lerpTime;

	private double lerpTimeCounter;

	private double rCounter;

	private double smoothedInterpTime;

	private double smoothedNetworkTime;

	private double lastNetTime;

	private double smoothedDeltaNetTime;

	private double deltaCounter;

	private bool isRigidbody;

	public Transform syncObj;

	public bool syncX;

	private float syncRot;

	private float timeSinceLastUpdate;

	public string networkStatus;

	private int updateInterval;

	private float calcFPS;

	private float accum;

	private int frames;

	private float timeleft;

	public InterpNetTrans()
	{
		buffer = new BState[10];
		smoothedPacketTime = 6.0;
		frameCounter = 1;
		smoothExtrapAmount = 50f;
		smoothedInterpTime = 0.07999999821186066;
		deltaCounter = 1.0;
		networkStatus = string.Empty;
		updateInterval = 5;
		calcFPS = 60f;
	}

	public virtual void Start()
	{
		rCounter = PhotonNetwork.time;
		if ((bool)(Rigidbody)gameObject.GetComponent(typeof(Rigidbody)))
		{
			isRigidbody = true;
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
			p = ((!isRigidbody) ? transform.position : rigidbody.position);
			r = ((!isRigidbody) ? transform.rotation : rigidbody.rotation);
			stream.SendNext(p);
			stream.SendNext(r);
			if (syncX)
			{
				syncRot = syncObj.localRotation.x;
				stream.SendNext(syncRot);
			}
		}
		else if (!photonView.isMine)
		{
			p = (Vector3)stream.ReceiveNext();
			r = (Quaternion)stream.ReceiveNext();
			BState bState = new BState(p, r, (float)info.timestamp, (!isRigidbody) ? transform.position : rigidbody.position, (!isRigidbody) ? transform.rotation : rigidbody.rotation);
			if (rCounter == 0.0)
			{
				rCounter = PhotonNetwork.time;
			}
			smoothedInterpTime = Mathf.Lerp((float)smoothedInterpTime, (float)((PhotonNetwork.time - rCounter) * 2.5), 0.15f);
			rCounter = PhotonNetwork.time;
			timeSinceLastUpdate = 0f;
			for (int num = buffer.Length - 1; num > 0; num--)
			{
				buffer[num] = buffer[num - 1];
			}
			buffer[0] = bState;
			if (buffer[1] != null)
			{
				smoothedPacketTime = Mathf.Max(frameCounter, Mathf.Lerp((float)smoothedPacketTime, frameCounter, 0.35f));
				lerpTime = buffer[0].ntime - buffer[1].ntime;
				lerpTimeCounter = lerpTime;
				frameCounter = 1;
			}
			if (syncX)
			{
				syncRot = RuntimeServices.UnboxSingle(stream.ReceiveNext());
				float x = syncRot;
				Quaternion localRotation = syncObj.localRotation;
				float num2 = (localRotation.x = x);
				Quaternion quaternion = (syncObj.localRotation = localRotation);
			}
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
			if (buffer[i] != null && !((double)buffer[i].ltime >= (double)Time.time - smoothedInterpTime))
			{
				float num = Mathf.Min(1f, (float)((double)frameCounter / smoothedPacketTime));
				float t = (float)(((double)Time.time - smoothedInterpTime - (double)buffer[i].ltime) / (double)(buffer[Mathf.Max(0, i - 1)].ltime - buffer[i].ltime));
				Vector3 vector = buffer[Mathf.Max(0, i - 1)].pos - buffer[i].pos;
				if (isRigidbody)
				{
					rigidbody.position = Vector3.Lerp(rigidbody.position, Vector3.Lerp(buffer[i].pos, buffer[Mathf.Max(0, i - 1)].pos, t), smoothExtrapAmount * Time.deltaTime);
					rigidbody.rotation = Quaternion.Slerp(rigidbody.rotation, Quaternion.Slerp(buffer[i].rot, buffer[Mathf.Max(0, i - 1)].rot, t), smoothExtrapAmount * Time.deltaTime);
				}
				else
				{
					transform.position = Vector3.Lerp(transform.position, Vector3.Lerp(buffer[i].pos, buffer[Mathf.Max(0, i - 1)].pos, t), smoothExtrapAmount * Time.deltaTime);
					transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Slerp(buffer[i].rot, buffer[Mathf.Max(0, i - 1)].rot, t), smoothExtrapAmount * Time.deltaTime);
				}
				if (isRigidbody && !rigidbody.isKinematic)
				{
					rigidbody.velocity = Vector3.zero;
					rigidbody.angularVelocity = Vector3.zero;
				}
				break;
			}
		}
	}
}
