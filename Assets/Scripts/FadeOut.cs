using UnityEngine;
using System.Collections;

public class FadeOut : MonoBehaviour
{

    public CanvasGroup canvas;
    public void Start()
    {
        Cursor.visible = false;
        StartCoroutine(Fading());
    }

    IEnumerator Fading()
    {
        Time.timeScale = 0.6f;
        yield return new WaitForSecondsRealtime(8);

        while (canvas.alpha < 1)
        {
            canvas.alpha += Time.deltaTime / 3;
            yield return null;
        }
        canvas.interactable = false;
        yield return null;
        yield return new WaitForSecondsRealtime(1);

        QuitGame();
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