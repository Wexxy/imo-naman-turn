using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Movement : MonoBehaviour
{
    public CharacterController characterController;
    public Animator animator;
    public float speed = 3;
    float motionSmoothTime = 0.1f;

    private Rigidbody rb;
    private float gravity = 9.87f;
    private float verticalSpeed = 0;
    private bool isGrounded;
    private float jumpHeight = 2;
    public Transform target;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        // animator = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        float movement = Input.GetAxis("Horizontal");

        if (characterController.isGrounded)
        {
            verticalSpeed = 0;
            // animator.SetBool("Jump", false);
        }
        else
        {
            verticalSpeed -= gravity * Time.deltaTime;
        }
        Vector3 gravityMove = new Vector3(0, verticalSpeed, 0);
        if (GameManager.Instance.CurrentPlayer == Player.Player2)
        {
            Vector3 move = transform.forward * movement + transform.right * 0;
            characterController.Move(-speed * Time.deltaTime * move + gravityMove * Time.deltaTime);
            animator.SetFloat("Speed", -characterController.velocity.x, motionSmoothTime, Time.deltaTime);
            if (Input.GetKeyDown("space") && characterController.isGrounded)
            {
                verticalSpeed += 10;
                Vector3 characterJump = new Vector3(0, verticalSpeed, 0);
                characterController.Move(jumpHeight * Time.deltaTime * characterJump * Time.deltaTime);
            }

        }
    }
}
