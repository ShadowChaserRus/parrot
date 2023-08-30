using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClanCreatePanel : MonoBehaviour
{
    [SerializeField] private TMP_InputField _nameInput;
    [SerializeField] private Toggle _isPrivate;
    [SerializeField] private Button _confirmButton;
    [SerializeField] private GameObject _clanDashboard;
    [SerializeField] private GameObject _clanSearch;

    public void CreateNewClan()
    {
        if (CharacterTest._char._clan == null)
        {
            Clan.CreateClan(_nameInput.text, _isPrivate.isOn, CharacterTest._char);
            
        }
    }
}
