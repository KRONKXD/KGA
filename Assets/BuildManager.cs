using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public GameObject standartTowerPrefab;

    public static BuildManager instance;

    public static bool buildMode;

    private GameObject towerToBuild;

    //Start is called before the first frame update
    void Start()
    {
        towerToBuild = standartTowerPrefab;
    }

    //// Update is called once per frame
    //void Update()
    //{

    //}

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Debug.LogError("Daugiau nei vienas Build Manager objektas");
        buildMode = false;
    }

    public GameObject GetTowerToBuild()
    {
        return towerToBuild;
    }
}
