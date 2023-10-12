using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaManager : MonoBehaviour
{
    public GameObject player;

    [Header("Stamina Bar")]
    public Image staminaBar;
    public float staminaAmount = 200f;
    public float staminaRegenSpeed;
    public float sprintCooldown;
    bool sprintReady;

    private Movement Movement;

    private void Awake()
    {
        Movement = player.GetComponent<Movement>();
        sprintReady = true;
    }

    void Update()
    {

        if (Movement.moveSpeedMultiplier > 1)
        {
            StaminaDeplete(1);
        }

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            StaminaRegen(2);
        }

        if (staminaAmount <= 0)
        {
            sprintReady = false;

            staminaAmount = 0;

            Movement.moveSpeedMultiplier = 1;
            Invoke(nameof(SprintReset), sprintCooldown);
        }

        if (staminaAmount < 200 && Movement.moveSpeedMultiplier == 1 && sprintReady == true)
        {
            StaminaRegen(1);
        }
    }

    private void StaminaDeplete(float deplete)
    {
        staminaAmount -= deplete;
        staminaBar.fillAmount = staminaAmount / 200f;
    }

    private void StaminaRegen(float regen)
    {
        staminaAmount += regen;
        staminaAmount = Mathf.Clamp(staminaAmount, 0, 200);

        staminaBar.fillAmount = staminaAmount / 200f;
    }

    private void SprintReset()
    {
        sprintReady = true;
        staminaAmount = 2;
    }
}
