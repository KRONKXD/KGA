using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class  turret : MonoBehaviour
{
    private Transform target;
    private turret instance;

    [Header("Audio")]

    //public AudioSource soundPlayer;
    public AudioClip shot;

    [Header("Attributes")]

    public float range = 15f;
    public float fireRate = 1f;
    public int price = 100;
    private float fireCountdown = 0f;

    [Header("Money Generator settings")]

    public bool moneyGenerator = false;
    public int moneyAmount = 0;
    public float moneyRate = 0f;
    public GameObject moneyEffect;

    [Header("Unity Setup Fields")]
    public string enemyTag = "Enemy";

    public Transform partToRotate;
    //public float turnSpeed = 10f;

    public Bullet bulletPrefab;
    public Transform firePoint;

    public int damage = 40;
    
    // Start is called before the first frame update
    void Start()
    {
        if (!moneyGenerator)
            InvokeRepeating("UpdateTarget", 0f, 0.25f);
        else
        {
            moneyEffect = Instantiate(moneyEffect, transform.position, Quaternion.Euler(0, 0, 0));
            moneyEffect.GetComponent<ParticleSystem>().Stop();
            InvokeRepeating("MakeMoney", moneyRate, moneyRate);
        }
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range) 
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    // Update is called once per frame
    void Update()
    { 
        if (target == null)
            return;

        //Vector3 dir = target.position - transform.position;
        //Quaternion lookRotation = Quaternion.LookRotation(dir);
        //Vector3 rotation = lookRotation.eulerAngles;
        //partToRotate.rotation = Quaternion.Euler(0f, 0f, rotation.z);

        //is neto fixas ant 2d
        Vector3 dir = target.position - transform.position;
        Vector3 rotatedVectorDir = Quaternion.Euler(0, 0, 90) * dir;
        //(You might have to adjust the rotation to point in the right direction, it worked at 180 for me)
        Quaternion lookRotation = Quaternion.LookRotation(forward: Vector3.forward, upwards: rotatedVectorDir);
        //Quaternion rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed);
        partToRotate.rotation = lookRotation;

        if (fireCountdown <= 0f)
        {
            
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;
    }

    void Shoot()
    {
        //soundPlayer.PlayOneShot(shot);
        SFXManager.instance.PlaySound(shot);
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    // Kad nupiestu per Gizmo range tureto kai ant jo paspaudi
    // void OnDrawGizmos() jei nori kad visada rodytu
    // void OnDrawGizmosSelected() jei nori kad tik pasirinkus rodytu
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    public int GetTowerPrice()
    {
        return price;
    }

    void MakeMoney()
    {
        MoneyManager.CurrentMoney += moneyAmount;

        //Vector3 dir = transform.position;
        ////Vector3 rotatedVectorDir = Quaternion.Euler(0, 0, 90) * dir;
        //Vector3 rotatedVectorDir = Quaternion.Euler(0, 0, 135) * Vector3.one;
        ////(You might have to adjust the rotation to point in the right direction, it worked at 180 for me)
        //Quaternion lookRotation = Quaternion.LookRotation(forward: Vector3.forward, upwards: rotatedVectorDir);
        ////Quaternion rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed);
        //partToRotate.rotation = lookRotation;
        //Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        moneyEffect.GetComponent<ParticleSystem>().Play();

    }
}
