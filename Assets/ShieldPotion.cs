using UnityEngine;

public class ShieldPotion : Item
{
    public float duration;

    public override void Use()
    {
        CharacterDamageable playerController = player.GetComponent<CharacterDamageable>();
        playerController.ActivateShield(duration);
    }
}
