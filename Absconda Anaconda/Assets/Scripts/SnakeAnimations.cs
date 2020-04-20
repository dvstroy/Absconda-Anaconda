using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class SnakeAnimations : MonoBehaviour
{
    //Making a variable for accessing the animator
    Animator anim;
    private void Start()
    {
        //Accessing the animator on the child of the parent empty object that all scripts run on
        anim = GetComponentInChildren<Animator>();
    }

    public void LookAround()
    {
        //If the snake is sitting still he might look around
        float look = Random.Range(1, 1000);
        if (look <= 10)
        {
            anim.SetTrigger("snakeCurious");
        }
    }

    public void RunFast()
    {
        //Toggling animations that rely on snake being scared of the player
        anim.SetBool("snakeIsScared", true);
    }

    public void RunSlow()
    {
        anim.SetBool("snakeIsScared", false);
    }

    //When the snake is first disturbed it will leave it's sleeping animation permanently
    public void WakeUp()
    {
        anim.SetTrigger("snakeWaker");
    }

    public void StayingStill()
    {
        anim.SetBool("snakeAtDestination", true);
    }

    public void Moving()
    {
        anim.SetBool("snakeAtDestination", false);
    }
}
