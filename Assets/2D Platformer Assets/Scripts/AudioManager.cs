using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource[]  soundEffects; 

    public AudioSource bgm, levelEndMusic;
    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySFX(int soundToPlay)
    {
        soundEffects[soundToPlay].Stop();

        soundEffects[soundToPlay].pitch = UnityEngine.Random.Range(0.9f, 1.1f);

        soundEffects[soundToPlay].Play();
    }
}
