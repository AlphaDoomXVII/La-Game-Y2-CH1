using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DeathManager : MonoBehaviour
{
    [Header("Game Objects")]
    public GameObject player;
    public GameObject health;
    public GameObject stamina;
    public GameObject mainCamera;

    [SerializeField]
    private GameObject deathScreen;

    [Header("Death Screen")]
    public TMP_Text deathText;

    [SerializeField]
    private List<string> deathMessages;

    private HealthManager healthManager;
    private MovementSystem movementSystem;
    private CameraMovement cameraMovement;

    public bool hasRun = false;
    

    private void Awake()
    {
        healthManager = GetComponent<HealthManager>();
        movementSystem = player.GetComponent<MovementSystem>();
        cameraMovement = mainCamera.GetComponent<CameraMovement>();

        deathScreen.SetActive(false);
        deathText.enabled = false;

    }

    private void Update()
    {
        if (healthManager.healthAmount <= 0)
        {
            deathText.enabled = true;

            if (hasRun == false)
            {
                deathText.text = DeathMessages();

                hasRun = true;
            }
            

            movementSystem.enabled = false;
            cameraMovement.enabled = false;

            deathScreen.SetActive(true);
            health.SetActive(false);
            stamina.SetActive(false);

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    private string DeathMessages()
    {
        return deathMessages[Random.Range(0, deathMessages.Count)];
    }
}
