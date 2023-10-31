using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleCamera : MonoBehaviour
{
    public Transform turret;

    [Header("Camera movement")]
    public float mouseSensitivity = 2f;
    float cameraVerticalRotation = 0f;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float inputX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float inputY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        cameraVerticalRotation -= inputY;
        cameraVerticalRotation = Mathf.Clamp(cameraVerticalRotation, -15f, 25f);
        transform.localEulerAngles = Vector3.right * cameraVerticalRotation;

        turret.Rotate(Vector3.up * inputX);
    }
}
