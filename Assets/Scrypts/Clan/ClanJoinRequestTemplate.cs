using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClanJoinRequestTemplate : MonoBehaviour
{
    [SerializeField] private Image _playerIcon;
    [SerializeField] private TMP_Text _playerName;
    [SerializeField] private TMP_Text _playerLevel;

    public void SetTemplate(Character player)
    {
        _playerName.text = player._name;
        _playerLevel.text = player._level.ToString();
    }
}
