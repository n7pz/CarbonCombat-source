using System;
using System.Security.Cryptography;
using System.Text;

internal class Playtomic_Encode
{
	public static string MD5(string input)
	{
		MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
		byte[] array = mD5CryptoServiceProvider.ComputeHash(Encoding.UTF8.GetBytes(input));
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < array.Length; i++)
		{
			stringBuilder.Append(array[i].ToString("x2"));
		}
		return stringBuilder.ToString();
	}

	public static string Base64(string data)
	{
		byte[] array = new byte[data.Length];
		array = Encoding.UTF8.GetBytes(data);
		return Convert.ToBase64String(array);
	}
}
