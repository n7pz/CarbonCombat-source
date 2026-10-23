using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class WaterFogCam : MonoBehaviour
{
	[Serializable]
	internal sealed class _0024setcolors_00245806 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal WaterFogCam _0024self__00245807;

			public _0024(WaterFogCam self_)
			{
				_0024self__00245807 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					result = (Yield(2, new WaitForSeconds(0.5f)) ? 1 : 0);
					break;
				case 2:
					_0024self__00245807.defcolor = RenderSettings.fogColor;
					_0024self__00245807.defdensity = RenderSettings.fogDensity;
					_0024self__00245807.go = true;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal WaterFogCam _0024self__00245808;

		public _0024setcolors_00245806(WaterFogCam self_)
		{
			_0024self__00245808 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00245808);
		}
	}

	public Color fogcolor;

	public Color fogcolornight;

	public float fogdensity;

	public AuthGameObject authobj;

	private bool go;

	private Color defcolor;

	public float defdensity;

	public GameObject guioverlay;

	public GameObject guioverlaynight;

	public WhirldIn win;

	public bool isUnderwater;

	public virtual void Start()
	{
		StartCoroutine_Auto(setcolors());
	}

	public virtual IEnumerator setcolors()
	{
		return new _0024setcolors_00245806(this).GetEnumerator();
	}

	public virtual void Update()
	{
		if (WhirldIn.hassea || AuthGameObject.whirldurl == string.Empty)
		{
			if (!go)
			{
				return;
			}
			if (transform.position.y < 11.5f || isUnderwater)
			{
				if (RenderSettings.fogMode != FogMode.ExponentialSquared)
				{
					RenderSettings.fogMode = FogMode.ExponentialSquared;
				}
				if (RenderSettings.fogDensity != fogdensity)
				{
					RenderSettings.fogDensity = fogdensity;
				}
				if (AuthGameObject.weatherindex >= 4)
				{
					if (RenderSettings.fogColor != fogcolornight)
					{
						RenderSettings.fogColor = fogcolornight;
					}
					if (!guioverlaynight.active)
					{
						guioverlaynight.active = true;
					}
				}
				else
				{
					if (RenderSettings.fogColor != fogcolor)
					{
						RenderSettings.fogColor = fogcolor;
					}
					if (!guioverlay.active)
					{
						guioverlay.active = true;
					}
				}
				return;
			}
			if (RenderSettings.fogDensity != defdensity)
			{
				RenderSettings.fogDensity = defdensity;
			}
			if (RenderSettings.fogColor != defcolor)
			{
				RenderSettings.fogColor = defcolor;
			}
			if (guioverlay.active)
			{
				guioverlay.active = false;
			}
			if (guioverlaynight.active)
			{
				guioverlaynight.active = false;
			}
			if (QualitySettings.GetQualityLevel() == 0 || QualitySettings.GetQualityLevel() == 1)
			{
				if (RenderSettings.fogMode != FogMode.Linear)
				{
					RenderSettings.fogMode = FogMode.Linear;
				}
				if (RenderSettings.fogEndDistance != Camera.main.farClipPlane)
				{
					RenderSettings.fogEndDistance = Camera.main.farClipPlane;
				}
				if (RenderSettings.fogStartDistance != Camera.main.farClipPlane - 500f)
				{
					RenderSettings.fogStartDistance = Camera.main.farClipPlane - 500f;
				}
			}
			else if (RenderSettings.fogMode != FogMode.ExponentialSquared)
			{
				RenderSettings.fogMode = FogMode.ExponentialSquared;
			}
			return;
		}
		if (RenderSettings.fogDensity != defdensity)
		{
			RenderSettings.fogDensity = defdensity;
		}
		if (RenderSettings.fogColor != defcolor)
		{
			RenderSettings.fogColor = defcolor;
		}
		if (guioverlay.active)
		{
			guioverlay.active = false;
		}
		if (guioverlaynight.active)
		{
			guioverlaynight.active = false;
		}
		if (QualitySettings.GetQualityLevel() == 0 || QualitySettings.GetQualityLevel() == 1)
		{
			if (RenderSettings.fogMode != FogMode.Linear)
			{
				RenderSettings.fogMode = FogMode.Linear;
			}
			if (RenderSettings.fogEndDistance != Camera.main.farClipPlane)
			{
				RenderSettings.fogEndDistance = Camera.main.farClipPlane;
			}
			if (RenderSettings.fogStartDistance != Camera.main.farClipPlane - 500f)
			{
				RenderSettings.fogStartDistance = Camera.main.farClipPlane - 500f;
			}
		}
		else if (RenderSettings.fogMode != FogMode.ExponentialSquared)
		{
			RenderSettings.fogMode = FogMode.ExponentialSquared;
		}
	}

	public virtual void Main()
	{
	}
}
