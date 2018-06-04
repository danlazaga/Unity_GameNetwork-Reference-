using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	[SerializeField] GameObject player;
	[SerializeField] int mouseXspeedMod = 1;
	[SerializeField] int mouseYSpeedMod = 1;
	Vector2 currentLook;

	// private void Start()
	// {
	// 	Cursor.lockState = CursorLockMode.Locked;
	// }

	/// <summary>
	/// LateUpdate is called every frame, if the Behaviour is enabled.
	/// It is called after all Update functions have been called.
	/// </summary>
	void Update()
	{
		Vector2 look = new Vector2(Input.GetAxisRaw("Mouse X") * mouseXspeedMod, Input.GetAxisRaw("Mouse Y")* mouseYSpeedMod);

		currentLook += look;
		currentLook.y = Mathf.Clamp(currentLook.y, -90, 90);

		transform.localRotation = Quaternion.AngleAxis(-currentLook.y, Vector3.right);
		player.transform.localRotation = Quaternion.AngleAxis(currentLook.x, player.transform.up);
	}



}