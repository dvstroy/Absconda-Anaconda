using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerScript : MonoBehaviour
{
    Animator anim;
    Rigidbody rb;
    CapsuleCollider cap;
    public GameObject cameraObject, cameraSorter;
    public float camSpeed;
    [Header ("Controls")]
    public KeyCode forward;
    public KeyCode backward, left, right, jump, crouch, altCrouch, interact;
    public float jumpForce;
    float movementSpeed;
    public float runSpeed, crouchSpeed;
    public bool isCrouching = false;
    Quaternion wantedDirection, camDirection;
    Vector3 debugEulerAngles;
    [Header("Wall jump force values")]
    public float wallJumpForce;
    public float wallJumpUpForce;
    Vector3 resetPos = new Vector3(0, 1, 0);
    bool jumpCheck = true;
    public bool grounded;
    [Header("Death Ragdoll")]
    public bool movementSmooth;

    //TIME STUFF
    public float timer;
    public Text timeDisplay;
    bool finished = false;

    // Start is called before the first frame update
    void Start()
    {
        wantedDirection = transform.rotation;
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        timer = 0;
        finished = false;
        grounded = true;

    }

    private void Update()
    {
        if(finished == false)
        {
            timer = timer + Time.deltaTime;
            timeDisplay.text = timer.ToString("F2");
        }
    }


    // Update is called once per frame
    void FixedUpdate()
    {

        if (Input.GetKeyDown(KeyCode.R))
        {
            Resetto();
        }
        if(Input.GetKey(KeyCode.LeftAlt) && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (Input.GetKey(crouch) || Input.GetKey(altCrouch))
        {
            if(grounded == true)
            {
             //   anim.SetBool("crouching", true);
                movementSpeed = crouchSpeed;
                isCrouching = true;
            }
        }
        else
        {
            if (grounded == true)
            {
              //  anim.SetBool("crouching", false);
                movementSpeed = runSpeed;
                isCrouching = false;
            }

        }
        if (Input.GetKey(forward))
        {
            wantedDirection = Quaternion.Euler(0, 0, 0);
        }
        if (Input.GetKey(backward))
        {
            wantedDirection = Quaternion.Euler(0, 180, 0);
        }
        if (Input.GetKey(left))
        {
            wantedDirection = Quaternion.Euler(0, 270, 0);
        }
        if (Input.GetKey(right))
        {
            wantedDirection = Quaternion.Euler(0, 90, 0);
        }
        if(Input.GetKey(forward) && Input.GetKey(right))
        {
            wantedDirection = Quaternion.Euler(0, 45, 0);
        }
        if (Input.GetKey(backward) && Input.GetKey(right))
        {
            wantedDirection = Quaternion.Euler(0, 135, 0);
        }
        if (Input.GetKey(backward) && Input.GetKey(left))
        {
            wantedDirection = Quaternion.Euler(0, 225, 0);
        }
        if (Input.GetKey(forward) && Input.GetKey(left))
        {
            wantedDirection = Quaternion.Euler(0, 315, 0);
        }
        if (Input.GetKey(forward) == false && Input.GetKey(backward) == false && Input.GetKey(left) == false && Input.GetKey(right) == false)
        {
           anim.SetBool("isRunning", false);
        }
        else
        {
            wantedDirection = Quaternion.Euler(0, wantedDirection.eulerAngles.y + cameraObject.transform.rotation.eulerAngles.y, 0);
            transform.Translate(Vector3.forward * movementSpeed * 0.1f);
           anim.SetBool("isRunning", true);
        }
        //camDirection = Quaternion.Euler(cameraObject.transform.rotation);
        if(movementSmooth == false)
        {
            if (grounded == true)
            {
                transform.rotation = wantedDirection;
            }
            else
            {
                transform.rotation = (Quaternion.Slerp(transform.rotation, wantedDirection, Time.deltaTime * camSpeed));
            }
        }
        else
        {
            transform.rotation = (Quaternion.Slerp(transform.rotation, wantedDirection, Time.deltaTime * camSpeed));
        }

        debugEulerAngles = wantedDirection.eulerAngles;
    }

    private void OnCollisionStay(Collision other)
    {
        if(other.gameObject.tag == "Ground")
        {
            grounded = true;
            if (Input.GetKeyDown(jump))
            {
                if(jumpCheck == true)
                {
                    rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
                    anim.SetTrigger("jump");
                    jumpCheck = false;
                    Debug.Log("jumpCheck is false");
                }
            }
            anim.SetBool("inAir", false);
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if(other.gameObject.tag == "Ground")
        {
            anim.SetBool("inAir", true);
            jumpCheck = true;
            Debug.Log("jumpCheck is true");
            grounded = false;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Resetter")
        {
            Resetto();
        }
    }

    void Resetto()
    {
        transform.position = resetPos;
        rb.velocity = new Vector3(0, 0, 0);
    }
}

