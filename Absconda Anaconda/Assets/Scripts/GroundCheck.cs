using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public playerScript player;
    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            player.SetGrounded(true);
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            player.SetGrounded(false);
        }
    }
}
