using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public Item item; // Reference to the item in this slot

    // Add item to the slot
    public void AddItem(Item newItem)
    {
        item = newItem;
        icon.sprite = newItem.itemIcon;
        icon.enabled = true;
    }

    // Remove item from the slot
    public void RemoveItem()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
    }

    public void OnUseItem()
    {
        Debug.Log("Tried to use " + item.name);
        if (item != null)
        {
            Debug.Log("Used " + item.name);
            item.Use();
            Inventory.instance.RemoveItem(item);
            RemoveItem();
        }
    }
}
