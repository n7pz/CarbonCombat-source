using System;
using UnityEngine;

[Serializable]
public class ReturnPnameForGun : MonoBehaviour
{
	public GameObject playernameobj;

	public virtual void returnpname(GameObject t)
	{
		t.SendMessage("returnedname", playernameobj.name);
	}

	public virtual void Main()
	{
	}
}
