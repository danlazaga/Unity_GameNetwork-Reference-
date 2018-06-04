using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.EventSystems;

public class PlayerController : NetworkBehaviour
{
	public Transform bulletSpawnPos;

	//we use over ride OnStartLocalPlayer to identify which Object
	//the player is using.
	public override void OnStartLocalPlayer()
	{
		GetComponent<MeshRenderer>().material.color = Color.green;
		DelegateManager.Instance.toUpdate += HandleUpdate;
		PlayerHUD.Instance.Initialize();
	}

	private void OnDisable()
	{
		DelegateManager.Instance.toUpdate -= HandleUpdate;
	}

	// Update is called once per frame
	void HandleUpdate()
	{
		if(EventSystem.current.IsPointerOverGameObject())
			return;

		if (Input.GetButtonDown("Fire1"))
		{
			CmdShoot();
		}

		var x = Input.GetAxis("Horizontal")* Time.deltaTime * 3.0f;
		var z = Input.GetAxis("Vertical")* Time.deltaTime * 3.0f;

		transform.Translate(x, 0, z);
	}

	[Command]
	void CmdShoot()
	{
		GameObject bullet = BulletPool.Instance.GetFromPool(bulletSpawnPos.position);
		bullet.transform.rotation = bulletSpawnPos.rotation;
		bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6;

		NetworkServer.Spawn(bullet, BulletPool.Instance.assetId);

		StartCoroutine(Destroy(bullet, 2f));
	}

	IEnumerator Destroy(GameObject go, float duration)
	{
		yield return new WaitForSeconds(duration);
		BulletPool.Instance.UnSpawnObject(go);
		NetworkServer.UnSpawn(go);
	}
}