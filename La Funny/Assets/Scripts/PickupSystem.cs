using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupClass : MonoBehaviour
{
    [Header("Game Objects")]
    public Transform playerCamera;
    public LayerMask pickupObj;

    [Header("Bools")]
    private bool canPickup;
    private bool isPickup;

    [Header("Input")]
    public KeyCode pickupinput;

    private void Start()
    {

    }


    void Update()
    {
        if (canPickup == true)
        {
            if (Input.GetKey(pickupinput)) 
            {
                isPickup = true;

            }
        }
    }

    void FixedUpdate()
    {
        Debug.DrawRay(playerCamera.position, playerCamera.forward * 4f, Color.red, 10);
        canPickup = Physics.Raycast(playerCamera.position, playerCamera.forward * 4f, pickupObj);
    } 
}