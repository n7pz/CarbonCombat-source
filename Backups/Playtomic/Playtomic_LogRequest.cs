using System.Collections.Generic;

public class Playtomic_LogRequest
{
	private static int Failed = 0;

	private static List<Playtomic_LogRequest> Pool = new List<Playtomic_LogRequest>();

	private string Data = string.Empty;

	public bool Ready;

	public static Playtomic_LogRequest Create()
	{
		Playtomic_LogRequest playtomic_LogRequest = null;
		if (Pool.Count > 0)
		{
			playtomic_LogRequest = Pool[0];
			Pool.RemoveAt(0);
		}
		else
		{
			playtomic_LogRequest = new Playtomic_LogRequest();
		}
		playtomic_LogRequest.Data = string.Empty;
		playtomic_LogRequest.Ready = false;
		return playtomic_LogRequest;
	}

	public void MassQueue(List<string> data)
	{
		if (Failed > 3)
		{
			return;
		}
		for (int num = data.Count - 1; num > -1; num--)
		{
			Data = Data + ((!(Data == string.Empty)) ? "~" : string.Empty) + data[num];
			data.RemoveAt(num);
			if (Data.Length > 300)
			{
				Playtomic_LogRequest playtomic_LogRequest = Create();
				playtomic_LogRequest.MassQueue(data);
				Ready = true;
				Send();
				return;
			}
		}
		Playtomic.Log.Request = this;
	}

	public void Queue(string data)
	{
		if (Failed <= 3)
		{
			if (Data.Length > 0)
			{
				Data += "~";
			}
			Data += data;
			if (Data.Length > 300 || data.StartsWith("v/") || data.StartsWith("t/"))
			{
				Ready = true;
			}
		}
	}

	public void Send()
	{
		Playtomic.API.StartCoroutine(Playtomic_Request.SendStatistics(Data));
		Pool.Add(this);
	}
}
