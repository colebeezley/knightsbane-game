using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour
{
    public AudioSource Coin;
    public AudioSource Death;
    public AudioSource GrassRun;
    public AudioSource Intro;
    public AudioSource NextLevel;

    public void PlayCoin() {
        Coin.Play();
    }

    public void PlayDeath() {
        Death.Play();
    }

    public void PlayGrassRun() {
        GrassRun.Play();
    }

    public void PlayIntro() {
        Intro.Play();
    }

    public void PlayNextLevel() {
        NextLevel.Play();
    }
}
