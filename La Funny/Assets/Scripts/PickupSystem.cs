using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupClass : MonoBehaviour
{

    [SerializeField] private LayerMask PickupMask;
    [SerializeField] private Camera PlayerCamera;
    [SerializeField] private Transform PickupTarget;
    [Space]
    [SerializeField] private float PickupRange;
    private Rigidbody CurrentObject;

    private void Start()
    { PlayerCamera = GetComponent<Camera>(); }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {

            if (CurrentObject)
            {
                CurrentObject.useGravity = true;
                CurrentObject = null;
                return;
            }
            Debug.Log("bugRay");
            Debug.DrawRay(new Vector3(0.5f, 0.5f, 0f), PlayerCamera.transform.forward * 1, Color.red, 10);
            Ray CameraRay = PlayerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            if (Physics.Raycast(CameraRay, out RaycastHit HitInfo, PickupRange, PickupMask))
            {
                CurrentObject = HitInfo.rigidbody;
                CurrentObject.useGravity = false;
            }
        }
    }

   void FixedUpdate()
    {
       
    }
}