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

    void OnCollisionEnter (Collision col)
    {
      if (collision.gameObject.tag == "Player")
      {
        FindObjectOfType<AudioManager>().Play("Ice");
      }
    }
}
