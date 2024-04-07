using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordHitBox : MonoBehaviour
{
    public float swordDamage = 1f;
    public float knockbackForce = 15f;
    
    
    public Collider2D swordCollider;

    public Vector3 faceRight = new Vector3 (0.119f, -0.09f, 0);
    public Vector3 faceLeft = new Vector3 (-0.119f, -0.09f, 0);

    void Start()
    {
        if (swordCollider == null)
        {
            Debug.LogWarning("Sword Collider not set");
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        col.collider.SendMessage("OnHit", swordDamage);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        IDamageable damagableObject = collider.GetComponent<IDamageable>();

        if(damagableObject != null)
        {
            //calculate direction between character and slime
            Vector3 parentPosition = transform.parent.position;

            Vector2 direction = (Vector2)(collider.gameObject.transform.position - parentPosition).normalized;
            Vector2 knockback = direction * knockbackForce;

            //collider.SendMessage("OnHit", swordDamage, knockback);
            damagableObject.OnHit(swordDamage, knockback);
        }
        //else
        //{
        //    Debug.LogWarning("Collider does not implement IDamageable interface");
        //}
    }

    void IsFacingRight(bool isFacingRight)
    {
        if (isFacingRight)
        {
            gameObject.transform.localPosition = faceRight;
        } else
        {
            gameObject.transform.localPosition = faceLeft;
        }
    }

    
}