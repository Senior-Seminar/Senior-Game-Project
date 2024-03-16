using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Slime2 : MonoBehaviour
{
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
}