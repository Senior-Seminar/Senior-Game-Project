using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Slime2 : MonoBehaviour
{

    public float damage = 1;
    public float knockbackForce = 100f;
    public float moveSpeed = 100f;
    public DetectionZone detectionZone;
    Rigidbody2D rb;
    Animator animator;

    private bool isMoving = false;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        //Collider2D detectedObject0 = detectionZone.detectedObjs[0];
        if (detectionZone.detectedObjs.Count > 0)
        {
            //calculate direction towards target object
            Vector2 direction = (detectionZone.detectedObjs[0].transform.position - transform.position).normalized;

            //move towards detected obj
            rb.AddForce(direction * moveSpeed * Time.deltaTime);
            
            //rb.velocity = direction * moveSpeed *Time.deltaTime;
            IsMoving = true;
        }
        else
        {
            IsMoving = false;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Collider2D collider = col.collider;
        IDamageable damageable = collider.GetComponent<IDamageable>();
        //also check if collision is with player tag so slime doesn't damage each other
        bool isPlayer = collider.gameObject.CompareTag("Player");

        if (damageable != null && isPlayer)
        {
            //play attack animatiaon
            animator.SetTrigger("Attack");
            //*** slime attack with knockback

            Vector2 direction = (col.transform.position - transform.position).normalized;

            Vector2 knockback = direction * knockbackForce;

            damageable.OnHit(damage, knockback);
        }
    }

    public bool IsMoving
    {
        set
        {
            isMoving = value;
            animator.SetBool("isMoving", value);
        }
    }



}