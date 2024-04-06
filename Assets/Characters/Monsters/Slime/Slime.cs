using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Slime2 : MonoBehaviour
{

    public float damage = 1;
    public float knockbackForce = 100;

    void OnCollisionEnter2D(Collision2D col)
    {
        Collider2D collider = col.collider;
        IDamageable damageable = collider.GetComponent<IDamageable>();
        //also check if collision is with player tag so slime doesn't damage each other
        bool isPlayer = collider.gameObject.CompareTag("Player");

        if (damageable != null && isPlayer)
        {
            //*** slime attack with knockback

            Vector2 direction = (collider.transform.position - transform.position).normalized;

            Vector2 knockback = direction * knockbackForce;

            //collider.SendMessage("OnHit", swordDamage, knockback);
            damageable.OnHit(damage, knockback);
        }
    }
}