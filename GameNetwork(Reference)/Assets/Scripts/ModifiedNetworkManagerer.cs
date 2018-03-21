using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;


public class ModifiedNetworkManager : NetworkLobbyManager {

	[Header("UI REFERENCES")]
	public InputField ipAddressInputField; 

	public RectTransform mainMenu;

	public void StartHostModified()
	{
		StartHost ();
	}

	public override void OnStartHost ()
	{
		base.OnStartHost ();

		Debug.Log ("Host Started!");
	}

	public void JoinGame()
	{
		networkAddress = ipAddressInputField.text;

		StartClient ();
	}

	public override void OnStartClient (NetworkClient client)
	{
		base.OnStartClient (client);


		//this is a public RectTransform mainMenu :D 
		mainMenu.gameObject.SetActive (false);	

		Debug.Log ("Connected!");
	}

}
