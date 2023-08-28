using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character
{
    public Fraction _fraction { get; private set; } = Fraction.Cockatiel;
    public string _name { get; private set; }
    public int _level { get; private set; }
    public Clan _clan { get; private set; }

    public Character(string name, int lvl)
    {
        _name = name;
        _level = lvl;
    }
    public string GetName()
    {
        return _name;
    }

    public void JoinClan(Clan clan)
    {
        _clan = clan;
    }

    public void LeaveClan()
    {
        _clan = null;
    }

    public void Setlvl(int lvl)
    {
        _level = lvl;
    }

    public int GetLevel()
    {
        return _level;
    }
}

public enum Fraction
{
    Cockatiel, Budgerigar
}
