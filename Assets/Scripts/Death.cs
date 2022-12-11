using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{

    public GameObject Player;
    public AudioSource PlayDeath;
    public Animator animator;
    public Rigidbody2D rb;
    public Collider2D collide;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(DeathSequence());
            // if death-scripted object collides with player, start sequence
        }
    }

    IEnumerator DeathSequence()
    {
        // set persistent deaths

        collide.enabled = false;
        // disable collision with arrow so char isn't pushed around

        rb.velocity = Vector2.zero;
        // remove all velocity, prevents screen movement after death

        Player.GetComponent<PlayerMovement>().enabled = false;
        // keep player from moving around after death

        animator.SetBool("UserDead", true);
        // start death animation

        Time.timeScale = 0.4f;
        // slow down time for cinematic appeal

        PlayDeath.Play();
        // play death sound

        yield return new WaitForSecondsRealtime(1f);

        int currDeaths = PlayerPrefs.GetInt("DeathCount");
        currDeaths++;
        PlayerPrefs.SetInt("DeathCount", currDeaths);
        
        Time.timeScale = 1;
        Player.GetComponent<PlayerMovement>().enabled = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        // reset needed timing and scripts, reload scene

        yield return null;
    }
}
