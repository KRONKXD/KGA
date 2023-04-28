using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLoseManager : MonoBehaviour
{
    public static int deadEnemyNumber = 0;
    public int requiredEnemyNumber = 30;
    public static int reqEN;
    private int hp;
    // Start is called before the first frame update
    void Start()
    {
        reqEN = requiredEnemyNumber;
    }

    // Update is called once per frame
    void Update()
    {
        hp = HealthManager.GetHealthAmount();
        if (deadEnemyNumber > requiredEnemyNumber && hp > 0)
        {
            SceneManager.LoadScene("Win");
        }

        if (hp <= 0)
        {
            SceneManager.LoadScene("Lose");
        }
    }
}
