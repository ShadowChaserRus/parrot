using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private Transform _shopList;
    [SerializeField] private ShopItemTemplate _shopItemTemplate;
    private Player _player;
    private InventoryWindow _playerInventory;

    public Shop Init(Player player)
    {
        _player = player;
        _playerInventory = PlayerUI.Instance.Inventory;
        return this;
    }
    public void Open(List<ItemData> itemList)
    {
        Clear();
        foreach(ItemData item in itemList)
        {
            Instantiate(_shopItemTemplate, _shopList).SetTemplate(item, _player);
        }
        gameObject.SetActive(true);
    }

    public void Close()
    {
        Clear();
        gameObject.SetActive(false);
    }

    private void Clear()
    {
        foreach (Transform item in _shopList)
        {
            Destroy(item.gameObject);
        }
    }
}
