using System.Collections;
using System.Text.RegularExpressions;
using UnityEngine;

public class WoogliePiracyProtection : MonoBehaviour
{
	private static bool validated;

	private void Awake()
	{
		TestPiracy();
		Debug.Log("Wooglie");
		Application.ExternalEval("HelloWooglie();");
	}

	private void Start()
	{
		StartCoroutine(MustHaveValidated());
	}

	private void OnLevelWasLoaded(int level)
	{
		StartCoroutine(MustHaveValidated());
	}

	private IEnumerator MustHaveValidated()
	{
		yield return new WaitForSeconds(5f);
		if (!validated)
		{
			Application.OpenURL("http://www.wooglie.com/");
		}
	}

	public void WoogliePong(string reply)
	{
		validated = true;
	}

	public static void TestPiracy()
	{
		if (Application.isWebPlayer)
		{
			if (!ValidWooglieURL(Application.absoluteURL))
			{
				Application.OpenURL("http://www.wooglie.com/?InvalidURL=" + Application.absoluteURL + "invalidType=abs");
				return;
			}
			if (!ValidWooglieURLSRC(Application.srcValue))
			{
				Application.OpenURL("http://www.wooglie.com/?InvalidURL=" + Application.srcValue + "invalidType=src");
				return;
			}
			string script = "var ind =  document.location.host.indexOf(\"wooglie.com\"); if(ind==-1){ document.location='http://www.wooglie.com/?InvalidURL='+document.location+'invalidType=js'; }var desiredIndex = document.location.host.length - 11;\nif(ind==-1 || ind!=desiredIndex ){ document.location='http://www.wooglie.com/?InvalidURL='+document.location+'invalidType=js'; } ";
			Application.ExternalEval(script);
		}
	}

	private static bool ValidWooglieURL(string URL)
	{
		URL = URL.ToLower();
		Regex regex = new Regex("http://[a-z]*.wooglie.com");
		Match match = regex.Match(URL);
		if (match.Success && match.Index == 0)
		{
			int num = URL.IndexOf("wooglie.com");
			int num2 = num + 11;
			if (num2 >= URL.Length || URL[num2] == '/')
			{
				return true;
			}
		}
		if (URL.IndexOf("http://wooglie.com/") == 0)
		{
			return true;
		}
		return false;
	}

	private static bool ValidWooglieURLSRC(string URL)
	{
		if (ValidWooglieURL(URL))
		{
			return true;
		}
		if (URL.Contains("http://"))
		{
			return false;
		}
		if (URL.Contains("https://"))
		{
			return false;
		}
		if (URL.Contains("ftp://"))
		{
			return false;
		}
		if (URL.Contains("www."))
		{
			return false;
		}
		return true;
	}
}
