using System;
using System.Collections;
using Boo.Lang.Runtime;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class ForgeCam : MonoBehaviour
{
	private float hspeed;

	private float vspeed;

	private float aspeed;

	private float mult;

	private float mult2;

	private float mult3;

	private Vector2 cPoint;

	private Vector3 lastPos;

	public GameObject[] itemPrefab;

	[NonSerialized]
	public static int index;

	private Vector2 downPos;

	private bool isSelecting;

	private Vector3 selOffset;

	private Vector3 selPosOrig;

	private GameObject selObj;

	private GameObject pselObj;

	private float dragRot;

	private float origDrag;

	private float objDist;

	public Hashtable hashtable;

	public Hashtable hashtable2;

	public LayerMask layerMask;

	public Texture crossHair;

	private string isDrag;

	private Vector3 dragOrigPos;

	[NonSerialized]
	public static bool snap;

	public GUIStyle rotationStyle;

	public GUIStyle rotationStyleShadow;

	private string overSpawn;

	public ForgeGUI fgui;

	private GameObject undoObj;

	public Transform undoOrig;

	public Transform objectTool;

	public LayerMask myLayerMask;

	public LayerMask myMoveLayerMask;

	[NonSerialized]
	public static bool isDragging;

	private Vector3 origMovePos;

	private Quaternion origMoveRot;

	public Transform origMoveRotObj;

	private Vector3 origMoveRealPos;

	[NonSerialized]
	public static bool isUsingGizmo;

	[NonSerialized]
	public static int brushSize = 5;

	private TerrainDeform td;

	private float rotationX;

	private float rotationY;

	public GUISkin guiskin;

	public GUIStyle labelStyleShadow;

	public GUIStyle labelStyle;

	private Vector3 textFieldPos;

	private Vector3 textFieldRot;

	public ForgeCam()
	{
		hspeed = 1f;
		vspeed = 1f;
		aspeed = 1f;
		mult = 1f;
		mult2 = 1f;
		mult3 = 1f;
		lastPos = Vector3.zero;
		isDrag = string.Empty;
		overSpawn = string.Empty;
	}

	public virtual void OnGUI()
	{
		GUI.skin = guiskin;
		Rect source = new Rect
		{
			x = Input.mousePosition.x - (float)(Screen.width / 2),
			y = 10f + ((float)Screen.height - Input.mousePosition.y) - (float)(Screen.height / 2),
			width = Screen.width,
			height = Screen.height
		};
		if (isSelecting && overSpawn != "red" && overSpawn != "blue" && !selObj.name.Contains("Terrain") && overSpawn != "terrain")
		{
			if (!isUsingGizmo)
			{
				if (!selObj.name.Contains("Primative"))
				{
					GUI.Label(new Rect(source), "Press [x] to duplicate", rotationStyleShadow);
					GUI.Label(new Rect(source), "Press [x] to duplicate", rotationStyle);
				}
				else
				{
					GUI.Label(new Rect(source), "Press [x] to duplicate\nPress [c] to change color", rotationStyleShadow);
					GUI.Label(new Rect(source), "Press [x] to duplicate\nPress [c] to change color", rotationStyle);
				}
			}
			else
			{
				GUI.Label(new Rect(source), "FOR ROTATING & SCALING:\nDragging up increases value;\nDragging down decreases", rotationStyleShadow);
				GUI.Label(new Rect(source), "FOR ROTATING & SCALING:\nDragging up increases value;\nDragging down decreases", rotationStyle);
			}
		}
		else if (overSpawn == "red")
		{
			GUI.Label(new Rect(source), "Red Spawn Point/Size Rep.\nClick & drag to move", rotationStyleShadow);
			GUI.Label(new Rect(source), "Red Spawn Point/Size Rep.\nClick & drag to move", rotationStyle);
		}
		else if (overSpawn == "blue")
		{
			GUI.Label(new Rect(source), "Blue Spawn Point/Size Rep.\nClick & drag to move", rotationStyleShadow);
			GUI.Label(new Rect(source), "Blue Spawn Point/Size Rep.\nClick & drag to move", rotationStyle);
		}
		else if (overSpawn == "obj")
		{
			GUI.Label(new Rect(source), "Click & drag to move", rotationStyleShadow);
			GUI.Label(new Rect(source), "Click & drag to move", rotationStyle);
		}
		else if (overSpawn == "terrain" && !TerrainDeform.deforming)
		{
			GUI.Label(new Rect(source), "Click to raise terrain\n[Shift] + click to lower", rotationStyleShadow);
			GUI.Label(new Rect(source), "Click to raise terrain\n[Shift] + click to lower", rotationStyle);
		}
		else if (TerrainDeform.deforming)
		{
			GUI.Label(new Rect(source), "[e] and [q] adjusts size", rotationStyleShadow);
			GUI.Label(new Rect(source), "[e] and [q] adjusts size", rotationStyle);
		}
		if ((bool)selObj)
		{
			GUI.Label(new Rect(Screen.width - 150, 10f, 150f, 20f), "Selection Details", labelStyleShadow);
			GUI.Label(new Rect(Screen.width - 150, 10f, 150f, 20f), "Selection Details", labelStyle);
			GUI.Label(new Rect(Screen.width - 150, 35f, 150f, 20f), "Position", labelStyleShadow);
			GUI.Label(new Rect(Screen.width - 150, 35f, 150f, 20f), "Position", labelStyle);
			GUI.Label(new Rect(Screen.width - 150, 53f, 150f, 20f), "X:", labelStyleShadow);
			GUI.Label(new Rect(Screen.width - 150, 53f, 150f, 20f), "X:", labelStyle);
			textFieldPos.x = UnityBuiltins.parseFloat(GUI.TextField(new Rect(Screen.width - 130, 50f, 120f, 20f), textFieldPos.x.ToString()));
			GUI.Label(new Rect(Screen.width - 150, 73f, 150f, 20f), "Y:", labelStyleShadow);
			GUI.Label(new Rect(Screen.width - 150, 73f, 150f, 20f), "Y:", labelStyle);
			textFieldPos.y = UnityBuiltins.parseFloat(GUI.TextField(new Rect(Screen.width - 130, 70f, 120f, 20f), textFieldPos.y.ToString()));
			GUI.Label(new Rect(Screen.width - 150, 93f, 150f, 20f), "Z:", labelStyleShadow);
			GUI.Label(new Rect(Screen.width - 150, 93f, 150f, 20f), "Z:", labelStyle);
			textFieldPos.z = UnityBuiltins.parseFloat(GUI.TextField(new Rect(Screen.width - 130, 90f, 120f, 20f), textFieldPos.z.ToString()));
			GUI.Label(new Rect(Screen.width - 150, 115f, 150f, 20f), "Rotation", labelStyleShadow);
			GUI.Label(new Rect(Screen.width - 150, 115f, 150f, 20f), "Rotation", labelStyle);
			GUI.Label(new Rect(Screen.width - 150, 138f, 150f, 20f), "X:", labelStyleShadow);
			GUI.Label(new Rect(Screen.width - 150, 138f, 150f, 20f), "X:", labelStyle);
			textFieldRot.x = UnityBuiltins.parseFloat(GUI.TextField(new Rect(Screen.width - 130, 135f, 120f, 20f), textFieldRot.x.ToString()));
			GUI.Label(new Rect(Screen.width - 150, 158f, 150f, 20f), "Y:", labelStyleShadow);
			GUI.Label(new Rect(Screen.width - 150, 158f, 150f, 20f), "Y:", labelStyle);
			textFieldRot.y = UnityBuiltins.parseFloat(GUI.TextField(new Rect(Screen.width - 130, 155f, 120f, 20f), textFieldRot.y.ToString()));
			GUI.Label(new Rect(Screen.width - 150, 178f, 150f, 20f), "Z:", labelStyleShadow);
			GUI.Label(new Rect(Screen.width - 150, 178f, 150f, 20f), "Z:", labelStyle);
			textFieldRot.z = UnityBuiltins.parseFloat(GUI.TextField(new Rect(Screen.width - 130, 175f, 120f, 20f), textFieldRot.z.ToString()));
		}
	}

	public virtual void Awake()
	{
		index = 0;
		snap = false;
		isDragging = false;
		isUsingGizmo = false;
		brushSize = 5;
	}

	public virtual void LateUpdate()
	{
		if (isSelecting)
		{
			if (!objectTool.gameObject.active)
			{
				objectTool.gameObject.SetActiveRecursively(true);
			}
			objectTool.position = selObj.transform.position;
			objectTool.Find("ArrowParent").rotation = selObj.transform.rotation;
		}
		else if (objectTool.gameObject.active)
		{
			objectTool.gameObject.SetActiveRecursively(false);
		}
	}

	public virtual void Update()
	{
		if (!ForgeGUI.showMenu && !ForgeGUI.showMeshWindow)
		{
			if ((bool)selObj)
			{
				selObj.transform.position = textFieldPos;
				Vector3 vector = textFieldRot;
				Quaternion rotation = selObj.transform.rotation;
				Vector3 vector2 = (rotation.eulerAngles = vector);
				Quaternion quaternion = (selObj.transform.rotation = rotation);
			}
			RaycastHit hitInfo = default(RaycastHit);
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(this.transform.position, ray.direction, out hitInfo, float.PositiveInfinity, myLayerMask))
			{
				if (hitInfo.transform.root.gameObject.name == "RedSpawn(Clone)")
				{
					overSpawn = "red";
				}
				else if (hitInfo.transform.root.gameObject.name == "BlueSpawn(Clone)")
				{
					overSpawn = "blue";
				}
				else if (hitInfo.transform.root.gameObject.name.Contains("(Clone)"))
				{
					overSpawn = "obj";
				}
				else if (hitInfo.transform.gameObject.name == "Terrain" && index == 0)
				{
					overSpawn = "terrain";
				}
				else
				{
					overSpawn = string.Empty;
				}
			}
			else
			{
				overSpawn = string.Empty;
			}
			if (Input.GetButtonUp("Fire1") && (isSelecting || isDrag != string.Empty))
			{
				isDrag = string.Empty;
				isDragging = false;
				isUsingGizmo = false;
			}
			if ((Input.GetKeyDown(KeyCode.Backspace) || Input.GetKeyDown(KeyCode.Delete)) && (bool)pselObj && !pselObj.name.Contains("Spawn"))
			{
				UnityEngine.Object.Destroy(pselObj);
			}
			if (Input.GetKeyDown("z") && Input.GetAxis("Brake") != 0f)
			{
				undoObj.transform.position = undoOrig.position;
				undoObj.transform.rotation = undoOrig.rotation;
				undoObj.transform.localScale = undoOrig.localScale;
			}
			if (Input.GetKeyDown("c") && isSelecting && selObj.name.Contains("Primative"))
			{
				selObj.SendMessage("toggleColor");
			}
			if (Input.GetKeyDown("q"))
			{
				brushSize = Mathf.Clamp(brushSize - 1, 2, 25);
			}
			if (Input.GetKeyDown("e"))
			{
				brushSize = Mathf.Clamp(brushSize + 1, 2, 25);
			}
			if (Input.GetKeyDown("r"))
			{
				this.transform.position = new Vector3(0f, 105.0096f, 0f);
				this.transform.rotation = Quaternion.identity;
			}
			if (Input.GetKeyDown("x") && isSelecting && overSpawn != "red" && overSpawn != "blue" && !selObj.name.Contains("Terrain") && !selObj.name.Contains("Spawn"))
			{
				GameObject gameObject;
				if (!selObj.name.Contains("Custom"))
				{
					int num = default(int);
					int num2 = 0;
					int i = 0;
					GameObject[] array = itemPrefab;
					for (int length = array.Length; i < length; i++)
					{
						if (array[i].gameObject.name + "(Clone)" == selObj.name)
						{
							num = num2;
						}
						num2++;
					}
					gameObject = (GameObject)UnityEngine.Object.Instantiate(itemPrefab[num], selObj.transform.position, selObj.transform.rotation);
					gameObject.transform.localScale = selObj.transform.localScale;
				}
				else
				{
					gameObject = (GameObject)UnityEngine.Object.Instantiate(selObj, selObj.transform.position, selObj.transform.rotation);
				}
				if (gameObject.gameObject.transform.root.name.Contains("Primative"))
				{
					if ((bool)selObj)
					{
						if ((bool)(Rigidbody)selObj.GetComponent(typeof(Rigidbody)))
						{
							selObj.rigidbody.useGravity = true;
							selObj.rigidbody.isKinematic = false;
						}
						if (selObj.gameObject.name.Contains("Primative"))
						{
							selObj.renderer.material.shader = Shader.Find("Diffuse");
							IEnumerator enumerator = UnityRuntimeServices.GetEnumerator(selObj.transform);
							while (enumerator.MoveNext())
							{
								object current = enumerator.Current;
								if (RuntimeServices.EqualityOperator(UnityRuntimeServices.GetProperty(current, "name"), "Parent"))
								{
									UnityRuntimeServices.Invoke(UnityRuntimeServices.GetProperty(current, "gameObject"), "SetActiveRecursively", new object[1] { false }, typeof(MonoBehaviour));
									UnityRuntimeServices.Update(enumerator, current);
								}
							}
							gameObject.SendMessage("setInitColor", ((ForgeCubePrimColor)selObj.GetComponent(typeof(ForgeCubePrimColor))).curColor);
						}
						selObj = null;
					}
					selObj = gameObject.transform.gameObject;
					textFieldPos = selObj.transform.position;
					textFieldRot = selObj.transform.rotation.eulerAngles;
					pselObj = gameObject.transform.gameObject;
					hashtable.Add(selObj.transform, 0);
					hashtable2.Add(selObj.transform, 0);
					if (selObj.gameObject.name.Contains("Primative"))
					{
						selObj.renderer.material.shader = Shader.Find("Outlined/Diffuse");
						IEnumerator enumerator2 = UnityRuntimeServices.GetEnumerator(selObj.transform);
						while (enumerator2.MoveNext())
						{
							object obj = enumerator2.Current;
							if (!(obj is Transform))
							{
								obj = RuntimeServices.Coerce(obj, typeof(Transform));
							}
							Transform transform = (Transform)obj;
							if (transform.name == "Parent")
							{
								transform.gameObject.SetActiveRecursively(true);
								UnityRuntimeServices.Update(enumerator2, transform);
							}
						}
					}
				}
				else
				{
					pselObj = null;
				}
			}
			if (Input.GetKeyDown("g"))
			{
				snap = !snap;
			}
			if (Input.GetKeyDown("1") && index != 0)
			{
				index--;
			}
			if (Input.GetKeyDown("3") && index < UnityScript.Lang.Extensions.get_length((System.Array)itemPrefab) - 1)
			{
				index++;
			}
			Vector3 vector4 = default(Vector3);
			if (isDrag == "x")
			{
				ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				float x = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0f, 0f, 100f)).y - dragOrigPos.y + origMovePos.x;
				Vector3 localScale = selObj.transform.localScale;
				float num3 = (localScale.x = x);
				Vector3 vector5 = (selObj.transform.localScale = localScale);
				if (snap)
				{
					float x2 = selObj.transform.localScale.x - selObj.transform.localScale.x % 5f;
					Vector3 localScale2 = selObj.transform.localScale;
					float num4 = (localScale2.x = x2);
					Vector3 vector7 = (selObj.transform.localScale = localScale2);
				}
				if (!(selObj.transform.localScale.x >= 10f))
				{
					int num5 = 10;
					Vector3 localScale3 = selObj.transform.localScale;
					float num6 = (localScale3.x = num5);
					Vector3 vector9 = (selObj.transform.localScale = localScale3);
				}
			}
			if (isDrag == "x2")
			{
				ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				float x3 = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0f, 0f, 100f)).y - dragOrigPos.y + origMovePos.x;
				Vector3 localScale4 = selObj.transform.localScale;
				float num7 = (localScale4.x = x3);
				Vector3 vector11 = (selObj.transform.localScale = localScale4);
				if (snap)
				{
					float x4 = selObj.transform.localScale.x - selObj.transform.localScale.x % 5f;
					Vector3 localScale5 = selObj.transform.localScale;
					float num8 = (localScale5.x = x4);
					Vector3 vector13 = (selObj.transform.localScale = localScale5);
				}
				if (!(selObj.transform.localScale.x >= 10f))
				{
					int num9 = 10;
					Vector3 localScale6 = selObj.transform.localScale;
					float num10 = (localScale6.x = num9);
					Vector3 vector15 = (selObj.transform.localScale = localScale6);
				}
			}
			if (isDrag == "y")
			{
				ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				float y = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0f, 0f, 100f)).y - dragOrigPos.y + origMovePos.y;
				Vector3 localScale7 = selObj.transform.localScale;
				float num11 = (localScale7.y = y);
				Vector3 vector17 = (selObj.transform.localScale = localScale7);
				if (snap)
				{
					float y2 = selObj.transform.localScale.y - selObj.transform.localScale.y % 5f;
					Vector3 localScale8 = selObj.transform.localScale;
					float num12 = (localScale8.y = y2);
					Vector3 vector19 = (selObj.transform.localScale = localScale8);
				}
				if (!(selObj.transform.localScale.y >= 1f))
				{
					int num13 = 1;
					Vector3 localScale9 = selObj.transform.localScale;
					float num14 = (localScale9.y = num13);
					Vector3 vector21 = (selObj.transform.localScale = localScale9);
				}
			}
			if (isDrag == "y2")
			{
				ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				float y3 = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0f, 0f, 100f)).y - dragOrigPos.y + origMovePos.y;
				Vector3 localScale10 = selObj.transform.localScale;
				float num15 = (localScale10.y = y3);
				Vector3 vector23 = (selObj.transform.localScale = localScale10);
				if (snap)
				{
					float y4 = selObj.transform.localScale.y - selObj.transform.localScale.y % 5f;
					Vector3 localScale11 = selObj.transform.localScale;
					float num16 = (localScale11.y = y4);
					Vector3 vector25 = (selObj.transform.localScale = localScale11);
				}
				if (!(selObj.transform.localScale.y >= 1f))
				{
					int num17 = 1;
					Vector3 localScale12 = selObj.transform.localScale;
					float num18 = (localScale12.y = num17);
					Vector3 vector27 = (selObj.transform.localScale = localScale12);
				}
			}
			if (isDrag == "z")
			{
				ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				float z = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0f, 0f, 100f)).y - dragOrigPos.y + origMovePos.z;
				Vector3 localScale13 = selObj.transform.localScale;
				float num19 = (localScale13.z = z);
				Vector3 vector29 = (selObj.transform.localScale = localScale13);
				if (snap)
				{
					float z2 = selObj.transform.localScale.z - selObj.transform.localScale.z % 5f;
					Vector3 localScale14 = selObj.transform.localScale;
					float num20 = (localScale14.z = z2);
					Vector3 vector31 = (selObj.transform.localScale = localScale14);
				}
				if (!(selObj.transform.localScale.z >= 10f))
				{
					int num21 = 10;
					Vector3 localScale15 = selObj.transform.localScale;
					float num22 = (localScale15.z = num21);
					Vector3 vector33 = (selObj.transform.localScale = localScale15);
				}
			}
			if (isDrag == "z2")
			{
				ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				float z3 = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0f, 0f, 100f)).y - dragOrigPos.y + origMovePos.z;
				Vector3 localScale16 = selObj.transform.localScale;
				float num23 = (localScale16.z = z3);
				Vector3 vector35 = (selObj.transform.localScale = localScale16);
				if (snap)
				{
					float z4 = selObj.transform.localScale.z - selObj.transform.localScale.z % 5f;
					Vector3 localScale17 = selObj.transform.localScale;
					float num24 = (localScale17.z = z4);
					Vector3 vector37 = (selObj.transform.localScale = localScale17);
				}
				if (!(selObj.transform.localScale.z >= 10f))
				{
					int num25 = 10;
					Vector3 localScale18 = selObj.transform.localScale;
					float num26 = (localScale18.z = num25);
					Vector3 vector39 = (selObj.transform.localScale = localScale18);
				}
			}
			if (isDrag == "mx")
			{
				ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				float x5 = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0f, 0f, 100f)).x - dragOrigPos.x + origMovePos.x;
				Vector3 position = selObj.transform.position;
				float num27 = (position.x = x5);
				Vector3 vector41 = (selObj.transform.position = position);
			}
			if (isDrag == "my")
			{
				ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				float y5 = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0f, 0f, 100f)).y - dragOrigPos.y + origMovePos.y;
				Vector3 position2 = selObj.transform.position;
				float num28 = (position2.y = y5);
				Vector3 vector43 = (selObj.transform.position = position2);
			}
			if (isDrag == "mz")
			{
				ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				float z5 = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0f, 0f, 100f)).z - dragOrigPos.z + origMovePos.z;
				Vector3 position3 = selObj.transform.position;
				float num29 = (position3.z = z5);
				Vector3 vector45 = (selObj.transform.position = position3);
			}
			if (isDrag == "rx")
			{
				selObj.transform.Rotate(-Vector3.right * Input.GetAxis("Mouse Y"), Space.Self);
			}
			if (isDrag == "ry")
			{
				selObj.transform.Rotate(-Vector3.up * Input.GetAxis("Mouse Y"), Space.Self);
			}
			if (isDrag == "rz")
			{
				selObj.transform.Rotate(-Vector3.forward * Input.GetAxis("Mouse Y"), Space.Self);
			}
			if (Input.GetButtonDown("Fire2"))
			{
				ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				Debug.DrawRay(this.transform.position, ray.direction, Color.yellow);
				if (Physics.Raycast(this.transform.position, ray.direction, out hitInfo, 60f, myLayerMask) && (index != 0 || !Terrain.activeTerrain))
				{
					if (itemPrefab[index].gameObject.name.Contains("Custom"))
					{
						Camera.main.SendMessage("setMeshPos", hitInfo.point);
						Camera.main.SendMessage("setMeshRot", Quaternion.Euler(new Vector3(0f, this.transform.rotation.eulerAngles.y, 0f)));
						Camera.main.SendMessage("fadeInMesh");
					}
					else
					{
						GameObject gameObject2 = (GameObject)UnityEngine.Object.Instantiate(itemPrefab[index], hitInfo.point, Quaternion.Euler(new Vector3(0f, this.transform.rotation.eulerAngles.y, 0f)));
						if (index == 0)
						{
							gameObject2 = ((TerrainDeform)gameObject2.gameObject.GetComponent(typeof(TerrainDeform))).setMode("create");
							float y6 = 100.5f;
							Vector3 position4 = gameObject2.transform.position;
							float num30 = (position4.y = y6);
							Vector3 vector47 = (gameObject2.transform.position = position4);
						}
						else
						{
							float y7 = gameObject2.transform.position.y + (gameObject2.transform.position.y - gameObject2.collider.bounds.min.y);
							Vector3 position5 = gameObject2.transform.position;
							float num31 = (position5.y = y7);
							Vector3 vector49 = (gameObject2.transform.position = position5);
						}
						if ((bool)selObj)
						{
							if ((bool)(Rigidbody)selObj.GetComponent(typeof(Rigidbody)))
							{
								selObj.rigidbody.useGravity = true;
								selObj.rigidbody.isKinematic = false;
							}
							if (selObj.gameObject.name.Contains("Primative"))
							{
								selObj.renderer.material.shader = Shader.Find("Diffuse");
								IEnumerator enumerator3 = UnityRuntimeServices.GetEnumerator(selObj.transform);
								while (enumerator3.MoveNext())
								{
									object current2 = enumerator3.Current;
									if (RuntimeServices.EqualityOperator(UnityRuntimeServices.GetProperty(current2, "name"), "Parent"))
									{
										UnityRuntimeServices.Invoke(UnityRuntimeServices.GetProperty(current2, "gameObject"), "SetActiveRecursively", new object[1] { false }, typeof(MonoBehaviour));
										UnityRuntimeServices.Update(enumerator3, current2);
									}
								}
							}
							selObj = null;
						}
						selObj = gameObject2.transform.gameObject;
						textFieldPos = selObj.transform.position;
						textFieldRot = selObj.transform.rotation.eulerAngles;
						pselObj = gameObject2.transform.gameObject;
						hashtable.Add(selObj.transform, 0);
						hashtable2.Add(selObj.transform, 0);
						if (selObj.gameObject.name.Contains("Primative"))
						{
							selObj.renderer.material.shader = Shader.Find("Outlined/Diffuse");
							IEnumerator enumerator4 = UnityRuntimeServices.GetEnumerator(selObj.transform);
							while (enumerator4.MoveNext())
							{
								object obj2 = enumerator4.Current;
								if (!(obj2 is Transform))
								{
									obj2 = RuntimeServices.Coerce(obj2, typeof(Transform));
								}
								Transform transform2 = (Transform)obj2;
								if (transform2.name == "Parent")
								{
									transform2.gameObject.SetActiveRecursively(true);
									UnityRuntimeServices.Update(enumerator4, transform2);
								}
							}
						}
						isSelecting = true;
					}
				}
				else if (index != 0 || !Terrain.activeTerrain)
				{
					Vector3 vector51 = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0f, 0f, 60f));
					if (Physics.Linecast(this.transform.position, vector51, out hitInfo, myLayerMask))
					{
						vector51 = hitInfo.point;
					}
					if (itemPrefab[index].gameObject.name.Contains("Custom"))
					{
						Camera.main.SendMessage("setMeshPos", vector51);
						Camera.main.SendMessage("setMeshRot", Quaternion.Euler(new Vector3(0f, this.transform.rotation.eulerAngles.y, 0f)));
						Camera.main.SendMessage("fadeInMesh");
					}
					else
					{
						GameObject gameObject2 = (GameObject)UnityEngine.Object.Instantiate(itemPrefab[index], vector51, Quaternion.Euler(new Vector3(0f, this.transform.rotation.eulerAngles.y, 0f)));
						if (index == 0)
						{
							gameObject2 = ((TerrainDeform)gameObject2.gameObject.GetComponent(typeof(TerrainDeform))).setMode("create");
							float y8 = 100.5f;
							Vector3 position6 = gameObject2.transform.position;
							float num32 = (position6.y = y8);
							Vector3 vector52 = (gameObject2.transform.position = position6);
						}
						else
						{
							float y9 = gameObject2.transform.position.y + (gameObject2.transform.position.y - gameObject2.collider.bounds.min.y);
							Vector3 position7 = gameObject2.transform.position;
							float num33 = (position7.y = y9);
							Vector3 vector54 = (gameObject2.transform.position = position7);
						}
						if ((bool)selObj)
						{
							if ((bool)(Rigidbody)selObj.GetComponent(typeof(Rigidbody)))
							{
								selObj.rigidbody.useGravity = true;
								selObj.rigidbody.isKinematic = false;
							}
							if (selObj.gameObject.name.Contains("Primative"))
							{
								selObj.renderer.material.shader = Shader.Find("Diffuse");
								IEnumerator enumerator5 = UnityRuntimeServices.GetEnumerator(selObj.transform);
								while (enumerator5.MoveNext())
								{
									object current3 = enumerator5.Current;
									if (RuntimeServices.EqualityOperator(UnityRuntimeServices.GetProperty(current3, "name"), "Parent"))
									{
										UnityRuntimeServices.Invoke(UnityRuntimeServices.GetProperty(current3, "gameObject"), "SetActiveRecursively", new object[1] { false }, typeof(MonoBehaviour));
										UnityRuntimeServices.Update(enumerator5, current3);
									}
								}
							}
							selObj = null;
						}
						selObj = gameObject2.transform.gameObject;
						textFieldPos = selObj.transform.position;
						textFieldRot = selObj.transform.rotation.eulerAngles;
						hashtable.Add(selObj.transform, 0);
						hashtable2.Add(selObj.transform, 0);
						pselObj = gameObject2.transform.gameObject;
						if (selObj.gameObject.name.Contains("Primative"))
						{
							selObj.renderer.material.shader = Shader.Find("Outlined/Diffuse");
							IEnumerator enumerator6 = UnityRuntimeServices.GetEnumerator(selObj.transform);
							while (enumerator6.MoveNext())
							{
								object current4 = enumerator6.Current;
								if (RuntimeServices.EqualityOperator(UnityRuntimeServices.GetProperty(current4, "name"), "Parent"))
								{
									UnityRuntimeServices.Invoke(UnityRuntimeServices.GetProperty(current4, "gameObject"), "SetActiveRecursively", new object[1] { true }, typeof(MonoBehaviour));
									UnityRuntimeServices.Update(enumerator6, current4);
								}
							}
						}
						isSelecting = true;
					}
				}
			}
			if (Input.GetButtonDown("Fire1") && !Input.GetButton("Option") && (!new Rect(Screen.width - 150, Screen.height - 175, 150f, 175f).Contains(Input.mousePosition) || !selObj))
			{
				ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				Debug.DrawRay(this.transform.position, ray.direction, Color.yellow);
				if (Physics.Raycast(this.transform.position, ray.direction, out hitInfo, float.PositiveInfinity, myMoveLayerMask))
				{
					isUsingGizmo = true;
					if (hitInfo.transform.gameObject.name.Contains("Arrow"))
					{
						origMovePos = selObj.transform.position;
						if (hitInfo.transform.gameObject.name.Contains("X"))
						{
							dragOrigPos = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0f, 0f, 100f));
							isDrag = "mx";
						}
						if (hitInfo.transform.gameObject.name.Contains("Y"))
						{
							dragOrigPos = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0f, 0f, 100f));
							isDrag = "my";
						}
						if (hitInfo.transform.gameObject.name.Contains("Z"))
						{
							dragOrigPos = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0f, 0f, 100f));
							isDrag = "mz";
						}
						isDragging = false;
					}
					else if (hitInfo.transform.gameObject.name.Contains("Ring"))
					{
						origMoveRotObj.position = selObj.transform.position;
						origMoveRotObj.rotation = selObj.transform.rotation;
						origMoveRot = selObj.transform.rotation;
						if (hitInfo.transform.gameObject.name.Contains("X"))
						{
							dragOrigPos = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0f, 0f, 100f));
							isDrag = "rx";
						}
						if (hitInfo.transform.gameObject.name.Contains("Y"))
						{
							dragOrigPos = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0f, 0f, 100f));
							isDrag = "ry";
						}
						if (hitInfo.transform.gameObject.name.Contains("Z"))
						{
							dragOrigPos = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0f, 0f, 100f));
							isDrag = "rz";
						}
						isDragging = false;
					}
					else if (hitInfo.transform.gameObject.name.Contains("DragCube"))
					{
						origMovePos = selObj.transform.localScale;
						origMoveRealPos = hitInfo.transform.root.position;
						if (hitInfo.transform.gameObject.name == "DragCubeX")
						{
							isDrag = "x";
							dragOrigPos = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0f, 0f, 100f));
						}
						if (hitInfo.transform.gameObject.name == "DragCubeX2")
						{
							isDrag = "x2";
							dragOrigPos = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0f, 0f, 100f));
						}
						if (hitInfo.transform.gameObject.name == "DragCubeY")
						{
							isDrag = "y";
							dragOrigPos = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0f, 0f, 100f));
						}
						if (hitInfo.transform.gameObject.name == "DragCubeY2")
						{
							isDrag = "y2";
							dragOrigPos = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0f, 0f, 100f));
						}
						if (hitInfo.transform.gameObject.name == "DragCubeZ")
						{
							isDrag = "z";
							dragOrigPos = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0f, 0f, 100f));
						}
						if (hitInfo.transform.gameObject.name == "DragCubeZ2")
						{
							isDrag = "z2";
							dragOrigPos = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0f, 0f, 100f));
						}
					}
				}
				else
				{
					isUsingGizmo = false;
					if (Physics.Raycast(this.transform.position, ray.direction, out hitInfo, float.PositiveInfinity, myLayerMask))
					{
						if (hitInfo.transform.gameObject.name.Contains("(Clone)"))
						{
							if ((bool)selObj)
							{
								if ((bool)(Rigidbody)selObj.GetComponent(typeof(Rigidbody)))
								{
									selObj.rigidbody.useGravity = true;
									selObj.rigidbody.isKinematic = false;
								}
								if (selObj.gameObject.name.Contains("Primative"))
								{
									selObj.renderer.material.shader = Shader.Find("Diffuse");
									IEnumerator enumerator7 = UnityRuntimeServices.GetEnumerator(selObj.transform);
									while (enumerator7.MoveNext())
									{
										object current5 = enumerator7.Current;
										if (RuntimeServices.EqualityOperator(UnityRuntimeServices.GetProperty(current5, "name"), "Parent"))
										{
											UnityRuntimeServices.Invoke(UnityRuntimeServices.GetProperty(current5, "gameObject"), "SetActiveRecursively", new object[1] { false }, typeof(MonoBehaviour));
											UnityRuntimeServices.Update(enumerator7, current5);
										}
									}
								}
								selObj = null;
							}
							isSelecting = true;
							pselObj = hitInfo.transform.root.gameObject;
							selObj = hitInfo.transform.root.gameObject;
							textFieldPos = selObj.transform.position;
							textFieldRot = selObj.transform.rotation.eulerAngles;
							undoOrig.position = selObj.transform.position;
							undoOrig.rotation = selObj.transform.rotation;
							undoOrig.localScale = selObj.transform.localScale;
							undoObj = selObj;
							selOffset = hitInfo.point;
							selPosOrig = hitInfo.transform.root.transform.position;
							dragRot = this.transform.rotation.eulerAngles.y;
							origDrag = selObj.transform.rotation.eulerAngles.y;
							if ((selObj.transform.rotation.eulerAngles.x < 80f || !(selObj.transform.rotation.eulerAngles.x <= 260f)) && !(selObj.transform.rotation.eulerAngles.z <= 170f) && RuntimeServices.ToBool(RuntimeServices.InvokeBinaryOperator("op_GreaterThan", hashtable[selObj.transform], 80)))
							{
								origDrag -= 180f;
							}
							objDist = hitInfo.distance;
							if ((bool)(Rigidbody)selObj.GetComponent(typeof(Rigidbody)))
							{
								selObj.rigidbody.useGravity = false;
							}
							if (selObj.gameObject.name.Contains("Primative"))
							{
								selObj.renderer.material.shader = Shader.Find("Outlined/Diffuse");
								IEnumerator enumerator8 = UnityRuntimeServices.GetEnumerator(selObj.transform);
								while (enumerator8.MoveNext())
								{
									object obj3 = enumerator8.Current;
									if (!(obj3 is Transform))
									{
										obj3 = RuntimeServices.Coerce(obj3, typeof(Transform));
									}
									Transform transform3 = (Transform)obj3;
									if (transform3.name == "Parent")
									{
										transform3.gameObject.SetActiveRecursively(true);
										UnityRuntimeServices.Update(enumerator8, transform3);
									}
								}
							}
							isDragging = true;
						}
						else
						{
							if ((bool)selObj)
							{
								if ((bool)(Rigidbody)selObj.GetComponent(typeof(Rigidbody)))
								{
									selObj.rigidbody.useGravity = true;
									selObj.rigidbody.isKinematic = false;
								}
								if (selObj.gameObject.name.Contains("Primative"))
								{
									selObj.renderer.material.shader = Shader.Find("Diffuse");
									IEnumerator enumerator9 = UnityRuntimeServices.GetEnumerator(selObj.transform);
									while (enumerator9.MoveNext())
									{
										object obj4 = enumerator9.Current;
										if (!(obj4 is Transform))
										{
											obj4 = RuntimeServices.Coerce(obj4, typeof(Transform));
										}
										Transform transform4 = (Transform)obj4;
										if (transform4.name == "Parent")
										{
											transform4.gameObject.SetActiveRecursively(false);
											UnityRuntimeServices.Update(enumerator9, transform4);
										}
									}
								}
							}
							selObj = null;
							pselObj = null;
							isSelecting = false;
							isDrag = string.Empty;
							isDragging = false;
						}
					}
					else
					{
						if ((bool)selObj)
						{
							if ((bool)(Rigidbody)selObj.GetComponent(typeof(Rigidbody)))
							{
								selObj.rigidbody.useGravity = true;
								selObj.rigidbody.isKinematic = false;
							}
							if (selObj.gameObject.name.Contains("Primative"))
							{
								selObj.renderer.material.shader = Shader.Find("Diffuse");
								IEnumerator enumerator10 = UnityRuntimeServices.GetEnumerator(selObj.transform);
								while (enumerator10.MoveNext())
								{
									object obj5 = enumerator10.Current;
									if (!(obj5 is Transform))
									{
										obj5 = RuntimeServices.Coerce(obj5, typeof(Transform));
									}
									Transform transform5 = (Transform)obj5;
									if (transform5.name == "Parent")
									{
										transform5.gameObject.SetActiveRecursively(false);
										UnityRuntimeServices.Update(enumerator10, transform5);
									}
								}
							}
						}
						selObj = null;
						pselObj = null;
						isSelecting = false;
						isDrag = string.Empty;
						isDragging = false;
						isUsingGizmo = false;
					}
				}
			}
			if (isSelecting)
			{
				if (!hashtable.ContainsKey(selObj.transform))
				{
					hashtable.Add(selObj.transform, 0);
				}
				if (!hashtable2.ContainsKey(selObj.transform))
				{
					hashtable2.Add(selObj.transform, 0);
				}
				if ((Input.GetKeyDown(KeyCode.Backspace) || Input.GetKeyDown(KeyCode.Delete)) && !selObj.gameObject.name.Contains("Spawn"))
				{
					isSelecting = false;
					UnityEngine.Object.Destroy(selObj);
					isDrag = string.Empty;
				}
				if ((bool)(Rigidbody)selObj.GetComponent(typeof(Rigidbody)))
				{
					selObj.rigidbody.velocity = new Vector3(0f, 0f, 0f);
					selObj.rigidbody.angularVelocity = new Vector3(0f, 0f, 0f);
				}
				ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				if (isDragging)
				{
					if (Physics.Raycast(this.transform.position, ray.direction, out hitInfo, objDist, layerMask))
					{
						Vector3 vector56 = selPosOrig + (new Vector3(hitInfo.point.x, hitInfo.point.y, hitInfo.point.z) - selOffset);
						selObj.transform.position = Vector3.Lerp(selObj.transform.position, (!snap) ? vector56 : new Vector3(vector56.x - vector56.x % 2f, vector56.y - vector56.y % 2f, vector56.z - vector56.z % 2f), 10f * Time.deltaTime);
					}
					else
					{
						Vector3 vector51 = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0f, 0f, objDist)).x, Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0f, 0f, objDist)).y, Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0f, 0f, objDist)).z);
						if (Physics.Linecast(this.transform.position, vector51, out hitInfo, myLayerMask))
						{
							vector51 = hitInfo.point;
						}
						Vector3 vector56 = selPosOrig + (vector51 - selOffset);
						selObj.transform.position = Vector3.Lerp(selObj.transform.position, (!snap) ? vector56 : new Vector3(vector56.x - vector56.x % 2f, vector56.y - vector56.y % 2f, vector56.z - vector56.z % 2f), 10f * Time.deltaTime);
					}
					Quaternion rotation2 = selObj.transform.rotation;
					Vector3 vector57 = new Vector3(selObj.transform.rotation.eulerAngles.x, (((!(selObj.transform.rotation.eulerAngles.x < 80f) && selObj.transform.rotation.eulerAngles.x <= 260f) || selObj.transform.rotation.eulerAngles.z <= 170f || !RuntimeServices.ToBool(RuntimeServices.InvokeBinaryOperator("op_GreaterThan", hashtable[selObj.transform], 80))) ? origDrag : (180f + origDrag)) + (this.transform.rotation.eulerAngles.y - dragRot), selObj.transform.rotation.eulerAngles.z);
					selObj.transform.rotation = Quaternion.Slerp(selObj.transform.rotation, Quaternion.Euler((!snap) ? vector57 : new Vector3(vector57.x, vector57.y - vector57.y % 45f, vector57.z)), 10f * Time.deltaTime);
				}
			}
			else if ((bool)selObj && !selObj.name.Contains("Primative"))
			{
				if ((bool)(Rigidbody)selObj.GetComponent(typeof(Rigidbody)))
				{
					selObj.rigidbody.useGravity = true;
					selObj.rigidbody.isKinematic = false;
				}
				selObj = null;
			}
			this.transform.Translate(Input.GetAxis("Horizontal") * ((mult3 == 1f) ? 30f : (30f * mult3)) * Time.deltaTime * hspeed, 0f, Input.GetAxis("Vertical") * ((mult == 1f) ? 30f : (30f * mult)) * Time.deltaTime * vspeed, Space.Self);
			if (Input.GetButtonDown("Fire1"))
			{
				cPoint = Input.mousePosition;
			}
			if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.LeftApple))
			{
				Screen.lockCursor = true;
				this.transform.Translate(new Vector3(Input.GetAxis("Mouse X") * 2f * ForgeGUI.cspeed, 0f, 0f), Space.Self);
				this.transform.Translate(new Vector3(0f, Input.GetAxis("Mouse Y") * 2f * ForgeGUI.cspeed, 0f), Space.Self);
			}
			if (Input.GetButton("Option"))
			{
				Screen.lockCursor = true;
				if (!isSelecting || selObj.gameObject.name.Contains("Terrain"))
				{
					rotationX += Input.GetAxis("Mouse X") * 2.5f * ForgeGUI.cspeed;
					rotationY += Input.GetAxis("Mouse Y") * 2.5f * ForgeGUI.cspeed;
					rotationX = ClampAngle(rotationX, -360f, 360f);
					rotationY = ClampAngle(rotationY, -90f, 90f);
					this.transform.localRotation = Quaternion.AngleAxis(rotationX, Vector3.up);
					this.transform.localRotation = this.transform.localRotation * Quaternion.AngleAxis(rotationY, Vector3.left);
				}
				else
				{
					this.transform.LookAt(selObj.transform);
					this.transform.RotateAround(selObj.transform.position, Vector3.up, Input.GetAxis("Mouse X") * 2.5f * ForgeGUI.cspeed);
					this.transform.RotateAround(selObj.transform.position, this.transform.TransformDirection(Vector3.left), Input.GetAxis("Mouse Y") * 2.5f * ForgeGUI.cspeed);
				}
				cPoint = Input.mousePosition;
			}
			if (!Input.GetKey(KeyCode.LeftControl) && !Input.GetKey(KeyCode.LeftApple) && !Input.GetButton("Option"))
			{
				Screen.lockCursor = false;
			}
			if (Input.GetAxis("Horizontal") != 0f)
			{
				hspeed = Mathf.SmoothStep(hspeed, 100f, 5f * Time.deltaTime);
			}
			else
			{
				hspeed = 1f;
			}
			if (Input.GetAxis("Vertical") != 0f)
			{
				vspeed = Mathf.SmoothStep(vspeed, 100f, 5f * Time.deltaTime);
			}
			else
			{
				vspeed = 1f;
			}
			if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.LeftShift))
			{
				aspeed = Mathf.SmoothStep(aspeed, 100f, 5f * Time.deltaTime);
			}
			else
			{
				aspeed = 1f;
			}
			RaycastHit hitInfo2 = default(RaycastHit);
			if (Physics.Raycast(this.transform.position, this.transform.TransformDirection((!Input.GetKey(KeyCode.Space)) ? (-Vector3.up) : Vector3.up), out hitInfo2, 50f, myLayerMask))
			{
				Debug.DrawLine(this.transform.position, hitInfo2.point, Color.red);
				mult2 = (hitInfo2.distance - 5f) / 50f;
			}
			else
			{
				mult2 = 1f;
			}
			if (!(mult2 >= 0f))
			{
				mult2 = 0f;
			}
			if (!(mult2 <= 1f))
			{
				mult2 = 1f;
			}
			if (Physics.Raycast(this.transform.position, this.transform.TransformDirection((Input.GetAxis("Vertical") <= 0f) ? (-Vector3.forward) : Vector3.forward), out hitInfo2, 50f, myLayerMask))
			{
				Debug.DrawLine(this.transform.position, hitInfo2.point, Color.red);
				mult = (hitInfo2.distance - 5f) / 50f;
			}
			else
			{
				mult = 1f;
			}
			if (!(mult >= 0f))
			{
				mult = 0f;
			}
			if (!(mult <= 1f))
			{
				mult = 1f;
			}
			if (Physics.Raycast(this.transform.position, this.transform.TransformDirection((Input.GetAxis("Horizontal") <= 0f) ? Vector3.left : (-Vector3.left)), out hitInfo2, 50f, myLayerMask))
			{
				Debug.DrawLine(this.transform.position, hitInfo2.point, Color.red);
				mult3 = (hitInfo2.distance - 5f) / 50f;
			}
			else
			{
				mult3 = 1f;
			}
			if (!(mult3 >= 0f))
			{
				mult3 = 0f;
			}
			if (!(mult3 <= 1f))
			{
				mult3 = 1f;
			}
		}
		if ((bool)selObj)
		{
			textFieldPos = selObj.transform.position;
			textFieldRot = selObj.transform.rotation.eulerAngles;
		}
		Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, this.transform.position, 10f * Time.deltaTime);
		Camera.main.transform.rotation = Quaternion.Slerp(Camera.main.transform.rotation, this.transform.rotation, 10f * Time.deltaTime);
	}

	public virtual float ClampAngle(float angle, float min, float max)
	{
		if (!(angle >= -360f))
		{
			angle += 360f;
		}
		if (!(angle <= 360f))
		{
			angle -= 360f;
		}
		return Mathf.Clamp(angle, min, max);
	}

	public virtual void Main()
	{
		hashtable = new Hashtable();
		hashtable2 = new Hashtable();
	}
}
