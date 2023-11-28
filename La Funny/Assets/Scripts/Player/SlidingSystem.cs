using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingSystem : MonoBehaviour
{
    [Header("Game Objects")]
    public Transform orientation;
    public Transform playerObj;
    private Rigidbody rb;
    private MovementSystem ms;


    [Header("Sliding")]
    public float maxSlideTime;
    public float slideForce;
    private float slideTimer;

    public float slideYScale;
    private float startYScale;


    [Header("Input")]
    public KeyCode slideKey = KeyCode.C;
    private float horizontalInput;
    private float verticalInput;

    private bool sliding;


    
    private void Start()
    {
        // Get the Rigidbody component attached to this GameObject and assign it to the 'rb' variable.
        rb = GetComponent<Rigidbody>();

        // Get the MovementSystem component attached to this GameObject and assign it to the 'ms' variable.
        ms = GetComponent<MovementSystem>();

        // Get the initial local Y scale of the 'playerObj' and assign it to the 'startYScale' variable.
        startYScale = playerObj.localScale.y;
    }

    private void Update()
    {
        // Get the raw input values for horizontal and vertical axes.
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        // Check if the slide key is pressed, there is movement input, and the move speed multiplier is greater than 1.
        if (Input.GetKeyDown(slideKey) && (horizontalInput != 0 || verticalInput != 0 && ms.moveSpeedMultiplier > 1))
            StartSlide();

        // Check if the slide key is released and the player is currently sliding.
        if (Input.GetKeyUp(slideKey) && sliding)
            StopSlide();
    }

    private void FixedUpdate()
    {
        // Check if the player is currently sliding.
        if (sliding)
            SlidingMovement(); // Execute the sliding movement logic.
    }

    private void StartSlide()
    {
        // Set the sliding flag to true.
        sliding = true;

        // Adjust the player's local scale to create a sliding effect.
        playerObj.localScale = new Vector3(playerObj.localScale.x, slideYScale, playerObj.localScale.z);

        // Apply a downward impulse force to simulate the start of a slide.
        rb.AddForce(Vector3.down * 5f, ForceMode.Impulse);

        // Set the initial value for the slide timer.
        slideTimer = maxSlideTime;
    }


    private void SlidingMovement()
    {
        // Calculate the movement direction based on player input and orientation.
        Vector3 inputDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        // Apply a force in the calculated direction to simulate sliding movement.
        rb.AddForce(inputDirection.normalized * slideForce, ForceMode.Force);

        // Check if the slide time has expired, and if so, stop the slide.
        if (slideTimer <= 0)
            StopSlide();
    }


    private void StopSlide()
    {
        // Set the sliding flag to false to indicate that the player has stopped sliding.
        sliding = false;

        // Reset the player's local scale to its original Y scale, ending the sliding effect.
        playerObj.localScale = new Vector3(playerObj.localScale.x, startYScale, playerObj.localScale.z);
    }
 



}
