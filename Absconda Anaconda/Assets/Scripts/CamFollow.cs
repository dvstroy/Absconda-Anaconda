using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public GameObject followTarget, myCam;
    public float lerpSpeed, camXSensitivity, camYSensitivity;
    public playerScript player;
    public float maxMouseHeight = 50;
    public float minMouseHeight = -50;
    public float currentMouseHeight;

    private void Start()
    {
        currentMouseHeight = 0;
        currentMouseHeight += Input.GetAxis("Mouse Y");
    }

    void Update()
    {
        player.SetCameraForward(myCam.transform.forward);
        transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0) * camXSensitivity );
        var currentMouseChange = Input.GetAxis("Mouse Y");
        var intendedMouseHeight = currentMouseChange + currentMouseHeight;

        if (intendedMouseHeight > maxMouseHeight || intendedMouseHeight < minMouseHeight)
        {
            var extra = 0f;
            if (intendedMouseHeight > maxMouseHeight)
            {
                extra = intendedMouseHeight - maxMouseHeight;
            }
            if (intendedMouseHeight < minMouseHeight)
            {
                extra = intendedMouseHeight - minMouseHeight;
            }
            currentMouseChange -= extra;
        }

        
        
        myCam.transform.Rotate(new Vector3(currentMouseChange, 0, 0) * -camYSensitivity);
        myCam.transform.Translate(new Vector3(0, currentMouseChange * -0.1f, 0), Space.World);
        currentMouseHeight += currentMouseChange;

        transform.position = Vector3.Lerp(transform.position, followTarget.transform.position, 0.2f);

        
    }
}