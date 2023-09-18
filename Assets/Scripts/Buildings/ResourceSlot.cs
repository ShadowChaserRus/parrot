using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResourceSlot : MonoBehaviour
{
    [SerializeField] private Image _resourceIcon;
    [SerializeField] private TMP_Text _amountText;
    [SerializeField] private Button _addButton, _removeButton;
    private Player _player;
    private ResourceType _resourceType;
    private int _requestedAmount;
    private int _currentAmount;
    public bool ready { get; private set; }

    public ResourceSlot SetResource(Player player, ResourceType type, int amount)
    {
        _player = player;
        _resourceType = type;
        _resourceIcon.color = new Color((int)type == 0 ? 1f : 0f, (int)type == 1 ? 1f : 0f, (int)type == 2 ? 1f : 0f);
        _requestedAmount = amount;
        _currentAmount = 0;
        _amountText.text = $"{_currentAmount}/{_requestedAmount}";
        return this;
    }

    public ResourceSlot SetResource(ResourceType type, int amount)
    {
        _resourceType = type;
        _resourceIcon.color = new Color((int)type == 0 ? 1f : 0f, (int)type == 1 ? 1f : 0f, (int)type == 2 ? 1f : 0f);
        _requestedAmount = amount;
        _currentAmount = _requestedAmount;
        _amountText.text = $"{_currentAmount}/{_requestedAmount}";
        SetActive(false);
        return this;
    }

    public void SetActive(bool toggle)
    {
        if (!toggle)
        {
            _addButton.gameObject.SetActive(false);
            _removeButton.gameObject.SetActive(false);
        }
    }
    public void OnAdd()
    {
        if (_currentAmount + 1 > _requestedAmount)
        {
            return;
        }
        else
        {
            if (_player.Inventory.ReserveItem(_resourceType))
            {
                _currentAmount++;
                ready = _currentAmount == _requestedAmount;
                _amountText.text = $"{_currentAmount}/{_requestedAmount}";
            }
        }
    }

    public void OnRemove()
    {
        if (_currentAmount - 1 >= 0)
        {
            if (_player.Inventory.UnreserveItem(_resourceType))
            {
                _currentAmount--;
                ready = _currentAmount == _requestedAmount;
                _amountText.text = $"{_currentAmount}/{_requestedAmount}";
            }
        }
        else
        {
            return;
        }
    }

}
