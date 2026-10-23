using UnityEngine;

public class RibbonMeshScript : MonoBehaviour
{
	private GameObject rootBoneObject;

	private int numLinks = 10;

	public float linkGravity = 0.015f;

	public float maxForceStrength = 0.5f;

	private GameObject[] ropeLinksArray;

	private GameObject[] bonesArray;

	private Vector3[] positionArray;

	private Vector3[] ribbonForces;

	private Vector3 worldUp = Vector3.up;

	public Vector3 hairGelDir = new Vector3(0f, 0f, 0f);

	public float hairGelStrength = 0.05f;

	public float hairGelInfluence = 0.4f;

	private float[] linkLengths;

	private void Start()
	{
		rootBoneObject = base.gameObject;
		maxForceStrength *= 1.6f;
		hairGelDir.Normalize();
		numLinks = 1;
		bool flag = true;
		Transform transform = rootBoneObject.transform;
		while (flag)
		{
			int num = 0;
			foreach (Transform item in transform)
			{
				num++;
				if (item.GetComponent<SkinnedMeshRenderer>() == null)
				{
					transform = item;
					numLinks++;
				}
			}
			if (num == 0)
			{
				flag = false;
			}
		}
		bonesArray = new GameObject[numLinks];
		positionArray = new Vector3[numLinks];
		ribbonForces = new Vector3[numLinks];
		linkLengths = new float[numLinks];
		bonesArray[0] = rootBoneObject;
		int num2 = 1;
		flag = true;
		transform = rootBoneObject.transform;
		while (flag)
		{
			int num3 = 0;
			foreach (Transform item2 in transform)
			{
				num3++;
				if (item2.GetComponent<SkinnedMeshRenderer>() == null)
				{
					bonesArray[num2] = item2.gameObject;
					positionArray[num2] = bonesArray[num2].transform.position;
					transform = item2;
					num2++;
				}
			}
			if (num3 == 0)
			{
				flag = false;
			}
		}
		ropeLinksArray = new GameObject[numLinks];
		ropeLinksArray[0] = new GameObject();
		ropeLinksArray[0].transform.position = bonesArray[0].transform.position;
		ropeLinksArray[0].transform.LookAt(bonesArray[1].transform.position);
		ropeLinksArray[0].transform.LookAt(ropeLinksArray[0].transform.position - ropeLinksArray[0].transform.forward);
		ropeLinksArray[0].transform.parent = base.transform.parent;
		base.transform.parent = ropeLinksArray[0].transform;
		for (int i = 1; i < bonesArray.Length; i++)
		{
			ropeLinksArray[i] = new GameObject();
			ropeLinksArray[i].transform.position = bonesArray[i].transform.position;
			ropeLinksArray[i].transform.LookAt(bonesArray[i - 1].transform.position);
			ropeLinksArray[i].transform.parent = ropeLinksArray[0].transform;
			bonesArray[i].transform.parent = ropeLinksArray[i].transform;
		}
		for (int j = 0; j < bonesArray.Length; j++)
		{
		}
		for (int k = 1; k < bonesArray.Length; k++)
		{
			linkLengths[k] = Vector3.Distance(ropeLinksArray[k].transform.position, ropeLinksArray[k - 1].transform.position);
		}
	}

	private void FixedUpdate()
	{
		float num = hairGelStrength;
		positionArray[0] = ropeLinksArray[0].transform.position;
		for (int i = 1; i < ropeLinksArray.Length; i++)
		{
			positionArray[i] += ribbonForces[i];
			if (Vector3.Distance(positionArray[i - 1], positionArray[i]) > linkLengths[i])
			{
				Vector3 vector = positionArray[i];
				Vector3 vector2 = positionArray[i] - positionArray[i - 1];
				vector2.Normalize();
				positionArray[i] = positionArray[i - 1] + vector2 * linkLengths[i];
				ribbonForces[i] += (positionArray[i] - vector) * 0.8f;
			}
			ribbonForces[i] *= 0.9f;
			ribbonForces[i] += worldUp * (0f - linkGravity);
			Vector3 vector3 = -ropeLinksArray[0].transform.right * hairGelDir.x + -ropeLinksArray[0].transform.up * hairGelDir.y + -ropeLinksArray[0].transform.forward * hairGelDir.z;
			vector3.Normalize();
			ribbonForces[i] += vector3 * num;
			if (ribbonForces[i].magnitude > maxForceStrength)
			{
				ribbonForces[i].Normalize();
				ribbonForces[i] *= maxForceStrength;
			}
			num *= hairGelInfluence;
		}
	}

	private void LateUpdate()
	{
		for (int i = 1; i < ropeLinksArray.Length; i++)
		{
			ropeLinksArray[i].transform.position = positionArray[i];
			ropeLinksArray[i].transform.LookAt(positionArray[i - 1], ropeLinksArray[i - 1].transform.up);
		}
	}
}
