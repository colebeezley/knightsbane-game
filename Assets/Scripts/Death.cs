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
        collide.enabled = false;
        rb.velocity = Vector2.zero;
        Player.GetComponent<PlayerMovement>().enabled = false;
        animator.SetBool("UserDead", true);
        Time.timeScale = 0.4f;
        PlayDeath.Play();
        yield return new WaitForSecondsRealtime(1f);
        Time.timeScale = 1;
        Player.GetComponent<PlayerMovement>().enabled = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        yield return null;
    }
}
