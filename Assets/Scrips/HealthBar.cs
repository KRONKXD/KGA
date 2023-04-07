using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    private Image[] images;
    public void SetMaxHealth(int    health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
    public void SetHealth(int health)
    {
        slider.value = health;
    }
    // Start is called before the first frame update
    void Start()
    {
        images = this.GetComponentsInChildren<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (slider.value == slider.maxValue)
        {
            images[0].enabled = false;
            images[1].enabled = false;
        }
        else
        {
            images[0].enabled = true;
            images[1].enabled = true;
        }
    }
}
