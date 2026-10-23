using System;

[Serializable]
public class NetPlayer
{
	public PhotonPlayer nplayer;

	public string username;

	public int kills;

	public int deaths;

	public string team;

	public bool isAI;

	public NetPlayer(PhotonPlayer nplayer, string username, int kills, int deaths, string team, bool isAI)
	{
		this.nplayer = nplayer;
		this.username = username;
		this.kills = kills;
		this.deaths = deaths;
		this.team = team;
		this.isAI = isAI;
	}
}
