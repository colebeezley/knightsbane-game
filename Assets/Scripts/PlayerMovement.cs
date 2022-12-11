using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator animator;
    public AudioSource GrassRun;

    public float runSpeed = 40f;

    public float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    // Update is called once per frame
    void Update()
    {

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButton("Jump"))
        {
            jump = true;
        }

        if (!controller.getGrounded())
        {
            animator.SetBool("JumpCheck", true);
            GrassRun.enabled = false;
        }
        else
        {
            animator.SetBool("JumpCheck", false);

            if (Mathf.Abs(horizontalMove) > 0.01){
                GrassRun.enabled = true;
            } else {
                GrassRun.enabled = false;
            }

        }

        // if (Input.GetButtonDown("Crouch"))
        // {
        // 	crouch = true;
        // } else if (Input.GetButtonUp("Crouch"))
        // {
        // 	crouch = false;
        // }

    }

    void FixedUpdate()
    {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}