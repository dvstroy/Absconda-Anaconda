using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnakeCatcher : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Snake")
        {
            Debug.Log("SnakeEnter");
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Snake")
        {
            Debug.Log("SnakeExit");
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Snake")
            if (Input.GetMouseButtonDown(0))
            {
                Destroy(collision.gameObject);
            }
    }
}
