using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clan
{
    public string Name { get; private set; }
    public Sprite ClanIcon;
    private int _levelRequirements;
    private bool _isPrivate;
    private string[] _privateType = new string[2] { "Открытый", "Приватный" };
    public List<ClanMember> _clanMemberList { get; private set; } = new(100);

    public static Clan CreateClan(string name, bool privateSetting, Character clanMaster)
    {
        Clan newClan = new Clan(name, privateSetting, clanMaster);
        clanMaster.JoinClan(newClan);
        return newClan;
    }
    public Clan(string name, bool privateSetting, Character ClanMaster)
    {
        Name = name;
        _isPrivate = privateSetting;
        _clanMemberList.Add(new ClanMember(ClanMaster, MemberRank.Master));
    }

    public void GetClanInfo(out Sprite icon, out string name, out string leaderName, out int memberCount, out string privateSetting)
    {
        icon = ClanIcon;
        name = Name;
        leaderName = _clanMemberList.Find(x => x._rank == MemberRank.Master)._character.GetName();
        memberCount = _clanMemberList.Count;
        privateSetting = _isPrivate ? _privateType[1] : _privateType[0];
    }
    public void AddMember(Character _member)
    {
        _clanMemberList.Add(new ClanMember(_member, MemberRank.Peasant));
        _member.JoinClan(this);
    }

    public void SetRequirement(int level)
    {
        _levelRequirements = level > 1 ? level : 1;
    }

    public bool GetRequirement(int level, out Clan clan)
    {
        if (level >= _levelRequirements && !_isPrivate)
        {
            clan = this;
            return true;
        }
        else
        {
            clan = null;
            return false;
        }
    }

    public class ClanMember
    {
        public Character _character { get; private set; }
        public MemberRank _rank { get; private set; }
        public ClanMember(Character character, MemberRank rank)
        {
            _character = character;
            _rank = rank;
        }

    }


}

public enum MemberRank
{
    Master, Officer, Peasant
}
