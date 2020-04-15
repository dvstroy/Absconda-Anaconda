using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class SnakeAnimations : MonoBehaviour
{
    //Making a variable for accessing the animator
    Animator anim;
    //Referencing the SnakeAI script so I can tell what the snake is doing
    private SnakeAI aIScript;
    private void Start()
    {
        //Accessing the animator on the child of the parent empty object that all scripts run on
        anim = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        //Toggling animations that rely on snake being scared of the player
        if (aIScript.isScared == true)
        {
            anim.SetBool("snakeIsScared", true);
        }
        else
        {
            anim.SetBool("snakeIsScared", false);
        }

        //Letting the snake have states where it can stay still
        if (aIScript.atDestination)
        {
            anim.SetBool("snakeAtDestination", true);
        }
        else
        {
            anim.SetBool("snakeAtDestination", false);
        }

        //If the snake is sitting still he might look around
        if (aIScript.isScared == false && aIScript.atDestination == true)
        {
            float look = Random.Range(1, 1000);
            if (look <= 50)
            {
                anim.SetTrigger("snakeCurious");
            }
        }
    }

    //When the snake is first disturbed it will leave it's sleeping animation permanently
    public void Spook()
    {
        anim.SetTrigger("snakeWaker");
    }
}
