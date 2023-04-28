using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public int StartingMoney = 0;
    public static int CurrentMoney;

    // Start is called before the first frame update
    void Start()
    {
        CurrentMoney = StartingMoney;
    }

    //// Update is called once per frame
    //void Update()
    //{

    //}
}
