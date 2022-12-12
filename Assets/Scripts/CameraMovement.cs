using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraMovement : MonoBehaviour
{

    public GameObject player;
    public CanvasGroup pauseMenu;
    public GameObject audio;
    public GameObject audio2;
    public bool paused = false;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.T)){
        //     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        // }
        // dev skip for testing purposes
        
        if (Input.GetKeyDown(KeyCode.Escape)){
            StartCoroutine(PauseMenu());
        }

        transform.position = new Vector3(player.transform.position.x + 3, transform.position.y, -10);
    }

    IEnumerator PauseMenu()
    {
        paused = !paused;
        if (paused){
            player.GetComponent<PlayerMovement>().enabled = false;
            audio.GetComponent<AudioSource>().volume = 0;
            audio2.GetComponent<AudioSource>().volume = 0;
            pauseMenu.alpha = 0.5f;
            Time.timeScale = 0;
        } else {
            player.GetComponent<PlayerMovement>().enabled = true;
            audio.GetComponent<AudioSource>().volume = 0.05f;
            audio2.GetComponent<AudioSource>().volume = 0.05f;
            pauseMenu.alpha = 0;
            Time.timeScale = 1;
        }
        yield return null;
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
