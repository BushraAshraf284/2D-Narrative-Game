using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
   
    public float runSpeed = 40f;
    public UnityEvent AnimatePush;
    //private variables
    private float horizontalMove;
    private bool jump;
    private bool push;
    private Vector2 relativePoint;
    private Transform Object;
    private bool right;

    //Other References
    private CharacterController2D characterController;
    private Animator animator;
    private bool _canPlayerMove;

    private void Awake()
    {
        characterController = GetComponent<CharacterController2D>();
        animator = GetComponent<Animator>();
        _canPlayerMove = true;
    }
    void Start()
    {
        characterController.OnLandEvent.AddListener(SetJump);
        Events.Player.TogglePlayerMovement += TogglePlayerMovement;
    }

    private void TogglePlayerMovement(bool canMove)
    {
        _canPlayerMove = canMove;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_canPlayerMove)
        {
            horizontalMove = 0f;
            animator.SetFloat("Speed", Math.Abs(horizontalMove));
            return;
        }
        horizontalMove = Input.GetAxis("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Math.Abs(horizontalMove));
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("isJump", true);
        }

        if (push)
        {
           
            
            animator.SetBool("isPushing",Math.Abs( horizontalMove)>1f);
            
           
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
    public void StartPushing()
    {
        push = true;
        
    }
    public void StopPushing()
    {
        push = false;
        animator.SetBool("isPushing", false);
    }

    

    private void OnDisable()
    {
        Events.Player.TogglePlayerMovement -= TogglePlayerMovement;
    }
}
