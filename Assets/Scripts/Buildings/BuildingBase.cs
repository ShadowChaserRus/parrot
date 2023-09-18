using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class BuildingBase : MonoBehaviour, INPC
{
    protected string _name;
    [SerializeField] protected BuildingData _data;
    [SerializeField] protected SpriteRenderer _sprite;
    public bool isBuilding { get; private set; }
    private WaitForSeconds _second = new WaitForSeconds(1f);
    public int buildTime { get; private set; }
    private Coroutine _buildCoroutine;
    public bool isReady { get; private set; }
    private BuildingCreatePanel _createPanel;
    private BuildingWindow _window;
    private Player _player;

    public void Interact(object obj, Player player)
    {
        _player = player;
        BuildingCreatePanel createPanel = obj as BuildingCreatePanel;
        if (!isReady)
        {
            _createPanel = createPanel;
            createPanel.SetBuilding(_data, this);
        }
        else
        {
            if (_window == null)
            {
                Instantiate(_data._buildingWindow, PlayerUI.Instance.BuildingContainer);
            }
            else
            {
                _window.Open(player);
            }

        }
    }

    public void StartBuilding()
    {
        isBuilding = true;
        buildTime = _data.TimeHour * 3600 + _data.TimeMinute * 60 + _data.TimeSecond;
        _buildCoroutine = StartCoroutine(BuildTimer(buildTime));
    }

    private IEnumerator BuildTimer(int time)
    {
        while (!isReady)
        {
            yield return _second;
            buildTime--;
            _createPanel?.UpdateTime(buildTime);
            if (buildTime == 0)
            {
                isReady = true;
                _createPanel.Close();
                _window = Instantiate(_data._buildingWindow, PlayerUI.Instance.BuildingContainer);
                _window.Open(_player);
                StopCoroutine(_buildCoroutine);
                _buildCoroutine = null;
            }
        }
    }

    public void Reset()
    {
        _createPanel = null;
    }
}
