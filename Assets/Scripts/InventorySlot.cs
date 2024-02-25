using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IPointerClickHandler, IDragHandler, IDropHandler
{
    public Image icon;
    public Item item; // Reference to the item in this slot

    // Add item to the slot
    public void AddItem(Item newItem)
    {
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
    }

    // Remove item from the slot
    public void RemoveItem()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
    }

    // Handle right-click to add item to inventory
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            Inventory.instance.AddItem(item);
            RemoveItem();
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Implement if dragging item is needed
    }

    public void OnDrop(PointerEventData eventData)
    {
        // Implement if dropping item is needed
    }
}
