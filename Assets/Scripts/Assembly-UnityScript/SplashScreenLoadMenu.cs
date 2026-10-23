using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Photon;
using UnityEngine;

[Serializable]
public class SplashScreenLoadMenu : Photon.MonoBehaviour
{
	[Serializable]
	internal sealed class _0024yieldhold_00244938 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal SplashScreenLoadMenu _0024self__00244939;

			public _0024(SplashScreenLoadMenu self_)
			{
				_0024self__00244939 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					result = (Yield(2, new WaitForSeconds(0.35f)) ? 1 : 0);
					break;
				case 2:
					_0024self__00244939.hold = false;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal SplashScreenLoadMenu _0024self__00244940;

		public _0024yieldhold_00244938(SplashScreenLoadMenu self_)
		{
			_0024self__00244940 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00244940);
		}
	}

	[Serializable]
	internal sealed class _0024decalpha_00244941 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal SplashScreenLoadMenu _0024self__00244942;

			public _0024(SplashScreenLoadMenu self_)
			{
				_0024self__00244942 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					result = (Yield(2, new WaitForSeconds(2f)) ? 1 : 0);
					break;
				case 2:
					_0024self__00244942.godown = true;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal SplashScreenLoadMenu _0024self__00244943;

		public _0024decalpha_00244941(SplashScreenLoadMenu self_)
		{
			_0024self__00244943 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00244943);
		}
	}

	private float curalpha;

	private bool godown;

	private bool hold;

	public string url;

	public Texture standalone;

	public GUIStyle labelstyle;

	public PreloaderExplosion pex;

	public HeadlesssDedServer headless;

	public SplashScreenLoadMenu()
	{
		hold = true;
		url = "http://4.bp.blogspot.com/_hF_IONjrwbU/TSAjapSBc8I/AAAAAAAAAZE/RYbzH7lJ3Cc/s1600/CarbonCombatTinyIcon.png";
	}

	public virtual void OnFailedToConnectToPhoton()
	{
		PhotonNetwork.ConnectUsingSettings(PreloaderExplosion.versionNumber);
	}

	public virtual void Start()
	{
		PhotonNetwork.ConnectUsingSettings(PreloaderExplosion.versionNumber);
		Application.targetFrameRate = -1;
		PhotonNetwork.sendRate = 11;
		Screen.showCursor = true;
		QualitySettings.SetQualityLevel(5);
		StartCoroutine_Auto(yieldhold());
	}

	public virtual IEnumerator yieldhold()
	{
		return new _0024yieldhold_00244938(this).GetEnumerator();
	}

	public virtual void OnGUI()
	{
		float a = curalpha;
		Color color = GUI.color;
		float num = (color.a = a);
		Color color2 = (GUI.color = color);
		GUI.DrawTexture(new Rect(Screen.width / 2 - 138, Screen.height / 2 - 138, 275f, 275f), standalone);
		GUI.Label(new Rect(Screen.width / 2 + 120, Screen.height / 2 + 100, 100f, 20f), "v" + PreloaderExplosion.versionNumber, labelstyle);
	}

	public virtual void Update()
	{
		if (hold)
		{
			return;
		}
		if (!(curalpha > 0.99f) && !godown)
		{
			curalpha += Time.deltaTime * 0.4f;
		}
		if (!(curalpha < 0.99f))
		{
			StartCoroutine_Auto(decalpha());
		}
		if (godown)
		{
			if (!(curalpha < 0f))
			{
				curalpha -= Time.deltaTime * 0.4f;
			}
			if (!(curalpha > 0f))
			{
				loader();
			}
		}
	}

	public virtual void loader()
	{
		QualitySettings.SetQualityLevel(3);
		Application.LoadLevel("Menu");
	}

	public virtual IEnumerator decalpha()
	{
		return new _0024decalpha_00244941(this).GetEnumerator();
	}

	public virtual void Main()
	{
	}
}
