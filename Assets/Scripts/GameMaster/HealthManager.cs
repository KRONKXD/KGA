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

    //audio reikalai
    //public AudioSource soundPlayer;
    public AudioClip loseHealth;
    //static AudioSource statSoundPlayer;
    static AudioClip statLoseHealth;

    public static void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0)
            currentHealth = 0;
        inGameUI.GetComponent<UI_script>().UpdateHealth();
        SFXManager.instance.PlaySound(statLoseHealth);
        if(currentHealth <= 0)
        {
            Time.timeScale = 0f;
            GameObject.Find("Menus").transform.GetChild(1).gameObject.SetActive(true);
        }
            
        //SceneManager.LoadScene("Lose");
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
        //statSoundPlayer = soundPlayer;
        statLoseHealth = loseHealth;
    }

    // Update is called once per frame
    //void Update()
    //{
        
    //}
}
