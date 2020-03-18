using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SnakeAI : MonoBehaviour
{
    //Allows me to access the Navmesh in script
    private NavMeshAgent nav;
    //Accessing transforms required for pathing. targetLocation is to be assigned by setNewDestination
    private Vector3 targetLocation;
    //Where the snake idles, and where the snake will return to if the player gives up
    public Transform homeLocation;
    //Just so I can access this from other scripts in the game
    public static SnakeAI instance;
    //Simplifying some lines of code into a bool
    private bool playerInRange = false;
    //A bool that triggers when the snake reaches targetLocation, can be removed but makes Liam's life easier until Liam brain ons
    public bool atDestination = true;
    //Literally just a garbage timer because I don't know how to make real timers
    private float snakeFear = 0;
    //Snake's maximum run distance
    public float radius = 20;
    //Allows us, in Unity Editor, to track how many times the snake repaths
    [System.NonSerialized]
    public int rePathCount = 0;

    [SerializeField]
    private float FearTime;


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
        SnakeUpdate();
    }

    private void SnakeUpdate()
    {
        SnakeThink();
        SnakeDecide();
    }

    private void SnakeThink()
    {
        if (playerInRange || Input.GetMouseButtonDown(0))
        {
            snakeFear = FearTime;
        } else
        {
            snakeFear -= Time.deltaTime;
        }
    }

    private void SnakeDecide()
    {
        if (snakeFear > 0)
        {
            if (atDestination)
            {
                atDestination = false;
                rePathCount++;
                setNewDestination();
            }
        } else
        {
            nav.SetDestination(homeLocation.position);
        }

        if(nav.remainingDistance <= 1)
        {
            atDestination = true;
        }
    }

    private void setNewDestination()
    {
        //Grabbing variables for calculations
        float realRadius = Random.Range(0, radius);
        float angle = Random.Range(0, 360) * Mathf.Deg2Rad;

        //Doing the math to convert angle and radius into X and Z coords
        float triangleX = realRadius * (Mathf.Sin(angle));
        float triangleZ = realRadius * (Mathf.Cos(angle));

        //Assigning that to the Vector3 targetLocation
        targetLocation.x = triangleX;
        targetLocation.z = triangleZ;
        targetLocation.y = 0;

        //He goes
        nav.SetDestination(transform.position + targetLocation);
    }
}
