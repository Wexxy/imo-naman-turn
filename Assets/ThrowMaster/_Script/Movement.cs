using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController characterController;
    public Animator animator;
    public float speed = 3;
    float motionSmoothTime = 0.1f;

    private Rigidbody rb;
    private float gravity = 9.87f;
    private float verticalSpeed = 0;
    private bool isGrounded;

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
        }
        else
        {
            verticalSpeed -= gravity * Time.deltaTime;
        }
        Vector3 gravityMove = new Vector3(0, verticalSpeed, 0);

        Vector3 move = transform.forward * movement + transform.right * 0;
        characterController.Move(speed * Time.deltaTime * move + gravityMove * Time.deltaTime);
        animator.SetFloat("Speed", characterController.velocity.z, motionSmoothTime, Time.deltaTime);
    }
    private void Aim() 
    {
        animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
    }
}
