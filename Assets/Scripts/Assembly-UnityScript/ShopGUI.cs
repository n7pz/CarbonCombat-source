using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class ShopGUI : MonoBehaviour
{
	[Serializable]
	internal sealed class _0024startcountDown_00245507 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal ShopGUI _0024self__00245508;

			public _0024(ShopGUI self_)
			{
				_0024self__00245508 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00245508.sellcounter = 5f;
					goto case 2;
				case 2:
					if (_0024self__00245508.startsell && _0024self__00245508.sellcounter > 0f)
					{
						_0024self__00245508.sellcounter -= Time.deltaTime;
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024self__00245508.startsell = false;
					_0024self__00245508.sellcounter = 5f;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal ShopGUI _0024self__00245509;

		public _0024startcountDown_00245507(ShopGUI self_)
		{
			_0024self__00245509 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00245509);
		}
	}

	[Serializable]
	internal sealed class _0024sellItem_00245510 : GenericGenerator<WWW>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WWW>, IEnumerator
		{
			internal int _0024theindex_00245511;

			internal int _0024count_00245512;

			internal string _0024item_00245513;

			internal int _0024price_00245514;

			internal string _0024e_00245515;

			internal string _0024e_00245516;

			internal string _0024e_00245517;

			internal string _0024e_00245518;

			internal string _0024e_00245519;

			internal WWW _0024getKey_00245520;

			internal WWW _0024item_00245521;

			internal WWW _0024bitem_00245522;

			internal int _0024_00241744_00245523;

			internal string[] _0024_00241745_00245524;

			internal int _0024_00241746_00245525;

			internal int _0024_00241748_00245526;

			internal string[] _0024_00241749_00245527;

			internal int _0024_00241750_00245528;

			internal int _0024_00241752_00245529;

			internal string[] _0024_00241753_00245530;

			internal int _0024_00241754_00245531;

			internal int _0024_00241756_00245532;

			internal string[] _0024_00241757_00245533;

			internal int _0024_00241758_00245534;

			internal int _0024_00241760_00245535;

			internal string[] _0024_00241761_00245536;

			internal int _0024_00241762_00245537;

			internal IEnumerator _0024_0024iterator_00243008_00245538;

			internal int _0024i_00245539;

			internal string[] _0024inventory_00245540;

			internal ShopGUI _0024self__00245541;

			public _0024(int i, string[] inventory, ShopGUI self_)
			{
				_0024i_00245539 = i;
				_0024inventory_00245540 = inventory;
				_0024self__00245541 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00245541.isbuying = true;
					_0024self__00245541.gameObject.SendMessage("showStatus", "Selling Item...");
					_0024theindex_00245511 = default(int);
					_0024count_00245512 = 0;
					_0024_0024iterator_00243008_00245538 = _0024self__00245541.autharraytoformat.GetEnumerator();
					while (_0024_0024iterator_00243008_00245538.MoveNext())
					{
						object obj = _0024_0024iterator_00243008_00245538.Current;
						if (!(obj is string))
						{
							obj = RuntimeServices.Coerce(obj, typeof(string));
						}
						_0024item_00245513 = (string)obj;
						if (_0024item_00245513 == _0024inventory_00245540[_0024i_00245539])
						{
							_0024theindex_00245511 = _0024count_00245512;
						}
						_0024count_00245512++;
					}
					_0024price_00245514 = default(int);
					_0024_00241744_00245523 = 0;
					_0024_00241745_00245524 = _0024self__00245541.cat1;
					for (_0024_00241746_00245525 = _0024_00241745_00245524.Length; _0024_00241744_00245523 < _0024_00241746_00245525; _0024_00241744_00245523++)
					{
						if (_0024_00241745_00245524[_0024_00241744_00245523].Split("|"[0])[UnityScript.Lang.Extensions.get_length((System.Array)_0024_00241745_00245524[_0024_00241744_00245523].Split("|"[0])) - 1] == _0024theindex_00245511.ToString())
						{
							Debug.Log(_0024_00241745_00245524[_0024_00241744_00245523].Split("|"[0])[UnityScript.Lang.Extensions.get_length((System.Array)_0024_00241745_00245524[_0024_00241744_00245523].Split("|"[0])) - 2] + "       " + AuthGameObject.rentarr[_0024theindex_00245511] + "      " + AuthGameObject.inventory[_0024theindex_00245511]);
							_0024price_00245514 = (int)((Mathf.Round((float)UnityBuiltins.parseInt(_0024_00241745_00245524[_0024_00241744_00245523].Split("|"[0])[UnityScript.Lang.Extensions.get_length((System.Array)_0024_00241745_00245524[_0024_00241744_00245523].Split("|"[0])) - 2]) * Mathf.Clamp((float)UnityBuiltins.parseInt(AuthGameObject.rentarr[_0024theindex_00245511]) / 14f, 0.2f, 1f)) + (float)((UnityBuiltins.parseInt(AuthGameObject.inventory[_0024theindex_00245511]) - 1) * 75)) * 0.85f);
						}
					}
					_0024_00241748_00245526 = 0;
					_0024_00241749_00245527 = _0024self__00245541.cat2;
					for (_0024_00241750_00245528 = _0024_00241749_00245527.Length; _0024_00241748_00245526 < _0024_00241750_00245528; _0024_00241748_00245526++)
					{
						if (_0024_00241749_00245527[_0024_00241748_00245526].Split("|"[0])[UnityScript.Lang.Extensions.get_length((System.Array)_0024_00241749_00245527[_0024_00241748_00245526].Split("|"[0])) - 1] == _0024theindex_00245511.ToString())
						{
							Debug.Log(_0024_00241749_00245527[_0024_00241748_00245526].Split("|"[0])[UnityScript.Lang.Extensions.get_length((System.Array)_0024_00241749_00245527[_0024_00241748_00245526].Split("|"[0])) - 2] + "       " + AuthGameObject.rentarr[_0024theindex_00245511] + "      " + AuthGameObject.inventory[_0024theindex_00245511]);
							_0024price_00245514 = (int)((Mathf.Round((float)UnityBuiltins.parseInt(_0024_00241749_00245527[_0024_00241748_00245526].Split("|"[0])[UnityScript.Lang.Extensions.get_length((System.Array)_0024_00241749_00245527[_0024_00241748_00245526].Split("|"[0])) - 2]) * Mathf.Clamp((float)UnityBuiltins.parseInt(AuthGameObject.rentarr[_0024theindex_00245511]) / 14f, 0.2f, 1f)) + (float)((UnityBuiltins.parseInt(AuthGameObject.inventory[_0024theindex_00245511]) - 1) * 75)) * 0.85f);
						}
					}
					_0024_00241752_00245529 = 0;
					_0024_00241753_00245530 = _0024self__00245541.cat3;
					for (_0024_00241754_00245531 = _0024_00241753_00245530.Length; _0024_00241752_00245529 < _0024_00241754_00245531; _0024_00241752_00245529++)
					{
						if (_0024_00241753_00245530[_0024_00241752_00245529].Split("|"[0])[UnityScript.Lang.Extensions.get_length((System.Array)_0024_00241753_00245530[_0024_00241752_00245529].Split("|"[0])) - 1] == _0024theindex_00245511.ToString())
						{
							Debug.Log(_0024_00241753_00245530[_0024_00241752_00245529].Split("|"[0])[UnityScript.Lang.Extensions.get_length((System.Array)_0024_00241753_00245530[_0024_00241752_00245529].Split("|"[0])) - 2] + "       " + AuthGameObject.rentarr[_0024theindex_00245511] + "      " + AuthGameObject.inventory[_0024theindex_00245511]);
							_0024price_00245514 = (int)((Mathf.Round((float)UnityBuiltins.parseInt(_0024_00241753_00245530[_0024_00241752_00245529].Split("|"[0])[UnityScript.Lang.Extensions.get_length((System.Array)_0024_00241753_00245530[_0024_00241752_00245529].Split("|"[0])) - 2]) * Mathf.Clamp((float)UnityBuiltins.parseInt(AuthGameObject.rentarr[_0024theindex_00245511]) / 14f, 0.2f, 1f)) + (float)((UnityBuiltins.parseInt(AuthGameObject.inventory[_0024theindex_00245511]) - 1) * 75)) * 0.85f);
						}
					}
					_0024_00241756_00245532 = 0;
					_0024_00241757_00245533 = _0024self__00245541.cat4;
					for (_0024_00241758_00245534 = _0024_00241757_00245533.Length; _0024_00241756_00245532 < _0024_00241758_00245534; _0024_00241756_00245532++)
					{
						if (_0024_00241757_00245533[_0024_00241756_00245532].Split("|"[0])[UnityScript.Lang.Extensions.get_length((System.Array)_0024_00241757_00245533[_0024_00241756_00245532].Split("|"[0])) - 1] == _0024theindex_00245511.ToString())
						{
							Debug.Log(_0024_00241757_00245533[_0024_00241756_00245532].Split("|"[0])[UnityScript.Lang.Extensions.get_length((System.Array)_0024_00241757_00245533[_0024_00241756_00245532].Split("|"[0])) - 2] + "       " + AuthGameObject.rentarr[_0024theindex_00245511] + "      " + AuthGameObject.inventory[_0024theindex_00245511]);
							_0024price_00245514 = (int)((Mathf.Round((float)UnityBuiltins.parseInt(_0024_00241757_00245533[_0024_00241756_00245532].Split("|"[0])[UnityScript.Lang.Extensions.get_length((System.Array)_0024_00241757_00245533[_0024_00241756_00245532].Split("|"[0])) - 2]) * Mathf.Clamp((float)UnityBuiltins.parseInt(AuthGameObject.rentarr[_0024theindex_00245511]) / 14f, 0.2f, 1f)) + (float)((UnityBuiltins.parseInt(AuthGameObject.inventory[_0024theindex_00245511]) - 1) * 75)) * 0.85f);
						}
					}
					_0024_00241760_00245535 = 0;
					_0024_00241761_00245536 = _0024self__00245541.cat5;
					for (_0024_00241762_00245537 = _0024_00241761_00245536.Length; _0024_00241760_00245535 < _0024_00241762_00245537; _0024_00241760_00245535++)
					{
						if (_0024_00241761_00245536[_0024_00241760_00245535].Split("|"[0])[UnityScript.Lang.Extensions.get_length((System.Array)_0024_00241761_00245536[_0024_00241760_00245535].Split("|"[0])) - 1] == _0024theindex_00245511.ToString())
						{
							Debug.Log(_0024_00241761_00245536[_0024_00241760_00245535].Split("|"[0])[UnityScript.Lang.Extensions.get_length((System.Array)_0024_00241761_00245536[_0024_00241760_00245535].Split("|"[0])) - 2] + "       " + AuthGameObject.rentarr[_0024theindex_00245511] + "      " + AuthGameObject.inventory[_0024theindex_00245511]);
							_0024price_00245514 = (int)((Mathf.Round((float)UnityBuiltins.parseInt(_0024_00241761_00245536[_0024_00241760_00245535].Split("|"[0])[UnityScript.Lang.Extensions.get_length((System.Array)_0024_00241761_00245536[_0024_00241760_00245535].Split("|"[0])) - 2]) * Mathf.Clamp((float)UnityBuiltins.parseInt(AuthGameObject.rentarr[_0024theindex_00245511]) / 14f, 0.2f, 1f)) + (float)((UnityBuiltins.parseInt(AuthGameObject.inventory[_0024theindex_00245511]) - 1) * 75)) * 0.85f);
						}
					}
					Debug.Log("Selling item with price: " + _0024price_00245514);
					_0024getKey_00245520 = new WWW(_0024self__00245541.keyGen + "username=" + Md5Sum.ComputeMd5(AuthGameObject.username + global::DontDestroyOnLoad.hitcollider));
					result = (Yield(2, _0024getKey_00245520) ? 1 : 0);
					break;
				case 2:
					_0024item_00245521 = new WWW(_0024self__00245541.storeInterface + "username=" + AuthGameObject.username + "&request=changevalue" + "&serverkey=" + Md5Sum.ComputeMd5(_0024getKey_00245520.text + global::DontDestroyOnLoad.hitcollider) + "&field=" + _0024self__00245541.dbindex[_0024theindex_00245511] + "&changeto=");
					result = (Yield(3, _0024item_00245521) ? 1 : 0);
					break;
				case 3:
					if (string.IsNullOrEmpty(_0024item_00245521.error) && _0024item_00245521.text.Contains("updated"))
					{
						AuthGameObject.inventory[_0024theindex_00245511] = "false";
					}
					_0024getKey_00245520 = new WWW(_0024self__00245541.keyGen + "username=" + Md5Sum.ComputeMd5(AuthGameObject.username + global::DontDestroyOnLoad.hitcollider));
					result = (Yield(4, _0024getKey_00245520) ? 1 : 0);
					break;
				case 4:
					_0024bitem_00245522 = new WWW(_0024self__00245541.storeInterface + "username=" + AuthGameObject.username + "&request=addcreds" + "&serverkey=" + Md5Sum.ComputeMd5(_0024getKey_00245520.text + global::DontDestroyOnLoad.hitcollider) + "&changeto=" + _0024price_00245514.ToString());
					result = (Yield(5, _0024bitem_00245522) ? 1 : 0);
					break;
				case 5:
					if (string.IsNullOrEmpty(_0024bitem_00245522.error))
					{
						if (_0024bitem_00245522.text.Contains("updated"))
						{
							AuthGameObject.inventory[2] = (UnityBuiltins.parseInt(_0024self__00245541.returnGold()) + _0024price_00245514).ToString() + "#" + AuthGameObject.inventory[2].Split("#"[0])[1] + "#" + AuthGameObject.inventory[2].Split("#"[0])[2] + "#" + AuthGameObject.inventory[2].Split("#"[0])[3] + "#" + AuthGameObject.inventory[2].Split("#"[0])[4] + "#" + LoginWindow.curday + "#" + AuthGameObject.inventory[2].Split("#"[0])[6];
							AuthGameObject.inventory[2] = _0024self__00245541.returnGoldEncrypted() + "#" + AuthGameObject.inventory[2].Split("#"[0])[1] + "#" + AuthGameObject.inventory[2].Split("#"[0])[2] + "#" + AuthGameObject.inventory[2].Split("#"[0])[3] + "#" + AuthGameObject.inventory[2].Split("#"[0])[4] + "#" + LoginWindow.curday + "#" + AuthGameObject.inventory[2].Split("#"[0])[6];
							_0024self__00245541.gameObject.SendMessage("showStatus", "Item Sold!");
						}
						else
						{
							_0024self__00245541.gameObject.SendMessage("showStatus", "Request Failed!");
						}
					}
					else
					{
						_0024self__00245541.gameObject.SendMessage("showStatus", "Request Failed!");
					}
					_0024self__00245541.isbuying = false;
					_0024self__00245541.gameObject.SendMessage("hideStatus");
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal int _0024i_00245542;

		internal string[] _0024inventory_00245543;

		internal ShopGUI _0024self__00245544;

		public _0024sellItem_00245510(int i, string[] inventory, ShopGUI self_)
		{
			_0024i_00245542 = i;
			_0024inventory_00245543 = inventory;
			_0024self__00245544 = self_;
		}

		public override IEnumerator<WWW> GetEnumerator()
		{
			return new _0024(_0024i_00245542, _0024inventory_00245543, _0024self__00245544);
		}
	}

	[Serializable]
	internal sealed class _0024updateEquip_00245545 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal WWW _0024getKey_00245546;

			internal string _0024escaped_00245547;

			internal WWW _0024bitem_00245548;

			internal string _0024p_00245549;

			internal string _0024s_00245550;

			internal string _0024a_00245551;

			internal string _0024i_00245552;

			internal string _0024v_00245553;

			internal ShopGUI _0024self__00245554;

			public _0024(string p, string s, string a, string i, string v, ShopGUI self_)
			{
				_0024p_00245549 = p;
				_0024s_00245550 = s;
				_0024a_00245551 = a;
				_0024i_00245552 = i;
				_0024v_00245553 = v;
				_0024self__00245554 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024a_00245551 == "false-37" && _0024i_00245552 == "36")
					{
						GameObject.Find("/AuthGameObject").SendMessage("gotAch", "Need For Speed");
					}
					_0024self__00245554.isbuying = true;
					_0024self__00245554.gameObject.SendMessage("showStatus", "Equipping Item...");
					_0024getKey_00245546 = new WWW(_0024self__00245554.keyGen + "username=" + Md5Sum.ComputeMd5(AuthGameObject.username + global::DontDestroyOnLoad.hitcollider));
					result = (Yield(2, _0024getKey_00245546) ? 1 : 0);
					break;
				case 2:
					_0024escaped_00245547 = WWW.EscapeURL("#" + _0024p_00245549 + "#" + _0024s_00245550 + "#" + _0024a_00245551 + "#" + _0024i_00245552 + "#" + LoginWindow.curday + "#" + _0024v_00245553);
					_0024bitem_00245548 = new WWW(_0024self__00245554.storeInterface + "username=" + AuthGameObject.username + "&request=changeequip" + "&serverkey=" + Md5Sum.ComputeMd5(_0024getKey_00245546.text + global::DontDestroyOnLoad.hitcollider) + "&changeto=" + _0024escaped_00245547);
					result = (Yield(3, _0024bitem_00245548) ? 1 : 0);
					break;
				case 3:
					if (string.IsNullOrEmpty(_0024bitem_00245548.error))
					{
						if (_0024bitem_00245548.text.Contains("updated"))
						{
							AuthGameObject.inventory[2] = _0024self__00245554.returnGold() + "#" + _0024p_00245549 + "#" + _0024s_00245550 + "#" + _0024a_00245551 + "#" + _0024i_00245552 + "#" + LoginWindow.curday + "#" + _0024v_00245553;
							AuthGameObject.inventory[2] = _0024self__00245554.returnGoldEncrypted() + "#" + _0024p_00245549 + "#" + _0024s_00245550 + "#" + _0024a_00245551 + "#" + _0024i_00245552 + "#" + LoginWindow.curday + "#" + _0024v_00245553;
							_0024self__00245554.gameObject.SendMessage("showStatus", "Item Equipped!");
						}
						else
						{
							_0024self__00245554.gameObject.SendMessage("showStatus", "Request Failed!");
						}
					}
					else
					{
						_0024self__00245554.gameObject.SendMessage("showStatus", "Request Failed!");
					}
					_0024self__00245554.isbuying = false;
					result = (Yield(4, new WaitForSeconds(1f)) ? 1 : 0);
					break;
				case 4:
					_0024self__00245554.gameObject.SendMessage("hideStatus");
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal string _0024p_00245555;

		internal string _0024s_00245556;

		internal string _0024a_00245557;

		internal string _0024i_00245558;

		internal string _0024v_00245559;

		internal ShopGUI _0024self__00245560;

		public _0024updateEquip_00245545(string p, string s, string a, string i, string v, ShopGUI self_)
		{
			_0024p_00245555 = p;
			_0024s_00245556 = s;
			_0024a_00245557 = a;
			_0024i_00245558 = i;
			_0024v_00245559 = v;
			_0024self__00245560 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024p_00245555, _0024s_00245556, _0024a_00245557, _0024i_00245558, _0024v_00245559, _0024self__00245560);
		}
	}

	[Serializable]
	internal sealed class _0024upgradeItemLevel_00245561 : GenericGenerator<WWW>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WWW>, IEnumerator
		{
			internal WWW _0024getKey_00245562;

			internal WWW _0024item_00245563;

			internal WWW _0024bitem_00245564;

			internal string _0024s_00245565;

			internal int _0024i_00245566;

			internal int _0024index_00245567;

			internal int _0024c_00245568;

			internal ShopGUI _0024self__00245569;

			public _0024(string s, int i, int index, int c, ShopGUI self_)
			{
				_0024s_00245565 = s;
				_0024i_00245566 = i;
				_0024index_00245567 = index;
				_0024c_00245568 = c;
				_0024self__00245569 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__00245569.isbuying = true;
					_0024self__00245569.gameObject.SendMessage("showStatus", "Upgrading Item...");
					_0024getKey_00245562 = new WWW(_0024self__00245569.keyGen + "username=" + Md5Sum.ComputeMd5(AuthGameObject.username + global::DontDestroyOnLoad.hitcollider));
					result = (Yield(2, _0024getKey_00245562) ? 1 : 0);
					break;
				case 2:
					_0024item_00245563 = new WWW(_0024self__00245569.storeInterface + "username=" + AuthGameObject.username + "&request=changevalue" + "&serverkey=" + Md5Sum.ComputeMd5(_0024getKey_00245562.text + global::DontDestroyOnLoad.hitcollider) + "&field=" + _0024s_00245565 + "&changeto=" + _0024i_00245566.ToString());
					result = (Yield(3, _0024item_00245563) ? 1 : 0);
					break;
				case 3:
					if (string.IsNullOrEmpty(_0024item_00245563.error) && _0024item_00245563.text.Contains("updated"))
					{
						AuthGameObject.inventory[_0024index_00245567] = _0024i_00245566.ToString();
					}
					_0024getKey_00245562 = new WWW(_0024self__00245569.keyGen + "username=" + Md5Sum.ComputeMd5(AuthGameObject.username + global::DontDestroyOnLoad.hitcollider));
					result = (Yield(4, _0024getKey_00245562) ? 1 : 0);
					break;
				case 4:
					_0024bitem_00245564 = new WWW(_0024self__00245569.storeInterface + "username=" + AuthGameObject.username + "&request=addcreds" + "&serverkey=" + Md5Sum.ComputeMd5(_0024getKey_00245562.text + global::DontDestroyOnLoad.hitcollider) + "&changeto=" + (_0024c_00245568 * -1).ToString());
					result = (Yield(5, _0024bitem_00245564) ? 1 : 0);
					break;
				case 5:
					if (string.IsNullOrEmpty(_0024bitem_00245564.error))
					{
						if (_0024bitem_00245564.text.Contains("updated"))
						{
							AuthGameObject.inventory[2] = (UnityBuiltins.parseInt(_0024self__00245569.returnGold()) - _0024c_00245568).ToString() + "#" + AuthGameObject.inventory[2].Split("#"[0])[1] + "#" + AuthGameObject.inventory[2].Split("#"[0])[2] + "#" + AuthGameObject.inventory[2].Split("#"[0])[3] + "#" + AuthGameObject.inventory[2].Split("#"[0])[4] + "#" + LoginWindow.curday + "#" + AuthGameObject.inventory[2].Split("#"[0])[6];
							AuthGameObject.inventory[2] = _0024self__00245569.returnGoldEncrypted() + "#" + AuthGameObject.inventory[2].Split("#"[0])[1] + "#" + AuthGameObject.inventory[2].Split("#"[0])[2] + "#" + AuthGameObject.inventory[2].Split("#"[0])[3] + "#" + AuthGameObject.inventory[2].Split("#"[0])[4] + "#" + LoginWindow.curday + "#" + AuthGameObject.inventory[2].Split("#"[0])[6];
							_0024self__00245569.gameObject.SendMessage("showStatus", "Item Upgraded!");
						}
						else
						{
							_0024self__00245569.gameObject.SendMessage("showStatus", "Request Failed!");
						}
					}
					else
					{
						_0024self__00245569.gameObject.SendMessage("showStatus", "Request Failed!");
					}
					_0024self__00245569.isbuying = false;
					_0024self__00245569.gameObject.SendMessage("hideStatus");
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal string _0024s_00245570;

		internal int _0024i_00245571;

		internal int _0024index_00245572;

		internal int _0024c_00245573;

		internal ShopGUI _0024self__00245574;

		public _0024upgradeItemLevel_00245561(string s, int i, int index, int c, ShopGUI self_)
		{
			_0024s_00245570 = s;
			_0024i_00245571 = i;
			_0024index_00245572 = index;
			_0024c_00245573 = c;
			_0024self__00245574 = self_;
		}

		public override IEnumerator<WWW> GetEnumerator()
		{
			return new _0024(_0024s_00245570, _0024i_00245571, _0024index_00245572, _0024c_00245573, _0024self__00245574);
		}
	}

	[Serializable]
	internal sealed class _0024renewItem_00245575 : GenericGenerator<WWW>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WWW>, IEnumerator
		{
			internal int _0024itemType_00245576;

			internal bool _0024canEquip_00245577;

			internal WWW _0024getKey_00245578;

			internal WWW _0024bitem_00245579;

			internal int _0024i_00245580;

			internal int _0024c_00245581;

			internal int _0024rtime_00245582;

			internal ShopGUI _0024self__00245583;

			public _0024(int i, int c, int rtime, ShopGUI self_)
			{
				_0024i_00245580 = i;
				_0024c_00245581 = c;
				_0024rtime_00245582 = rtime;
				_0024self__00245583 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024itemType_00245576 = _0024self__00245583.toolbarInt;
					_0024canEquip_00245577 = false;
					_0024self__00245583.isbuying = true;
					_0024self__00245583.gameObject.SendMessage("showStatus", "Renewing Item...");
					_0024getKey_00245578 = new WWW(_0024self__00245583.keyGen + "username=" + Md5Sum.ComputeMd5(AuthGameObject.username + global::DontDestroyOnLoad.hitcollider));
					result = (Yield(2, _0024getKey_00245578) ? 1 : 0);
					break;
				case 2:
					_0024getKey_00245578 = new WWW(_0024self__00245583.keyGen + "username=" + Md5Sum.ComputeMd5(AuthGameObject.username + global::DontDestroyOnLoad.hitcollider));
					result = (Yield(3, _0024getKey_00245578) ? 1 : 0);
					break;
				case 3:
					_0024bitem_00245579 = new WWW(_0024self__00245583.storeInterface + "username=" + AuthGameObject.username + "&request=renewitem" + "&serverkey=" + Md5Sum.ComputeMd5(_0024getKey_00245578.text + global::DontDestroyOnLoad.hitcollider) + "&field=" + _0024self__00245583.getFieldFor(_0024i_00245580) + "&ex=" + _0024rtime_00245582.ToString());
					result = (Yield(4, _0024bitem_00245579) ? 1 : 0);
					break;
				case 4:
					if (string.IsNullOrEmpty(_0024bitem_00245579.error))
					{
						if (_0024bitem_00245579.text.Contains("updated"))
						{
							_0024getKey_00245578 = new WWW(_0024self__00245583.keyGen + "username=" + Md5Sum.ComputeMd5(AuthGameObject.username + global::DontDestroyOnLoad.hitcollider));
							result = (Yield(5, _0024getKey_00245578) ? 1 : 0);
							break;
						}
						_0024self__00245583.gameObject.SendMessage("showStatus", "Request Failed!");
					}
					else
					{
						_0024self__00245583.gameObject.SendMessage("showStatus", "Request Failed!");
					}
					goto IL_0581;
				case 5:
					_0024bitem_00245579 = new WWW(_0024self__00245583.storeInterface + "username=" + AuthGameObject.username + "&request=addcreds" + "&serverkey=" + Md5Sum.ComputeMd5(_0024getKey_00245578.text + global::DontDestroyOnLoad.hitcollider) + "&changeto=" + (-1 * _0024c_00245581).ToString());
					result = (Yield(6, _0024bitem_00245579) ? 1 : 0);
					break;
				case 6:
					AuthGameObject.inventory[2] = (UnityBuiltins.parseInt(_0024self__00245583.returnGold()) - _0024c_00245581).ToString() + "#" + AuthGameObject.inventory[2].Split("#"[0])[1] + "#" + AuthGameObject.inventory[2].Split("#"[0])[2] + "#" + AuthGameObject.inventory[2].Split("#"[0])[3] + "#" + AuthGameObject.inventory[2].Split("#"[0])[4] + "#" + LoginWindow.curday + "#" + AuthGameObject.inventory[2].Split("#"[0])[6];
					AuthGameObject.inventory[2] = _0024self__00245583.returnGoldEncrypted() + "#" + AuthGameObject.inventory[2].Split("#"[0])[1] + "#" + AuthGameObject.inventory[2].Split("#"[0])[2] + "#" + AuthGameObject.inventory[2].Split("#"[0])[3] + "#" + AuthGameObject.inventory[2].Split("#"[0])[4] + "#" + LoginWindow.curday + "#" + AuthGameObject.inventory[2].Split("#"[0])[6];
					AuthGameObject.rentarr[_0024i_00245580] = (_0024rtime_00245582 + UnityBuiltins.parseInt(AuthGameObject.rentarr[_0024i_00245580])).ToString();
					_0024self__00245583.gameObject.SendMessage("showStatus", "Item Renewed!");
					_0024canEquip_00245577 = true;
					goto IL_0581;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0581:
					_0024self__00245583.isbuying = false;
					_0024self__00245583.gameObject.SendMessage("hideStatus");
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal int _0024i_00245584;

		internal int _0024c_00245585;

		internal int _0024rtime_00245586;

		internal ShopGUI _0024self__00245587;

		public _0024renewItem_00245575(int i, int c, int rtime, ShopGUI self_)
		{
			_0024i_00245584 = i;
			_0024c_00245585 = c;
			_0024rtime_00245586 = rtime;
			_0024self__00245587 = self_;
		}

		public override IEnumerator<WWW> GetEnumerator()
		{
			return new _0024(_0024i_00245584, _0024c_00245585, _0024rtime_00245586, _0024self__00245587);
		}
	}

	[Serializable]
	internal sealed class _0024buyItemPrem_00245588 : GenericGenerator<WWW>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WWW>, IEnumerator
		{
			internal int _0024itemType_00245589;

			internal bool _0024canEquip_00245590;

			internal WWW _0024getKey_00245591;

			internal string _0024escaped_00245592;

			internal WWW _0024bitem_00245593;

			internal UnityScript.Lang.Array _0024inventoryarr_00245594;

			internal int _0024icounter_00245595;

			internal string _0024item_00245596;

			internal int _0024inventorySize_00245597;

			internal int _0024themainindex_00245598;

			internal int _0024_00241780_00245599;

			internal string[] _0024_00241781_00245600;

			internal int _0024_00241782_00245601;

			internal int _0024i_00245602;

			internal int _0024c_00245603;

			internal int _0024rtime_00245604;

			internal ShopGUI _0024self__00245605;

			public _0024(int i, int c, int rtime, ShopGUI self_)
			{
				_0024i_00245602 = i;
				_0024c_00245603 = c;
				_0024rtime_00245604 = rtime;
				_0024self__00245605 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024itemType_00245589 = _0024self__00245605.toolbarInt;
					_0024canEquip_00245590 = false;
					_0024self__00245605.isbuying = true;
					_0024self__00245605.gameObject.SendMessage("showStatus", "Buying Item...");
					_0024getKey_00245591 = new WWW(_0024self__00245605.keyGen + "username=" + Md5Sum.ComputeMd5(AuthGameObject.username + global::DontDestroyOnLoad.hitcollider));
					result = (Yield(2, _0024getKey_00245591) ? 1 : 0);
					break;
				case 2:
					_0024escaped_00245592 = WWW.EscapeURL("#" + AuthGameObject.inventory[2].Split("#"[0])[1] + "#" + AuthGameObject.inventory[2].Split("#"[0])[2] + "#" + AuthGameObject.inventory[2].Split("#"[0])[3] + "#" + AuthGameObject.inventory[2].Split("#"[0])[4] + "#" + LoginWindow.curday);
					_0024getKey_00245591 = new WWW(_0024self__00245605.keyGen + "username=" + Md5Sum.ComputeMd5(AuthGameObject.username + global::DontDestroyOnLoad.hitcollider));
					result = (Yield(3, _0024getKey_00245591) ? 1 : 0);
					break;
				case 3:
					_0024bitem_00245593 = new WWW(_0024self__00245605.storeInterface + "username=" + AuthGameObject.username + "&request=changevalue" + "&serverkey=" + Md5Sum.ComputeMd5(_0024getKey_00245591.text + global::DontDestroyOnLoad.hitcollider) + "&field=" + _0024self__00245605.getFieldFor(_0024i_00245602) + "&changeto=1&ex=" + _0024rtime_00245604.ToString());
					result = (Yield(4, _0024bitem_00245593) ? 1 : 0);
					break;
				case 4:
					if (string.IsNullOrEmpty(_0024bitem_00245593.error))
					{
						if (_0024bitem_00245593.text.Contains("updated"))
						{
							_0024getKey_00245591 = new WWW(_0024self__00245605.keyGen + "username=" + Md5Sum.ComputeMd5(AuthGameObject.username + global::DontDestroyOnLoad.hitcollider));
							result = (Yield(5, _0024getKey_00245591) ? 1 : 0);
							break;
						}
						_0024self__00245605.gameObject.SendMessage("showStatus", "Request Failed!");
					}
					else
					{
						_0024self__00245605.gameObject.SendMessage("showStatus", "Request Failed!");
					}
					goto IL_0447;
				case 5:
					_0024bitem_00245593 = new WWW(_0024self__00245605.storeInterface + "username=" + AuthGameObject.username + "&request=changevalue" + "&serverkey=" + Md5Sum.ComputeMd5(_0024getKey_00245591.text + global::DontDestroyOnLoad.hitcollider) + "&field=premiumcredits&changeto=" + (UnityBuiltins.parseInt(_0024self__00245605.returnGoldPrem()) - _0024c_00245603).ToString());
					result = (Yield(6, _0024bitem_00245593) ? 1 : 0);
					break;
				case 6:
					AuthGameObject.inventory[45] = (UnityBuiltins.parseInt(_0024self__00245605.returnGoldPrem()) - _0024c_00245603).ToString();
					AuthGameObject.inventory[_0024i_00245602] = "1";
					AuthGameObject.rentarr[_0024i_00245602] = _0024rtime_00245604.ToString();
					_0024self__00245605.gameObject.SendMessage("showStatus", "Item Bought!");
					_0024canEquip_00245590 = true;
					goto IL_0447;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0447:
					_0024inventoryarr_00245594 = new UnityScript.Lang.Array();
					_0024icounter_00245595 = 0;
					_0024_00241780_00245599 = 0;
					_0024_00241781_00245600 = AuthGameObject.inventory;
					for (_0024_00241782_00245601 = _0024_00241781_00245600.Length; _0024_00241780_00245599 < _0024_00241782_00245601; _0024_00241780_00245599++)
					{
						if (_0024icounter_00245595 > 2 && _0024_00241781_00245600[_0024_00241780_00245599] != "false" && _0024icounter_00245595 != 45)
						{
							_0024inventoryarr_00245594.Add(_0024self__00245605.autharraytoformat[_0024icounter_00245595]);
						}
						_0024icounter_00245595++;
					}
					_0024inventorySize_00245597 = _0024inventoryarr_00245594.length;
					if (_0024inventorySize_00245597 == 43)
					{
						GameObject.Find("/AuthGameObject").SendMessage("gotAch", "All Sold Out");
					}
					_0024self__00245605.isbuying = false;
					_0024self__00245605.gameObject.SendMessage("hideStatus");
					if (_0024canEquip_00245590)
					{
						_0024themainindex_00245598 = _0024i_00245602;
						if (_0024itemType_00245589 == 0)
						{
							_0024self__00245605.StartCoroutine_Auto(_0024self__00245605.updateEquip(_0024themainindex_00245598.ToString(), AuthGameObject.inventory[2].Split("#"[0])[2], AuthGameObject.inventory[2].Split("#"[0])[3], AuthGameObject.inventory[2].Split("#"[0])[4], AuthGameObject.inventory[2].Split("#"[0])[6]));
						}
						if (_0024itemType_00245589 == 2)
						{
							_0024self__00245605.StartCoroutine_Auto(_0024self__00245605.updateEquip(AuthGameObject.inventory[2].Split("#"[0])[1], AuthGameObject.inventory[2].Split("#"[0])[2], AuthGameObject.inventory[2].Split("#"[0])[3].Split("-"[0])[0] + "-" + _0024themainindex_00245598.ToString(), AuthGameObject.inventory[2].Split("#"[0])[4], AuthGameObject.inventory[2].Split("#"[0])[6]));
						}
						if (_0024itemType_00245589 == 3)
						{
							_0024self__00245605.StartCoroutine_Auto(_0024self__00245605.updateEquip(AuthGameObject.inventory[2].Split("#"[0])[1], AuthGameObject.inventory[2].Split("#"[0])[2], _0024themainindex_00245598.ToString() + "-" + AuthGameObject.inventory[2].Split("#"[0])[3].Split("-"[0])[1], AuthGameObject.inventory[2].Split("#"[0])[4], AuthGameObject.inventory[2].Split("#"[0])[6]));
						}
						if (_0024itemType_00245589 == 1)
						{
							_0024self__00245605.StartCoroutine_Auto(_0024self__00245605.updateEquip(AuthGameObject.inventory[2].Split("#"[0])[1], AuthGameObject.inventory[2].Split("#"[0])[2], AuthGameObject.inventory[2].Split("#"[0])[3], _0024themainindex_00245598.ToString(), AuthGameObject.inventory[2].Split("#"[0])[6]));
						}
						_0024self__00245605.StartCoroutine_Auto(_0024self__00245605.showEquip(true));
					}
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal int _0024i_00245606;

		internal int _0024c_00245607;

		internal int _0024rtime_00245608;

		internal ShopGUI _0024self__00245609;

		public _0024buyItemPrem_00245588(int i, int c, int rtime, ShopGUI self_)
		{
			_0024i_00245606 = i;
			_0024c_00245607 = c;
			_0024rtime_00245608 = rtime;
			_0024self__00245609 = self_;
		}

		public override IEnumerator<WWW> GetEnumerator()
		{
			return new _0024(_0024i_00245606, _0024c_00245607, _0024rtime_00245608, _0024self__00245609);
		}
	}

	[Serializable]
	internal sealed class _0024buyItem_00245610 : GenericGenerator<WWW>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WWW>, IEnumerator
		{
			internal int _0024itemType_00245611;

			internal bool _0024canEquip_00245612;

			internal WWW _0024getKey_00245613;

			internal WWW _0024bitem_00245614;

			internal UnityScript.Lang.Array _0024inventoryarr_00245615;

			internal int _0024icounter_00245616;

			internal string _0024item_00245617;

			internal int _0024inventorySize_00245618;

			internal int _0024themainindex_00245619;

			internal int _0024_00241784_00245620;

			internal string[] _0024_00241785_00245621;

			internal int _0024_00241786_00245622;

			internal int _0024i_00245623;

			internal int _0024c_00245624;

			internal int _0024rtime_00245625;

			internal ShopGUI _0024self__00245626;

			public _0024(int i, int c, int rtime, ShopGUI self_)
			{
				_0024i_00245623 = i;
				_0024c_00245624 = c;
				_0024rtime_00245625 = rtime;
				_0024self__00245626 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024itemType_00245611 = _0024self__00245626.toolbarInt;
					_0024canEquip_00245612 = false;
					_0024self__00245626.isbuying = true;
					_0024self__00245626.gameObject.SendMessage("showStatus", "Buying Item...");
					_0024getKey_00245613 = new WWW(_0024self__00245626.keyGen + "username=" + Md5Sum.ComputeMd5(AuthGameObject.username + global::DontDestroyOnLoad.hitcollider));
					result = (Yield(2, _0024getKey_00245613) ? 1 : 0);
					break;
				case 2:
					_0024getKey_00245613 = new WWW(_0024self__00245626.keyGen + "username=" + Md5Sum.ComputeMd5(AuthGameObject.username + global::DontDestroyOnLoad.hitcollider));
					result = (Yield(3, _0024getKey_00245613) ? 1 : 0);
					break;
				case 3:
					_0024bitem_00245614 = new WWW(_0024self__00245626.storeInterface + "username=" + AuthGameObject.username + "&request=changevalue" + "&serverkey=" + Md5Sum.ComputeMd5(_0024getKey_00245613.text + global::DontDestroyOnLoad.hitcollider) + "&field=" + _0024self__00245626.getFieldFor(_0024i_00245623) + "&changeto=1&ex=" + _0024rtime_00245625.ToString());
					result = (Yield(4, _0024bitem_00245614) ? 1 : 0);
					break;
				case 4:
					if (string.IsNullOrEmpty(_0024bitem_00245614.error))
					{
						if (_0024bitem_00245614.text.Contains("updated"))
						{
							_0024getKey_00245613 = new WWW(_0024self__00245626.keyGen + "username=" + Md5Sum.ComputeMd5(AuthGameObject.username + global::DontDestroyOnLoad.hitcollider));
							result = (Yield(5, _0024getKey_00245613) ? 1 : 0);
							break;
						}
						_0024self__00245626.gameObject.SendMessage("showStatus", "Request Failed!");
					}
					else
					{
						_0024self__00245626.gameObject.SendMessage("showStatus", "Request Failed!");
					}
					goto IL_057d;
				case 5:
					_0024bitem_00245614 = new WWW(_0024self__00245626.storeInterface + "username=" + AuthGameObject.username + "&request=addcreds" + "&serverkey=" + Md5Sum.ComputeMd5(_0024getKey_00245613.text + global::DontDestroyOnLoad.hitcollider) + "&changeto=" + (-1 * _0024c_00245624).ToString());
					result = (Yield(6, _0024bitem_00245614) ? 1 : 0);
					break;
				case 6:
					AuthGameObject.inventory[2] = (UnityBuiltins.parseInt(_0024self__00245626.returnGold()) - _0024c_00245624).ToString() + "#" + AuthGameObject.inventory[2].Split("#"[0])[1] + "#" + AuthGameObject.inventory[2].Split("#"[0])[2] + "#" + AuthGameObject.inventory[2].Split("#"[0])[3] + "#" + AuthGameObject.inventory[2].Split("#"[0])[4] + "#" + LoginWindow.curday + "#" + AuthGameObject.inventory[2].Split("#"[0])[6];
					AuthGameObject.inventory[2] = _0024self__00245626.returnGoldEncrypted() + "#" + AuthGameObject.inventory[2].Split("#"[0])[1] + "#" + AuthGameObject.inventory[2].Split("#"[0])[2] + "#" + AuthGameObject.inventory[2].Split("#"[0])[3] + "#" + AuthGameObject.inventory[2].Split("#"[0])[4] + "#" + LoginWindow.curday + "#" + AuthGameObject.inventory[2].Split("#"[0])[6];
					AuthGameObject.inventory[_0024i_00245623] = "1";
					AuthGameObject.rentarr[_0024i_00245623] = _0024rtime_00245625.ToString();
					_0024self__00245626.gameObject.SendMessage("showStatus", "Item Bought!");
					_0024canEquip_00245612 = true;
					goto IL_057d;
				case 1:
					{
						result = 0;
						break;
					}
					IL_057d:
					_0024inventoryarr_00245615 = new UnityScript.Lang.Array();
					_0024icounter_00245616 = 0;
					_0024_00241784_00245620 = 0;
					_0024_00241785_00245621 = AuthGameObject.inventory;
					for (_0024_00241786_00245622 = _0024_00241785_00245621.Length; _0024_00241784_00245620 < _0024_00241786_00245622; _0024_00241784_00245620++)
					{
						if (_0024icounter_00245616 > 2 && _0024_00241785_00245621[_0024_00241784_00245620] != "false" && _0024icounter_00245616 != 45)
						{
							_0024inventoryarr_00245615.Add(_0024self__00245626.autharraytoformat[_0024icounter_00245616]);
						}
						_0024icounter_00245616++;
					}
					_0024inventorySize_00245618 = _0024inventoryarr_00245615.length;
					if (_0024inventorySize_00245618 == 48)
					{
						GameObject.Find("/AuthGameObject").SendMessage("gotAch", "All Sold Out");
					}
					_0024self__00245626.isbuying = false;
					_0024self__00245626.gameObject.SendMessage("hideStatus");
					if (_0024canEquip_00245612)
					{
						_0024themainindex_00245619 = _0024i_00245623;
						if (_0024itemType_00245611 == 0)
						{
							_0024self__00245626.StartCoroutine_Auto(_0024self__00245626.updateEquip(_0024themainindex_00245619.ToString(), AuthGameObject.inventory[2].Split("#"[0])[2], AuthGameObject.inventory[2].Split("#"[0])[3], AuthGameObject.inventory[2].Split("#"[0])[4], AuthGameObject.inventory[2].Split("#"[0])[6]));
						}
						if (_0024itemType_00245611 == 2)
						{
							_0024self__00245626.StartCoroutine_Auto(_0024self__00245626.updateEquip(AuthGameObject.inventory[2].Split("#"[0])[1], AuthGameObject.inventory[2].Split("#"[0])[2], AuthGameObject.inventory[2].Split("#"[0])[3].Split("-"[0])[0] + "-" + _0024themainindex_00245619.ToString(), AuthGameObject.inventory[2].Split("#"[0])[4], AuthGameObject.inventory[2].Split("#"[0])[6]));
						}
						if (_0024itemType_00245611 == 3)
						{
							_0024self__00245626.StartCoroutine_Auto(_0024self__00245626.updateEquip(AuthGameObject.inventory[2].Split("#"[0])[1], AuthGameObject.inventory[2].Split("#"[0])[2], _0024themainindex_00245619.ToString() + "-" + AuthGameObject.inventory[2].Split("#"[0])[3].Split("-"[0])[1], AuthGameObject.inventory[2].Split("#"[0])[4], AuthGameObject.inventory[2].Split("#"[0])[6]));
						}
						if (_0024itemType_00245611 == 4)
						{
							_0024self__00245626.StartCoroutine_Auto(_0024self__00245626.updateEquip(AuthGameObject.inventory[2].Split("#"[0])[1], AuthGameObject.inventory[2].Split("#"[0])[2], AuthGameObject.inventory[2].Split("#"[0])[3], AuthGameObject.inventory[2].Split("#"[0])[4], _0024themainindex_00245619.ToString()));
						}
						if (_0024itemType_00245611 == 1)
						{
							_0024self__00245626.StartCoroutine_Auto(_0024self__00245626.updateEquip(AuthGameObject.inventory[2].Split("#"[0])[1], AuthGameObject.inventory[2].Split("#"[0])[2], AuthGameObject.inventory[2].Split("#"[0])[3], _0024themainindex_00245619.ToString(), AuthGameObject.inventory[2].Split("#"[0])[6]));
						}
						_0024self__00245626.StartCoroutine_Auto(_0024self__00245626.showEquip(true));
					}
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal int _0024i_00245627;

		internal int _0024c_00245628;

		internal int _0024rtime_00245629;

		internal ShopGUI _0024self__00245630;

		public _0024buyItem_00245610(int i, int c, int rtime, ShopGUI self_)
		{
			_0024i_00245627 = i;
			_0024c_00245628 = c;
			_0024rtime_00245629 = rtime;
			_0024self__00245630 = self_;
		}

		public override IEnumerator<WWW> GetEnumerator()
		{
			return new _0024(_0024i_00245627, _0024c_00245628, _0024rtime_00245629, _0024self__00245630);
		}
	}

	[Serializable]
	internal sealed class _0024showEquip_00245631 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal bool _0024t_00245632;

			internal ShopGUI _0024self__00245633;

			public _0024(bool t, ShopGUI self_)
			{
				_0024t_00245632 = t;
				_0024self__00245633 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024t_00245632)
					{
						goto case 2;
					}
					goto case 3;
				case 2:
					if (!(_0024self__00245633.offset2 >= 0f) && offset == 0f)
					{
						_0024self__00245633.offset2 = Mathf.Lerp(_0024self__00245633.offset2, 1f, 6f * Time.deltaTime);
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024self__00245633.offset2 = 0f;
					goto IL_00fd;
				case 3:
					if (!(_0024self__00245633.offset2 <= -290f) && offset == 0f)
					{
						_0024self__00245633.offset2 = Mathf.Lerp(_0024self__00245633.offset2, -291f, 6f * Time.deltaTime);
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					_0024self__00245633.offset2 = -290f;
					goto IL_00fd;
				case 1:
					{
						result = 0;
						break;
					}
					IL_00fd:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal bool _0024t_00245634;

		internal ShopGUI _0024self__00245635;

		public _0024showEquip_00245631(bool t, ShopGUI self_)
		{
			_0024t_00245634 = t;
			_0024self__00245635 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024t_00245634, _0024self__00245635);
		}
	}

	[Serializable]
	internal sealed class _0024fadeInRent_00245636 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal ShopGUI _0024self__00245637;

			public _0024(ShopGUI self_)
			{
				_0024self__00245637 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__00245637.rentalpha < 1f)
					{
						_0024self__00245637.rentalpha = Mathf.Min(1f, _0024self__00245637.rentalpha + 4f * Time.deltaTime);
						result = (YieldDefault(2) ? 1 : 0);
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

		internal ShopGUI _0024self__00245638;

		public _0024fadeInRent_00245636(ShopGUI self_)
		{
			_0024self__00245638 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00245638);
		}
	}

	[Serializable]
	internal sealed class _0024fadeOutRent_00245639 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal ShopGUI _0024self__00245640;

			public _0024(ShopGUI self_)
			{
				_0024self__00245640 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__00245640.rentalpha > 0f)
					{
						_0024self__00245640.rentalpha = Mathf.Max(0f, _0024self__00245640.rentalpha - 4f * Time.deltaTime);
						result = (YieldDefault(2) ? 1 : 0);
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

		internal ShopGUI _0024self__00245641;

		public _0024fadeOutRent_00245639(ShopGUI self_)
		{
			_0024self__00245641 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00245641);
		}
	}

	[Serializable]
	internal sealed class _0024fadeInCredits_00245642 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal ShopGUI _0024self__00245643;

			public _0024(ShopGUI self_)
			{
				_0024self__00245643 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__00245643.creditalpha < 1f)
					{
						_0024self__00245643.creditalpha = Mathf.Min(1f, _0024self__00245643.creditalpha + 4f * Time.deltaTime);
						result = (YieldDefault(2) ? 1 : 0);
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

		internal ShopGUI _0024self__00245644;

		public _0024fadeInCredits_00245642(ShopGUI self_)
		{
			_0024self__00245644 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00245644);
		}
	}

	[Serializable]
	internal sealed class _0024fadeOutCredits_00245645 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal ShopGUI _0024self__00245646;

			public _0024(ShopGUI self_)
			{
				_0024self__00245646 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__00245646.creditalpha > 0f)
					{
						_0024self__00245646.creditalpha = Mathf.Max(0f, _0024self__00245646.creditalpha - 4f * Time.deltaTime);
						result = (YieldDefault(2) ? 1 : 0);
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

		internal ShopGUI _0024self__00245647;

		public _0024fadeOutCredits_00245645(ShopGUI self_)
		{
			_0024self__00245647 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00245647);
		}
	}

	[NonSerialized]
	public static float offset;

	private float offset2;

	public string[] categories;

	public string[] cat1;

	public string[] cat2;

	public string[] cat3;

	public string[] cat4;

	public string[] cat5;

	public string[] cat6;

	public string[] dbindex;

	public string[] autharraytoformat;

	public Texture[] itemicons;

	public Texture hasImage;

	private int toolbarInt;

	private int itemsInt;

	private int inInt;

	public GUIStyle toolbarbuttons;

	public GUIStyle shopwindow;

	public GUIStyle shopwindow2;

	public GUIStyle buttonstyle;

	public GUISkin scrollstyle;

	public GUIStyle labelstyle;

	public GUIStyle labelstyle2;

	public GUIStyle labelstyle3;

	public GUIStyle labelstyle3p;

	public GUIStyle bars1;

	public GUIStyle bars2;

	public GUIStyle itemsStyle;

	public Texture[] bars;

	public Texture[] gold;

	public GUIStyle equipbackground;

	public GUIStyle largeblue;

	public GUIStyle smallgrey;

	public Texture greybackground;

	public Vector2 scrollPosition;

	public Vector2 scrollPosition2;

	public GameObject maincar;

	public GameObject maincarfake;

	public GameObject[] cat1obj;

	public GameObject[] cat2obj;

	public GameObject[] cat3obj;

	public GameObject[] cat4obj;

	public GameObject[] cat5obj;

	public GameObject[] cat6obj;

	public GameObject maingun;

	private string keyGen;

	private string storeInterface;

	private bool fadetool;

	private float toolalpha;

	public GUIStyle tooltipstyle;

	public Texture origtooltip;

	public Texture flippedtooltip;

	public AuthGameObject authobj;

	public LoginWindow lwindow;

	private bool isbuying;

	public Renderer[] meshes;

	public Material goldmat;

	public Material platinummat;

	public Material defaultblack;

	public Material carbonfibermat;

	public Material crystalmat;

	public Material camomat;

	public Material rustmat;

	public Material neonmat;

	public Material aquamat;

	public DontDestroyOnLoad ddol;

	private UnityScript.Lang.Array equipped;

	public GameObject[] equippedarray;

	private string searchstring;

	private bool startsell;

	private float sellcounter;

	private int sellindex;

	private int lastitemInt;

	private int lastToolbarInt;

	public GameObject gtrbasic;

	public GameObject gtrinvis;

	public GameObject gtrhealth;

	[NonSerialized]
	public static int itemsBuy;

	[NonSerialized]
	public static int itemsBought;

	private int lastSelInt;

	public GameObject gtrinvinc;

	private PreloaderExplosion pex;

	public DisplayTopPlayers dplayer;

	private float creditalpha;

	public GUIStyle credback;

	public GUIStyle credtxt;

	public Texture toolbarBack;

	private float rentalpha;

	private int baseCost;

	private int itemIndex;

	private bool isRenewing;

	private int showLayer;

	public GameObject previewCarMesh;

	public ShopGUI()
	{
		offset2 = -290f;
		scrollPosition = Vector2.zero;
		scrollPosition2 = Vector2.zero;
		keyGen = "http://72.14.184.180/serverKeyGen.php?";
		storeInterface = "http://72.14.184.180/storeInterface.php?";
		equipped = new UnityScript.Lang.Array();
		searchstring = "Search...";
		sellcounter = 5f;
		showLayer = 9;
	}

	public virtual void Awake()
	{
		offset = 0f - ((float)Screen.height + 5f);
		offset2 = -290f;
	}

	public virtual void Update()
	{
		if (offset != 0f && offset2 == 0f)
		{
			StartCoroutine_Auto(showEquip(false));
		}
		if (Application.loadedLevelName == "Menu" && AuthGameObject.shop)
		{
			itemsBuy = 0;
			itemsBought = 0;
			int i = 0;
			string[] array = cat1;
			for (int length = array.Length; i < length; i++)
			{
				if (UnityBuiltins.parseInt(array[i].Split("|"[0])[UnityScript.Lang.Extensions.get_length((System.Array)array[i].Split("|"[0])) - 2]) <= UnityBuiltins.parseInt(returnGold()) && AuthGameObject.inventory[UnityBuiltins.parseInt(array[i].Split("|"[0])[UnityScript.Lang.Extensions.get_length((System.Array)array[i].Split("|"[0])) - 1])] == "false")
				{
					itemsBuy++;
				}
				if (AuthGameObject.inventory[UnityBuiltins.parseInt(array[i].Split("|"[0])[UnityScript.Lang.Extensions.get_length((System.Array)array[i].Split("|"[0])) - 1])] == "false")
				{
					itemsBought++;
				}
			}
			int j = 0;
			string[] array2 = cat2;
			for (int length2 = array2.Length; j < length2; j++)
			{
				if (UnityBuiltins.parseInt(array2[j].Split("|"[0])[UnityScript.Lang.Extensions.get_length((System.Array)array2[j].Split("|"[0])) - 2]) <= UnityBuiltins.parseInt(returnGold()) && AuthGameObject.inventory[UnityBuiltins.parseInt(array2[j].Split("|"[0])[UnityScript.Lang.Extensions.get_length((System.Array)array2[j].Split("|"[0])) - 1])] == "false")
				{
					itemsBuy++;
				}
				if (AuthGameObject.inventory[UnityBuiltins.parseInt(array2[j].Split("|"[0])[UnityScript.Lang.Extensions.get_length((System.Array)array2[j].Split("|"[0])) - 1])] == "false")
				{
					itemsBought++;
				}
			}
			int k = 0;
			string[] array3 = cat3;
			for (int length3 = array3.Length; k < length3; k++)
			{
				if (UnityBuiltins.parseInt(array3[k].Split("|"[0])[UnityScript.Lang.Extensions.get_length((System.Array)array3[k].Split("|"[0])) - 2]) <= UnityBuiltins.parseInt(returnGold()) && AuthGameObject.inventory[UnityBuiltins.parseInt(array3[k].Split("|"[0])[UnityScript.Lang.Extensions.get_length((System.Array)array3[k].Split("|"[0])) - 1])] == "false")
				{
					itemsBuy++;
				}
				if (AuthGameObject.inventory[UnityBuiltins.parseInt(array3[k].Split("|"[0])[UnityScript.Lang.Extensions.get_length((System.Array)array3[k].Split("|"[0])) - 1])] == "false")
				{
					itemsBought++;
				}
			}
			int l = 0;
			string[] array4 = cat4;
			for (int length4 = array4.Length; l < length4; l++)
			{
				if (UnityBuiltins.parseInt(array4[l].Split("|"[0])[UnityScript.Lang.Extensions.get_length((System.Array)array4[l].Split("|"[0])) - 2]) <= UnityBuiltins.parseInt(returnGold()) && AuthGameObject.inventory[UnityBuiltins.parseInt(array4[l].Split("|"[0])[UnityScript.Lang.Extensions.get_length((System.Array)array4[l].Split("|"[0])) - 1])] == "false")
				{
					itemsBuy++;
				}
				if (AuthGameObject.inventory[UnityBuiltins.parseInt(array4[l].Split("|"[0])[UnityScript.Lang.Extensions.get_length((System.Array)array4[l].Split("|"[0])) - 1])] == "false")
				{
					itemsBought++;
				}
			}
			int m = 0;
			string[] array5 = cat5;
			for (int length5 = array5.Length; m < length5; m++)
			{
				if (UnityBuiltins.parseInt(array5[m].Split("|"[0])[UnityScript.Lang.Extensions.get_length((System.Array)array5[m].Split("|"[0])) - 2]) <= UnityBuiltins.parseInt(returnGold()) && AuthGameObject.inventory[UnityBuiltins.parseInt(array5[m].Split("|"[0])[UnityScript.Lang.Extensions.get_length((System.Array)array5[m].Split("|"[0])) - 1])] == "false")
				{
					itemsBuy++;
				}
				if (AuthGameObject.inventory[UnityBuiltins.parseInt(array5[m].Split("|"[0])[UnityScript.Lang.Extensions.get_length((System.Array)array5[m].Split("|"[0])) - 1])] == "false")
				{
					itemsBought++;
				}
			}
			int n = 0;
			string[] array6 = cat6;
			for (int length6 = array6.Length; n < length6; n++)
			{
				if (UnityBuiltins.parseInt(array6[n].Split("|"[0])[UnityScript.Lang.Extensions.get_length((System.Array)array6[n].Split("|"[0])) - 2]) <= UnityBuiltins.parseInt(returnGold()) && AuthGameObject.inventory[UnityBuiltins.parseInt(array6[n].Split("|"[0])[UnityScript.Lang.Extensions.get_length((System.Array)array6[n].Split("|"[0])) - 1])] == "false")
				{
					itemsBuy++;
				}
				if (AuthGameObject.inventory[UnityBuiltins.parseInt(array6[n].Split("|"[0])[UnityScript.Lang.Extensions.get_length((System.Array)array6[n].Split("|"[0])) - 1])] == "false")
				{
					itemsBought++;
				}
			}
			itemsBought = UnityScript.Lang.Extensions.get_length((System.Array)AuthGameObject.inventory) - 3 - itemsBought;
		}
		if (offset2 == -290f && !(offset < -50f))
		{
			if (Input.GetKeyDown(KeyCode.RightArrow))
			{
				if (toolbarInt < UnityScript.Lang.Extensions.get_length((System.Array)categories) - 1)
				{
					toolbarInt++;
				}
				else
				{
					toolbarInt = 0;
				}
				itemsInt = 0;
			}
			if (Input.GetKeyDown(KeyCode.LeftArrow))
			{
				if (toolbarInt > 0)
				{
					toolbarInt--;
				}
				else
				{
					toolbarInt = UnityScript.Lang.Extensions.get_length((System.Array)categories) - 1;
				}
				itemsInt = 0;
			}
			int num = default(int);
			if (Input.GetKeyDown(KeyCode.DownArrow))
			{
				num = default(int);
				if (toolbarInt == 0)
				{
					num = UnityScript.Lang.Extensions.get_length((System.Array)cat1obj);
				}
				if (toolbarInt == 1)
				{
					num = UnityScript.Lang.Extensions.get_length((System.Array)cat2obj);
				}
				if (toolbarInt == 2)
				{
					num = UnityScript.Lang.Extensions.get_length((System.Array)cat3obj);
				}
				if (toolbarInt == 3)
				{
					num = UnityScript.Lang.Extensions.get_length((System.Array)cat4obj);
				}
				if (toolbarInt == 4)
				{
					num = UnityScript.Lang.Extensions.get_length((System.Array)cat5obj);
				}
				if (toolbarInt == 5)
				{
					num = UnityScript.Lang.Extensions.get_length((System.Array)cat6obj);
				}
				if (itemsInt < num - 1)
				{
					itemsInt++;
				}
				else
				{
					itemsInt = 0;
				}
			}
			if (Input.GetKeyDown(KeyCode.UpArrow))
			{
				if (toolbarInt == 0)
				{
					num = UnityScript.Lang.Extensions.get_length((System.Array)cat1obj);
				}
				if (toolbarInt == 1)
				{
					num = UnityScript.Lang.Extensions.get_length((System.Array)cat2obj);
				}
				if (toolbarInt == 2)
				{
					num = UnityScript.Lang.Extensions.get_length((System.Array)cat3obj);
				}
				if (toolbarInt == 3)
				{
					num = UnityScript.Lang.Extensions.get_length((System.Array)cat4obj);
				}
				if (toolbarInt == 4)
				{
					num = UnityScript.Lang.Extensions.get_length((System.Array)cat5obj);
				}
				if (toolbarInt == 5)
				{
					num = UnityScript.Lang.Extensions.get_length((System.Array)cat6obj);
				}
				if (itemsInt > 0)
				{
					itemsInt--;
				}
				else
				{
					itemsInt = num - 1;
				}
			}
		}
		GameObject[] array7 = new GameObject[0];
		if (offset2 != -290f)
		{
			bool flag = false;
			lastitemInt = -1;
			UnityScript.Lang.Array array8 = new UnityScript.Lang.Array();
			for (int num2 = 0; num2 < 5; num2++)
			{
				if (num2 == 1)
				{
					continue;
				}
				if (num2 == 2)
				{
					int num3 = 0;
					Renderer[] array9 = meshes;
					for (int length7 = array9.Length; num3 < length7; num3++)
					{
						UnityScript.Lang.Array array10 = new UnityScript.Lang.Array();
						int num4 = 0;
						Material[] sharedMaterials = array9[num3].sharedMaterials;
						for (int length8 = sharedMaterials.Length; num4 < length8; num4++)
						{
							if (sharedMaterials[num4].name.Contains("porsche-textured-default"))
							{
								array10.Add(sharedMaterials[num4]);
								if (RuntimeServices.ToBool(RuntimeServices.Invoke(equipped[num2], "Contains", new object[1] { "Gold" })))
								{
									array10.RemoveAt(array10.length - 1);
									array10.Add(goldmat);
								}
								if (RuntimeServices.ToBool(RuntimeServices.Invoke(equipped[num2], "Contains", new object[1] { "Platinum" })))
								{
									array10.RemoveAt(array10.length - 1);
									array10.Add(platinummat);
								}
								if (RuntimeServices.ToBool(RuntimeServices.Invoke(equipped[num2], "Contains", new object[1] { "Carbon" })))
								{
									array10.RemoveAt(array10.length - 1);
									array10.Add(carbonfibermat);
								}
								if (RuntimeServices.ToBool(RuntimeServices.Invoke(equipped[num2], "Contains", new object[1] { "Crystal" })))
								{
									array10.RemoveAt(array10.length - 1);
									array10.Add(crystalmat);
								}
								if (RuntimeServices.ToBool(RuntimeServices.Invoke(equipped[num2], "Contains", new object[1] { "Camouflage" })))
								{
									array10.RemoveAt(array10.length - 1);
									array10.Add(camomat);
								}
								if (RuntimeServices.ToBool(RuntimeServices.Invoke(equipped[num2], "Contains", new object[1] { "Rust" })))
								{
									array10.RemoveAt(array10.length - 1);
									array10.Add(rustmat);
								}
								if (RuntimeServices.ToBool(RuntimeServices.Invoke(equipped[num2], "Contains", new object[1] { "Neon" })))
								{
									array10.RemoveAt(array10.length - 1);
									array10.Add(neonmat);
								}
								if (RuntimeServices.ToBool(RuntimeServices.Invoke(equipped[num2], "Contains", new object[1] { "Aqua" })))
								{
									array10.RemoveAt(array10.length - 1);
									array10.Add(aquamat);
								}
								if (RuntimeServices.ToBool(RuntimeServices.Invoke(equipped[num2], "Contains", new object[1] { "Melee Ramming Blade Body" })))
								{
									array10.RemoveAt(array10.length - 1);
									array10.Add(defaultblack);
								}
								if (RuntimeServices.ToBool(RuntimeServices.Invoke(RuntimeServices.GetSlice(RuntimeServices.Invoke(equipped[num2], "Split", new object[1] { "-"[0] }), string.Empty, new object[1] { 1 }), "Contains", new object[1] { "false" })))
								{
									array10.RemoveAt(array10.length - 1);
									array10.Add(defaultblack);
								}
							}
							else
							{
								array10.Add(sharedMaterials[num4]);
							}
						}
						array9[num3].sharedMaterials = (Material[])array10.ToBuiltin(typeof(Material));
					}
				}
				int num5;
				if (RuntimeServices.ToBool(RuntimeServices.Invoke(equipped[num2], "Contains", new object[1] { "-" })))
				{
					if (RuntimeServices.EqualityOperator(RuntimeServices.GetSlice(RuntimeServices.Invoke(equipped[num2], "Split", new object[1] { "-"[0] }), string.Empty, new object[1] { 0 }), "false"))
					{
					}
					num5 = 0;
					int num6 = 0;
					string[] array11 = autharraytoformat;
					for (int length9 = array11.Length; num6 < length9; num6++)
					{
						if (RuntimeServices.EqualityOperator(array11[num6], RuntimeServices.GetSlice(RuntimeServices.Invoke(equipped[num2], "Split", new object[1] { "-"[0] }), string.Empty, new object[1] { 0 })))
						{
							array8.Add(num5);
							if (!equippedarray[num5].gameObject.active)
							{
								equippedarray[num5].gameObject.SetActiveRecursively(true);
							}
						}
						if (RuntimeServices.EqualityOperator(array11[num6], RuntimeServices.GetSlice(RuntimeServices.Invoke(equipped[num2], "Split", new object[1] { "-"[0] }), string.Empty, new object[1] { 1 })))
						{
							array8.Add(num5);
							if (!equippedarray[num5].gameObject.active)
							{
								equippedarray[num5].gameObject.SetActiveRecursively(true);
							}
						}
						num5++;
					}
					continue;
				}
				num5 = 0;
				int num7 = 0;
				string[] array12 = autharraytoformat;
				for (int length10 = array12.Length; num7 < length10; num7++)
				{
					if (RuntimeServices.EqualityOperator(array12[num7], equipped[num2]))
					{
						array8.Add(num5);
						if (!equippedarray[num5].gameObject.active)
						{
							equippedarray[num5].gameObject.SetActiveRecursively(true);
						}
						if (cat3obj[9].active)
						{
							if (equippedarray[num5].gameObject.name.Contains("Invincibilityitem"))
							{
								flag = true;
								if (cat3obj[9].renderer.enabled)
								{
									cat3obj[9].renderer.enabled = false;
								}
								if (equippedarray[num5].gameObject.active)
								{
									equippedarray[num5].gameObject.active = false;
								}
							}
						}
						else if (equippedarray[num5].gameObject.name.Contains("Invincibilityitem"))
						{
							flag = true;
							if (meshes[0].gameObject.active)
							{
								meshes[0].gameObject.active = false;
							}
							if (!equippedarray[num5].gameObject.active)
							{
								equippedarray[num5].gameObject.active = true;
							}
						}
					}
					num5++;
				}
			}
			int num8 = 0;
			int num9 = 0;
			GameObject[] array13 = equippedarray;
			for (int length11 = array13.Length; num9 < length11; num9++)
			{
				bool flag2 = true;
				IEnumerator enumerator = UnityRuntimeServices.GetEnumerator(array8);
				while (enumerator.MoveNext())
				{
					int num10 = RuntimeServices.UnboxInt32(enumerator.Current);
					if (num10 == num8)
					{
						flag2 = false;
					}
				}
				if (array13[num9] != null && flag2 && array13[num9].active)
				{
					array13[num9].SetActiveRecursively(false);
				}
				num8++;
			}
			if (!flag && !meshes[0].gameObject.active)
			{
				meshes[0].gameObject.active = true;
			}
		}
		else if (!(offset < -50f))
		{
			if (toolbarInt == 0)
			{
				array7 = cat1obj;
				int num11 = 0;
				GameObject[] array14 = cat2obj;
				for (int length12 = array14.Length; num11 < length12; num11++)
				{
					if (array14[num11].active)
					{
						array14[num11].SetActiveRecursively(false);
					}
				}
				int num12 = 0;
				GameObject[] array15 = cat3obj;
				for (int length13 = array15.Length; num12 < length13; num12++)
				{
					if (array15[num12].active)
					{
						array15[num12].SetActiveRecursively(false);
					}
				}
				int num13 = 0;
				GameObject[] array16 = cat4obj;
				for (int length14 = array16.Length; num13 < length14; num13++)
				{
					if (array16[num13].active)
					{
						array16[num13].SetActiveRecursively(false);
					}
				}
				int num14 = 0;
				GameObject[] array17 = cat5obj;
				for (int length15 = array17.Length; num14 < length15; num14++)
				{
					if (array17[num14].active)
					{
						array17[num14].SetActiveRecursively(false);
					}
				}
				int num15 = 0;
				GameObject[] array18 = cat6obj;
				for (int length16 = array18.Length; num15 < length16; num15++)
				{
					if (array18[num15].active)
					{
						array18[num15].SetActiveRecursively(false);
					}
				}
				if (previewCarMesh.layer != showLayer)
				{
					previewCarMesh.layer = showLayer;
					IEnumerator enumerator2 = UnityRuntimeServices.GetEnumerator(previewCarMesh.transform);
					while (enumerator2.MoveNext())
					{
						object obj = enumerator2.Current;
						if (!(obj is Transform))
						{
							obj = RuntimeServices.Coerce(obj, typeof(Transform));
						}
						Transform transform = (Transform)obj;
						transform.gameObject.layer = showLayer;
						UnityRuntimeServices.Update(enumerator2, transform);
					}
				}
			}
			if (toolbarInt == 1)
			{
				array7 = cat2obj;
				int num16 = 0;
				GameObject[] array19 = cat1obj;
				for (int length17 = array19.Length; num16 < length17; num16++)
				{
					if (array19[num16].active)
					{
						array19[num16].SetActiveRecursively(false);
					}
				}
				int num17 = 0;
				GameObject[] array20 = cat3obj;
				for (int length18 = array20.Length; num17 < length18; num17++)
				{
					if (array20[num17].active)
					{
						array20[num17].SetActiveRecursively(false);
					}
				}
				int num18 = 0;
				GameObject[] array21 = cat4obj;
				for (int length19 = array21.Length; num18 < length19; num18++)
				{
					if (array21[num18].active)
					{
						array21[num18].SetActiveRecursively(false);
					}
				}
				int num19 = 0;
				GameObject[] array22 = cat5obj;
				for (int length20 = array22.Length; num19 < length20; num19++)
				{
					if (array22[num19].active)
					{
						array22[num19].SetActiveRecursively(false);
					}
				}
				int num20 = 0;
				GameObject[] array23 = cat6obj;
				for (int length21 = array23.Length; num20 < length21; num20++)
				{
					if (array23[num20].active)
					{
						array23[num20].SetActiveRecursively(false);
					}
				}
				if (!maingun.active)
				{
					maingun.SetActiveRecursively(true);
				}
				if (previewCarMesh.layer != showLayer)
				{
					previewCarMesh.layer = showLayer;
					IEnumerator enumerator3 = UnityRuntimeServices.GetEnumerator(previewCarMesh.transform);
					while (enumerator3.MoveNext())
					{
						object obj2 = enumerator3.Current;
						if (!(obj2 is Transform))
						{
							obj2 = RuntimeServices.Coerce(obj2, typeof(Transform));
						}
						Transform transform2 = (Transform)obj2;
						transform2.gameObject.layer = showLayer;
						UnityRuntimeServices.Update(enumerator3, transform2);
					}
				}
			}
			if (toolbarInt == 2)
			{
				array7 = cat3obj;
				int num21 = 0;
				GameObject[] array24 = cat1obj;
				for (int length22 = array24.Length; num21 < length22; num21++)
				{
					if (array24[num21].active)
					{
						array24[num21].SetActiveRecursively(false);
					}
				}
				int num22 = 0;
				GameObject[] array25 = cat2obj;
				for (int length23 = array25.Length; num22 < length23; num22++)
				{
					if (array25[num22].active)
					{
						array25[num22].SetActiveRecursively(false);
					}
				}
				int num23 = 0;
				GameObject[] array26 = cat4obj;
				for (int length24 = array26.Length; num23 < length24; num23++)
				{
					if (array26[num23].active)
					{
						array26[num23].SetActiveRecursively(false);
					}
				}
				int num24 = 0;
				GameObject[] array27 = cat5obj;
				for (int length25 = array27.Length; num24 < length25; num24++)
				{
					if (array27[num24].active)
					{
						array27[num24].SetActiveRecursively(false);
					}
				}
				int num25 = 0;
				GameObject[] array28 = cat6obj;
				for (int length26 = array28.Length; num25 < length26; num25++)
				{
					if (array28[num25].active)
					{
						array28[num25].SetActiveRecursively(false);
					}
				}
				if (!maingun.active)
				{
					maingun.SetActiveRecursively(true);
				}
				if (previewCarMesh.layer != showLayer)
				{
					previewCarMesh.layer = showLayer;
					IEnumerator enumerator4 = UnityRuntimeServices.GetEnumerator(previewCarMesh.transform);
					while (enumerator4.MoveNext())
					{
						object obj3 = enumerator4.Current;
						if (!(obj3 is Transform))
						{
							obj3 = RuntimeServices.Coerce(obj3, typeof(Transform));
						}
						Transform transform3 = (Transform)obj3;
						transform3.gameObject.layer = showLayer;
						UnityRuntimeServices.Update(enumerator4, transform3);
					}
				}
			}
			if (toolbarInt == 3)
			{
				array7 = cat4obj;
				int num26 = 0;
				GameObject[] array29 = cat1obj;
				for (int length27 = array29.Length; num26 < length27; num26++)
				{
					if (array29[num26].active)
					{
						array29[num26].SetActiveRecursively(false);
					}
				}
				int num27 = 0;
				GameObject[] array30 = cat2obj;
				for (int length28 = array30.Length; num27 < length28; num27++)
				{
					if (array30[num27].active)
					{
						array30[num27].SetActiveRecursively(false);
					}
				}
				int num28 = 0;
				GameObject[] array31 = cat3obj;
				for (int length29 = array31.Length; num28 < length29; num28++)
				{
					if (array31[num28].active)
					{
						array31[num28].SetActiveRecursively(false);
					}
				}
				int num29 = 0;
				GameObject[] array32 = cat5obj;
				for (int length30 = array32.Length; num29 < length30; num29++)
				{
					if (array32[num29].active)
					{
						array32[num29].SetActiveRecursively(false);
					}
				}
				int num30 = 0;
				GameObject[] array33 = cat6obj;
				for (int length31 = array33.Length; num30 < length31; num30++)
				{
					if (array33[num30].active)
					{
						array33[num30].SetActiveRecursively(false);
					}
				}
				if (!maingun.active)
				{
					maingun.SetActiveRecursively(true);
				}
				if (previewCarMesh.layer != showLayer)
				{
					previewCarMesh.layer = showLayer;
					IEnumerator enumerator5 = UnityRuntimeServices.GetEnumerator(previewCarMesh.transform);
					while (enumerator5.MoveNext())
					{
						object obj4 = enumerator5.Current;
						if (!(obj4 is Transform))
						{
							obj4 = RuntimeServices.Coerce(obj4, typeof(Transform));
						}
						Transform transform4 = (Transform)obj4;
						transform4.gameObject.layer = showLayer;
						UnityRuntimeServices.Update(enumerator5, transform4);
					}
				}
			}
			if (toolbarInt == 4)
			{
				array7 = cat5obj;
				int num31 = 0;
				GameObject[] array34 = cat1obj;
				for (int length32 = array34.Length; num31 < length32; num31++)
				{
					if (array34[num31].active)
					{
						array34[num31].SetActiveRecursively(false);
					}
				}
				int num32 = 0;
				GameObject[] array35 = cat2obj;
				for (int length33 = array35.Length; num32 < length33; num32++)
				{
					if (array35[num32].active)
					{
						array35[num32].SetActiveRecursively(false);
					}
				}
				int num33 = 0;
				GameObject[] array36 = cat3obj;
				for (int length34 = array36.Length; num33 < length34; num33++)
				{
					if (array36[num33].active)
					{
						array36[num33].SetActiveRecursively(false);
					}
				}
				int num34 = 0;
				GameObject[] array37 = cat4obj;
				for (int length35 = array37.Length; num34 < length35; num34++)
				{
					if (array37[num34].active)
					{
						array37[num34].SetActiveRecursively(false);
					}
				}
				int num35 = 0;
				GameObject[] array38 = cat6obj;
				for (int length36 = array38.Length; num35 < length36; num35++)
				{
					if (array38[num35].active)
					{
						array38[num35].SetActiveRecursively(false);
					}
				}
				if (!maingun.active)
				{
					maingun.SetActiveRecursively(true);
				}
			}
			if (toolbarInt == 5)
			{
				array7 = cat6obj;
				int num36 = 0;
				GameObject[] array39 = cat1obj;
				for (int length37 = array39.Length; num36 < length37; num36++)
				{
					if (array39[num36].active)
					{
						array39[num36].SetActiveRecursively(false);
					}
				}
				int num37 = 0;
				GameObject[] array40 = cat2obj;
				for (int length38 = array40.Length; num37 < length38; num37++)
				{
					if (array40[num37].active)
					{
						array40[num37].SetActiveRecursively(false);
					}
				}
				int num38 = 0;
				GameObject[] array41 = cat3obj;
				for (int length39 = array41.Length; num38 < length39; num38++)
				{
					if (array41[num38].active)
					{
						array41[num38].SetActiveRecursively(false);
					}
				}
				int num39 = 0;
				GameObject[] array42 = cat4obj;
				for (int length40 = array42.Length; num39 < length40; num39++)
				{
					if (array42[num39].active)
					{
						array42[num39].SetActiveRecursively(false);
					}
				}
				int num40 = 0;
				GameObject[] array43 = cat5obj;
				for (int length41 = array43.Length; num40 < length41; num40++)
				{
					if (array43[num40].active)
					{
						array43[num40].SetActiveRecursively(false);
					}
				}
				if (!maingun.active)
				{
					maingun.SetActiveRecursively(true);
				}
			}
			if (gtrinvinc.active)
			{
				gtrinvinc.active = false;
			}
			int num41 = 0;
			if (itemsInt != lastitemInt || toolbarInt != lastToolbarInt)
			{
				lastitemInt = itemsInt;
				int num42 = 0;
				GameObject[] array44 = array7;
				for (int length42 = array44.Length; num42 < length42; num42++)
				{
					if (num41 != itemsInt)
					{
						if (array44[num42].active)
						{
							array44[num42].SetActiveRecursively(false);
						}
					}
					else
					{
						if (array44[num42].name.Contains("bodykit"))
						{
							int num43 = 0;
							Renderer[] array45 = meshes;
							for (int length43 = array45.Length; num43 < length43; num43++)
							{
								UnityScript.Lang.Array array10 = new UnityScript.Lang.Array();
								int num44 = 0;
								Material[] sharedMaterials2 = array45[num43].sharedMaterials;
								for (int length44 = sharedMaterials2.Length; num44 < length44; num44++)
								{
									if (sharedMaterials2[num44].name.Contains("porsche-textured-default"))
									{
										if (array44[num42].name.Contains("gold"))
										{
											array10.Add(goldmat);
										}
										if (array44[num42].name.Contains("platinum"))
										{
											array10.Add(platinummat);
										}
										if (array44[num42].name.Contains("carbon"))
										{
											array10.Add(carbonfibermat);
										}
										if (array44[num42].name.Contains("crystal"))
										{
											array10.Add(crystalmat);
										}
										if (array44[num42].name.Contains("camo"))
										{
											array10.Add(camomat);
										}
										if (array44[num42].name.Contains("rust"))
										{
											array10.Add(rustmat);
										}
										if (array44[num42].name.Contains("neon"))
										{
											array10.Add(neonmat);
										}
										if (array44[num42].name.Contains("aqua"))
										{
											array10.Add(aquamat);
										}
										if (!array44[num42].name.Contains("melee"))
										{
											continue;
										}
										int num45 = 0;
										Renderer[] array46 = meshes;
										for (int length45 = array46.Length; num45 < length45; num45++)
										{
											array10 = new UnityScript.Lang.Array();
											int num46 = 0;
											Material[] sharedMaterials3 = array46[num45].sharedMaterials;
											for (int length46 = sharedMaterials3.Length; num46 < length46; num46++)
											{
												if (sharedMaterials3[num46].name.Contains("porsche-textured-default"))
												{
													array10.Add(defaultblack);
												}
												else
												{
													array10.Add(sharedMaterials3[num46]);
												}
											}
											array46[num45].sharedMaterials = (Material[])array10.ToBuiltin(typeof(Material));
										}
									}
									else
									{
										array10.Add(sharedMaterials2[num44]);
									}
								}
								array45[num43].sharedMaterials = (Material[])array10.ToBuiltin(typeof(Material));
							}
						}
						else
						{
							int num47 = 0;
							Renderer[] array47 = meshes;
							for (int length47 = array47.Length; num47 < length47; num47++)
							{
								UnityScript.Lang.Array array10 = new UnityScript.Lang.Array();
								int num48 = 0;
								Material[] sharedMaterials4 = array47[num47].sharedMaterials;
								for (int length48 = sharedMaterials4.Length; num48 < length48; num48++)
								{
									if (sharedMaterials4[num48].name.Contains("porsche-textured-default"))
									{
										array10.Add(defaultblack);
									}
									else
									{
										array10.Add(sharedMaterials4[num48]);
									}
								}
								array47[num47].sharedMaterials = (Material[])array10.ToBuiltin(typeof(Material));
							}
						}
						if (!meshes[0].gameObject.active)
						{
							meshes[0].gameObject.active = true;
						}
						if (array44[num42].name == "_GTRCarPrefab")
						{
							if (meshes[0].enabled)
							{
								meshes[0].enabled = false;
							}
							if (meshes[24].enabled)
							{
								meshes[24].enabled = false;
							}
							if (meshes[25].enabled)
							{
								meshes[25].enabled = false;
							}
							if (meshes[26].enabled)
							{
								meshes[26].enabled = false;
							}
							if (meshes[27].enabled)
							{
								meshes[27].enabled = false;
							}
						}
						else if (array44[num42].name == "Invincibilityitem")
						{
							if (meshes[0].enabled)
							{
								meshes[0].enabled = false;
							}
							if (!meshes[24].enabled)
							{
								meshes[24].enabled = true;
							}
							if (!meshes[25].enabled)
							{
								meshes[25].enabled = true;
							}
							if (!meshes[26].enabled)
							{
								meshes[26].enabled = true;
							}
							if (!meshes[27].enabled)
							{
								meshes[27].enabled = true;
							}
						}
						else
						{
							if (!meshes[0].enabled)
							{
								meshes[0].enabled = true;
							}
							if (!meshes[24].enabled)
							{
								meshes[24].enabled = true;
							}
							if (!meshes[25].enabled)
							{
								meshes[25].enabled = true;
							}
							if (!meshes[26].enabled)
							{
								meshes[26].enabled = true;
							}
							if (!meshes[27].enabled)
							{
								meshes[27].enabled = true;
							}
						}
						if (!array44[num42].gameObject.active)
						{
							array44[num42].gameObject.SetActiveRecursively(true);
							array44[num42].layer = 9;
						}
						if ((Renderer)array44[num42].GetComponent(typeof(Renderer)) != null && !array44[num42].renderer.enabled)
						{
							array44[num42].renderer.enabled = true;
						}
					}
					num41++;
				}
			}
		}
		else
		{
			int num49 = 0;
			GameObject[] array48 = cat1obj;
			for (int length49 = array48.Length; num49 < length49; num49++)
			{
				if (array48[num49].active)
				{
					array48[num49].SetActiveRecursively(false);
				}
			}
			int num50 = 0;
			GameObject[] array49 = cat2obj;
			for (int length50 = array49.Length; num50 < length50; num50++)
			{
				if (array49[num50].active)
				{
					array49[num50].SetActiveRecursively(false);
				}
			}
			int num51 = 0;
			GameObject[] array50 = cat3obj;
			for (int length51 = array50.Length; num51 < length51; num51++)
			{
				if (array50[num51].active)
				{
					array50[num51].SetActiveRecursively(false);
				}
			}
			int num52 = 0;
			GameObject[] array51 = cat4obj;
			for (int length52 = array51.Length; num52 < length52; num52++)
			{
				if (array51[num52].active)
				{
					array51[num52].SetActiveRecursively(false);
				}
			}
			int num53 = 0;
			GameObject[] array52 = cat5obj;
			for (int length53 = array52.Length; num53 < length53; num53++)
			{
				if (array52[num53].active)
				{
					array52[num53].SetActiveRecursively(false);
				}
			}
			int num54 = 0;
			GameObject[] array53 = cat6obj;
			for (int length54 = array53.Length; num54 < length54; num54++)
			{
				if (array53[num54].active)
				{
					array53[num54].SetActiveRecursively(false);
				}
			}
			if (previewCarMesh.layer != showLayer)
			{
				previewCarMesh.layer = showLayer;
				IEnumerator enumerator6 = UnityRuntimeServices.GetEnumerator(previewCarMesh.transform);
				while (enumerator6.MoveNext())
				{
					object obj5 = enumerator6.Current;
					if (!(obj5 is Transform))
					{
						obj5 = RuntimeServices.Coerce(obj5, typeof(Transform));
					}
					Transform transform5 = (Transform)obj5;
					transform5.gameObject.layer = showLayer;
					UnityRuntimeServices.Update(enumerator6, transform5);
				}
			}
			int num55 = 0;
			Renderer[] array54 = meshes;
			for (int length55 = array54.Length; num55 < length55; num55++)
			{
				UnityScript.Lang.Array array10 = new UnityScript.Lang.Array();
				int num56 = 0;
				Material[] sharedMaterials5 = array54[num55].sharedMaterials;
				for (int length56 = sharedMaterials5.Length; num56 < length56; num56++)
				{
					if (sharedMaterials5[num56].name.Contains("porsche-textured-default"))
					{
						array10.Add(defaultblack);
					}
					else
					{
						array10.Add(sharedMaterials5[num56]);
					}
				}
				array54[num55].sharedMaterials = (Material[])array10.ToBuiltin(typeof(Material));
			}
			if (!meshes[0].enabled)
			{
				meshes[0].enabled = true;
			}
			if (!maingun.active)
			{
				maingun.SetActiveRecursively(true);
			}
		}
		if (fadetool)
		{
			if (!(toolalpha >= 1f))
			{
				toolalpha += 4f * Time.deltaTime;
			}
			else
			{
				toolalpha = 1f;
			}
		}
		else if (!(toolalpha <= 0f))
		{
			toolalpha -= 4f * Time.deltaTime;
		}
		else
		{
			toolalpha = 0f;
		}
	}

	public virtual void OnGUI()
	{
		if (!AuthGameObject.shop)
		{
			return;
		}
		GUI.depth = 4;
		GUI.skin = scrollstyle;
		if (offset2 != -290f || rentalpha != 0f || creditalpha != 0f)
		{
			GUI.enabled = false;
		}
		if (offset == 0f - ((float)Screen.height + 5f))
		{
			return;
		}
		GUI.BeginGroup(new Rect(0f, offset, Screen.width, Screen.height));
		int num = toolbarInt;
		toolbarInt = GUI.SelectionGrid(new Rect(20f, 80f, 135f, 230f), toolbarInt, categories, 1, toolbarbuttons);
		GUI.EndGroup();
		GUI.BeginGroup(new Rect(0f, offset + 25f, Screen.width, Screen.height));
		if (num != toolbarInt)
		{
			itemsInt = 0;
		}
		string[] array = new string[0];
		if (toolbarInt == 0)
		{
			array = cat1;
		}
		if (toolbarInt == 1)
		{
			array = cat2;
		}
		if (toolbarInt == 2)
		{
			array = cat3;
		}
		if (toolbarInt == 3)
		{
			array = cat4;
		}
		if (toolbarInt == 4)
		{
			array = cat5;
		}
		if (toolbarInt == 5)
		{
			array = cat6;
		}
		GUI.BeginGroup(new Rect(158f, 45f, Screen.width / 2 - 15 - 135, 250f));
		GUI.Box(new Rect(0f, 0f, Screen.width / 2 - 15 - 135, 250f), "Available Items", shopwindow);
		int num2 = default(int);
		num2 = UnityScript.Lang.Extensions.get_length((System.Array)array) * 50;
		scrollPosition = GUI.BeginScrollView(new Rect(20f, 40f, Screen.width / 2 - 50 - 135, 190f), scrollPosition, new Rect(0f, 0f, Screen.width / 2 - 80 - 135, num2));
		int num3 = 5;
		num3 = ((num2 <= 190) ? 5 : 25);
		string[] array2 = null;
		int num4 = 0;
		array2 = new string[UnityScript.Lang.Extensions.get_length((System.Array)array)];
		int i = 0;
		string[] array3 = array;
		for (int length = array3.Length; i < length; i++)
		{
			string text = array3[i].Split("|"[0])[0];
			array2[num4] = text;
			int num5 = UnityBuiltins.parseInt(array3[i].Split("|"[0])[UnityScript.Lang.Extensions.get_length((System.Array)array3[i].Split("|"[0])) - 1]);
			if (itemicons[num5].width != 171 && itemicons[num5].height != 171)
			{
				GUI.DrawTexture(new Rect(0f, 4 + num4 * 50, 50f, 50f), hasImage);
				GUI.DrawTexture(new Rect(4f, (float)(4 + num4 * 50) + (50f - 42f / (float)itemicons[num5].width * (float)itemicons[num5].height) / 2f, 42f, 42f / (float)itemicons[num5].width * (float)itemicons[num5].height), itemicons[num5]);
			}
			else
			{
				GUI.DrawTexture(new Rect(0f, 4 + num4 * 50, 50f, 50f), itemicons[num5]);
			}
			num4++;
		}
		string[] texts = array2;
		itemsInt = GUI.SelectionGrid(new Rect(50f, 0f, Screen.width / 2 - 50 - num3 - 50 - 135, num2), itemsInt, texts, 1, itemsStyle);
		GUI.EndScrollView();
		GUI.EndGroup();
		GUI.BeginGroup(new Rect(Screen.width - 15 - (Screen.width / 2 - 15), 45f, Screen.width / 2 - 15, 250f));
		GUI.Box(new Rect(0f, 0f, Screen.width / 2 - 15, 250f), "Item Details", shopwindow);
		if (toolbarInt == 1)
		{
			GUI.Label(new Rect(20f, 35f, Screen.width / 2 - 15 - 40, 52f), array[itemsInt].Split("|"[0])[1] + " (Press [m] in-game to deploy).", labelstyle);
		}
		else if (toolbarInt == 2)
		{
			GUI.Label(new Rect(20f, 35f, Screen.width / 2 - 15 - 40, 52f), array[itemsInt].Split("|"[0])[1] + " (Can be applied under armor).", labelstyle);
		}
		else
		{
			GUI.Label(new Rect(20f, 35f, Screen.width / 2 - 15 - 40, 52f), array[itemsInt].Split("|"[0])[1], labelstyle);
		}
		if (toolbarInt == 0)
		{
			int num6 = (Screen.width / 2 - 111) / 4;
			float width = UnityBuiltins.parseFloat(array[itemsInt].Split("|"[0])[2]) / 10f * (float)num6 - 2f;
			GUI.Label(new Rect(33f, 115f, num6, 25f), "Damage", labelstyle2);
			GUI.DrawTexture(new Rect(33f, 100f, num6, 17f), bars[0]);
			GUI.DrawTexture(new Rect(34f, 101f, width, 15f), bars[1]);
			float width2 = UnityBuiltins.parseFloat(array[itemsInt].Split("|"[0])[3]) / 10f * (float)num6 - 2f;
			GUI.Label(new Rect(33 + num6 + 10, 115f, num6, 25f), "Accuracy", labelstyle2);
			GUI.DrawTexture(new Rect(33 + num6 + 10, 100f, num6, 17f), bars[0]);
			GUI.DrawTexture(new Rect(33 + num6 + 10 + 1, 101f, width2, 15f), bars[1]);
			float num7 = UnityBuiltins.parseFloat(array[itemsInt].Split("|"[0])[4]) / 10f * (float)num6 - 2f;
			if (!(num7 >= 0f))
			{
				num7 = 0f;
			}
			GUI.Label(new Rect(33 + 2 * num6 + 20, 115f, num6, 25f), "Area Damage", labelstyle2);
			GUI.DrawTexture(new Rect(33 + 2 * num6 + 20, 100f, num6, 17f), bars[0]);
			GUI.DrawTexture(new Rect(33 + 2 * num6 + 20 + 1, 101f, num7, 15f), bars[1]);
			float width3 = UnityBuiltins.parseFloat(array[itemsInt].Split("|"[0])[5]) / 10f * (float)num6 - 2f;
			GUI.Label(new Rect(33 + 3 * num6 + 30, 115f, num6, 25f), "Rate of Fire", labelstyle2);
			GUI.DrawTexture(new Rect(33 + 3 * num6 + 30, 100f, num6, 17f), bars[0]);
			GUI.DrawTexture(new Rect(33 + 3 * num6 + 30 + 1, 101f, width3, 15f), bars[1]);
			GUI.DrawTexture(new Rect(35f, 155f, 25f, 25f), gold[0]);
			GUI.Label(new Rect(80f, 155f, 1f, 25f), "Costs " + Mathf.Round((float)UnityBuiltins.parseInt(array[itemsInt].Split("|"[0])[6]) * 0.1f).ToString() + " credits for one day", labelstyle3);
			GUI.DrawTexture(new Rect(35f, 190f, 33f, 25f), gold[1]);
			GUI.Label(new Rect(80f, 190f, 1f, 25f), "You have " + returnGold() + " credits", labelstyle3);
			string text2 = "Buy Item";
			if (array[itemsInt].Split("|"[0])[6] == "0")
			{
				GUI.enabled = false;
				text2 = "(Default Item)";
			}
			if (AuthGameObject.inventory[UnityBuiltins.parseInt(array[itemsInt].Split("|"[0])[7])] != "false")
			{
				GUI.enabled = false;
				text2 = "(Already Bought)";
			}
			if (offset2 != -290f)
			{
				GUI.enabled = false;
			}
			if (isbuying)
			{
				GUI.enabled = false;
			}
			if (GUI.Button(new Rect(Screen.width / 2 - 15 - 100 - 52, 190f, 120f, 25f), text2, buttonstyle))
			{
				baseCost = UnityBuiltins.parseInt(array[itemsInt].Split("|"[0])[6]);
				itemIndex = UnityBuiltins.parseInt(array[itemsInt].Split("|"[0])[7]);
				isRenewing = false;
				StartCoroutine_Auto(fadeInRent());
			}
			GUI.enabled = true;
			if (offset2 != -290f)
			{
				GUI.enabled = false;
			}
		}
		if (toolbarInt == 4)
		{
			int num6 = (Screen.width / 2 - 111) / 4;
			float width4 = UnityBuiltins.parseFloat(array[itemsInt].Split("|"[0])[2]) / 10f * (float)num6 - 2f;
			GUI.Label(new Rect(33f, 115f, num6, 25f), "Top Speed", labelstyle2);
			GUI.DrawTexture(new Rect(33f, 100f, num6, 17f), bars[0]);
			GUI.DrawTexture(new Rect(34f, 101f, width4, 15f), bars[1]);
			float width5 = UnityBuiltins.parseFloat(array[itemsInt].Split("|"[0])[3]) / 10f * (float)num6 - 2f;
			GUI.Label(new Rect(33 + num6 + 10, 115f, num6, 25f), "Handling", labelstyle2);
			GUI.DrawTexture(new Rect(33 + num6 + 10, 100f, num6, 17f), bars[0]);
			GUI.DrawTexture(new Rect(33 + num6 + 10 + 1, 101f, width5, 15f), bars[1]);
			float width6 = UnityBuiltins.parseFloat(array[itemsInt].Split("|"[0])[4]) / 10f * (float)num6 - 2f;
			GUI.Label(new Rect(33 + 2 * num6 + 20, 115f, num6, 25f), "Acceleration", labelstyle2);
			GUI.DrawTexture(new Rect(33 + 2 * num6 + 20, 100f, num6, 17f), bars[0]);
			GUI.DrawTexture(new Rect(33 + 2 * num6 + 20 + 1, 101f, width6, 15f), bars[1]);
			float width7 = UnityBuiltins.parseFloat(array[itemsInt].Split("|"[0])[5]) / 10f * (float)num6 - 2f;
			GUI.Label(new Rect(33 + 3 * num6 + 30, 115f, num6, 25f), "Flying Agil.", labelstyle2);
			GUI.DrawTexture(new Rect(33 + 3 * num6 + 30, 100f, num6, 17f), bars[0]);
			GUI.DrawTexture(new Rect(33 + 3 * num6 + 30 + 1, 101f, width7, 15f), bars[1]);
			GUI.DrawTexture(new Rect(35f, 155f, 25f, 25f), gold[0]);
			GUI.Label(new Rect(80f, 155f, 1f, 25f), "Costs " + Mathf.Round((float)UnityBuiltins.parseInt(array[itemsInt].Split("|"[0])[6]) * 0.1f).ToString() + " credits for one day", labelstyle3);
			GUI.DrawTexture(new Rect(35f, 190f, 33f, 25f), gold[1]);
			GUI.Label(new Rect(80f, 190f, 1f, 25f), "You have " + returnGold() + " credits", labelstyle3);
			string text2 = "Buy Item";
			if (array[itemsInt].Split("|"[0])[6] == "0")
			{
				GUI.enabled = false;
				text2 = "(Default Item)";
			}
			if (AuthGameObject.inventory[UnityBuiltins.parseInt(array[itemsInt].Split("|"[0])[7])] != "false")
			{
				GUI.enabled = false;
				text2 = "(Already Bought)";
			}
			if (offset2 != -290f)
			{
				GUI.enabled = false;
			}
			if (isbuying)
			{
				GUI.enabled = false;
			}
			if (GUI.Button(new Rect(Screen.width / 2 - 15 - 100 - 52, 190f, 120f, 25f), text2, buttonstyle))
			{
				baseCost = UnityBuiltins.parseInt(array[itemsInt].Split("|"[0])[6]);
				itemIndex = UnityBuiltins.parseInt(array[itemsInt].Split("|"[0])[7]);
				isRenewing = false;
				StartCoroutine_Auto(fadeInRent());
			}
			GUI.enabled = true;
			if (offset2 != -290f)
			{
				GUI.enabled = false;
			}
		}
		if (toolbarInt == 2 || toolbarInt == 3)
		{
			float width8 = UnityBuiltins.parseFloat(array[itemsInt].Split("|"[0])[2]) / 100f * (float)(Screen.width / 2 - 15 - 68);
			string text3 = "Protection";
			if (array[itemsInt].Split("|"[0])[0].Contains("Melee"))
			{
				text3 = "Melee Damage";
			}
			GUI.Label(new Rect(33f, 115f, Screen.width / 2 - 15 - 66, 25f), text3, labelstyle2);
			GUI.Box(new Rect(33f, 100f, Screen.width / 2 - 15 - 66, 17f), string.Empty, bars1);
			GUI.Box(new Rect(34f, 101f, width8, 15f), string.Empty, bars2);
			if (toolbarInt == 2)
			{
				GUI.DrawTexture(new Rect(35f, 155f, 25f, 25f), gold[2]);
				GUI.Label(new Rect(80f, 155f, 1f, 25f), "This item costs " + array[itemsInt].Split("|"[0])[3] + " premium credits", labelstyle3p);
				GUI.DrawTexture(new Rect(35f, 190f, 33f, 25f), gold[3]);
				GUI.Label(new Rect(80f, 190f, 1f, 25f), "You have " + returnGoldPrem() + " prem. credits", labelstyle3p);
			}
			else
			{
				GUI.DrawTexture(new Rect(35f, 155f, 25f, 25f), gold[0]);
				GUI.Label(new Rect(80f, 155f, 1f, 25f), "This item costs " + array[itemsInt].Split("|"[0])[3] + " credits", labelstyle3);
				GUI.DrawTexture(new Rect(35f, 190f, 33f, 25f), gold[1]);
				GUI.Label(new Rect(80f, 190f, 1f, 25f), "You have " + returnGold() + " credits", labelstyle3);
			}
			string text2 = "Buy Item";
			if (array[itemsInt].Split("|"[0])[3] == "0")
			{
				GUI.enabled = false;
				text2 = "(Default Item)";
			}
			if (AuthGameObject.inventory[UnityBuiltins.parseInt(array[itemsInt].Split("|"[0])[4])] != "false")
			{
				GUI.enabled = false;
				text2 = "(Already Bought)";
			}
			if (isbuying)
			{
				GUI.enabled = false;
			}
			if (GUI.Button(new Rect(Screen.width / 2 - 15 - 100 - 52, 190f, 120f, 25f), text2, buttonstyle))
			{
				if (toolbarInt != 2)
				{
					baseCost = UnityBuiltins.parseInt(array[itemsInt].Split("|"[0])[3]);
					itemIndex = UnityBuiltins.parseInt(array[itemsInt].Split("|"[0])[4]);
					isRenewing = false;
					StartCoroutine_Auto(fadeInRent());
				}
				else
				{
					baseCost = UnityBuiltins.parseInt(array[itemsInt].Split("|"[0])[3]);
					itemIndex = UnityBuiltins.parseInt(array[itemsInt].Split("|"[0])[4]);
					if (UnityBuiltins.parseInt(returnGoldPrem()) >= UnityBuiltins.parseInt(array[itemsInt].Split("|"[0])[3]))
					{
						StartCoroutine_Auto(buyItemPrem(itemIndex, baseCost, 999));
					}
					else
					{
						StartCoroutine_Auto(fadeInCredits());
					}
				}
			}
			GUI.enabled = true;
		}
		if (toolbarInt == 1)
		{
			float width9 = UnityBuiltins.parseFloat(array[itemsInt].Split("|"[0])[2]) / 100f * (float)((Screen.width / 2 - 15) / 2 - 42);
			string text4 = "Damage";
			if (array[itemsInt].Split("|"[0])[0].Contains("Item"))
			{
				text4 = "Resiliency";
			}
			GUI.Label(new Rect(33f, 115f, (Screen.width / 2 - 15) / 2 - 40, 17f), text4, labelstyle2);
			GUI.Box(new Rect(33f, 100f, (Screen.width / 2 - 15) / 2 - 40, 17f), string.Empty, bars1);
			GUI.Box(new Rect(34f, 101f, width9, 15f), string.Empty, bars2);
			float width10 = UnityBuiltins.parseFloat(array[itemsInt].Split("|"[0])[3]) / 10f * (float)((Screen.width / 2 - 15) / 2 - 42);
			string text5 = "Area Damage";
			if (array[itemsInt].Split("|"[0])[0].Contains("Item"))
			{
				text5 = "Melee Damage";
			}
			GUI.Label(new Rect((Screen.width / 2 - 15) / 2 + 10, 115f, (Screen.width / 2 - 15) / 2 - 40, 17f), text5, labelstyle2);
			GUI.Box(new Rect((Screen.width / 2 - 15) / 2 + 10, 100f, (Screen.width / 2 - 15) / 2 - 40, 17f), string.Empty, bars1);
			GUI.Box(new Rect((Screen.width / 2 - 15) / 2 + 11, 101f, width10, 15f), string.Empty, bars2);
			GUI.DrawTexture(new Rect(35f, 155f, 25f, 25f), gold[0]);
			GUI.Label(new Rect(80f, 155f, 1f, 25f), "This item costs " + array[itemsInt].Split("|"[0])[4] + " credits", labelstyle3);
			GUI.DrawTexture(new Rect(35f, 190f, 33f, 25f), gold[1]);
			GUI.Label(new Rect(80f, 190f, 1f, 25f), "You have " + returnGold() + " credits", labelstyle3);
			string text2 = "Buy Item";
			if (array[itemsInt].Split("|"[0])[4] == "0")
			{
				GUI.enabled = false;
				text2 = "(Default Item)";
			}
			if (AuthGameObject.inventory[UnityBuiltins.parseInt(array[itemsInt].Split("|"[0])[5])] != "false")
			{
				GUI.enabled = false;
				text2 = "(Already Bought)";
			}
			if (isbuying)
			{
				GUI.enabled = false;
			}
			if (GUI.Button(new Rect(Screen.width / 2 - 15 - 100 - 52, 190f, 120f, 25f), text2, buttonstyle))
			{
				baseCost = UnityBuiltins.parseInt(array[itemsInt].Split("|"[0])[4]);
				itemIndex = UnityBuiltins.parseInt(array[itemsInt].Split("|"[0])[5]);
				isRenewing = false;
				StartCoroutine_Auto(fadeInRent());
			}
			GUI.enabled = true;
		}
		GUI.EndGroup();
		GUI.enabled = true;
		if (offset2 != -290f)
		{
			GUI.enabled = false;
		}
		if (GUI.Button(new Rect(20f, 295f, 150f, 30f), "Reload Store", buttonstyle))
		{
			Camera.main.SendMessage("backToMenuReload");
		}
		GUI.enabled = true;
		string text6 = "Equip and Upgrade";
		if (offset2 == 0f)
		{
			text6 = "Close Window";
		}
		if (GUI.Button(new Rect(Screen.width - 26 - 150, 295f, 150f, 30f), text6, buttonstyle))
		{
			if (offset2 == -290f)
			{
				StartCoroutine_Auto(showEquip(true));
			}
			if (offset2 == 0f)
			{
				StartCoroutine_Auto(showEquip(false));
			}
		}
		GUI.EndGroup();
		if (offset2 != -290f)
		{
			GUI.BeginGroup(new Rect(30f, offset2 + 30f, Screen.width - 60, 275f));
			GUI.Box(new Rect(0f, 0f, Screen.width - 60, 275f), "Equip and Upgrade", equipbackground);
			Rect position = new Rect(20f, 45f, (Screen.width - 60) / 2 - 25, 220f);
			GUI.BeginGroup(position);
			GUI.Box(new Rect(0f, 0f, (Screen.width - 60) / 2 - 25, 220f), "Inventory", shopwindow);
			GUI.SetNextControlName("searchfield");
			searchstring = GUI.TextField(new Rect(20f, 15f, ((Screen.width - 60) / 2 - 25) / 2 - 60, 20f), searchstring);
			if (GUI.GetNameOfFocusedControl() == "searchfield" && searchstring == "Search...")
			{
				searchstring = string.Empty;
			}
			else if (GUI.GetNameOfFocusedControl() != "searchfield" && searchstring.Replace(" ", string.Empty) == string.Empty)
			{
				searchstring = "Search...";
			}
			string[] array4 = null;
			UnityScript.Lang.Array array5 = new UnityScript.Lang.Array();
			UnityScript.Lang.Array array6 = new UnityScript.Lang.Array();
			UnityScript.Lang.Array array7 = new UnityScript.Lang.Array();
			int num8 = 0;
			int j = 0;
			string[] inventory = AuthGameObject.inventory;
			for (int length2 = inventory.Length; j < length2; j++)
			{
				if (num8 > 2 && inventory[j] != "false" && num8 != 45)
				{
					if (searchstring == "Search...")
					{
						array5.Add(autharraytoformat[num8]);
						array6.Add(AuthGameObject.rentarr[num8]);
						array7.Add(num8);
					}
					else if (autharraytoformat[num8].ToLower().Contains(searchstring.ToLower()))
					{
						array5.Add(autharraytoformat[num8]);
						array6.Add(AuthGameObject.rentarr[num8]);
						array7.Add(num8);
					}
				}
				num8++;
			}
			if (searchstring != "Search..." && array5.length == 0)
			{
				array5 = new UnityScript.Lang.Array();
				num8 = 0;
				int k = 0;
				string[] inventory2 = AuthGameObject.inventory;
				for (int length3 = inventory2.Length; k < length3; k++)
				{
					if (num8 > 2 && inventory2[k] != "false" && num8 != 45)
					{
						array5.Add(autharraytoformat[num8]);
						array6.Add(AuthGameObject.rentarr[num8]);
						array7.Add(num8);
					}
					num8++;
				}
			}
			if (inInt > array5.length - 1)
			{
				inInt = 0;
			}
			array4 = (string[])array5.ToBuiltin(typeof(string));
			num2 = UnityScript.Lang.Extensions.get_length((System.Array)array4) * 50;
			scrollPosition2 = GUI.BeginScrollView(new Rect(20f, 40f, (Screen.width - 60) / 2 - 65, 155f), scrollPosition2, new Rect(0f, 0f, (Screen.width - 60) / 2 - 95, num2));
			num3 = 5;
			if (num2 > 190)
			{
				num3 = 25;
			}
			else
			{
				num3 = 5;
			}
			UnityScript.Lang.Array array8 = new UnityScript.Lang.Array();
			int num9 = 0;
			int l = 0;
			string[] array9 = array4;
			for (int length4 = array9.Length; l < length4; l++)
			{
				if (array9[l] == "Rocket Launcher" || array9[l] == "Plasma Blaster" || array9[l] == "Combat Car")
				{
					array8.Add(array9[l] + "\n(Permanent)");
				}
				else if (RuntimeServices.ToBool(RuntimeServices.InvokeBinaryOperator("op_GreaterThan", RuntimeServices.Invoke(typeof(UnityBuiltins), "parseInt", new object[1] { array6[num9] }), 365)))
				{
					array8.Add(array9[l] + "\n(Permanent)");
				}
				else
				{
					array8.Add(RuntimeServices.InvokeBinaryOperator("op_Addition", RuntimeServices.InvokeBinaryOperator("op_Addition", RuntimeServices.InvokeBinaryOperator("op_Addition", array9[l] + "\n", array6[num9]), " day"), RuntimeServices.EqualityOperator(RuntimeServices.Invoke(typeof(UnityBuiltins), "parseInt", new object[1] { array6[num9] }), 1) ? " left" : "s left"));
				}
				num9++;
			}
			inInt = RuntimeServices.UnboxInt32(UnityRuntimeServices.Invoke(typeof(GUI), "SelectionGrid", new object[5]
			{
				new Rect(50f, 0f, (Screen.width - 60) / 2 - 65 - 10 - 80 - 50, num2),
				inInt,
				array8.ToBuiltin(typeof(string)),
				1,
				itemsStyle
			}, typeof(MonoBehaviour)));
			for (int m = 0; m < UnityScript.Lang.Extensions.get_length((System.Array)array4); m++)
			{
				if (itemicons[RuntimeServices.UnboxInt32(array7[m])].width != 171 && itemicons[RuntimeServices.UnboxInt32(array7[m])].height != 171)
				{
					GUI.DrawTexture(new Rect(0f, 4 + m * 50, 50f, 50f), hasImage);
					GUI.DrawTexture(new Rect(4f, (float)(4 + m * 50) + (50f - 42f / (float)itemicons[RuntimeServices.UnboxInt32(array7[m])].width * (float)itemicons[RuntimeServices.UnboxInt32(array7[m])].height) / 2f, 42f, 42f / (float)itemicons[RuntimeServices.UnboxInt32(array7[m])].width * (float)itemicons[RuntimeServices.UnboxInt32(array7[m])].height), itemicons[RuntimeServices.UnboxInt32(array7[m])]);
				}
				else
				{
					GUI.DrawTexture(new Rect(0f, 4 + m * 50, 50f, 50f), itemicons[RuntimeServices.UnboxInt32(array7[m])]);
				}
				string text7 = "Sell";
				if (array4[m] == "Rocket Launcher" || array4[m] == "Plasma Blaster" || array4[m] == "Combat Car")
				{
					GUI.enabled = false;
					text7 = "Default";
				}
				else
				{
					GUI.enabled = true;
				}
				if (equipped.length > 0 && (RuntimeServices.EqualityOperator(array4[m], equipped[0]) || RuntimeServices.EqualityOperator(array4[m], equipped[1]) || RuntimeServices.EqualityOperator(array4[m], RuntimeServices.GetSlice(RuntimeServices.Invoke(equipped[2], "Split", new object[1] { "-"[0] }), string.Empty, new object[1] { 0 })) || RuntimeServices.EqualityOperator(array4[m], RuntimeServices.GetSlice(RuntimeServices.Invoke(equipped[2], "Split", new object[1] { "-"[0] }), string.Empty, new object[1] { 1 })) || RuntimeServices.EqualityOperator(array4[m], equipped[3])))
				{
					GUI.enabled = false;
					text7 = "Equipped";
				}
				if (isbuying)
				{
					GUI.enabled = false;
				}
				if (((!((float)(4 + m * 50) <= scrollPosition2.y) && (float)(4 + m * 50) < scrollPosition2.y + 155f) || (!((float)(24 + m * 50) <= scrollPosition2.y) && !((float)(24 + m * 50) >= scrollPosition2.y + 155f))) && GUI.Button(new Rect((Screen.width - 60) / 2 - 65 - 5 - 80, 4 + m * 50, 60f, 20f), (!startsell) ? text7 : ((m != sellindex) ? text7 : "Confirm"), buttonstyle))
				{
					if (startsell)
					{
						startsell = false;
						StartCoroutine_Auto(sellItem(Mathf.FloorToInt(m), array4));
					}
					else
					{
						startsell = true;
						sellindex = m;
						StartCoroutine_Auto(startcountDown());
					}
				}
				if (text7 == "Default")
				{
					GUI.enabled = false;
				}
				else
				{
					GUI.enabled = true;
				}
				if (((!((float)(29 + m * 50) <= scrollPosition2.y) && (float)(29 + m * 50) < scrollPosition2.y + 155f) || (!((float)(53 + m * 50) <= scrollPosition2.y) && !((float)(53 + m * 50) >= scrollPosition2.y + 155f))) && GUI.Button(new Rect((Screen.width - 60) / 2 - 65 - 5 - 80, 4 + m * 50 + 25, 60f, 20f), "Renew", buttonstyle))
				{
					baseCost = returnBaseCost(RuntimeServices.UnboxInt32(array7[m]));
					itemIndex = RuntimeServices.UnboxInt32(array7[m]);
					isRenewing = true;
					StartCoroutine_Auto(fadeInRent());
				}
			}
			GUI.enabled = true;
			GUI.EndScrollView();
			GUI.EndGroup();
			Rect position2 = new Rect((Screen.width - 60) / 2, 45f, (Screen.width - 60) / 2 - 25, 150f);
			GUI.BeginGroup(position2);
			GUI.Box(new Rect(0f, 0f, (Screen.width - 60) / 2 - 25, 150f), "Equipment", shopwindow2);
			float a = 0.7f;
			Color color = GUI.color;
			float num10 = (color.a = a);
			Color color2 = (GUI.color = color);
			GUI.DrawTexture(new Rect(11f, 31f, (Screen.width - 60) / 2 - 25 - 22, 21f), greybackground);
			GUI.DrawTexture(new Rect(11f, 73f, (Screen.width - 60) / 2 - 25 - 22, 21f), greybackground);
			GUI.DrawTexture(new Rect(11f, 115f, (Screen.width - 60) / 2 - 25 - 22, 21f), greybackground);
			float a2 = 1f;
			Color color4 = GUI.color;
			float num11 = (color4.a = a2);
			Color color5 = (GUI.color = color4);
			equipped = new UnityScript.Lang.Array();
			UnityScript.Lang.Array array10 = new UnityScript.Lang.Array((IEnumerable)AuthGameObject.inventory[2].Split("#"[0]));
			array10.RemoveAt(0);
			if (array10.length == 6)
			{
				array10.RemoveAt(4);
			}
			if (!RuntimeServices.EqualityOperator(array10[array10.length - 1], "false") && RuntimeServices.ToBool(RuntimeServices.InvokeBinaryOperator("op_GreaterThan", RuntimeServices.Invoke(typeof(UnityBuiltins), "parseInt", new object[1] { array10[array10.length - 1] }), UnityScript.Lang.Extensions.get_length((System.Array)autharraytoformat) - 1)))
			{
				AuthGameObject.inventory[2] = AuthGameObject.inventory[2].Split("#"[0])[0] + "#" + AuthGameObject.inventory[2].Split("#"[0])[1] + "#" + AuthGameObject.inventory[2].Split("#"[0])[2] + "#" + AuthGameObject.inventory[2].Split("#"[0])[3] + "#" + AuthGameObject.inventory[2].Split("#"[0])[4] + "#" + AuthGameObject.inventory[2].Split("#"[0])[5] + "#49";
				array10 = new UnityScript.Lang.Array((IEnumerable)AuthGameObject.inventory[2].Split("#"[0]));
				array10.RemoveAt(0);
				if (array10.length == 6)
				{
					array10.RemoveAt(4);
				}
			}
			IEnumerator enumerator = UnityRuntimeServices.GetEnumerator(array10);
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				if (!(obj is string))
				{
					obj = RuntimeServices.Coerce(obj, typeof(string));
				}
				string text8 = (string)obj;
				if (text8 == "false")
				{
					equipped.Add("None");
				}
				else if (UnityScript.Lang.Extensions.get_length((System.Array)text8.Split("-"[0])) > 1)
				{
					if (text8.Split("-"[0])[1] != "false" && text8.Split("-"[0])[0] != "false")
					{
						equipped.Add(autharraytoformat[UnityBuiltins.parseInt(text8.Split("-"[0])[0])] + "-" + autharraytoformat[UnityBuiltins.parseInt(text8.Split("-"[0])[1])]);
						UnityRuntimeServices.Update(enumerator, text8);
					}
					if (text8.Split("-"[0])[0] != "false" && text8.Split("-"[0])[1] == "false")
					{
						equipped.Add(autharraytoformat[UnityBuiltins.parseInt(text8.Split("-"[0])[0])] + "-false");
						UnityRuntimeServices.Update(enumerator, text8);
					}
					if (text8.Split("-"[0])[0] == "false" && text8.Split("-"[0])[1] != "false")
					{
						equipped.Add("false-" + autharraytoformat[UnityBuiltins.parseInt(text8.Split("-"[0])[1])]);
						UnityRuntimeServices.Update(enumerator, text8);
					}
					if (text8.Split("-"[0])[0] == "false" && text8.Split("-"[0])[1] == "false")
					{
						equipped.Add("false-false");
					}
				}
				else
				{
					equipped.Add(autharraytoformat[UnityBuiltins.parseInt(text8)]);
					UnityRuntimeServices.Update(enumerator, text8);
				}
			}
			GUI.Label(new Rect(20f, 30f, 120f, 25f), "Primary Weapon:", largeblue);
			UnityRuntimeServices.Invoke(typeof(GUI), "Label", new object[3]
			{
				new Rect(140f, 30f, (Screen.width - 60) / 2 - 100 - 135, 25f),
				equipped[0],
				smallgrey
			}, typeof(MonoBehaviour));
			if (array4[inInt].Contains("Armor") || array4[inInt] == "Liberator" || array4[inInt] == "UR-12 Concussion Mine" || array4[inInt] == "Incapacitator" || array4[inInt] == "EMP1" || array4[inInt] == "Mini Bar Mine" || array4[inInt] == "Anti-Tank Bar Mine" || array4[inInt].Contains("Plating") || array4[inInt].Contains("Body") || array4[inInt].Contains("Item") || array4[inInt].Contains("Mine") || array4[inInt] == "Combat Car" || array4[inInt] == "Sprinter" || array4[inInt] == "Racer" || array4[inInt] == "Devastator")
			{
				GUI.enabled = false;
			}
			if (isbuying)
			{
				GUI.enabled = false;
			}
			int num12;
			int num13;
			if (GUI.Button(new Rect((Screen.width - 60) / 2 - 100, 32f, 50f, 20f), new GUIContent("Equip", "Equip the " + array4[inInt] + " as your primary weapon."), buttonstyle))
			{
				num12 = 0;
				num13 = 0;
				int n = 0;
				string[] array11 = autharraytoformat;
				for (int length5 = array11.Length; n < length5; n++)
				{
					if (array11[n] == array4[inInt])
					{
						num13 = num12;
					}
					num12++;
				}
				if (RuntimeServices.EqualityOperator(array4[inInt], equipped[1]))
				{
					num12 = 0;
					int num14 = 0;
					int num15 = 0;
					string[] array12 = autharraytoformat;
					for (int length6 = array12.Length; num15 < length6; num15++)
					{
						if (RuntimeServices.EqualityOperator(array12[num15], equipped[0]))
						{
							num14 = num12;
						}
						num12++;
					}
					StartCoroutine_Auto(updateEquip(num13.ToString(), num14.ToString(), AuthGameObject.inventory[2].Split("#"[0])[3], AuthGameObject.inventory[2].Split("#"[0])[4], AuthGameObject.inventory[2].Split("#"[0])[6]));
				}
				else
				{
					StartCoroutine_Auto(updateEquip(num13.ToString(), AuthGameObject.inventory[2].Split("#"[0])[2], AuthGameObject.inventory[2].Split("#"[0])[3], AuthGameObject.inventory[2].Split("#"[0])[4], AuthGameObject.inventory[2].Split("#"[0])[6]));
				}
			}
			GUI.enabled = true;
			GUI.Label(new Rect(20f, 51f, 135f, 25f), "Secondary Weapon:", largeblue);
			UnityRuntimeServices.Invoke(typeof(GUI), "Label", new object[3]
			{
				new Rect(160f, 51f, (Screen.width - 60) / 2 - 100 - 150, 25f),
				equipped[1],
				smallgrey
			}, typeof(MonoBehaviour));
			if (array4[inInt].Contains("Armor") || array4[inInt] == "Liberator" || array4[inInt] == "UR-12 Concussion Mine" || array4[inInt] == "Incapacitator" || array4[inInt] == "EMP1" || array4[inInt] == "Mini Bar Mine" || array4[inInt] == "Anti-Tank Bar Mine" || array4[inInt].Contains("Plating") || array4[inInt].Contains("Body") || array4[inInt].Contains("Item") || array4[inInt].Contains("Mine") || array4[inInt] == "Combat Car" || array4[inInt] == "Sprinter" || array4[inInt] == "Racer" || array4[inInt] == "Devastator")
			{
				GUI.enabled = false;
			}
			if (isbuying)
			{
				GUI.enabled = false;
			}
			if (GUI.Button(new Rect((Screen.width - 60) / 2 - 100, 53f, 50f, 20f), new GUIContent("Equip", "Equip the " + array4[inInt] + " as your secondary weapon."), buttonstyle))
			{
				num12 = 0;
				num13 = 0;
				int num16 = 0;
				string[] array13 = autharraytoformat;
				for (int length7 = array13.Length; num16 < length7; num16++)
				{
					if (array13[num16] == array4[inInt])
					{
						num13 = num12;
					}
					num12++;
				}
				if (RuntimeServices.EqualityOperator(array4[inInt], equipped[0]))
				{
					num12 = 0;
					int num14 = 0;
					int num17 = 0;
					string[] array14 = autharraytoformat;
					for (int length8 = array14.Length; num17 < length8; num17++)
					{
						if (RuntimeServices.EqualityOperator(array14[num17], equipped[1]))
						{
							num14 = num12;
						}
						num12++;
					}
					StartCoroutine_Auto(updateEquip(num14.ToString(), num13.ToString(), AuthGameObject.inventory[2].Split("#"[0])[3], AuthGameObject.inventory[2].Split("#"[0])[4], AuthGameObject.inventory[2].Split("#"[0])[6]));
				}
				else
				{
					StartCoroutine_Auto(updateEquip(AuthGameObject.inventory[2].Split("#"[0])[1], num13.ToString(), AuthGameObject.inventory[2].Split("#"[0])[3], AuthGameObject.inventory[2].Split("#"[0])[4], AuthGameObject.inventory[2].Split("#"[0])[6]));
				}
			}
			GUI.enabled = true;
			GUI.Label(new Rect(20f, 72f, 110f, 25f), "Armor/Body:", largeblue);
			if (RuntimeServices.ToBool(RuntimeServices.InvokeBinaryOperator("op_GreaterThan", UnityRuntimeServices.GetProperty(RuntimeServices.Invoke(equipped[2], "Split", new object[1] { "-"[0] }), "length"), 1)))
			{
				if (!RuntimeServices.EqualityOperator(RuntimeServices.GetSlice(RuntimeServices.Invoke(equipped[2], "Split", new object[1] { "-"[0] }), string.Empty, new object[1] { 0 }), "false") && !RuntimeServices.EqualityOperator(RuntimeServices.GetSlice(RuntimeServices.Invoke(equipped[2], "Split", new object[1] { "-"[0] }), string.Empty, new object[1] { 1 }), "false"))
				{
					UnityRuntimeServices.Invoke(typeof(GUI), "Label", new object[3]
					{
						new Rect(115f, 72f, (Screen.width - 60) / 2 - 100 - 125, 25f),
						RuntimeServices.InvokeBinaryOperator("op_Addition", RuntimeServices.InvokeBinaryOperator("op_Addition", RuntimeServices.GetSlice(RuntimeServices.Invoke(equipped[2], "Split", new object[1] { "-"[0] }), string.Empty, new object[1] { 0 }), "/"), RuntimeServices.GetSlice(RuntimeServices.Invoke(equipped[2], "Split", new object[1] { "-"[0] }), string.Empty, new object[1] { 1 })),
						smallgrey
					}, typeof(MonoBehaviour));
				}
				if (RuntimeServices.EqualityOperator(RuntimeServices.GetSlice(RuntimeServices.Invoke(equipped[2], "Split", new object[1] { "-"[0] }), string.Empty, new object[1] { 0 }), "false") && !RuntimeServices.EqualityOperator(RuntimeServices.GetSlice(RuntimeServices.Invoke(equipped[2], "Split", new object[1] { "-"[0] }), string.Empty, new object[1] { 1 }), "false"))
				{
					UnityRuntimeServices.Invoke(typeof(GUI), "Label", new object[3]
					{
						new Rect(115f, 72f, (Screen.width - 60) / 2 - 100 - 125, 25f),
						RuntimeServices.GetSlice(RuntimeServices.Invoke(equipped[2], "Split", new object[1] { "-"[0] }), string.Empty, new object[1] { 1 }),
						smallgrey
					}, typeof(MonoBehaviour));
				}
				if (RuntimeServices.EqualityOperator(RuntimeServices.GetSlice(RuntimeServices.Invoke(equipped[2], "Split", new object[1] { "-"[0] }), string.Empty, new object[1] { 1 }), "false") && !RuntimeServices.EqualityOperator(RuntimeServices.GetSlice(RuntimeServices.Invoke(equipped[2], "Split", new object[1] { "-"[0] }), string.Empty, new object[1] { 0 }), "false"))
				{
					UnityRuntimeServices.Invoke(typeof(GUI), "Label", new object[3]
					{
						new Rect(115f, 72f, (Screen.width - 60) / 2 - 100 - 125, 25f),
						RuntimeServices.GetSlice(RuntimeServices.Invoke(equipped[2], "Split", new object[1] { "-"[0] }), string.Empty, new object[1] { 0 }),
						smallgrey
					}, typeof(MonoBehaviour));
				}
				if (RuntimeServices.EqualityOperator(RuntimeServices.GetSlice(RuntimeServices.Invoke(equipped[2], "Split", new object[1] { "-"[0] }), string.Empty, new object[1] { 0 }), "false") && RuntimeServices.EqualityOperator(RuntimeServices.GetSlice(RuntimeServices.Invoke(equipped[2], "Split", new object[1] { "-"[0] }), string.Empty, new object[1] { 1 }), "false"))
				{
					GUI.Label(new Rect(115f, 72f, (Screen.width - 60) / 2 - 100 - 125, 25f), "None", smallgrey);
				}
			}
			else
			{
				GUI.Label(new Rect(115f, 72f, (Screen.width - 60) / 2 - 100 - 125, 25f), "None", smallgrey);
			}
			if (array4[inInt].Contains("Armor") || array4[inInt].Contains("Plating") || array4[inInt].Contains("Body"))
			{
				GUI.enabled = true;
			}
			else
			{
				GUI.enabled = false;
			}
			if (isbuying)
			{
				GUI.enabled = false;
			}
			string text9 = "Equip";
			string tooltip = "Equip the " + array4[inInt] + " as your armor/bodykit.";
			int num18 = 0;
			if (array4[inInt].Contains("Plating") || array4[inInt].Contains("Body"))
			{
				num18 = 1;
			}
			if (RuntimeServices.EqualityOperator(array4[inInt], RuntimeServices.GetSlice(RuntimeServices.Invoke(equipped[2], "Split", new object[1] { "-"[0] }), string.Empty, new object[1] { 0 })))
			{
				text9 = "Rmv.";
				tooltip = "Remove the " + array4[inInt] + " from your equipment.";
			}
			if (RuntimeServices.ToBool(RuntimeServices.InvokeBinaryOperator("op_GreaterThan", UnityRuntimeServices.GetProperty(RuntimeServices.Invoke(equipped[2], "Split", new object[1] { "-"[0] }), "length"), 1)) && RuntimeServices.EqualityOperator(array4[inInt], RuntimeServices.GetSlice(RuntimeServices.Invoke(equipped[2], "Split", new object[1] { "-"[0] }), string.Empty, new object[1] { 1 })))
			{
				text9 = "Rmv.";
				tooltip = "Remove the " + array4[inInt] + " from your equipment.";
			}
			if (GUI.Button(new Rect((Screen.width - 60) / 2 - 100, 74f, 50f, 20f), new GUIContent(text9, tooltip), buttonstyle))
			{
				if (text9 == "Equip")
				{
					num12 = 0;
					num13 = 0;
					int num19 = 0;
					string[] array15 = autharraytoformat;
					for (int length9 = array15.Length; num19 < length9; num19++)
					{
						if (array15[num19] == array4[inInt])
						{
							num13 = num12;
						}
						num12++;
					}
					if (num18 == 0)
					{
						StartCoroutine_Auto(updateEquip(AuthGameObject.inventory[2].Split("#"[0])[1], AuthGameObject.inventory[2].Split("#"[0])[2], num13.ToString() + "-" + AuthGameObject.inventory[2].Split("#"[0])[3].Split("-"[0])[1], AuthGameObject.inventory[2].Split("#"[0])[4], AuthGameObject.inventory[2].Split("#"[0])[6]));
					}
					else
					{
						StartCoroutine_Auto(updateEquip(AuthGameObject.inventory[2].Split("#"[0])[1], AuthGameObject.inventory[2].Split("#"[0])[2], AuthGameObject.inventory[2].Split("#"[0])[3].Split("-"[0])[0] + "-" + num13.ToString(), AuthGameObject.inventory[2].Split("#"[0])[4], AuthGameObject.inventory[2].Split("#"[0])[6]));
					}
				}
				else if (num18 == 0)
				{
					StartCoroutine_Auto(updateEquip(AuthGameObject.inventory[2].Split("#"[0])[1], AuthGameObject.inventory[2].Split("#"[0])[2], "false-" + AuthGameObject.inventory[2].Split("#"[0])[3].Split("-"[0])[1], AuthGameObject.inventory[2].Split("#"[0])[4], AuthGameObject.inventory[2].Split("#"[0])[6]));
				}
				else
				{
					StartCoroutine_Auto(updateEquip(AuthGameObject.inventory[2].Split("#"[0])[1], AuthGameObject.inventory[2].Split("#"[0])[2], AuthGameObject.inventory[2].Split("#"[0])[3].Split("-"[0])[0] + "-false", AuthGameObject.inventory[2].Split("#"[0])[4], AuthGameObject.inventory[2].Split("#"[0])[6]));
				}
			}
			GUI.enabled = true;
			GUI.Label(new Rect(20f, 93f, 50f, 25f), "Item:", largeblue);
			UnityRuntimeServices.Invoke(typeof(GUI), "Label", new object[3]
			{
				new Rect(65f, 93f, (Screen.width - 60) / 2 - 100 - 65, 25f),
				equipped[3],
				smallgrey
			}, typeof(MonoBehaviour));
			if (array4[inInt] == "Liberator" || array4[inInt] == "UR-12 Concussion Mine" || array4[inInt] == "Incapacitator" || array4[inInt] == "EMP1" || array4[inInt] == "Mini Bar Mine" || array4[inInt] == "Anti-Tank Bar Mine" || array4[inInt].Contains("Item") || array4[inInt].Contains("Mine"))
			{
				GUI.enabled = true;
			}
			else
			{
				GUI.enabled = false;
			}
			if (isbuying)
			{
				GUI.enabled = false;
			}
			text9 = "Equip";
			tooltip = "Equip the " + array4[inInt] + " as your item.";
			if (RuntimeServices.EqualityOperator(array4[inInt], equipped[3]))
			{
				text9 = "Rmv.";
				tooltip = "Remove the " + array4[inInt] + " from your equipment.";
			}
			if (GUI.Button(new Rect((Screen.width - 60) / 2 - 100, 95f, 50f, 20f), new GUIContent(text9, tooltip), buttonstyle))
			{
				num12 = 0;
				num13 = 0;
				int num20 = 0;
				string[] array16 = autharraytoformat;
				for (int length10 = array16.Length; num20 < length10; num20++)
				{
					if (array16[num20] == array4[inInt])
					{
						num13 = num12;
					}
					num12++;
				}
				if (text9 == "Equip")
				{
					StartCoroutine_Auto(updateEquip(AuthGameObject.inventory[2].Split("#"[0])[1], AuthGameObject.inventory[2].Split("#"[0])[2], AuthGameObject.inventory[2].Split("#"[0])[3], num13.ToString(), AuthGameObject.inventory[2].Split("#"[0])[6]));
				}
				else
				{
					StartCoroutine_Auto(updateEquip(AuthGameObject.inventory[2].Split("#"[0])[1], AuthGameObject.inventory[2].Split("#"[0])[2], AuthGameObject.inventory[2].Split("#"[0])[3], "false", AuthGameObject.inventory[2].Split("#"[0])[6]));
				}
			}
			GUI.enabled = true;
			GUI.Label(new Rect(20f, 114f, 65f, 25f), "Vehicle:", largeblue);
			UnityRuntimeServices.Invoke(typeof(GUI), "Label", new object[3]
			{
				new Rect(85f, 114f, (Screen.width - 60) / 2 - 100 - 65, 25f),
				equipped[4],
				smallgrey
			}, typeof(MonoBehaviour));
			if (array4[inInt] == "Sprinter" || array4[inInt] == "Combat Car" || array4[inInt] == "Racer" || array4[inInt] == "Devastator")
			{
				GUI.enabled = true;
			}
			else
			{
				GUI.enabled = false;
			}
			if (isbuying)
			{
				GUI.enabled = false;
			}
			text9 = "Equip";
			tooltip = "Equip the " + array4[inInt] + " as your vehicle.";
			if (GUI.Button(new Rect((Screen.width - 60) / 2 - 100, 116f, 50f, 20f), new GUIContent(text9, tooltip), buttonstyle))
			{
				num12 = 0;
				num13 = 0;
				int num21 = 0;
				string[] array17 = autharraytoformat;
				for (int length11 = array17.Length; num21 < length11; num21++)
				{
					if (array17[num21] == array4[inInt])
					{
						num13 = num12;
					}
					num12++;
				}
				StartCoroutine_Auto(updateEquip(AuthGameObject.inventory[2].Split("#"[0])[1], AuthGameObject.inventory[2].Split("#"[0])[2], AuthGameObject.inventory[2].Split("#"[0])[3], AuthGameObject.inventory[2].Split("#"[0])[4], num13.ToString()));
			}
			GUI.enabled = true;
			GUI.EndGroup();
			Rect position3 = new Rect((Screen.width - 60) / 2, 190f, (Screen.width - 60) / 2 - 25, 75f);
			GUI.BeginGroup(position3);
			if (array4[inInt].Contains("Plating") || array4[inInt].Contains("Body") || array4[inInt] == "Combat Car" || array4[inInt] == "Sprinter" || array4[inInt] == "Racer" || array4[inInt] == "Devastator")
			{
				GUI.enabled = false;
			}
			GUI.Box(new Rect(0f, 0f, (Screen.width - 60) / 2 - 25, 75f), "Upgrade " + array4[inInt], shopwindow2);
			GUI.Box(new Rect(20f, 35f, (Screen.width - 60) / 2 - 25 - 40 - 70, 20f), string.Empty, bars1);
			float num22 = 0.05f;
			num12 = 0;
			num13 = 0;
			int num23 = 0;
			string[] array18 = autharraytoformat;
			for (int length12 = array18.Length; num23 < length12; num23++)
			{
				if (array18[num23] == array4[inInt])
				{
					num13 = num12;
				}
				num12++;
			}
			num22 = UnityBuiltins.parseFloat(AuthGameObject.inventory[num13]) / 20f;
			GUI.Box(new Rect(21f, 36f, (float)((Screen.width - 60) / 2 - 25 - 42 - 70) * num22, 18f), string.Empty, bars2);
			if (UnityBuiltins.parseInt(AuthGameObject.inventory[num13]) < 20)
			{
				GUI.enabled = true;
			}
			else
			{
				GUI.enabled = false;
			}
			if (UnityBuiltins.parseInt(returnGold()) < 75)
			{
				GUI.enabled = false;
			}
			if (isbuying)
			{
				GUI.enabled = false;
			}
			if (array4[inInt].Contains("Plating") || array4[inInt].Contains("Body") || array4[inInt] == "Combat Car" || array4[inInt] == "Sprinter" || array4[inInt] == "Racer" || array4[inInt] == "Devastator")
			{
				GUI.enabled = false;
			}
			if (GUI.Button(new Rect((Screen.width - 60) / 2 - 25 - 20 - 60, 35f, 60f, 20f), new GUIContent("[+] lvl " + (num22 * 20f).ToString(), "Upgrade the item's damage or shielding.\nCosts " + Mathf.Round((num22 * 20f + 1f) * 75f).ToString() + " credits."), buttonstyle))
			{
				if (!((float)UnityBuiltins.parseInt(returnGold()) >= (num22 * 20f + 1f) * 75f))
				{
					StartCoroutine_Auto(fadeInCredits());
				}
				else
				{
					StartCoroutine_Auto(upgradeItemLevel(dbindex[num13], UnityBuiltins.parseInt(AuthGameObject.inventory[num13]) + 1, num13, (int)Mathf.Round((num22 * 20f + 1f) * 75f)));
				}
			}
			GUI.enabled = true;
			GUI.EndGroup();
			GUI.EndGroup();
		}
		float a3 = rentalpha;
		Color color7 = GUI.color;
		float num24 = (color7.a = a3);
		Color color8 = (GUI.color = color7);
		GUI.enabled = true;
		if (!(rentalpha <= 0f))
		{
			GUILayout.BeginArea(new Rect(Screen.width / 2 - 200, Screen.height / 2 - 180, 400f, 360f));
			GUI.Box(new Rect(0f, 0f, 400f, 360f), "Buy Items", credback);
			GUI.Label(new Rect(25f, 30f, 350f, 60f), "All items can be temporarily or permanently bought depending on your current level in the game.", credtxt);
			if (GUI.Button(new Rect(25f, 100f, 240f, 25f), "1 day – \"Newbie\" (lvl 1) or higher", buttonstyle))
			{
				if (!((float)UnityBuiltins.parseInt(returnGold()) >= Mathf.Round((float)baseCost * 0.1f)))
				{
					StartCoroutine_Auto(fadeInCredits());
				}
				else
				{
					if (!isRenewing)
					{
						StartCoroutine_Auto(buyItem(itemIndex, (int)Mathf.Round((float)baseCost * 0.1f), 1));
					}
					else
					{
						StartCoroutine_Auto(renewItem(itemIndex, (int)Mathf.Round((float)baseCost * 0.1f), 1));
					}
					StartCoroutine_Auto(fadeOutRent());
				}
			}
			GUI.Label(new Rect(290f, 100f, 130f, 25f), Mathf.Round((float)baseCost * 0.1f).ToString() + " credits", labelstyle3);
			if (DisplayTopPlayers.mypointsStat >= 1000)
			{
				GUI.enabled = true;
			}
			else
			{
				GUI.enabled = false;
			}
			if (GUI.Button(new Rect(25f, 130f, 240f, 25f), "3 days – \"Rookie\" (lvl 2) or higher", buttonstyle))
			{
				if (!((float)UnityBuiltins.parseInt(returnGold()) >= Mathf.Round((float)baseCost * 0.2f)))
				{
					StartCoroutine_Auto(fadeInCredits());
				}
				else
				{
					if (!isRenewing)
					{
						StartCoroutine_Auto(buyItem(itemIndex, (int)Mathf.Round((float)baseCost * 0.2f), 3));
					}
					else
					{
						StartCoroutine_Auto(renewItem(itemIndex, (int)Mathf.Round((float)baseCost * 0.2f), 3));
					}
					StartCoroutine_Auto(fadeOutRent());
				}
			}
			GUI.Label(new Rect(290f, 130f, 130f, 25f), Mathf.Round((float)baseCost * 0.2f).ToString() + " credits", labelstyle3);
			if (DisplayTopPlayers.mypointsStat >= 2000)
			{
				GUI.enabled = true;
			}
			else
			{
				GUI.enabled = false;
			}
			if (GUI.Button(new Rect(25f, 160f, 240f, 25f), "7 days – \"Amateur\" (lvl 3) or higher", buttonstyle))
			{
				if (!((float)UnityBuiltins.parseInt(returnGold()) >= Mathf.Round((float)baseCost * 0.3f)))
				{
					StartCoroutine_Auto(fadeInCredits());
				}
				else
				{
					if (!isRenewing)
					{
						StartCoroutine_Auto(buyItem(itemIndex, (int)Mathf.Round((float)baseCost * 0.3f), 7));
					}
					else
					{
						StartCoroutine_Auto(renewItem(itemIndex, (int)Mathf.Round((float)baseCost * 0.3f), 7));
					}
					StartCoroutine_Auto(fadeOutRent());
				}
			}
			GUI.Label(new Rect(290f, 160f, 130f, 25f), Mathf.Round((float)baseCost * 0.25f).ToString() + " credits", labelstyle3);
			if (DisplayTopPlayers.mypointsStat >= 3000)
			{
				GUI.enabled = true;
			}
			else
			{
				GUI.enabled = false;
			}
			if (GUI.Button(new Rect(25f, 190f, 240f, 25f), "14 days – \"Skilled\" (lvl 4) or higher", buttonstyle))
			{
				if (!((float)UnityBuiltins.parseInt(returnGold()) >= (float)baseCost * 0.4f))
				{
					StartCoroutine_Auto(fadeInCredits());
				}
				else
				{
					if (!isRenewing)
					{
						StartCoroutine_Auto(buyItem(itemIndex, (int)((float)baseCost * 0.4f), 14));
					}
					else
					{
						StartCoroutine_Auto(renewItem(itemIndex, (int)((float)baseCost * 0.4f), 14));
					}
					StartCoroutine_Auto(fadeOutRent());
				}
			}
			GUI.Label(new Rect(290f, 190f, 130f, 25f), ((float)baseCost * 0.4f).ToString() + " credits", labelstyle3);
			if (DisplayTopPlayers.mypointsStat >= 4000)
			{
				GUI.enabled = true;
			}
			else
			{
				GUI.enabled = false;
			}
			if (GUI.Button(new Rect(25f, 220f, 240f, 25f), "30 days – \"Pro\" (lvl 5) or higher", buttonstyle))
			{
				if (!((float)UnityBuiltins.parseInt(returnGold()) >= Mathf.Round((float)baseCost * 0.65f)))
				{
					StartCoroutine_Auto(fadeInCredits());
				}
				else
				{
					if (!isRenewing)
					{
						StartCoroutine_Auto(buyItem(itemIndex, (int)Mathf.Round((float)baseCost * 0.65f), 30));
					}
					else
					{
						StartCoroutine_Auto(renewItem(itemIndex, (int)Mathf.Round((float)baseCost * 0.65f), 30));
					}
					StartCoroutine_Auto(fadeOutRent());
				}
			}
			GUI.Label(new Rect(290f, 220f, 130f, 25f), Mathf.Round((float)baseCost * 0.65f).ToString() + " credits", labelstyle3);
			if (DisplayTopPlayers.mypointsStat >= 5000)
			{
				GUI.enabled = true;
			}
			else
			{
				GUI.enabled = false;
			}
			if (GUI.Button(new Rect(25f, 250f, 240f, 25f), "90 days – \"Expert\" (lvl 6) or higher", buttonstyle))
			{
				if (!((float)UnityBuiltins.parseInt(returnGold()) >= (float)baseCost * 0.8f))
				{
					StartCoroutine_Auto(fadeInCredits());
				}
				else
				{
					if (!isRenewing)
					{
						StartCoroutine_Auto(buyItem(itemIndex, (int)((float)baseCost * 0.8f), 90));
					}
					else
					{
						StartCoroutine_Auto(renewItem(itemIndex, (int)((float)baseCost * 0.8f), 90));
					}
					StartCoroutine_Auto(fadeOutRent());
				}
			}
			GUI.Label(new Rect(290f, 250f, 130f, 25f), ((float)baseCost * 0.8f).ToString() + " credits", labelstyle3);
			GUI.enabled = true;
			Color textColor = buttonstyle.normal.textColor;
			buttonstyle.normal.textColor = labelstyle3.normal.textColor;
			if (GUI.Button(new Rect(25f, 280f, 240f, 25f), "Permanent – any level", buttonstyle))
			{
				if (UnityBuiltins.parseInt(returnGold()) < baseCost * 1)
				{
					StartCoroutine_Auto(fadeInCredits());
				}
				else
				{
					if (!isRenewing)
					{
						StartCoroutine_Auto(buyItem(itemIndex, baseCost * 1, 999));
					}
					else
					{
						StartCoroutine_Auto(renewItem(itemIndex, baseCost * 1, 999));
					}
					StartCoroutine_Auto(fadeOutRent());
				}
			}
			buttonstyle.normal.textColor = textColor;
			GUI.Label(new Rect(290f, 280f, 130f, 25f), (baseCost * 1).ToString() + " credits", labelstyle3);
			GUI.enabled = true;
			if (GUI.Button(new Rect(275f, 315f, 100f, 25f), "Close", buttonstyle))
			{
				StartCoroutine_Auto(fadeOutRent());
			}
			GUILayout.EndArea();
		}
		float a4 = creditalpha;
		Color color10 = GUI.color;
		float num25 = (color10.a = a4);
		Color color11 = (GUI.color = color10);
		GUI.enabled = true;
		if (!(creditalpha <= 0f))
		{
			GUI.BeginGroup(new Rect(Screen.width / 2 - 175, Screen.height / 2 - 110, 350f, 185f));
			GUI.Box(new Rect(0f, 0f, 350f, 185f), "Too Expensive", credback);
			GUI.Label(new Rect(25f, 30f, 300f, 60f), (toolbarInt != 2) ? "Looks like you don't have enough credits. Complete free offers to get more!" : "Epic items require premium credits (instead of normal credits). Complete free offers to get more!", credtxt);
			Color textColor = buttonstyle.normal.textColor;
			buttonstyle.normal.textColor = labelstyle3.normal.textColor;
			if (GUI.Button(new Rect(25f, 100f, 300f, 25f), (toolbarInt != 2) ? "Get Free Credits" : "Get Free Premium Credits", buttonstyle))
			{
				Application.ExternalEval("showCredits" + ((toolbarInt != 2) ? string.Empty : "Prem") + "(" + AuthGameObject.inventory[0] + ")");
			}
			buttonstyle.normal.textColor = textColor;
			if (GUI.Button(new Rect(25f, 135f, 300f, 25f), "Close Window", buttonstyle))
			{
				StartCoroutine_Auto(fadeOutCredits());
			}
			GUI.EndGroup();
		}
		float a5 = 1f;
		Color color13 = GUI.color;
		float num26 = (color13.a = a5);
		Color color14 = (GUI.color = color13);
		if (GUI.tooltip != string.Empty)
		{
			fadetool = true;
		}
		else
		{
			fadetool = false;
		}
		float a6 = toolalpha;
		Color color16 = GUI.color;
		float num27 = (color16.a = a6);
		Color color17 = (GUI.color = color16);
		GUI.Label(new Rect(Mathf.Min(Input.mousePosition.x, Screen.width - 324), Mathf.Min((float)Screen.height - Input.mousePosition.y + 15f, Screen.height - 70), 324f, 70f), GUI.tooltip, tooltipstyle);
	}

	public virtual IEnumerator startcountDown()
	{
		return new _0024startcountDown_00245507(this).GetEnumerator();
	}

	public virtual IEnumerator sellItem(int i, string[] inventory)
	{
		return new _0024sellItem_00245510(i, inventory, this).GetEnumerator();
	}

	public virtual int returnBaseCost(int i)
	{
		int num = 0;
		string[] array = cat1;
		int length = array.Length;
		int result;
		while (true)
		{
			if (num < length)
			{
				if (UnityBuiltins.parseInt(array[num].Split("|"[0])[UnityScript.Lang.Extensions.get_length((System.Array)array[num].Split("|"[0])) - 1]) == i)
				{
					result = UnityBuiltins.parseInt(array[num].Split("|"[0])[UnityScript.Lang.Extensions.get_length((System.Array)array[num].Split("|"[0])) - 2]);
					break;
				}
				num++;
				continue;
			}
			int num2 = 0;
			string[] array2 = cat2;
			int length2 = array2.Length;
			while (true)
			{
				if (num2 < length2)
				{
					if (UnityBuiltins.parseInt(array2[num2].Split("|"[0])[UnityScript.Lang.Extensions.get_length((System.Array)array2[num2].Split("|"[0])) - 1]) == i)
					{
						result = UnityBuiltins.parseInt(array2[num2].Split("|"[0])[UnityScript.Lang.Extensions.get_length((System.Array)array2[num2].Split("|"[0])) - 2]);
						break;
					}
					num2++;
					continue;
				}
				int num3 = 0;
				string[] array3 = cat3;
				int length3 = array3.Length;
				while (true)
				{
					if (num3 < length3)
					{
						if (UnityBuiltins.parseInt(array3[num3].Split("|"[0])[UnityScript.Lang.Extensions.get_length((System.Array)array3[num3].Split("|"[0])) - 1]) == i)
						{
							result = UnityBuiltins.parseInt(array3[num3].Split("|"[0])[UnityScript.Lang.Extensions.get_length((System.Array)array3[num3].Split("|"[0])) - 2]);
							break;
						}
						num3++;
						continue;
					}
					int num4 = 0;
					string[] array4 = cat4;
					int length4 = array4.Length;
					while (true)
					{
						if (num4 < length4)
						{
							if (UnityBuiltins.parseInt(array4[num4].Split("|"[0])[UnityScript.Lang.Extensions.get_length((System.Array)array4[num4].Split("|"[0])) - 1]) == i)
							{
								result = UnityBuiltins.parseInt(array4[num4].Split("|"[0])[UnityScript.Lang.Extensions.get_length((System.Array)array4[num4].Split("|"[0])) - 2]);
								break;
							}
							num4++;
							continue;
						}
						result = 0;
						break;
					}
					break;
				}
				break;
			}
			break;
		}
		return result;
	}

	public virtual IEnumerator updateEquip(string p, string s, string a, string i, string v)
	{
		return new _0024updateEquip_00245545(p, s, a, i, v, this).GetEnumerator();
	}

	public virtual IEnumerator upgradeItemLevel(string s, int i, int index, int c)
	{
		return new _0024upgradeItemLevel_00245561(s, i, index, c, this).GetEnumerator();
	}

	public virtual IEnumerator renewItem(int i, int c, int rtime)
	{
		return new _0024renewItem_00245575(i, c, rtime, this).GetEnumerator();
	}

	public virtual IEnumerator buyItemPrem(int i, int c, int rtime)
	{
		return new _0024buyItemPrem_00245588(i, c, rtime, this).GetEnumerator();
	}

	public virtual IEnumerator buyItem(int i, int c, int rtime)
	{
		return new _0024buyItem_00245610(i, c, rtime, this).GetEnumerator();
	}

	public virtual string getFieldFor(int i)
	{
		return dbindex[i];
	}

	public virtual string returnGoldPrem()
	{
		return AuthGameObject.inventory[45];
	}

	public virtual string returnGold()
	{
		string text = AuthGameObject.inventory[2].Split("#"[0])[0];
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

	public virtual string returnGoldEncrypted()
	{
		string[] array = AuthGameObject.inventory[2].Split("#"[0]);
		string text = null;
		for (int i = 0; i < UnityScript.Lang.Extensions.get_length(array[0]); i++)
		{
			if (array[0].Substring(i, 1) == "0")
			{
				text += "a";
			}
			if (array[0].Substring(i, 1) == "1")
			{
				text += "b";
			}
			if (array[0].Substring(i, 1) == "2")
			{
				text += "c";
			}
			if (array[0].Substring(i, 1) == "3")
			{
				text += "d";
			}
			if (array[0].Substring(i, 1) == "4")
			{
				text += "e";
			}
			if (array[0].Substring(i, 1) == "5")
			{
				text += "f";
			}
			if (array[0].Substring(i, 1) == "6")
			{
				text += "g";
			}
			if (array[0].Substring(i, 1) == "7")
			{
				text += "h";
			}
			if (array[0].Substring(i, 1) == "8")
			{
				text += "i";
			}
			if (array[0].Substring(i, 1) == "9")
			{
				text += "j";
			}
		}
		return text;
	}

	public virtual IEnumerator showEquip(bool t)
	{
		return new _0024showEquip_00245631(t, this).GetEnumerator();
	}

	public virtual IEnumerator fadeInRent()
	{
		return new _0024fadeInRent_00245636(this).GetEnumerator();
	}

	public virtual IEnumerator fadeOutRent()
	{
		return new _0024fadeOutRent_00245639(this).GetEnumerator();
	}

	public virtual IEnumerator fadeInCredits()
	{
		return new _0024fadeInCredits_00245642(this).GetEnumerator();
	}

	public virtual IEnumerator fadeOutCredits()
	{
		return new _0024fadeOutCredits_00245645(this).GetEnumerator();
	}

	public virtual void Main()
	{
	}
}
