using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LobbyPlayer : NetworkLobbyPlayer {

	private LobbyPlayerList lobbyPlayerList;

	void OnEnable()
	{
		lobbyPlayerList = FindObjectOfType<LobbyPlayerList> ();
	}

	public override void OnClientEnterLobby ()
	{
		base.OnClientEnterLobby ();

		lobbyPlayerList.AddPlayer (this);
	}
}
