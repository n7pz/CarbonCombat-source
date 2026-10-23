using System;
using Boo.Lang.Runtime;

[Serializable]
public class AIPlayer
{
	public string ainame;

	public string ainame2;

	public string ainame3;

	public string location;

	public int maxplayers;

	public string gametype;

	public string whirldurl;

	public int avgXP;

	public AIPlayer(string ainame, string location, int maxplayers, string ainame2, string ainame3, string gametype, string whirldurl, object avgXP)
	{
		this.ainame = ainame;
		this.ainame2 = ainame2;
		this.ainame3 = ainame3;
		this.location = location;
		this.maxplayers = maxplayers;
		this.gametype = gametype;
		this.whirldurl = whirldurl;
		this.avgXP = RuntimeServices.UnboxInt32(avgXP);
	}
}
