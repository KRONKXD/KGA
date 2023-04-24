using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private float spawnRate=1f;
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private bool canSpawn = true;
    public waypoints waypoint = null;
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
