using UnityEngine;
using System.Collections;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;

    public float remainingEnemies = 0;
    public float totalEnemies = 1;

    public GameObject[] enemies;
    public float spawnDelay;

    private void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        remainingEnemies = enemies.Length;

        if (remainingEnemies == 0)
        {
            StartCoroutine(SpawnWave());
        }

    }

    IEnumerator SpawnWave()
    {
        for (int i = 0; i < totalEnemies; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnDelay);
        }

        totalEnemies = totalEnemies * 2;
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
