using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyFactory : MonoBehaviour
{
    public float breakTime = 0f;
    private float timer = 2f;
    public Wave[] waves;
    //public Transform[][] enemyPrefabArray;
    private int waveIndex = 0;
    public int kurisWaypoints = 0;
    private string waypointsName;

    private bool waveEnded = true;
    // Start is called before the first frame update
    void Start()
    {
        waypointsName = "Waypoints" + kurisWaypoints;
        //waves = WaveDatabase.instance.waves;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 0)
        {
            if(waveIndex < waves.Length) 
            {
                if(waveEnded)
                {
                    waveEnded = false;
                    StartCoroutine(SpawnWave(waves[waveIndex]));
                }
                if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
                {
                    timer = breakTime + waves[waveIndex].enemyPrefabArray.Length * waves[waveIndex].spawnInterval;
                    waveEnded = true;
                }
            }
            else
            {
                if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
                {
                    Invoke("WinLevel", 5f);
                }
            }
            
        }
        timer -= Time.smoothDeltaTime;
        
    }

    IEnumerator SpawnWave(Wave enemyWave)
    {
        //Debug.Log("Incoming wave");
        for (int i = 0; i < enemyWave.enemyPrefabArray.Length; i++)
        {
            //Debug.Log("Priešas");
            SpawnEnemy(enemyWave.enemyPrefabArray[i]);
            yield return new WaitForSeconds(enemyWave.spawnInterval);
        }
        waveIndex++;
    }

    void SpawnEnemy(Transform enemyPrefab)
    {
        var enemy = Instantiate(enemyPrefab, this.transform.position, this.transform.rotation);
        enemy.GetComponent<Enemy>().waypoint = GameObject.Find(waypointsName).GetComponent<waypoints>();
    }

    void WinLevel()
    {
        SceneManager.LoadScene("Win");
    }
}
