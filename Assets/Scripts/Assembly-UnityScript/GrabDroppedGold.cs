using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class GrabDroppedGold : MonoBehaviour
{
	[Serializable]
	internal sealed class _0024Start_00243936 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal GrabDroppedGold _0024self__00243937;

			public _0024(GrabDroppedGold self_)
			{
				_0024self__00243937 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					result = (Yield(2, new WaitForSeconds(120f)) ? 1 : 0);
					break;
				case 2:
					UnityEngine.Object.Destroy(_0024self__00243937.gameObject);
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal GrabDroppedGold _0024self__00243938;

		public _0024Start_00243936(GrabDroppedGold self_)
		{
			_0024self__00243938 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00243938);
		}
	}

	public virtual IEnumerator Start()
	{
		return new _0024Start_00243936(this).GetEnumerator();
	}

	public virtual void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.name == "MainBoxCol" && ((PhotonView)col.gameObject.GetComponent(typeof(PhotonView))).isMine)
		{
			col.SendMessage("grabGold");
			UnityEngine.Object.Destroy(transform.parent.gameObject);
		}
	}

	public virtual void Main()
	{
	}
}
