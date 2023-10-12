using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupClass : MonoBehaviour

{
    [SerializeField] private LayerMask Pickuplayer;
    [SerializeField] private Camera PlayerCamera;
    [SerializeField] private float PickupRange;
    [SerializeField] private Transform hand;

    private Rigidbody CurrentObjectRigidbody;
    private Collider CurrentObjectCollider;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            
        }
        Ray PickupRay = new Ray(PlayerCamera.transform.position, PlayerCamera.transform.forward);   

        if(Physics.Raycast(PickupRay, out RaycastHit hitInfo, Pickuplayer))
        {

                if (CurrentObjectRigidbody)
                {

                }
                else
                {
                    CurrentObjectRigidbody = hitInfo.rigidbody;
                    CurrentObjectCollider = hitInfo.collider;

                    CurrentObjectRigidbody.isKinematic = true;
                    CurrentObjectCollider.enabled = false;

            }

        }

        if(CurrentObjectRigidbody)
        {
            CurrentObjectRigidbody.position = hand.position;
            CurrentObjectRigidbody.rotation = hand.rotation;
        }
    }
}