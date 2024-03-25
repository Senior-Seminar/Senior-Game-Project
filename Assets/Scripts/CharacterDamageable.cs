using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.UI;

public class CharacterDamageable : MonoBehaviour, IDamageable
{
    public bool disableSimulation = false;
    public Image healthBar; // Reference to the health bar image

    Animator animator;
    Rigidbody2D rb;
    Collider2D physicsCollider;
    SpriteRenderer spriteRenderer;

    public bool isAlive = true;
    private Transform playerTransform;
    
    
    // Health property
    public float Health
    {
        set
        {
            if (value < _health)
            {
                animator.SetTrigger("hit");
            }

            _health = value;

            // Trigger death when health is equal or below 0
            if (_health <= 0)
            {
                animator.SetBool("isAlive", false);
                Targetable = false;
            }
        }
        get
        {
            return _health;
        }
    }

    public bool Targetable
    {
        get
        {
            return _targetable;
        }
        set
        {
            _targetable = value;
            // Disable movement when character is not targetable
            if (disableSimulation)
            {
                rb.simulated = false;
            }
            physicsCollider.enabled = value;
        }
    }

    public float _health = 3;
    public bool _targetable = true;

    public void Start()
    {

        animator = GetComponent<Animator>();
        animator.SetBool("isAlive", isAlive);

        rb = GetComponent<Rigidbody2D>();
        physicsCollider = GetComponent<Collider2D>();

        // Get player transform
        playerTransform = GameObject.FindWithTag("Player").transform;

        spriteRenderer = GetComponent<SpriteRenderer>();
        healthBar = GetComponent<Image>();
    }

    private void Update()
    {
        // Check if player is attacked from left or right
        CheckAttackDirection();
    }

    public void OnHit(float damage, Vector2 knockback)
    {
        // Reduce health and update the health bar
        Health -= damage;
        UpdateHealthBar(damage);
        // Apply force 
        rb.AddForce(knockback);
    }

    public void OnHit(float damage)
    {
        // Reduce health and update the health bar
        Health -= damage;
        UpdateHealthBar(damage);
    }

    void UpdateHealthBar(float damage)
    {
        if (healthBar != null)
        {
            if(Health == 0)
            {
                healthBar.fillAmount = 0;
            }

            else
            {
                // Calculate the new fill amount based on damage
                float newFillAmount = Mathf.Clamp01(healthBar.fillAmount - ((damage * 3)/10));
                healthBar.fillAmount = newFillAmount;
            }
            
        }
        else
        {
            Debug.LogError("Health bar Image not assigned to healthBar variable");
        }
    }

    public void MakeUntargetable()
    {
        rb.simulated = false;
    }

    public void OnObjectDestroyed()
    {
        Destroy(gameObject);
    }

    void CheckAttackDirection()
    {
        // Determine if player direction is left or right
        float direction = playerTransform.position.x < transform.position.x ? -1f : 1f;

        // Flip animation based on attack direction using rotation
        if (direction < 0f)
        {
            // Player is on the left, rotate 180 degrees to face left
            animator.transform.localEulerAngles = new Vector3(0, 180, 1);
        }
        else
        {
            // Player is on the right, reset rotation to face right
            animator.transform.localEulerAngles = new Vector3(0, 0, 1);
        }
    }
}
