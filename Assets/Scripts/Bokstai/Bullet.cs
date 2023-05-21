//using System.Collections;
//using System.Collections.Generic;

using System;
using System.Security.Cryptography;
using TMPro;
using UnityEditor.Build;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.XR;
using static UnityEngine.GraphicsBuffer;

public class Bullet : MonoBehaviour
{
    //private Transform target;
    public float speed = 70f;
    public int damage = 1;
    public float explosiveRange = 0f;
    public float freezeTime = 0f;

    //public Enemy enemy;
    bool hit = false;

    public bool notification = false;
    //public float notif_duration = 0f;
    //private Vector3 target = new Vector3();
    //private Vector3 velocity = Vector3.zero;

    public GameObject impactEffect;
    //public void Seek(Transform _target)
    //{
    //    target = _target;
    //}

    // Start is called before the first frame update
    //void Start()
    //{
   
    //}

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * Time.deltaTime * speed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hit)
            return;
        if(collision.gameObject.tag != "Bullet" && collision.gameObject.tag != "Tower" && collision.gameObject.tag != "Grass")
        {
            hit = true;
            Destroy(gameObject);
        }
        if (explosiveRange > 0)
        {
            var hitColliders = Physics2D.OverlapCircleAll(transform.position, explosiveRange);
            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.gameObject.tag == "Enemy")
                {
                    this.GetComponent<Collider2D>().enabled = false;
                    hitCollider.gameObject.GetComponent<Enemy>().TakeDamage(damage);
                    //cia  jei darysim kad dmg darytu pagal atstuma nuo sprogimo centro
                    //var closestPoint = hitCollider.ClosestPoint(transform.position);
                    //var distance = Vector3.Distance(closestPoint, transform.position);
                    //var damagePercent = Mathf.InverseLerp(explosiveRange, 0, distance);
                    //-----
                    GameObject effectIns = Instantiate(impactEffect, transform.position, transform.rotation);
                    Destroy(effectIns, 2f);
                    if (freezeTime > 0)
                    {
                        hitCollider.gameObject.GetComponent<Enemy>().Freeze(freezeTime);
                    }
                    //Destroy(hitCollider.gameObject);
                    //hit = true;
                    //Destroy(gameObject);
                }
            }
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            this.GetComponent<Collider2D>().enabled = false;
            collision.gameObject.GetComponent<Enemy>().TakeDamage(damage);
            
            GameObject effectIns = Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(effectIns, 2f);
            if (freezeTime > 0)
            {
                collision.gameObject.GetComponent<Enemy>().Freeze(freezeTime);
            }
            //Destroy(collision.gameObject);
            //hit = true;
            //Destroy(gameObject);
        }
        //else if (collision.gameObject.tag != "Bullet")
        //{
        //    hit = true;
        //    Destroy(gameObject);
        //}
        
    }
}
