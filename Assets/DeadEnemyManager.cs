using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class DeadEnemyManager : MonoBehaviour
{
    private static Queue<GameObject> deadEnemies = new Queue<GameObject>();
    // Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}

    public static void addDeadEnemy(GameObject deadEnemy)
    {
        //Debug.Log("added an enemy"+deadEnemy);
        deadEnemies.Enqueue(deadEnemy);
        if(deadEnemies.Count > 5)
        {
            //Debug.Log("more than 5 added");
            deadEnemies.Dequeue();
        }
    }

    public static GameObject getDeadEnemy() 
    {
        //Debug.Log("reikalauja prieso lavono. Count: " + deadEnemies.Count());
        if (deadEnemies.Count > 0)
            return deadEnemies.Dequeue();
        else return null;
    }
}
