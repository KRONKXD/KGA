using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class HealthManager : MonoBehaviour
{
    public int startingHealth = 100;
    public UIDocument activeUI;
    static UIDocument inGameUI;
    static int currentHealth;

    public static void TakeDamage(int damage)
    {
        currentHealth -= damage;
        inGameUI.GetComponent<UI_script>().UpdateHealth();
    }

    public static int GetHealthAmount() 
    {
        return currentHealth;
    }

    //Start is called before the first frame update
    void Start()
    {
        currentHealth = startingHealth;
        inGameUI = activeUI;
        inGameUI.GetComponent<UI_script>().UpdateHealth();
    }

    // Update is called once per frame
    //void Update()
    //{

    //}
}
