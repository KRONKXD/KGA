using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Mime;
using System.Threading;
using UnityEngine;

public class enemy_movement : MonoBehaviour
{
    public float speed = 10f;
    public int bounty = 30;
    private Transform target;
    private int waypointIndex = 0;



    // Start is called before the first frame update
    void Start()
    {
        target = waypoints.points[0];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.1f)
        {
            GetNextWaypoint();
        }
    }

    private void OnDestroy()
    {
        MoneyManager.CurrentMoney += bounty;
    }

    void GetNextWaypoint()
    {
        if (waypointIndex >= waypoints.points.Length - 1) 
        {
            Destroy(gameObject);
            return;
        }
        waypointIndex++;
        target = waypoints.points[waypointIndex];
    }
}
