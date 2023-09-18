using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private InventoryWindow _inventory;
    [SerializeField] private Shop _shop;
    [SerializeField] private TMP_Text _currency;
    [SerializeField] private BuildingCreatePanel _building;
    public Transform BuildingContainer;
    public InventoryWindow Inventory => _inventory;
    public Shop Shop => _shop;
    public BuildingCreatePanel BuildingCreatePanel => _building;
    private Player _player;
    public static PlayerUI Instance;
    public PlayerUI Init(Player player)
    {
        _player = player;
        if(Instance == null) Instance = this;
        return Instance;
    }
    public void UpdateCurrency(int value)
    {
        _currency.text = value.ToString();
    }

    public void Ressurect()
    {
        _player?.Ress();
    }
}
