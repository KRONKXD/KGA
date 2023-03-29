using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buildable : MonoBehaviour
{
    //public Color hoverColor;

    private GameObject tower;

    //private Renderer rend;
    //private Color startColor;

    // Start is called before the first frame update
    void Start()
    {
        //rend = GetComponent<Renderer>();
        //startColor = rend.material.color;
    }

    //// Update is called once per frame
    //void Update()
    //{

    //}

    //private void OnMouseEnter()
    //{
    //    GetComponent<Renderer>().material.color = hoverColor;
    //}

    //private void OnMouseExit()
    //{
    //    rend.material.color = startColor;
    //}

    private void OnMouseDown()
    {
        if (BuildManager.buildMode)
        {
            Vector3 mousePos = Input.mousePosition;
            //mousePos.z = Camera.main.nearClipPlane;
            mousePos.z = 0;
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
            worldPos.y += (float)(8 * 0.0625);
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(worldPos, 0f);
            Debug.Log(hitColliders.Length);
            if (hitColliders.Length < 2)
            {
                GameObject towerToBuild = BuildManager.instance.GetTowerToBuild();
                tower = (GameObject)Instantiate(towerToBuild, worldPos, transform.rotation);
                BuildManager.buildMode = false;
            }
        }
        
    }
}
