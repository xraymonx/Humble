using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;
    [SerializeField]private GameObject humbleModel;

    private Animator animator; 
    private Rigidbody thisRigid;
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        controller = GetComponent<CharacterController>();
        thisRigid = GetComponent<Rigidbody>();
        // let the gameObject fall down
        //gameObject.transform.position = new Vector3(0, 5, 0);
    }

    void Update()
    {
        if (controller.isGrounded)
        {
            // We are grounded, so recalculate
            // move direction directly from axes

            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            
            moveDirection = transform.TransformDirection(moveDirection);

            moveDirection = moveDirection * speed;

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }

        // Apply gravity
        moveDirection.y = moveDirection.y - (gravity * Time.deltaTime);

        if((Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)){
            print("moving");
            animator.SetBool("isMoving", true);
        }
        else if(!controller.isGrounded) animator.SetBool("isMoving", false);
            
            
        if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)   humbleModel.transform.rotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0, moveDirection.z));
        // Move the controller
        controller.Move(moveDirection * Time.deltaTime);
    }
}