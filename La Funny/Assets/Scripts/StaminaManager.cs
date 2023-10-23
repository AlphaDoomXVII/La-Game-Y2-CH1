using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaManager : MonoBehaviour
{
    public GameObject player;

    [Header("Stamina Bar")]
    public Image regenEffect;
    public Image staminaBar;
    public float staminaAmount = 250f;
    public float sprintCooldown;
    bool sprintReady;

    private Movement Movement;

    private void Awake()
    { 
        Movement = player.GetComponent<Movement>();
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

            Movement.moveSpeedMultiplier = 1;
            Invoke(nameof(SprintReset), sprintCooldown);
        }
    }

    private void FixedUpdate()
    {
        if (Movement.sprintInput > 0 && Movement.verticalInput != 0 | Movement.horizontalInput != 0)
        {
            StaminaDeplete(1);
            Movement.moveSpeedMultiplier = 2;
        }
        else
        {
            Movement.moveSpeedMultiplier = 1;
        }

        if (staminaAmount < 250 && Movement.moveSpeedMultiplier == 1 && sprintReady == true)
        {
            StaminaRegen(1);
            regenEffect.enabled = true;
        }

        if (staminaAmount == 250 | Movement.moveSpeedMultiplier > 1)
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
