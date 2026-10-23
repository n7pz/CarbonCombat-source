using System;
using UnityEngine;

[Serializable]
public class game : MonoBehaviour
{
	public GameObject soldier;

	public GameObject soldierPrefab;

	public GameObject sentryGun;

	public GameObject sentryGunPrefab;

	public bool resetMenu;

	public GUIText menu1;

	public GUIText menu2;

	public virtual void Start()
	{
		Screen.lockCursor = true;
		Screen.showCursor = false;
	}

	public virtual void Update()
	{
		if (Input.GetKey("escape"))
		{
			Application.Quit();
		}
		if (Input.GetKeyDown(KeyCode.B))
		{
			Debug.Break();
		}
		if (Input.GetKeyDown(KeyCode.R))
		{
			resetMenu = true;
		}
		if (resetMenu)
		{
			menu1.text = "Reset menu:";
			menu2.text = "(1) Reset soldier. (2) Reset sentry gun.";
			if (Input.GetKeyDown(KeyCode.Alpha1))
			{
				ResetSoldier();
				resetMenu = false;
			}
			if (Input.GetKeyDown(KeyCode.Alpha2))
			{
				ResetSentryGun();
				resetMenu = false;
			}
		}
		else
		{
			menu1.text = "Soldier scripts v0.93 sample scene";
			menu2.text = "(Under development - report bugs: dogzerx@hotmail.com)";
		}
		Screen.lockCursor = true;
	}

	public virtual void ResetSoldier()
	{
		UnityEngine.Object.Destroy(soldier);
		soldier = (GameObject)UnityEngine.Object.Instantiate(soldierPrefab, Vector3.zero, Quaternion.identity);
		soldier.name = "soldier3rdPerson";
	}

	public virtual void ResetSentryGun()
	{
		UnityEngine.Object.Destroy(sentryGun);
		sentryGun = (GameObject)UnityEngine.Object.Instantiate(sentryGunPrefab, new Vector3(0f, 0f, 3f), Quaternion.identity);
		int num = 90;
		Quaternion rotation = sentryGun.transform.rotation;
		Vector3 eulerAngles = rotation.eulerAngles;
		float num2 = (eulerAngles.y = num);
		Vector3 vector = (rotation.eulerAngles = eulerAngles);
		Quaternion quaternion = (sentryGun.transform.rotation = rotation);
		sentryGun.name = "sentryGun";
	}

	public virtual void Main()
	{
	}
}
