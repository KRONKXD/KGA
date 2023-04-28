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
}
public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private float spawnRate=1f;
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private bool canSpawn = true;

    public waypoints waypoint = null;

    [SerializeField] private Wave[] waves;
    private int currentWaveNumber;


    static int numberOfEnemies;
    
    // Start is called before the first frame update
    void Start()
    {
        numberOfEnemies++;
        StartCoroutine(Spawner());
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] totalenemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (totalenemies.Length == 0 && !canSpawn)
        {
            currentWaveNumber++;
        }
    }

    private IEnumerator Spawner()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);
        while (canSpawn)
        {
            yield return wait;
            int random = Random.Range(0, enemyPrefabs.Length);
            GameObject enemyToSpawn = enemyPrefabs[random];
            GameObject enemy = Instantiate(enemyToSpawn, transform.position, Quaternion.identity);
            numberOfEnemies++;
            enemy.GetComponent<Enemy>().waypoint = waypoint;
        }
    }

    public static int GetNumberOfEnemies()
    {
        return numberOfEnemies;
    }
}
