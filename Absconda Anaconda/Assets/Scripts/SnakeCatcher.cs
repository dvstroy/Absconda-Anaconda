using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SnakeCatcher : MonoBehaviour
{
    public GameObject completeLevelUI;

    public GameObject scoreText;
    //public AudioSource CollectSound;



    public int snakeRequired = 7;
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
                snakeCount++;
                scoreText.GetComponent<Text>().text = snakeCount + "/7";
                
                Destroy(collision.gameObject);
                
                //CollectSound.Play();
                
                EndGame();
            }
    }

    private void EndGame()
    {
        if(snakeCount == snakeRequired)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            completeLevelUI.SetActive(true);
        }
    }
}
