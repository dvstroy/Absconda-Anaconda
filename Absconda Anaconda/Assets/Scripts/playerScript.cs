using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerScript : MonoBehaviour
{
    [Header ("Controls")]
    public KeyCode forward, backward, left, right, jump, interact;
    public float jumpForce;
    public float runSpeed;
    public bool isGrounded;

    Animator anim;
    Rigidbody rb;
    Vector3 wantedDirection, camDirection;
    bool wantedJump;
    Vector3 debugEulerAngles;
    Vector3 resetPos = Vector3.zero;
    float cameraRotationY = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        isGrounded = true;
    }

    private void Update()
    {
        //R Resets player to 000
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reset();
        }
        if (Input.GetKey(KeyCode.LeftAlt) && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        var forwardIntent = 0;
        var horizontalIntent = 0;
        if (Input.GetKey(forward))
        {
            forwardIntent += 1;
        }
        if (Input.GetKey(backward))
        {
            forwardIntent -= 1;
        }
        if (Input.GetKey(left))
        {
            horizontalIntent -= 1;
        }
        if (Input.GetKey(right))
        {
            horizontalIntent += 1;
        }

        wantedDirection = new Vector3(horizontalIntent, 0, forwardIntent).normalized;


        if (Input.GetKeyDown(jump) && isGrounded)
        {
            wantedJump=true;
        }
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (wantedDirection.magnitude==0)
        {
           anim.SetBool("isRunning", false);
        }
        else
        {
            rb.transform.forward = Quaternion.Euler(0, cameraRotationY, 0) * wantedDirection;
            rb.MovePosition(rb.position + rb.transform.forward * runSpeed * Time.deltaTime);
            anim.SetBool("isRunning", true);
        }
        //camDirection = Quaternion.Euler(cameraObject.transform.rotation);
        if (wantedJump)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            anim.SetTrigger("jump");
            wantedJump = false;
        }
        
    }

    public void SetCameraForward(Vector3 forward)
    {
        cameraRotationY = Quaternion.FromToRotation(Vector3.forward, new Vector3(forward.x, 0, forward.z)).eulerAngles.y;
    }

    public void SetGrounded(bool grounded)
    {
        isGrounded = grounded;
        anim.SetBool("inAir", !grounded);
    }

    void Reset()
    {
        transform.position = resetPos;
        rb.velocity = new Vector3(0, 0, 0);
    }
}

