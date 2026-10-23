using System;

[Serializable]
public class Friend
{
	public string username;

	public bool online;

	public Friend(string username, bool online)
	{
		this.username = username;
		this.online = online;
	}
}
