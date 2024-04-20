using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Slime2 : MonoBehaviour
{

    public float smallDropChance;
    public float mediumDropChance;
    public float largeDropChance;

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

    public float damage = 1;
    void OnCollisionEnter2D(Collision2D col)
    {
        IDamageable damageable = col.collider.GetComponent<IDamageable>();
        //also check if collision is with player tag so slime doesn't damage each other
        bool isPlayer = col.gameObject.CompareTag("Player");

        if (damageable != null && isPlayer)
        {
            damageable.OnHit(damage);
        }
    }

    public void DropItems()
    {
        float dropChance = Random.value;
        if (dropChance <= largeDropChance)
        {
            DropLargeItem();
        }
        else if (dropChance <= mediumDropChance)
        {
            DropMediumItem();
        }
        else if (dropChance <= smallDropChance)
        {
            DropSmallItem();
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
}