using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public static float maxHealth;
    public static float currentHealth;
    public Slider healthSlider;

    public static bool isDie = false;

    void Start()
    {
        maxHealth = 100;
        currentHealth = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
    }

    void Update()
    {
        healthSlider.value = currentHealth;
        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        isDie = true;
    }
}
