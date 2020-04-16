using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcrticOST : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {

    }

    void OnCollisionEnter (Collision collision)
    {
      if (collision.gameObject.tag == "AudioTrigger")
      {
        FindObjectOfType<AudioManager>().Play("Ice");
      }
    }
}
