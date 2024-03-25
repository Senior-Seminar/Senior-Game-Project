using UnityEngine;
using UnityEngine.UI;

public class Damage : MonoBehaviour
{
    // Assuming PlayerHealth is the correct class name
    public PlayerHealth pHealth;
    public float damage = 20f; // Adjust the damage amount as needed

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (pHealth == null)
            {
                // Assuming the PlayerHealth script is on the same GameObject as the player
                pHealth = other.GetComponent<PlayerHealth>();
            }

            if (pHealth != null)
            {
                pHealth.TakeDamage(damage);
                Debug.Log("Damage dealt to player: " + damage);
            }
            else
            {
                Debug.LogError("PlayerHealth script not found on the player GameObject!");
            }
        }
    }
}