using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInInventory : ItemBase
{
    [SerializeField] private Image _itemIcon;
    public bool isAvalible { get; private set; } = true;
    private Color _color;
    public ItemInInventory SetItem(ItemData data)
    {
        _data = data;
        _color = new Color((int)data.ResourceType == 0 ? 1f : 0f, (int)data.ResourceType == 1 ? 1f : 0f, (int)data.ResourceType == 2 ? 1f : 0f);
        _itemIcon.color = _color;
        return this;
    }

    public void SetAvalible(bool toggle)
    {
        isAvalible = toggle;
        if (toggle)
        {
            _itemIcon.color = _color;
        }
        else
        {
            _itemIcon.color = _color / 2f;
        }
    }

    public void Destroy()
    {
        Destroy(this.gameObject);
    }
}
