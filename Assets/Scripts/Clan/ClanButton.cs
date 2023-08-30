using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClanButton : MonoBehaviour
{
    [SerializeField] private GameObject _clanDashboard;
    [SerializeField] private GameObject _clanSearch;
    [SerializeField] private ClanDashboard _clan;

    public void OnClick()
    {
        if (CharacterTest._char._clan == null)
        {
            _clanSearch.SetActive(!_clanSearch.activeSelf);
            _clanDashboard.SetActive(false);
        }
        else
        {
            _clanSearch.SetActive(false);
            _clanDashboard.SetActive(!_clanDashboard.activeSelf);
            _clan.UpdateClanInfo();
        }
    }
}
