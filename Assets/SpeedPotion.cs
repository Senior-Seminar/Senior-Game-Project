using UnityEngine;

public class SpeedPotion : Item
{
    public float speedMultiplier;
    public float duration;

    public override void Use()
    {
        PlayerController playerController = player.GetComponent<PlayerController>();
        playerController.ApplySpeedBoost(speedMultiplier, duration);
    }
}
