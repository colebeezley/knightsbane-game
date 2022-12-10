using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowFireDelay : MonoBehaviour
{

    public GameObject trigger;
    public GameObject arrow;

    private bool moveArrow = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (moveArrow)
        {
            arrow.transform.Translate(7 * Time.deltaTime, 0, 0);
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(FireArrow());
        }
    }

    IEnumerator FireArrow()
    {
        
        yield return new WaitForSeconds(Random.Range(1,20));
        moveArrow=true;
    }
}
