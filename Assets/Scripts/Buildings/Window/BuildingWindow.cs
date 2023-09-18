using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuildingWindow : MonoBehaviour
{
    [SerializeField] private Image _buildingImage;
    [SerializeField] private TMP_Text _buildingName;
    [SerializeField] private BuildingData _data;
    private Player _player;
    public void Open(Player player)
    {
        _player = player;
        gameObject.SetActive(true);
    }

    public void Close()
    {
        _player = null;
        gameObject.SetActive(false);
    }

    public void Save()
    {
        _player?.Save();
    }
}
