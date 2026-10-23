using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class RampLauncher : MonoBehaviour
{
	[Serializable]
	internal sealed class _0024addForce_00245155 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal bool _0024hascol_00245156;

			internal Collider _0024colcheck_00245157;

			internal IEnumerator _0024_0024iterator_0024352_00245158;

			internal Collider _0024col_00245159;

			internal RampLauncher _0024self__00245160;

			public _0024(Collider col, RampLauncher self_)
			{
				_0024col_00245159 = col;
				_0024self__00245160 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024hascol_00245156 = false;
					_0024_0024iterator_0024352_00245158 = UnityRuntimeServices.GetEnumerator(_0024self__00245160.collist);
					while (_0024_0024iterator_0024352_00245158.MoveNext())
					{
						object obj = _0024_0024iterator_0024352_00245158.Current;
						if (!(obj is Collider))
						{
							obj = RuntimeServices.Coerce(obj, typeof(Collider));
						}
						_0024colcheck_00245157 = (Collider)obj;
						if (_0024colcheck_00245157 == _0024col_00245159)
						{
							_0024hascol_00245156 = true;
						}
					}
					if (!_0024hascol_00245156)
					{
						_0024self__00245160.collist.Add(_0024col_00245159);
						goto case 2;
					}
					goto IL_0284;
				case 2:
					if (!(_0024self__00245160.counter <= 0f) && (bool)_0024col_00245159)
					{
						_0024self__00245160.counter -= Time.deltaTime;
						if (!(_0024self__00245160.counter > 0.5f))
						{
							_0024col_00245159.attachedRigidbody.AddForce(_0024self__00245160.transform.TransformDirection(0f, 0f, (float)_0024self__00245160.power * 0.0085f * (_0024self__00245160.counter / 0.5f) * Time.deltaTime * 60f));
						}
						else
						{
							_0024col_00245159.attachedRigidbody.AddForce(_0024self__00245160.transform.TransformDirection(0f, 0f, (float)_0024self__00245160.power * 0.0085f * Time.deltaTime * 60f));
						}
						if (Input.GetAxis("Jump") == 0f && _0024col_00245159.gameObject.name.Contains("CarPrefab"))
						{
							_0024col_00245159.attachedRigidbody.angularDrag = 15f;
						}
						result = (YieldDefault(2) ? 1 : 0);
					}
					else
					{
						if ((bool)_0024col_00245159 && _0024col_00245159.gameObject.name.Contains("CarPrefab") && Input.GetAxis("Jump") == 0f)
						{
							_0024col_00245159.attachedRigidbody.angularDrag = 0.05f;
						}
						_0024self__00245160.counter = 1.5f;
						result = (Yield(3, new WaitForSeconds(2f)) ? 1 : 0);
					}
					break;
				case 3:
					_0024self__00245160.collist.Clear();
					goto IL_0284;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0284:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal Collider _0024col_00245161;

		internal RampLauncher _0024self__00245162;

		public _0024addForce_00245155(Collider col, RampLauncher self_)
		{
			_0024col_00245161 = col;
			_0024self__00245162 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024col_00245161, _0024self__00245162);
		}
	}

	public int power;

	private float counter;

	private UnityScript.Lang.Array collist;

	public RampLauncher()
	{
		counter = 1.5f;
		collist = new UnityScript.Lang.Array();
	}

	public virtual void Awake()
	{
		power = (int)((float)power * 0.6f);
	}

	public virtual void OnTriggerEnter(Collider col)
	{
		if (col.attachedRigidbody != null && col.gameObject.name != "BotSpectator(Clone)")
		{
			if (col.gameObject.name.Contains("CarPrefab"))
			{
				col.attachedRigidbody.angularDrag = 15f;
				col.gameObject.SendMessage("disableHover");
				if (((PhotonView)col.gameObject.GetComponent(typeof(PhotonView))).isMine)
				{
					GameObject.Find("/AuthGameObject").SendMessage("gotAch", "Whoosh!");
				}
			}
			audio.PlayOneShot(audio.clip);
			StartCoroutine_Auto(addForce(col));
		}
		if (col.gameObject.name == "HumanPrefab(Clone)" && ((PhotonView)col.gameObject.GetComponent(typeof(PhotonView))).isMine)
		{
			GameObject.Find("/GUI/SubMessage").SendMessage("setMessage", "Launch ramps are only available for cars!");
		}
	}

	public virtual IEnumerator addForce(Collider col)
	{
		return new _0024addForce_00245155(col, this).GetEnumerator();
	}

	public virtual void Main()
	{
	}
}
