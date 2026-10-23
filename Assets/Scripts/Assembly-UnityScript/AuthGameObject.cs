using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using Photon;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class AuthGameObject : Photon.MonoBehaviour
{
	[Serializable]
	internal sealed class _0024fadeInGameMode_00243207 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal string _0024s_00243208;

			internal AuthGameObject _0024self__00243209;

			public _0024(string s, AuthGameObject self_)
			{
				_0024s_00243208 = s;
				_0024self__00243209 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00243209.gameModeText = _0024s_00243208;
					goto case 2;
				case 2:
					if (_0024self__00243209.gametypealpha < 1f)
					{
						_0024self__00243209.gametypealpha = Mathf.Min(1f, _0024self__00243209.gametypealpha + Time.deltaTime * 4f);
						result = (YieldDefault(2) ? 1 : 0);
					}
					else
					{
						result = (Yield(3, new WaitForSeconds(12f)) ? 1 : 0);
					}
					break;
				case 3:
				case 4:
					if (_0024self__00243209.gametypealpha > 0f)
					{
						_0024self__00243209.gametypealpha = Mathf.Max(0f, _0024self__00243209.gametypealpha - Time.deltaTime * 4f);
						result = (YieldDefault(4) ? 1 : 0);
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

		internal string _0024s_00243210;

		internal AuthGameObject _0024self__00243211;

		public _0024fadeInGameMode_00243207(string s, AuthGameObject self_)
		{
			_0024s_00243210 = s;
			_0024self__00243211 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024s_00243210, _0024self__00243211);
		}
	}

	[Serializable]
	internal sealed class _0024displayAlert_00243212 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal string _0024m_00243213;

			internal AuthGameObject _0024self__00243214;

			public _0024(string m, AuthGameObject self_)
			{
				_0024m_00243213 = m;
				_0024self__00243214 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00243214.alertText = _0024m_00243213;
					goto case 2;
				case 2:
					if (_0024self__00243214.alertAlpha < 1f)
					{
						_0024self__00243214.alertAlpha += 4f * Time.deltaTime;
						if (!(_0024self__00243214.alertAlpha <= 1f))
						{
							_0024self__00243214.alertAlpha = 1f;
						}
						result = (YieldDefault(2) ? 1 : 0);
					}
					else
					{
						result = (Yield(3, new WaitForSeconds(8f)) ? 1 : 0);
					}
					break;
				case 3:
				case 4:
					if (_0024self__00243214.alertAlpha > 0f)
					{
						_0024self__00243214.alertAlpha -= 4f * Time.deltaTime;
						if (!(_0024self__00243214.alertAlpha >= 0f))
						{
							_0024self__00243214.alertAlpha = 0f;
						}
						result = (YieldDefault(4) ? 1 : 0);
						break;
					}
					_0024self__00243214.alertText = string.Empty;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal string _0024m_00243215;

		internal AuthGameObject _0024self__00243216;

		public _0024displayAlert_00243212(string m, AuthGameObject self_)
		{
			_0024m_00243215 = m;
			_0024self__00243216 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024m_00243215, _0024self__00243216);
		}
	}

	[Serializable]
	internal sealed class _0024gotAch_00243217 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal int _0024i_00243218;

			internal string _0024ss_00243219;

			internal string _0024d_00243220;

			internal string _0024a_00243221;

			internal IEnumerator _0024_0024iterator_0024235_00243222;

			internal WWWForm _0024form_00243223;

			internal WWW _0024w_00243224;

			internal WWW _0024getKey_00243225;

			internal string[] _0024goldarr_00243226;

			internal WWW _0024bitem_00243227;

			internal string _0024temphash_00243228;

			internal string[] _0024hashgold_00243229;

			internal bool _0024firstone_00243230;

			internal string _0024str_00243231;

			internal string _0024finalhash_00243232;

			internal int _0024_0024408_00243233;

			internal string[] _0024_0024409_00243234;

			internal int _0024_0024410_00243235;

			internal int _0024_0024412_00243236;

			internal string[] _0024_0024413_00243237;

			internal int _0024_0024414_00243238;

			internal string _0024iv_00243239;

			internal AuthGameObject _0024self__00243240;

			public _0024(string iv, AuthGameObject self_)
			{
				_0024iv_00243239 = iv;
				_0024self__00243240 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024i_00243218 = 0;
					_0024_0024408_00243233 = 0;
					_0024_0024409_00243234 = _0024self__00243240.ach;
					_0024_0024410_00243235 = _0024_0024409_00243234.Length;
					while (_0024_0024408_00243233 < _0024_0024410_00243235 && !(_0024_0024409_00243234[_0024_0024408_00243233] == _0024iv_00243239))
					{
						_0024i_00243218++;
						_0024_0024408_00243233++;
					}
					if (shop && !RuntimeServices.EqualityOperator(achGot[_0024i_00243218], "1"))
					{
						achGot[_0024i_00243218] = "1";
						_0024d_00243220 = string.Empty;
						_0024_0024iterator_0024235_00243222 = UnityRuntimeServices.GetEnumerator(achGot);
						while (_0024_0024iterator_0024235_00243222.MoveNext())
						{
							object obj = _0024_0024iterator_0024235_00243222.Current;
							if (!(obj is string))
							{
								obj = RuntimeServices.Coerce(obj, typeof(string));
							}
							_0024a_00243221 = (string)obj;
							_0024d_00243220 = _0024d_00243220 + ((!(_0024d_00243220 != string.Empty)) ? string.Empty : "|") + _0024a_00243221;
							UnityRuntimeServices.Update(_0024_0024iterator_0024235_00243222, _0024a_00243221);
						}
						_0024form_00243223 = new WWWForm();
						_0024form_00243223.AddField("username", username);
						_0024form_00243223.AddField("key", Md5Sum.ComputeMd5(username + global::DontDestroyOnLoad.hitcollider));
						_0024form_00243223.AddField("data", _0024d_00243220);
						_0024w_00243224 = new WWW("http://72.14.184.180/achInterface.php", _0024form_00243223);
						result = (Yield(2, _0024w_00243224) ? 1 : 0);
						break;
					}
					goto IL_08f1;
				case 2:
					if (!RuntimeServices.EqualityOperator(UnityRuntimeServices.GetProperty(_0024w_00243224.text, "error"), null) || !_0024w_00243224.text.Contains("Done"))
					{
						_0024w_00243224 = new WWW("http://72.14.184.180/achInterface.php", _0024form_00243223);
						result = (Yield(3, _0024w_00243224) ? 1 : 0);
						break;
					}
					goto case 3;
				case 3:
					Debug.Log(_0024w_00243224.text);
					if (_0024w_00243224.text.Contains("Done"))
					{
						_0024self__00243240.alertText = _0024self__00243240.ach[_0024i_00243218] + " - " + _0024self__00243240.achDesc[_0024i_00243218] + " (+50 credits)";
						goto case 4;
					}
					goto IL_08f1;
				case 4:
					if (_0024self__00243240.alertAlpha < 1f)
					{
						_0024self__00243240.alertAlpha += 4f * Time.deltaTime;
						if (!(_0024self__00243240.alertAlpha <= 1f))
						{
							_0024self__00243240.alertAlpha = 1f;
						}
						result = (YieldDefault(4) ? 1 : 0);
					}
					else
					{
						result = (Yield(5, new WaitForSeconds(8f)) ? 1 : 0);
					}
					break;
				case 5:
				case 6:
					if (_0024self__00243240.alertAlpha > 0f)
					{
						_0024self__00243240.alertAlpha -= 4f * Time.deltaTime;
						if (!(_0024self__00243240.alertAlpha >= 0f))
						{
							_0024self__00243240.alertAlpha = 0f;
						}
						result = (YieldDefault(6) ? 1 : 0);
					}
					else
					{
						_0024self__00243240.alertText = string.Empty;
						_0024getKey_00243225 = new WWW("http://72.14.184.180/serverKeyGen.php?username=" + Md5Sum.ComputeMd5(username + global::DontDestroyOnLoad.hitcollider));
						result = (Yield(7, _0024getKey_00243225) ? 1 : 0);
					}
					break;
				case 7:
					_0024goldarr_00243226 = inventory[2].Split("#"[0]);
					_0024bitem_00243227 = new WWW("http://72.14.184.180/storeInterface.php?username=" + username + "&request=addcreds" + "&serverkey=" + Md5Sum.ComputeMd5(_0024getKey_00243225.text + global::DontDestroyOnLoad.hitcollider) + "&changeto=" + "50");
					result = (Yield(8, _0024bitem_00243227) ? 1 : 0);
					break;
				case 8:
					if (string.IsNullOrEmpty(_0024bitem_00243227.error) && _0024bitem_00243227.text.Contains("updated"))
					{
						inventory[2] = (UnityBuiltins.parseInt(_0024self__00243240.returnGold()) + 50).ToString() + "#" + _0024goldarr_00243226[1] + "#" + _0024goldarr_00243226[2] + "#" + _0024goldarr_00243226[3] + "#" + _0024goldarr_00243226[4] + "#" + LoginWindow.curday + "#" + _0024goldarr_00243226[6];
						_0024temphash_00243228 = string.Empty;
						_0024hashgold_00243229 = inventory[2].Split("#"[0]);
						for (_0024i_00243218 = 0; _0024i_00243218 < UnityScript.Lang.Extensions.get_length(_0024hashgold_00243229[0]); _0024i_00243218++)
						{
							if (_0024hashgold_00243229[0].Substring(_0024i_00243218, 1) == "0")
							{
								_0024temphash_00243228 += "a";
							}
							if (_0024hashgold_00243229[0].Substring(_0024i_00243218, 1) == "1")
							{
								_0024temphash_00243228 += "b";
							}
							if (_0024hashgold_00243229[0].Substring(_0024i_00243218, 1) == "2")
							{
								_0024temphash_00243228 += "c";
							}
							if (_0024hashgold_00243229[0].Substring(_0024i_00243218, 1) == "3")
							{
								_0024temphash_00243228 += "d";
							}
							if (_0024hashgold_00243229[0].Substring(_0024i_00243218, 1) == "4")
							{
								_0024temphash_00243228 += "e";
							}
							if (_0024hashgold_00243229[0].Substring(_0024i_00243218, 1) == "5")
							{
								_0024temphash_00243228 += "f";
							}
							if (_0024hashgold_00243229[0].Substring(_0024i_00243218, 1) == "6")
							{
								_0024temphash_00243228 += "g";
							}
							if (_0024hashgold_00243229[0].Substring(_0024i_00243218, 1) == "7")
							{
								_0024temphash_00243228 += "h";
							}
							if (_0024hashgold_00243229[0].Substring(_0024i_00243218, 1) == "8")
							{
								_0024temphash_00243228 += "i";
							}
							if (_0024hashgold_00243229[0].Substring(_0024i_00243218, 1) == "9")
							{
								_0024temphash_00243228 += "j";
							}
						}
						_0024hashgold_00243229[0] = _0024temphash_00243228;
						_0024firstone_00243230 = true;
						_0024_0024412_00243236 = 0;
						_0024_0024413_00243237 = _0024hashgold_00243229;
						for (_0024_0024414_00243238 = _0024_0024413_00243237.Length; _0024_0024412_00243236 < _0024_0024414_00243238; _0024_0024412_00243236++)
						{
							if (_0024firstone_00243230)
							{
								_0024finalhash_00243232 = _0024_0024413_00243237[_0024_0024412_00243236];
								_0024firstone_00243230 = false;
							}
							else
							{
								_0024finalhash_00243232 = _0024finalhash_00243232 + "#" + _0024_0024413_00243237[_0024_0024412_00243236];
							}
						}
						inventory[2] = _0024finalhash_00243232;
					}
					goto IL_08f1;
				case 1:
					{
						result = 0;
						break;
					}
					IL_08f1:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal string _0024iv_00243241;

		internal AuthGameObject _0024self__00243242;

		public _0024gotAch_00243217(string iv, AuthGameObject self_)
		{
			_0024iv_00243241 = iv;
			_0024self__00243242 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024iv_00243241, _0024self__00243242);
		}
	}

	[Serializable]
	internal sealed class _0024fadeV_00243243 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal AuthGameObject _0024self__00243244;

			public _0024(AuthGameObject self_)
			{
				_0024self__00243244 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__00243244.alphav < 1f)
					{
						_0024self__00243244.alphav = Mathf.Min(1f, _0024self__00243244.alphav + 4f * Time.deltaTime);
						result = (YieldDefault(2) ? 1 : 0);
					}
					else
					{
						result = (Yield(3, new WaitForSeconds(4f)) ? 1 : 0);
					}
					break;
				case 3:
				case 4:
					if (_0024self__00243244.alphav > 0f)
					{
						_0024self__00243244.alphav = Mathf.Max(0f, _0024self__00243244.alphav - 4f * Time.deltaTime);
						result = (YieldDefault(4) ? 1 : 0);
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

		internal AuthGameObject _0024self__00243245;

		public _0024fadeV_00243243(AuthGameObject self_)
		{
			_0024self__00243245 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00243245);
		}
	}

	[Serializable]
	internal sealed class _0024fadeI_00243246 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal AuthGameObject _0024self__00243247;

			public _0024(AuthGameObject self_)
			{
				_0024self__00243247 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__00243247.alphai < 1f)
					{
						_0024self__00243247.alphai = Mathf.Min(1f, _0024self__00243247.alphai + 4f * Time.deltaTime);
						result = (YieldDefault(2) ? 1 : 0);
					}
					else
					{
						result = (Yield(3, new WaitForSeconds(4f)) ? 1 : 0);
					}
					break;
				case 3:
				case 4:
					if (_0024self__00243247.alphai > 0f)
					{
						_0024self__00243247.alphai = Mathf.Max(0f, _0024self__00243247.alphai - 4f * Time.deltaTime);
						result = (YieldDefault(4) ? 1 : 0);
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

		internal AuthGameObject _0024self__00243248;

		public _0024fadeI_00243246(AuthGameObject self_)
		{
			_0024self__00243248 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00243248);
		}
	}

	[Serializable]
	internal sealed class _0024sendStat_00243249 : GenericGenerator<WWW>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WWW>, IEnumerator
		{
			internal string _0024statType_00243250;

			internal int _0024randomnumber_00243251;

			internal WWW _0024stat_00243252;

			internal string _0024sName_00243253;

			internal float _0024sAmount_00243254;

			internal int _0024t_00243255;

			internal AuthGameObject _0024self__00243256;

			public _0024(string sName, float sAmount, int t, AuthGameObject self_)
			{
				_0024sName_00243253 = sName;
				_0024sAmount_00243254 = sAmount;
				_0024t_00243255 = t;
				_0024self__00243256 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024statType_00243250 = string.Empty;
					if (_0024t_00243255 == 0)
					{
						_0024statType_00243250 = "addStat";
					}
					else if (_0024t_00243255 == 1)
					{
						_0024statType_00243250 = "avgStat";
					}
					else if (_0024t_00243255 == 2)
					{
						_0024statType_00243250 = "mostStat";
					}
					else if (_0024t_00243255 == 3)
					{
						_0024statType_00243250 = "leastStat";
					}
					_0024randomnumber_00243251 = UnityEngine.Random.Range(0, 99999);
					_0024stat_00243252 = new WWW("http://72.14.184.180/rankingsManager.php?request=" + _0024statType_00243250 + "&key=" + Md5Sum.ComputeMd5(global::DontDestroyOnLoad.hitcollider + _0024randomnumber_00243251.ToString()) + "&random=" + _0024randomnumber_00243251.ToString() + "&user=" + username + "&stat=" + _0024sName_00243253 + "&num=" + _0024sAmount_00243254);
					result = (Yield(2, _0024stat_00243252) ? 1 : 0);
					break;
				case 2:
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal string _0024sName_00243257;

		internal float _0024sAmount_00243258;

		internal int _0024t_00243259;

		internal AuthGameObject _0024self__00243260;

		public _0024sendStat_00243249(string sName, float sAmount, int t, AuthGameObject self_)
		{
			_0024sName_00243257 = sName;
			_0024sAmount_00243258 = sAmount;
			_0024t_00243259 = t;
			_0024self__00243260 = self_;
		}

		public override IEnumerator<WWW> GetEnumerator()
		{
			return new _0024(_0024sName_00243257, _0024sAmount_00243258, _0024t_00243259, _0024self__00243260);
		}
	}

	[Serializable]
	internal sealed class _0024sendStat_00243261 : GenericGenerator<WWW>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WWW>, IEnumerator
		{
			internal string _0024statType_00243262;

			internal int _0024randomnumber_00243263;

			internal WWW _0024stat_00243264;

			internal string _0024sName_00243265;

			internal int _0024sAmount_00243266;

			internal int _0024t_00243267;

			internal AuthGameObject _0024self__00243268;

			public _0024(string sName, int sAmount, int t, AuthGameObject self_)
			{
				_0024sName_00243265 = sName;
				_0024sAmount_00243266 = sAmount;
				_0024t_00243267 = t;
				_0024self__00243268 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024statType_00243262 = string.Empty;
					if (_0024t_00243267 == 0)
					{
						_0024statType_00243262 = "addStat";
					}
					else if (_0024t_00243267 == 1)
					{
						_0024statType_00243262 = "avgStat";
					}
					else if (_0024t_00243267 == 2)
					{
						_0024statType_00243262 = "mostStat";
					}
					else if (_0024t_00243267 == 3)
					{
						_0024statType_00243262 = "leastStat";
					}
					_0024randomnumber_00243263 = UnityEngine.Random.Range(0, 99999);
					_0024stat_00243264 = new WWW("http://72.14.184.180/rankingsManager.php?request=" + _0024statType_00243262 + "&key=" + Md5Sum.ComputeMd5(global::DontDestroyOnLoad.hitcollider + _0024randomnumber_00243263.ToString()) + "&random=" + _0024randomnumber_00243263.ToString() + "&user=" + username + "&stat=" + _0024sName_00243265 + "&num=" + _0024sAmount_00243266);
					result = (Yield(2, _0024stat_00243264) ? 1 : 0);
					break;
				case 2:
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal string _0024sName_00243269;

		internal int _0024sAmount_00243270;

		internal int _0024t_00243271;

		internal AuthGameObject _0024self__00243272;

		public _0024sendStat_00243261(string sName, int sAmount, int t, AuthGameObject self_)
		{
			_0024sName_00243269 = sName;
			_0024sAmount_00243270 = sAmount;
			_0024t_00243271 = t;
			_0024self__00243272 = self_;
		}

		public override IEnumerator<WWW> GetEnumerator()
		{
			return new _0024(_0024sName_00243269, _0024sAmount_00243270, _0024t_00243271, _0024self__00243272);
		}
	}

	[Serializable]
	internal sealed class _0024grabAch_00243273 : GenericGenerator<WWW>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WWW>, IEnumerator
		{
			internal WWWForm _0024form_00243274;

			internal WWW _0024w_00243275;

			internal int _0024c_00243276;

			internal AuthGameObject _0024self__00243277;

			public _0024(AuthGameObject self_)
			{
				_0024self__00243277 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					result = (YieldDefault(2) ? 1 : 0);
					break;
				case 2:
					if (!username.Contains("guest_"))
					{
						_0024form_00243274 = new WWWForm();
						_0024form_00243274.AddField("username", username);
						_0024form_00243274.AddField("key", Md5Sum.ComputeMd5(username + global::DontDestroyOnLoad.hitcollider));
						_0024w_00243275 = new WWW("http://72.14.184.180/achInterface.php", _0024form_00243274);
						result = (Yield(3, _0024w_00243275) ? 1 : 0);
						break;
					}
					goto IL_01e7;
				case 3:
					if (_0024w_00243275.error == null && _0024w_00243275.text != string.Empty && _0024w_00243275.text.Contains("|"))
					{
						achGot.Clear();
						for (_0024c_00243276 = 0; _0024c_00243276 < UnityScript.Lang.Extensions.get_length((System.Array)_0024self__00243277.ach); _0024c_00243276++)
						{
							if (_0024c_00243276 < UnityScript.Lang.Extensions.get_length((System.Array)_0024w_00243275.text.Split("|"[0])))
							{
								if (_0024w_00243275.text.Split("|"[0])[_0024c_00243276] != "Done")
								{
									achGot.Add(_0024w_00243275.text.Split("|"[0])[_0024c_00243276]);
								}
							}
							else
							{
								achGot.Add("0");
							}
						}
					}
					goto IL_01e7;
				case 1:
					{
						result = 0;
						break;
					}
					IL_01e7:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal AuthGameObject _0024self__00243278;

		public _0024grabAch_00243273(AuthGameObject self_)
		{
			_0024self__00243278 = self_;
		}

		public override IEnumerator<WWW> GetEnumerator()
		{
			return new _0024(_0024self__00243278);
		}
	}

	[Serializable]
	internal sealed class _0024startTutorial_00243279 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal bool _0024noAch_00243280;

			internal int _0024counter_00243281;

			internal string _0024ach_00243282;

			internal IEnumerator _0024_0024iterator_0024236_00243283;

			internal int _0024curInt_00243284;

			internal AuthGameObject _0024self__00243285;

			public _0024(AuthGameObject self_)
			{
				_0024self__00243285 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					result = (((!(SpawningScript.team2 == string.Empty)) ? Yield(3, new WaitForSeconds(5f)) : YieldDefault(2)) ? 1 : 0);
					break;
				case 3:
					if (!PlayerPrefs.HasKey("tutorial"))
					{
						PlayerPrefs.SetInt("tutorial", 0);
						_0024noAch_00243280 = true;
						_0024counter_00243281 = 0;
						_0024_0024iterator_0024236_00243283 = UnityRuntimeServices.GetEnumerator(achGot);
						while (_0024_0024iterator_0024236_00243283.MoveNext())
						{
							object obj = _0024_0024iterator_0024236_00243283.Current;
							if (!(obj is string))
							{
								obj = RuntimeServices.Coerce(obj, typeof(string));
							}
							_0024ach_00243282 = (string)obj;
							if (_0024ach_00243282 == "1" && _0024counter_00243281 != 0 && _0024counter_00243281 != 2)
							{
								_0024noAch_00243280 = false;
							}
							_0024counter_00243281++;
						}
						if (_0024noAch_00243280)
						{
							_0024curInt_00243284 = 0;
							goto case 4;
						}
						goto IL_019b;
					}
					goto case 1;
				case 4:
					if (_0024curInt_00243284 < UnityScript.Lang.Extensions.get_length((System.Array)_0024self__00243285.tutorialList))
					{
						GameObject.Find("/GUI/SubMessage").SendMessage("setMessageTut", _0024self__00243285.tutorialList[_0024curInt_00243284]);
						_0024curInt_00243284++;
						result = (Yield(4, new WaitForSeconds(10.5f)) ? 1 : 0);
						break;
					}
					goto IL_019b;
				case 1:
					{
						result = 0;
						break;
					}
					IL_019b:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal AuthGameObject _0024self__00243286;

		public _0024startTutorial_00243279(AuthGameObject self_)
		{
			_0024self__00243286 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00243286);
		}
	}

	[Serializable]
	internal sealed class _0024startEvict_00243287 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal AuthGameObject _0024self__00243288;

			public _0024(AuthGameObject self_)
			{
				_0024self__00243288 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					result = (Yield(2, new WaitForSeconds(5f)) ? 1 : 0);
					break;
				case 2:
					_0024self__00243288.checkAgain = true;
					result = (Yield(3, new WaitForSeconds(3f)) ? 1 : 0);
					break;
				case 3:
					_0024self__00243288.checkAgain = false;
					_0024self__00243288.gotError = false;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal AuthGameObject _0024self__00243289;

		public _0024startEvict_00243287(AuthGameObject self_)
		{
			_0024self__00243289 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00243289);
		}
	}

	[Serializable]
	internal sealed class _0024fadeDC_00243290 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal AuthGameObject _0024self__00243291;

			public _0024(AuthGameObject self_)
			{
				_0024self__00243291 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					Debug.LogError("We lost connection to the server (showed the player the disconnect message)");
					goto case 2;
				case 2:
					if (_0024self__00243291.alphadc < 1f)
					{
						_0024self__00243291.alphadc += 4f * Time.deltaTime;
						result = (YieldDefault(2) ? 1 : 0);
					}
					else
					{
						_0024self__00243291.alphadc = 1f;
						result = (Yield(3, new WaitForSeconds(8.5f)) ? 1 : 0);
					}
					break;
				case 3:
				case 4:
					if (_0024self__00243291.alphadc > 0f)
					{
						_0024self__00243291.alphadc -= 4f * Time.deltaTime;
						result = (YieldDefault(4) ? 1 : 0);
						break;
					}
					_0024self__00243291.alphadc = 0f;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal AuthGameObject _0024self__00243292;

		public _0024fadeDC_00243290(AuthGameObject self_)
		{
			_0024self__00243292 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00243292);
		}
	}

	[Serializable]
	internal sealed class _0024fadeEvict_00243293 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal AuthGameObject _0024self__00243294;

			public _0024(AuthGameObject self_)
			{
				_0024self__00243294 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__00243294.alpha < 1f)
					{
						_0024self__00243294.alpha += 4f * Time.deltaTime;
						result = (YieldDefault(2) ? 1 : 0);
					}
					else
					{
						_0024self__00243294.alpha = 1f;
						result = (Yield(3, new WaitForSeconds(8.5f)) ? 1 : 0);
					}
					break;
				case 3:
				case 4:
					if (_0024self__00243294.alpha > 0f)
					{
						_0024self__00243294.alpha -= 4f * Time.deltaTime;
						result = (YieldDefault(4) ? 1 : 0);
						break;
					}
					_0024self__00243294.alpha = 0f;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal AuthGameObject _0024self__00243295;

		public _0024fadeEvict_00243293(AuthGameObject self_)
		{
			_0024self__00243295 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00243295);
		}
	}

	[Serializable]
	internal sealed class _0024endGameAPI_00243296 : GenericGenerator<WWW>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WWW>, IEnumerator
		{
			internal WWWForm _0024post_00243297;

			internal WWW _0024www_00243298;

			internal int _0024reasonId_00243299;

			internal AuthGameObject _0024self__00243300;

			public _0024(int reasonId, AuthGameObject self_)
			{
				_0024reasonId_00243299 = reasonId;
				_0024self__00243300 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024post_00243297 = new WWWForm();
					_0024post_00243297.AddField("action", "endGame");
					_0024post_00243297.AddField("auditId", PreloaderExplosion.auditId);
					_0024post_00243297.AddField("hashKey", PreloaderExplosion.hashKey);
					_0024post_00243297.AddField("loserId", (!PreloaderExplosion.wonGame) ? PreloaderExplosion.myId : PreloaderExplosion.otherId);
					_0024post_00243297.AddField("winnerId", (!PreloaderExplosion.wonGame) ? PreloaderExplosion.otherId : PreloaderExplosion.myId);
					_0024post_00243297.AddField("reasonId", _0024reasonId_00243299);
					Debug.Log("Sending endGame call to server with fields: auditId=" + PreloaderExplosion.auditId + " hashKey=" + PreloaderExplosion.hashKey + " loserId=" + ((!PreloaderExplosion.wonGame) ? PreloaderExplosion.myId : PreloaderExplosion.otherId) + " winnerId=" + ((!PreloaderExplosion.wonGame) ? PreloaderExplosion.otherId : PreloaderExplosion.myId) + " reasonId=" + _0024reasonId_00243299);
					_0024www_00243298 = new WWW("http://www.playsmart123.appspot.com/playsmartAppEngine/relay", _0024post_00243297);
					result = (Yield(2, _0024www_00243298) ? 1 : 0);
					break;
				case 2:
					Debug.Log("Recieved text from request: " + _0024www_00243298.text);
					if (_0024www_00243298.text == "1" && string.IsNullOrEmpty(_0024www_00243298.error))
					{
						Debug.Log("endGame API message successfully sent to server!");
					}
					else
					{
						Debug.Log("API message failed!");
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

		internal int _0024reasonId_00243301;

		internal AuthGameObject _0024self__00243302;

		public _0024endGameAPI_00243296(int reasonId, AuthGameObject self_)
		{
			_0024reasonId_00243301 = reasonId;
			_0024self__00243302 = self_;
		}

		public override IEnumerator<WWW> GetEnumerator()
		{
			return new _0024(_0024reasonId_00243301, _0024self__00243302);
		}
	}

	[NonSerialized]
	public static string username = string.Empty;

	[NonSerialized]
	public static string hostusername = string.Empty;

	[NonSerialized]
	public static bool shop;

	[NonSerialized]
	public static bool shopfailed;

	[NonSerialized]
	public static string[] inventory;

	[NonSerialized]
	public static string[] rentarr;

	[NonSerialized]
	public static int weatherindex;

	[NonSerialized]
	public static bool nextGameJoinBot;

	[NonSerialized]
	public static string whirldurl = string.Empty;

	[NonSerialized]
	public static string whirldmmurl = string.Empty;

	[NonSerialized]
	public static string whirldname = string.Empty;

	[NonSerialized]
	public static int maxplayers;

	[NonSerialized]
	public static int timelimit;

	[NonSerialized]
	public static string gametype;

	public Material[] skyboxes;

	public Color[] fogcolors;

	public UnityScript.Lang.Array fogdensity;

	public Flare[] flares;

	public Material[] skyboxes2;

	public Color[] fogcolors2;

	public UnityScript.Lang.Array fogdensity2;

	public Flare[] flares2;

	public Material[] skyboxes3;

	public Color[] fogcolors3;

	public UnityScript.Lang.Array fogdensity3;

	public Flare[] flares3;

	public Material[] skyboxes4;

	public Color[] fogcolors4;

	public UnityScript.Lang.Array fogdensity4;

	public Flare[] flares4;

	public Material[] skyboxes5;

	public Color[] fogcolors5;

	public UnityScript.Lang.Array fogdensity5;

	public Flare[] flares5;

	[NonSerialized]
	public static int skyboxindex;

	private bool stopsetting;

	private string cachename;

	private string cacheurl;

	[NonSerialized]
	public static bool isAIserver;

	[NonSerialized]
	public static bool ff = true;

	[NonSerialized]
	public static bool fpsenabled = true;

	[NonSerialized]
	public static bool cDam = true;

	[NonSerialized]
	public static bool wasevicted;

	[NonSerialized]
	public static bool wasdc;

	public GUIStyle evictStyle;

	public GUIStyle textStyle;

	private float alpha;

	private float alphadc;

	private float alphai;

	private float alphav;

	public GUIStyle logStyle;

	public GUISkin guiSkin;

	[NonSerialized]
	public static string[] output = new string[30];

	private string finalOutput;

	public Texture greyTex;

	private Vector2 scrollpos;

	private bool showLog;

	public string[] tutorialList;

	private string lastLoadedLevel;

	public SpawningScript spwnsrc;

	public HeadlesssDedServer headless;

	public LoginWindow lwindow;

	public PreloaderExplosion pex;

	public EndofRound eor;

	private bool gotError;

	private bool checkAgain;

	public string[] ach;

	public string[] achDesc;

	[NonSerialized]
	public static string[] achStat;

	[NonSerialized]
	public static string[] achDescStat;

	[NonSerialized]
	public static UnityScript.Lang.Array achGot = new UnityScript.Lang.Array();

	public DontDestroyOnLoad ddol;

	public GUIStyle alertStyle;

	private float alertAlpha;

	private string alertText;

	[NonSerialized]
	public static float timePlayed;

	private bool leftRoom;

	[NonSerialized]
	public static bool showTutorial;

	private float versionAlpha;

	[NonSerialized]
	public static UnityScript.Lang.Array friendsArr = new UnityScript.Lang.Array();

	[NonSerialized]
	public static string myIP = string.Empty;

	[NonSerialized]
	public static bool isBanned;

	private string gameModeText;

	public GUIStyle gameModeStyle;

	private float gametypealpha;

	public AuthGameObject()
	{
		fogdensity = new UnityScript.Lang.Array(0.0002f, 0.0004f, 0.0006f, 0.0002f, 0.0004f, 0.0006f);
		fogdensity2 = new UnityScript.Lang.Array(0.002f, 0.004f, 0.006f, 0.002f, 0.004f, 0.006f);
		fogdensity3 = new UnityScript.Lang.Array(0.0015f, 0.001f, 0.0025f, 0.0035f, 0.0035f, 0.0035f);
		fogdensity4 = new UnityScript.Lang.Array(0.00035f, 0.0005f, 0.00055f, 0.00035f, 0.0008f, 0.00085f);
		fogdensity5 = new UnityScript.Lang.Array(0.00035f, 0.0015f, 0.002f, 0.00035f, 0.0008f, 0.00085f);
		cachename = string.Empty;
		cacheurl = string.Empty;
		finalOutput = string.Empty;
		lastLoadedLevel = string.Empty;
		gameModeText = string.Empty;
	}

	public virtual IEnumerator fadeInGameMode(string s)
	{
		return new _0024fadeInGameMode_00243207(s, this).GetEnumerator();
	}

	public virtual void Awake()
	{
		achStat = ach;
		achDescStat = achDesc;
		if (achGot.length == 0)
		{
			for (int i = 0; i < UnityScript.Lang.Extensions.get_length((System.Array)ach); i++)
			{
				achGot.Add("0");
			}
		}
	}

	public virtual IEnumerator displayAlert(string m)
	{
		return new _0024displayAlert_00243212(m, this).GetEnumerator();
	}

	public virtual IEnumerator gotAch(string iv)
	{
		return new _0024gotAch_00243217(iv, this).GetEnumerator();
	}

	public virtual string returnGold()
	{
		string text = inventory[2].Split("#"[0])[0];
		string text2 = string.Empty;
		for (int i = 0; i < UnityScript.Lang.Extensions.get_length(text); i++)
		{
			if (text.Substring(i, 1) == "a")
			{
				text2 += "0";
			}
			if (text.Substring(i, 1) == "b")
			{
				text2 += "1";
			}
			if (text.Substring(i, 1) == "c")
			{
				text2 += "2";
			}
			if (text.Substring(i, 1) == "d")
			{
				text2 += "3";
			}
			if (text.Substring(i, 1) == "e")
			{
				text2 += "4";
			}
			if (text.Substring(i, 1) == "f")
			{
				text2 += "5";
			}
			if (text.Substring(i, 1) == "g")
			{
				text2 += "6";
			}
			if (text.Substring(i, 1) == "h")
			{
				text2 += "7";
			}
			if (text.Substring(i, 1) == "i")
			{
				text2 += "8";
			}
			if (text.Substring(i, 1) == "j")
			{
				text2 += "9";
			}
		}
		return text2;
	}

	public virtual IEnumerator fadeV()
	{
		return new _0024fadeV_00243243(this).GetEnumerator();
	}

	public virtual IEnumerator fadeI()
	{
		return new _0024fadeI_00243246(this).GetEnumerator();
	}

	public virtual IEnumerator sendStat(string sName, float sAmount, int t)
	{
		return new _0024sendStat_00243249(sName, sAmount, t, this).GetEnumerator();
	}

	public virtual IEnumerator sendStat(string sName, int sAmount, int t)
	{
		return new _0024sendStat_00243261(sName, sAmount, t, this).GetEnumerator();
	}

	public virtual void OnGUI()
	{
		float a = gametypealpha;
		Color color = GUI.color;
		float num = (color.a = a);
		Color color2 = (GUI.color = color);
		if (!(gametypealpha <= 0f))
		{
			GUI.depth = -5;
			GUI.Label(new Rect(0f, 0f, Screen.width, 95f), gameModeText, gameModeStyle);
		}
		if (!(alertAlpha <= 0f))
		{
			float a2 = alertAlpha;
			Color color4 = GUI.color;
			float num2 = (color4.a = a2);
			Color color5 = (GUI.color = color4);
			GUI.depth = -99;
			GUILayout.BeginArea(new Rect(0f, 5f, Screen.width, 50f));
			GUILayout.BeginHorizontal();
			GUILayout.FlexibleSpace();
			GUILayout.Label(alertText, alertStyle, GUILayout.Height(50f));
			GUILayout.FlexibleSpace();
			GUILayout.EndHorizontal();
			GUILayout.EndArea();
		}
		if (!(alphai <= 0f))
		{
			float a3 = alphai;
			Color color7 = GUI.color;
			float num3 = (color7.a = a3);
			Color color8 = (GUI.color = color7);
			GUI.depth = -5;
			GUI.Box(new Rect(Screen.width / 2 - 160, Screen.height / 2 - 57, 320f, 115f), "Loading Inventory", evictStyle);
			GUI.Label(new Rect(Screen.width / 2 - 160, Screen.height / 2 - 57, 320f, 115f), "Your inventory hasn't finished loading yet; you won't have any items if you join a game!", textStyle);
		}
		if (!(alphadc <= 0f))
		{
			float a4 = alphadc;
			Color color10 = GUI.color;
			float num4 = (color10.a = a4);
			Color color11 = (GUI.color = color10);
			GUI.depth = -5;
			GUI.Box(new Rect(Screen.width / 2 - 160, Screen.height / 2 - 57, 320f, 115f), "Lost Connection", evictStyle);
			GUI.Label(new Rect(Screen.width / 2 - 160, Screen.height / 2 - 57, 320f, 115f), "You lost the connection to the server! This is usually caused by an unreliable internet connection.", textStyle);
		}
		if (!(alpha <= 0f))
		{
			float a5 = alpha;
			Color color13 = GUI.color;
			float num5 = (color13.a = a5);
			Color color14 = (GUI.color = color13);
			GUI.depth = -5;
			GUI.Box(new Rect(Screen.width / 2 - 160, Screen.height / 2 - 57, 320f, 115f), "Evicted From Server", evictStyle);
			GUI.Label(new Rect(Screen.width / 2 - 160, Screen.height / 2 - 57, 320f, 115f), "You were evicted from the server by the host; you may want to find another server.", textStyle);
		}
		if (!(alphav <= 0f))
		{
			float a6 = alphav;
			Color color16 = GUI.color;
			float num6 = (color16.a = a6);
			Color color17 = (GUI.color = color16);
			GUI.depth = -5;
			GUI.Box(new Rect(Screen.width / 2 - 160, Screen.height / 2 - 57, 320f, 115f), "Outdated Version", evictStyle);
			GUI.Label(new Rect(Screen.width / 2 - 160, Screen.height / 2 - 57, 320f, 115f), "This is an old version of the game; empty your browser cache and reload the page.", textStyle);
		}
		GUI.skin = guiSkin;
		float a7 = 1f;
		Color color19 = GUI.color;
		float num7 = (color19.a = a7);
		Color color20 = (GUI.color = color19);
		if (showLog)
		{
			GUI.depth = -100;
			GUI.DrawTexture(new Rect(0f, 0f, Screen.width, Screen.height), greyTex);
			scrollpos = GUILayout.BeginScrollView(scrollpos, GUILayout.Width(Screen.width), GUILayout.Height(Screen.height));
			GUILayout.Label(finalOutput, logStyle);
			GUILayout.FlexibleSpace();
			GUILayout.EndScrollView();
		}
		if (Event.current.type == EventType.KeyDown && Event.current.character == '`')
		{
			showLog = !showLog;
		}
	}

	public virtual void Gametype(string s)
	{
		gametype = s;
	}

	public virtual void FF(bool b)
	{
		ff = b;
	}

	public virtual void FPSen(bool b)
	{
		fpsenabled = b;
	}

	public virtual void WeatherIndex(int t)
	{
		weatherindex = t;
	}

	public virtual void Maxplayers(string s)
	{
		maxplayers = UnityBuiltins.parseInt(s.Replace(" player", string.Empty).Replace("s", string.Empty));
	}

	public virtual void Timelimit(string s)
	{
		timelimit = UnityBuiltins.parseInt(s.Replace(" minutes", string.Empty));
	}

	public virtual void Start()
	{
		UnityEngine.Object.DontDestroyOnLoad(this);
		Application.RegisterLogCallback(HandleLog);
	}

	public virtual IEnumerator grabAch()
	{
		return new _0024grabAch_00243273(this).GetEnumerator();
	}

	public virtual IEnumerator startTutorial()
	{
		return new _0024startTutorial_00243279(this).GetEnumerator();
	}

	public virtual void HandleLog(string logString, string stackTrace, LogType type)
	{
		if (type != LogType.Warning && logString != string.Empty && !logString.Contains("controls when doing KeyDown") && !logString.Contains("Sent RPC call 'updateStates' to all connected clients"))
		{
			for (int num = 29; num > 0; num--)
			{
				output[num] = output[num - 1];
			}
			output[0] = logString + "\n" + ((!(stackTrace != string.Empty)) ? "\n\n" : ("\t\t\t\t(" + stackTrace + ")\n\n"));
			finalOutput = string.Empty;
			for (int num = 0; num < 30; num++)
			{
				finalOutput += output[num];
			}
		}
	}

	public virtual IEnumerator startEvict()
	{
		return new _0024startEvict_00243287(this).GetEnumerator();
	}

	public virtual void setskybox(int i)
	{
		skyboxindex = i;
		weatherindex = i;
	}

	public virtual IEnumerator fadeDC()
	{
		return new _0024fadeDC_00243290(this).GetEnumerator();
	}

	public virtual IEnumerator fadeEvict()
	{
		return new _0024fadeEvict_00243293(this).GetEnumerator();
	}

	public virtual void startGameAPI()
	{
	}

	public virtual IEnumerator endGameAPI(int reasonId)
	{
		return new _0024endGameAPI_00243296(reasonId, this).GetEnumerator();
	}

	public virtual void Update()
	{
		timePlayed += Time.deltaTime;
		if (!(timePlayed < 720000f))
		{
			timePlayed = 0f;
			StartCoroutine_Auto(gotAch("Two Hours"));
		}
		if (HeadlesssDedServer.isServerHost)
		{
			int i = 0;
			Camera[] allCameras = Camera.allCameras;
			for (int length = allCameras.Length; i < length; i++)
			{
				if (allCameras[i].enabled)
				{
					allCameras[i].enabled = false;
				}
			}
		}
		if (Application.loadedLevelName != "Menu" && Application.loadedLevelName != "Forge" && Application.loadedLevelName != lastLoadedLevel)
		{
			lastLoadedLevel = Application.loadedLevelName;
		}
		if (Application.loadedLevelName == "Menu" && wasevicted)
		{
			wasevicted = false;
			StartCoroutine_Auto(fadeEvict());
		}
		if (Application.loadedLevelName == "Menu" && wasdc)
		{
			wasdc = false;
			StartCoroutine_Auto(fadeDC());
		}
		if (Application.loadedLevelName == "Menu" && !wasdc && !leftRoom)
		{
			leftRoom = true;
			Debug.Log("Left room normally!");
		}
		if (whirldname != cachename)
		{
			GameObject.Find("/WhirldIn").SendMessage("setwname", whirldname);
			cachename = whirldname;
		}
		if (whirldmmurl != cacheurl)
		{
			GameObject.Find("/WhirldIn").SendMessage("setwurl", whirldmmurl);
			cacheurl = whirldmmurl;
		}
		if (!stopsetting)
		{
			if (Application.loadedLevelName == "MainScene")
			{
				@delegate();
			}
			if (Application.loadedLevelName == "NuclearSilo")
			{
				delegate2();
			}
			if (Application.loadedLevelName == "NewIsland")
			{
				delegate3();
			}
			if (Application.loadedLevelName == "CCWhirldScene" || Application.loadedLevelName == "Forge_Scene")
			{
				delegate4();
			}
			if (Application.loadedLevelName == "ChokePoint")
			{
				delegate5();
			}
			if (Application.loadedLevelName == "Sanctum")
			{
				delegate6();
			}
		}
		else if (Application.loadedLevelName == "Menu")
		{
			weatherindex = 0;
			maxplayers = 0;
			timelimit = 5;
			gametype = string.Empty;
			UnityEngine.Object.Destroy(gameObject);
		}
	}

	public virtual void @delegate()
	{
		stopsetting = true;
		RenderSettings.skybox = skyboxes[skyboxindex];
		RenderSettings.fogColor = fogcolors[skyboxindex];
		RenderSettings.fogDensity = RuntimeServices.UnboxSingle(fogdensity[skyboxindex]);
		GameObject gameObject = GameObject.Find("LightSources/Sun");
		gameObject.light.flare = flares[skyboxindex];
		if (skyboxindex >= 4)
		{
			GameObject gameObject2 = GameObject.Find("Water/NightWater");
			gameObject2.SetActiveRecursively(true);
			gameObject2 = GameObject.Find("Water/Daylight Water");
			gameObject2.active = false;
			gameObject2 = GameObject.Find("Water/Daylight Water1");
			gameObject2.active = false;
		}
		GameObject gameObject3 = GameObject.Find("/Main Camera/Rain");
		if (skyboxindex == 2 || skyboxindex == 5)
		{
			gameObject3.particleEmitter.emit = true;
		}
		else
		{
			UnityEngine.Object.Destroy(gameObject3);
		}
	}

	public virtual void delegate2()
	{
		stopsetting = true;
		RenderSettings.skybox = skyboxes2[skyboxindex];
		RenderSettings.fogColor = fogcolors2[skyboxindex];
		RenderSettings.fogDensity = RuntimeServices.UnboxSingle(fogdensity2[skyboxindex]);
		GameObject gameObject = GameObject.Find("LightSources/Sun");
		gameObject.light.flare = flares2[skyboxindex];
		GameObject gameObject2 = GameObject.Find("/Main Camera/Rain");
		if (skyboxindex == 2 || skyboxindex == 5)
		{
			gameObject2.particleEmitter.emit = true;
		}
		else
		{
			UnityEngine.Object.Destroy(gameObject2);
		}
	}

	public virtual void delegate3()
	{
		stopsetting = true;
		RenderSettings.skybox = skyboxes3[skyboxindex];
		RenderSettings.fogColor = fogcolors3[skyboxindex];
		RenderSettings.fogDensity = RuntimeServices.UnboxSingle(fogdensity3[skyboxindex]);
		GameObject gameObject = GameObject.Find("LightSources/Sun");
		gameObject.light.flare = flares3[skyboxindex];
		GameObject gameObject2 = GameObject.Find("Water/NightWater");
		if (skyboxindex >= 4)
		{
			gameObject2.SetActiveRecursively(true);
			gameObject2 = GameObject.Find("Water/Daylight Water");
			gameObject2.active = false;
			gameObject2 = GameObject.Find("Water/Daylight Water1");
			gameObject2.active = false;
		}
		else
		{
			gameObject2.SetActiveRecursively(false);
		}
		GameObject gameObject3 = GameObject.Find("/Main Camera/Rain");
		if (skyboxindex == 2 || skyboxindex == 5)
		{
			gameObject3.particleEmitter.emit = true;
		}
		else
		{
			UnityEngine.Object.Destroy(gameObject3);
		}
	}

	public virtual void delegate4()
	{
		stopsetting = true;
		weatherindex = 0;
		GameObject obj = GameObject.Find("/Main Camera/Rain");
		UnityEngine.Object.Destroy(obj);
	}

	public virtual void delegate5()
	{
		stopsetting = true;
		RenderSettings.skybox = skyboxes4[skyboxindex];
		RenderSettings.fogColor = fogcolors4[skyboxindex];
		RenderSettings.fogDensity = RuntimeServices.UnboxSingle(fogdensity4[skyboxindex]);
		GameObject gameObject = GameObject.Find("LightSources/Sun");
		gameObject.light.flare = flares4[skyboxindex];
		GameObject gameObject2 = GameObject.Find("Water/NightWater");
		if (skyboxindex >= 4)
		{
			gameObject2.SetActiveRecursively(true);
			gameObject2 = GameObject.Find("Water/Daylight Water");
			gameObject2.active = false;
			gameObject2 = GameObject.Find("Water/Daylight Water1");
			gameObject2.active = false;
		}
		else
		{
			gameObject2.SetActiveRecursively(false);
		}
		GameObject gameObject3 = GameObject.Find("/Main Camera/Rain");
		if (skyboxindex == 2 || skyboxindex == 5)
		{
			gameObject3.particleEmitter.emit = true;
		}
		else
		{
			UnityEngine.Object.Destroy(gameObject3);
		}
	}

	public virtual void delegate6()
	{
		stopsetting = true;
		RenderSettings.skybox = skyboxes5[skyboxindex];
		RenderSettings.fogColor = fogcolors5[skyboxindex];
		RenderSettings.fogDensity = RuntimeServices.UnboxSingle(fogdensity5[skyboxindex]);
		GameObject gameObject = GameObject.Find("LightSources/Sun");
		gameObject.light.flare = flares4[skyboxindex];
		GameObject gameObject2 = GameObject.Find("Water/NightWater");
		if (skyboxindex >= 4)
		{
			gameObject2.SetActiveRecursively(true);
			gameObject2 = GameObject.Find("Water/Daylight Water");
			gameObject2.active = false;
			gameObject2 = GameObject.Find("Water/Daylight Water1");
			gameObject2.active = false;
		}
		else
		{
			gameObject2.SetActiveRecursively(false);
		}
		GameObject gameObject3 = GameObject.Find("/Main Camera/Rain");
		if (skyboxindex == 2 || skyboxindex == 5)
		{
			gameObject3.particleEmitter.emit = true;
		}
		else
		{
			UnityEngine.Object.Destroy(gameObject3);
		}
	}

	public virtual void Main()
	{
	}
}
