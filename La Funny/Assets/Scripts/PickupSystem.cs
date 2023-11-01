using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupClass : MonoBehaviour
{
    [Header("Game Objects")]
    public Transform playerCamera;
    private ObjectPickup currentObj;
    Rigidbody currentObjRB;

    [Header("Bools")]
    private bool canPickup;

    [Header("Input")]
    public KeyCode pickupInput;

    void Update()
    {
        if (Input.GetKeyDown(pickupInput) && Physics.Raycast(playerCamera.position, playerCamera.forward * 5f, out RaycastHit hitInfo))
        {
            currentObj = hitInfo.transform.GetComponent<ObjectPickup>();
            currentObj.isPickedUp = true;

            currentObjRB = hitInfo.rigidbody.GetComponent<Rigidbody>();
            currentObjRB.useGravity = false;
        }

        if (Input.GetKeyUp(pickupInput) && currentObj != null)
        {
            currentObj.isPickedUp = false;
            currentObj = null;

            currentObjRB.useGravity = true;
        }
    }

    void FixedUpdate()
    {
        Debug.DrawRay(playerCamera.position, playerCamera.forward * 5f, Color.red, 10);
        canPickup = Physics.Raycast(playerCamera.position, playerCamera.forward * 5f);
    }
}