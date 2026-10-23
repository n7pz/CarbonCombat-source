using System;
using UnityEngine;

[Serializable]
public class TutorialTrigger : MonoBehaviour
{
	private SpawningScript spawnsrc;

	private bool sent;

	private AuthGameObject authobj;

	public virtual void Start()
	{
		if (!AuthGameObject.showTutorial)
		{
			UnityEngine.Object.Destroy(gameObject);
		}
	}

	public virtual void OnTriggerEnter(Collider col)
	{
		if (col.transform == SpawningScript.playertrans && !sent)
		{
			sent = true;
			SpawningScript.playertrans.rigidbody.velocity = Vector3.zero;
			((TutorialManager)GameObject.Find("/TutorialManager").GetComponent(typeof(TutorialManager))).nextOne = true;
			gameObject.active = false;
		}
	}

	public virtual void Main()
	{
	}
}
