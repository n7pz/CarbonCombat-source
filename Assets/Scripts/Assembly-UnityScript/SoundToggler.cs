using System;
using UnityEngine;

[Serializable]
public class SoundToggler : MonoBehaviour
{
	public float fadeTime;

	private SoundController soundScript;

	public SoundToggler()
	{
		fadeTime = 1f;
	}

	public virtual void Start()
	{
		soundScript = (SoundController)UnityEngine.Object.FindObjectOfType(typeof(SoundController));
	}

	public virtual void OnTriggerEnter()
	{
		soundScript.StartCoroutine_Auto(soundScript.ControlSound(true, fadeTime));
	}

	public virtual void OnTriggerExit()
	{
		soundScript.StartCoroutine_Auto(soundScript.ControlSound(false, fadeTime));
	}

	public virtual void Main()
	{
	}
}
