using System;
using Photon;
using UnityEngine;

[Serializable]
public class GliderController : Photon.MonoBehaviour
{
	public bool gliderState;

	private float alphaMult;

	private Color initColor;

	private Color deadColor;

	private PhotonView cachedPView;

	private CalculateHealth chealth;

	public float motorInputSmoothed;

	private Rigidbody rigidbodyObj;

	private WheelCollider wheel;

	private float upForce;

	public bool isStalling;

	private bool buggyFlightLooPower;

	private float buggyFlightDrag;

	private float buggyFlightAgility;

	private bool buggyFlightSlip;

	private Vector3 maxVel;

	public GliderController()
	{
		alphaMult = 1f;
		upForce = -5000000f;
		buggyFlightDrag = 8.5E+10f;
		buggyFlightAgility = 10f;
		buggyFlightSlip = true;
		maxVel = Vector3.zero;
	}

	public virtual void Start()
	{
		initColor = renderer.material.GetColor("_Color");
		deadColor = Color.black;
		deadColor.a = 0f;
		cachedPView = (PhotonView)transform.root.gameObject.GetComponent(typeof(PhotonView));
		rigidbodyObj = transform.root.rigidbody;
		wheel = (WheelCollider)transform.root.Find("Wheel Colliders/BL").GetComponent(typeof(WheelCollider));
		if (!cachedPView.isMine)
		{
			cachedPView.RPC("rsS", cachedPView.owner);
			return;
		}
		cachedPView.RPC("sS", PhotonTargets.All, false);
		gliderState = false;
	}

	public virtual void Update()
	{
		if (gliderState && !(alphaMult >= 1f))
		{
			alphaMult = Mathf.Min(1f, alphaMult + 5f * Time.deltaTime);
		}
		if (!gliderState && !(alphaMult <= 0f))
		{
			alphaMult = Mathf.Max(0f, alphaMult - 5f * Time.deltaTime);
		}
		renderer.material.SetColor("_Color", Color.Lerp(deadColor, initColor, alphaMult));
		if (!(alphaMult > 0f))
		{
			if (renderer.enabled)
			{
				renderer.enabled = false;
			}
		}
		else if (!renderer.enabled)
		{
			renderer.enabled = true;
		}
		if (cachedPView.isMine && Input.GetKeyDown(KeyCode.F))
		{
			cachedPView.RPC("sS", PhotonTargets.All, !gliderState);
		}
	}

	public virtual void FixedUpdate()
	{
		if (!gliderState || rigidbodyObj.isKinematic)
		{
			return;
		}
		motorInputSmoothed = Mathf.Lerp(Input.GetAxis("Vertical") * 26f, motorInputSmoothed, 0.8f);
		float num = 1000f;
		Vector3 vector = transform.InverseTransformDirection(rigidbodyObj.velocity);
		float num2 = ((transform.eulerAngles.z <= 180f) ? transform.eulerAngles.z : (transform.eulerAngles.z - 360f));
		float num3 = ((transform.eulerAngles.x <= 180f) ? transform.eulerAngles.x : (transform.eulerAngles.x - 360f));
		rigidbodyObj.angularDrag = 1.5f;
		isStalling = false;
		if (!wheel.isGrounded)
		{
			rigidbodyObj.drag = rigidbodyObj.velocity.magnitude / (buggyFlightDrag * 900000f);
		}
		int num4 = 0;
		float num5 = Vector3.Angle(rigidbodyObj.velocity, transform.TransformDirection(Vector3.forward));
		if (!wheel.isGrounded)
		{
			if (!(num5 <= 10f) && buggyFlightSlip)
			{
				rigidbodyObj.velocity = rigidbodyObj.transform.TransformDirection(vector.x * 0.95f, vector.y * 0.95f, vector.z + (Mathf.Abs(vector.x) + Mathf.Abs(vector.y)) * 0.1f * (num5 / 360f));
			}
			else
			{
				rigidbodyObj.velocity = rigidbodyObj.transform.TransformDirection(0f, 0f, vector.magnitude + Time.deltaTime * 50f * (buggyFlightLooPower ? (Mathf.Abs(motorInputSmoothed) / 10f) : ((motorInputSmoothed >= 0.999f || motorInputSmoothed <= -0.999f) ? 0f : (Mathf.Abs(motorInputSmoothed) / 10f))));
			}
		}
		else if (!(Input.GetAxis("Vertical") >= 0f))
		{
			rigidbodyObj.AddRelativeForce(0f, ((Input.GetAxis("Vertical") >= 0f) ? 0f : Input.GetAxis("Vertical")) * upForce * Time.deltaTime * rigidbodyObj.velocity.magnitude / 65f, 0f);
		}
		rigidbodyObj.velocity = new Vector3(Mathf.Clamp(rigidbodyObj.velocity.x, -180f, 180f), Mathf.Clamp(rigidbodyObj.velocity.y, -180f, 180f), Mathf.Clamp(rigidbodyObj.velocity.z, -180f, 180f));
		rigidbodyObj.AddRelativeTorque(new Vector3(motorInputSmoothed * 100f * buggyFlightAgility, 0f, Input.GetAxis("Horizontal") * 26f * -100f * buggyFlightAgility));
		if (Input.GetAxis("Horizontal") == 0f && (transform.eulerAngles.z < 90f || !(transform.eulerAngles.z <= 270f)))
		{
			rigidbodyObj.AddRelativeTorque(((!(transform.eulerAngles.x < 10f) && transform.eulerAngles.x <= 350f) ? 0f : (num3 - 0.95f)) * 0f, num2 * -0.6f, (!(transform.eulerAngles.z < 20f) && transform.eulerAngles.z <= 340f) ? 0f : (num2 * -0.5f));
		}
		else if (Input.GetAxis("Horizontal") == 0f)
		{
			rigidbodyObj.AddRelativeTorque(0f, (transform.eulerAngles.z - 180f) * 0.4f, 0f);
		}
	}
}
