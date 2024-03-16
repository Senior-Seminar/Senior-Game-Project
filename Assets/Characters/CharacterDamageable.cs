using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class CharacterDamageable : MonoBehaviour, IDamageable
{
    Animator animator;
    Rigidbody2D rb;
    Collider2D physicsCollider;

    public float damage = 1;

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
        set
        {
            _targetable = value;

            //rb.simulated = value;
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

        //get player transform
        playerTransform = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        //check if player is attack from left or right and switch animation on x axis accordingly
        CheckAttackDirection();
    }


    public void OnHit(float damage, Vector2 knockback)
    {
        Health -= damage;

        //Apply force to slime enemy
        rb.AddForce(knockback);
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

        //flip slime animation based on attack direction
        if (direction < 0f)
        {
            //player on left
            animator.transform.localEulerAngles = new Vector3(0, 180, 1);

        }
        else
        {
            //player on right
            animator.transform.localEulerAngles = new Vector3(0, 0, 1);
        }
    }
}