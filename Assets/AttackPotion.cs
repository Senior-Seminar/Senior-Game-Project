using UnityEngine;

public class AttackPotion : Item
{
    public int damageIncrease;
    public float duration;

    public override void Use()
    {
        CharacterDamageable playerController = player.GetComponent<CharacterDamageable>();
        playerController.SetDamageMultiplier(damageIncrease, duration);
    }
}
