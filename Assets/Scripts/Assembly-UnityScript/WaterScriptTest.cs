using System;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

[Serializable]
public class WaterScriptTest : MonoBehaviour
{
	public virtual void Awake()
	{
		Debug.Log(sha1sum("Achilles" + "SecretKKKKKKEeyHEEEERE" + "Achilles"));
	}

	public static string sha1sum(string strToEncrypt)
	{
		UTF8Encoding uTF8Encoding = new UTF8Encoding();
		byte[] bytes = uTF8Encoding.GetBytes(strToEncrypt);
		SHA1CryptoServiceProvider sHA1CryptoServiceProvider = new SHA1CryptoServiceProvider();
		byte[] array = sHA1CryptoServiceProvider.ComputeHash(bytes);
		string text = string.Empty;
		for (int i = 0; i < array.Length; i++)
		{
			text += Convert.ToString(array[i], 16).PadLeft(2, "0"[0]);
		}
		return text.PadLeft(32, "0"[0]);
	}

	public virtual void Main()
	{
	}
}
