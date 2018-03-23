using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ModifiedNetworkLobbyManager : NetworkLobbyManager
{
	[Header("LOBBY HUD REFERENCES")]
	[SerializeField] LobbyHUD lobbyHUD;

	[Header("UI REFERENCES")]
	public Color[] colorArray = { Color.red, Color.green };
	public int currentPlayerColor = 0;

	private static ModifiedNetworkLobbyManager instance;

	public static ModifiedNetworkLobbyManager Instance
	{
		get
		{
			return instance;
		}
	}

#region Unity Methods
	void Awake()
	{
		instance = this;
	}

	void Start()
	{
		lobbyHUD.invokeHostEvent += StartHostModified;
		lobbyHUD.invokeClientEvent += JoinGame;
		lobbyHUD.invokeStartGame += StartGame;
	}

	void OnDestroy()
	{
		lobbyHUD.invokeHostEvent -= StartHostModified;
		lobbyHUD.invokeClientEvent -= JoinGame;
		lobbyHUD.invokeStartGame -= StartGame;
	}
#endregion

	void StartHostModified()
	{
		StartHost();
	}

	void JoinGame(string ipAddressInputField)
	{
		networkAddress = ipAddressInputField;

		StartClient();
	}

	public override void OnStartHost()
	{
		base.OnStartHost();

		Debug.Log("Host Started!");
	}

	public override void OnStartClient(NetworkClient client)
	{
		base.OnStartClient(client);

		Debug.Log("Connected!");
	}

	void StartGame()
	{
		ServerChangeScene("LobbyScene");
	}

	public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
	{
		var player = (GameObject)GameObject.Instantiate(gamePlayerPrefab, Vector3.zero, Quaternion.identity);
		NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
	}
}