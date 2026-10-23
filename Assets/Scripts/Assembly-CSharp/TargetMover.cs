using UnityEngine;

public class TargetMover : MonoBehaviour
{
	public LayerMask mask;

	public Transform target;

	public bool onlyOnDoubleClick;

	private Camera cam;

	public void Start()
	{
		cam = Camera.main;
	}

	public void OnGUI()
	{
		if (onlyOnDoubleClick && cam != null && Event.current.type == EventType.MouseDown && Event.current.clickCount == 2)
		{
			UpdateTargetPosition();
		}
	}

	private void Update()
	{
		if (!onlyOnDoubleClick && cam != null)
		{
			UpdateTargetPosition();
		}
	}

	public void UpdateTargetPosition()
	{
		RaycastHit hitInfo;
		if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hitInfo, float.PositiveInfinity, mask))
		{
			target.position = hitInfo.point;
		}
	}
}
