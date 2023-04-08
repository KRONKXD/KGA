using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blueprint : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite newSprite;
    private Color tempColor;
    public GameObject buildingRange;
    private float towerRange = 0f;
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
        if(BuildManager.buildMode)
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
            tempColor.a = 0;
            this.GetComponent<SpriteRenderer>().color = tempColor;
            buildingRange.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
