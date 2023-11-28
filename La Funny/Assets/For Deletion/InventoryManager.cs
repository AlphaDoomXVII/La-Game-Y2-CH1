using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<Item> inventory = new();
    private Item item;

    [Header("Game Objects")]
    public GameObject inventoryUI;
    public GameObject inventoryItem;
    public Transform itemContent;
    public Transform playerCamera;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
            inventoryUI.SetActive(!inventoryUI.activeSelf);

        ListItems();

        Physics.Raycast(playerCamera.position, playerCamera.forward * 5f, out RaycastHit hitInfo);

        if (Input.GetKey(KeyCode.F) && hitInfo.transform.GetComponent<ItemController>() != null) 
        {
            Pickup();
        }
        
    }

    public void AddItem(Item item)
    {
        inventory.Add(item);
    }

    public void RemoveItem(Item item)
    {
        inventory.Remove(item);
    }

    public void ListItems()
    {
        foreach (Transform item in itemContent)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in inventory) 
        {
            GameObject obj = Instantiate(inventoryItem, itemContent);
            var itemName = obj.transform.Find("Item/itemName").GetComponent<Text>();
            var itemIcon = obj.transform.Find("Item/itemIcon").GetComponent<Image>();

            itemName.text = item.itemName;
            itemIcon.sprite = item.itemIcon;
        }
    }

    private void Pickup()
    {
        AddItem(item);
        Destroy(gameObject); 
    }
}