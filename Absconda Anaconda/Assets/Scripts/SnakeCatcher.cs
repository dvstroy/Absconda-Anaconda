using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SnakeCatcher : MonoBehaviour
{
    private int snakeCount = 0;
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
                snakeCount++;
                EndGame();
            }
    }

    private void EndGame()
    {
        if(snakeCount == 3)
        {
            SceneManager.LoadScene("Endgame", LoadSceneMode.Single);
        }
    }
}
