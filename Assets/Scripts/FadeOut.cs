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
        yield return new WaitForSeconds(3);

        while (canvas.alpha < 1)
        {
            canvas.alpha += Time.deltaTime / 6;
            yield return null;
        }
        canvas.interactable = false;
        yield return null;
        yield return new WaitForSeconds(1);

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