using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyFactory : MonoBehaviour
{
    public float breakTime = 0f;
    private float timer = 3f;
    public Wave[] waves;
    //public Transform[][] enemyPrefabArray;
    private int waveIndex = 0;
    public int kurisWaypoints = 0;
    private string waypointsName;
    private UI_script UI;

    private bool waveEnded = true;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        waypointsName = "Waypoints" + kurisWaypoints;
        UI = GameObject.Find("UIDocument").GetComponent<UI_script>();
        UI.UpdateWave(waveIndex + 1, waves.Length, (int)timer);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 0)
        {
            if (waveIndex < waves.Length)
            {
                if (waveEnded)
                {
                    waveEnded = false;
                    StartCoroutine(SpawnWave(waves[waveIndex]));
                }
                if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
                {
                    //timer = breakTime + waves[waveIndex].enemyPrefabArray.Length * waves[waveIndex].spawnInterval;
                    timer = breakTime;
                    waveEnded = true;
                    
                    UI.UpdateWave(waveIndex + 1, waves.Length, (int)breakTime);
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
        Time.timeScale = 0f;
        GameObject.Find("Menus").transform.GetChild(2).gameObject.SetActive(true);
        //SceneManager.LoadScene("Win");
    }
}
