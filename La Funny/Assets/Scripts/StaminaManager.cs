using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaManager : MonoBehaviour
{
    [Header("Game Objects")]
    public GameObject player;

    [Header("Stamina Bar")]
    public Image regenEffect;
    public Image staminaBar;
    public float staminaAmount = 250f;
    public float sprintCooldown;
    bool sprintReady;

    private MovementSystem movementSystem;

    private void Awake()
    { 
        movementSystem = player.GetComponent<MovementSystem>();
        sprintReady = true;
        staminaAmount = 250f;
        regenEffect.enabled = false;
    }

    void Update()
    {
        if (staminaAmount <= 0)
        {
            sprintReady = false;

            staminaAmount = 0;

            movementSystem.moveSpeedMultiplier = 1;
            Invoke(nameof(SprintReset), sprintCooldown);
        }
    }

    private void FixedUpdate()
    {
        if (movementSystem.sprintInput > 0 && movementSystem.verticalInput != 0 | movementSystem.horizontalInput != 0)
        {
            StaminaDeplete(1);
            movementSystem.moveSpeedMultiplier = 2;
        }
        else
        {
            movementSystem.moveSpeedMultiplier = 1;
        }

        if (staminaAmount < 250 && movementSystem.moveSpeedMultiplier == 1 && sprintReady == true)
        {
            StaminaRegen(1);
            regenEffect.enabled = true;
        }

        if (staminaAmount == 250 | movementSystem.moveSpeedMultiplier > 1)
        {
            regenEffect.enabled = false;
        }
    }

    private void StaminaDeplete(float deplete)
    {
        staminaAmount -= deplete;
        staminaBar.fillAmount = staminaAmount / 250f;
    }

    private void StaminaRegen(float regen)
    {
        staminaAmount += regen;
        staminaAmount = Mathf.Clamp(staminaAmount, 0, 250);

        staminaBar.fillAmount = staminaAmount / 250f;
    }

    private void SprintReset()
    {
        sprintReady = true;
        staminaAmount = 1;
    }
}
