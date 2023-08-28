using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClanMemberTemplate : MonoBehaviour
{
    [SerializeField] private Image _playerIcon;
    [SerializeField] private TMP_Text _playerName;
    [SerializeField] private TMP_Text _playerLevel;
    [SerializeField] private TMP_Text _playerRank;

    private string[] _rankName = new[] {"Master", "Officer", "Peasant"};

    public void SetTemplate(Clan.ClanMember player)
    {
        _playerIcon.sprite = null;
        _playerName.text = player._character.GetName();
        _playerLevel.text = player._character.GetLevel().ToString();
        _playerRank.text = _rankName[(int)player._rank];
    }
}
