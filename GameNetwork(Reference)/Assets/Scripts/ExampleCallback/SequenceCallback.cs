using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceCallback : MonoBehaviour {

	delegate void DoSomething();
	DoSomething callStart;

	public bool isChecker;
	public bool isSuccess;
	//System.Action
	void Start()
	{
		StartSomething (()=>{
			callStart();
		});
	}

	void StartSomething(System.Action cb = null)
	{
		Debug.Log ("Starting!");


		callStart += OnStartSomething;

		if (cb != null)
			cb ();
	}

	void OnStartSomething()
	{
		Debug.Log ("it is done!");
		callStart -= OnStartSomething;
	}
}
