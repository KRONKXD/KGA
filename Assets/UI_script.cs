using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UI_script : MonoBehaviour
{
    //// Start is called before the first frame update
    //void Start()
    //{

    //} 
    public GameObject paused_Menu;
    
    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        Button buttonPause = root.Q<Button>("button_Pause");

        PausedMenu pausedMenu = paused_Menu.GetComponent<PausedMenu>();
        buttonPause.clicked += () => pausedMenu.Pause();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
