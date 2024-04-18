using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// Takes and handles input and movement for a player character
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 150f;
    public float maxSpeed = 8f;
    public float idleFriction = 0.9f;

    Vector2 movementInput;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rb;
    Animator animator;


    private bool isMoving = false;
    bool canMove = true;


    public GameObject swordHitBox;
    Collider2D swordCollider;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        swordCollider = swordHitBox.GetComponent<Collider2D>();
    }

    private void FixedUpdate()
    {
        if (canMove == true && movementInput != Vector2.zero)
        {
            //player movement with force
            rb.AddForce(movementInput * moveSpeed * Time.deltaTime, ForceMode2D.Force);


            //Control whether looking left or right
            if(movementInput.x > 0)
            {
                spriteRenderer.flipX = false;
                gameObject.BroadcastMessage("IsFacingRight", true);
            } else if (movementInput.x < 0)
            {
                spriteRenderer.flipX = true;
                gameObject.BroadcastMessage("IsFacingRight", false);
            }

            IsMoving = true;
        } else {
            //No movement so interpolate velocity towards 0
            //rb.velocity = Vector2.Lerp(rb.velocity, Vector2.zero, idleFriction);
            IsMoving = false;
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


    void OnMove(InputValue movementValue)
    {
        movementInput = movementValue.Get<Vector2>();
    }

    void OnFire()
    {
        animator.SetTrigger("swordAttack");
    }

    public void LockMovement()
    {
        canMove = false;
    }

    public void UnlockMovement()
    {
        canMove = true;
    }


    

}
