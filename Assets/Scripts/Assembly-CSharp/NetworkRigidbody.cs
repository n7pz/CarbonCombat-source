using Photon;
using UnityEngine;

public class NetworkRigidbody : Photon.MonoBehaviour
{
	internal struct State
	{
		internal double timestamp;

		internal Vector3 pos;

		internal Vector3 velocity;

		internal Quaternion rot;

		internal Vector3 angularVelocity;
	}

	public double m_InterpolationBackTime = 0.05;

	public double m_ExtrapolationLimit = 0.8;

	private State[] m_BufferedState = new State[20];

	private int m_TimestampCount;

	private void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if (stream.isWriting)
		{
			Vector3 obj = base.rigidbody.position;
			Quaternion obj2 = base.rigidbody.rotation;
			Vector3 obj3 = base.rigidbody.velocity;
			Vector3 obj4 = base.rigidbody.angularVelocity;
			stream.Serialize(ref obj);
			stream.Serialize(ref obj3);
			stream.Serialize(ref obj2);
			stream.Serialize(ref obj4);
			return;
		}
		Vector3 obj5 = Vector3.zero;
		Vector3 obj6 = Vector3.zero;
		Quaternion obj7 = Quaternion.identity;
		Vector3 obj8 = Vector3.zero;
		stream.Serialize(ref obj5);
		stream.Serialize(ref obj6);
		stream.Serialize(ref obj7);
		stream.Serialize(ref obj8);
		for (int num = m_BufferedState.Length - 1; num >= 1; num--)
		{
			m_BufferedState[num] = m_BufferedState[num - 1];
		}
		State state = default(State);
		state.timestamp = info.timestamp;
		state.pos = obj5;
		state.velocity = obj6;
		state.rot = obj7;
		state.angularVelocity = obj8;
		m_BufferedState[0] = state;
		m_TimestampCount = Mathf.Min(m_TimestampCount + 1, m_BufferedState.Length);
		for (int i = 0; i < m_TimestampCount - 1; i++)
		{
			if (m_BufferedState[i].timestamp < m_BufferedState[i + 1].timestamp)
			{
				Debug.Log("State inconsistent");
			}
		}
	}

	private void Update()
	{
		double num = PhotonNetwork.time - m_InterpolationBackTime;
		if (m_BufferedState[0].timestamp > num)
		{
			for (int i = 0; i < m_TimestampCount; i++)
			{
				if (m_BufferedState[i].timestamp <= num || i == m_TimestampCount - 1)
				{
					State state = m_BufferedState[Mathf.Max(i - 1, 0)];
					State state2 = m_BufferedState[i];
					double num2 = state.timestamp - state2.timestamp;
					float t = 0f;
					if (num2 > 0.0001)
					{
						t = (float)((num - state2.timestamp) / num2);
					}
					base.transform.localPosition = Vector3.Lerp(state2.pos, state.pos, t);
					base.transform.localRotation = Quaternion.Slerp(state2.rot, state.rot, t);
					break;
				}
			}
		}
		else
		{
			State state3 = m_BufferedState[0];
			float num3 = (float)(num - state3.timestamp);
			if ((double)num3 < m_ExtrapolationLimit)
			{
				float angle = num3 * state3.angularVelocity.magnitude * 57.29578f;
				Quaternion quaternion = Quaternion.AngleAxis(angle, state3.angularVelocity);
				base.rigidbody.position = state3.pos + state3.velocity * num3;
				base.rigidbody.rotation = quaternion * state3.rot;
				base.rigidbody.velocity = state3.velocity;
				base.rigidbody.angularVelocity = state3.angularVelocity;
			}
		}
	}
}
