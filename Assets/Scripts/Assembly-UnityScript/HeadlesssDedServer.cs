using System;
using UnityEngine;

[Serializable]
public class HeadlesssDedServer : MonoBehaviour
{
	public AuthGameObject authobj;

	public MasterServerScript mserver;

	public InitWorld iw;

	public CWFLoader cwf;

	[NonSerialized]
	public static int serverid;

	[NonSerialized]
	public static bool isServerHost;

	public PreloaderExplosion pex;

	public virtual void Main()
	{
	}
}
