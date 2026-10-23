using System;
using Boo.Lang.Runtime;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class bulletTraceGenerator : MonoBehaviour
{
	public GameObject bulletTracePrefab;

	public float rate;

	public Vector3 velocity;

	public bool on;

	public float accuracy;

	private float nextbulletTraceTime;

	public bulletTraceGenerator()
	{
		rate = 8f;
		accuracy = 1f;
	}

	public virtual void Update()
	{
		accuracy = Mathf.Clamp01(accuracy);
		if (on && !(Time.time <= nextbulletTraceTime))
		{
			rate = Mathf.Max(rate, 1f);
			nextbulletTraceTime = Time.time + 1f / rate;
			GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(bulletTracePrefab, transform.position, transform.rotation);
			Vector3 vector = (Vector3)UnityRuntimeServices.GetProperty(gameObject.GetComponent("bulletTrace"), "velocity");
			float num = 1f - accuracy;
			num = RuntimeServices.UnboxSingle(RuntimeServices.InvokeBinaryOperator("op_Multiply", num, RuntimeServices.InvokeBinaryOperator("op_Multiply", UnityRuntimeServices.GetProperty(gameObject.GetComponent("bulletTrace"), "bulletSpeed"), 0.05f)));
			vector += gameObject.transform.right * UnityEngine.Random.Range(0f - num, num);
			vector += gameObject.transform.up * UnityEngine.Random.Range(0f - num, num);
			RuntimeServices.SetProperty(gameObject.GetComponent("bulletTrace"), "velocity", vector);
		}
	}

	public virtual void Main()
	{
	}
}
