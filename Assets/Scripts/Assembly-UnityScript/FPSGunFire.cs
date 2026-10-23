using System;
using Boo.Lang.Runtime;
using Photon;
using UnityEngine;

[Serializable]
public class FPSGunFire : Photon.MonoBehaviour
{
	public LayerMask layermask;

	public Transform casingspawn;

	public GameObject bullet;

	public GameObject minigunflash;

	public GameObject bulletcasing;

	public Transform firePoint;

	private AuthGameObject authobj;

	private SpawningScript spawnsrc;

	private float fireCounter;

	public GunAndCameraBob camBob;

	private EndofRound eor;

	private PauseObject pobj;

	private ChatScript cscript;

	public bool firing;

	public Transform alternateFlashLocation;

	public Transform alternateCasingLocation;

	private ProjectileReferenceManager projMan;

	private ConduitInputReciever cInput;

	public FPSGunFire()
	{
		fireCounter = 0.15f;
	}

	public virtual void Awake()
	{
		projMan = (ProjectileReferenceManager)GameObject.Find("/ProjectileMan").GetComponent(typeof(ProjectileReferenceManager));
	}

	public virtual void Update()
	{
		if (!photonView.isMine || PauseObject.pubalpha != 0f || EndofRound.alphastat != 0f)
		{
			return;
		}
		if (Input.GetButtonDown("Fire1"))
		{
			fireCounter = 0f;
		}
		if (Input.GetButton("Fire1") || RuntimeServices.ToBool(ConduitInputReciever.ht["tPadState"]))
		{
			if (!firing)
			{
				firing = true;
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("setFireState", PhotonTargets.Others, true);
			}
			if (!(fireCounter <= 0f))
			{
				fireCounter -= Time.deltaTime * ((!ChatScript.hasrapidfire) ? 1f : 2f);
				return;
			}
			fireCounter = 0.15f;
			camBob.bulletFire = true;
			Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
			RaycastHit hitInfo = default(RaycastHit);
			if (Physics.Raycast(ray, out hitInfo, float.PositiveInfinity, layermask))
			{
				Vector3 vector = new Vector3(UnityEngine.Random.Range(-2f, 2f), UnityEngine.Random.Range(-2f, 2f), UnityEngine.Random.Range(-2f, 2f));
				vector *= Mathf.Min(1.2f, hitInfo.distance / 50f);
				Vector3 forward = hitInfo.point + vector - transform.position;
				Quaternion quaternion = Quaternion.LookRotation(forward);
				((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("firegun", PhotonTargets.All, AuthGameObject.username, UnityEngine.Random.Range(-999999999, 999999999), 1, SpawningScript.team2, quaternion, (!ChatScript.hasrapidfire) ? 1f : 0.5f);
			}
		}
		else if (firing)
		{
			firing = false;
			((PhotonView)gameObject.GetComponent(typeof(PhotonView))).RPC("setFireState", PhotonTargets.Others, false);
		}
	}

	[RPC]
	public virtual void setFireState(bool b)
	{
		firing = b;
	}

	[RPC]
	public virtual void firegun(string user, int id, int level, string team, Quaternion rot, float dM)
	{
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(bullet, transform.position, rot);
		GameObject gameObject2 = (GameObject)UnityEngine.Object.Instantiate(bulletcasing, (!photonView.isMine) ? alternateCasingLocation.position : casingspawn.position, (!photonView.isMine) ? alternateCasingLocation.rotation : casingspawn.rotation);
		GameObject gameObject3 = (GameObject)UnityEngine.Object.Instantiate(minigunflash, (!photonView.isMine) ? alternateFlashLocation.position : transform.position, (!photonView.isMine) ? alternateFlashLocation.rotation : transform.rotation);
		gameObject3.transform.parent = transform;
		gameObject2.rigidbody.AddRelativeForce(new Vector3(UnityEngine.Random.Range(240, 285), UnityEngine.Random.Range(85, 105), 0f));
		transform.audio.PlayOneShot(transform.audio.clip);
		gameObject.gameObject.SendMessage("setOwner", user);
		gameObject.gameObject.SendMessage("setlevel", level);
		gameObject.gameObject.SendMessage("setteam", team);
		gameObject.gameObject.SendMessage("setID", id);
		projMan.AllocateNewId(gameObject, id);
		((LowPolyBulletExplode)gameObject.gameObject.GetComponent(typeof(LowPolyBulletExplode))).firedFromObject = transform.root.gameObject;
		((LowPolyBulletExplode)gameObject.gameObject.GetComponent(typeof(LowPolyBulletExplode))).projMan = projMan;
		((LowPolyBulletExplode)gameObject.gameObject.GetComponent(typeof(LowPolyBulletExplode))).dM = dM;
		if ((bool)transform.root.collider)
		{
			Physics.IgnoreCollision(gameObject2.gameObject.collider, transform.root.collider);
		}
	}
}
