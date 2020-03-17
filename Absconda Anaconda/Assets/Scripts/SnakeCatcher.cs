using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnakeCatcher : MonoBehaviour
{
    public Text snakeCatchable;

    // Start is called before the first frame update
    void Start()
    {
        snakeCatchable.text = ("Snake - Out of Range");
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Snake")
        {
            Debug.Log("SnakeEnter");
           snakeCatchable.text = ("Snake - In Range");
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Snake")
        {
            Debug.Log("SnakeExit");
            snakeCatchable.text = ("Snake - Out of Range");
        }
    }
}
