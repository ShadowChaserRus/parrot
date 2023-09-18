using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItemData", menuName = "Items/Item Data", order = 1)]
public class ItemData : ScriptableObject
{
    public Sprite GroundSprite;
    public Sprite InventoryIcon;
    public int ID;
    public string Name;
    public ResourceType ResourceType = ResourceType.Branch;
    public int Price;
}

public enum ResourceType
{
    Branch,
    Feather,
    Fluff
}