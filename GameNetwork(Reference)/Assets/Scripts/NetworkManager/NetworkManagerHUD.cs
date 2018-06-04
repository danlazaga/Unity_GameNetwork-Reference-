using System;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

[RequireComponent(typeof(ModifiedNetworkManager))]
public class NetworkManagerHUD : MonoBehaviour
{
#region Variables
	ModifiedNetworkManager manager;
	[SerializeField] GameObject menu;
	[SerializeField] GameObject connectingPanel;
	[SerializeField] InputField inputField;
	[SerializeField] Text ipAddress;
#endregion

#region Unity Methods
	private void Awake()
	{
		manager = GetComponent<ModifiedNetworkManager>();
	}

	private void Update()
	{
		bool noConnection = (manager.client == null || manager.client.connection == null ||
			manager.client.connection.connectionId == -1);

		if (!manager.IsClientConnected()&& !NetworkServer.active)
		{
			if (noConnection)
			{
				menu.SetActive(true);
				connectingPanel.SetActive(false);
			
			}
			else
			{
				menu.SetActive(false);
				connectingPanel.SetActive(true);
	
				ipAddress.text = "Connecting to " + manager.networkAddress + " : " + manager.networkPort + "..";
			}
		}

		if (NetworkServer.active || manager.IsClientConnected())
		{
			menu.SetActive(false);
			connectingPanel.SetActive(false);
		}
	}

#endregion

	public void StartHost()
	{
		if (!manager.IsClientConnected()&& !NetworkServer.active)
		{

			manager.StartHost();

		}
	}

	public void StartClient()
	{
		manager.networkAddress = inputField.text;
		manager.StartClient();
	}

	public void StopHost()
	{
		if (NetworkServer.active || manager.IsClientConnected())
		{
			manager.StopHost();
		}
	}

	//Try to Connect to Server
	public void StopClient()
	{
		manager.StopClient();
	}

}