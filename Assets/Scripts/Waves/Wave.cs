using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[System.Serializable]
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Wave", order = 1)]
public class Wave : ScriptableObject
{
    public Transform[] enemyPrefabArray;
    public float spawnInterval;

    /*
    public Wave() { }
    public Wave(Transform[] enemyPrefabArray, float spawnInterval)
    {
        this.enemyPrefabArray = enemyPrefabArray;
        this.spawnInterval = spawnInterval;
    }
    */
}
