using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public GameObject followTarget, myCam;
    public Vector3 camZ;
    public float lerpSpeed, camXSensitivity, camYSensitivity;

    private void Start()
    {
        camZ = myCam.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0) * camXSensitivity );
        myCam.transform.Rotate(new Vector3(Input.GetAxis("Mouse Y"), 0, 0) * -camYSensitivity);
        myCam.transform.Translate(new Vector3(0, Input.GetAxis("Mouse Y") * -0.1f));
        transform.position = new Vector3(Mathf.Lerp(transform.position.x, followTarget.transform.position.x, lerpSpeed * Time.deltaTime), Mathf.Lerp(transform.position.y, followTarget.transform.position.y, lerpSpeed * Time.deltaTime), Mathf.Lerp(transform.position.z, followTarget.transform.position.z, lerpSpeed * Time.deltaTime));
        //myCam.transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, camZ.z);
        //transform.rotation = new Quaternion(0, Mathf.Lerp(transform.rotation.y, followTarget.transform.rotation.y, lerpSpeed * Time.deltaTime), 0, 0);
    }
}