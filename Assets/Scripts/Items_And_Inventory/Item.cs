using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public float pickupRadius = 2f; // Radius within which the player can pick up the item
    public KeyCode pickupKey = KeyCode.E; // Key to pick up the item
    protected bool isInRange; // Flag to check if the player is in range
    public GameObject player;

    public string itemName;
    public Sprite itemIcon;
    public int itemID;

    private void Update()
    {
        if (isInRange && Input.GetKeyDown(pickupKey))
        {
            Pickup();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = true; // Set the flag to true when the player enters the pickup radius
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = false; // Set the flag to false when the player exits the pickup radius
        }
    }

    private void Pickup()
    {
        Inventory playerInventory = player.GetComponent<Inventory>();
        if (playerInventory == null)
        {
            Debug.Log("Inventory is null");
            return;
        }
        player.GetComponent<Inventory>().AddItem(this);
        Destroy(gameObject);
    }
}
