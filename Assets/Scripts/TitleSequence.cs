using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSequence : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("test");
        StartCoroutine(wait());
    }

    public float max = 1f;
    public float speed = 5.0f;

    public SpriteRenderer sprite;

    void Update()
    {
        sprite.color = new Color(1f, 1f, 1f, Mathf.PingPong(Time.time * speed, max));
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(6);
        yield return new WaitForSeconds(6);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
