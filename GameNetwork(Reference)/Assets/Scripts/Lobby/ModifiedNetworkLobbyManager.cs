using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ModifiedNetworkLobbyManager : NetworkLobbyManager
{
	[Header("UI REFERENCES")]
	public Color[] colorArray = { Color.red, Color.green };
	public int currentPlayerColor = 0;
	public RectTransform mainMenuPanel;
	public RectTransform lobbyPanel;
	public RectTransform startButton;
	RectTransform currentPanel;
	LobbyHook lobbyHooks;

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
		lobbyHooks = GetComponent<LobbyHook>();
		currentPanel = mainMenuPanel;
	}

	public override void OnStartHost()
	{
		base.OnStartHost();
		ChangeTo(lobbyPanel);
		startButton.gameObject.SetActive(true);
		Debug.Log("Host Started!");
	}

	//------ Server Callback

	public override GameObject OnLobbyServerCreateLobbyPlayer(NetworkConnection conn, short playerControllerId)
	{
		Debug.Log("NetworkConnection: " + conn.connectionId);

		return base.OnLobbyServerCreateLobbyPlayer(conn, playerControllerId);
	}

	public override bool OnLobbyServerSceneLoadedForPlayer(GameObject lobbyPlayer, GameObject gamePlayer)
	{
		//This hook allows you to apply state data from the lobby-player to the game-player
		//just subclass "LobbyHook" and add it to the lobby object.
		Debug.Log("Player Data Hooked");

		if (lobbyHooks)
			lobbyHooks.OnLobbyServerSceneLoadedForPlayer(this, lobbyPlayer, gamePlayer);

		return true;
	}

	public override void OnLobbyClientSceneChanged(NetworkConnection conn)
	{
		if (SceneManager.GetSceneAt(0).name == lobbyScene)
		{
			ChangeTo(lobbyPanel);
		}
		else
		{
			ChangeTo(null);
		}
	}

	//------ Client Callback

	public override void OnClientConnect(NetworkConnection conn)
	{
		base.OnClientConnect(conn);

		Debug.Log("Client Joined");
		if (!NetworkServer.active)
		{
			ChangeTo(lobbyPanel);
		}
	}
#endregion

	public void ChangeScene(string name)
	{
		ServerChangeScene(name);
	}

	public void ChangeTo(RectTransform newPanel)
	{
		if (currentPanel != null)
		{
			currentPanel.gameObject.SetActive(false);
		}

		if (newPanel != null)
		{
			newPanel.gameObject.SetActive(true);
		}

		currentPanel = newPanel;
	}

}