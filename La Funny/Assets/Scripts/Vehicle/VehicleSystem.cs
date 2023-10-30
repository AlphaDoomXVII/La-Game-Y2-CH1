using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleSystem: MonoBehaviour
{
    [Header("Game Objects")]
    public GameObject player;
    public GameObject body;
    public GameObject turret;
    public Camera vehicleCamera;

    public Transform orientation;

    [Header("Movement")]
    public float moveSpeed;
    bool grounded;
    public float groundDrag;
    public LayerMask Ground;
    public float vehicleHeight;
    Vector3 moveDir;

    [Header("Input")]
    private float horizontalInput;
    private float verticalInput;

    [Header("Components")]
    Rigidbody rb;

    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, vehicleHeight * 0.5f + 0.2f, Ground);

        MovementInput();
        SpeedController();

        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 3;
    }

    private void FixedUpdate()
    {
        MoveVehicle();
    }

    private void MovementInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MoveVehicle()
    {
        transform.Rotate(new Vector3(0, horizontalInput, 0));

        moveDir = orientation.forward * verticalInput;

        if (grounded)
            rb.AddForce(10f * moveSpeed * moveDir.normalized, ForceMode.Force);

        else if (!grounded)
            rb.AddForce(10f * moveSpeed * moveDir.normalized, ForceMode.Force);
    }

    private void SpeedController()
    {

        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }
}
