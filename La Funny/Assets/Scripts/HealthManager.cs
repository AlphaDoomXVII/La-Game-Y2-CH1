using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public GameObject player;

    [Header("Stamina Bar")]
    public Image regenEffect;
    public Image healthBar;
    public float healthAmount = 250f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            HealthDeplete(20);
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            HealthRegen(20);
        }
    }

    private void HealthDeplete(float deplete)
    {
        healthAmount -= deplete;
        healthBar.fillAmount = healthAmount / 250f;
    }

    private void HealthRegen(float regen)
    {
        healthAmount += regen;
        healthAmount = Mathf.Clamp(healthAmount, 0, 250);

        healthBar.fillAmount = healthAmount / 250f;
    }
}
