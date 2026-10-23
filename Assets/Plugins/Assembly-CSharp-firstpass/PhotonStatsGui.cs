using ExitGames.Client.Photon;
using UnityEngine;

public class PhotonStatsGui : MonoBehaviour
{
	public Rect statsRect = new Rect(0f, 0f, 200f, 50f);

	public float WidthWithText = 400f;

	public bool statsWindowOn;

	public bool statsOn;

	public bool textOn;

	public bool resetButtonOn;

	private void Start()
	{
		float num = statsRect.width;
		if (textOn)
		{
			num = WidthWithText;
		}
		statsRect = new Rect((float)Screen.width - num, 0f, num, statsRect.height);
	}

	private void OnGUI()
	{
		if (PhotonNetwork.networkingPeer.TrafficStatsEnabled != statsOn)
		{
			PhotonNetwork.networkingPeer.TrafficStatsEnabled = statsOn;
		}
		if (statsWindowOn)
		{
			statsRect = GUILayout.Window(0, statsRect, TrafficStatsWindow, "Messages");
			if (GUILayout.Button("Disconnect"))
			{
				PhotonNetwork.Disconnect();
			}
		}
	}

	private void TrafficStatsWindow(int windowID)
	{
		TrafficStatsGameLevel trafficStatsGameLevel = PhotonNetwork.networkingPeer.TrafficStatsGameLevel;
		long num = PhotonNetwork.networkingPeer.TrafficStatsElapsedMs / 1000;
		if (num == 0L)
		{
			num = 1L;
		}
		GUILayout.Label(string.Format("Out|In|Sum:\t{0,4} | {1,4} | {2,4}", trafficStatsGameLevel.TotalOutgoingMessageCount, trafficStatsGameLevel.TotalIncomingMessageCount, trafficStatsGameLevel.TotalMessageCount));
		GUILayout.Label(string.Format("{0}sec average:", num));
		GUILayout.Label(string.Format("Out|In|Sum:\t{0,4} | {1,4} | {2,4}", trafficStatsGameLevel.TotalOutgoingMessageCount / num, trafficStatsGameLevel.TotalIncomingMessageCount / num, trafficStatsGameLevel.TotalMessageCount / num));
		if (resetButtonOn && GUILayout.Button("Reset"))
		{
			PhotonNetwork.networkingPeer.TrafficStatsReset();
			PhotonNetwork.networkingPeer.TrafficStatsEnabled = true;
		}
		if (textOn)
		{
			GUILayout.Label("Incoming: " + PhotonNetwork.networkingPeer.TrafficStatsIncoming.ToString());
			GUILayout.Label("Outgoing: " + PhotonNetwork.networkingPeer.TrafficStatsOutgoing.ToString());
		}
		GUI.DragWindow();
	}
}
