using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeSpook : MonoBehaviour
{

    private void OnTriggerEnter(Collider collision)
    {
        var snakeAI = collision.gameObject.GetComponent<SnakeAI>();
        if (snakeAI != null)
        {
            snakeAI.ScareSnake();
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        var snakeAI = collision.gameObject.GetComponent<SnakeAI>();
        if (snakeAI != null)
        {
            snakeAI.SootheSnake();
        }
    }
}
