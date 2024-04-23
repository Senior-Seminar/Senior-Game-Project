using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    Animator animator;

    public float smallDropChance = 0.3f;
    public float mediumDropChance = 0.15f;
    public float largeDropChance = 0.05f;

    public GameObject smallHealthP;
    public GameObject smallAttackP;
    public GameObject smallShieldP;
    public GameObject smallSpeedP;

    public GameObject mediumHealthP;
    public GameObject mediumAttackP;
    public GameObject mediumShieldP;
    public GameObject mediumSpeedP;

    public GameObject largeHealthP;
    public GameObject largeAttackP;
    public GameObject largeShieldP;
    public GameObject largeSpeedP;

    //set health as property
    public float Health
    {
        set
        {
            health = value;
            if (health <= 0)
            {
                Defeated();
            }
        }
        get
        {
            return health;
        }
    }

    public float health = 1;

    public void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }

    public void Defeated()
    {
        animator.SetTrigger("Defeated");
        float dropChance = Random.value;
        Debug.Log("Defeated running");
        if (Random.value <= smallDropChance)
        {
            DropSmallItem();
        }
        else if (dropChance <= smallDropChance + mediumDropChance)
        {
            DropMediumItem();
        }
        else if (dropChance <= smallDropChance + mediumDropChance + largeDropChance)
        {
            DropLargeItem();
        }
    }

    void DropSmallItem()
    {
        int potionIndex = Random.Range(0, 4);
        GameObject[] smallPotions = { smallHealthP, smallAttackP, smallShieldP, smallSpeedP };
        GameObject potionDrop = smallPotions[potionIndex];
        if (potionDrop != null)
        {
            Instantiate(potionDrop, transform.position, Quaternion.identity);
        }
    }

    void DropMediumItem()
    {
        int potionIndex = Random.Range(0, 4);
        GameObject[] mediumPotions = { mediumHealthP, mediumAttackP, mediumShieldP, mediumSpeedP };
        GameObject potionDrop = mediumPotions[potionIndex];
        if (potionDrop != null)
        {
            Instantiate(potionDrop, transform.position, Quaternion.identity);
        }
    }

    void DropLargeItem()
    {
        int potionIndex = Random.Range(0, 4);
        GameObject[] largePotions = { largeHealthP, largeAttackP, largeShieldP, largeSpeedP };
        GameObject potionDrop = largePotions[potionIndex];
        if (potionDrop != null)
        {
            Instantiate(potionDrop, transform.position, Quaternion.identity);
        }
    }

    public void RemoveEnemy()
    {
        Destroy(gameObject);
    }

}
