using UnityEngine;

public class SpeedPotion : Item
{
    public float speedMultiplier;
    public float duration;

    public void Use()
    {
        ApplySpeedBoost(GameObject.FindGameObjectWithTag("Player"));
    }

    void ApplySpeedBoost(GameObject player)
    {
        PlayerController playerController = player.GetComponent<PlayerController>();

        if (playerController != null)
        {
            playerController.ApplySpeedBoost(speedMultiplier, duration);
        }
    }
}
