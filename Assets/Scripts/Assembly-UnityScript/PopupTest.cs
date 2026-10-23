using System;
using UnityEngine;

[Serializable]
public class PopupTest : MonoBehaviour
{
	private bool showList;

	private int listEntry;

	private GUIContent[] list;

	private GUIStyle listStyle;

	private bool picked;

	private bool asdf;

	public virtual void Start()
	{
		list = new GUIContent[5];
		list[0] = new GUIContent("Foo");
		list[1] = new GUIContent("Bar");
		list[2] = new GUIContent("Thing1");
		list[3] = new GUIContent("Thing2");
		list[4] = new GUIContent("Thing3");
		listStyle = new GUIStyle();
		listStyle.normal.textColor = Color.white;
		Texture2D background = new Texture2D(2, 2);
		listStyle.hover.background = background;
		listStyle.onHover.background = background;
		RectOffset padding = listStyle.padding;
		RectOffset padding2 = listStyle.padding;
		RectOffset padding3 = listStyle.padding;
		int num = (listStyle.padding.bottom = 4);
		int num3 = (padding3.top = num);
		int left = (padding2.right = num3);
		padding.left = left;
	}

	public virtual void OnGUI()
	{
		if (Popup.List(new Rect(50f, 100f, 100f, 20f), ref showList, ref listEntry, new GUIContent("Click me!"), list, listStyle))
		{
			picked = true;
		}
		if (picked)
		{
			GUI.Label(new Rect(50f, 70f, 400f, 20f), "You picked " + list[listEntry].text + "!");
		}
		asdf = GUI.Toggle(new Rect(280f, 85f, 20f, 20f), asdf, "Raining: ");
	}

	public virtual void Main()
	{
	}
}
