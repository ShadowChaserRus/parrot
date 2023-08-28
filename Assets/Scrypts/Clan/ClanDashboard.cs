using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClanDashboard : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _clanName;
    [SerializeField] private TMP_Text _memberCount;
    [SerializeField] private TMP_Text _clanPrivacity;
    [SerializeField] private ClanMemberTemplate _clanMemberTemplatePrefab;
    [SerializeField] private Transform _clanMemberListTransform;
    [SerializeField] private Button _leaveButton;
    [SerializeField] private Button _newClanButton;
    private void Start()
    {
        _leaveButton.onClick.AddListener(CharacterTest._char.LeaveClan);
        _leaveButton.onClick.AddListener(UpdateClanInfo);
        UpdateClanInfo();
    }

    public void UpdateClanInfo()
    {
        ClearMemberList();
        if (CharacterTest._char._clan != null)
        {
            _newClanButton.gameObject.SetActive(false);
            _leaveButton.gameObject.SetActive(true);
            CharacterTest._char._clan.GetClanInfo(out Sprite icon, out string name, out string leaderName, out int memberCount, out string privateType);
            _icon.sprite = icon;
            _clanName.text = name;
            _memberCount.text = $"{memberCount}/100";
            _clanPrivacity.text = privateType;
            GetMemberList(CharacterTest._char._clan);
        }
        else
        {
            _newClanButton.gameObject.SetActive(true);
            _leaveButton.gameObject.SetActive(false);
            _icon.sprite = null;
            _clanName.text = "Empty";
            _clanPrivacity.text = "Empty";
            _memberCount.text = $"0/100";
        }
    }

    public void GetMemberList(Clan clan)
    {
        foreach (var member in clan._clanMemberList)
        {
            Instantiate(_clanMemberTemplatePrefab, _clanMemberListTransform).SetTemplate(member);
        }

    }

    private void ClearMemberList()
    {
        foreach (Transform member in _clanMemberListTransform)
        {
            Destroy(member.gameObject);
        }
    }
}
