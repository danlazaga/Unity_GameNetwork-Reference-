using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyHUD : MonoBehaviour
{
#region Variables
	[Header("UI REFERENCES")]
	public RectTransform mainMenu;
	public RectTransform lobbyMenu;
	[Space(10)]
	public Button startButton;
#endregion

#region Unity Methods
	void Start()
	{
		ModifiedNetworkLobbyManager.Instance.invokeHostEvent += HandleHostEvent;
		ModifiedNetworkLobbyManager.Instance.invokeClientEvent += HandleClientEvent;
	}

	void OnDisable()
	{
		ModifiedNetworkLobbyManager.Instance.invokeHostEvent -= HandleHostEvent;
		ModifiedNetworkLobbyManager.Instance.invokeClientEvent -= HandleClientEvent;
	}

#endregion

#region Callbacks
	void HandleHostEvent()
	{
		startButton.gameObject.SetActive(true);
	}

	void HandleClientEvent()
	{
		mainMenu.gameObject.SetActive(false);
		lobbyMenu.gameObject.SetActive(true);
	}
#endregion
}