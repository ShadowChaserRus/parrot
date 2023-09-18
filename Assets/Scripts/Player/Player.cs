using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    public SaveData _saveData;
    private Character _character = new Character("ShadowChaser", 1);
    [SerializeField] private Attack _attack;
    [SerializeField] private Health _health;
    [SerializeField] private Movement _movement;
     private Inventory _inventory;
    public Inventory Inventory => _inventory;
    private Currency _gold = new Currency("Gold", 100);
    
    public void Init()
    {
        _inventory = new Inventory(PlayerUI.Instance.Inventory);
        PlayerUI.Instance.UpdateCurrency(_gold.Info());
        PlayerUI.Instance.Shop.Init(this);
        PlayerUI.Instance.BuildingCreatePanel.Init(this);
    }
    public void TakeDamage(int amount)
    {
        _health.TakeDamage(amount, out bool isDead);
        Debug.Log("player");
    }

    public bool TryToSpendMoney(int amount)
    {
        return _gold.CheckAmount(amount);
    }
    public void SpendMoney(int amount)
    {
        _gold.Spend(amount);
        PlayerUI.Instance.UpdateCurrency(_gold.Info());
    }

    public void Save()
    {
        _saveData.SavePoint = _movement._currentCell.GetPosition(true);
    }

    public void Ress()
    {
        _movement.Teleport(_saveData.SavePoint);
    }
    
}
