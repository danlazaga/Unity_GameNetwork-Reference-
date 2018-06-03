using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Health : NetworkBehaviour
{
	public int maxHealth = 100;
	[SyncVar(hook = "OnChangeHealth")] int currentHealth;
	public RectTransform healthBar;

	public bool destroyOnDeath;

	[ServerCallback]
	private void OnEnable()
	{
		currentHealth = maxHealth;
	}

	public override void OnStartClient()
	{
		OnChangeHealth(currentHealth);
	}

	public void TakeDamage(int amount)
	{
		if (!isServer)
		{
			return;
		}
		currentHealth -= amount;

		if (currentHealth <= 0)
		{

			if (destroyOnDeath)
				Destroy(this.gameObject);
			else
			{
				currentHealth = maxHealth;

				RpcRespawn();
			}

		}

	}

	[ClientRpc]
	void RpcRespawn()
	{
		if (isLocalPlayer)
		{
			transform.position = Vector3.zero;
		}
	}

	void OnChangeHealth(int health)
	{
		healthBar.sizeDelta = new Vector2(health, healthBar.sizeDelta.y);
	}
}