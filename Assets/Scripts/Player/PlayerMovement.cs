using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   
    public float runSpeed = 40f;

    //private variables
    private float horizontalMove;
    private bool jump;

    //Other References
    private CharacterController2D characterController;
    private Animator animator;
    private void Awake()
    {
        characterController = GetComponent<CharacterController2D>();
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Math.Abs(horizontalMove));
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("isJump", true);
        }
           


    }

    private void FixedUpdate()
    {
        // Move Character
        characterController.Move(horizontalMove * Time.fixedDeltaTime, false, jump );
        jump = false;

      

            

        
    }

    public void SetJump()
    {
        animator.SetBool("isJump", false);
    }
}
