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

    public int splitInto = 0;
    public GameObject splitMinion;
    public bool minion = false;
    // Start is called before the first frame update
    void Start()
    {
        if(!minion)
        {
            target = waypoints.points[0];
        }
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
        healthBar.SetHealth(health);
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        MoneyManager.CurrentMoney += bounty;
        Destroy(gameObject);
        if(splitInto != 0)
        {
            for (int i = 0; i < splitInto; i++)
            {
                GameObject minion;
                Vector3 misplaceMin, misplaceMax, misplace = Vector3.zero;
                misplaceMin = transform.position;
                misplaceMin.x -= 0.3f;
                misplaceMin.y -= 0.3f;
                misplaceMax = transform.position;
                misplaceMax.x += 0.3f;
                misplaceMax.y += 0.3f;
                Random(ref misplace, misplaceMin, misplaceMax);
                minion = Instantiate(splitMinion, misplace, transform.rotation);
                minion.GetComponent<Enemy>().setWaypoint(target, waypointIndex);
            }
        }
    }

    public void setWaypoint(Transform newTarget, int newWaypointIndex)
    {
        target = newTarget;
        waypointIndex = newWaypointIndex;
    }

    public static void Random(ref Vector3 myVector, Vector3 min, Vector3 max)
    {
        myVector = new Vector3(UnityEngine.Random.Range(min.x, max.x), UnityEngine.Random.Range(min.y, max.y), UnityEngine.Random.Range(min.z, max.z));
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player Base")
        {
            HealthManager.TakeDamage(damage);
        }
    }
}
