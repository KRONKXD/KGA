using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    public int startingHealth = 100;
    public UIDocument activeUI;
    static UIDocument inGameUI;
    static int currentHealth;
    static int enimyNumber = EnemySpawn.GetNumberOfEnemies();
    static int diedEnemyNumber = Enemy.GetNumberOfEnemiesDied();
    //enimyNumber=enimyNumber+3;
    //static int x = 0;

    public static void TakeDamage(int damage)
    {
        currentHealth -= damage;
        inGameUI.GetComponent<UI_script>().UpdateHealth();
        diedEnemyNumber++;
        //x++;
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
    //static int enimyNumber = EnemySpawn.GetNumberOfEnemies();
    //public int diedEnemyNumber = Enemy.GetNumberOfEnemiesDied();

    public static void OnTriggerEnter()
    {
        //int health = inGameUI.GetComponent<UI_script>().UpdateHealth();
        // int currentHealth = HealthManager.GetHealthAmount();

        if(enimyNumber <= diedEnemyNumber && currentHealth > 0 && currentHealth < 100)
        {
            SceneManager.LoadScene("Win");
        }

        if (currentHealth <= 0)
        {
            //inGameUI = activeUI;
            //inGameUI.GetComponent<UI_script>().CompletedLevel();
            //inGameUI.GetComponent<UI_script>().EndGame();
            SceneManager.LoadScene("Lose");
        }
        
        //activeUI.CompletedLevel();
    }
}
