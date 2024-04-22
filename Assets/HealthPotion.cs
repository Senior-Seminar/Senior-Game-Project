using UnityEngine;

public class HealthPotion : Item
{
    public int healAmount;

    public override void Use()
    {
        CharacterDamageable playerController = player.GetComponent<CharacterDamageable>();
        playerController.ApplyHeal(healAmount);
    }
}
