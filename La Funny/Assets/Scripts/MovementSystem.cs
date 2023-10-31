using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSystem : MonoBehaviour
{
    [SerializeField] 
    private GameObject player;

    [Header("Movement ground")]
    public float moveSpeed;
    public float moveSpeedMultiplier;
    public float moveSpeedAir;
    public float groundDrag;
    public float playerHeight;
    public LayerMask Ground;
    bool grounded;

    public Transform orientation;

    Vector3 moveDir;

    [Header("Jumping")]
    public float jumpForce;
    public float jumpCooldown;
    bool jumpReady;

    [Header("Crouching")]
    public float crouchSpeed;
    public float crouchYScale;
    public float startYScale;

    [Header("Input")]
    public KeyCode crouchInput = KeyCode.C;
    public KeyCode jumpInput = KeyCode.Space;
    public float horizontalInput;
    public float verticalInput;
    public float sprintInput;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        jumpReady = true;
        moveSpeedMultiplier = 1;
    }
    private void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, Ground);

        MovementInput();
        SpeedController();

        if (sprintInput > 0 && grounded)
            rb.drag = groundDrag * moveSpeedMultiplier;
        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 3;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovementInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        sprintInput = Input.GetAxis("Fire3");
    }
    private void MovePlayer()
    {
        if (Input.GetKeyDown(crouchInput) && moveSpeedMultiplier == 1) 
        {
            transform.localScale = new Vector3(transform.localScale.x, crouchYScale, transform.localScale.z);
            rb.AddForce(Vector3.down * 5f, ForceMode.Impulse);
        }

        if (Input.GetKeyUp(crouchInput))
        {
            transform.localScale = new Vector3(transform.localScale.x, startYScale, transform.localScale.z);
        }

        if (Input.GetKey(jumpInput) && jumpReady && grounded)
        {
            jumpReady = false;

            JumpController();

            Invoke(nameof(JumpReset), jumpCooldown);
        }

        moveDir = orientation.forward * verticalInput + orientation.right * horizontalInput;

        if (grounded)
            rb.AddForce(10f * moveSpeed * moveSpeedMultiplier * moveDir.normalized, ForceMode.Force);

        else if (!grounded)
            rb.AddForce(10f * moveSpeed * moveSpeedAir * moveDir.normalized, ForceMode.Force);

    }

    private void SpeedController()
    {

        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed * moveSpeedMultiplier;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void JumpController()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void JumpReset()
    {
        jumpReady = true;
    }
}
