using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    //Start of Variables
    
    
    //Simple Movement
    [SerializeField] private float moveSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed; 

    private Vector3 moveDirection; 
    private Vector3 velocity; 
    
    //Gravity-Grounded
    [SerializeField] private bool isGrounded;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float gravity; 

    //Jumping
    [SerializeField] private float jumpHeight;
    //Variables End

    //Start of References
    
    private CharacterController controller;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
       
        
    }

    private void Update()
    {
        Move();
    }

    //Movement Stanzas
    
    private void Move()
    {
        
        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);       

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        
        float moveZ = Input.GetAxis("Vertical");

        moveDirection = new Vector3(0, 0, moveZ);
        moveDirection = transform.TransformDirection(moveDirection);

        if(isGrounded)
        {
            if(moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
            {
                Walk();
            }
        
            else if(moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
            {
                Run();
            }

            else if(moveDirection == Vector3.zero)
            {
                Idle();
            }

            moveDirection *= moveSpeed;

            if(Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
        }

        controller.Move(moveDirection * Time.deltaTime);
         
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    //Equations
    private void Idle()
    {

    }

    private void Walk()
    {
       moveSpeed = walkSpeed;
    }
    
    private void Run()
    {
        moveSpeed = runSpeed;
    }

    private void Jump()
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
    }
}
