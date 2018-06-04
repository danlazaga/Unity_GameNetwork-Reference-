using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegateManager : MonoBehaviour
{

	public delegate void ToUpdate();
	public ToUpdate toUpdate;

	private static DelegateManager instance;

	public static DelegateManager Instance
	{
		get
		{
			return instance;
		}
	}

	void Awake()
	{
		instance = this;
	}

	void Update()
	{
		if (toUpdate != null)toUpdate();
	}

}