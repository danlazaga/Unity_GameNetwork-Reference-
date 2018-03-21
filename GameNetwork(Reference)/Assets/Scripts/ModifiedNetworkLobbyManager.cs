using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ModifiedNetworkLobbyManager : NetworkLobbyManager
{
	public delegate void GameEvent();
	public event GameEvent invokeHostEvent;
	public event GameEvent invokeClientEvent;

	[Header("UI REFERENCES")]
	public InputField ipAddressInputField;
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

	void Awake()
	{
		instance = this;
	}

	public void StartHostModified()
	{
		StartHost();
	}

	public override void OnStartHost()
	{
		base.OnStartHost();

		if (invokeHostEvent != null) { invokeHostEvent(); }
		Debug.Log("Host Started!");
	}

	public void JoinGame()
	{
		networkAddress = ipAddressInputField.text;

		StartClient();
	}

	public override void OnStartClient(NetworkClient client)
	{
		base.OnStartClient(client);

		if (invokeClientEvent != null) { invokeClientEvent(); }
		Debug.Log("Connected!");
	}

	public void OnStartGame()
	{
		ServerChangeScene("LobbyScene");
	}
}