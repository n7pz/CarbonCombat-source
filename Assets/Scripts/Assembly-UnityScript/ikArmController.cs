using System;
using Boo.Lang.Runtime;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class ikArmController : MonoBehaviour
{
	public Transform target;

	public Transform elbowTarget;

	private MonoBehaviour inverseKinematicsScript;

	public virtual void Start()
	{
		inverseKinematicsScript = (MonoBehaviour)GetComponent("inverseKinematics");
	}

	public virtual void Update()
	{
		RuntimeServices.SetProperty(inverseKinematicsScript, "target", target.position);
		RuntimeServices.SetProperty(inverseKinematicsScript, "elbowTarget", elbowTarget.position);
		UnityRuntimeServices.Invoke(inverseKinematicsScript, "CalculateIK", new object[0], typeof(MonoBehaviour));
	}

	public virtual void Main()
	{
	}
}
