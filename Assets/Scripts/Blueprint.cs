using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class Blueprint : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite newSprite;
    private Color tempColor;
    public GameObject buildingRange;
    private float towerRange = 0f;

    public static Blueprint instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Debug.LogError("Daugiau nei vienas Blueprint objektas");
    }

    void Start()
    {
        this.GetComponent<SpriteRenderer>().sprite = newSprite;
        tempColor = this.GetComponent<SpriteRenderer>().color;
        tempColor.a = 0;
        this.GetComponent<SpriteRenderer>().color = tempColor;
    }

    // Update is called once per frame
    void Update()
    {
        if (BuildManager.buildMode)
        {
            newSprite = BuildManager.instance.GetTowerToBuild().GetComponentInChildren<SpriteRenderer>().sprite;
            towerRange = BuildManager.instance.GetTowerToBuild().GetComponent<turret>().range;
            this.GetComponent<SpriteRenderer>().sprite = newSprite;
            tempColor.a = 0.5f;
            this.GetComponent<SpriteRenderer>().color = tempColor;
            transform.position = BuildManager.instance.gameObject.transform.position;
            buildingRange.transform.localScale = new Vector3(towerRange * 2, towerRange * 2, towerRange * 2);
            buildingRange.GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            //tempColor.a = 0;
            //this.GetComponent<SpriteRenderer>().color = tempColor;
            //buildingRange.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    public void Select(GameObject tower)
    {
        tempColor.a = 0.5f;
        this.GetComponent<SpriteRenderer>().color = tempColor;
        this.GetComponent<SpriteRenderer>().enabled = false;
        transform.position = tower.transform.position;
        towerRange = tower.GetComponent<turret>().range;
        buildingRange.transform.localScale = new Vector3(towerRange * 2, towerRange * 2, towerRange * 2);
        buildingRange.GetComponent<SpriteRenderer>().enabled = true;
    }

    public void Deselect()
    {
        tempColor.a = 0;
        this.GetComponent<SpriteRenderer>().color = tempColor;
        this.GetComponent<SpriteRenderer>().enabled = true;
        buildingRange.GetComponent<SpriteRenderer>().enabled = false;
    }
}
