using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegateController : MonoBehaviour {

	void Move()
	{
		Debug.Log ("I'm moving!");
	}

	public void RegisterFunction()
	{
		DelegateManager.Instance.toUpdate += Move;
	}

	public void UnRegisterFunction()
	{
		DelegateManager.Instance.toUpdate -= Move;
	}
}
