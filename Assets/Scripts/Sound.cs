using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    private AudioSource soundPlayer;
    public AudioClip hoverFx;
    public AudioClip clickFx;
   // [SerializeField] private Difficulty difficulty;

    public void HoverSound()
    {
        soundPlayer.PlayOneShot(hoverFx);
    }
    public void ClickSound()
    {
        soundPlayer.PlayOneShot(clickFx);
    }
    public void Awake() 
    {
        soundPlayer = GameObject.Find("BackgroundAudio").GetComponent<AudioSource>();
        //DontDestroyOnLoad(transform.gameObject);
    }
}
