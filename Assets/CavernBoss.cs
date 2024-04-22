using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CavernBoss : MonoBehaviour
{
    public float damage = 2;
    public GameObject keyItem;
    void OnCollisionEnter2D(Collision2D col)
    {
        IDamageable damageable = col.collider.GetComponent<IDamageable>();
        //also check if collision is with player tag so cavern boss doesn't damage other enemies
        bool isPlayer = col.gameObject.CompareTag("Player");

        if (damageable != null && isPlayer)
        {
            damageable.OnHit(damage);
        }
    }

    public void DropKey() {
        Instantiate(keyItem, transform.position, Quaternion.identity);
    }
}
