using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChestEnd : MonoBehaviour
{

    public GameObject Player;
    public CanvasGroup canvas;
    public Animator animator;
    public Rigidbody2D rb;
    public Collider2D collide;
    public AudioSource levelEnd;
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
            StartCoroutine(Fading());
        }
    }
        IEnumerator Fading()
    {
        levelEnd.enabled = true;
        animator.SetBool("LevelEnd", true);
        collide.enabled = false;
        rb.velocity = Vector2.zero;
        Player.GetComponent<PlayerMovement>().enabled = false;
        while (canvas.alpha < 1)
        {
            canvas.alpha += Time.deltaTime;
            yield return null;
        }
        canvas.interactable = false;
        yield return null;
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
