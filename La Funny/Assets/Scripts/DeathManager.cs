using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DeathManager : MonoBehaviour
{
    [Header("Game Objects")]
    public GameObject player;
    public GameObject health;
    public GameObject stamina;
    public GameObject mainCamera;

    [Header("Death Screen")]
    public Image deathScreen;

    private HealthManager healthManager;
    private MovementSystem movementSystem;
    private CameraMovement cameraMovement;
    

    private void Awake()
    {
        healthManager = GetComponent<HealthManager>();
        movementSystem = player.GetComponent<MovementSystem>();
        cameraMovement = mainCamera.GetComponent<CameraMovement>();
        deathScreen.enabled = false;
    }

    private void Update()
    {
        if (healthManager.healthAmount <= 0)
        {
            deathScreen.enabled = true; 
            movementSystem.enabled = false;
            cameraMovement.enabled = false;
            health.SetActive(false);
            stamina.SetActive(false);

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
