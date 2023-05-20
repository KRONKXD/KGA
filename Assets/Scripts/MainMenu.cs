using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    //[SerializeField] private Slider volumeSlider = null;
    //[SerializeField] private Text volumeTextUI = null;
    //private Button DifficultyButton;
    [SerializeField] private Difficulty difficulty;
    [SerializeField] private VolumeLevel volumeLevel;
    void Start()
    {
        GameObject.Find("BackgroundAudio").GetComponent<AudioSource>().volume = volumeLevel.volume;
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

    public void volumeSlide()
    {
        //volumeTextUI.text = volume.ToString("0.0");
        volumeLevel.volume = GetComponentInChildren<Slider>().value;
        GameObject.Find("BackgroundAudio").GetComponent<AudioSource>().volume = volumeLevel.volume;
    }

    public void SetSlider()
    {
        GetComponentInChildren<Slider>().value = volumeLevel.volume;
    }

    //public DifficultyLevel selectedDifficulty = DifficultyLevel.Easy;

    public void SetDifficulty(int diff)
    {
        difficulty.Value = diff;
    }
    

}
