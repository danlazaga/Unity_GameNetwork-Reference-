using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHUD : MonoBehaviour
{
#region Variables
	[SerializeField] GameObject HUD;
#endregion

	static PlayerHUD instance;

	public static PlayerHUD Instance
	{
		get { return instance; }
	}

	private void Awake()
	{
		instance = this;

	}
	private void Start()
	{
		ModifiedNetworkManager.Instance.stopHost += DeInitialize;
	}

	private void OnDestroy()
	{
		ModifiedNetworkManager.Instance.stopHost -= DeInitialize;
	}

	public void Initialize()
	{
		HUD.SetActive(true);
	}

	void DeInitialize()
	{
		HUD.SetActive(false);
	}

}