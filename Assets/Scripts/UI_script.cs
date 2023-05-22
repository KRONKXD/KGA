using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class UI_script : MonoBehaviour
{
    //// Start is called before the first frame update
    //void Start()
    //{

    //} 

    private VisualElement root;
    public GameObject[] towers4sale;
    public bool[] unlocks;
    private GameObject Menus;
    //public GameObject buy1_Tower;
    //public GameObject buy2_Tower;
    //public GameObject buy3_Tower;
    //private int[] towerPrices = new int[4];
    private int price1Tower;
    private int price2Tower;
    private int price3Tower;
    private int price4Tower;
    private int price5Tower;
    private int storedMoney;
    private bool demoMode;

    private StyleColor oldColor;
    //private VisualElement root;

    private void Awake()
    {
        Menus = GameObject.Find("Menus");
    }
    private void OnEnable()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        Button buttonPause = root.Q<Button>("button_Pause");

        PausedMenu pausedMenu = Menus.GetComponent<PausedMenu>();
        buttonPause.clicked += () => pausedMenu.Pause();

        Button buttonBuy1 = root.Q<Button>("buy1");
        buttonBuy1.clicked += () =>
        {
            if (unlocks[0])
            {
                if (BuildManager.demoMode)
                {
                    ToggleDemolishMode();
                }
                if (MoneyManager.CurrentMoney >= price1Tower)
                {
                    //soundPlayer.PlayOneShot(build);
                    BuildManager.instance.SetTowerToBuild(towers4sale[0]);
                    BuildManager.buildMode = true;
                }
                else
                {
                    Debug.Log("u broke lol");
                }
            }
            else
            {
                if (MoneyManager.CurrentMoney >= price1Tower  )
                {
                    UpdateMoney(price1Tower  );
                    Unlock(buttonBuy1, root.Q<Label>("price1"), 0);
                }
                else
                {
                    Debug.Log("u broke lol");
                }
            }
        };

        Button buttonBuy2 = root.Q<Button>("buy2");
        buttonBuy2.clicked += () =>
        {
            if (unlocks[1])
            {
                if (BuildManager.demoMode)
                {
                    ToggleDemolishMode();
                }
                if (MoneyManager.CurrentMoney >= price2Tower)
                {
                    //soundPlayer.PlayOneShot(build);
                    BuildManager.instance.SetTowerToBuild(towers4sale[1]);
                    BuildManager.buildMode = true;
                }
                else
                {
                    Debug.Log("u broke lol");
                }
            }
            else
            {
                if (MoneyManager.CurrentMoney >= price2Tower  )
                {
                    UpdateMoney(price2Tower  );
                    Unlock(buttonBuy2, root.Q<Label>("price2"), 1);
                }
                else
                {
                    Debug.Log("u broke lol");
                }
            }
        };

        Button buttonBuy3 = root.Q<Button>("buy3");
        buttonBuy3.clicked += () =>
        {
            if (unlocks[2])
            {
                if (BuildManager.demoMode)
                {
                    ToggleDemolishMode();
                }
                if (MoneyManager.CurrentMoney >= price3Tower)
                {
                    //soundPlayer.PlayOneShot(build);
                    BuildManager.instance.SetTowerToBuild(towers4sale[2]);
                    BuildManager.buildMode = true;
                }
                else
                {
                    Debug.Log("u broke lol");
                }
            }
            else
            {
                if (MoneyManager.CurrentMoney >= price3Tower  )
                {
                    UpdateMoney(price3Tower  );
                    Unlock(buttonBuy3, root.Q<Label>("price3"), 2);
                }
                else
                {
                    Debug.Log("u broke lol");
                }
            }
        };

        Button buttonBuy4 = root.Q<Button>("buy4");
        buttonBuy4.clicked += () =>
        {
            if (unlocks[3])
            {
                if (BuildManager.demoMode)
                {
                    ToggleDemolishMode();
                }
                if (MoneyManager.CurrentMoney >= price4Tower)
                {
                    //soundPlayer.PlayOneShot(build);
                    BuildManager.instance.SetTowerToBuild(towers4sale[3]);
                    BuildManager.buildMode = true;
                }
                else
                {
                    Debug.Log("u broke lol");
                }
            }
            else
            {
                if (MoneyManager.CurrentMoney >= price4Tower  )
                {
                    UpdateMoney(price4Tower  );
                    Unlock(buttonBuy4, root.Q<Label>("price4"), 3);
                }
                else
                {
                    Debug.Log("u broke lol");
                }
            }
        };

        Button buttonBuy5 = root.Q<Button>("buy5");
        buttonBuy5.clicked += () =>
        {
            if (unlocks[4])
            {
                if (BuildManager.demoMode)
                {
                    ToggleDemolishMode();
                }
                if (MoneyManager.CurrentMoney >= price5Tower)
                {
                    //soundPlayer.PlayOneShot(build);
                    BuildManager.instance.SetTowerToBuild(towers4sale[4]);
                    BuildManager.buildMode = true;
                }
                else
                {
                    Debug.Log("u broke lol");
                }
            }
            else
            {
                if (MoneyManager.CurrentMoney >= price5Tower  )
                {
                    
                    Unlock(buttonBuy5, root.Q<Label>("price5"), 4);
                    UpdateMoney(price5Tower  );
                }
                else
                {
                    Debug.Log("u broke lol");
                }
            }
        };

        Button buttonDemo = root.Q<Button>("demolish");
        buttonDemo.clicked += () =>
        {
            ToggleDemolishMode();
            BuildManager.buildMode = false;
        };
    }

    private void Start()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        price1Tower = towers4sale[0].GetComponent<turret>().GetTowerPrice();
        price2Tower = towers4sale[1].GetComponent<turret>().GetTowerPrice();
        price3Tower = towers4sale[2].GetComponent<turret>().GetTowerPrice();
        price4Tower = towers4sale[3].GetComponent<turret>().GetTowerPrice();
        price5Tower = towers4sale[4].GetComponent<turret>().GetTowerPrice();
        
        //root = GetComponent<UIDocument>().rootVisualElement;
        //oldColor = root.Q<Button>().style.backgroundColor;
        root.Q<Label>("price1").text = price1Tower + " G";
        root.Q<Label>("price2").text = price2Tower + " G";
        root.Q<Label>("price3").text = price3Tower + " G";
        root.Q<Label>("price4").text = price4Tower + " G";
        root.Q<Label>("price5").text = price5Tower + " G";

        if (!unlocks[0])
        {
            root.Q<Button>("buy1").text = "Unlock";
           // root.Q<Button>("buy1").style.backgroundColor = Color.red;
            //root.Q<Label>("price1").text = price1Tower   + " G";
        }
        else
        {
            root.Q<VisualElement>("display1").style.backgroundImage = new StyleBackground(towers4sale[0].GetComponentInChildren<SpriteRenderer>().sprite);
        }

        if (!unlocks[1])
        {
            root.Q<Button>("buy2").text = "Unlock";
            //root.Q<Button>("buy2").style.backgroundColor = Color.red;
            //root.Q<Label>("price2").text = price2Tower   + " G";
        }
        else
        {
            root.Q<VisualElement>("display2").style.backgroundImage = new StyleBackground(towers4sale[1].GetComponentInChildren<SpriteRenderer>().sprite);
        }

        if (!unlocks[2])
        {
            root.Q<Button>("buy3").text = "Unlock";
            //root.Q<Button>("buy3").style.backgroundColor = Color.red;
            //root.Q<Label>("price3").text = price3Tower   + " G";
        }
        else
        {
            root.Q<VisualElement>("display3").style.backgroundImage = new StyleBackground(towers4sale[2].GetComponentInChildren<SpriteRenderer>().sprite);
        }

        if (!unlocks[3])
        {
            root.Q<Button>("buy4").text = "Unlock";
            //root.Q<Button>("buy4").style.backgroundColor = Color.red;
            //root.Q<Label>("price4").text = price4Tower   + " G";
        }
        else
        {
            root.Q<VisualElement>("display4").style.backgroundImage = new StyleBackground(towers4sale[3].GetComponentInChildren<SpriteRenderer>().sprite);
        }

        if (!unlocks[4])
        {
            root.Q<Button>("buy5").text = "Unlock";
            //root.Q<Button>("buy5").style.backgroundColor = Color.red;
            //root.Q<Label>("price5").text = price5Tower   + " G";
        }
        else
        {
            root.Q<VisualElement>("display5").style.backgroundImage = new StyleBackground(towers4sale[4].GetComponentInChildren<SpriteRenderer>().sprite);
        }

        UpdateMoney(0);

        demoMode = false;


    }

    private void UpdateMoney(int change)
    {
        //root = GetComponent<UIDocument>().rootVisualElement;
        Label moneyLabel = root.Q<Label>("money");
        MoneyManager.CurrentMoney -= change;
        storedMoney = MoneyManager.CurrentMoney;
        moneyLabel.text = moneyLabel.text.Substring(0, 2) + MoneyManager.CurrentMoney;
        CheckPrices();
    }

    private void CheckPrices()
    {
        string price;
        int numPrice;
        for(int i = 1; i <= towers4sale.Length; i++) 
        {
            price = root.Q<Label>("price" + i).text;
            price = price.Trim('G', '$');
            //Debug.Log(price);
            numPrice = int.Parse(price);
            if (numPrice <= storedMoney)
            {
                root.Q<Button>("buy" + i).style.backgroundColor = Color.green;
            }
            else
            {
                root.Q<Button>("buy" + i).style.backgroundColor = Color.red;
            }
        }
    }

    private void ToggleDemolishMode()
    {
        // VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        Button buttonDemo = root.Q<Button>("demolish");
        if (buttonDemo.text == "Off")
        {
            buttonDemo.text = "On";
            buttonDemo.Q<VisualElement>().style.backgroundColor = Color.green;
            BuildManager.demoMode = true;
            demoMode = true;
        }
        else
        {
            buttonDemo.text = "Off";
            buttonDemo.Q<VisualElement>().style.backgroundColor = Color.red;
            BuildManager.demoMode = false;
            demoMode = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (storedMoney != MoneyManager.CurrentMoney)
        {
            UpdateMoney(0);
        }
        if (demoMode != BuildManager.demoMode)
        {
            ToggleDemolishMode();
        }

    }

    public void UpdateHealth()
    {
        //VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        Label healthLabel = root.Q<Label>("health");
        int currentHealth = HealthManager.GetHealthAmount();
        healthLabel.text = healthLabel.text.Substring(0, 2) + currentHealth;
        //soundPlayer.PlayOneShot(loseHealth);
    }

    private void Unlock(Button button, Label price, int index)
    {
        unlocks[index] = true;
        button.text = "Buy";
        //button.style.backgroundColor = oldColor;
        //price.text = price1Tower + " G";
        switch (index)
        {
            case (0):
                price.text = price1Tower + " G";
                root.Q<VisualElement>("display1").style.backgroundImage = new StyleBackground(towers4sale[0].GetComponentInChildren<SpriteRenderer>().sprite);
                break;
            case (1):
                price.text = price2Tower + " G";
                root.Q<VisualElement>("display2").style.backgroundImage = new StyleBackground(towers4sale[1].GetComponentInChildren<SpriteRenderer>().sprite);
                break;
            case (2):
                price.text = price3Tower + " G";
                root.Q<VisualElement>("display3").style.backgroundImage = new StyleBackground(towers4sale[2].GetComponentInChildren<SpriteRenderer>().sprite);
                break;
            case (3):
                price.text = price4Tower + " G";
                root.Q<VisualElement>("display4").style.backgroundImage = new StyleBackground(towers4sale[3].GetComponentInChildren<SpriteRenderer>().sprite);
                break;
            case (4):
                price.text = price5Tower + " G";
                root.Q<VisualElement>("display5").style.backgroundImage = new StyleBackground(towers4sale[4].GetComponentInChildren<SpriteRenderer>().sprite);
                break;
        }
    }

    public void UpdateWave(int currentWave, int lastWave, int time)
    {
        //root = GetComponent<UIDocument>().rootVisualElement;
        Label wave = root.Q<Label>("wave");
        wave.text = "x " + currentWave + " / " + lastWave;
        StartCoroutine(WaveTimer(time));
    }

    IEnumerator WaveTimer(int time)
    {
        //Debug.Log("Incoming wave");
        Label waveTimer = root.Q<Label>("waveTimer");
        for (int i = time; i > 0; i--)
        {
            //Debug.Log("Priešas");
            //SpawnEnemy(enemyWave.enemyPrefabArray[i]);
            waveTimer.text = "Next wave in: " + i;
            yield return new WaitForSeconds(1);
        }
        waveTimer.text = "Wave incoming";
        //waveIndex++;

    }
}


