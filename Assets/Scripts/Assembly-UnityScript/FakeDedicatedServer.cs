using System;
using System.Collections;
using Photon;
using UnityEngine;

[Serializable]
public class FakeDedicatedServer : Photon.MonoBehaviour
{
	private PhotonPlayer heir;

	private string hname;

	private bool chosenone;

	private bool origconnected;

	private bool tryonce;

	private float timer;

	private GameObject[] carobj;

	public GameObject refobj;

	public AuthGameObject authobj;

	public MasterServerScript gname;

	public RefreshMasterServer refreshmserver;

	public SpawningScript spwnsrc;

	public WorldWindow worldwindowsrc;

	public TestConnection testcon;

	public FadeSceneTransition fadestrans;

	public GameObject spawnobj;

	public GameObject authgameobj;

	public PreloaderExplosion pex;

	private float counter;

	private int trycount;

	public GUIStyle txtstyle;

	public GUIStyle wbox;

	public GUIStyle wsym;

	private bool warning;

	private float GUIalpha;

	private int maxplayers;

	private float int2float;

	private string servername;

	private bool sayonce;

	[NonSerialized]
	public static Vector3 spos;

	[NonSerialized]
	public static Quaternion srot;

	private int fails;

	private Hashtable networkTypes;

	public FakeDedicatedServer()
	{
		timer = 5f;
		counter = 2f;
		trycount = 1;
	}

	public virtual void Main()
	{
		networkTypes = new Hashtable();
	}
}
