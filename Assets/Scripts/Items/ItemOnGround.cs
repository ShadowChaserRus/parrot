using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemOnGround : ItemBase, IPickable
{
    [SerializeField] private SpriteRenderer _itemSprite;
    public ItemOnGround SetItem(ItemData data)
    {
        _data = data;
        _itemSprite.color = new Color((int)data.ResourceType == 0 ? 1f : 0f, (int)data.ResourceType == 1 ? 1f : 0f, (int)data.ResourceType == 2 ? 1f : 0f);
        return this;
    }
    public ItemData GetItemData()
    {
        Destroy(gameObject);
        return _data;
    }
    public object Pickup()
    {
        return this;
    }
}
