using System;
using UnityEngine;

[Serializable]
public class gun : MonoBehaviour
{
	public bool firing;

	public float accuracy;

	private Transform bulletCaseGenerator;

	private Transform bulletTraceGenerator;

	private Transform muzzleFlashGenerator;

	private bulletCaseGenerator bulletCaseGeneratorScript;

	private bulletTraceGenerator bulletTraceGeneratorScript;

	private muzzleFlashGenerator muzzleFlashGeneratorScript;

	public virtual void Start()
	{
		bulletCaseGenerator = transform.Find("bulletCaseGenerator");
		bulletTraceGenerator = transform.Find("bulletTraceGenerator");
		muzzleFlashGenerator = transform.Find("muzzleFlashGenerator");
		bulletCaseGeneratorScript = (bulletCaseGenerator)bulletCaseGenerator.GetComponent("bulletCaseGenerator");
		bulletTraceGeneratorScript = (bulletTraceGenerator)bulletTraceGenerator.GetComponent("bulletTraceGenerator");
		muzzleFlashGeneratorScript = (muzzleFlashGenerator)muzzleFlashGenerator.GetComponent("muzzleFlashGenerator");
		firing = false;
	}

	public virtual void Update()
	{
		bulletCaseGeneratorScript.on = firing;
		bulletTraceGeneratorScript.on = firing;
		muzzleFlashGeneratorScript.on = firing;
		bulletTraceGeneratorScript.accuracy = accuracy;
	}

	public virtual void Main()
	{
	}
}
