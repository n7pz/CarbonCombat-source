using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class KongregateKreds : MonoBehaviour
{
	[Serializable]
	internal sealed class _0024UserItems_00244037 : GenericGenerator<WWW>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WWW>, IEnumerator
		{
			internal WWW _0024www_00244038;

			internal string _0024id_00244039;

			internal KongregateKreds _0024self__00244040;

			public _0024(string id, KongregateKreds self_)
			{
				_0024id_00244039 = id;
				_0024self__00244040 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					Debug.Log("Result of Inventory: " + _0024id_00244039);
					Debug.Log("http://72.14.184.180/kredsPost.php?gauth=" + _0024self__00244040.gameAuthToken + "&uid=" + _0024self__00244040.userId + "&iid=" + _0024id_00244039);
					_0024www_00244038 = new WWW("http://72.14.184.180/kredsPost.php?gauth=" + _0024self__00244040.gameAuthToken + "&uid=" + _0024self__00244040.userId + "&iid=" + _0024id_00244039);
					result = (Yield(2, _0024www_00244038) ? 1 : 0);
					break;
				case 2:
					Debug.Log(_0024www_00244038.text);
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal string _0024id_00244041;

		internal KongregateKreds _0024self__00244042;

		public _0024UserItems_00244037(string id, KongregateKreds self_)
		{
			_0024id_00244041 = id;
			_0024self__00244042 = self_;
		}

		public override IEnumerator<WWW> GetEnumerator()
		{
			return new _0024(_0024id_00244041, _0024self__00244042);
		}
	}

	public string gameAuthToken;

	public string userId;

	public virtual void OnKongregateAPILoaded(object userInfoString)
	{
		Debug.Log(userInfoString);
		object target = UnityRuntimeServices.Invoke(userInfoString, "Split", new object[1] { "|"[0] }, typeof(MonoBehaviour));
		userId = RuntimeServices.Invoke(typeof(UnityBuiltins), "parseInt", new object[1] { RuntimeServices.GetSlice(target, string.Empty, new object[1] { 0 }) }).ToString();
		gameAuthToken = RuntimeServices.GetSlice(target, string.Empty, new object[1] { 2 }).ToString();
		Application.ExternalEval("kongregate.mtx.purchaseItems([\"creds-500\"], function(b){" + "   kongregateUnitySupport.getUnityObject().SendMessage('KongregateAPI', 'WindowLoaded', b.success.toString());" + "});");
	}

	public virtual void WindowLoaded(string result)
	{
		Debug.Log("Result of Shop: " + result);
		Application.ExternalEval("kongregate.mtx.requestUserItemList(null, function(b){" + "   alert(b.data.length);" + "   kongregateUnitySupport.getUnityObject().SendMessage('KongregateAPI', 'UserItems', b.data[0].id.toString());" + "});");
	}

	public virtual IEnumerator UserItems(string id)
	{
		return new _0024UserItems_00244037(id, this).GetEnumerator();
	}

	public virtual void Start()
	{
		Application.ExternalEval("if(typeof(kongregateUnitySupport) != 'undefined'){" + " kongregateUnitySupport.initAPI('KongregateAPI', 'OnKongregateAPILoaded');" + "};");
	}

	public virtual void Main()
	{
	}
}
