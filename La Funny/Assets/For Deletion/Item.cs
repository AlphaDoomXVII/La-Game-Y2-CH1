using UnityEngine;

[CreateAssetMenu(fileName = "New Item",menuName = "Item/Create New Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public int itemId;
    public Sprite itemIcon;
    public int value;
}