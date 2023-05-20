using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PausedMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    private GameObject pausedMenuUI;
    [SerializeField] private VolumeLevel volumeLevel;
    private void Start()
    {
        pausedMenuUI = this.transform.GetChild(0).gameObject;
        GameObject.Find("BackgroundAudio").GetComponent<AudioSource>().volume = volumeLevel.volume;
        GameObject.Find("GameMaster").GetComponent<AudioSource>().volume = volumeLevel.volume;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pausedMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    public void Pause()
    {
        pausedMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    public void volumeSlide()
    {
        //volumeTextUI.text = volume.ToString("0.0");
        volumeLevel.volume = GetComponentInChildren<Slider>().value;
        GameObject.Find("BackgroundAudio").GetComponent<AudioSource>().volume = volumeLevel.volume;
        GameObject.Find("GameMaster").GetComponent<AudioSource>().volume = volumeLevel.volume;
    }

    public void SetSlider()
    {
        GetComponentInChildren<Slider>().value = volumeLevel.volume;
    }
}
