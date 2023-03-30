using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.UIElements;
using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public GameObject standartTowerPrefab;

    public static BuildManager instance;

    public static bool buildMode;
    public static bool demoMode;

    public static Vector3 worldPos;

    private GameObject towerToBuild;

    //Start is called before the first frame update
    void Start()
    {
        towerToBuild = standartTowerPrefab;
    }

    // Update is called once per frame
    void Update()
    {
        if (buildMode)
        {
            Vector3 mousePos = Input.mousePosition;
            worldPos = Camera.main.ScreenToWorldPoint(mousePos);
            worldPos.y += (8 * 0.0625f);
            ToPixels();
            //Debug.Log("esama worldPos " + worldPos + "apskaiciuotas xPix " + xPix + " apskaiciuota xCoord" + xCoord);
            transform.position = worldPos;
        }
        if (demoMode)
        {
            if (Input.GetMouseButton(0))
            {
                Vector3 mousePos = Input.mousePosition;
                worldPos = Camera.main.ScreenToWorldPoint(mousePos);
                //worldPos.y += (8 * 0.0625f);
                //ToPixels();
                //Debug.Log("esama worldPos " + worldPos + "apskaiciuotas xPix " + xPix + " apskaiciuota xCoord" + xCoord);
                transform.position = worldPos;
                Collider2D[] hitColliders = Physics2D.OverlapCircleAll(worldPos, 0f);
                foreach (var a in hitColliders)
                {
                    if (a.gameObject.tag == "Tower")
                    {
                        Debug.Log("Sold!");
                        MoneyManager.CurrentMoney += a.gameObject.GetComponent<turret>().GetTowerPrice() / 2;
                        Destroy(a.gameObject);
                    }
                }
            } 
        }
    }

    private void OnMouseDown()
    {
        
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Debug.LogError("Daugiau nei vienas Build Manager objektas");
        buildMode = false;
        demoMode = false;
    }

    public GameObject GetTowerToBuild()
    {
        return towerToBuild;
    }

    public void SetTowerToBuild(GameObject tower)
    {
        towerToBuild = tower;
    }

    private void ToPixels()
    {
        int xPix = (int)(worldPos.x / 0.0625f);
        float xCoord = xPix * 0.0625f;
        int yPix = (int)(worldPos.y / 0.0625f);
        float yCoord = yPix * 0.0625f;
        int zPix = (int)(worldPos.z / 0.0625f);
        float zCoord = zPix * 0.0625f;
        worldPos.x = xCoord;
        worldPos.y = yCoord;
        worldPos.z = zCoord;
    }
}
