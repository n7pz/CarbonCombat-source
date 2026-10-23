using System;
using Photon;
using UnityEngine;

[Serializable]
public class TestConnection : Photon.MonoBehaviour
{
	public string testStatus;

	public string testMessage;

	public string shouldEnableNatMessage;

	public bool doneTesting;

	public bool probingPublicIP;

	public int serverPort;

	public ConnectionTesterStatus connectionTestResult;

	[NonSerialized]
	public static int result = -1;

	public bool useNat;

	public TestConnection()
	{
		testStatus = "Testing network connection capabilities.";
		testMessage = "Test in progress";
		shouldEnableNatMessage = string.Empty;
		serverPort = 9999;
		connectionTestResult = ConnectionTesterStatus.Undetermined;
	}
}
