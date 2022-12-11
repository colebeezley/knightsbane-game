using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSequence : MonoBehaviour
{

    public CanvasGroup canvas;
    public TextMesh pressStart;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("DeathCount", 0);
        StartCoroutine(RevealStart());
    }

    IEnumerator RevealStart()
    {
        yield return new WaitForSeconds(1.5f);
        yield return null;
    }

    public float max = 1f;
    public float speed = 5.0f;

    public SpriteRenderer sprite;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            QuitGame();
        }
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space)){
            StartCoroutine(wait());
        }
        sprite.color = new Color(1f, 1f, 1f, Time.time * speed);
    }
    IEnumerator wait()
    {
        while (canvas.alpha < 1)
        {
            canvas.alpha += Time.deltaTime;
            yield return null;
        }
        canvas.interactable = false;
        yield return null;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame()
    {
        // save any game data here
#if UNITY_EDITOR
        // Application.Quit() does not work in the editor so
        // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }
}
