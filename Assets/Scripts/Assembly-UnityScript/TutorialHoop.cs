using System;
using UnityEngine;

[Serializable]
public class TutorialHoop : MonoBehaviour
{
	private SpawningScript spawnsrc;

	public virtual void OnTriggerEnter(Collider col)
	{
		if (col.transform == SpawningScript.playertrans)
		{
			((TutorialManager)GameObject.Find("/TutorialManager").GetComponent(typeof(TutorialManager))).hoopCounter = ((TutorialManager)GameObject.Find("/TutorialManager").GetComponent(typeof(TutorialManager))).hoopCounter + 1;
			transform.parent.gameObject.SetActiveRecursively(false);
		}
	}

	public virtual void Main()
	{
	}
}
