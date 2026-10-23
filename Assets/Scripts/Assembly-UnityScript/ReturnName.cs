using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class ReturnName : MonoBehaviour
{
	[Serializable]
	internal sealed class _0024Start_00244706 : GenericGenerator<object>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal ReturnName _0024self__00244707;

			public _0024(ReturnName self_)
			{
				_0024self__00244707 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__00244707.isHuman)
					{
						_0024self__00244707.camBobScript = (GunAndCameraBob)_0024self__00244707.gameObject.GetComponent(typeof(GunAndCameraBob));
						_0024self__00244707.calcHealth = (FPSCalculateHealth)_0024self__00244707.gameObject.GetComponent(typeof(FPSCalculateHealth));
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					goto IL_00a2;
				case 2:
					_0024self__00244707.team = _0024self__00244707.camBobScript.team;
					goto IL_00a2;
				case 1:
					{
						result = 0;
						break;
					}
					IL_00a2:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal ReturnName _0024self__00244708;

		public _0024Start_00244706(ReturnName self_)
		{
			_0024self__00244708 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__00244708);
		}
	}

	public GameObject nameobject;

	public AIManager aimanager;

	public string team;

	public bool isHuman;

	private GunAndCameraBob camBobScript;

	private FPSCalculateHealth calcHealth;

	public virtual IEnumerator Start()
	{
		return new _0024Start_00244706(this).GetEnumerator();
	}

	public virtual string returnName()
	{
		return nameobject.name;
	}

	public virtual void returnpname(GameObject t)
	{
		if (isHuman)
		{
			int num = default(int);
			if (camBobScript.team == "red")
			{
				num = 0;
			}
			if (camBobScript.team == "blue")
			{
				num = 1;
			}
			t.SendMessage("returnedname", ((!(nameobject.name == "CarbonTech") && !(nameobject.name == "nattyfrank") && !(nameobject.name == "techietotoro") && !(nameobject.name == "Apophis") && !(nameobject.name == "Nattyfrank") && !(nameobject.name == "TheGoodGuy")) ? string.Empty : "[mod] ") + nameobject.name + " - " + calcHealth.currenthealth + "%");
			t.SendMessage("returnedteam", num);
		}
	}

	public virtual bool returnAI()
	{
		return !isHuman && aimanager.isAI;
	}

	public virtual void Main()
	{
	}
}
