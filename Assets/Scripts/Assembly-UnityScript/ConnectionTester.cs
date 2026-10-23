using System;
using Photon;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class ConnectionTester : Photon.MonoBehaviour
{
	public string testStatus;

	public string testMessage;

	public string shouldEnableNatMessage;

	public bool doneTesting;

	public bool probingPublicIP;

	public int serverPort;

	public ConnectionTesterStatus connectionTestResult;

	public bool useNat;

	public ConnectionTester()
	{
		testStatus = "Testing network connection capabilities.";
		testMessage = "Test in progress";
		shouldEnableNatMessage = string.Empty;
		serverPort = 9999;
		connectionTestResult = ConnectionTesterStatus.Undetermined;
	}

	public virtual void OnGUI()
	{
		GUILayout.Label("Current Status: " + testStatus);
		GUILayout.Label("Test result : " + testMessage);
		GUILayout.Label(shouldEnableNatMessage);
		if (!doneTesting)
		{
			TestConnection();
		}
	}

	public virtual void TestConnection()
	{
		connectionTestResult = (ConnectionTesterStatus)UnityRuntimeServices.Invoke(typeof(PhotonNetwork), "TestConnection", new object[0], typeof(UnityEngine.MonoBehaviour));
		ConnectionTesterStatus connectionTesterStatus = connectionTestResult;
		switch (connectionTesterStatus)
		{
		case ConnectionTesterStatus.Error:
			testMessage = "Problem determining NAT capabilities";
			doneTesting = true;
			break;
		case ConnectionTesterStatus.Undetermined:
			testMessage = "Undetermined NAT capabilities";
			doneTesting = false;
			break;
		case ConnectionTesterStatus.PublicIPIsConnectable:
			testMessage = "Directly connectable public IP address.";
			useNat = false;
			doneTesting = true;
			break;
		case ConnectionTesterStatus.PublicIPPortBlocked:
		{
			testMessage = "Non-connectble public IP address (port " + serverPort + " blocked), running a server is impossible.";
			useNat = false;
			float num = default(float);
			if (!probingPublicIP)
			{
				connectionTestResult = (ConnectionTesterStatus)UnityRuntimeServices.Invoke(typeof(PhotonNetwork), "TestConnectionNAT", new object[0], typeof(UnityEngine.MonoBehaviour));
				probingPublicIP = true;
				testStatus = "Testing if blocked public IP can be circumvented";
				num = Time.time + 10f;
			}
			else if (!(Time.time <= num))
			{
				probingPublicIP = false;
				useNat = true;
				doneTesting = true;
			}
			break;
		}
		case ConnectionTesterStatus.PublicIPNoServerStarted:
			testMessage = "Public IP address but server not initialized, " + "it must be started to check server accessibility. Restart " + "connection test when ready.";
			break;
		case ConnectionTesterStatus.LimitedNATPunchthroughPortRestricted:
			testMessage = "Limited NAT punchthrough capabilities. Cannot " + "connect to all types of NAT servers.";
			useNat = true;
			doneTesting = true;
			break;
		default:
			switch (connectionTesterStatus)
			{
			case ConnectionTesterStatus.LimitedNATPunchthroughPortRestricted:
				testMessage = "Limited NAT punchthrough capabilities. Cannot " + "connect to all types of NAT servers. Running a server " + "is ill advised as not everyone can connect.";
				useNat = true;
				doneTesting = true;
				break;
			case ConnectionTesterStatus.LimitedNATPunchthroughSymmetric:
				testMessage = "Limited NAT punchthrough capabilities. Cannot " + "connect to all types of NAT servers. Running a server " + "is ill advised as not everyone can connect.";
				useNat = true;
				doneTesting = true;
				break;
			case ConnectionTesterStatus.NATpunchthroughFullCone:
			case ConnectionTesterStatus.NATpunchthroughAddressRestrictedCone:
				testMessage = "NAT punchthrough capable. Can connect to all " + "servers and receive connections from all clients. Enabling " + "NAT punchthrough functionality.";
				useNat = true;
				doneTesting = true;
				break;
			default:
				testMessage = "Error in test routine, got " + connectionTestResult;
				break;
			}
			break;
		}
		if (doneTesting)
		{
			if (useNat)
			{
				shouldEnableNatMessage = "When starting a server the NAT " + "punchthrough feature should be enabled (useNat parameter)";
			}
			else
			{
				shouldEnableNatMessage = "NAT punchthrough not needed";
			}
			testStatus = "Done testing";
		}
	}
}
