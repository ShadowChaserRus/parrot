using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClanSearchDashboard : MonoBehaviour
{
    [SerializeField] private ClanTemplate _clanTemplatePrefab;
    [SerializeField] private Transform _clanListTransform;
    [SerializeField] private GameObject _clanSearchPanel;
    [SerializeField] private GameObject _clanPanel;

    public void Search()
    {
        if(CharacterTest._char._clan != null) return;
        ClearSearch();

        foreach(Clan clan in ClanTest.ClanList)
        {
            if(clan.GetRequirement(CharacterTest._char.GetLevel(), out Clan _clan))
            {
                Instantiate(_clanTemplatePrefab, _clanListTransform).SetTemplate(_clan, this);
            }
        }
    }

    public void ClearSearch()
    {
        foreach(Transform template in _clanListTransform)
        {
            Destroy(template.gameObject);
        }
    }

    public void JoinClan(Clan _clan)
    {
        _clan?.AddMember(CharacterTest._char);
        ClearSearch();
        _clanSearchPanel.SetActive(false);
        _clanPanel.SetActive(true);
    }
    
}
