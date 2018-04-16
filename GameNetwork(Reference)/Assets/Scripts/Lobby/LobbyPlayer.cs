using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LobbyPlayer : NetworkLobbyPlayer
{

	public override void OnClientEnterLobby()
	{
		LobbyPlayerList.Instance.AddPlayer(this);
	}
}