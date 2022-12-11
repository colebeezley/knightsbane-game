using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowFire : MonoBehaviour
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
            arrow.transform.Translate(8 * Time.deltaTime, 0, 0);
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            moveArrow=true;
        }
    }

}
