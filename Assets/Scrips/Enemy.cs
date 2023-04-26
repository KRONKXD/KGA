using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public AudioSource soundPlayer;
    public AudioClip deadSound;

    public EnemySpawn enemySpawn;

    public float speed = 2f;
    public int bounty = 60;

    private Transform target;
    private int waypointIndex = 0;
    public int maxHealth = 100;
    public int health = 100;
    public int damage = 1;
    private int currentHealth;
    public HealthBar healthBar;
    public waypoints waypoint = null;

    public int splitInto = 0;
    public GameObject splitMinion;
    public bool minion = false;

    //freeze stuff
    private bool freezeTimerRunning = false;
    private float freezeTimer = 0f;
    private float oldSpeed = 0f;
    private Color frozenColor = Color.blue;

    //necro stuff
    public bool necromancer = false;
    public float reviveCD = 0f;
    //private bool necroTimerRunning = true;
    private float necroTimer = 0f;
    private Color revivedColor = Color.gray;
    public float reviveExec = 0f;
    private float reviveTimer = 0f;
    static int enemiesKilled;
    private bool revived = false;

    // Start is called before the first frame update
    void Start()
    {
        if(!minion && !revived)
        {
            target = waypoint.points[0];
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

        if (freezeTimerRunning)
        {
            //Debug.Log(freezeTimer);
            freezeTimer -= Time.smoothDeltaTime;
            if (freezeTimer >= 0)
            { 
            }
            else
            {
                freezeTimerRunning = false;
               // speed = oldSpeed;
                //this.GetComponent<SpriteRenderer>().color = Color.white;
               // this.GetComponent<Animator>().speed = 1;
            }
        }

        if (necromancer)
        {
            //Debug.Log(necroTimer);
            necroTimer -= Time.smoothDeltaTime;
            if (necroTimer >= 0 )
            {
                
            }
            else
            {
                if (speed != 0)
                    oldSpeed = speed;
                speed = 0;
                reviveTimer -= Time.smoothDeltaTime;
                if (reviveTimer >= 0)
                {
                    //Debug.Log("baiges laikas, bandom revive");
                    //necroTimerRunning = false;
                    
                }
                else
                {
                    Revive();
                    speed = oldSpeed;
                }
                
            }
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        healthBar.SetHealth(health);
        if (health <= 0)
        {
            //soundPlayer.PlayOneShot(deadSound);
            Die();
        }
    }

    void Die()
    {
        soundPlayer.PlayOneShot(deadSound);
        MoneyManager.CurrentMoney += bounty;
        enemiesKilled++;
        if (!minion && !revived)
        {
            GameObject copy = Instantiate(this.gameObject, transform.position, transform.rotation);
            copy.GetComponent<Enemy>().setWaypoint(target, waypointIndex);
            copy.GetComponent<Enemy>().waypoint = waypoint;
            copy.SetActive(false);
            DeadEnemyManager.addDeadEnemy(copy);
        }
            
        Destroy(gameObject);
        HealthManager.diedEnemyNumber++;
        
        if (splitInto != 0)
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
                minion.GetComponent<SpriteRenderer>().color = this.GetComponent<SpriteRenderer>().color;
                minion.GetComponent<Enemy>().setWaypoint(target, waypointIndex);
                minion.GetComponent<Enemy>().waypoint = waypoint;
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
        if (waypointIndex >= waypoint.points.Length - 1)
        {
            soundPlayer.PlayOneShot(deadSound);
            Destroy(gameObject);
            return;
        }
        waypointIndex++;
        target = waypoint.points[waypointIndex];
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player Base")
        {
            HealthManager.TakeDamage(damage);
        }
    }

    public void Freeze(float freezeTime)
    {
        if(speed != 0)
        oldSpeed = speed;
        speed = 0;
        this.GetComponent<SpriteRenderer>().color = frozenColor;
        this.GetComponent<Animator>().speed = 0;
        freezeTimerRunning = true;
        freezeTimer = freezeTime;
    }

    private void Revive()
    {
        
        GameObject target = DeadEnemyManager.getDeadEnemy();
        //Debug.Log(target);
        if(target != null)
        {
            //Instantiate(target, transform.position, transform.rotation);
            target.GetComponent<Enemy>().maxHealth /= 2;
            target.GetComponent<Enemy>().health = target.GetComponent<Enemy>().maxHealth;
            target.GetComponent<SpriteRenderer>().color = revivedColor;
            target.GetComponent<Enemy>().revived = true;
            target.GetComponent<Enemy>().bounty /= 10;
            target.SetActive(true);
        }

        //necroTimerRunning = true;
        necroTimer = reviveCD;
        speed = oldSpeed;
        reviveTimer = reviveExec;

    }

    public static int GetNumberOfEnemiesDied()
    {
        return enemiesKilled;
    }
}
