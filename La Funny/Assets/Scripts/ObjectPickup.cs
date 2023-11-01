using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPickup : MonoBehaviour
{
    public Transform playerCamera;
    public bool isPickedUp;

    private void Update()
    {
        if (isPickedUp)
            PickedUp();
    }

    private void PickedUp()
    {
        Vector3 resultingPosition = transform.position;
        transform.position = resultingPosition;
    }
}
