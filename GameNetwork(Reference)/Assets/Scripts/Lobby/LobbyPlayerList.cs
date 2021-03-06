﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyPlayerList : MonoBehaviour
{
	private static LobbyPlayerList instance;

	public static LobbyPlayerList Instance
	{
		get
		{
			return instance;
		}
	}

	[SerializeField] protected List<LobbyPlayer> _playerList = new List<LobbyPlayer>();

	private void Awake()
	{
		instance = this;
	}

	public void AddPlayer(LobbyPlayer player)
	{
		if (_playerList.Contains(player))
			return;

		player.gameObject.GetComponent<Image>().color = ModifiedNetworkLobbyManager
			.Instance
			.colorArray[ModifiedNetworkLobbyManager.Instance.currentPlayerColor];

		ModifiedNetworkLobbyManager.Instance.currentPlayerColor++;

		_playerList.Add(player);

		player.transform.SetParent(this.transform, false);
	}

}