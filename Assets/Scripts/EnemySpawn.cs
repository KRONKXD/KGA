using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[System.Serializable]
public class Wave
{
    private string waveName;
    public int numberOfEnemies;
    public GameObject[] enemyType;
    public float spawnInterval;
}
public class EnemySpawn : MonoBehaviour
{
    public waypoints waypoint = null;
    public Wave[] waves;
    public Transform[] spawnPoints;
    private Wave currentWave;
    private int currentWaveNumber;
    public float nextSpawnTime;
    private bool canSpawn = true;
    
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        currentWave = waves[currentWaveNumber];
        SpawnWave();
        GameObject[] totalEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (totalEnemies.Length == 0 && !canSpawn && currentWaveNumber + 1 != waves.Length)
        {
            currentWaveNumber++;
            canSpawn = true;
        }
    }

    void SpawnWave()
    {
        if (canSpawn && nextSpawnTime < Time.time)
        {
            GameObject randomEnemy = currentWave.enemyType[Random.Range(0, currentWave.enemyType.Length)];
            Transform randomPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(randomEnemy, randomPoint.position, Quaternion.identity);
            currentWave.numberOfEnemies--;
            nextSpawnTime = Time.time + currentWave.spawnInterval;
            if (currentWave.numberOfEnemies == 0)
            {
                canSpawn = false;
            }
        }
    }
}
