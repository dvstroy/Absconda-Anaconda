using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public Text timerText;
    private float startTime;
    private bool finished = false;



    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {

        if (finished)
            return;


        float t = Time.time - startTime;

        string minutes = ((int)t / 60).ToString("00");
        string seconds = (t % 60).ToString("00");
        string miliseconds = ((int)(t * 100f) % 100).ToString("00");

        timerText.text = minutes + ":" + seconds + ":" + miliseconds;

        PlayerPrefs.SetString("YourTime", minutes + ":" + seconds + ":" + miliseconds);

        timerText.text = minutes + ":" + seconds + ":" + miliseconds;
    }

    public void Finish()
    {
        finished = true;
       
    }
}
