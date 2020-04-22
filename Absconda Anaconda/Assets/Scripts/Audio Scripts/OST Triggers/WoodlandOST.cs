using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodlandOST : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter (Collision collision)
    {
      if (collision.gameObject.tag == "AudioTrigger")
      {
        FindObjectOfType<AudioManager>().Play("Woodland");
      }
    }
}
