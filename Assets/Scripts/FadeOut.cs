using UnityEngine;
using System.Collections;

public class FadeOut : MonoBehaviour
{

    public CanvasGroup canvas;
    public void Start()
    {
        StartCoroutine(Fading());
    }

    IEnumerator Fading()
    {
        yield return new WaitForSeconds(3);

        while (canvas.alpha > 0)
        {
            canvas.alpha += Time.deltaTime / 6;
            yield return null;
        }
        canvas.interactable = false;
        yield return null;
        yield return new WaitForSeconds(2);
        Application.Quit();
    }

}