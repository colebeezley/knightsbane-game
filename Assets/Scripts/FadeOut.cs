using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class FadeOut : MonoBehaviour
{

    public CanvasGroup canvas;
    public GameObject cameraMove;
    public void Start()
    {
        Cursor.visible = false;
        StartCoroutine(Fading());
    }

    IEnumerator Fading()
    {
        Time.timeScale = 0.6f;
        yield return new WaitForSecondsRealtime(12.3f);
        Destroy(cameraMove);
        yield return new WaitForSecondsRealtime(1);
        while (canvas.alpha < 1)
        {
            canvas.alpha += Time.deltaTime / 2.5f;
            yield return null;
        }
        canvas.interactable = false;
        yield return null;
        yield return new WaitForSecondsRealtime(1);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}