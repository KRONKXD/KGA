using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public enum DifficultyLevel
    {
        Easy,
        Medium,
        Hard
    }
    [SerializeField] private Slider volumeSlider = null;
    [SerializeField] private Text volumeTextUI = null;
    private Button DifficultyButton;
    [SerializeField] private Difficulty difficulty;
    void Start()
    {
        
    }

    public void PlayGame(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

    public void volumeSlide(float volume)
    {
        volumeTextUI.text = volume.ToString("0.0");
    }

    //public DifficultyLevel selectedDifficulty = DifficultyLevel.Easy;

    public void SetDifficulty(int diff)
    {
        difficulty.Value = diff;


    }
    

}
