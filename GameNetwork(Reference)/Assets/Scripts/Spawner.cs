﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Spawner : NetworkBehaviour {

	public GameObject targetPrefab;
	public int numberOfTargets;

	public override void OnStartServer()
	{
		for (int i = 0; i < numberOfTargets; i++) {
			var spawnPosition = new Vector3 (
				                   Random.Range (-8.0f, 8.0f), 
				                   0.0f, 
				                   Random.Range (-8.0f, 8.0f));

			var spawnRotation = Quaternion.Euler (0.0f, Random.Range (0, 180), 0.0f);

			var target = (GameObject)Instantiate (targetPrefab, spawnPosition, spawnRotation);
			NetworkServer.Spawn (target);
		}
	}

	}
