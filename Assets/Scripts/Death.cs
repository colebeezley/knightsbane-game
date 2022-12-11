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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(DeathSequence());
        }
    }

    IEnumerator DeathSequence()
    {
        Player.GetComponent<PlayerMovement>().enabled = false;
        Time.timeScale = 0.5f;
        animator.SetBool("UserDead", true);
        PlayDeath.Play();
        yield return new WaitForSecondsRealtime(.8f);
        Time.timeScale = 1;
        Player.GetComponent<PlayerMovement>().enabled = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        yield return null;
    }
}
