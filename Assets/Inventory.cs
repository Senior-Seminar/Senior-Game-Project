using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public List<Item> items = new List<Item>();
    public int space = 16;

    public GameObject inventoryUI;
    public GameObject inventorySlotsParent;
    public GameObject inventorySlotPrefab;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }
        instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleVisibility();
        }
    }

    public bool AddItem(Item item)
    {
        if (items.Count >= space)
        {
            Debug.Log("Not enough room.");
            return false;
        }

        items.Add(item);
        UpdateInventoryUI();

        return true;
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);
        UpdateInventoryUI();

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }

    public void ToggleVisibility()
    {
        bool newVisibility = !inventoryUI.activeSelf;
        inventoryUI.SetActive(newVisibility);
    }

    // Update the inventory UI to reflect the current items
    public void UpdateInventoryUI()
    {
        Debug.Log("Updating UI");
        // Destroy existing inventory slots
        foreach (Transform child in inventorySlotsParent.transform)
        {
            Destroy(child.gameObject);
        }

        int remainingSpace = space - items.Count;
        foreach (Item item in items)
        {
            GameObject slotObject = Instantiate(inventorySlotPrefab, inventorySlotsParent.transform);
            InventorySlot slot = slotObject.GetComponent<InventorySlot>();
            Debug.Log(item.itemName);
            slot.AddItem(item);
        }

        for (int i = 0; i < remainingSpace; i++)
        {
            GameObject slotObject = Instantiate(inventorySlotPrefab, inventorySlotsParent.transform);
            InventorySlot slot = slotObject.GetComponent<InventorySlot>();
        }

        Debug.Log("Updated");
    }


}
