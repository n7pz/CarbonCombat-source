using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon;
using ExitGames.Client.Photon.Lite;

public class LoadbalancingPeer : PhotonPeer
{
	public LoadbalancingPeer(IPhotonPeerListener listener, ConnectionProtocol protocolType)
		: base(listener, protocolType)
	{
	}

	public bool OpJoinLobby()
	{
		if ((int)base.DebugOut >= 3)
		{
			base.Listener.DebugReturn(DebugLevel.INFO, "JoinLobby()");
		}
		return OpCustom(229, null, true);
	}

	public bool OpLeaveLobby()
	{
		if ((int)base.DebugOut >= 3)
		{
			base.Listener.DebugReturn(DebugLevel.INFO, "OpLeaveLobby()");
		}
		return OpCustom(228, null, true);
	}

	public virtual bool OpCreateGame(string gameID, bool isVisible, bool isOpen, byte maxPlayers, bool autoCleanUp, Hashtable customGameProperties, Hashtable customActorProperties, string[] customRoomPropertiesForLobby)
	{
		if ((int)base.DebugOut >= 3)
		{
			base.Listener.DebugReturn(DebugLevel.INFO, "OpCreateGame()");
		}
		Hashtable hashtable = new Hashtable();
		hashtable[(byte)253] = isOpen;
		hashtable[(byte)254] = isVisible;
		hashtable[(byte)250] = customRoomPropertiesForLobby;
		hashtable.MergeStringKeys(customGameProperties);
		if (maxPlayers > 0)
		{
			hashtable[byte.MaxValue] = maxPlayers;
		}
		Dictionary<byte, object> dictionary = new Dictionary<byte, object>();
		dictionary[248] = hashtable;
		dictionary[249] = customActorProperties;
		dictionary[250] = true;
		if (!string.IsNullOrEmpty(gameID))
		{
			dictionary[byte.MaxValue] = gameID;
		}
		if (autoCleanUp)
		{
			dictionary[241] = autoCleanUp;
			hashtable[(byte)249] = autoCleanUp;
		}
		base.Listener.DebugReturn(DebugLevel.INFO, (byte)227 + ": " + SupportClass.DictionaryToString(dictionary));
		return OpCustom(227, dictionary, true);
	}

	public virtual bool OpJoin(string gameID, Hashtable actorProperties)
	{
		if ((int)base.DebugOut >= 3)
		{
			base.Listener.DebugReturn(DebugLevel.INFO, "OpJoin()");
		}
		if (string.IsNullOrEmpty(gameID))
		{
			base.Listener.DebugReturn(DebugLevel.ERROR, "OpJoin() failed. Please specify a roomname.");
			return false;
		}
		Dictionary<byte, object> dictionary = new Dictionary<byte, object>();
		dictionary[byte.MaxValue] = gameID;
		dictionary[249] = actorProperties;
		dictionary[250] = true;
		base.Listener.DebugReturn(DebugLevel.INFO, (byte)226 + ": " + SupportClass.DictionaryToString(dictionary));
		return OpCustom(226, dictionary, true);
	}

	public virtual bool OpJoinRandom(Hashtable expectedGameProperties)
	{
		if ((int)base.DebugOut >= 3)
		{
			base.Listener.DebugReturn(DebugLevel.INFO, "OpJoinRandom()");
		}
		Dictionary<byte, object> dictionary = new Dictionary<byte, object>();
		if (expectedGameProperties != null && expectedGameProperties.Count > 0)
		{
			dictionary[251] = expectedGameProperties;
		}
		base.Listener.DebugReturn(DebugLevel.INFO, (byte)225 + ": " + SupportClass.DictionaryToString(dictionary));
		return OpCustom(225, dictionary, true);
	}

	public bool OpSetCustomPropertiesOfActor(int actorNr, Hashtable actorProperties, bool broadcast, byte channelId)
	{
		return OpSetPropertiesOfActor(actorNr, actorProperties.StripToStringKeys(), broadcast, channelId);
	}

	protected bool OpSetPropertiesOfActor(int actorNr, Hashtable actorProperties, bool broadcast, byte channelId)
	{
		if ((int)base.DebugOut >= 3)
		{
			base.Listener.DebugReturn(DebugLevel.INFO, "OpSetPropertiesOfActor()");
		}
		Dictionary<byte, object> dictionary = new Dictionary<byte, object>();
		dictionary.Add(251, actorProperties);
		dictionary.Add(254, actorNr);
		if (broadcast)
		{
			dictionary.Add(250, broadcast);
		}
		return OpCustom(252, dictionary, broadcast, channelId);
	}

	protected void OpSetPropertyOfGame(byte propCode, object value)
	{
		Hashtable hashtable = new Hashtable();
		hashtable[propCode] = value;
		OpSetPropertiesOfGame(hashtable, true, 0);
	}

	public bool OpSetCustomPropertiesOfGame(Hashtable gameProperties, bool broadcast, byte channelId)
	{
		return OpSetPropertiesOfGame(gameProperties.StripToStringKeys(), broadcast, channelId);
	}

	public bool OpSetPropertiesOfGame(Hashtable gameProperties, bool broadcast, byte channelId)
	{
		if ((int)base.DebugOut >= 3)
		{
			base.Listener.DebugReturn(DebugLevel.INFO, "OpSetPropertiesOfGame()");
		}
		Dictionary<byte, object> dictionary = new Dictionary<byte, object>();
		dictionary.Add(251, gameProperties);
		if (broadcast)
		{
			dictionary.Add(250, broadcast);
		}
		return OpCustom(252, dictionary, broadcast, channelId);
	}

	protected bool OpAuthenticate(string appId, string appVersion)
	{
		if ((int)base.DebugOut >= 3)
		{
			base.Listener.DebugReturn(DebugLevel.INFO, "OpAuthenticate()");
		}
		Dictionary<byte, object> dictionary = new Dictionary<byte, object>();
		dictionary[220] = appVersion;
		dictionary[224] = appId;
		return OpCustom(230, dictionary, true, 0, false);
	}

	public virtual bool OpRaiseEvent(byte eventCode, Hashtable evData, bool sendReliable, byte channelId)
	{
		return OpRaiseEvent(eventCode, evData, sendReliable, channelId, EventCaching.DoNotCache, ReceiverGroup.Others);
	}

	public virtual bool OpRaiseEvent(byte eventCode, Hashtable evData, bool sendReliable, byte channelId, int[] targetActors)
	{
		return OpRaiseEvent(eventCode, evData, sendReliable, channelId, targetActors, EventCaching.DoNotCache);
	}

	public virtual bool OpRaiseEvent(byte eventCode, Hashtable evData, bool sendReliable, byte channelId, int[] targetActors, EventCaching cache)
	{
		if ((int)base.DebugOut >= 3)
		{
			base.Listener.DebugReturn(DebugLevel.INFO, "OpRaiseEvent()");
		}
		Dictionary<byte, object> dictionary = new Dictionary<byte, object>();
		dictionary[245] = evData;
		dictionary[244] = eventCode;
		if (cache != EventCaching.DoNotCache)
		{
			dictionary[247] = (byte)cache;
		}
		if (targetActors != null)
		{
			dictionary[252] = targetActors;
		}
		return OpCustom(253, dictionary, sendReliable, channelId);
	}

	public virtual bool OpRaiseEvent(byte eventCode, Hashtable evData, bool sendReliable, byte channelId, EventCaching cache, ReceiverGroup receivers)
	{
		if ((int)base.DebugOut >= 3)
		{
			base.Listener.DebugReturn(DebugLevel.INFO, "OpRaiseEvent()");
		}
		Dictionary<byte, object> dictionary = new Dictionary<byte, object>();
		dictionary[245] = evData;
		dictionary[244] = eventCode;
		if (receivers != ReceiverGroup.Others)
		{
			dictionary[246] = (byte)receivers;
		}
		if (cache != EventCaching.DoNotCache)
		{
			dictionary[247] = (byte)cache;
		}
		return OpCustom(253, dictionary, sendReliable, channelId);
	}
}
