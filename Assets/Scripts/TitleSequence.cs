using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSequence : MonoBehaviour
{

    public CanvasGroup canvas;

    // Start is called before the first frame update
    void Start()
    {
        
        Cursor.visible = false;
        Debug.Log("test");
        StartCoroutine(wait());
    }

    public float max = 1f;
    public float speed = 5.0f;

    public SpriteRenderer sprite;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        sprite.color = new Color(1f, 1f, 1f, Mathf.PingPong(Time.time * speed, max));
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(2.5f);
        while (canvas.alpha < 1)
        {
            canvas.alpha += Time.deltaTime / 3;
            yield return null;
        }
        canvas.interactable = false;
        yield return null;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
