using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PauseMenu : MonoBehaviour 
{
#region Variables
	[SerializeField] GameObject pauseHud;
#endregion

#region Unity Methods

	void Update () 
	{
		if(!NetworkServer.active)
			return;

		if(Input.GetButtonDown("Cancel"))
		{
			pauseHud.SetActive(!pauseHud.activeSelf);
		}
	}
#endregion
}
