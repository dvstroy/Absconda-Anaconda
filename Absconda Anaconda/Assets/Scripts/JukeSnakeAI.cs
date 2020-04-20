using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class JukeSnakeAI : MonoBehaviour
{
    //Allows me to access the Navmesh in script
    private NavMeshAgent nav;
    //Accessing transforms required for pathing. targetLocation is to be assigned by setNewDestination
    private Vector3 targetLocation;
    //Where the snake idles, and where the snake will return to if the player gives up
    public Transform homeLocation;
    //Just so I can access this from other scripts in the game
    public static JukeSnakeAI instance;
    //A bool that triggers when the snake reaches targetLocation, can be removed but makes Liam's life easier until Liam brain ons
    public bool atDestination = true;
    //Literally just a garbage timer because I don't know how to make real timers
    private float snakeFear = 0;
    //Snake's maximum run distance
    public float radius = 20;
    //Tells the snake to have fear
    private bool isScared = false;
    public Transform playerPosition;
    //Tracks how many times the snake repaths
    [System.NonSerialized]
    public int repathCount = 0;

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
        //Realistically not needed, but I don't want to move things
        SnakeUpdate();
    }

    private void SnakeUpdate()
    {
        //Snake wonders whether it's scared
        SnakeThink();
        //Snake decides what it wants to do
        SnakeDecide();
    }

    private void SnakeThink()
    {
        if (isScared || Input.GetMouseButtonDown(0))
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
                repathCount++;
                setNewDestination();
            }
        } else
        {
            nav.SetDestination(homeLocation.position);
        }

        if(nav.remainingDistance <= 1)
        {
            atDestination = true;
            nav.isStopped = true;
        }
    }

    public void ScareSnake()
    {
        isScared = true;
    }
    public void SootheSnake()
    {
        isScared = false;
    }


    private void OnTriggerStay(Collider other)
    {
        snakeFear = 3;
    }


    private void setNewDestination()
    {
        var iterator = 0;
        targetLocation = playerPosition.position;
        while (Vector3.Distance(targetLocation, playerPosition.position) < 10)
        {
            iterator += 1;
            //Grabbing variables for calculations
            float realRadius = Random.Range(0, radius);
            float angle = Random.Range(0, 360) * Mathf.Deg2Rad;

            //Doing the math to convert angle and radius into X and Z coords
            float triangleX = realRadius * (Mathf.Sin(angle));
            float triangleZ = realRadius * (Mathf.Cos(angle));

            //Assigning that to the Vector3 targetLocation
            Vector3 testLocation = Vector3.zero;
            testLocation.x = triangleX;
            testLocation.z = triangleZ;
            testLocation.y = 50;

            if (Physics.Raycast(testLocation + transform.position, Vector3.down, out var hit, 100))
            {
                atDestination = false;
                targetLocation = hit.point;
            }
            
            if(iterator > 10)
            {
                float distancex = (gameObject.transform.position.x - playerPosition.transform.position.x) * 3;
                float distancez = (gameObject.transform.position.z - playerPosition.transform.position.z) * 3;

                testLocation.x = distancex;
                testLocation.z = distancez;
                testLocation.y = 50;

                if (Physics.Raycast(testLocation + transform.position, Vector3.down, out var zap, 100))
                {
                    atDestination = false;
                    targetLocation = zap.point;
                }

                break;
            }

        }

        //He goes
        nav.SetDestination(targetLocation);
        nav.isStopped = false;
    }
}
