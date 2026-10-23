using System;
using UnityEngine;

[Serializable]
public class LevelEditorCamControl : MonoBehaviour
{
	public Vector3 target;

	private Vector2 lastMousePos;

	private Vector2 lastMousePos2;

	private Vector2 lastMousePosPan;

	private Vector2 lastMousePosScroll;

	private GameObject gobj;

	public GameObject selectedObj;

	public Material[] smat;

	public LevelEditorCamControl()
	{
		target = Vector3.zero;
	}

	public virtual void Update()
	{
		if (Input.GetAxis("Fire1") == 0f || !Input.GetKey(KeyCode.LeftAlt))
		{
			lastMousePos = Vector2.zero;
			lastMousePosPan = Vector2.zero;
			lastMousePosScroll = Vector2.zero;
		}
		if (Input.GetAxis("Fire2") == 0f)
		{
			lastMousePos2 = Vector2.zero;
		}
		if (Input.GetKey(KeyCode.LeftAlt) && !Input.GetKey(KeyCode.LeftApple) && !Input.GetKey(KeyCode.LeftControl) && Input.GetAxis("Fire1") != 0f && lastMousePos == Vector2.zero)
		{
			lastMousePos = Input.mousePosition;
		}
		if (Input.GetKey(KeyCode.LeftAlt) && !Input.GetKey(KeyCode.LeftApple) && !Input.GetKey(KeyCode.LeftControl) && Input.GetAxis("Fire1") != 0f)
		{
			transform.RotateAround(target, Vector3.up, (Input.mousePosition.x - lastMousePos.x) * 0.25f);
			transform.RotateAround(target, transform.TransformDirection(Vector3.left), (Input.mousePosition.y - lastMousePos.y) * 0.25f);
			lastMousePos = Input.mousePosition;
		}
		if (!Input.GetKey(KeyCode.LeftAlt) && !Input.GetKey(KeyCode.LeftApple) && !Input.GetKey(KeyCode.LeftControl) && Input.GetAxis("Fire2") != 0f && lastMousePos2 == Vector2.zero)
		{
			lastMousePos2 = Input.mousePosition;
		}
		if (!Input.GetKey(KeyCode.LeftAlt) && !Input.GetKey(KeyCode.LeftApple) && !Input.GetKey(KeyCode.LeftControl) && Input.GetAxis("Fire2") != 0f)
		{
			transform.Rotate(Vector3.up, (Input.mousePosition.x - lastMousePos2.x) * 0.25f, Space.World);
			transform.Rotate(Vector3.left, (Input.mousePosition.y - lastMousePos2.y) * 0.25f, Space.Self);
			lastMousePos2 = Input.mousePosition;
		}
		if (Input.GetKey(KeyCode.LeftAlt) && Input.GetKey(KeyCode.LeftApple) && Input.GetAxis("Fire1") != 0f && lastMousePosPan == Vector2.zero)
		{
			lastMousePosPan = Input.mousePosition;
		}
		if (Input.GetKey(KeyCode.LeftAlt) && Input.GetKey(KeyCode.LeftApple) && Input.GetAxis("Fire1") != 0f)
		{
			transform.Translate(Vector3.left * ((Input.mousePosition.x - lastMousePosPan.x) * 0.0017f * Vector3.Distance(transform.position, target)), Space.Self);
			transform.Translate(Vector3.up * ((Input.mousePosition.y - lastMousePosPan.y) * -0.0017f * Vector3.Distance(transform.position, target)), Space.Self);
			lastMousePosPan = Input.mousePosition;
		}
		if (Input.GetKey(KeyCode.LeftAlt) && Input.GetKey(KeyCode.LeftControl) && Input.GetAxis("Fire1") != 0f && lastMousePosScroll == Vector2.zero)
		{
			lastMousePosScroll = Input.mousePosition;
		}
		if (Input.GetKey(KeyCode.LeftAlt) && Input.GetKey(KeyCode.LeftControl) && Input.GetAxis("Fire1") != 0f)
		{
			transform.Translate(Vector3.forward * ((Input.mousePosition.x - lastMousePosScroll.x) * 0.0035f * Vector3.Distance(transform.position, target)), Space.Self);
			transform.Translate(Vector3.forward * ((Input.mousePosition.y - lastMousePosScroll.y) * -0.0035f * Vector3.Distance(transform.position, target)), Space.Self);
			lastMousePosScroll = Input.mousePosition;
		}
		if (Input.GetAxis("Mouse ScrollWheel") != 0f)
		{
			transform.Translate(Vector3.forward * (Input.GetAxis("Mouse ScrollWheel") * 0.03f * Vector3.Distance(transform.position, target)), Space.Self);
		}
		if (Input.GetKeyDown("f"))
		{
			if ((bool)gobj)
			{
				gobj.transform.DetachChildren();
				UnityEngine.Object.Destroy(gobj);
			}
			gobj = new GameObject("FocusCam");
			gobj.transform.position = transform.TransformPoint(new Vector3(0f, 0f, 3.5f));
			transform.parent = gobj.transform;
		}
		if ((bool)gobj)
		{
			if (gobj.transform.position != target)
			{
				gobj.transform.position = Vector3.Lerp(gobj.transform.position, target, 10f * Time.deltaTime);
			}
			else
			{
				transform.parent = null;
				UnityEngine.Object.Destroy(gobj);
			}
		}
		if (Input.GetAxis("Fire1") != 0f && !Input.GetKey(KeyCode.LeftAlt))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hitInfo = default(RaycastHit);
			if (Physics.Raycast(ray, out hitInfo, float.PositiveInfinity) && hitInfo.transform.gameObject != selectedObj)
			{
				selectedObj.renderer.material = smat[0];
				selectedObj = hitInfo.transform.gameObject;
				selectedObj.renderer.material = smat[1];
				target = hitInfo.transform.gameObject.transform.position;
			}
		}
	}

	public virtual void Main()
	{
	}
}
