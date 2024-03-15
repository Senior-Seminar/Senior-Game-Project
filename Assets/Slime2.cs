using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Slime2 : MonoBehaviour, IDamageable
{
    Animator animator;
    Rigidbody2D rb;
    Collider2D physicsCollider;

    bool isAlive = true;


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
            if(_health <= 0)
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

    public bool Targetable {
        set
        {
            _targetable = value;

            rb.simulated = value;
            physicsCollider.enabled = value;
        }
        get
        {
            return _targetable;
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
    }


    public void OnHit(float damage, Vector2 knockback)
    {
        Health -= damage;

        //Apply force to slime enemy
        rb.AddForce(knockback);
    }

    public void Onhit(float damage)
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
}
