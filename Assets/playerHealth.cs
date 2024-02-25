using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public Image healthBar;
    void Start()
    {
        health = maxHealth;
        UpdateHealthUI();
    }
    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        health = Mathf.Clamp(health, 0, maxHealth);
        UpdateHealthUI();

        if (health <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        Debug.Log("Player died!");
    }

    void UpdateHealthUI()
    {
        if (healthBar != null)
        {
            float healthPercent = (float)health / maxHealth;
            healthBar.transform.localScale = new Vector3(healthPercent, 1f, 1f);
            //healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 100);
        }
    }
}
