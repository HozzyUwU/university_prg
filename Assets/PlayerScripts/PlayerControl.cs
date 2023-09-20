using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    //private Rigidbody rb;
    public CharacterController controller;

    public float jumpVelocity;
    public float gravityScale;
    public float runningSpeed;

    private Vector3 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
        jumpVelocity = 8f;
        gravityScale = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = new Vector3(runningSpeed, moveDirection.y, 0f);
        if(controller.isGrounded)
        {
            if (Input.touchCount > 0)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    moveDirection.y = jumpVelocity;
                }
            }
        }
        

        moveDirection.y += Physics.gravity.y * gravityScale * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        //isGrounded = Physics.OverlapSphere(groundCheck.position, checkRadius, whatIsGround);
        //isGrounded = Physics.CheckSphere(groundCheck.position, checkRadius, whatIsGround);

    }
}
