using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class AudioController : MonoBehaviour
{
	public GUIStyle soundGUI;

	public Texture[] soundlist;

	[NonSerialized]
	public static int curvol = 3;

	private bool incrVol;

	private float alpha;

	public Texture pauseicon;

	private float pausealpha;

	public GUIStyle pauseGUI;

	public Texture camicon;

	private float camalpha;

	[NonSerialized]
	public static bool hideGUI;

	public Texture fullscreenicon;

	private float fullscreenalpha;

	public Resolution[] resolutions;

	public PreloaderExplosion pex;

	public HeadlesssDedServer headless;

	public GUIStyle tooltipstyle;

	private float toolalpha;

	private bool fadetool;

	public GUIStyle backgroundTex;

	public AudioController()
	{
		alpha = (hideGUI ? 0f : 0.2f);
		pausealpha = (hideGUI ? 0f : 0.2f);
		camalpha = (hideGUI ? 0f : 0.2f);
		fullscreenalpha = (hideGUI ? 0f : 0.2f);
	}

	public virtual void Start()
	{
		resolutions = Screen.resolutions;
	}

	public virtual void OnGUI()
	{
		if (!HeadlesssDedServer.isServerHost)
		{
			if (!hideGUI)
			{
				GUI.Box(new Rect(0f, Screen.height - 30, (!(Application.loadedLevelName == "Menu")) ? 130 : 65, 30f), string.Empty, backgroundTex);
			}
			float a = alpha;
			Color color = GUI.color;
			float num = (color.a = a);
			Color color2 = (GUI.color = color);
			GUI.depth = -7;
			if (GUI.Button(new Rect(width: (curvol != 3) ? 23 : 25, left: 5f, top: Screen.height - 5 - 20, height: 20f), new GUIContent(string.Empty, "Adjust overall game volume"), soundGUI))
			{
				if (!incrVol)
				{
					if (curvol != 0)
					{
						curvol--;
					}
					else
					{
						incrVol = true;
						curvol++;
					}
				}
				else if (curvol != 3)
				{
					curvol++;
				}
				else
				{
					incrVol = false;
					curvol--;
				}
			}
			soundGUI.normal.background = (Texture2D)soundlist[curvol];
			if (Application.loadedLevelName != "Menu")
			{
				pauseGUI.normal.background = (Texture2D)pauseicon;
				float a2 = pausealpha;
				Color color4 = GUI.color;
				float num2 = (color4.a = a2);
				Color color5 = (GUI.color = color4);
				if (GUI.Button(new Rect(39f, Screen.height - 5 - 20, 20f, 20f), new GUIContent(string.Empty, "Open game settings window"), pauseGUI))
				{
					GameObject.Find("PauseObject").SendMessage("fadein");
				}
				pauseGUI.normal.background = (Texture2D)camicon;
				float a3 = camalpha;
				Color color7 = GUI.color;
				float num3 = (color7.a = a3);
				Color color8 = (GUI.color = color7);
				if (GUI.Button(new Rect(67f, Screen.height - 5 - 20, 30f, 20f), new GUIContent(string.Empty, "Enable snapshot mode (clears screen of GUI)"), pauseGUI))
				{
					hideGUI = !hideGUI;
					if (hideGUI)
					{
						GameObject.Find("/GUI/SubMessage").SendMessage("setMessage", "Snapshot mode enabled\n(Click button in bottom-left corner again to disable)");
					}
					if (hideGUI)
					{
						GameObject.FindWithTag("minimap").camera.enabled = false;
					}
					else if (!hideGUI && QualitySettings.GetQualityLevel() != 0)
					{
						GameObject.FindWithTag("minimap").camera.enabled = true;
					}
				}
				pauseGUI.normal.background = (Texture2D)fullscreenicon;
				float a4 = fullscreenalpha;
				Color color10 = GUI.color;
				float num4 = (color10.a = a4);
				Color color11 = (GUI.color = color10);
				if (GUI.Button(new Rect(105f, Screen.height - 5 - 20, 20f, 20f), new GUIContent(string.Empty, "Toggle between fullscreen and windowed"), pauseGUI))
				{
					if (!Screen.fullScreen)
					{
						int num5 = UnityScript.Lang.Extensions.get_length((System.Array)resolutions) - 1;
						Screen.SetResolution(resolutions[num5].width, resolutions[num5].height, true);
					}
					Screen.fullScreen = !Screen.fullScreen;
				}
			}
			else
			{
				pauseGUI.normal.background = (Texture2D)fullscreenicon;
				float a5 = fullscreenalpha;
				Color color13 = GUI.color;
				float num6 = (color13.a = a5);
				Color color14 = (GUI.color = color13);
				if (GUI.Button(new Rect(40f, Screen.height - 5 - 20, 20f, 20f), new GUIContent(string.Empty, "Toggle between fullscreen and windowed"), pauseGUI))
				{
					if (!Screen.fullScreen)
					{
						int num5 = UnityScript.Lang.Extensions.get_length((System.Array)resolutions) - 1;
						Screen.SetResolution(resolutions[num5].width, resolutions[num5].height, true);
					}
					Screen.fullScreen = !Screen.fullScreen;
				}
			}
		}
		if (GUI.tooltip != string.Empty)
		{
			fadetool = true;
		}
		else
		{
			fadetool = false;
		}
		float a6 = toolalpha;
		Color color16 = GUI.color;
		float num7 = (color16.a = a6);
		Color color17 = (GUI.color = color16);
		GUI.Label(new Rect(Mathf.Min(Input.mousePosition.x, Screen.width - 324), Mathf.Min((float)Screen.height - Input.mousePosition.y + 15f, Screen.height - 70), 324f, 70f), GUI.tooltip, tooltipstyle);
	}

	public virtual void Update()
	{
		if (fadetool)
		{
			if (!(toolalpha >= 1f))
			{
				toolalpha += 4f * Time.deltaTime;
			}
			else
			{
				toolalpha = 1f;
			}
		}
		else if (!(toolalpha <= 0f))
		{
			toolalpha -= 4f * Time.deltaTime;
		}
		else
		{
			toolalpha = 0f;
		}
		if (!HeadlesssDedServer.isServerHost)
		{
			if (curvol == 3 && AudioListener.volume != 1f)
			{
				AudioListener.volume = 1f;
			}
			if (curvol == 2 && AudioListener.volume != 0.66f)
			{
				AudioListener.volume = 0.66f;
			}
			if (curvol == 1 && AudioListener.volume != 0.33f)
			{
				AudioListener.volume = 0.33f;
			}
			if (curvol == 0 && AudioListener.volume != 0f)
			{
				AudioListener.volume = 0f;
			}
		}
		if (new Rect(5f, 0f, 25f, 20f).Contains(Input.mousePosition))
		{
			if (!(alpha >= 0.4f))
			{
				alpha += 0.7f * Time.deltaTime;
			}
			else
			{
				alpha = 0.4f;
			}
		}
		else if (!(alpha <= (hideGUI ? 0f : 0.2f)))
		{
			alpha -= 0.45f * Time.deltaTime;
		}
		else
		{
			alpha = (hideGUI ? 0f : 0.2f);
		}
		if (new Rect(39f, 0f, 20f, 20f).Contains(Input.mousePosition))
		{
			if (!(pausealpha >= 0.4f))
			{
				pausealpha += 0.7f * Time.deltaTime;
			}
			else
			{
				pausealpha = 0.4f;
			}
		}
		else if (!(pausealpha <= (hideGUI ? 0f : 0.2f)))
		{
			pausealpha -= 0.45f * Time.deltaTime;
		}
		else
		{
			pausealpha = (hideGUI ? 0f : 0.2f);
		}
		if (new Rect(67f, 0f, 30f, 20f).Contains(Input.mousePosition))
		{
			if (!(camalpha >= 0.4f))
			{
				camalpha += 0.7f * Time.deltaTime;
			}
			else
			{
				camalpha = 0.4f;
			}
		}
		else if (!(camalpha <= (hideGUI ? 0f : 0.2f)))
		{
			camalpha -= 0.45f * Time.deltaTime;
		}
		else
		{
			camalpha = (hideGUI ? 0f : 0.2f);
		}
		if (Application.loadedLevelName != "Menu")
		{
			if (!PreloaderExplosion.isKong || !Application.isWebPlayer)
			{
				if (new Rect(105f, 0f, 20f, 20f).Contains(Input.mousePosition))
				{
					if (!(fullscreenalpha >= 0.4f))
					{
						fullscreenalpha += 0.7f * Time.deltaTime;
					}
					else
					{
						fullscreenalpha = 0.4f;
					}
				}
				else if (!(fullscreenalpha <= (hideGUI ? 0f : 0.2f)))
				{
					fullscreenalpha -= 0.45f * Time.deltaTime;
				}
				else
				{
					fullscreenalpha = (hideGUI ? 0f : 0.2f);
				}
			}
		}
		else if (!PreloaderExplosion.isKong || !Application.isWebPlayer)
		{
			if (new Rect(40f, 0f, 20f, 20f).Contains(Input.mousePosition))
			{
				if (!(fullscreenalpha >= 0.4f))
				{
					fullscreenalpha += 0.7f * Time.deltaTime;
				}
				else
				{
					fullscreenalpha = 0.4f;
				}
			}
			else if (!(fullscreenalpha <= (hideGUI ? 0f : 0.2f)))
			{
				fullscreenalpha -= 0.45f * Time.deltaTime;
			}
			else
			{
				fullscreenalpha = (hideGUI ? 0f : 0.2f);
			}
		}
		if (GUI.tooltip != string.Empty)
		{
			fadetool = true;
		}
		else
		{
			fadetool = false;
		}
		float a = toolalpha;
		Color color = GUI.color;
		float num = (color.a = a);
		Color color2 = (GUI.color = color);
	}

	public virtual void Main()
	{
	}
}
