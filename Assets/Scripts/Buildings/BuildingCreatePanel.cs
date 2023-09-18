using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuildingCreatePanel : MonoBehaviour
{
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _time;
    [SerializeField] private Image _image;
    [SerializeField] private ResourceSlot _resourceSlotPrefab;
    [SerializeField] private Transform _resourceContainer;
    [SerializeField] private Button _buildButton;
    private Player _player;
    private BuildingData _data;
    private BuildingBase _building;
    private List<ResourceSlot> _resourceList = new List<ResourceSlot>();

    public void Init(Player player)
    {
        _player = player;
    }
    public void SetBuilding(BuildingData _data, BuildingBase building)
    {
        _building = building;
        _name.text = _data.Name;
        Open();
        if (_building.isBuilding)
        {
            _buildButton.gameObject.SetActive(false);
            int hour = building.buildTime / 3600;
            int minute = (building.buildTime - (hour * 3600)) / 60;
            int second = building.buildTime - ((hour * 3600) + (minute * 60));
            string hourString = hour < 10 ? "0" + hour.ToString() : hour.ToString();
            string minuteString = minute < 10 ? "0" + minute.ToString() : minute.ToString();
            string secondString = second < 10 ? "0" + second.ToString() : second.ToString();
            _time.text = $"{hourString}:{minuteString}:{secondString}";
            // _image.sprite = Image;
            this._data = _data;
            for (int i = 0; i < _data.BuildResources.Count; i++)
            {
                Instantiate(_resourceSlotPrefab, _resourceContainer).SetResource(_data.BuildResources[i], _data.RecourceAmount[i]);
            }
        }
        else
        {
            _buildButton.gameObject.SetActive(true);
            string hourString = _data.TimeHour < 10 ? "0" + _data.TimeHour.ToString() : _data.TimeHour.ToString();
            string minuteString = _data.TimeMinute < 10 ? "0" + _data.TimeMinute.ToString() : _data.TimeMinute.ToString();
            string secondString = _data.TimeSecond < 10 ? "0" + _data.TimeSecond.ToString() : _data.TimeSecond.ToString();
            _time.text = $"{hourString}:{minuteString}:{secondString}";
            // _image.sprite = Image;
            this._data = _data;
            for (int i = 0; i < _data.BuildResources.Count; i++)
            {
                _resourceList.Add(Instantiate(_resourceSlotPrefab, _resourceContainer).SetResource(_player, _data.BuildResources[i], _data.RecourceAmount[i]));
            }
        }

    }

    public void OnBuild()
    {
        foreach (ResourceSlot resource in _resourceList)
        {
            if (!resource.ready) return;
        }
        _buildButton.gameObject.SetActive(false);
        _player.Inventory.UseReservedItems();
        foreach (ResourceSlot resource in _resourceList)
        {
            resource.SetActive(false);
        }
        _building.StartBuilding();
    }

    public void SetActive(bool toggle)
    {
        if (toggle)
        {
            Open();
        }
        else
        {
            Close();
        }
    }

    private void Open()
    {
        foreach (Transform resource in _resourceContainer)
        {
            Destroy(resource.gameObject);
        }
        _resourceList.Clear();
        _player.Inventory.UnreserveAllItems();
        gameObject.SetActive(true);
    }

    public void Close()
    {
        _building.Reset();
        _building = null;
        _player.Inventory.UnreserveAllItems();
        gameObject.SetActive(false);
    }

    public void UpdateTime(int time)
    {
        int hour = time / 3600;
        int minute = (time - (hour * 3600)) / 60;
        int second = time - ((hour * 3600) + (minute * 60));
        string hourString = hour < 10 ? "0" + hour.ToString() : hour.ToString();
        string minuteString = minute < 10 ? "0" + minute.ToString() : minute.ToString();
        string secondString = second < 10 ? "0" + second.ToString() : second.ToString();
        _time.text = $"{hourString}:{minuteString}:{secondString}";
    }
}
