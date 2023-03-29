using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blueprint : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite newSprite;
    private Color tempColor;
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
            tempColor.a = 0.5f;
            this.GetComponent<SpriteRenderer>().color = tempColor;
            transform.position = BuildManager.instance.gameObject.transform.position;
        }
    }

}
