using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class StartMainGameAudLater : MonoBehaviour
{
	[Serializable]
	internal sealed class _0024startgameaud_00244947 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal StartMainGameAudLater _0024self__00244948;

			public _0024(StartMainGameAudLater self_)
			{
				_0024self__00244948 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					result = (Yield(2, new WaitForSeconds(1.1f)) ? 1 : 0);
					break;
				case 2:
				case 3:
					if (_0024self__00244948.auds[0].volume < 0.6f)
					{
						_0024self__00244948.auds[0].volume = _0024self__00244948.auds[0].volume + 0.24f * Time.deltaTime;
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal StartMainGameAudLater _0024self__00244949;

		public _0024startgameaud_00244947(StartMainGameAudLater self_)
		{
			_0024self__00244949 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00244949);
		}
	}

	private float t;

	public AudioSource[] auds;

	public AuthGameObject auth;

	public StartMainGameAudLater()
	{
		t = 1.3f;
	}

	public virtual void Start()
	{
		auds = GetComponents<AudioSource>();
		auds[0].volume = 0f;
		auds[0].Play();
		if (AuthGameObject.weatherindex != 2 && AuthGameObject.weatherindex != 5)
		{
			auds[1].volume = 0f;
			auds[1].enabled = false;
		}
		StartCoroutine_Auto(startgameaud());
	}

	public virtual IEnumerator startgameaud()
	{
		return new _0024startgameaud_00244947(this).GetEnumerator();
	}

	public virtual void Update()
	{
		if (UnityScript.Lang.Extensions.get_length((System.Array)auds) == 3)
		{
			if (!(transform.position.y >= 11.5f))
			{
				auds[2].volume = Mathf.Lerp(auds[2].volume, 0.7f, Time.time);
			}
			else
			{
				auds[2].volume = Mathf.Lerp(auds[2].volume, 0f, Time.time);
			}
		}
	}

	public virtual void Main()
	{
	}
}
