using System.Collections.Generic;

public class Playtomic_Responder
{
	public Dictionary<string, Playtomic_Response> Responses = new Dictionary<string, Playtomic_Response>();

	public Playtomic_Response GetResponse(string name)
	{
		if (Responses.ContainsKey(name))
		{
			return Responses[name];
		}
		return Playtomic_Response.GeneralError("No response found");
	}

	public void SetResponse(Playtomic_Response response, string name)
	{
		if (Responses.ContainsKey(name))
		{
			Responses[name] = response;
		}
		else
		{
			Responses.Add(name, response);
		}
	}
}
