using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class EndTriger : MonoBehaviour
{
    //public GameMaster gameManager;
    static UIDocument inGameUI;
    public UIDocument activeUI;

    //currentHealth = startingHealth;
    //inGameUI = activeUI;
    //health=inGameUI.GetComponent<UI_script>().UpdateHealth();
    //static int currentHealth;
    //currentHealth -= damage;

    void OnTriggerEnter()
    {
        //int health = inGameUI.GetComponent<UI_script>().UpdateHealth();
        int currentHealth = HealthManager.GetHealthAmount();
        if (currentHealth == 0)
        {
            inGameUI = activeUI;
            inGameUI.GetComponent<UI_script>().CompletedLevel();
            inGameUI.GetComponent<UI_script>().EndGame();
            SceneManager.LoadScene("Lose");
        }
        else
        {
            inGameUI.GetComponent<UI_script>().EndGame();
        }
        //activeUI.CompletedLevel();
    }
}
