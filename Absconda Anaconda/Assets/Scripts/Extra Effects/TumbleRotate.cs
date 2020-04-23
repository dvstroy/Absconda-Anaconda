using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TumbleRotate : MonoBehaviour
{
    public float rotateSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotateSpeed, 0);
        transform.Rotate (new Vector3(0,0,Time.deltaTime*55));
    }
}
