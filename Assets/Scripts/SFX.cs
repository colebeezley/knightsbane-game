using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour
{
    public AudioSource Coin;
    public AudioSource Death;
    public AudioSource Intro;
    public AudioSource NextLevel;

    public float speed;

    PlayerMovement playermove;
    CharacterController2D controller;

    public void PlayCoin()
    {
        Coin.Play();
    }

    public void PlayDeath()
    {
        Death.Play();
    }

    public void PlayGrassRun()
    {
    }

    public void PlayIntro()
    {
        Intro.Play();
    }

    public void PlayNextLevel()
    {
        NextLevel.Play();
    }
}
