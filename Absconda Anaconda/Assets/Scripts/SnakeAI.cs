using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SnakeAI : MonoBehaviour
{
    //Allows me to access the Navmesh in script
    private NavMeshAgent nav;
    //Accessing transforms required for pathing. targetLocation is to be assigned by setNewDestination
    public Vector3 targetLocation;
    //Allows the snake to be aware that the player is nearby and thus, avoid them
    public Transform playerLocation;
    //Where the snake idles, and where the snake will return to if the player gives up
    public Transform homeLocation;
    //Just so I can access this from other scripts in the game
    public static SnakeAI instance;
    //Simplifying some lines of code into a bool
    private bool playerInRange = false;
    //A bool that triggers when the snake reaches targetLocation, can be removed but makes Liam's life easier until Liam brain ons
    private bool atDestination = true;
    //Literally just a garbage timer because I don't know how to make real timers
    private int snakeFear = 0;
    //Snake's maximum run distance
    public float radius = 20;

    [System.NonSerialized]
    public int rePathCount = 0;




    private float realRadius;
    private float angle;


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        //assigns the Navmesh to the private NavMeshAgent
        nav = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        // snakeFear is purely a timer that tells the snake to keep running as long as the player is around. If this can be made more efficient, then do so.
        if(playerInRange == true)
        {
            snakeFear = 500;
        }
        else
        {
            if(snakeFear > 0)
            {
                snakeFear--;
            }
            else
            {
                nav.SetDestination(homeLocation.position);
            }
        }

        //Telling the snake to run when it would otherwise stop
        if(atDestination == true && snakeFear > 0)
        {
            setNewDestination();
            rePathCount++;
        }
    }


    private void setNewDestination()
    {
        Random.Range(0, radius) = realRadius;
        Random.Range(0, 360) = angle;

        Mathf.Asin(Random.Range(0,360))
    }
}
