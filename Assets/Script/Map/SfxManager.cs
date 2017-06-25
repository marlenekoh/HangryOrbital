﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxManager : MonoBehaviour
{

    public static AudioClip playerWalk;
    public static AudioClip playerJump;
    public static AudioClip gameOver;
    public static AudioClip playerWin;
    public static AudioClip enemyDie;
    public static AudioClip forwardSlash;
    public static AudioClip backwardSlash;
    public static AudioClip zap;

    public static bool muteSfx;

    static AudioSource audioSrc;

    // Use this for initialization
    void Start()
    {
        muteSfx = false;
        playerWalk = Resources.Load<AudioClip>("Walking");
        playerJump = Resources.Load<AudioClip>("Jumping");
        gameOver = Resources.Load<AudioClip>("GameOver");
        enemyDie = Resources.Load<AudioClip>("EnemyDie");
        forwardSlash = Resources.Load<AudioClip>("forwardSlash");
        backwardSlash = Resources.Load<AudioClip>("backwardSlash");
        zap = Resources.Load<AudioClip>("Zap");

        audioSrc = GetComponent<AudioSource>();

    }

    public static void PlaySound(string clip)
    {
       
        switch (clip)
        {
            case ("Walking"):
                if (!audioSrc.isPlaying)
                    audioSrc.PlayOneShot(playerWalk);
                break;
            case ("Jumping"):
                audioSrc.PlayOneShot(playerJump);
                break;
            case ("GameOver"):
                audioSrc.PlayOneShot(gameOver);
                break;
            case ("EnemyDie"):
                if (audioSrc.isPlaying)
                    audioSrc.Stop();
                audioSrc.PlayOneShot(enemyDie);
                break;
            case ("ForwardSlash"):
                if (audioSrc.isPlaying)
                    audioSrc.Stop();
                audioSrc.PlayOneShot(forwardSlash);
                break;
            case ("BackwardSlash"):
                if (audioSrc.isPlaying)
                    audioSrc.Stop();
                audioSrc.PlayOneShot(backwardSlash);
                break;
            case ("Zap"):
                if (audioSrc.isPlaying)
                    audioSrc.Stop();
                audioSrc.PlayOneShot(zap);
                break;
        }
    }

}