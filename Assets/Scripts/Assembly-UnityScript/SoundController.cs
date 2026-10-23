using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class SoundController : MonoBehaviour
{
	[Serializable]
	internal sealed class _0024GearShift_00245476 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal float _0024timer_00245477;

			internal float _0024pitchFactor_00245478;

			internal float _0024newPitch_00245479;

			internal float _0024oldPitchFactor_00245480;

			internal int _0024gear_00245481;

			internal bool _0024shiftUp_00245482;

			internal SoundController _0024self__00245483;

			public _0024(float oldPitchFactor, int gear, bool shiftUp, SoundController self_)
			{
				_0024oldPitchFactor_00245480 = oldPitchFactor;
				_0024gear_00245481 = gear;
				_0024shiftUp_00245482 = shiftUp;
				_0024self__00245483 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00245483.shiftingGear = true;
					_0024timer_00245477 = 0f;
					_0024pitchFactor_00245478 = 0f;
					_0024newPitch_00245479 = 0f;
					if (_0024shiftUp_00245482)
					{
						goto case 2;
					}
					goto case 3;
				case 2:
					if (_0024timer_00245477 < _0024self__00245483.gearShiftTime)
					{
						_0024pitchFactor_00245478 = Mathf.Lerp(_0024oldPitchFactor_00245480, 0f, _0024timer_00245477 / _0024self__00245483.gearShiftTime);
						if (_0024gear_00245481 == 0)
						{
							_0024newPitch_00245479 = Mathf.Lerp(_0024self__00245483.lowPitch, _0024self__00245483.highPitchFirst, _0024pitchFactor_00245478);
						}
						else
						{
							_0024newPitch_00245479 = Mathf.Lerp(_0024self__00245483.lowPitch, _0024self__00245483.highPitchSecond, _0024pitchFactor_00245478);
						}
						_0024self__00245483.SetPitch(_0024newPitch_00245479);
						_0024self__00245483.SetVolume(_0024newPitch_00245479);
						_0024timer_00245477 += Time.deltaTime;
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					goto IL_01d0;
				case 3:
					if (_0024timer_00245477 < _0024self__00245483.gearShiftTime)
					{
						_0024pitchFactor_00245478 = Mathf.Lerp(0f, 1f, _0024timer_00245477 / _0024self__00245483.gearShiftTime);
						_0024newPitch_00245479 = Mathf.Lerp(_0024self__00245483.lowPitch, _0024self__00245483.shiftPitch, _0024pitchFactor_00245478);
						_0024self__00245483.SetPitch(_0024newPitch_00245479);
						_0024self__00245483.SetVolume(_0024newPitch_00245479);
						_0024timer_00245477 += Time.deltaTime;
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					goto IL_01d0;
				case 1:
					{
						result = 0;
						break;
					}
					IL_01d0:
					_0024self__00245483.shiftingGear = false;
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal float _0024oldPitchFactor_00245484;

		internal int _0024gear_00245485;

		internal bool _0024shiftUp_00245486;

		internal SoundController _0024self__00245487;

		public _0024GearShift_00245476(float oldPitchFactor, int gear, bool shiftUp, SoundController self_)
		{
			_0024oldPitchFactor_00245484 = oldPitchFactor;
			_0024gear_00245485 = gear;
			_0024shiftUp_00245486 = shiftUp;
			_0024self__00245487 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024oldPitchFactor_00245484, _0024gear_00245485, _0024shiftUp_00245486, _0024self__00245487);
		}
	}

	[Serializable]
	internal sealed class _0024Crash_00245488 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal float _0024volumeFactor_00245489;

			internal SoundController _0024self__00245490;

			public _0024(float volumeFactor, SoundController self_)
			{
				_0024volumeFactor_00245489 = volumeFactor;
				_0024self__00245490 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__00245490.crashesStarted > 3 || _0024self__00245490.OneShotLimitReached())
					{
						goto case 1;
					}
					if (!(_0024volumeFactor_00245489 <= 0.9f))
					{
						_0024self__00245490.carAudio.PlayOneShot(_0024self__00245490.crashHighSpeedSound, Mathf.Clamp01((0.5f + _0024volumeFactor_00245489 * 0.5f) * _0024self__00245490.crashHighVolume));
					}
					_0024self__00245490.carAudio.PlayOneShot(_0024self__00245490.crashLowSpeedSound, Mathf.Clamp01(_0024volumeFactor_00245489 * _0024self__00245490.crashLowVolume));
					_0024self__00245490.crashesStarted++;
					result = (Yield(2, new WaitForSeconds(_0024self__00245490.crashTime)) ? 1 : 0);
					break;
				case 2:
					_0024self__00245490.crashesStarted--;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal float _0024volumeFactor_00245491;

		internal SoundController _0024self__00245492;

		public _0024Crash_00245488(float volumeFactor, SoundController self_)
		{
			_0024volumeFactor_00245491 = volumeFactor;
			_0024self__00245492 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024volumeFactor_00245491, _0024self__00245492);
		}
	}

	[Serializable]
	internal sealed class _0024ControlSound_00245493 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal float _0024timer_00245494;

			internal bool _0024play_00245495;

			internal float _0024fadeTime_00245496;

			internal SoundController _0024self__00245497;

			public _0024(bool play, float fadeTime, SoundController self_)
			{
				_0024play_00245495 = play;
				_0024fadeTime_00245496 = fadeTime;
				_0024self__00245497 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024timer_00245494 = 0f;
					if (_0024play_00245495 && !_0024self__00245497.tunnelAudio.isPlaying)
					{
						_0024self__00245497.tunnelAudio.volume = 0f;
						_0024self__00245497.tunnelAudio.Play();
						goto case 2;
					}
					if (!_0024play_00245495 && _0024self__00245497.tunnelAudio.isPlaying)
					{
						goto case 3;
					}
					goto IL_0160;
				case 2:
					if (_0024timer_00245494 < _0024fadeTime_00245496)
					{
						_0024self__00245497.tunnelAudio.volume = Mathf.Lerp(0f, _0024self__00245497.tunnelVolume, _0024timer_00245494 / _0024fadeTime_00245496);
						_0024timer_00245494 += Time.deltaTime;
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					goto IL_0160;
				case 3:
					if (_0024timer_00245494 < _0024fadeTime_00245496)
					{
						_0024self__00245497.tunnelAudio.volume = Mathf.Lerp(0f, _0024self__00245497.tunnelVolume, _0024timer_00245494 / _0024fadeTime_00245496);
						_0024timer_00245494 += Time.deltaTime;
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					_0024self__00245497.tunnelAudio.Stop();
					goto IL_0160;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0160:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal bool _0024play_00245498;

		internal float _0024fadeTime_00245499;

		internal SoundController _0024self__00245500;

		public _0024ControlSound_00245493(bool play, float fadeTime, SoundController self_)
		{
			_0024play_00245498 = play;
			_0024fadeTime_00245499 = fadeTime;
			_0024self__00245500 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024play_00245498, _0024fadeTime_00245499, _0024self__00245500);
		}
	}

	private Car car;

	public AudioClip D;

	public float DVolume;

	public AudioClip E;

	public float EVolume;

	public AudioClip F;

	public float FVolume;

	public AudioClip K;

	public float KVolume;

	public AudioClip L;

	public float LVolume;

	public AudioClip wind;

	public float windVolume;

	public AudioClip tunnelSound;

	public float tunnelVolume;

	public AudioClip crashLowSpeedSound;

	public float crashLowVolume;

	public AudioClip crashHighSpeedSound;

	public float crashHighVolume;

	public AudioClip skidSound;

	public AudioClip BackgroundMusic;

	public float BackgroundMusicVolume;

	private AudioSource DAudio;

	private AudioSource EAudio;

	private AudioSource FAudio;

	private AudioSource KAudio;

	private AudioSource LAudio;

	private AudioSource tunnelAudio;

	private AudioSource windAudio;

	private AudioSource skidAudio;

	private AudioSource carAudio;

	private AudioSource backgroundMusic;

	private float carMaxSpeed;

	private float gearShiftTime;

	private bool shiftingGear;

	private int gearShiftsStarted;

	private int crashesStarted;

	private float crashTime;

	private int oneShotLimit;

	private float idleFadeStartSpeed;

	private float idleFadeStopSpeed;

	private float idleFadeSpeedDiff;

	private float speedFadeStartSpeed;

	private float speedFadeStopSpeed;

	private float speedFadeSpeedDiff;

	private bool soundsSet;

	private float inputFactor;

	private int gear;

	private int topGear;

	private float idlePitch;

	private float startPitch;

	private float lowPitch;

	private float medPitch;

	private float highPitchFirst;

	private float highPitchSecond;

	private float highPitchThird;

	private float highPitchFourth;

	private float shiftPitch;

	private float prevPitchFactor;

	public SoundController()
	{
		DVolume = 1f;
		EVolume = 1f;
		FVolume = 1f;
		KVolume = 1f;
		LVolume = 1f;
		windVolume = 1f;
		tunnelVolume = 1f;
		crashLowVolume = 1f;
		crashHighVolume = 1f;
		BackgroundMusicVolume = 0.6f;
		carMaxSpeed = 55f;
		gearShiftTime = 0.1f;
		crashTime = 0.2f;
		oneShotLimit = 8;
		idleFadeStartSpeed = 3f;
		idleFadeStopSpeed = 10f;
		idleFadeSpeedDiff = 7f;
		speedFadeStopSpeed = 8f;
		speedFadeSpeedDiff = 8f;
		topGear = 6;
		idlePitch = 0.7f;
		startPitch = 0.85f;
		lowPitch = 1.17f;
		medPitch = 1.25f;
		highPitchFirst = 1.65f;
		highPitchSecond = 1.76f;
		highPitchThird = 1.8f;
		highPitchFourth = 1.86f;
		shiftPitch = 1.44f;
	}

	public virtual void Awake()
	{
		car = (Car)transform.GetComponent(typeof(Car));
		DVolume *= 0.4f;
		EVolume *= 0.4f;
		FVolume *= 0.4f;
		KVolume *= 0.7f;
		LVolume *= 0.4f;
		windVolume *= 0.4f;
		DAudio = (AudioSource)gameObject.AddComponent(typeof(AudioSource));
		DAudio.loop = true;
		DAudio.playOnAwake = true;
		DAudio.clip = D;
		DAudio.volume = DVolume;
		EAudio = (AudioSource)gameObject.AddComponent(typeof(AudioSource));
		EAudio.loop = true;
		EAudio.playOnAwake = true;
		EAudio.clip = E;
		EAudio.volume = EVolume;
		FAudio = (AudioSource)gameObject.AddComponent(typeof(AudioSource));
		FAudio.loop = true;
		FAudio.playOnAwake = true;
		FAudio.clip = F;
		FAudio.volume = FVolume;
		KAudio = (AudioSource)gameObject.AddComponent(typeof(AudioSource));
		KAudio.loop = true;
		KAudio.playOnAwake = true;
		KAudio.clip = K;
		KAudio.volume = KVolume;
		LAudio = (AudioSource)gameObject.AddComponent(typeof(AudioSource));
		LAudio.loop = true;
		LAudio.playOnAwake = true;
		LAudio.clip = L;
		LAudio.volume = LVolume;
		windAudio = (AudioSource)gameObject.AddComponent(typeof(AudioSource));
		windAudio.loop = true;
		windAudio.playOnAwake = true;
		windAudio.clip = wind;
		windAudio.volume = windVolume;
		tunnelAudio = (AudioSource)gameObject.AddComponent(typeof(AudioSource));
		tunnelAudio.loop = true;
		tunnelAudio.playOnAwake = false;
		tunnelAudio.clip = tunnelSound;
		tunnelAudio.volume = tunnelVolume;
		skidAudio = (AudioSource)gameObject.AddComponent(typeof(AudioSource));
		skidAudio.loop = true;
		skidAudio.playOnAwake = true;
		skidAudio.clip = skidSound;
		skidAudio.volume = 0f;
		carAudio = (AudioSource)gameObject.AddComponent(typeof(AudioSource));
		carAudio.loop = false;
		carAudio.playOnAwake = false;
		carAudio.Stop();
		crashTime = Mathf.Max(crashLowSpeedSound.length, crashHighSpeedSound.length);
		soundsSet = false;
		idleFadeSpeedDiff = idleFadeStopSpeed - idleFadeStartSpeed;
		speedFadeSpeedDiff = speedFadeStopSpeed - speedFadeStartSpeed;
		backgroundMusic = (AudioSource)gameObject.AddComponent(typeof(AudioSource));
		backgroundMusic.loop = true;
		backgroundMusic.playOnAwake = true;
		backgroundMusic.clip = BackgroundMusic;
		backgroundMusic.volume = BackgroundMusicVolume;
	}

	public virtual void Update()
	{
		float magnitude = car.rigidbody.velocity.magnitude;
		float num = Mathf.Clamp01(magnitude / car.topSpeed);
		KAudio.volume = Mathf.Lerp(0f, KVolume, num);
		windAudio.volume = Mathf.Lerp(0f, windVolume, num * 2f);
		if (shiftingGear)
		{
			return;
		}
		float num2 = Sinerp(0f, topGear, num);
		int num3 = (int)num2;
		num2 -= (float)num3;
		float num4 = num2;
		num2 *= 0.3f;
		num2 += num4 * 0.7f * Mathf.Clamp01(car.throttle * 2f);
		if (num3 != gear)
		{
			if (num3 > gear)
			{
				StartCoroutine_Auto(GearShift(prevPitchFactor, num2, gear, true));
			}
			else
			{
				StartCoroutine_Auto(GearShift(prevPitchFactor, num2, gear, false));
			}
			gear = num3;
		}
		else
		{
			float num5 = 0f;
			num5 = ((gear == 0) ? Mathf.Lerp(idlePitch, highPitchFirst, num2) : ((gear == 1) ? Mathf.Lerp(startPitch, highPitchSecond, num2) : ((gear != 2) ? Mathf.Lerp(medPitch, highPitchFourth, num2) : Mathf.Lerp(lowPitch, highPitchThird, num2))));
			SetPitch(num5);
			SetVolume(num5);
		}
		prevPitchFactor = num2;
	}

	public virtual float Coserp(float start, float end, float value)
	{
		return Mathf.Lerp(start, end, 1f - Mathf.Cos(value * (float)Math.PI * 0.5f));
	}

	public virtual float Sinerp(float start, float end, float value)
	{
		return Mathf.Lerp(start, end, Mathf.Sin(value * (float)Math.PI * 0.5f));
	}

	public virtual void SetPitch(float pitch)
	{
		DAudio.pitch = pitch;
		EAudio.pitch = pitch;
		FAudio.pitch = pitch;
		LAudio.pitch = pitch;
		tunnelAudio.pitch = pitch;
	}

	public virtual void SetVolume(float pitch)
	{
		float t = Mathf.Lerp(0f, 1f, (pitch - startPitch) / (highPitchSecond - startPitch));
		DAudio.volume = Mathf.Lerp(0f, DVolume, t);
		float num = Mathf.Lerp(FVolume * 0.8f, FVolume, t);
		FAudio.volume = num * 0.7f + num * 0.3f * Mathf.Clamp01(car.throttle);
		float num2 = Mathf.Lerp(EVolume * 0.89f, EVolume, t);
		EAudio.volume = num2 * 0.8f + num2 * 0.2f * Mathf.Clamp01(car.throttle);
	}

	public virtual IEnumerator GearShift(float oldPitchFactor, float newPitchFactor, int gear, bool shiftUp)
	{
		return new _0024GearShift_00245476(oldPitchFactor, gear, shiftUp, this).GetEnumerator();
	}

	public virtual void Skid(bool play, float volumeFactor)
	{
		if ((bool)skidAudio)
		{
			if (play)
			{
				skidAudio.volume = Mathf.Clamp01(volumeFactor + 0.3f);
			}
			else
			{
				skidAudio.volume = 0f;
			}
		}
	}

	public virtual IEnumerator Crash(float volumeFactor)
	{
		return new _0024Crash_00245488(volumeFactor, this).GetEnumerator();
	}

	public virtual bool OneShotLimitReached()
	{
		return crashesStarted + gearShiftsStarted > oneShotLimit;
	}

	public virtual void OnTriggerEnter(Collider coll)
	{
		SoundToggler soundToggler = (SoundToggler)coll.transform.GetComponent(typeof(SoundToggler));
		if ((bool)soundToggler)
		{
			StartCoroutine_Auto(ControlSound(true, soundToggler.fadeTime));
		}
	}

	public virtual void OnTriggerExit(Collider coll)
	{
		SoundToggler soundToggler = (SoundToggler)coll.transform.GetComponent(typeof(SoundToggler));
		if ((bool)soundToggler)
		{
			StartCoroutine_Auto(ControlSound(false, soundToggler.fadeTime));
		}
	}

	public virtual IEnumerator ControlSound(bool play, float fadeTime)
	{
		return new _0024ControlSound_00245493(play, fadeTime, this).GetEnumerator();
	}

	public virtual void Main()
	{
	}
}
