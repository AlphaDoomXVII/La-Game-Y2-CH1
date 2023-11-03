using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPickup : MonoBehaviour
{
    public Transform playerCamera;
    public bool isPickedUp;

    private void Start()
    {
        playerCamera = Camera.main.transform;
    }

    private void Update()
    {
        if (isPickedUp)
            PickedUp();
    }

    private void PickedUp()
    {
        Vector3 resultingPosition = playerCamera.position + playerCamera.forward * 5f;
        transform.position = resultingPosition;
    }
}
