using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;

    // Function to call when the item is used
    public virtual void Use()
    {
        // Use the item
        // Something may happen
    }

    // Remove the item from the inventory
    public void RemoveFromInventory()
    {
        Inventory.instance.RemoveItem(this);
    }
}
