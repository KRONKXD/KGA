using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager instance;
    public AudioSource soundPlayer;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Debug.LogError("Daugiau nei vienas SFXManager objektas");
    }

    public void PlaySound(AudioClip sound)
    {
        soundPlayer.PlayOneShot(sound);
    }

    // Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}
}
