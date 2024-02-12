using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Slime : MonoBehaviour
{

    public float speed = 2f;
    private Transform player;
    private Rigidbody2D rb;
    private bool playerInRange = false; // Track if the player is within detection radius

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (playerInRange)
        {
            MoveTowardsPlayer();
        }
    }

    void MoveTowardsPlayer()
    {
        Vector2 direction = (player.position - transform.position).normalized;
        rb.MovePosition(rb.position + direction * speed * Time.deltaTime);
    }

    // Triggered when something enters the trigger zone
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Something entered the trigger zone");
        if (other.gameObject.CompareTag("Player"))
        {
            playerInRange = true;
            Debug.Log("Player entered the detection zone");
        }
    }


    // Triggered when something exits the trigger zone
    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Something exited the trigger zone");
        if (other.gameObject.CompareTag("Player"))
        {
            playerInRange = false;
            Debug.Log("Player exited the detection zone");
        }
    }

}
