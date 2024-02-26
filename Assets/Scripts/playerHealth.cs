using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f; // Maximum health value
    public float currentHealth; // Current health value
    public Image healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            // Calculate the fill amount based on current health
            float fillAmount = Mathf.Clamp01(currentHealth / maxHealth);
            healthBar.fillAmount = fillAmount;
        }
        else
        {
            Debug.LogError("Health bar Image not assigned to healthBar variable!");
        }
    }

    // Method to take damage
    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        currentHealth = Mathf.Max(currentHealth, 0f); // Ensure health doesn't go below zero
        UpdateHealthBar();
        Debug.Log("Player took damage. Current health: " + currentHealth);
    }
}