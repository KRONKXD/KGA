using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.iOS;
using UnityEngine.UIElements;

public class UI_script : MonoBehaviour
{
    //// Start is called before the first frame update
    //void Start()
    //{

    //} 
    public GameObject paused_Menu;
    public GameObject buy1_Tower;
    public GameObject buy2_Tower;
    private int price1Tower;
    private int price2Tower;
    private int storedMoney;
    //private VisualElement root;
    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        Button buttonPause = root.Q<Button>("button_Pause");

        PausedMenu pausedMenu = paused_Menu.GetComponent<PausedMenu>();
        buttonPause.clicked += () => pausedMenu.Pause();

        Button buttonBuy1 = root.Q<Button>("buy1");
        buttonBuy1.clicked += () =>
        {

            if (MoneyManager.CurrentMoney >= price1Tower)
            {
                BuildManager.instance.SetTowerToBuild(buy1_Tower);
                BuildManager.buildMode = true;
            }
            else
            {
                Debug.Log("u broke lol");
            }
        };

        Button buttonBuy2 = root.Q<Button>("buy2");
        buttonBuy2.clicked += () =>
        {
            if (MoneyManager.CurrentMoney >= price2Tower)
            {
                BuildManager.instance.SetTowerToBuild(buy2_Tower);
                BuildManager.buildMode = true;
            }
            else
            {
                Debug.Log("u broke lol");
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
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        price1Tower = buy1_Tower.GetComponent<turret>().GetTowerPrice();
        price2Tower = buy2_Tower.GetComponent<turret>().GetTowerPrice();
        UpdateMoney(0);
        root = GetComponent<UIDocument>().rootVisualElement;
        root.Q<Label>("price1").text = price1Tower + " $";
        root.Q<Label>("price2").text = price2Tower + " $";
    }

    private void UpdateMoney(int change)
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        Label moneyLabel = root.Q<Label>("money");
        MoneyManager.CurrentMoney -= change;
        storedMoney = MoneyManager.CurrentMoney;
        moneyLabel.text = moneyLabel.text.Substring(0, 7) + MoneyManager.CurrentMoney + " $";
    }

    private void ToggleDemolishMode()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        Button buttonDemo = root.Q<Button>("demolish");
        if (buttonDemo.text == "Off")
        {
            buttonDemo.text = "On";
            buttonDemo.Q<VisualElement>().style.backgroundColor = Color.green;
            BuildManager.demoMode = true;
        }
        else
        {
            buttonDemo.text = "Off";
            buttonDemo.Q<VisualElement>().style.backgroundColor = Color.red;
            BuildManager.demoMode = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(storedMoney != MoneyManager.CurrentMoney)
        {
            UpdateMoney(0);
        }
    }
}
