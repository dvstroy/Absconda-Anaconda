using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SnakeCatcher : MonoBehaviour
{
    public GameObject completeLevelUI;
    public Text scoreText;
    public AudioSource CollectSound;
    public GameObject player;
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
          if (Input.GetMouseButtonDown(0) && player.GetComponent<playerScript>().enabled)
          {
              var anim = player.GetComponent<Animator>();
              anim.SetTrigger("catchSnake");
              snakeCount++;
              FunctionTimer.Create(() => Destroy(collision.gameObject), .5f);
              player.GetComponent<playerScript>().enabled = false;
              FunctionTimer.Create(() => player.GetComponent<playerScript>().enabled = true, .5f);
              //CollectSound.Play();
              EndGame();
          }
    }

    public void Update()
    {
        scoreText.text = snakeCount + " / " + snakeRequired;
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
