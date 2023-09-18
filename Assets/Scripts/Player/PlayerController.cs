using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private PlayerUI _playerUIPrebaf;
    [SerializeField] private Movement _movement;
    private PlayerUI _playerUI;
    public void Awake()
    {
        Init();
    }
    public void Init()
    {
        _playerUI = Instantiate(_playerUIPrebaf).Init(_player);
        _player.Init();
    }
    public void CloseSomething()
    {
        if (PlayerUI.Instance.Shop.gameObject.activeSelf)
            PlayerUI.Instance.Shop.Close();
        if (PlayerUI.Instance.BuildingCreatePanel.gameObject.activeSelf)
            PlayerUI.Instance.BuildingCreatePanel.SetActive(false);
            foreach(Transform go in PlayerUI.Instance.BuildingContainer)
            {
                go.gameObject.SetActive(false);
            }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            int x = _movement._currentCell.GetArrayX() + _movement.direction.x;
            int y = _movement._currentCell.GetArrayY() + _movement.direction.y;
            if (x < 0 || y < 0 || x > EarthGrid.Instance._cellGrid.GetLength(0) - 1 || y > EarthGrid.Instance._cellGrid.GetLength(1) - 1) return;
            if (EarthGrid.Instance._cellGrid[x, y]._item != null)
            {
                if (EarthGrid.Instance._cellGrid[x, y]._item.Pickup().GetType() == typeof(ItemOnGround))
                {
                    ItemOnGround groundItem = EarthGrid.Instance._cellGrid[x, y]._item as ItemOnGround;
                    if (_player.Inventory.CheckSpace())
                    {
                        _player.Inventory.AddItem(groundItem.GetItemData());
                        EarthGrid.Instance._cellGrid[x, y].SetAvalible();
                    }
                }
                else
                {
                    Debug.Log("Не предмет");
                }
            }
            else if (EarthGrid.Instance._cellGrid[x, y]._npc != null)
            {
                if (EarthGrid.Instance._cellGrid[x, y]._npc.GetType() == typeof(BuildingBase))
                {
                    EarthGrid.Instance._cellGrid[x, y]._npc.Interact(PlayerUI.Instance.BuildingCreatePanel, _player);
                }
                else
                {
                    EarthGrid.Instance._cellGrid[x, y]._npc.Interact(PlayerUI.Instance.Shop, _player);
                }

            }
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            PlayerUI.Instance.Inventory.SetActive();
        }
    }
}
