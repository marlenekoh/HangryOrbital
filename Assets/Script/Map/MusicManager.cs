﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{

    public static AudioClip BGM1;
    public static AudioClip BGM2;

    public static bool muteMusic;

    static AudioSource audioSrc;

    // Use this for initialization
    void Start()
    {
        muteMusic = false;

        BGM1 = Resources.Load<AudioClip>("BGM1");
        BGM2 = Resources.Load<AudioClip>("BGM2");

        audioSrc = GetComponent<AudioSource>();
        audioSrc.volume = 0.5f;
    }

    private void FixedUpdate()
    {
        if (!muteMusic)
        {
            if (gameObject.scene.name == "Fight scene")
            {
                PlayBGM("BGM2");
            }
            else
            {
                PlayBGM("BGM1");
            }
        }
    }

    public static void PlayBGM(string bgm)
    {
        switch (bgm)
        {
            case ("BGM1"):
                if (!audioSrc.isPlaying)
                    audioSrc.PlayOneShot(BGM1);
                break;
            case ("BGM2"):
                if (!audioSrc.isPlaying)
                    audioSrc.PlayOneShot(BGM2);
                break;
                // can add more bgm for diff themes in future
        }
    }

    public static void StopBGM()
    {
        audioSrc.Stop();
    }
}
