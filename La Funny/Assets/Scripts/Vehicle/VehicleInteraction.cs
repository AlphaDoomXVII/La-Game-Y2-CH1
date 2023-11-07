using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VehicleInteraction : MonoBehaviour
{
    /*
    [Header("Game Objects")]
    public GameObject player;
    private Transform vehicle;
    public Transform playerCamera;
    public Camera vehicleCamera;
    public TMP_Text interactionText;

    public KeyCode interactionInput;
    bool inVehicle;
    
    private void Update()
    {
        
        Physics.Raycast(playerCamera.position, playerCamera.forward * 5f, out RaycastHit hitInfo);

        if (hitInfo.transform.GetComponent<VehicleSystem>() != null)
        {
            vehicle = hitInfo.transform;
            vehicleCamera = hitInfo.transform.gameObject.GetComponent<Camera>();

            interactionText.text = "Press" + interactionInput + "to enter vehicle";

            if (Input.GetKey(interactionInput) && inVehicle == false)
            {
                EnterVehicle();
                GetComponent<VehicleSystem>().enabled = true;
            }

            if (Input.GetKey(interactionInput) && inVehicle == true)
            {
                ExitVehicle();
                GetComponent<VehicleSystem>().enabled = false;
            }
        }
    }

    private void EnterVehicle()
    {
        player.SetActive(false);

        vehicleCamera.enabled = true;

        inVehicle = true;
    }

    private void ExitVehicle()
    {
        player.SetActive(true);
        player.transform.position = vehicle.right * 5f;

        vehicleCamera.enabled = false;

        inVehicle = false;
    }
    */
     
}
