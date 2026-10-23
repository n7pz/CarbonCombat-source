using UnityEngine;

public class Popup
{
	private static int popupListHash = "PopupList".GetHashCode();

	public static bool List(Rect position, ref bool showList, ref int listEntry, GUIContent buttonContent, GUIContent[] listContent, GUIStyle listStyle)
	{
		return List(position, ref showList, ref listEntry, buttonContent, listContent, "button", "box", listStyle);
	}

	public static bool List(Rect position, ref bool showList, ref int listEntry, GUIContent buttonContent, GUIContent[] listContent, GUIStyle buttonStyle, GUIStyle boxStyle, GUIStyle listStyle)
	{
		int controlID = GUIUtility.GetControlID(popupListHash, FocusType.Passive);
		bool flag = false;
		switch (Event.current.GetTypeForControl(controlID))
		{
		case EventType.MouseDown:
			if (position.Contains(Event.current.mousePosition))
			{
				GUIUtility.hotControl = controlID;
				showList = true;
			}
			break;
		case EventType.MouseUp:
			if (showList)
			{
				flag = true;
			}
			break;
		}
		GUI.Label(position, buttonContent, buttonStyle);
		if (showList)
		{
			Rect position2 = new Rect(position.x, position.y, position.width, listStyle.CalcHeight(listContent[0], 1f) * (float)listContent.Length);
			GUI.Box(position2, string.Empty, boxStyle);
			listEntry = GUI.SelectionGrid(position2, listEntry, listContent, 1, listStyle);
		}
		if (flag)
		{
			showList = false;
		}
		return flag;
	}
}
