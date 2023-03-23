//using System.Collections;
//using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public float speed = 70f;
    public float explosiveRange = 1f;

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
       if(explosiveRange > 0)
        {
            var hitColliders = Physics2D.OverlapCircleAll(transform.position, explosiveRange);
            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.gameObject.tag == "Enemy")
                {
                    //cia  jei darysim kad dmg darytu pagal atstuma nuo sprogimo centro
                    var closestPoint = hitCollider.ClosestPoint(transform.position);
                    var distance = Vector3.Distance(closestPoint, transform.position);
                    var damagePercent = Mathf.InverseLerp(explosiveRange, 0, distance);
                    //-----

                    GameObject effectIns = Instantiate(impactEffect, transform.position, transform.rotation);
                    Destroy(effectIns, 2f);
                    Destroy(hitCollider.gameObject);
                }
            }
        }
       else if(collision.gameObject.tag == "Enemy")
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
