using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventoryWindow : MonoBehaviour
{
    [SerializeField] private Transform _itemContainer;
    [SerializeField] private ItemInInventory _itemPrebaf;
    public Button ClearButton;

    public void SetActive()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }

    public ItemInInventory RenderItem(ItemData item)
    {
        var newItem = Instantiate(_itemPrebaf, _itemContainer);
        newItem.SetItem(item);
        return newItem;
    }

    public void ClearInventory()
    {
        foreach (Transform item in _itemContainer)
        {
            Destroy(item.gameObject);
        }
    }

}
