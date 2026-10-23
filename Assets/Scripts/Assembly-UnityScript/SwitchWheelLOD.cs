using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Photon;
using UnityEngine;

[Serializable]
public class SwitchWheelLOD : Photon.MonoBehaviour
{
	[Serializable]
	internal sealed class _0024setcloak_00244950 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal bool _0024t_00244951;

			internal SwitchWheelLOD _0024self__00244952;

			public _0024(bool t, SwitchWheelLOD self_)
			{
				_0024t_00244951 = t;
				_0024self__00244952 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00244952.cloaked = _0024t_00244951;
					if (_0024t_00244951)
					{
						_0024self__00244952.invisglow.emit = true;
						result = (Yield(2, new WaitForSeconds(1f)) ? 1 : 0);
						break;
					}
					_0024self__00244952.invisglow.emit = false;
					goto IL_007f;
				case 2:
					_0024self__00244952.invisglow.emit = false;
					goto IL_007f;
				case 1:
					{
						result = 0;
						break;
					}
					IL_007f:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal bool _0024t_00244953;

		internal SwitchWheelLOD _0024self__00244954;

		public _0024setcloak_00244950(bool t, SwitchWheelLOD self_)
		{
			_0024t_00244953 = t;
			_0024self__00244954 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024t_00244953, _0024self__00244954);
		}
	}

	public Transform maincar;

	public Renderer wheel1;

	public Renderer wheel2;

	public Renderer wheel3;

	public Renderer wheel4;

	public Renderer simp1;

	public Renderer simp2;

	public Renderer simp3;

	public Renderer simp4;

	public Renderer shock1;

	public Renderer shock2;

	public Renderer shock3;

	public Renderer shock4;

	private float timer;

	public SpawningScript spawnobj;

	private bool cloaked;

	public ParticleEmitter invisglow;

	public SwitchWheelLOD()
	{
		timer = 5f;
	}

	public virtual void setmain(Transform t)
	{
		maincar = t;
	}

	public virtual void Start()
	{
		maincar = SpawningScript.playertrans;
	}

	public virtual void returncloakstate(GameObject s)
	{
		s.SendMessage("returnedcloakstate", cloaked);
	}

	public virtual void Update()
	{
		if (!photonView.isMine)
		{
			if (!(timer <= 0f))
			{
				timer -= Time.deltaTime;
			}
			else if (!(timer > 0f))
			{
				timer = 5f;
			}
		}
	}

	public virtual IEnumerator setcloak(bool t)
	{
		return new _0024setcloak_00244950(t, this).GetEnumerator();
	}

	public virtual void setwheels()
	{
		if (maincar != null && !cloaked)
		{
			float sqrMagnitude = (maincar.position - transform.position).sqrMagnitude;
			bool flag = default(bool);
			if (!(sqrMagnitude <= 422500f))
			{
				flag = true;
			}
			if (!(sqrMagnitude >= 422500f))
			{
				flag = false;
			}
			if (flag)
			{
				wheel1.enabled = false;
				wheel2.enabled = false;
				wheel3.enabled = false;
				wheel4.enabled = false;
				simp1.enabled = true;
				simp2.enabled = true;
				simp3.enabled = true;
				simp4.enabled = true;
				shock1.enabled = false;
				shock2.enabled = false;
				shock3.enabled = false;
				shock4.enabled = false;
			}
			else
			{
				wheel1.enabled = true;
				wheel2.enabled = true;
				wheel3.enabled = true;
				wheel4.enabled = true;
				simp1.enabled = false;
				simp2.enabled = false;
				simp3.enabled = false;
				simp4.enabled = false;
				shock1.enabled = true;
				shock2.enabled = true;
				shock3.enabled = true;
				shock4.enabled = true;
			}
		}
	}

	public virtual void Main()
	{
	}
}
