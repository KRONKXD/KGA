//using System.Collections;
//using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public float speed = 70f;

    public GameObject impactEffect;
    public void Seek(Transform _target)
    {
        target = _target;
    }

    // Start is called before the first frame update
    //void Start()
    //{
        
    //}

    // Update is called once per frame
    void Update()
    {
        //if(target == null)
        //{
        //    Destroy(gameObject);
        //    return;
        //}

        //Vector3 dir = target.position - transform.position;
        //float distanceThisFrame = speed * Time.deltaTime;

        //if(dir.magnitude <= distanceThisFrame) 
        //{
        //    HitTarget();
        //    return;
        //}

        //transform.Translate(dir.normalized * distanceThisFrame, Space.World);

        transform.position += transform.right * Time.deltaTime * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       // Debug.Log("collision");
       if(collision.gameObject.tag == "Enemy")
        {
            GameObject effectIns = Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(effectIns, 2f);
            Destroy(collision.gameObject);
        }
        
        Destroy(gameObject);
    }

    void HitTarget()
    {
        GameObject effectIns = Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 2f);
        Destroy(target.gameObject);
        Destroy(gameObject);
    }
}
