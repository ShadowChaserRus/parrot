using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemTemplate : MonoBehaviour
{
    [SerializeField] private Image _itemIcon;
    [SerializeField] private TMP_Text _itemName;
    [SerializeField] private TMP_Text _price;
    private Player _player;
    private ItemData _item;

    public void SetTemplate(ItemData data, Player player)
    {
        // _itemIcon.sprite = data.InventoryIcon;
        _itemIcon.color = new Color((int)data.ResourceType == 0 ? 1f : 0f, (int)data.ResourceType == 1 ? 1f : 0f, (int)data.ResourceType == 2 ? 1f : 0f);
        _itemName.text = data.Name;
        _price.text = data.Price.ToString();
        _player = player;
        _item = data;
    }

    public void OnBuy()
    {
        if(_player.TryToSpendMoney(_item.Price) && _player.Inventory.CheckSpace())
        {
            _player.SpendMoney(_item.Price);
            _player.Inventory.AddItem(_item);
        }
    }
}
