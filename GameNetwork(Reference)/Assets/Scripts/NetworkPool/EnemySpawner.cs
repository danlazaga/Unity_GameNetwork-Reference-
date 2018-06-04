using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class EnemySpawner : NetworkBehaviour
{
    [SerializeField] bool canSpawn = false;

    [Header("Spawn Properties")]
    // maximum wave amount
    public int maxWaveAmount;

    // current wave amount
    int waveAmount = 0;

    // maximum spawn interval
    [SerializeField] private float maxSpawnRate;
    // current spawn rate
    [SerializeField] float spawnRate;

    // Player Wait Time before next wave
    private WaitForSeconds waitTime = new WaitForSeconds(10f);

    // Minimum and maximum Spawn addition
    private int minAddSpawn;
    private int maxAddSpawn;

#region Unity Methods
    public override void OnStartServer()
    {
        maxWaveAmount = 5;
        maxSpawnRate = 3f;

        minAddSpawn = 4;
        maxAddSpawn = 9;

        HandleStartSpawn();
    }

    private void OnDisable()
    {
        spawnRate = 0;
        canSpawn = false;
    }

    private void Update()
    {
        if (!isServer)
            return;

        if (canSpawn)
        {
            spawnRate += Time.deltaTime;
            if (spawnRate >= maxSpawnRate)
            {
                SpawnEnemy();
                spawnRate = 0;
            }
            if (waveAmount >= maxWaveAmount)
            {
                canSpawn = false;
                waveAmount = 0;

                StartCoroutine(IncreaseSpawn());
            }

        }
    }
#endregion

    void HandleStartSpawn()
    {
        StartCoroutine(IncreaseSpawn());
    }

    IEnumerator IncreaseSpawn()
    {
        int amount = Random.Range(minAddSpawn, maxAddSpawn);
        maxWaveAmount += amount;

        yield return waitTime;

        Debug.Log("Resume, New Wave Amount: " + maxWaveAmount);

        canSpawn = true;
    }

    // Spawn Enemy Randomly

    void SpawnEnemy()
    {
        GameObject obj = EnemyPool.Instance.GetFromPool(RandomizePos());
        NetworkServer.Spawn(obj, EnemyPool.Instance.assetId);
    }

    Vector3 RandomizePos()
    {
        var spawnPosition = new Vector3(
            Random.Range(-8.0f, 8.0f),
            0.0f,
            Random.Range(-8.0f, 8.0f));

        return spawnPosition;
    }
}