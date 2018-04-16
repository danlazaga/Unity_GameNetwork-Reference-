using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkLobbyHook : LobbyHook
{

#region Unity Methods
	public override void OnLobbyServerSceneLoadedForPlayer(NetworkManager manager, GameObject lobbyPlayer, GameObject gamePlayer)
	{
		LobbyPlayer lobby = lobbyPlayer.GetComponent<LobbyPlayer>();
		PlayerController controller = gamePlayer.GetComponent<PlayerController>();

		controller.name = lobby.name;
	}
#endregion
}