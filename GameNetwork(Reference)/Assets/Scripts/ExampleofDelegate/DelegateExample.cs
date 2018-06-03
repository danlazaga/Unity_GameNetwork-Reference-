using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegateExample : MonoBehaviour
{

	void Start()
	{
		DelegateManager.Instance.toUpdate += Jump;
	}

	private void OnDestroy()
	{
		DelegateManager.Instance.toUpdate -= Jump;
	}

	void Jump()
	{
		Debug.LogError("Jump");
	}
}