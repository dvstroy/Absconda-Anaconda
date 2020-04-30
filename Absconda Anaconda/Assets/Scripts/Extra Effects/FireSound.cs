using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSound : MonoBehaviour
{
    public AudioSource SFX;

    void OnTriggerEnter(Collider collider)
    {
        SFX.Play();
    }

    void OnTriggerExit(Collider collider)
    {
        SFX.Stop();
    }
}
