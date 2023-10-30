using UnityEngine;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour
{
    public List<Item> inventory = new List<Item>();

    // Add an item to the inventory
    public void AddItem(Item item)
    {
        Item existingItem = inventory.Find(i => i.itemId == item.itemId);
        if (existingItem != null)
        {
            existingItem.quantity += item.quantity;
        }
        else
        {
            inventory.Add(item);
        }
    }

    // Remove an item from the inventory
    public void RemoveItem(Item item)
    {
        Item existingItem = inventory.Find(i => i.itemId == item.itemId);
        if (existingItem != null)
        {
            existingItem.quantity -= item.quantity;
            if (existingItem.quantity <= 0)
            {
                inventory.Remove(existingItem);
            }
        }
    }
}