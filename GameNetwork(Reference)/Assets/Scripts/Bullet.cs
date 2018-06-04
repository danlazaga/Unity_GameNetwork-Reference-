using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Bullet : MonoBehaviour {

	void OnCollisionEnter(Collision collision)
	{
		var hit = collision.gameObject;
		var health = hit.GetComponent<Health> ();
		if (health != null) {
			health.TakeDamage (10);
		}

		BulletPool.Instance.UnSpawnObject(this.gameObject);
		NetworkServer.UnSpawn(this.gameObject);
	}
}
