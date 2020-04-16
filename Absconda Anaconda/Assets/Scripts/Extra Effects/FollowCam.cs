using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public Camera MainCam;

    void Update()
    {
        transform.LookAt (transform.position + MainCam.transform.rotation * Vector3.back, MainCam.transform.rotation * Vector3.up);
    }
}
