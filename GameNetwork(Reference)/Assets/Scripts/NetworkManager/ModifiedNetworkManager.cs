using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public delegate void StopHost();
public class ModifiedNetworkManager : NetworkManager
{

	public event StopHost stopHost;
	static ModifiedNetworkManager instance;

	public static ModifiedNetworkManager Instance
	{
		get { return instance; }
	}

	private void Awake()
	{
		instance = this;
	}

	public override void OnStartHost()
	{
		base.OnStartHost();

		Debug.Log("Host Started!");
	}

	public override void OnStartClient(NetworkClient client)
	{
		base.OnStartClient(client);

		Debug.Log("Client Connect!");
	}

	public override void OnStopHost()
	{
		base.OnStopHost();

		if (stopHost != null) {	stopHost();	}
	}

	public override void OnStopClient()
	{
		base.OnStopClient();
	}

}