using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    private List<ItemInInventory> _itemList = new List<ItemInInventory>(30);
    private InventoryWindow _invWindow;

    public Inventory(InventoryWindow window)
    {
        _invWindow = window;
        _invWindow.ClearButton.onClick.AddListener(ClearInventory);
    }

    public bool AddItem(ItemData item)
    {
        if (_itemList.Count == 30)
        {
            return false;
        }
        else
        {
            _itemList.Add(_invWindow.RenderItem(item));
            return true;
        }
    }

    public void ClearInventory()
    {
        _itemList.Clear();
        _invWindow.ClearInventory();
    }

    public bool CheckSpace()
    {
        if (_itemList.Count == 30)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public bool ReserveItem(ResourceType type)
    {
        List<ItemInInventory> reserveItemList = _itemList.FindAll(x => x._data.ResourceType == type);
        if (reserveItemList.Count > 0)
        {
            ItemInInventory reserveItem = reserveItemList.Find(x => x.isAvalible == true);
            if (reserveItem != null)
            {
                reserveItem.SetAvalible(false);
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    public bool UnreserveItem(ResourceType type)
    {
        List<ItemInInventory> reserveItemList = _itemList.FindAll(x => x._data.ResourceType == type);
        if (reserveItemList.Count > 0)
        {
            ItemInInventory reserveItem = reserveItemList.Find(x => x.isAvalible == false);
            if (reserveItem != null)
            {
                reserveItem.SetAvalible(true);
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    public void UnreserveAllItems()
    {
        List<ItemInInventory> reserveItemList = _itemList.FindAll(x => x.isAvalible == false);
        foreach(ItemInInventory item in reserveItemList)
        {
            item.SetAvalible(true);
        }
    }

    public void UseReservedItems()
    {
        List<ItemInInventory> reserveItemList = _itemList.FindAll(x => x.isAvalible == false);
        foreach(ItemInInventory item in reserveItemList)
        {
            item.Destroy();
            _itemList.Remove(item);
        }
    }
}
