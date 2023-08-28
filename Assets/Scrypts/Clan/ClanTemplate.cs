using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClanTemplate : MonoBehaviour
{
    [SerializeField] private Image _clanIcon;
    [SerializeField] private TMP_Text _clanName;
    [SerializeField] private TMP_Text _clanLeaderName;
    [SerializeField] private TMP_Text _clanMemberCount;

    private Clan _clan;
    private ClanSearchDashboard _clanSearchDashboard;

    public void SetTemplate(Clan clan, ClanSearchDashboard dashboard)
    {
        clan.GetClanInfo(out Sprite icon, out string clanName, out string leaderName, out int memberCount, out string privateType);
        _clanIcon.sprite = icon;
        _clanName.text = clanName;
        _clanLeaderName.text = leaderName;
        _clanMemberCount.text = $"{memberCount}/100";
        _clan = clan;
        _clanSearchDashboard = dashboard;
    }

    public void JoinClan()
    {
        _clan?.AddMember(CharacterTest._char);
        _clanSearchDashboard.ClearSearch();
    }
}
