using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class CharacterDamageable : MonoBehaviour, IDamageable
{
    public bool disableSimulation = false;

    Animator animator;
    Rigidbody2D rb;
    Collider2D physicsCollider;
    SpriteRenderer spriteRenderer;

    bool isAlive = true;

    private Transform playerTransform;

    //health property
    public float Health
    {
        set
        {
            if (value < _health)
            {
                animator.SetTrigger("hit");
            }

            _health = value;

            //trigger death when health is equal or below 0
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
            //disable movement when character 
            //if (disableSimulation)
            //{
            //    rb.simulated = false;
            //}
            rb.simulated = false;
            physicsCollider.enabled = value;
        }
    }

    public float _health = 3;
    public bool _targetable = true;

    public void Start()
    {
        animator = GetComponent<Animator>();
        //this is here to make sure isAlive boolean parameters is set to true when starting
        animator.SetBool("isAlive", isAlive);

        rb = GetComponent<Rigidbody2D>();
        physicsCollider = GetComponent<Collider2D>();

        //get player transform
        playerTransform = GameObject.FindWithTag("Player").transform;

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        //check if player is attack from left or right and switch animation on x axis accordingly
        CheckAttackDirection();
    }


    public void OnHit(float damage, Vector2 knockback)
    {
        Health -= damage;

        //Apply force 
        rb.AddForce(knockback, ForceMode2D.Impulse);
    }

    public void OnHit(float damage)
    {
        Health -= damage;
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
        //determine if player direction is left or right
        float direction = playerTransform.position.x < transform.position.x ? -1f : 1f;

        // Flip animation based on attack direction using rotation
        //using eular angle because for some reason player is twice the size of enemy slime and don't want to change scale
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