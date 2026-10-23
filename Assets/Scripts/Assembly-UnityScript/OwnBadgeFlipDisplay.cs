using System;
using UnityEngine;

[Serializable]
public class OwnBadgeFlipDisplay : MonoBehaviour
{
	public GUIStyle boxstyle;

	private bool go;

	private Rigidbody obj;

	private ChatScript cscript;

	public virtual void OnGUI()
	{
		if (go && ChatScript.isCar)
		{
			GUI.depth = -1;
			GUI.Box(new Rect(Screen.width / 2 - 75, Screen.height / 2 - 100, 150f, 35f), (!Application.absoluteURL.Contains("Conduit.unity3d")) ? "Press [f] to Flip Car" : "Flip Car", boxstyle);
		}
	}

	public virtual void Update()
	{
		if (go && Input.GetKeyDown("f"))
		{
			obj.AddForce(0f, 350000f, 0f);
			obj.AddRelativeTorque(0f, 0f, ((Mathf.Abs(obj.transform.localRotation.eulerAngles.z) >= 180f) ? 1 : (-1)) * 20000000);
			go = false;
		}
	}

	public virtual void enable(Rigidbody t)
	{
		go = true;
		obj = t;
	}

	public virtual void disable(GameObject t)
	{
		go = false;
	}

	public virtual void Main()
	{
	}
}
