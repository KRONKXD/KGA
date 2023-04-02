using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2f;
    public int bounty = 60;

    private Transform target;
    private int waypointIndex = 0;
    public int maxHealth = 100;
    public int health = 100;
    public int damage = 1;
    private int currentHealth;
    public HealthBar healthBar;



    // Start is called before the first frame update
    void Start()
    {
        target = waypoints.points[0];
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
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

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    private void OnDestroy()
    {
        MoneyManager.CurrentMoney += bounty;
    }

    void Die()
    {
        Destroy(gameObject);
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
