using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Results : MonoBehaviour
{
    string yourScore;
    public Text Time;


    // Start is called before the first frame update
    void Start()
    {
        SetText();
        OnGUI();
    }

    // Update is called once per frame
    void Update()
    {

        
    }


    public void QuitGame()
    {
        Application.Quit();
    }
    public void RestartGame()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    void SetText()
    {
        yourScore = PlayerPrefs.GetString("YourTime");
        
    }

    void OnGUI()
    {
        Time.text = yourScore;
    }

}
