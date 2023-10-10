using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour
{
    [SerializeField] private GameObject player;

    public float moveSpeed;
    public float moveSpeedMultiplier;
    public float groundDrag;
    public float playerHeight;
    public LayerMask Ground;
    bool grounded;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;
    float jumpInput;
    float sprintInput;

    Vector3 moveDir;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }
    private void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f * 0.2f, Ground);

        MovementInput();

        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0.5f;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovementInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        jumpInput = Input.GetAxisRaw("Jump");
        sprintInput = Input.GetAxisRaw("Fire3");
    }
    private void MovePlayer()
    {
        moveSpeedMultiplier = sprintInput > 0 ? 2 : 1;

        moveDir = orientation.forward * verticalInput + orientation.right * horizontalInput + orientation.up * jumpInput;

        rb.AddForce(moveDir.normalized * moveSpeed * moveSpeedMultiplier * 10f, ForceMode.Force);
    }

    private void SpeedController()
    {
        
            Vector3 flatVel = new Vector3(rb.velocity.x, rb.velocity.y, rb.velocity.z);

        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, limitedVel.y, limitedVel.z);
        }
    }
}
