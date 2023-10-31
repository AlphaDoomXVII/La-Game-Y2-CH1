using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    [Header("Game Objects")]
    public GameObject player;

    [Header("Health Bar")]
    public Image regenEffect;
    public Image healthBar;
    public float healthAmount = 250f;

    private void Awake()
    {
        
    }

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
