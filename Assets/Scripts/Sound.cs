using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public AudioSource soundPlayer;
    public AudioClip hoverFx;
    public AudioClip clickFx;

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
        DontDestroyOnLoad(transform.gameObject);
    }
}
