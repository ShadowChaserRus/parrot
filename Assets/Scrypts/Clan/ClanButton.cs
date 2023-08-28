using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClanButton : MonoBehaviour
{
    [SerializeField] private GameObject _clanDashboard;
    [SerializeField] private GameObject _clanSearch;
    [SerializeField] private ClanDashboard _clan;
    private bool _isPanelActive;

    public void OnClick()
    {
        if (CharacterTest._char._clan == null)
        {
            _clanSearch.SetActive(!_isPanelActive);
            _clanDashboard.SetActive(false);
        }
        else
        {
            _clanSearch.SetActive(false);
            _clanDashboard.SetActive(!_isPanelActive);
            _clan.UpdateClanInfo();
        }
        _isPanelActive = !_isPanelActive;
    }
}
