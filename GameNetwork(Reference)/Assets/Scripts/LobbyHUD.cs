using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyHUD : MonoBehaviour
{
#region Variables
	[Header("UI REFERENCES")]
	[SerializeField] RectTransform mainMenu;
	[SerializeField] RectTransform lobbyMenu;
	[SerializeField] InputField ipAddressInputField;
	[SerializeField] Button startButton;

	public delegate void InvokeHost();
	public event InvokeHost invokeHostEvent;

	public delegate void InvokeClient(string input);
	public event InvokeClient invokeClientEvent;

	public delegate void InvokeStartGame();
	public event InvokeStartGame invokeStartGame;
#endregion

#region Functions
	public void OnClickStartHost()
	{
		if (invokeHostEvent != null) { invokeHostEvent(); }
		startButton.gameObject.SetActive(true);

		mainMenu.gameObject.SetActive(false);
		lobbyMenu.gameObject.SetActive(true);
	}

	public void OnClickJoin()
	{
		if (invokeClientEvent != null) { invokeClientEvent(ipAddressInputField.text); }

		mainMenu.gameObject.SetActive(false);
		lobbyMenu.gameObject.SetActive(true);
	}

	public void OnClickStartGame()
	{
		if (invokeStartGame != null)invokeStartGame();

		lobbyMenu.gameObject.SetActive(false);
	}
#endregion
}